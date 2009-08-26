namespace Korzh.WebControls.XControls
{
    using System;
    using System.Drawing;
    using System.Web.UI.WebControls;
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
            this.ElementControl.BackColor = Color.Transparent;
            base.EmptyValueText = "<empty>";
            this.SubType = subType;
            base.Value = text;
            this.Text = text;
        }

        protected override WebControl CreateElementControl()
        {
            this.control = new Label();
            return this.control;
        }

        public override void ParseXmlNode(XmlNode node)
        {
            this.Text = node.InnerText;
        }

        protected override void PreRenderElementControl()
        {
            this.control.Text = this.Text;
        }

        public override string Text
        {
            set { base.Text = value; }
        }

        public static string XmlTagName
        {
            get { return "TEXT"; }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new TextXElement();
            }

            public string TagName
            {
                get { return TextXElement.XmlTagName; }
            }
        }
    }
}