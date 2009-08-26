namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;

    public class LabelXElement : XElement, IPostBackEventHandler
    {
        private string actionName;
        private ScriptMenuStyle altMenuStyle;
        protected RowLinkLabel linkControl;

        public LabelXElement() : this("")
        {
        }

        public LabelXElement(string subType)
        {
            this.altMenuStyle = new ScriptMenuStyle();
            this.actionName = "";
            this.ElementControl.BackColor = Color.Transparent;
            this.SubType = subType;
            this.ForeColor = Color.Blue;
        }

        protected internal override void AddElementControlAttributes(HtmlTextWriter writer)
        {
            if (this.Enabled && !base.ReadOnly)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, ColorTranslator.ToHtml(this.ForeColor));
                if (base.altMenuControl != null)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Onclick,
                                        "if (event.ctrlKey) " + base.altMenuControl.GetShowScriptReference() +
                                        ";return false");
                }
            }
            else if (!this.Enabled)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color,
                                         ColorTranslator.ToHtml(Color.FromKnownColor(KnownColor.GrayText)));
            }
        }

        public override void ApplyFormats()
        {
            base.ApplyFormats();
        }

        public override void Arrange(int bottomLine, int rowHeight)
        {
            base.Arrange(bottomLine, rowHeight);
        }

        protected override WebControl CreateElementControl()
        {
            this.linkControl = new RowLinkLabel(this);
            return this.linkControl;
        }

        public override void ParseXmlNode(XmlNode node)
        {
            if (node.Attributes["Value"] != null)
            {
                base.Value = node.Attributes["Value"].Value;
            }
            if (node.Attributes["Action"] != null)
            {
                this.actionName = node.Attributes["Action"].Value;
            }
            if (node.Attributes["Data"] != null)
            {
                base.Data = node.Attributes["Data"].Value;
            }
            if (node.InnerText != "")
            {
                this.Text = node.InnerText;
            }
        }

        protected override void PreRenderElementControl()
        {
            this.linkControl.Text = this.Text;
            this.linkControl.NavigateUrl = this.Page.ClientScript.GetPostBackClientHyperlink(this, string.Empty);
            base.PreRenderElementControl();
        }

        void IPostBackEventHandler.RaisePostBackEvent(string EventArgument)
        {
            string postedValue = EventArgument;
            if (postedValue.StartsWith("__ALT:"))
            {
                postedValue = postedValue.Substring("__ALT:".Length);
                base.AltMenuItemClickHandler(postedValue);
            }
            else if ((this.actionName != "") && (base.ParentRow != null))
            {
                base.ParentRow.ElementAction(this, this.actionName);
            }
        }

        public string ActionName
        {
            get { return this.actionName; }
            set { this.actionName = value; }
        }

        public override bool Clickable
        {
            get { return true; }
        }

        public static string XmlTagName
        {
            get { return "LABEL"; }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new LabelXElement();
            }

            public string TagName
            {
                get { return LabelXElement.XmlTagName; }
            }
        }
    }
}