namespace Korzh.WebControls
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using System.Resources;

    public class TextStorage
    {
        private Hashtable textMap = new Hashtable();

        public string Get(string id)
        {
            object obj2 = this.textMap[id];
            if (obj2 == null)
            {
                return null;
            }
            return obj2.ToString();
        }

        public void LoadFromFile(string path)
        {
            string str;
            TextReader reader = new StreamReader(path);
            char[] separator = new char[] {'='};
            while ((str = reader.ReadLine()) != null)
            {
                string[] strArray = str.Split(separator, 2);
                if (strArray.Length == 2)
                {
                    this.textMap[strArray[0].Trim()] = strArray[1];
                }
            }
        }

        public void LoadFromResources(ResourceManager resources)
        {
            IDictionaryEnumerator enumerator =
                resources.GetResourceSet(CultureInfo.InvariantCulture, true, true).GetEnumerator();
            while (enumerator.MoveNext())
            {
                this.textMap[enumerator.Key] = enumerator.Value;
            }
            enumerator = resources.GetResourceSet(CultureInfo.CurrentUICulture, true, true).GetEnumerator();
            while (enumerator.MoveNext())
            {
                this.textMap[enumerator.Key] = enumerator.Value;
            }
        }

        public void Put(string key, string value)
        {
            this.textMap[key] = value;
        }
    }
}