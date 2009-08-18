namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class LabelXElement : XElement
    {
        private string actionName;
        private ContextMenu altMenu;
        private bool disposed;
        protected RowLinkLabel linkControl;

        public LabelXElement() : this("")
        {
        }

        public LabelXElement(string subType)
        {
            this.actionName = "";
            this.TextColor = Color.Blue;
            this.linkControl.AutoSize = true;
            this.linkControl.LinkBehavior = LinkBehavior.AlwaysUnderline;
            this.linkControl.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkClickedHandler);
            base.EmptyValueText = "[enter value]";
            base.BasePanel.Controls.Add(this.linkControl);
            this.SubType = subType;
            this.altMenu = new ContextMenu();
        }

        private void AltMenuItemClickHandler(object sender, EventArgs e)
        {
            if (base.parentRow != null)
            {
                base.parentRow.InnerElementAltMenuClick(this, ((MenuListControl.ListMenuItem) sender).Item);
            }
        }

        public override void Arrange(int bottomLine, int rowHeight)
        {
            base.Arrange(bottomLine, rowHeight);
        }

        protected override Control CreateElementControl()
        {
            this.linkControl = new RowLinkLabel(this);
            return this.linkControl;
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    if (this.altMenu != null)
                    {
                        this.altMenu.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
            this.disposed = true;
        }

        public void FillAltMenu(ValueItemList items)
        {
            this.altMenu.MenuItems.Clear();
            this.FillAltMenuItem(this.altMenu.MenuItems, items);
        }

        private void FillAltMenuItem(Menu.MenuItemCollection menuItems, ValueItemList items)
        {
            foreach (ValueItem item in items)
            {
                MenuListControl.ListMenuItem item2 = new MenuListControl.ListMenuItem(item);
                item2.Click += new EventHandler(this.AltMenuItemClickHandler);
                menuItems.Add(item2);
                item2.Enabled = item.Enabled;
                this.FillAltMenuItem(item2.MenuItems, item.SubItems);
            }
        }

        protected virtual void LinkClickedHandler(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!base.ReadOnly)
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    this.OnAltClick(EventArgs.Empty);
                }
                else if ((this.actionName != "") && (base.parentRow != null))
                {
                    base.parentRow.ElementAction(this, this.actionName);
                }
            }
        }

        protected override void OnAltClick(EventArgs e)
        {
            if (this.altMenu.MenuItems.Count > 0)
            {
                this.ShowAltMenu();
            }
            else
            {
                base.OnAltClick(e);
            }
        }

        public override void ParseXmlNode(XmlNode node)
        {
            if (node.Attributes["Value"] != null)
            {
                base.Value = node.Attributes["Value"].Value;
            }
            if (node.Attributes["Action"] != null)
            {
                this.actionName = node.Attributes["Action"].Value;
            }
            if (node.InnerText != "")
            {
                this.Text = node.InnerText;
            }
        }

        protected virtual void ShowAltMenu()
        {
            this.altMenu.Show(this.ElementControl, new Point(0, this.ElementControl.Height));
        }

        public string ActionName
        {
            get
            {
                return this.actionName;
            }
            set
            {
                this.actionName = value;
            }
        }

        public override Control ElementControl
        {
            get
            {
                return this.linkControl;
            }
        }

        public override Color ReadOnlyColor
        {
            get
            {
                return base.ReadOnlyColor;
            }
            set
            {
                base.ReadOnlyColor = value;
                if (base.ReadOnly)
                {
                    this.linkControl.LinkColor = base.ReadOnlyColor;
                }
            }
        }

        public static string TagName
        {
            get
            {
                return "LABEL";
            }
        }

        public override Color TextColor
        {
            get
            {
                return base.TextColor;
            }
            set
            {
                base.TextColor = value;
                this.linkControl.LinkColor = base.TextColor;
            }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new LabelXElement();
            }

            public string TagName
            {
                get
                {
                    return LabelXElement.TagName;
                }
            }
        }

        protected class RowLinkLabel : LinkLabel
        {
            private LabelXElement parentElement;

            public RowLinkLabel(LabelXElement parentElement)
            {
                this.parentElement = parentElement;
                base.SetStyle(ControlStyles.Selectable, true);
            }

            protected override bool IsInputKey(Keys keyData)
            {
                if (((!base.IsInputKey(keyData) && (keyData != Keys.Down)) && ((keyData != Keys.Up) && (keyData != Keys.Left))) && (((keyData != Keys.Right) && (keyData != Keys.Tab)) && ((keyData != (Keys.Shift | Keys.Tab)) && (keyData != (Keys.Control | Keys.Right)))))
                {
                    return (keyData == (Keys.Control | Keys.Left));
                }
                return true;
            }

            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                this.parentElement.Activate();
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                Signals none = Signals.None;
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (!e.Control)
                        {
                            none = Signals.KeyLeft;
                            break;
                        }
                        none = Signals.KeyCtrlLeft;
                        break;

                    case Keys.Up:
                        if (!e.Control)
                        {
                            none = Signals.KeyUp;
                            break;
                        }
                        none = Signals.KeyCtrlUp;
                        break;

                    case Keys.Right:
                        if (!e.Control)
                        {
                            none = Signals.KeyRight;
                            break;
                        }
                        none = Signals.KeyCtrlRight;
                        break;

                    case Keys.Down:
                        if (!e.Control)
                        {
                            none = Signals.KeyDown;
                            break;
                        }
                        none = Signals.KeyCtrlDown;
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
                if ((none != Signals.None) && (this.parentElement.parentRow != null))
                {
                    this.parentElement.parentRow.ElementSignal(this.parentElement, none);
                }
            }

            protected override bool ShowFocusCues
            {
                get
                {
                    return true;
                }
            }
        }
    }
}

