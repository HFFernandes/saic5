namespace Korzh.WinControls.XControls
{
    using System;

    public class TextAdjustingEventArgs : EventArgs
    {
        private string ftext;

        public TextAdjustingEventArgs(string text)
        {
            this.ftext = text;
        }

        public string Text
        {
            get
            {
                return this.ftext;
            }
            set
            {
                this.ftext = value;
            }
        }
    }
}

