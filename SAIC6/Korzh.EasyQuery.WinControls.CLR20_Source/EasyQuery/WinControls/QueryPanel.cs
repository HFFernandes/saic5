namespace Korzh.EasyQuery.WinControls
{
    using Korzh.EasyQuery;
    using Korzh.WinControls.XControls;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml;

    [ToolboxBitmap(typeof(QueryPanel))]
    public class QueryPanel : XPanel
    {
        private bool active;
        private AdditionRow addRow;
        internal ValueItemList boolValuesMenuList;
        internal ValueItemList condButtonMenuList;
        private bool disposed;
        private ValueItemList entityTree;
        private DataModel model;
        private ToolTip panelToolTip;
        internal ValueItemList predicateMenuList;
        private Korzh.EasyQuery.Query query;
        internal ValueItemList rootButtonMenuList;
        private RootRow rootRow;
        internal ValueItemList specDateValuesMenuList;
        internal ValueItemList specTimeValuesMenuList;

        public event CreateValueElementEventHandler CreateValueElement;

        public event ListRequestEventHandler ListRequest;

        public event SqlExecuteEventHandler SqlExecute;

        public event ValueRequestEventHandler ValueRequest;

        static QueryPanel()
        {
            XElement.Register(new SqlListXElement.Creator());
            XElement.Register(new SubQueryXElement.Creator());
        }

        public QueryPanel()
        {
            ResourceManager resources = new ResourceManager("Korzh.EasyQuery.WinControls.QueryPanel", typeof(QueryPanel).Assembly);
            base.Texts.LoadFromResources(resources);
            this.panelToolTip = new ToolTip();
            this.entityTree = new ValueItemList();
            this.addRow = new AdditionRow(this);
            base.Controls.Add(this.addRow.RowControl);
            this.addRow.Visible = false;
            this.rootRow = null;
            this.FillRootButtonMenu();
            this.FillPredicateMenu();
            this.FillCondButtonMenu();
            this.boolValuesMenuList = new ValueItemList();
            this.boolValuesMenuList.Add(new ValueItem("False", "${false}", "", ""));
            this.boolValuesMenuList.Add(new ValueItem("True", "${true}", "", ""));
            this.specDateValuesMenuList = new ValueItemList();
            this.specDateValuesMenuList.Add(new ValueItem("Today", "${Today}", "", ""));
            this.specDateValuesMenuList.Add(new ValueItem("Yesterday", "${Yesterday}", "", ""));
            this.specDateValuesMenuList.Add(new ValueItem("Tomorrow", "${Tomorrow}", "", ""));
            this.specDateValuesMenuList.Add(new ValueItem("First day of month", "${FirstDayOfMonth}", ""));
            this.specDateValuesMenuList.Add(new ValueItem("First day of year", "${FirstDayOfYear}", ""));
            this.specTimeValuesMenuList = new ValueItemList();
            this.specTimeValuesMenuList.Add(new ValueItem("Now", "${Now}", ""));
            this.specTimeValuesMenuList.Add(new ValueItem("This hour start", "${HourStart}", ""));
            this.specTimeValuesMenuList.Add(new ValueItem("Midnight", "${Midnight}", ""));
            this.specTimeValuesMenuList.Add(new ValueItem("Noon", "${Noon}", ""));
        }

        public void Activate()
        {
            this.CheckDataModel();
            this.CheckQuery();
            this.active = true;
            this.RefreshRootRow();
            this.addRow.PlaceAt(this.Rows.Count);
            this.addRow.Visible = this.Appearance.EditMode == EditModeKind.All;
            this.RefreshPanelByQuery();
            this.ApplyFormats();
        }

        internal void AddFirstLevelSimpleCondition(string attrID)
        {
            this.CheckDataModel();
            this.CheckQuery();
            DataModel.EntityAttr defaultUICAttribute = null;
            if (attrID != null)
            {
                defaultUICAttribute = this.Model.EntityRoot.FindAttribute(EntAttrProp.ID, attrID);
            }
            else
            {
                defaultUICAttribute = this.Model.GetDefaultUICAttribute();
            }
            this.CoreAddSimpleCondition(this.Query.Root, this.Query.Root.Conditions.Count, defaultUICAttribute);
        }

        private void AddPredicate(Korzh.EasyQuery.Query.Predicate parent, ConditionRow previous)
        {
            this.CheckDataModel();
            this.CheckQuery();
            int condIndex = (previous != null) ? (previous.Condition.Index + 1) : parent.Conditions.Count;
            this.CoreAddPredicate(parent, condIndex);
        }

        private void AddRowByCondition(Korzh.EasyQuery.Query.Condition cond)
        {
            ConditionRow row;
            int rowIndexForNewCondition = this.GetRowIndexForNewCondition(cond);
            if (cond is Korzh.EasyQuery.Query.Predicate)
            {
                row = new PredicateRow(this, (Korzh.EasyQuery.Query.Predicate) cond);
            }
            else
            {
                row = new SimpleConditionRow(this, (Korzh.EasyQuery.Query.SimpleCondition) cond);
            }
            row.RefreshByCondition();
            this.Rows.Insert(rowIndexForNewCondition, row);
        }

        private void AddRowsByPredicate(Korzh.EasyQuery.Query.Predicate root, int level)
        {
            foreach (Korzh.EasyQuery.Query.Condition condition in root.Conditions)
            {
                if (condition is Korzh.EasyQuery.Query.SimpleCondition)
                {
                    ConditionRow newrow = new SimpleConditionRow(this, (Korzh.EasyQuery.Query.SimpleCondition) condition);
                    newrow.RefreshByCondition();
                    newrow.Level = level;
                    this.Rows.Add(newrow);
                }
                else if (condition is Korzh.EasyQuery.Query.Predicate)
                {
                    PredicateRow row2 = new PredicateRow(this, (Korzh.EasyQuery.Query.Predicate) condition);
                    row2.RefreshByCondition();
                    row2.Level = level;
                    this.Rows.Add(row2);
                    this.AddRowsByPredicate((Korzh.EasyQuery.Query.Predicate) condition, level + 1);
                }
            }
        }

        public void AddSimpleCondition()
        {
            this.CheckDataModel();
            this.CheckQuery();
            this.CoreAddSimpleCondition(this.Query.Root, this.Query.Root.Conditions.Count, this.Model.GetDefaultUICAttribute());
        }

        private void AddSimpleCondition(Korzh.EasyQuery.Query.Predicate parent, ConditionRow previous)
        {
            this.CheckDataModel();
            this.CheckQuery();
            int condIndex = (previous != null) ? (previous.Condition.Index + 1) : parent.Conditions.Count;
            if (previous == null)
            {
                int count = this.Rows.Count;
            }
            else
            {
                this.IndexOfNextSameLevelRow(previous);
            }
            this.CoreAddSimpleCondition(parent, condIndex, this.Model.GetDefaultUICAttribute());
        }

        protected override void ApplyFormats()
        {
            this.FillRootButtonMenu();
            this.FillCondButtonMenu();
            base.ApplyFormats();
            this.addRow.Visible = this.Appearance.EditMode == EditModeKind.All;
            this.addRow.ApplyFormats();
        }

        protected override void Arrange()
        {
            base.Arrange();
            this.addRow.PlaceAt(this.Rows.Count);
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

        protected void CoreAddPredicate(Korzh.EasyQuery.Query.Predicate parent, int condIndex)
        {
            Korzh.EasyQuery.Query.Predicate predicate = this.query.AddPredicate(parent, condIndex);
            this.CoreAddSimpleCondition(predicate, 0, this.Model.GetDefaultUICAttribute());
        }

        protected virtual Korzh.EasyQuery.Query.Condition CoreAddSimpleCondition(Korzh.EasyQuery.Query.Predicate parent, int condIndex, DataModel.EntityAttr attr)
        {
            return this.query.AddSimpleCondition(parent, condIndex, attr);
        }

        protected virtual void CoreAddSimpleConditionThroughUI(string attrID)
        {
            this.AddFirstLevelSimpleCondition(attrID);
            this.addRow.PlaceAt(this.Rows.Count);
            this.ScrollAddRowIntoView();
        }

        protected override void CoreEndUpdate()
        {
            this.addRow.PlaceAt(this.Rows.Count);
        }

        private void CoreFillEntityTree(ValueItemList items, DataModel.Entity parentEntity)
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
                if (attr.UseInConditions)
                {
                    items.Add(attr.Caption, attr.ID);
                }
            }
        }

        protected override XPanel.XAppearance CreateAppearance()
        {
            return new QPAppearance(this);
        }

        protected override XRowList CreateRowList()
        {
            return new ConditionRowList(this);
        }

        public void Deactivate()
        {
            this.active = false;
            this.Rows.Clear();
            this.addRow.Visible = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    if (this.rootRow != null)
                    {
                        this.rootRow.Dispose();
                    }
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
            Korzh.EasyQuery.Query.Predicate parent = (this.ActiveRow != null) ? this.ActiveRow.Condition.Parent : this.query.Root;
            if (string.Compare(actionName, "AddCondition", true) == 0)
            {
                this.AddSimpleCondition(parent, this.ActiveRow);
            }
            else if (string.Compare(actionName, "AddPredicate", true) == 0)
            {
                this.AddPredicate(parent, this.ActiveRow);
            }
            else if (string.Compare(actionName, "AddConditionInto", true) == 0)
            {
                Korzh.EasyQuery.Query.Predicate predicate2 = ((this.ActiveRow != null) && (this.ActiveRow.Condition is Korzh.EasyQuery.Query.Predicate)) ? ((Korzh.EasyQuery.Query.Predicate) this.ActiveRow.Condition) : this.query.Root;
                this.AddSimpleCondition(predicate2, null);
            }
            else if (string.Compare(actionName, "AddPredicateInto", true) == 0)
            {
                Korzh.EasyQuery.Query.Predicate predicate3 = ((this.ActiveRow != null) && (this.ActiveRow.Condition is Korzh.EasyQuery.Query.Predicate)) ? ((Korzh.EasyQuery.Query.Predicate) this.ActiveRow.Condition) : this.query.Root;
                this.AddPredicate(predicate3, null);
            }
            else if (string.Compare(actionName, "DeleteRow", true) == 0)
            {
                parent.Conditions.Remove(this.ActiveRow.Condition);
            }
            else if (string.Compare(actionName, "SqlListRequest", true) == 0)
            {
                SqlListXElement element = (SqlListXElement) sender;
                SqlExecuteEventArgs e = new SqlExecuteEventArgs(element.SQL, new ValueItemList());
                e.ListItems.EmptyText = base.Texts.Get("MsgEmptyList");
                this.OnSqlExecute(e);
                element.Items = e.ListItems;
            }
            else if (string.Compare(actionName, "ValueRequest", true) == 0)
            {
                XElement element2 = (XElement) sender;
                ValueRequestEventArgs args2 = new ValueRequestEventArgs(element2.Value, element2.Text, element2.Data.ToString());
                this.OnValueRequest(args2);
                element2.Value = args2.Value;
                element2.Text = args2.Text;
            }
            else
            {
                base.DoAction(sender, actionName, data);
            }
        }

        protected override void DoListRequest(ListXElement element, string listName)
        {
            if (listName == "BooleanValues")
            {
                element.Items = this.boolValuesMenuList;
            }
            else if (listName == "EntityTree")
            {
                this.FillElementByEntityTree(element);
            }
            else if (listName == "SpecDateValues")
            {
                element.Items = this.specDateValuesMenuList;
            }
            else if (listName == "SpecTimeValues")
            {
                element.Items = this.specTimeValuesMenuList;
            }
            else
            {
                ListRequestEventArgs e = new ListRequestEventArgs(listName, element.Items);
                e.ListItems.EmptyText = base.Texts.Get("MsgEmptyList");
                this.OnListRequest(e);
                element.Items = e.ListItems;
            }
        }

        protected virtual void DoQueryConditionsChanged(object sender, ConditionsChangeEventArgs e)
        {
            if (this.Active)
            {
                switch (e.What)
                {
                    case ChangeType.Total:
                        this.RefreshPanelByQuery();
                        return;

                    case ChangeType.Addition:
                        this.AddRowByCondition(e.Condition);
                        return;

                    case ChangeType.Removal:
                        this.Rows.RemoveAt(this.Rows.IndexByCondition(e.Condition), true);
                        return;

                    case ChangeType.Update:
                    {
                        int num = this.Rows.IndexByCondition(e.Condition);
                        this.Rows[num].RefreshByCondition();
                        return;
                    }
                }
            }
        }

        private void FillCondButtonMenu()
        {
            if (this.condButtonMenuList == null)
            {
                this.condButtonMenuList = new ValueItemList();
            }
            this.condButtonMenuList.Clear();
            if (this.Appearance.EditMode == EditModeKind.All)
            {
                this.condButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdAddConditionAfter"), "AddCondition", "AddCondition"));
                if (!this.Appearance.HideBracketMenuItem)
                {
                    this.condButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdAddPredicateAfter"), "AddPredicate", "AddPredicate"));
                }
                this.condButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdDeleteRow"), "DeleteRow", "DeleteRow"));
            }
        }

        private void FillElementByEntityTree(ListXElement element)
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

        private void FillOperatorElementByAttribute(DataModel.EntityAttr attr, ListXElement operatorElement)
        {
            this.CheckDataModel();
            operatorElement.Items.Clear();
            foreach (DataModel.Operator @operator in attr.Operations)
            {
                operatorElement.AddListItem(null, @operator.Caption, @operator.ID);
            }
        }

        private void FillPredicateMenu()
        {
            if (this.predicateMenuList == null)
            {
                this.predicateMenuList = new ValueItemList();
            }
            this.predicateMenuList.Clear();
            this.predicateMenuList.Add(new ValueItem(base.Texts.Get("LinkTypeAll"), "all"));
            this.predicateMenuList.Add(new ValueItem(base.Texts.Get("LinkTypeAny"), "any"));
        }

        private void FillRootButtonMenu()
        {
            if (this.rootButtonMenuList == null)
            {
                this.rootButtonMenuList = new ValueItemList();
            }
            this.rootButtonMenuList.Clear();
            if (this.Appearance.EditMode == EditModeKind.All)
            {
                this.rootButtonMenuList.Add(new ValueItem(base.Texts.Get("AddConditionInto"), "AddConditionInto", "AddConditionInto"));
                if (!this.Appearance.HideBracketMenuItem)
                {
                    this.rootButtonMenuList.Add(new ValueItem(base.Texts.Get("AddPredicateInto"), "AddPredicateInto", "AddPredicateInto"));
                }
            }
        }

        private int GetRowIndexForNewCondition(Korzh.EasyQuery.Query.Condition cond)
        {
            Korzh.EasyQuery.Query.Predicate parent = cond.Parent;
            int index = parent.Conditions.IndexOf(cond);
            int num3 = this.Rows.IndexByCondition(parent);
            for (int i = 0; (i < index) && (i < parent.Conditions.Count); i++)
            {
                if (parent.Conditions[i] is Korzh.EasyQuery.Query.Predicate)
                {
                    num3 += ((Korzh.EasyQuery.Query.Predicate) parent.Conditions[i]).GetOffspringCount() + 1;
                }
                else
                {
                    num3++;
                }
            }
            num3++;
            return num3;
        }

        internal void HandleSubQueryCreateValueElement(object sender, CreateValueElementEventArgs e)
        {
            this.OnCreateValueElement(e);
        }

        internal void HandleSubQueryListRequest(object sender, ListRequestEventArgs e)
        {
            this.OnListRequest(e);
        }

        internal void HandleSubQuerySqlExecute(object sender, SqlExecuteEventArgs e)
        {
            this.OnSqlExecute(e);
        }

        internal void HandleSubQueryValidateValue(object sender, ValidateValueEventArgs e)
        {
            this.OnValidateValue(e);
        }

        internal void HandleSubQueryValueRequest(object sender, ValueRequestEventArgs e)
        {
            this.OnValueRequest(e);
        }

        private int IndexOfNextSameLevelRow(XRow row)
        {
            int num = row.Index + 1;
            while ((num < this.Rows.Count) && (this.Rows[num].Level > row.Level))
            {
                num++;
            }
            return num;
        }

        public override void MoveRowDown(int index)
        {
            this.CheckQuery();
            Korzh.EasyQuery.Query.Condition condition = this.Rows[index].Condition;
            this.Rows[index].Condition.MoveDown();
            foreach (ConditionRow row in this.Rows)
            {
                if (row.Condition == condition)
                {
                    row.Active = true;
                    break;
                }
            }
        }

        public override void MoveRowUp(int index)
        {
            this.CheckQuery();
            Korzh.EasyQuery.Query.Condition condition = this.Rows[index].Condition;
            this.Rows[index].Condition.MoveUp();
            foreach (ConditionRow row in this.Rows)
            {
                if (row.Condition == condition)
                {
                    row.Active = true;
                    break;
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(this.TimerEventProcessor);
            timer.Interval = 0x7d0;
            timer.Start();
        }

        protected internal virtual void OnCreateValueElement(CreateValueElementEventArgs e)
        {
            if (this.CreateValueElement != null)
            {
                this.CreateValueElement(this, e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!e.Handled && (base.ActiveRowIndex >= 0))
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (base.ActiveRowIndex == (this.Rows.Count - 1))
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
                        this.Rows[base.ActiveRowIndex].SelectNextControl(-1, true, true);
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if ((this.addRow != null) && this.addRow.Elements[0].ElementControl.Focused)
                    {
                        base.ActiveRowIndex = this.Rows.Count - 1;
                        this.Rows[base.ActiveRowIndex].SelectNextControl(-1, true, true);
                    }
                    else if (base.ActiveRowIndex > 0)
                    {
                        base.ActiveRowIndex--;
                        this.Rows[base.ActiveRowIndex].SelectNextControl(-1, true, true);
                    }
                    e.Handled = true;
                }
                base.OnKeyDown(e);
            }
        }

        protected virtual void OnListRequest(ListRequestEventArgs e)
        {
            if (this.ListRequest != null)
            {
                this.ListRequest(this, e);
            }
        }

        protected override void OnRowAdded(XRow row)
        {
            base.OnRowAdded(row);
            row.ArrangeRow();
        }

        protected override void OnRowListChanged()
        {
            if (!base.Updating)
            {
                this.ApplyFormats();
                this.addRow.PlaceAt(this.Rows.Count);
            }
        }

        protected virtual void OnSqlExecute(SqlExecuteEventArgs e)
        {
            if (this.SqlExecute != null)
            {
                this.SqlExecute(this, e);
            }
        }

        protected virtual void OnValueRequest(ValueRequestEventArgs e)
        {
            if (this.ValueRequest != null)
            {
                this.ValueRequest(this, e);
            }
        }

        protected void RecreateRootRow()
        {
            if (this.rootRow != null)
            {
                this.rootRow.Dispose();
                this.rootRow = null;
            }
            this.rootRow = new RootRow(this, this.Query.Root);
            this.rootRow.RefreshByCondition();
        }

        private void RefreshPanelByQuery()
        {
            base.BeginUpdate();
            try
            {
                this.Rows.Clear();
                if ((this.query != null) && (this.model != null))
                {
                    this.RefreshRootRow();
                    this.AddRowsByPredicate(this.Query.Root, 0);
                    base.ActiveRowIndex = 0;
                }
            }
            finally
            {
                base.EndUpdate();
            }
        }

        protected internal void RefreshRootRow()
        {
            if (this.Appearance.ShowRootRow && this.Active)
            {
                this.RecreateRootRow();
                if (!this.Rows.Contains(this.rootRow))
                {
                    this.Rows.Insert(0, this.rootRow);
                }
                this.rootRow.Visible = true;
            }
            else if (this.Rows.Contains(this.rootRow))
            {
                this.Rows.Remove(this.rootRow);
            }
        }

        protected void ScrollAddRowIntoView()
        {
            this.AdjustFormScrollbars(true);
            if (base.Visible)
            {
                base.ScrollControlIntoView(this.addRow.RowControl);
            }
        }

        protected override void SetRowsWidth(int width)
        {
            base.SetRowsWidth(width);
            if (this.addRow != null)
            {
                this.addRow.Width = width;
            }
            this.AdjustFormScrollbars(true);
        }

        public override void ShiftRowLevel(int rowIndex, bool up)
        {
            this.CheckQuery();
            Korzh.EasyQuery.Query.Condition condition = this.Rows[rowIndex].Condition;
            this.Rows[rowIndex].Condition.ShiftLevel(up);
            foreach (ConditionRow row in this.Rows)
            {
                if (row.Condition == condition)
                {
                    row.Active = true;
                    break;
                }
            }
        }

        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)
        {
            ((Timer) myObject).Stop();
            //if (MessageBox.Show("Unlicensed version of QueryPanel control!\r\nDo you want to register it now?", "EasyQuery.NET library", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //{
            //    Process.Start("http://devtools.korzh.com/eq/dotnet/");
            //}
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

        [Browsable(false)]
        public ConditionRow ActiveRow
        {
            get
            {
                return (ConditionRow) base.ActiveRow;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
        public QPAppearance Appearance
        {
            get
            {
                return (QPAppearance) base.Appearance;
            }
            set
            {
                base.Appearance = value;
            }
        }

        public ValueItemList BoolValuesMenuList
        {
            get
            {
                return this.boolValuesMenuList;
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
                        this.FillEntityTree(this.entityTree);
                        if (this.query != null)
                        {
                            this.query.Model = this.model;
                            this.RefreshPanelByQuery();
                        }
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
                    if (this.query != null)
                    {
                        this.query.ConditionsChanged -= new ConditionsChangedEventHandler(this.DoQueryConditionsChanged);
                    }
                    this.query = value;
                    if (this.query != null)
                    {
                        this.query.ConditionsChanged += new ConditionsChangedEventHandler(this.DoQueryConditionsChanged);
                    }
                    else
                    {
                        this.Deactivate();
                    }
                }
            }
        }

        [Browsable(false)]
        public ConditionRowList Rows
        {
            get
            {
                return (ConditionRowList) base.Rows;
            }
        }

        public ValueItemList SpecDateValuesMenuList
        {
            get
            {
                return this.specDateValuesMenuList;
            }
        }

        public ValueItemList SpecTimeValuesMenuList
        {
            get
            {
                return this.specTimeValuesMenuList;
            }
        }

        internal protected class AdditionRow : XRow
        {
            private ListXElement baseElement;
            private QueryPanel parentPanel;

            public AdditionRow(QueryPanel parentPanel) : base(false)
            {
                base.Parent = parentPanel;
                this.parentPanel = parentPanel;
                this.baseElement = new AdditionRowBaseElement(parentPanel);
                this.baseElement.ListName = "EntityTree";
                this.baseElement.EmptyValueText = this.RowText;
                base.Elements.Add(this.baseElement);
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
                    return ("[" + this.parentPanel.Texts.Get("ClickToAdd") + "]");
                }
            }

            protected class AdditionRowBaseElement : ListXElement
            {
                private QueryPanel parentPanel;

                public AdditionRowBaseElement(QueryPanel parentPanel)
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
                    return ((QueryPanel.AdditionRow) base.ParentRow).RowText;
                }

                protected override void OnContentChanged(bool valueChanged, bool textChanged)
                {
                    this.parentPanel.CoreAddSimpleConditionThroughUI(base.Value);
                    base.SetContentSilent(string.Empty, string.Empty);
                }
            }
        }

        public class ConditionRow : XRow
        {
            protected ConditionButton button;
            protected internal Korzh.EasyQuery.Query.Condition condition;
            protected internal QueryPanel parentPanel;
            private bool refreshing;

            public ConditionRow(QueryPanel aPanel, Korzh.EasyQuery.Query.Condition aCondition) : this(aPanel, aCondition, true)
            {
            }

            public ConditionRow(QueryPanel aPanel, Korzh.EasyQuery.Query.Condition aCondition, bool useCheckBox) : base("", useCheckBox)
            {
                this.parentPanel = aPanel;
                this.condition = aCondition;
                this.button = new ConditionButton(this);
                this.FillButtonMenu();
                base.Elements.Add(this.button);
            }

            protected override void ApplyElementFormats(XElement element)
            {
                base.ApplyElementFormats(element);
                if ((element is EditXElement) && (this.parentPanel.Appearance.EmptyEditText != ""))
                {
                    element.EmptyValueText = this.parentPanel.Appearance.EmptyEditText;
                }
                else if (((element is ListXElement) && !(element is ButtonListXElement)) && (this.parentPanel.Appearance.EmptyListText != ""))
                {
                    element.EmptyValueText = this.parentPanel.Appearance.EmptyListText;
                }
            }

            protected virtual void CoreRefreshByCondition()
            {
            }

            protected virtual void FillButtonMenu()
            {
                this.button.Items = null;
                this.button.Items = this.parentPanel.condButtonMenuList;
            }

            protected override void OnEnableChange()
            {
                this.Refreshing = true;
                try
                {
                    this.Condition.Enabled = base.Enabled;
                }
                finally
                {
                    this.Refreshing = false;
                }
            }

            internal void RefreshByCondition()
            {
                if (!this.Refreshing)
                {
                    this.Refreshing = true;
                    try
                    {
                        this.CoreRefreshByCondition();
                        this.Level = this.Condition.Level - 1;
                        base.Enabled = this.Condition.Enabled;
                    }
                    finally
                    {
                        this.Refreshing = false;
                    }
                }
            }

            protected void ResumeRefresh()
            {
                this.Refreshing = false;
            }

            protected void SuppressRefresh()
            {
                this.Refreshing = true;
            }

            public Korzh.EasyQuery.Query.Condition Condition
            {
                get
                {
                    return this.condition;
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

            internal protected class ConditionButton : ButtonListXElement
            {
                private QueryPanel.ConditionRow row;

                public ConditionButton(QueryPanel.ConditionRow row) : base("")
                {
                    this.row = row;
                }

                protected override string CoreGetTextAdjustedByValue(string value)
                {
                    string emptyValueText = base.EmptyValueText;
                    if (((this.row != null) && (this.row.Condition != null)) && ((this.row.parentPanel != null) && this.row.parentPanel.Appearance.ShowRowNum))
                    {
                        emptyValueText = this.row.Condition.FullNum;
                    }
                    return emptyValueText;
                }
            }
        }

        public class ConditionRowList : XRowList
        {
            public ConditionRowList(QueryPanel queryPanel) : base(queryPanel)
            {
            }

            public int IndexByCondition(Query.Condition cond)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].Condition == cond)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public QueryPanel.ConditionRow this[int index]
            {
                get
                {
                    return (QueryPanel.ConditionRow) base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
        }

        public enum EditModeKind
        {
            All,
            FixedConditions,
            FixedExpressions,
            ValuesOnly,
            None
        }

        public class Error : Exception
        {
            public Error(string message) : base(message)
            {
            }
        }

        public class PredicateRow : QueryPanel.ConditionRow
        {
            private ListXElement linkElement;
            private TextXElement textElement1;
            private TextXElement textElement2;

            public PredicateRow(QueryPanel qpanel, Korzh.EasyQuery.Query.Predicate condition) : this(qpanel, condition, true)
            {
            }

            public PredicateRow(QueryPanel qpanel, Korzh.EasyQuery.Query.Predicate condition, bool useCheckBox) : base(qpanel, condition, useCheckBox)
            {
                string str = this.getPredicateRowText();
                int index = str.IndexOf("<lt>");
                if (index < 0)
                {
                    throw new QueryPanel.Error("Wrong format of bracket text");
                }
                if (index > 0)
                {
                    this.textElement1 = new TextXElement();
                    this.textElement1.Value = str.Substring(0, index);
                    base.Elements.Add(this.textElement1);
                }
                this.linkElement = new ListXElement();
                this.linkElement.Items = base.parentPanel.predicateMenuList;
                this.linkElement.Value = "any";
                this.linkElement.ContentChanged += new ContentChangedEventHandler(this.LinkingChanged);
                base.Elements.Add(this.linkElement);
                this.textElement2 = new TextXElement();
                this.textElement2.Value = str.Substring(index + 4);
                this.textElement2.Text = this.textElement2.Value;
                base.Elements.Add(this.textElement2);
            }

            protected override void CoreRefreshByCondition()
            {
                if (this.Predicate.Linking == Query.Condition.LinkType.Any)
                {
                    this.linkElement.Value = "any";
                }
                else
                {
                    this.linkElement.Value = "all";
                }
            }

            protected virtual string getPredicateRowText()
            {
                return base.parentPanel.Texts.Get("PredicateTitle");
            }

            protected internal virtual void LinkingChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    this.Predicate.LinkingStr = element.Value;
                }
            }

            public Korzh.EasyQuery.Query.Predicate Predicate
            {
                get
                {
                    return (Korzh.EasyQuery.Query.Predicate) base.Condition;
                }
            }
        }

        [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
        public class QPAppearance : XPanel.XAppearance
        {
            private Color additionRowColor;
            private Color attrColor;
            private string attrElementFormat;
            private QueryPanel.EditModeKind editMode;
            private string emptyEditText;
            private string emptyListText;
            private Color exprColor;
            private bool hideBracketMenuItem;
            private Color operatorColor;
            private bool showRootRow;
            private bool showRowNum;

            public QPAppearance(QueryPanel parent) : base(parent)
            {
                this.showRootRow = true;
                this.attrElementFormat = "{entity} {attr}";
                this.emptyEditText = "";
                this.emptyListText = "";
                this.additionRowColor = Color.Navy;
                this.attrColor = Color.Blue;
                this.operatorColor = Color.Blue;
                this.exprColor = Color.Blue;
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

            [DefaultValue(typeof(Color), "Blue")]
            public Color AttrColor
            {
                get
                {
                    return this.attrColor;
                }
                set
                {
                    if (this.attrColor != value)
                    {
                        this.attrColor = value;
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
                        this.ParentPanel.ApplyFormats();
                    }
                }
            }

            public QueryPanel.EditModeKind EditMode
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

            public string EmptyEditText
            {
                get
                {
                    return this.emptyEditText;
                }
                set
                {
                    if (this.emptyEditText != value)
                    {
                        this.emptyEditText = value;
                        this.ParentPanel.ApplyFormats();
                    }
                }
            }

            public string EmptyListText
            {
                get
                {
                    return this.emptyListText;
                }
                set
                {
                    if (this.emptyListText != value)
                    {
                        this.emptyListText = value;
                        this.ParentPanel.ApplyFormats();
                    }
                }
            }

            [DefaultValue(typeof(Color), "Blue")]
            public Color ExprColor
            {
                get
                {
                    return this.exprColor;
                }
                set
                {
                    if (this.exprColor != value)
                    {
                        this.exprColor = value;
                        if (this.ParentPanel != null)
                        {
                            this.ParentPanel.ApplyFormats();
                        }
                    }
                }
            }

            [DefaultValue(false)]
            public bool HideBracketMenuItem
            {
                get
                {
                    return this.hideBracketMenuItem;
                }
                set
                {
                    this.hideBracketMenuItem = value;
                    this.ParentPanel.ApplyFormats();
                }
            }

            [DefaultValue(typeof(Color), "Blue")]
            public Color OperatorColor
            {
                get
                {
                    return this.operatorColor;
                }
                set
                {
                    if (this.operatorColor != value)
                    {
                        this.operatorColor = value;
                        if (this.ParentPanel != null)
                        {
                            this.ParentPanel.ApplyFormats();
                        }
                    }
                }
            }

            [Browsable(false)]
            public QueryPanel ParentPanel
            {
                get
                {
                    return (QueryPanel) base.parent;
                }
            }

            public bool ShowRootRow
            {
                get
                {
                    return this.showRootRow;
                }
                set
                {
                    if (this.showRootRow != value)
                    {
                        this.showRootRow = value;
                        this.ParentPanel.RefreshRootRow();
                    }
                }
            }

            [DefaultValue(false)]
            public bool ShowRowNum
            {
                get
                {
                    return this.showRowNum;
                }
                set
                {
                    if (this.showRowNum != value)
                    {
                        this.showRowNum = value;
                        this.ParentPanel.ApplyFormats();
                    }
                }
            }
        }

        internal protected class RootRow : QueryPanel.PredicateRow
        {
            public RootRow(QueryPanel qpanel, Query.Predicate condition) : base(qpanel, condition, false)
            {
                this.AllowShifting = false;
            }

            protected override void FillButtonMenu()
            {
                base.button.Items = base.parentPanel.rootButtonMenuList;
            }

            protected override string getPredicateRowText()
            {
                return base.parentPanel.Texts.Get("RootPredicateTitle");
            }
        }

        public class SimpleConditionRow : QueryPanel.ConditionRow
        {
            private XElement baseElement;
            private XElement operatorElement;

            public SimpleConditionRow(QueryPanel qpanel, Korzh.EasyQuery.Query.SimpleCondition condition) : base(qpanel, condition)
            {
            }

            protected override void ApplyElementFormats(XElement element)
            {
                base.ApplyElementFormats(element);
                if (element == this.baseElement)
                {
                    element.TextColor = base.parentPanel.Appearance.AttrColor;
                }
                else if (element == this.operatorElement)
                {
                    element.TextColor = base.parentPanel.Appearance.OperatorColor;
                }
                else if ((element.Data != null) && (element.Data is Expression))
                {
                    element.TextColor = base.parentPanel.Appearance.ExprColor;
                }
            }

            protected internal virtual void BaseElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    Expression data = (Expression) element.Data;
                    data.Value = element.Value;
                }
            }

            protected virtual void BaseElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                EntityAttrExpr baseExpr = (EntityAttrExpr) this.SimpleCondition.BaseExpr;
                DataModel.EntityAttr attribute = baseExpr.Attribute;
                if (base.parentPanel.Appearance.AttrElementFormat != string.Empty)
                {
                    string str = base.parentPanel.Appearance.AttrElementFormat.Replace("{attr}", attribute.Caption);
                    e.Text = str.Replace("{entity}", attribute.Entity.GetFullName(".")).Trim();
                }
                else
                {
                    e.Text = attribute.Caption;
                }
                base.parentPanel.PanelToolTip.SetToolTip(((XElement) sender).ElementControl, attribute.Description);
            }

            private string ConvertDataType(DataType dataType)
            {
                switch (dataType)
                {
                    case DataType.Byte:
                    case DataType.Word:
                    case DataType.Int:
                    case DataType.Int64:
                    case DataType.Autoinc:
                        return "INTEGER";

                    case DataType.Float:
                    case DataType.Currency:
                    case DataType.BCD:
                        return "FLOAT";
                }
                return "TEXT";
            }

            protected override void CoreApplyFormats()
            {
                base.CoreApplyFormats();
                QueryPanel.EditModeKind editMode = base.parentPanel.Appearance.EditMode;
                foreach (XElement element in base.Elements)
                {
                    if (element == this.baseElement)
                    {
                        element.ReadOnly = (editMode != QueryPanel.EditModeKind.All) && (editMode != QueryPanel.EditModeKind.FixedConditions);
                    }
                    else
                    {
                        if (element == this.operatorElement)
                        {
                            element.ReadOnly = (editMode == QueryPanel.EditModeKind.ValuesOnly) || (editMode == QueryPanel.EditModeKind.None);
                            continue;
                        }
                        element.ReadOnly = editMode == QueryPanel.EditModeKind.None;
                    }
                }
            }

            protected override void CoreElementAltMenuClick(XElement sender, ValueItem item)
            {
                string str;
                int index = this.SimpleCondition.Expressions.IndexOf(sender.Data);
                if ((index >= 0) && ((str = item.Value) != null))
                {
                    if (!(str == "ALT_ATTR"))
                    {
                        if (str == "ALT_CONSTANT")
                        {
                            this.SimpleCondition.RecreateValueExpr(index);
                        }
                    }
                    else
                    {
                        DataModel aModel = this.SimpleCondition.Model;
                        this.SimpleCondition.Expressions[index] = new EntityAttrExpr(aModel, aModel.GetDefaultUICAttribute());
                    }
                }
            }

            protected override void CoreRefreshByCondition()
            {
                base.BeginUpdate();
                try
                {
                    EntityAttrExpr baseExpr = (EntityAttrExpr) this.SimpleCondition.BaseExpr;
                    DataModel.EntityAttr attribute = baseExpr.Attribute;
                    for (int i = base.Elements.Count - 1; i > 0; i--)
                    {
                        if (((base.Elements[i] != base.button) && (base.Elements[i] != this.operatorElement)) && (base.Elements[i] != this.baseElement))
                        {
                            base.Elements.RemoveAt(i);
                        }
                    }
                    DisplayFormatParser parser = new DisplayFormatParser();
                    parser.Start(this.SimpleCondition.Operator.DisplayFormat);
                    while (parser.Next())
                    {
                        if (parser.Token == DisplayFormatParser.TokenType.Operator)
                        {
                            if (this.operatorElement == null)
                            {
                                this.operatorElement = new ListXElement();
                                this.operatorElement.ContentChanged += new ContentChangedEventHandler(this.OperatorElementContentChanged);
                                this.operatorElement.TextAdjusting += new TextAdjustingEventHandler(this.OperatorElementTextAdjusting);
                                base.Elements.Add(this.operatorElement);
                            }
                            this.operatorElement.Data = this.SimpleCondition.Operator;
                            base.parentPanel.FillOperatorElementByAttribute(attribute, (ListXElement) this.operatorElement);
                            this.operatorElement.Value = this.SimpleCondition.Operator.ID;
                        }
                        else
                        {
                            if (parser.Token == DisplayFormatParser.TokenType.Expression)
                            {
                                Expression expr = this.SimpleCondition.Expressions[parser.ExprNum - 1];
                                if (expr == this.SimpleCondition.BaseExpr)
                                {
                                    if (this.baseElement == null)
                                    {
                                        this.baseElement = new ListXElement();
                                        base.parentPanel.FillElementByEntityTree((ListXElement) this.baseElement);
                                        this.baseElement.ContentChanged += new ContentChangedEventHandler(this.BaseElementContentChanged);
                                        this.baseElement.TextAdjusting += new TextAdjustingEventHandler(this.BaseElementTextAdjusting);
                                        base.Elements.Add(this.baseElement);
                                    }
                                    this.baseElement.Data = baseExpr;
                                    this.baseElement.Value = attribute.ID;
                                }
                                else
                                {
                                    XElement element = null;
                                    if (expr is EntityAttrExpr)
                                    {
                                        element = new ListXElement();
                                        base.parentPanel.FillElementByEntityTree((ListXElement) element);
                                        element.TextAdjusting += new TextAdjustingEventHandler(this.ValueAttrElementTextAdjusting);
                                        element.Data = expr;
                                        element.Value = ((EntityAttrExpr) expr).Attribute.ID;
                                    }
                                    else
                                    {
                                        element = this.CreateValueElement(expr.DataType);
                                        element.NeedValidate = true;
                                        element.NeedTextAdjustingOnApplyFormats = false;
                                        element.SetContentSilent(expr.Value, expr.Text);
                                        element.Data = expr;
                                    }
                                    element.ContentChanged += new ContentChangedEventHandler(this.ExprElementContentChanged);
                                    if (element is LabelXElement)
                                    {
                                        this.FillElementAltMenu((LabelXElement) element, expr);
                                    }
                                    base.Elements.Add(element);
                                    expr.SetContentSilent(element.Value, element.Text);
                                }
                                continue;
                            }
                            if (parser.Token == DisplayFormatParser.TokenType.Text)
                            {
                                base.AddTextElement(parser.TokenText);
                            }
                        }
                    }
                }
                finally
                {
                    base.EndUpdate();
                }
            }

            private XElement CreateValueElement(DataType dataType)
            {
                XElement element = null;
                if (this.SimpleCondition.BaseExpr is EntityAttrExpr)
                {
                    EntityAttrExpr baseExpr = (EntityAttrExpr) this.SimpleCondition.BaseExpr;
                    DataModel.EntityAttr attribute = baseExpr.Attribute;
                    ValueEditor valueEditor = attribute.GetValueEditor(this.SimpleCondition.Operator);
                    if ((valueEditor is DateTimeValueEditor) && (this.SimpleCondition.Operator.ValueKind == DataKind.List))
                    {
                        element = new EditXElement();
                    }
                    else
                    {
                        element = base.CreateElementByXmlText(valueEditor.XmlDefinition);
                    }
                    if (element == null)
                    {
                        element = new EditXElement();
                    }
                    if (element is EditXElement)
                    {
                        ((EditXElement) element).MaxLength = attribute.Size;
                    }
                }
                else
                {
                    element = new EditXElement();
                }
                element.AllowList = this.SimpleCondition.Operator.ValueKind == DataKind.List;
                if (element is EditXElement)
                {
                    element.SubType = this.ConvertDataType(dataType);
                }
                if (element is ListXElement)
                {
                    element.EmptyValueText = base.parentPanel.Texts.Get("MsgEmptyListValue");
                    ((ListXElement) element).AutoSelectFirstItem = true;
                }
                else
                {
                    element.EmptyValueText = base.parentPanel.Texts.Get("MsgEmptyScalarValue");
                }
                CreateValueElementEventArgs e = new CreateValueElementEventArgs(this, dataType);
                e.Element = element;
                base.parentPanel.OnCreateValueElement(e);
                if (e.Element != element)
                {
                    element = e.Element;
                }
                return element;
            }

            protected internal virtual void ExprElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing)
                {
                    if (e.ValueChanged)
                    {
                        XElement element = (XElement) sender;
                        Expression data = (Expression) element.Data;
                        data.Value = element.Value;
                    }
                    if (e.TextChanged)
                    {
                        base.SuppressRefresh();
                        try
                        {
                            XElement element2 = (XElement) sender;
                            Expression expression2 = (Expression) element2.Data;
                            expression2.Text = element2.Text;
                        }
                        finally
                        {
                            base.ResumeRefresh();
                        }
                    }
                }
            }

            protected void FillElementAltMenu(LabelXElement element, Expression expr)
            {
                ValueItemList items = new ValueItemList();
                ValueItem item = new ValueItem("Constant expression", "ALT_CONSTANT");
                item.Enabled = !(expr is ConstExpr);
                items.Add(item);
                item = new ValueItem("Attribute", "ALT_ATTR");
                item.Enabled = !(expr is EntityAttrExpr);
                items.Add(item);
                element.FillAltMenu(items);
            }

            protected internal virtual void OperatorElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    this.SimpleCondition.Operator = base.parentPanel.Model.Operators.FindByID(element.Value);
                }
            }

            protected virtual void OperatorElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                DataModel.Operator @operator = this.SimpleCondition.Operator;
                e.Text = @operator.MainText;
            }

            protected virtual void ValueAttrElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                int index = this.SimpleCondition.Expressions.IndexOf(((XElement) sender).Data);
                if (index >= 0)
                {
                    EntityAttrExpr expr = (EntityAttrExpr) this.SimpleCondition.Expressions[index];
                    DataModel.EntityAttr attribute = expr.Attribute;
                    if (base.parentPanel.Appearance.AttrElementFormat != string.Empty)
                    {
                        string str = base.parentPanel.Appearance.AttrElementFormat.Replace("{attr}", attribute.Caption);
                        e.Text = str.Replace("{entity}", attribute.Entity.GetFullName(".")).Trim();
                    }
                    else
                    {
                        e.Text = attribute.Caption;
                    }
                    base.parentPanel.PanelToolTip.SetToolTip(((XElement) sender).ElementControl, attribute.Description);
                }
            }

            public Korzh.EasyQuery.Query.SimpleCondition SimpleCondition
            {
                get
                {
                    return (Korzh.EasyQuery.Query.SimpleCondition) base.condition;
                }
            }
        }

        public class SqlListXElement : ListXElement
        {
            private bool listPopulated;
            private string sql = "";

            protected override string CoreGetTextAdjustedByValue(string newValue)
            {
                if (!this.listPopulated)
                {
                    this.PopulateList();
                }
                return base.CoreGetTextAdjustedByValue(newValue);
            }

            protected override void LinkClickedHandler(object sender, LinkLabelLinkClickedEventArgs e)
            {
                if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
                {
                    if (!this.listPopulated)
                    {
                        this.PopulateList();
                    }
                    if (base.Items.Count != 0)
                    {
                        base.DropDown();
                    }
                }
                else
                {
                    this.OnAltClick(EventArgs.Empty);
                }
            }

            public override void ParseXmlNode(XmlNode node)
            {
                XmlAttribute attribute = node.Attributes["ControlType"];
                if (attribute != null)
                {
                    base.RecreateListControl(attribute.Value);
                }
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.LocalName == "SQL")
                    {
                        this.SetSql(node2.InnerText);
                    }
                }
            }

            protected virtual void PopulateList()
            {
                ValueItemList items = base.Items;
                if (base.ParentRow != null)
                {
                    base.ParentRow.ElementAction(this, "SqlListRequest", this.sql);
                }
                if ((base.Items.Count > 0) && (items != base.Items))
                {
                    this.listPopulated = true;
                }
            }

            protected void SetSql(string newSql)
            {
                if (this.sql != newSql)
                {
                    this.sql = newSql;
                    this.listPopulated = false;
                    base.Items.Clear();
                }
            }

            public string SQL
            {
                get
                {
                    return this.sql;
                }
            }

            public static string TagName
            {
                get
                {
                    return "SQLLIST";
                }
            }

            public class Creator : XElement.ICreator
            {
                public XElement Create()
                {
                    return new QueryPanel.SqlListXElement();
                }

                public string TagName
                {
                    get
                    {
                        return QueryPanel.SqlListXElement.TagName;
                    }
                }
            }
        }

        public class SubQueryXElement : LabelXElement
        {
            private SubQueryForm formSubQuery;

            protected override string CalcNewValue()
            {
                if (this.formSubQuery != null)
                {
                    return this.formSubQuery.ResultXml;
                }
                return "";
            }

            protected override string CoreGetTextAdjustedByValue(string newValue)
            {
                if (newValue != string.Empty)
                {
                    return "--- Sub Query ---";
                }
                return "--- Enter Sub Query ---";
            }

            protected override void HideControl()
            {
            }

            protected override void LinkClickedHandler(object sender, LinkLabelLinkClickedEventArgs e)
            {
                if (!base.ReadOnly)
                {
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        this.OnAltClick(EventArgs.Empty);
                    }
                    else
                    {
                        base.DropDown();
                        base.RollUp(this.formSubQuery.DialogResult == DialogResult.OK);
                    }
                }
            }

            public override void ParseXmlNode(XmlNode node)
            {
            }

            protected override void ShowControl()
            {
                if (this.formSubQuery == null)
                {
                    this.formSubQuery = new SubQueryForm();
                    this.formSubQuery.Init((QueryPanel) base.ParentPanel);
                }
                this.formSubQuery.InitQuery(base.Value);
                this.formSubQuery.ShowDialog();
            }

            public static string TagName
            {
                get
                {
                    return "SUBQUERY";
                }
            }

            public class Creator : XElement.ICreator
            {
                public XElement Create()
                {
                    return new QueryPanel.SubQueryXElement();
                }

                public string TagName
                {
                    get
                    {
                        return QueryPanel.SubQueryXElement.TagName;
                    }
                }
            }
        }
    }
}

