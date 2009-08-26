namespace Korzh.EasyQuery.WebControls
{
    using Korzh.EasyQuery;
    using Korzh.WebControls.XControls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    [ToolboxBitmap(typeof (QueryColumnsPanel))]
    public class QueryColumnsPanel : XPanel
    {
        private bool active;
        internal AdditionRow addRow;
        internal ValueItemList aggrFuncList;
        internal ValueItemList colButtonMenuList;
        internal ValueItemList colButtonMenuListWOSorting;
        internal Korzh.EasyQuery.Query.ColumnsStore columns;
        private EditModeKind editMode;
        internal ValueItemList entityList;
        internal Korzh.EasyQuery.Query.ColumnsStore justSortedColumns;
        private DataModel model;
        private Korzh.EasyQuery.Query query;

        private static ResourceManager resources = new ResourceManager("Korzh.EasyQuery.WebControls.QueryColumnsPanel",
                                                                       typeof (QueryColumnsPanel).Assembly);

        private Type rsType;
        protected Korzh.EasyQuery.Query.SortedColumnList sortedColumns;
        internal ValueItemList sortingMenuList;
        internal bool specListsInitialized;

        public event EventHandler RowListChanged;

        static QueryColumnsPanel()
        {
            ColumnRow.RegisterType("ENTATTR", new SimpleColumnRowCreator());
            ColumnRow.RegisterType("AGGRFUNC", new AggrColumnRowCreator());
        }

        public QueryColumnsPanel()
        {
            base.Texts.LoadFromResources(resources);
            this.rsType = base.GetType();
            this.Appearance.RowButtonTooltip = base.Texts.Get("QCPRowButtonTitle");
            this.Query = null;
            this.ScrollBars = ScrollBars.Auto;
            this.BorderStyle = BorderStyle.Solid;
            this.BorderWidth = new Unit(1);
            this.BorderColor = Color.Black;
        }

        protected void Activate()
        {
            if ((this.model != null) && (this.query != null))
            {
                this.RefillEntityList();
                this.RefillAggrFuncList();
                this.RecreateAdditionRow();
                this.active = true;
            }
        }

        protected virtual void AddEntities(ValueItemList listItems, DataModel.Entity parentEntity)
        {
            foreach (DataModel.Entity entity in parentEntity.SubEntities)
            {
                ValueItem item = new ValueItem(entity.Name, "", "");
                this.AddEntities(item.SubItems, entity);
                if (item.SubItems.Count > 0)
                {
                    listItems.Add(item);
                }
            }
            foreach (DataModel.EntityAttr attr in parentEntity.Attributes)
            {
                if (attr.UseInResult)
                {
                    ValueItem item2 = new ValueItem(attr.Caption, attr.ID, "");
                    listItems.Add(item2);
                }
            }
        }

        protected virtual void AddRowByColumn(Korzh.EasyQuery.Query.Column column)
        {
            ColumnRow newrow = ColumnRow.Create(this, column.ExprType, column, false);
            newrow.RefreshByColumn();
            base.Rows.Add(newrow);
        }

        protected virtual void AddSimpleColumn(string attrID)
        {
            this.CheckQuery();
            this.CheckDataModel();
            Korzh.EasyQuery.Query.Column column = new Korzh.EasyQuery.Query.Column();
            column.Expr = Expression.Create("ENTATTR", this.Model);
            if (attrID != null)
            {
                column.Expr.Value = attrID;
            }
            this.columns.Add(column);
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

        protected override XPanel.XAppearance CreateAppearance()
        {
            return new QCPAppearance();
        }

        protected override void DoAction(object sender, string actionName, object data)
        {
            if ((sender is ColumnRow.ColumnButton) || (sender is ButtonXElement))
            {
                ColumnRow parentRow = (ColumnRow) ((XElement) sender).ParentRow;
                if (string.Compare(actionName, "NotSorted", true) == 0)
                {
                    parentRow.column.Sorting = Korzh.EasyQuery.SortDirection.None;
                }
                else if (string.Compare(actionName, "Ascending", true) == 0)
                {
                    parentRow.column.Sorting = Korzh.EasyQuery.SortDirection.Ascending;
                }
                else if (string.Compare(actionName, "Descending", true) == 0)
                {
                    parentRow.column.Sorting = Korzh.EasyQuery.SortDirection.Descending;
                }
                else if (string.Compare(actionName, "DeleteColumn", true) == 0)
                {
                    int index = ((ColumnRow.ColumnButton) sender).ParentRow.Index;
                    this.columns.RemoveAt(index);
                }
                else if (string.Compare(actionName, "MoveRowUp", true) != 0)
                {
                    if (string.Compare(actionName, "MoveRowDown", true) != 0)
                    {
                        if (actionName.StartsWith("CCT_"))
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
                        int num3 = ((ColumnRow) ((XElement) sender).ParentRow).Column.Index;
                        if (num3 < (this.Columns.Count - 1))
                        {
                            this.Columns.Move(num3, num3 + 1);
                        }
                    }
                }
                else
                {
                    int num2 = ((ColumnRow) ((XElement) sender).ParentRow).Column.Index;
                    if (num2 > 0)
                    {
                        this.Columns.Move(num2, num2 - 1);
                    }
                }
            }
            else
            {
                base.DoAction(sender, actionName, data);
            }
        }

        protected override void DoAddRow()
        {
            base.DoAddRow();
            this.AddSimpleColumn(null);
        }

        internal void FillAggrElement(ListXElement aggrElement, AggrFuncExpr expression)
        {
            this.CheckDataModel();
            ValueItemList list = new ValueItemList(aggrElement.ID + "_aggrFuncs");
            if (this.TypeIsInList(expression.Argument.DataType,
                                  new DataType[]
                                      {
                                          DataType.Autoinc, DataType.Byte, DataType.Currency, DataType.Float, DataType.Int,
                                          DataType.Int64, DataType.Word
                                      }))
            {
                list.Add("Sum", "SUM");
                list.Add("Average", "AVG");
            }
            if (this.TypeIsInList(expression.Argument.DataType,
                                  new DataType[]
                                      {
                                          DataType.Autoinc, DataType.BCD, DataType.Byte, DataType.Currency, DataType.Date,
                                          DataType.DateTime, DataType.Float, DataType.Int, DataType.Int64, DataType.Time,
                                          DataType.Word
                                      }))
            {
                list.Add("Minimum", "MIN");
                list.Add("Maximum", "MAX");
            }
            list.Add("Count", "COUNT");
            aggrElement.Items = list;
            aggrElement.ListChanged();
        }

        internal void FillEntityElement(ListXElement entityElement)
        {
            this.CheckDataModel();
            entityElement.Items = this.entityList;
        }

        protected virtual void InitSpecialLists()
        {
            this.entityList = new ValueItemList(this.ID + "_entities");
            this.sortingMenuList = new ValueItemList(this.ID + "_sortingMenu");
            this.sortingMenuList.Add(new ValueItem(base.Texts.Get("CmdNotSorted"), "NotSorted", "NotSorted"));
            this.sortingMenuList.Add(new ValueItem(base.Texts.Get("CmdAscending"), "Ascending", "Ascending"));
            this.sortingMenuList.Add(new ValueItem(base.Texts.Get("CmdDescending"), "Descending", "Descending"));
            this.colButtonMenuList = new ValueItemList(this.ID + "_colBtnMenu");
            ValueItem item = new ValueItem(base.Texts.Get("CmdGroupSort"), "", "");
            for (int i = 0; i < this.sortingMenuList.Count; i++)
            {
                item.SubItems.Add(this.sortingMenuList[i]);
            }
            if (this.EditMode != EditModeKind.None)
            {
                this.colButtonMenuList.Add(item);
            }
            if ((this.EditMode == EditModeKind.All) || (this.EditMode == EditModeKind.FixedList))
            {
                this.colButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdMoveUp"), "MoveRowUp", "MoveRowUp"));
                this.colButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdMoveDown"), "MoveRowDown", "MoveRowDown"));
            }
            if (this.EditMode == EditModeKind.All)
            {
                this.colButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdDeleteColumn"), "DeleteColumn",
                                                         "DeleteColumn"));
            }
            item = new ValueItem(base.Texts.Get("ColTypeGroup"), "", "");
            IDictionaryEnumerator enumerator = ColumnRow.Creators.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if ((((string) enumerator.Key) != "AGGRFUNC") || this.AllowAggrColumns)
                {
                    item.SubItems.Add(new ValueItem(((IColumnRowCreator) enumerator.Value).GetCaption(this),
                                                    "CCT_" + ((string) enumerator.Key),
                                                    "CCT_" + ((string) enumerator.Key)));
                }
            }
            if ((item.SubItems.Count > 1) &&
                ((this.EditMode == EditModeKind.All) || (this.EditMode == EditModeKind.FixedList)))
            {
                this.colButtonMenuList.Add(item);
            }
            this.colButtonMenuListWOSorting = new ValueItemList(this.ID + "_colBtnMenuWOSorting");
            if ((this.EditMode == EditModeKind.All) || (this.EditMode == EditModeKind.FixedList))
            {
                this.colButtonMenuListWOSorting.Add(new ValueItem(base.Texts.Get("CmdMoveUp"), "MoveRowUp", "MoveRowUp"));
                this.colButtonMenuListWOSorting.Add(new ValueItem(base.Texts.Get("CmdMoveDown"), "MoveRowDown",
                                                                  "MoveRowDown"));
            }
            if (this.EditMode == EditModeKind.All)
            {
                this.colButtonMenuListWOSorting.Add(new ValueItem(base.Texts.Get("CmdDeleteColumn"), "DeleteColumn",
                                                                  "DeleteColumn"));
            }
            item = new ValueItem(base.Texts.Get("ColTypeGroup"), "", "");
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                item.SubItems.Add(new ValueItem(((IColumnRowCreator) enumerator.Value).GetCaption(this),
                                                "CCT_" + ((string) enumerator.Key), "CCT_" + ((string) enumerator.Key)));
            }
            if ((this.EditMode == EditModeKind.All) || (this.EditMode == EditModeKind.FixedList))
            {
                this.colButtonMenuListWOSorting.Add(item);
            }
            this.specListsInitialized = true;
        }

        private void MoveRow(int index1, int index2)
        {
            this.CheckQuery();
            if (((index1 >= 0) && (index2 >= 0)) &&
                (((index1 < base.Rows.Count) && (index2 < base.Rows.Count)) && (index1 != index2)))
            {
                this.columns.Move(index1, index2);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.InitSpecialLists();
            this.Page.PreRender += new EventHandler(this.PagePreRenderHandler);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.active)
            {
                this.Activate();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //this.BackImageUrl = this.Page.ClientScript.GetWebResourceUrl(this.rsType,"Korzh.EasyQuery.WebControls.Resources.Watermark.gif");
            this.addRow.RowControl.Visible = this.EditMode == EditModeKind.All;
        }

        protected override void OnRowAdded(XRow row)
        {
            base.OnRowAdded(row);
        }

        protected override void OnRowListChanged()
        {
            if (this.RowListChanged != null)
            {
                this.RowListChanged(this, new EventArgs());
            }
        }

        protected virtual void PagePreRenderHandler(object sender, EventArgs e)
        {
            this.RefreshByColumns();
        }

        protected virtual void RecreateAdditionRow()
        {
            if (this.addRow == null)
            {
                this.addRow = new AdditionRow(this);
            }
            base.PlaceRow(this.addRow);
        }

        private void RefillAggrFuncList()
        {
            if (this.Model != null)
            {
                if (this.aggrFuncList == null)
                {
                    this.aggrFuncList = new ValueItemList(this.ID + "_aggrFuncs");
                }
                else
                {
                    this.aggrFuncList.Clear();
                }
                foreach (AggrFunction function in this.Model.AggrFunctions)
                {
                    this.aggrFuncList.Add(new ValueItem(function.Caption, function.ID));
                }
            }
        }

        private void RefillEntityList()
        {
            this.entityList.Clear();
            if (this.Model != null)
            {
                this.AddEntities(this.entityList, this.Model.EntityRoot);
            }
        }

        public virtual void RefreshByColumns()
        {
            this.CheckQuery();
            base.Rows.Clear();
            for (int i = 0; i < this.columns.Count; i++)
            {
                this.AddRowByColumn(this.columns[i]);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Style, "text-align:left");
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
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Appearance.ElementSpacing.ToString());
            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "1");
            writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
            writer.RenderBeginTag(HtmlTextWriterTag.Table);
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Colgroup);
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Colgroup);
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Colgroup);
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Colgroup);
            writer.RenderEndTag();
            if (this.ShowHeaders && (base.Rows.Count > 0))
            {
                if (this.HeaderCssClass != string.Empty)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.HeaderCssClass);
                }
                else
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Style,
                                        "color:Black;font-size:10pt;font-family:Tahoma, Verdana, Geneva, Arial");
                }
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(this.HeaderBgColor));
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("");
                writer.RenderEndTag();
                writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(this.HeaderBgColor));
                writer.AddAttribute(HtmlTextWriterAttribute.Width, this.ExprColumnWidth);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write(base.Texts.Get("HeaderExpression"));
                writer.RenderEndTag();
                if (this.AllowEditCaptions)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(this.HeaderBgColor));
                    writer.AddAttribute(HtmlTextWriterAttribute.Width, this.TitleColumnWidth);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(base.Texts.Get("HeaderTitle"));
                    writer.RenderEndTag();
                }
                if (this.AllowSorting)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(this.HeaderBgColor));
                    writer.AddAttribute(HtmlTextWriterAttribute.Width, this.SortingColumnWidth);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(base.Texts.Get("HeaderSorting"));
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
            foreach (SimpleColumnRow row in base.Rows)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Height, this.Appearance.RowHeight.ToString());
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                row.Elements[0].RenderControl(writer);
                if (this.Appearance.ShowMoveUpDownButtons &&
                    ((this.EditMode == EditModeKind.All) || (this.EditMode == EditModeKind.FixedList)))
                {
                    writer.Write("&nbsp;");
                    row.Elements[1].RenderControl(writer);
                    writer.Write("&nbsp;");
                    row.Elements[2].RenderControl(writer);
                }
                writer.RenderEndTag();
                writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "true");
                writer.AddAttribute(HtmlTextWriterAttribute.Width, this.ExprColumnWidth);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                for (
                    int i = (this.Appearance.ShowMoveUpDownButtons &&
                             ((this.EditMode == EditModeKind.All) || (this.EditMode == EditModeKind.FixedList)))
                                ? 3
                                : 1;
                    row.Elements[i] != row.titleElement;
                    i++)
                {
                    row.Elements[i].RenderControl(writer);
                }
                writer.RenderEndTag();
                if (this.AllowEditCaptions)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                    writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "true");
                    writer.AddAttribute(HtmlTextWriterAttribute.Width, this.TitleColumnWidth);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    row.titleElement.RenderControl(writer);
                    writer.RenderEndTag();
                }
                if (this.AllowSorting && (row.sortElement != null))
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                    writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "true");
                    writer.AddAttribute(HtmlTextWriterAttribute.Width, this.SortingColumnWidth);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    row.sortElement.RenderControl(writer);
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            if (this.addRow != null)
            {
                this.addRow.RenderRow(writer);
            }
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

        [DefaultValue(true), Browsable(true), NotifyParentProperty(true)]
        public virtual bool AllowAggrColumns
        {
            get
            {
                object obj2 = this.ViewState["AllowAggrColumns"];
                if (obj2 != null)
                {
                    return (bool) obj2;
                }
                return true;
            }
            set { this.ViewState["AllowAggrColumns"] = value; }
        }

        [DefaultValue(true), NotifyParentProperty(true), Browsable(true)]
        public virtual bool AllowEditCaptions
        {
            get
            {
                object obj2 = this.ViewState["AllowEditCaptions"];
                if (obj2 != null)
                {
                    return (bool) obj2;
                }
                return true;
            }
            set { this.ViewState["AllowEditCaptions"] = value; }
        }

        [Browsable(true), DefaultValue(true), NotifyParentProperty(true)]
        public virtual bool AllowSorting
        {
            get
            {
                object obj2 = this.ViewState["AllowSorting"];
                if (obj2 != null)
                {
                    return (bool) obj2;
                }
                return true;
            }
            set { this.ViewState["AllowSorting"] = value; }
        }

        [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public QCPAppearance Appearance
        {
            get { return (QCPAppearance) base.Appearance; }
        }

        [Browsable(false)]
        public Korzh.EasyQuery.Query.ColumnsStore Columns
        {
            get { return this.columns; }
        }

        public EditModeKind EditMode
        {
            get { return this.editMode; }
            set
            {
                if (this.editMode != value)
                {
                    this.editMode = value;
                    this.InitSpecialLists();
                }
            }
        }

        [Browsable(true), DefaultValue("0"), NotifyParentProperty(true), Category("Appearance")]
        public string ExprColumnWidth
        {
            get
            {
                object obj2 = this.ViewState["ExprColumnWidth"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "0";
            }
            set { this.ViewState["ExprColumnWidth"] = value; }
        }

        [NotifyParentProperty(true), Browsable(true), DefaultValue(typeof (Color), "LightGray"), Category("Appearance")]
        public Color HeaderBgColor
        {
            get
            {
                object obj2 = this.ViewState["HeaderBgColor"];
                if (obj2 != null)
                {
                    return (Color) obj2;
                }
                return Color.LightGray;
            }
            set { this.ViewState["HeaderBgColor"] = value; }
        }

        [Category("Appearance"), Browsable(true), DefaultValue(""), NotifyParentProperty(true)]
        public string HeaderCssClass
        {
            get
            {
                object obj2 = this.ViewState["HeaderCssClass"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return string.Empty;
            }
            set { this.ViewState["HeaderCssClass"] = value; }
        }

        [Browsable(false)]
        public Korzh.EasyQuery.Query.ColumnsStore JustSortedColumns
        {
            get { return this.justSortedColumns; }
        }

        public DataModel Model
        {
            get { return this.model; }
            set
            {
                if (this.model != value)
                {
                    this.model = value;
                    if (this.query != null)
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
                    this.query = value;
                    if (this.query != null)
                    {
                        this.query.Model = this.model;
                        if ((this.model != null) && this.specListsInitialized)
                        {
                            this.Activate();
                        }
                        this.columns = this.query.Result.Columns;
                        this.sortedColumns = this.query.Result.SortedColumns;
                        this.justSortedColumns = this.query.Result.JustSortedColumns;
                        this.Enabled = true;
                        this.RefreshByColumns();
                    }
                    else
                    {
                        this.columns = null;
                        this.Enabled = false;
                    }
                }
            }
        }

        [NotifyParentProperty(true), DefaultValue(true), Browsable(true), Category("Appearance")]
        public bool ShowHeaders
        {
            get
            {
                object obj2 = this.ViewState["ShowHeaders"];
                if (obj2 != null)
                {
                    return (bool) obj2;
                }
                return true;
            }
            set { this.ViewState["ShowHeaders"] = value; }
        }

        [NotifyParentProperty(true), DefaultValue("0"), Category("Appearance"), Browsable(true)]
        public string SortingColumnWidth
        {
            get
            {
                object obj2 = this.ViewState["SortingColumnWidth"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "0";
            }
            set { this.ViewState["SortingColumnWidth"] = value; }
        }

        [DefaultValue("0"), Category("Appearance"), NotifyParentProperty(true), Browsable(true)]
        public string TitleColumnWidth
        {
            get
            {
                object obj2 = this.ViewState["TitleColumnWidth"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "0";
            }
            set { this.ViewState["TitleColumnWidth"] = value; }
        }

        protected internal class AdditionRow : XRow
        {
            private ListXElement baseElement;
            private QueryColumnsPanel parentPanel;

            public AdditionRow(QueryColumnsPanel parentPanel) : base(false)
            {
                this.parentPanel = parentPanel;
                base.ID = "ar";
                this.baseElement = new LabelListXElement();
                parentPanel.FillEntityElement(this.baseElement);
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
                XElement element = (XElement) sender;
                if (e.ValueChanged)
                {
                    this.parentPanel.AddSimpleColumn(element.Value);
                }
            }

            protected void BaseElementPreRender(object sender, EventArgs e)
            {
                ((XElement) sender).ForeColor = ((QueryColumnsPanel) base.Parent).Appearance.AdditionRowColor;
            }

            protected virtual void BaseElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                e.Text = this.RowText;
            }

            protected internal Control RowControl
            {
                get { return base.rowControl; }
            }

            protected string RowText
            {
                get { return ("[" + this.parentPanel.Texts.Get("CmdClickToAdd") + "]"); }
            }
        }

        public class AggrColumnRow : QueryColumnsPanel.SimpleColumnRow
        {
            protected ListXElement aggrElement;
            protected TextXElement ofElement;

            public AggrColumnRow(QueryColumnsPanel aPanel, Query.Column aColumn, bool useCheckBox)
                : base(aPanel, aColumn, useCheckBox)
            {
            }

            protected virtual void AggrFuncElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if ((!base.Refreshing && (this.aggrElement == ((XElement) sender))) && e.ValueChanged)
                {
                    ((AggrFuncExpr) base.column.Expr).Value = this.aggrElement.Value;
                }
            }

            protected internal override void AttrElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if ((!base.Refreshing && (base.attrElement == ((XElement) sender))) && e.ValueChanged)
                {
                    ((AggrFuncExpr) base.column.Expr).Argument.Value = base.attrElement.Value;
                }
            }

            internal override void InternalRefreshByColumn()
            {
                if (base.column.Caption == "")
                {
                    base.column.Caption = ((AggrFuncExpr) base.column.Expr).Argument.Text + "_" +
                                          ((AggrFuncExpr) base.column.Expr).Function.Caption;
                }
                if (this.aggrElement == null)
                {
                    this.aggrElement = new LabelListXElement();
                    this.aggrElement.ContentChanged += new ContentChangedEventHandler(this.AggrFuncElementContentChanged);
                    base.Elements.Add(this.aggrElement);
                    this.aggrElement.ID = base.ID + "_aggrElem";
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
                    ((AggrFuncExpr) base.column.Expr).Function = new AggrFunction(id, text, id + "({expr1})",
                                                                                  "[[" + id + "]] of {attr1}");
                    function = ((AggrFuncExpr) base.column.Expr).Function;
                }
                this.aggrElement.Data = (AggrFuncExpr) base.column.Expr;
                this.aggrElement.Value = function.ID;
                this.aggrElement.Text = function.Caption;
                if (this.ofElement == null)
                {
                    this.ofElement = new TextXElement("&nbsp;" + base.parentPanel.Texts.Get("MsgOf") + "&nbsp;");
                    base.Elements.Add(this.ofElement);
                }
                if (base.attrElement == null)
                {
                    base.attrElement = new LabelListXElement();
                    base.parentPanel.FillEntityElement(base.attrElement);
                    base.attrElement.ContentChanged += new ContentChangedEventHandler(this.AttrElementContentChanged);
                    base.attrElement.TextAdjusting += new TextAdjustingEventHandler(this.AttrElementTextAdjusting);
                    base.Elements.Add(base.attrElement);
                }
                EntityAttrExpr argument = (EntityAttrExpr) ((AggrFuncExpr) base.column.Expr).Argument;
                base.attrElement.Data = argument;
                DataModel.EntityAttr attribute = argument.Attribute;
                base.attrElement.Value = attribute.ID;
                base.attrElement.Text = attribute.Caption;
            }

            public static string STypeName
            {
                get { return "AGGRFUNC"; }
            }

            public override string TypeName
            {
                get { return STypeName; }
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

        public class CompoundColumnRow : QueryColumnsPanel.SimpleColumnRow
        {
            protected internal ListXElement attrElement1;
            protected internal ListXElement attrElement2;
            protected internal EditXElement exprElement;
            protected internal TextXElement spaceElement;
            protected internal TextXElement textElement1;
            protected internal TextXElement textElement2;

            public CompoundColumnRow(QueryColumnsPanel aPanel, Query.Column aColumn, bool useCheckBox)
                : base(aPanel, aColumn, useCheckBox)
            {
                this.exprElement = new EditXElement();
                this.exprElement.Value = "{ea}-({ea}*0.05)";
                this.exprElement.Text = "[..]";
                this.exprElement.TextAdjusting += new TextAdjustingEventHandler(this.ExprElementTextAdjusting);
                base.Elements.Add(this.exprElement);
                this.spaceElement = new TextXElement();
                this.spaceElement.Value = " ";
                this.spaceElement.Text = " ";
                base.Elements.Add(this.spaceElement);
                this.attrElement1 = new LabelListXElement();
                base.parentPanel.FillEntityElement(this.attrElement1);
                this.attrElement1.Value = "40";
                base.Elements.Add(this.attrElement1);
                this.textElement1 = new TextXElement();
                this.textElement1.Value = "";
                this.textElement1.Text = " - (";
                base.Elements.Add(this.textElement1);
                this.attrElement2 = new LabelListXElement();
                base.parentPanel.FillEntityElement(this.attrElement2);
                this.attrElement2.Value = "40";
                base.Elements.Add(this.attrElement2);
                this.textElement2 = new TextXElement();
                this.textElement2.Value = "";
                this.textElement2.Text = "*0.05)";
                base.Elements.Add(this.textElement2);
            }

            protected virtual void ExprElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                e.Text = "[..]";
            }

            internal override void InternalRefreshByColumn()
            {
            }

            public static string STypeName
            {
                get { return "COMPOUND"; }
            }

            public override string TypeName
            {
                get { return STypeName; }
            }
        }

        internal class CompoundColumnRowCreator : IColumnRowCreator
        {
            public ColumnRow Create(QueryColumnsPanel panel, Query.Column column, bool useCheckBox)
            {
                return new QueryColumnsPanel.CompoundColumnRow(panel, column, useCheckBox);
            }

            public string GetCaption(QueryColumnsPanel panel)
            {
                return panel.Texts.Get("ColTypeCompound");
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
            protected internal ListXElement sortElement;
            protected internal EditXElement titleElement;

            public SimpleColumnRow(QueryColumnsPanel aPanel, Query.Column aColumn, bool useCheckBox)
                : base(aPanel, aColumn, useCheckBox)
            {
            }

            protected override void AddCommonElements()
            {
                base.AddCommonElements();
                if (this.titleElement == null)
                {
                    this.titleElement = new EditXElement("");
                    this.titleElement.ContentChanged += new ContentChangedEventHandler(this.TitleElementContentChanged);
                    base.Elements.Add(this.titleElement);
                }
                this.titleElement.Value = base.column.Caption;
                if (base.column.AllowSorting && base.parentPanel.AllowSorting)
                {
                    if (this.sortElement == null)
                    {
                        this.sortElement = new LabelListXElement();
                        this.sortElement.Items = base.parentPanel.sortingMenuList;
                        this.sortElement.ContentChanged += new ContentChangedEventHandler(this.SortContentChanged);
                        base.Elements.Add(this.sortElement);
                    }
                    this.sortElement.Value = base.column.Sorting.ToString();
                }
                else if (this.sortElement != null)
                {
                    base.Elements.Remove(this.sortElement);
                    this.sortElement = null;
                }
            }

            protected override void ApplyElementFormats(XElement element)
            {
                base.ApplyElementFormats(element);
                QueryColumnsPanel.EditModeKind editMode = base.parentPanel.EditMode;
                if (element == this.attrElement)
                {
                    element.ReadOnly = (editMode != QueryColumnsPanel.EditModeKind.All) &&
                                       (editMode != QueryColumnsPanel.EditModeKind.FixedList);
                }
                else if (element == this.titleElement)
                {
                    element.ReadOnly = (editMode == QueryColumnsPanel.EditModeKind.SortingOnly) ||
                                       (editMode == QueryColumnsPanel.EditModeKind.None);
                }
                else if (element != base.button)
                {
                    element.ReadOnly = editMode == QueryColumnsPanel.EditModeKind.None;
                }
            }

            protected internal virtual void AttrElementContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    base.column.Expr.Value = this.attrElement.Value;
                    EntityAttrExpr data = (EntityAttrExpr) this.attrElement.Data;
                    base.column.Expr.Value = this.attrElement.Value;
                }
            }

            protected virtual void AttrElementTextAdjusting(object sender, TextAdjustingEventArgs e)
            {
                if (!base.Refreshing)
                {
                    XElement element = (XElement) sender;
                    EntityAttrExpr data = (EntityAttrExpr) element.Data;
                    e.Text = this.GetAttributeCaption(data.Attribute);
                }
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

            internal override void InternalRefreshByColumn()
            {
                if (this.attrElement == null)
                {
                    this.attrElement = new LabelListXElement();
                    base.parentPanel.FillEntityElement(this.attrElement);
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
                    this.attrElement.Text = this.GetAttributeCaption(attribute);
                }
            }

            protected internal virtual void SortContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    if (element.Value == "NotSorted")
                    {
                        base.column.Sorting = Korzh.EasyQuery.SortDirection.None;
                    }
                    else if (element.Value == "Ascending")
                    {
                        base.column.Sorting = Korzh.EasyQuery.SortDirection.Ascending;
                    }
                    else
                    {
                        base.column.Sorting = Korzh.EasyQuery.SortDirection.Descending;
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
                get { return "ENTATTR"; }
            }

            public override string TypeName
            {
                get { return STypeName; }
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