namespace Korzh.EasyQuery.WinControls
{
    using Korzh.EasyQuery;
    using Korzh.WinControls.XControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxItem(true), ToolboxBitmap(typeof(SortColumnsPanel))]
    public class SortColumnsPanel : QueryColumnsPanel
    {
        private bool allowAddRow = true;

        protected override void AddRowByColumn(Query.Column column)
        {
            ColumnRow newrow = new SimpleSortingRow(this, column, "", false);
            newrow.RefreshByColumn();
            int num = base.Rows.Add(newrow);
            if (!base.Updating)
            {
                base.ActiveRowIndex = num;
            }
        }

        public void Clear()
        {
            if (base.addRow != null)
            {
                base.addRow.InnerDetach();
            }
            if (base.addRow == null)
            {
                base.addRow = new QueryColumnsPanel.AdditionRow(this);
                base.Controls.Add(base.addRow.RowControl);
            }
            base.addRow.ApplyFormats();
            base.Rows.Clear();
            this.Arrange();
        }

        protected override void ColumnsChangedHandler(object sender, ColumnsChangeEventArgs e)
        {
        }

        protected override void CoreAddSimpleColumn(DataModel.EntityAttr attr)
        {
            base.justSortedColumns.BeginUpdate();
            try
            {
                Query.Column column = new Query.Column();
                if (attr != null)
                {
                    column.Expr = new EntityAttrExpr(base.Model, attr);
                    column.Caption = attr.Caption;
                    column.Sorting = SortDirection.Ascending;
                    base.justSortedColumns.Add(column);
                }
            }
            finally
            {
                base.justSortedColumns.EndUpdate();
            }
        }

        protected override void CoreFillEntityTree(ValueItemList items, DataModel.Entity parentEntity)
        {
            foreach (DataModel.Entity entity in parentEntity.SubEntities)
            {
                ValueItem item = new ValueItem(entity.Name, entity.Name, "");
                this.CoreFillEntityTree(item.SubItems, entity);
                if (item.SubItems.Count > 0)
                {
                    items.Add(item);
                }
            }
            foreach (DataModel.EntityAttr attr in parentEntity.Attributes)
            {
                if (attr.UseInResult && attr.UseInSorting)
                {
                    items.Add(attr.Caption, attr.ID);
                }
            }
        }

        protected override XPanel.XAppearance CreateAppearance()
        {
            return new SCPAppearance(this);
        }

        protected override void DoAction(object sender, string actionName, object data)
        {
            base.CheckQuery();
            if ((base.ActiveRow != null) && (sender is ColumnRow.ColumnButton))
            {
                SimpleSortingRow parentRow = (SimpleSortingRow) ((ColumnRow.ColumnButton) sender).ParentRow;
                if (string.Compare(actionName, "Ascending", true) == 0)
                {
                    base.BeginUpdate();
                    parentRow.Column.Sorting = SortDirection.Ascending;
                    base.EndUpdate();
                }
                else if (string.Compare(actionName, "Descending", true) == 0)
                {
                    base.BeginUpdate();
                    parentRow.Column.Sorting = SortDirection.Descending;
                    base.EndUpdate();
                }
                else if (string.Compare(actionName, "DeleteSorting", true) == 0)
                {
                    ((SimpleSortingRow) base.ActiveRow).Column.Sorting = SortDirection.None;
                }
                else
                {
                    base.DoAction(sender, actionName, data);
                }
            }
            else
            {
                base.DoAction(sender, actionName, data);
            }
        }

        public int IndexByColumnRow(XRow row)
        {
            for (int i = 0; i < base.Rows.Count; i++)
            {
                if (((SimpleSortingRow) base.Rows[i]).ColumnRow == row)
                {
                    return i;
                }
            }
            return -1;
        }

        protected override void MoveRow(int index1, int index2)
        {
            base.CheckQuery();
            if (((index1 >= 0) && (index2 >= 0)) && (((index1 < base.Rows.Count) && (index2 < base.Rows.Count)) && (index1 != index2)))
            {
                Query.Column column = null;
                if (base.ActiveRow != null)
                {
                    column = ((ColumnRow) base.ActiveRow).Column;
                }
                base.sortedColumns.Move(index1, index2);
                if (column != null)
                {
                    base.ActiveRowIndex = base.sortedColumns.IndexOf(column);
                }
                this.Refresh();
            }
        }

        public override void RefreshByColumns()
        {
            if (!base.Updating)
            {
                base.CheckQuery();
                int activeRowIndex = base.ActiveRowIndex;
                base.BeginUpdate();
                try
                {
                    for (int i = 0; i < base.sortedColumns.Count; i++)
                    {
                        if (i >= base.Rows.Count)
                        {
                            break;
                        }
                        ((ColumnRow) base.Rows[i]).SetColumn(base.sortedColumns[i]);
                        ((ColumnRow) base.Rows[i]).RefreshByColumn();
                    }
                    if (base.sortedColumns.Count > base.Rows.Count)
                    {
                        for (int j = base.Rows.Count; j < base.sortedColumns.Count; j++)
                        {
                            this.AddRowByColumn(base.sortedColumns[j]);
                        }
                    }
                    else if (base.sortedColumns.Count < base.Rows.Count)
                    {
                        for (int k = base.Rows.Count - 1; k >= base.sortedColumns.Count; k--)
                        {
                            base.Rows.RemoveAt(k);
                        }
                    }
                    if (!this.allowAddRow)
                    {
                        if (base.addRow != null)
                        {
                            base.addRow.InnerDetach();
                        }
                        base.addRow = null;
                    }
                    else if (base.addRow == null)
                    {
                        base.addRow = new QueryColumnsPanel.AdditionRow(this);
                        base.Controls.Add(base.addRow.RowControl);
                        base.addRow.ApplyFormats();
                    }
                }
                finally
                {
                    base.EndUpdate();
                }
                this.Arrange();
                if ((activeRowIndex >= 0) && (activeRowIndex < base.Rows.Count))
                {
                    base.ActiveRowIndex = activeRowIndex;
                }
                else if (base.Rows.Count > 0)
                {
                    base.ActiveRowIndex = 0;
                }
            }
        }

        protected override void SortOrderChangedHander(object sender, SortOrderChangedEventArgs e)
        {
            this.RefreshByColumns();
        }

        [DefaultValue(true), NotifyParentProperty(true), Browsable(true)]
        public bool AllowAddRow
        {
            get
            {
                return this.allowAddRow;
            }
            set
            {
                if (this.allowAddRow != value)
                {
                    this.allowAddRow = value;
                    if (base.Query != null)
                    {
                        this.RefreshByColumns();
                    }
                }
            }
        }

        [Browsable(false), DefaultValue(true)]
        public override bool AllowAggrColumns
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [DefaultValue(true), Browsable(false)]
        public override bool AllowEditCaptions
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [Browsable(false), NotifyParentProperty(false), DefaultValue(true)]
        public override bool AllowSorting
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
        public class SCPAppearance : QueryColumnsPanel.CPAppearance
        {
            public SCPAppearance(QueryColumnsPanel parent) : base(parent)
            {
            }

            [Browsable(false)]
            private QueryColumnsPanel.EditModeKind EditMode
            {
                get
                {
                    return QueryColumnsPanel.EditModeKind.All;
                }
            }
        }

        public class SimpleSortingRow : Korzh.EasyQuery.WinControls.ColumnRow
        {
            internal ListXElement attrElement;
            internal TextXElement colonElement;
            private Korzh.EasyQuery.WinControls.ColumnRow columnRow;
            internal ListXElement sortElement;
            internal TextXElement titleElement;

            public SimpleSortingRow(SortColumnsPanel aPanel, Query.Column aColumn, string xmlText, bool useCheckBox) : base(aPanel, aColumn, useCheckBox)
            {
                base.button.Items = null;
                base.colButtonMenuList.Clear();
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdAscending"), "", "Ascending");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdDescending"), "", "Descending");
                base.colButtonMenuList.Add("-", "");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveTop"), "", "MoveRowTop");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveUp"), "", "MoveRowUp");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveDown"), "", "MoveRowDown");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveBottom"), "", "MoveRowBottom");
                base.colButtonMenuList.Add("-", "");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdDeleteSorting"), "", "DeleteSorting");
                this.FillButtonMenu();
                base.sortMenuList.Clear();
                base.sortMenuList.Add(base.parentPanel.Texts.Get("CmdAscending"), SortDirection.Ascending.ToString());
                base.sortMenuList.Add(base.parentPanel.Texts.Get("CmdDescending"), SortDirection.Descending.ToString());
            }

            protected internal virtual void AttrElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && (this.attrElement == ((XElement) sender)))
                {
                    if (e.ValueChanged)
                    {
                        base.column.Expr.Value = this.attrElement.Value;
                    }
                    if (e.TextChanged)
                    {
                        base.Refreshing = true;
                        base.column.Expr.Text = this.attrElement.Text;
                        base.Refreshing = false;
                    }
                }
            }

            protected virtual void AttrElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                EntityAttrExpr expr = (EntityAttrExpr) base.column.Expr;
                DataModel.EntityAttr attribute = expr.Attribute;
                if (base.parentPanel.Appearance.AttrElementFormat != string.Empty)
                {
                    e.Text = base.parentPanel.Appearance.AttrElementFormat.Replace("{attr}", attribute.Caption).Replace("{entity}", attribute.Entity.GetFullName("."));
                }
                else
                {
                    e.Text = attribute.Caption;
                }
                base.parentPanel.PanelToolTip.SetToolTip(((XElement) sender).ElementControl, attribute.Description);
            }

            internal override void CoreRefreshByColumn()
            {
                if (((SortColumnsPanel) base.parentPanel).columns.IndexOf(base.Column) >= 0)
                {
                    if (this.attrElement != null)
                    {
                        base.Elements.Remove(this.attrElement);
                        this.attrElement = null;
                    }
                    if (this.titleElement == null)
                    {
                        this.titleElement = new TextXElement();
                        base.Elements.Insert(1, this.titleElement);
                    }
                    if (base.column.Caption != "")
                    {
                        this.titleElement.Value = base.column.Caption;
                    }
                    else
                    {
                        this.titleElement.Value = ((EntityAttrExpr) base.column.Expr).Attribute.Caption;
                    }
                }
                else
                {
                    if (this.titleElement != null)
                    {
                        base.Elements.Remove(this.titleElement);
                        this.titleElement = null;
                    }
                    if (this.attrElement == null)
                    {
                        this.attrElement = new ListXElement();
                        base.parentPanel.FillElementByEntityTree(this.attrElement);
                        this.attrElement.ContentChanged += new ContentChangedEventHandler(this.AttrElementContentChanged);
                        this.attrElement.TextAdjusting += new TextAdjustingEventHandler(this.AttrElementTextAdjusting);
                        base.Elements.Insert(1, this.attrElement);
                    }
                    EntityAttrExpr expr = (EntityAttrExpr) base.column.Expr;
                    this.attrElement.Data = expr;
                    DataModel.EntityAttr attribute = expr.Attribute;
                    this.attrElement.Value = attribute.ID;
                }
                if (this.colonElement == null)
                {
                    this.colonElement = new TextXElement(": ");
                    base.Elements.Add(this.colonElement);
                }
                if (this.sortElement == null)
                {
                    this.sortElement = new ListXElement();
                    this.sortElement.Items = base.sortMenuList;
                    this.sortElement.ContentChanged += new ContentChangedEventHandler(this.SortContentChanged);
                    base.Elements.Add(this.sortElement);
                }
                this.sortElement.Value = base.column.Sorting.ToString();
                base.ApplyFormats();
            }

            internal override void RefreshByColumn()
            {
                if (!base.Refreshing)
                {
                    base.Refreshing = true;
                    try
                    {
                        this.CoreRefreshByColumn();
                    }
                    finally
                    {
                        base.Refreshing = false;
                    }
                }
            }

            protected internal virtual void SortContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing)
                {
                    XElement element = (XElement) sender;
                    if (e.ValueChanged)
                    {
                        if (element.Value == SortDirection.Ascending.ToString())
                        {
                            base.column.Sorting = SortDirection.Ascending;
                        }
                        else
                        {
                            base.column.Sorting = SortDirection.Descending;
                        }
                    }
                }
            }

            public Korzh.EasyQuery.WinControls.ColumnRow ColumnRow
            {
                get
                {
                    return this.columnRow;
                }
                set
                {
                    this.columnRow = value;
                }
            }
        }
    }
}

