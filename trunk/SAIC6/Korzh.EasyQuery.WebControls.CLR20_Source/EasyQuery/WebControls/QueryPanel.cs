namespace Korzh.EasyQuery.WebControls
{
    using Korzh.EasyQuery;
    using Korzh.WebControls.XControls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;

    [ToolboxBitmap(typeof (QueryPanel))]
    public class QueryPanel : XPanel
    {
        private bool active;
        private AdditionRow addRow;
        internal ValueItemList boolValuesMenuList;
        internal ValueItemList condButtonMenuList;
        private EditModeKind editMode;
        private ValueItemList entityTree;
        private DataModel model;
        internal ValueItemList predicateMenuList;
        private Korzh.EasyQuery.Query query;
        internal ValueItemList rootButtonMenuList;
        private RootRow rootRow;
        private Type rsType;
        internal ValueItemList specDateValuesMenuList;
        private bool specListsInitialized;
        internal ValueItemList specTimeValuesMenuList;
        private bool useListCache = true;

        public event CreateValueElementEventHandler CreateValueElement;

        public event ListRequestEventHandler ListRequest;

        public event SqlExecuteEventHandler SqlExecute;

        public event ValueRequestEventHandler ValueRequest;

        static QueryPanel()
        {
            XElement.Register(new SqlListXElement.Creator());
        }

        public QueryPanel()
        {
            ResourceManager resources = new ResourceManager("Korzh.EasyQuery.WebControls.QueryPanel",
                                                            typeof (QueryPanel).Assembly);
            base.Texts.LoadFromResources(resources);
            this.rsType = base.GetType();
            this.Appearance.RowButtonTooltip = base.Texts.Get("QPRowButtonTitle");
            this.ScrollBars = ScrollBars.Auto;
            this.rootRow = null;
        }

        protected void Activate()
        {
            if ((this.model != null) && (this.query != null))
            {
                this.RefillEntityTree();
                this.RecreateAdditionRow();
                this.RecreateRootRow();
                this.active = true;
            }
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
            int rowIndex = (previous != null) ? this.IndexOfNextSameLevelRow(previous) : this.Rows.Count;
            this.CoreAddPredicate(parent, condIndex, rowIndex);
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

        private void AddSimpleCondition()
        {
            this.CheckDataModel();
            this.CheckQuery();
            this.CoreAddSimpleCondition(this.Query.Root, this.Query.Root.Conditions.Count,
                                        this.Model.GetDefaultUICAttribute());
        }

        private void AddSimpleCondition(Korzh.EasyQuery.Query.Predicate parent, ConditionRow previous)
        {
            this.CheckDataModel();
            this.CheckQuery();
            int condIndex = (previous != null) ? (previous.Condition.Index + 1) : parent.Conditions.Count;
            this.CoreAddSimpleCondition(parent, condIndex, this.Model.GetDefaultUICAttribute());
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

        public void ClearListCache()
        {
            if (this.ListCache != null)
            {
                this.ListCache.Clear();
            }
        }

        protected void CoreAddPredicate(Korzh.EasyQuery.Query.Predicate parent, int condIndex, int rowIndex)
        {
            Korzh.EasyQuery.Query.Predicate predicate = this.query.AddPredicate(parent, condIndex);
            this.CoreAddSimpleCondition(predicate, 0, this.Model.GetDefaultUICAttribute());
        }

        protected virtual void CoreAddSimpleCondition(Korzh.EasyQuery.Query.Predicate parent, int condIndex,
                                                      DataModel.EntityAttr attr)
        {
            this.query.AddSimpleCondition(parent, condIndex, attr);
        }

        private void CoreFillEntityTree(ValueItemList listItems, DataModel.Entity parentEntity)
        {
            foreach (DataModel.Entity entity in parentEntity.SubEntities)
            {
                ValueItem item = new ValueItem(entity.Name, "", "");
                if (this.Appearance.ShowEntitiesAsTree)
                {
                    this.CoreFillEntityTree(item.SubItems, entity);
                    if (item.SubItems.Count > 0)
                    {
                        listItems.Add(item);
                    }
                }
                else
                {
                    this.CoreFillEntityTree(listItems, entity);
                }
            }
            foreach (DataModel.EntityAttr attr in parentEntity.Attributes)
            {
                if (!attr.UseInConditions)
                {
                    continue;
                }
                string text = null;
                if (this.Appearance.ShowEntitiesAsTree)
                {
                    text = attr.Caption;
                }
                else
                {
                    text = this.Appearance.AttrElementFormat.Replace("{attr}", attr.Caption).Replace("{entity}",
                                                                                                     attr.Entity.
                                                                                                         GetFullName("."));
                }
                ValueItem item2 = new ValueItem(text, attr.ID, "");
                listItems.Add(item2);
            }
        }

        protected override XPanel.XAppearance CreateAppearance()
        {
            return new QPAppearance();
        }

        protected virtual void CreateRootRow()
        {
            this.rootRow = new RootRow(this, this.Query.Root);
            this.rootRow.RefreshByCondition();
            this.AddRowsByPredicate(this.Query.Root, 0);
            this.EmbedRootRow();
        }

        protected override XRowList CreateRowList()
        {
            return new ConditionRowList(this);
        }

        protected override void DoAction(object sender, string actionName, object data)
        {
            ConditionRow previous = null;
            if (sender is ConditionRow.ConditionButton)
            {
                previous = (ConditionRow) ((ConditionRow.ConditionButton) sender).ParentRow;
            }
            Korzh.EasyQuery.Query.Predicate parent = (previous != null) ? previous.Condition.Parent : this.query.Root;
            if (string.Compare(actionName, "AddCondition", true) == 0)
            {
                this.AddSimpleCondition(parent, previous);
            }
            else if (string.Compare(actionName, "AddPredicate", true) == 0)
            {
                this.AddPredicate(parent, previous);
            }
            else if (string.Compare(actionName, "AddConditionInto", true) == 0)
            {
                Korzh.EasyQuery.Query.Predicate predicate2 = ((previous != null) &&
                                                              (previous.Condition is Korzh.EasyQuery.Query.Predicate))
                                                                 ? ((Korzh.EasyQuery.Query.Predicate) previous.Condition)
                                                                 : this.query.Root;
                this.AddSimpleCondition(predicate2, null);
            }
            else if (string.Compare(actionName, "AddPredicateInto", true) == 0)
            {
                Korzh.EasyQuery.Query.Predicate predicate3 = ((previous != null) &&
                                                              (previous.Condition is Korzh.EasyQuery.Query.Predicate))
                                                                 ? ((Korzh.EasyQuery.Query.Predicate) previous.Condition)
                                                                 : this.query.Root;
                this.AddPredicate(predicate3, null);
            }
            else if (string.Compare(actionName, "DeleteRow", true) == 0)
            {
                parent.Conditions.Remove(((ConditionRow) ((XElement) sender).ParentRow).Condition);
            }
            else if (string.Compare(actionName, "SqlListRequest", true) == 0)
            {
                SqlListXElement element = (SqlListXElement) sender;
                if (this.UseListCache)
                {
                    element.Items = (ValueItemList) this.ListCache[SqlListXElement.GetListIDBySQL(element.SQL)];
                }
                if (element.Items == null)
                {
                    element.Items = new ValueItemList(element.ListID);
                    SqlExecuteEventArgs e = new SqlExecuteEventArgs(element.SQL, element.Items);
                    e.ListItems.EmptyText = base.Texts.Get("MsgEmptyList");
                    this.OnSqlExecute(e);
                    element.Items = null;
                    element.Items = e.ListItems;
                    if (this.UseListCache)
                    {
                        this.UpdateListInCache(element.Items);
                    }
                }
            }
            else if (string.Compare(actionName, "ValueRequest", true) == 0)
            {
                XElement element2 = (XElement) sender;
                ValueRequestEventArgs args2 = new ValueRequestEventArgs(element2.Value, element2.Text,
                                                                        element2.Data.ToString());
                this.OnValueRequest(args2);
                element2.Value = args2.Value;
                element2.Text = args2.Text;
            }
            else
            {
                base.DoAction(sender, actionName, data);
            }
        }

        protected override void DoAddRow()
        {
            base.DoAddRow();
            this.AddSimpleCondition();
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
                ValueItemList listItems = new ValueItemList(listName);
                ListRequestEventArgs e = new ListRequestEventArgs(element, listName, listItems);
                e.ListItems.EmptyText = base.Texts.Get("MsgEmptyList");
                this.OnListRequest(e);
                element.Items = e.ListItems;
            }
        }

        protected virtual void DoQueryConditionsChanged(object sender, ConditionsChangeEventArgs e)
        {
            if (e.What == ChangeType.Update)
            {
                int num = this.Rows.IndexByCondition(e.Condition);
                if (num >= 0)
                {
                    this.Rows[num].RefreshByCondition();
                }
            }
            else
            {
                this.RefreshPanelByQuery();
            }
        }

        protected internal void EmbedRootRow()
        {
            if (this.Appearance.ShowRootRow)
            {
                if (!this.Rows.Contains(this.rootRow))
                {
                    this.Rows.Insert(0, this.rootRow);
                }
            }
            else
            {
                this.Rows.Remove(this.rootRow);
            }
        }

        private void FillElementByEntityTree(ListXElement element)
        {
            if ((this.entityTree.Count == 0) && (this.model != null))
            {
                this.CoreFillEntityTree(this.entityTree, this.model.EntityRoot);
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
            ValueItemList list = new ValueItemList("attr" + Utils.StrToIdentifier(attr.ID) + "_operators");
            foreach (DataModel.Operator @operator in attr.Operations)
            {
                ValueItem item = new ValueItem(@operator.Caption, @operator.ID);
                list.Add(item);
            }
            operatorElement.Items = list;
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

        private int IndexOfNextSameLevelRow(XRow row)
        {
            int num = row.Index + 1;
            while ((num < this.Rows.Count) && (this.Rows[num].Level > row.Level))
            {
                num++;
            }
            return num;
        }

        private void InitSpecialLists()
        {
            this.entityTree = new ValueItemList(this.ID + "_entities");
            this.rootButtonMenuList = new ValueItemList(this.ID + "_rootMenu");
            this.predicateMenuList = new ValueItemList(this.ID + "_predicateMenu");
            this.condButtonMenuList = new ValueItemList(this.ID + "_conditionMenu");
            this.RefillPanelMenus();
            this.boolValuesMenuList = new ValueItemList(this.ID + "_boolvaluesMenu");
            this.boolValuesMenuList.Add(new ValueItem("False", "${false}", ""));
            this.boolValuesMenuList.Add(new ValueItem("True", "${true}", ""));
            this.specDateValuesMenuList = new ValueItemList(this.ID + "_specDateValuesMenu");
            this.specDateValuesMenuList.Add(new ValueItem("Today", "${Today}", ""));
            this.specDateValuesMenuList.Add(new ValueItem("Yesterday", "${Yesterday}", ""));
            this.specDateValuesMenuList.Add(new ValueItem("Tomorrow", "${Tomorrow}", ""));
            this.specDateValuesMenuList.Add(new ValueItem("First day of month", "${FirstDayOfMonth}", ""));
            this.specDateValuesMenuList.Add(new ValueItem("First day of year", "${FirstDayOfYear}", ""));
            this.specTimeValuesMenuList = new ValueItemList(this.ID + "_specTimeValuesMenu");
            this.specTimeValuesMenuList.Add(new ValueItem("Now", "${Now}", ""));
            this.specTimeValuesMenuList.Add(new ValueItem("This hour start", "${HourStart}", ""));
            this.specTimeValuesMenuList.Add(new ValueItem("Midnight", "${Midnight}", ""));
            this.specTimeValuesMenuList.Add(new ValueItem("Noon", "${Noon}", ""));
            this.specListsInitialized = true;
        }

        protected internal virtual void OnCreateValueElement(CreateValueElementEventArgs e)
        {
            if (this.CreateValueElement != null)
            {
                this.CreateValueElement(this, e);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.InitSpecialLists();
        }

        protected virtual void OnListRequest(ListRequestEventArgs e)
        {
            if (this.ListRequest != null)
            {
                this.ListRequest(this, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.Page.IsPostBack && this.UseListCache)
            {
                this.ListCache.Clear();
            }
            if (!this.active)
            {
                this.Activate();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.addRow.RowControl.Visible = this.EditMode == EditModeKind.All;
            this.RefillPanelMenus();
            base.OnPreRender(e);
            //this.BackImageUrl = this.Page.ClientScript.GetWebResourceUrl(this.rsType,
            //                                                             "Korzh.EasyQuery.WebControls.Resources.Watermark.gif");
        }

        protected override void OnRowAdded(XRow row)
        {
            base.OnRowAdded(row);
        }

        protected override void OnRowListChanged()
        {
        }

        protected virtual void OnSqlExecute(SqlExecuteEventArgs e)
        {
            if (this.SqlExecute != null)
            {
                this.SqlExecute(this, e);
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (this.query != null)
            {
                this.query.ConditionsChanged -= new ConditionsChangedEventHandler(this.DoQueryConditionsChanged);
            }
        }

        protected virtual void OnValueRequest(ValueRequestEventArgs e)
        {
            if (this.ValueRequest != null)
            {
                this.ValueRequest(this, e);
            }
        }

        protected virtual void RecreateAdditionRow()
        {
            if (this.addRow == null)
            {
                this.addRow = new AdditionRow(this);
            }
            base.PlaceRowAt(this.addRow, 0);
        }

        private void RecreateRootRow()
        {
            if (this.rootRow != null)
            {
                this.Rows.Clear();
            }
            this.CreateRootRow();
        }

        private void RefillEntityTree()
        {
            this.entityTree.Clear();
            if (this.model != null)
            {
                this.CoreFillEntityTree(this.entityTree, this.model.EntityRoot);
            }
        }

        private void RefillPanelMenus()
        {
            this.rootButtonMenuList.Clear();
            if (this.EditMode == EditModeKind.All)
            {
                this.rootButtonMenuList.Add(new ValueItem(base.Texts.Get("AddConditionInto"), "AddConditionInto",
                                                          "AddConditionInto"));
                this.rootButtonMenuList.Add(new ValueItem(base.Texts.Get("AddPredicateInto"), "AddPredicateInto",
                                                          "AddPredicateInto"));
            }
            this.predicateMenuList.Clear();
            this.predicateMenuList.Add(new ValueItem(base.Texts.Get("LinkTypeAll"), "all"));
            this.predicateMenuList.Add(new ValueItem(base.Texts.Get("LinkTypeAny"), "any"));
            this.condButtonMenuList.Clear();
            if (this.EditMode == EditModeKind.All)
            {
                this.condButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdAddConditionAfter"), "AddCondition",
                                                          "AddCondition"));
                this.condButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdAddPredicateAfter"), "AddPredicate",
                                                          "AddPredicate"));
                this.condButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdDeleteRow"), "DeleteRow", "DeleteRow"));
            }
        }

        private void RefreshPanelByQuery()
        {
            this.CheckDataModel();
            this.CheckQuery();
            this.RecreateRootRow();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            base.Render(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Style,
                                string.Format(
                                    "border-width:1px;border-style:Solid;color:Navy;background-color:Lavender;height:18px;width:{0};text-align:right;font-size:8pt;font-family:Verdana",
                                    this.Width.ToString()));
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            //writer.Write(" :: ");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "http://www.bsd.com");
            writer.AddAttribute(HtmlTextWriterAttribute.Target, "_blank");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            //writer.Write("Powered by EasyQuery.NET");
            writer.RenderEndTag();
            //writer.Write(" :: ");
            writer.RenderEndTag();
            writer.RenderEndTag();
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            base.RenderChildren(writer);
            if (this.addRow != null)
            {
                this.addRow.RenderRow(writer);
            }
        }

        public void UpdateListInCache(ValueItemList items)
        {
            Hashtable listCache = this.ListCache;
            if (listCache != null)
            {
                listCache[items.ID] = items;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance"),
         PersistenceMode(PersistenceMode.Attribute)]
        public QPAppearance Appearance
        {
            get { return (QPAppearance) base.Appearance; }
        }

        public EditModeKind EditMode
        {
            get { return this.editMode; }
            set
            {
                if (this.editMode != value)
                {
                    this.editMode = value;
                }
            }
        }

        protected Hashtable ListCache
        {
            get
            {
                object obj2 = null;
                if (this.Page != null)
                {
                    obj2 = this.Page.Session[this.UniqueID + "_ListCache"];
                    if (obj2 == null)
                    {
                        obj2 = new Hashtable();
                        this.Page.Session[this.UniqueID + "_ListCache"] = obj2;
                    }
                }
                return (Hashtable) obj2;
            }
        }

        public DataModel Model
        {
            get { return this.model; }
            set
            {
                if (this.model != value)
                {
                    this.model = value;
                    if ((this.query != null) && (this.model != null))
                    {
                        this.query.Model = this.model;
                    }
                }
            }
        }

        public Korzh.EasyQuery.Query Query
        {
            get { return this.query; }
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
                        this.query.Model = this.model;
                        if ((this.model != null) && this.specListsInitialized)
                        {
                            this.Activate();
                        }
                        this.query.ConditionsChanged += new ConditionsChangedEventHandler(this.DoQueryConditionsChanged);
                    }
                }
            }
        }

        [Browsable(false)]
        public ConditionRowList Rows
        {
            get { return (ConditionRowList) base.Rows; }
        }

        [DefaultValue(true)]
        public bool UseListCache
        {
            get { return this.useListCache; }
            set
            {
                if (this.useListCache != value)
                {
                    this.useListCache = value;
                    if ((base.Site == null) || !base.Site.DesignMode)
                    {
                        this.ClearListCache();
                    }
                }
            }
        }

        protected internal class AdditionRow : XRow
        {
            private ListXElement baseElement;
            private QueryPanel parentPanel;

            public AdditionRow(QueryPanel parentPanel) : base(false)
            {
                this.parentPanel = parentPanel;
                base.ID = "ar";
                this.baseElement = new LabelListXElement();
                this.parentPanel.FillElementByEntityTree(this.baseElement);
                this.baseElement.PreRender += new EventHandler(this.BaseElementPreRender);
                this.baseElement.ContentChanged += new ContentChangedEventHandler(this.BaseElementContentChanged);
                this.baseElement.TextAdjusting += new TextAdjustingEventHandler(this.BaseElementTextAdjusting);
                this.baseElement.MenuStyle.ItemMinWidth = 200;
                this.baseElement.EmptyValueText = this.RowText;
                this.baseElement.Value = "";
                base.Elements.Add(this.baseElement);
            }

            protected virtual void BaseElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    this.parentPanel.AddFirstLevelSimpleCondition(element.Value);
                }
            }

            protected void BaseElementPreRender(object sender, EventArgs e)
            {
                ((XElement) sender).ForeColor = ((QueryPanel) base.Parent).Appearance.AdditionRowColor;
            }

            protected virtual void BaseElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                e.Text = this.RowText;
            }

            protected internal Panel RowControl
            {
                get { return base.rowControl; }
            }

            protected string RowText
            {
                get { return ("[" + this.parentPanel.Texts.Get("ClickToAdd") + "]"); }
            }
        }

        public class ConditionRow : XRow
        {
            protected ConditionButton button;
            protected internal Korzh.EasyQuery.Query.Condition condition;
            protected QueryPanel parentPanel;
            private bool refreshing;

            public ConditionRow(QueryPanel aPanel, Korzh.EasyQuery.Query.Condition aCondition)
                : this(aPanel, aCondition, true)
            {
            }

            public ConditionRow(QueryPanel aPanel, Korzh.EasyQuery.Query.Condition aCondition, bool useCheckBox)
                : base("", useCheckBox)
            {
                this.parentPanel = aPanel;
                this.condition = aCondition;
                this.button = new ConditionButton();
                this.button.Items = this.parentPanel.condButtonMenuList;
                base.Elements.Add(this.button);
            }

            protected override void ApplyElementFormats(XElement element)
            {
                base.ApplyElementFormats(element);
                element.ReadOnly = this.Condition.ReadOnly;
                if (element is ConditionButton)
                {
                    ((ConditionButton) element).MenuStyle.ItemMinWidth = 220;
                    if (this.parentPanel != null)
                    {
                        ((ConditionButton) element).ImageUrl = this.parentPanel.Appearance.RowButtonImageUrl;
                    }
                }
            }

            protected virtual void CoreRefreshByCondition()
            {
                this.Enabled = this.condition.Enabled;
                this.ReadOnly = this.condition.ReadOnly;
            }

            protected override void OnEnabledChange()
            {
                this.Condition.Enabled = this.Enabled;
            }

            public void RefreshByCondition()
            {
                if (!this.Refreshing)
                {
                    this.Refreshing = true;
                    try
                    {
                        this.CoreRefreshByCondition();
                        this.Level = this.Condition.Level - 1;
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

            protected void SupressRefresh()
            {
                this.Refreshing = true;
            }

            public Korzh.EasyQuery.Query.Condition Condition
            {
                get { return this.condition; }
            }

            protected internal bool Refreshing
            {
                get { return this.refreshing; }
                set { this.refreshing = value; }
            }

            protected internal class ConditionButton : ButtonListXElement
            {
                protected override string CoreGetTextAdjustedByValue(string newValue)
                {
                    return "";
                }

                protected override void PreRenderElementControl()
                {
                    base.PreRenderElementControl();
                    QueryPanel parentPanel = (QueryPanel) base.ParentPanel;
                    string str = (parentPanel != null) ? parentPanel.Appearance.RowButtonTooltip : "";
                    base.linkControl.Text = "ConditionButton";
                    base.linkControl.ToolTip = str;
                    if (base.ImageUrl == string.Empty)
                    {
                        Type type = typeof (QueryPanel.ConditionRow.ConditionButton);
                        base.linkControl.ImageUrl = this.Page.ClientScript.GetWebResourceUrl(type,
                                                                                             "Korzh.EasyQuery.WebControls.Resources.XRowButton20x16.gif");
                    }
                    else
                    {
                        base.linkControl.ImageUrl = base.ImageUrl;
                    }
                }
            }
        }

        public class ConditionRowList : XRowList
        {
            public ConditionRowList(QueryPanel parentPanel) : base(parentPanel)
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

            protected override void OnRowInserted(XRow newrow, int index)
            {
                base.OnRowInserted(newrow, index);
            }

            public QueryPanel.ConditionRow this[int index]
            {
                get { return (QueryPanel.ConditionRow) base[index]; }
                set { base[index] = value; }
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

            public PredicateRow(QueryPanel qpanel, Korzh.EasyQuery.Query.Predicate condition)
                : this(qpanel, condition, true)
            {
            }

            public PredicateRow(QueryPanel qpanel, Korzh.EasyQuery.Query.Predicate condition, bool useCheckBox)
                : base(qpanel, condition, useCheckBox)
            {
                string predicateRowText = this.GetPredicateRowText();
                int index = predicateRowText.IndexOf("<lt>");
                if (index < 0)
                {
                    throw new QueryPanel.Error("Wrong format of bracket text");
                }
                if (index > 0)
                {
                    this.textElement1 = new TextXElement();
                    this.textElement1.Value = predicateRowText.Substring(0, index);
                    base.Elements.Add(this.textElement1);
                }
                this.linkElement = new LabelListXElement();
                this.linkElement.Items = base.parentPanel.predicateMenuList;
                this.linkElement.ContentChanged += new ContentChangedEventHandler(this.LinkingChanged);
                base.Elements.Add(this.linkElement);
                this.textElement2 = new TextXElement();
                this.textElement2.Value = predicateRowText.Substring(index + 4);
                this.textElement2.Text = this.textElement2.Value;
                base.Elements.Add(this.textElement2);
            }

            protected override void CoreRefreshByCondition()
            {
                base.CoreRefreshByCondition();
                if (this.Predicate.Linking == Query.Condition.LinkType.Any)
                {
                    this.linkElement.Value = "any";
                }
                else
                {
                    this.linkElement.Value = "all";
                }
            }

            protected virtual string GetPredicateRowText()
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
                get { return (Korzh.EasyQuery.Query.Predicate) base.Condition; }
            }
        }

        [TypeConverter(typeof (ExpandableObjectConverter))]
        public class QPAppearance : XPanel.XAppearance
        {
            private Color exprColor = Color.Blue;

            [DefaultValue(typeof (Color), "Green"), NotifyParentProperty(true),
             TypeConverter(typeof (WebColorConverter))]
            public Color AdditionRowColor
            {
                get
                {
                    object obj2 = this.ViewState["AdditionRowColor"];
                    if (obj2 != null)
                    {
                        return (Color) obj2;
                    }
                    return Color.Green;
                }
                set
                {
                    if (this.AdditionRowColor != value)
                    {
                        this.ViewState["AdditionRowColor"] = value;
                    }
                }
            }

            [TypeConverter(typeof (WebColorConverter)), DefaultValue(typeof (Color), "Blue"), NotifyParentProperty(true)
            ]
            public Color AttrColor
            {
                get
                {
                    object obj2 = this.ViewState["AttrColor"];
                    if (obj2 != null)
                    {
                        return (Color) obj2;
                    }
                    return Color.Blue;
                }
                set
                {
                    if (this.AttrColor != value)
                    {
                        this.ViewState["AttrColor"] = value;
                    }
                }
            }

            [DefaultValue("{entity} {attr}"), NotifyParentProperty(true)]
            public string AttrElementFormat
            {
                get
                {
                    object obj2 = this.ViewState["AttrElementFormat"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return "{entity} {attr}";
                }
                set
                {
                    if (this.AttrElementFormat != value)
                    {
                        this.ViewState["AttrElementFormat"] = value;
                    }
                }
            }

            [NotifyParentProperty(true), TypeConverter(typeof (WebColorConverter)), DefaultValue(typeof (Color), "Blue")
            ]
            public Color ExprColor
            {
                get
                {
                    object obj2 = this.ViewState["ExprColor"];
                    if (obj2 != null)
                    {
                        return (Color) obj2;
                    }
                    return Color.Blue;
                }
                set
                {
                    if (this.ExprColor != value)
                    {
                        this.ViewState["ExprColor"] = value;
                    }
                }
            }

            [DefaultValue(typeof (Color), "Blue"), NotifyParentProperty(true), TypeConverter(typeof (WebColorConverter))
            ]
            public Color OperatorColor
            {
                get
                {
                    object obj2 = this.ViewState["OperatorColor"];
                    if (obj2 != null)
                    {
                        return (Color) obj2;
                    }
                    return Color.Blue;
                }
                set
                {
                    if (this.OperatorColor != value)
                    {
                        this.ViewState["OperatorColor"] = value;
                    }
                }
            }

            [NotifyParentProperty(true), DefaultValue("")]
            public string RowButtonImageUrl
            {
                get
                {
                    object obj2 = this.ViewState["RowButtonImageUrl"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return "";
                }
                set { this.ViewState["RowButtonImageUrl"] = value; }
            }

            [NotifyParentProperty(true)]
            public string RowButtonTooltip
            {
                get
                {
                    object obj2 = this.ViewState["RowButtonTooltip"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return "";
                }
                set { this.ViewState["RowButtonTooltip"] = value; }
            }

            [NotifyParentProperty(true), DefaultValue(true)]
            public bool ShowEntitiesAsTree
            {
                get
                {
                    object obj2 = this.ViewState["ShowEntitiesAsTree"];
                    if (obj2 != null)
                    {
                        return (bool) obj2;
                    }
                    return true;
                }
                set { this.ViewState["ShowEntitiesAsTree"] = value; }
            }

            [NotifyParentProperty(true), DefaultValue(true)]
            public bool ShowRootRow
            {
                get
                {
                    object obj2 = this.ViewState["ShowRootRow"];
                    if (obj2 != null)
                    {
                        return (bool) obj2;
                    }
                    return true;
                }
                set { this.ViewState["ShowRootRow"] = value; }
            }
        }

        protected internal class RootRow : QueryPanel.PredicateRow
        {
            public RootRow(QueryPanel qpanel, Query.Predicate condition) : base(qpanel, condition, false)
            {
                this.AllowShifting = false;
                base.button.Items = base.parentPanel.rootButtonMenuList;
            }

            protected override string GetPredicateRowText()
            {
                return base.parentPanel.Texts.Get("RootPredicateTitle");
            }
        }

        public class SimpleConditionRow : QueryPanel.ConditionRow
        {
            private XElement baseElement;
            internal XElement operatorElement;

            public SimpleConditionRow(QueryPanel qpanel, Korzh.EasyQuery.Query.SimpleCondition condition)
                : base(qpanel, condition)
            {
            }

            protected override void ApplyElementFormats(XElement element)
            {
                if (element == this.operatorElement)
                {
                    ((ListXElement) element).MenuStyle.ItemMinWidth = 200;
                }
                if (element == this.baseElement)
                {
                    this.AttrElementApplyFormats(element);
                }
                else if (element == this.operatorElement)
                {
                    this.OperatorElementApplyFormats(element);
                }
                else if (element.Data is Expression)
                {
                    this.ExprElementApplyFormats(element);
                }
                else
                {
                    base.ApplyElementFormats(element);
                }
            }

            protected virtual void AttrElementApplyFormats(XElement element)
            {
                if (base.parentPanel != null)
                {
                    element.ForeColor = base.parentPanel.Appearance.AttrColor;
                    element.ReadOnly = base.Condition.ReadOnly ||
                                       ((base.parentPanel.EditMode != QueryPanel.EditModeKind.All) &&
                                        (base.parentPanel.EditMode != QueryPanel.EditModeKind.FixedConditions));
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
                XElement element = (XElement) sender;
                EntityAttrExpr data = (EntityAttrExpr) element.Data;
                if (data != null)
                {
                    e.Text = this.GetAttributeCaption(data.Attribute);
                }
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
                        this.SimpleCondition.Expressions[index] = new EntityAttrExpr(aModel,
                                                                                     aModel.GetDefaultUICAttribute());
                    }
                }
            }

            protected override void CoreRefreshByCondition()
            {
                base.CoreRefreshByCondition();
                EntityAttrExpr baseExpr = (EntityAttrExpr) this.SimpleCondition.BaseExpr;
                DataModel.EntityAttr attribute = baseExpr.Attribute;
                for (int i = base.Elements.Count - 1; i > 0; i--)
                {
                    if (((base.Elements[i] != base.button) && (base.Elements[i] != this.operatorElement)) &&
                        (base.Elements[i] != this.baseElement))
                    {
                        base.Elements[i].Detach();
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
                            this.operatorElement = new LabelListXElement();
                            this.operatorElement.ContentChanged +=
                                new ContentChangedEventHandler(this.OperatorElementContentChanged);
                            this.operatorElement.TextAdjusting +=
                                new TextAdjustingEventHandler(this.OperatorElementTextAdjusting);
                            base.Elements.Add(this.operatorElement);
                        }
                        DataModel.Operator @operator = this.SimpleCondition.Operator;
                        this.operatorElement.Data = @operator;
                        base.parentPanel.FillOperatorElementByAttribute(attribute, (ListXElement) this.operatorElement);
                        this.operatorElement.SetContentSilent(@operator.ID, @operator.MainText);
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
                                    this.baseElement = new LabelListXElement();
                                    base.parentPanel.FillElementByEntityTree((ListXElement) this.baseElement);
                                    this.baseElement.ContentChanged +=
                                        new ContentChangedEventHandler(this.BaseElementContentChanged);
                                    this.baseElement.TextAdjusting +=
                                        new TextAdjustingEventHandler(this.BaseElementTextAdjusting);
                                    base.Elements.Add(this.baseElement);
                                }
                                this.baseElement.Data = baseExpr;
                                this.baseElement.Value = attribute.ID;
                            }
                            else
                            {
                                XElement element = null;
                                if (expr is ConstExpr)
                                {
                                    element = this.CreateValueElement(expr.DataType);
                                    element.NeedValidate = true;
                                    element.SetContentSilent(expr.Value, expr.Text);
                                    element.Data = expr;
                                }
                                else if (expr is EntityAttrExpr)
                                {
                                    element = new LabelListXElement();
                                    base.parentPanel.FillElementByEntityTree((ListXElement) element);
                                    element.TextAdjusting +=
                                        new TextAdjustingEventHandler(this.ValueAttrElementTextAdjusting);
                                    element.Data = expr;
                                    element.Value = ((EntityAttrExpr) expr).Attribute.ID;
                                    expr.SetContentSilent(element.Value, element.Text);
                                }
                                else
                                {
                                    element = new LabelXElement();
                                    element.Data = expr;
                                    element.SetContentSilent(expr.Value, expr.Text);
                                }
                                element.ContentChanged += new ContentChangedEventHandler(this.ExprContentChanged);
                                this.FillElementAltMenu(element, expr);
                                base.Elements.Add(element);
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

            private XElement CreateValueElement(DataType type)
            {
                XElement element = null;
                CreateValueElementEventArgs e = new CreateValueElementEventArgs(this, type);
                if (this.SimpleCondition.BaseExpr is EntityAttrExpr)
                {
                    EntityAttrExpr baseExpr = (EntityAttrExpr) this.SimpleCondition.BaseExpr;
                    ValueEditor valueEditor = baseExpr.Attribute.GetValueEditor(this.SimpleCondition.Operator);
                    element = base.CreateElementByXmlText(valueEditor.XmlDefinition);
                    if (element == null)
                    {
                        element = new EditXElement();
                    }
                }
                else
                {
                    element = new EditXElement();
                }
                element.AllowList = this.SimpleCondition.Operator.ValueKind == DataKind.List;
                if (element is EditXElement)
                {
                    element.SubType = this.ConvertDataType(type);
                }
                if (element is ListXElement)
                {
                    element.EmptyValueText = base.parentPanel.Texts.Get("MsgEmptyListValue");
                }
                else
                {
                    element.EmptyValueText = base.parentPanel.Texts.Get("MsgEmptyScalarValue");
                }
                e.Element = element;
                base.parentPanel.OnCreateValueElement(e);
                if (e.Element != element)
                {
                    element = e.Element;
                }
                return element;
            }

            protected internal virtual void ExprContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing)
                {
                    base.SupressRefresh();
                    try
                    {
                        XElement element = (XElement) sender;
                        Expression data = (Expression) element.Data;
                        if (e.ValueChanged)
                        {
                            data.Value = element.Value;
                        }
                        if (e.TextChanged)
                        {
                            data.Text = element.Text;
                        }
                    }
                    finally
                    {
                        base.ResumeRefresh();
                    }
                }
            }

            protected virtual void ExprElementApplyFormats(XElement element)
            {
                if (base.parentPanel != null)
                {
                    element.ForeColor = base.parentPanel.Appearance.ExprColor;
                    element.ReadOnly = base.Condition.ReadOnly ||
                                       (base.parentPanel.EditMode == QueryPanel.EditModeKind.None);
                }
            }

            protected void FillElementAltMenu(XElement element, Expression expr)
            {
                ValueItemList list = new ValueItemList(element.ID + "_altmenu");
                ValueItem item = new ValueItem("Constant expression", "ALT_CONSTANT");
                if (expr is ConstExpr)
                {
                    item.Selected = true;
                }
                list.Add(item);
                item = new ValueItem("Attribute", "ALT_ATTR");
                if (expr is EntityAttrExpr)
                {
                    item.Selected = true;
                }
                list.Add(item);
                element.AltMenuItems = list;
            }

            protected string GetAttributeCaption(DataModel.EntityAttr attr)
            {
                if (base.parentPanel.Appearance.AttrElementFormat != string.Empty)
                {
                    return
                        base.parentPanel.Appearance.AttrElementFormat.Replace("{attr}", attr.Caption).Replace(
                            "{entity}", attr.Entity.GetFullName(".")).Trim();
                }
                return attr.Caption;
            }

            protected virtual void OperatorElementApplyFormats(XElement element)
            {
                if (base.parentPanel != null)
                {
                    element.ForeColor = base.parentPanel.Appearance.OperatorColor;
                    element.ReadOnly = (base.Condition.ReadOnly ||
                                        (base.parentPanel.EditMode == QueryPanel.EditModeKind.ValuesOnly)) ||
                                       (base.parentPanel.EditMode == QueryPanel.EditModeKind.None);
                }
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
                XElement element = (XElement) sender;
                EntityAttrExpr data = (EntityAttrExpr) element.Data;
                if (data != null)
                {
                    e.Text = this.GetAttributeCaption(data.Attribute);
                }
            }

            public Korzh.EasyQuery.Query.SimpleCondition SimpleCondition
            {
                get { return (Korzh.EasyQuery.Query.SimpleCondition) base.condition; }
            }
        }

        public class SqlListXElement : LabelListXElement
        {
            private string listID;
            private bool listPopulated;
            private string sql = "";

            public override void ApplyFormats()
            {
                base.ApplyFormats();
                base.MenuStyle.ItemMinWidth = 240;
            }

            internal static string GetListIDBySQL(string sql)
            {
                int num = 0;
                for (int i = 0; i < sql.Length; i++)
                {
                    num += sql[i];
                }
                return ("SQL:" + num);
            }

            public override void ParseXmlNode(XmlNode node)
            {
                XmlAttribute attribute = node.Attributes["ControlType"];
                if (attribute != null)
                {
                    base.ControlType = attribute.Value;
                }
                if (base.ControlType == "MULTILIST")
                {
                    base.MultiSelect = true;
                }
                attribute = node.Attributes["ID"];
                if (attribute != null)
                {
                    this.ListID = attribute.Value;
                }
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.LocalName == "SQL")
                    {
                        this.SetSql(node2.InnerText);
                    }
                }
            }

            protected override void PreRenderElementControl()
            {
                if (!this.listPopulated && (base.ParentRow != null))
                {
                    base.ParentRow.ElementAction(this, "SqlListRequest", this.sql);
                    this.listPopulated = true;
                }
                base.PreRenderElementControl();
            }

            protected void SetSql(string newSql)
            {
                if (this.sql != newSql)
                {
                    this.sql = newSql;
                    this.listPopulated = false;
                    if (base.Items != null)
                    {
                        base.Items.Clear();
                    }
                }
            }

            public string ListID
            {
                get
                {
                    if (this.listID == null)
                    {
                        this.listID = GetListIDBySQL(this.SQL);
                    }
                    return this.listID;
                }
                set { this.listID = value; }
            }

            public string SQL
            {
                get { return this.sql; }
            }

            public static string XmlTagName
            {
                get { return "SQLLIST"; }
            }

            public class Creator : XElement.ICreator
            {
                public XElement Create()
                {
                    return new QueryPanel.SqlListXElement();
                }

                public string TagName
                {
                    get { return QueryPanel.SqlListXElement.XmlTagName; }
                }
            }
        }
    }
}