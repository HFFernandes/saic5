namespace Korzh.EasyQuery.WinControls
{
    using Korzh.WinControls.XControls;
    using System;

    public class ListRequestEventArgs : EventArgs
    {
        private ValueItemList listItems;
        private string listName;

        public ListRequestEventArgs(string listName, ValueItemList listItems)
        {
            this.listName = listName;
            this.listItems = listItems;
            if (listItems == null)
            {
                throw new Exception("listItems parameter can not be null");
            }
        }

        public ValueItemList ListItems
        {
            get
            {
                return this.listItems;
            }
            set
            {
                this.listItems = value;
            }
        }

        public string ListName
        {
            get
            {
                return this.listName;
            }
        }
    }
}

