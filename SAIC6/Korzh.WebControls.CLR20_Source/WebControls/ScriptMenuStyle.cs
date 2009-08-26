namespace Korzh.WebControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Web.UI.WebControls;

    [Serializable, TypeConverter(typeof (ExpandableObjectConverter))]
    public class ScriptMenuStyle : Style
    {
        public override void CopyFrom(Style s)
        {
            base.CopyFrom(s);
            if (s is ScriptMenuStyle)
            {
                this.BackColorOver = ((ScriptMenuStyle) s).BackColorOver;
                this.BlankImageUrl = ((ScriptMenuStyle) s).BlankImageUrl;
                this.CssClassOver = ((ScriptMenuStyle) s).CssClassOver;
                this.IncludeScriptUrl = ((ScriptMenuStyle) s).IncludeScriptUrl;
                this.ItemMinWidth = ((ScriptMenuStyle) s).ItemMinWidth;
                this.ItemMaxWidth = ((ScriptMenuStyle) s).ItemMaxWidth;
                this.ItemHeight = ((ScriptMenuStyle) s).ItemHeight;
                this.ForeColor = ((ScriptMenuStyle) s).ForeColor;
                this.ZIndex = ((ScriptMenuStyle) s).ZIndex;
            }
        }

        [TypeConverter(typeof (WebColorConverter)), DefaultValue(typeof (Color), "LightSteelBlue"),
         NotifyParentProperty(true)]
        public Color BackColorOver
        {
            get
            {
                object obj2 = base.ViewState["BackColorOver"];
                if (obj2 != null)
                {
                    return (Color) obj2;
                }
                return Color.LightSteelBlue;
            }
            set { base.ViewState["BackColorOver"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue("")]
        public string BlankImageUrl
        {
            get
            {
                object obj2 = base.ViewState["BlankImageUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "";
            }
            set { base.ViewState["BlankImageUrl"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue("")]
        public string CssClassOver
        {
            get
            {
                object obj2 = base.ViewState["CssClassOver"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return string.Empty;
            }
            set { base.ViewState["CssClassOver"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue("(empty list)")]
        public string EmptyListText
        {
            get
            {
                object obj2 = base.ViewState["EmptyListText"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "(empty list)";
            }
            set { base.ViewState["EmptyListText"] = value; }
        }

        [DefaultValue(typeof (Color), "Black"), NotifyParentProperty(true), TypeConverter(typeof (WebColorConverter))]
        public Color ForeColor
        {
            get
            {
                object obj2 = base.ViewState["ForeColor"];
                if (obj2 != null)
                {
                    return (Color) obj2;
                }
                return Color.Black;
            }
            set { base.ViewState["ForeColor"] = value; }
        }

        [DefaultValue(""), NotifyParentProperty(true)]
        public string IncludeScriptUrl
        {
            get
            {
                object obj2 = base.ViewState["IncludeScriptUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "";
            }
            set { base.ViewState["IncludeScriptUrl"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue(20)]
        public int ItemHeight
        {
            get
            {
                object obj2 = base.ViewState["ItemHeight"];
                if (obj2 != null)
                {
                    return (int) obj2;
                }
                return 20;
            }
            set { base.ViewState["ItemHeight"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue(0)]
        public int ItemMaxWidth
        {
            get
            {
                object obj2 = base.ViewState["ItemMaxWidth"];
                if (obj2 != null)
                {
                    return (int) obj2;
                }
                return 0;
            }
            set { base.ViewState["ItemMaxWidth"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue(140)]
        public int ItemMinWidth
        {
            get
            {
                object obj2 = base.ViewState["ItemMinWidth"];
                if (obj2 != null)
                {
                    return (int) obj2;
                }
                return 140;
            }
            set { base.ViewState["ItemMinWidth"] = value; }
        }

        [Obsolete("This property will be removed in the next version"), Browsable(false), DefaultValue(140)]
        public int ItemWidth
        {
            get
            {
                object obj2 = base.ViewState["ItemMinWidth"];
                if (obj2 != null)
                {
                    return (int) obj2;
                }
                return 140;
            }
            set { base.ViewState["ItemMinWidth"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue(0x3e9)]
        public int ZIndex
        {
            get
            {
                object obj2 = base.ViewState["ZIndex"];
                if (obj2 != null)
                {
                    return (int) obj2;
                }
                return 0x3e9;
            }
            set { base.ViewState["ZIndex"] = value; }
        }
    }
}