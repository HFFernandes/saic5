namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class CustomListValueEditor : ListValueEditor
    {
        private string listName = string.Empty;

        public override void LoadFromXmlNode(XmlNode node)
        {
            base.LoadFromXmlNode(node);
            XmlAttribute attribute = node.Attributes["NAME"];
            if (attribute != null)
            {
                this.ListName = attribute.Value;
            }
        }

        protected override void SaveContentToXmlWriter(XmlWriter writer)
        {
            writer.WriteAttributeString("NAME", this.ListName);
        }

        public string ListName
        {
            get
            {
                return this.listName;
            }
            set
            {
                this.listName = value;
            }
        }

        public static string STypeName
        {
            get
            {
                return "CUSTOMLIST";
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
                return ("<LIST ListName=\"" + this.listName + "\" ControlType=\"" + base.ControlType + "\"/>\r\n");
            }
        }
    }
}

