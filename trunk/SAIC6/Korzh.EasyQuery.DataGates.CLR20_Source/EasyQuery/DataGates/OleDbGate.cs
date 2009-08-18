namespace Korzh.EasyQuery.DataGates
{
    using Korzh.EasyQuery;
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class OleDbGate : DbGate
    {
        private const int adBigInt = 20;
        private const int adBinary = 0x80;
        private const int adBoolean = 11;
        private const int adBSTR = 8;
        private const int adChapter = 0x88;
        private const int adChar = 0x81;
        private const int adCurrency = 6;
        private const int adDate = 7;
        private const int adDBDate = 0x85;
        private const int adDBFileTime = 0x89;
        private const int adDBTime = 0x86;
        private const int adDBTimeStamp = 0x87;
        private const int adDecimal = 14;
        private const int adDouble = 5;
        private const int adEmpty = 0;
        private const int adError = 10;
        private const int adFileTime = 0x40;
        private const int adGUID = 0x48;
        private const int adIDispatch = 9;
        private const int adInteger = 3;
        private const int adIUnknown = 13;
        private const int adLongVarBinary = 0xcd;
        private const int adLongVarChar = 0xc9;
        private const int adLongVarWChar = 0xcb;
        private const int adNumeric = 0x83;
        private const int adPropVariant = 0x8a;
        private const int adSingle = 4;
        private const int adSmallInt = 2;
        private const int adTinyInt = 0x10;
        private const int adUnsignedBigInt = 0x15;
        private const int adUnsignedInt = 0x13;
        private const int adUnsignedSmallInt = 0x12;
        private const int adUnsignedTinyInt = 0x11;
        private const int adUserDefined = 0x84;
        private const int adVarBinary = 0xcc;
        private const int adVarChar = 200;
        private const int adVariant = 12;
        private const int adVarNumeric = 0x8b;
        private const int adVarWChar = 0xca;
        private const int adWChar = 130;
        private OleDbConnection connection = new OleDbConnection();

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
            string[] restrictions = new string[4];
            if ((dbName != null) && (dbName != ""))
            {
                restrictions[0] = dbName;
            }
            if ((schemaName != null) && (schemaName != ""))
            {
                restrictions[1] = schemaName;
            }
            restrictions[2] = tableName;
            foreach (DataRow row in this.connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, restrictions).Rows)
            {
                string str;
                DbFieldInfo info = new DbFieldInfo();
                info.Name = (string) row["COLUMN_NAME"];
                object obj2 = row["CHARACTER_MAXIMUM_LENGTH"];
                if (obj2 != null)
                {
                    str = obj2.ToString();
                    if (str != "")
                    {
                        info.Size = int.Parse(str);
                    }
                    if (info.Size > 0xffff)
                    {
                        info.Size = 0;
                    }
                }
                obj2 = row["DATA_TYPE"];
                if (obj2 != null)
                {
                    str = obj2.ToString();
                    if (str != "")
                    {
                        info.FieldType = this.GetDataTypeByAdoType(int.Parse(str));
                    }
                }
                fields.Add(info);
            }
        }

        protected override void CoreGetLinks(string dbName, string schemaName, DbLinkInfoList links)
        {
            links.Clear();
            this.CheckConnection();
            string[] restrictions = new string[5];
            if ((dbName != null) && (dbName != ""))
            {
                restrictions[0] = dbName;
            }
            if ((schemaName != null) && (schemaName != ""))
            {
                restrictions[1] = schemaName;
            }
            foreach (DataRow row in this.connection.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions).Rows)
            {
                string str = (string) row["PK_TABLE_NAME"];
                string str2 = (string) row["PK_COLUMN_NAME"];
                string str3 = (string) row["FK_TABLE_NAME"];
                string str4 = (string) row["FK_COLUMN_NAME"];
                if (!(str == str3) && (links.FindByTableNames(str, str3) == null))
                {
                    links.Add(new DbLinkInfo(str, str3, str2, str4));
                }
            }
        }

        protected override void CoreGetTables(string dbName, string schemaName, DbTableInfoList tables)
        {
            tables.Clear();
            this.CheckConnection();
            foreach (DataRow row in this.connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[0]).Rows)
            {
                string str = "";
                object obj2 = row["TABLE_SCHEMA"];
                if (obj2 != null)
                {
                    str = obj2.ToString();
                }
                string str2 = (string) row["TABLE_TYPE"];
                string tableName = (string) row["TABLE_NAME"];
                switch (str2)
                {
                    case "TABLE":
                    case "VIEW":
                        tables.Add(new DbTableInfo("", str, tableName));
                        break;
                }
            }
        }

        protected override bool GetConnected()
        {
            return (this.connection.State == ConnectionState.Open);
        }

        private DataType GetDataTypeByAdoType(int adoType)
        {
            switch (adoType)
            {
                case 2:
                case 0x10:
                case 0x11:
                case 0x12:
                    return DataType.Word;

                case 3:
                case 0x13:
                    return DataType.Int;

                case 4:
                case 5:
                case 14:
                case 0x83:
                    return DataType.Float;

                case 6:
                    return DataType.Currency;

                case 7:
                case 0x85:
                    return DataType.Date;

                case 8:
                case 130:
                case 0xca:
                    return DataType.WideString;

                case 11:
                    return DataType.Bool;

                case 20:
                case 0x15:
                    return DataType.Int64;

                case 0x80:
                case 0xcc:
                    return DataType.Blob;

                case 0x81:
                case 200:
                    return DataType.String;

                case 0x86:
                    return DataType.Time;

                case 0x87:
                    return DataType.DateTime;

                case 0xc9:
                case 0xcb:
                    return DataType.Memo;
            }
            return DataType.Unknown;
        }

        public override string GetName()
        {
            return "OLE DB";
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

        public OleDbConnection Connection
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

