namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    using System.Web.UI;
    using System.Xml;

    public class DateTimeXElement : LabelXElement, IPostBackDataHandler
    {
        private DateTimeType dtType;
        private static string internalDateFormat = "yyyy'-'MM'-'dd";
        private static string internalDateTimeFormat = (internalDateFormat + " " + internalTimeFormat);
        private static string internalTimeFormat = "HH':'mm':'ss";
        private string postedValue;

        public DateTimeXElement() : this("")
        {
        }

        public DateTimeXElement(string subType) : base(subType)
        {
            if (subType == "TIME")
            {
                this.dtType = DateTimeType.Time;
            }
            else if (subType != "DATE")
            {
                this.dtType = DateTimeType.DateTime;
            }
            else
            {
                this.dtType = DateTimeType.Date;
            }
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
                    str = "if (event.ctrlKey) " + base.altMenuControl.GetShowScriptReference() + "; else {";
                }
                str = str + "javascript:kShowElementAt('" + this.DatePanelClientID + "','" + this.ClientID +
                      "', 0, 0);kFocusElement('" + this.DatePanelClientID + "_textbox');" + str2 + " return false";
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, str);
            }
        }

        protected override string CoreGetTextAdjustedByValue(string newValue)
        {
            DateTime time;
            string currentFormat = this.GetCurrentFormat();
            bool flag = false;
            if (currentFormat == string.Empty)
            {
                flag = true;
                switch (this.dtType)
                {
                    case DateTimeType.Date:
                        currentFormat = "d";
                        goto Label_0045;

                    case DateTimeType.Time:
                        currentFormat = "T";
                        goto Label_0045;
                }
                currentFormat = "G";
            }
            Label_0045:
            time = DateTime.Now;
            if (newValue != "")
            {
                time = this.ParseDateTimeValue(newValue);
            }
            if (flag)
            {
                return time.ToString(currentFormat, DateTimeFormatInfo.CurrentInfo);
            }
            return time.ToString(currentFormat, DateTimeFormatInfo.InvariantInfo);
        }

        protected override void CoreLaunch()
        {
            base.CoreLaunch();
            base.AdjustTextByValue();
        }

        protected string GetCurrentFormat()
        {
            if (base.ParentPanel == null)
            {
                return this.GetCurrentInternalFormat();
            }
            if (this.dtType == DateTimeType.Time)
            {
                return base.ParentPanel.Appearance.TimeFormat;
            }
            if (this.dtType == DateTimeType.Date)
            {
                return base.ParentPanel.Appearance.DateFormat;
            }
            return base.ParentPanel.Appearance.DateTimeFormat;
        }

        protected string GetCurrentInternalFormat()
        {
            if (this.dtType == DateTimeType.Time)
            {
                return internalTimeFormat;
            }
            if (this.dtType == DateTimeType.Date)
            {
                return internalDateFormat;
            }
            return internalDateTimeFormat;
        }

        protected DateTime ParseDateTimeValue(string s)
        {
            return DateTime.ParseExact(s, this.GetCurrentInternalFormat(), DateTimeFormatInfo.InvariantInfo);
        }

        public override void ParseXmlNode(XmlNode node)
        {
            XmlAttribute attribute = node.Attributes["SubType"];
            if (attribute != null)
            {
                this.SubType = attribute.Value;
            }
            if (this.SubType == "TIME")
            {
                this.dtType = DateTimeType.Time;
            }
            else if (this.SubType != "DATE")
            {
                this.dtType = DateTimeType.DateTime;
            }
            else
            {
                this.dtType = DateTimeType.Date;
            }
            if (node.Attributes["Value"] != null)
            {
                base.Value = node.Attributes["Value"].Value;
            }
            if (node.InnerText != "")
            {
                this.Text = node.InnerText;
            }
        }

        protected override void PreRenderElementControl()
        {
            this.GetCurrentFormat();
            base.linkControl.Text = this.Text;
            base.linkControl.NavigateUrl = "javascript:void(0)";
            base.PreRenderElementControl();
            this.Page.ClientScript.RegisterClientScriptInclude("DateTimePicker",
                                                               this.Page.ClientScript.GetWebResourceUrl(base.GetType(),
                                                                                                        "Korzh.WebControls.Resources.DateTimePicker.js"));
            if (base.IsInsideUpdatePanel)
            {
                Ajax.RegisterClientScriptResource(this.Page, base.GetType(),
                                                  "Korzh.WebControls.Resources.DateTimePicker.js");
            }
            Type type = base.GetType();
            string key = this.ClientID + "_dtformat";
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(type, key))
            {
                StringBuilder builder = new StringBuilder(0x3e8);
                builder.Append("<script type=\"text/javascript\">\n<!--\n");
                builder.Append("var " + this.DatePanelClientID + "_dtformat = '" + this.GetCurrentFormat() + "';");
                builder.Append("// -->\n</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(type, key, builder.ToString());
                if (base.IsInsideUpdatePanel)
                {
                    Ajax.RegisterClientScriptBlock(this.Page, type, key, builder.ToString(), false);
                }
            }
            key = EventHandlersScriptName;
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(type, key))
            {
                StringBuilder builder2 = new StringBuilder(0x3e8);
                builder2.Append("<script type=\"text/javascript\">\n<!--\n");
                builder2.Append("eqn_dtre_ignore_next_blur = false;\n");
                builder2.Append("function eqn_dtre_keypressHandler(eventTargetID, e) {\n");
                builder2.Append("    var keynum = e.keyCode || e.which;\n");
                builder2.Append("    var srcElement = e.target || e.srcElement;\n");
                builder2.Append("    if (keynum == 13) {\n");
                builder2.Append("        eqn_dtre_ignore_next_blur = true;\n");
                builder2.Append("        e.cancelBubble = true;\n");
                builder2.Append("        e.returnValue = false;\n");
                builder2.Append("        if (!isDate(srcElement.value, window[eventTargetID + '_dtformat'])) {\n");
                builder2.Append("             alert('Incorrect date/time format');\n");
                builder2.Append("             if (window.event) {;\n");
                builder2.Append("                 e.returnValue = false;}\n");
                builder2.Append("             else {\n");
                builder2.Append("                 e.preventDefault(); };\n");
                builder2.Append("             return false;\n");
                builder2.Append("        } else {\n");
                builder2.Append(
                    "             var corDate = formatDate(getDateFromFormat(srcElement.value, window[eventTargetID + '_dtformat']), window[eventTargetID + '_dtformat']);\n");
                builder2.Append("             srcElement.value = corDate;\n");
                builder2.Append("             kHideElement(eventTargetID);\n");
                builder2.Append("             __doPostBack(eventTargetID, '');\n");
                builder2.Append("             return false;\n");
                builder2.Append("        } \n");
                builder2.Append("    }\n");
                builder2.Append("    else if (keynum == 27) {\n");
                builder2.Append("        eqn_dtre_ignore_next_blur = true;\n");
                builder2.Append("        kHideElement(eventTargetID);\n");
                builder2.Append("        if (e.currentTarget) e.currentTarget.blur();\n");
                builder2.Append("        e.cancelBubble = true;\n");
                builder2.Append("        e.returnValue = false;\n");
                builder2.Append("        return false\n");
                builder2.Append("    }\n");
                builder2.Append("    return true;\n");
                builder2.Append("}\n");
                builder2.Append("\n");
                builder2.Append("function eqn_dtre_lostFocusHandler(eventTargetID, event) {\n");
                builder2.Append("    if (!eqn_dtre_ignore_next_blur){\n");
                builder2.Append("        event.cancelBubble = true;\n");
                builder2.Append("        event.returnValue = false;\n");
                builder2.Append("        var target = document.getElementById(eventTargetID);\n");
                builder2.Append("        if (target.style.visibility == 'visible') {\n");
                builder2.Append("          var srcElement = event.target || event.srcElement;\n");
                builder2.Append("          if (!isDate(srcElement.value, window[eventTargetID + '_dtformat'])) {\n");
                builder2.Append("             alert('Incorrect date/time format');\n");
                builder2.Append("             if (window.event) {;\n");
                builder2.Append("                 event.returnValue = false;}\n");
                builder2.Append("             else {\n");
                builder2.Append("                 event.preventDefault(); };\n");
                builder2.Append("             return false;\n");
                builder2.Append("          } else {\n");
                builder2.Append(
                    "             var corDate = formatDate(getDateFromFormat(srcElement.value, window[eventTargetID + '_dtformat']), window[eventTargetID + '_dtformat']);\n");
                builder2.Append("             srcElement.value = corDate;\n");
                builder2.Append("             kHideElement(eventTargetID);\n");
                builder2.Append("             __doPostBack(eventTargetID, '');\n");
                builder2.Append("             return false\n");
                builder2.Append("          } \n");
                builder2.Append("        }\n");
                builder2.Append("    }\n");
                builder2.Append("    eqn_dtre_ignore_next_blur = false;\n");
                builder2.Append("    return false\n");
                builder2.Append("}\n");
                builder2.Append("// -->\n</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(type, key, builder2.ToString());
                if (base.IsInsideUpdatePanel)
                {
                    Ajax.RegisterClientScriptBlock(this.Page, type, key, builder2.ToString(), false);
                }
            }
            this.Page.RegisterRequiresPostBack(this);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            int num = 0x3e7;
            string internalDateFormat = DateTimeXElement.internalDateFormat;
            string internalTimeFormat = DateTimeXElement.internalTimeFormat;
            if (base.ParentPanel != null)
            {
                internalDateFormat = base.ParentPanel.Appearance.DateFormat;
                internalTimeFormat = base.ParentPanel.Appearance.TimeFormat;
            }
            if (this.dtType == DateTimeType.Date)
            {
                internalTimeFormat = "";
            }
            writer.AddAttribute("id", this.DatePanelClientID, false);
            writer.AddAttribute("style",
                                "position:absolute; z-index:" + num.ToString() + ";visibility:hidden;overflow:auto",
                                false);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute("border", "0", false);
            writer.AddAttribute("cellspacing", "0", false);
            writer.AddAttribute("cellpadding", "0", false);
            writer.RenderBeginTag("table");
            writer.RenderBeginTag("tr");
            writer.RenderBeginTag("td");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.DatePanelClientID + "_textbox");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.DatePanelClientID + "_textbox");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
            writer.AddAttribute("onkeypress",
                                "javascript: return eqn_dtre_keypressHandler('" + this.DatePanelClientID + "', event)");
            writer.AddAttribute("onblur",
                                "javascript: return eqn_dtre_lostFocusHandler('" + this.DatePanelClientID + "', event)");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderBeginTag("td");
            if (this.dtType != DateTimeType.Time)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, this.DatePanelClientID + "_dimg");
                writer.AddAttribute(HtmlTextWriterAttribute.Id, this.DatePanelClientID + "_dimg");
                writer.AddAttribute(HtmlTextWriterAttribute.Src,
                                    this.Page.ClientScript.GetWebResourceUrl(base.GetType(),
                                                                             "Korzh.WebControls.Resources.Picker.gif"));
                writer.AddAttribute("onmousedown", "javascript:eqn_dtre_ignore_next_blur = true;");
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick,
                                    "displayDatePicker('" + this.DatePanelClientID + "_textbox',false,'" +
                                    internalDateFormat + "', '" + internalTimeFormat + "');");
                writer.RenderBeginTag(HtmlTextWriterTag.Img);
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
            base.Render(writer);
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection values)
        {
            this.postedValue = values[this.DatePanelClientID + "_textBox"];
            return (this.postedValue != null);
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            try
            {
                string str =
                    DateTime.ParseExact(this.postedValue, this.GetCurrentFormat(), DateTimeFormatInfo.InvariantInfo).
                        ToString(this.GetCurrentInternalFormat(), DateTimeFormatInfo.CurrentInfo);
                bool accept = true;
                if (base.NeedValidate)
                {
                    ValidateValueEventArgs e = new ValidateValueEventArgs(str, true);
                    this.OnValidate(e);
                    str = e.Value;
                    accept = e.Accept;
                }
                if (accept)
                {
                    base.Value = str;
                }
            }
            catch
            {
            }
        }

        public override bool AllowList
        {
            get { return false; }
            set { }
        }

        protected string DatePanelClientID
        {
            get { return (this.ClientID + "_DatePanel"); }
        }

        protected static string EventHandlersScriptName
        {
            get { return "eqn_dtre_eventHandlers"; }
        }

        public static string XmlTagName
        {
            get { return "DATETIME"; }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new DateTimeXElement();
            }

            public string TagName
            {
                get { return DateTimeXElement.XmlTagName; }
            }
        }

        protected enum DateTimeType
        {
            Date,
            Time,
            DateTime
        }
    }
}