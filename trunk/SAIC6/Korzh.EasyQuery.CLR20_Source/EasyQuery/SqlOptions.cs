namespace Korzh.EasyQuery
{
    using System;
    using System.ComponentModel;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SqlOptions
    {
        private bool lazyJoins;
        private string limitClause = "";
        private bool selectDistinct;
        private string selectTop = "";

        [DefaultValue(false)]
        public bool LazyJoins
        {
            get
            {
                return this.lazyJoins;
            }
            set
            {
                this.lazyJoins = value;
            }
        }

        [DefaultValue("")]
        public string LimitClause
        {
            get
            {
                return this.limitClause;
            }
            set
            {
                this.limitClause = value;
            }
        }

        [DefaultValue(false)]
        public bool SelectDistinct
        {
            get
            {
                return this.selectDistinct;
            }
            set
            {
                this.selectDistinct = value;
            }
        }

        [DefaultValue("")]
        public string SelectTop
        {
            get
            {
                return this.selectTop;
            }
            set
            {
                this.selectTop = value;
            }
        }
    }
}

