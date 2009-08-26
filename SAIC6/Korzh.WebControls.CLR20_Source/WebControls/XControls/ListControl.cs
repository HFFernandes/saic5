namespace Korzh.WebControls.XControls
{
    using System;
    using System.Web.UI;

    public abstract class ListControl
    {
        protected XElement element;
        protected ValueItemList items;
        protected bool listWasChanged;

        public ListControl(ValueItemList items, XElement element)
        {
            this.items = items;
            this.element = element;
        }

        public virtual string GetShowScriptHyperlink()
        {
            if (this.element.Enabled && !this.element.ReadOnly)
            {
                return ("javascript:" + this.GetShowScriptReference());
            }
            return "";
        }

        public virtual string GetShowScriptReference()
        {
            return "#";
        }

        public virtual void ListChanged()
        {
            this.listWasChanged = true;
        }

        public abstract void RefillItems();
        public abstract void Render(Page page);

        public virtual bool Grouped
        {
            get { return false; }
            set { }
        }

        public virtual bool IsInPartialRendering
        {
            get { return false; }
            set { }
        }

        public virtual bool MultiSelect
        {
            get { return false; }
            set { }
        }

        public virtual bool Visible
        {
            get { return false; }
        }
    }
}