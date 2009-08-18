namespace Korzh.EasyQuery
{
    using System;

    public class ConstValueItem
    {
        private string id;
        private string text;

        public virtual string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public virtual string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
    }
}

