namespace Korzh.WinControls.XControls
{
    using System;

    public class ValidateValueEventArgs : EventArgs
    {
        private bool accept = true;
        private string fvalue;
        private XElement sourceElement;

        public ValidateValueEventArgs(XElement sourceElement, string value, bool accept)
        {
            this.sourceElement = sourceElement;
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

        public XElement SourceElement
        {
            get
            {
                return this.sourceElement;
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

