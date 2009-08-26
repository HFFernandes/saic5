namespace Korzh.EasyQuery.WebControls
{
    using Korzh.EasyQuery;
    using Korzh.WebControls.XControls;
    using System;
    using System.Collections;

    public class ColumnRow : XRow
    {
        protected ColumnButton button;
        protected internal Korzh.EasyQuery.Query.Column column;
        internal static Hashtable Creators = new Hashtable();
        protected ButtonXElement downButton;
        protected internal QueryColumnsPanel parentPanel;
        private bool refreshing;
        protected ButtonXElement upButton;

        public ColumnRow(QueryColumnsPanel aPanel, Korzh.EasyQuery.Query.Column column, bool useCheckBox)
            : base(useCheckBox)
        {
            this.parentPanel = aPanel;
            this.column = column;
            base.ID = this.parentPanel.ID + "_row" + column.Index.ToString();
            this.button = new ColumnButton();
            this.button.MenuStyle.ItemMinWidth = 120;
            base.Elements.Add(this.button);
            if (this.parentPanel.Appearance.ShowMoveUpDownButtons &&
                ((this.parentPanel.EditMode == QueryColumnsPanel.EditModeKind.All) ||
                 (this.parentPanel.EditMode == QueryColumnsPanel.EditModeKind.FixedList)))
            {
                this.upButton = new ButtonXElement();
                this.upButton.ActionName = "MoveRowUp";
                this.upButton.EmptyValueText = "Press to move row up";
                this.SetUpButtonImage();
                base.Elements.Add(this.upButton);
                this.downButton = new ButtonXElement();
                this.downButton.ActionName = "MoveRowDown";
                this.downButton.EmptyValueText = "Press to move row down";
                this.SetDownButtonImage();
                base.Elements.Add(this.downButton);
            }
        }

        protected virtual void AddCommonElements()
        {
            this.button.Enabled = this.parentPanel.EditMode != QueryColumnsPanel.EditModeKind.None;
            if (this.column.AllowSorting && this.parentPanel.AllowSorting)
            {
                this.button.Items = this.parentPanel.colButtonMenuList;
            }
            else
            {
                this.button.Items = this.parentPanel.colButtonMenuListWOSorting;
            }
        }

        protected override void ApplyElementFormats(XElement element)
        {
            base.ApplyElementFormats(element);
            if (element is ColumnButton)
            {
                ((ColumnButton) element).MenuStyle.ItemMinWidth = 220;
                if (this.parentPanel != null)
                {
                    ((ColumnButton) element).ImageUrl = this.parentPanel.Appearance.ColumnButtonImageUrl;
                }
            }
            if (element == this.upButton)
            {
                this.SetUpButtonImage();
            }
            if (element == this.downButton)
            {
                this.SetDownButtonImage();
            }
        }

        public static ColumnRow Create(QueryColumnsPanel panel, string type, Korzh.EasyQuery.Query.Column column,
                                       bool useCheckBox)
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

        internal virtual void InternalRefreshByColumn()
        {
        }

        internal void RefreshByColumn()
        {
            if (!this.Refreshing)
            {
                this.Refreshing = true;
                try
                {
                    this.InternalRefreshByColumn();
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

        private void SetDownButtonImage()
        {
            Type type = typeof (ColumnRow);
            if (this.parentPanel.Appearance.DownButtonImageUrl != string.Empty)
            {
                this.downButton.ImageUrl = this.parentPanel.Appearance.DownButtonImageUrl;
            }
            else
            {
                this.downButton.ImageUrl = this.parentPanel.Page.ClientScript.GetWebResourceUrl(type,
                                                                                                "Korzh.EasyQuery.WebControls.Resources.XDownButton.gif");
            }
        }

        private void SetUpButtonImage()
        {
            Type type = typeof (ColumnRow);
            if (this.parentPanel.Appearance.UpButtonImageUrl != string.Empty)
            {
                this.upButton.ImageUrl = this.parentPanel.Appearance.UpButtonImageUrl;
            }
            else
            {
                this.upButton.ImageUrl = this.parentPanel.Page.ClientScript.GetWebResourceUrl(type,
                                                                                              "Korzh.EasyQuery.WebControls.Resources.XUpButton.gif");
            }
        }

        public Korzh.EasyQuery.Query.Column Column
        {
            get { return this.column; }
        }

        protected internal bool Refreshing
        {
            get { return this.refreshing; }
            set { this.refreshing = value; }
        }

        public static string STypeName
        {
            get { return ""; }
        }

        public virtual string TypeName
        {
            get { return STypeName; }
        }

        protected internal class ColumnButton : ButtonListXElement
        {
            protected override string CoreGetTextAdjustedByValue(string newValue)
            {
                return "";
            }

            protected override void PreRenderElementControl()
            {
                base.PreRenderElementControl();
                QueryColumnsPanel parentPanel = (QueryColumnsPanel) base.ParentPanel;
                string str = (parentPanel != null) ? parentPanel.Appearance.RowButtonTooltip : "";
                base.linkControl.Text = "ColumnButton";
                base.linkControl.ToolTip = str;
                if (base.ImageUrl == string.Empty)
                {
                    Type type = typeof (ColumnRow.ColumnButton);
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
}