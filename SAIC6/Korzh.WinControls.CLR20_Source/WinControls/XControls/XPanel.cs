namespace Korzh.WinControls.XControls
{
    using Korzh.WinControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(XPanel))]
    public class XPanel : Panel
    {
        internal XRow activeRowBeforeUpdate;
        private int activeRowIndex = -1;
        private XAppearance appearance;
        private bool disposed;
        private XRowList rows;
        private TextStorage texts = new TextStorage();
        private int updatingLevel;

        public event ActionEventHandler Action;

        public event PaintEventHandler ElementPaint;

        public event PaintEventHandler RowPaint;

        public event ValidateValueEventHandler ValidateValue;

        static XPanel()
        {
            XElement.Register(new TextXElement.Creator());
            XElement.Register(new LabelXElement.Creator());
            XElement.Register(new EditXElement.Creator());
            XElement.Register(new ListXElement.Creator());
            XElement.Register(new DateTimeXElement.Creator());
            XElement.Register(new ButtonListXElement.Creator());
        }

        public XPanel()
        {
            base.SetStyle(ControlStyles.Selectable, true);
            this.rows = this.CreateRowList();
            this.appearance = this.CreateAppearance();
            this.AutoScroll = true;
            base.TabStop = true;
        }

        protected virtual void ApplyFormats()
        {
            foreach (XRow row in this.Rows)
            {
                row.ApplyFormats();
            }
        }

        protected virtual void Arrange()
        {
            this.Rows.Arrange();
        }

        public void BeginUpdate()
        {
            if (this.updatingLevel == 0)
            {
                this.CoreBeginUpdate();
                base.SuspendLayout();
                this.activeRowBeforeUpdate = this.ActiveRow;
            }
            this.updatingLevel++;
        }

        internal void CheckActiveRowIndex()
        {
            if (this.activeRowIndex >= this.Rows.Count)
            {
                this.activeRowIndex = this.Rows.Count - 1;
            }
        }

        internal void CheckRowsWidth()
        {
            int nativeWidth = 0;
            if (this.AutoScroll)
            {
                foreach (XRow row in this.Rows)
                {
                    if (nativeWidth < row.NativeWidth)
                    {
                        nativeWidth = row.NativeWidth;
                    }
                }
                int width = (nativeWidth > base.ClientSize.Width) ? nativeWidth : base.ClientSize.Width;
                this.SetRowsWidth(width);
            }
            else
            {
                this.SetRowsWidth(base.ClientSize.Width);
            }
        }

        protected virtual void CoreBeginUpdate()
        {
        }

        protected virtual void CoreEndUpdate()
        {
        }

        protected virtual XAppearance CreateAppearance()
        {
            return new XAppearance(this);
        }

        protected virtual XRowList CreateRowList()
        {
            return new XRowList(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    this.rows.Clear();
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
            this.disposed = true;
        }

        protected virtual void DoAction(object sender, string actionName, object data)
        {
            if (this.Action != null)
            {
                ActionEventArgs e = new ActionEventArgs(actionName, data);
                this.Action(sender, e);
            }
        }

        protected virtual void DoElementPaint(object sender, PaintEventArgs e)
        {
            if (this.ElementPaint != null)
            {
                this.ElementPaint(sender, e);
            }
        }

        protected virtual void DoListRequest(ListXElement element, string listName)
        {
        }

        protected virtual void DoRowPaint(object sender, PaintEventArgs e)
        {
            if (this.RowPaint != null)
            {
                this.RowPaint(sender, e);
            }
        }

        protected virtual void DoSignal(object sender, Signals signalID, string[] paramList)
        {
            int activeRowIndex;
            Keys none = Keys.None;
            switch (signalID)
            {
                case Signals.KeyDown:
                    none = Keys.Down;
                    break;

                case Signals.KeyCtrlDown:
                    activeRowIndex = this.ActiveRowIndex;
                    if (activeRowIndex < (this.Rows.Count - 1))
                    {
                        this.MoveRowDown(activeRowIndex);
                    }
                    break;

                case Signals.KeyUp:
                    none = Keys.Up;
                    break;

                case Signals.KeyCtrlUp:
                    activeRowIndex = this.ActiveRowIndex;
                    if (activeRowIndex > 0)
                    {
                        this.MoveRowUp(activeRowIndex);
                    }
                    break;

                case Signals.KeyLeft:
                    none = Keys.Left;
                    break;

                case Signals.KeyCtrlLeft:
                    this.ShiftRowLevel(this.ActiveRowIndex, true);
                    break;

                case Signals.KeyRight:
                    none = Keys.Right;
                    break;

                case Signals.KeyCtrlRight:
                    this.ShiftRowLevel(this.ActiveRowIndex, false);
                    break;

                case Signals.KeyTab:
                    base.TopLevelControl.SelectNextControl(this, true, true, true, true);
                    break;

                case Signals.KeyShiftTab:
                    base.TopLevelControl.SelectNextControl(this, false, true, true, true);
                    break;

                case Signals.ListRequest:
                    this.DoListRequest((ListXElement) sender, paramList[0]);
                    break;

                case Signals.Activate:
                {
                    XRow parentRow = ((XElement) sender).ParentRow;
                    this.ActiveRowIndex = parentRow.Index;
                    break;
                }
            }
            if (none != Keys.None)
            {
                KeyEventArgs e = new KeyEventArgs(none);
                this.OnKeyDown(e);
            }
        }

        internal void ElementValidateValue(XElement sender, ValidateValueEventArgs e)
        {
            this.OnValidateValue(e);
        }

        public void EndUpdate()
        {
            this.updatingLevel--;
            if (this.updatingLevel == 0)
            {
                base.ResumeLayout();
                this.AdjustFormScrollbars(true);
                this.UpdateActiveRow(this.activeRowBeforeUpdate);
                this.CoreEndUpdate();
            }
        }

        private int GetRowIndexAt(int YPos)
        {
            return (YPos / this.Appearance.RowHeight);
        }

        internal void InnerDoAction(object sender, string actionName, object data)
        {
            this.DoAction(sender, actionName, data);
        }

        internal void InnerDoSignal(object sender, Signals signalID, string[] paramList)
        {
            this.DoSignal(sender, signalID, paramList);
        }

        internal void InnerPlaceRow(XRow row)
        {
            this.PlaceRow(row);
        }

        internal void InnerRowAdded(XRow row)
        {
            this.OnRowAdded(row);
        }

        internal void InnerRowListChanged()
        {
            this.OnRowListChanged();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (((!base.IsInputKey(keyData) && (keyData != Keys.Down)) && ((keyData != Keys.Up) && (keyData != Keys.Left))) && ((keyData != Keys.Right) && (keyData != Keys.Tab)))
            {
                return (keyData == (Keys.Shift | Keys.Tab));
            }
            return true;
        }

        public virtual void MoveRowDown(int index)
        {
            this.Arrange();
        }

        public virtual void MoveRowUp(int index)
        {
            this.Arrange();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.Arrange();
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.ActiveRow != null)
            {
                this.ActiveRow.CloseEdits();
            }
            base.OnClick(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.Arrange();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.Arrange();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.ActiveRow != null)
            {
                this.ActiveRow.SelectNextControl(-1, true, false);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!e.Handled && (this.activeRowIndex >= 0))
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.ActiveRowIndex++;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    this.ActiveRowIndex--;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    this.Rows[this.ActiveRowIndex].SelectNextControl(false, true);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    this.Rows[this.ActiveRowIndex].SelectNextControl(true, true);
                    e.Handled = true;
                }
            }
            base.OnKeyDown(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            base.Invalidate();
        }

        protected virtual void OnRowAdded(XRow row)
        {
        }

        protected virtual void OnRowListChanged()
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.CheckRowsWidth();
        }

        protected virtual void OnValidateValue(ValidateValueEventArgs e)
        {
            if (this.ValidateValue != null)
            {
                this.ValidateValue(this, e);
            }
        }

        protected void PlaceRow(XRow row)
        {
            row.Parent = this;
            row.Active = true;
            row.rowControl.Paint += new PaintEventHandler(this.DoRowPaint);
            base.Controls.Add(row.rowControl);
        }

        public override void Refresh()
        {
            this.ApplyFormats();
            this.Arrange();
            base.Refresh();
        }

        protected virtual void SetRowsWidth(int width)
        {
            foreach (XRow row in this.Rows)
            {
                row.rowControl.Width = width;
            }
        }

        public virtual void ShiftRowLevel(int rowIndex, bool up)
        {
            if (((rowIndex >= 0) && (rowIndex < this.rows.Count)) && ((this.rows[rowIndex] != null) && this.rows[rowIndex].AllowShifting))
            {
                int num = up ? -1 : 1;
                int level = this.rows[rowIndex].Level;
                if ((level != 0) || !up)
                {
                    this.rows[rowIndex].Level += num;
                    if (this.Appearance.AdjustChildLevel)
                    {
                        int num3 = rowIndex + 1;
                        while ((num3 >= 0) && (num3 < this.rows.Count))
                        {
                            if (this.rows[num3] != null)
                            {
                                if (this.rows[num3].Level <= level)
                                {
                                    return;
                                }
                                this.rows[num3].Level += num;
                                num3++;
                            }
                        }
                    }
                }
            }
        }

        internal void UpdateActiveRow(XRow prevActiveRow)
        {
            if (prevActiveRow != null)
            {
                prevActiveRow.rowControl.BackColor = this.BackColor;
            }
            if (this.ActiveRow != null)
            {
                this.ActiveRow.rowControl.BackColor = this.Appearance.ActiveBackColor;
                this.ActiveRow.SelectNextControl(-1, true, false);
                if (base.Visible)
                {
                    base.ScrollControlIntoView(this.ActiveRow.rowControl);
                }
            }
        }

        [Browsable(false)]
        public XRow ActiveRow
        {
            get
            {
                if (this.ActiveRowIndex >= 0)
                {
                    return this.Rows[this.ActiveRowIndex];
                }
                return null;
            }
        }

        [Browsable(false)]
        public int ActiveRowIndex
        {
            get
            {
                this.CheckActiveRowIndex();
                return this.activeRowIndex;
            }
            set
            {
                if (((value != this.activeRowIndex) && (value >= 0)) && (value < this.Rows.Count))
                {
                    XRow activeRow = this.ActiveRow;
                    this.activeRowIndex = value;
                    if (!this.Updating)
                    {
                        this.UpdateActiveRow(activeRow);
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
        public XAppearance Appearance
        {
            get
            {
                return this.appearance;
            }
            set
            {
                if (this.appearance != value)
                {
                    this.appearance = value;
                    this.ApplyFormats();
                }
            }
        }

        [DefaultValue(true)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        public static Color DefaultBackColor
        {
            get
            {
                return Color.White;
            }
        }

        [Browsable(false)]
        public XRowList Rows
        {
            get
            {
                return this.rows;
            }
        }

        public TextStorage Texts
        {
            get
            {
                return this.texts;
            }
        }

        public bool Updating
        {
            get
            {
                return (this.updatingLevel > 0);
            }
        }

        [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
        public class XAppearance
        {
            private Color activeBackColor;
            private Color activeForeColor;
            private bool adjustChildLevel = true;
            private Color buttonActiveBodyColor;
            private Color buttonActiveBorderColor;
            private Color buttonClickBodyColor;
            private Color buttonClickBorderColor;
            private Color buttonForeColor;
            private Color buttonInactiveBodyColor;
            private Color buttonInactiveBorderColor;
            private bool buttonRounded;
            private string dateFormat = "";
            private string datetimeFormat = "";
            private int elementSpacing = 2;
            private int leftMargin = 2;
            private int levelSpacing = 30;
            private Color linkColor;
            private int maxEditBoxSize = 300;
            private int minEditBoxSize = 100;
            protected XPanel parent;
            private Color readOnlyColor;
            private bool rowCheckBoxes = true;
            private int rowHeight;
            private string timeFormat = "";
            private bool tuneElementSizes;

            public XAppearance(XPanel parent)
            {
                this.parent = parent;
                this.activeBackColor = Color.FromArgb(190, 0xe1, 190);
                this.activeForeColor = SystemColors.HighlightText;
                this.linkColor = Color.Blue;
                this.readOnlyColor = Color.Black;
                this.rowHeight = 0x12;
                this.buttonRounded = true;
                this.buttonForeColor = parent.ForeColor;
                this.buttonInactiveBodyColor = Color.Transparent;
                this.buttonInactiveBorderColor = Color.Black;
                this.buttonActiveBodyColor = Color.Gray;
                this.buttonActiveBorderColor = Color.Black;
                this.buttonClickBodyColor = Color.White;
                this.buttonClickBorderColor = Color.Black;
            }

            protected void RefreshParent()
            {
                this.parent.Refresh();
            }

            public Color ActiveBackColor
            {
                get
                {
                    return this.activeBackColor;
                }
                set
                {
                    if (this.activeBackColor != value)
                    {
                        this.activeBackColor = value;
                        if (this.parent.ActiveRow != null)
                        {
                            this.parent.ActiveRow.Refresh();
                        }
                    }
                }
            }

            public Color ActiveForeColor
            {
                get
                {
                    return this.activeForeColor;
                }
                set
                {
                    if (this.activeForeColor != value)
                    {
                        this.activeForeColor = value;
                        if (this.parent.ActiveRow != null)
                        {
                            this.parent.ActiveRow.Refresh();
                        }
                    }
                }
            }

            public bool AdjustChildLevel
            {
                get
                {
                    return this.adjustChildLevel;
                }
                set
                {
                    if (this.adjustChildLevel != value)
                    {
                        this.adjustChildLevel = value;
                        this.parent.Refresh();
                    }
                }
            }

            public Color ButtonActiveBodyColor
            {
                get
                {
                    return this.buttonActiveBodyColor;
                }
                set
                {
                    if (this.buttonActiveBodyColor != value)
                    {
                        this.buttonActiveBodyColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ButtonActiveBorderColor
            {
                get
                {
                    return this.buttonActiveBorderColor;
                }
                set
                {
                    if (this.buttonActiveBorderColor != value)
                    {
                        this.buttonActiveBorderColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ButtonClickBodyColor
            {
                get
                {
                    return this.buttonClickBodyColor;
                }
                set
                {
                    if (this.buttonClickBodyColor != value)
                    {
                        this.buttonClickBodyColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ButtonClickBorderColor
            {
                get
                {
                    return this.buttonClickBorderColor;
                }
                set
                {
                    if (this.buttonClickBorderColor != value)
                    {
                        this.buttonClickBorderColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ButtonForeColor
            {
                get
                {
                    return this.buttonForeColor;
                }
                set
                {
                    if (this.buttonForeColor != value)
                    {
                        this.buttonForeColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ButtonInactiveBodyColor
            {
                get
                {
                    return this.buttonInactiveBodyColor;
                }
                set
                {
                    if (this.buttonInactiveBodyColor != value)
                    {
                        this.buttonInactiveBodyColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ButtonInactiveBorderColor
            {
                get
                {
                    return this.buttonInactiveBorderColor;
                }
                set
                {
                    if (this.buttonInactiveBorderColor != value)
                    {
                        this.buttonInactiveBorderColor = value;
                        this.RefreshParent();
                    }
                }
            }

            [Browsable(true)]
            public bool ButtonRounded
            {
                get
                {
                    return this.buttonRounded;
                }
                set
                {
                    if (this.buttonRounded != value)
                    {
                        this.buttonRounded = value;
                        this.RefreshParent();
                    }
                }
            }

            [DefaultValue("")]
            public string DateFormat
            {
                get
                {
                    return this.dateFormat;
                }
                set
                {
                    if (this.dateFormat != value)
                    {
                        this.dateFormat = value;
                        this.RefreshParent();
                    }
                }
            }

            [DefaultValue("")]
            public string DateTimeFormat
            {
                get
                {
                    return this.datetimeFormat;
                }
                set
                {
                    if (this.datetimeFormat != value)
                    {
                        this.datetimeFormat = value;
                        this.RefreshParent();
                    }
                }
            }

            public int ElementSpacing
            {
                get
                {
                    return this.elementSpacing;
                }
                set
                {
                    if (this.elementSpacing != value)
                    {
                        this.elementSpacing = value;
                        this.RefreshParent();
                    }
                }
            }

            public int LeftMargin
            {
                get
                {
                    return this.leftMargin;
                }
                set
                {
                    if (this.leftMargin != value)
                    {
                        this.leftMargin = value;
                        this.RefreshParent();
                    }
                }
            }

            public int LevelSpacing
            {
                get
                {
                    return this.levelSpacing;
                }
                set
                {
                    if (this.levelSpacing != value)
                    {
                        this.levelSpacing = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color LinkColor
            {
                get
                {
                    return this.linkColor;
                }
                set
                {
                    if (this.linkColor != value)
                    {
                        this.linkColor = value;
                        this.RefreshParent();
                    }
                }
            }

            [DefaultValue(300)]
            public int MaxEditBoxSize
            {
                get
                {
                    return this.maxEditBoxSize;
                }
                set
                {
                    if (this.maxEditBoxSize != value)
                    {
                        this.maxEditBoxSize = value;
                        this.RefreshParent();
                    }
                }
            }

            [DefaultValue(100)]
            public int MinEditBoxSize
            {
                get
                {
                    return this.minEditBoxSize;
                }
                set
                {
                    if (this.minEditBoxSize != value)
                    {
                        this.minEditBoxSize = value;
                        this.RefreshParent();
                    }
                }
            }

            public Color ReadOnlyColor
            {
                get
                {
                    return this.readOnlyColor;
                }
                set
                {
                    if (this.readOnlyColor != value)
                    {
                        this.readOnlyColor = value;
                        this.RefreshParent();
                    }
                }
            }

            public bool RowCheckBoxes
            {
                get
                {
                    return this.rowCheckBoxes;
                }
                set
                {
                    if (this.rowCheckBoxes != value)
                    {
                        this.rowCheckBoxes = value;
                        this.RefreshParent();
                    }
                }
            }

            public int RowHeight
            {
                get
                {
                    return this.rowHeight;
                }
                set
                {
                    if (this.rowHeight != value)
                    {
                        this.rowHeight = value;
                        this.RefreshParent();
                    }
                }
            }

            [DefaultValue("")]
            public string TimeFormat
            {
                get
                {
                    return this.timeFormat;
                }
                set
                {
                    if (this.timeFormat != value)
                    {
                        this.timeFormat = value;
                        this.RefreshParent();
                    }
                }
            }

            public bool TuneElementSizes
            {
                get
                {
                    return this.tuneElementSizes;
                }
                set
                {
                    if (this.tuneElementSizes != value)
                    {
                        this.tuneElementSizes = value;
                        this.parent.Refresh();
                    }
                }
            }
        }
    }
}

