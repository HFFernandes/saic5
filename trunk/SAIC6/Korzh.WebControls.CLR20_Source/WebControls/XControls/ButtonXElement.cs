namespace Korzh.WebControls.XControls
{
    using System;
    using System.Drawing;
    using System.Web.UI;

    public class ButtonXElement : LabelXElement, IPostBackEventHandler
    {
        private string imageUrl = "";

        public ButtonXElement()
        {
            this.ElementControl.BackColor = Color.Transparent;
        }

        protected override void PreRenderElementControl()
        {
            base.PreRenderElementControl();
            base.linkControl.ImageUrl = this.ImageUrl;
            if (base.linkControl.ImageUrl == string.Empty)
            {
                base.linkControl.Text = "( )";
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            set { this.imageUrl = value; }
        }

        public static string XmlTagName
        {
            get { return "BUTTON"; }
        }
    }
}