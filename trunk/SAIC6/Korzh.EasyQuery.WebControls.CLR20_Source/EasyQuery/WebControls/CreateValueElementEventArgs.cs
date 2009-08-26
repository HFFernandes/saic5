namespace Korzh.EasyQuery.WebControls
{
    using Korzh.EasyQuery;
    using Korzh.WebControls.XControls;
    using System;

    public class CreateValueElementEventArgs : EventArgs
    {
        private Korzh.EasyQuery.WebControls.QueryPanel.ConditionRow conditionRow;
        private Korzh.EasyQuery.DataType dataType;
        private XElement element;

        public CreateValueElementEventArgs(Korzh.EasyQuery.WebControls.QueryPanel.ConditionRow conditionRow,
                                           Korzh.EasyQuery.DataType dataType)
        {
            this.conditionRow = conditionRow;
            this.dataType = dataType;
            this.Element = null;
        }

        public Korzh.EasyQuery.WebControls.QueryPanel.ConditionRow ConditionRow
        {
            get { return this.conditionRow; }
            set { this.conditionRow = value; }
        }

        public Korzh.EasyQuery.DataType DataType
        {
            get { return this.dataType; }
            set { this.dataType = value; }
        }

        public XElement Element
        {
            get { return this.element; }
            set { this.element = value; }
        }
    }
}