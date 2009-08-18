namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class CustomValueEditor : ValueEditor
    {
        private string data = "";

        public override void LoadFromXmlNode(XmlNode node)
        {
            foreach (XmlNode node2 in node.ChildNodes)
            {
                if (node2.LocalName == "DATA")
                {
                    this.data = node.InnerText;
                }
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString("TYPE", this.TypeName);
            writer.WriteElementString("DATA", this.Data);
            writer.WriteEndElement();
        }

        public string Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
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

        public static string STypeName
        {
            get
            {
                return "CUSTOM";
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
                return ("<LABEL Value=\"" + this.DefaultValue + "\" Action=\"ValueRequest\" Data=\"" + this.Data + "\" />");
            }
        }
    }
}

