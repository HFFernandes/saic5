namespace Korzh.EasyQuery.WinControls
{
    using Korzh.EasyQuery;
    using Korzh.WinControls.XControls;
    using System;
    using System.Collections;

    public class ColumnRow : XRow
    {
        protected ColumnButton button;
        protected internal ValueItemList colButtonMenuList;
        protected Korzh.EasyQuery.Query.Column column;
        internal static Hashtable Creators = new Hashtable();
        protected internal QueryColumnsPanel parentPanel;
        private bool refreshing;
        internal ValueItemList sortMenuList;

        public ColumnRow(QueryColumnsPanel aPanel, Korzh.EasyQuery.Query.Column column, bool useCheckBox) : base(useCheckBox)
        {
            this.colButtonMenuList = new ValueItemList();
            this.sortMenuList = new ValueItemList();
            this.parentPanel = aPanel;
            this.SetColumn(column);
            this.button = new ColumnButton();
            this.FillButtonMenu();
            base.Elements.Add(this.button);
        }

        protected virtual void AddCommonElements()
        {
        }

        protected virtual void AttachEvents()
        {
            this.column.ColumnChanged += new EventHandler(this.DoColumnChanged);
        }

        protected override void CoreDetach()
        {
            base.CoreDetach();
            this.DetachEvents();
        }

        internal virtual void CoreRefreshByColumn()
        {
        }

        public static ColumnRow Create(QueryColumnsPanel panel, string type, Korzh.EasyQuery.Query.Column column, bool useCheckBox)
        {
            IDictionaryEnumerator enumerator = Creators.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (type == ((string) enumerator.Key))
                {
                    IColumnRowCreator creator = (IColumnRowCreator) enumerator.Value;
                    return creator.Create(panel, column, useCheckBox);
                }
            }
            return null;
        }

        protected virtual void DetachEvents()
        {
            this.column.ColumnChanged -= new EventHandler(this.DoColumnChanged);
        }

        protected void DoColumnChanged(object sender, EventArgs e)
        {
            this.RefreshByColumn();
        }

        protected virtual void FillButtonMenu()
        {
            this.button.Items = this.colButtonMenuList;
        }

        internal void InnerDetach()
        {
            this.CoreDetach();
        }

        internal virtual void RefreshByColumn()
        {
            if (this.column.ExprType != this.TypeName)
            {
                this.parentPanel.RecreateRow(this);
            }
            else
            {
                this.Refreshing = true;
                try
                {
                    this.CoreRefreshByColumn();
                    this.AddCommonElements();
                }
                finally
                {
                    this.Refreshing = false;
                }
            }
        }

        public static bool RegisterType(string type, IColumnRowCreator creator)
        {
            Creators.Add(type, creator);
            return true;
        }

        internal void SetColumn(Korzh.EasyQuery.Query.Column newColumn)
        {
            if (this.column != null)
            {
                this.DetachEvents();
            }
            this.column = newColumn;
            if (this.column != null)
            {
                this.AttachEvents();
            }
        }

        public Korzh.EasyQuery.Query.Column Column
        {
            get
            {
                return this.column;
            }
        }

        protected internal bool Refreshing
        {
            get
            {
                return this.refreshing;
            }
            set
            {
                this.refreshing = value;
            }
        }

        public static string STypeName
        {
            get
            {
                return "";
            }
        }

        public virtual string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        internal protected class ColumnButton : ButtonListXElement
        {
            public ColumnButton() : base("")
            {
            }

            protected override string CoreGetTextAdjustedByValue(string value)
            {
                return this.Text;
            }
        }
    }
}

