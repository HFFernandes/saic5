namespace Korzh.WinControls.XControls
{
    using System;
    using System.Windows.Forms;
    using System.Xml;

    public class TextXElement : XElement
    {
        private Label control;

        public TextXElement() : this("", "")
        {
        }

        public TextXElement(string text) : this(text, "")
        {
        }

        public TextXElement(string text, string subType)
        {
            this.control.AutoSize = true;
            this.SubType = subType;
            base.Value = text;
            this.Text = text;
            base.BasePanel.Controls.Add(this.control);
        }

        protected override Control CreateElementControl()
        {
            this.control = new Label();
            return this.control;
        }

        public override void ParseXmlNode(XmlNode node)
        {
            this.Text = node.InnerText;
        }

        public override Control ElementControl
        {
            get
            {
                return this.control;
            }
        }

        public static string TagName
        {
            get
            {
                return "TEXT";
            }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new TextXElement();
            }

            public string TagName
            {
                get
                {
                    return TextXElement.TagName;
                }
            }
        }
    }
}

