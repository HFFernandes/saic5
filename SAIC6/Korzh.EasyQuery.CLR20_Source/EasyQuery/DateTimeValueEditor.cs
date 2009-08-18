namespace Korzh.EasyQuery
{
    using System;

    public class DateTimeValueEditor : ValueEditor, IDefaultValuesStorage
    {
        private string defaultValue;
        private ConstValueList defaultValues = new ConstValueList();
        private DataType subType = DataType.Date;

        public DateTimeValueEditor()
        {
            this.RecalcDefValue();
        }

        private void RecalcDefValue()
        {
            this.defaultValue = Utils.DateTimeToInternalFormat(DateTime.Now, this.SubType);
        }

        public override string DefaultText
        {
            get
            {
                if (this.defaultValue != "")
                {
                    return Utils.DateTimeToUserFormat(Utils.InternalFormatToDateTime(this.defaultValue, this.SubType), this.SubType);
                }
                return string.Empty;
            }
            set
            {
            }
        }

        public override string DefaultValue
        {
            get
            {
                return this.defaultValue;
            }
            set
            {
                this.defaultValue = value;
            }
        }

        public ConstValueList DefaultValues
        {
            get
            {
                return this.defaultValues;
            }
        }

        public static string STypeName
        {
            get
            {
                return "DATETIME";
            }
        }

        public DataType SubType
        {
            get
            {
                return this.subType;
            }
            set
            {
                this.subType = value;
                this.RecalcDefValue();
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public override string XmlDefinition
        {
            get
            {
                string str;
                switch (this.SubType)
                {
                    case DataType.Date:
                        str = "DATE";
                        break;

                    case DataType.Time:
                        str = "TIME";
                        break;

                    default:
                        str = "DATETIME";
                        break;
                }
                return ("<DATETIME Value=\"" + this.DefaultValue + "\" SubType=\"" + str + "\"/>");
            }
        }
    }
}

