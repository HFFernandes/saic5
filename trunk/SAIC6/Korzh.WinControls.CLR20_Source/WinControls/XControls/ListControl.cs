namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;

    public abstract class ListControl
    {
        protected ListXElement parentElement = null;
        protected internal ValueItem selectedItem = null;

        protected virtual void Dispose(bool disposing)
        {
        }

        public virtual void Hide()
        {
            this.parentElement = null;
        }

        public abstract void RefillItems(ValueItemList items);
        protected internal virtual void SelectItems()
        {
        }

        public virtual void Show(ListXElement parentElement, Point position)
        {
            this.parentElement = parentElement;
        }

        protected internal virtual void UpdateItemsBySelection(ValueItemList items)
        {
        }

        public virtual bool MultiSelect
        {
            get
            {
                return false;
            }
        }

        public ValueItem SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
        }

        public virtual bool Visible
        {
            get
            {
                return false;
            }
        }
    }
}

