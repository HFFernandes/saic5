namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class AggrFunctionList : ArrayList
    {
        public AggrFunction FindByID(string id)
        {
            foreach (AggrFunction function in this)
            {
                if (string.Compare(function.ID, id, true) == 0)
                {
                    return function;
                }
            }
            return null;
        }

        public AggrFunction this[int index]
        {
            get
            {
                return (AggrFunction) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

