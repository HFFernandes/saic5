namespace Korzh.WinControls.XControls
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Xml;

    public class ValueItemList : ArrayList
    {
        private ListControl defaultControl;
        private string emptyText;
        private ValueItem parent;
        private int updating;

        public ValueItemList() : this(null)
        {
        }

        public ValueItemList(ValueItem parent)
        {
            this.emptyText = "(empty)";
            this.parent = parent;
        }

        public override int Add(object value)
        {
            ((ValueItem) value).parent = this.parent;
            int num = base.Add(value);
            this.OnChildChanged();
            return num;
        }

        public ValueItem Add(string text, string fvalue)
        {
            return this.Add(text, fvalue, "", "");
        }

        public ValueItem Add(string text, string fvalue, string action)
        {
            return this.Add(text, fvalue, action, "");
        }

        public ValueItem Add(string text, string fvalue, string action, string hint)
        {
            ValueItem item = new ValueItem(text, fvalue, action, hint);
            this.Add(item);
            return item;
        }

        public void BeginUpdate()
        {
            this.updating++;
        }

        public override void Clear()
        {
            base.Clear();
            this.OnChildChanged();
        }

        public void EndUpdate()
        {
            this.updating--;
            if (this.updating == 0)
            {
                this.OnChildChanged();
            }
        }

        public override void Insert(int index, object value)
        {
            ((ValueItem) value).parent = this.parent;
            base.Insert(index, value);
            this.OnChildChanged();
        }

        public void LoadFromXml(string xml)
        {
            this.BeginUpdate();
            this.Clear();
            if ((xml != null) && (xml != string.Empty))
            {
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
                    this.Add(str2, innerText, "", "");
                }
            }
            else
            {
                this.Add(this.emptyText, "", "", "");
            }
            this.EndUpdate();
        }

        protected virtual void OnChildChanged()
        {
            if (this.updating == 0)
            {
                if (this.defaultControl != null)
                {
                    this.defaultControl.RefillItems(this);
                }
                if (this.parent != null)
                {
                    this.parent.ChildChanged();
                }
            }
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
            this.OnChildChanged();
        }

        public ListControl DefaultControl
        {
            get
            {
                return this.defaultControl;
            }
            set
            {
                if (this.defaultControl != value)
                {
                    this.defaultControl = value;
                }
            }
        }

        public string EmptyText
        {
            get
            {
                return this.emptyText;
            }
            set
            {
                this.emptyText = value;
            }
        }

        public ValueItem this[int index]
        {
            get
            {
                return (ValueItem) base[index];
            }
            set
            {
                base[index] = value;
                this.OnChildChanged();
            }
        }
    }
}

