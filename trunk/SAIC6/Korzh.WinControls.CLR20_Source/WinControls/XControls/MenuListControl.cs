namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class MenuListControl : Korzh.WinControls.XControls.ListControl
    {
        private bool disposed;
        private bool fMenuClicked;
        protected ContextMenu menuControl = new ContextMenu();

        protected override void Dispose(bool disposing)
        {
            if ((!this.disposed && disposing) && (this.menuControl != null))
            {
                this.menuControl.Dispose();
            }
            this.disposed = true;
        }

        private void FillMenuItem(Menu.MenuItemCollection menuItems, ValueItemList items)
        {
            foreach (ValueItem item in items)
            {
                ListMenuItem item2 = new ListMenuItem(item);
                item2.Click += new EventHandler(this.MenuItemClickHandler);
                menuItems.Add(item2);
                item2.Enabled = item.Enabled;
                this.FillMenuItem(item2.MenuItems, item.SubItems);
            }
        }

        public override void Hide()
        {
            base.Hide();
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            this.fMenuClicked = true;
            base.selectedItem = ((ListMenuItem) sender).Item;
            if (base.parentElement != null)
            {
                base.parentElement.DoInputAccepted();
            }
        }

        public override void RefillItems(ValueItemList items)
        {
            this.menuControl.MenuItems.Clear();
            this.FillMenuItem(this.menuControl.MenuItems, items);
        }

        public override void Show(ListXElement parentElement, Point position)
        {
            base.Show(parentElement, position);
            this.fMenuClicked = false;
            this.menuControl.Show(parentElement.ElementControl, position);
            Application.DoEvents();
            if (!this.fMenuClicked && (parentElement != null))
            {
                parentElement.DoInputCanceled();
            }
        }

        public class ListMenuItem : MenuItem
        {
            private ValueItem item;

            public ListMenuItem(ValueItem item) : base(item.Text)
            {
                this.item = item;
            }

            public ValueItem Item
            {
                get
                {
                    return this.item;
                }
                set
                {
                    this.item = value;
                }
            }
        }
    }
}

