namespace Korzh.WebControls.XControls
{
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class LabelListXElement : ListXElement
    {
        protected RowLinkLabel linkControl;

        protected internal override void AddElementControlAttributes(HtmlTextWriter writer)
        {
            if (this.Enabled && !base.ReadOnly)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, ColorTranslator.ToHtml(this.ForeColor));
                string str = "";
                if (base.altMenuControl != null)
                {
                    str = "if (event.ctrlKey) " + base.altMenuControl.GetShowScriptReference() + "; else ";
                }
                str = str + base.listControl.GetShowScriptReference() + "; return false";
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, str);
            }
            else if (!this.Enabled)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color,
                                         ColorTranslator.ToHtml(Color.FromKnownColor(KnownColor.GrayText)));
            }
        }

        protected override WebControl CreateElementControl()
        {
            this.linkControl = new RowLinkLabel(this);
            return this.linkControl;
        }

        protected override void PreRenderElementControl()
        {
            base.PreRenderElementControl();
            this.linkControl.Text = this.Text;
            this.linkControl.NavigateUrl = "javascript:void(0)";
        }

        public override bool Clickable
        {
            get { return true; }
        }

        public static string XmlTagName
        {
            get { return "LIST"; }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new LabelListXElement();
            }

            public string TagName
            {
                get { return LabelListXElement.XmlTagName; }
            }
        }
    }
}