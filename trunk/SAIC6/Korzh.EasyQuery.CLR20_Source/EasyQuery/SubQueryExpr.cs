namespace Korzh.EasyQuery
{
    using System;
    using System.Xml;

    public class SubQueryExpr : Expression
    {
        private DataModel model;
        private string queryRep = "";

        public SubQueryExpr(DataModel model)
        {
            this.model = model;
        }

        public override string GetSqlExpr(SqlFormats formats)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(this.Value);
            if (!(document.DocumentElement.Name == "Query"))
            {
                return document.DocumentElement.InnerText;
            }
            Query query = new Query();
            query.Model = this.model;
            query.Formats.CopyFrom(formats);
            query.Formats.SubQueryLevel = formats.SubQueryLevel + 1;
            query.LoadFromXmlNode(document.DocumentElement, Query.RWOptions.Content);
            if (query.CanBuild)
            {
                query.BuildSQL();
                return query.Result.SQL;
            }
            return "";
        }

        public override void LoadFromXmlNode(XmlNode rootNode)
        {
            XmlAttribute attribute = rootNode.Attributes["text"];
            if (attribute != null)
            {
                this.Text = attribute.Value;
            }
            if (rootNode.FirstChild != null)
            {
                this.Value = rootNode.FirstChild.InnerText;
            }
        }

        public override void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            this.WriteXmlTagStart(writer, tagName);
            writer.WriteAttributeString("text", this.Text);
            writer.WriteCData(this.Value);
            writer.WriteEndElement();
        }

        public static string STypeName
        {
            get
            {
                return "QUERY";
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
                return this.queryRep;
            }
            set
            {
                if (this.queryRep != value)
                {
                    this.queryRep = value;
                }
            }
        }
    }
}

