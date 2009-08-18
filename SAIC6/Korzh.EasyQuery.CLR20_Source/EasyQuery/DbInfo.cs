namespace Korzh.EasyQuery
{
    using System;

    public class DbInfo
    {
        private string name;

        public DbInfo(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}

