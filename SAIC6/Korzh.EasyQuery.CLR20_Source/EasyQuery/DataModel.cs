namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using System.Text;
    using System.Xml;

    [Serializable, ToolboxBitmap(typeof(DataModel))]
    public class DataModel : Component, ISerializable
    {
        public readonly AggrFunctionList AggrFunctions;
        public static readonly OperatorGroup AnyOperatorGroup = new OperatorGroup("[Any group]", new DataTypeList());
        public static DataTypeList CommonDataTypes = new DataTypeList(new DataType[] { DataType.String, DataType.WideString, DataType.Byte, DataType.Word, DataType.Int, DataType.Int64, DataType.Bool, DataType.Float, DataType.Currency, DataType.BCD, DataType.Autoinc, DataType.Memo, DataType.FixedChar });
        public static readonly OperatorGroup CommonOperatorGroup = new OperatorGroup("Common operators", CommonDataTypes);
        private string customInfo;
        private DbParameters dbParams;
        private string defQueryFilePath;
        private string description;
        private Entity entityRoot;
        private string filePath;
        private int formatVersion;
        public static readonly int LastFormatVersion = 5;
        public readonly LinksStorage Links;
        public readonly MacroList Macros;
        private int maxEntAttrID;
        private string modelName;
        private EntityAttr nullAttribute;
        public static Operator NullOperator = new Operator("null", "Unrecognized operator", "{expr1} unrecognized {expr2}", "{expr1} {op} {expr2}");
        public static OperatorGroupList OperatorGroups = new OperatorGroupList(new OperatorGroup[] { CommonOperatorGroup, StringOperatorGroup, TimeOperatorGroup, OtherOperatorGroup });
        public readonly OperatorList Operators;
        public static readonly OperatorGroup OtherOperatorGroup = new OperatorGroup("Other operators", CommonDataTypes);
        public static readonly DataTypeList RangeDataTypes = new DataTypeList(new DataType[] { DataType.Byte, DataType.Word, DataType.Int, DataType.Int64, DataType.Bool, DataType.Float, DataType.Currency, DataType.BCD, DataType.Autoinc });
        private bool storeDbParams;
        public static readonly DataTypeList StringDataTypes = new DataTypeList(new DataType[] { DataType.String, DataType.WideString, DataType.Memo, DataType.FixedChar });
        public static readonly OperatorGroup StringOperatorGroup = new OperatorGroup("String operators", StringDataTypes);
        private TableList tables;
        private TextStorage texts;
        public static readonly DataTypeList TimeDataTypes = new DataTypeList(new DataType[] { DataType.Date, DataType.Time, DataType.DateTime });
        public static readonly OperatorGroup TimeOperatorGroup = new OperatorGroup("Date/time operators", TimeDataTypes);
        private TypeOperatorMap toMap;
        private bool useResourcesForOperators;

        static DataModel()
        {
            ValueEditor.RegisterType(TextValueEditor.STypeName, new TextValueEditorCreator());
            ValueEditor.RegisterType(DateTimeValueEditor.STypeName, new DateTimeValueEditorCreator());
            ValueEditor.RegisterType("DATE", new DateValueEditorCreator());
            ValueEditor.RegisterType("TIME", new TimeValueEditorCreator());
            ValueEditor.RegisterType(ConstListValueEditor.STypeName, new ConstListValueEditorCreator());
            ValueEditor.RegisterType("CUSTOMLIST", new CustomListValueEditorCreator());
            ValueEditor.RegisterType("LISTBOX", new ListBoxValueEditorCreator());
            ValueEditor.RegisterType("MULTILIST", new MultiListBoxValueEditorCreator());
            ValueEditor.RegisterType(SqlListValueEditor.STypeName, new SqlListValueEditorCreator());
            ValueEditor.RegisterType(CustomValueEditor.STypeName, new CustomValueEditorCreator());
        }

        public DataModel()
        {
            this.formatVersion = LastFormatVersion;
            this.Links = new LinksStorage();
            this.Operators = new OperatorList();
            this.AggrFunctions = new AggrFunctionList();
            this.Macros = new MacroList();
            this.useResourcesForOperators = true;
            this.defQueryFilePath = "";
            this.storeDbParams = true;
            this.customInfo = "";
            this.filePath = "";
            this.texts = new TextStorage();
            this.ReloadResources();
            this.dbParams = new DbParameters();
            this.toMap = new TypeOperatorMap();
            this.RefillAggrFunctionList();
            this.AddDefaultMacros();
            this.tables = new TablesStorage(this);
            this.entityRoot = new RootEntity(this);
            Entity entity = new Entity();
            entity.Name = "";
            this.nullAttribute = new EntityAttr();
            this.nullAttribute.Caption = "{unrecognized attribute}";
            this.nullAttribute.UseInConditions = false;
            this.nullAttribute.UseInResult = false;
            this.nullAttribute.UseInSorting = false;
            entity.Attributes.Add(this.nullAttribute);
        }

        protected DataModel(SerializationInfo info, StreamingContext context)
            : this()
        {
            string xmlText = info.GetString("ModelXml");
            this.LoadFromString(xmlText);
        }

        private void AddDefaultMacros()
        {
            foreach (TimeMacroType type in Enum.GetValues(typeof(TimeMacroType)))
            {
                this.Macros.Add(new TimeMacro(type));
            }
        }

        public void AddDefaultOperators()
        {
            this.AddUpdateOperator("Equal", "", "{expr1} = {expr2}", "{expr1} [[is equal to]] {expr2}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("NotEqual", "no sea igual a", "{expr1} <> {expr2}", "{expr1} [[is not equal to]] {expr2}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("LessThan", "sea menor que", "{expr1} < {expr2}", "{expr1} [[is less than]] {expr2}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("LessOrEqual", "sea menor que o igual a", "{expr1} <= {expr2}", "{expr1} [[is less than or equal to]] {expr2}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("GreaterThan", "sea mayor que", "{expr1} > {expr2}", "{expr1} [[is greater than]] {expr2}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("GreaterOrEqual", "sea mayor que o igual a", "{expr1} >= {expr2}", "{expr1} [[is greater than or equal to]] {expr2}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("IsNull", "sea vacio", "{expr1} IS NULL", "{expr1} [[is null]]", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("IsNotNull", "no sea vacio", "{expr1} IS NOT NULL", "{expr1} [[is not null]]", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("InList", "este enlistado", "{expr1} in ({expr2})", "{expr1} [[is in list]] {expr2}", DataKind.List, CommonOperatorGroup);
            this.AddUpdateOperator("NotInList", "no este enlistado", "NOT ({expr1} in ({expr2}))", "{expr1} [[is not in list]] {expr2}", DataKind.List, CommonOperatorGroup);
            this.AddUpdateOperator("Between", "este entre", "{expr1} BETWEEN {expr2} AND {expr3}", "{expr1} [[is between]] {expr2} and {expr3}", DataKind.Scalar, CommonOperatorGroup);
            this.AddUpdateOperator("NotBetween", "no este entre", "NOT ({expr1} BETWEEN {expr2} AND {expr3})", "{expr1} [[is not between]] {expr2} and {expr3}", DataKind.Scalar, CommonOperatorGroup);
            Operator @operator = this.AddUpdateOperator("StartsWith", "empieze con", "{expr1} LIKE {expr2}", "{expr1} [[starts with]] {expr2}", DataKind.Scalar, StringOperatorGroup);
            @operator.DefaultEditor = new TextValueEditor();
            @operator.ConstValueFormat = "{const}{ws}";
            @operator = this.AddUpdateOperator("NotStartsWith", "no empieze con", "NOT ({expr1} LIKE {expr2})", "{expr1} [[does not start with]] s{expr2}", DataKind.Scalar, StringOperatorGroup);
            @operator.DefaultEditor = new TextValueEditor();
            @operator.ConstValueFormat = "{const}{ws}";
            @operator = this.AddUpdateOperator("Contains", "contenga", "{expr1} LIKE {expr2}", "{expr1}  [[contains]] {expr2}", DataKind.Scalar, StringOperatorGroup);
            @operator.DefaultEditor = new TextValueEditor();
            @operator.ConstValueFormat = "{ws}{const}{ws}";
            @operator = this.AddUpdateOperator("NotContains", "no contenga", "NOT ({expr1} LIKE {expr2})", "{expr1} [[does not contain]] {expr2}", DataKind.Scalar, StringOperatorGroup);
            @operator.DefaultEditor = new TextValueEditor();
            @operator.ConstValueFormat = "{ws}{const}{ws}";
            this.AddUpdateOperator("InSubQuery", "en subconsulta", "{expr1} IN ({expr2})", "{expr1} [[in sub query]] {expr2}", DataKind.Query, CommonOperatorGroup).ExprDefType = DataType.Byte;
            CustomListValueEditor editor = new CustomListValueEditor();
            editor.ListName = "SpecDateValues";
            DateTimeValueEditor editor2 = new DateTimeValueEditor();
            editor2.SubType = DataType.Date;
            CustomListValueEditor editor3 = new CustomListValueEditor();
            editor3.ListName = "SpecTimeValues";
            DateTimeValueEditor editor4 = new DateTimeValueEditor();
            editor2.SubType = DataType.Time;
            @operator = this.AddUpdateOperator("DateEqualSpecial", "sea (fecha especial)", "{expr1} = {expr2}", "{expr1} [[is]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateEqualPrecise", "sea (precisar fecha)", "{expr1} = {expr2}", "{expr1} [[is]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor2;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateNotEqualSpecial", "no sea", "{expr1} <> {expr2}", "{expr1} [[is not]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateNotEqualPrecise", "no sea", "{expr1} <> {expr2}", "{expr1} [[is not]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor2;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateBeforeSpecial", "sea antes (fecha especial)", "{expr1} < {expr2}", "{expr1} [[is before]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateBeforePrecise", "sea antes (precisar fecha)", "{expr1} < {expr2}", "{expr1} [[is before]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor2;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateAfterSpecial", "sea despues (fecha especial)", "{expr1} >= {expr2}", "{expr1} [[is after]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DateAfterPrecise", "sea despues (precisar fecha)", "{expr1} >= {expr2}", "{expr1} [[is after]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor2;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("DatePeriodPrecise", "este entre", "{expr1} BETWEEN {expr2} AND {expr3}", "{expr1} [[is between]] {expr2} and {expr3}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor2;
            @operator.AppliedTypes.Remove(DataType.Time);
            @operator = this.AddUpdateOperator("TimeBeforeSpecial", "sea antes (tiempo especial)", "{expr1} < {expr2}", "{expr1} [[is before]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor3;
            @operator.AppliedTypes.Remove(DataType.Date);
            @operator.AppliedTypes.Remove(DataType.DateTime);
            @operator = this.AddUpdateOperator("TimeBeforePrecise", "sea antes (precisar tiempo)", "{expr1} < {expr2}", "{expr1} [[is before]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor4;
            @operator.AppliedTypes.Remove(DataType.Date);
            @operator.AppliedTypes.Remove(DataType.DateTime);
            @operator = this.AddUpdateOperator("TimeAfterSpecial", "sea despues (tiempo especial)", "{expr1} >= {expr2}", "{expr1} [[is after]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor3;
            @operator.AppliedTypes.Remove(DataType.Date);
            @operator.AppliedTypes.Remove(DataType.DateTime);
            @operator = this.AddUpdateOperator("TimeAfterPrecise", "sea despues (precisar tiempo)", "{expr1} >= {expr2}", "{expr1} [[is after]] {expr2}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor4;
            @operator.AppliedTypes.Remove(DataType.Date);
            @operator.AppliedTypes.Remove(DataType.DateTime);
            @operator = this.AddUpdateOperator("TimePeriodPrecise", "este entre", "{expr1} BETWEEN {expr2} AND {expr3}", "{expr1} [[is between]] {expr2} and {expr3}", DataKind.Scalar, TimeOperatorGroup);
            @operator.DefaultEditor = editor4;
            @operator.AppliedTypes.Remove(DataType.Date);
            @operator.AppliedTypes.Remove(DataType.DateTime);
            @operator = this.AddUpdateOperator("MaximumOfAttr", "sea máximo de", "{expr1} = (SELECT MAX({expr2.field}) from {expr2.table})", "{expr1} [[is maximum of]] {expr2}", DataKind.Attribute, OtherOperatorGroup);
            @operator.AppliedTypes.Add(DataType.Date);
            @operator.AppliedTypes.Add(DataType.DateTime);
            @operator.AppliedTypes.Add(DataType.Time);
            if (this.useResourcesForOperators)
            {
                this.UpdateOperatorsTexts();
            }
        }

        protected Operator AddUpdateOperator(string id, string caption, string expr, string format, DataKind kind, OperatorGroup group)
        {
            Operator @operator = this.Operators.FindByID(id);
            if (@operator == null)
            {
                @operator = new Operator(id, caption, expr, format);
                this.Operators.Add(@operator);
            }
            @operator.Caption = caption;
            @operator.DisplayFormat = format;
            @operator.Expr = expr;
            @operator.ValueKind = kind;
            @operator.Group = group;
            return @operator;
        }

        public void AssignEntityAttrID(EntityAttr attr)
        {
            SqlFormats formats = new SqlFormats();
            formats.SqlQuote1 = '{';
            formats.SqlQuote2 = '}';
            string val = "";
            if (attr.Kind == EntAttrKind.Data)
            {
                string sqlExpr = attr.GetSqlExpr(formats);
                val = sqlExpr;
                int num = 1;
                while (this.EntityRoot.FindAttribute(EntAttrProp.ID, val) != null)
                {
                    num++;
                    val = sqlExpr + num.ToString();
                }
            }
            else
            {
                val = "VEA_" + this.GetNextEntityAttrID().ToString();
            }
            attr.ID = val;
        }

        public Path CalcPath(Table table1, Table table2)
        {
            PathList list = new PathList();
            PathList nextStep = new PathList();
            bool flag = false;
            Path path = new Path();
            path.Add(table1);
            list.Add(path);
            while (!flag)
            {
                nextStep.Clear();
                foreach (Path path2 in list)
                {
                    flag = this.CheckPath(path2, table2, nextStep);
                    if (flag)
                    {
                        path2.Add(table2);
                        path = path2;
                        break;
                    }
                }
                list.Clear();
                if (!flag)
                {
                    if (nextStep.Count == 0)
                    {
                        throw new Error(string.Format("Can not find path between tables \"{0}\" and \"{1}\"", table1.Name, table2.Name));
                    }
                    foreach (Path path3 in nextStep)
                    {
                        list.Add(path3);
                    }
                }
            }
            return path;
        }

        private bool CheckPath(Path path, Table destTable, PathList nextStep)
        {
            Table endPoint = path.EndPoint;
            foreach (Link link in endPoint.Links)
            {
                Table table2 = null;
                if (link.Table1 == endPoint)
                {
                    table2 = link.Table2;
                }
                else
                {
                    table2 = link.Table1;
                }
                if (table2 == destTable)
                {
                    nextStep.Clear();
                    return true;
                }
                if (path.IndexOf(table2) < 0)
                {
                    Path path2 = new Path();
                    path2.AddRange(path);
                    path2.Add(table2);
                    nextStep.Add(path2);
                }
            }
            return false;
        }

        public void Clear()
        {
            this.Operators.Clear();
            this.Tables.Clear();
            this.Links.Clear();
            this.EntityRoot.Attributes.Clear();
            this.EntityRoot.SubEntities.Clear();
        }

        public void FillAttributeOperators(EntityAttr entityAttr)
        {
        }

        public void FillByDataTable(DataTable dataTable, bool createEntity)
        {
            Entity entityRoot;
            Table table = this.Tables.FindByName(dataTable.TableName);
            if (table == null)
            {
                table = new Table();
                table.Name = dataTable.TableName;
                this.Tables.Add(table);
            }
            if (createEntity)
            {
                entityRoot = new Entity();
                entityRoot.Name = table.Name;
                this.EntityRoot.SubEntities.Add(entityRoot);
            }
            else
            {
                entityRoot = this.EntityRoot;
            }
            foreach (DataColumn column in dataTable.Columns)
            {
                EntityAttr attr = new EntityAttr();
                attr.Caption = column.ColumnName;
                attr.Tables.Add(table);
                attr.Expr = column.ColumnName;
                attr.DataType = Utils.GetDataTypeBySystemType(column.DataType);
                attr.Size = column.MaxLength;
                attr.FillOperatorsWithDefaults(this);
                this.AssignEntityAttrID(attr);
                entityRoot.Attributes.Add(attr);
            }
        }

        private XmlElement findElementByName(XmlElement parentNode, string name)
        {
            if (string.Compare(parentNode.LocalName, name, true) == 0)
            {
                return parentNode;
            }
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    XmlElement element = this.findElementByName((XmlElement)node, name);
                    if (element != null)
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        public OperatorList GetDefaultOperatorsForDataType(DataType dataType)
        {
            OperatorList operats = new OperatorList();
            this.ListDefaultOperatorsForDataType(operats, dataType);
            return operats;
        }

        public EntityAttr GetDefaultUICAttribute()
        {
            return this.GetUICAttributeFromEntity(this.EntityRoot);
        }

        public EntityAttr GetDefaultUIRAttribute()
        {
            return this.GetDefaultUIRAttribute(false);
        }

        public EntityAttr GetDefaultUIRAttribute(bool needUseInSorting)
        {
            return this.GetUIRAttributeFromEntity(this.EntityRoot, needUseInSorting);
        }

        private int GetNextEntityAttrID()
        {
            return ++this.maxEntAttrID;
        }

        private EntityAttr GetUICAttributeFromEntity(Entity entity)
        {
            foreach (EntityAttr attr in entity.Attributes)
            {
                if (attr.UseInConditions)
                {
                    return attr;
                }
            }
            foreach (Entity entity2 in entity.SubEntities)
            {
                EntityAttr uICAttributeFromEntity = this.GetUICAttributeFromEntity(entity2);
                if (uICAttributeFromEntity != null)
                {
                    return uICAttributeFromEntity;
                }
            }
            return null;
        }

        private EntityAttr GetUIRAttributeFromEntity(Entity entity)
        {
            return this.GetUIRAttributeFromEntity(entity, false);
        }

        private EntityAttr GetUIRAttributeFromEntity(Entity entity, bool needUseInSorting)
        {
            foreach (EntityAttr attr in entity.Attributes)
            {
                if (attr.UseInResult && (!needUseInSorting || attr.UseInSorting))
                {
                    return attr;
                }
            }
            foreach (Entity entity2 in entity.SubEntities)
            {
                EntityAttr uIRAttributeFromEntity = this.GetUIRAttributeFromEntity(entity2, needUseInSorting);
                if (uIRAttributeFromEntity != null)
                {
                    return uIRAttributeFromEntity;
                }
            }
            return null;
        }

        public void ListDefaultOperatorsForDataType(OperatorList operats, DataType dataType)
        {
            operats.Clear();
            switch (dataType)
            {
                case DataType.String:
                case DataType.WideString:
                case DataType.Memo:
                    operats.AddByIDs(this, "StartsWith,Contains,Equal,NotStartsWith,NotContains,NotEqual,InSubQuery,IsNull");
                    return;

                case DataType.Byte:
                case DataType.Word:
                case DataType.Int:
                case DataType.Int64:
                case DataType.Float:
                case DataType.Currency:
                case DataType.BCD:
                case DataType.Autoinc:
                    operats.AddByIDs(this, "Equal,Between,LessThan,LessOrEqual,GreaterThan,GreaterOrEqual,NotBetween,NotEqual,MaximumOfAttr,InSubQuery,IsNull");
                    return;

                case DataType.Bool:
                    operats.AddByIDs(this, "Equal,NotEqual,IsNull");
                    return;

                case DataType.Date:
                case DataType.DateTime:
                    operats.AddByIDs(this, "DateEqualSpecial,DateEqualPrecise,DateNotEqualSpecial,DateNotEqualPrecise,DateBeforeSpecial,DateBeforePrecise,DateAfterSpecial,DateAfterPrecise,DatePeriodPrecise,MaximumOfAttr,IsNull");
                    return;

                case DataType.Time:
                    operats.AddByIDs(this, "TimeEqualSpecial,TimeEqualPrecise,TimeNotEqualSpecial,TimeNotEqualPrecise,TimeBeforeSpecial,TimeBeforePrecise,TimeAfterSpecial,TimeAfterPrecise,TimePeriodPrecise,MaximumOfAttr,IsNull");
                    return;
            }
            foreach (Operator @operator in this.Operators)
            {
                if (@operator.AppliedTypes.IndexOf(dataType) >= 0)
                {
                    operats.Add(@operator);
                }
            }
        }

        private void LoadAttributeNode(EntityAttr entityAttr, XmlElement attrNode)
        {
            entityAttr.ID = attrNode.GetAttribute("ID");
            entityAttr.Kind = EntityAttr.StrToEntAttrKind(attrNode.GetAttribute("KIND"));
            entityAttr.Caption = attrNode.GetAttribute("CAPTION");
            entityAttr.Expr = attrNode.GetAttribute("EXPR");
            entityAttr.DataType = Utils.DataTypeByName(attrNode.GetAttribute("TYPE"));
            entityAttr.Size = int.Parse(attrNode.GetAttribute("SIZE"));
            string str = attrNode.GetAttribute("QUOTE");
            if (str != string.Empty)
            {
                entityAttr.Quote = bool.Parse(str);
            }
            entityAttr.UseInConditions = bool.Parse(attrNode.GetAttribute("UIC"));
            entityAttr.UseInResult = bool.Parse(attrNode.GetAttribute("UIR"));
            str = attrNode.GetAttribute("UIS");
            if (str != string.Empty)
            {
                entityAttr.UseInSorting = bool.Parse(str);
            }
            str = attrNode.GetAttribute("UAL");
            if (str != string.Empty)
            {
                entityAttr.UseAlias = bool.Parse(str);
            }
            str = attrNode.GetAttribute("AGGR");
            if (str != string.Empty)
            {
                entityAttr.IsAggregate = bool.Parse(str);
            }
            XmlAttribute attributeNode = attrNode.GetAttributeNode("TABLE");
            if (attributeNode != null)
            {
                Table table = this.Tables.FindByAlias(attributeNode.Value);
                entityAttr.Tables.Add(table);
            }
            attributeNode = attrNode.GetAttributeNode("TABLES");
            if (attributeNode != null)
            {
                char[] separator = new char[] { ',' };
                string[] strArray = attributeNode.Value.Split(separator);
                Table table2 = null;
                foreach (string str2 in strArray)
                {
                    table2 = this.Tables.FindByAlias(str2);
                    if (table2 != null)
                    {
                        entityAttr.Tables.Add(table2);
                    }
                }
            }
            foreach (XmlNode node in attrNode.ChildNodes)
            {
                if (node.LocalName == "OPERATORS")
                {
                    char[] chArray2 = new char[] { ',' };
                    string[] strArray2 = node.InnerText.Split(chArray2);
                    Operator @operator = null;
                    foreach (string str3 in strArray2)
                    {
                        @operator = this.Operators.FindByID(str3);
                        if (@operator != null)
                        {
                            entityAttr.Operations.Add(@operator);
                        }
                    }
                    continue;
                }
                if (node.LocalName == "EDITORS")
                {
                    foreach (XmlNode node2 in node.ChildNodes)
                    {
                        ValueEditor editor = ValueEditor.Create(node2.Attributes["TYPE"].Value);
                        if (editor != null)
                        {
                            editor.LoadFromXmlNode(node2);
                        }
                        if (node2.LocalName == "DEFAULT")
                        {
                            entityAttr.DefaultEditor = editor;
                        }
                        else
                        {
                            entityAttr.Editors.Add(editor);
                        }
                    }
                    continue;
                }
                if (node.LocalName == "DESCRIPTION")
                {
                    entityAttr.Description = node.InnerText;
                }
                else if (node.LocalName == "USERDATA")
                {
                    entityAttr.UserData = node.InnerText;
                }
            }
        }

        private void LoadDbParamsNode(XmlElement dbpRoot)
        {
            XmlAttribute attribute = dbpRoot.Attributes["Name"];
            if (attribute != null)
            {
                this.DbParams["DbName"] = attribute.Value;
            }
            foreach (XmlNode node in dbpRoot.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    this.DbParams[node.LocalName] = node.InnerText;
                }
            }
        }

        private void LoadEntitiesNode(XmlElement entRoot)
        {
            XmlAttribute attribute = entRoot.Attributes["MAXID"];
            if (attribute != null)
            {
                this.maxEntAttrID = int.Parse(attribute.Value);
            }
            this.LoadEntityNode(this.EntityRoot, entRoot);
        }

        private void LoadEntityNode(Entity entity, XmlElement groupNode)
        {
            entity.Name = groupNode.GetAttribute("NAME");
            string str = (this.formatVersion < 2) ? "GROUP" : "ENTITY";
            string str2 = (this.formatVersion < 2) ? "ENTITY" : "ATTR";
            for (int i = 0; i < groupNode.ChildNodes.Count; i++)
            {
                XmlNode node = groupNode.ChildNodes[i];
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (node.LocalName == "USERDATA")
                    {
                        entity.UserData = node.InnerText;
                    }
                    else if (node.LocalName == str)
                    {
                        Entity entity2 = new Entity();
                        this.LoadEntityNode(entity2, (XmlElement)node);
                        entity.SubEntities.Add(entity2);
                    }
                    else if (node.LocalName == str2)
                    {
                        EntityAttr entityAttr = new EntityAttr();
                        this.LoadAttributeNode(entityAttr, (XmlElement)node);
                        entity.Attributes.Add(entityAttr);
                    }
                }
            }
        }

        public void LoadFromFile(string path)
        {
            this.filePath = path;
            FileStream inStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlDocument document = new XmlDocument();
            document.Load(inStream);
            this.LoadFromXmlNode(document.DocumentElement);
            inStream.Close();
        }

        public void LoadFromString(string xmlText)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlText);
            this.LoadFromXmlNode(document.DocumentElement);
        }

        public void LoadFromXmlNode(XmlElement rootNode)
        {
            this.Clear();
            XmlAttribute attribute = rootNode.Attributes["Version"];
            this.formatVersion = (attribute != null) ? int.Parse(attribute.Value) : 1;
            if (this.formatVersion > LastFormatVersion)
            {
                throw new Error(string.Concat(new object[] { "Can not load data model created in newer version of EasyQuery.NET\nLast supported version:", LastFormatVersion, "; Loaded model version:", this.formatVersion }));
            }
            attribute = rootNode.Attributes["Name"];
            if (attribute != null)
            {
                this.ModelName = attribute.Value;
            }
            attribute = rootNode.Attributes["DefQuery"];
            this.defQueryFilePath = (attribute != null) ? attribute.Value : string.Empty;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (string.Compare(node.LocalName, "NAME", true) == 0)
                    {
                        this.modelName = node.InnerText;
                    }
                    if (string.Compare(node.LocalName, "DESCRIPTION", true) == 0)
                    {
                        this.description = node.InnerText;
                    }
                    else
                    {
                        if ((node.LocalName == "DBPARAMS") && this.StoreDbParams)
                        {
                            this.LoadDbParamsNode((XmlElement)node);
                            continue;
                        }
                        if (node.LocalName == "CUSTOMINFO")
                        {
                            this.LoadDbParamsNode((XmlElement)node);
                            continue;
                        }
                        if (node.LocalName == "TABLES")
                        {
                            this.LoadTablesNode((XmlElement)node);
                            continue;
                        }
                        if (node.LocalName == "LINKS")
                        {
                            this.LoadLinksNode((XmlElement)node);
                            continue;
                        }
                        if (node.LocalName == "OPERATORS")
                        {
                            this.LoadOperatorsNode((XmlElement)node);
                            continue;
                        }
                        if (node.LocalName == "ENTITIES")
                        {
                            this.LoadEntitiesNode((XmlElement)node);
                        }
                    }
                }
            }
            if (this.useResourcesForOperators)
            {
                this.UpdateOperatorsTexts();
            }
        }

        private void LoadLinkConditionNode(Link link, XmlElement condNode)
        {
            Link.Condition condition = new Link.Condition(link);
            condition.CondType = Link.Condition.StrToLinkCondType(condNode.GetAttribute("TYPE"));
            condition.Expr1 = condNode.GetAttribute("EXPR1");
            condition.Expr2 = condNode.GetAttribute("EXPR2");
            condition.Operator = condNode.GetAttribute("OP");
            link.Conditions.Add(condition);
        }

        private void LoadLinkNode(XmlElement linkNode)
        {
            Link link = new Link();
            string attribute = linkNode.GetAttribute("TABLE1");
            link.Table1 = this.Tables.FindByAlias(attribute);
            if (link.Table1 == null)
            {
                throw new Error("Can not find table: " + attribute);
            }
            string alias = linkNode.GetAttribute("TABLE2");
            link.Table2 = this.Tables.FindByAlias(alias);
            if (link.Table2 == null)
            {
                throw new Error("Can not find table: " + alias);
            }
            link.Type = Link.StrToLinkType(linkNode.GetAttribute("TYPE"));
            string str3 = linkNode.GetAttribute("QF");
            if (str3 != string.Empty)
            {
                link.QuoteFields = bool.Parse(str3);
            }
            foreach (XmlElement element in linkNode.GetElementsByTagName("CONDITION"))
            {
                this.LoadLinkConditionNode(link, element);
            }
            this.Links.Add(link);
        }

        private void LoadLinksNode(XmlElement linksRoot)
        {
            foreach (XmlElement element in linksRoot.GetElementsByTagName("LINK"))
            {
                this.LoadLinkNode(element);
            }
        }

        private void LoadOperatorNode(XmlElement opNode)
        {
            Operator @operator = new Operator();
            @operator.ID = opNode.GetAttribute("ID");
            @operator.Caption = opNode.GetAttribute("CAPTION");
            @operator.Expr = opNode.GetAttribute("EXPR");
            @operator.DisplayFormat = opNode.GetAttribute("FORMAT");
            @operator.ValueKind = Utils.DataKindByName(opNode.GetAttribute("KIND"));
            string str = opNode.GetAttribute("MAINTEXT");
            if (str != null)
            {
                @operator.DisplayFormat = @operator.DisplayFormat.Replace("{op}", "[[" + str + "]]");
            }
            str = opNode.GetAttribute("CONSTFMT");
            if (str != null)
            {
                @operator.ConstValueFormat = str;
            }
            if (this.FormatVersion < 5)
            {
                if (string.Compare(@operator.ID, "StartsWith", true) == 0)
                {
                    @operator.ConstValueFormat = "{const}{ws}";
                }
                else if (string.Compare(@operator.ID, "NotStartsWith", true) == 0)
                {
                    @operator.ConstValueFormat = "{const}{ws}";
                }
                else if (string.Compare(@operator.ID, "Contains", true) == 0)
                {
                    @operator.ConstValueFormat = "{ws}{const}{ws}";
                }
                else if (string.Compare(@operator.ID, "NotContains", true) == 0)
                {
                    @operator.ConstValueFormat = "{ws}{const}{ws}";
                }
                else
                {
                    @operator.ConstValueFormat = "{const}";
                }
            }
            XmlAttribute attributeNode = opNode.Attributes["CASEINS"];
            if (attributeNode != null)
            {
                @operator.CaseInsensitive = bool.Parse(attributeNode.Value);
            }
            OperatorGroup group = null;
            attributeNode = opNode.Attributes["GROUP"];
            if (attributeNode != null)
            {
                group = OperatorGroups.FindByName(attributeNode.Value);
            }
            if (group != null)
            {
                @operator.Group = group;
            }
            else if (((@operator.ID == "StartsWith") || (@operator.ID == "NotStartsWith")) || ((@operator.ID == "Contains") || (@operator.ID == "NotContains")))
            {
                @operator.Group = StringOperatorGroup;
            }
            else
            {
                @operator.Group = CommonOperatorGroup;
            }
            attributeNode = opNode.Attributes["condition"];
            if (attributeNode != null)
            {
                @operator.IsCondition = bool.Parse(attributeNode.Value);
            }
            attributeNode = opNode.GetAttributeNode("tables");
            if (attributeNode != null)
            {
                char[] separator = new char[] { ',' };
                string[] strArray = attributeNode.Value.Split(separator);
                Table table = null;
                foreach (string str2 in strArray)
                {
                    table = this.Tables.FindByAlias(str2);
                    if (table != null)
                    {
                        @operator.Tables.Add(table);
                    }
                }
            }
            foreach (XmlNode node in opNode.ChildNodes)
            {
                if (node.LocalName == "TYPES")
                {
                    char[] chArray2 = new char[] { ',' };
                    foreach (string str3 in node.InnerText.Split(chArray2))
                    {
                        DataType unknown;
                        try
                        {
                            unknown = (DataType)Enum.Parse(typeof(DataType), str3, true);
                        }
                        catch (Exception)
                        {
                            unknown = DataType.Unknown;
                        }
                        @operator.AppliedTypes.Add(unknown);
                    }
                    continue;
                }
                if (node.LocalName == "EXPRS")
                {
                    attributeNode = node.Attributes["DefType"];
                    if (attributeNode != null)
                    {
                        @operator.ExprDefType = Utils.DataTypeByName(attributeNode.Value);
                    }
                }
                else if (node.LocalName == "EDITORS")
                {
                    foreach (XmlNode node2 in node.ChildNodes)
                    {
                        ValueEditor editor = ValueEditor.Create(node2.Attributes["TYPE"].Value);
                        if (editor != null)
                        {
                            editor.LoadFromXmlNode(node2);
                        }
                        if (node2.LocalName == "DEFAULT")
                        {
                            @operator.DefaultEditor = editor;
                        }
                    }
                    continue;
                }
            }
            if (((this.FormatVersion < 4) && (@operator.DefaultEditor == null)) && (((@operator.ID == "StartsWith") || (@operator.ID == "NotStartsWith")) || ((@operator.ID == "Contains") || (@operator.ID == "NotContains"))))
            {
                @operator.DefaultEditor = new TextValueEditor();
            }
            this.Operators.Add(@operator);
        }

        public void LoadOperatorsFromFile(string path)
        {
            FileStream inStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlDocument document = new XmlDocument();
            document.Load(inStream);
            XmlElement opRoot = this.findElementByName(document.DocumentElement, "OPERATORS");
            if (opRoot != null)
            {
                this.LoadOperatorsNode(opRoot);
            }
            inStream.Close();
        }

        public void LoadOperatorsFromString(string xmlText)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlText);
            XmlElement opRoot = this.findElementByName(document.DocumentElement, "OPERATORS");
            if (opRoot != null)
            {
                this.LoadOperatorsNode(opRoot);
            }
        }

        private void LoadOperatorsNode(XmlElement opRoot)
        {
            foreach (XmlElement element in opRoot.GetElementsByTagName("OPERATOR"))
            {
                this.LoadOperatorNode(element);
            }
        }

        private void LoadTableNode(XmlElement tblNode)
        {
            Table table = new Table();
            table.Name = tblNode.GetAttribute("NAME");
            table.Alias = tblNode.GetAttribute("ALIAS");
            table.DBName = tblNode.GetAttribute("DB");
            table.SchemaName = tblNode.GetAttribute("SCHEMA");
            table.Hints = tblNode.GetAttribute("HINTS");
            string attribute = tblNode.GetAttribute("QUOTE");
            if (attribute != string.Empty)
            {
                table.Quote = bool.Parse(attribute);
            }
            table.DesignLayout = tblNode.GetAttribute("DSGNLAYOUT");
            this.Tables.Add(table);
        }

        private void LoadTablesNode(XmlElement tblRoot)
        {
            foreach (XmlElement element in tblRoot.GetElementsByTagName("TABLE"))
            {
                this.LoadTableNode(element);
            }
        }

        protected virtual void RefillAggrFunctionList()
        {
            this.AggrFunctions.Clear();
            this.AggrFunctions.Add(new AggrFunction("SUM", "Sum", "SUM({expr1})", "[[Sum]] of {attr1}"));
            this.AggrFunctions.Add(new AggrFunction("COUNT", "Count", "COUNT({expr1})", "[[Count]] of {attr1}"));
            this.AggrFunctions.Add(new AggrFunction("COUNT DISTINCT", "Distinct count", "COUNT(DISTINCT {expr1})", "[[Distinct count]] of {attr1}"));
            this.AggrFunctions.Add(new AggrFunction("AVG", "Average", "AVG({expr1})", "[[Average]] of {attr1}"));
            this.AggrFunctions.Add(new AggrFunction("MIN", "Minimum", "MIN({expr1})", "[[Minimum]] of {attr1}"));
            this.AggrFunctions.Add(new AggrFunction("MAX", "Maximum", "MAX({expr1})", "[[Maximum]] of {attr1}"));
        }

        public void ReloadResources()
        {
            ResourceManager resources = new ResourceManager("Korzh.EasyQuery.DataModel", typeof(DataModel).Assembly);
            this.Texts.LoadFromResources(resources);
        }

        protected void SaveCustomInfoNode(XmlWriter writer)
        {
            writer.WriteStartElement("CUSTOMINFO");
            writer.WriteRaw(this.CustomInfo);
            writer.WriteEndElement();
        }

        protected void SaveDbParamsNode(XmlWriter writer)
        {
            writer.WriteStartElement("DBPARAMS");
            foreach (DbParam param in this.DbParams)
            {
                writer.WriteElementString(param.Name, param.Value);
            }
            writer.WriteEndElement();
        }

        protected void SaveEntitiesNode(XmlWriter writer)
        {
            writer.WriteStartElement("ENTITIES");
            writer.WriteAttributeString("MAXID", this.maxEntAttrID.ToString());
            this.SaveEntity(writer, this.EntityRoot);
            writer.WriteEndElement();
        }

        protected void SaveEntity(XmlWriter writer, Entity entity)
        {
            if (entity.UserData != null)
            {
                writer.WriteElementString("USERDATA", entity.UserData.ToString());
            }
            foreach (Entity entity2 in entity.SubEntities)
            {
                writer.WriteStartElement("ENTITY");
                writer.WriteAttributeString("NAME", entity2.Name);
                this.SaveEntity(writer, entity2);
                writer.WriteEndElement();
            }
            foreach (EntityAttr attr in entity.Attributes)
            {
                writer.WriteStartElement("ATTR");
                writer.WriteAttributeString("ID", attr.ID);
                writer.WriteAttributeString("KIND", attr.Kind.ToString());
                writer.WriteAttributeString("EXPR", attr.Expr);
                writer.WriteAttributeString("CAPTION", attr.Caption);
                writer.WriteAttributeString("TYPE", attr.DataType.ToString());
                writer.WriteAttributeString("SIZE", attr.Size.ToString());
                writer.WriteAttributeString("QUOTE", attr.Quote.ToString());
                writer.WriteAttributeString("UIC", attr.UseInConditions.ToString());
                writer.WriteAttributeString("UIR", attr.UseInResult.ToString());
                writer.WriteAttributeString("UIS", attr.UseInSorting.ToString());
                writer.WriteAttributeString("UAL", attr.UseAlias.ToString());
                writer.WriteAttributeString("AGGR", attr.IsAggregate.ToString());
                writer.WriteAttributeString("TABLES", attr.Tables.GetCommaText());
                StringBuilder builder = new StringBuilder(200);
                builder.Length = 0;
                foreach (Operator @operator in attr.Operations)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(',');
                    }
                    builder.Append(@operator.ID);
                }
                writer.WriteElementString("OPERATORS", builder.ToString());
                writer.WriteStartElement("EDITORS");
                if (attr.DefaultEditor != null)
                {
                    attr.DefaultEditor.SaveToXmlWriter(writer, "DEFAULT");
                }
                foreach (ValueEditor editor in attr.Editors)
                {
                    editor.SaveToXmlWriter(writer, "EDITOR");
                }
                writer.WriteEndElement();
                if (attr.Description != null)
                {
                    writer.WriteElementString("DESCRIPTION", attr.Description);
                }
                if (attr.UserData != null)
                {
                    writer.WriteElementString("USERDATA", attr.UserData.ToString());
                }
                writer.WriteEndElement();
            }
        }

        protected void SaveLinksNode(XmlWriter writer)
        {
            writer.WriteStartElement("LINKS");
            foreach (Link link in this.Links)
            {
                writer.WriteStartElement("LINK");
                writer.WriteAttributeString("TABLE1", link.Table1.Alias);
                writer.WriteAttributeString("TABLE2", link.Table2.Alias);
                writer.WriteAttributeString("TYPE", link.Type.ToString());
                writer.WriteAttributeString("QF", link.QuoteFields.ToString());
                foreach (Link.Condition condition in link.Conditions)
                {
                    writer.WriteStartElement("CONDITION");
                    writer.WriteAttributeString("TYPE", Link.Condition.LinkCondTypeToStr(condition.CondType));
                    writer.WriteAttributeString("EXPR1", condition.Expr1);
                    writer.WriteAttributeString("EXPR2", condition.Expr2);
                    writer.WriteAttributeString("OP", condition.Operator);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        protected void SaveOperatorsNode(XmlWriter writer)
        {
            writer.WriteStartElement("OPERATORS");
            foreach (Operator @operator in this.Operators)
            {
                writer.WriteStartElement("OPERATOR");
                writer.WriteAttributeString("ID", @operator.ID);
                writer.WriteAttributeString("CAPTION", @operator.Caption);
                writer.WriteAttributeString("EXPR", @operator.Expr);
                writer.WriteAttributeString("FORMAT", @operator.DisplayFormat);
                writer.WriteAttributeString("CONSTFMT", @operator.ConstValueFormat);
                writer.WriteAttributeString("KIND", @operator.ValueKind.ToString());
                writer.WriteAttributeString("CASEINS", @operator.CaseInsensitive.ToString());
                writer.WriteAttributeString("GROUP", @operator.Group.Name);
                writer.WriteAttributeString("cond", @operator.IsCondition.ToString());
                writer.WriteAttributeString("tables", @operator.Tables.GetCommaText());
                string str = "";
                foreach (DataType type in @operator.AppliedTypes)
                {
                    if (str != "")
                    {
                        str = str + ",";
                    }
                    str = str + type.ToString();
                }
                writer.WriteElementString("TYPES", str);
                writer.WriteStartElement("EXPRS");
                writer.WriteAttributeString("DefType", @operator.ExprDefType.ToString());
                writer.WriteEndElement();
                if (@operator.DefaultEditor != null)
                {
                    writer.WriteStartElement("EDITORS");
                    @operator.DefaultEditor.SaveToXmlWriter(writer, "DEFAULT");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        protected void SaveTablesNode(XmlWriter writer)
        {
            writer.WriteStartElement("TABLES");
            foreach (Table table in this.Tables)
            {
                writer.WriteStartElement("TABLE");
                writer.WriteAttributeString("NAME", table.Name);
                writer.WriteAttributeString("ALIAS", table.Alias);
                writer.WriteAttributeString("SCHEMA", table.SchemaName);
                writer.WriteAttributeString("DB", table.DBName);
                writer.WriteAttributeString("HINTS", table.Hints);
                writer.WriteAttributeString("QUOTE", table.Quote.ToString());
                writer.WriteAttributeString("DSGNLAYOUT", table.DesignLayout);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void SaveToFile(string path)
        {
            XmlTextWriter writer = new XmlTextWriter(path, null);
            writer.Formatting = Formatting.Indented;
            this.SaveToXmlWriter(writer);
            writer.Flush();
            writer.Close();
        }

        public string SaveToString()
        {
            StringWriter w = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(w);
            writer.Formatting = Formatting.Indented;
            this.SaveToXmlWriter(writer);
            writer.Flush();
            writer.Close();
            return w.ToString();
        }

        public void SaveToXmlWriter(XmlWriter writer)
        {
            writer.WriteStartElement("DATAMODEL");
            writer.WriteAttributeString("Version", LastFormatVersion.ToString());
            writer.WriteAttributeString("Name", this.ModelName);
            writer.WriteAttributeString("DefQuery", this.defQueryFilePath);
            writer.WriteElementString("DESCRIPTION", this.description);
            this.SaveDbParamsNode(writer);
            this.SaveTablesNode(writer);
            this.SaveLinksNode(writer);
            this.SaveOperatorsNode(writer);
            this.SaveEntitiesNode(writer);
            writer.WriteEndElement();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ModelXml", this.SaveToString());
        }

        public virtual void UpdateOperatorsTexts()
        {
            foreach (Operator @operator in this.Operators)
            {
                string str = this.Texts.Get("op" + @operator.ID + "Caption");
                if (str != null)
                {
                    @operator.Caption = str;
                }
                str = this.Texts.Get("op" + @operator.ID + "Format");
                if (str != null)
                {
                    @operator.DisplayFormat = str;
                }
            }
        }

        public string CustomInfo
        {
            get
            {
                return this.customInfo;
            }
            set
            {
                this.customInfo = value;
            }
        }

        public DbParameters DbParams
        {
            get
            {
                return this.dbParams;
            }
        }

        public string DefQueryFilePath
        {
            get
            {
                return this.defQueryFilePath;
            }
            set
            {
                this.defQueryFilePath = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public Entity EntityRoot
        {
            get
            {
                return this.entityRoot;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
        }

        public int FormatVersion
        {
            get
            {
                return this.formatVersion;
            }
        }

        public string ModelName
        {
            get
            {
                return this.modelName;
            }
            set
            {
                this.modelName = value;
            }
        }

        public EntityAttr NullAttribute
        {
            get
            {
                return this.nullAttribute;
            }
        }

        [DefaultValue(true)]
        public bool StoreDbParams
        {
            get
            {
                return this.storeDbParams;
            }
            set
            {
                this.storeDbParams = value;
            }
        }

        public TableList Tables
        {
            get
            {
                return this.tables;
            }
        }

        public TextStorage Texts
        {
            get
            {
                return this.texts;
            }
        }

        [DefaultValue(true)]
        public bool UseResourcesForOperators
        {
            get
            {
                return this.useResourcesForOperators;
            }
            set
            {
                if (this.useResourcesForOperators != value)
                {
                    this.useResourcesForOperators = value;
                    if (this.useResourcesForOperators)
                    {
                        this.UpdateOperatorsTexts();
                    }
                }
            }
        }

        public class EditorsMap : ArrayList
        {
            public ValueEditor FindEditor(DataModel.Operator op, DataType type)
            {
                foreach (DataModel.ValueEditorEntry entry in this)
                {
                    if ((entry.Operators.IndexOf(op) >= 0) && ((type == entry.Type) || (entry.Type == DataType.Unknown)))
                    {
                        return entry.Editor;
                    }
                }
                return null;
            }

            public DataModel.ValueEditorEntry this[int index]
            {
                get
                {
                    return (DataModel.ValueEditorEntry)base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
        }

        public enum EntAttrKind
        {
            Data,
            Virtual
        }

        public class Entity
        {
            private DataModel.EntityAttrStore attributes;
            private string name;
            internal DataModel.Entity parent;
            private DataModel.EntityStore subEntities;
            private object userData;

            public Entity()
            {
                this.attributes = new DataModel.EntityAttrStore(this);
                this.subEntities = new DataModel.EntityStore(this);
            }

            public DataModel.EntityAttr FindAttribute(EntAttrProp what, string val)
            {
                switch (what)
                {
                    case EntAttrProp.Caption:
                        foreach (DataModel.EntityAttr attr in this.Attributes)
                        {
                            if (attr.Caption == val)
                            {
                                return attr;
                            }
                        }
                        break;

                    case EntAttrProp.SqlName:
                        foreach (DataModel.EntityAttr attr2 in this.Attributes)
                        {
                            if (attr2.CompareSqlName(val))
                            {
                                return attr2;
                            }
                        }
                        break;

                    default:
                        foreach (DataModel.EntityAttr attr3 in this.Attributes)
                        {
                            if (attr3.ID == val)
                            {
                                return attr3;
                            }
                        }
                        break;
                }
                DataModel.EntityAttr attr4 = null;
                foreach (DataModel.Entity entity in this.SubEntities)
                {
                    attr4 = entity.FindAttribute(what, val);
                    if (attr4 != null)
                    {
                        return attr4;
                    }
                }
                return null;
            }

            public DataModel.EntityAttr GetFirstLeaf()
            {
                if (this.Attributes.Count > 0)
                {
                    return this.Attributes[0];
                }
                foreach (DataModel.Entity entity in this.SubEntities)
                {
                    DataModel.EntityAttr firstLeaf = entity.GetFirstLeaf();
                    if (firstLeaf != null)
                    {
                        return firstLeaf;
                    }
                }
                return null;
            }

            public string GetFullName(string separator)
            {
                if ((this.parent != null) && !(this.parent is DataModel.RootEntity))
                {
                    return (this.parent.GetFullName(separator) + separator + this.Name);
                }
                return this.Name;
            }

            protected internal virtual void OnModelAssignment()
            {
                foreach (DataModel.Entity entity in this.SubEntities)
                {
                    entity.OnModelAssignment();
                }
                foreach (DataModel.EntityAttr attr in this.Attributes)
                {
                    attr.OnModelAssignment();
                }
            }

            public DataModel.EntityAttrStore Attributes
            {
                get
                {
                    return this.attributes;
                }
            }

            public virtual DataModel Model
            {
                get
                {
                    if (this.parent == null)
                    {
                        return null;
                    }
                    return this.parent.Model;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }

            public DataModel.Entity Parent
            {
                get
                {
                    return this.parent;
                }
            }

            public DataModel.EntityStore SubEntities
            {
                get
                {
                    return this.subEntities;
                }
            }

            public object UserData
            {
                get
                {
                    return this.userData;
                }
                set
                {
                    this.userData = value;
                }
            }
        }

        public class EntityAttr
        {
            private string caption;
            private Korzh.EasyQuery.DataType dataType = Korzh.EasyQuery.DataType.String;
            private ValueEditor defaultEditor;
            private string description;
            private DataModel.EditorsMap editors = new DataModel.EditorsMap();
            internal Korzh.EasyQuery.DataModel.Entity entity;
            private string expr = "";
            private string id = "";
            private bool isAggregate;
            private DataModel.EntAttrKind kind;
            private DataModel.OperatorList operators = new DataModel.OperatorList();
            private bool quote;
            private int size;
            private DataModel.TableList tables = new DataModel.TableList();
            private bool useAlias = true;
            private bool useInConditions = true;
            private bool useInResult = true;
            private bool useInSorting = true;
            private object userData;

            public bool CompareSqlName(string sqlName)
            {
                SqlFormats formats = new SqlFormats();
                formats.SqlQuote1 = '\0';
                formats.SqlQuote2 = '\0';
                bool flag = string.Compare(sqlName, this.GetSqlExpr(formats)) == 0;
                if (!flag)
                {
                    flag = string.Compare(sqlName, this.GetSqlName(formats)) == 0;
                }
                return flag;
            }

            private void ExcludeTablesByExpr()
            {
                if (this.Model != null)
                {
                    StringTokenizer tokenizer = new StringTokenizer(this.Expr);
                    string alias = "";
                    DataModel.Table item = null;
                    for (string str2 = tokenizer.FirstToken(); str2 != null; str2 = tokenizer.NextToken())
                    {
                        if (str2 == ".")
                        {
                            item = this.Model.Tables.FindByAlias(alias);
                            if (item == null)
                            {
                                item = this.Model.Tables.FindByName(alias);
                            }
                            if ((item != null) && !this.Tables.Contains(item))
                            {
                                this.Tables.Add(item);
                            }
                        }
                        alias = str2;
                    }
                }
            }

            public void FillOperatorsWithDefaults(DataModel model)
            {
                model.ListDefaultOperatorsForDataType(this.operators, this.DataType);
            }

            public DataModel.Operator GetDefaultOperator()
            {
                if (this.operators.Count > 0)
                {
                    return this.operators[0];
                }
                return DataModel.NullOperator;
            }

            public virtual string GetSqlExpr(SqlFormats formats)
            {
                if (this.Kind != DataModel.EntAttrKind.Data)
                {
                    return this.Expr;
                }
                string expr = this.Expr;
                if (this.quote || (expr.IndexOf(' ') >= 0))
                {
                    expr = formats.SqlQuote1 + expr + formats.SqlQuote2;
                }
                if ((this.tables.Count > 0) && !formats.FilterMode)
                {
                    expr = this.tables[0].GetSqlExpr(formats) + "." + expr;
                }
                return expr;
            }

            public virtual string GetSqlName(SqlFormats formats)
            {
                if (this.Kind != DataModel.EntAttrKind.Data)
                {
                    return this.Expr;
                }
                string expr = this.Expr;
                if (this.quote || (expr.IndexOf(' ') >= 0))
                {
                    expr = formats.SqlQuote1 + expr + formats.SqlQuote2;
                }
                if ((this.tables.Count > 0) && !formats.FilterMode)
                {
                    expr = this.tables[0].GetSqlName(formats) + "." + expr;
                }
                return expr;
            }

            public ValueEditor GetValueEditor(DataModel.Operator op)
            {
                ValueEditor defaultEditor = null;
                Korzh.EasyQuery.DataType type = (op.ExprDefType != Korzh.EasyQuery.DataType.Unknown) ? op.ExprDefType : this.DataType;
                if (op.ValueKind == DataKind.Query)
                {
                    defaultEditor = new SubQueryValueEditor();
                }
                else
                {
                    defaultEditor = this.Editors.FindEditor(op, type);
                }
                if (defaultEditor == null)
                {
                    defaultEditor = op.DefaultEditor;
                }
                if (defaultEditor == null)
                {
                    defaultEditor = this.DefaultEditor;
                }
                if ((defaultEditor != null) && (defaultEditor is ListValueEditor))
                {
                    string str = "MENU";
                    if (op.ValueKind == DataKind.List)
                    {
                        str = "MULTILIST";
                    }
                    else if ((defaultEditor is ConstListValueEditor) && (((ConstListValueEditor)defaultEditor).Values.Count > 30))
                    {
                        str = "LISTBOX";
                    }
                    ((ListValueEditor)defaultEditor).ControlType = str;
                }
                if (defaultEditor == null)
                {
                    switch (type)
                    {
                        case Korzh.EasyQuery.DataType.Bool:
                            defaultEditor = new CustomListValueEditor();
                            ((ListValueEditor)defaultEditor).ControlType = "MENU";
                            ((CustomListValueEditor)defaultEditor).ListName = "BooleanValues";
                            goto Label_00FD;

                        case Korzh.EasyQuery.DataType.Date:
                        case Korzh.EasyQuery.DataType.Time:
                        case Korzh.EasyQuery.DataType.DateTime:
                            defaultEditor = new DateTimeValueEditor();
                            goto Label_00FD;
                    }
                    defaultEditor = new TextValueEditor();
                }
            Label_00FD:
                if ((defaultEditor != null) && (defaultEditor is DateTimeValueEditor))
                {
                    ((DateTimeValueEditor)defaultEditor).SubType = type;
                }
                return defaultEditor;
            }

            protected internal virtual void OnModelAssignment()
            {
                if (this.kind == DataModel.EntAttrKind.Virtual)
                {
                    this.ExcludeTablesByExpr();
                }
            }

            public static DataModel.EntAttrKind StrToEntAttrKind(string s)
            {
                return (DataModel.EntAttrKind)Enum.Parse(typeof(DataModel.EntAttrKind), s, true);
            }

            public string Caption
            {
                get
                {
                    return this.caption;
                }
                set
                {
                    this.caption = value;
                }
            }

            public Korzh.EasyQuery.DataType DataType
            {
                get
                {
                    return this.dataType;
                }
                set
                {
                    this.dataType = value;
                }
            }

            public ValueEditor DefaultEditor
            {
                get
                {
                    return this.defaultEditor;
                }
                set
                {
                    this.defaultEditor = value;
                }
            }

            public string Description
            {
                get
                {
                    return this.description;
                }
                set
                {
                    this.description = value;
                }
            }

            public DataModel.EditorsMap Editors
            {
                get
                {
                    return this.editors;
                }
            }

            public Korzh.EasyQuery.DataModel.Entity Entity
            {
                get
                {
                    return this.entity;
                }
            }

            public string Expr
            {
                get
                {
                    return this.expr;
                }
                set
                {
                    if (this.expr != value)
                    {
                        this.expr = value;
                        if (this.kind == DataModel.EntAttrKind.Virtual)
                        {
                            this.ExcludeTablesByExpr();
                        }
                    }
                }
            }

            public string ID
            {
                get
                {
                    return this.id;
                }
                set
                {
                    this.id = value;
                }
            }

            public bool IsAggregate
            {
                get
                {
                    return this.isAggregate;
                }
                set
                {
                    if (this.kind == DataModel.EntAttrKind.Virtual)
                    {
                        this.isAggregate = value;
                    }
                }
            }

            public DataModel.EntAttrKind Kind
            {
                get
                {
                    return this.kind;
                }
                set
                {
                    this.kind = value;
                }
            }

            public DataModel Model
            {
                get
                {
                    if (this.entity == null)
                    {
                        return null;
                    }
                    return this.entity.Model;
                }
            }

            public DataModel.OperatorList Operations
            {
                get
                {
                    return this.operators;
                }
            }

            public bool Quote
            {
                get
                {
                    return this.quote;
                }
                set
                {
                    this.quote = value;
                }
            }

            public int Size
            {
                get
                {
                    return this.size;
                }
                set
                {
                    this.size = (value >= 0) ? value : 0;
                }
            }

            public DataModel.TableList Tables
            {
                get
                {
                    return this.tables;
                }
            }

            public bool UseAlias
            {
                get
                {
                    return this.useAlias;
                }
                set
                {
                    this.useAlias = value;
                }
            }

            public bool UseInConditions
            {
                get
                {
                    return this.useInConditions;
                }
                set
                {
                    this.useInConditions = value;
                }
            }

            public bool UseInResult
            {
                get
                {
                    return this.useInResult;
                }
                set
                {
                    this.useInResult = value;
                }
            }

            public bool UseInSorting
            {
                get
                {
                    return this.useInSorting;
                }
                set
                {
                    this.useInSorting = value;
                }
            }

            public object UserData
            {
                get
                {
                    return this.userData;
                }
                set
                {
                    this.userData = value;
                }
            }
        }

        public class EntityAttrList : ArrayList
        {
            public DataModel.EntityAttr this[int index]
            {
                get
                {
                    return (DataModel.EntityAttr)base[index];
                }
            }
        }

        public class EntityAttrStore : DataModel.EntityAttrList
        {
            private DataModel.Entity entity;

            public EntityAttrStore(DataModel.Entity entity)
            {
                this.entity = entity;
            }

            public override int Add(object value)
            {
                int index = base.Add(value);
                this.OnEntityAttrInsertion((DataModel.EntityAttr)value, index);
                return index;
            }

            public override void Insert(int index, object value)
            {
                base.Insert(index, value);
                this.OnEntityAttrInsertion((DataModel.EntityAttr)value, index);
            }

            protected virtual void OnEntityAttrInsertion(DataModel.EntityAttr entityAttr, int index)
            {
                entityAttr.entity = this.entity;
                entityAttr.OnModelAssignment();
            }
        }

        public class EntityList : ArrayList
        {
            public DataModel.Entity this[int index]
            {
                get
                {
                    return (DataModel.Entity)base[index];
                }
            }
        }

        public class EntityStore : DataModel.EntityList
        {
            private DataModel.Entity parentEntity;

            public EntityStore(DataModel.Entity parentEntity)
            {
                this.parentEntity = parentEntity;
            }

            public override int Add(object value)
            {
                int index = base.Add(value);
                this.OnEntityInsertion((DataModel.Entity)value, index);
                return index;
            }

            public override void Insert(int index, object value)
            {
                base.Insert(index, value);
                this.OnEntityInsertion((DataModel.Entity)value, index);
            }

            protected virtual void OnEntityInsertion(DataModel.Entity entity, int index)
            {
                entity.parent = this.parentEntity;
                if (this.parentEntity.Model != null)
                {
                    entity.OnModelAssignment();
                }
            }
        }

        public class Error : Exception
        {
            public Error(string message)
                : base(message)
            {
            }
        }

        public class Link
        {
            private ConditionList conditions = new ConditionList();
            private bool quoteFields;
            private DataModel.Table table1;
            private DataModel.Table table2;
            private LinkType type = LinkType.Inner;

            public Condition AddCondition(DataModel.LinkCondType condType, string expr1, string expr2, string operation)
            {
                Condition condition = new Condition(this);
                condition.CondType = condType;
                condition.Expr1 = expr1;
                condition.Expr2 = expr2;
                condition.Operator = operation;
                this.Conditions.Add(condition);
                return condition;
            }

            public string GetSqlExpr(SqlFormats formats)
            {
                string str = "";
                foreach (Condition condition in this.Conditions)
                {
                    if (str != "")
                    {
                        str = str + " and ";
                    }
                    str = str + "(" + condition.GetSqlExpr(formats) + ")";
                }
                return str;
            }

            protected internal void RemoveFromTables()
            {
                if (this.Table1 != null)
                {
                    this.Table1.Links.Remove(this);
                }
                if (this.Table2 != null)
                {
                    this.Table2.Links.Remove(this);
                }
            }

            public static LinkType StrToLinkType(string s)
            {
                return (LinkType)Enum.Parse(typeof(LinkType), s, true);
            }

            public override string ToString()
            {
                string str;
                switch (this.type)
                {
                    case LinkType.Left:
                        str = " -> ";
                        break;

                    case LinkType.Right:
                        str = " <- ";
                        break;

                    case LinkType.Full:
                        str = " <-> ";
                        break;

                    default:
                        str = " - ";
                        break;
                }
                string str2 = "";
                if (this.table1 != null)
                {
                    str2 = str2 + this.table1.Name;
                }
                str2 = str2 + str;
                if (this.table2 != null)
                {
                    str2 = str2 + this.table2.Name;
                }
                return str2;
            }

            public ConditionList Conditions
            {
                get
                {
                    return this.conditions;
                }
            }

            public bool QuoteFields
            {
                get
                {
                    return this.quoteFields;
                }
                set
                {
                    this.quoteFields = value;
                }
            }

            public DataModel.Table Table1
            {
                get
                {
                    return this.table1;
                }
                set
                {
                    if (this.table1 != null)
                    {
                        this.table1.Links.Remove(this);
                    }
                    this.table1 = value;
                    if (this.table1 != null)
                    {
                        this.table1.Links.Add(this);
                    }
                }
            }

            public DataModel.Table Table2
            {
                get
                {
                    return this.table2;
                }
                set
                {
                    if (this.table2 != null)
                    {
                        this.table2.Links.Remove(this);
                    }
                    this.table2 = value;
                    if (this.table2 != null)
                    {
                        this.table2.Links.Add(this);
                    }
                }
            }

            public LinkType Type
            {
                get
                {
                    return this.type;
                }
                set
                {
                    this.type = value;
                }
            }

            public class Condition
            {
                private DataModel.LinkCondType condType;
                private string expr1 = "";
                private string expr2 = "";
                private DataModel.Link link;
                private string operation = "=";

                public Condition(DataModel.Link aLink)
                {
                    this.link = aLink;
                    this.condType = DataModel.LinkCondType.FieldField;
                }

                public string GetSqlExpr(SqlFormats formats)
                {
                    string str = "";
                    string str2 = ((formats.SqlSyntax == SqlSyntax.Oracle) && (this.link.Type == DataModel.Link.LinkType.Right)) ? " (+) " : " ";
                    string str3 = ((formats.SqlSyntax == SqlSyntax.Oracle) && (this.link.Type == DataModel.Link.LinkType.Left)) ? " (+) " : " ";
                    string str4 = this.link.QuoteFields ? formats.SqlQuote1.ToString() : "";
                    string str5 = this.link.QuoteFields ? formats.SqlQuote2.ToString() : "";
                    if ((this.CondType == DataModel.LinkCondType.ExprExpr) || (this.CondType == DataModel.LinkCondType.ExprField))
                    {
                        str = this.Expr1 + " ";
                    }
                    else
                    {
                        str = this.Table1.GetSqlExpr(formats) + "." + str4 + this.Expr1 + str5 + str2;
                    }
                    str = str + this.Operator + " ";
                    if ((this.CondType == DataModel.LinkCondType.FieldField) || (this.CondType == DataModel.LinkCondType.ExprField))
                    {
                        string str6 = str;
                        return (str6 + this.Table2.GetSqlExpr(formats) + "." + str4 + this.Expr2 + str5 + str3);
                    }
                    return (str + this.Expr2);
                }

                public static string LinkCondTypeToStr(DataModel.LinkCondType type)
                {
                    switch (type)
                    {
                        case DataModel.LinkCondType.FieldExpr:
                            return "FE";

                        case DataModel.LinkCondType.ExprField:
                            return "EF";

                        case DataModel.LinkCondType.ExprExpr:
                            return "EE";

                        case DataModel.LinkCondType.UserExpr:
                            return "UE";
                    }
                    return "FF";
                }

                public static DataModel.LinkCondType StrToLinkCondType(string s)
                {
                    switch (s)
                    {
                        case "FE":
                            return DataModel.LinkCondType.FieldExpr;

                        case "EF":
                            return DataModel.LinkCondType.ExprField;

                        case "EE":
                            return DataModel.LinkCondType.ExprExpr;

                        case "UE":
                            return DataModel.LinkCondType.UserExpr;
                    }
                    return DataModel.LinkCondType.FieldField;
                }

                public override string ToString()
                {
                    return (this.Expr1 + " " + this.Operator + " " + this.Expr2);
                }

                public DataModel.LinkCondType CondType
                {
                    get
                    {
                        return this.condType;
                    }
                    set
                    {
                        this.condType = value;
                    }
                }

                public string Expr1
                {
                    get
                    {
                        return this.expr1;
                    }
                    set
                    {
                        this.expr1 = value;
                    }
                }

                public string Expr2
                {
                    get
                    {
                        return this.expr2;
                    }
                    set
                    {
                        this.expr2 = value;
                    }
                }

                public string Operator
                {
                    get
                    {
                        return this.operation;
                    }
                    set
                    {
                        this.operation = value;
                    }
                }

                public DataModel.Table Table1
                {
                    get
                    {
                        return this.link.Table1;
                    }
                }

                public DataModel.Table Table2
                {
                    get
                    {
                        return this.link.Table2;
                    }
                }
            }

            public class ConditionList : ArrayList
            {
                public DataModel.Link.Condition this[int index]
                {
                    get
                    {
                        return (DataModel.Link.Condition)base[index];
                    }
                }
            }

            public enum LinkType
            {
                Inner,
                Left,
                Right,
                Full,
                Cross
            }
        }

        public enum LinkCondType
        {
            FieldField,
            FieldExpr,
            ExprField,
            ExprExpr,
            UserExpr
        }

        public class LinkList : ArrayList
        {
            public DataModel.Link FindByTables(DataModel.Table table1, DataModel.Table table2)
            {
                foreach (DataModel.Link link in this)
                {
                    if (((link.Table1 != table1) || (link.Table2 != table2)) && ((link.Table1 != table2) || (link.Table2 != table1)))
                    {
                        continue;
                    }
                    return link;
                }
                return null;
            }

            public DataModel.Link this[int index]
            {
                get
                {
                    return (DataModel.Link)base[index];
                }
            }
        }

        public class LinksStorage : DataModel.LinkList
        {
            public override void Remove(object obj)
            {
                ((DataModel.Link)obj).RemoveFromTables();
                base.Remove(obj);
            }

            public override void RemoveAt(int index)
            {
                base[index].RemoveFromTables();
                base.RemoveAt(index);
            }

            public override void RemoveRange(int index, int count)
            {
                int num = index;
                for (int i = 0; i < count; i++)
                {
                    base[num].RemoveFromTables();
                    num++;
                }
                base.RemoveRange(index, count);
            }
        }

        public class Operator
        {
            private DataTypeList appliedTypes;
            private string caption;
            private bool caseInsensitive;
            private string constValueFormat;
            private ValueEditor defaultEditor;
            private string displayFormat;
            internal string expr;
            private DataType exprDefType;
            private DataModel.OperatorGroup group;
            private string id;
            private bool isCondition;
            private int paramCount;
            private DataModel.TableList tables;
            private DataKind valueKind;

            public Operator()
            {
                this.paramCount = 2;
                this.id = "";
                this.caption = "";
                this.constValueFormat = "{const}";
                this.tables = new DataModel.TableList();
                this.appliedTypes = new DataTypeList();
                this.appliedTypes.AddRange(Enum.GetValues(typeof(DataType)));
            }

            public Operator(string id, string aCaption, string aExpr, string aDisplayFormat)
                : this()
            {
                this.ID = id;
                this.Caption = aCaption;
                this.expr = aExpr;
                this.displayFormat = aDisplayFormat;
                this.CalcParamCount();
            }

            private void CalcParamCount()
            {
                int num = 0;
                do
                {
                    num++;
                }
                while (this.expr.IndexOf("{expr" + num.ToString()) >= 0);
                this.paramCount = num - 1;
            }

            public override string ToString()
            {
                return this.ID;
            }

            public DataTypeList AppliedTypes
            {
                get
                {
                    return this.appliedTypes;
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
                    if (this.caption != value)
                    {
                        this.caption = value;
                    }
                }
            }

            public bool CaseInsensitive
            {
                get
                {
                    return this.caseInsensitive;
                }
                set
                {
                    this.caseInsensitive = value;
                }
            }

            public string ConstValueFormat
            {
                get
                {
                    return this.constValueFormat;
                }
                set
                {
                    this.constValueFormat = value;
                }
            }

            public ValueEditor DefaultEditor
            {
                get
                {
                    return this.defaultEditor;
                }
                set
                {
                    this.defaultEditor = value;
                }
            }

            public string DisplayFormat
            {
                get
                {
                    return this.displayFormat;
                }
                set
                {
                    if (value != this.displayFormat)
                    {
                        this.displayFormat = value;
                    }
                }
            }

            public string Expr
            {
                get
                {
                    return this.expr;
                }
                set
                {
                    if (this.expr != value)
                    {
                        this.expr = value;
                        this.CalcParamCount();
                    }
                }
            }

            public DataType ExprDefType
            {
                get
                {
                    return this.exprDefType;
                }
                set
                {
                    this.exprDefType = value;
                }
            }

            public DataModel.OperatorGroup Group
            {
                get
                {
                    return this.group;
                }
                set
                {
                    this.group = value;
                    if (this.group != null)
                    {
                        this.appliedTypes.Clear();
                        this.appliedTypes.InsertRange(0, this.group.AppliedTypes);
                    }
                }
            }

            public string ID
            {
                get
                {
                    return this.id;
                }
                set
                {
                    this.id = value;
                }
            }

            public bool IsCondition
            {
                get
                {
                    return this.isCondition;
                }
                set
                {
                    this.isCondition = value;
                }
            }

            public string MainText
            {
                get
                {
                    int index = this.displayFormat.IndexOf("[[");
                    int num2 = this.displayFormat.IndexOf("]]", (int)(index + 2));
                    string str = this.displayFormat.Substring(index + 2, (num2 - index) - 2).Trim();
                    if (!(str != ""))
                    {
                        return this.Caption;
                    }
                    return str;
                }
            }

            public string MathSymbol
            {
                get
                {
                    if (this.ID.Equals("Equal"))
                    {
                        return "=";
                    }
                    if (this.ID.Equals("NotEqual"))
                    {
                        return "<>";
                    }
                    if (this.ID.Equals("LessThan"))
                    {
                        return "<";
                    }
                    if (this.ID.Equals("LessThan"))
                    {
                        return "<";
                    }
                    if (this.ID.Equals("LessOrEqual"))
                    {
                        return "<=";
                    }
                    if (this.ID.Equals("GreaterThan"))
                    {
                        return ">";
                    }
                    if (this.ID.Equals("GreaterOrEqual"))
                    {
                        return ">=";
                    }
                    return this.MainText;
                }
            }

            public int ParamCount
            {
                get
                {
                    return this.paramCount;
                }
            }

            public DataModel.TableList Tables
            {
                get
                {
                    return this.tables;
                }
            }

            public DataKind ValueKind
            {
                get
                {
                    return this.valueKind;
                }
                set
                {
                    this.valueKind = value;
                }
            }
        }

        public class OperatorGroup
        {
            private DataTypeList appliedTypes;
            private string groupName;

            public OperatorGroup(string groupName, DataType[] appliedTypes)
            {
                this.groupName = groupName;
                this.appliedTypes = new DataTypeList(appliedTypes);
            }

            public OperatorGroup(string groupName, DataTypeList appliedTypes)
                : this(groupName, new DataType[0])
            {
                this.appliedTypes.InsertRange(0, appliedTypes);
            }

            public override string ToString()
            {
                return this.groupName;
            }

            public DataTypeList AppliedTypes
            {
                get
                {
                    return this.appliedTypes;
                }
            }

            public string Name
            {
                get
                {
                    return this.groupName;
                }
                set
                {
                    this.groupName = value;
                }
            }
        }

        public class OperatorGroupList : ArrayList
        {
            public OperatorGroupList(DataModel.OperatorGroup[] groups)
                : base(groups)
            {
            }

            public DataModel.OperatorGroup FindByName(string groupName)
            {
                foreach (DataModel.OperatorGroup group in this)
                {
                    if (group != null)
                    {
                        if (string.Compare(group.Name, groupName, true) == 0)
                        {
                            return group;
                        }
                    }
                }
                return null;
            }

            public DataModel.OperatorGroup this[int index]
            {
                get
                {
                    return (DataModel.OperatorGroup)base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
        }

        public class OperatorList : ArrayList
        {
            public void AddByIDs(DataModel model, string ids)
            {
                char[] separator = new char[] { ',' };
                foreach (string str in ids.Split(separator))
                {
                    DataModel.Operator @operator = model.Operators.FindByID(str);
                    if (@operator != null)
                    {
                        this.Add(@operator);
                    }
                }
            }

            public DataModel.Operator FindByID(string OpID)
            {
                int num = this.IndexByID(OpID);
                if (num >= 0)
                {
                    return this[num];
                }
                return null;
            }

            public int IndexByID(string OpID)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].ID == OpID)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public DataModel.Operator this[int index]
            {
                get
                {
                    return (DataModel.Operator)base[index];
                }
            }
        }

        public class Path : DataModel.TableList
        {
            public DataModel.Table EndPoint
            {
                get
                {
                    if (this.Count > 0)
                    {
                        return base[this.Count - 1];
                    }
                    return null;
                }
            }

            public DataModel.Table StartPoint
            {
                get
                {
                    if (this.Count > 0)
                    {
                        return base[0];
                    }
                    return null;
                }
            }
        }

        public class PathList : ArrayList
        {
            public DataModel.Path this[int index]
            {
                get
                {
                    return (DataModel.Path)base[index];
                }
            }
        }

        public class RootEntity : DataModel.Entity
        {
            private DataModel model;

            public RootEntity(DataModel model)
            {
                this.model = model;
            }

            public override DataModel Model
            {
                get
                {
                    return this.model;
                }
            }
        }

        public class Table
        {
            private string alias;
            private string dbname;
            private string designLayout;
            private string hints;
            public readonly DataModel.LinkList Links;
            private string name;
            private bool quote;
            private string schemaName;

            public Table()
            {
                this.dbname = "";
                this.name = "";
                this.Links = new DataModel.LinkList();
                this.schemaName = "";
                this.alias = "";
                this.hints = "";
                this.designLayout = "";
            }

            public Table(DataModel.Table source)
            {
                this.dbname = "";
                this.name = "";
                this.Links = new DataModel.LinkList();
                this.schemaName = "";
                this.alias = "";
                this.hints = "";
                this.designLayout = "";
                this.Name = source.Name;
                this.SchemaName = source.SchemaName;
                this.DBName = source.DBName;
                this.Alias = source.Alias;
                this.Hints = source.Hints;
                this.Quote = source.Quote;
            }

            private string ComposeAlias(SqlFormats formats)
            {
                string s = (formats.SubQueryLevel > 0) ? (this.Alias + "SQ" + formats.SubQueryLevel) : this.Alias;
                return this.QuoteIfNecessary(s, formats);
            }

            public virtual string GetFromExpr(SqlFormats formats)
            {
                string sqlName = this.GetSqlName(formats);
                if (this.Alias != string.Empty)
                {
                    sqlName = sqlName + " " + this.ComposeAlias(formats);
                }
                if (this.Hints != string.Empty)
                {
                    sqlName = sqlName + " WITH " + this.Hints;
                }
                return sqlName;
            }

            public virtual string GetSqlExpr(SqlFormats formats)
            {
                if (this.Alias != "")
                {
                    return this.ComposeAlias(formats);
                }
                return this.GetSqlName(formats);
            }

            public string GetSqlName(SqlFormats formats)
            {
                string str = this.QuoteIfNecessary(this.Name, formats);
                string s = (this.SchemaName != string.Empty) ? this.SchemaName : formats.DefaultSchemaName;
                if (formats.UseSchema && (s != string.Empty))
                {
                    str = this.QuoteIfNecessary(s, formats) + '.' + str;
                }
                if (formats.UseDbName && (this.dbname != string.Empty))
                {
                    str = this.QuoteIfNecessary(this.dbname, formats) + '.' + str;
                }
                return str;
            }

            private string QuoteIfNecessary(string s, SqlFormats formats)
            {
                if (!this.quote && (s.IndexOf(' ') < 0))
                {
                    return s;
                }
                return (formats.SqlQuote1 + s + formats.SqlQuote2);
            }

            public override string ToString()
            {
                return this.FullName;
            }

            public string Alias
            {
                get
                {
                    return this.alias;
                }
                set
                {
                    this.alias = value;
                }
            }

            public string DBName
            {
                get
                {
                    return this.dbname;
                }
                set
                {
                    this.dbname = value;
                }
            }

            public string DesignLayout
            {
                get
                {
                    return this.designLayout;
                }
                set
                {
                    this.designLayout = value;
                }
            }

            public string FullName
            {
                get
                {
                    StringBuilder builder = new StringBuilder(70);
                    if (this.DBName != "")
                    {
                        builder.Append(this.DBName + ":");
                    }
                    if (this.SchemaName != "")
                    {
                        builder.Append(this.SchemaName + ".");
                    }
                    builder.Append(this.Name);
                    if (this.Alias != "")
                    {
                        builder.Append(" (" + this.Alias + ")");
                    }
                    return builder.ToString();
                }
            }

            public string Hints
            {
                get
                {
                    return this.hints;
                }
                set
                {
                    this.hints = value;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    if ((this.alias == string.Empty) || (this.alias == this.name))
                    {
                        this.alias = value;
                    }
                    this.name = value;
                }
            }

            public bool Quote
            {
                get
                {
                    return this.quote;
                }
                set
                {
                    this.quote = value;
                }
            }

            public string SchemaName
            {
                get
                {
                    return this.schemaName;
                }
                set
                {
                    this.schemaName = value;
                }
            }
        }

        public class TableList : ArrayList
        {
            public DataModel.Table FindByAlias(string alias)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (string.Compare(this[i].Alias, alias, true) == 0)
                    {
                        return this[i];
                    }
                }
                return null;
            }

            public DataModel.Table FindByName(string name)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (string.Compare(this[i].Name, name, true) == 0)
                    {
                        return this[i];
                    }
                }
                return null;
            }

            public string GetCommaText()
            {
                StringBuilder builder = new StringBuilder(200);
                foreach (DataModel.Table table in this)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(',');
                    }
                    builder.Append(table.Alias);
                }
                return builder.ToString();
            }

            public string GetUniqueAlias(string baseName)
            {
                string alias = baseName;
                int num = 0;
                while (this.FindByAlias(alias) != null)
                {
                    num++;
                    alias = baseName + num;
                }
                return alias;
            }

            public DataModel.Table this[int index]
            {
                get
                {
                    return (DataModel.Table)base[index];
                }
            }
        }

        public class TablesStorage : DataModel.TableList
        {
            private DataModel model;

            public TablesStorage(DataModel model)
            {
                this.model = model;
            }

            private void ProcessAttributesForTableRemove(DataModel.Entity entity, DataModel.Table table)
            {
                for (int i = entity.Attributes.Count - 1; i >= 0; i--)
                {
                    DataModel.EntityAttr attr = entity.Attributes[i];
                    if (attr.Tables.Contains(table))
                    {
                        if (attr.Kind == DataModel.EntAttrKind.Data)
                        {
                            entity.Attributes.Remove(attr);
                        }
                        else
                        {
                            attr.Tables.Remove(table);
                        }
                    }
                }
                for (int j = entity.SubEntities.Count - 1; j >= 0; j--)
                {
                    DataModel.Entity entity2 = entity.SubEntities[j];
                    this.ProcessAttributesForTableRemove(entity2, table);
                    if ((entity2.Attributes.Count == 0) && (entity2.SubEntities.Count == 0))
                    {
                        entity.SubEntities.RemoveAt(j);
                    }
                }
            }

            public override void RemoveAt(int index)
            {
                DataModel.Table table = base[index];
                this.ProcessAttributesForTableRemove(this.model.EntityRoot, table);
                base.RemoveAt(index);
            }
        }

        public class TypeOperatorEntry
        {
            private DataModel.OperatorList operators = new DataModel.OperatorList();
            private DataTypeList types = new DataTypeList();

            public DataModel.OperatorList Operators
            {
                get
                {
                    return this.operators;
                }
            }

            public DataTypeList Types
            {
                get
                {
                    return this.types;
                }
            }
        }

        public class TypeOperatorMap : ArrayList
        {
            public DataModel.TypeOperatorEntry FindByType(DataType type)
            {
                int num = this.IndexByType(type);
                if (num >= 0)
                {
                    return this[num];
                }
                return null;
            }

            public int IndexByType(DataType type)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].Types.IndexOf(type) >= 0)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public DataModel.TypeOperatorEntry this[int index]
            {
                get
                {
                    return (DataModel.TypeOperatorEntry)base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
        }

        public class ValueEditorEntry
        {
            private ValueEditor editor = null;
            private DataModel.OperatorList operators = new DataModel.OperatorList();
            private DataType type = DataType.Unknown;

            public ValueEditor Editor
            {
                get
                {
                    return this.editor;
                }
                set
                {
                    this.editor = value;
                }
            }

            public DataModel.OperatorList Operators
            {
                get
                {
                    return this.operators;
                }
            }

            public DataType Type
            {
                get
                {
                    return this.type;
                }
            }
        }
    }
}

