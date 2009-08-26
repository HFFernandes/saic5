namespace Korzh.EasyQuery.WebControls
{
    using System;

    public class ValueRequestEventArgs : EventArgs
    {
        private string data = "";
        private string fvalue;
        private string text;

        public ValueRequestEventArgs(string value, string text, string data)
        {
            this.fvalue = value;
            this.text = text;
            this.data = data;
        }

        public string Data
        {
            get { return this.data; }
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string Value
        {
            get { return this.fvalue; }
            set { this.fvalue = value; }
        }
    }
}