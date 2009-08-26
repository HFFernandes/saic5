namespace Korzh.EasyQuery.WebControls
{
    using Korzh.EasyQuery;
    using Korzh.WebControls.XControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Resources;
    using System.Web.UI;

    [ToolboxBitmap(typeof (SortColumnsPanel))]
    public class SortColumnsPanel : QueryColumnsPanel
    {
        private static ResourceManager resources = new ResourceManager("Korzh.EasyQuery.WebControls.SortColumnsPanel",
                                                                       typeof (SortColumnsPanel).Assembly);

        internal ValueItemList sortButtonMenuList;
        internal ValueItemList sortElementMenuList;

        protected override void AddEntities(ValueItemList listItems, DataModel.Entity parentEntity)
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
                if (attr.UseInResult && attr.UseInSorting)
                {
                    ValueItem item2 = new ValueItem(attr.Caption, attr.ID, "");
                    listItems.Add(item2);
                }
            }
        }

        protected override void AddRowByColumn(Query.Column column)
        {
            ColumnRow newrow = new SimpleSortingRow(this, column, "", false);
            newrow.RefreshByColumn();
            base.Rows.Add(newrow);
        }

        protected override void AddSimpleColumn(string attrID)
        {
            base.CheckQuery();
            DataModel.EntityAttr defaultUIRAttribute = base.Model.GetDefaultUIRAttribute(true);
            if (defaultUIRAttribute != null)
            {
                Query.Column column = new Query.Column();
                column.Expr = new EntityAttrExpr(base.Model, defaultUIRAttribute);
                if (attrID != null)
                {
                    column.Expr.Value = attrID;
                }
                column.Caption = ((EntityAttrExpr) column.Expr).Attribute.Caption;
                column.Sorting = SortDirection.Ascending;
                base.justSortedColumns.Add(column);
            }
        }

        protected override void DoAction(object sender, string actionName, object data)
        {
            base.CheckQuery();
            if ((sender is ColumnRow.ColumnButton) || (sender is ButtonXElement))
            {
                SimpleSortingRow parentRow = (SimpleSortingRow) ((XElement) sender).ParentRow;
                if (string.Compare(actionName, "Ascending", true) == 0)
                {
                    parentRow.column.Sorting = SortDirection.Ascending;
                }
                else if (string.Compare(actionName, "Descending", true) == 0)
                {
                    parentRow.column.Sorting = SortDirection.Descending;
                }
                else if (string.Compare(actionName, "DeleteSorting", true) == 0)
                {
                    parentRow.column.Sorting = SortDirection.None;
                    base.sortedColumns.Remove(parentRow.column);
                    base.justSortedColumns.Remove(parentRow.column);
                }
                else if (string.Compare(actionName, "MoveRowUp", true) == 0)
                {
                    base.sortedColumns.Move(parentRow.Column, -1);
                }
                else if (string.Compare(actionName, "MoveRowDown", true) == 0)
                {
                    base.sortedColumns.Move(parentRow.Column, 1);
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

        protected override void InitSpecialLists()
        {
            base.entityList = new ValueItemList(this.ID + "_entities");
            base.sortingMenuList = new ValueItemList(this.ID + "_sortingMenu");
            base.sortingMenuList.Add(new ValueItem(base.Texts.Get("CmdNotSorted"), "NotSorted", "NotSorted"));
            base.sortingMenuList.Add(new ValueItem(base.Texts.Get("CmdAscending"), "Ascending", "Ascending"));
            base.sortingMenuList.Add(new ValueItem(base.Texts.Get("CmdDescending"), "Descending", "Descending"));
            this.sortButtonMenuList = new ValueItemList(this.ID + "_sortBtnMenu");
            this.sortButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdAscending"), "Ascending", "Ascending"));
            this.sortButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdDescending"), "Descending", "Descending"));
            this.sortButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdMoveUp"), "MoveRowUp", "MoveRowUp"));
            this.sortButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdMoveDown"), "MoveRowDown", "MoveRowDown"));
            this.sortButtonMenuList.Add(new ValueItem(base.Texts.Get("CmdDeleteSorting"), "DeleteSorting",
                                                      "DeleteSorting"));
            this.sortElementMenuList = new ValueItemList(this.ID + "_sortElemMenu");
            this.sortElementMenuList.Add(new ValueItem(base.Texts.Get("CmdAscending"), "Ascending"));
            this.sortElementMenuList.Add(new ValueItem(base.Texts.Get("CmdDescending"), "Descending"));
            base.specListsInitialized = true;
        }

        protected override void OnRowAdded(XRow row)
        {
            base.OnRowAdded(row);
        }

        public override void RefreshByColumns()
        {
            base.CheckQuery();
            base.Rows.Clear();
            if (!this.AllowAddRow)
            {
                base.addRow = null;
            }
            else
            {
                this.RecreateAdditionRow();
            }
            for (int i = 0; i < base.sortedColumns.Count; i++)
            {
                this.AddRowByColumn(base.sortedColumns[i]);
            }
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Appearance.ElementSpacing.ToString());
            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "1");
            writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
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
            if (base.ShowHeaders && (base.Rows.Count > 0))
            {
                if (base.HeaderCssClass != string.Empty)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, base.HeaderCssClass);
                }
                else
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Style,
                                        "color:Black;font-size:10pt;font-family:Tahoma, Verdana, Geneva, Arial");
                }
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(base.HeaderBgColor));
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("");
                writer.RenderEndTag();
                writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(base.HeaderBgColor));
                writer.AddAttribute(HtmlTextWriterAttribute.Width, base.ExprColumnWidth);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Column");
                writer.RenderEndTag();
                writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, ColorTranslator.ToHtml(base.HeaderBgColor));
                writer.AddAttribute(HtmlTextWriterAttribute.Width, base.SortingColumnWidth);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Sorting");
                writer.RenderEndTag();
                writer.RenderEndTag();
            }
            foreach (SimpleSortingRow row in base.Rows)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Height, this.Appearance.RowHeight.ToString());
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                row.Elements[0].RenderControl(writer);
                if (this.Appearance.ShowMoveUpDownButtons)
                {
                    writer.Write("&nbsp;");
                    row.Elements[1].RenderControl(writer);
                    writer.Write("&nbsp;");
                    row.Elements[2].RenderControl(writer);
                }
                writer.RenderEndTag();
                int num = this.Appearance.ShowMoveUpDownButtons ? 3 : 1;
                writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "true");
                writer.AddAttribute(HtmlTextWriterAttribute.Width, base.ExprColumnWidth);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                row.Elements[num].RenderControl(writer);
                writer.RenderEndTag();
                num++;
                writer.AddAttribute(HtmlTextWriterAttribute.Class, row.ElementCssClass);
                writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "true");
                writer.AddAttribute(HtmlTextWriterAttribute.Width, base.SortingColumnWidth);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                row.Elements[num].RenderControl(writer);
                writer.RenderEndTag();
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            if (base.addRow != null)
            {
                base.addRow.RenderRow(writer);
            }
        }

        [NotifyParentProperty(true), DefaultValue(true), Browsable(true)]
        public virtual bool AllowAddRow
        {
            get
            {
                object obj2 = this.ViewState["AllowAddRow"];
                if (obj2 != null)
                {
                    return (bool) obj2;
                }
                return true;
            }
            set { this.ViewState["AllowAddRow"] = value; }
        }

        [DefaultValue(true), NotifyParentProperty(false), Browsable(false)]
        public override bool AllowAggrColumns
        {
            get { return true; }
            set { }
        }

        [Browsable(false), NotifyParentProperty(false), DefaultValue(true)]
        public override bool AllowEditCaptions
        {
            get { return true; }
            set { }
        }

        [DefaultValue(true), Browsable(false), NotifyParentProperty(false)]
        public override bool AllowSorting
        {
            get { return true; }
            set { }
        }

        [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public QCPAppearance Appearance
        {
            get { return base.Appearance; }
        }

        [Browsable(false)]
        private QueryColumnsPanel.EditModeKind EditMode
        {
            get { return QueryColumnsPanel.EditModeKind.All; }
        }

        [NotifyParentProperty(false), Browsable(false), DefaultValue("")]
        public string TitleColumnWidth
        {
            get { return ""; }
            set { }
        }

        public class SimpleSortingRow : Korzh.EasyQuery.WebControls.ColumnRow
        {
            internal TextXElement colonElement;
            private Korzh.EasyQuery.WebControls.ColumnRow columnRow;
            internal TextXElement dispNameElement;
            internal ListXElement entityElement;
            internal ListXElement sortElement;

            public SimpleSortingRow(SortColumnsPanel aPanel, Query.Column aColumn, string xmlText, bool useCheckBox)
                : base(aPanel, aColumn, useCheckBox)
            {
                base.button.Items = ((SortColumnsPanel) base.parentPanel).sortButtonMenuList;
            }

            protected override void AddCommonElements()
            {
                base.button.Items = ((SortColumnsPanel) base.parentPanel).sortButtonMenuList;
            }

            protected internal virtual void ExprContentChanged(object sender, ContentChangedEventArgs e)
            {
                if ((!base.Refreshing && (this.entityElement == ((XElement) sender))) && e.ValueChanged)
                {
                    Expression data = (Expression) this.entityElement.Data;
                    data.Value = this.entityElement.Value;
                    data.Text = this.entityElement.Text;
                    base.column.Expr.Value = this.entityElement.Value;
                    base.column.Caption = this.entityElement.Text;
                }
            }

            internal override void InternalRefreshByColumn()
            {
                if (((SortColumnsPanel) base.parentPanel).columns.IndexOf(base.Column) >= 0)
                {
                    if (this.dispNameElement == null)
                    {
                        this.dispNameElement = new TextXElement();
                        base.Elements.Add(this.dispNameElement);
                    }
                    if (base.column.Caption != "")
                    {
                        this.dispNameElement.Value = base.column.Caption;
                    }
                    else
                    {
                        this.dispNameElement.Value = ((EntityAttrExpr) base.column.Expr).Attribute.Caption;
                    }
                }
                else
                {
                    if (this.entityElement == null)
                    {
                        this.entityElement = new LabelListXElement();
                        base.parentPanel.FillEntityElement(this.entityElement);
                        this.entityElement.ContentChanged += new ContentChangedEventHandler(this.ExprContentChanged);
                        base.Elements.Add(this.entityElement);
                    }
                    EntityAttrExpr expr = (EntityAttrExpr) base.column.Expr;
                    this.entityElement.Data = expr;
                    DataModel.EntityAttr attribute = expr.Attribute;
                    this.entityElement.Value = attribute.ID;
                    this.entityElement.Text = attribute.Caption;
                }
                if (this.sortElement == null)
                {
                    this.sortElement = new LabelListXElement();
                    this.sortElement.Items = ((SortColumnsPanel) base.parentPanel).sortElementMenuList;
                    this.sortElement.ContentChanged += new ContentChangedEventHandler(this.SortContentChanged);
                    base.Elements.Add(this.sortElement);
                }
                this.sortElement.Value = base.column.Sorting.ToString();
            }

            protected internal virtual void SortContentChanged(object sender, ContentChangedEventArgs e)
            {
                if (!base.Refreshing && e.ValueChanged)
                {
                    XElement element = (XElement) sender;
                    if (element.Value == "Ascending")
                    {
                        base.column.Sorting = SortDirection.Ascending;
                    }
                    else
                    {
                        base.column.Sorting = SortDirection.Descending;
                    }
                }
            }

            public Korzh.EasyQuery.WebControls.ColumnRow ColumnRow
            {
                get { return this.columnRow; }
                set { this.columnRow = value; }
            }
        }
    }
}