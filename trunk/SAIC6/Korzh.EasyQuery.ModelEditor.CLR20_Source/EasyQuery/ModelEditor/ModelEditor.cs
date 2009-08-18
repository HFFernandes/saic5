namespace Korzh.EasyQuery.ModelEditor
{
    using Korzh.EasyQuery;
    using System;

    public class ModelEditor
    {
        private static DbGateList dbGates = new DbGateList();

        public static DbGateList DbGates
        {
            get
            {
                return dbGates;
            }
        }
    }
}

