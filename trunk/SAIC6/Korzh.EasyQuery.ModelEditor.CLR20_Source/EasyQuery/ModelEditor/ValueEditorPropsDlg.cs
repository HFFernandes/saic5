namespace Korzh.EasyQuery.ModelEditor
{
    using Korzh.EasyQuery;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ValueEditorPropsDlg : Form
    {
        private Button btVEConstListAddItem;
        private Button btVEConstListDeleteItem;
        private Button btVEConstListUpdateItem;
        private Button buttonCancel;
        private Button buttonOK;
        private ColumnHeader columnHeaderText;
        private ColumnHeader columnHeaderValue;
        private ComboBox comboBoxVETextDataType;
        private Container components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelVEConstListText;
        private Label labelVEConstListValue;
        private Label labelVECustomListName;
        private Label labelVETextDefValue;
        private ListView listViewVEConstListItems;
        private Panel panelAttrValEditorConstList;
        private Panel panelAttrValEditorCustom;
        private Panel panelAttrValEditorCustomList;
        private Panel panelAttrValEditorProps;
        private Panel panelAttrValEditorSqlList;
        private Panel panelAttrValEditorTextEdit;
        private TextBox textBoxVEConstListText;
        private TextBox textBoxVEConstListValue;
        private TextBox textBoxVECustomData;
        private TextBox textBoxVECustomListName;
        private TextBox textBoxVESqlListSQL;
        private TextBox textBoxVETextDefValue;
        private ValueEditor valueEditor;

        public ValueEditorPropsDlg()
        {
            this.InitializeComponent();
            XPStyle.ApplyVisualStyles(this);
            this.InitControls();
        }

        private void btVEConstListAddItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(this.textBoxVEConstListValue.Text, 0);
            item.SubItems.Add(this.textBoxVEConstListText.Text);
            this.listViewVEConstListItems.Items.Add(item);
            item.Selected = true;
        }

        private void btVEConstListDeleteItem_Click(object sender, EventArgs e)
        {
            int index = this.listViewVEConstListItems.SelectedIndices[0];
            this.listViewVEConstListItems.Items.RemoveAt(index);
            if (index >= this.listViewVEConstListItems.Items.Count)
            {
                index--;
            }
            if (index >= 0)
            {
                this.listViewVEConstListItems.Items[index].Selected = true;
            }
            else
            {
                this.EnableVEConstListControls();
            }
        }

        private void btVEConstListUpdateItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.listViewVEConstListItems.SelectedItems[0];
            item.Text = this.textBoxVEConstListValue.Text;
            item.SubItems[1].Text = this.textBoxVEConstListText.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EnableVEConstListControls()
        {
            bool flag = this.listViewVEConstListItems.SelectedItems.Count > 0;
            this.btVEConstListUpdateItem.Enabled = flag;
            this.btVEConstListDeleteItem.Enabled = flag;
        }

        private void InitControls()
        {
            DataType[] values = (DataType[]) Enum.GetValues(typeof(DataType));
            this.comboBoxVETextDataType.Items.Clear();
            foreach (DataType type in values)
            {
                this.comboBoxVETextDataType.Items.Add(type);
            }
        }

        private void InitializeComponent()
        {
            this.panelAttrValEditorProps = new Panel();
            this.panelAttrValEditorCustom = new Panel();
            this.textBoxVECustomData = new TextBox();
            this.label3 = new Label();
            this.panelAttrValEditorCustomList = new Panel();
            this.textBoxVECustomListName = new TextBox();
            this.labelVECustomListName = new Label();
            this.panelAttrValEditorConstList = new Panel();
            this.textBoxVEConstListText = new TextBox();
            this.labelVEConstListText = new Label();
            this.textBoxVEConstListValue = new TextBox();
            this.labelVEConstListValue = new Label();
            this.btVEConstListUpdateItem = new Button();
            this.btVEConstListDeleteItem = new Button();
            this.btVEConstListAddItem = new Button();
            this.listViewVEConstListItems = new ListView();
            this.columnHeaderValue = new ColumnHeader();
            this.columnHeaderText = new ColumnHeader();
            this.panelAttrValEditorTextEdit = new Panel();
            this.comboBoxVETextDataType = new ComboBox();
            this.label1 = new Label();
            this.textBoxVETextDefValue = new TextBox();
            this.labelVETextDefValue = new Label();
            this.panelAttrValEditorSqlList = new Panel();
            this.textBoxVESqlListSQL = new TextBox();
            this.label2 = new Label();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.panelAttrValEditorProps.SuspendLayout();
            this.panelAttrValEditorCustom.SuspendLayout();
            this.panelAttrValEditorCustomList.SuspendLayout();
            this.panelAttrValEditorConstList.SuspendLayout();
            this.panelAttrValEditorTextEdit.SuspendLayout();
            this.panelAttrValEditorSqlList.SuspendLayout();
            base.SuspendLayout();
            this.panelAttrValEditorProps.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panelAttrValEditorProps.Controls.Add(this.panelAttrValEditorCustom);
            this.panelAttrValEditorProps.Controls.Add(this.panelAttrValEditorCustomList);
            this.panelAttrValEditorProps.Controls.Add(this.panelAttrValEditorConstList);
            this.panelAttrValEditorProps.Controls.Add(this.panelAttrValEditorTextEdit);
            this.panelAttrValEditorProps.Controls.Add(this.panelAttrValEditorSqlList);
            this.panelAttrValEditorProps.Location = new Point(0, 0);
            this.panelAttrValEditorProps.Name = "panelAttrValEditorProps";
            this.panelAttrValEditorProps.Size = new Size(0x1d2, 0x170);
            this.panelAttrValEditorProps.TabIndex = 2;
            this.panelAttrValEditorCustom.Controls.Add(this.textBoxVECustomData);
            this.panelAttrValEditorCustom.Controls.Add(this.label3);
            this.panelAttrValEditorCustom.Location = new Point(0x10, 0x108);
            this.panelAttrValEditorCustom.Name = "panelAttrValEditorCustom";
            this.panelAttrValEditorCustom.Size = new Size(0xe4, 0x58);
            this.panelAttrValEditorCustom.TabIndex = 7;
            this.panelAttrValEditorCustom.Tag = "5";
            this.panelAttrValEditorCustom.Visible = false;
            this.textBoxVECustomData.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.textBoxVECustomData.Location = new Point(8, 0x18);
            this.textBoxVECustomData.Multiline = true;
            this.textBoxVECustomData.Name = "textBoxVECustomData";
            this.textBoxVECustomData.Size = new Size(0xd4, 60);
            this.textBoxVECustomData.TabIndex = 3;
            this.textBoxVECustomData.Text = "";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1c, 0x10);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data";
            this.panelAttrValEditorCustomList.Controls.Add(this.textBoxVECustomListName);
            this.panelAttrValEditorCustomList.Controls.Add(this.labelVECustomListName);
            this.panelAttrValEditorCustomList.Location = new Point(0x10, 0xd0);
            this.panelAttrValEditorCustomList.Name = "panelAttrValEditorCustomList";
            this.panelAttrValEditorCustomList.Size = new Size(0xc0, 0x30);
            this.panelAttrValEditorCustomList.TabIndex = 5;
            this.panelAttrValEditorCustomList.Tag = "3";
            this.panelAttrValEditorCustomList.Visible = false;
            this.textBoxVECustomListName.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.textBoxVECustomListName.Location = new Point(0x58, 0x10);
            this.textBoxVECustomListName.Name = "textBoxVECustomListName";
            this.textBoxVECustomListName.Size = new Size(0x58, 20);
            this.textBoxVECustomListName.TabIndex = 3;
            this.textBoxVECustomListName.Text = "";
            this.labelVECustomListName.AutoSize = true;
            this.labelVECustomListName.Location = new Point(8, 0x10);
            this.labelVECustomListName.Name = "labelVECustomListName";
            this.labelVECustomListName.Size = new Size(0x38, 0x10);
            this.labelVECustomListName.TabIndex = 2;
            this.labelVECustomListName.Text = "List name:";
            this.panelAttrValEditorConstList.Controls.Add(this.textBoxVEConstListText);
            this.panelAttrValEditorConstList.Controls.Add(this.labelVEConstListText);
            this.panelAttrValEditorConstList.Controls.Add(this.textBoxVEConstListValue);
            this.panelAttrValEditorConstList.Controls.Add(this.labelVEConstListValue);
            this.panelAttrValEditorConstList.Controls.Add(this.btVEConstListUpdateItem);
            this.panelAttrValEditorConstList.Controls.Add(this.btVEConstListDeleteItem);
            this.panelAttrValEditorConstList.Controls.Add(this.btVEConstListAddItem);
            this.panelAttrValEditorConstList.Controls.Add(this.listViewVEConstListItems);
            this.panelAttrValEditorConstList.Location = new Point(8, 0x58);
            this.panelAttrValEditorConstList.Name = "panelAttrValEditorConstList";
            this.panelAttrValEditorConstList.Size = new Size(440, 200);
            this.panelAttrValEditorConstList.TabIndex = 4;
            this.panelAttrValEditorConstList.Tag = "2";
            this.panelAttrValEditorConstList.Visible = false;
            this.textBoxVEConstListText.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.textBoxVEConstListText.Location = new Point(0x130, 0x48);
            this.textBoxVEConstListText.Name = "textBoxVEConstListText";
            this.textBoxVEConstListText.Size = new Size(0x80, 20);
            this.textBoxVEConstListText.TabIndex = 7;
            this.textBoxVEConstListText.Text = "";
            this.labelVEConstListText.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.labelVEConstListText.AutoSize = true;
            this.labelVEConstListText.Location = new Point(0x130, 0x38);
            this.labelVEConstListText.Name = "labelVEConstListText";
            this.labelVEConstListText.Size = new Size(0x1a, 0x10);
            this.labelVEConstListText.TabIndex = 6;
            this.labelVEConstListText.Text = "Text";
            this.textBoxVEConstListValue.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.textBoxVEConstListValue.Location = new Point(0x130, 0x18);
            this.textBoxVEConstListValue.Name = "textBoxVEConstListValue";
            this.textBoxVEConstListValue.Size = new Size(0x80, 20);
            this.textBoxVEConstListValue.TabIndex = 5;
            this.textBoxVEConstListValue.Text = "";
            this.labelVEConstListValue.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.labelVEConstListValue.AutoSize = true;
            this.labelVEConstListValue.Location = new Point(0x130, 8);
            this.labelVEConstListValue.Name = "labelVEConstListValue";
            this.labelVEConstListValue.Size = new Size(0x21, 0x10);
            this.labelVEConstListValue.TabIndex = 4;
            this.labelVEConstListValue.Text = "Value";
            this.btVEConstListUpdateItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btVEConstListUpdateItem.Location = new Point(0x148, 0x88);
            this.btVEConstListUpdateItem.Name = "btVEConstListUpdateItem";
            this.btVEConstListUpdateItem.TabIndex = 3;
            this.btVEConstListUpdateItem.Text = "Update";
            this.btVEConstListUpdateItem.Click += new EventHandler(this.btVEConstListUpdateItem_Click);
            this.btVEConstListDeleteItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btVEConstListDeleteItem.Location = new Point(0x148, 0xa8);
            this.btVEConstListDeleteItem.Name = "btVEConstListDeleteItem";
            this.btVEConstListDeleteItem.TabIndex = 2;
            this.btVEConstListDeleteItem.Text = "Delete";
            this.btVEConstListDeleteItem.Click += new EventHandler(this.btVEConstListDeleteItem_Click);
            this.btVEConstListAddItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btVEConstListAddItem.Location = new Point(0x148, 0x68);
            this.btVEConstListAddItem.Name = "btVEConstListAddItem";
            this.btVEConstListAddItem.TabIndex = 1;
            this.btVEConstListAddItem.Text = "Add";
            this.btVEConstListAddItem.Click += new EventHandler(this.btVEConstListAddItem_Click);
            this.listViewVEConstListItems.Activation = ItemActivation.OneClick;
            this.listViewVEConstListItems.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listViewVEConstListItems.Columns.AddRange(new ColumnHeader[] { this.columnHeaderValue, this.columnHeaderText });
            this.listViewVEConstListItems.FullRowSelect = true;
            this.listViewVEConstListItems.HideSelection = false;
            this.listViewVEConstListItems.Location = new Point(8, 8);
            this.listViewVEConstListItems.MultiSelect = false;
            this.listViewVEConstListItems.Name = "listViewVEConstListItems";
            this.listViewVEConstListItems.Size = new Size(0x120, 0xb8);
            this.listViewVEConstListItems.TabIndex = 0;
            this.listViewVEConstListItems.View = View.Details;
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 140;
            this.columnHeaderText.Text = "Text";
            this.columnHeaderText.Width = 140;
            this.panelAttrValEditorTextEdit.Controls.Add(this.comboBoxVETextDataType);
            this.panelAttrValEditorTextEdit.Controls.Add(this.label1);
            this.panelAttrValEditorTextEdit.Controls.Add(this.textBoxVETextDefValue);
            this.panelAttrValEditorTextEdit.Controls.Add(this.labelVETextDefValue);
            this.panelAttrValEditorTextEdit.Location = new Point(8, 8);
            this.panelAttrValEditorTextEdit.Name = "panelAttrValEditorTextEdit";
            this.panelAttrValEditorTextEdit.Size = new Size(0x180, 0x48);
            this.panelAttrValEditorTextEdit.TabIndex = 3;
            this.panelAttrValEditorTextEdit.Tag = "1";
            this.panelAttrValEditorTextEdit.Visible = false;
            this.comboBoxVETextDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxVETextDataType.Location = new Point(0x58, 40);
            this.comboBoxVETextDataType.Name = "comboBoxVETextDataType";
            this.comboBoxVETextDataType.Size = new Size(0x98, 0x15);
            this.comboBoxVETextDataType.TabIndex = 7;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 0x30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 0x10);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data type";
            this.textBoxVETextDefValue.Location = new Point(0x58, 8);
            this.textBoxVETextDefValue.Name = "textBoxVETextDefValue";
            this.textBoxVETextDefValue.Size = new Size(0xf8, 20);
            this.textBoxVETextDefValue.TabIndex = 1;
            this.textBoxVETextDefValue.Text = "";
            this.labelVETextDefValue.AutoSize = true;
            this.labelVETextDefValue.Location = new Point(8, 11);
            this.labelVETextDefValue.Name = "labelVETextDefValue";
            this.labelVETextDefValue.Size = new Size(0x49, 0x10);
            this.labelVETextDefValue.TabIndex = 0;
            this.labelVETextDefValue.Text = "Default value:";
            this.panelAttrValEditorSqlList.Controls.Add(this.textBoxVESqlListSQL);
            this.panelAttrValEditorSqlList.Controls.Add(this.label2);
            this.panelAttrValEditorSqlList.Location = new Point(0x108, 0xd8);
            this.panelAttrValEditorSqlList.Name = "panelAttrValEditorSqlList";
            this.panelAttrValEditorSqlList.Size = new Size(200, 0x88);
            this.panelAttrValEditorSqlList.TabIndex = 6;
            this.panelAttrValEditorSqlList.Tag = "4";
            this.panelAttrValEditorSqlList.Visible = false;
            this.textBoxVESqlListSQL.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.textBoxVESqlListSQL.Location = new Point(8, 0x18);
            this.textBoxVESqlListSQL.Multiline = true;
            this.textBoxVESqlListSQL.Name = "textBoxVESqlListSQL";
            this.textBoxVESqlListSQL.Size = new Size(0xb8, 0x6c);
            this.textBoxVESqlListSQL.TabIndex = 3;
            this.textBoxVESqlListSQL.Text = "";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new Size(80, 0x10);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL statement";
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1e2, 0x10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x1e2, 0x38);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(570, 0x16e);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.panelAttrValEditorProps);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ValueEditorPropsDlg";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Value editor settings";
            this.panelAttrValEditorProps.ResumeLayout(false);
            this.panelAttrValEditorCustom.ResumeLayout(false);
            this.panelAttrValEditorCustomList.ResumeLayout(false);
            this.panelAttrValEditorConstList.ResumeLayout(false);
            this.panelAttrValEditorTextEdit.ResumeLayout(false);
            this.panelAttrValEditorSqlList.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void listViewVEConstListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = (this.listViewVEConstListItems.SelectedItems.Count > 0) ? this.listViewVEConstListItems.SelectedItems[0] : null;
            if (item != null)
            {
                this.textBoxVEConstListValue.Text = item.Text;
                this.textBoxVEConstListText.Text = item.SubItems[1].Text;
            }
            this.EnableVEConstListControls();
        }

        protected virtual void RenderValueEditorProps()
        {
            this.panelAttrValEditorTextEdit.Visible = false;
            this.panelAttrValEditorCustomList.Visible = false;
            this.panelAttrValEditorConstList.Visible = false;
            this.panelAttrValEditorSqlList.Visible = false;
            this.panelAttrValEditorCustom.Visible = false;
            if (this.valueEditor is TextValueEditor)
            {
                this.ShowPropsPanel(this.panelAttrValEditorTextEdit);
                this.textBoxVETextDefValue.Text = ((TextValueEditor) this.valueEditor).DefaultValue;
                this.comboBoxVETextDataType.SelectedItem = ((TextValueEditor) this.valueEditor).ValueType;
            }
            else if (this.valueEditor is ConstListValueEditor)
            {
                this.ShowPropsPanel(this.panelAttrValEditorConstList);
                this.listViewVEConstListItems.Items.Clear();
                foreach (ConstValueItem item in ((ConstListValueEditor) this.valueEditor).Values)
                {
                    ListViewItem item2 = new ListViewItem(item.ID, 0);
                    item2.SubItems.Add(item.Text);
                    this.listViewVEConstListItems.Items.Add(item2);
                }
            }
            else if (this.valueEditor is CustomListValueEditor)
            {
                this.ShowPropsPanel(this.panelAttrValEditorCustomList);
                this.textBoxVECustomListName.Text = ((CustomListValueEditor) this.valueEditor).ListName;
            }
            else if (this.valueEditor is SqlListValueEditor)
            {
                this.ShowPropsPanel(this.panelAttrValEditorSqlList);
                this.textBoxVESqlListSQL.Text = ((SqlListValueEditor) this.valueEditor).SQL;
            }
            else if (this.valueEditor is CustomValueEditor)
            {
                this.ShowPropsPanel(this.panelAttrValEditorCustom);
                this.textBoxVECustomData.Text = ((CustomValueEditor) this.valueEditor).Data;
            }
        }

        protected virtual void SaveValueEditorProps()
        {
            if (this.valueEditor is TextValueEditor)
            {
                ((TextValueEditor) this.valueEditor).DefaultValue = this.textBoxVETextDefValue.Text;
                ((TextValueEditor) this.valueEditor).ValueType = (DataType) this.comboBoxVETextDataType.SelectedItem;
            }
            else if (this.valueEditor is ConstListValueEditor)
            {
                ConstListValueEditor valueEditor = (ConstListValueEditor) this.valueEditor;
                valueEditor.Values.Clear();
                foreach (ListViewItem item in this.listViewVEConstListItems.Items)
                {
                    valueEditor.Values.Add(item.Text, item.SubItems[1].Text);
                }
            }
            else if (this.valueEditor is CustomListValueEditor)
            {
                ((CustomListValueEditor) this.valueEditor).ListName = this.textBoxVECustomListName.Text;
            }
            else if (this.valueEditor is SqlListValueEditor)
            {
                ((SqlListValueEditor) this.valueEditor).SQL = this.textBoxVESqlListSQL.Text;
            }
            else if (this.valueEditor is CustomValueEditor)
            {
                ((CustomValueEditor) this.valueEditor).Data = this.textBoxVECustomData.Text;
            }
        }

        public bool ShowModal(ValueEditor valueEditor)
        {
            this.valueEditor = valueEditor;
            this.RenderValueEditorProps();
            bool flag = base.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.SaveValueEditorProps();
            }
            return flag;
        }

        private void ShowPropsPanel(Panel panel)
        {
            panel.Location = new Point(0, 0);
            panel.Size = this.panelAttrValEditorProps.ClientSize;
            panel.Visible = true;
        }
    }
}

