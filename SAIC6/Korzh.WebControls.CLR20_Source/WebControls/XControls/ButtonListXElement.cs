namespace Korzh.WebControls.XControls
{
    using System;
    using System.Web.UI;

    public class ButtonListXElement : LabelListXElement, IPostBackEventHandler
    {
        private string imageUrl = "";

        protected override void PreRenderElementControl()
        {
            base.PreRenderElementControl();
            base.linkControl.ImageUrl = this.ImageUrl;
            if (base.linkControl.ImageUrl == string.Empty)
            {
                base.linkControl.Text = "( )";
            }
        }

        protected override void processSelectedIDs()
        {
            if ((base.selectedIDs != null) && (base.Items != null))
            {
                ValueItem itemByID = base.Items.GetItemByID(base.selectedIDs);
                if ((itemByID != null) && (base.ParentRow != null))
                {
                    base.ParentRow.ElementAction(this, itemByID.Action);
                }
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            set { this.imageUrl = value; }
        }

        public static string XmlTagName
        {
            get { return "BUTTONLIST"; }
        }
    }
}