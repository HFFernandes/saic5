namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Web.UI;
    using System.Xml;

    public abstract class ListXElement : XElement, IPostBackEventHandler
    {
        private bool autoSelectFirstItem;
        private string controlType;
        private ValueItemList items;
        protected ListControl listControl;
        private string listName;
        private bool listWasChanged;
        private bool multiSelect;
        protected string selectedIDs;
        protected internal ValueItem selectedItem;
        private string valueSeparator;

        public ListXElement() : this("MENU")
        {
        }

        public ListXElement(string subType)
        {
            this.valueSeparator = ",";
            this.controlType = "MENU";
        }

        public override void ApplyFormats()
        {
            base.ApplyFormats();
        }

        protected override string CoreGetTextAdjustedByValue(string newValue)
        {
            ValueItem item;
            if (this.Items != null)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].Selected = false;
                }
            }
            if (!(newValue != ""))
            {
                return base.CoreGetTextAdjustedByValue(newValue);
            }
            if (this.MultiSelect)
            {
                StringTokenizer tokenizer = new StringTokenizer(new StringBuilder(newValue), this.valueSeparator, "");
                StringBuilder builder = new StringBuilder(200);
                for (string str = tokenizer.FirstToken(); str != null; str = tokenizer.NextToken())
                {
                    if (str != ",")
                    {
                        if (this.GetItemByValue(str, out item))
                        {
                            string text = item.Text;
                            if (text.IndexOf(",") >= 0)
                            {
                                text = "\"" + text + "\"";
                            }
                            builder.Append(text);
                        }
                    }
                    else
                    {
                        builder.Append(",");
                    }
                }
                return builder.ToString();
            }
            if (this.GetItemByValue(newValue, out item))
            {
                return item.Text;
            }
            return newValue;
        }

        protected override void CoreLaunch()
        {
            base.CoreLaunch();
            if (this.listName != null)
            {
                this.RequestList(this.listName);
                if (this.AutoSelectFirstItem)
                {
                    this.SelectFirstItem();
                }
            }
        }

        protected virtual ListControl CreateListControl()
        {
            return new KorzhMenuListControl(base.ParentPanel.MenuPool, this.Items, this);
        }

        public bool GetItemByValue(string value, out ValueItem resItem)
        {
            resItem = null;
            return ((this.Items != null) && this.Items.GetItemByValue(value, out resItem));
        }

        protected virtual string GetValueByItems()
        {
            if (this.MultiSelect)
            {
                StringBuilder builder = new StringBuilder(200);
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append(this.valueSeparator);
                        }
                        string str = this.Items[i].Value;
                        if (str.IndexOf(this.valueSeparator) >= 0)
                        {
                            str = "\"" + str.Replace("\"", "\"\"") + "\"";
                        }
                        builder.Append(str);
                    }
                }
                return builder.ToString();
            }
            if (this.SelectedItem != null)
            {
                return this.SelectedItem.Value;
            }
            return "";
        }

        private void InternalParseItemXmlNode(ValueItemList valueItems, XmlNode node, ValueItem parent)
        {
            string text = "";
            string fvalue = "";
            string action = "";
            if (node.Attributes != null)
            {
                if (node.Attributes["Value"] != null)
                {
                    fvalue = node.Attributes["Value"].Value;
                }
                if (node.Attributes["Text"] != null)
                {
                    text = node.Attributes["Text"].Value;
                }
                if (node.Attributes["Action"] != null)
                {
                    action = node.Attributes["Action"].Value;
                }
            }
            ValueItem item = new ValueItem(text, fvalue, action);
            valueItems.Add(item);
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                this.InternalParseItemXmlNode(valueItems, node.ChildNodes[i], item);
            }
        }

        protected virtual void ItemsChanged()
        {
            this.processSelectedIDs();
            this.ListChanged();
        }

        public void ListChanged()
        {
            this.listWasChanged = true;
        }

        public override void ParseXmlNode(XmlNode node)
        {
            XmlAttribute attribute = node.Attributes["ControlType"];
            if (attribute != null)
            {
                this.ControlType = attribute.Value;
            }
            if (this.ControlType == "MULTILIST")
            {
                this.MultiSelect = true;
            }
            attribute = node.Attributes["ListName"];
            if (attribute != null)
            {
                this.listName = attribute.Value;
                this.RequestList(this.listName);
            }
            else
            {
                ValueItemList valueItems = new ValueItemList("");
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    this.InternalParseItemXmlNode(valueItems, node.ChildNodes[i], null);
                }
                this.Items = valueItems;
                this.ListChanged();
            }
            attribute = node.Attributes["Value"];
            if (attribute != null)
            {
                base.Value = attribute.Value;
            }
            attribute = node.Attributes["Text"];
            if (attribute != null)
            {
                this.Text = attribute.Value;
            }
        }

        protected override void PreRenderElementControl()
        {
            if (this.listControl == null)
            {
                this.RecreateListControl();
            }
            if (this.listWasChanged)
            {
                this.listControl.ListChanged();
            }
            if ((this.listName != null) && ((this.Items == null) || (this.Items.Count == 0)))
            {
                this.RequestList(this.listName);
            }
            base.PreRenderElementControl();
            if (this.items != null)
            {
                if ((this.items.ID == null) || (this.items.ID == string.Empty))
                {
                    this.items.ID = this.ClientID + "_List";
                }
                this.listControl.MultiSelect = this.MultiSelect;
                this.SelectItemsByValue();
                this.listControl.RefillItems();
                this.listControl.IsInPartialRendering = Ajax.IsInAsyncPostBack(this.Page);
                this.listControl.Render(this.Page);
            }
        }

        protected virtual void processSelectedIDs()
        {
            if ((this.selectedIDs != null) && (this.Items != null))
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].Selected = false;
                }
                StringBuilder builder = new StringBuilder(200);
                StringTokenizer tokenizer = new StringTokenizer(new StringBuilder(this.selectedIDs), ",", "");
                for (string str = tokenizer.FirstToken(); str != null; str = tokenizer.NextToken())
                {
                    if (str != ",")
                    {
                        ValueItem itemByID = this.Items.GetItemByID(str);
                        if (itemByID != null)
                        {
                            itemByID.Selected = true;
                            if (builder.Length > 0)
                            {
                                builder.Append(",");
                            }
                            string str2 = itemByID.Value;
                            if (str2.IndexOf(this.valueSeparator) >= 0)
                            {
                                str2 = "\"" + str2.Replace("\"", "\"\"") + "\"";
                            }
                            builder.Append(str2);
                        }
                    }
                }
                base.Value = builder.ToString();
            }
        }

        protected void RecreateListControl()
        {
            this.listControl = this.CreateListControl();
        }

        protected void RequestList(string listName)
        {
            string[] paramList = new string[] {listName};
            if (base.ParentRow != null)
            {
                base.ParentRow.ElementSignal(this, Signals.ListRequest, paramList);
            }
            if (((this.Items != null) && (base.Value == string.Empty)) && (this.Items.Count > 0))
            {
                base.Value = this.Items[0].Value;
            }
        }

        public void SelectFirstItem()
        {
            if (this.Items.Count > 0)
            {
                base.Value = this.Items[0].Value;
            }
        }

        protected void SelectItemsByValue()
        {
            ValueItem item;
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].Selected = false;
            }
            this.selectedItem = null;
            if (this.MultiSelect)
            {
                StringTokenizer tokenizer = new StringTokenizer(new StringBuilder(base.Value), this.valueSeparator, "");
                for (string str = tokenizer.FirstToken(); str != null; str = tokenizer.NextToken())
                {
                    if ((str != this.valueSeparator) && this.GetItemByValue(str, out item))
                    {
                        item.Selected = true;
                    }
                }
            }
            else if (this.GetItemByValue(base.Value, out item))
            {
                item.Selected = true;
            }
        }

        void IPostBackEventHandler.RaisePostBackEvent(string EventArgument)
        {
            string postedValue = EventArgument;
            if (postedValue.StartsWith("__ALT:"))
            {
                postedValue = postedValue.Substring("__ALT:".Length);
                base.AltMenuItemClickHandler(postedValue);
            }
            else
            {
                if (postedValue.StartsWith("__MULTI:"))
                {
                    this.MultiSelect = true;
                    this.selectedIDs = postedValue.Substring("__MULTI:".Length);
                }
                else
                {
                    this.selectedIDs = postedValue;
                }
                this.processSelectedIDs();
            }
        }

        public override bool AllowList
        {
            get { return true; }
            set { }
        }

        public bool AutoSelectFirstItem
        {
            get { return this.autoSelectFirstItem; }
            set { this.autoSelectFirstItem = value; }
        }

        public string ControlType
        {
            get { return this.controlType; }
            set { this.controlType = value; }
        }

        public ValueItemList Items
        {
            get { return this.items; }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                    this.ItemsChanged();
                }
            }
        }

        public bool MultiSelect
        {
            get { return this.multiSelect; }
            set
            {
                this.multiSelect = value;
                if (this.listControl != null)
                {
                    this.listControl.MultiSelect = this.multiSelect;
                }
            }
        }

        public ValueItem SelectedItem
        {
            get { return this.selectedItem; }
        }

        public override string SubType
        {
            set
            {
                if (this.SubType != value)
                {
                    base.SubType = value;
                }
            }
        }
    }
}