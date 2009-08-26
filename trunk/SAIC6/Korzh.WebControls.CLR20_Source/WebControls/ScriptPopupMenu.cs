namespace Korzh.WebControls
{
    using System;
    using System.Web.UI;

    [Serializable]
    public class ScriptPopupMenu : ScriptMenu
    {
        private string customPrefix;
        private string defaultItemUrl;
        private bool grouped;
        private string id;
        private bool isInPartialRendering;
        private bool isRendered;
        private bool multiSelect;
        protected string postbackRef;
        internal int refCount;
        [NonSerialized] private ScriptMenuStyle style;

        public ScriptPopupMenu(string id) : this(id, null)
        {
        }

        public ScriptPopupMenu(string id, ScriptMenu parent) : base(parent)
        {
            this.id = "menu";
            this.style = new ScriptMenuStyle();
            this.customPrefix = "";
            this.defaultItemUrl = "";
            this.id = id;
        }

        protected virtual string GetItemUrl(ScriptMenuItem item)
        {
            if ((item.Link != null) && (item.Link != string.Empty))
            {
                return item.Link;
            }
            return this.DefaultItemUrl.Replace("{id}", "'" + item.ID + "'");
        }

        public void Render(Control parentControl)
        {
            if (!this.IsInPartialRendering || !this.isRendered)
            {
                Type type = base.GetType();
                ClientScriptManager clientScript = parentControl.Page.ClientScript;
                this.postbackRef = clientScript.GetPostBackEventReference(parentControl, "arg1");
                this.postbackRef = this.postbackRef.Replace("'" + parentControl.ClientID + "'", "arg0");
                this.postbackRef = this.postbackRef.Replace("'arg1'", "arg1");
                string key = type.FullName + "_include";
                clientScript.RegisterClientScriptInclude(type, key, this.style.IncludeScriptUrl);
                if (this.IsInPartialRendering)
                {
                    Ajax.RegisterClientScriptInclude(parentControl.Page, type, key, this.style.IncludeScriptUrl);
                }
                string script = this.RenderMenuFuncs();
                if (script != string.Empty)
                {
                    string str3 = type.FullName + "_funcs";
                    clientScript.RegisterClientScriptBlock(type, str3, script, false);
                    if (this.IsInPartialRendering)
                    {
                        Ajax.RegisterClientScriptBlock(parentControl.Page, type, str3, script, false);
                    }
                }
                string str4 = this.ID + "_items";
                string str5 = this.RenderItemsScript();
                if (this.IsInPartialRendering)
                {
                    Ajax.RegisterClientScriptBlock(parentControl.Page, type, str4, str5, false);
                }
                clientScript.RegisterClientScriptBlock(type, str4, str5, false);
                this.isRendered = true;
            }
        }

        public virtual string RenderHideMenuCommand(Control parentControl)
        {
            return "";
        }

        protected virtual string RenderItemsScript()
        {
            return "";
        }

        protected virtual string RenderMenuFuncs()
        {
            return "";
        }

        public virtual void RenderMenuStyle(HtmlTextWriter writer)
        {
        }

        public virtual string RenderShowMenuCommand(Control parentControl)
        {
            return "";
        }

        public string CustomPrefix
        {
            get { return this.customPrefix; }
            set
            {
                if (this.customPrefix != value)
                {
                    this.customPrefix = value;
                    this.isRendered = false;
                }
            }
        }

        public string DefaultItemUrl
        {
            get { return this.defaultItemUrl; }
            set { this.defaultItemUrl = value; }
        }

        public bool Grouped
        {
            get { return this.grouped; }
            set
            {
                if (this.grouped != value)
                {
                    this.grouped = value;
                    this.isRendered = false;
                }
            }
        }

        public string ID
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.isRendered = false;
                this.isInPartialRendering = false;
            }
        }

        public bool IsInPartialRendering
        {
            get { return this.isInPartialRendering; }
            set { this.isInPartialRendering = value; }
        }

        public bool IsRendered
        {
            get { return this.isRendered; }
            set { this.isRendered = value; }
        }

        public bool MultiSelect
        {
            get { return this.multiSelect; }
            set
            {
                if (this.multiSelect != value)
                {
                    this.multiSelect = value;
                    this.isRendered = false;
                }
            }
        }

        public ScriptMenuStyle Style
        {
            get { return this.style; }
            set { this.style = value; }
        }
    }
}