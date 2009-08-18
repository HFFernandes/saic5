namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DbFieldInfoList : ArrayList
    {
        public DbFieldInfo this[int index]
        {
            get
            {
                return (DbFieldInfo) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

