namespace Korzh.WinControls.XControls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class ValueItem
    {
        private string action;
        private bool enabled;
        private string fvalue;
        private string hint;
        internal ValueItem parent;
        private bool selected;
        private ValueItemList subItems;
        private string text;
        private int updating;

        public event EventHandler Changed;

        public ValueItem(string text, string value) : this(text, value, "", "")
        {
        }

        public ValueItem(string text, string value, string action) : this(text, value, action, "")
        {
        }

        public ValueItem(string text, string fvalue, string action, string hint)
        {
            this.hint = "";
            this.text = text;
            this.fvalue = fvalue;
            this.action = action;
            this.selected = false;
            this.enabled = true;
            this.parent = null;
            this.subItems = new ValueItemList(this);
        }

        public void BeginUpdate()
        {
            this.updating++;
        }

        internal void ChildChanged()
        {
            this.OnChanged(EventArgs.Empty);
        }

        public void EndUpdate()
        {
            this.updating--;
            if (this.updating == 0)
            {
                this.OnChanged(EventArgs.Empty);
            }
        }

        public bool GetItemByValue(string val, out ValueItem item)
        {
            item = null;
            if (this.fvalue == val)
            {
                item = this;
                return true;
            }
            for (int i = 0; i < this.SubItems.Count; i++)
            {
                if (this.SubItems[i].GetItemByValue(val, out item))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (this.parent != null)
            {
                this.parent.OnChanged(e);
            }
            else if ((this.updating == 0) && (this.Changed != null))
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
            get
            {
                return this.action;
            }
            set
            {
                if (this.action != value)
                {
                    this.action = value;
                    this.OnChanged(EventArgs.Empty);
                }
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;
                }
            }
        }

        public string Hint
        {
            get
            {
                return this.hint;
            }
            set
            {
                this.hint = value;
            }
        }

        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                }
            }
        }

        public ValueItemList SubItems
        {
            get
            {
                return this.subItems;
            }
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
            get
            {
                return this.text;
            }
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
            get
            {
                return this.fvalue;
            }
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

