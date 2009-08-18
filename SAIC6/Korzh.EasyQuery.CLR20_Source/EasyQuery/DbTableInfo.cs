namespace Korzh.EasyQuery
{
    using System;
    using System.Text;

    public class DbTableInfo
    {
        private string dbName;
        private string name;
        private string schemaName;

        public DbTableInfo(string tableName)
        {
            this.dbName = "";
            this.schemaName = "";
            this.Name = tableName;
        }

        public DbTableInfo(string dbName, string schemaName, string tableName)
        {
            this.dbName = "";
            this.schemaName = "";
            this.dbName = dbName;
            this.schemaName = schemaName;
            this.Name = tableName;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(70);
            if (this.DBName != "")
            {
                builder.Append(this.DBName + ":");
            }
            if (this.SchemaName != "")
            {
                builder.Append(this.SchemaName + ".");
            }
            builder.Append(this.Name);
            return builder.ToString();
        }

        public string DBName
        {
            get
            {
                return this.dbName;
            }
            set
            {
                this.dbName = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string SchemaName
        {
            get
            {
                return this.schemaName;
            }
            set
            {
                this.schemaName = value;
            }
        }
    }
}

