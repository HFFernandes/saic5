namespace Korzh.EasyQuery.WebControls
{
    using Korzh.WebControls.XControls;
    using System;

    public class SqlExecuteEventArgs : EventArgs
    {
        private ValueItemList listItems;
        private string sql;

        public SqlExecuteEventArgs(string sql, ValueItemList listItems)
        {
            this.sql = sql;
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

        public string ResultXml
        {
            get { return string.Empty; }
            set { this.ListItems.LoadFromXml(value); }
        }

        public string SQL
        {
            get { return this.sql; }
        }
    }
}