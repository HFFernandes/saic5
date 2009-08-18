namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DbInfoList : ArrayList
    {
        public DbInfo this[int index]
        {
            get
            {
                return (DbInfo) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

