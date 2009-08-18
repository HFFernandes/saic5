namespace Korzh.EasyQuery
{
    using System;
    using System.Globalization;
    using System.Text;

    public class Utils
    {
        private static string[] expectedOldDateTimeFormats = new string[] { "d", "T", "G", "g", "s", "u" };
        private static string internalDateFormat = "yyyy'-'MM'-'dd";
        private static string internalTimeFormat = "HH':'mm':'ss";
        private static IFormatProvider oldFormatCulture = new CultureInfo("fr-FR", true);

        public static DataKind DataKindByName(string kindName)
        {
            try
            {
                return (DataKind) Enum.Parse(typeof(DataKind), kindName);
            }
            catch
            {
                return DataKind.Scalar;
            }
        }

        public static DataType DataTypeByName(string typeName)
        {
            try
            {
                return (DataType) Enum.Parse(typeof(DataType), typeName);
            }
            catch
            {
                return DataType.Unknown;
            }
        }

        public static string DateTimeToInternalFormat(DateTime dt, DataType dataType)
        {
            string dateTimeInternalFormat = GetDateTimeInternalFormat(dataType);
            return dt.ToString(dateTimeInternalFormat);
        }

        public static string DateTimeToUserFormat(DateTime dt, DataType dataType)
        {
            string str;
            switch (dataType)
            {
                case DataType.Date:
                    str = "d";
                    break;

                case DataType.Time:
                    str = "T";
                    break;

                default:
                    str = "G";
                    break;
            }
            return dt.ToString(str, DateTimeFormatInfo.CurrentInfo);
        }

        public static DataType GetDataTypeBySystemType(Type systemType)
        {
            switch (systemType.Name)
            {
                case "Boolean":
                    return DataType.Bool;

                case "Byte":
                case "Char":
                case "SByte":
                    return DataType.Byte;

                case "DateTime":
                case "TimeSpan":
                    return DataType.DateTime;

                case "Decimal":
                    return DataType.Currency;

                case "Double":
                case "Single":
                    return DataType.Float;

                case "Int16":
                case "UInt16":
                    return DataType.Word;

                case "Int32":
                case "UInt32":
                    return DataType.Int;

                case "Int64":
                case "UInt64":
                    return DataType.Int64;

                case "String":
                    return DataType.WideString;
            }
            return DataType.Unknown;
        }

        public static string GetDateTimeInternalFormat(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Date:
                    return internalDateFormat;

                case DataType.Time:
                    return internalTimeFormat;
            }
            return InternalDateTimeFormat;
        }

        public static DateTime InternalFormatToDateTime(string val, DataType dataType)
        {
            string dateTimeInternalFormat = GetDateTimeInternalFormat(dataType);
            DateTime now = DateTime.Now;
            bool flag = true;
            try
            {
                now = DateTime.ParseExact(val, dateTimeInternalFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowWhiteSpaces);
            }
            catch
            {
                flag = false;
            }
            if (!flag && (dataType == DataType.DateTime))
            {
                dateTimeInternalFormat = GetDateTimeInternalFormat(DataType.Date);
                now = DateTime.ParseExact(val, dateTimeInternalFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowWhiteSpaces);
            }
            return now;
        }

        public static bool IsStrNullOrEmpty(string s)
        {
            if (s != null)
            {
                return (s == "");
            }
            return true;
        }

        public static DateTime OldFormatToDateTime(string val)
        {
            return DateTime.ParseExact(val, expectedOldDateTimeFormats, oldFormatCulture, DateTimeStyles.AllowWhiteSpaces);
        }

        public static string StrToIdentifier(string s)
        {
            StringBuilder builder = new StringBuilder(s);
            for (int i = 0; i < builder.Length; i++)
            {
                if (!char.IsLetterOrDigit(builder[i]))
                {
                    builder[i] = '_';
                }
            }
            return builder.ToString();
        }

        public static string InternalDateFormat
        {
            get
            {
                return internalDateFormat;
            }
        }

        public static string InternalDateTimeFormat
        {
            get
            {
                return (internalDateFormat + " " + internalTimeFormat);
            }
        }

        public static string InternalTimeFormat
        {
            get
            {
                return internalTimeFormat;
            }
        }
    }
}

