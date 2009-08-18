namespace Korzh.EasyQuery
{
    using System;

    public class AggrFunction
    {
        private string caption;
        private string displayFormat;
        private bool enabled;
        private string id;
        private int paramCount = 1;
        private string sqlExpr;

        public AggrFunction(string id, string caption, string sqlExpr, string format)
        {
            this.id = id;
            this.caption = caption;
            this.sqlExpr = sqlExpr;
            this.displayFormat = format;
            this.enabled = true;
            this.CalcParamCount();
        }

        private void CalcParamCount()
        {
            int num = 0;
            do
            {
                num++;
            }
            while (this.sqlExpr.IndexOf("{expr" + num.ToString() + "}") >= 0);
            this.paramCount = num - 1;
        }

        public string Caption
        {
            get
            {
                return this.caption;
            }
            set
            {
                this.caption = value;
            }
        }

        public string DisplayFormat
        {
            get
            {
                return this.displayFormat;
            }
            set
            {
                if (value != this.displayFormat)
                {
                    this.displayFormat = value;
                }
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public string MainText
        {
            get
            {
                int index = this.displayFormat.IndexOf("[[");
                int num2 = this.displayFormat.IndexOf("]]", (int) (index + 2));
                string str = this.displayFormat.Substring(index + 2, (num2 - index) - 2).Trim();
                if (!(str != ""))
                {
                    return this.Caption;
                }
                return str;
            }
        }

        public int ParamCount
        {
            get
            {
                return this.paramCount;
            }
        }

        public string SqlExpr
        {
            get
            {
                return this.sqlExpr;
            }
        }
    }
}

