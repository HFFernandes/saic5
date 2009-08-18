namespace Korzh.WinControls.XControls
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class XElementList : ArrayList
    {
        public XElement FindByData(object data)
        {
            int num = this.IndexByData(data);
            if (num >= 0)
            {
                return this[num];
            }
            return null;
        }

        public int IndexByData(object data)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Data == data)
                {
                    return i;
                }
            }
            return -1;
        }

        public XElement this[int index]
        {
            get
            {
                return (XElement) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

