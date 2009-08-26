namespace Korzh.WebControls.XControls
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Xml;

    [Serializable]
    public class ValueItemList : ArrayList
    {
        private string emptyText;
        private string id;
        private ValueItem parent;

        public ValueItemList(string id) : this(id, null)
        {
        }

        public ValueItemList(string id, ValueItem parent)
        {
            this.emptyText = "(empty)";
            this.id = id;
            this.parent = parent;
        }

        public override int Add(object value)
        {
            ((ValueItem) value).parent = this.parent;
            ((ValueItem) value).parentList = this;
            return base.Add(value);
        }

        public ValueItem Add(string text, string fvalue)
        {
            return this.Add(text, fvalue, string.Empty);
        }

        public ValueItem Add(string text, string fvalue, string action)
        {
            ValueItem item = new ValueItem(text, fvalue, action);
            this.Add(item);
            return item;
        }

        public ValueItem GetItemByID(string id)
        {
            foreach (ValueItem item in this)
            {
                ValueItem itemByID = item.GetItemByID(id);
                if (itemByID != null)
                {
                    return itemByID;
                }
            }
            return null;
        }

        public bool GetItemByValue(string value, out ValueItem resItem)
        {
            resItem = null;
            foreach (ValueItem item in this)
            {
                ValueItem item2;
                if (item.GetItemByValue(value, out item2))
                {
                    resItem = item2;
                    return true;
                }
            }
            return false;
        }

        public override void Insert(int index, object value)
        {
            ((ValueItem) value).parent = this.parent;
            ((ValueItem) value).parentList = this;
            base.Insert(index, value);
        }

        public void LoadFromXml(string xml)
        {
            if ((xml != null) && (xml != string.Empty))
            {
                this.Clear();
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                foreach (XmlNode node in document.DocumentElement.ChildNodes)
                {
                    string str2;
                    if (node.ChildNodes.Count <= 0)
                    {
                        continue;
                    }
                    string innerText = node.ChildNodes[0].InnerText;
                    if (node.ChildNodes.Count > 1)
                    {
                        str2 = node.ChildNodes[1].InnerText;
                    }
                    else
                    {
                        str2 = innerText;
                    }
                    str2 = str2.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");
                    this.Add(str2, innerText, string.Empty);
                }
            }
            else
            {
                this.Add(this.emptyText, string.Empty, string.Empty);
            }
        }

        public override void RemoveAt(int index)
        {
            ValueItem item = this[index];
            item.parent = null;
            item.parentList = null;
            base.RemoveAt(index);
        }

        public string EmptyText
        {
            get { return this.emptyText; }
            set { this.emptyText = value; }
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public ValueItem this[int index]
        {
            get { return (ValueItem) base[index]; }
            set { base[index] = value; }
        }

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder(string.Empty);
                foreach (ValueItem item in this)
                {
                    if (item.Selected)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append(",");
                        }
                        builder.Append(item.Value);
                    }
                }
                return builder.ToString();
            }
        }
    }
}