namespace Korzh.EasyQuery.DataGates
{
    using Korzh.EasyQuery;
    using System;
    using System.Data;
    using System.Data.Odbc;

    public class OdbcGate : DbGate
    {
        private OdbcConnection connection = new OdbcConnection();
        private const int SQL_BIGINT = -5;
        private const int SQL_BINARY = -2;
        private const int SQL_BIT = 14;
        private const int SQL_BIT_VARYING = 15;
        private const int SQL_BOOLEAN = 0x10;
        private const int SQL_CHAR = 1;
        private const int SQL_DATETIME = 9;
        private const int SQL_DECIMAL = 3;
        private const int SQL_DOUBLE = 8;
        private const int SQL_FLOAT = 6;
        private const int SQL_GUID = -11;
        private const int SQL_INTEGER = 4;
        private const int SQL_LONGVARBINARY = -4;
        private const int SQL_LONGVARCHAR = -1;
        private const int SQL_NUMERIC = 2;
        private const int SQL_REAL = 7;
        private const int SQL_SMALLINT = 5;
        private const int SQL_TIME = 10;
        private const int SQL_TIMESTAMP = 11;
        private const int SQL_TINYINT = -6;
        private const int SQL_TYPE_DATE = 0x5b;
        private const int SQL_TYPE_TIME = 0x5c;
        private const int SQL_TYPE_TIMESTAMP = 0x5d;
        private const int SQL_VARBINARY = -3;
        private const int SQL_VARCHAR = 12;
        private const int SQL_WCHAR = -8;
        private const int SQL_WLONGVARCHAR = -10;
        private const int SQL_WVARCHAR = -9;

        protected void CheckConnection()
        {
            if (this.connection == null)
            {
                throw new Error("Connection is null");
            }
            base.Connected = true;
        }

        protected override void CoreGetDatabases(DbInfoList databases)
        {
            databases.Clear();
        }

        protected override void CoreGetFields(string dbName, string schemaName, string tableName, DbFieldInfoList fields)
        {
            fields.Clear();
            this.CheckConnection();
            string[] restrictionValues = new string[4];
            if ((dbName != null) && (dbName != ""))
            {
                restrictionValues[0] = dbName;
            }
            if ((schemaName != null) && (schemaName != ""))
            {
                restrictionValues[1] = schemaName;
            }
            restrictionValues[2] = tableName;
            foreach (DataRow row in this.connection.GetSchema("Columns", restrictionValues).Rows)
            {
                string str;
                DbFieldInfo info = new DbFieldInfo();
                info.Name = (string) row["COLUMN_NAME"];
                object obj2 = row["CHAR_OCTET_LENGTH"];
                if (obj2 != null)
                {
                    str = obj2.ToString();
                    if (str != "")
                    {
                        info.Size = int.Parse(str);
                    }
                }
                obj2 = row["DATA_TYPE"];
                if (obj2 != null)
                {
                    str = obj2.ToString();
                    int odbcDataType = 0;
                    if (str != "")
                    {
                        odbcDataType = int.Parse(str);
                    }
                    string typeName = "";
                    obj2 = row["TYPE_NAME"];
                    if (obj2 != null)
                    {
                        typeName = obj2.ToString();
                    }
                    info.FieldType = this.GetDataType(odbcDataType, typeName);
                }
                fields.Add(info);
            }
        }

        protected override void CoreGetLinks(string dbName, string schemaName, DbLinkInfoList links)
        {
            links.Clear();
            this.CheckConnection();
            DataTable table = null;
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    string str = (string) row["PK_TABLE_NAME"];
                    string str2 = (string) row["PK_COLUMN_NAME"];
                    string str3 = (string) row["FK_TABLE_NAME"];
                    string str4 = (string) row["FK_COLUMN_NAME"];
                    links.Add(new DbLinkInfo(str, str3, str2, str4));
                }
            }
        }

        protected override void CoreGetTables(string dbName, string schemaName, DbTableInfoList tables)
        {
            tables.Clear();
            this.CheckConnection();
            string[] restrictionValues = new string[3];
            if ((dbName != null) && (dbName != ""))
            {
                restrictionValues[0] = dbName;
            }
            if ((schemaName != null) && (schemaName != ""))
            {
                restrictionValues[1] = schemaName;
            }
            foreach (DataRow row in this.connection.GetSchema("Tables", restrictionValues).Rows)
            {
                string tableName = (string) row["TABLE_NAME"];
                tables.Add(new DbTableInfo(tableName));
            }
            foreach (DataRow row2 in this.connection.GetSchema("Views", restrictionValues).Rows)
            {
                string str2 = (string) row2["TABLE_NAME"];
                tables.Add(new DbTableInfo(str2));
            }
        }

        protected override bool GetConnected()
        {
            return (this.connection.State == ConnectionState.Open);
        }

        private DataType GetDataType(int odbcDataType, string typeName)
        {
            switch (odbcDataType)
            {
                case -10:
                case -1:
                    return DataType.Memo;

                case -9:
                    return DataType.WideString;

                case -8:
                    if (!typeName.ToLowerInvariant().StartsWith("char"))
                    {
                        return DataType.WideString;
                    }
                    return DataType.String;

                case -6:
                case 5:
                    return DataType.Word;

                case -5:
                    return DataType.Int64;

                case -4:
                case -3:
                case -2:
                    return DataType.Blob;

                case 1:
                case 12:
                    return DataType.String;

                case 2:
                    if (!typeName.ToLowerInvariant().StartsWith("currency"))
                    {
                        return DataType.Float;
                    }
                    return DataType.Currency;

                case 3:
                    return DataType.Currency;

                case 4:
                    return DataType.Int;

                case 6:
                case 7:
                case 8:
                    return DataType.Float;

                case 9:
                case 0x5b:
                    return DataType.Date;

                case 10:
                case 0x5c:
                    return DataType.Time;

                case 11:
                case 0x5d:
                    return DataType.DateTime;

                case 14:
                case 15:
                case 0x10:
                    return DataType.Bool;
            }
            return DataType.Unknown;
        }

        public override string GetName()
        {
            return "ODBC";
        }

        protected override string GetPwdName()
        {
            return "PWD";
        }

        protected override string GetUidName()
        {
            return "UID";
        }

        protected override void SetConnected(bool connected)
        {
            if (connected)
            {
                this.connection.ConnectionString = base.finalConnectionString;
                this.connection.Open();
            }
            else
            {
                this.connection.Close();
            }
        }

        public OdbcConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public class Error : Exception
        {
            public Error(string message) : base(message)
            {
            }
        }
    }
}

