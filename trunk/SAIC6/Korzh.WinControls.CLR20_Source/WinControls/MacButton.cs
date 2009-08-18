namespace Korzh.WinControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    public class MacButton : UserControl
    {
        private Color activeBodyColor;
        private Color activeBorderColor;
        private int borderWidth;
        private Color clickBodyColor;
        private Color clickBorderColor;
        private bool dragging;
        private Color inactiveBodyColor;
        private Color inactiveBorderColor;
        private bool mouseInControl;
        private MState mouseState;
        private bool rounded;
        private int roundRadius;

        public MacButton()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.Selectable, true);
            this.BackColor = Color.Transparent;
            this.activeBorderColor = Color.Black;
            this.activeBodyColor = Color.Gray;
            this.inactiveBorderColor = Color.Black;
            this.inactiveBodyColor = Color.Silver;
            this.clickBorderColor = Color.Black;
            this.clickBodyColor = Color.White;
            this.mouseState = MState.stNotIn;
            this.Cursor = Cursors.Hand;
            this.rounded = true;
            this.roundRadius = -1;
            this.borderWidth = 1;
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.OnTextChanged(EventArgs.Empty);
        }

        private void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(X + radius, Y, (X + width) - (radius * 2f), Y);
            path.AddArc((X + width) - (radius * 2f), Y, radius * 2f, radius * 2f, 270f, 90f);
            path.AddLine((float) (X + width), (float) (Y + radius), (float) (X + width), (float) ((Y + height) - (radius * 2f)));
            path.AddArc((float) ((X + width) - (radius * 2f)), (float) ((Y + height) - (radius * 2f)), (float) (radius * 2f), (float) (radius * 2f), 0f, 90f);
            path.AddLine((float) ((X + width) - (radius * 2f)), (float) (Y + height), (float) (X + radius), (float) (Y + height));
            path.AddArc(X, (Y + height) - (radius * 2f), radius * 2f, radius * 2f, 90f, 90f);
            path.AddLine(X, (Y + height) - (radius * 2f), X, Y + radius);
            path.AddArc(X, Y, radius * 2f, radius * 2f, 180f, 90f);
            path.CloseFigure();
            g.DrawPath(p, path);
            path.Dispose();
        }

        private void FillRoundRect(Graphics g, Brush br, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(X + radius, Y, (X + width) - (radius * 2f), Y);
            path.AddArc((X + width) - (radius * 2f), Y, radius * 2f, radius * 2f, 270f, 90f);
            path.AddLine((float) (X + width), (float) (Y + radius), (float) (X + width), (float) ((Y + height) - (radius * 2f)));
            path.AddArc((float) ((X + width) - (radius * 2f)), (float) ((Y + height) - (radius * 2f)), (float) (radius * 2f), (float) (radius * 2f), 0f, 90f);
            path.AddLine((float) ((X + width) - (radius * 2f)), (float) (Y + height), (float) (X + radius), (float) (Y + height));
            path.AddArc(X, (Y + height) - (radius * 2f), radius * 2f, radius * 2f, 90f, 90f);
            path.AddLine(X, (Y + height) - (radius * 2f), X, Y + radius);
            path.AddArc(X, Y, radius * 2f, radius * 2f, 180f, 90f);
            path.CloseFigure();
            g.FillPath(br, path);
            path.Dispose();
        }

        protected override void OnClick(EventArgs e)
        {
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            if (!this.mouseInControl && base.Enabled)
            {
                this.mouseInControl = true;
                base.Invalidate();
            }
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button == MouseButtons.Left) && base.Enabled)
            {
                this.mouseState = MState.stClick;
                base.Invalidate();
                this.dragging = true;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!this.mouseInControl && base.Enabled)
            {
                this.mouseInControl = true;
                base.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if ((this.mouseInControl && base.Enabled) && !this.dragging)
            {
                this.mouseInControl = false;
            }
            base.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.dragging)
            {
                bool flag = base.ClientRectangle.Contains(e.X, e.Y);
                this.dragging = false;
                this.mouseInControl = false;
                base.Invalidate();
                if (flag)
                {
                    base.OnClick(EventArgs.Empty);
                }
                this.mouseState = MState.stNotIn;
                base.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle clientRectangle = base.ClientRectangle;
            clientRectangle.Location.Offset(1, 1);
            clientRectangle.Width -= 2;
            clientRectangle.Height -= 2;
            SolidBrush br = new SolidBrush(this.InactiveBodyColor);
            Pen p = new Pen(this.InactiveBorderColor, (float) this.borderWidth);
            p.Alignment = PenAlignment.Inset;
            if (this.mouseState != MState.stClick)
            {
                if (this.mouseInControl)
                {
                    this.mouseState = MState.stIn;
                }
                else
                {
                    this.mouseState = MState.stNotIn;
                }
            }
            switch (this.mouseState)
            {
                case MState.stIn:
                    br.Color = this.ActiveBodyColor;
                    p.Color = this.ActiveBorderColor;
                    break;

                case MState.stClick:
                    br.Color = this.ClickBodyColor;
                    p.Color = this.ClickBorderColor;
                    break;
            }
            if (this.rounded)
            {
                float roundRadius = this.roundRadius;
                if (roundRadius < 0f)
                {
                    roundRadius = clientRectangle.Height / 3;
                }
                this.FillRoundRect(g, br, (float) clientRectangle.X, (float) clientRectangle.Y, (float) clientRectangle.Width, (float) clientRectangle.Height, roundRadius);
                this.DrawRoundRect(g, p, (float) clientRectangle.X, (float) clientRectangle.Y, (float) clientRectangle.Width, (float) clientRectangle.Height, roundRadius);
            }
            else
            {
                g.FillRectangle(br, clientRectangle);
                g.DrawRectangle(p, clientRectangle);
            }
            Size size = g.MeasureString(this.Text, this.Font).ToSize();
            int num2 = (clientRectangle.Width - size.Width) / 2;
            int num3 = (clientRectangle.Height - size.Height) / 2;
            SolidBrush brush = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, brush, (float) num2, (float) num3);
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Invalidate();
        }

        public Color ActiveBodyColor
        {
            get
            {
                return this.activeBodyColor;
            }
            set
            {
                this.activeBodyColor = value;
                base.Invalidate();
            }
        }

        public Color ActiveBorderColor
        {
            get
            {
                return this.activeBorderColor;
            }
            set
            {
                this.activeBorderColor = value;
                base.Invalidate();
            }
        }

        public int BorderWidth
        {
            get
            {
                return this.borderWidth;
            }
            set
            {
                if (this.borderWidth != value)
                {
                    this.borderWidth = value;
                    base.Invalidate();
                }
            }
        }

        public Color ClickBodyColor
        {
            get
            {
                return this.clickBodyColor;
            }
            set
            {
                this.clickBodyColor = value;
                base.Invalidate();
            }
        }

        public Color ClickBorderColor
        {
            get
            {
                return this.clickBorderColor;
            }
            set
            {
                this.clickBorderColor = value;
                base.Invalidate();
            }
        }

        public Color InactiveBodyColor
        {
            get
            {
                return this.inactiveBodyColor;
            }
            set
            {
                this.inactiveBodyColor = value;
                base.Invalidate();
            }
        }

        public Color InactiveBorderColor
        {
            get
            {
                return this.inactiveBorderColor;
            }
            set
            {
                this.inactiveBorderColor = value;
                base.Invalidate();
            }
        }

        public bool Rounded
        {
            get
            {
                return this.rounded;
            }
            set
            {
                if (this.rounded != value)
                {
                    this.rounded = value;
                    base.Invalidate();
                }
            }
        }

        public int RoundRadius
        {
            get
            {
                return this.roundRadius;
            }
            set
            {
                if (this.roundRadius != value)
                {
                    this.roundRadius = value;
                    base.Invalidate();
                }
            }
        }

        public enum MState
        {
            stIn,
            stNotIn,
            stClick
        }
    }
}

