namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.Web.UI;

    public abstract class MenuListControl : ListControl
    {
        private string customPrexif;
        private bool grouped;
        private bool isInPartialRendering;
        private ScriptPopupMenuList menuPool;
        private bool multiSelect;
        private ScriptPopupMenu popupMenu;

        public MenuListControl(ScriptPopupMenuList menuPool, ValueItemList items, XElement parentElement)
            : base(items, parentElement)
        {
            this.customPrexif = "";
            this.menuPool = menuPool;
        }

        protected abstract ScriptPopupMenu CreateMenu(string id);

        protected void DetachMenu(ScriptPopupMenu menu)
        {
            menu.refCount--;
            if (menu.refCount == 0)
            {
                this.menuPool.Remove(menu);
            }
        }

        protected ScriptPopupMenu EstablishMenu(string id)
        {
            ScriptPopupMenu menu = null;
            if (this.menuPool != null)
            {
                menu = this.menuPool.FindById(id);
            }
            if (menu == null)
            {
                menu = this.CreateMenu(id);
                if (this.menuPool != null)
                {
                    this.menuPool.Add(menu);
                }
            }
            menu.MultiSelect = this.MultiSelect;
            menu.Grouped = this.Grouped;
            menu.CustomPrefix = this.CustomPrefix;
            menu.IsInPartialRendering = this.IsInPartialRendering;
            menu.refCount++;
            return menu;
        }

        private void FillMenuItem(ScriptMenuItemList menuItems, ValueItemList items)
        {
            foreach (ValueItem item in items)
            {
                ScriptMenuItem item2 = new ScriptMenuItem(null);
                item2.ID = item.ID;
                item2.Text = item.Text;
                item2.Value = item.Value;
                item2.Selected = item.Selected;
                menuItems.Add(item2);
                this.FillMenuItem(item2.Items, item.SubItems);
            }
        }

        public override string GetShowScriptReference()
        {
            this.RefreshMenu();
            if (this.popupMenu == null)
            {
                return "";
            }
            return this.popupMenu.RenderShowMenuCommand(base.element);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
        }

        public override void RefillItems()
        {
            this.RefreshMenu();
            if (this.popupMenu != null)
            {
                this.popupMenu.Items.Clear();
                this.FillMenuItem(this.popupMenu.Items, base.items);
            }
        }

        protected void RefreshMenu()
        {
            if ((this.popupMenu == null) || (this.popupMenu.ID != base.items.ID))
            {
                if (this.popupMenu != null)
                {
                    this.DetachMenu(this.popupMenu);
                }
                if (base.items != null)
                {
                    this.popupMenu = this.EstablishMenu(base.items.ID);
                }
            }
        }

        public override void Render(Page page)
        {
            this.RefreshMenu();
            if (((this.popupMenu != null) && base.element.Enabled) && !base.element.ReadOnly)
            {
                if (base.listWasChanged)
                {
                    this.popupMenu.IsRendered = false;
                }
                this.popupMenu.Style = base.element.MenuStyle;
                this.popupMenu.Render(page);
            }
            base.listWasChanged = false;
        }

        public string CustomPrefix
        {
            get { return this.customPrexif; }
            set
            {
                if (this.customPrexif != value)
                {
                    this.customPrexif = value;
                    if (this.popupMenu != null)
                    {
                        this.popupMenu.CustomPrefix = value;
                    }
                }
            }
        }

        public override bool Grouped
        {
            get { return this.grouped; }
            set
            {
                if (this.grouped != value)
                {
                    this.grouped = value;
                    if (this.popupMenu != null)
                    {
                        this.popupMenu.Grouped = value;
                    }
                }
            }
        }

        public override bool IsInPartialRendering
        {
            get { return this.isInPartialRendering; }
            set
            {
                this.isInPartialRendering = value;
                if (this.popupMenu != null)
                {
                    this.popupMenu.IsInPartialRendering = value;
                }
            }
        }

        public override bool MultiSelect
        {
            get { return this.multiSelect; }
            set
            {
                if (this.multiSelect != value)
                {
                    this.multiSelect = value;
                    if (this.popupMenu != null)
                    {
                        this.popupMenu.MultiSelect = value;
                    }
                }
            }
        }

        public ScriptPopupMenu PopupMenu
        {
            get { return this.popupMenu; }
        }
    }
}