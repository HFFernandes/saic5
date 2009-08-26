namespace Korzh.WebControls.XControls
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class XRowList : ArrayList
    {
        private XPanel listbox;

        public XRowList(XPanel XPanel)
        {
            this.listbox = XPanel;
        }

        public int Add(XRow newrow)
        {
            int index = base.Add(newrow);
            this.OnRowInserted(newrow, index);
            this.listbox.OnRowListChanged();
            return index;
        }

        public override void Clear()
        {
            foreach (XRow row in this)
            {
                row.DetachControl();
            }
            base.Clear();
            this.listbox.OnRowListChanged();
        }

        public void Insert(int index, XRow newrow)
        {
            base.Insert(index, newrow);
            this.OnRowInserted(newrow, index);
            this.listbox.OnRowListChanged();
        }

        public void Move(int currentIndex, int newIndex)
        {
            XRow newrow = this[currentIndex];
            this.RemoveAt(currentIndex);
            this.Insert(newIndex, newrow);
        }

        protected virtual void OnRowInserted(XRow newrow, int index)
        {
            newrow.rowControl.EnableViewState = false;
            this.listbox.PlaceRowAt(newrow, index);
            this.ReassignIDs();
            this.listbox.OnRowAdded(newrow);
        }

        protected virtual void ReassignIDs()
        {
            foreach (XRow row in this)
            {
                row.AssignID();
            }
        }

        public override void RemoveAt(int index)
        {
            this[index].DetachControl();
            base.RemoveAt(index);
            if (this.listbox != null)
            {
                this.listbox.OnRowListChanged();
            }
        }

        public virtual void RemoveAt(int index, bool untilSameLevel)
        {
            int level = this[index].Level;
            this[index].DetachControl();
            base.RemoveAt(index);
            if (untilSameLevel)
            {
                while ((index < this.Count) && (this[index].Level > level))
                {
                    this[index].DetachControl();
                    base.RemoveAt(index);
                }
            }
            this.listbox.OnRowListChanged();
        }

        public XRow this[int index]
        {
            get { return (XRow) base[index]; }
            set { base[index] = value; }
        }
    }
}