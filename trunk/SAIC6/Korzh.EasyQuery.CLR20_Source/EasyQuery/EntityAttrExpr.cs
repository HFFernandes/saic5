namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class EntityAttrExpr : Expression
    {
        private DataModel.EntityAttr attribute;
        private DataModel model;
        private static string textFormat = "{entity} {attr}";

        public EntityAttrExpr(DataModel aModel, DataModel.EntityAttr attribute)
        {
            this.model = aModel;
            this.attribute = attribute;
            if ((attribute == null) && (this.model != null))
            {
                this.attribute = aModel.GetDefaultUICAttribute();
            }
        }

        public override void AssignExpr(Expression expr)
        {
            if ((expr is AggrFuncExpr) && (((AggrFuncExpr) expr).Argument is EntityAttrExpr))
            {
                this.Attribute = ((EntityAttrExpr) ((AggrFuncExpr) expr).Argument).Attribute;
            }
            else if (expr is EntityAttrExpr)
            {
                this.Attribute = ((EntityAttrExpr) expr).Attribute;
            }
            else
            {
                return;
            }
            this.OnContentChange(EventArgs.Empty);
        }

        public override string GetSqlExpr(SqlFormats formats)
        {
            return this.attribute.GetSqlExpr(formats);
        }

        public override void GetUsedTables(DataModel.TableList tables)
        {
            tables.AddRange(this.Attribute.Tables);
        }

        public override void LoadFromXmlNode(XmlNode rootNode)
        {
            this.Value = rootNode.Attributes["id"].Value;
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            this.WriteXmlTagStart(writer, tagName);
            writer.WriteAttributeString("id", this.Attribute.ID);
            writer.WriteEndElement();
        }

        public DataModel.EntityAttr Attribute
        {
            get
            {
                return this.attribute;
            }
            set
            {
                if (this.attribute != value)
                {
                    this.attribute = value;
                    this.OnContentChange(EventArgs.Empty);
                }
            }
        }

        public override Korzh.EasyQuery.DataType DataType
        {
            get
            {
                return this.attribute.DataType;
            }
        }

        public override DataKind Kind
        {
            get
            {
                return DataKind.Attribute;
            }
        }

        public static string STypeName
        {
            get
            {
                return "ENTATTR";
            }
        }

        public override string Text
        {
            get
            {
                if (this.attribute != null)
                {
                    return TextFormat.Replace("{attr}", this.Attribute.Caption).Replace("{entity}", this.Attribute.Entity.Name);
                }
                return "";
            }
        }

        public static string TextFormat
        {
            get
            {
                return textFormat;
            }
            set
            {
                textFormat = value;
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
                if (this.attribute == null)
                {
                    return "";
                }
                return this.attribute.ID;
            }
            set
            {
                if (value != this.Value)
                {
                    this.attribute = this.model.EntityRoot.FindAttribute(EntAttrProp.ID, value);
                    if (this.attribute == null)
                    {
                        this.attribute = this.model.NullAttribute;
                    }
                    this.OnContentChange(EventArgs.Empty);
                }
            }
        }
    }
}

