namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ExprList : ArrayList
    {
        public Expression this[int index]
        {
            get
            {
                return (Expression) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

