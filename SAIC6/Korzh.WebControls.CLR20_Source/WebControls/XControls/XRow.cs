namespace Korzh.WebControls.XControls
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;

    public class XRow
    {
        private bool allowShifting;
        protected XElementsStore elements;
        private bool enabled;
        private int level;
        private XPanel listBox;
        private bool readOnly;
        internal XRowCheckBox rowCheckBox;
        protected internal XRowControl rowControl;

        public XRow(bool useCheckBox)
        {
            this.allowShifting = true;
            this.enabled = true;
            this.rowControl = new XRowControl(this);
            this.elements = new XElementsStore(this);
            if (useCheckBox)
            {
                this.rowCheckBox = new XRowCheckBox();
                this.rowCheckBox.Checked = this.enabled;
                this.rowCheckBox.ID = "cb";
                this.rowCheckBox.BackColor = Color.Transparent;
                this.rowCheckBox.ForeColor = Color.Black;
                this.rowCheckBox.AutoPostBack = true;
                this.rowCheckBox.CheckedChanged += new EventHandler(this.RowCheckedChanged);
                this.rowControl.Controls.Add(this.rowCheckBox);
            }
            else
            {
                this.rowCheckBox = null;
            }
        }

        public XRow(string axmlText) : this(axmlText, false)
        {
        }

        public XRow(string axmlText, bool useCheckBox) : this(useCheckBox)
        {
            this.ParseXmlText(this.CheckXmlText(axmlText));
        }

        private void AddElementByXml(XmlNode node)
        {
            XElement element = this.CreateElementByXmlNode(node);
            if (element != null)
            {
                this.Elements.Add(element);
            }
        }

        public void AddTextElement(string text)
        {
            TextXElement element = new TextXElement();
            element.Value = text;
            element.Text = text;
            this.elements.Add(element);
        }

        protected internal virtual void ApplyElementFormats(XElement element)
        {
            if ((element is LabelXElement) || (element is ListXElement))
            {
                element.ForeColor = this.listBox.Appearance.LinkColor;
            }
            else
            {
                element.ForeColor = this.listBox.ForeColor;
            }
            element.ApplyFormats();
        }

        public void ApplyFormats()
        {
            if (this.listBox != null)
            {
                foreach (XElement element in this.Elements)
                {
                    this.ApplyElementFormats(element);
                }
            }
        }

        protected internal virtual void AssignID()
        {
            this.ID = "r" + this.Index.ToString();
        }

        private string CheckXmlText(string s)
        {
            if (!s.Trim().ToUpper().StartsWith("<ROW>"))
            {
                return ("<ROW>" + s + "</ROW>");
            }
            return s;
        }

        protected virtual void CoreElementAltMenuClick(XElement sender, ValueItem item)
        {
        }

        protected virtual void CoreElementValidateValue(XElement sender, ValidateValueEventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.ElementValidateValue(sender, e);
            }
        }

        protected XElement CreateElementByXmlNode(XmlNode node)
        {
            XElement element = XElement.Create(node.LocalName);
            if (element != null)
            {
                element.ParseXmlNode(node);
                return element;
            }
            return null;
        }

        protected XElement CreateElementByXmlText(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            return this.CreateElementByXmlNode(document.DocumentElement);
        }

        protected internal virtual void DetachControl()
        {
            if (this.rowControl.Parent != null)
            {
                this.rowControl.Parent.Controls.Remove(this.rowControl);
            }
        }

        public virtual void ElementAction(object sender, string actionName)
        {
            this.ElementAction(sender, actionName, null);
        }

        public virtual void ElementAction(object sender, string actionName, object data)
        {
            if (this.Parent != null)
            {
                this.Parent.DoAction(sender, actionName, data);
            }
        }

        protected internal virtual void ElementSignal(object sender, Signals signalID)
        {
            this.ElementSignal(sender, signalID, null);
        }

        protected internal virtual void ElementSignal(object sender, Signals signalID, string[] paramList)
        {
            if (this.Parent != null)
            {
                this.Parent.DoSignal(sender, signalID, paramList);
            }
        }

        private int GetSpacing(XElement elem)
        {
            if (this.Parent == null)
            {
                return 2;
            }
            return this.Parent.Appearance.ElementSpacing;
        }

        internal void InnerElementAltMenuClick(XElement sender, ValueItem item)
        {
            this.CoreElementAltMenuClick(sender, item);
        }

        internal void InnerElementValidateValue(XElement sender, ValidateValueEventArgs e)
        {
            this.CoreElementValidateValue(sender, e);
        }

        protected internal void LaunchElements()
        {
            foreach (XElement element in this.Elements)
            {
                element.InnerLaunch();
            }
        }

        protected virtual void OnEnabledChange()
        {
        }

        private void ParseXmlText(string xmlText)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlText);
            XmlNodeList childNodes = document.DocumentElement.ChildNodes;
            this.elements.Clear();
            foreach (XmlNode node in childNodes)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            this.AddElementByXml(node);
                            continue;
                        }
                    case XmlNodeType.Attribute:
                        {
                            continue;
                        }
                    case XmlNodeType.Text:
                        {
                            this.AddTextElement(node.Value);
                            continue;
                        }
                }
            }
        }

        protected internal void ProcessNewElement(XElement element, int index)
        {
            this.rowControl.Controls.Add(element);
            element.EnableViewState = false;
            element.Enabled = this.Enabled;
            element.ID = 'e' + index.ToString();
            element.SetParentRow(this);
        }

        public void Refresh()
        {
        }

        public void RenderRow(HtmlTextWriter writer)
        {
            this.rowControl.RenderControl(writer);
        }

        private void RowCheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = ((CheckBox) sender).Checked;
        }

        public virtual bool AllowShifting
        {
            get { return this.allowShifting; }
            set { this.allowShifting = value; }
        }

        public string ElementCssClass
        {
            get
            {
                string elementCssClass = this.Parent.Appearance.ElementCssClass;
                if (!(elementCssClass != string.Empty))
                {
                    return this.RowCssClass;
                }
                return elementCssClass;
            }
        }

        public XElementList Elements
        {
            get { return this.elements; }
        }

        public virtual bool Enabled
        {
            get { return this.enabled; }
            set
            {
                if (value != this.enabled)
                {
                    this.enabled = value;
                    foreach (XElement element in this.elements)
                    {
                        element.Enabled = this.enabled;
                    }
                    if ((this.rowCheckBox != null) && (this.rowCheckBox.Checked != this.enabled))
                    {
                        this.rowCheckBox.Checked = this.enabled;
                    }
                    this.OnEnabledChange();
                }
            }
        }

        public string ID
        {
            get { return this.rowControl.ID; }
            set { this.rowControl.ID = value; }
        }

        public int Index
        {
            get
            {
                if (this.listBox != null)
                {
                    return this.listBox.Rows.IndexOf(this);
                }
                return -1;
            }
        }

        public XElement this[int index]
        {
            get { return this.elements[index]; }
        }

        public virtual int Level
        {
            get { return this.level; }
            set
            {
                if (this.level != value)
                {
                    this.level = (value < 0) ? 0 : value;
                }
            }
        }

        protected internal XPanel Parent
        {
            get { return this.listBox; }
            set
            {
                if (value != this.listBox)
                {
                    this.listBox = value;
                    if (this.listBox != null)
                    {
                        this.LaunchElements();
                        this.ApplyFormats();
                    }
                }
            }
        }

        public virtual bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                if (value != this.readOnly)
                {
                    this.readOnly = value;
                    foreach (XElement element in this.elements)
                    {
                        element.ReadOnly = this.readOnly;
                    }
                    if (this.rowCheckBox != null)
                    {
                        this.rowCheckBox.Enabled = !this.readOnly;
                    }
                }
            }
        }

        public string RowCssClass
        {
            get
            {
                string rowCssClass = this.Parent.Appearance.RowCssClass;
                if (!(rowCssClass != string.Empty))
                {
                    return this.Parent.CssClass;
                }
                return rowCssClass;
            }
        }

        public string XmlText
        {
            get
            {
                string str = "<ROW>";
                return (str + "</ROW>");
            }
            set { this.ParseXmlText(value); }
        }

        internal class XRowCheckBox : CheckBox
        {
        }

        protected internal class XRowControl : Panel, INamingContainer
        {
            private XRow row;

            public XRowControl(XRow aRow)
            {
                this.row = aRow;
            }

            protected override void Render(HtmlTextWriter writer)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "2");
                writer.AddAttribute(HtmlTextWriterAttribute.Style, "border:none;");
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.row.RowCssClass);
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                if (this.row.rowCheckBox != null)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.row.ElementCssClass);
                    writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "nowrap");
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    this.row.rowCheckBox.RenderControl(writer);
                    writer.RenderEndTag();
                }
                for (int i = 0; i < this.row.Level; i++)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write("&nbsp;&nbsp;&nbsp;");
                    writer.RenderEndTag();
                }
                foreach (XElement element in this.row.Elements)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.row.ElementCssClass);
                    writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "nowrap");
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    element.RenderControl(writer);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write("&nbsp;");
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
                writer.RenderEndTag();
            }

            private XPanel listBox
            {
                get { return this.row.listBox; }
            }
        }
    }
}