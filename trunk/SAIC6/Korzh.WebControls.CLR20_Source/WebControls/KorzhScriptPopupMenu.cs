namespace Korzh.WebControls
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Web.UI;

    [Serializable]
    public class KorzhScriptPopupMenu : ScriptPopupMenu
    {
        public KorzhScriptPopupMenu(string id) : this(id, null)
        {
        }

        public KorzhScriptPopupMenu(string id, ScriptMenu parent) : base(id, parent)
        {
        }

        public override string RenderHideMenuCommand(Control parentControl)
        {
            return (base.ID + ".hide();");
        }

        protected override string RenderItemsScript()
        {
            string str = "";
            for (int i = 0; i < base.Style.Font.Names.Length; i++)
            {
                if (i > 0)
                {
                    str = str + ", ";
                }
                str = str + base.Style.Font.Names[i];
            }
            if (str != "")
            {
                str = "fontFamily:'" + str + "';";
            }
            string str2 = !base.Style.Font.Size.IsEmpty ? base.Style.Font.Size.ToString() : "12px";
            if (!base.Style.ForeColor.IsEmpty)
            {
                ColorTranslator.ToHtml(base.Style.ForeColor);
            }
            string str3 = str + " fontSize:'" + str2 + "'";
            string str4 = "menu" + base.ID;
            string str5 = str4 + "Colors";
            string str6 = str4 + "Props";
            string str7 = str4 + "Items";
            string str8 = str4 + "ItemStyle";
            string str9 = str4 + "Style";
            string str10 = !base.Style.BackColor.IsEmpty ? ColorTranslator.ToHtml(base.Style.BackColor) : "white";
            string str11 = ColorTranslator.ToHtml(base.Style.BackColorOver);
            StringBuilder result = new StringBuilder("", 0x800);
            result.Append("<script type=\"text/javascript\">\n");
            result.Append("var " + str5 + " = {border:'#666666', shadow:'#888888', bgON:'" + str10 + "',bgOVER:'" +
                          str11 + "'};\n");
            result.Append("var " + str8 + " = {" + str3 + "};\n");
            result.Append("var " + str9 + " = {border:1, shadow:2, colors:" + str5);
            if (base.Style.CssClass != string.Empty)
            {
                result.Append(", itemClass:'" + base.Style.CssClass + "'");
            }
            if (base.Style.CssClassOver != string.Empty)
            {
                result.Append(", itemClassOver:'" + base.Style.CssClassOver + "'");
            }
            result.Append(", itemStyle:" + str8);
            result.Append("};\n");
            result.Append("var " + str6 + " = {\n");
            result.Append("    id:'" + base.ID + "',\n");
            result.Append("    style:" + str9 + ",\n");
            result.Append("    zIndex:" + base.Style.ZIndex + ",\n");
            string str12 = "";
            if (base.MultiSelect)
            {
                str12 = "__MULTI:";
            }
            result.Append("    commandTemplate:' " +
                          base.postbackRef.Replace("arg0", @"\'${arg0}\'").Replace("arg1",
                                                                                   @"\'" + base.CustomPrefix + str12 +
                                                                                   @"${itemId}\'") + "'");
            if (base.Style.ItemMinWidth > 0)
            {
                result.Append(",\n    minItemWidth:" + base.Style.ItemMinWidth);
            }
            if (base.Style.ItemMaxWidth > 0)
            {
                result.Append(",\n    maxItemWidth:" + base.Style.ItemMaxWidth);
            }
            if (base.MultiSelect)
            {
                result.Append(",\n    multiselect:true");
            }
            result.Append("\n};\n");
            result.Append("var " + str7 + " = [\n");
            this.RenderSubItems(base.Items, result, 0);
            result.Append("];\n");
            if (!base.IsInPartialRendering)
            {
                result.Append("  var " + str4 + " = new PopupMenu(" + str6 + ", " + str7 + ");\n");
            }
            else
            {
                result.Append("  var " + str4 + " = new kCreatePopupMenu(" + str6 + ", " + str7 + ");\n");
            }
            result.Append("</script>\n");
            return result.ToString();
        }

        protected override string RenderMenuFuncs()
        {
            return "";
        }

        public override string RenderShowMenuCommand(Control parentControl)
        {
            return ("menu" + base.ID + ".showUnderEx('" + parentControl.ClientID + "', 0, 2,['" + parentControl.UniqueID +
                    "'], event)");
        }

        protected void RenderSubItems(ScriptMenuItemList items, StringBuilder result, int level)
        {
            string str = "    " + string.Empty.PadRight(level*2, ' ');
            try
            {
                if (items.Count > 0)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        ScriptMenuItem item = items[i];
                        string text = item.Text;
                        result.Append(str + "{ id:'" + item.ID + "', text:'" + text.Replace("'", @"\'") + "'");
                        if (item.Selected && (base.MultiSelect || base.Grouped))
                        {
                            result.Append(", sel:true");
                        }
                        if (item.Items.Count > 0)
                        {
                            result.Append(", sub:[\n");
                            this.RenderSubItems(item.Items, result, level + 1);
                            result.Append(str + "]");
                        }
                        result.Append(" }" + ((i < (items.Count - 1)) ? "," : "") + "\n");
                    }
                }
                else
                {
                    result.Append(str + "{ id:'', text:'" + base.Style.EmptyListText + "'}");
                }
            }
            catch (Exception exception)
            {
                string str3 = (items != null) ? items.ToString() : "null";
                throw new Exception(exception.Message + ";  Menu ID: " + base.ID + "; items: " + str3);
            }
        }

        private string StrConstJS(string s)
        {
            return s.Replace("\"", "\\\"").Replace("'", @"\'");
        }
    }
}