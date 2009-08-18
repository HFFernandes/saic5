namespace Korzh.EasyQuery
{
    using System;

    public class TextValueEditor : ValueEditor
    {
        private string defaultValue = "";
        private bool multiline;
        private DataType valueType = DataType.String;

        public override string DefaultText
        {
            get
            {
                return this.defaultValue;
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

        public bool Multiline
        {
            get
            {
                return this.multiline;
            }
            set
            {
                this.multiline = value;
            }
        }

        public static string STypeName
        {
            get
            {
                return "EDIT";
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public DataType ValueType
        {
            get
            {
                return this.valueType;
            }
            set
            {
                this.valueType = value;
            }
        }

        public override string XmlDefinition
        {
            get
            {
                return ("<EDIT Value=\"" + this.DefaultValue + "\" Multiline=\"" + this.Multiline.ToString() + "\" />");
            }
        }
    }
}

