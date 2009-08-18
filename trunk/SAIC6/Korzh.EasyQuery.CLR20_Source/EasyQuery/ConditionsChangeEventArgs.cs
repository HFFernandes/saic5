namespace Korzh.EasyQuery
{
    using System;

    public class ConditionsChangeEventArgs : EventArgs
    {
        private Korzh.EasyQuery.Query.Condition condition;
        private int info;
        private ChangeType what;

        public ConditionsChangeEventArgs() : this(ChangeType.Total, null, 0)
        {
        }

        public ConditionsChangeEventArgs(ChangeType what, Korzh.EasyQuery.Query.Condition condition) : this(what, condition, 0)
        {
        }

        public ConditionsChangeEventArgs(ChangeType what, Korzh.EasyQuery.Query.Condition condition, int info)
        {
            this.what = what;
            this.condition = condition;
            this.info = info;
        }

        public Korzh.EasyQuery.Query.Condition Condition
        {
            get
            {
                return this.condition;
            }
            set
            {
                this.condition = value;
            }
        }

        public static ConditionsChangeEventArgs Default
        {
            get
            {
                return new ConditionsChangeEventArgs();
            }
        }

        public int Info
        {
            get
            {
                return this.info;
            }
            set
            {
                this.info = value;
            }
        }

        public ChangeType What
        {
            get
            {
                return this.what;
            }
            set
            {
                this.what = value;
            }
        }
    }
}

