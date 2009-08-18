namespace Korzh.EasyQuery.ModelEditor
{
    using Korzh.EasyQuery;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ModelPropsDlg : Form
    {
        private Button buttonBuildConnection;
        private Button buttonCancel;
        private Button buttonOK;
        private Button buttonTestConn;
        private CheckBox checkBoxLoginPrompt;
        private ComboBox comboBoxDbGate;
        private Container components;
        private Korzh.EasyQuery.DbGate dbGate;
        private DbParameters dbParams = new DbParameters();
        private static string DMETitle = "Data Model Editor";
        private Label label1;
        private Label labelConnectionString;
        private Label labelModelDesc;
        private Label labelModelName;
        private TextBox textBoxConnectionString;
        private TextBox textBoxModelDesc;
        private TextBox textBoxModelName;

        public ModelPropsDlg()
        {
            this.InitializeComponent();
            XPStyle.ApplyVisualStyles(this);
        }

        private void buttonBuildConnection_Click(object sender, EventArgs e)
        {
            this.dbGate = (Korzh.EasyQuery.DbGate) this.comboBoxDbGate.SelectedItem;
            if (((this.dbGate != null) && (this.dbGate.ConnectionStringBuilderDlg != null)) && this.dbGate.ConnectionStringBuilderDlg.RunDialog(this.dbGate))
            {
                this.textBoxConnectionString.Text = this.dbGate.ConnectionStringBuilderDlg.ConnectionString;
            }
        }

        private void buttonTestConn_Click(object sender, EventArgs e)
        {
            this.SaveDbGateProps();
            try
            {
                this.dbGate.Connected = true;
                MessageBox.Show("Test connection succeeded", DMETitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, DMETitle + " Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void comboBoxDbGate_SelectedValueChanged(object sender, EventArgs e)
        {
            object selectedItem = ((ComboBox) sender).SelectedItem;
            this.buttonBuildConnection.Enabled = (selectedItem != null) && (((Korzh.EasyQuery.DbGate) selectedItem).ConnectionStringBuilderDlg != null);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillDbGatesCombo()
        {
            this.comboBoxDbGate.Items.Clear();
            foreach (Korzh.EasyQuery.DbGate gate in Korzh.EasyQuery.ModelEditor.ModelEditor.DbGates)
            {
                this.comboBoxDbGate.Items.Add(gate);
            }
        }

        private void InitializeComponent()
        {
            this.labelModelName = new Label();
            this.textBoxModelName = new TextBox();
            this.comboBoxDbGate = new ComboBox();
            this.textBoxConnectionString = new TextBox();
            this.labelConnectionString = new Label();
            this.labelModelDesc = new Label();
            this.textBoxModelDesc = new TextBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.buttonTestConn = new Button();
            this.buttonBuildConnection = new Button();
            this.label1 = new Label();
            this.checkBoxLoginPrompt = new CheckBox();
            base.SuspendLayout();
            this.labelModelName.AutoSize = true;
            this.labelModelName.Location = new Point(8, 8);
            this.labelModelName.Name = "labelModelName";
            this.labelModelName.Size = new Size(0x43, 13);
            this.labelModelName.TabIndex = 0;
            this.labelModelName.Text = "Model Name";
            this.textBoxModelName.Location = new Point(8, 0x18);
            this.textBoxModelName.Name = "textBoxModelName";
            this.textBoxModelName.Size = new Size(0x178, 20);
            this.textBoxModelName.TabIndex = 1;
            this.comboBoxDbGate.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxDbGate.Location = new Point(8, 0x48);
            this.comboBoxDbGate.Name = "comboBoxDbGate";
            this.comboBoxDbGate.Size = new Size(0x178, 0x15);
            this.comboBoxDbGate.TabIndex = 3;
            this.comboBoxDbGate.SelectedValueChanged += new EventHandler(this.comboBoxDbGate_SelectedValueChanged);
            this.textBoxConnectionString.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.textBoxConnectionString.Location = new Point(8, 120);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.ScrollBars = ScrollBars.Vertical;
            this.textBoxConnectionString.Size = new Size(0x178, 80);
            this.textBoxConnectionString.TabIndex = 5;
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new Point(8, 0x68);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new Size(0x59, 13);
            this.labelConnectionString.TabIndex = 4;
            this.labelConnectionString.Text = "Connection string";
            this.labelModelDesc.AutoSize = true;
            this.labelModelDesc.Location = new Point(8, 0xf8);
            this.labelModelDesc.Name = "labelModelDesc";
            this.labelModelDesc.Size = new Size(90, 13);
            this.labelModelDesc.TabIndex = 8;
            this.labelModelDesc.Text = "Model description";
            this.textBoxModelDesc.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.textBoxModelDesc.Location = new Point(8, 0x108);
            this.textBoxModelDesc.Multiline = true;
            this.textBoxModelDesc.Name = "textBoxModelDesc";
            this.textBoxModelDesc.ScrollBars = ScrollBars.Vertical;
            this.textBoxModelDesc.Size = new Size(0x178, 0x38);
            this.textBoxModelDesc.TabIndex = 9;
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(400, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(80, 0x17);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(400, 0x30);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(80, 0x17);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonTestConn.Location = new Point(0x98, 0xd0);
            this.buttonTestConn.Name = "buttonTestConn";
            this.buttonTestConn.Size = new Size(0x70, 0x17);
            this.buttonTestConn.TabIndex = 7;
            this.buttonTestConn.Text = "Test connection";
            this.buttonTestConn.Click += new EventHandler(this.buttonTestConn_Click);
            this.buttonBuildConnection.Enabled = false;
            this.buttonBuildConnection.Location = new Point(0x110, 0xd0);
            this.buttonBuildConnection.Name = "buttonBuildConnection";
            this.buttonBuildConnection.Size = new Size(0x70, 0x17);
            this.buttonBuildConnection.TabIndex = 6;
            this.buttonBuildConnection.Text = "Build connection";
            this.buttonBuildConnection.Click += new EventHandler(this.buttonBuildConnection_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 0x38);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xae, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database gate (type of connection)";
            this.checkBoxLoginPrompt.Location = new Point(8, 0xd0);
            this.checkBoxLoginPrompt.Name = "checkBoxLoginPrompt";
            this.checkBoxLoginPrompt.Size = new Size(0x88, 0x18);
            this.checkBoxLoginPrompt.TabIndex = 12;
            this.checkBoxLoginPrompt.Text = "Show login dialog";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x1e8, 0x146);
            base.Controls.Add(this.comboBoxDbGate);
            base.Controls.Add(this.checkBoxLoginPrompt);
            base.Controls.Add(this.buttonBuildConnection);
            base.Controls.Add(this.buttonTestConn);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.textBoxModelDesc);
            base.Controls.Add(this.labelModelDesc);
            base.Controls.Add(this.textBoxConnectionString);
            base.Controls.Add(this.labelConnectionString);
            base.Controls.Add(this.textBoxModelName);
            base.Controls.Add(this.labelModelName);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ModelPropsDlg";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "New Model";
            base.Load += new EventHandler(this.ModelPropsDlg_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ModelPropsDlg_Load(object sender, EventArgs e)
        {
        }

        private void SaveDbGateProps()
        {
            this.dbGate = (Korzh.EasyQuery.DbGate) this.comboBoxDbGate.SelectedItem;
            this.dbGate.ConnectionString = this.textBoxConnectionString.Text;
            this.dbGate.LoginPrompt = this.checkBoxLoginPrompt.Checked;
        }

        public bool ShowModal(DataModel model, string dlgTitle)
        {
            this.Text = dlgTitle;
            this.textBoxModelName.Text = model.ModelName;
            this.textBoxModelDesc.Text = model.Description;
            this.FillDbGatesCombo();
            if (this.dbGate != null)
            {
                this.comboBoxDbGate.SelectedItem = this.dbGate;
                this.textBoxConnectionString.Text = this.dbGate.ConnectionString;
                this.checkBoxLoginPrompt.Checked = this.dbGate.LoginPrompt;
            }
            else
            {
                this.comboBoxDbGate.SelectedIndex = 0;
            }
            bool flag = base.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.SaveDbGateProps();
                model.ModelName = this.textBoxModelName.Text;
                model.Description = this.textBoxModelDesc.Text;
            }
            return flag;
        }

        public Korzh.EasyQuery.DbGate DbGate
        {
            get
            {
                return this.dbGate;
            }
            set
            {
                this.dbGate = value;
            }
        }
    }
}

