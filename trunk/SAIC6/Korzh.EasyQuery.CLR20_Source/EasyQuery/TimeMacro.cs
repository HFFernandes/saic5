namespace Korzh.EasyQuery
{
    using System;

    public class TimeMacro : IMacroValue
    {
        private string id;
        private TimeMacroType macroType;

        public TimeMacro(TimeMacroType macroType)
        {
            this.macroType = macroType;
            this.id = Enum.GetName(typeof(TimeMacroType), macroType);
        }

        public string GetValue(int index)
        {
            if (index == 0)
            {
                return this.Value;
            }
            return "";
        }

        public int Count
        {
            get
            {
                return 1;
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public string Value
        {
            get
            {
                DateTime now;
                DateTime time6;
                switch (this.macroType)
                {
                    case TimeMacroType.Today:
                        return Utils.DateTimeToInternalFormat(DateTime.Now, DataType.Date);

                    case TimeMacroType.Yesterday:
                        return Utils.DateTimeToInternalFormat(DateTime.Now.AddDays(-1.0), DataType.Date);

                    case TimeMacroType.Tomorrow:
                        return Utils.DateTimeToInternalFormat(DateTime.Now.AddDays(1.0), DataType.Date);

                    case TimeMacroType.FirstDayOfMonth:
                    {
                        now = DateTime.Now;
                        DateTime dt = new DateTime(now.Year, now.Month, 1);
                        return Utils.DateTimeToInternalFormat(dt, DataType.Date);
                    }
                    case TimeMacroType.LastDayOfMonth:
                    {
                        DateTime time3 = DateTime.Now;
                        time3.AddMonths(1);
                        DateTime time4 = new DateTime(time3.Year, time3.Month, 1);
                        time4.AddDays(-1.0);
                        return Utils.DateTimeToInternalFormat(time4, DataType.Date);
                    }
                    case TimeMacroType.FirstDayOfYear:
                    {
                        now = DateTime.Now;
                        DateTime time5 = new DateTime(now.Year, 1, 1);
                        return Utils.DateTimeToInternalFormat(time5, DataType.Date);
                    }
                    case TimeMacroType.Now:
                        return Utils.DateTimeToInternalFormat(DateTime.Now, DataType.Time);

                    case TimeMacroType.HourStart:
                    {
                        time6 = DateTime.Now;
                        DateTime time7 = new DateTime(time6.Year, time6.Month, time6.Day, time6.Hour, 0, 0);
                        return Utils.DateTimeToInternalFormat(time7, DataType.Time);
                    }
                    case TimeMacroType.Midnight:
                    {
                        time6 = DateTime.Now;
                        DateTime time8 = new DateTime(time6.Year, time6.Month, time6.Day, 0, 0, 0);
                        return Utils.DateTimeToInternalFormat(time8, DataType.Time);
                    }
                    case TimeMacroType.Noon:
                    {
                        time6 = DateTime.Now;
                        DateTime time9 = new DateTime(time6.Year, time6.Month, time6.Day, 12, 0, 0);
                        return Utils.DateTimeToInternalFormat(time9, DataType.Time);
                    }
                }
                return Utils.DateTimeToInternalFormat(DateTime.Now, DataType.Time);
            }
        }
    }
}

