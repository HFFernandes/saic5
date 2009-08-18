namespace Korzh.EasyQuery.WinControls
{
    using Korzh.EasyQuery;
    using Korzh.WinControls.XControls;
    using System;

    public class CreateValueElementEventArgs : EventArgs
    {
        private Korzh.EasyQuery.WinControls.QueryPanel.ConditionRow conditionRow;
        private Korzh.EasyQuery.DataType dataType;
        private XElement element;

        public CreateValueElementEventArgs(Korzh.EasyQuery.WinControls.QueryPanel.ConditionRow conditionRow, Korzh.EasyQuery.DataType dataType)
        {
            this.conditionRow = conditionRow;
            this.dataType = dataType;
            this.Element = null;
        }

        public Korzh.EasyQuery.WinControls.QueryPanel.ConditionRow ConditionRow
        {
            get
            {
                return this.conditionRow;
            }
            set
            {
                this.conditionRow = value;
            }
        }

        public Korzh.EasyQuery.DataType DataType
        {
            get
            {
                return this.dataType;
            }
            set
            {
                this.dataType = value;
            }
        }

        public XElement Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }
    }
}

