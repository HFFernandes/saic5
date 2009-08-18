namespace Korzh.EasyQuery
{
    using System;

    public class DbFieldInfo
    {
        private DataType fieldType;
        private string name;
        private int size;

        public override string ToString()
        {
            return this.name;
        }

        public DataType FieldType
        {
            get
            {
                return this.fieldType;
            }
            set
            {
                this.fieldType = value;
            }
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

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}

