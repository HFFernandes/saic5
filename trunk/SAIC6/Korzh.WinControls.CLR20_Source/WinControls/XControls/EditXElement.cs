namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class EditXElement : LabelXElement
    {
        private string currentText;
        protected TextBox editControl;
        private bool multiline;
        private bool prevPanelAutoSize;

        public EditXElement() : this("")
        {
        }

        public EditXElement(string type) : base(type)
        {
            this.currentText = "";
            this.editControl = new TextBox();
            this.editControl.Left = 0;
            this.editControl.Width = (base.BasePanel.Width < this.MinEditWidth) ? this.MinEditWidth : base.BasePanel.Width;
            this.editControl.Visible = false;
            base.BasePanel.Controls.Add(this.editControl);
        }

        protected internal override void AdjustSize()
        {
            base.AdjustSize();
            this.EditSizeChangedHandler(this, EventArgs.Empty);
        }

        public override void Arrange(int bottomLine, int rowHeight)
        {
            base.Arrange(bottomLine, rowHeight);
            if (!this.Multiline)
            {
                int num = 0;
                if (this.editControl.BorderStyle != BorderStyle.None)
                {
                    num = 4;
                }
                this.editControl.Top = (bottomLine - this.editControl.Height) + num;
            }
            else
            {
                Point p = base.BasePanel.PointToScreen(this.ElementControl.Location);
                if (base.ParentPanel != null)
                {
                    this.editControl.Parent = base.ParentPanel;
                    this.editControl.Location = base.ParentPanel.PointToClient(p);
                }
            }
        }

        protected override string CalcNewValue()
        {
            return this.editControl.Text;
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
            string[] strArray = val.Split(new char[] { ',', ' ', '\t' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if ((strArray[i] != "") && !this.CheckScalarValue(strArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        protected override string CoreGetTextAdjustedByValue(string newValue)
        {
            string str = base.CoreGetTextAdjustedByValue(newValue);
            if (!this.multiline || ((str.IndexOf('\n') < 0) && (str.Length <= 30)))
            {
                return str;
            }
            string str2 = str.Replace('\n', ' ').Replace('\r', ' ');
            if (str2.Length > 30)
            {
                str2 = str2.Substring(0, 30) + "...";
            }
            return str2;
        }

        protected virtual void EditKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if (!base.ReadOnly)
            {
                if (!char.IsControl(e.KeyChar))
                {
                    TextBox box = (TextBox) sender;
                    string text = box.Text;
                    text.Remove(box.SelectionStart, box.SelectionLength);
                    string val = text.Insert(box.SelectionStart, e.KeyChar.ToString());
                    e.Handled = !this.CheckValue(val);
                }
                if ((!this.multiline && (e.KeyChar == '\r')) || (this.multiline && (e.KeyChar == '\n')))
                {
                    base.RollUp(true);
                    this.ElementControl.Select();
                }
                if (e.KeyChar == '\x001b')
                {
                    base.RollUp(false);
                    this.ElementControlSizeChangedHandler(this, null);
                    this.ElementControl.Select();
                }
            }
        }

        protected virtual void EditLostFocusHandler(object sender, EventArgs e)
        {
            base.RollUp(true);
        }

        protected void EditSizeChangedHandler(object sender, EventArgs e)
        {
            if ((this.editControl != null) && base.Dropped)
            {
                if (this.editControl.Width < this.MinEditWidth)
                {
                    this.editControl.Width = this.MinEditWidth;
                }
                else if (this.editControl.Width > this.MaxEditWidth)
                {
                    this.editControl.Width = this.MaxEditWidth;
                }
                base.BasePanel.Width = this.editControl.Width;
            }
        }

        protected void EditTextChangedHandler(object sender, EventArgs e)
        {
            TextBox box = (TextBox) sender;
            string text = box.Text;
            if ((text != "") && !this.CheckValue(text))
            {
                box.Text = this.currentText;
            }
            else
            {
                this.currentText = this.editControl.Text;
                if (!this.multiline)
                {
                    SizeF ef = this.editControl.CreateGraphics().MeasureString(this.editControl.Text, this.editControl.Font);
                    if (ef.Width > (this.MaxEditWidth - 10))
                    {
                        ef.Width = this.MaxEditWidth - 10;
                    }
                    if (ef.Width < (this.MinEditWidth - 10))
                    {
                        ef.Width = this.MinEditWidth - 10;
                    }
                    this.editControl.Width = ((int) ef.Width) + 10;
                }
            }
        }

        protected override void HideControl()
        {
            this.editControl.KeyPress -= new KeyPressEventHandler(this.EditKeyPressHandler);
            this.editControl.LostFocus -= new EventHandler(this.EditLostFocusHandler);
            this.editControl.SizeChanged -= new EventHandler(this.EditSizeChangedHandler);
            this.editControl.TextChanged -= new EventHandler(this.EditTextChangedHandler);
            this.editControl.Visible = false;
            if (!this.Multiline)
            {
                base.BasePanel.AutoSize = this.prevPanelAutoSize;
            }
            this.ElementControl.Visible = true;
        }

        protected override void LinkClickedHandler(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!base.ReadOnly)
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    this.OnAltClick(EventArgs.Empty);
                }
                else
                {
                    base.DropDown();
                }
            }
        }

        public override void ParseXmlNode(XmlNode node)
        {
            base.ParseXmlNode(node);
            XmlAttribute attribute = node.Attributes["Multiline"];
            if (attribute != null)
            {
                this.Multiline = bool.Parse(attribute.Value);
            }
        }

        protected override void ShowControl()
        {
            this.editControl.Clear();
            this.currentText = base.Value;
            this.editControl.Text = base.Value;
            this.ElementControl.Visible = false;
            if (this.Multiline)
            {
                this.editControl.Width = 300;
                this.editControl.Height = 150;
            }
            else
            {
                base.parentRow.ArrangeRow();
                this.prevPanelAutoSize = base.BasePanel.AutoSize;
                base.BasePanel.AutoSize = false;
            }
            this.EditTextChangedHandler(this.editControl, EventArgs.Empty);
            this.editControl.Visible = true;
            this.editControl.BringToFront();
            this.editControl.Focus();
            this.editControl.ScrollToCaret();
            this.editControl.SelectAll();
            this.editControl.KeyPress += new KeyPressEventHandler(this.EditKeyPressHandler);
            this.editControl.LostFocus += new EventHandler(this.EditLostFocusHandler);
            this.editControl.SizeChanged += new EventHandler(this.EditSizeChangedHandler);
            this.editControl.TextChanged += new EventHandler(this.EditTextChangedHandler);
        }

        private int MaxEditWidth
        {
            get
            {
                if (base.ParentPanel != null)
                {
                    return base.ParentPanel.Appearance.MaxEditBoxSize;
                }
                return 300;
            }
        }

        public int MaxLength
        {
            get
            {
                return this.editControl.MaxLength;
            }
            set
            {
                if (value >= 0)
                {
                    this.editControl.MaxLength = value;
                }
                else
                {
                    this.editControl.MaxLength = 0;
                }
            }
        }

        private int MinEditWidth
        {
            get
            {
                if (base.ParentPanel != null)
                {
                    return base.ParentPanel.Appearance.MinEditBoxSize;
                }
                return 100;
            }
        }

        public bool Multiline
        {
            get
            {
                return this.multiline;
            }
            set
            {
                if (this.multiline != value)
                {
                    this.multiline = value;
                    this.editControl.Multiline = this.multiline;
                    if (this.multiline)
                    {
                        this.editControl.ScrollBars = ScrollBars.Vertical;
                    }
                    else
                    {
                        this.editControl.Parent = base.BasePanel;
                        this.editControl.ScrollBars = ScrollBars.None;
                    }
                }
            }
        }

        public static string TagName
        {
            get
            {
                return "EDIT";
            }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new EditXElement();
            }

            public string TagName
            {
                get
                {
                    return EditXElement.TagName;
                }
            }
        }
    }
}

