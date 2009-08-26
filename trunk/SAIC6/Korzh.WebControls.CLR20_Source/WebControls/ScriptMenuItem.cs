namespace Korzh.WebControls
{
    using System;

    [Serializable]
    public class ScriptMenuItem : ScriptMenu
    {
        private string fvalue;
        private string id;
        private string link;
        internal ScriptMenu parent;
        private bool selected;
        private string text;

        public ScriptMenuItem(ScriptMenu parent) : base(parent)
        {
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Link
        {
            get { return this.link; }
            set { this.link = value; }
        }

        public ScriptMenu Parent
        {
            get { return this.parent; }
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string Value
        {
            get { return this.fvalue; }
            set { this.fvalue = value; }
        }
    }
}