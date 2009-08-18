namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DbTableInfoList : ArrayList
    {
        public DbTableInfo this[int index]
        {
            get
            {
                return (DbTableInfo) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

