namespace Korzh.WinControls.XControls
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml;

    public abstract class XElement : IDisposable
    {
        private bool allowList;
        private BaseElementPanel basePanel;
        private static Hashtable creators = new Hashtable();
        private object data;
        private bool disposed;
        private bool dropped;
        private string emptyValueText = "";
        private string ftext = "";
        private string fvalue;
        private bool needTextAdjustingOnApplyFormats = true;
        private bool needValidate;
        internal XRow parentRow;
        private bool readOnly;
        private Color readOnlyColor = Color.Black;
        private string subType = "";
        private Color textColor = Color.Black;

        public event EventHandler AltClick;

        public event ContentChangedEventHandler ContentChanged;

        public event TextAdjustingEventHandler TextAdjusting;

        public XElement()
        {
            Control control = this.CreateElementControl();
            if (control != null)
            {
                control.SizeChanged += new EventHandler(this.ElementControlSizeChangedHandler);
                control.FontChanged += new EventHandler(this.ElementControlFontChangedHandler);
                control.Click += new EventHandler(this.ElementControlClickHandler);
                control.TabStop = false;
            }
            this.basePanel = new BaseElementPanel(this);
            this.basePanel.TabStop = false;
            this.BasePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (this.ParentPanel != null)
            {
                this.BasePanel.AutoSize = this.ParentPanel.Appearance.TuneElementSizes;
            }
            else
            {
                this.BasePanel.AutoSize = false;
            }
            this.SetContentSilent("", "");
        }

        public virtual void Activate()
        {
            this.Select();
            if (this.parentRow != null)
            {
                this.parentRow.ElementSignal(this, Signals.Activate);
            }
        }

        protected internal virtual void AdjustSize()
        {
            try
            {
                if ((this.ParentPanel == null) || !this.ParentPanel.Appearance.TuneElementSizes)
                {
                    this.BasePanel.Width = this.ElementControl.Text == "" ? 10 : MeasureDisplayStringWidth(this.ElementControl.CreateGraphics(), this.ElementControl.Text, this.ElementControl.Font);
                }
            }
            catch (Exception ex)
            {
                this.BasePanel.Width = 15;
            }
        }

        internal void AdjustTextByValue()
        {
            this.SetText(this.GetTextAdjustedByValue(this.Value));
        }

        public virtual void ApplyFormats()
        {
            if (this.ParentPanel != null)
            {
                this.BasePanel.AutoSize = this.ParentPanel.Appearance.TuneElementSizes;
            }
            else
            {
                this.BasePanel.AutoSize = false;
            }
            if (this.NeedTextAdjustingOnApplyFormats)
            {
                this.AdjustTextByValue();
            }
        }

        public virtual void Arrange(int bottomLine, int rowHeight)
        {
            this.BasePanel.Top = 0;
            this.BasePanel.Height = rowHeight;
            this.ElementControl.Top = bottomLine - this.ElementControl.Font.Height;
        }

        protected virtual string CalcNewValue()
        {
            return this.Value;
        }

        public void CloseEdit(bool accept)
        {
            if (this.dropped)
            {
                this.RollUp(accept);
            }
        }

        protected virtual string CoreGetTextAdjustedByValue(string newValue)
        {
            if (((this.ftext == "") || (newValue == "")) && (newValue == string.Empty))
            {
                return this.emptyValueText;
            }
            return newValue;
        }

        protected virtual void CoreLaunch()
        {
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

        protected abstract Control CreateElementControl();
        public void Detach()
        {
            this.parentRow = null;
            this.basePanel.Parent = null;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.BasePanel.Dispose();
            }
            this.disposed = true;
        }

        public void DropDown()
        {
            this.OnBeforeDropDown();
            this.dropped = true;
            this.ShowControl();
            this.AdjustSize();
        }

        protected virtual void ElementControlClickHandler(object sender, EventArgs e)
        {
            if (this.parentRow != null)
            {
                this.parentRow.CloseEdits();
                this.parentRow.Active = true;
            }
        }

        protected virtual void ElementControlFontChangedHandler(object sender, EventArgs e)
        {
            this.AdjustSize();
        }

        protected virtual void ElementControlSizeChangedHandler(object sender, EventArgs e)
        {
            this.AdjustSize();
        }

        public virtual bool Focus()
        {
            return this.ElementControl.Focus();
        }

        protected string GetTextAdjustedByValue(string newValue)
        {
            TextAdjustingEventArgs e = new TextAdjustingEventArgs(this.CoreGetTextAdjustedByValue(newValue));
            this.OnTextAdjusting(e);
            return e.Text;
        }

        protected virtual void HideControl()
        {
        }

        internal void InnerLaunch()
        {
            this.CoreLaunch();
        }

        public virtual void Invalidate()
        {
            this.ElementControl.Invalidate();
        }

        public static int MeasureDisplayStringWidth(Graphics graphics, string text, System.Drawing.Font font)
        {
            StringFormat stringFormat = new StringFormat();
            RectangleF layoutRect = new RectangleF(0f, 0f, 1000f, 1000f);
            CharacterRange[] ranges = new CharacterRange[] { new CharacterRange(0, text.Length) };
            Region[] regionArray = new Region[1];
            stringFormat.SetMeasurableCharacterRanges(ranges);
            return (int) (graphics.MeasureCharacterRanges(text, font, layoutRect, stringFormat)[0].GetBounds(graphics).Right + 1f);
        }

        protected virtual void OnAltClick(EventArgs e)
        {
            if (this.AltClick != null)
            {
                this.AltClick(this, e);
            }
        }

        protected virtual void OnBeforeDropDown()
        {
            if (this.parentRow != null)
            {
                this.parentRow.InnerElementBeforeDropDown(this);
            }
        }

        protected virtual void OnContentChanged(bool valueChanged, bool textChanged)
        {
            if ((this.parentRow == null) || !this.parentRow.Updating)
            {
                if (textChanged)
                {
                    this.AdjustSize();
                    if (this.parentRow != null)
                    {
                        int index = this.parentRow.Elements.IndexOf(this);
                        this.parentRow.InnerRearrangeElements(index + 1);
                    }
                }
                if (this.ContentChanged != null)
                {
                    this.ContentChanged(this, new ContentChangedEventArgs(valueChanged, textChanged));
                }
            }
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
        protected void ReAdjustTextByValue()
        {
            this.ftext = "";
            this.AdjustTextByValue();
        }

        public static bool Register(ICreator creator)
        {
            creators[creator.TagName] = creator;
            return true;
        }

        public void RollUp(bool accept)
        {
            if (this.dropped)
            {
                string str = this.CalcNewValue();
                bool flag = true;
                string str2 = str;
                if (accept && this.NeedValidate)
                {
                    ValidateValueEventArgs e = new ValidateValueEventArgs(this, str2, flag);
                    this.OnValidate(e);
                    str = e.Value;
                    accept = e.Accept;
                }
                if (accept)
                {
                    this.Value = str;
                }
                this.HideControl();
                this.dropped = false;
                this.AdjustSize();
                if (this.parentRow != null)
                {
                    this.parentRow.InnerRearrangeElements(this.parentRow.Elements.IndexOf(this) + 1);
                }
            }
        }

        public virtual void Select()
        {
            this.ElementControl.Select();
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
            this.ElementControl.Text = this.ftext.Replace("&", "&&");
        }

        protected virtual bool SetValue(string newValue)
        {
            this.fvalue = newValue;
            return true;
        }

        protected virtual void ShowControl()
        {
        }

        public virtual bool AllowList
        {
            get
            {
                return this.allowList;
            }
            set
            {
                this.allowList = value;
            }
        }

        protected internal BaseElementPanel BasePanel
        {
            get
            {
                return this.basePanel;
            }
        }

        public virtual bool CanFocus
        {
            get
            {
                return this.ElementControl.CanFocus;
            }
        }

        public virtual bool CanSelect
        {
            get
            {
                return this.ElementControl.CanSelect;
            }
        }

        public object Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public bool Dropped
        {
            get
            {
                return this.dropped;
            }
        }

        public abstract Control ElementControl { get; }

        public string EmptyValueText
        {
            get
            {
                return this.emptyValueText;
            }
            set
            {
                if (value != this.emptyValueText)
                {
                    this.emptyValueText = value;
                    if (this.Value == "")
                    {
                        this.ReAdjustTextByValue();
                    }
                }
            }
        }

        public virtual System.Drawing.Font Font
        {
            get
            {
                return this.ElementControl.Font;
            }
            set
            {
                if (this.ElementControl.Font != value)
                {
                    this.BasePanel.Font = value;
                    this.ElementControl.Font = value;
                }
            }
        }

        public bool NeedTextAdjustingOnApplyFormats
        {
            get
            {
                return this.needTextAdjustingOnApplyFormats;
            }
            set
            {
                this.needTextAdjustingOnApplyFormats = value;
            }
        }

        public bool NeedValidate
        {
            get
            {
                return this.needValidate;
            }
            set
            {
                this.needValidate = value;
            }
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
            get
            {
                return this.parentRow;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return this.readOnly;
            }
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
            get
            {
                return this.readOnlyColor;
            }
            set
            {
                this.readOnlyColor = value;
                if ((this.ElementControl != null) && this.ReadOnly)
                {
                    this.ElementControl.ForeColor = this.readOnlyColor;
                }
            }
        }

        public virtual string SubType
        {
            get
            {
                return this.subType;
            }
            set
            {
                this.subType = value;
            }
        }

        public static string TagName
        {
            get
            {
                return "";
            }
        }

        public virtual string Text
        {
            get
            {
                return this.ftext;
            }
            set
            {
                if ((((this.ftext == string.Empty) && (value == string.Empty)) && (this.EmptyValueText != string.Empty)) || ((value != this.ftext) && (!(value == string.Empty) || !(this.ftext == this.EmptyValueText))))
                {
                    this.SetText(value);
                    this.OnContentChanged(false, true);
                }
            }
        }

        public virtual Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                this.textColor = value;
                if (this.ElementControl != null)
                {
                    this.ElementControl.ForeColor = this.textColor;
                }
            }
        }

        public string Value
        {
            get
            {
                return this.fvalue;
            }
            set
            {
                if (value != this.fvalue)
                {
                    this.SetValue(value);
                    this.OnContentChanged(true, false);
                    if (!this.disposed)
                    {
                        string textAdjustedByValue = this.GetTextAdjustedByValue(value);
                        if (this.ftext != textAdjustedByValue)
                        {
                            this.SetText(textAdjustedByValue);
                            this.OnContentChanged(false, true);
                        }
                    }
                }
            }
        }

        internal protected class BaseElementPanel : Panel
        {
            private XElement parent;

            public BaseElementPanel(XElement parent)
            {
                this.parent = parent;
                this.BackColor = Color.Transparent;
            }

            protected override bool IsInputKey(Keys keyData)
            {
                if ((!base.IsInputKey(keyData) && (keyData != Keys.Down)) && ((keyData != Keys.Up) && (keyData != Keys.Left)))
                {
                    return (keyData == Keys.Right);
                }
                return true;
            }

            protected override void OnClick(EventArgs e)
            {
                if (this.parent.parentRow != null)
                {
                    this.parent.parentRow.CloseEdits();
                    this.parent.parentRow.Active = true;
                }
                base.OnClick(e);
            }
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

