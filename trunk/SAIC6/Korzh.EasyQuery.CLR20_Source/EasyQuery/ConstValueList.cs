namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ConstValueList : ArrayList
    {
        public int Add(string id, string text)
        {
            ConstValueItem item = new ConstValueItem();
            item.ID = id;
            item.Text = text;
            return this.Add(item);
        }

        public ConstValueItem this[int index]
        {
            get
            {
                return (ConstValueItem) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

