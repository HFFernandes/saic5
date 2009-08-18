namespace Korzh.WinControls.XControls
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class XRowList : ArrayList
    {
        private XPanel parentPanel;

        public XRowList(XPanel parentPanel)
        {
            this.parentPanel = parentPanel;
        }

        public int Add(XRow newrow)
        {
            int index = base.Add(newrow);
            this.OnRowInserted(newrow, index);
            this.parentPanel.InnerRowListChanged();
            return index;
        }

        public void Arrange()
        {
            this.Arrange(0);
        }

        public void Arrange(int startIndex)
        {
            for (int i = startIndex; i < this.Count; i++)
            {
                this[i].ArrangeRow();
            }
        }

        public override void Clear()
        {
            foreach (XRow row in this)
            {
                row.InnerDetach();
                row.Dispose();
            }
            base.Clear();
            if (this.parentPanel != null)
            {
                this.parentPanel.activeRowBeforeUpdate = null;
            }
            this.parentPanel.InnerRowListChanged();
        }

        public void Insert(int index, XRow newrow)
        {
            base.Insert(index, newrow);
            this.OnRowInserted(newrow, index);
            this.Arrange(index + 1);
            this.parentPanel.InnerRowListChanged();
        }

        public void Move(int index1, int index2)
        {
            if (index1 > index2)
            {
                XRow newrow = this[index1];
                this.RemoveAt(index1);
                this.Insert(index2, newrow);
            }
            else
            {
                XRow row2 = this[index2];
                this.RemoveAt(index2);
                this.Insert(index1, row2);
            }
        }

        protected virtual void OnRowInserted(XRow row, int index)
        {
            this.parentPanel.InnerPlaceRow(row);
            this.parentPanel.InnerRowAdded(row);
            if (this.Count == 1)
            {
                row.SelectNextControl(-1, true, false);
            }
        }

        public override void RemoveAt(int index)
        {
            XRow row = this[index];
            bool active = row.Active;
            row.InnerDetach();
            base.RemoveAt(index);
            this.Arrange(index);
            if (this.parentPanel != null)
            {
                if (row == this.parentPanel.activeRowBeforeUpdate)
                {
                    this.parentPanel.activeRowBeforeUpdate = null;
                }
                if (this.parentPanel.ActiveRow != null)
                {
                    this.parentPanel.ActiveRow.rowControl.Invalidate();
                    this.parentPanel.ActiveRow.SelectNextControl(-1, true, false);
                }
                if (active)
                {
                    this.parentPanel.CheckActiveRowIndex();
                    this.parentPanel.UpdateActiveRow(null);
                }
                this.parentPanel.InnerRowListChanged();
            }
            row.Dispose();
            row = null;
        }

        public virtual void RemoveAt(int index, bool untilSameLevel)
        {
            XRow row = this[index];
            bool active = row.Active;
            int level = row.Level;
            row.InnerDetach();
            if ((this.parentPanel != null) && (row == this.parentPanel.activeRowBeforeUpdate))
            {
                this.parentPanel.activeRowBeforeUpdate = null;
            }
            if (untilSameLevel)
            {
                int num2 = index + 1;
                while ((num2 < this.Count) && (this[num2].Level > level))
                {
                    num2++;
                }
                for (int i = num2 - 1; i > index; i--)
                {
                    this[i].InnerDetach();
                    if ((this.parentPanel != null) && (this[i] == this.parentPanel.activeRowBeforeUpdate))
                    {
                        this.parentPanel.activeRowBeforeUpdate = null;
                    }
                    this[i].Dispose();
                    base.RemoveAt(i);
                }
            }
            base.RemoveAt(index);
            if (active)
            {
                this.parentPanel.CheckActiveRowIndex();
                this.parentPanel.UpdateActiveRow(null);
            }
            this.Arrange(index);
            this.parentPanel.InnerRowListChanged();
            row.Dispose();
            row = null;
        }

        public XRow this[int index]
        {
            get
            {
                return (XRow) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

