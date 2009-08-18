namespace Korzh.EasyQuery.ModelEditor
{
    using Korzh.EasyQuery;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class LinkPropsDlg : Form
    {
        private Button buttonAddCondition;
        private Button buttonCancel;
        private Button buttonClearCondition;
        private Button buttonDeleteCondition;
        private Button buttonOK;
        private CheckBox checkBoxQuoteFields;
        private ComboBox comboBoxField1;
        private ComboBox comboBoxField2;
        private ComboBox comboBoxLeftPartType;
        private ComboBox comboBoxOperator;
        private ComboBox comboBoxRightPartType;
        private ComboBox comboBoxTable1;
        private ComboBox comboBoxTable2;
        private IContainer components;
        private DbGate dbGate;
        private GroupBox groupBoxConditoins;
        private GroupBox groupBoxJoinType;
        private GroupBox groupBoxLeftPart;
        private GroupBox groupBoxRightPart;
        private Label labelOperators;
        private Label labelTable1;
        private Label labelTable2;
        private DataModel.Link link;
        private ListBox listBoxJoinConditions;
        private DataModel model;
        private Panel panel1;
        private RadioButton radioButtonCrossJoin;
        private RadioButton radioButtonFullJoin;
        private RadioButton radioButtonInnerJoin;
        private RadioButton radioButtonLeftJoin;
        private RadioButton radioButtonRightJoin;
        private TextBox textBoxConst1;
        private TextBox textBoxConst2;

        public LinkPropsDlg()
        {
            this.InitializeComponent();
            this.comboBoxOperator.SelectedIndex = 0;
            this.comboBoxLeftPartType.SelectedIndex = 0;
            this.comboBoxRightPartType.SelectedIndex = 0;
            this.comboBoxTable1.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBoxTable1.AutoCompleteMode = AutoCompleteMode.Append;
            this.comboBoxTable2.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBoxTable2.AutoCompleteMode = AutoCompleteMode.Append;
        }

        private void buttonAddCondition_Click(object sender, EventArgs e)
        {
            DataModel.Link.Condition item = new DataModel.Link.Condition(this.link);
            short num = 0;
            if (this.comboBoxLeftPartType.SelectedIndex == 0)
            {
                item.Expr1 = this.comboBoxField1.Text;
            }
            else
            {
                item.Expr1 = this.textBoxConst1.Text;
                num = (short) (num + 1);
            }
            if (this.comboBoxRightPartType.SelectedIndex == 0)
            {
                item.Expr2 = this.comboBoxField2.Text;
            }
            else
            {
                item.Expr2 = this.textBoxConst2.Text;
                num = (short) (num + 2);
            }
            if (num > 2)
            {
                item.CondType = DataModel.LinkCondType.ExprExpr;
            }
            else
            {
                switch (num)
                {
                    case 2:
                        item.CondType = DataModel.LinkCondType.FieldExpr;
                        goto Label_00A8;

                    case 1:
                        item.CondType = DataModel.LinkCondType.ExprField;
                        goto Label_00A8;
                }
                item.CondType = DataModel.LinkCondType.FieldField;
            }
        Label_00A8:
            item.Operator = this.comboBoxOperator.Text;
            this.listBoxJoinConditions.Items.Add(item);
            this.EnableControls();
        }

        private void buttonClearCondition_Click(object sender, EventArgs e)
        {
            this.listBoxJoinConditions.Items.Clear();
            this.EnableControls();
        }

        private void buttonDeleteCondition_Click(object sender, EventArgs e)
        {
            if (this.listBoxJoinConditions.SelectedIndex >= 0)
            {
                this.listBoxJoinConditions.Items.Remove(this.listBoxJoinConditions.SelectedIndex);
            }
            this.EnableControls();
        }

        private void comboBoxTable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillFields1Combo();
        }

        private void comboBoxTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillFields2Combo();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EnableControls()
        {
            this.buttonOK.Enabled = this.listBoxJoinConditions.Items.Count > 0;
        }

        private void FillDbSchemaControls()
        {
            this.comboBoxTable1.Items.Clear();
            this.comboBoxTable2.Items.Clear();
            foreach (DataModel.Table table in this.model.Tables)
            {
                this.comboBoxTable1.Items.Add(table);
                this.comboBoxTable2.Items.Add(table);
            }
        }

        private void FillFields1Combo()
        {
            this.comboBoxField1.Items.Clear();
            if (this.comboBoxTable1.SelectedItem != null)
            {
                DataModel.Table selectedItem = (DataModel.Table) this.comboBoxTable1.SelectedItem;
                foreach (DbFieldInfo info in this.dbGate.GetFields(selectedItem.DBName, selectedItem.SchemaName, selectedItem.Name))
                {
                    this.comboBoxField1.Items.Add(info.Name);
                }
            }
        }

        private void FillFields2Combo()
        {
            this.comboBoxField2.Items.Clear();
            if (this.comboBoxTable2.SelectedItem != null)
            {
                DataModel.Table selectedItem = (DataModel.Table) this.comboBoxTable2.SelectedItem;
                foreach (DbFieldInfo info in this.dbGate.GetFields(selectedItem.DBName, selectedItem.SchemaName, selectedItem.Name))
                {
                    this.comboBoxField2.Items.Add(info.Name);
                }
            }
        }

        private void InitializeComponent()
        {
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBoxConditoins = new GroupBox();
            this.comboBoxOperator = new ComboBox();
            this.groupBoxRightPart = new GroupBox();
            this.comboBoxRightPartType = new ComboBox();
            this.textBoxConst2 = new TextBox();
            this.comboBoxField2 = new ComboBox();
            this.groupBoxLeftPart = new GroupBox();
            this.comboBoxLeftPartType = new ComboBox();
            this.textBoxConst1 = new TextBox();
            this.comboBoxField1 = new ComboBox();
            this.buttonAddCondition = new Button();
            this.labelOperators = new Label();
            this.listBoxJoinConditions = new ListBox();
            this.buttonClearCondition = new Button();
            this.buttonDeleteCondition = new Button();
            this.groupBoxJoinType = new GroupBox();
            this.radioButtonCrossJoin = new RadioButton();
            this.radioButtonRightJoin = new RadioButton();
            this.radioButtonFullJoin = new RadioButton();
            this.radioButtonLeftJoin = new RadioButton();
            this.radioButtonInnerJoin = new RadioButton();
            this.panel1 = new Panel();
            this.comboBoxTable1 = new ComboBox();
            this.comboBoxTable2 = new ComboBox();
            this.labelTable2 = new Label();
            this.labelTable1 = new Label();
            this.checkBoxQuoteFields = new CheckBox();
            this.groupBoxConditoins.SuspendLayout();
            this.groupBoxRightPart.SuspendLayout();
            this.groupBoxLeftPart.SuspendLayout();
            this.groupBoxJoinType.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new Point(480, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(480, 0x30);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.groupBoxConditoins.Controls.Add(this.comboBoxOperator);
            this.groupBoxConditoins.Controls.Add(this.groupBoxRightPart);
            this.groupBoxConditoins.Controls.Add(this.groupBoxLeftPart);
            this.groupBoxConditoins.Controls.Add(this.buttonAddCondition);
            this.groupBoxConditoins.Controls.Add(this.labelOperators);
            this.groupBoxConditoins.Controls.Add(this.listBoxJoinConditions);
            this.groupBoxConditoins.Controls.Add(this.buttonClearCondition);
            this.groupBoxConditoins.Controls.Add(this.buttonDeleteCondition);
            this.groupBoxConditoins.Location = new Point(8, 0x88);
            this.groupBoxConditoins.Name = "groupBoxConditoins";
            this.groupBoxConditoins.Size = new Size(0x1d0, 0xd0);
            this.groupBoxConditoins.TabIndex = 13;
            this.groupBoxConditoins.TabStop = false;
            this.groupBoxConditoins.Text = "Join Conditions";
            this.comboBoxOperator.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOperator.Items.AddRange(new object[] { "=", "<>", ">", ">=", "<", "<=" });
            this.comboBoxOperator.Location = new Point(360, 0x68);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new Size(0x60, 0x15);
            this.comboBoxOperator.TabIndex = 0x2a;
            this.groupBoxRightPart.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBoxRightPart.Controls.Add(this.comboBoxRightPartType);
            this.groupBoxRightPart.Controls.Add(this.textBoxConst2);
            this.groupBoxRightPart.Controls.Add(this.comboBoxField2);
            this.groupBoxRightPart.Location = new Point(8, 0x98);
            this.groupBoxRightPart.Name = "groupBoxRightPart";
            this.groupBoxRightPart.Size = new Size(0x158, 0x30);
            this.groupBoxRightPart.TabIndex = 0x2d;
            this.groupBoxRightPart.TabStop = false;
            this.groupBoxRightPart.Text = "Condition right part ";
            this.comboBoxRightPartType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxRightPartType.Items.AddRange(new object[] { "Field", "Constant" });
            this.comboBoxRightPartType.Location = new Point(8, 0x10);
            this.comboBoxRightPartType.Name = "comboBoxRightPartType";
            this.comboBoxRightPartType.Size = new Size(0x60, 0x15);
            this.comboBoxRightPartType.TabIndex = 0x23;
            this.textBoxConst2.Location = new Point(0x80, 0x10);
            this.textBoxConst2.Name = "textBoxConst2";
            this.textBoxConst2.Size = new Size(0xc0, 20);
            this.textBoxConst2.TabIndex = 0x21;
            this.textBoxConst2.Text = "";
            this.comboBoxField2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxField2.DropDownWidth = 300;
            this.comboBoxField2.Location = new Point(0x80, 0x10);
            this.comboBoxField2.MaxDropDownItems = 0x10;
            this.comboBoxField2.Name = "comboBoxField2";
            this.comboBoxField2.Size = new Size(0xd0, 0x15);
            this.comboBoxField2.TabIndex = 0x20;
            this.groupBoxLeftPart.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBoxLeftPart.Controls.Add(this.comboBoxLeftPartType);
            this.groupBoxLeftPart.Controls.Add(this.textBoxConst1);
            this.groupBoxLeftPart.Controls.Add(this.comboBoxField1);
            this.groupBoxLeftPart.Location = new Point(8, 0x58);
            this.groupBoxLeftPart.Name = "groupBoxLeftPart";
            this.groupBoxLeftPart.Size = new Size(0x158, 0x30);
            this.groupBoxLeftPart.TabIndex = 0x2c;
            this.groupBoxLeftPart.TabStop = false;
            this.groupBoxLeftPart.Text = "Condition left part ";
            this.comboBoxLeftPartType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxLeftPartType.Items.AddRange(new object[] { "Field", "Constant" });
            this.comboBoxLeftPartType.Location = new Point(8, 0x10);
            this.comboBoxLeftPartType.Name = "comboBoxLeftPartType";
            this.comboBoxLeftPartType.Size = new Size(0x60, 0x15);
            this.comboBoxLeftPartType.TabIndex = 0x22;
            this.textBoxConst1.Location = new Point(0x80, 0x10);
            this.textBoxConst1.Name = "textBoxConst1";
            this.textBoxConst1.Size = new Size(0xc0, 20);
            this.textBoxConst1.TabIndex = 0x21;
            this.textBoxConst1.Text = "";
            this.comboBoxField1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxField1.DropDownWidth = 300;
            this.comboBoxField1.Location = new Point(0x80, 0x10);
            this.comboBoxField1.MaxDropDownItems = 0x10;
            this.comboBoxField1.Name = "comboBoxField1";
            this.comboBoxField1.Size = new Size(0xd0, 0x15);
            this.comboBoxField1.TabIndex = 0x20;
            this.buttonAddCondition.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonAddCondition.Location = new Point(360, 0x98);
            this.buttonAddCondition.Name = "buttonAddCondition";
            this.buttonAddCondition.Size = new Size(0x60, 0x17);
            this.buttonAddCondition.TabIndex = 0x2b;
            this.buttonAddCondition.Text = "Add Condition";
            this.buttonAddCondition.Click += new EventHandler(this.buttonAddCondition_Click);
            this.labelOperators.AutoSize = true;
            this.labelOperators.Location = new Point(360, 0x58);
            this.labelOperators.Name = "labelOperators";
            this.labelOperators.Size = new Size(0x31, 0x10);
            this.labelOperators.TabIndex = 0x29;
            this.labelOperators.Text = "Operator";
            this.listBoxJoinConditions.Items.AddRange(new object[] { "AAAA", "BBBB", "CCCC" });
            this.listBoxJoinConditions.Location = new Point(6, 0x13);
            this.listBoxJoinConditions.Name = "listBoxJoinConditions";
            this.listBoxJoinConditions.Size = new Size(0x15b, 0x38);
            this.listBoxJoinConditions.TabIndex = 3;
            this.buttonClearCondition.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonClearCondition.Location = new Point(0x178, 0x10);
            this.buttonClearCondition.Name = "buttonClearCondition";
            this.buttonClearCondition.TabIndex = 1;
            this.buttonClearCondition.Text = "Clear";
            this.buttonClearCondition.Click += new EventHandler(this.buttonClearCondition_Click);
            this.buttonDeleteCondition.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonDeleteCondition.Location = new Point(0x178, 0x30);
            this.buttonDeleteCondition.Name = "buttonDeleteCondition";
            this.buttonDeleteCondition.TabIndex = 0;
            this.buttonDeleteCondition.Text = "Delete";
            this.buttonDeleteCondition.Click += new EventHandler(this.buttonDeleteCondition_Click);
            this.groupBoxJoinType.Controls.Add(this.radioButtonCrossJoin);
            this.groupBoxJoinType.Controls.Add(this.radioButtonRightJoin);
            this.groupBoxJoinType.Controls.Add(this.radioButtonFullJoin);
            this.groupBoxJoinType.Controls.Add(this.radioButtonLeftJoin);
            this.groupBoxJoinType.Controls.Add(this.radioButtonInnerJoin);
            this.groupBoxJoinType.Location = new Point(8, 0x38);
            this.groupBoxJoinType.Name = "groupBoxJoinType";
            this.groupBoxJoinType.Size = new Size(0x158, 0x48);
            this.groupBoxJoinType.TabIndex = 14;
            this.groupBoxJoinType.TabStop = false;
            this.groupBoxJoinType.Text = "Join Type";
            this.radioButtonCrossJoin.Location = new Point(0xf8, 0x10);
            this.radioButtonCrossJoin.Name = "radioButtonCrossJoin";
            this.radioButtonCrossJoin.Size = new Size(0x58, 0x11);
            this.radioButtonCrossJoin.TabIndex = 4;
            this.radioButtonCrossJoin.Text = "Cross Join";
            this.radioButtonRightJoin.Location = new Point(0x80, 0x10);
            this.radioButtonRightJoin.Name = "radioButtonRightJoin";
            this.radioButtonRightJoin.Size = new Size(0x6f, 0x11);
            this.radioButtonRightJoin.TabIndex = 3;
            this.radioButtonRightJoin.Text = "Outer Right Join";
            this.radioButtonFullJoin.Location = new Point(0x80, 40);
            this.radioButtonFullJoin.Name = "radioButtonFullJoin";
            this.radioButtonFullJoin.Size = new Size(0x67, 0x11);
            this.radioButtonFullJoin.TabIndex = 2;
            this.radioButtonFullJoin.Text = "Full Join";
            this.radioButtonLeftJoin.Location = new Point(0x10, 0x2a);
            this.radioButtonLeftJoin.Name = "radioButtonLeftJoin";
            this.radioButtonLeftJoin.Size = new Size(0x68, 0x11);
            this.radioButtonLeftJoin.TabIndex = 1;
            this.radioButtonLeftJoin.Text = "Outer Left Join";
            this.radioButtonInnerJoin.Checked = true;
            this.radioButtonInnerJoin.Location = new Point(0x10, 0x13);
            this.radioButtonInnerJoin.Name = "radioButtonInnerJoin";
            this.radioButtonInnerJoin.Size = new Size(0x58, 0x11);
            this.radioButtonInnerJoin.TabIndex = 0;
            this.radioButtonInnerJoin.TabStop = true;
            this.radioButtonInnerJoin.Text = "Inner Join";
            this.panel1.Controls.Add(this.comboBoxTable1);
            this.panel1.Controls.Add(this.comboBoxTable2);
            this.panel1.Controls.Add(this.labelTable2);
            this.panel1.Controls.Add(this.labelTable1);
            this.panel1.Location = new Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1d0, 40);
            this.panel1.TabIndex = 0x2a;
            this.comboBoxTable1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxTable1.DropDownWidth = 300;
            this.comboBoxTable1.Location = new Point(0, 0x10);
            this.comboBoxTable1.MaxDropDownItems = 0x24;
            this.comboBoxTable1.Name = "comboBoxTable1";
            this.comboBoxTable1.Size = new Size(0xe0, 0x15);
            this.comboBoxTable1.Sorted = true;
            this.comboBoxTable1.TabIndex = 0x2a;
            this.comboBoxTable1.SelectedIndexChanged += new EventHandler(this.comboBoxTable1_SelectedIndexChanged);
            this.comboBoxTable2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxTable2.DropDownWidth = 300;
            this.comboBoxTable2.Location = new Point(240, 0x10);
            this.comboBoxTable2.MaxDropDownItems = 0x24;
            this.comboBoxTable2.Name = "comboBoxTable2";
            this.comboBoxTable2.Size = new Size(0xd8, 0x15);
            this.comboBoxTable2.Sorted = true;
            this.comboBoxTable2.TabIndex = 0x2d;
            this.comboBoxTable2.SelectedIndexChanged += new EventHandler(this.comboBoxTable2_SelectedIndexChanged);
            this.labelTable2.AutoSize = true;
            this.labelTable2.Location = new Point(240, 0);
            this.labelTable2.Name = "labelTable2";
            this.labelTable2.Size = new Size(0x27, 0x10);
            this.labelTable2.TabIndex = 0x2c;
            this.labelTable2.Text = "Table2";
            this.labelTable1.AutoSize = true;
            this.labelTable1.Location = new Point(0, 0);
            this.labelTable1.Name = "labelTable1";
            this.labelTable1.Size = new Size(0x27, 0x10);
            this.labelTable1.TabIndex = 0x2b;
            this.labelTable1.Text = "Table1";
            this.checkBoxQuoteFields.Location = new Point(0x170, 0x38);
            this.checkBoxQuoteFields.Name = "checkBoxQuoteFields";
            this.checkBoxQuoteFields.Size = new Size(0x60, 0x18);
            this.checkBoxQuoteFields.TabIndex = 0x2e;
            this.checkBoxQuoteFields.Text = "Quote fields";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x232, 0x160);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBoxJoinType);
            base.Controls.Add(this.groupBoxConditoins);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.checkBoxQuoteFields);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "LinkPropsDlg";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "LinkPropsDlg";
            base.Load += new EventHandler(this.LinkPropsDlg_Load);
            base.Activated += new EventHandler(this.LinkPropsDlg_Activated);
            this.groupBoxConditoins.ResumeLayout(false);
            this.groupBoxRightPart.ResumeLayout(false);
            this.groupBoxLeftPart.ResumeLayout(false);
            this.groupBoxJoinType.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void LinkPropsDlg_Activated(object sender, EventArgs e)
        {
            this.EnableControls();
        }

        private void LinkPropsDlg_Load(object sender, EventArgs e)
        {
            XPStyle.ApplyVisualStyles(this);
        }

        private void radionButtonCond_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideControls();
        }

        protected virtual void RenderLink()
        {
            this.Text = "Link: " + this.link.ToString();
            this.comboBoxTable1.Enabled = this.link.Table1 == null;
            if (this.link.Table1 != null)
            {
                this.comboBoxTable1.SelectedItem = this.link.Table1;
                this.FillFields1Combo();
            }
            this.comboBoxTable2.Enabled = this.link.Table2 == null;
            if (this.link.Table2 != null)
            {
                this.comboBoxTable2.SelectedItem = this.link.Table2;
                this.FillFields2Combo();
            }
            switch (this.link.Type)
            {
                case DataModel.Link.LinkType.Left:
                    this.radioButtonLeftJoin.Checked = true;
                    break;

                case DataModel.Link.LinkType.Right:
                    this.radioButtonRightJoin.Checked = true;
                    break;

                case DataModel.Link.LinkType.Full:
                    this.radioButtonFullJoin.Checked = true;
                    break;

                case DataModel.Link.LinkType.Cross:
                    this.radioButtonCrossJoin.Checked = true;
                    break;

                default:
                    this.radioButtonInnerJoin.Checked = true;
                    break;
            }
            this.checkBoxQuoteFields.Checked = this.link.QuoteFields;
            this.listBoxJoinConditions.Items.Clear();
            foreach (DataModel.Link.Condition condition in this.link.Conditions)
            {
                this.listBoxJoinConditions.Items.Add(condition);
            }
        }

        protected virtual void SaveLink()
        {
            this.link.Table1 = (DataModel.Table) this.comboBoxTable1.SelectedItem;
            this.link.Table2 = (DataModel.Table) this.comboBoxTable2.SelectedItem;
            this.link.QuoteFields = this.checkBoxQuoteFields.Checked;
            if (this.radioButtonLeftJoin.Checked)
            {
                this.link.Type = DataModel.Link.LinkType.Left;
            }
            else if (this.radioButtonRightJoin.Checked)
            {
                this.link.Type = DataModel.Link.LinkType.Right;
            }
            else if (this.radioButtonFullJoin.Checked)
            {
                this.link.Type = DataModel.Link.LinkType.Full;
            }
            else if (this.radioButtonCrossJoin.Checked)
            {
                this.link.Type = DataModel.Link.LinkType.Cross;
            }
            else
            {
                this.link.Type = DataModel.Link.LinkType.Inner;
            }
            this.link.Conditions.Clear();
            foreach (DataModel.Link.Condition condition in this.listBoxJoinConditions.Items)
            {
                this.link.Conditions.Add(condition);
            }
        }

        private void showHideControls()
        {
            this.comboBoxField1.Visible = this.comboBoxLeftPartType.SelectedIndex == 0;
            this.textBoxConst1.Visible = this.comboBoxLeftPartType.SelectedIndex == 1;
            this.comboBoxField2.Visible = this.comboBoxRightPartType.SelectedIndex == 0;
            this.textBoxConst2.Visible = this.comboBoxRightPartType.SelectedIndex == 1;
        }

        public bool ShowModal(DbGate dbGate, DataModel model, DataModel.Link link, string dlgTitle)
        {
            this.Text = dlgTitle;
            this.dbGate = dbGate;
            this.model = model;
            this.link = link;
            this.FillDbSchemaControls();
            this.showHideControls();
            this.RenderLink();
            bool flag = base.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.SaveLink();
            }
            return flag;
        }
    }
}

