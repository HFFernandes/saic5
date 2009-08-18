namespace Korzh.EasyQuery
{
    using System;

    public class SortOrderChangedEventArgs : EventArgs
    {
        private Korzh.EasyQuery.Query.Column column;
        private static SortOrderChangedEventArgs defaultEvent = new SortOrderChangedEventArgs();
        private int info;
        private ChangeType what;

        public SortOrderChangedEventArgs() : this(ChangeType.Total, null, 0)
        {
        }

        public SortOrderChangedEventArgs(ChangeType what, Korzh.EasyQuery.Query.Column column) : this(what, column, 0)
        {
        }

        public SortOrderChangedEventArgs(ChangeType what, Korzh.EasyQuery.Query.Column column, int info)
        {
            this.what = what;
            this.column = column;
            this.info = info;
        }

        public Korzh.EasyQuery.Query.Column Column
        {
            get
            {
                return this.column;
            }
            set
            {
                this.column = value;
            }
        }

        public static SortOrderChangedEventArgs Default
        {
            get
            {
                return defaultEvent;
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

