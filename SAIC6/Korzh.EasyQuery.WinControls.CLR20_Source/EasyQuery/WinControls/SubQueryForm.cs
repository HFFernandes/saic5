namespace Korzh.EasyQuery.WinControls
{
    using Korzh.EasyQuery;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class SubQueryForm : Form
    {
        private Button buttonCancel;
        private Button buttonClear;
        private Button buttonOK;
        private Container components;
        internal DataModel dataModel;
        private bool ignoreTabChange = true;
        private Label labelColumns;
        private Label labelQuery;
        private Label labelSql;
        private Panel pnlBottom;
        internal Query query;
        private QueryColumnsPanel queryColumnsPanel;
        internal QueryPanel queryPanel;
        internal string ResultXml = "";
        private Splitter splitter;
        private string sqlOld = "";
        private TabControl tabPanel;
        internal TabPage tabQBuilder;
        private TabPage tabSql;
        internal TextBox textSQL;

        public SubQueryForm()
        {
            this.InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (this.tabPanel.SelectedIndex == 0)
            {
                this.query.Clear();
            }
            else
            {
                this.textSQL.Clear();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.tabPanel.SelectedIndex == 0)
            {
                if (this.queryIsEmpty())
                {
                    this.ResultXml = "";
                }
                else
                {
                    this.ResultXml = this.query.SaveToString();
                }
            }
            else if (this.textSQL.Text == string.Empty)
            {
                this.ResultXml = "";
            }
            else
            {
                this.ResultXml = "<SQL>" + this.textSQL.Text + "</SQL>";
            }
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Init(QueryPanel parentQP)
        {
            this.dataModel = parentQP.Model;
            this.queryPanel.Appearance = parentQP.Appearance;
            this.queryPanel.BackColor = parentQP.BackColor;
            this.queryPanel.SqlExecute += new SqlExecuteEventHandler(parentQP.HandleSubQuerySqlExecute);
            this.queryPanel.ListRequest += new ListRequestEventHandler(parentQP.HandleSubQueryListRequest);
            this.queryPanel.ValueRequest += new ValueRequestEventHandler(parentQP.HandleSubQueryValueRequest);
            this.queryPanel.CreateValueElement += new CreateValueElementEventHandler(parentQP.HandleSubQueryCreateValueElement);
            this.query.Formats.CopyFrom(parentQP.Query.Formats);
        }

        private void InitializeComponent()
        {
            this.tabPanel = new TabControl();
            this.tabQBuilder = new TabPage();
            this.queryPanel = new QueryPanel();
            this.labelQuery = new Label();
            this.splitter = new Splitter();
            this.queryColumnsPanel = new QueryColumnsPanel();
            this.labelColumns = new Label();
            this.tabSql = new TabPage();
            this.textSQL = new TextBox();
            this.labelSql = new Label();
            this.pnlBottom = new Panel();
            this.buttonClear = new Button();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.query = new Query();
            this.dataModel = new DataModel();
            this.tabPanel.SuspendLayout();
            this.tabQBuilder.SuspendLayout();
            this.tabSql.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            base.SuspendLayout();
            this.tabPanel.Appearance = TabAppearance.FlatButtons;
            this.tabPanel.Controls.Add(this.tabQBuilder);
            this.tabPanel.Controls.Add(this.tabSql);
            this.tabPanel.Dock = DockStyle.Fill;
            this.tabPanel.Location = new Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new Size(0x210, 0x11e);
            this.tabPanel.TabIndex = 1;
            this.tabPanel.SelectedIndexChanged += new EventHandler(this.tabPanel_SelectedIndexChanged);
            this.tabQBuilder.Controls.Add(this.queryPanel);
            this.tabQBuilder.Controls.Add(this.labelQuery);
            this.tabQBuilder.Controls.Add(this.splitter);
            this.tabQBuilder.Controls.Add(this.queryColumnsPanel);
            this.tabQBuilder.Controls.Add(this.labelColumns);
            this.tabQBuilder.Location = new Point(4, 0x19);
            this.tabQBuilder.Name = "tabQBuilder";
            this.tabQBuilder.Size = new Size(520, 0x101);
            this.tabQBuilder.TabIndex = 2;
            this.tabQBuilder.Text = "Query Builder";
            this.queryPanel.Active = false;
            this.queryPanel.ActiveRowIndex = -1;
            this.queryPanel.Appearance.ActiveBackColor = Color.FromArgb(190, 0xe1, 190);
            this.queryPanel.Appearance.ActiveForeColor = SystemColors.HighlightText;
            this.queryPanel.Appearance.AdjustChildLevel = true;
            this.queryPanel.Appearance.AttrElementFormat = "{entity} {attr}";
            this.queryPanel.Appearance.ButtonActiveBodyColor = Color.Gray;
            this.queryPanel.Appearance.ButtonActiveBorderColor = Color.Black;
            this.queryPanel.Appearance.ButtonClickBodyColor = Color.White;
            this.queryPanel.Appearance.ButtonClickBorderColor = Color.Black;
            this.queryPanel.Appearance.ButtonForeColor = SystemColors.ControlText;
            this.queryPanel.Appearance.ButtonInactiveBodyColor = Color.Transparent;
            this.queryPanel.Appearance.ButtonInactiveBorderColor = Color.Black;
            this.queryPanel.Appearance.ButtonRounded = true;
            this.queryPanel.Appearance.EditMode = QueryPanel.EditModeKind.All;
            this.queryPanel.Appearance.ElementSpacing = 2;
            this.queryPanel.Appearance.EmptyEditText = "[enter value]";
            this.queryPanel.Appearance.EmptyListText = "[select value]";
            this.queryPanel.Appearance.LeftMargin = 2;
            this.queryPanel.Appearance.LevelSpacing = 30;
            this.queryPanel.Appearance.LinkColor = Color.Blue;
            this.queryPanel.Appearance.ReadOnlyColor = Color.Black;
            this.queryPanel.Appearance.RowCheckBoxes = true;
            this.queryPanel.Appearance.RowHeight = 0x12;
            this.queryPanel.Appearance.ShowRootRow = true;
            this.queryPanel.Appearance.ShowRowNum = false;
            this.queryPanel.Appearance.TuneElementSizes = false;
            this.queryPanel.BackColor = Color.White;
            this.queryPanel.BorderStyle = BorderStyle.FixedSingle;
            this.queryPanel.Dock = DockStyle.Fill;
            this.queryPanel.Location = new Point(0, 0x90);
            this.queryPanel.Model = null;
            this.queryPanel.Name = "queryPanel";
            this.queryPanel.Query = null;
            this.queryPanel.Size = new Size(520, 0x71);
            this.queryPanel.TabIndex = 4;
            this.labelQuery.Dock = DockStyle.Top;
            this.labelQuery.Location = new Point(0, 0x77);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new Size(520, 0x19);
            this.labelQuery.TabIndex = 3;
            this.labelQuery.Text = "Query";
            this.labelQuery.TextAlign = ContentAlignment.BottomLeft;
            this.labelQuery.Click += new EventHandler(this.labelQuery_Click);
            this.splitter.Dock = DockStyle.Top;
            this.splitter.Location = new Point(0, 0x74);
            this.splitter.Name = "splitter";
            this.splitter.Size = new Size(520, 3);
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.queryColumnsPanel.Active = false;
            this.queryColumnsPanel.ActiveRowIndex = -1;
            this.queryColumnsPanel.Appearance.ActiveBackColor = Color.FromArgb(190, 0xe1, 190);
            this.queryColumnsPanel.Appearance.ActiveForeColor = SystemColors.HighlightText;
            this.queryColumnsPanel.Appearance.AdjustChildLevel = true;
            this.queryColumnsPanel.Appearance.AttrElementFormat = "{entity} {attr}";
            this.queryColumnsPanel.Appearance.BackColor = Color.Ivory;
            this.queryColumnsPanel.Appearance.BorderStyle = BorderStyle.FixedSingle;
            this.queryColumnsPanel.Appearance.ButtonActiveBodyColor = Color.Gray;
            this.queryColumnsPanel.Appearance.ButtonActiveBorderColor = Color.Black;
            this.queryColumnsPanel.Appearance.ButtonClickBodyColor = Color.White;
            this.queryColumnsPanel.Appearance.ButtonClickBorderColor = Color.Black;
            this.queryColumnsPanel.Appearance.ButtonForeColor = SystemColors.ControlText;
            this.queryColumnsPanel.Appearance.ButtonInactiveBodyColor = Color.Transparent;
            this.queryColumnsPanel.Appearance.ButtonInactiveBorderColor = Color.Black;
            this.queryColumnsPanel.Appearance.ButtonRounded = true;
            this.queryColumnsPanel.Appearance.ElementSpacing = 2;
            this.queryColumnsPanel.Appearance.LeftMargin = 2;
            this.queryColumnsPanel.Appearance.LevelSpacing = 30;
            this.queryColumnsPanel.Appearance.LinkColor = Color.Blue;
            this.queryColumnsPanel.Appearance.ReadOnlyColor = Color.Black;
            this.queryColumnsPanel.Appearance.RowCheckBoxes = true;
            this.queryColumnsPanel.Appearance.RowHeight = 0x12;
            this.queryColumnsPanel.Appearance.Title = "";
            this.queryColumnsPanel.Appearance.TuneElementSizes = false;
            this.queryColumnsPanel.BackColor = Color.Ivory;
            this.queryColumnsPanel.BorderStyle = BorderStyle.FixedSingle;
            this.queryColumnsPanel.Dock = DockStyle.Top;
            this.queryColumnsPanel.Location = new Point(0, 0x10);
            this.queryColumnsPanel.Model = null;
            this.queryColumnsPanel.Name = "queryColumnsPanel";
            this.queryColumnsPanel.Query = null;
            this.queryColumnsPanel.Size = new Size(520, 100);
            this.queryColumnsPanel.TabIndex = 1;
            this.labelColumns.Dock = DockStyle.Top;
            this.labelColumns.Location = new Point(0, 0);
            this.labelColumns.Name = "labelColumns";
            this.labelColumns.Size = new Size(520, 0x10);
            this.labelColumns.TabIndex = 0;
            this.labelColumns.Text = "Columns";
            this.tabSql.Controls.Add(this.textSQL);
            this.tabSql.Controls.Add(this.labelSql);
            this.tabSql.Location = new Point(4, 0x19);
            this.tabSql.Name = "tabSql";
            this.tabSql.Size = new Size(520, 0x101);
            this.tabSql.TabIndex = 1;
            this.tabSql.Text = "SQL";
            this.textSQL.Dock = DockStyle.Fill;
            this.textSQL.Location = new Point(0, 0x10);
            this.textSQL.Multiline = true;
            this.textSQL.Name = "textSQL";
            this.textSQL.Size = new Size(520, 0xf1);
            this.textSQL.TabIndex = 1;
            this.labelSql.Dock = DockStyle.Top;
            this.labelSql.Location = new Point(0, 0);
            this.labelSql.Name = "labelSql";
            this.labelSql.Size = new Size(520, 0x10);
            this.labelSql.TabIndex = 0;
            this.labelSql.Text = "SQL query text";
            this.pnlBottom.Controls.Add(this.buttonClear);
            this.pnlBottom.Controls.Add(this.buttonOK);
            this.pnlBottom.Controls.Add(this.buttonCancel);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 0x11e);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(0x210, 40);
            this.pnlBottom.TabIndex = 2;
            this.buttonClear.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.buttonClear.Location = new Point(8, 8);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new Size(80, 0x18);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new EventHandler(this.buttonClear_Click);
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x158, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(80, 0x18);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(440, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(80, 0x18);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.query.FilePath = "";
            this.query.Model = null;
            this.dataModel.CustomInfo = "";
            this.dataModel.DefQueryFilePath = "";
            this.dataModel.Description = null;
            this.dataModel.ModelName = null;
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(0x210, 0x146);
            base.Controls.Add(this.tabPanel);
            base.Controls.Add(this.pnlBottom);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "SubQueryForm";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Edit Sub Query";
            this.tabPanel.ResumeLayout(false);
            this.tabQBuilder.ResumeLayout(false);
            this.tabSql.ResumeLayout(false);
            this.tabSql.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void InitQuery(string queryXml)
        {
            this.query.Model = null;
            this.query.Model = this.dataModel;
            this.queryColumnsPanel.Model = this.dataModel;
            this.queryColumnsPanel.Query = this.query;
            this.queryPanel.Model = this.dataModel;
            this.queryPanel.Query = this.query;
            this.textSQL.Text = "";
            this.ignoreTabChange = true;
            if (queryXml == string.Empty)
            {
                this.query.Clear();
                this.tabPanel.SelectedIndex = 0;
                this.ignoreTabChange = false;
                this.queryPanel.Activate();
                this.queryColumnsPanel.Activate();
            }
            else
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(queryXml);
                XmlNode documentElement = document.DocumentElement;
                if (documentElement.Name == "SQL")
                {
                    this.textSQL.Text = documentElement.InnerText;
                    this.sqlOld = "";
                    this.ignoreTabChange = true;
                    this.tabPanel.SelectedIndex = 1;
                }
                else
                {
                    this.query.LoadFromString(documentElement.OuterXml, Query.RWOptions.All);
                    this.tabPanel.SelectedIndex = 0;
                    this.queryPanel.Activate();
                    this.queryColumnsPanel.Activate();
                }
                this.ignoreTabChange = false;
            }
        }

        private void labelQuery_Click(object sender, EventArgs e)
        {
        }

        private bool queryIsEmpty()
        {
            return ((this.query.Root.Conditions.Count == 0) && (this.query.Result.Columns.Count == 0));
        }

        private bool sqlModified()
        {
            return (this.sqlOld != this.textSQL.Text);
        }

        private void tabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ignoreTabChange)
            {
                this.ignoreTabChange = false;
            }
            else if (this.tabPanel.SelectedIndex == 1)
            {
                if (this.queryIsEmpty())
                {
                    this.textSQL.Text = "";
                    this.sqlOld = "";
                }
                else
                {
                    this.query.BuildSQL();
                    this.textSQL.Text = this.query.Result.SQL;
                    this.sqlOld = this.textSQL.Text;
                }
            }
            else if (this.sqlModified() && (MessageBox.Show("The changes you made in SQL text will be lost. Continue?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No))
            {
                this.ignoreTabChange = true;
                this.tabPanel.SelectedIndex = 1;
            }
        }
    }
}

