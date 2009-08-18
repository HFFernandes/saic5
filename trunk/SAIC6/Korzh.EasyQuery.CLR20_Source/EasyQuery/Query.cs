namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using System.Text;
    using System.Xml;

    [Serializable, ToolboxBitmap(typeof(Query))]
    public class Query : Component, ISerializable
    {
        private DataModel.TableList extraTables;
        private string filePath;
        private SqlFormats formats;
        private int lastParamNum;
        private DataModel model;
        private SqlOptions options;
        private bool paramMode;
        private QResult qresult;
        private string queryDescription;
        private string queryName;
        private RootPredicate root;
        private string serializationQueryXml;
        private bool storeModelPath;
        private bool storeOptions;
        private DataModel.TableList usedTables;

        public event ColumnsChangedEventHandler ColumnsChanged;

        public event ConditionsChangedEventHandler ConditionsChanged;

        public event SortOrderChangedEventHandler SortOrderChanged;

        static Query()
        {
            Expression.RegisterType(ConstExpr.STypeName, new ConstExprCreator());
            Expression.RegisterType(SubQueryExpr.STypeName, new SubQueryExprCreator());
            Expression.RegisterType(EntityAttrExpr.STypeName, new EntityAttrExprCreator());
            Expression.RegisterType("ENTITY", new EntityAttrExprCreator());
            Expression.RegisterType(AggrFuncExpr.STypeName, new AggrFuncExprCreator());
            Expression.RegisterType(CompoundExpr.STypeName, new CompoundExprCreator());
            Condition.RegisterType(SimpleCondition.STypeName, new SimpleConditionCreator());
            Condition.RegisterType(Predicate.STypeName, new PredicateCreator());
        }

        public Query()
        {
            this.queryName = "";
            this.queryDescription = "";
            this.filePath = "";
            this.formats = new SqlFormats();
            this.options = new SqlOptions();
            this.qresult = new QResult(this);
            this.usedTables = new DataModel.TableList();
            this.extraTables = new DataModel.TableList();
        }

        protected Query(SerializationInfo info, StreamingContext context) : this()
        {
            this.serializationQueryXml = info.GetString("QueryXml");
        }

        private void AddExtraTables()
        {
            foreach (DataModel.Table table in this.extraTables)
            {
                this.AddTable(table);
            }
        }

        public Predicate AddPredicate(Predicate group, int index)
        {
            Predicate predicate = new Predicate(this.model);
            if (group.Linking == Condition.LinkType.Any)
            {
                predicate.Linking = Condition.LinkType.All;
            }
            else
            {
                predicate.Linking = Condition.LinkType.Any;
            }
            group.Conditions.Insert(index, predicate);
            return predicate;
        }

        public SimpleCondition AddSimpleCondition(Predicate group, int index, DataModel.EntityAttr attribute)
        {
            if (attribute == null)
            {
                attribute = this.model.NullAttribute;
            }
            SimpleCondition condition = new SimpleCondition(this.model);
            EntityAttrExpr expr = new EntityAttrExpr(this.model, attribute);
            condition.BaseExpr = expr;
            group.Conditions.Insert(index, condition);
            return condition;
        }

        private void AddTable(DataModel.Table table)
        {
            DataModel.TableList excludeTables = new DataModel.TableList();
            excludeTables.Add(table);
            this.AddTableEx(table, excludeTables);
        }

        private void AddTableEx(DataModel.Table table, DataModel.TableList excludeTables)
        {
            if (this.qresult.RootTable == null)
            {
                this.qresult.SetRootTable(table);
            }
            else if (this.qresult.RootTable.FindTableByAlias(table.Alias) == null)
            {
                DataModel.Path path2 = null;
                foreach (DataModel.Table table2 in this.usedTables)
                {
                    if (excludeTables.IndexOf(table2) < 0)
                    {
                        DataModel.Path path = this.model.CalcPath(table2, table);
                        if ((path2 == null) || (path2.Count > path.Count))
                        {
                            path2 = path;
                        }
                    }
                }
                if (this.qresult.RootTable.FindTableByAlias(path2[0].Alias) == null)
                {
                    excludeTables.Add(path2[0]);
                    this.AddTableEx(path2[0], excludeTables);
                }
                for (int i = 0; i < (path2.Count - 1); i++)
                {
                    DataModel.Link aLink = this.model.Links.FindByTables(path2[i], path2[i + 1]);
                    if (this.qresult.RootTable.FindTableByAlias(path2[i + 1].Alias) == null)
                    {
                        this.qresult.RootTable.FindTableByAlias(path2[i].Alias).AddChildTable(path2[i + 1], aLink);
                    }
                }
            }
        }

        private void AddTables(DataModel.TableList tables)
        {
            foreach (DataModel.Table table in tables)
            {
                this.AddTable(table);
            }
        }

        private void AddUsedTables(DataModel.TableList tableList)
        {
            foreach (DataModel.Table table in tableList)
            {
                if (this.usedTables.IndexOf(table) < 0)
                {
                    this.usedTables.Add(table);
                }
            }
        }

        private string AddWildSymbols(DataModel.Operator op, string s)
        {
            return op.ConstValueFormat.Replace("{const}", s).Replace("{ws}", this.Formats.WildSymbol.ToString());
        }

        public bool BuildParamSQL()
        {
            this.ResetSqlBuilder();
            bool flag = false;
            this.paramMode = true;
            try
            {
                flag = this.BuildSQL();
            }
            finally
            {
                this.paramMode = false;
            }
            return flag;
        }

        public bool BuildSQL()
        {
            this.ResetSqlBuilder();
            this.FillUsedTables();
            this.qresult.SetRootTable(null);
            this.qresult.ClearWhereClause();
            this.qresult.ClearHavingClause();
            this.AddExtraTables();
            this.ProcessColumns();
            this.ProcessPredicate(this.root, false, "  ");
            this.ProcessPredicate(this.root, true, "  ");
            return (this.qresult.RootTable != null);
        }

        private string CalcScalarExpr(Expression expr, string value)
        {
            string val = this.ProcessMacros(value);
            if (expr.DataType == DataType.Date)
            {
                val = this.FormatDateTimeValue(val, this.formats.DateFormat, expr.DataType);
            }
            else if (expr.DataType == DataType.Time)
            {
                val = this.FormatDateTimeValue(val, this.formats.TimeFormat, expr.DataType);
            }
            else if (expr.DataType == DataType.DateTime)
            {
                val = this.FormatDateTimeValue(val, this.formats.DateTimeFormat, expr.DataType);
            }
            if (value == "")
            {
                if ((((expr.DataType == DataType.Byte) || (expr.DataType == DataType.Word)) || ((expr.DataType == DataType.Int) || (expr.DataType == DataType.Int64))) || ((expr.DataType == DataType.Float) || (expr.DataType == DataType.Currency)))
                {
                    val = "0";
                }
                else if (expr.DataType == DataType.Bool)
                {
                    val = this.Formats.FalseValue;
                }
            }
            if (this.paramMode)
            {
                Param param = new Param(this.GenParamID(), expr.DataType, val);
                this.Result.Params.Add(param);
                return this.GetParamExpr(param.ID);
            }
            if (this.Formats.IsQuotedType(expr.DataType))
            {
                val = "'" + val.Replace("'", "''") + "'";
            }
            return val;
        }

        private string CalcSQLExpr(SimpleCondition cnd, int expIndex)
        {
            Expression expr = cnd.Expressions[expIndex];
            string sqlExpr = expr.GetSqlExpr(this.formats);
            if ((expIndex > 0) && !(expr is EntityAttrExpr))
            {
                sqlExpr = this.AddWildSymbols(cnd.Operator, sqlExpr);
            }
            if (expr is ConstExpr)
            {
                if (expr.Kind == DataKind.List)
                {
                    StringTokenizer tokenizer = new StringTokenizer(new StringBuilder(sqlExpr), ",", "");
                    sqlExpr = string.Empty;
                    for (string str2 = tokenizer.FirstToken(); str2 != null; str2 = tokenizer.NextToken())
                    {
                        if (str2 != ",")
                        {
                            sqlExpr = sqlExpr + this.CalcScalarExpr(expr, str2);
                        }
                        else
                        {
                            sqlExpr = sqlExpr + ",";
                        }
                    }
                }
                if (expr.Kind == DataKind.Scalar)
                {
                    sqlExpr = this.CalcScalarExpr(expr, sqlExpr);
                }
            }
            return sqlExpr;
        }

        public void Clear()
        {
            if (this.Root != null)
            {
                this.Root.Conditions.Clear();
            }
            this.Result.SortedColumns.Clear();
            this.Result.Columns.Clear();
            this.Result.JustSortedColumns.Clear();
        }

        private void FillUsedTables()
        {
            this.usedTables.Clear();
            foreach (Column column in this.qresult.Columns)
            {
                this.AddUsedTables(column.UsedTables);
            }
            this.root.GetUsedTables(this.usedTables);
            this.AddUsedTables(this.extraTables);
        }

        private string FormatDateTimeValue(string val, string format, DataType dataType)
        {
            return Utils.InternalFormatToDateTime(val, dataType).ToString(format, DateTimeFormatInfo.InvariantInfo);
        }

        private string GenParamID()
        {
            this.lastParamNum++;
            return ("param" + this.lastParamNum);
        }

        public string GetConditionsText(QueryTextFormats formats)
        {
            return this.Root.GetText(formats, "", "");
        }

        private string GetParamExpr(string id)
        {
            return ("@" + id);
        }

        internal void InnerSortOrderChanged(SortOrderChangedEventArgs e)
        {
            this.OnSortOrderChanged(e);
        }

        private void LoadDataModelNode(XmlElement dmNode)
        {
            XmlAttribute attribute = dmNode.Attributes["path"];
            if (attribute != null)
            {
                string path = attribute.Value;
                this.Model.LoadFromFile(path);
            }
        }

        public void LoadFromFile(string path)
        {
            this.LoadFromFile(path, RWOptions.All);
        }

        public void LoadFromFile(string path, RWOptions Options)
        {
            this.filePath = path;
            FileStream inStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlDocument document = new XmlDocument();
            document.Load(inStream);
            if ((Options & RWOptions.Conditions) == RWOptions.Conditions)
            {
                this.Root.BeginUpdate();
            }
            if ((Options & RWOptions.Columns) == RWOptions.Columns)
            {
                this.Result.Columns.BeginUpdate();
            }
            try
            {
                if ((Options & RWOptions.Conditions) == RWOptions.Conditions)
                {
                    this.Root.Conditions.Clear();
                }
                if ((Options & RWOptions.Columns) == RWOptions.Columns)
                {
                    this.Result.Columns.Clear();
                }
                this.LoadFromXmlNode(document.DocumentElement, Options);
            }
            finally
            {
                if ((Options & RWOptions.Conditions) == RWOptions.Conditions)
                {
                    this.Root.EndUpdate();
                }
                if ((Options & RWOptions.Columns) == RWOptions.Columns)
                {
                    this.Result.Columns.EndUpdate();
                }
            }
            inStream.Close();
        }

        public void LoadFromString(string xml)
        {
            this.LoadFromString(xml, RWOptions.All);
        }

        public void LoadFromString(string xml, RWOptions Options)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if ((Options & RWOptions.Conditions) == RWOptions.Conditions)
            {
                this.Root.BeginUpdate();
            }
            if ((Options & RWOptions.Columns) == RWOptions.Columns)
            {
                this.Result.Columns.BeginUpdate();
            }
            try
            {
                if ((Options & RWOptions.Conditions) == RWOptions.Conditions)
                {
                    this.Root.Conditions.Clear();
                }
                if ((Options & RWOptions.Columns) == RWOptions.Columns)
                {
                    this.Result.Columns.Clear();
                }
                this.LoadFromXmlNode(document.DocumentElement, Options);
            }
            finally
            {
                if ((Options & RWOptions.Conditions) == RWOptions.Conditions)
                {
                    this.Root.EndUpdate();
                }
                if ((Options & RWOptions.Columns) == RWOptions.Columns)
                {
                    this.Result.Columns.EndUpdate();
                }
            }
        }

        public void LoadFromXmlNode(XmlElement rootNode, RWOptions Options)
        {
            if (string.Compare(rootNode.LocalName, "query", true) != 0)
            {
                throw new Error("Wrong XML format");
            }
            XmlAttribute attribute = rootNode.Attributes["name"];
            if (attribute != null)
            {
                this.queryName = attribute.Value;
            }
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if ((string.Compare(node.LocalName, "description") == 0) && ((Options & RWOptions.Description) == RWOptions.Description))
                    {
                        this.queryDescription = node.InnerText;
                    }
                    else
                    {
                        if ((string.Compare(node.LocalName, "datamodel", true) == 0) && this.StoreModelPath)
                        {
                            this.LoadDataModelNode((XmlElement) node);
                            continue;
                        }
                        if (string.Compare(node.LocalName, "options", true) == 0)
                        {
                            this.LoadOptionsNode((XmlElement) node);
                            continue;
                        }
                        if (string.Compare(node.LocalName, "formats", true) == 0)
                        {
                            this.formats.LoadFromXmlNode(node);
                            continue;
                        }
                        if ((string.Compare(node.LocalName, "columns", true) == 0) && ((Options & RWOptions.Columns) == RWOptions.Columns))
                        {
                            this.Result.Columns.LoadFromXmlNode(node);
                            continue;
                        }
                        if ((string.Compare(node.LocalName, "justsortedcolumns", true) == 0) && ((Options & RWOptions.Columns) == RWOptions.Columns))
                        {
                            this.Result.JustSortedColumns.LoadFromXmlNode(node);
                            continue;
                        }
                        if ((string.Compare(node.LocalName, "conditions", true) == 0) && ((Options & RWOptions.Conditions) == RWOptions.Conditions))
                        {
                            this.root.LoadFromXmlNode(node);
                        }
                    }
                }
            }
            this.Result.SortedColumns.Sort(this.Result.SortedColumns);
        }

        private void LoadOptionsNode(XmlElement optNode)
        {
            foreach (XmlNode node in optNode)
            {
                if (string.Compare(node.LocalName, "selectdistinct", true) == 0)
                {
                    this.Options.SelectDistinct = bool.Parse(node.InnerText);
                }
                else if (string.Compare(node.LocalName, "lazyjoins", true) == 0)
                {
                    this.Options.LazyJoins = bool.Parse(node.InnerText);
                }
            }
        }

        protected virtual void OnColumnsChanged(ColumnsChangeEventArgs e)
        {
            if (this.ColumnsChanged != null)
            {
                this.ColumnsChanged(this.Result.Columns, e);
            }
        }

        protected internal virtual void OnConditionsChanged(ConditionsChangeEventArgs e)
        {
            if (this.ConditionsChanged != null)
            {
                this.ConditionsChanged(this, e);
            }
        }

        protected virtual void OnSortOrderChanged(SortOrderChangedEventArgs e)
        {
            if (this.SortOrderChanged != null)
            {
                this.SortOrderChanged(this, e);
            }
        }

        private void ProcessColumns()
        {
            foreach (Column column in this.Result.Columns)
            {
                this.AddTables(column.UsedTables);
                if (column.Aggregate)
                {
                    this.Result.needGroupBy = true;
                }
            }
            foreach (Column column2 in this.Result.JustSortedColumns)
            {
                this.AddTables(column2.UsedTables);
            }
        }

        private string ProcessMacros(string s)
        {
            StringBuilder builder = new StringBuilder(s);
            builder.Replace("$(false)", this.Formats.FalseValue);
            builder.Replace("$(true)", this.Formats.TrueValue);
            builder.Replace("${false}", this.Formats.FalseValue);
            builder.Replace("${true}", this.Formats.TrueValue);
            foreach (IMacroValue value2 in this.model.Macros)
            {
                builder.Replace("${" + value2.ID + "}", value2.Value);
            }
            return builder.ToString();
        }

        private void ProcessPredicate(Predicate predicate, bool processHavingRows, string ident)
        {
            if (predicate.Conditions.Count != 0)
            {
                string str;
                DataModel.TableList usedTables = new DataModel.TableList();
                switch (predicate.Linking)
                {
                    case Condition.LinkType.Any:
                    case Condition.LinkType.None:
                        str = " OR ";
                        break;

                    default:
                        str = " AND ";
                        break;
                }
                bool flag = false;
                foreach (Condition condition in predicate.Conditions)
                {
                    if (!condition.Enabled || (processHavingRows ^ condition.IsHaving))
                    {
                        continue;
                    }
                    if (condition.IsHaving)
                    {
                        this.Result.needGroupBy = true;
                    }
                    if (flag)
                    {
                        if (processHavingRows)
                        {
                            this.qresult.AddToHavingClause(str);
                        }
                        else
                        {
                            this.qresult.AddToWhereClause(str);
                        }
                    }
                    if (!flag)
                    {
                        string str2;
                        if ((predicate.Linking == Condition.LinkType.None) || (predicate.Linking == Condition.LinkType.NotAll))
                        {
                            str2 = "NOT (";
                        }
                        else
                        {
                            str2 = "(";
                        }
                        if (processHavingRows)
                        {
                            this.qresult.AddToHavingClause(str2);
                        }
                        else
                        {
                            this.qresult.AddToWhereClause(str2);
                        }
                    }
                    flag = true;
                    if (condition is Predicate)
                    {
                        this.ProcessPredicate((Predicate) condition, processHavingRows, ident + "  ");
                    }
                    else if (condition is SimpleCondition)
                    {
                        SimpleCondition cnd = (SimpleCondition) condition;
                        usedTables.Clear();
                        cnd.GetUsedTables(usedTables);
                        this.AddTables(usedTables);
                        string expr = cnd.Operator.Expr;
                        for (int i = 0; i < cnd.Expressions.Count; i++)
                        {
                            Expression expression = cnd.Expressions[i];
                            string newValue = this.CalcSQLExpr(cnd, i);
                            if (cnd.Operator.CaseInsensitive)
                            {
                                newValue = this.Formats.LowerFuncName + "(" + newValue + ")";
                            }
                            string name = "";
                            string str6 = "";
                            if (expression is EntityAttrExpr)
                            {
                                DataModel.EntityAttr attribute = ((EntityAttrExpr) expression).Attribute;
                                if (attribute.Tables.Count > 0)
                                {
                                    name = attribute.Tables[0].Name;
                                }
                                str6 = attribute.Expr;
                            }
                            int num2 = i + 1;
                            int num3 = i + 1;
                            int num4 = i + 1;
                            expr = expr.Replace("{expr" + num2.ToString() + "}", newValue).Replace("{expr" + num3.ToString() + ".table}", name).Replace("{expr" + num4.ToString() + ".field}", str6);
                        }
                        if (processHavingRows)
                        {
                            this.qresult.AddHavingCondition(ident + expr);
                            continue;
                        }
                        this.qresult.AddCondition(ident + expr);
                    }
                }
                if (flag)
                {
                    if (processHavingRows)
                    {
                        this.qresult.AddToHavingClause(" )");
                    }
                    else
                    {
                        this.qresult.AddToWhereClause(" )");
                    }
                }
            }
        }

        protected void ResetSqlBuilder()
        {
            this.lastParamNum = 0;
            this.Result.Params.Clear();
            this.Result.needGroupBy = false;
        }

        public void SaveToFile(string path)
        {
            this.SaveToFile(path, RWOptions.Content);
        }

        public void SaveToFile(string path, RWOptions Options)
        {
            this.filePath = path;
            XmlTextWriter writer = new XmlTextWriter(path, null);
            writer.Formatting = Formatting.Indented;
            this.SaveToXmlWriter(writer, Options);
            writer.Flush();
            writer.Close();
        }

        public string SaveToString()
        {
            return this.SaveToString(RWOptions.Content);
        }

        public string SaveToString(RWOptions Options)
        {
            StringWriter w = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(w);
            writer.Formatting = Formatting.Indented;
            this.SaveToXmlWriter(writer, Options);
            writer.Flush();
            writer.Close();
            return w.ToString();
        }

        public void SaveToXmlWriter(XmlWriter writer, RWOptions rwOptions)
        {
            writer.WriteStartElement("query");
            writer.WriteAttributeString("name", this.QueryName);
            if ((rwOptions & RWOptions.Description) == RWOptions.Description)
            {
                writer.WriteElementString("description", this.QueryDescription);
            }
            if (this.StoreModelPath && (this.Model != null))
            {
                writer.WriteStartElement("datamodel");
                writer.WriteAttributeString("path", this.Model.FilePath);
                writer.WriteEndElement();
            }
            if (((rwOptions & RWOptions.Options) == RWOptions.Options) || this.StoreOptions)
            {
                writer.WriteStartElement("options");
                writer.WriteElementString("selectdistinct", this.Options.SelectDistinct.ToString());
                writer.WriteElementString("lazyjoins", this.Options.LazyJoins.ToString());
                writer.WriteEndElement();
            }
            if ((rwOptions & RWOptions.Formats) == RWOptions.Formats)
            {
                this.formats.SaveToXmlWriter(writer, "formats");
            }
            if ((rwOptions & RWOptions.Columns) == RWOptions.Columns)
            {
                this.Result.Columns.SaveToXmlWriter(writer, "columns");
                this.Result.JustSortedColumns.SaveToXmlWriter(writer, "justsortedcolumns");
            }
            if ((rwOptions & RWOptions.Conditions) == RWOptions.Conditions)
            {
                this.root.SaveToXmlWriter(writer);
            }
            writer.WriteEndElement();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("QueryXml", this.SaveToString(RWOptions.All));
        }

        public bool CanBuild
        {
            get
            {
                if (this.Result.Columns.Count > 0)
                {
                    return true;
                }
                for (int i = 0; i < this.Root.Conditions.Count; i++)
                {
                    if (this.Root.Conditions[i].Enabled)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public DataModel.TableList ExtraTables
        {
            get
            {
                return this.extraTables;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SqlFormats Formats
        {
            get
            {
                return this.formats;
            }
        }

        public DataModel Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (this.model != value)
                {
                    this.model = value;
                    this.Clear();
                    this.Result.Columns.Model = this.model;
                    this.Result.JustSortedColumns.Model = this.model;
                    this.root = null;
                    if (this.model != null)
                    {
                        this.root = new RootPredicate(this.model);
                        this.root.Query = this;
                        if (this.serializationQueryXml != null)
                        {
                            this.LoadFromString(this.serializationQueryXml, RWOptions.All);
                            this.serializationQueryXml = null;
                        }
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SqlOptions Options
        {
            get
            {
                return this.options;
            }
        }

        [DefaultValue("")]
        public string QueryDescription
        {
            get
            {
                return this.queryDescription;
            }
            set
            {
                this.queryDescription = value;
            }
        }

        [DefaultValue("")]
        public string QueryName
        {
            get
            {
                return this.queryName;
            }
            set
            {
                this.queryName = value;
            }
        }

        public QResult Result
        {
            get
            {
                return this.qresult;
            }
        }

        public RootPredicate Root
        {
            get
            {
                return this.root;
            }
        }

        [DefaultValue(false)]
        public bool StoreModelPath
        {
            get
            {
                return this.storeModelPath;
            }
            set
            {
                this.storeModelPath = value;
            }
        }

        [DefaultValue(false)]
        public bool StoreOptions
        {
            get
            {
                return this.storeOptions;
            }
            set
            {
                this.storeOptions = value;
            }
        }

        public class Column
        {
            private string alias;
            private string caption;
            private bool distinct;
            private Expression expr;
            internal int innerSortIndex;
            private bool isInsideColumnChangedEvent;
            private DataModel model;
            private bool needAliasRegeneration;
            private Query.ColumnsStore parent;
            private SortDirection sorting;
            private DataModel.TableList usedTables;

            public event EventHandler ColumnChanged;

            public Column() : this("", SortDirection.None)
            {
            }

            public Column(string dispName, SortDirection sorting)
            {
                this.innerSortIndex = -1;
                this.caption = dispName;
                this.Sorting = sorting;
                this.usedTables = new DataModel.TableList();
            }

            private string ChangeSymbolsTo(string s, char c)
            {
                StringBuilder builder = new StringBuilder(s);
                for (int i = 0; i < builder.Length; i++)
                {
                    if (this.IsSymbol(builder[i]))
                    {
                        builder[i] = c;
                    }
                }
                return builder.ToString();
            }

            private bool ContainSymbols(string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (this.IsSymbol(s[i]))
                    {
                        return true;
                    }
                }
                return false;
            }

            protected virtual void ExprChangeHandler(object sender, EventArgs e)
            {
                this.RegenerateCaption();
                this.OnColumnChanged(EventArgs.Empty);
            }

            protected void FillTablesList()
            {
                this.usedTables.Clear();
                this.Expr.GetUsedTables(this.usedTables);
            }

            public string GetAlias(SqlFormats formats)
            {
                if (this.needAliasRegeneration)
                {
                    this.RegenerateAlias(formats);
                }
                if (!this.NeedQuoting(this.alias))
                {
                    return this.alias;
                }
                if (formats.AlphaAlias && this.ContainSymbols(this.alias))
                {
                    return this.ChangeSymbolsTo(this.alias, '_');
                }
                return (formats.SqlQuote1 + this.alias + formats.SqlQuote2);
            }

            public string GetOrderByExpr(SqlFormats formats)
            {
                string alias;
                if (!this.IsJustSorting)
                {
                    if (formats.OrderByStyle == OrderByStyles.Numbers)
                    {
                        alias = (this.Index + 1).ToString();
                    }
                    else if ((formats.OrderByStyle == OrderByStyles.Aliases) && this.UseAlias(formats))
                    {
                        alias = this.GetAlias(formats);
                    }
                    else
                    {
                        alias = this.Expr.GetSqlExpr(formats);
                    }
                }
                else
                {
                    alias = this.Expr.GetSqlExpr(formats);
                }
                if (this.Sorting == SortDirection.Descending)
                {
                    alias = alias + " DESC";
                }
                return alias;
            }

            public string GetSelectExpr(SqlFormats formats)
            {
                string sqlExpr = this.Expr.GetSqlExpr(formats);
                if (this.UseAlias(formats))
                {
                    sqlExpr = sqlExpr + " AS " + this.GetAlias(formats);
                }
                return sqlExpr;
            }

            private bool IsSQLKeyWord(string s)
            {
                if ((((((string.Compare(s, "date", true) != 0) && (string.Compare(s, "select", true) != 0)) && ((string.Compare(s, "from", true) != 0) && (string.Compare(s, "where", true) != 0))) && (((string.Compare(s, "order", true) != 0) && (string.Compare(s, "group", true) != 0)) && ((string.Compare(s, "by", true) != 0) && (string.Compare(s, "join", true) != 0)))) && ((((string.Compare(s, "inner", true) != 0) && (string.Compare(s, "outer", true) != 0)) && ((string.Compare(s, "left", true) != 0) && (string.Compare(s, "right", true) != 0))) && (((string.Compare(s, "full", true) != 0) && (string.Compare(s, "on", true) != 0)) && ((string.Compare(s, "having", true) != 0) && (string.Compare(s, "as", true) != 0))))) && (((string.Compare(s, "sum", true) != 0) && (string.Compare(s, "count", true) != 0)) && ((string.Compare(s, "min", true) != 0) && (string.Compare(s, "max", true) != 0))))
                {
                    return (string.Compare(s, "avg", true) == 0);
                }
                return true;
            }

            private bool IsSuspiciousSymbol(char c)
            {
                if ((((c != '"') && (c != '\'')) && ((c != '[') && (c != ']'))) && (((c != '@') && (c != ';')) && (c != ',')))
                {
                    return (c == '.');
                }
                return true;
            }

            private bool IsSymbol(char c)
            {
                if ((((((c != ' ') && (c != '!')) && ((c != '#') && (c != '$'))) && (((c != '%') && (c != '"')) && ((c != '\'') && (c != '&')))) && ((((c != '/') && (c != ':')) && ((c != '.') && (c != ';'))) && (((c != ',') && (c != '|')) && ((c != '[') && (c != ']'))))) && (((c != '@') && (c != '\\')) && (c != '^')))
                {
                    return (c == '~');
                }
                return true;
            }

            public virtual void LoadFromXmlNode(XmlNode rootNode)
            {
                XmlAttribute attribute;
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.LocalName == Expression.XmlTagName)
                    {
                        attribute = node.Attributes["class"];
                        if (attribute == null)
                        {
                            attribute = node.Attributes["type"];
                        }
                        if (attribute != null)
                        {
                            Expression expression = Expression.Create(attribute.Value, this.Model);
                            expression.LoadFromXmlNode(node);
                            this.Expr = expression;
                        }
                    }
                }
                attribute = rootNode.Attributes["caption"];
                if (attribute != null)
                {
                    this.Caption = attribute.Value;
                }
                attribute = rootNode.Attributes["sorting"];
                if (attribute != null)
                {
                    this.Sorting = (SortDirection) Enum.Parse(typeof(SortDirection), attribute.Value, true);
                }
                attribute = rootNode.Attributes["sortindex"];
                if (attribute != null)
                {
                    this.innerSortIndex = int.Parse(attribute.Value);
                }
            }

            private bool NeedQuoting(string s)
            {
                if (!this.ContainSymbols(s) && !this.IsSQLKeyWord(s))
                {
                    return false;
                }
                return true;
            }

            protected void OnColumnChanged(EventArgs e)
            {
                this.needAliasRegeneration = true;
                if (!this.AllowSorting)
                {
                    this.Sorting = SortDirection.None;
                }
                if (((this.parent == null) || !this.parent.Updating) && !this.isInsideColumnChangedEvent)
                {
                    this.isInsideColumnChangedEvent = true;
                    try
                    {
                        if (this.parent != null)
                        {
                            this.parent.OnColumnsChanged(new ColumnsChangeEventArgs(ChangeType.Update, this, 0));
                        }
                        if (this.ColumnChanged != null)
                        {
                            this.ColumnChanged(this, e);
                        }
                    }
                    finally
                    {
                        this.isInsideColumnChangedEvent = false;
                    }
                }
            }

            private void RecreateExpression(string type)
            {
                Expression expr = this.Expr;
                this.expr = Expression.Create(type, this.Model);
                this.expr.AssignExpr(expr);
                if (this.Expr is AggrFuncExpr)
                {
                    ((AggrFuncExpr) this.Expr).Distinct = this.distinct;
                }
                expr.ContentChange -= new EventHandler(this.ExprChangeHandler);
                this.expr.ContentChange += new EventHandler(this.ExprChangeHandler);
                this.RegenerateCaption();
                this.OnColumnChanged(EventArgs.Empty);
            }

            private void RegenerateAlias(SqlFormats formats)
            {
                this.needAliasRegeneration = false;
                string str = this.RemoveSuspiciousSymbols(this.Caption);
                this.alias = string.Empty;
                string alias = str;
                int num = 1;
                if (this.Parent != null)
                {
                    while (this.Parent.FindByAlias(alias) != null)
                    {
                        num++;
                        alias = str + num.ToString();
                    }
                }
                this.alias = alias;
            }

            private void RegenerateCaption()
            {
                if (this.expr != null)
                {
                    this.caption = this.expr.Text;
                }
            }

            private string RemoveSuspiciousSymbols(string s)
            {
                StringBuilder builder = new StringBuilder(s);
                for (int i = 0; i < builder.Length; i++)
                {
                    if (this.IsSuspiciousSymbol(builder[i]))
                    {
                        builder[i] = '_';
                    }
                }
                return builder.ToString();
            }

            public virtual void SaveToXmlWriter(XmlWriter writer)
            {
                writer.WriteStartElement("Column");
                writer.WriteAttributeString("caption", this.caption);
                writer.WriteAttributeString("sorting", this.Sorting.ToString());
                if (this.parent != null)
                {
                    writer.WriteAttributeString("sortindex", this.parent.ParentQuery.Result.SortedColumns.IndexOf(this).ToString());
                }
                else
                {
                    writer.WriteAttributeString("sortindex", "-1");
                }
                this.Expr.SaveToXmlWriter(writer);
                writer.WriteEndElement();
            }

            public bool UseAlias(SqlFormats formats)
            {
                bool useAlias = true;
                if (this.Expr is EntityAttrExpr)
                {
                    useAlias = ((EntityAttrExpr) this.Expr).Attribute.UseAlias;
                }
                if (!useAlias)
                {
                    return false;
                }
                switch (formats.UseColumnAliases)
                {
                    case ColumnAliasesUsage.Never:
                        return false;

                    case ColumnAliasesUsage.IfNecessary:
                        return (!(this.Expr is EntityAttrExpr) || ((this.Caption != this.Expr.GetSqlExpr(formats)) && (this.Caption != "")));
                }
                return true;
            }

            public bool Aggregate
            {
                get
                {
                    return ((this.Expr is AggrFuncExpr) || ((this.Expr is EntityAttrExpr) && ((EntityAttrExpr) this.Expr).Attribute.IsAggregate));
                }
            }

            public string Alias
            {
                get
                {
                    return this.alias;
                }
            }

            public bool AllowSorting
            {
                get
                {
                    if (this.expr is EntityAttrExpr)
                    {
                        return ((EntityAttrExpr) this.expr).Attribute.UseInSorting;
                    }
                    return true;
                }
            }

            public string Caption
            {
                get
                {
                    return this.caption;
                }
                set
                {
                    if (value != this.caption)
                    {
                        this.caption = value;
                        this.OnColumnChanged(EventArgs.Empty);
                    }
                }
            }

            public bool Distinct
            {
                get
                {
                    return this.distinct;
                }
                set
                {
                    if (this.distinct != value)
                    {
                        this.distinct = value;
                        if (this.Expr is AggrFuncExpr)
                        {
                            ((AggrFuncExpr) this.Expr).Distinct = this.distinct;
                        }
                        this.OnColumnChanged(EventArgs.Empty);
                    }
                }
            }

            public Expression Expr
            {
                get
                {
                    return this.expr;
                }
                set
                {
                    if ((value != null) && (value != this.expr))
                    {
                        if (this.expr != null)
                        {
                            this.expr.ContentChange -= new EventHandler(this.ExprChangeHandler);
                        }
                        this.expr = value;
                        this.RegenerateCaption();
                        if (this.expr != null)
                        {
                            this.expr.ContentChange += new EventHandler(this.ExprChangeHandler);
                        }
                        this.OnColumnChanged(EventArgs.Empty);
                    }
                }
            }

            public string ExprType
            {
                get
                {
                    if (this.expr == null)
                    {
                        return "";
                    }
                    return this.expr.TypeName;
                }
                set
                {
                    if (value != this.ExprType)
                    {
                        this.RecreateExpression(value);
                    }
                }
            }

            public int Index
            {
                get
                {
                    if (this.parent != null)
                    {
                        return this.parent.IndexOf(this);
                    }
                    return -1;
                }
            }

            public bool IsJustSorting
            {
                get
                {
                    return (this.ParentQuery.Result.JustSortedColumns.IndexOf(this) >= 0);
                }
            }

            public DataModel Model
            {
                get
                {
                    return this.model;
                }
                set
                {
                    this.model = value;
                }
            }

            public Query.ColumnsStore Parent
            {
                get
                {
                    return this.parent;
                }
                set
                {
                    this.parent = value;
                    if (this.parent != null)
                    {
                        this.needAliasRegeneration = true;
                    }
                }
            }

            public Query ParentQuery
            {
                get
                {
                    if (this.parent == null)
                    {
                        return null;
                    }
                    return this.parent.ParentQuery;
                }
            }

            public int SortIndex
            {
                get
                {
                    if (this.ParentQuery != null)
                    {
                        return this.ParentQuery.Result.SortedColumns.IndexOf(this);
                    }
                    return this.innerSortIndex;
                }
            }

            public SortDirection Sorting
            {
                get
                {
                    return this.sorting;
                }
                set
                {
                    if (value != this.sorting)
                    {
                        Query parentQuery = this.ParentQuery;
                        if (parentQuery != null)
                        {
                            parentQuery.Result.SortedColumns.BeginUpdate();
                        }
                        try
                        {
                            SortDirection sorting = this.sorting;
                            this.sorting = value;
                            if (sorting == SortDirection.None)
                            {
                                if ((parentQuery != null) && (parentQuery.Result.SortedColumns.IndexOf(this) < 0))
                                {
                                    parentQuery.Result.SortedColumns.Add(this);
                                }
                            }
                            else if ((this.sorting == SortDirection.None) && (parentQuery != null))
                            {
                                parentQuery.Result.SortedColumns.Remove(this);
                                parentQuery.Result.JustSortedColumns.Remove(this);
                            }
                        }
                        finally
                        {
                            if (parentQuery != null)
                            {
                                parentQuery.Result.SortedColumns.EndUpdate();
                            }
                        }
                        this.OnColumnChanged(EventArgs.Empty);
                    }
                }
            }

            public DataModel.TableList UsedTables
            {
                get
                {
                    this.FillTablesList();
                    return this.usedTables;
                }
            }
        }

        public class ColumnList : ArrayList
        {
            public Query.Column FindByAlias(string alias)
            {
                foreach (Query.Column column in this)
                {
                    if (string.Compare(column.Alias, alias, true) == 0)
                    {
                        return column;
                    }
                }
                return null;
            }

            public bool HasAggregate
            {
                get
                {
                    foreach (Query.Column column in this)
                    {
                        if (column.Aggregate)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Query.Column this[int index]
            {
                get
                {
                    return (Query.Column) base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
        }

        public class ColumnsStore : Query.ColumnList
        {
            private DataModel model;
            protected Query parentQuery;
            private int updatingLevel;

            public event ColumnsChangedEventHandler ColumnsChanged;

            public ColumnsStore(Query query)
            {
                this.parentQuery = query;
            }

            public override int Add(object value)
            {
                int info = base.Add(value);
                ((Query.Column) value).Parent = this;
                ((Query.Column) value).Model = this.Model;
                this.AddColumnToSorting((Query.Column) value);
                this.OnColumnsChanged(new ColumnsChangeEventArgs(ChangeType.Addition, (Query.Column) value, info));
                return info;
            }

            private void AddColumnToSorting(Query.Column col)
            {
                if (col.Sorting != SortDirection.None)
                {
                    this.ParentQuery.Result.SortedColumns.Add(col);
                }
            }

            public override void AddRange(ICollection c)
            {
                base.AddRange(c);
                this.ParentQuery.Result.SortedColumns.BeginUpdate();
                try
                {
                    foreach (Query.Column column in c)
                    {
                        column.Parent = this;
                        column.Model = this.Model;
                        this.AddColumnToSorting(column);
                    }
                    this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
                }
                finally
                {
                    this.ParentQuery.Result.SortedColumns.EndUpdate();
                }
            }

            public void BeginUpdate()
            {
                this.updatingLevel++;
                this.ParentQuery.Result.SortedColumns.BeginUpdate();
            }

            public override void Clear()
            {
                this.ParentQuery.Result.SortedColumns.BeginUpdate();
                try
                {
                    foreach (Query.Column column in this)
                    {
                        this.RemoveColumnFromSorting(column);
                    }
                    base.Clear();
                    this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
                }
                finally
                {
                    this.ParentQuery.Result.SortedColumns.EndUpdate();
                }
            }

            public void EndUpdate()
            {
                if (this.updatingLevel > 0)
                {
                    this.updatingLevel--;
                }
                this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
                this.ParentQuery.Result.SortedColumns.EndUpdate();
            }

            public override void Insert(int index, object value)
            {
                base.Insert(index, value);
                ((Query.Column) value).Parent = this;
                ((Query.Column) value).Model = this.Model;
                this.OnColumnsChanged(new ColumnsChangeEventArgs(ChangeType.Addition, (Query.Column) value, index));
                this.AddColumnToSorting((Query.Column) value);
            }

            public override void InsertRange(int index, ICollection c)
            {
                base.InsertRange(index, c);
                this.ParentQuery.Result.SortedColumns.BeginUpdate();
                try
                {
                    foreach (Query.Column column in c)
                    {
                        column.Parent = this;
                        column.Model = this.Model;
                        this.AddColumnToSorting(column);
                    }
                    this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
                }
                finally
                {
                    this.ParentQuery.Result.SortedColumns.EndUpdate();
                }
            }

            public virtual void LoadFromXmlNode(XmlNode rootNode)
            {
                this.BeginUpdate();
                try
                {
                    this.Clear();
                    foreach (XmlNode node in rootNode.ChildNodes)
                    {
                        if (string.Compare(node.LocalName, "Column", true) == 0)
                        {
                            Query.Column column = new Query.Column();
                            this.Add(column);
                            column.LoadFromXmlNode(node);
                        }
                    }
                }
                finally
                {
                    this.EndUpdate();
                }
            }

            public void Move(int index, int newIndex)
            {
                if (((index >= 0) && (newIndex >= 0)) && (((index < this.Count) && (newIndex < this.Count)) && (index != newIndex)))
                {
                    Query.Column column = base[index];
                    this.BeginUpdate();
                    try
                    {
                        this.RemoveAt(index);
                        this.Insert(newIndex, column);
                    }
                    finally
                    {
                        this.EndUpdate();
                    }
                }
            }

            protected internal virtual void OnColumnsChanged(ColumnsChangeEventArgs e)
            {
                if (!this.Updating && (this.ColumnsChanged != null))
                {
                    this.ColumnsChanged(this, e);
                }
            }

            public override void RemoveAt(int index)
            {
                Query.Column column = base[index];
                base.RemoveAt(index);
                this.OnColumnsChanged(new ColumnsChangeEventArgs(ChangeType.Removal, column, index));
                this.RemoveColumnFromSorting(column);
            }

            private void RemoveColumnFromSorting(Query.Column col)
            {
                this.ParentQuery.Result.SortedColumns.Remove(col);
            }

            public override void RemoveRange(int index, int count)
            {
                this.ParentQuery.Result.SortedColumns.BeginUpdate();
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        this.RemoveColumnFromSorting(base[index + i]);
                    }
                    base.RemoveRange(index, count);
                    this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
                }
                finally
                {
                    this.ParentQuery.Result.SortedColumns.EndUpdate();
                }
            }

            public override void Reverse(int index, int count)
            {
                base.Reverse(index, count);
                this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
            }

            public virtual void SaveToXmlWriter(XmlWriter writer, string tagName)
            {
                writer.WriteStartElement(tagName);
                foreach (Query.Column column in this)
                {
                    column.SaveToXmlWriter(writer);
                }
                writer.WriteEndElement();
            }

            public override void SetRange(int index, ICollection c)
            {
                base.SetRange(index, c);
                this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
            }

            public override void Sort(int index, int count, IComparer comparer)
            {
                base.Sort(index, count, comparer);
                this.OnColumnsChanged(ColumnsChangeEventArgs.Default);
            }

            public DataModel Model
            {
                get
                {
                    return this.model;
                }
                set
                {
                    if (this.model != value)
                    {
                        this.model = value;
                        foreach (Query.Column column in this)
                        {
                            column.Model = this.model;
                        }
                    }
                }
            }

            public Query ParentQuery
            {
                get
                {
                    return this.parentQuery;
                }
            }

            protected internal bool Updating
            {
                get
                {
                    return (this.updatingLevel > 0);
                }
            }
        }

        public class Condition
        {
            internal static Hashtable ConditionCreators = new Hashtable();
            private bool enabled = true;
            private int id;
            private DataModel model;
            internal Korzh.EasyQuery.Query.Predicate parent;
            private Korzh.EasyQuery.Query query;
            private bool readOnly;
            private int updating;
            private bool wasModification;

            public Condition(DataModel model)
            {
                this.model = model;
            }

            public virtual void BeginUpdate()
            {
                this.updating++;
            }

            public void Changed()
            {
                this.wasModification = true;
                if (this.updating <= 0)
                {
                    this.wasModification = false;
                    if (this.query != null)
                    {
                        this.query.OnConditionsChanged(new ConditionsChangeEventArgs(ChangeType.Update, this, 0));
                    }
                }
            }

            public static Korzh.EasyQuery.Query.Condition Create(string type, DataModel model)
            {
                IDictionaryEnumerator enumerator = ConditionCreators.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (string.Compare(type, (string) enumerator.Key, true) == 0)
                    {
                        Korzh.EasyQuery.Query.IConditionCreator creator = (Korzh.EasyQuery.Query.IConditionCreator) enumerator.Value;
                        return creator.Create(model);
                    }
                }
                return null;
            }

            public virtual void EndUpdate()
            {
                this.updating--;
                if ((this.updating == 0) && this.wasModification)
                {
                    this.Changed();
                }
            }

            protected virtual bool GetHaving()
            {
                return false;
            }

            public virtual string GetText(QueryTextFormats formats, string levelSpace, string prefix)
            {
                return string.Empty;
            }

            protected internal virtual void GetUsedTables(DataModel.TableList usedTables)
            {
            }

            internal void InnerSetEnabled(bool newValue)
            {
                this.SetEnabled(newValue);
            }

            internal void InnerSetReadOnly(bool newValue)
            {
                this.SetReadOnly(newValue);
            }

            public virtual void LoadFromXmlNode(XmlNode rootNode)
            {
                XmlAttribute attribute = rootNode.Attributes["enabled"];
                if (attribute != null)
                {
                    this.enabled = bool.Parse(attribute.Value);
                }
                attribute = rootNode.Attributes["ReadOnly"];
                if (attribute != null)
                {
                    this.readOnly = bool.Parse(attribute.Value);
                }
            }

            public virtual void MoveDown()
            {
                if (this.Parent != null)
                {
                    if (this.Index < (this.Parent.Conditions.Count - 1))
                    {
                        this.Parent.Conditions.BeginUpdate();
                        Korzh.EasyQuery.Query.Condition condition = this.Parent.Conditions[this.Index + 1];
                        this.Parent.Conditions.RemoveAt(this.Index + 1);
                        this.Parent.Conditions.Insert(this.Index, condition);
                        this.Parent.Conditions.EndUpdate();
                    }
                    else if (this.Parent.Parent != null)
                    {
                        for (int i = this.Parent.Index + 1; i < this.Parent.Parent.Conditions.Count; i++)
                        {
                            if (this.Parent.Parent.Conditions[i] is Korzh.EasyQuery.Query.Predicate)
                            {
                                Korzh.EasyQuery.Query.ConditionsStore conditions = this.Parent.Parent.Conditions;
                                conditions.BeginUpdate();
                                Korzh.EasyQuery.Query.ConditionsStore store2 = ((Korzh.EasyQuery.Query.Predicate) this.Parent.Parent.Conditions[i]).Conditions;
                                this.Parent.Conditions.RemoveAt(this.Index);
                                store2.Insert(0, this);
                                conditions.EndUpdate();
                                return;
                            }
                        }
                    }
                }
            }

            public virtual void MoveUp()
            {
                if (this.Parent != null)
                {
                    if (this.Index > 0)
                    {
                        this.Parent.Conditions.BeginUpdate();
                        Korzh.EasyQuery.Query.Condition condition = this.Parent.Conditions[this.Index - 1];
                        this.Parent.Conditions.RemoveAt(this.Index - 1);
                        this.Parent.Conditions.Insert(this.Index + 1, condition);
                        this.Parent.Conditions.EndUpdate();
                    }
                    else if (this.Parent.Parent != null)
                    {
                        for (int i = this.Parent.Index - 1; i >= 0; i--)
                        {
                            if (this.Parent.Parent.Conditions[i] is Korzh.EasyQuery.Query.Predicate)
                            {
                                Korzh.EasyQuery.Query.ConditionsStore conditions = this.Parent.Parent.Conditions;
                                conditions.BeginUpdate();
                                Korzh.EasyQuery.Query.ConditionsStore store2 = ((Korzh.EasyQuery.Query.Predicate) this.Parent.Parent.Conditions[i]).Conditions;
                                this.Parent.Conditions.RemoveAt(this.Index);
                                store2.Insert(store2.Count, this);
                                conditions.EndUpdate();
                                return;
                            }
                        }
                    }
                }
            }

            public static bool RegisterType(string condType, Korzh.EasyQuery.Query.IConditionCreator creator)
            {
                ConditionCreators.Add(condType, creator);
                return true;
            }

            public virtual void SaveToXmlWriter(XmlWriter writer)
            {
                writer.WriteStartElement(XmlTagName);
                writer.WriteAttributeString("class", this.TypeName);
                writer.WriteAttributeString("enabled", this.Enabled.ToString());
                writer.WriteAttributeString("ReadOnly", this.ReadOnly.ToString());
                this.WriteContent(writer);
                writer.WriteEndElement();
            }

            protected virtual void SetEnabled(bool newValue)
            {
                this.enabled = newValue;
                this.Changed();
            }

            protected virtual void SetQuery(Korzh.EasyQuery.Query newQuery)
            {
                this.query = newQuery;
            }

            protected virtual void SetReadOnly(bool newValue)
            {
                this.readOnly = newValue;
                this.Changed();
            }

            public virtual void ShiftLevel(bool up)
            {
                if (this.Parent != null)
                {
                    if (up)
                    {
                        if (this.Parent.Parent != null)
                        {
                            Korzh.EasyQuery.Query.ConditionsStore conditions = this.Parent.Parent.Conditions;
                            int index = this.Parent.Index;
                            conditions.BeginUpdate();
                            this.Parent.Conditions.RemoveAt(this.Index);
                            conditions.Insert(index + 1, this);
                            if ((conditions[index] is Korzh.EasyQuery.Query.Predicate) && (((Korzh.EasyQuery.Query.Predicate) conditions[index]).Conditions.Count == 0))
                            {
                                conditions.RemoveAt(index);
                            }
                            conditions.EndUpdate();
                        }
                    }
                    else
                    {
                        Korzh.EasyQuery.Query.ConditionsStore store2 = this.Parent.Conditions;
                        store2.BeginUpdate();
                        if ((this.Index > 0) && (this.Parent.Conditions[this.Index - 1] is Korzh.EasyQuery.Query.Predicate))
                        {
                            int num2 = this.Index;
                            store2.RemoveAt(num2);
                            ((Korzh.EasyQuery.Query.Predicate) store2[num2 - 1]).Conditions.Add(this);
                        }
                        else
                        {
                            Korzh.EasyQuery.Query.Predicate predicate = new Korzh.EasyQuery.Query.Predicate(this.Query.Model);
                            store2.Insert(this.Index, predicate);
                            store2.RemoveAt(this.Index);
                            predicate.Conditions.Add(this);
                        }
                        store2.EndUpdate();
                    }
                }
            }

            protected virtual void WriteContent(XmlWriter writer)
            {
            }

            public virtual bool Enabled
            {
                get
                {
                    return this.enabled;
                }
                set
                {
                    if (value != this.enabled)
                    {
                        this.SetEnabled(value);
                        if (this.parent != null)
                        {
                            this.parent.CheckIfEnabled();
                        }
                    }
                }
            }

            public string FullNum
            {
                get
                {
                    if (this.parent == null)
                    {
                        return "";
                    }
                    string fullNum = this.parent.FullNum;
                    if (fullNum != "")
                    {
                        fullNum = fullNum + ".";
                    }
                    return (fullNum + (this.Index + 1));
                }
            }

            public int ID
            {
                get
                {
                    return this.id;
                }
                set
                {
                    if (this.id != value)
                    {
                        this.id = value;
                    }
                }
            }

            public int Index
            {
                get
                {
                    if (this.parent == null)
                    {
                        return -1;
                    }
                    return this.parent.Conditions.IndexOf(this);
                }
            }

            public bool IsHaving
            {
                get
                {
                    return this.GetHaving();
                }
            }

            public int Level
            {
                get
                {
                    if (this.parent != null)
                    {
                        return (this.parent.Level + 1);
                    }
                    return 0;
                }
            }

            public DataModel Model
            {
                get
                {
                    return this.model;
                }
            }

            public Korzh.EasyQuery.Query.Predicate Parent
            {
                get
                {
                    return this.parent;
                }
            }

            public Korzh.EasyQuery.Query Query
            {
                get
                {
                    return this.query;
                }
                set
                {
                    if (this.query != value)
                    {
                        this.SetQuery(value);
                    }
                }
            }

            public bool ReadOnly
            {
                get
                {
                    return this.readOnly;
                }
                set
                {
                    if (value != this.readOnly)
                    {
                        this.SetReadOnly(value);
                    }
                }
            }

            public static string STypeName
            {
                get
                {
                    return "";
                }
            }

            public virtual string TypeName
            {
                get
                {
                    return "";
                }
            }

            public static string XmlTagName
            {
                get
                {
                    return "Condition";
                }
            }

            public enum LinkType
            {
                All,
                Any,
                None,
                NotAll
            }
        }

        public class ConditionList : ArrayList
        {
            public Query.Condition this[int index]
            {
                get
                {
                    return (Query.Condition) base[index];
                }
            }
        }

        public class ConditionsStore : Korzh.EasyQuery.Query.ConditionList
        {
            private int maxID;
            private Korzh.EasyQuery.Query.Predicate predicate;
            private int updatingLevel;
            private bool wasModification;

            public ConditionsStore(Korzh.EasyQuery.Query.Predicate predicate)
            {
                this.predicate = predicate;
            }

            public override int Add(object value)
            {
                this.CheckObject(value);
                ((Korzh.EasyQuery.Query.Condition) value).parent = this.predicate;
                int index = base.Add(value);
                ((Korzh.EasyQuery.Query.Condition) value).Query = this.Query;
                this.OnAdded((Korzh.EasyQuery.Query.Condition) value, index);
                return index;
            }

            public void BeginUpdate()
            {
                this.updatingLevel++;
            }

            internal void CheckMaxID()
            {
                foreach (Korzh.EasyQuery.Query.Condition condition in this)
                {
                    if (condition.ID > this.maxID)
                    {
                        this.maxID = condition.ID;
                    }
                }
            }

            private void CheckObject(object value)
            {
                if (!(value is Korzh.EasyQuery.Query.Condition))
                {
                    throw new Korzh.EasyQuery.Query.Error("Only Condition objects are accepted");
                }
            }

            public override void Clear()
            {
                base.Clear();
                this.maxID = 0;
                this.OnListChange();
            }

            public void EndUpdate()
            {
                this.updatingLevel--;
                if (this.wasModification)
                {
                    this.OnListChange();
                }
                if (this.updatingLevel == 0)
                {
                    this.wasModification = false;
                }
            }

            protected virtual int GetNewID()
            {
                this.maxID++;
                return this.maxID;
            }

            public override void Insert(int index, object value)
            {
                this.CheckObject(value);
                ((Korzh.EasyQuery.Query.Condition) value).parent = this.predicate;
                base.Insert(index, value);
                ((Korzh.EasyQuery.Query.Condition) value).Query = this.Query;
                this.OnAdded((Korzh.EasyQuery.Query.Condition) value, index);
            }

            protected virtual void OnAdded(Korzh.EasyQuery.Query.Condition condition, int index)
            {
                if (condition.ID == 0)
                {
                    condition.ID = this.GetNewID();
                }
                else if (condition.ID < this.maxID)
                {
                    this.maxID = condition.ID;
                }
                if ((this.updatingLevel == 0) && (this.Query != null))
                {
                    this.Query.OnConditionsChanged(new ConditionsChangeEventArgs(ChangeType.Addition, condition, index));
                }
                else
                {
                    this.wasModification = true;
                }
            }

            protected virtual void OnListChange()
            {
                if ((this.updatingLevel == 0) && (this.Query != null))
                {
                    this.Query.OnConditionsChanged(new ConditionsChangeEventArgs());
                }
            }

            protected virtual void OnRemoved(Korzh.EasyQuery.Query.Condition condition)
            {
                if ((this.updatingLevel == 0) && (this.Query != null))
                {
                    this.Query.OnConditionsChanged(new ConditionsChangeEventArgs(ChangeType.Removal, condition));
                }
                else
                {
                    this.wasModification = true;
                }
            }

            public override void Remove(object obj)
            {
                this.CheckObject(obj);
                base.Remove(obj);
            }

            public override void RemoveAt(int index)
            {
                Korzh.EasyQuery.Query.Condition condition = base[index];
                base.RemoveAt(index);
                condition.Query = null;
                this.OnRemoved(condition);
            }

            public Korzh.EasyQuery.Query Query
            {
                get
                {
                    if (this.predicate == null)
                    {
                        return null;
                    }
                    return this.predicate.Query;
                }
            }
        }

        public class Error : Exception
        {
            public Error(string msg) : base(msg)
            {
            }
        }

        public interface IConditionCreator
        {
            Query.Condition Create(DataModel model);
        }

        public class Param
        {
            public readonly Korzh.EasyQuery.DataType DataType;
            public readonly string ID;
            public readonly string Value;

            public Param(string id, Korzh.EasyQuery.DataType dataType, string value)
            {
                this.ID = id;
                this.DataType = dataType;
                this.Value = value;
            }
        }

        public class ParamList : ArrayList
        {
            public Query.Param this[int index]
            {
                get
                {
                    return (Query.Param) base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
        }

        public class Predicate : Query.Condition
        {
            private Query.ConditionsStore conditions;
            private Query.Condition.LinkType linking;

            public Predicate(DataModel model) : base(model)
            {
                this.conditions = new Query.ConditionsStore(this);
                this.linking = Query.Condition.LinkType.All;
            }

            public override void BeginUpdate()
            {
                base.BeginUpdate();
                this.Conditions.BeginUpdate();
            }

            protected internal virtual void CheckIfEnabled()
            {
                foreach (Query.Condition condition in this.Conditions)
                {
                    if (condition.Enabled)
                    {
                        base.SetEnabled(true);
                        return;
                    }
                }
                base.SetEnabled(false);
            }

            public override void EndUpdate()
            {
                this.Conditions.EndUpdate();
                base.EndUpdate();
            }

            protected override bool GetHaving()
            {
                foreach (Query.Condition condition in this.Conditions)
                {
                    if (condition.IsHaving)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetOffspringCount()
            {
                int num = 0;
                foreach (Query.Condition condition in this.Conditions)
                {
                    if (condition is Query.Predicate)
                    {
                        num += ((Query.Predicate) condition).GetOffspringCount() + 1;
                    }
                    else
                    {
                        num++;
                    }
                }
                return num;
            }

            protected virtual string GetPredicateHeader()
            {
                return "{lt} of the following apply";
            }

            public override string GetText(QueryTextFormats formats, string levelSpace, string prefix)
            {
                string newValue = levelSpace + prefix + this.GetPredicateHeader().Replace("{lt}", this.linking.ToString().ToLower());
                if (formats.UseHtml && (base.Parent != null))
                {
                    newValue = formats.HtmlFormatting.BracketOpen.Replace("{0}", newValue);
                }
                StringBuilder builder = new StringBuilder(newValue);
                string str2 = ((this.linking == Query.Condition.LinkType.All) || (this.linking == Query.Condition.LinkType.NotAll)) ? "AND" : "OR";
                string str3 = string.Empty;
                bool flag = true;
                if (base.Parent != null)
                {
                    levelSpace = levelSpace + "  ";
                }
                foreach (Query.Condition condition in this.Conditions)
                {
                    if (!condition.Enabled)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        builder.Append(Environment.NewLine);
                        str3 = str2 + " ";
                        if (formats.UseHtml)
                        {
                            if (base.Parent == null)
                            {
                                str3 = formats.HtmlFormatting.BoolOperatorRoot.Replace("{0}", str3);
                            }
                            else
                            {
                                str3 = formats.HtmlFormatting.BoolOperator.Replace("{0}", str3);
                            }
                        }
                    }
                    else
                    {
                        str3 = string.Empty;
                    }
                    builder.Append(condition.GetText(formats, levelSpace, str3));
                    flag = false;
                }
                if (formats.UseHtml && (base.Parent != null))
                {
                    newValue = formats.HtmlFormatting.BracketClose;
                    builder.Append(newValue);
                }
                return builder.ToString();
            }

            protected internal override void GetUsedTables(DataModel.TableList usedTables)
            {
                if (this.Enabled)
                {
                    foreach (Query.Condition condition in this.Conditions)
                    {
                        condition.GetUsedTables(usedTables);
                    }
                }
            }

            protected string LinkTypeToStr(Query.Condition.LinkType lt)
            {
                return Enum.GetName(typeof(Query.Condition.LinkType), lt);
            }

            public override void LoadFromXmlNode(XmlNode rootNode)
            {
                base.LoadFromXmlNode(rootNode);
                this.conditions.BeginUpdate();
                try
                {
                    XmlNode node = rootNode.Attributes["linking"];
                    if (node != null)
                    {
                        this.Linking = this.StrToLinkType(node.Value);
                    }
                    foreach (XmlNode node2 in rootNode.ChildNodes)
                    {
                        if ((node2.NodeType == XmlNodeType.Element) && (string.Compare(node2.LocalName, Query.Condition.XmlTagName, true) == 0))
                        {
                            node = node2.Attributes["class"];
                            if (node == null)
                            {
                                node = node2.Attributes["type"];
                            }
                            if (node != null)
                            {
                                Query.Condition condition = Query.Condition.Create(node.Value, base.Model);
                                if (condition != null)
                                {
                                    condition.LoadFromXmlNode((XmlElement) node2);
                                    this.Conditions.Add(condition);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    this.conditions.EndUpdate();
                }
            }

            protected override void SetEnabled(bool newValue)
            {
                foreach (Query.Condition condition in this.Conditions)
                {
                    if (condition.Enabled != newValue)
                    {
                        condition.InnerSetEnabled(newValue);
                    }
                }
                base.SetEnabled(newValue);
            }

            protected override void SetQuery(Query newQuery)
            {
                base.SetQuery(newQuery);
                foreach (Query.Condition condition in this.Conditions)
                {
                    condition.Query = newQuery;
                }
            }

            protected override void SetReadOnly(bool newValue)
            {
                foreach (Query.Condition condition in this.Conditions)
                {
                    if (condition.ReadOnly != newValue)
                    {
                        condition.InnerSetReadOnly(newValue);
                    }
                }
                base.SetReadOnly(newValue);
            }

            private Query.Condition.LinkType StrToLinkType(string s)
            {
                return (Query.Condition.LinkType) Enum.Parse(typeof(Query.Condition.LinkType), s, true);
            }

            protected override void WriteContent(XmlWriter writer)
            {
                writer.WriteAttributeString("linking", this.LinkTypeToStr(this.Linking));
                this.WriteSubNodesToXml(writer);
            }

            protected virtual void WriteSubNodesToXml(XmlWriter writer)
            {
                foreach (Query.Condition condition in this.Conditions)
                {
                    condition.SaveToXmlWriter(writer);
                }
            }

            public Query.ConditionsStore Conditions
            {
                get
                {
                    return this.conditions;
                }
            }

            public Query.Condition.LinkType Linking
            {
                get
                {
                    return this.linking;
                }
                set
                {
                    if (this.linking != value)
                    {
                        this.linking = value;
                        base.Changed();
                    }
                }
            }

            public string LinkingStr
            {
                get
                {
                    return this.LinkTypeToStr(this.Linking);
                }
                set
                {
                    this.Linking = this.StrToLinkType(value);
                }
            }

            public static string STypeName
            {
                get
                {
                    return "PDCT";
                }
            }

            public override string TypeName
            {
                get
                {
                    return STypeName;
                }
            }
        }

        internal class PredicateCreator : Query.IConditionCreator
        {
            public Query.Condition Create(DataModel model)
            {
                return new Query.Predicate(model);
            }
        }

        public class QResult
        {
            private Query.ColumnsStore columns;
            private string havingClause;
            private Query.ColumnsStore justSortedColumns;
            internal bool needGroupBy;
            private Query.ParamList paramList;
            private Query query;
            private Query.ResultTable rootTable;
            private Query.SortedColumnList sortedColumns;
            private bool wasSQL1Joins;
            private string whereClause;

            public QResult(Query query)
            {
                this.sortedColumns = new Query.SortedColumnList(query);
                this.columns = new Query.ColumnsStore(query);
                this.justSortedColumns = new Query.ColumnsStore(query);
                this.paramList = new Query.ParamList();
                this.columns.ColumnsChanged += new ColumnsChangedEventHandler(this.HandleColumnsChanged);
                this.justSortedColumns.ColumnsChanged += new ColumnsChangedEventHandler(this.HandleColumnsChanged);
                this.whereClause = "";
                this.havingClause = "";
                if (query == null)
                {
                    throw new Query.Error("Query parameter can not be null for QResult constructor");
                }
                this.query = query;
            }

            public void AddCondition(string s)
            {
                string eolSymbol = this.Formats.GetEolSymbol();
                this.whereClause = this.whereClause + eolSymbol + this.AdjustCondition(s);
            }

            public void AddHavingCondition(string s)
            {
                this.havingClause = this.havingClause + " " + this.AdjustCondition(s);
            }

            private string AddSQL1Joins()
            {
                return this.AddTableLinkConditions(this.RootTable);
            }

            private string AddTableLinkConditions(Query.ResultTable table)
            {
                string eolSymbol = this.Formats.GetEolSymbol();
                StringBuilder builder = new StringBuilder(200);
                foreach (Query.ResultTable table2 in table.ChildTables)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(" AND ");
                    }
                    builder.Append("    " + this.AdjustCondition(table2.Link.GetSqlExpr(this.Formats)) + eolSymbol);
                    string str2 = this.AddTableLinkConditions(table2);
                    if (str2 != "")
                    {
                        builder.Append("AND " + str2 + eolSymbol);
                    }
                }
                return builder.ToString();
            }

            public void AddToHavingClause(string s)
            {
                this.havingClause = this.havingClause + s;
            }

            public void AddToWhereClause(string s)
            {
                this.whereClause = this.whereClause + s;
            }

            private string AdjustCondition(string s)
            {
                return s;
            }

            public void ClearHavingClause()
            {
                this.havingClause = "";
            }

            public void ClearWhereClause()
            {
                this.whereClause = "";
            }

            public virtual string GetSql(string selectExpr, string orderExpr)
            {
                string eolSymbol = this.Formats.GetEolSymbol();
                StringBuilder builder = new StringBuilder("SELECT " + selectExpr + " " + eolSymbol);
                builder.Append("FROM " + this.FromClause + eolSymbol);
                if (!Utils.IsStrNullOrEmpty(this.Options.LimitClause))
                {
                    builder.Append("LIMIT " + this.Options.LimitClause + eolSymbol);
                }
                if (this.wasSQL1Joins || (this.WhereClause != ""))
                {
                    builder.Append("WHERE" + eolSymbol);
                    if (this.wasSQL1Joins)
                    {
                        builder.Append(this.AddSQL1Joins());
                        if (this.WhereClause != "")
                        {
                            builder.Append(" AND" + eolSymbol);
                        }
                    }
                    builder.Append(this.WhereClause + eolSymbol);
                }
                if (this.GroupClause != "")
                {
                    builder.Append("GROUP BY " + this.GroupClause + eolSymbol);
                }
                if (this.HavingClause != "")
                {
                    builder.Append("HAVING " + this.HavingClause + eolSymbol);
                }
                if (orderExpr != "")
                {
                    builder.Append("ORDER BY  " + this.OrderClause + eolSymbol);
                }
                return builder.ToString();
            }

            private void HandleColumnsChanged(object sender, ColumnsChangeEventArgs e)
            {
                this.query.OnColumnsChanged(e);
            }

            private string JoinTable(Query.ResultTable table, DataModel.Link link, StringBuilder leftBrackets)
            {
                string eolSymbol = this.Formats.GetEolSymbol();
                bool flag = this.Formats.SqlSyntax == SqlSyntax.SQL2;
                StringBuilder builder = new StringBuilder(400);
                builder.Append(table.GetFromExpr(this.Formats));
                if (((link != null) && !this.Options.LazyJoins) && flag)
                {
                    if (link.Type != DataModel.Link.LinkType.Cross)
                    {
                        builder.Append(" ON " + link.GetSqlExpr(this.Formats));
                    }
                    if (this.Formats.BracketJoins && (leftBrackets != null))
                    {
                        builder.Append(")");
                        leftBrackets.Append("(");
                    }
                }
                StringBuilder builder2 = leftBrackets;
                if (this.Options.LazyJoins || (link == null))
                {
                    builder2 = new StringBuilder(20);
                }
                foreach (Query.ResultTable table2 in table.ChildTables)
                {
                    string str3;
                    if (!flag)
                    {
                        builder.Append(", " + eolSymbol);
                        builder.Append("     " + this.JoinTable(table2, null, null));
                        this.wasSQL1Joins = true;
                        continue;
                    }
                    string str2 = "";
                    switch (table2.Link.Type)
                    {
                        case DataModel.Link.LinkType.Left:
                            if (!(table.Alias == table2.Link.Table1.Alias))
                            {
                                break;
                            }
                            str2 = "LEFT OUTER";
                            goto Label_01B9;

                        case DataModel.Link.LinkType.Right:
                            if (!(table.Alias == table2.Link.Table1.Alias))
                            {
                                goto Label_0197;
                            }
                            str2 = "RIGHT OUTER";
                            goto Label_01B9;

                        case DataModel.Link.LinkType.Full:
                            str2 = "FULL";
                            goto Label_01B9;

                        case DataModel.Link.LinkType.Cross:
                            str2 = "CROSS";
                            goto Label_01B9;

                        default:
                            str2 = "INNER";
                            goto Label_01B9;
                    }
                    str2 = "RIGHT OUTER";
                    goto Label_01B9;
                Label_0197:
                    str2 = "LEFT OUTER";
                Label_01B9:
                    str3 = this.JoinTable(table2, table2.Link, builder2);
                    builder.Append(eolSymbol);
                    builder.Append("     " + str2 + " JOIN ");
                    builder.Append(str3);
                }
                if (((link != null) && this.Options.LazyJoins) && flag)
                {
                    builder.Append(" ON " + link.GetSqlExpr(this.Formats));
                    if (this.Formats.BracketJoins && (leftBrackets != null))
                    {
                        leftBrackets.Append("(");
                        builder.Append(")");
                    }
                }
                if ((this.Options.LazyJoins || (link == null)) && (this.Formats.BracketJoins && (builder2 != null)))
                {
                    builder.Insert(0, builder2.ToString());
                }
                return builder.ToString();
            }

            private string Replicate(string s, int num)
            {
                string str = "";
                for (int i = 0; i < num; i++)
                {
                    str = str + s;
                }
                return str;
            }

            internal void SetRootTable(DataModel.Table ATable)
            {
                if (ATable != null)
                {
                    this.rootTable = new Query.ResultTable(ATable, null);
                }
                else
                {
                    this.rootTable = null;
                }
            }

            public Query.ColumnsStore Columns
            {
                get
                {
                    return this.columns;
                }
            }

            protected SqlFormats Formats
            {
                get
                {
                    return this.query.Formats;
                }
            }

            public string FromClause
            {
                get
                {
                    if (this.RootTable == null)
                    {
                        throw new Query.Error("Query was not built");
                    }
                    this.wasSQL1Joins = false;
                    return this.JoinTable(this.RootTable, null, null);
                }
            }

            public string GroupClause
            {
                get
                {
                    string str = string.Empty;
                    if (this.NeedGroupBy)
                    {
                        foreach (Query.Column column in this.Columns)
                        {
                            if (!column.Aggregate)
                            {
                                if (str != string.Empty)
                                {
                                    str = str + ", ";
                                }
                                str = str + column.Expr.GetSqlExpr(this.Formats);
                            }
                        }
                    }
                    return str;
                }
            }

            public string HavingClause
            {
                get
                {
                    return this.havingClause;
                }
            }

            public Query.ColumnsStore JustSortedColumns
            {
                get
                {
                    return this.justSortedColumns;
                }
            }

            protected bool NeedGroupBy
            {
                get
                {
                    return this.needGroupBy;
                }
            }

            protected SqlOptions Options
            {
                get
                {
                    return this.query.Options;
                }
            }

            public string OrderClause
            {
                get
                {
                    string str = "";
                    foreach (Query.Column column in this.Columns.ParentQuery.Result.SortedColumns)
                    {
                        if (str != "")
                        {
                            str = str + ", ";
                        }
                        str = str + column.GetOrderByExpr(this.Formats);
                    }
                    return str;
                }
            }

            public Query.ParamList Params
            {
                get
                {
                    return this.paramList;
                }
            }

            public Query.ResultTable RootTable
            {
                get
                {
                    return this.rootTable;
                }
            }

            public string SelectClause
            {
                get
                {
                    StringBuilder builder = new StringBuilder(this.Options.SelectDistinct ? "DISTINCT " : "");
                    if (this.Columns.Count > 0)
                    {
                        for (int i = 0; i < this.Columns.Count; i++)
                        {
                            if (i > 0)
                            {
                                builder.Append(", ");
                            }
                            builder.Append(this.Columns[i].GetSelectExpr(this.Formats));
                        }
                    }
                    else
                    {
                        builder.Append("*");
                    }
                    if (!Utils.IsStrNullOrEmpty(this.Options.SelectTop))
                    {
                        builder.Append(" TOP " + this.Options.SelectTop + " ");
                    }
                    return builder.ToString();
                }
            }

            public Query.SortedColumnList SortedColumns
            {
                get
                {
                    return this.sortedColumns;
                }
            }

            public virtual string SQL
            {
                get
                {
                    return this.GetSql(this.SelectClause, this.OrderClause);
                }
            }

            public string WhereClause
            {
                get
                {
                    return this.whereClause;
                }
            }
        }

        public class ResultTable : DataModel.Table
        {
            private Query.ResultTableList childTables;
            private Korzh.EasyQuery.DataModel.Link link;

            public ResultTable(DataModel.Table aTable, Korzh.EasyQuery.DataModel.Link aLink) : base(aTable)
            {
                this.link = aLink;
                this.childTables = new Query.ResultTableList();
            }

            public Query.ResultTable AddChildTable(DataModel.Table aTable, Korzh.EasyQuery.DataModel.Link aLink)
            {
                Query.ResultTable table = new Query.ResultTable(aTable, aLink);
                this.childTables.Add(table);
                return table;
            }

            public Query.ResultTable FindTableByAlias(string alias)
            {
                if (base.Alias == alias)
                {
                    return this;
                }
                foreach (Query.ResultTable table in this.childTables)
                {
                    Query.ResultTable table2 = table.FindTableByAlias(alias);
                    if (table2 != null)
                    {
                        return table2;
                    }
                }
                return null;
            }

            public Query.ResultTableList ChildTables
            {
                get
                {
                    return this.childTables;
                }
            }

            public Korzh.EasyQuery.DataModel.Link Link
            {
                get
                {
                    return this.link;
                }
                set
                {
                    if (value != this.link)
                    {
                        this.link = value;
                    }
                }
            }
        }

        public class ResultTableList : DataModel.TableList
        {
            public Query.ResultTable this[int index]
            {
                get
                {
                    return (Query.ResultTable) base[index];
                }
            }
        }

        public class RootPredicate : Query.Predicate
        {
            public RootPredicate(DataModel model) : base(model)
            {
            }

            protected internal override void CheckIfEnabled()
            {
            }

            protected override string GetPredicateHeader()
            {
                return "";
            }

            public override void SaveToXmlWriter(XmlWriter writer)
            {
                writer.WriteStartElement("conditions");
                writer.WriteAttributeString("linking", base.LinkTypeToStr(base.Linking));
                this.WriteSubNodesToXml(writer);
                writer.WriteEndElement();
            }

            public override bool Enabled
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }
        }

        [Flags]
        public enum RWOptions
        {
            All = 0xff,
            Columns = 2,
            Conditions = 1,
            Content = 7,
            Description = 4,
            Formats = 0x10,
            Options = 8
        }

        public class SimpleCondExprList : ExprList
        {
            private Query.SimpleCondition condition;

            public SimpleCondExprList(Query.SimpleCondition condition)
            {
                this.condition = condition;
            }

            public override int Add(object value)
            {
                if (value != null)
                {
                    this.condition.AttachExpr((Expression) value);
                }
                return base.Add(value);
            }

            public override void Insert(int index, object value)
            {
                base.Insert(index, value);
                if (value != null)
                {
                    this.condition.AttachExpr((Expression) value);
                }
            }

            public override void RemoveAt(int index)
            {
                this.condition.DetachExpr(base[index]);
                base.RemoveAt(index);
            }

            public Expression this[int index]
            {
                get
                {
                    return base[index];
                }
                set
                {
                    if (base[index] != value)
                    {
                        if (base[index] != null)
                        {
                            this.condition.DetachExpr(base[index]);
                        }
                        base[index] = value;
                        if (value != null)
                        {
                            this.condition.AttachExpr(value);
                        }
                        this.condition.Changed();
                    }
                }
            }
        }

        public class SimpleCondition : Query.Condition
        {
            private Query.SimpleCondExprList expressions;
            private Korzh.EasyQuery.DataModel.Operator operation;

            public SimpleCondition(DataModel model) : base(model)
            {
                this.operation = null;
                this.expressions = new Query.SimpleCondExprList(this);
            }

            private void AdjustExpressions()
            {
                this.BeginUpdate();
                try
                {
                    int num;
                    for (num = this.Expressions.Count - 1; num >= this.Operator.ParamCount; num--)
                    {
                        if (num > 0)
                        {
                            this.Expressions.RemoveAt(num);
                        }
                    }
                    if (this.BaseExpr != null)
                    {
                        DataType exprType = (this.Operator.ExprDefType != DataType.Unknown) ? this.Operator.ExprDefType : this.BaseExpr.DataType;
                        for (num = 1; num < this.Expressions.Count; num++)
                        {
                            Expression expression = this.Expressions[num];
                            if (expression.Kind != this.Operator.ValueKind)
                            {
                                this.Expressions[num] = this.CreateValueExpr(exprType, this.Operator.ValueKind);
                            }
                            else if (!(expression is EntityAttrExpr))
                            {
                                expression.DataType = exprType;
                                expression.Kind = this.Operator.ValueKind;
                                expression.Value = this.DefaultValue;
                                expression.Text = this.DefaultText;
                            }
                        }
                        for (num = this.Expressions.Count; num < this.Operator.ParamCount; num++)
                        {
                            Expression expression2 = this.CreateValueExpr(exprType, this.Operator.ValueKind);
                            this.Expressions.Add(expression2);
                        }
                    }
                }
                finally
                {
                    this.EndUpdate();
                }
            }

            public void AdjustOperator()
            {
                if ((this.BaseExpr != null) && (this.BaseExpr is EntityAttrExpr))
                {
                    EntityAttrExpr baseExpr = (EntityAttrExpr) this.BaseExpr;
                    DataModel.EntityAttr attribute = baseExpr.Attribute;
                    if (attribute != null)
                    {
                        this.SetOperator(attribute.GetDefaultOperator());
                    }
                }
            }

            protected internal virtual void AttachExpr(Expression expr)
            {
                expr.ContentChange += new EventHandler(this.DoExprContentChanged);
            }

            private Expression CreateValueExpr(DataType exprType, DataKind exprKind)
            {
                Expression expr = null;
                if (exprKind == DataKind.Query)
                {
                    expr = new SubQueryExpr(base.Model);
                    expr.Text = this.DefaultText;
                    return expr;
                }
                if (exprKind == DataKind.Attribute)
                {
                    DataModel.EntityAttr attribute = null;
                    if (this.BaseExpr is EntityAttrExpr)
                    {
                        attribute = ((EntityAttrExpr) this.BaseExpr).Attribute;
                    }
                    else
                    {
                        attribute = base.Model.GetDefaultUICAttribute();
                    }
                    expr = new EntityAttrExpr(base.Model, attribute);
                    expr.Text = this.DefaultText;
                    return expr;
                }
                expr = new ConstExpr(exprType, exprKind);
                this.SetExprDefaults(expr);
                return expr;
            }

            protected internal virtual void DetachExpr(Expression expr)
            {
                expr.ContentChange -= new EventHandler(this.DoExprContentChanged);
            }

            protected virtual void DoExprContentChanged(object sender, EventArgs e)
            {
                this.BeginUpdate();
                try
                {
                    if (sender == this.BaseExpr)
                    {
                        for (int i = this.Expressions.Count - 1; i > 0; i--)
                        {
                            this.Expressions.RemoveAt(i);
                        }
                        this.AdjustOperator();
                    }
                    else
                    {
                        base.Changed();
                    }
                }
                finally
                {
                    this.EndUpdate();
                }
            }

            protected override bool GetHaving()
            {
                return ((this.BaseExpr is EntityAttrExpr) && ((EntityAttrExpr) this.BaseExpr).Attribute.IsAggregate);
            }

            public override string GetText(QueryTextFormats formats, string levelSpace, string prefix)
            {
                StringBuilder builder = new StringBuilder(levelSpace + prefix);
                DisplayFormatParser parser = new DisplayFormatParser();
                parser.Start(this.Operator.DisplayFormat);
                while (parser.Next())
                {
                    if (parser.Token == DisplayFormatParser.TokenType.Operator)
                    {
                        string mathSymbol;
                        if (formats.UseMathSymbolsForOperators)
                        {
                            mathSymbol = this.Operator.MathSymbol;
                        }
                        else
                        {
                            mathSymbol = this.Operator.MainText;
                        }
                        if (formats.UseHtml)
                        {
                            mathSymbol = formats.HtmlFormatting.Operator.Replace("{0}", mathSymbol);
                        }
                        builder.Append(mathSymbol);
                    }
                    else if (parser.Token == DisplayFormatParser.TokenType.Expression)
                    {
                        if ((this.expressions[parser.ExprNum - 1] == this.BaseExpr) && (this.BaseExpr is EntityAttrExpr))
                        {
                            DataModel.EntityAttr attribute = ((EntityAttrExpr) this.BaseExpr).Attribute;
                            string caption = attribute.Caption;
                            if (formats.ShowEntityName)
                            {
                                caption = attribute.Entity.GetFullName(".").Trim() + " " + caption;
                            }
                            if (formats.UseHtml)
                            {
                                caption = formats.HtmlFormatting.Expression.Replace("{0}", caption);
                            }
                            builder.Append(caption);
                        }
                        else
                        {
                            string text = this.expressions[parser.ExprNum - 1].Text;
                            if (text == string.Empty)
                            {
                                text = "{undefined}";
                            }
                            if (formats.UseHtml)
                            {
                                text = formats.HtmlFormatting.Text.Replace("{0}", text);
                            }
                            builder.Append(text);
                        }
                    }
                    else if (parser.Token == DisplayFormatParser.TokenType.Text)
                    {
                        string tokenText = parser.TokenText;
                        if (formats.UseHtml)
                        {
                            tokenText = formats.HtmlFormatting.Text.Replace("{0}", tokenText);
                        }
                        builder.Append(tokenText);
                    }
                    builder.Append(' ');
                }
                return builder.ToString();
            }

            protected internal override void GetUsedTables(DataModel.TableList usedTables)
            {
                if (this.Enabled)
                {
                    usedTables.AddRange(this.Operator.Tables);
                    foreach (Expression expression in this.Expressions)
                    {
                        if (expression is EntityAttrExpr)
                        {
                            usedTables.AddRange(((EntityAttrExpr) expression).Attribute.Tables);
                        }
                    }
                }
            }

            public override void LoadFromXmlNode(XmlNode rootNode)
            {
                base.LoadFromXmlNode(rootNode);
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        if (node.LocalName == "operator")
                        {
                            string opID = node.Attributes["id"].Value;
                            this.Operator = base.Model.Operators.FindByID(opID);
                        }
                        else if (node.LocalName == "expressions")
                        {
                            XmlElement element = (XmlElement) node;
                            foreach (XmlNode node2 in element.ChildNodes)
                            {
                                if (node2.NodeType == XmlNodeType.Element)
                                {
                                    XmlAttribute attribute = node2.Attributes["class"];
                                    if (attribute == null)
                                    {
                                        attribute = node2.Attributes["type"];
                                    }
                                    if (attribute != null)
                                    {
                                        Expression expression = Expression.Create(attribute.Value, base.Model);
                                        expression.LoadFromXmlNode((XmlElement) node2);
                                        this.Expressions.Add(expression);
                                    }
                                }
                            }
                            continue;
                        }
                    }
                }
            }

            public Expression RecreateValueExpr(int index)
            {
                DataType exprType = (this.Operator.ExprDefType != DataType.Unknown) ? this.Operator.ExprDefType : this.BaseExpr.DataType;
                Expression expr = this.CreateValueExpr(exprType, this.Operator.ValueKind);
                this.SetValueExpr(index, expr);
                return expr;
            }

            private void SetExprDefaults(Expression expr)
            {
                ValueEditor valueEditor = null;
                if ((this.BaseExpr != null) && (this.BaseExpr is EntityAttrExpr))
                {
                    valueEditor = ((EntityAttrExpr) this.BaseExpr).Attribute.GetValueEditor(this.Operator);
                }
                if (valueEditor != null)
                {
                    expr.Value = valueEditor.DefaultValue;
                    expr.Text = valueEditor.DefaultText;
                }
                else
                {
                    expr.Value = "";
                }
            }

            protected virtual void SetOperator(Korzh.EasyQuery.DataModel.Operator newOperator)
            {
                this.BeginUpdate();
                try
                {
                    this.operation = newOperator;
                    base.Changed();
                    if (this.operation != null)
                    {
                        this.AdjustExpressions();
                    }
                }
                finally
                {
                    this.EndUpdate();
                }
            }

            public void SetValueExpr(int index, Expression expr)
            {
                if (index < this.Expressions.Count)
                {
                    this.Expressions[index] = expr;
                }
                else
                {
                    DataType exprType = (this.Operator.ExprDefType != DataType.Unknown) ? this.Operator.ExprDefType : this.BaseExpr.DataType;
                    for (int i = this.Expressions.Count; i < index; i++)
                    {
                        this.Expressions.Add(this.CreateValueExpr(exprType, this.Operator.ValueKind));
                    }
                    this.Expressions.Add(expr);
                }
            }

            protected override void WriteContent(XmlWriter writer)
            {
                writer.WriteStartElement("operator");
                writer.WriteAttributeString("id", this.Operator.ID);
                writer.WriteEndElement();
                writer.WriteStartElement("expressions");
                foreach (Expression expression in this.Expressions)
                {
                    expression.SaveToXmlWriter(writer);
                }
                writer.WriteEndElement();
            }

            public Expression BaseExpr
            {
                get
                {
                    if (this.Expressions.Count <= 0)
                    {
                        return null;
                    }
                    return this.Expressions[0];
                }
                set
                {
                    if (value != this.BaseExpr)
                    {
                        if (this.BaseExpr != null)
                        {
                            this.BaseExpr.ContentChange -= new EventHandler(this.DoExprContentChanged);
                        }
                        if (this.Expressions.Count > 0)
                        {
                            this.Expressions[0] = value;
                        }
                        else
                        {
                            this.Expressions.Add(value);
                        }
                        if (value != null)
                        {
                            for (int i = this.Expressions.Count - 1; i > 0; i--)
                            {
                                this.Expressions.RemoveAt(i);
                            }
                        }
                        this.AdjustOperator();
                    }
                }
            }

            public string DefaultText
            {
                get
                {
                    string defaultText = "";
                    if (((this.BaseExpr != null) && (this.BaseExpr is EntityAttrExpr)) && ((this.Operator == null) || (this.Operator.ExprDefType == DataType.Unknown)))
                    {
                        ValueEditor valueEditor = ((EntityAttrExpr) this.BaseExpr).Attribute.GetValueEditor(this.Operator);
                        if (valueEditor != null)
                        {
                            defaultText = valueEditor.DefaultText;
                        }
                    }
                    return defaultText;
                }
            }

            public string DefaultValue
            {
                get
                {
                    string defaultValue = "";
                    if ((this.BaseExpr != null) && (this.BaseExpr is EntityAttrExpr))
                    {
                        ValueEditor valueEditor = ((EntityAttrExpr) this.BaseExpr).Attribute.GetValueEditor(this.Operator);
                        if (valueEditor != null)
                        {
                            defaultValue = valueEditor.DefaultValue;
                        }
                    }
                    return defaultValue;
                }
            }

            public Query.SimpleCondExprList Expressions
            {
                get
                {
                    return this.expressions;
                }
            }

            public Korzh.EasyQuery.DataModel.Operator Operator
            {
                get
                {
                    return this.operation;
                }
                set
                {
                    if (this.operation != value)
                    {
                        this.SetOperator(value);
                    }
                }
            }

            public static string STypeName
            {
                get
                {
                    return "SMPL";
                }
            }

            public override string TypeName
            {
                get
                {
                    return STypeName;
                }
            }
        }

        internal class SimpleConditionCreator : Query.IConditionCreator
        {
            public Query.Condition Create(DataModel model)
            {
                return new Query.SimpleCondition(model);
            }
        }

        public class SortedColumnList : Query.ColumnList, IComparer
        {
            private Query parentQuery;
            private int updatingLevel;
            private bool wasChange;

            public SortedColumnList(Query query)
            {
                this.parentQuery = query;
            }

            public override int Add(object value)
            {
                int index = 0;
                Query.Column column = (Query.Column) value;
                if (column.innerSortIndex >= 0)
                {
                    while ((index < this.Count) && (base[index].innerSortIndex < column.innerSortIndex))
                    {
                        index++;
                    }
                }
                else
                {
                    index = this.Count;
                }
                base.Insert(index, column);
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
                return index;
            }

            public override void AddRange(ICollection c)
            {
                base.AddRange(c);
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
            }

            public void BeginUpdate()
            {
                if (this.updatingLevel == 0)
                {
                    this.wasChange = false;
                }
                this.updatingLevel++;
            }

            public override void Clear()
            {
                base.Clear();
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
            }

            public int Compare(object x, object y)
            {
                if (((Query.Column) x).innerSortIndex < ((Query.Column) y).innerSortIndex)
                {
                    return -1;
                }
                if (((Query.Column) x).innerSortIndex > ((Query.Column) y).innerSortIndex)
                {
                    return 1;
                }
                return 0;
            }

            protected virtual void CoreSortOrderChanged(SortOrderChangedEventArgs e)
            {
                this.wasChange = true;
                if ((this.parentQuery != null) && !this.Updating)
                {
                    this.parentQuery.InnerSortOrderChanged(e);
                }
            }

            public void EndUpdate()
            {
                if (this.updatingLevel > 0)
                {
                    this.updatingLevel--;
                }
                if ((this.updatingLevel == 0) && this.wasChange)
                {
                    this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
                    this.wasChange = false;
                }
            }

            public override void Insert(int index, object value)
            {
                if (index > this.Count)
                {
                    index = this.Count;
                }
                base.Insert(index, value);
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
            }

            public override void InsertRange(int index, ICollection c)
            {
                base.InsertRange(index, c);
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
            }

            public void Move(Query.Column col, int shift)
            {
                int index = this.IndexOf(col);
                int num2 = index + shift;
                if (index >= 0)
                {
                    if (num2 < 0)
                    {
                        num2 = 0;
                    }
                    if (num2 >= this.Count)
                    {
                        num2 = this.Count - 1;
                    }
                    this.BeginUpdate();
                    try
                    {
                        this.RemoveAt(index);
                        this.Insert(num2, col);
                    }
                    finally
                    {
                        this.EndUpdate();
                    }
                }
            }

            public void Move(int index, int newIndex)
            {
                if (((index >= 0) && (newIndex >= 0)) && (((index < this.Count) && (newIndex < this.Count)) && (index != newIndex)))
                {
                    Query.Column column = base[index];
                    this.BeginUpdate();
                    try
                    {
                        this.RemoveAt(index);
                        this.Insert(newIndex, column);
                    }
                    finally
                    {
                        this.EndUpdate();
                    }
                }
            }

            public override void RemoveAt(int index)
            {
                base.RemoveAt(index);
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
            }

            public override void RemoveRange(int index, int count)
            {
                base.RemoveRange(index, count);
                this.CoreSortOrderChanged(SortOrderChangedEventArgs.Default);
            }

            protected internal bool Updating
            {
                get
                {
                    return (this.updatingLevel > 0);
                }
            }
        }
    }
}

