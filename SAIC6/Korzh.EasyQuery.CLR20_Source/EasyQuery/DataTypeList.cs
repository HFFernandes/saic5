namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DataTypeList : ArrayList
    {
        public DataTypeList()
        {
        }

        public DataTypeList(DataType[] typeList)
        {
            foreach (DataType type in typeList)
            {
                this.Add(type);
            }
        }

        public DataTypeList(string listStr)
        {
            if ((listStr != null) && (listStr != string.Empty))
            {
                this.CommaText = listStr;
            }
        }

        public override int Add(object value)
        {
            if (!(value is DataType))
            {
                throw new ArgumentException("value must be of type DataType.", "value");
            }
            int index = this.IndexOf(value);
            if (index >= 0)
            {
                return index;
            }
            return base.Add(value);
        }

        public override void Insert(int index, object value)
        {
            if (!(value is DataType))
            {
                throw new ArgumentException("value must be of type DataType.", "value");
            }
            if (!this.Contains(value))
            {
                base.Insert(index, value);
            }
        }

        public string CommaText
        {
            get
            {
                string str = "";
                foreach (DataType type in this)
                {
                    if (str != "")
                    {
                        str = str + ", ";
                    }
                    str = str + type.ToString();
                }
                return str;
            }
            set
            {
                this.Clear();
                if (value != null)
                {
                    char[] separator = new char[] { ',' };
                    foreach (string str in value.Split(separator))
                    {
                        this.Add(Enum.Parse(typeof(DataType), str.Trim(), true));
                    }
                }
            }
        }

        public DataType this[int index]
        {
            get
            {
                return (DataType) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

