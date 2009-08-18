namespace Korzh.EasyQuery.WinControls
{
    using Korzh.EasyQuery;
    using Korzh.WinControls.XControls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(QueryColumnsPanel))]
    public class QueryColumnsPanel : XPanel
    {
        private bool active;
        internal AdditionRow addRow;
        private bool allowAggrColumns = true;
        private bool allowEditCaptions = true;
        private bool allowSorting = true;
        internal Korzh.EasyQuery.Query.ColumnsStore columns;
        private bool disposed;
        private ValueItemList entityTree;
        internal Korzh.EasyQuery.Query.ColumnsStore justSortedColumns;
        private DataModel model;
        private ToolTip panelToolTip;
        private Korzh.EasyQuery.Query query;
        protected Korzh.EasyQuery.Query.SortedColumnList sortedColumns;
        private SortColumnsPanel sortPanel;

        public event EventHandler RowListChanged;

        static QueryColumnsPanel()
        {
            ColumnRow.RegisterType("ENTATTR", new SimpleColumnRowCreator());
            ColumnRow.RegisterType("AGGRFUNC", new AggrColumnRowCreator());
        }

        public QueryColumnsPanel()
        {
            ResourceManager resources = new ResourceManager("Korzh.EasyQuery.WinControls.QueryColumnsPanel", typeof(QueryColumnsPanel).Assembly);
            base.Texts.LoadFromResources(resources);
            this.panelToolTip = new ToolTip();
            this.Query = null;
            this.entityTree = new ValueItemList();
            this.addRow = new AdditionRow(this);
            base.Controls.Add(this.addRow.RowControl);
            this.addRow.Visible = false;
            this.ApplyFormats();
        }

        public void Activate()
        {
            this.CheckDataModel();
            this.CheckQuery();
            this.active = true;
            if (this.addRow != null)
            {
                this.addRow.Visible = this.Appearance.EditMode == EditModeKind.All;
            }
            this.RefreshByColumns();
            this.ApplyFormats();
        }

        protected virtual void AddRowByColumn(Korzh.EasyQuery.Query.Column column)
        {
            ColumnRow newrow = ColumnRow.Create(this, column.ExprType, column, false);
            newrow.RefreshByColumn();
            int num = base.Rows.Add(newrow);
            if (!base.Updating)
            {
                base.ActiveRowIndex = num;
            }
        }

        public void AddSimpleColumn()
        {
            this.CheckQuery();
            this.CheckDataModel();
            this.CoreAddSimpleColumn(this.Model.GetDefaultUIRAttribute());
        }

        public void AddSimpleColumn(DataModel.EntityAttr attr)
        {
            this.CheckQuery();
            this.CheckDataModel();
            this.CoreAddSimpleColumn(attr);
        }

        public void AddSimpleColumn(string attrID)
        {
            this.CheckQuery();
            this.CheckDataModel();
            DataModel.EntityAttr defaultUIRAttribute = this.Model.EntityRoot.FindAttribute(EntAttrProp.ID, attrID);
            if (defaultUIRAttribute == null)
            {
                defaultUIRAttribute = this.Model.GetDefaultUIRAttribute();
            }
            this.CoreAddSimpleColumn(defaultUIRAttribute);
        }

        protected override void ApplyFormats()
        {
            base.ApplyFormats();
            if (this.addRow != null)
            {
                this.addRow.Visible = this.Appearance.EditMode == EditModeKind.All;
                this.addRow.ApplyFormats();
            }
        }

        protected override void Arrange()
        {
            base.Arrange();
            if (this.addRow != null)
            {
                this.addRow.PlaceAt(base.Rows.Count);
            }
        }

        protected void CheckDataModel()
        {
            if (this.model == null)
            {
                throw new Error("Data Model is not specified");
            }
        }

        protected void CheckQuery()
        {
            if (this.query == null)
            {
                throw new Error("Query object is not specified");
            }
        }

        protected virtual void ColumnsChangedHandler(object sender, ColumnsChangeEventArgs e)
        {
            this.RefreshByColumns();
        }

        protected virtual void CoreAddSimpleColumn(DataModel.EntityAttr attr)
        {
            Korzh.EasyQuery.Query.Column column = new Korzh.EasyQuery.Query.Column();
            column.Expr = new EntityAttrExpr(this.Model, attr);
            this.columns.Add(column);
        }

        protected virtual void CoreAddSimpleColumnThroughUI(string attrID)
        {
            this.AddSimpleColumn(attrID);
            if (base.Rows.Count > 0)
            {
                base.Rows[base.Rows.Count - 1].Active = true;
            }
            if (this.addRow != null)
            {
                this.addRow.PlaceAt(base.Rows.Count);
                this.ScrollAddRowIntoView();
            }
            this.OnSizeChanged(EventArgs.Empty);
        }

        protected override void CoreEndUpdate()
        {
            if (this.addRow != null)
            {
                this.addRow.PlaceAt(base.Rows.Count);
            }
        }

        protected virtual void CoreFillEntityTree(ValueItemList items, DataModel.Entity parentEntity)
        {
            foreach (DataModel.Entity entity in parentEntity.SubEntities)
            {
                string hint = (entity.UserData != null) ? entity.UserData.ToString() : "";
                ValueItem item = new ValueItem(entity.Name, entity.Name, "", hint);
                this.CoreFillEntityTree(item.SubItems, entity);
                if (item.SubItems.Count > 0)
                {
                    items.Add(item);
                }
            }
            foreach (DataModel.EntityAttr attr in parentEntity.Attributes)
            {
                if (attr.UseInResult)
                {
                    items.Add(attr.Caption, attr.ID);
                }
            }
        }

        protected override XPanel.XAppearance CreateAppearance()
        {
            return new CPAppearance(this);
        }

        public void Deactivate()
        {
            this.active = false;
            base.Rows.Clear();
            this.addRow.Visible = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    if (this.addRow != null)
                    {
                        this.addRow.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
            this.disposed = true;
        }

        protected override void DoAction(object sender, string actionName, object data)
        {
            if ((base.ActiveRow != null) && (sender is ColumnRow.ColumnButton))
            {
                ColumnRow parentRow = (ColumnRow) ((ColumnRow.ColumnButton) sender).ParentRow;
                if (string.Compare(actionName, "NotSorted", true) == 0)
                {
                    parentRow.Column.Sorting = SortDirection.None;
                }
                else if (string.Compare(actionName, "Ascending", true) == 0)
                {
                    parentRow.Column.Sorting = SortDirection.Ascending;
                }
                else if (string.Compare(actionName, "Descending", true) == 0)
                {
                    parentRow.Column.Sorting = SortDirection.Descending;
                }
                else if (string.Compare(actionName, "Distinct", true) == 0)
                {
                    parentRow.Column.Distinct = !parentRow.Column.Distinct;
                }
                else if (string.Compare(actionName, "DeleteColumn", true) == 0)
                {
                    int activeRowIndex = base.ActiveRowIndex;
                    this.columns.RemoveAt(activeRowIndex);
                }
                else if (string.Compare(actionName, "MoveRowTop", true) == 0)
                {
                    this.MoveRow(parentRow.Index, 0);
                }
                else if (string.Compare(actionName, "MoveRowUp", true) == 0)
                {
                    this.DoSignal(sender, Signals.KeyCtrlUp, null);
                }
                else if (string.Compare(actionName, "MoveRowDown", true) == 0)
                {
                    this.DoSignal(sender, Signals.KeyCtrlDown, null);
                }
                else if (string.Compare(actionName, "MoveRowBottom", true) == 0)
                {
                    this.MoveRow(parentRow.Index, base.Rows.Count - 1);
                }
                else if (actionName.StartsWith("CCT_"))
                {
                    ((ColumnRow) ((ListXElement) sender).ParentRow).Column.ExprType = actionName.Substring(4);
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

        protected override void DoSignal(object sender, Signals signalID, string[] paramList)
        {
            if (((signalID != Signals.Activate) || (((XElement) sender).ParentRow != this.addRow)) && ((signalID != Signals.KeyCtrlLeft) && (signalID != Signals.KeyCtrlRight)))
            {
                base.DoSignal(sender, signalID, paramList);
            }
        }

        internal void FillAggrElement(ListXElement entityElement, AggrFuncExpr expression)
        {
            this.CheckDataModel();
            entityElement.Items.Clear();
            if (this.TypeIsInList(expression.Argument.DataType, new DataType[] { DataType.Autoinc, DataType.Byte, DataType.Currency, DataType.Float, DataType.Int, DataType.Int64, DataType.Word }))
            {
                entityElement.AddListItem(null, "Sum", "SUM");
                entityElement.AddListItem(null, "Average", "AVG");
            }
            if (this.TypeIsInList(expression.Argument.DataType, new DataType[] { DataType.Autoinc, DataType.BCD, DataType.Byte, DataType.Currency, DataType.Date, DataType.Time, DataType.DateTime, DataType.Float, DataType.Int, DataType.Int64, DataType.Word }))
            {
                entityElement.AddListItem(null, "Minimum", "MIN");
                entityElement.AddListItem(null, "Maximum", "MAX");
            }
            entityElement.AddListItem(null, "Count", "COUNT");
        }

        internal void FillElementByEntityTree(ListXElement element)
        {
            if ((this.entityTree.Count == 0) && (this.model != null))
            {
                this.FillEntityTree(this.entityTree);
            }
            element.Items = this.entityTree;
        }

        private void FillEntityTree(ValueItemList items)
        {
            this.CheckDataModel();
            this.CoreFillEntityTree(items, this.model.EntityRoot);
        }

        protected virtual void MoveRow(int index1, int index2)
        {
            this.CheckQuery();
            if (((index1 >= 0) && (index2 >= 0)) && (((index1 < base.Rows.Count) && (index2 < base.Rows.Count)) && (index1 != index2)))
            {
                Korzh.EasyQuery.Query.Column column = null;
                if (base.ActiveRow != null)
                {
                    column = ((ColumnRow) base.ActiveRow).Column;
                }
                this.columns.Move(index1, index2);
                if (column != null)
                {
                    base.ActiveRowIndex = this.columns.IndexOf(column);
                }
            }
        }

        public override void MoveRowDown(int index)
        {
            this.MoveRow(index, index + 1);
        }

        public override void MoveRowUp(int index)
        {
            this.MoveRow(index, index - 1);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if ((base.ActiveRow == null) && (this.addRow != null))
            {
                this.addRow.Elements[0].Select();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!e.Handled && (base.ActiveRowIndex >= 0))
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (base.ActiveRowIndex == (base.Rows.Count - 1))
                    {
                        if ((this.addRow != null) && base.Visible)
                        {
                            base.ScrollControlIntoView(this.addRow.RowControl);
                            this.addRow.Elements[0].Select();
                        }
                        e.Handled = true;
                    }
                    else
                    {
                        base.ActiveRowIndex++;
                        base.Rows[base.ActiveRowIndex].SelectNextControl(-1, true, true);
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if ((this.addRow != null) && this.addRow.Elements[0].ElementControl.Focused)
                    {
                        base.ActiveRowIndex = base.Rows.Count - 1;
                        base.Rows[base.ActiveRowIndex].SelectNextControl(-1, true, true);
                    }
                    else if (base.ActiveRowIndex > 0)
                    {
                        base.ActiveRowIndex--;
                        base.Rows[base.ActiveRowIndex].SelectNextControl(-1, true, true);
                    }
                    e.Handled = true;
                }
                base.OnKeyDown(e);
            }
        }

        protected override void OnRowAdded(XRow row)
        {
            base.OnRowAdded(row);
        }

        protected override void OnRowListChanged()
        {
            if ((this.addRow != null) && !base.Updating)
            {
                this.addRow.PlaceAt(base.Rows.Count);
            }
            if (this.RowListChanged != null)
            {
                this.RowListChanged(this, new EventArgs());
            }
        }

        internal void RecreateRow(ColumnRow row)
        {
            int index = base.Rows.IndexOf(row);
            if (index >= 0)
            {
                ColumnRow row2 = ColumnRow.Create(this, row.Column.ExprType, row.Column, false);
                base.Rows[index] = row2;
                row2.RefreshByColumn();
                row.Visible = false;
                row.InnerDetach();
                row.Dispose();
                base.PlaceRow(row2);
                this.ApplyFormats();
                this.Arrange();
            }
        }

        public virtual void RefreshByColumns()
        {
            this.CheckQuery();
            int activeRowIndex = base.ActiveRowIndex;
            base.BeginUpdate();
            try
            {
                for (int i = 0; i < this.columns.Count; i++)
                {
                    if (i >= base.Rows.Count)
                    {
                        break;
                    }
                    ((ColumnRow) base.Rows[i]).SetColumn(this.columns[i]);
                    ((ColumnRow) base.Rows[i]).RefreshByColumn();
                }
                if (this.columns.Count > base.Rows.Count)
                {
                    for (int j = base.Rows.Count; j < this.columns.Count; j++)
                    {
                        this.AddRowByColumn(this.columns[j]);
                    }
                }
                else if (this.columns.Count < base.Rows.Count)
                {
                    for (int k = base.Rows.Count - 1; k >= this.columns.Count; k--)
                    {
                        base.Rows.RemoveAt(k);
                    }
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

        protected void ScrollAddRowIntoView()
        {
            if (this.addRow.Visible)
            {
                this.AdjustFormScrollbars(true);
                base.ScrollControlIntoView(this.addRow.RowControl);
            }
        }

        protected override void SetRowsWidth(int width)
        {
            base.SetRowsWidth(width);
            if (this.addRow != null)
            {
                this.addRow.Width = (this.addRow.Elements[0].ElementControl.Width > width) ? this.addRow.Elements[0].ElementControl.Width : width;
            }
            this.AdjustFormScrollbars(this.AutoScroll);
        }

        protected virtual void SortOrderChangedHander(object sender, SortOrderChangedEventArgs e)
        {
        }

        private bool TypeIsInList(DataType type, DataType[] list)
        {
            foreach (DataType type2 in list)
            {
                if (type2 == type)
                {
                    return true;
                }
            }
            return false;
        }

        [Browsable(false)]
        public bool Active
        {
            get
            {
                return this.active;
            }
            set
            {
                if (this.active != value)
                {
                    this.active = value;
                    if (this.active)
                    {
                        this.Activate();
                    }
                    else
                    {
                        this.Deactivate();
                    }
                }
            }
        }

        [DefaultValue(true), Browsable(true)]
        public virtual bool AllowAggrColumns
        {
            get
            {
                return this.allowAggrColumns;
            }
            set
            {
                if (this.allowAggrColumns != value)
                {
                    this.allowAggrColumns = value;
                    this.Refresh();
                }
            }
        }

        [DefaultValue(true), Browsable(true)]
        public virtual bool AllowEditCaptions
        {
            get
            {
                return this.allowEditCaptions;
            }
            set
            {
                if (this.allowEditCaptions != value)
                {
                    this.allowEditCaptions = value;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), DefaultValue(true)]
        public virtual bool AllowSorting
        {
            get
            {
                return this.allowSorting;
            }
            set
            {
                if (this.allowSorting != value)
                {
                    this.allowSorting = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CPAppearance Appearance
        {
            get
            {
                return (CPAppearance) base.Appearance;
            }
            set
            {
                base.Appearance = value;
            }
        }

        [Browsable(false)]
        public Korzh.EasyQuery.Query.ColumnsStore Columns
        {
            get
            {
                return this.columns;
            }
        }

        [Browsable(false)]
        public Korzh.EasyQuery.Query.ColumnsStore JustSortedColumns
        {
            get
            {
                return this.justSortedColumns;
            }
        }

        public DataModel Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (this.model != value)
                {
                    this.model = value;
                    this.entityTree.Clear();
                    if (this.model != null)
                    {
                        if (this.query != null)
                        {
                            this.query.Model = this.model;
                        }
                        this.FillEntityTree(this.entityTree);
                    }
                }
            }
        }

        protected internal ToolTip PanelToolTip
        {
            get
            {
                return this.panelToolTip;
            }
        }

        public Korzh.EasyQuery.Query Query
        {
            get
            {
                return this.query;
            }
            set
            {
                if (this.query != value)
                {
                    this.query = value;
                    if (this.query != null)
                    {
                        this.columns = this.query.Result.Columns;
                        this.sortedColumns = this.query.Result.SortedColumns;
                        this.justSortedColumns = this.query.Result.JustSortedColumns;
                        this.query.ColumnsChanged += new ColumnsChangedEventHandler(this.ColumnsChangedHandler);
                        this.query.SortOrderChanged += new SortOrderChangedEventHandler(this.SortOrderChangedHander);
                    }
                    else
                    {
                        this.Deactivate();
                    }
                }
            }
        }

        internal SortColumnsPanel SortPanel
        {
            get
            {
                return this.sortPanel;
            }
            set
            {
                this.sortPanel = value;
            }
        }

        internal protected class AdditionRow : XRow
        {
            private ListXElement baseElement;
            private QueryColumnsPanel parentPanel;

            public AdditionRow(QueryColumnsPanel parentPanel) : base(false)
            {
                this.parentPanel = parentPanel;
                base.Parent = parentPanel;
                this.baseElement = new AdditionRowBaseElement(parentPanel);
                this.baseElement.ListName = "EntityTree";
                this.baseElement.EmptyValueText = this.RowText;
                base.Elements.Add(this.baseElement);
            }

            internal void InnerDetach()
            {
                base.CoreDetach();
            }

            protected internal void PlaceAt(int position)
            {
                base.ArrangeRowAt(position);
            }

            protected internal Control RowControl
            {
                get
                {
                    return base.rowControl;
                }
            }

            protected string RowText
            {
                get
                {
                    return ("[" + this.parentPanel.Texts.Get("CmdClickToAdd") + "]");
                }
            }

            protected class AdditionRowBaseElement : ListXElement
            {
                private QueryColumnsPanel parentPanel;

                public AdditionRowBaseElement(QueryColumnsPanel parentPanel)
                {
                    this.parentPanel = parentPanel;
                }

                public override void ApplyFormats()
                {
                    base.ApplyFormats();
                    base.linkControl.LinkColor = this.parentPanel.Appearance.AdditionRowColor;
                }

                protected override string CoreGetTextAdjustedByValue(string newValue)
                {
                    if (base.ParentRow == null)
                    {
                        return "";
                    }
                    return ((QueryColumnsPanel.AdditionRow) base.ParentRow).RowText;
                }

                protected override void OnContentChanged(bool valueChanged, bool textChanged)
                {
                    this.parentPanel.CoreAddSimpleColumnThroughUI(base.Value);
                    base.SetContentSilent(string.Empty, string.Empty);
                }

                protected override void RequestList(string listName)
                {
                    this.parentPanel.FillElementByEntityTree(this);
                    base.Items = this.parentPanel.entityTree;
                }
            }
        }

        public class AggrColumnRow : QueryColumnsPanel.SimpleColumnRow
        {
            protected ListXElement aggrElement;
            protected TextXElement ofElement;

            public AggrColumnRow(QueryColumnsPanel aPanel, Query.Column aColumn, bool useCheckBox) : base(aPanel, aColumn, useCheckBox)
            {
                base.colButtonMenuList.BeginUpdate();
                base.DistinctMenuItem.Enabled = true;
                base.colButtonMenuList.EndUpdate();
            }

            protected override void AddCommonElements()
            {
                if (base.distinctElement == null)
                {
                    base.distinctElement = new TextXElement();
                    base.Elements.Add(base.distinctElement);
                }
                if (base.Column.Distinct)
                {
                    base.distinctElement.Text = base.parentPanel.Texts.Get("MsgDistinct");
                }
                else
                {
                    base.distinctElement.Text = "";
                }
                base.AddCommonElements();
            }

            protected virtual void AggrFuncElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if ((!base.Refreshing && (this.aggrElement == ((XElement) sender))) && e.ValueChanged)
                {
                    ((AggrFuncExpr) base.column.Expr).Value = this.aggrElement.Value;
                }
            }

            protected override void AttrElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if ((!base.Refreshing && (base.attrElement == ((XElement) sender))) && e.ValueChanged)
                {
                    base.Refreshing = true;
                    ((AggrFuncExpr) base.column.Expr).Argument.Value = base.attrElement.Value;
                    base.Refreshing = false;
                    this.RefreshByColumn();
                }
            }

            protected override void AttrElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                EntityAttrExpr argument = (EntityAttrExpr) ((AggrFuncExpr) base.column.Expr).Argument;
                DataModel.EntityAttr attribute = argument.Attribute;
                e.Text = base.GetAttributeCaption(attribute);
                base.parentPanel.PanelToolTip.SetToolTip(((XElement) sender).ElementControl, attribute.Description);
            }

            internal override void CoreRefreshByColumn()
            {
                if (this.aggrElement == null)
                {
                    this.aggrElement = new ListXElement();
                    this.aggrElement.ContentChanged += new ContentChangedEventHandler(this.AggrFuncElementContentChanged);
                    base.Elements.Add(this.aggrElement);
                }
                base.parentPanel.FillAggrElement(this.aggrElement, (AggrFuncExpr) base.column.Expr);
                AggrFunction function = ((AggrFuncExpr) base.column.Expr).Function;
                bool flag = false;
                foreach (ValueItem item in this.aggrElement.Items)
                {
                    if (item.Value == function.ID)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    string id = this.aggrElement.Items[0].Value;
                    string text = this.aggrElement.Items[0].Text;
                    ((AggrFuncExpr) base.column.Expr).Function = new AggrFunction(id, text, id + "({expr1})", "[[" + id + "]] of {attr1}");
                    function = ((AggrFuncExpr) base.column.Expr).Function;
                }
                this.aggrElement.Data = (AggrFuncExpr) base.column.Expr;
                this.aggrElement.Value = function.ID;
                this.aggrElement.Text = function.Caption;
                if (this.ofElement == null)
                {
                    this.ofElement = new TextXElement(base.parentPanel.Texts.Get("MsgOf"));
                    base.Elements.Add(this.ofElement);
                }
                if (base.attrElement == null)
                {
                    base.attrElement = new ListXElement();
                    base.parentPanel.FillElementByEntityTree(base.attrElement);
                    base.attrElement.ContentChanged += new ContentChangedEventHandler(this.AttrElementContentChanged);
                    base.attrElement.TextAdjusting += new TextAdjustingEventHandler(this.AttrElementTextAdjusting);
                    base.Elements.Add(base.attrElement);
                }
                EntityAttrExpr argument = (EntityAttrExpr) ((AggrFuncExpr) base.column.Expr).Argument;
                base.attrElement.Data = argument;
                DataModel.EntityAttr attribute = argument.Attribute;
                base.attrElement.Value = attribute.ID;
            }

            public static string STypeName
            {
                get
                {
                    return "AGGRFUNC";
                }
            }

            public override string TypeName
            {
                get
                {
                    return STypeName;
                }
            }
        }

        internal class AggrColumnRowCreator : IColumnRowCreator
        {
            public ColumnRow Create(QueryColumnsPanel panel, Query.Column column, bool useCheckBox)
            {
                return new QueryColumnsPanel.AggrColumnRow(panel, column, useCheckBox);
            }

            public string GetCaption(QueryColumnsPanel panel)
            {
                return panel.Texts.Get("ColTypeAggrFunc");
            }
        }

        [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
        public class CPAppearance : XPanel.XAppearance
        {
            private Color additionRowColor;
            private string attrElementFormat;
            private QueryColumnsPanel.EditModeKind editMode;
            private string title;

            public event EventHandler TitleChanged;

            public CPAppearance(QueryColumnsPanel parent) : base(parent)
            {
                this.attrElementFormat = "{entity} {attr}";
                this.additionRowColor = Color.Navy;
                parent.BackColor = Color.LightYellow;
                this.title = "";
                parent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }

            protected void OnTitleChanged(EventArgs e)
            {
                if (this.TitleChanged != null)
                {
                    this.TitleChanged(this, e);
                }
            }

            [DefaultValue(typeof(Color), "Navy")]
            public Color AdditionRowColor
            {
                get
                {
                    return this.additionRowColor;
                }
                set
                {
                    if (this.additionRowColor != value)
                    {
                        this.additionRowColor = value;
                        if (this.ParentPanel != null)
                        {
                            this.ParentPanel.ApplyFormats();
                        }
                    }
                }
            }

            public string AttrElementFormat
            {
                get
                {
                    return this.attrElementFormat;
                }
                set
                {
                    if (this.attrElementFormat != value)
                    {
                        this.attrElementFormat = value;
                        base.RefreshParent();
                    }
                }
            }

            public Color BackColor
            {
                get
                {
                    return base.parent.BackColor;
                }
                set
                {
                    if (base.parent.BackColor != value)
                    {
                        base.parent.BackColor = value;
                        base.parent.Refresh();
                    }
                }
            }

            [Browsable(true)]
            public System.Windows.Forms.BorderStyle BorderStyle
            {
                get
                {
                    return base.parent.BorderStyle;
                }
                set
                {
                    if (this.BorderStyle != value)
                    {
                        base.parent.BorderStyle = value;
                    }
                }
            }

            public QueryColumnsPanel.EditModeKind EditMode
            {
                get
                {
                    return this.editMode;
                }
                set
                {
                    if (this.editMode != value)
                    {
                        this.editMode = value;
                        this.ParentPanel.ApplyFormats();
                    }
                }
            }

            [Browsable(false)]
            public QueryColumnsPanel ParentPanel
            {
                get
                {
                    return (QueryColumnsPanel) base.parent;
                }
            }

            public string Title
            {
                get
                {
                    return this.title;
                }
                set
                {
                    if (value != this.title)
                    {
                        this.title = value;
                        this.OnTitleChanged(EventArgs.Empty);
                    }
                }
            }
        }

        public enum EditModeKind
        {
            All,
            FixedList,
            FixedColumns,
            SortingOnly,
            None
        }

        public class Error : Exception
        {
            public Error(string message) : base(message)
            {
            }
        }

        public class SimpleColumnRow : ColumnRow
        {
            protected internal TextXElement asElement;
            protected internal ListXElement attrElement;
            protected internal TextXElement colonElement;
            protected internal TextXElement distinctElement;
            protected ValueItem DistinctMenuItem;
            protected internal ListXElement sortElement;
            protected internal EditXElement titleElement;

            public SimpleColumnRow(QueryColumnsPanel aPanel, Query.Column aColumn, bool useCheckBox) : base(aPanel, aColumn, useCheckBox)
            {
                base.colButtonMenuList.BeginUpdate();
                ValueItem item = base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdGroupSort"), "", "");
                item.SubItems.Add(base.parentPanel.Texts.Get("CmdNotSorted"), "", "NotSorted");
                item.SubItems.Add(base.parentPanel.Texts.Get("CmdAscending"), "", "Ascending");
                item.SubItems.Add(base.parentPanel.Texts.Get("CmdDescending"), "", "Descending");
                this.DistinctMenuItem = base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdDistinct"), "", "Distinct");
                this.DistinctMenuItem.Enabled = false;
                base.colButtonMenuList.Add("-", "");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveTop"), "", "MoveRowTop");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveUp"), "", "MoveRowUp");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveDown"), "", "MoveRowDown");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdMoveBottom"), "", "MoveRowBottom");
                base.colButtonMenuList.Add("-", "");
                base.colButtonMenuList.Add(base.parentPanel.Texts.Get("CmdDeleteColumn"), "", "DeleteColumn");
                base.colButtonMenuList.Add("-", "");
                item = base.colButtonMenuList.Add(base.parentPanel.Texts.Get("ColTypeGroup"), "", "");
                IDictionaryEnumerator enumerator = ColumnRow.Creators.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if ((((string) enumerator.Key) != this.TypeName) && ((((string) enumerator.Key) != "AGGRFUNC") || base.parentPanel.AllowAggrColumns))
                    {
                        item.SubItems.Add(((IColumnRowCreator) enumerator.Value).GetCaption(base.parentPanel), "", "CCT_" + ((string) enumerator.Key));
                    }
                }
                item.Enabled = item.SubItems.Count > 0;
                base.colButtonMenuList.EndUpdate();
                base.sortMenuList.Add(new ValueItem(base.parentPanel.Texts.Get("CmdNotSorted"), SortDirection.None.ToString()));
                base.sortMenuList.Add(new ValueItem(base.parentPanel.Texts.Get("CmdAscending"), SortDirection.Ascending.ToString()));
                base.sortMenuList.Add(new ValueItem(base.parentPanel.Texts.Get("CmdDescending"), SortDirection.Descending.ToString()));
            }

            protected override void AddCommonElements()
            {
                if ((base.parentPanel == null) || base.parentPanel.AllowEditCaptions)
                {
                    if (this.asElement == null)
                    {
                        this.asElement = new TextXElement(base.parentPanel.Texts.Get("MsgAs"));
                        base.Elements.Add(this.asElement);
                    }
                    if (this.titleElement == null)
                    {
                        this.titleElement = new EditXElement("");
                        this.titleElement.NeedValidate = true;
                        this.titleElement.ContentChanged += new ContentChangedEventHandler(this.TitleElementContentChanged);
                        base.Elements.Add(this.titleElement);
                    }
                    if (base.column.Caption != "")
                    {
                        this.titleElement.Value = base.column.Caption;
                    }
                    else
                    {
                        this.titleElement.Value = this.attrElement.Text;
                    }
                }
                if (base.parentPanel.AllowSorting && base.column.AllowSorting)
                {
                    if (this.colonElement == null)
                    {
                        this.colonElement = new TextXElement(": ");
                        base.Elements.Add(this.colonElement);
                    }
                    if (this.sortElement == null)
                    {
                        this.sortElement = new ListXElement();
                        this.sortElement.Items = base.sortMenuList;
                        this.sortElement.ContentChanged += new ContentChangedEventHandler(this.SortElementContentChanged);
                        base.Elements.Add(this.sortElement);
                    }
                    this.sortElement.Value = base.column.Sorting.ToString();
                }
                else
                {
                    if (this.colonElement != null)
                    {
                        base.Elements.Remove(this.colonElement);
                        this.colonElement = null;
                    }
                    if (this.sortElement != null)
                    {
                        base.Elements.Remove(this.sortElement);
                        this.sortElement = null;
                    }
                }
            }

            protected virtual void AttrElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if ((!base.Refreshing && (this.attrElement == ((XElement) sender))) && e.ValueChanged)
                {
                    base.Refreshing = true;
                    base.column.Expr.Value = this.attrElement.Value;
                    base.Refreshing = false;
                }
            }

            protected virtual void AttrElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                EntityAttrExpr expr = (EntityAttrExpr) base.column.Expr;
                DataModel.EntityAttr attribute = expr.Attribute;
                e.Text = this.GetAttributeCaption(attribute);
                base.parentPanel.PanelToolTip.SetToolTip(((XElement) sender).ElementControl, attribute.Description);
            }

            protected override void CoreApplyFormats()
            {
                base.CoreApplyFormats();
                QueryColumnsPanel.EditModeKind editMode = base.parentPanel.Appearance.EditMode;
                foreach (XElement element in base.Elements)
                {
                    if (element == this.attrElement)
                    {
                        element.ReadOnly = (editMode != QueryColumnsPanel.EditModeKind.All) && (editMode != QueryColumnsPanel.EditModeKind.FixedList);
                    }
                    else
                    {
                        if (element == this.titleElement)
                        {
                            element.ReadOnly = (editMode == QueryColumnsPanel.EditModeKind.SortingOnly) || (editMode == QueryColumnsPanel.EditModeKind.None);
                            continue;
                        }
                        if (element != base.button)
                        {
                            element.ReadOnly = editMode == QueryColumnsPanel.EditModeKind.None;
                        }
                    }
                }
                base.colButtonMenuList[0].Enabled = (base.parentPanel.AllowSorting && base.column.AllowSorting) && (editMode != QueryColumnsPanel.EditModeKind.None);
                base.colButtonMenuList[8].Enabled = editMode == QueryColumnsPanel.EditModeKind.All;
                base.colButtonMenuList[10].Enabled = (editMode == QueryColumnsPanel.EditModeKind.All) || (editMode == QueryColumnsPanel.EditModeKind.FixedList);
                base.button.Items = null;
                base.button.Items = base.colButtonMenuList;
            }

            protected override void CoreElementBeforeDropDown(XElement sender)
            {
            }

            internal override void CoreRefreshByColumn()
            {
                if (this.attrElement == null)
                {
                    this.attrElement = new ListXElement();
                    base.parentPanel.FillElementByEntityTree(this.attrElement);
                    this.attrElement.ContentChanged += new ContentChangedEventHandler(this.AttrElementContentChanged);
                    this.attrElement.TextAdjusting += new TextAdjustingEventHandler(this.AttrElementTextAdjusting);
                    base.Elements.Add(this.attrElement);
                }
                EntityAttrExpr expr = (EntityAttrExpr) base.column.Expr;
                this.attrElement.Data = expr;
                DataModel.EntityAttr attribute = expr.Attribute;
                if (attribute != null)
                {
                    this.attrElement.Value = attribute.ID;
                }
            }

            protected string GetAttributeCaption(DataModel.EntityAttr attr)
            {
                if (base.parentPanel.Appearance.AttrElementFormat != string.Empty)
                {
                    return base.parentPanel.Appearance.AttrElementFormat.Replace("{attr}", attr.Caption).Replace("{entity}", attr.Entity.GetFullName(".")).Trim();
                }
                return attr.Caption;
            }

            protected virtual void SortElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    if (element.Value == SortDirection.None.ToString())
                    {
                        base.column.Sorting = SortDirection.None;
                    }
                    else if (element.Value == SortDirection.Ascending.ToString())
                    {
                        base.column.Sorting = SortDirection.Ascending;
                    }
                    else
                    {
                        base.column.Sorting = SortDirection.Descending;
                    }
                }
            }

            protected virtual void TitleElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    base.column.Caption = this.titleElement.Value;
                }
            }

            public static string STypeName
            {
                get
                {
                    return "ENTATTR";
                }
            }

            public override string TypeName
            {
                get
                {
                    return STypeName;
                }
            }
        }

        internal class SimpleColumnRowCreator : IColumnRowCreator
        {
            public ColumnRow Create(QueryColumnsPanel panel, Query.Column column, bool useCheckBox)
            {
                return new QueryColumnsPanel.SimpleColumnRow(panel, column, useCheckBox);
            }

            public string GetCaption(QueryColumnsPanel panel)
            {
                return panel.Texts.Get("ColTypeSimple");
            }
        }
    }
}

