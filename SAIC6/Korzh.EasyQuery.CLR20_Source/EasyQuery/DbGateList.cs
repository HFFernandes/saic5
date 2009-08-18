namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DbGateList : ArrayList
    {
        public DbGate Find(string className, string version)
        {
            foreach (DbGate gate in this)
            {
                if ((gate.GetType().FullName == className) && ((version == null) || (gate.Version == version)))
                {
                    return gate;
                }
            }
            return null;
        }

        public DbGate this[int index]
        {
            get
            {
                return (DbGate) base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}

