namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class EditXElement : LabelXElement, IPostBackDataHandler
    {
        protected TextBox editControl;
        private string postedValue;

        public EditXElement() : this("")
        {
        }

        public EditXElement(string subType) : base(subType)
        {
            this.editControl = new TextBox();
            this.editControl.Visible = false;
        }

        protected internal override void AddElementControlAttributes(HtmlTextWriter writer)
        {
            if (this.Enabled && !base.ReadOnly)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, ColorTranslator.ToHtml(this.ForeColor));
                string str = "";
                string str2 = (base.altMenuControl == null) ? "" : "}";
                if (base.altMenuControl != null)
                {
                    str = "if (event.ctrlKey) {" + base.altMenuControl.GetShowScriptReference() + ";} else {";
                }
                string str3 = str;
                str = str3 + "kShowElementAt('" + this.EditPanelClientID + "','" + this.ClientID +
                      "', 0, 0);kFocusElement('" + this.EditBoxClientID + "');" + str2 + " return false;";
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, str);
            }
            else if (!this.Enabled)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color,
                                         ColorTranslator.ToHtml(Color.FromKnownColor(KnownColor.GrayText)));
            }
        }

        private bool CheckScalarValue(string val)
        {
            try
            {
                if (this.SubType == "INTEGER")
                {
                    int.Parse(val);
                }
                else if (this.SubType == "FLOAT")
                {
                    float.Parse(val);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CheckValue(string val)
        {
            if (!this.AllowList)
            {
                return this.CheckScalarValue(val);
            }
            string[] strArray = val.Split(new char[] {',', ' ', '\t'});
            for (int i = 0; i < strArray.Length; i++)
            {
                if ((strArray[i] != "") && !this.CheckScalarValue(strArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        protected override void OnValidate(ValidateValueEventArgs e)
        {
            if (!this.CheckValue(e.Value))
            {
                e.Accept = false;
            }
            else
            {
                base.OnValidate(e);
            }
        }

        protected override void PreRenderElementControl()
        {
            base.linkControl.Text = this.Text;
            base.PreRenderElementControl();
            base.linkControl.NavigateUrl = "javascript:void(0)";
            string eventHandlersScriptName = EventHandlersScriptName;
            Type type = base.GetType();
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(type, eventHandlersScriptName) ||
                base.IsInsideUpdatePanel)
            {
                StringBuilder builder = new StringBuilder(0x3e8);
                builder.Append("<script type=\"text/javascript\">\n<!--\n");
                builder.Append("function eqn_ere_keypressHandler(eventTargetId, event) {\n");
                builder.Append("    var keynum;\n");
                builder.Append("    keynum = event.keyCode || event.which;\n");
                builder.Append("    if (keynum == 13) {\n");
                builder.Append("        event.cancelBubble = true;\n");
                builder.Append("        event.returnValue = false;\n");
                builder.Append("        kHideElement(eventTargetId);\n");
                builder.Append("        __doPostBack(eventTargetId, '');\n");
                builder.Append("        return false\n");
                builder.Append("    }\n");
                builder.Append("    else if (keynum == 27) {\n");
                builder.Append("        kHideElement(eventTargetId);\n");
                builder.Append("        if (event.currentTarget) event.currentTarget.blur();\n");
                builder.Append("        event.cancelBubble = true;\n");
                builder.Append("        event.returnValue = false;\n");
                builder.Append("        if (event.stopPropagation) event.stopPropagation();\n");
                builder.Append("        return false\n");
                builder.Append("    }\n");
                builder.Append("    return true;\n");
                builder.Append("}\n");
                builder.Append("\n");
                builder.Append("function eqn_ere_lostFocusHandler(eventTargetId, event) {\n");
                builder.Append("    var target = document.getElementById(eventTargetId);");
                builder.Append("    if (target.style.visibility == 'visible') {\n");
                builder.Append("        event.cancelBubble = true;\n");
                builder.Append("        event.returnValue = false;\n");
                builder.Append("        kHideElement(eventTargetId);\n");
                builder.Append("        __doPostBack(eventTargetId, '');\n");
                builder.Append("    }\n");
                builder.Append("    return false\n");
                builder.Append("}\n");
                builder.Append("// -->\n</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(type, eventHandlersScriptName, builder.ToString());
                if (base.IsInsideUpdatePanel)
                {
                    Ajax.RegisterClientScriptBlock(this.Page, type, eventHandlersScriptName, builder.ToString(), false);
                }
            }
            this.Page.RegisterRequiresPostBack(this);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            int num = 0x3e7;
            if (!base.DesignMode)
            {
                writer.AddAttribute("id", this.EditPanelClientID, false);
                writer.AddAttribute("style",
                                    "position:absolute; z-index:" + num.ToString() +
                                    "; visibility:hidden;background-color:red;", false);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.AddAttribute(HtmlTextWriterAttribute.Name, this.EditBoxClientID);
                writer.AddAttribute(HtmlTextWriterAttribute.Id, this.EditBoxClientID);
                writer.AddAttribute(HtmlTextWriterAttribute.Value, base.Value);
                writer.AddAttribute("onkeypress",
                                    "javascript: return eqn_ere_keypressHandler('" + this.EditPanelClientID +
                                    "', event)");
                writer.AddAttribute("onblur",
                                    "javascript: return eqn_ere_lostFocusHandler('" + this.EditPanelClientID +
                                    "', event)");
                this.editControl.RenderBeginTag(writer);
                this.editControl.RenderEndTag(writer);
                writer.RenderEndTag();
            }
            base.Render(writer);
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection values)
        {
            this.postedValue = values[this.EditBoxClientID];
            return (this.postedValue != null);
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            bool accept = true;
            string postedValue = this.postedValue;
            if (base.NeedValidate)
            {
                ValidateValueEventArgs e = new ValidateValueEventArgs(this.postedValue, true);
                this.OnValidate(e);
                postedValue = e.Value;
                accept = e.Accept;
            }
            if (accept)
            {
                base.Value = postedValue;
            }
        }

        protected string EditBoxClientID
        {
            get { return (this.ClientID + "_EditBox"); }
        }

        protected string EditPanelClientID
        {
            get { return (this.ClientID + "_EditPanel"); }
        }

        protected static string EventHandlersScriptName
        {
            get { return "eqn_ere_eventHandlers"; }
        }

        public static string XmlTagName
        {
            get { return "EDIT"; }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new EditXElement();
            }

            public string TagName
            {
                get { return EditXElement.XmlTagName; }
            }
        }
    }
}