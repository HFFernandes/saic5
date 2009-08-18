namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MacroList : ArrayList
    {
        public IMacroValue this[int index]
        {
            get
            {
                return (IMacroValue) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

