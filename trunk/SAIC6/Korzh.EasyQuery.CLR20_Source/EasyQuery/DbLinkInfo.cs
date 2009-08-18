namespace Korzh.EasyQuery
{
    using System;

    public class DbLinkInfo
    {
        private string field1Name;
        private string field2Name;
        private string table1Name;
        private string table2Name;

        public DbLinkInfo(string table1, string table2, string field1, string field2)
        {
            this.table1Name = table1;
            this.table2Name = table2;
            this.field1Name = field1;
            this.field2Name = field2;
        }

        public string Field1Name
        {
            get
            {
                return this.field1Name;
            }
            set
            {
                this.field1Name = value;
            }
        }

        public string Field2Name
        {
            get
            {
                return this.field2Name;
            }
            set
            {
                this.field2Name = value;
            }
        }

        public string Table1Name
        {
            get
            {
                return this.table1Name;
            }
            set
            {
                this.table1Name = value;
            }
        }

        public string Table2Name
        {
            get
            {
                return this.table2Name;
            }
            set
            {
                this.table2Name = value;
            }
        }
    }
}

