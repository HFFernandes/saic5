namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ListBoxListControl : Korzh.WinControls.XControls.ListControl
    {
        private bool disposed;
        protected ListBox listboxControl;
        private bool multiMode;

        public ListBoxListControl() : this(false)
        {
        }

        public ListBoxListControl(bool multi)
        {
            this.multiMode = multi;
            if (this.multiMode)
            {
                this.listboxControl = new CheckedListBox();
                ((CheckedListBox) this.listboxControl).CheckOnClick = true;
            }
            else
            {
                this.listboxControl = new ListBox();
            }
            this.listboxControl.Visible = false;
            this.listboxControl.Width = 50;
            this.listboxControl.KeyPress += new KeyPressEventHandler(this.LBKeyPressHandler);
            this.listboxControl.LostFocus += new EventHandler(this.LBLostFocusHandler);
            this.listboxControl.SelectedIndexChanged += new EventHandler(this.LBSelectedIndexChangedHandler);
            if (!this.multiMode)
            {
                this.listboxControl.DoubleClick += new EventHandler(this.ListBoxDblClickHandler);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if ((!this.disposed && disposing) && (this.listboxControl != null))
            {
                this.listboxControl.Dispose();
            }
            this.disposed = true;
        }

        private int GetIndexByValue(string value)
        {
            for (int i = 0; i < this.listboxControl.Items.Count; i++)
            {
                if (((ValueItem) this.listboxControl.Items[i]).Value == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public override void Hide()
        {
            this.listboxControl.Hide();
        }

        protected virtual void LBKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r') && (base.parentElement != null))
            {
                base.parentElement.DoInputAccepted();
                base.parentElement.ElementControl.Select();
            }
            if ((e.KeyChar == '\x001b') && (base.parentElement != null))
            {
                base.parentElement.DoInputCanceled();
                base.parentElement.ElementControl.Select();
            }
        }

        protected virtual void LBLostFocusHandler(object sender, EventArgs e)
        {
            if (base.parentElement != null)
            {
                base.parentElement.DoInputAccepted();
            }
        }

        protected virtual void LBSelectedIndexChangedHandler(object sender, EventArgs e)
        {
            if (!this.MultiSelect)
            {
                base.selectedItem = (ValueItem) this.listboxControl.SelectedItem;
            }
        }

        private void ListBoxDblClickHandler(object sender, EventArgs e)
        {
            if (base.parentElement != null)
            {
                base.parentElement.DoInputAccepted();
                base.parentElement.ElementControl.Select();
            }
        }

        public override void RefillItems(ValueItemList items)
        {
            this.listboxControl.Items.Clear();
            this.listboxControl.Width = 50;
            for (int i = 0; i < items.Count; i++)
            {
                int num = XElement.MeasureDisplayStringWidth(this.listboxControl.CreateGraphics(), items[i].Text, this.listboxControl.Font);
                if (this.MultiSelect)
                {
                    num += 0x16;
                }
                if ((num + 0x23) > this.listboxControl.Width)
                {
                    this.listboxControl.Width = num + 0x23;
                }
                this.listboxControl.Items.Add(items[i]);
                this.listboxControl.Height = this.listboxControl.PreferredHeight + 5;
            }
            if (this.listboxControl.PreferredHeight > 180)
            {
                this.listboxControl.Height = 200;
            }
        }

        protected internal override void SelectItems()
        {
            if (this.multiMode)
            {
                ValueItem item = null;
                for (int i = 0; i < this.listboxControl.Items.Count; i++)
                {
                    item = (ValueItem) this.listboxControl.Items[i];
                    ((CheckedListBox) this.listboxControl).SetItemChecked(i, item.Selected);
                }
            }
            else if (base.SelectedItem != null)
            {
                this.listboxControl.SelectedIndex = this.GetIndexByValue(base.SelectedItem.Value);
            }
            else
            {
                this.listboxControl.SelectedIndex = -1;
            }
        }

        public override void Show(ListXElement parentElement, Point position)
        {
            base.Show(parentElement, position);
            Control elementControl = parentElement.ElementControl;
            Control control2 = elementControl.FindForm();
            if (this.listboxControl.Parent == null)
            {
                control2.Controls.Add(this.listboxControl);
            }
            Point point = control2.PointToScreen(new Point(0, 0));
            Point p = parentElement.BasePanel.PointToScreen(position);
            int num = (p.Y - elementControl.Height) - point.Y;
            int num2 = (point.Y + control2.ClientRectangle.Height) - p.Y;
            int num3 = (point.X + control2.ClientRectangle.Width) - p.X;
            if (num2 < this.listboxControl.Height)
            {
                if ((num2 > 100) || (num2 > num))
                {
                    this.listboxControl.Height = num2;
                }
                else if (num > this.listboxControl.Height)
                {
                    p.Y = (p.Y - elementControl.Height) - this.listboxControl.Height;
                }
                else
                {
                    this.listboxControl.Height = num;
                    p.Y = (p.Y - elementControl.Height) - this.listboxControl.Height;
                }
            }
            if (num3 < this.listboxControl.Width)
            {
                this.listboxControl.Width = num3 - 2;
            }
            p = control2.PointToClient(p);
            this.listboxControl.Location = p;
            this.listboxControl.Show();
            this.listboxControl.BringToFront();
            this.listboxControl.Select();
            this.listboxControl.Focus();
        }

        protected internal override void UpdateItemsBySelection(ValueItemList items)
        {
            foreach (ValueItem item in items)
            {
                item.Selected = false;
            }
            base.selectedItem = null;
            if (this.multiMode)
            {
                ValueItem item2 = null;
                for (int i = 0; i < this.listboxControl.Items.Count; i++)
                {
                    item2 = (ValueItem) this.listboxControl.Items[i];
                    item2.Selected = ((CheckedListBox) this.listboxControl).GetItemChecked(i);
                }
            }
            else
            {
                base.selectedItem = (ValueItem) this.listboxControl.SelectedItem;
            }
        }

        public override bool MultiSelect
        {
            get
            {
                return this.multiMode;
            }
        }

        public override bool Visible
        {
            get
            {
                return this.listboxControl.Visible;
            }
        }
    }
}

