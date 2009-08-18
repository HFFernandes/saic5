namespace Korzh.WinControls.XControls
{
    using System;

    public class BeforeRollUpEventArgs : EventArgs
    {
        private bool accept = true;
        private string fvalue;

        public BeforeRollUpEventArgs(string value, bool accept)
        {
            this.fvalue = value;
            this.Accept = accept;
        }

        public bool Accept
        {
            get
            {
                return this.accept;
            }
            set
            {
                this.accept = value;
            }
        }

        public string Value
        {
            get
            {
                return this.fvalue;
            }
            set
            {
                this.fvalue = value;
            }
        }
    }
}

