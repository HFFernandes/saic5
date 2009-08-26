namespace Korzh.WebControls
{
    using System;

    [Serializable]
    public class ScriptMenu
    {
        private ScriptMenuItemList items;

        public ScriptMenu(ScriptMenu parent)
        {
            this.items = new ScriptMenuItemList(this);
        }

        public ScriptMenuItemList Items
        {
            get { return this.items; }
        }
    }
}