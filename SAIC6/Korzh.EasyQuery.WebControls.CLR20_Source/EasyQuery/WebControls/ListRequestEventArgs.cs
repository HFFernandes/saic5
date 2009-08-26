namespace Korzh.EasyQuery.WebControls
{
    using Korzh.WebControls.XControls;
    using System;

    public class ListRequestEventArgs : EventArgs
    {
        private ValueItemList listItems;
        private string listName;
        private XElement sourceElement;

        public ListRequestEventArgs(XElement sourceElement, string listName, ValueItemList listItems)
        {
            this.sourceElement = sourceElement;
            this.listName = listName;
            this.listItems = listItems;
            if (listItems == null)
            {
                throw new Exception("listItems parameter can not be null");
            }
        }

        public ValueItemList ListItems
        {
            get { return this.listItems; }
            set { this.listItems = value; }
        }

        public string ListName
        {
            get { return this.listName; }
        }

        public XElement SourceElement
        {
            get { return this.sourceElement; }
        }
    }
}