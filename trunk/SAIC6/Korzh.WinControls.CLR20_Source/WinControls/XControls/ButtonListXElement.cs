namespace Korzh.WinControls.XControls
{
    using Korzh.WinControls;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ButtonListXElement : ListXElement
    {
        protected RowButton buttonControl;

        public ButtonListXElement() : this("")
        {
        }

        public ButtonListXElement(string type) : base(type)
        {
            base.EmptyValueText = "";
            this.buttonControl.BackColor = Color.Transparent;
            this.buttonControl.Click += new EventHandler(this.ButtonClickHandler);
            base.BasePanel.Controls.Add(this.buttonControl);
        }

        public override void Activate()
        {
            base.Activate();
        }

        protected internal override void AdjustSize()
        {
            base.BasePanel.Width = this.ElementControl.Width;
        }

        public override void Arrange(int bottomLine, int rowHeight)
        {
            base.Arrange(bottomLine, rowHeight);
            this.buttonControl.SetBounds(this.buttonControl.Left, 2, (int) ((rowHeight - 4) * 1.3), rowHeight - 4);
            if ((base.ParentRow != null) && (base.ParentRow.Parent != null))
            {
                this.buttonControl.Rounded = base.ParentRow.Parent.Appearance.ButtonRounded;
                this.buttonControl.ActiveBodyColor = base.ParentRow.Parent.Appearance.ButtonActiveBodyColor;
                this.buttonControl.ActiveBorderColor = base.ParentRow.Parent.Appearance.ButtonActiveBorderColor;
                this.buttonControl.InactiveBodyColor = base.ParentRow.Parent.Appearance.ButtonInactiveBodyColor;
                this.buttonControl.InactiveBorderColor = base.ParentRow.Parent.Appearance.ButtonInactiveBorderColor;
                this.buttonControl.ClickBodyColor = base.ParentRow.Parent.Appearance.ButtonClickBodyColor;
                this.buttonControl.ClickBorderColor = base.ParentRow.Parent.Appearance.ButtonClickBorderColor;
                this.buttonControl.ForeColor = base.ParentRow.Parent.Appearance.ButtonForeColor;
            }
            this.buttonControl.Refresh();
        }

        protected virtual void ButtonClickHandler(object sender, EventArgs e)
        {
            if (!base.ReadOnly)
            {
                this.LinkClickedHandler(sender, new LinkLabelLinkClickedEventArgs(null));
            }
        }

        protected override Control CreateElementControl()
        {
            base.CreateElementControl();
            this.buttonControl = new RowButton(this);
            return this.buttonControl;
        }

        public override Control ElementControl
        {
            get
            {
                return this.buttonControl;
            }
        }

        public static string TagName
        {
            get
            {
                return "BUTTONLIST";
            }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new ButtonListXElement();
            }

            public string TagName
            {
                get
                {
                    return ButtonListXElement.TagName;
                }
            }
        }

        protected class RowButton : MacButton
        {
            private Graphics buttonGraphics;
            private ButtonListXElement parentElement;

            public RowButton(ButtonListXElement parentElement)
            {
                this.parentElement = parentElement;
                base.SetStyle(ControlStyles.Selectable, true);
            }

            protected override bool IsInputKey(Keys keyData)
            {
                if ((((!base.IsInputKey(keyData) && (keyData != Keys.Down)) && ((keyData != Keys.Up) && (keyData != Keys.Left))) && (((keyData != Keys.Right) && (keyData != Keys.Tab)) && ((keyData != (Keys.Shift | Keys.Tab)) && (keyData != Keys.Space)))) && (keyData != (Keys.Control | Keys.Right)))
                {
                    return (keyData == (Keys.Control | Keys.Left));
                }
                return true;
            }

            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                this.parentElement.Activate();
                this.Refresh();
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                Signals none = Signals.None;
                switch (e.KeyCode)
                {
                    case Keys.Space:
                    case Keys.Return:
                        this.parentElement.ButtonClickHandler(this, EventArgs.Empty);
                        base.OnKeyDown(e);
                        break;

                    case Keys.Left:
                        if (!e.Control)
                        {
                            none = Signals.KeyLeft;
                        }
                        else
                        {
                            none = Signals.KeyCtrlLeft;
                        }
                        break;

                    case Keys.Up:
                        if (!e.Control)
                        {
                            none = Signals.KeyUp;
                        }
                        else
                        {
                            none = Signals.KeyCtrlUp;
                        }
                        break;

                    case Keys.Right:
                        if (!e.Control)
                        {
                            none = Signals.KeyRight;
                        }
                        else
                        {
                            none = Signals.KeyCtrlRight;
                        }
                        break;

                    case Keys.Down:
                        if (!e.Control)
                        {
                            none = Signals.KeyDown;
                        }
                        else
                        {
                            none = Signals.KeyCtrlDown;
                        }
                        break;

                    case Keys.Tab:
                        if (e.Shift)
                        {
                            none = Signals.KeyShiftTab;
                        }
                        else
                        {
                            none = Signals.KeyTab;
                        }
                        break;

                    default:
                        base.OnKeyDown(e);
                        break;
                }
                if (((none != Signals.None) && !this.parentElement.ReadOnly) && (this.parentElement.parentRow != null))
                {
                    this.parentElement.parentRow.ElementSignal(this.parentElement, none);
                }
            }

            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);
                this.Refresh();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
            }

            protected override void OnResize(EventArgs e)
            {
                if (this.Text == "")
                {
                    base.Width = (int) (base.Height * 1.3);
                }
                else
                {
                    base.Width = XElement.MeasureDisplayStringWidth(this.ButtonGraphics, this.Text, this.Font) + 7;
                }
                base.OnResize(e);
            }

            public override void Refresh()
            {
                base.Refresh();
                if (this.Focused)
                {
                    Rectangle clientRectangle = base.ClientRectangle;
                    clientRectangle.X += 3;
                    clientRectangle.Y += 3;
                    clientRectangle.Width -= 6;
                    clientRectangle.Height -= 6;
                    ControlPaint.DrawFocusRectangle(base.CreateGraphics(), clientRectangle);
                }
            }

            protected internal Graphics ButtonGraphics
            {
                get
                {
                    if (this.buttonGraphics == null)
                    {
                        this.buttonGraphics = base.CreateGraphics();
                    }
                    return this.buttonGraphics;
                }
            }
        }
    }
}

