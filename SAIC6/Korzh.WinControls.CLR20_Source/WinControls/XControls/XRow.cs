namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml;

    public class XRow
    {
        private bool allowShifting;
        private bool disposed;
        protected XElementsStore elements;
        private bool enabled;
        private string id;
        private int level;
        private XPanel listBox;
        internal XRowCheckBox rowCheckBox;
        protected internal XRowControl rowControl;
        private bool showCheckBox;
        private int updatingLevel;
        private bool useCheckBox;

        public XRow(bool useCheckBox)
        {
            this.allowShifting = true;
            this.enabled = true;
            this.rowControl = new XRowControl(this);
            this.useCheckBox = useCheckBox;
            this.rowCheckBox = new XRowCheckBox();
            this.rowCheckBox.ThreeState = false;
            this.rowCheckBox.TabStop = true;
            this.rowCheckBox.BackColor = Color.Transparent;
            this.rowCheckBox.ForeColor = Color.Black;
            this.rowCheckBox.FlatStyle = FlatStyle.Flat;
            this.rowCheckBox.Width = 13;
            this.rowCheckBox.Height = 13;
            this.rowCheckBox.CheckedChanged += new EventHandler(this.RowCheckedChanged);
            this.rowControl.Controls.Add(this.rowCheckBox);
            this.UpdateCheckBox(useCheckBox);
            this.elements = new XElementsStore(this);
            this.rowControl.TabStop = false;
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
            this.Elements.Add(element);
        }

        protected virtual void ApplyElementFormats(XElement element)
        {
            element.ReadOnlyColor = this.listBox.Appearance.ReadOnlyColor;
            if (element is LabelXElement)
            {
                element.TextColor = this.listBox.Appearance.LinkColor;
            }
            element.ApplyFormats();
        }

        public void ApplyFormats()
        {
            if ((this.listBox != null) && !this.RowUpdating)
            {
                this.CoreApplyFormats();
            }
        }

        public void ArrangeRow()
        {
            this.ArrangeRowAt(this.Index);
        }

        protected internal void ArrangeRowAt(int position)
        {
            if (this.Parent != null)
            {
                this.rowControl.SetBounds(this.Parent.DisplayRectangle.Left, (position * this.Parent.Appearance.RowHeight) + this.Parent.DisplayRectangle.Top, this.Parent.ClientSize.Width, this.Parent.Appearance.RowHeight);
                if (this.ShowCheckBox)
                {
                    this.rowCheckBox.Left = this.Parent.Appearance.LeftMargin;
                    this.rowCheckBox.Top = (this.rowControl.Height - this.rowCheckBox.Height) / 2;
                }
                this.InnerRearrangeElements(0);
            }
        }

        public void BeginUpdate()
        {
            if (this.updatingLevel == 0)
            {
                this.rowControl.SuspendLayout();
            }
            this.updatingLevel++;
        }

        private string CheckXmlText(string s)
        {
            if (!s.Trim().ToUpper().StartsWith("<ROW>"))
            {
                return ("<ROW>" + s + "</ROW>");
            }
            return s;
        }

        public void CloseEdits()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                this.elements[i].CloseEdit(true);
            }
        }

        protected virtual void CoreApplyFormats()
        {
            foreach (XElement element in this.Elements)
            {
                this.ApplyElementFormats(element);
            }
            this.ShowCheckBox = this.listBox.Appearance.RowCheckBoxes;
        }

        protected virtual void CoreDetach()
        {
            this.rowControl.Parent = null;
            this.listBox = null;
        }

        protected virtual void CoreDetachElement(XElement element)
        {
        }

        protected virtual void CoreElementAltMenuClick(XElement sender, ValueItem item)
        {
        }

        protected virtual void CoreElementBeforeDropDown(XElement sender)
        {
        }

        protected virtual void CoreElementValidateValue(XElement sender, ValidateValueEventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.ElementValidateValue(sender, e);
            }
        }

        private void CoreRearrangeElements(int startIndex)
        {
            if (this.Parent != null)
            {
                int num = 0;
                if (startIndex > 0)
                {
                    num = this.elements[startIndex - 1].BasePanel.Right + this.GetSpacing(this.elements[startIndex - 1]);
                }
                else
                {
                    num = this.ShowCheckBox ? ((this.rowCheckBox.Right + this.Parent.Appearance.ElementSpacing) + (this.Parent.Appearance.LevelSpacing * this.Level)) : (this.Parent.Appearance.LeftMargin + (this.Parent.Appearance.LevelSpacing * this.Level));
                }
                int bottomLine = ((this.Parent.Appearance.RowHeight - this.Parent.Font.Height) / 2) + this.Parent.Font.Height;
                for (int i = startIndex; i < this.elements.Count; i++)
                {
                    this.elements[i].BasePanel.Left = num;
                    this.elements[i].Arrange(bottomLine, this.Parent.Appearance.RowHeight);
                    num += this.elements[i].BasePanel.Width + this.GetSpacing(this.elements[i]);
                }
                if (num > this.rowControl.Width)
                {
                    this.rowControl.Width = num;
                    if (this.listBox != null)
                    {
                        this.listBox.CheckRowsWidth();
                    }
                }
            }
        }

        protected XElement CreateElementByXmlNode(XmlNode node)
        {
            XElement element = XElement.Create(node.LocalName);
            element.ParseXmlNode(node);
            return element;
        }

        protected XElement CreateElementByXmlText(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            return this.CreateElementByXmlNode(document.DocumentElement);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.elements.Clear();
                if (this.rowControl != null)
                {
                    this.rowControl.Dispose();
                }
                if (this.rowCheckBox != null)
                {
                    this.rowCheckBox.Dispose();
                }
            }
            this.disposed = true;
        }

        public virtual void ElementAction(object sender, string actionName)
        {
            this.ElementAction(sender, actionName, null);
        }

        public virtual void ElementAction(object sender, string actionName, object data)
        {
            if (this.Parent != null)
            {
                this.Parent.InnerDoAction(sender, actionName, data);
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
                this.Parent.InnerDoSignal(sender, signalID, paramList);
            }
        }

        public void EndUpdate()
        {
            this.EndUpdate(true);
        }

        public void EndUpdate(bool updateElements)
        {
            if (this.updatingLevel == 1)
            {
                this.rowControl.ResumeLayout();
                if ((this.Parent != null) && updateElements)
                {
                    this.CoreApplyFormats();
                    this.CoreRearrangeElements(0);
                }
            }
            this.updatingLevel--;
        }

        private XElement FindNextSelectable(int startFrom, bool forward, bool lap)
        {
            int count = startFrom;
            if ((count < 0) && !forward)
            {
                count = this.elements.Count;
            }
            int num2 = count;
            int num3 = -1;
        Label_0019:
            if (forward)
            {
                num2++;
            }
            else
            {
                num2--;
            }
            if ((num2 < 0) || (num2 >= this.elements.Count))
            {
                if (!lap)
                {
                    goto Label_0069;
                }
                if (forward)
                {
                    num2 = -1;
                }
                else
                {
                    num2 = this.elements.Count;
                }
                goto Label_0019;
            }
            if (num2 != count)
            {
                if (!this.elements[num2].CanSelect)
                {
                    goto Label_0019;
                }
                num3 = num2;
            }
        Label_0069:
            if (num3 < 0)
            {
                return null;
            }
            return this.elements[num3];
        }

        public int GetSelectedElementIndex()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                if (this.rowControl.ActiveControl == this.elements[i].ElementControl)
                {
                    return i;
                }
            }
            return -1;
        }

        private int GetSpacing(XElement elem)
        {
            return this.Parent.Appearance.ElementSpacing;
        }

        internal void InnerDetach()
        {
            this.CoreDetach();
        }

        internal void InnerDetachElement(XElement element)
        {
            this.CoreDetachElement(element);
        }

        internal void InnerElementAltMenuClick(XElement sender, ValueItem item)
        {
            this.CoreElementAltMenuClick(sender, item);
        }

        internal void InnerElementBeforeDropDown(XElement sender)
        {
            this.CoreElementBeforeDropDown(sender);
        }

        internal void InnerElementValidateValue(XElement sender, ValidateValueEventArgs e)
        {
            this.CoreElementValidateValue(sender, e);
        }

        internal void InnerRearrangeElements(int startIndex)
        {
            if (!this.RowUpdating)
            {
                this.BeginUpdate();
                try
                {
                    this.CoreRearrangeElements(startIndex);
                }
                finally
                {
                    this.EndUpdate(false);
                }
            }
        }

        protected internal void LaunchElements()
        {
            foreach (XElement element in this.Elements)
            {
                element.InnerLaunch();
            }
        }

        protected virtual void OnEnableChange()
        {
        }

        private void ParseXmlText(string xmlText)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlText);
            XmlNodeList childNodes = document.DocumentElement.ChildNodes;
            this.BeginUpdate();
            try
            {
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
            finally
            {
                this.EndUpdate();
            }
        }

        protected internal void ProcessNewElement(XElement element, int index)
        {
            this.BeginUpdate();
            try
            {
                element.BasePanel.Enabled = this.Enabled;
                element.SetParentRow(this);
                if (this.Parent != null)
                {
                    this.InnerRearrangeElements(index);
                }
                this.rowControl.Controls.Add(element.BasePanel);
            }
            finally
            {
                this.EndUpdate();
            }
        }

        public void Refresh()
        {
            this.rowControl.Refresh();
        }

        private void RowCheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = ((CheckBox) sender).Checked;
            if (this.Active)
            {
                this.SelectNextControl(-1, true, false);
            }
        }

        public void SelectNextControl(bool forward, bool lap)
        {
            this.SelectNextControl(this.GetSelectedElementIndex(), forward, lap);
        }

        public void SelectNextControl(int startFrom, bool forward, bool lap)
        {
            XElement element = this.FindNextSelectable(startFrom, forward, lap);
            if (element != null)
            {
                element.Select();
            }
        }

        private void UpdateCheckBox(bool showCheckBox)
        {
            if (showCheckBox && this.useCheckBox)
            {
                this.rowCheckBox.Checked = this.enabled;
                this.rowCheckBox.Visible = true;
                this.showCheckBox = true;
            }
            else
            {
                this.rowCheckBox.Visible = false;
                this.showCheckBox = false;
            }
        }

        public bool Active
        {
            get
            {
                return (((this.listBox != null) && (this.Index != -1)) && (this.Index == this.listBox.ActiveRowIndex));
            }
            set
            {
                if (((value != this.Active) && (this.listBox != null)) && this.listBox.Rows.Contains(this))
                {
                    this.listBox.ActiveRowIndex = this.Index;
                }
            }
        }

        public virtual bool AllowShifting
        {
            get
            {
                return this.allowShifting;
            }
            set
            {
                this.allowShifting = value;
            }
        }

        public XElementList Elements
        {
            get
            {
                return this.elements;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (value != this.enabled)
                {
                    this.enabled = value;
                    foreach (XElement element in this.elements)
                    {
                        element.BasePanel.Enabled = this.enabled;
                    }
                    if (this.ShowCheckBox && (this.rowCheckBox.Checked != this.enabled))
                    {
                        this.rowCheckBox.Checked = this.enabled;
                    }
                    this.OnEnableChange();
                }
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                }
            }
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
            get
            {
                return this.elements[index];
            }
        }

        public virtual int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                if (this.level != value)
                {
                    this.level = (value < 0) ? 0 : value;
                    this.ArrangeRow();
                }
            }
        }

        public int NativeWidth
        {
            get
            {
                int right = 0;
                foreach (XElement element in this.elements)
                {
                    if (element.BasePanel.Right > right)
                    {
                        right = element.BasePanel.Right;
                    }
                }
                return right;
            }
        }

        protected internal XPanel Parent
        {
            get
            {
                return this.listBox;
            }
            set
            {
                if (value != this.listBox)
                {
                    this.listBox = value;
                    if (this.listBox != null)
                    {
                        this.LaunchElements();
                        this.CoreApplyFormats();
                        this.ArrangeRow();
                    }
                }
            }
        }

        public bool RowUpdating
        {
            get
            {
                return (this.updatingLevel > 0);
            }
        }

        public bool ShowCheckBox
        {
            get
            {
                return this.showCheckBox;
            }
            set
            {
                if (this.useCheckBox && (this.showCheckBox != value))
                {
                    this.UpdateCheckBox(value);
                    this.InnerRearrangeElements(0);
                }
            }
        }

        public bool Updating
        {
            get
            {
                return ((this.updatingLevel > 0) || ((this.listBox != null) && this.listBox.Updating));
            }
        }

        public bool Visible
        {
            get
            {
                return this.rowControl.Visible;
            }
            set
            {
                this.rowControl.Visible = value;
            }
        }

        public int Width
        {
            get
            {
                return this.rowControl.Width;
            }
            set
            {
                this.rowControl.Width = value;
            }
        }

        public string XmlText
        {
            get
            {
                string str = "<ROW>";
                return (str + "</ROW>");
            }
            set
            {
                this.ParseXmlText(value);
            }
        }

        internal class XRowCheckBox : CheckBox
        {
            public XRowCheckBox()
            {
                base.SetStyle(ControlStyles.Selectable, false);
            }
        }

        internal protected class XRowControl : ContainerControl
        {
            private XRow row;

            public XRowControl(XRow aRow)
            {
                this.row = aRow;
                base.SetStyle(ControlStyles.Selectable, false);
                base.SetStyle(ControlStyles.ResizeRedraw, true);
                base.SetStyle(ControlStyles.Opaque, false);
                base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                base.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override bool IsInputKey(Keys keyData)
            {
                if ((!base.IsInputKey(keyData) && (keyData != Keys.Down)) && ((keyData != Keys.Up) && (keyData != Keys.Left)))
                {
                    return (keyData == Keys.Right);
                }
                return true;
            }

            protected override void OnClick(EventArgs e)
            {
                if (this.listBox != null)
                {
                    this.listBox.Focus();
                    this.row.Active = true;
                }
                this.row.CloseEdits();
                base.OnClick(e);
            }

            private XPanel listBox
            {
                get
                {
                    return this.row.listBox;
                }
            }
        }
    }
}

