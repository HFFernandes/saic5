namespace Korzh.EasyQuery.DataGates
{
    using Korzh.EasyQuery;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class SqlClientGate : DbGate
    {
        private SqlConnection connection = new SqlConnection();
        private static Hashtable typeMap = new Hashtable();

        static SqlClientGate()
        {
            typeMap.Add("bigint", DataType.Int64);
            typeMap.Add("numeric", DataType.Int);
            typeMap.Add("bit", DataType.Bool);
            typeMap.Add("smallint", DataType.Word);
            typeMap.Add("decimal", DataType.Currency);
            typeMap.Add("smallmoney", DataType.Currency);
            typeMap.Add("int", DataType.Int);
            typeMap.Add("tinyint", DataType.Word);
            typeMap.Add("money", DataType.Currency);
            typeMap.Add("float", DataType.Float);
            typeMap.Add("real", DataType.Float);
            typeMap.Add("date", DataType.Date);
            typeMap.Add("datetimeoffset", DataType.Int);
            typeMap.Add("datetime", DataType.DateTime);
            typeMap.Add("datetime2", DataType.DateTime);
            typeMap.Add("smalldatetime", DataType.DateTime);
            typeMap.Add("timestamp", DataType.DateTime);
            typeMap.Add("time", DataType.Time);
            typeMap.Add("char", DataType.String);
            typeMap.Add("varchar", DataType.String);
            typeMap.Add("text", DataType.Memo);
            typeMap.Add("nchar", DataType.WideString);
            typeMap.Add("nvarchar", DataType.WideString);
            typeMap.Add("ntext", DataType.Memo);
            typeMap.Add("binary", DataType.Blob);
            typeMap.Add("varbinary", DataType.Blob);
        }

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
            this.CheckConnection();
            foreach (DataRow row in this.connection.GetSchema(SqlClientMetaDataCollectionNames.Databases).Rows)
            {
                object obj2 = row["DATABASE_NAME"];
                if (obj2 != null)
                {
                    databases.Add(new DbInfo(obj2.ToString()));
                }
            }
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
            foreach (DataRow row in this.connection.GetSchema(SqlClientMetaDataCollectionNames.Columns, restrictionValues).Rows)
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
                        info.FieldType = this.GetDataTypeBySqlType(str);
                    }
                }
                fields.Add(info);
            }
        }

        protected override void CoreGetLinks(string dbName, string schemaName, DbLinkInfoList links)
        {
            links.Clear();
            this.CheckConnection();
            StringBuilder builder = new StringBuilder();
            if ((schemaName != null) && (schemaName != ""))
            {
                builder.Append("sch.name = '" + schemaName + "'");
            }
            string str = "SELECT f.name AS FK_NAME, sch.name AS SCHEMA_NAME,\r\n                OBJECT_NAME(f.parent_object_id) AS FK_TABLE_NAME,\r\n                COL_NAME(fc.parent_object_id,\r\n                fc.parent_column_id) AS FK_COLUMN_NAME,\r\n                OBJECT_NAME (f.referenced_object_id) AS PK_TABLE_NAME,\r\n                COL_NAME(fc.referenced_object_id,\r\n                fc.referenced_column_id) AS PK_COLUMN_NAME\r\n                FROM sys.foreign_keys AS f\r\n                INNER JOIN sys.foreign_key_columns AS fc\r\n                ON f.OBJECT_ID = fc.constraint_object_id\r\n                INNER JOIN sys.schemas AS sch ON sch.schema_id = f.schema_id";
            if (builder.Length > 0)
            {
                str = str + " WHERE " + builder.ToString();
            }
            SqlCommand command = this.connection.CreateCommand();
            command.CommandText = str;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string str2 = reader["PK_TABLE_NAME"].ToString();
                string str3 = reader["PK_COLUMN_NAME"].ToString();
                string str4 = reader["FK_TABLE_NAME"].ToString();
                string str5 = reader["FK_COLUMN_NAME"].ToString();
                if (!(str2 == str4) && (links.FindByTableNames(str2, str4) == null))
                {
                    links.Add(new DbLinkInfo(str2, str4, str3, str5));
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
            foreach (DataRow row in this.connection.GetSchema(SqlClientMetaDataCollectionNames.Tables, restrictionValues).Rows)
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
                    case "BASE TABLE":
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

        private DataType GetDataTypeBySqlType(string sqlType)
        {
            object obj2 = typeMap[sqlType];
            if (obj2 == null)
            {
                return DataType.Unknown;
            }
            return (DataType) obj2;
        }

        public override string GetName()
        {
            return "MS SQL Server (native)";
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

        public SqlConnection Connection
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

