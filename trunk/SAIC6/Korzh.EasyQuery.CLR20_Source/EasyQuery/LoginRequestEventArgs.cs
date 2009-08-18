namespace Korzh.EasyQuery
{
    using System;

    public class LoginRequestEventArgs : EventArgs
    {
        private string password = "";
        private string userID = "";

        public LoginRequestEventArgs(string userID, string password)
        {
            this.userID = userID;
            this.password = password;
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
    }
}

