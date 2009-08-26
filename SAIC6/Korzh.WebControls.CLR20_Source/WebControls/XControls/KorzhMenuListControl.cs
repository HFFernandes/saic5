namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;

    public class KorzhMenuListControl : MenuListControl
    {
        public KorzhMenuListControl(ScriptPopupMenuList menuPool, ValueItemList items, XElement parentElement)
            : base(menuPool, items, parentElement)
        {
        }

        protected override ScriptPopupMenu CreateMenu(string id)
        {
            return new KorzhScriptPopupMenu(id);
        }
    }
}