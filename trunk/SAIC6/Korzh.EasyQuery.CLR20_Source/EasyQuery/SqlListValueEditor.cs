namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class SqlListValueEditor : ListValueEditor
    {
        private string id = "";
        private static int maxID;
        private string sql = "";
        private string sqlCount;

        public SqlListValueEditor()
        {
            int nextID = GetNextID();
            this.id = "SqlList" + nextID;
        }

        private static int GetNextID()
        {
            return ++maxID;
        }

        public override void LoadFromXmlNode(XmlNode node)
        {
            foreach (XmlNode node2 in node.ChildNodes)
            {
                if (node2.LocalName == "SQL")
                {
                    this.sql = node.InnerText;
                }
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString("TYPE", this.TypeName);
            writer.WriteStartElement("SQL");
            writer.WriteCData(this.sql);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public override string DefaultText
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public override string DefaultValue
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public virtual string SQL
        {
            get
            {
                return this.sql;
            }
            set
            {
                this.sql = value;
            }
        }

        public virtual string SQLCount
        {
            get
            {
                return this.sqlCount;
            }
            set
            {
                this.sqlCount = value;
            }
        }

        public static string STypeName
        {
            get
            {
                return "SQLLIST";
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public override string XmlDefinition
        {
            get
            {
                return ((("<SQLLIST ControlType=\"" + base.ControlType + "\" ID=\"" + this.ID + "\">\r\n") + "<SQL><![CDATA[\r\n" + this.SQL) + "]]></SQL>\r\n" + "</SQLLIST>");
            }
        }
    }
}

