namespace Korzh.EasyQuery.WebControls
{
    using Korzh.WebControls.XControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Web.UI.WebControls;

    public class QCPAppearance : XPanel.XAppearance
    {
        [TypeConverter(typeof (WebColorConverter)), DefaultValue(typeof (Color), "Green"), NotifyParentProperty(true)]
        public Color AdditionRowColor
        {
            get
            {
                object obj2 = this.ViewState["AdditionRowColor"];
                if (obj2 != null)
                {
                    return (Color) obj2;
                }
                return Color.Green;
            }
            set { this.ViewState["AdditionRowColor"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue("{entity} {attr}")]
        public string AttrElementFormat
        {
            get
            {
                object obj2 = this.ViewState["AttrElementFormat"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "{entity} {attr}";
            }
            set { this.ViewState["AttrElementFormat"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue("")]
        public string ColumnButtonImageUrl
        {
            get
            {
                object obj2 = this.ViewState["ColumnButtonImageUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "";
            }
            set { this.ViewState["ColumnButtonImageUrl"] = value; }
        }

        [DefaultValue(""), NotifyParentProperty(true)]
        public string DownButtonImageUrl
        {
            get
            {
                object obj2 = this.ViewState["DownButtonImageUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "";
            }
            set { this.ViewState["DownButtonImageUrl"] = value; }
        }

        [NotifyParentProperty(true)]
        public string RowButtonTooltip
        {
            get
            {
                object obj2 = this.ViewState["RowButtonTooltip"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "";
            }
            set { this.ViewState["RowButtonTooltip"] = value; }
        }

        [Browsable(true), NotifyParentProperty(true), DefaultValue(false)]
        public bool ShowMoveUpDownButtons
        {
            get
            {
                object obj2 = this.ViewState["ShowMoveUpDownButtons"];
                return ((obj2 != null) && ((bool) obj2));
            }
            set { this.ViewState["ShowMoveUpDownButtons"] = value; }
        }

        [DefaultValue(""), NotifyParentProperty(true)]
        public string UpButtonImageUrl
        {
            get
            {
                object obj2 = this.ViewState["UpButtonImageUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "";
            }
            set { this.ViewState["UpButtonImageUrl"] = value; }
        }
    }
}