namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using System.Xml;

    public class DateTimeXElement : LabelXElement
    {
        protected DateTimePicker dateControl;
        private bool droppedDown;
        private DateTimeType dtType;
        private static string internalDateFormat = "yyyy'-'MM'-'dd";
        private static string internalTimeFormat = "HH':'mm':'ss";

        public DateTimeXElement() : this("")
        {
        }

        public DateTimeXElement(string type) : base(type)
        {
            this.dateControl = new DateTimePicker();
            this.dateControl.Left = 0;
            this.dateControl.Visible = false;
            this.dateControl.Format = DateTimePickerFormat.Custom;
            if (type == "TIME")
            {
                this.dateControl.ShowUpDown = true;
                this.dtType = DateTimeType.Time;
            }
            else if (type != "DATE")
            {
                this.dtType = DateTimeType.DateTime;
            }
            else
            {
                this.dtType = DateTimeType.Date;
            }
            base.BasePanel.Controls.Add(this.dateControl);
        }

        protected internal override void AdjustSize()
        {
            base.AdjustSize();
            if (base.Dropped)
            {
                this.DateSizeChangedHandler(this, EventArgs.Empty);
            }
        }

        public override void Arrange(int bottomLine, int rowHeight)
        {
            base.Arrange(bottomLine, rowHeight);
            this.dateControl.Top = (bottomLine - this.dateControl.Height) + 4;
        }

        protected override string CalcNewValue()
        {
            string internalTimeFormat;
            if (this.dtType == DateTimeType.Time)
            {
                internalTimeFormat = DateTimeXElement.internalTimeFormat;
            }
            else if (this.dtType == DateTimeType.DateTime)
            {
                internalTimeFormat = internalDateFormat + " " + DateTimeXElement.internalTimeFormat;
            }
            else
            {
                internalTimeFormat = internalDateFormat;
            }
            return this.dateControl.Value.ToString(internalTimeFormat);
        }

        protected override string CoreGetTextAdjustedByValue(string newValue)
        {
            string format = string.Empty;
            bool flag = false;
            switch (this.dtType)
            {
                case DateTimeType.Date:
                    if (base.ParentPanel != null)
                    {
                        format = base.ParentPanel.Appearance.DateFormat;
                    }
                    if (format == string.Empty)
                    {
                        format = "d";
                        flag = true;
                    }
                    break;

                case DateTimeType.Time:
                    if (base.ParentPanel != null)
                    {
                        format = base.ParentPanel.Appearance.TimeFormat;
                    }
                    if (format == string.Empty)
                    {
                        format = "T";
                        flag = true;
                    }
                    break;

                default:
                    if (base.ParentPanel != null)
                    {
                        format = base.ParentPanel.Appearance.DateTimeFormat;
                    }
                    if (format == string.Empty)
                    {
                        format = "G";
                        flag = true;
                    }
                    break;
            }
            DateTime now = DateTime.Now;
            if (newValue != "")
            {
                now = this.ParseDateTimeValue(newValue);
            }
            if (flag)
            {
                return now.ToString(format, DateTimeFormatInfo.CurrentInfo);
            }
            return now.ToString(format, DateTimeFormatInfo.InvariantInfo);
        }

        protected override void CoreLaunch()
        {
            base.CoreLaunch();
            base.AdjustTextByValue();
        }

        protected void DateCloseUpHandler(object sender, EventArgs e)
        {
            this.droppedDown = false;
        }

        protected void DateDropDownHandler(object sender, EventArgs e)
        {
            this.droppedDown = true;
        }

        protected virtual void DateKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                base.RollUp(true);
                this.ElementControl.Select();
            }
            if (e.KeyChar == '\x001b')
            {
                base.RollUp(false);
                this.ElementControl.Select();
            }
        }

        protected virtual void DateLostFocusHandler(object sender, EventArgs e)
        {
            if (!this.droppedDown)
            {
                base.RollUp(true);
            }
        }

        protected void DateSizeChangedHandler(object sender, EventArgs e)
        {
            if (this.dateControl != null)
            {
                base.BasePanel.Width = this.dateControl.Width;
            }
        }

        protected void DateTextChangedHandler(object sender, EventArgs e)
        {
            if ((this.dateControl != null) && base.Dropped)
            {
                SizeF ef = this.dateControl.CreateGraphics().MeasureString(this.dateControl.Text, this.dateControl.Font);
                this.dateControl.Width = ((int) ef.Width) + 40;
            }
        }

        protected override void HideControl()
        {
            this.dateControl.KeyPress -= new KeyPressEventHandler(this.DateKeyPressHandler);
            this.dateControl.LostFocus -= new EventHandler(this.DateLostFocusHandler);
            this.dateControl.SizeChanged -= new EventHandler(this.DateSizeChangedHandler);
            this.dateControl.TextChanged -= new EventHandler(this.DateTextChangedHandler);
            this.dateControl.CloseUp -= new EventHandler(this.DateCloseUpHandler);
            this.dateControl.DropDown -= new EventHandler(this.DateDropDownHandler);
            this.dateControl.Visible = false;
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

        protected DateTime ParseDateTimeValue(string s)
        {
            string internalDateFormat;
            switch (this.dtType)
            {
                case DateTimeType.Date:
                    internalDateFormat = DateTimeXElement.internalDateFormat;
                    break;

                case DateTimeType.Time:
                    internalDateFormat = internalTimeFormat;
                    break;

                default:
                    internalDateFormat = DateTimeXElement.internalDateFormat + " " + internalTimeFormat;
                    break;
            }
            return DateTime.ParseExact(s, internalDateFormat, DateTimeFormatInfo.InvariantInfo);
        }

        public override void ParseXmlNode(XmlNode node)
        {
            XmlAttribute attribute = node.Attributes["SubType"];
            if (attribute != null)
            {
                this.SubType = attribute.Value;
            }
            this.dateControl.ShowUpDown = false;
            if (this.SubType == "TIME")
            {
                this.dateControl.ShowUpDown = true;
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

        protected override void ShowControl()
        {
            if (base.Value != "")
            {
                this.dateControl.Value = this.ParseDateTimeValue(base.Value);
            }
            else
            {
                this.dateControl.Value = DateTime.Now;
            }
            this.dateControl.KeyPress += new KeyPressEventHandler(this.DateKeyPressHandler);
            this.dateControl.LostFocus += new EventHandler(this.DateLostFocusHandler);
            this.dateControl.SizeChanged += new EventHandler(this.DateSizeChangedHandler);
            this.dateControl.TextChanged += new EventHandler(this.DateTextChangedHandler);
            this.dateControl.CloseUp += new EventHandler(this.DateCloseUpHandler);
            this.dateControl.DropDown += new EventHandler(this.DateDropDownHandler);
            base.BasePanel.Width = this.dateControl.Width;
            this.ShowDateTime();
            this.dateControl.BringToFront();
            this.dateControl.Focus();
            this.dateControl.Select();
        }

        protected virtual void ShowDateTime()
        {
            if (this.dtType == DateTimeType.Time)
            {
                this.dateControl.ShowUpDown = true;
                if (base.ParentRow.Parent.Appearance.TimeFormat == "")
                {
                    this.dateControl.CustomFormat = DateTimeFormatInfo.CurrentInfo.LongTimePattern;
                }
                else
                {
                    this.dateControl.CustomFormat = base.ParentRow.Parent.Appearance.TimeFormat;
                }
            }
            else if (this.dtType == DateTimeType.DateTime)
            {
                if (base.ParentRow.Parent.Appearance.DateTimeFormat == "")
                {
                    DateTimeFormatInfo currentInfo = DateTimeFormatInfo.CurrentInfo;
                    this.dateControl.CustomFormat = currentInfo.ShortDatePattern + " " + currentInfo.LongTimePattern;
                }
                else
                {
                    this.dateControl.CustomFormat = base.ParentRow.Parent.Appearance.DateTimeFormat;
                }
            }
            else if (base.ParentRow.Parent.Appearance.DateFormat == "")
            {
                this.dateControl.CustomFormat = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            }
            else
            {
                this.dateControl.CustomFormat = base.ParentRow.Parent.Appearance.DateFormat;
            }
            this.dateControl.Visible = true;
            this.DateTextChangedHandler(null, EventArgs.Empty);
            this.DateSizeChangedHandler(null, EventArgs.Empty);
        }

        public override bool AllowList
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public static string TagName
        {
            get
            {
                return "DATETIME";
            }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new DateTimeXElement();
            }

            public string TagName
            {
                get
                {
                    return DateTimeXElement.TagName;
                }
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

