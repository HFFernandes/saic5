namespace Korzh.EasyQuery
{
    using System;

    public class QueryTextFormats
    {
        private static QueryTextFormats defaultFormats = new QueryTextFormats();
        private HtmlFormats htmlFormatting = new HtmlFormats();
        private bool showEntityName = true;
        private bool useHtml;
        private bool useMathSymbolsForOperators;

        public static QueryTextFormats Default
        {
            get
            {
                return defaultFormats;
            }
        }

        public HtmlFormats HtmlFormatting
        {
            get
            {
                return this.htmlFormatting;
            }
        }

        public bool ShowEntityName
        {
            get
            {
                return this.showEntityName;
            }
            set
            {
                this.showEntityName = value;
            }
        }

        public bool UseHtml
        {
            get
            {
                return this.useHtml;
            }
            set
            {
                this.useHtml = value;
            }
        }

        public bool UseMathSymbolsForOperators
        {
            get
            {
                return this.useMathSymbolsForOperators;
            }
            set
            {
                this.useMathSymbolsForOperators = value;
            }
        }

        public class HtmlFormats
        {
            private string _operator = "<span style=\"color:blue\">{0}</span>";
            private string boolOperator = "<span style=\"color:black\">{0}</span>";
            private string boolOperatorRoot = "<br /><span style=\"color:black\">{0}</span><br />";
            private string bracketClose = "<br /> <span style=\"font-weight:800;\"> )</span>";
            private string bracketOpen = "{0} <span style=\"font-weight:800;\">(</span> <br /> ";
            private string expression = "<span style=\"color:red\">{0}</span>";
            private string text = "<span style=\"color:green\">{0}</span>";

            public string BoolOperator
            {
                get
                {
                    return this.boolOperator;
                }
                set
                {
                    this.boolOperator = value;
                }
            }

            public string BoolOperatorRoot
            {
                get
                {
                    return this.boolOperatorRoot;
                }
                set
                {
                    this.boolOperatorRoot = value;
                }
            }

            public string BracketClose
            {
                get
                {
                    return this.bracketClose;
                }
                set
                {
                    this.bracketClose = value;
                }
            }

            public string BracketOpen
            {
                get
                {
                    return this.bracketOpen;
                }
                set
                {
                    this.bracketOpen = value;
                }
            }

            public string Expression
            {
                get
                {
                    return this.expression;
                }
                set
                {
                    this.expression = value;
                }
            }

            public string Operator
            {
                get
                {
                    return this._operator;
                }
                set
                {
                    this._operator = value;
                }
            }

            public string Text
            {
                get
                {
                    return this.text;
                }
                set
                {
                    this.text = value;
                }
            }
        }
    }
}

