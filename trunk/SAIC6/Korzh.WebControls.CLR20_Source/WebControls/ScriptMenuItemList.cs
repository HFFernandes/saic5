namespace Korzh.WebControls
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Text;

    [Serializable]
    public class ScriptMenuItemList : ArrayList
    {
        private ScriptMenu parentMenu;

        public ScriptMenuItemList(ScriptMenu parentMenu)
        {
            this.parentMenu = parentMenu;
        }

        public override int Add(object value)
        {
            ((ScriptMenuItem) value).parent = this.parentMenu;
            return base.Add(value);
        }

        public override void Insert(int index, object value)
        {
            ((ScriptMenuItem) value).parent = this.parentMenu;
            base.Insert(index, value);
        }

        public ScriptMenuItem this[int index]
        {
            get { return (ScriptMenuItem) base[index]; }
        }

        public string SelectedValues
        {
            get
            {
                StringBuilder builder = new StringBuilder(string.Empty);
                foreach (ScriptMenuItem item in this)
                {
                    if (item.Selected)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append(",");
                        }
                        builder.Append(item.ID);
                    }
                }
                return builder.ToString();
            }
        }
    }
}