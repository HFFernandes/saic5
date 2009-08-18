namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class ConstListValueEditor : ListValueEditor
    {
        private ConstValueList values;

        public ConstListValueEditor()
        {
            this.values = this.CreateValueList();
        }

        protected virtual ConstValueList CreateValueList()
        {
            return new ConstValueList();
        }

        public override void LoadFromXmlNode(XmlNode node)
        {
            foreach (XmlNode node2 in node.ChildNodes)
            {
                if (node2.LocalName == "VALUES")
                {
                    foreach (XmlNode node3 in node2.ChildNodes)
                    {
                        this.Values.Add(node3.Attributes["ID"].Value, node3.Attributes["TEXT"].Value);
                    }
                    continue;
                }
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString("TYPE", this.TypeName);
            writer.WriteStartElement("VALUES");
            foreach (ConstValueItem item in this.Values)
            {
                writer.WriteStartElement("VALUE");
                writer.WriteAttributeString("ID", item.ID);
                writer.WriteAttributeString("TEXT", item.Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public override string DefaultText
        {
            get
            {
                if (this.Values.Count > 0)
                {
                    return this.Values[0].Text;
                }
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
                if (this.Values.Count > 0)
                {
                    return this.Values[0].ID;
                }
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
                return "LIST";
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public virtual ConstValueList Values
        {
            get
            {
                return this.values;
            }
        }

        public override string XmlDefinition
        {
            get
            {
                string iD = "";
                string text = "";
                if (this.Values.Count > 0)
                {
                    iD = this.Values[0].ID;
                    text = this.Values[0].Text;
                }
                string str3 = "<LIST Value=\"" + iD + "\" Text=\"" + text + "\" ControlType=\"" + base.ControlType + "\">\r\n";
                foreach (ConstValueItem item in this.Values)
                {
                    string str4 = str3;
                    str3 = str4 + "  <ITEM Value=\"" + item.ID + "\" Text=\"" + item.Text + "\"/>\r\n";
                }
                return (str3 + "</LIST>");
            }
        }
    }
}

