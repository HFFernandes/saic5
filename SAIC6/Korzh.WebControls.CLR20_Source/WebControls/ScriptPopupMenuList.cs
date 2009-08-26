namespace Korzh.WebControls
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class ScriptPopupMenuList : ArrayList
    {
        public ScriptPopupMenu FindById(string id)
        {
            foreach (ScriptPopupMenu menu in this)
            {
                if (string.Compare(menu.ID, id, true) == 0)
                {
                    return menu;
                }
            }
            return null;
        }

        public ScriptPopupMenu this[int index]
        {
            get { return (ScriptPopupMenu) base[index]; }
            set { base[index] = value; }
        }
    }
}