namespace Korzh.WebControls.XControls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Serializable]
    public class ValueItem
    {
        private string action;
        private string fvalue;
        internal ValueItem parent;
        internal ValueItemList parentList;
        private bool selected;
        private ValueItemList subItems;
        private string text;

        public event EventHandler Changed;

        public ValueItem(string text, string value) : this(text, value, "")
        {
        }

        public ValueItem(string text, string fvalue, string action)
        {
            this.text = text;
            this.fvalue = fvalue;
            this.action = action;
            this.selected = false;
            this.parent = null;
            this.subItems = new ValueItemList("", this);
        }

        internal void ChildChanged()
        {
            this.OnChanged(EventArgs.Empty);
        }

        public ValueItem GetItemByID(string id)
        {
            if (this.ID == id)
            {
                return this;
            }
            return this.SubItems.GetItemByID(id);
        }

        public bool GetItemByValue(string value, out ValueItem item)
        {
            item = null;
            if (this.fvalue == value)
            {
                item = this;
                return true;
            }
            return this.SubItems.GetItemByValue(value, out item);
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (this.parent != null)
            {
                this.parent.OnChanged(e);
            }
            else if (this.Changed != null)
            {
                this.Changed(this, e);
            }
        }

        public override string ToString()
        {
            return this.Text;
        }

        public string Action
        {
            get { return this.action; }
            set
            {
                if (this.action != value)
                {
                    this.action = value;
                    this.OnChanged(EventArgs.Empty);
                }
            }
        }

        public string ID
        {
            get
            {
                if ((this.parent != null) && (this.parent.ID != ""))
                {
                    return (this.parent.ID + "." + this.Index.ToString());
                }
                return this.Index.ToString();
            }
        }

        public int Index
        {
            get
            {
                if (this.parentList == null)
                {
                    return -1;
                }
                return this.parentList.IndexOf(this);
            }
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public ValueItemList SubItems
        {
            get { return this.subItems; }
            set
            {
                if (this.subItems != value)
                {
                    this.subItems = value;
                    this.OnChanged(EventArgs.Empty);
                }
            }
        }

        public string Text
        {
            get { return this.text; }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnChanged(EventArgs.Empty);
                }
            }
        }

        public string Value
        {
            get { return this.fvalue; }
            set
            {
                if (this.fvalue != value)
                {
                    this.fvalue = value;
                    this.OnChanged(EventArgs.Empty);
                }
            }
        }
    }
}