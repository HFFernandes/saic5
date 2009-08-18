namespace Korzh.EasyQuery
{
    using System;
    using System.ComponentModel;
    using System.Xml;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SqlFormats
    {
        private bool alphaAlias;
        private bool bracketJoins = true;
        private string dateFormat;
        private string dateTimeFormat;
        private string defaultSchemaName = "";
        private EOLSymbol eol = EOLSymbol.CRLF;
        private string falseValue = "false";
        private bool filterMode;
        private string lowerFuncName = "LOWER";
        private OrderByStyles orderByStyle;
        private DataTypeList quotedTypes = new DataTypeList();
        private char sqlQuote1 = '"';
        private char sqlQuote2 = '"';
        private Korzh.EasyQuery.SqlSyntax sqlSyntax = Korzh.EasyQuery.SqlSyntax.SQL2;
        protected internal int SubQueryLevel;
        private string timeFormat;
        private string trueValue = "true";
        private ColumnAliasesUsage useColumnAliases = ColumnAliasesUsage.IfNecessary;
        private bool useDbName;
        private bool useSchema = true;
        private char wildSymbol = '%';

        public SqlFormats()
        {
            this.quotedTypes.CommaText = "String, WideString, Bool, Date, Time, DateTime";
            this.dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateFormat = "yyyy-MM-dd";
            this.timeFormat = "HH:mm:ss";
        }

        public void CopyFrom(SqlFormats source)
        {
            this.AlphaAlias = source.AlphaAlias;
            this.BracketJoins = source.BracketJoins;
            this.DateFormat = source.DateFormat;
            this.DateTimeFormat = source.DateTimeFormat;
            this.DefaultSchemaName = source.DefaultSchemaName;
            this.EOL = source.EOL;
            this.FalseValue = source.FalseValue;
            this.FilterMode = source.FilterMode;
            this.LowerFuncName = source.LowerFuncName;
            this.OrderByStyle = source.OrderByStyle;
            this.QuoteBool = source.QuoteBool;
            this.QuoteTime = source.QuoteTime;
            this.SqlQuote1 = source.SqlQuote1;
            this.SqlQuote2 = source.SqlQuote2;
            this.SqlSyntax = source.SqlSyntax;
            this.TimeFormat = source.TimeFormat;
            this.TrueValue = source.TrueValue;
            this.UseColumnAliases = source.UseColumnAliases;
            this.UseSchema = source.UseSchema;
            this.UseDbName = source.UseDbName;
        }

        public string GetEolSymbol()
        {
            if (this.eol == EOLSymbol.CRLF)
            {
                return "\r\n";
            }
            if (this.eol == EOLSymbol.LF)
            {
                return "\n";
            }
            if (this.eol == EOLSymbol.CR)
            {
                return "\r";
            }
            return " ";
        }

        public bool IsQuotedType(DataType type)
        {
            return this.quotedTypes.Contains(type);
        }

        public void LoadFromXmlNode(XmlNode rootNode)
        {
            foreach (XmlNode node in rootNode)
            {
                if (string.Compare(node.LocalName, "AlphaAlias", true) == 0)
                {
                    this.AlphaAlias = bool.Parse(node.InnerText);
                }
                else
                {
                    if (string.Compare(node.LocalName, "UseSchema", true) == 0)
                    {
                        this.UseSchema = bool.Parse(node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "UseDbName", true) == 0)
                    {
                        this.UseDbName = bool.Parse(node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "BracketJoins", true) == 0)
                    {
                        this.BracketJoins = bool.Parse(node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "DateFormat", true) == 0)
                    {
                        this.DateFormat = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "TimeFormat", true) == 0)
                    {
                        this.TimeFormat = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "DateTimeFormat", true) == 0)
                    {
                        this.DateTimeFormat = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "QuotedTypes", true) == 0)
                    {
                        this.quotedTypes.CommaText = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "SqlQuote1", true) == 0)
                    {
                        this.SqlQuote1 = char.Parse(node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "SqlQuote2", true) == 0)
                    {
                        this.SqlQuote2 = char.Parse(node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "SqlSyntax", true) == 0)
                    {
                        this.SqlSyntax = (Korzh.EasyQuery.SqlSyntax) Enum.Parse(typeof(Korzh.EasyQuery.SqlSyntax), node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "OrderByStyle", true) == 0)
                    {
                        this.OrderByStyle = (OrderByStyles) Enum.Parse(typeof(OrderByStyles), node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "UseColumnAliases", true) == 0)
                    {
                        this.UseColumnAliases = (ColumnAliasesUsage) Enum.Parse(typeof(ColumnAliasesUsage), node.InnerText);
                        continue;
                    }
                    if (string.Compare(node.LocalName, "LowerFuncName", true) == 0)
                    {
                        this.LowerFuncName = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "DefaultSchemaName", true) == 0)
                    {
                        this.DefaultSchemaName = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "TrueValue", true) == 0)
                    {
                        this.TrueValue = node.InnerText;
                        continue;
                    }
                    if (string.Compare(node.LocalName, "FalseValue", true) == 0)
                    {
                        this.FalseValue = node.InnerText;
                    }
                }
            }
        }

        public void SaveToXmlWriter(XmlWriter writer, string rootNodeName)
        {
            writer.WriteStartElement(rootNodeName);
            writer.WriteElementString("AlphaAlias", this.alphaAlias.ToString());
            writer.WriteElementString("UseSchema", this.useSchema.ToString());
            writer.WriteElementString("UseDbName", this.useDbName.ToString());
            writer.WriteElementString("BracketJoins", this.bracketJoins.ToString());
            writer.WriteElementString("DateFormat", this.dateFormat);
            writer.WriteElementString("TimeFormat", this.timeFormat);
            writer.WriteElementString("DateTimeFormat", this.dateTimeFormat);
            writer.WriteElementString("QuotedTypes", this.quotedTypes.CommaText);
            writer.WriteElementString("SqlQuote1", this.sqlQuote1.ToString());
            writer.WriteElementString("SqlQuote2", this.sqlQuote2.ToString());
            writer.WriteElementString("SqlSyntax", this.sqlSyntax.ToString());
            writer.WriteElementString("OrderByStyle", this.orderByStyle.ToString());
            writer.WriteElementString("UseColumnAliases", this.useColumnAliases.ToString());
            writer.WriteElementString("LowerFuncName", this.lowerFuncName);
            writer.WriteElementString("DefaultSchemaName", this.defaultSchemaName);
            writer.WriteElementString("TrueValue", this.trueValue);
            writer.WriteElementString("FalseValue", this.falseValue);
            writer.WriteEndElement();
        }

        [DefaultValue(false)]
        public bool AlphaAlias
        {
            get
            {
                return this.alphaAlias;
            }
            set
            {
                this.alphaAlias = value;
            }
        }

        [DefaultValue(true)]
        public bool BracketJoins
        {
            get
            {
                return this.bracketJoins;
            }
            set
            {
                this.bracketJoins = value;
            }
        }

        [DefaultValue("yyyy-MM-dd")]
        public string DateFormat
        {
            get
            {
                return this.dateFormat;
            }
            set
            {
                this.dateFormat = value;
            }
        }

        [DefaultValue("yyyy-MM-dd HH:mm:ss")]
        public string DateTimeFormat
        {
            get
            {
                return this.dateTimeFormat;
            }
            set
            {
                this.dateTimeFormat = value;
            }
        }

        [DefaultValue("")]
        public string DefaultSchemaName
        {
            get
            {
                return this.defaultSchemaName;
            }
            set
            {
                this.defaultSchemaName = value;
            }
        }

        [DefaultValue(1)]
        public EOLSymbol EOL
        {
            get
            {
                return this.eol;
            }
            set
            {
                this.eol = value;
            }
        }

        [DefaultValue("false")]
        public string FalseValue
        {
            get
            {
                return this.falseValue;
            }
            set
            {
                this.falseValue = value;
            }
        }

        [DefaultValue(false)]
        public bool FilterMode
        {
            get
            {
                return this.filterMode;
            }
            set
            {
                this.filterMode = value;
            }
        }

        [DefaultValue("LOWER")]
        public string LowerFuncName
        {
            get
            {
                return this.lowerFuncName;
            }
            set
            {
                this.lowerFuncName = value;
            }
        }

        [DefaultValue(0)]
        public OrderByStyles OrderByStyle
        {
            get
            {
                return this.orderByStyle;
            }
            set
            {
                this.orderByStyle = value;
            }
        }

        [DefaultValue(true)]
        public bool QuoteBool
        {
            get
            {
                return this.IsQuotedType(DataType.Bool);
            }
            set
            {
                if (value)
                {
                    this.quotedTypes.Add(DataType.Bool);
                }
                else
                {
                    this.quotedTypes.Remove(DataType.Bool);
                }
            }
        }

        [DefaultValue(true)]
        public bool QuoteTime
        {
            get
            {
                return this.IsQuotedType(DataType.Date);
            }
            set
            {
                if (value)
                {
                    this.quotedTypes.Add(DataType.Date);
                    this.quotedTypes.Add(DataType.Time);
                    this.quotedTypes.Add(DataType.DateTime);
                }
                else
                {
                    this.quotedTypes.Remove(DataType.Date);
                    this.quotedTypes.Remove(DataType.Time);
                    this.quotedTypes.Remove(DataType.DateTime);
                }
            }
        }

        [DefaultValue('"')]
        public char SqlQuote1
        {
            get
            {
                return this.sqlQuote1;
            }
            set
            {
                this.sqlQuote1 = value;
            }
        }

        [DefaultValue('"')]
        public char SqlQuote2
        {
            get
            {
                return this.sqlQuote2;
            }
            set
            {
                this.sqlQuote2 = value;
            }
        }

        [DefaultValue(1)]
        public Korzh.EasyQuery.SqlSyntax SqlSyntax
        {
            get
            {
                return this.sqlSyntax;
            }
            set
            {
                this.sqlSyntax = value;
            }
        }

        [DefaultValue("HH:mm:ss")]
        public string TimeFormat
        {
            get
            {
                return this.timeFormat;
            }
            set
            {
                this.timeFormat = value;
            }
        }

        [DefaultValue("true")]
        public string TrueValue
        {
            get
            {
                return this.trueValue;
            }
            set
            {
                this.trueValue = value;
            }
        }

        [DefaultValue(1)]
        public ColumnAliasesUsage UseColumnAliases
        {
            get
            {
                return this.useColumnAliases;
            }
            set
            {
                this.useColumnAliases = value;
            }
        }

        [DefaultValue(false)]
        public bool UseDbName
        {
            get
            {
                return this.useDbName;
            }
            set
            {
                this.useDbName = value;
            }
        }

        [DefaultValue(true)]
        public bool UseSchema
        {
            get
            {
                return this.useSchema;
            }
            set
            {
                this.useSchema = value;
            }
        }

        public char WildSymbol
        {
            get
            {
                return this.wildSymbol;
            }
            set
            {
                this.wildSymbol = value;
            }
        }
    }
}

