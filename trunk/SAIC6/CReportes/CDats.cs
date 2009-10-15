using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSD.C4.Tlaxcala.Sai
{
    public class CDats
    {
        private string server, user, password, catalog;
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Catalog
        {
            get { return catalog; }
            set { catalog = value; }
        }
        public CDats()
        {
            server = "";
            user = "";
            password = "";
            catalog = "";
        }
    }
}
