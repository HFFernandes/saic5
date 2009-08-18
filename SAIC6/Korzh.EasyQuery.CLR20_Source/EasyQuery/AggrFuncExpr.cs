namespace Korzh.EasyQuery
{
    using System;
    using System.Reflection;
    using System.Xml;

    public class AggrFuncExpr : Expression
    {
        private ArgStore arguments;
        private bool distinct;
        private AggrFunction function;
        private DataModel model;

        public AggrFuncExpr(DataModel model) : this(model, "", null)
        {
        }

        public AggrFuncExpr(DataModel model, string funcID, Expression argExpr)
        {
            this.model = model;
            this.Function = this.GetFunctionByID(funcID);
            this.arguments = new ArgStore(this);
            this.arguments.Add(argExpr);
        }

        public override void AssignExpr(Expression expr)
        {
            this.Argument = expr;
        }

        internal void AttachArgument(Expression argument)
        {
            if (argument != null)
            {
                argument.ContentChange += new EventHandler(this.DoArgumentContentChange);
            }
        }

        internal void DetachArgument(Expression argument)
        {
            if (argument != null)
            {
                argument.ContentChange -= new EventHandler(this.DoArgumentContentChange);
            }
        }

        private void DoArgumentContentChange(object sender, EventArgs e)
        {
            this.OnContentChange(EventArgs.Empty);
        }

        private AggrFunction GetFunctionByID(string funcID)
        {
            AggrFunction function = this.model.AggrFunctions.FindByID(funcID);
            if (function == null)
            {
                return new AggrFunction(funcID, funcID, funcID + "({expr1})", "[[" + funcID + "]] of {attr1}");
            }
            return function;
        }

        public override string GetSqlExpr(SqlFormats formats)
        {
            string str = (this.function != null) ? this.function.SqlExpr : "COUNT({expr1})";
            string newValue = (this.Argument != null) ? this.Argument.GetSqlExpr(formats) : "*";
            if (this.distinct)
            {
                newValue = "DISTINCT " + newValue;
            }
            return str.Replace("{expr1}", newValue);
        }

        public override void GetUsedTables(DataModel.TableList tables)
        {
            this.Argument.GetUsedTables(tables);
        }

        public override void LoadFromXmlNode(XmlNode rootNode)
        {
            XmlAttribute attribute = rootNode.Attributes["func"];
            if (attribute != null)
            {
                this.Function = this.GetFunctionByID(attribute.Value);
            }
            attribute = rootNode.Attributes["distinct"];
            this.distinct = (attribute != null) ? bool.Parse(attribute.Value) : false;
            this.arguments.Clear();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (string.Compare(node.LocalName, "argument", true) == 0)
                {
                    attribute = node.Attributes["class"];
                    if (attribute != null)
                    {
                        Expression expression = Expression.Create(attribute.Value, this.model);
                        expression.LoadFromXmlNode(node);
                        this.arguments.Add(expression);
                    }
                }
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            this.WriteXmlTagStart(writer, tagName);
            writer.WriteAttributeString("func", this.Function.ID);
            writer.WriteAttributeString("distinct", this.distinct.ToString());
            foreach (Expression expression in this.arguments)
            {
                expression.SaveToXmlWriter(writer, "argument");
            }
            writer.WriteEndElement();
        }

        public Expression Argument
        {
            get
            {
                if (this.arguments.Count <= 0)
                {
                    return null;
                }
                return this.arguments[0];
            }
            set
            {
                if (this.arguments.Count > 0)
                {
                    this.arguments[0] = value;
                }
                else
                {
                    this.arguments.Add(value);
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
                this.distinct = value;
            }
        }

        public AggrFunction Function
        {
            get
            {
                return this.function;
            }
            set
            {
                if (this.function != value)
                {
                    this.function = value;
                    this.OnContentChange(EventArgs.Empty);
                }
            }
        }

        public static string STypeName
        {
            get
            {
                return "AGGRFUNC";
            }
        }

        public override string Text
        {
            get
            {
                string str = (this.Argument != null) ? this.Argument.Text : string.Empty;
                return (str + ((this.function != null) ? (" " + this.function.Caption) : string.Empty));
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public override string Value
        {
            get
            {
                if (this.function == null)
                {
                    return "";
                }
                return this.function.ID;
            }
            set
            {
                if (value != this.Value)
                {
                    this.Function = this.model.AggrFunctions.FindByID(value);
                }
            }
        }

        public class ArgStore : ExprList
        {
            private AggrFuncExpr aggrFuncExpr;

            public ArgStore(AggrFuncExpr aggrFuncExpr)
            {
                this.aggrFuncExpr = aggrFuncExpr;
            }

            public override int Add(object value)
            {
                if (value != null)
                {
                    this.aggrFuncExpr.AttachArgument((Expression) value);
                }
                int num = base.Add(value);
                this.aggrFuncExpr.OnContentChange(EventArgs.Empty);
                return num;
            }

            public override void Insert(int index, object value)
            {
                base.Insert(index, value);
                if (value != null)
                {
                    this.aggrFuncExpr.AttachArgument((Expression) value);
                }
                this.aggrFuncExpr.OnContentChange(EventArgs.Empty);
            }

            public override void RemoveAt(int index)
            {
                this.aggrFuncExpr.DetachArgument(base[index]);
                base.RemoveAt(index);
                this.aggrFuncExpr.OnContentChange(EventArgs.Empty);
            }

            public Expression this[int index]
            {
                get
                {
                    return base[index];
                }
                set
                {
                    Expression argument = base[index];
                    if (argument != value)
                    {
                        if (argument != null)
                        {
                            this.aggrFuncExpr.DetachArgument(argument);
                        }
                        base[index] = value;
                        if (value != null)
                        {
                            this.aggrFuncExpr.AttachArgument(argument);
                        }
                        this.aggrFuncExpr.OnContentChange(EventArgs.Empty);
                    }
                }
            }
        }
    }
}

