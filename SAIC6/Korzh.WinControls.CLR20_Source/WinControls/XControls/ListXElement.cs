namespace Korzh.WinControls.XControls
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class ListXElement : LabelXElement
    {
        private bool autoSelectFirstItem;
        public static string DefaultListControlType = "MENU";
        private Korzh.WinControls.XControls.ListControl listControl;
        private string listName;
        private ValueItem rootItem;
        private string valueSeparator;

        public ListXElement() : this("TEXT")
        {
        }

        public ListXElement(string type) : base(type)
        {
            this.valueSeparator = ",";
            base.EmptyValueText = "[select value]";
            this.RecreateListControl(DefaultListControlType);
        }

        public void AddListItem(ValueItem parentItem, ValueItem newItem)
        {
            if (parentItem == null)
            {
                this.Items.Add(newItem);
            }
            else
            {
                parentItem.SubItems.Add(newItem);
            }
        }

        public ValueItem AddListItem(ValueItem parentItem, string text, string value)
        {
            return this.AddListItem(parentItem, text, value, "", "");
        }

        public ValueItem AddListItem(ValueItem parentItem, string text, string value, string action, string hint)
        {
            ValueItem newItem = new ValueItem(text, value, action, hint);
            this.AddListItem(parentItem, newItem);
            return newItem;
        }

        protected override string CalcNewValue()
        {
            this.listControl.UpdateItemsBySelection(this.Items);
            return this.GetValueByItems();
        }

        protected override string CoreGetTextAdjustedByValue(string newValue)
        {
            ValueItem item;
            if (!(newValue != ""))
            {
                return base.CoreGetTextAdjustedByValue(newValue);
            }
            if (this.listControl.MultiSelect)
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
                this.SelectItemsByValue();
                if ((!this.listControl.MultiSelect && (this.listControl.selectedItem == null)) && this.AutoSelectFirstItem)
                {
                    this.SelectFirstItem();
                }
            }
        }

        protected virtual Korzh.WinControls.XControls.ListControl CreateListControl(string controlType)
        {
            Korzh.WinControls.XControls.ListControl control = null;
            if (control != null)
            {
                return control;
            }
            if (string.Compare(controlType, "LISTBOX", true) == 0)
            {
                return new ListBoxListControl(false);
            }
            if (string.Compare(controlType, "MULTILIST", true) == 0)
            {
                return new ListBoxListControl(true);
            }
            return new MenuListControl();
        }

        protected virtual void CreateRootItem()
        {
            this.rootItem = new ValueItem(string.Empty, string.Empty);
            this.rootItem.Changed += new EventHandler(this.DoItemsChanged);
        }

        internal void DoInputAccepted()
        {
            base.RollUp(true);
            if ((!this.listControl.MultiSelect && (this.listControl.SelectedItem != null)) && ((this.listControl.SelectedItem.Action != "") && (base.parentRow != null)))
            {
                base.parentRow.ElementAction(this, this.listControl.SelectedItem.Action);
            }
        }

        internal void DoInputCanceled()
        {
            base.RollUp(false);
        }

        protected virtual void DoItemsChanged(object sender, EventArgs e)
        {
            if (this.Items != null)
            {
                this.listControl.RefillItems(this.Items);
                if (this.Items.DefaultControl == null)
                {
                    this.Items.DefaultControl = this.listControl;
                }
            }
        }

        public bool GetItemByValue(string val, out ValueItem resItem)
        {
            resItem = null;
            foreach (ValueItem item2 in this.Items)
            {
                ValueItem item;
                if (item2.GetItemByValue(val, out item))
                {
                    resItem = item;
                    return true;
                }
            }
            return false;
        }

        protected virtual string GetValueByItems()
        {
            if (this.listControl.MultiSelect)
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
            if (this.listControl.SelectedItem != null)
            {
                return this.listControl.SelectedItem.Value;
            }
            return "";
        }

        protected override void HideControl()
        {
            this.listControl.Hide();
        }

        private void InternalParseItemXmlNode(XmlNode node, ValueItem parent)
        {
            string str = "";
            string text = "";
            string action = "";
            string hint = "";
            if (node.Attributes != null)
            {
                if (node.Attributes["Value"] != null)
                {
                    str = node.Attributes["Value"].Value;
                }
                if (node.Attributes["Text"] != null)
                {
                    text = node.Attributes["Text"].Value;
                }
                if (node.Attributes["Action"] != null)
                {
                    action = node.Attributes["Action"].Value;
                }
                if (node.Attributes["Action"] != null)
                {
                    hint = node.Attributes["Hint"].Value;
                }
            }
            ValueItem item = this.AddListItem(parent, text, str, action, hint);
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                this.InternalParseItemXmlNode(node.ChildNodes[i], item);
            }
        }

        private bool IsSuitableControl(Korzh.WinControls.XControls.ListControl control)
        {
            return ((this.listControl != null) && control.GetType().IsSubclassOf(this.listControl.GetType()));
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
                    if ((base.ActionName != "") && (base.parentRow != null))
                    {
                        base.parentRow.ElementAction(this, base.ActionName);
                    }
                    if (((this.Items == null) || (this.Items.Count == 0)) && (this.listName != null))
                    {
                        this.RequestList(this.listName);
                    }
                    if (this.Items.Count != 0)
                    {
                        base.DropDown();
                    }
                }
            }
        }

        protected virtual void OnItemsReassigned()
        {
            if (this.Items != null)
            {
                if ((this.Items.DefaultControl != null) && this.IsSuitableControl(this.Items.DefaultControl))
                {
                    this.listControl = this.Items.DefaultControl;
                }
                else if (this.listControl != null)
                {
                    this.listControl.RefillItems(this.Items);
                }
                if ((this.Items.DefaultControl == null) && (this.listControl != null))
                {
                    this.Items.DefaultControl = this.listControl;
                }
            }
        }

        public override void ParseXmlNode(XmlNode node)
        {
            XmlAttribute attribute = node.Attributes["ListName"];
            this.listName = (attribute != null) ? attribute.Value : null;
            if (this.listName != null)
            {
                this.RequestList(this.listName);
            }
            else
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    this.InternalParseItemXmlNode(node.ChildNodes[i], null);
                }
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
            attribute = node.Attributes["Action"];
            if (attribute != null)
            {
                base.ActionName = attribute.Value;
            }
            attribute = node.Attributes["ControlType"];
            if (attribute != null)
            {
                this.RecreateListControl(attribute.Value);
            }
        }

        public void RecreateListControl(string controlType)
        {
            this.listControl = this.CreateListControl(controlType);
            if (this.Items != null)
            {
                this.listControl.RefillItems(this.Items);
                if (this.Items.DefaultControl == null)
                {
                    this.Items.DefaultControl = this.listControl;
                }
            }
        }

        protected virtual void RequestList(string listName)
        {
            string[] paramList = new string[] { listName };
            if (base.parentRow != null)
            {
                base.parentRow.ElementSignal(this, Signals.ListRequest, paramList);
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
            this.listControl.selectedItem = null;
            if (this.listControl.MultiSelect)
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
                this.listControl.selectedItem = item;
            }
        }

        protected override void ShowControl()
        {
            this.ShowListControl();
        }

        protected void ShowListControl()
        {
            this.SelectItemsByValue();
            this.listControl.SelectItems();
            this.listControl.Show(this, new Point(0, this.ElementControl.Height));
        }

        public override bool AllowList
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public bool AutoSelectFirstItem
        {
            get
            {
                return this.autoSelectFirstItem;
            }
            set
            {
                this.autoSelectFirstItem = value;
            }
        }

        public ValueItemList Items
        {
            get
            {
                if (this.rootItem == null)
                {
                    this.CreateRootItem();
                }
                return this.rootItem.SubItems;
            }
            set
            {
                if (this.Items != value)
                {
                    this.rootItem.SubItems = value;
                    this.OnItemsReassigned();
                }
            }
        }

        public string ListName
        {
            get
            {
                return this.listName;
            }
            set
            {
                this.listName = value;
            }
        }

        public static string TagName
        {
            get
            {
                return "LIST";
            }
        }

        public class Creator : XElement.ICreator
        {
            public XElement Create()
            {
                return new ListXElement();
            }

            public string TagName
            {
                get
                {
                    return ListXElement.TagName;
                }
            }
        }
    }
}

