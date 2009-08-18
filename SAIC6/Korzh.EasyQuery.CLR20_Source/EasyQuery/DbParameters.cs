namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DbParameters : ArrayList
    {
        public DbParam FindByName(string name)
        {
            foreach (DbParam param in this)
            {
                if (param.Name == name)
                {
                    return param;
                }
            }
            return null;
        }

        public string ConnectionString
        {
            get
            {
                return this["ConnectionString"];
            }
            set
            {
                this["ConnectionString"] = value;
            }
        }

        public string GateClass
        {
            get
            {
                return this["GateClass"];
            }
            set
            {
                this["GateClass"] = value;
            }
        }

        public DbParam this[int index]
        {
            get
            {
                return (DbParam) base[index];
            }
            set
            {
                base[index] = value;
            }
        }

        public string this[string name]
        {
            get
            {
                DbParam param = this.FindByName(name);
                if (param == null)
                {
                    return string.Empty;
                }
                return param.Value;
            }
            set
            {
                DbParam param = this.FindByName(name);
                if (param == null)
                {
                    param = new DbParam();
                    param.Name = name;
                    this.Add(param);
                }
                param.Value = value;
            }
        }

        public bool LoginPrompt
        {
            get
            {
                string str = this["LoginPrompt"];
                return (((str != null) && (str != "")) && bool.Parse(str));
            }
            set
            {
                this["LoginPrompt"] = value.ToString();
            }
        }
    }
}

