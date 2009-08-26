namespace Korzh.WebControls.XControls
{
    using System;

    public class ActionEventArgs : EventArgs
    {
        private string actionName;
        private object data;

        public ActionEventArgs(string actionName) : this(actionName, "")
        {
        }

        public ActionEventArgs(string actionName, object data)
        {
            this.actionName = actionName;
            this.data = data;
        }

        public string ActionName
        {
            get { return this.actionName; }
        }

        public object Data
        {
            get { return this.data; }
        }
    }
}