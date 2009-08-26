namespace Korzh.WebControls.XControls
{
    using System;

    public class ContentChangedEventArgs : EventArgs
    {
        private bool fTextChanged;
        private bool fValueChanged;

        public ContentChangedEventArgs(bool valueChanged, bool textChanged)
        {
            this.fValueChanged = valueChanged;
            this.fTextChanged = textChanged;
        }

        public bool TextChanged
        {
            get { return this.fTextChanged; }
            set { this.fTextChanged = value; }
        }

        public bool ValueChanged
        {
            get { return this.fValueChanged; }
            set { this.fValueChanged = value; }
        }
    }
}