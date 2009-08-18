namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class ConstExpr : Expression
    {
        private string cvalue;
        private Korzh.EasyQuery.DataType dataType;
        private DataKind kind;

        public ConstExpr(Korzh.EasyQuery.DataType dataType) : this(dataType, DataKind.Scalar)
        {
        }

        public ConstExpr(string val) : this(Korzh.EasyQuery.DataType.String, DataKind.Scalar, val)
        {
        }

        public ConstExpr(Korzh.EasyQuery.DataType dataType, DataKind dataKind) : this(dataType, dataKind, "")
        {
        }

        public ConstExpr(Korzh.EasyQuery.DataType dataType, string val) : this(dataType, DataKind.Scalar, val)
        {
        }

        public ConstExpr(Korzh.EasyQuery.DataType dataType, DataKind aKind, string val)
        {
            this.dataType = dataType;
            this.kind = aKind;
            this.cvalue = val;
            base.text = val;
        }

        public override void LoadFromXmlNode(XmlNode rootNode)
        {
            XmlAttribute attribute = rootNode.Attributes["type"];
            if ((attribute != null) && (attribute.Value != "CONST"))
            {
                this.DataType = (Korzh.EasyQuery.DataType) Enum.Parse(typeof(Korzh.EasyQuery.DataType), attribute.Value, true);
            }
            attribute = rootNode.Attributes["kind"];
            if (attribute != null)
            {
                this.Kind = (DataKind) Enum.Parse(typeof(DataKind), attribute.Value, true);
            }
            attribute = rootNode.Attributes["value"];
            if (attribute != null)
            {
                if ((this.dataType == Korzh.EasyQuery.DataType.Date) || (this.dataType == Korzh.EasyQuery.DataType.DateTime))
                {
                    this.ProcessDateValue(attribute.Value);
                }
                else
                {
                    this.Value = attribute.Value;
                }
            }
            if (rootNode.FirstChild != null)
            {
                this.Value = rootNode.FirstChild.InnerText;
            }
            attribute = rootNode.Attributes["text"];
            if (attribute != null)
            {
                this.Text = attribute.Value;
            }
        }

        private void ProcessDateValue(string val)
        {
            if (val.IndexOf("/") >= 0)
            {
                DateTime dt = Utils.OldFormatToDateTime(val);
                this.Value = Utils.DateTimeToInternalFormat(dt, this.DataType);
            }
            else
            {
                this.Value = val;
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            this.WriteXmlTagStart(writer, tagName);
            writer.WriteAttributeString("type", this.DataType.ToString());
            writer.WriteAttributeString("kind", this.Kind.ToString());
            if (this.kind != DataKind.Query)
            {
                writer.WriteAttributeString("value", this.Value);
            }
            writer.WriteAttributeString("text", this.Text);
            if (this.kind == DataKind.Query)
            {
                writer.WriteCData(this.Value);
            }
            writer.WriteEndElement();
        }

        public override void SetContentSilent(string val, string txt)
        {
            this.cvalue = val;
            base.text = txt;
        }

        public void SetDataType(Korzh.EasyQuery.DataType dataType)
        {
            this.dataType = dataType;
        }

        public override Korzh.EasyQuery.DataType DataType
        {
            get
            {
                return this.dataType;
            }
            set
            {
                if (this.dataType != value)
                {
                    this.dataType = value;
                }
            }
        }

        public override DataKind Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }

        public static string STypeName
        {
            get
            {
                return "CONST";
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public override string Value
        {
            get
            {
                return this.cvalue;
            }
            set
            {
                if (this.cvalue != value)
                {
                    this.cvalue = value;
                }
            }
        }
    }
}

