namespace Korzh.WebControls.XControls
{
    using System;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    [ToolboxItem(false)]
    public class RowLinkLabel : HyperLink
    {
        private XElement parentElement;

        public RowLinkLabel(XElement parentElement)
        {
            this.parentElement = parentElement;
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            this.parentElement.AddElementControlAttributes(writer);
        }
    }
}