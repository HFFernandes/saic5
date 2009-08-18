namespace Korzh.EasyQuery
{
    using System;
    using System.Collections;
    using System.Xml;

    public class ValueEditor
    {
        internal static Hashtable Creators = new Hashtable();

        public static ValueEditor Create(string type)
        {
            IDictionaryEnumerator enumerator = Creators.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (type == ((string) enumerator.Key))
                {
                    IValueEditorCreator creator = (IValueEditorCreator) enumerator.Value;
                    return creator.Create();
                }
            }
            return null;
        }

        public virtual void LoadFromXmlNode(XmlNode node)
        {
        }

        public static bool RegisterType(string type, IValueEditorCreator creator)
        {
            Creators.Add(type, creator);
            return true;
        }

        protected virtual void SaveContentToXmlWriter(XmlWriter writer)
        {
        }

        public virtual void SaveToXmlWriter(XmlWriter writer, string tagName)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString("TYPE", this.TypeName);
            this.SaveContentToXmlWriter(writer);
            writer.WriteEndElement();
        }

        public virtual string DefaultText
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public virtual string DefaultValue
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public static string STypeName
        {
            get
            {
                return "";
            }
        }

        public virtual string TypeName
        {
            get
            {
                return STypeName;
            }
        }

        public virtual string XmlDefinition
        {
            get
            {
                return "";
            }
        }
    }
}

