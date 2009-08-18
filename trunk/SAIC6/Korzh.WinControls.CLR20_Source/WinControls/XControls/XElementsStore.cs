namespace Korzh.WinControls.XControls
{
    using System;

    public class XElementsStore : XElementList
    {
        private XRow row;

        public XElementsStore(XRow row)
        {
            this.row = row;
        }

        public override int Add(object value)
        {
            int index = base.Add(value);
            this.row.ProcessNewElement((XElement) value, index);
            return index;
        }

        public override void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                base[i].Detach();
                base[i].Dispose();
                this.row.InnerDetachElement(base[i]);
            }
            base.Clear();
        }

        public override void Insert(int index, object value)
        {
            base.Insert(index, value);
            this.row.ProcessNewElement((XElement) value, index);
        }

        public override void Remove(object obj)
        {
            base.Remove(obj);
        }

        public override void RemoveAt(int index)
        {
            base[index].Detach();
            base[index].Dispose();
            this.row.InnerDetachElement(base[index]);
            base.RemoveAt(index);
        }
    }
}

