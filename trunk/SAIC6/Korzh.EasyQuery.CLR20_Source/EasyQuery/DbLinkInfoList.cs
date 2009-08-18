namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DbLinkInfoList : ArrayList
    {
        public DbLinkInfo FindByTableNames(string table1, string table2)
        {
            foreach (DbLinkInfo info in this)
            {
                if (((string.Compare(info.Table1Name, table1, true) != 0) || (string.Compare(info.Table2Name, table2, true) != 0)) && ((string.Compare(info.Table1Name, table2, true) != 0) || (string.Compare(info.Table2Name, table1, true) != 0)))
                {
                    continue;
                }
                return info;
            }
            return null;
        }

        public DbLinkInfo this[int index]
        {
            get
            {
                return (DbLinkInfo) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

