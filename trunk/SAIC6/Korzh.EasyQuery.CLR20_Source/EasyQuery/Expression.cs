namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Xml;

    public class Expression
    {
        internal static Hashtable Creators = new Hashtable();
        private string hint = "";
        protected string text = "";

        public event EventHandler ContentChange;

        public virtual void AssignExpr(Expression expr)
        {
        }

        public void ContentChanged()
        {
            this.OnContentChange(EventArgs.Empty);
        }

        public static Expression Create(string type, DataModel model)
        {
            IExpressionCreator creator = (IExpressionCreator) Creators[type];
            if (creator == null)
            {
                throw new Exception("Unknown type of expression: " + type);
            }
            return creator.Create(model);
        }

        public virtual string GetSqlExpr(SqlFormats formats)
        {
            return this.Value;
        }

        public virtual string GetSqlText(SqlFormats formats)
        {
            return this.Text;
        }

        public virtual void GetUsedTables(DataModel.TableList tables)
        {
        }

        public virtual void LoadFromXmlNode(XmlNode rootNode)
        {
        }

        protected virtual void OnContentChange(EventArgs e)
        {
            if (this.ContentChange != null)
            {
                this.ContentChange(this, e);
            }
        }

        public static bool RegisterType(string type, IExpressionCreator creator)
        {
            Creators.Add(type, creator);
            return true;
        }

        public void SaveToXmlWriter(XmlWriter writer)
        {
            this.SaveToXmlWriter(writer, XmlTagName);
        }

        public virtual void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
        }

        public void SetContent(string val, string txt)
        {
            this.SetContentSilent(val, txt);
            this.OnContentChange(EventArgs.Empty);
        }

        public virtual void SetContentSilent(string val, string txt)
        {
            this.text = txt;
        }

        protected void WriteXmlTagStart(XmlWriter writer)
        {
            this.WriteXmlTagStart(writer, XmlTagName);
        }

        protected virtual void WriteXmlTagStart(XmlWriter writer, string tagName)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString("class", this.TypeName);
        }

        public virtual Korzh.EasyQuery.DataType DataType
        {
            get
            {
                return Korzh.EasyQuery.DataType.Unknown;
            }
            set
            {
            }
        }

        public string Hint
        {
            get
            {
                return this.hint;
            }
            set
            {
                if (this.hint != value)
                {
                    this.hint = value;
                }
            }
        }

        public virtual DataKind Kind
        {
            get
            {
                return DataKind.Scalar;
            }
            set
            {
            }
        }

        public static string STypeName
        {
            get
            {
                return "";
            }
        }

        public virtual string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnContentChange(EventArgs.Empty);
                }
            }
        }

        public virtual string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public virtual string Value
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public static string XmlTagName
        {
            get
            {
                return "expr";
            }
        }
    }
}

