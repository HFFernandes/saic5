namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class SubQueryValueEditor : ValueEditor
    {
        private string queryXml;

        public override void LoadFromXmlNode(XmlNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                this.queryXml = node.ChildNodes[0].OuterXml;
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            writer.WriteStartElement(tagName);
            writer.WriteRaw(this.QueryXml);
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

        public virtual string QueryXml
        {
            get
            {
                return this.queryXml;
            }
        }

        public static string STypeName
        {
            get
            {
                return "SUBQUERY";
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
                string str = "<SUBQUERY>\r\n";
                return (str + this.QueryXml + "</SUBQUERY>");
            }
        }
    }
}

