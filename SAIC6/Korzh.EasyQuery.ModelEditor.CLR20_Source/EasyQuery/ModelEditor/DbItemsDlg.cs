namespace Korzh.EasyQuery.ModelEditor
{
    using Korzh.EasyQuery;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DbItemsDlg : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private CheckBox checkBoxOption1;
        private ComboBox comboBoxGroup;
        private Container components;
        private DbGate dbGate;
        private DbItemType itemType;
        private Label labelGroup;
        private ListBox listBoxMain;
        private DataModel model;
        private Panel panelGroup;
        private Panel panelOptions;
        private Panel panelRight;

        public DbItemsDlg()
        {
            this.InitializeComponent();
            XPStyle.ApplyVisualStyles(this);
            this.comboBoxGroup.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBoxGroup.AutoCompleteMode = AutoCompleteMode.Append;
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.itemType == DbItemType.ModelOperators)
            {
                this.RefillOperatorList();
            }
            else
            {
                this.RefillFieldsList();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelGroup = new Panel();
            this.comboBoxGroup = new ComboBox();
            this.labelGroup = new Label();
            this.panelRight = new Panel();
            this.buttonCancel = new Button();
            this.buttonOK = new Button();
            this.listBoxMain = new ListBox();
            this.panelOptions = new Panel();
            this.checkBoxOption1 = new CheckBox();
            this.panelGroup.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelOptions.SuspendLayout();
            base.SuspendLayout();
            this.panelGroup.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.panelGroup.Controls.Add(this.comboBoxGroup);
            this.panelGroup.Controls.Add(this.labelGroup);
            this.panelGroup.Location = new Point(0, 0);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new Size(0xf8, 0x2c);
            this.panelGroup.TabIndex = 0;
            this.comboBoxGroup.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.comboBoxGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxGroup.Location = new Point(4, 0x12);
            this.comboBoxGroup.MaxDropDownItems = 0x24;
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new Size(0xec, 0x15);
            this.comboBoxGroup.Sorted = true;
            this.comboBoxGroup.TabIndex = 1;
            this.comboBoxGroup.SelectedIndexChanged += new EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new Point(4, 4);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new Size(0x23, 0x10);
            this.labelGroup.TabIndex = 0;
            this.labelGroup.Text = "label1";
            this.panelRight.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panelRight.Controls.Add(this.buttonCancel);
            this.panelRight.Controls.Add(this.buttonOK);
            this.panelRight.Location = new Point(0xf8, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new Size(0x58, 0x170);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new PaintEventHandler(this.panelRight_Paint);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(8, 0x30);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(8, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.listBoxMain.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listBoxMain.Location = new Point(4, 0x30);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.SelectionMode = SelectionMode.MultiExtended;
            this.listBoxMain.Size = new Size(240, 0x115);
            this.listBoxMain.TabIndex = 2;
            this.panelOptions.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.panelOptions.Controls.Add(this.checkBoxOption1);
            this.panelOptions.Location = new Point(0, 0x150);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new Size(0xf8, 0x18);
            this.panelOptions.TabIndex = 3;
            this.panelOptions.Visible = false;
            this.checkBoxOption1.Location = new Point(4, 0);
            this.checkBoxOption1.Name = "checkBoxOption1";
            this.checkBoxOption1.Size = new Size(260, 0x18);
            this.checkBoxOption1.TabIndex = 0;
            this.checkBoxOption1.Text = "option1";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x150, 0x16e);
            base.Controls.Add(this.listBoxMain);
            base.Controls.Add(this.panelRight);
            base.Controls.Add(this.panelGroup);
            base.Controls.Add(this.panelOptions);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            base.Name = "DbItemsDlg";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ListDlg";
            this.panelGroup.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {
        }

        protected virtual void RefillFieldsList()
        {
            this.listBoxMain.Items.Clear();
            DataModel.Table selectedItem = (DataModel.Table) this.comboBoxGroup.SelectedItem;
            if (selectedItem != null)
            {
                foreach (DbFieldInfo info in this.dbGate.GetFields(selectedItem.DBName, selectedItem.SchemaName, selectedItem.Name))
                {
                    this.listBoxMain.Items.Add(info);
                }
            }
        }

        protected void RefillOperatorList()
        {
            this.listBoxMain.Items.Clear();
            DataModel.OperatorGroup selectedItem = (DataModel.OperatorGroup) this.comboBoxGroup.SelectedItem;
            if (selectedItem != null)
            {
                foreach (DataModel.Operator @operator in this.model.Operators)
                {
                    if ((selectedItem == DataModel.AnyOperatorGroup) || (selectedItem == @operator.Group))
                    {
                        this.listBoxMain.Items.Add(@operator);
                    }
                }
            }
        }

        public bool ShowModal(DbGate dbGate, DataModel model, DbItemType itemType, string dlgTitle, Params dlgParams)
        {
            this.Text = dlgTitle;
            this.dbGate = dbGate;
            this.model = model;
            this.itemType = itemType;
            switch (itemType)
            {
                case DbItemType.DbTables:
                    this.panelGroup.Visible = false;
                    this.panelOptions.Visible = true;
                    this.listBoxMain.Top = 4;
                    this.listBoxMain.Height = (base.ClientSize.Height - 12) - this.panelOptions.Height;
                    this.checkBoxOption1.Text = "Automatically add entities";
                    this.checkBoxOption1.Checked = dlgParams.Option1;
                    foreach (DbTableInfo info in dbGate.GetTables("", ""))
                    {
                        this.listBoxMain.Items.Add(info);
                    }
                    break;

                case DbItemType.ModelTables:
                    this.panelGroup.Visible = false;
                    this.panelOptions.Visible = false;
                    this.listBoxMain.Top = 4;
                    this.listBoxMain.Height = base.ClientSize.Height - 8;
                    foreach (DataModel.Table table in model.Tables)
                    {
                        this.listBoxMain.Items.Add(table);
                    }
                    break;

                case DbItemType.ModelOperators:
                    this.labelGroup.Text = "Operator groups";
                    this.panelGroup.Visible = true;
                    this.panelOptions.Visible = false;
                    this.listBoxMain.Top = 0x30;
                    this.listBoxMain.Height = base.ClientSize.Height - 0x34;
                    this.comboBoxGroup.Items.Clear();
                    this.comboBoxGroup.Items.Add(DataModel.AnyOperatorGroup);
                    foreach (DataModel.OperatorGroup group in DataModel.OperatorGroups)
                    {
                        this.comboBoxGroup.Items.Add(group);
                    }
                    this.comboBoxGroup.SelectedIndex = 0;
                    break;

                default:
                    this.labelGroup.Text = "Table";
                    this.panelGroup.Visible = true;
                    this.panelOptions.Visible = false;
                    this.listBoxMain.Top = 0x30;
                    this.listBoxMain.Height = base.ClientSize.Height - 0x34;
                    foreach (DataModel.Table table2 in model.Tables)
                    {
                        this.comboBoxGroup.Items.Add(table2);
                    }
                    if (model.Tables.Count > 0)
                    {
                        this.comboBoxGroup.SelectedIndex = 0;
                    }
                    break;
            }
            bool flag = base.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                dlgParams.ResultGroup = this.comboBoxGroup.SelectedItem;
                dlgParams.Option1 = this.checkBoxOption1.Checked;
                dlgParams.ResultList.Clear();
                foreach (object obj2 in this.listBoxMain.SelectedItems)
                {
                    dlgParams.ResultList.Add(obj2);
                }
            }
            return flag;
        }

        public class Params
        {
            public bool Option1;
            public object ResultGroup;
            public ArrayList ResultList = new ArrayList();
        }
    }
}

