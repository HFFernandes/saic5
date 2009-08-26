namespace Korzh.WebControls.XControls
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

        public override void Insert(int index, object value)
        {
            base.Insert(index, value);
            this.row.ProcessNewElement((XElement) value, index);
        }

        public override void Remove(object obj)
        {
            ((XElement) obj).Detach();
            base.Remove(obj);
        }

        public override void RemoveAt(int index)
        {
            base[index].Detach();
            base.RemoveAt(index);
        }
    }
}