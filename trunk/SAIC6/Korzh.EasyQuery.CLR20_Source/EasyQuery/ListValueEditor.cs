namespace Korzh.EasyQuery
{
    using System;

    public class ListValueEditor : ValueEditor
    {
        private string controlType = "MENU";

        public string ControlType
        {
            get
            {
                return this.controlType;
            }
            set
            {
                this.controlType = value;
            }
        }
    }
}

