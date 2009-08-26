namespace Korzh.WebControls.XControls
{
    using System;

    public class ValidateValueEventArgs : EventArgs
    {
        private bool accept = true;
        private string fvalue;

        public ValidateValueEventArgs(string value, bool accept)
        {
            this.fvalue = value;
            this.Accept = accept;
        }

        public bool Accept
        {
            get { return this.accept; }
            set { this.accept = value; }
        }

        public string Value
        {
            get { return this.fvalue; }
            set { this.fvalue = value; }
        }
    }
}