namespace Korzh.EasyQuery
{
    using System;
    using System.Runtime.CompilerServices;

    public class DbGate
    {
        private string connectionString = "";
        private IConnectionStringBuilderDlg connectionStringBuilderDlg;
        protected string finalConnectionString = "";
        private bool loginPrompt;
        private string password = "";
        private string userID = "";

        public event LoginRequestEventHandler LoginRequest;

        protected virtual string AssembleConnectionString()
        {
            string str = Environment.ExpandEnvironmentVariables(this.ConnectionString);
            if (this.loginPrompt && (this.password == ""))
            {
                this.OnLoginRequest();
            }
            string str2 = str.ToLower();
            string uidName = this.GetUidName();
            string pwdName = this.GetPwdName();
            if (str2.IndexOf(uidName) == -1)
            {
                string str5 = str;
                str = str5 + ";" + uidName + "=" + this.UserID;
            }
            if (str2.IndexOf(pwdName) == -1)
            {
                string str6 = str;
                str = str6 + ";" + pwdName + "=" + this.Password;
            }
            return str;
        }

        protected virtual void CoreGetDatabases(DbInfoList databases)
        {
        }

        protected virtual void CoreGetFields(string dbName, string schemaName, string tableName, DbFieldInfoList fields)
        {
        }

        protected virtual void CoreGetLinks(string dbName, string schemaName, DbLinkInfoList links)
        {
        }

        protected virtual void CoreGetTables(string dbName, string schemaName, DbTableInfoList tables)
        {
        }

        protected virtual void CoreLoadParams(DbParameters dbParams)
        {
            this.ConnectionString = dbParams.ConnectionString;
            this.LoginPrompt = dbParams.LoginPrompt;
        }

        protected virtual void CoreSaveParams(DbParameters dbParams)
        {
            dbParams.ConnectionString = this.ConnectionString;
            dbParams.LoginPrompt = this.LoginPrompt;
            dbParams.GateClass = base.GetType().FullName;
        }

        protected virtual bool GetConnected()
        {
            return false;
        }

        public DbInfoList GetDatabases()
        {
            DbInfoList databases = new DbInfoList();
            this.CoreGetDatabases(databases);
            return databases;
        }

        public DbFieldInfoList GetFields(string dbName, string schemaName, string tableName)
        {
            DbFieldInfoList fields = new DbFieldInfoList();
            this.CoreGetFields(dbName, schemaName, tableName, fields);
            return fields;
        }

        public DbLinkInfoList GetLinks(string dbName, string schemaName)
        {
            DbLinkInfoList links = new DbLinkInfoList();
            this.CoreGetLinks(dbName, schemaName, links);
            return links;
        }

        public virtual string GetName()
        {
            return "Abstract DbGate";
        }

        protected virtual string GetPwdName()
        {
            return "Password";
        }

        public DbTableInfoList GetTables(string dbName, string schemaName)
        {
            DbTableInfoList tables = new DbTableInfoList();
            this.CoreGetTables(dbName, schemaName, tables);
            return tables;
        }

        protected virtual string GetUidName()
        {
            return "User ID";
        }

        protected virtual string GetVersion()
        {
            return "";
        }

        public void LoadParams(DbParameters dbParams)
        {
            this.CoreLoadParams(dbParams);
        }

        protected virtual void OnLoginRequest()
        {
            if (this.LoginRequest != null)
            {
                LoginRequestEventArgs e = new LoginRequestEventArgs(this.userID, this.password);
                this.LoginRequest(this, e);
                this.userID = e.UserID;
                this.password = e.Password;
            }
        }

        public void SaveParams(DbParameters dbParams)
        {
            this.CoreSaveParams(dbParams);
        }

        protected virtual void SetConnected(bool connected)
        {
        }

        public override string ToString()
        {
            return this.GetName();
        }

        public bool Connected
        {
            get
            {
                return this.GetConnected();
            }
            set
            {
                if (value != this.GetConnected())
                {
                    this.finalConnectionString = this.AssembleConnectionString();
                    this.SetConnected(value);
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
                if (this.Connected)
                {
                    this.SetConnected(false);
                }
            }
        }

        public IConnectionStringBuilderDlg ConnectionStringBuilderDlg
        {
            get
            {
                return this.connectionStringBuilderDlg;
            }
            set
            {
                this.connectionStringBuilderDlg = value;
            }
        }

        public bool LoginPrompt
        {
            get
            {
                return this.loginPrompt;
            }
            set
            {
                this.loginPrompt = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public string Version
        {
            get
            {
                return this.GetVersion();
            }
        }
    }
}

