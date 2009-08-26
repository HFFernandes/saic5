namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.Design;
    using System.Web.UI.WebControls;

    [ToolboxBitmap(typeof (XPanel)), Designer(typeof (ControlDesigner))]
    public class XPanel : Panel, INamingContainer
    {
        private XAppearance appearance;
        private XRowList rows;
        private TextStorage texts = new TextStorage();

        public event ActionEventHandler Action;

        public event ValidateValueEventHandler ValidateValue;

        static XPanel()
        {
            XElement.Register(new TextXElement.Creator());
            XElement.Register(new LabelXElement.Creator());
            XElement.Register(new EditXElement.Creator());
            XElement.Register(new LabelListXElement.Creator());
            XElement.Register(new DateTimeXElement.Creator());
        }

        public XPanel()
        {
            this.InitAppearance();
            this.rows = this.CreateRowList();
            this.BorderStyle = BorderStyle.Solid;
            this.BorderColor = Color.Black;
            this.BorderWidth = new Unit(1);
            this.Width = new Unit(300);
            this.Height = new Unit(100);
        }

        protected virtual XAppearance CreateAppearance()
        {
            return new XAppearance();
        }

        protected virtual XRowList CreateRowList()
        {
            return new XRowList(this);
        }

        protected internal virtual void DoAction(object sender, string actionName, object data)
        {
            if (string.Compare(actionName, "AddRow", true) == 0)
            {
                this.DoAddRow();
            }
            else if (this.Action != null)
            {
                ActionEventArgs e = new ActionEventArgs(actionName, data);
                this.Action(sender, e);
            }
        }

        protected virtual void DoAddRow()
        {
        }

        protected virtual void DoListRequest(ListXElement element, string listName)
        {
        }

        protected internal virtual void DoSignal(object sender, Signals signalID, string[] paramList)
        {
            int num;
            switch (signalID)
            {
                case Signals.KeyCtrlDown:
                    num = int.Parse(paramList[0]);
                    if (num >= (this.Rows.Count - 1))
                    {
                        break;
                    }
                    this.MoveRow(num, num + 1);
                    return;

                case Signals.KeyUp:
                    break;

                case Signals.KeyCtrlUp:
                    num = int.Parse(paramList[0]);
                    if (num <= 0)
                    {
                        break;
                    }
                    this.MoveRow(num, num - 1);
                    return;

                case Signals.ListRequest:
                    this.DoListRequest((ListXElement) sender, paramList[0]);
                    break;

                default:
                    return;
            }
        }

        internal void ElementValidateValue(XElement sender, ValidateValueEventArgs e)
        {
            this.OnValidateValue(e);
        }

        private void InitAppearance()
        {
            if (this.appearance == null)
            {
                this.appearance = this.CreateAppearance();
            }
        }

        public virtual void MoveRow(int currentIndex, int newIndex)
        {
            this.Rows.Move(currentIndex, newIndex);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Ajax.IsInAsyncPostBack(this.Page))
            {
                foreach (ScriptPopupMenu menu in this.MenuPool)
                {
                    menu.IsRendered = false;
                }
            }
            base.OnLoad(e);
        }

        protected internal virtual void OnRowAdded(XRow row)
        {
        }

        protected internal virtual void OnRowListChanged()
        {
        }

        protected virtual void OnValidateValue(ValidateValueEventArgs e)
        {
            if (this.ValidateValue != null)
            {
                this.ValidateValue(this, e);
            }
        }

        protected void PlaceRow(XRow row)
        {
            this.PlaceRowAt(row, this.Rows.Count - 1);
        }

        protected internal void PlaceRowAt(XRow row, int index)
        {
            if (row != null)
            {
                if (this.Controls.Contains(row.rowControl))
                {
                    this.Controls.Remove(row.rowControl);
                }
                row.Parent = this;
                if (!this.Controls.Contains(row.rowControl))
                {
                    this.Controls.AddAt(index, row.rowControl);
                }
            }
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            if (this.Rows.Count > 0)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Style, "border:none;");
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                foreach (XRow row in this.Rows)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    row.RenderRow(writer);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
        }

        public virtual void ShiftRowLevel(int rowIndex, bool up)
        {
            if (((rowIndex >= 0) && (rowIndex < this.rows.Count)) &&
                ((this.rows[rowIndex] != null) && this.rows[rowIndex].AllowShifting))
            {
                int num = up ? 1 : -1;
                int level = this.rows[rowIndex].Level;
                if ((level != 0) || up)
                {
                    this.rows[rowIndex].Level += num;
                    int num3 = rowIndex + 1;
                    while ((num3 >= 0) && (num3 < this.rows.Count))
                    {
                        if (this.rows[num3] != null)
                        {
                            if (this.rows[num3].Level <= level)
                            {
                                return;
                            }
                            this.rows[num3].Level += num;
                            num3++;
                        }
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
         PersistenceMode(PersistenceMode.Attribute), NotifyParentProperty(true), Category("Appearance")]
        public XAppearance Appearance
        {
            get { return this.appearance; }
        }

        public ScriptPopupMenuList MenuPool
        {
            get
            {
                object obj2 = this.Page.Session[this.ID + "_MenuPool"];
                if (obj2 == null)
                {
                    obj2 = new ScriptPopupMenuList();
                    this.Page.Session[this.ID + "_MenuPool"] = obj2;
                }
                return (ScriptPopupMenuList) obj2;
            }
        }

        [Browsable(false)]
        public XRowList Rows
        {
            get { return this.rows; }
        }

        public TextStorage Texts
        {
            get { return this.texts; }
        }

        [TypeConverter(typeof (ExpandableObjectConverter))]
        public class XAppearance : IStateManager
        {
            private bool isTrackingViewState;
            private Korzh.WebControls.ScriptMenuStyle scriptMenuStyle = new Korzh.WebControls.ScriptMenuStyle();
            private StateBag viewState;

            public virtual void LoadViewState(object savedState)
            {
                if (savedState != null)
                {
                    Pair pair = (Pair) savedState;
                    ((IStateManager) this.ViewState).LoadViewState(pair.First);
                    ((IStateManager) this.ScriptMenuStyle).LoadViewState(pair.Second);
                }
            }

            public virtual object SaveViewState()
            {
                object obj2 = null;
                if (this.viewState != null)
                {
                    object x = ((IStateManager) this.viewState).SaveViewState();
                    object y = ((IStateManager) this.ScriptMenuStyle).SaveViewState();
                    obj2 = new Pair(x, y);
                }
                return obj2;
            }

            public virtual void TrackViewState()
            {
                this.isTrackingViewState = true;
                if (this.viewState != null)
                {
                    ((IStateManager) this.viewState).TrackViewState();
                    ((IStateManager) this.ScriptMenuStyle).TrackViewState();
                }
            }

            [DefaultValue("MM/dd/yyyy"), NotifyParentProperty(true)]
            public string DateFormat
            {
                get
                {
                    object obj2 = this.ViewState["DateFormat"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return "MM/dd/yyyy";
                }
                set { this.ViewState["DateFormat"] = value; }
            }

            public string DateTimeFormat
            {
                get { return (this.DateFormat + " " + this.TimeFormat); }
            }

            [NotifyParentProperty(true), DefaultValue("")]
            public string ElementCssClass
            {
                get
                {
                    object obj2 = this.ViewState["ElementCssClass"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return string.Empty;
                }
                set { this.ViewState["ElementCssClass"] = value; }
            }

            [DefaultValue(4), NotifyParentProperty(true)]
            public int ElementSpacing
            {
                get
                {
                    object obj2 = this.ViewState["ElementSpacing"];
                    if (obj2 != null)
                    {
                        return (int) obj2;
                    }
                    return 4;
                }
                set { this.ViewState["ElementSpacing"] = value; }
            }

            [NotifyParentProperty(true), DefaultValue(2)]
            public int LeftMargin
            {
                get
                {
                    object obj2 = this.ViewState["LeftMargin"];
                    if (obj2 != null)
                    {
                        return (int) obj2;
                    }
                    return 2;
                }
                set { this.ViewState["LeftMargin"] = value; }
            }

            [NotifyParentProperty(true), DefaultValue(30)]
            public int LevelSpacing
            {
                get
                {
                    object obj2 = this.ViewState["LevelSpacing"];
                    if (obj2 != null)
                    {
                        return (int) obj2;
                    }
                    return 30;
                }
                set { this.ViewState["LevelSpacing"] = value; }
            }

            [NotifyParentProperty(true), DefaultValue(typeof (Color), "Blue"), TypeConverter(typeof (WebColorConverter))
            ]
            public Color LinkColor
            {
                get
                {
                    object obj2 = this.ViewState["LinkColor"];
                    if (obj2 != null)
                    {
                        return (Color) obj2;
                    }
                    return Color.Blue;
                }
                set { this.ViewState["LinkColor"] = value; }
            }

            [NotifyParentProperty(true), DefaultValue("")]
            public string RowCssClass
            {
                get
                {
                    object obj2 = this.ViewState["RowCssClass"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return string.Empty;
                }
                set { this.ViewState["RowCssClass"] = value; }
            }

            [DefaultValue(0x12), NotifyParentProperty(true)]
            public int RowHeight
            {
                get
                {
                    object obj2 = this.ViewState["RowHeight"];
                    if (obj2 != null)
                    {
                        return (int) obj2;
                    }
                    return 0x12;
                }
                set { this.ViewState["RowHeight"] = value; }
            }

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true),
             PersistenceMode(PersistenceMode.Attribute)]
            public Korzh.WebControls.ScriptMenuStyle ScriptMenuStyle
            {
                get { return this.scriptMenuStyle; }
                set { this.scriptMenuStyle = value; }
            }

            bool IStateManager.IsTrackingViewState
            {
                get { return this.isTrackingViewState; }
            }

            [NotifyParentProperty(true), DefaultValue("HH:mm:ss")]
            public string TimeFormat
            {
                get
                {
                    object obj2 = this.ViewState["TimeFormat"];
                    if (obj2 != null)
                    {
                        return (string) obj2;
                    }
                    return "HH:mm:ss";
                }
                set { this.ViewState["TimeFormat"] = value; }
            }

            protected virtual StateBag ViewState
            {
                get
                {
                    if (this.viewState == null)
                    {
                        this.viewState = new StateBag(false);
                        if (this.isTrackingViewState)
                        {
                            ((IStateManager) this.viewState).TrackViewState();
                        }
                    }
                    return this.viewState;
                }
            }
        }
    }
}