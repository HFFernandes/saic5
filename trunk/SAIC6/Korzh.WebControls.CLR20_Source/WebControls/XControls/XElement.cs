namespace Korzh.WebControls.XControls
{
    using Korzh.WebControls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;

    [ToolboxItem(false)]
    public abstract class XElement : Panel, IPostBackEventHandler
    {
        private bool allowList;
        protected Korzh.WebControls.XControls.ListControl altMenuControl;
        private ValueItemList altMenuItems;
        internal static Hashtable creators = new Hashtable();
        private object data;
        private bool dropped;
        private WebControl elementControl;
        private string ftext = string.Empty;
        private string fvalue = string.Empty;
        private ScriptMenuStyle menuStyle = new ScriptMenuStyle();
        private bool needValidate;
        private XRow parentRow;
        private bool readOnly;
        private Color readOnlyColor = Color.Black;
        private string subType;

        public event ContentChangedEventHandler ContentChanged;

        public event TextAdjustingEventHandler TextAdjusting;

        public XElement()
        {
            this.elementControl = this.CreateElementControl();
            this.EmptyValueText = "[enter value]";
            this.BackColor = Color.Transparent;
            this.SetContentSilent("", "");
            this.Controls.Add(this.elementControl);
        }

        public void Activate()
        {
            if (this.parentRow != null)
            {
                this.parentRow.ElementSignal(this, Signals.Activate);
            }
        }

        protected internal virtual void AddElementControlAttributes(HtmlTextWriter writer)
        {
        }

        internal void AdjustTextByValue()
        {
            this.SetText(this.GetTextAdjustedByValue(this.Value));
        }

        protected void AltMenuItemClickHandler(string postedValue)
        {
            ValueItem itemByID = this.AltMenuItems.GetItemByID(postedValue);
            if ((this.parentRow != null) && (itemByID != null))
            {
                this.parentRow.InnerElementAltMenuClick(this, itemByID);
            }
        }

        public virtual void ApplyFormats()
        {
            if (this.ReadOnly)
            {
                this.ElementControl.ForeColor = this.ReadOnlyColor;
            }
            this.AdjustTextByValue();
            if ((this.ParentRow != null) && (this.ParentRow.Parent != null))
            {
                this.MenuStyle = this.ParentRow.Parent.Appearance.ScriptMenuStyle;
            }
        }

        public virtual void Arrange(int bottomLine, int rowHeight)
        {
            this.Height = rowHeight;
        }

        protected virtual string CoreGetTextAdjustedByValue(string newValue)
        {
            if (((this.ftext == "") || (newValue == "")) && (newValue == string.Empty))
            {
                return (string) this.ViewState["EmptyValueText"];
            }
            return newValue;
        }

        protected virtual void CoreLaunch()
        {
            this.altMenuControl = this.CreateAltMenuControl();
            this.ParentRow.ApplyElementFormats(this);
        }

        protected virtual void CoreSetContent(string value, string text)
        {
            this.SetValue(value);
            this.SetText(text);
        }

        public static XElement Create(string tagName)
        {
            ICreator creator = (ICreator) creators[tagName];
            if (creator == null)
            {
                throw new Error("Unknown type of XElement: " + tagName);
            }
            return creator.Create();
        }

        protected virtual Korzh.WebControls.XControls.ListControl CreateAltMenuControl()
        {
            if ((this.AltMenuItems == null) || (this.AltMenuItems.Count == 0))
            {
                return null;
            }
            KorzhMenuListControl control = new KorzhMenuListControl(this.ParentPanel.MenuPool, this.AltMenuItems, this);
            control.Grouped = true;
            control.CustomPrefix = "__ALT:";
            return control;
        }

        protected abstract WebControl CreateElementControl();

        public void Detach()
        {
            this.parentRow = null;
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        protected string GetTextAdjustedByValue(string newValue)
        {
            TextAdjustingEventArgs e = new TextAdjustingEventArgs(this.CoreGetTextAdjustedByValue(newValue));
            this.OnTextAdjusting(e);
            return e.Text;
        }

        internal void InnerLaunch()
        {
            this.CoreLaunch();
        }

        public static int MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
        {
            StringFormat stringFormat = new StringFormat();
            RectangleF layoutRect = new RectangleF(0f, 0f, 1000f, 1000f);
            CharacterRange[] ranges = new CharacterRange[] {new CharacterRange(0, text.Length)};
            Region[] regionArray = new Region[1];
            stringFormat.SetMeasurableCharacterRanges(ranges);
            return
                (int)
                (graphics.MeasureCharacterRanges(text, font, layoutRect, stringFormat)[0].GetBounds(graphics).Right + 1f);
        }

        protected virtual void OnContentChanged(bool valueChanged, bool textChanged)
        {
            if (this.ContentChanged != null)
            {
                this.ContentChanged(this, new ContentChangedEventArgs(valueChanged, textChanged));
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.ApplyFormats();
            base.OnPreRender(e);
            this.PreRenderElementControl();
        }

        protected virtual void OnTextAdjusting(TextAdjustingEventArgs e)
        {
            if (this.TextAdjusting != null)
            {
                this.TextAdjusting(this, e);
            }
        }

        protected virtual void OnValidate(ValidateValueEventArgs e)
        {
            if (this.parentRow != null)
            {
                this.parentRow.InnerElementValidateValue(this, e);
            }
        }

        public abstract void ParseXmlNode(XmlNode node);

        private int PosStrToNum(string pos)
        {
            if (pos.EndsWith("px", true, null))
            {
                return int.Parse(pos.Substring(0, pos.Length - 2));
            }
            return 0;
        }

        protected virtual void PreRenderElementControl()
        {
            Type type = typeof (XElement);
            ClientScriptManager clientScript = this.Page.ClientScript;
            this.MenuStyle.IncludeScriptUrl = clientScript.GetWebResourceUrl(type,
                                                                             "Korzh.WebControls.Resources.KorzhWebScripts.js");
            if (this.MenuStyle.BlankImageUrl == string.Empty)
            {
                this.MenuStyle.BlankImageUrl = clientScript.GetWebResourceUrl(type,
                                                                              "Korzh.WebControls.Resources.BlankImage.gif");
            }
            this.AdjustTextByValue();
            if ((this.altMenuControl != null) && (this.altMenuItems != null))
            {
                if ((this.altMenuItems.ID == null) || (this.altMenuItems.ID == string.Empty))
                {
                    this.altMenuItems.ID = this.ClientID + "_AltList";
                }
                this.altMenuControl.MultiSelect = false;
                this.altMenuControl.RefillItems();
                this.altMenuControl.IsInPartialRendering = Ajax.IsInAsyncPostBack(this.Page);
                this.altMenuControl.Render(this.Page);
            }
        }

        public static bool Register(ICreator creator)
        {
            creators[creator.TagName] = creator;
            return true;
        }

        public void SetContent(string value, string text)
        {
            this.CoreSetContent(value, text);
            this.OnContentChanged(true, true);
        }

        public void SetContentSilent(string value, string text)
        {
            this.CoreSetContent(value, text);
        }

        internal void SetParentRow(XRow parent)
        {
            this.parentRow = parent;
            this.AdjustTextByValue();
            if (this.ParentPanel != null)
            {
                this.CoreLaunch();
            }
        }

        protected virtual void SetText(string newText)
        {
            if (newText == string.Empty)
            {
                this.ftext = this.EmptyValueText;
            }
            else
            {
                this.ftext = newText;
            }
            if (this.Page != null)
            {
                this.Page.Trace.Write(this.ID, "New text:" + newText);
            }
        }

        protected virtual bool SetValue(string newValue)
        {
            this.fvalue = newValue;
            return true;
        }

        void IPostBackEventHandler.RaisePostBackEvent(string EventArgument)
        {
            string postedValue = EventArgument;
            if (postedValue.StartsWith("__ALT:"))
            {
                postedValue = postedValue.Substring("__ALT:".Length);
                this.AltMenuItemClickHandler(postedValue);
            }
        }

        public virtual bool AllowList
        {
            get { return this.allowList; }
            set { this.allowList = value; }
        }

        public ValueItemList AltMenuItems
        {
            get { return this.altMenuItems; }
            set
            {
                if (this.altMenuItems != value)
                {
                    this.altMenuItems = value;
                }
            }
        }

        public virtual bool Clickable
        {
            get { return false; }
        }

        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public bool Dropped
        {
            get { return this.dropped; }
        }

        public virtual WebControl ElementControl
        {
            get { return this.elementControl; }
        }

        public string EmptyValueText
        {
            get { return (string) this.ViewState["EmptyValueText"]; }
            set
            {
                if (value != this.EmptyValueText)
                {
                    this.ViewState["EmptyValueText"] = value;
                    if (this.Value == string.Empty)
                    {
                        this.AdjustTextByValue();
                    }
                }
            }
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                this.ElementControl.Enabled = value;
            }
        }

        public bool IsInPartialRendering
        {
            get { return Ajax.IsControlInPartialRendering(this); }
        }

        public bool IsInsideUpdatePanel
        {
            get { return Ajax.IsControlInsideUpdatePanel(this); }
        }

        public ScriptMenuStyle MenuStyle
        {
            get { return this.menuStyle; }
            set { this.menuStyle.CopyFrom(value); }
        }

        public bool NeedValidate
        {
            get { return this.needValidate; }
            set { this.needValidate = value; }
        }

        public XPanel ParentPanel
        {
            get
            {
                if (this.parentRow == null)
                {
                    return null;
                }
                return this.parentRow.Parent;
            }
        }

        public XRow ParentRow
        {
            get { return this.parentRow; }
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                if (this.readOnly != value)
                {
                    this.readOnly = value;
                    if (this.parentRow != null)
                    {
                        this.ApplyFormats();
                    }
                }
            }
        }

        public virtual Color ReadOnlyColor
        {
            get { return this.readOnlyColor; }
            set { this.readOnlyColor = value; }
        }

        public virtual string SubType
        {
            get { return this.subType; }
            set { this.subType = value; }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Span; }
        }

        public virtual string Text
        {
            get { return this.ftext; }
            set
            {
                if ((((this.ftext == string.Empty) && (value == string.Empty)) && (this.EmptyValueText != string.Empty)) ||
                    ((value != this.ftext) && (!(value == string.Empty) || !(this.ftext == this.EmptyValueText))))
                {
                    this.SetText(value);
                    this.OnContentChanged(false, true);
                }
            }
        }

        public string Value
        {
            get { return this.fvalue; }
            set
            {
                if (value != this.fvalue)
                {
                    this.SetValue(value);
                    this.OnContentChanged(true, false);
                    string textAdjustedByValue = this.GetTextAdjustedByValue(value);
                    if (this.ftext != textAdjustedByValue)
                    {
                        this.SetText(textAdjustedByValue);
                        this.OnContentChanged(false, true);
                    }
                }
            }
        }

        public static string XmlTagName
        {
            get { return ""; }
        }

        public class Error : Exception
        {
            public Error(string msg) : base(msg)
            {
            }
        }

        public interface ICreator
        {
            XElement Create();

            string TagName { get; }
        }
    }
}