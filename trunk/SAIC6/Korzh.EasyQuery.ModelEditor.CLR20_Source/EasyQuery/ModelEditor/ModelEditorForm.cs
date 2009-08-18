namespace Korzh.EasyQuery.ModelEditor
{
    using Korzh.EasyQuery;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class ModelEditorForm : Form
    {
        private AboutDlg aboutDlg;
        private bool autoAddEntitiesForTable = true;
        private Button buttonAttrAddTable;
        private Button buttonAttrDefValEditorSettings;
        private Button buttonAttrDeleteTable;
        private Button buttonAttrOpAdd;
        private Button buttonAttrOpAddDefault;
        private Button buttonAttrOpClear;
        private Button buttonAttrOpDelete;
        private Button buttonLinkAdd;
        private Button buttonLinkDelete;
        private Button buttonLinkEdit;
        private Button buttonOpDefValEditorSettings;
        private CheckBox checkBoxAttrIsAggregate;
        private CheckBox checkBoxAttrQuote;
        private CheckBox checkBoxAttrUseAlias;
        private CheckBox checkBoxAttrUseInConditions;
        private CheckBox checkBoxAttrUseInResult;
        private CheckBox checkBoxAttrUseInSorting;
        private CheckBox checkBoxOpCaseInsens;
        private CheckBox checkBoxQuote;
        private CheckedListBox checkedListBoxOpAppliedTypes;
        private MenuItem cmenuItemEntAdd;
        private MenuItem cmenuItemEntAddDataAttr;
        private MenuItem cmenuItemEntAddSub;
        private MenuItem cmenuItemEntAddVirtAttr;
        private MenuItem cmenuItemEntDelete;
        private MenuItem cmenuItemTableAdd;
        private MenuItem cmenuItemTableDelete;
        private ComboBox comboBoxAttrDataType;
        private ComboBox comboBoxAttrValEditorType;
        private ComboBox comboBoxOpDefValueEditor;
        private ComboBox comboBoxOpExprType;
        private ComboBox comboBoxOpGroup;
        private ComboBox comboBoxOpGroupFilter;
        private ComboBox comboBoxOpValueKind;
        private ComboBox comboBoxTableHints;
        private IContainer components;
        private ContextMenu contextMenuEntities;
        private ContextMenu contextMenuTables;
        private ValueEditor currentAttrValueEditor;
        private object currentEntityObj;
        private DataModel.Operator currentOperator;
        private ValueEditor currentOpValueEditor;
        private DataModel.Table currentTable;
        private DbGate dbGate;
        private DbItemsDlg dbItemsDialog;
        private string DMETitle = "Data Model Editor";
        private GroupBox groupBoxAttrOptions;
        private GroupBox groupBoxAttrTables;
        private GroupBox groupBoxEntityAttrProps;
        private GroupBox groupBoxLinkedTables;
        private GroupBox groupBoxTableProps;
        private ImageList imageListEntities;
        private static DataTypeList IntDataTypes = new DataTypeList(new DataType[] { DataType.Byte, DataType.Word, DataType.Int, DataType.Int64, DataType.Autoinc });
        private Label labelAlias;
        private Label labelAttrCaption;
        private Label labelAttrCustomData;
        private Label labelAttrDataType;
        private Label labelAttrDescription;
        private Label labelAttrExpr;
        private Label labelAttrSize;
        private Label labelDefValEditor;
        private Label labelEntityCaption;
        private Label labelEntityUserData;
        private Label labelHints;
        private Label labelOpAppliedTypes;
        private Label labelOpCaption;
        private Label labelOpDataType;
        private Label labelOpDefValueEditor;
        private Label labelOpDispFormat;
        private Label labelOpExpr;
        private Label labelOpGroup;
        private Label labelOpGroupFilter;
        private Label labelOpID;
        private Label labelOpValueKind;
        private static DataTypeList LinkDataTypes = new DataTypeList(new DataType[] { DataType.String, DataType.WideString, DataType.Byte, DataType.Word, DataType.Int, DataType.Int64, DataType.Autoinc });
        private LinkPropsDlg linkPropsDlg;
        private ListBox listBoxAttrOperators;
        private ListBox listBoxAttrTables;
        private ListBox listBoxOperators;
        private ListBox listBoxTableLinks;
        private ListBox listBoxTables;
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItemAbout;
        private MenuItem menuItemAddDataAttr;
        private MenuItem menuItemAddEntity;
        private MenuItem menuItemAddSubEntity;
        private MenuItem menuItemAddVirtualAttr;
        private MenuItem menuItemAutoAddLinks;
        private MenuItem menuItemAutoGenerateLinks;
        private MenuItem menuItemContents;
        private MenuItem menuItemEditModelSettings;
        private MenuItem menuItemEntities;
        private MenuItem menuItemEntitiesDelete;
        private MenuItem menuItemExit;
        private MenuItem menuItemHelp;
        private MenuItem menuItemModel;
        private MenuItem menuItemNewModel;
        private MenuItem menuItemOpenModel;
        private MenuItem menuItemOperatorAdd;
        private MenuItem menuItemOperatorAddUpdateDefault;
        private MenuItem menuItemOperatorDelete;
        private MenuItem menuItemOperators;
        private MenuItem menuItemSaveModel;
        private MenuItem menuItemSaveModelAs;
        private MenuItem menuItemSep11;
        private MenuItem menuItemSep21;
        private MenuItem menuItemTableAdd;
        private MenuItem menuItemTableDelete;
        private MenuItem menuItemTables;
        private DataModel model = new DataModel();
        private bool modelChanged;
        private ModelPropsDlg modelPropsDlg;
        private NumericUpDown numUpDownAttrSize;
        private OpenFileDialog openFileDlg;
        private Panel panelAttrValEditorsTop;
        private Panel panelEntityProps;
        private Panel panelOperatorProps;
        private Panel panelTableProps;
        private int rendering;
        private bool runNewModelWizardOnStart;
        private SaveFileDialog saveFileDlg;
        private TabControl tabControlAttrProps;
        private TabControl tabControlMain;
        private TabPage tabEntities;
        private TabPage tabOperators;
        private TabPage tabPageAttrGeneral;
        private TabPage tabPageAttrOperators;
        private TabPage tabPageAttrValueEditors;
        private TabPage tabTables;
        private TextBox textBoxAttrCaption;
        private TextBox textBoxAttrCustomData;
        private TextBox textBoxAttrDescription;
        private TextBox textBoxAttrExpr;
        private TextBox textBoxEntityName;
        private TextBox textBoxEntityUserData;
        private TextBox textBoxOpCaption;
        private TextBox textBoxOpDisplayFormat;
        private TextBox textBoxOpExpr;
        private TextBox textBoxOpID;
        private TextBox textBoxTableAlias;
        private Timer timer1;
        private TreeView treeViewEntities;
        private ValueEditorPropsDlg valueEditorPropsDlg;
        private string workFolder = "";

        public ModelEditorForm()
        {
            this.model.UseResourcesForOperators = false;
            this.InitializeComponent();
            this.InitModelControls();
            this.EnableMenuItems();
            ListBoxItemDragger dragger = new ListBoxItemDragger(this.listBoxAttrOperators);
            dragger.ItemMoved += new EventHandler(this.SomeChangesOccured);
            XPStyle.ApplyVisualStyles(this);
        }

        protected virtual void AddDataAttr()
        {
            DbItemsDlg.Params dlgParams = new DbItemsDlg.Params();
            if (this.ShowDbItemsListDlg(DbItemType.DbFields, "Add field(s)", dlgParams))
            {
                DataModel.Table resultGroup = (DataModel.Table) dlgParams.ResultGroup;
                TreeNode selectedNode = this.treeViewEntities.SelectedNode;
                if (selectedNode.Tag is DataModel.EntityAttr)
                {
                    selectedNode = selectedNode.Parent;
                }
                DataModel.Entity tag = (DataModel.Entity) selectedNode.Tag;
                foreach (DbFieldInfo info in dlgParams.ResultList)
                {
                    DataModel.EntityAttr attr = new DataModel.EntityAttr();
                    attr.Kind = DataModel.EntAttrKind.Data;
                    attr.Tables.Add(resultGroup);
                    attr.Caption = info.Name;
                    attr.Expr = info.Name;
                    attr.DataType = info.FieldType;
                    attr.Size = info.Size;
                    attr.FillOperatorsWithDefaults(this.model);
                    this.model.AssignEntityAttrID(attr);
                    tag.Attributes.Add(attr);
                    TreeNode node = new TreeNode(attr.Caption, 1, 1);
                    node.Tag = attr;
                    selectedNode.Nodes.Add(node);
                    this.treeViewEntities.SelectedNode = node;
                }
                this.ModelChanged = true;
                this.EnableEntityControls();
            }
        }

        protected virtual void AddEntity(TreeNode parentNode)
        {
            DataModel.Entity tag;
            TreeNodeCollection nodes;
            if (parentNode != null)
            {
                tag = (DataModel.Entity) parentNode.Tag;
                nodes = parentNode.Nodes;
            }
            else
            {
                tag = this.model.EntityRoot;
                nodes = this.treeViewEntities.Nodes;
            }
            int count = tag.SubEntities.Count;
            DataModel.Entity entity2 = new DataModel.Entity();
            entity2.Name = "New entity";
            tag.SubEntities.Add(entity2);
            TreeNode node = new TreeNode(entity2.Name, 0, 0);
            node.Tag = entity2;
            nodes.Insert(count, node);
            this.treeViewEntities.SelectedNode = node;
            this.ModelChanged = true;
            this.EnableEntityControls();
        }

        private void AddEntityForTable(DataModel.Table table)
        {
            DataModel.Entity entity = new DataModel.Entity();
            entity.Name = table.Alias;
            this.model.EntityRoot.SubEntities.Add(entity);
            foreach (DbFieldInfo info in this.dbGate.GetFields(table.DBName, table.SchemaName, table.Name))
            {
                DataModel.EntityAttr attr = new DataModel.EntityAttr();
                attr.Caption = info.Name;
                attr.Tables.Add(table);
                attr.Expr = info.Name;
                attr.DataType = info.FieldType;
                attr.Size = info.Size;
                attr.FillOperatorsWithDefaults(this.model);
                this.model.AssignEntityAttrID(attr);
                entity.Attributes.Add(attr);
            }
            this.RenderEntities();
        }

        protected void AddEntityNode(DataModel.Entity entity, TreeNodeCollection parentNodes)
        {
            TreeNode node = new TreeNode(entity.Name, 0, 0);
            node.Tag = entity;
            parentNodes.Add(node);
            this.AddSubEntityNodes(entity, node.Nodes);
            foreach (DataModel.EntityAttr attr in entity.Attributes)
            {
                TreeNode node2 = new TreeNode(attr.Caption, 1, 1);
                node2.Tag = attr;
                node.Nodes.Add(node2);
            }
        }

        protected virtual void AddLinkByLinkInfo(DbLinkInfo linkInfo)
        {
            DataModel.Table table = this.model.Tables.FindByName(linkInfo.Table1Name);
            if (table != null)
            {
                DataModel.Table table2 = this.model.Tables.FindByName(linkInfo.Table2Name);
                if (table2 != null)
                {
                    DataModel.Link link = new DataModel.Link();
                    link.Table1 = table;
                    link.Table2 = table2;
                    link.AddCondition(DataModel.LinkCondType.FieldField, linkInfo.Field1Name, linkInfo.Field2Name, "=");
                    this.model.Links.Add(link);
                }
            }
        }

        private void AddNewOperator()
        {
            DataModel.Operator @operator = new DataModel.Operator();
            @operator.ID = "NewOp";
            @operator.Caption = "New operator";
            @operator.DisplayFormat = "{expr1} [[new operator]] {expr2}";
            @operator.Expr = "{expr1} operator {expr2}";
            @operator.Group = DataModel.OtherOperatorGroup;
            this.model.Operators.Add(@operator);
            int num = this.listBoxOperators.Items.Add(@operator);
            this.listBoxOperators.SelectedIndex = num;
            this.ModelChanged = true;
        }

        private void AddSubEntityNodes(DataModel.Entity parentEntity, TreeNodeCollection parentNodes)
        {
            foreach (DataModel.Entity entity in parentEntity.SubEntities)
            {
                this.AddEntityNode(entity, parentNodes);
            }
        }

        private void AddTables()
        {
            DbItemsDlg.Params dlgParams = new DbItemsDlg.Params();
            dlgParams.Option1 = this.autoAddEntitiesForTable;
            if (this.ShowDbItemsListDlg(DbItemType.DbTables, "Add table(s)", dlgParams))
            {
                foreach (DbTableInfo info in dlgParams.ResultList)
                {
                    DataModel.Table table = new DataModel.Table();
                    table.DBName = info.DBName;
                    table.SchemaName = info.SchemaName;
                    table.Name = info.Name;
                    table.Alias = this.model.Tables.GetUniqueAlias(table.Name);
                    this.model.Tables.Add(table);
                    this.listBoxTables.Items.Add(table);
                    this.autoAddEntitiesForTable = dlgParams.Option1;
                    if (dlgParams.Option1)
                    {
                        this.AddEntityForTable(table);
                    }
                    this.ModelChanged = true;
                }
            }
        }

        protected virtual void AddVirtualAttr()
        {
            TreeNode selectedNode = this.treeViewEntities.SelectedNode;
            if (selectedNode.Tag is DataModel.EntityAttr)
            {
                selectedNode = selectedNode.Parent;
            }
            DataModel.Entity tag = (DataModel.Entity) selectedNode.Tag;
            DataModel.EntityAttr attr = new DataModel.EntityAttr();
            attr.Kind = DataModel.EntAttrKind.Virtual;
            attr.Caption = "New attribute";
            attr.Expr = "";
            attr.DataType = DataType.String;
            attr.Size = 20;
            attr.FillOperatorsWithDefaults(this.model);
            this.model.AssignEntityAttrID(attr);
            tag.Attributes.Add(attr);
            TreeNode node = new TreeNode(attr.Caption, 1, 1);
            node.Tag = attr;
            selectedNode.Nodes.Add(node);
            this.treeViewEntities.SelectedNode = node;
            this.ModelChanged = true;
            this.EnableEntityControls();
        }

        private bool AreSimilarTypes(DataType dt1, DataType dt2)
        {
            return ((dt1 == dt2) || (IntDataTypes.Contains(dt1) && IntDataTypes.Contains(dt2)));
        }

        protected virtual void AutoAddLinks()
        {
            DbLinkInfoList links = this.dbGate.GetLinks("", "");
            if (links.Count > 0)
            {
                foreach (DbLinkInfo info in links)
                {
                    this.AddLinkByLinkInfo(info);
                }
            }
        }

        protected virtual void AutoGenerateLinks()
        {
            int num = ((1 + this.model.Tables.Count) / 2) * this.model.Tables.Count;
            int num2 = 0;
            ProgressBarDlg dlg = new ProgressBarDlg();
            try
            {
                dlg.SetMinMax(0, 100);
                dlg.SetPosition(0);
                dlg.Show();
                for (int i = 0; i < (this.model.Tables.Count - 1); i++)
                {
                    DataModel.Table table = this.model.Tables[i];
                    DbFieldInfoList list = this.dbGate.GetFields(table.DBName, table.SchemaName, table.Name);
                    for (int j = i + 1; j < this.model.Tables.Count; j++)
                    {
                        num2++;
                        dlg.SetPosition((int) ((((double) num2) / ((double) num)) * 100.0));
                        DataModel.Table table2 = this.model.Tables[j];
                        if (this.model.Links.FindByTables(table, table2) == null)
                        {
                            bool flag = false;
                            DbFieldInfoList list2 = this.dbGate.GetFields(table2.DBName, table2.SchemaName, table2.Name);
                            foreach (DbFieldInfo info in list)
                            {
                                foreach (DbFieldInfo info2 in list2)
                                {
                                    if ((this.IsLinkType(info.FieldType) && this.AreSimilarTypes(info.FieldType, info2.FieldType)) && (string.Compare(info.Name, info2.Name, true) == 0))
                                    {
                                        DataModel.Link link = new DataModel.Link();
                                        link.Table1 = table;
                                        link.Table2 = table2;
                                        link.AddCondition(DataModel.LinkCondType.FieldField, info.Name, info2.Name, "=");
                                        this.model.Links.Add(link);
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                dlg.Hide();
                dlg.Dispose();
            }
        }

        private void btAddLink_Click(object sender, EventArgs e)
        {
            DataModel.Link link = new DataModel.Link();
            link.Table1 = this.currentTable;
            if (this.ShowEditLinkDialog(link, "Add link"))
            {
                this.listBoxTableLinks.Items.Add(link);
                this.model.Links.Add(link);
                this.ModelChanged = true;
            }
        }

        private void btDeleteLink_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentLink();
            this.EnableLinkButtons();
        }

        private void btEditLink_Click(object sender, EventArgs e)
        {
            this.EditCurrentLink();
        }

        private void buttonAttrAddTable_Click(object sender, EventArgs e)
        {
            DbItemsDlg.Params dlgParams = new DbItemsDlg.Params();
            if (this.ShowDbItemsListDlg(DbItemType.ModelTables, "Add table(s)", dlgParams))
            {
                foreach (DataModel.Table table in dlgParams.ResultList)
                {
                    this.listBoxAttrTables.Items.Add(table);
                }
                this.ModelChanged = true;
            }
        }

        private void buttonAttrDefValEditorSettings_Click(object sender, EventArgs e)
        {
            if (this.ShowValueEditorPropsDlg(this.currentAttrValueEditor))
            {
                this.ModelChanged = true;
            }
        }

        private void buttonAttrDeleteTable_Click(object sender, EventArgs e)
        {
            this.listBoxAttrTables.Items.RemoveAt(this.listBoxAttrTables.SelectedIndex);
        }

        private void buttonAttrOpAdd_Click(object sender, EventArgs e)
        {
            DbItemsDlg.Params dlgParams = new DbItemsDlg.Params();
            if (this.ShowDbItemsListDlg(DbItemType.ModelOperators, "Add operator(s)", dlgParams))
            {
                foreach (DataModel.Operator @operator in dlgParams.ResultList)
                {
                    this.listBoxAttrOperators.Items.Add(@operator);
                    this.ModelChanged = true;
                }
            }
        }

        private void buttonAttrOpAddDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Current operator list will be replaced by default.\n Do you want to proceed?", this.DMETitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                DataModel.EntityAttr currentEntityObj = (DataModel.EntityAttr) this.currentEntityObj;
                DataModel.OperatorList defaultOperatorsForDataType = this.model.GetDefaultOperatorsForDataType(currentEntityObj.DataType);
                this.listBoxAttrOperators.Items.Clear();
                foreach (DataModel.Operator @operator in defaultOperatorsForDataType)
                {
                    this.listBoxAttrOperators.Items.Add(@operator);
                }
                this.ModelChanged = true;
            }
        }

        private void buttonAttrOpClear_Click(object sender, EventArgs e)
        {
            this.listBoxAttrOperators.Items.Clear();
            this.ModelChanged = true;
        }

        private void buttonAttrOpDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentAttrOp();
        }

        private void buttonOpDefValEditorSettings_Click(object sender, EventArgs e)
        {
            if (this.ShowValueEditorPropsDlg(this.currentOpValueEditor))
            {
                this.ModelChanged = true;
            }
        }

        protected virtual bool ChangeValueEditorType(ValueEditor currentEditor, ValueEditor newEditor)
        {
            return (((currentEditor == null) || (((newEditor == null) || (newEditor.GetType() == currentEditor.GetType())) && (newEditor != null))) || (MessageBox.Show("All settings for current value editor will be lost. Continue?", this.DMETitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK));
        }

        private void comboBoxAttrValEditorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsRendering)
            {
                ValueEditor newEditor = this.CreateValueEditor(this.comboBoxAttrValEditorType.SelectedIndex);
                if (this.ChangeValueEditorType(this.currentAttrValueEditor, newEditor))
                {
                    this.currentAttrValueEditor = newEditor;
                    this.EnableValueEditorSettingsButton(this.buttonAttrDefValEditorSettings, this.currentAttrValueEditor);
                    this.ModelChanged = true;
                }
                else
                {
                    this.RenderValueEditorTypeCombo(this.comboBoxAttrValEditorType, this.currentAttrValueEditor);
                }
            }
        }

        private void comboBoxOpDefValueEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsRendering)
            {
                ValueEditor newEditor = this.CreateValueEditor(this.comboBoxOpDefValueEditor.SelectedIndex);
                if (this.ChangeValueEditorType(this.currentOpValueEditor, newEditor))
                {
                    this.currentOpValueEditor = newEditor;
                    this.EnableValueEditorSettingsButton(this.buttonOpDefValEditorSettings, this.currentOpValueEditor);
                    this.ModelChanged = true;
                }
                else
                {
                    this.RenderValueEditorTypeCombo(this.comboBoxOpDefValueEditor, this.currentOpValueEditor);
                }
            }
        }

        private void comboBoxOpGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RenderOperatorList();
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null)
            {
                return false;
            }
            return (node2.Parent.Equals(node1) || this.ContainsNode(node1, node2.Parent));
        }

        private void contextMenuEntities_Popup(object sender, EventArgs e)
        {
        }

        private ValueEditor CreateValueEditor(int editorTypeIndex)
        {
            switch (editorTypeIndex)
            {
                case 1:
                    return new TextValueEditor();

                case 2:
                    return new DateTimeValueEditor();

                case 3:
                    return new ConstListValueEditor();

                case 4:
                    return new CustomListValueEditor();

                case 5:
                    return new SqlListValueEditor();

                case 6:
                    return new CustomValueEditor();
            }
            return null;
        }

        private void DeleteCurrentAttrOp()
        {
            DataModel.EntityAttr currentEntityObj = (DataModel.EntityAttr) this.currentEntityObj;
            DataModel.Operator selectedItem = (DataModel.Operator) this.listBoxAttrOperators.SelectedItem;
            if ((selectedItem != null) && (MessageBox.Show(string.Format("Delete operator {0} from attribute's list?", currentEntityObj.Caption), this.DMETitle, MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                this.listBoxAttrOperators.Items.Remove(selectedItem);
                this.ModelChanged = true;
            }
        }

        private void DeleteCurrentLink()
        {
            DataModel.Link selectedItem = (DataModel.Link) this.listBoxTableLinks.SelectedItem;
            if ((selectedItem != null) && (MessageBox.Show("Delete link?", this.DMETitle, MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                this.model.Links.Remove(selectedItem);
                this.listBoxTableLinks.Items.Remove(selectedItem);
                this.ModelChanged = true;
            }
        }

        private void DeleteCurrentOperator()
        {
            if ((this.currentOperator != null) && (MessageBox.Show(string.Format("Delete operator \"{0}\"?", this.currentOperator.ID), this.DMETitle, MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                int index = this.listBoxOperators.Items.IndexOf(this.currentOperator);
                this.listBoxOperators.BeginUpdate();
                try
                {
                    this.model.Operators.Remove(this.currentOperator);
                    this.currentOperator = null;
                    this.listBoxOperators.Items.RemoveAt(index);
                    if (index >= this.listBoxOperators.Items.Count)
                    {
                        index--;
                    }
                    if (index >= 0)
                    {
                        this.listBoxOperators.SelectedIndex = index;
                    }
                    else
                    {
                        this.RenderSelectedOperator();
                    }
                }
                finally
                {
                    this.listBoxOperators.EndUpdate();
                }
                this.ModelChanged = true;
            }
        }

        private void DeleteCurrentTable()
        {
            if ((this.currentTable != null) && (MessageBox.Show(string.Format("Delete table \"{0}\"?\nPlease note: all entity attributes associated with this table will be removed as well", this.currentTable.Name), this.DMETitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
            {
                this.SaveCurrentEntityObj();
                this.model.Tables.Remove(this.currentTable);
                this.listBoxTables.Items.Remove(this.currentTable);
                this.RenderEntities();
                this.RenderSelectedTable();
                this.ModelChanged = true;
            }
        }

        protected virtual void DeleteSelectedEntityObj()
        {
            TreeNode selectedNode = this.treeViewEntities.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is DataModel.Entity)
                {
                    DataModel.Entity tag = (DataModel.Entity) selectedNode.Tag;
                    if (MessageBox.Show(string.Format("Delete entity \"{0}\"?", tag.Name), this.DMETitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        tag.Parent.SubEntities.Remove(tag);
                        this.treeViewEntities.SelectedNode.Remove();
                    }
                }
                else
                {
                    DataModel.EntityAttr attr = (DataModel.EntityAttr) selectedNode.Tag;
                    if (MessageBox.Show(string.Format("Delete entity attribute \"{0}\"?", attr.Caption), this.DMETitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        attr.Entity.Attributes.Remove(attr);
                        this.treeViewEntities.SelectedNode.Remove();
                    }
                }
                this.ModelChanged = true;
                this.EnableEntityControls();
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

        private void EditCurrentLink()
        {
            DataModel.Link selectedItem = (DataModel.Link) this.listBoxTableLinks.SelectedItem;
            if ((selectedItem != null) && this.ShowEditLinkDialog(selectedItem, "Edit link"))
            {
                this.ModelChanged = true;
            }
        }

        private void EnableEntityControls()
        {
            TreeNode selectedNode = this.treeViewEntities.SelectedNode;
            bool flag = (selectedNode != null) && (selectedNode.Tag is DataModel.Entity);
            this.groupBoxEntityAttrProps.Visible = selectedNode != null;
            this.menuItemAddSubEntity.Enabled = selectedNode != null;
            this.cmenuItemEntAddSub.Visible = flag;
            this.menuItemAddDataAttr.Enabled = selectedNode != null;
            this.cmenuItemEntAddDataAttr.Visible = flag;
            this.menuItemAddVirtualAttr.Enabled = selectedNode != null;
            this.cmenuItemEntAddVirtAttr.Visible = flag;
            this.menuItemEntitiesDelete.Enabled = selectedNode != null;
            this.cmenuItemEntDelete.Enabled = selectedNode != null;
        }

        private void EnableLinkButtons()
        {
            this.buttonLinkEdit.Enabled = this.listBoxTableLinks.SelectedItem != null;
            this.buttonLinkDelete.Enabled = this.listBoxTableLinks.SelectedItem != null;
        }

        private void EnableMenuItems()
        {
            this.menuItemTables.Visible = this.tabControlMain.Visible && (this.tabControlMain.SelectedIndex == 0);
            this.menuItemEntities.Visible = this.tabControlMain.Visible && (this.tabControlMain.SelectedIndex == 1);
            this.menuItemOperators.Visible = this.tabControlMain.Visible && (this.tabControlMain.SelectedIndex == 2);
        }

        private void EnableOperatorControls()
        {
        }

        private void EnableTableControls()
        {
            this.panelTableProps.Visible = this.currentTable != null;
            this.menuItemTableDelete.Enabled = this.currentTable != null;
            this.cmenuItemTableDelete.Enabled = this.currentTable != null;
        }

        private void EnableValueEditorSettingsButton(Button button, ValueEditor editor)
        {
            button.Enabled = editor != null;
        }

        protected void EndRendering()
        {
            this.rendering--;
        }

        private void FillAttrTablesList(DataModel.EntityAttr attr)
        {
            this.listBoxAttrTables.Items.Clear();
            foreach (DataModel.Table table in attr.Tables)
            {
                this.listBoxAttrTables.Items.Add(table);
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ModelEditorForm));
            this.mainMenu1 = new MainMenu();
            this.menuItemModel = new MenuItem();
            this.menuItemNewModel = new MenuItem();
            this.menuItemOpenModel = new MenuItem();
            this.menuItemSaveModel = new MenuItem();
            this.menuItemSaveModelAs = new MenuItem();
            this.menuItemSep11 = new MenuItem();
            this.menuItemEditModelSettings = new MenuItem();
            this.menuItem3 = new MenuItem();
            this.menuItemExit = new MenuItem();
            this.menuItemTables = new MenuItem();
            this.menuItemTableAdd = new MenuItem();
            this.menuItemTableDelete = new MenuItem();
            this.menuItem2 = new MenuItem();
            this.menuItemAutoAddLinks = new MenuItem();
            this.menuItemAutoGenerateLinks = new MenuItem();
            this.menuItemEntities = new MenuItem();
            this.menuItemAddEntity = new MenuItem();
            this.menuItemAddSubEntity = new MenuItem();
            this.menuItemAddDataAttr = new MenuItem();
            this.menuItemAddVirtualAttr = new MenuItem();
            this.menuItemEntitiesDelete = new MenuItem();
            this.menuItemOperators = new MenuItem();
            this.menuItemOperatorAdd = new MenuItem();
            this.menuItemOperatorDelete = new MenuItem();
            this.menuItem1 = new MenuItem();
            this.menuItemOperatorAddUpdateDefault = new MenuItem();
            this.menuItemHelp = new MenuItem();
            this.menuItemContents = new MenuItem();
            this.menuItemSep21 = new MenuItem();
            this.menuItemAbout = new MenuItem();
            this.tabControlMain = new TabControl();
            this.tabTables = new TabPage();
            this.panelTableProps = new Panel();
            this.groupBoxLinkedTables = new GroupBox();
            this.buttonLinkDelete = new Button();
            this.buttonLinkEdit = new Button();
            this.buttonLinkAdd = new Button();
            this.listBoxTableLinks = new ListBox();
            this.groupBoxTableProps = new GroupBox();
            this.checkBoxQuote = new CheckBox();
            this.comboBoxTableHints = new ComboBox();
            this.labelHints = new Label();
            this.labelAlias = new Label();
            this.textBoxTableAlias = new TextBox();
            this.listBoxTables = new ListBox();
            this.contextMenuTables = new ContextMenu();
            this.cmenuItemTableAdd = new MenuItem();
            this.cmenuItemTableDelete = new MenuItem();
            this.tabEntities = new TabPage();
            this.groupBoxEntityAttrProps = new GroupBox();
            this.tabControlAttrProps = new TabControl();
            this.tabPageAttrGeneral = new TabPage();
            this.groupBoxAttrTables = new GroupBox();
            this.buttonAttrDeleteTable = new Button();
            this.buttonAttrAddTable = new Button();
            this.listBoxAttrTables = new ListBox();
            this.textBoxAttrCustomData = new TextBox();
            this.labelAttrCustomData = new Label();
            this.textBoxAttrDescription = new TextBox();
            this.labelAttrDescription = new Label();
            this.groupBoxAttrOptions = new GroupBox();
            this.checkBoxAttrIsAggregate = new CheckBox();
            this.checkBoxAttrUseAlias = new CheckBox();
            this.checkBoxAttrQuote = new CheckBox();
            this.checkBoxAttrUseInSorting = new CheckBox();
            this.checkBoxAttrUseInResult = new CheckBox();
            this.checkBoxAttrUseInConditions = new CheckBox();
            this.numUpDownAttrSize = new NumericUpDown();
            this.labelAttrSize = new Label();
            this.comboBoxAttrDataType = new ComboBox();
            this.labelAttrExpr = new Label();
            this.textBoxAttrExpr = new TextBox();
            this.textBoxAttrCaption = new TextBox();
            this.labelAttrCaption = new Label();
            this.labelAttrDataType = new Label();
            this.tabPageAttrOperators = new TabPage();
            this.buttonAttrOpAddDefault = new Button();
            this.buttonAttrOpClear = new Button();
            this.buttonAttrOpDelete = new Button();
            this.buttonAttrOpAdd = new Button();
            this.listBoxAttrOperators = new ListBox();
            this.tabPageAttrValueEditors = new TabPage();
            this.panelAttrValEditorsTop = new Panel();
            this.buttonAttrDefValEditorSettings = new Button();
            this.labelDefValEditor = new Label();
            this.comboBoxAttrValEditorType = new ComboBox();
            this.panelEntityProps = new Panel();
            this.textBoxEntityUserData = new TextBox();
            this.labelEntityUserData = new Label();
            this.textBoxEntityName = new TextBox();
            this.labelEntityCaption = new Label();
            this.treeViewEntities = new TreeView();
            this.contextMenuEntities = new ContextMenu();
            this.cmenuItemEntAdd = new MenuItem();
            this.cmenuItemEntAddSub = new MenuItem();
            this.cmenuItemEntAddDataAttr = new MenuItem();
            this.cmenuItemEntAddVirtAttr = new MenuItem();
            this.cmenuItemEntDelete = new MenuItem();
            this.imageListEntities = new ImageList(this.components);
            this.tabOperators = new TabPage();
            this.comboBoxOpGroupFilter = new ComboBox();
            this.labelOpGroupFilter = new Label();
            this.panelOperatorProps = new Panel();
            this.buttonOpDefValEditorSettings = new Button();
            this.labelOpGroup = new Label();
            this.comboBoxOpGroup = new ComboBox();
            this.comboBoxOpDefValueEditor = new ComboBox();
            this.labelOpDefValueEditor = new Label();
            this.labelOpAppliedTypes = new Label();
            this.checkedListBoxOpAppliedTypes = new CheckedListBox();
            this.comboBoxOpValueKind = new ComboBox();
            this.labelOpValueKind = new Label();
            this.comboBoxOpExprType = new ComboBox();
            this.labelOpDataType = new Label();
            this.textBoxOpExpr = new TextBox();
            this.labelOpExpr = new Label();
            this.textBoxOpDisplayFormat = new TextBox();
            this.labelOpDispFormat = new Label();
            this.textBoxOpCaption = new TextBox();
            this.labelOpCaption = new Label();
            this.textBoxOpID = new TextBox();
            this.labelOpID = new Label();
            this.checkBoxOpCaseInsens = new CheckBox();
            this.listBoxOperators = new ListBox();
            this.openFileDlg = new OpenFileDialog();
            this.saveFileDlg = new SaveFileDialog();
            this.timer1 = new Timer(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.panelTableProps.SuspendLayout();
            this.groupBoxLinkedTables.SuspendLayout();
            this.groupBoxTableProps.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.groupBoxEntityAttrProps.SuspendLayout();
            this.tabControlAttrProps.SuspendLayout();
            this.tabPageAttrGeneral.SuspendLayout();
            this.groupBoxAttrTables.SuspendLayout();
            this.groupBoxAttrOptions.SuspendLayout();
            this.numUpDownAttrSize.BeginInit();
            this.tabPageAttrOperators.SuspendLayout();
            this.tabPageAttrValueEditors.SuspendLayout();
            this.panelAttrValEditorsTop.SuspendLayout();
            this.panelEntityProps.SuspendLayout();
            this.tabOperators.SuspendLayout();
            this.panelOperatorProps.SuspendLayout();
            base.SuspendLayout();
            this.mainMenu1.MenuItems.AddRange(new MenuItem[] { this.menuItemModel, this.menuItemTables, this.menuItemEntities, this.menuItemOperators, this.menuItemHelp });
            this.menuItemModel.Index = 0;
            this.menuItemModel.MenuItems.AddRange(new MenuItem[] { this.menuItemNewModel, this.menuItemOpenModel, this.menuItemSaveModel, this.menuItemSaveModelAs, this.menuItemSep11, this.menuItemEditModelSettings, this.menuItem3, this.menuItemExit });
            this.menuItemModel.Text = "Model";
            this.menuItemNewModel.Index = 0;
            this.menuItemNewModel.Text = "New...";
            this.menuItemNewModel.Click += new EventHandler(this.menuItemNewModel_Click);
            this.menuItemOpenModel.Index = 1;
            this.menuItemOpenModel.Text = "Open...";
            this.menuItemOpenModel.Click += new EventHandler(this.menuItemOpenModel_Click);
            this.menuItemSaveModel.Enabled = false;
            this.menuItemSaveModel.Index = 2;
            this.menuItemSaveModel.Text = "Save";
            this.menuItemSaveModel.Click += new EventHandler(this.menuItemSaveModel_Click);
            this.menuItemSaveModelAs.Index = 3;
            this.menuItemSaveModelAs.Text = "Save As...";
            this.menuItemSaveModelAs.Click += new EventHandler(this.menuItemSaveModelAs_Click);
            this.menuItemSep11.Index = 4;
            this.menuItemSep11.Text = "-";
            this.menuItemEditModelSettings.Enabled = false;
            this.menuItemEditModelSettings.Index = 5;
            this.menuItemEditModelSettings.Text = "Model settings...";
            this.menuItemEditModelSettings.Click += new EventHandler(this.menuItemEditModelSettings_Click);
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            this.menuItemExit.Index = 7;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new EventHandler(this.menuItemExit_Click);
            this.menuItemTables.Index = 1;
            this.menuItemTables.MenuItems.AddRange(new MenuItem[] { this.menuItemTableAdd, this.menuItemTableDelete, this.menuItem2, this.menuItemAutoAddLinks, this.menuItemAutoGenerateLinks });
            this.menuItemTables.Text = "Tables";
            this.menuItemTables.Visible = false;
            this.menuItemTableAdd.Index = 0;
            this.menuItemTableAdd.Text = "Add table(s)...";
            this.menuItemTableAdd.Click += new EventHandler(this.menuItemTableAdd_Click);
            this.menuItemTableDelete.Enabled = false;
            this.menuItemTableDelete.Index = 1;
            this.menuItemTableDelete.Text = "Delete selected";
            this.menuItemTableDelete.Click += new EventHandler(this.menuItemTableDelete_Click);
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            this.menuItemAutoAddLinks.Index = 3;
            this.menuItemAutoAddLinks.Text = "Add links automatically (by database schema)...";
            this.menuItemAutoAddLinks.Click += new EventHandler(this.menuItemAutoAddLinks_Click);
            this.menuItemAutoGenerateLinks.Index = 4;
            this.menuItemAutoGenerateLinks.Text = "Generate links by field-to-field comparision...";
            this.menuItemAutoGenerateLinks.Click += new EventHandler(this.menuItemAutoGenerateLinks_Click);
            this.menuItemEntities.Index = 2;
            this.menuItemEntities.MenuItems.AddRange(new MenuItem[] { this.menuItemAddEntity, this.menuItemAddSubEntity, this.menuItemAddDataAttr, this.menuItemAddVirtualAttr, this.menuItemEntitiesDelete });
            this.menuItemEntities.Text = "Entities";
            this.menuItemEntities.Visible = false;
            this.menuItemAddEntity.Index = 0;
            this.menuItemAddEntity.Text = "Add root level entity";
            this.menuItemAddEntity.Click += new EventHandler(this.menuItemAddEntity_Click);
            this.menuItemAddSubEntity.Enabled = false;
            this.menuItemAddSubEntity.Index = 1;
            this.menuItemAddSubEntity.Text = "Add sub-entity";
            this.menuItemAddSubEntity.Click += new EventHandler(this.menuItemAddSubEntity_Click);
            this.menuItemAddDataAttr.Enabled = false;
            this.menuItemAddDataAttr.Index = 2;
            this.menuItemAddDataAttr.Text = "Add data attribute...";
            this.menuItemAddDataAttr.Click += new EventHandler(this.menuItemAddDataAttr_Click);
            this.menuItemAddVirtualAttr.Enabled = false;
            this.menuItemAddVirtualAttr.Index = 3;
            this.menuItemAddVirtualAttr.Text = "Add virtual attribute...";
            this.menuItemAddVirtualAttr.Click += new EventHandler(this.menuItemAddVirtualAttr_Click);
            this.menuItemEntitiesDelete.Enabled = false;
            this.menuItemEntitiesDelete.Index = 4;
            this.menuItemEntitiesDelete.Text = "Delete selected";
            this.menuItemEntitiesDelete.Click += new EventHandler(this.menuItemEntitiesDelete_Click);
            this.menuItemOperators.Index = 3;
            this.menuItemOperators.MenuItems.AddRange(new MenuItem[] { this.menuItemOperatorAdd, this.menuItemOperatorDelete, this.menuItem1, this.menuItemOperatorAddUpdateDefault });
            this.menuItemOperators.Text = "Operators";
            this.menuItemOperators.Visible = false;
            this.menuItemOperatorAdd.Index = 0;
            this.menuItemOperatorAdd.Text = "Add operator";
            this.menuItemOperatorAdd.Click += new EventHandler(this.menuItemOperatorAdd_Click);
            this.menuItemOperatorDelete.Enabled = false;
            this.menuItemOperatorDelete.Index = 1;
            this.menuItemOperatorDelete.Text = "Delete selected";
            this.menuItemOperatorDelete.Click += new EventHandler(this.menuItemOperatorDelete_Click);
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            this.menuItemOperatorAddUpdateDefault.Index = 3;
            this.menuItemOperatorAddUpdateDefault.Text = "Add/Update default operators";
            this.menuItemOperatorAddUpdateDefault.Click += new EventHandler(this.menuItemOperatorAddUpdateDefault_Click);
            this.menuItemHelp.Index = 4;
            this.menuItemHelp.MenuItems.AddRange(new MenuItem[] { this.menuItemContents, this.menuItemSep21, this.menuItemAbout });
            this.menuItemHelp.Text = "Help";
            this.menuItemContents.Index = 0;
            this.menuItemContents.Text = "Contents";
            this.menuItemContents.Click += new EventHandler(this.menuItemContents_Click);
            this.menuItemSep21.Index = 1;
            this.menuItemSep21.Text = "-";
            this.menuItemAbout.Index = 2;
            this.menuItemAbout.Text = "About...";
            this.menuItemAbout.Click += new EventHandler(this.menuItemAbout_Click);
            this.tabControlMain.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.tabControlMain.Controls.Add(this.tabTables);
            this.tabControlMain.Controls.Add(this.tabEntities);
            this.tabControlMain.Controls.Add(this.tabOperators);
            this.tabControlMain.Location = new Point(4, 4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new Size(0x2f2, 480);
            this.tabControlMain.TabIndex = 2;
            this.tabControlMain.Visible = false;
            this.tabControlMain.SelectedIndexChanged += new EventHandler(this.tcMain_SelectedIndexChanged);
            this.tabTables.Controls.Add(this.panelTableProps);
            this.tabTables.Controls.Add(this.listBoxTables);
            this.tabTables.Location = new Point(4, 0x16);
            this.tabTables.Name = "tabTables";
            this.tabTables.Size = new Size(0x2ea, 0x1c6);
            this.tabTables.TabIndex = 0;
            this.tabTables.Text = "Tables and Links";
            this.panelTableProps.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panelTableProps.Controls.Add(this.groupBoxLinkedTables);
            this.panelTableProps.Controls.Add(this.groupBoxTableProps);
            this.panelTableProps.Location = new Point(240, 0);
            this.panelTableProps.Name = "panelTableProps";
            this.panelTableProps.Size = new Size(0x1f8, 0x1c4);
            this.panelTableProps.TabIndex = 1;
            this.panelTableProps.Visible = false;
            this.groupBoxLinkedTables.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBoxLinkedTables.Controls.Add(this.buttonLinkDelete);
            this.groupBoxLinkedTables.Controls.Add(this.buttonLinkEdit);
            this.groupBoxLinkedTables.Controls.Add(this.buttonLinkAdd);
            this.groupBoxLinkedTables.Controls.Add(this.listBoxTableLinks);
            this.groupBoxLinkedTables.Location = new Point(4, 0xa2);
            this.groupBoxLinkedTables.Name = "groupBoxLinkedTables";
            this.groupBoxLinkedTables.Size = new Size(500, 0x121);
            this.groupBoxLinkedTables.TabIndex = 3;
            this.groupBoxLinkedTables.TabStop = false;
            this.groupBoxLinkedTables.Text = "Links";
            this.buttonLinkDelete.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonLinkDelete.Enabled = false;
            this.buttonLinkDelete.Location = new Point(0x198, 0x6a);
            this.buttonLinkDelete.Name = "buttonLinkDelete";
            this.buttonLinkDelete.Size = new Size(0x4b, 0x17);
            this.buttonLinkDelete.TabIndex = 3;
            this.buttonLinkDelete.Text = "Delete";
            this.buttonLinkDelete.Click += new EventHandler(this.btDeleteLink_Click);
            this.buttonLinkEdit.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonLinkEdit.Enabled = false;
            this.buttonLinkEdit.Location = new Point(0x198, 0x40);
            this.buttonLinkEdit.Name = "buttonLinkEdit";
            this.buttonLinkEdit.Size = new Size(0x4b, 0x17);
            this.buttonLinkEdit.TabIndex = 2;
            this.buttonLinkEdit.Text = "Edit";
            this.buttonLinkEdit.Click += new EventHandler(this.btEditLink_Click);
            this.buttonLinkAdd.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonLinkAdd.Location = new Point(0x198, 0x18);
            this.buttonLinkAdd.Name = "buttonLinkAdd";
            this.buttonLinkAdd.Size = new Size(0x4b, 0x17);
            this.buttonLinkAdd.TabIndex = 1;
            this.buttonLinkAdd.Text = "Add";
            this.buttonLinkAdd.Click += new EventHandler(this.btAddLink_Click);
            this.listBoxTableLinks.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listBoxTableLinks.Location = new Point(6, 0x13);
            this.listBoxTableLinks.Name = "listBoxTableLinks";
            this.listBoxTableLinks.Size = new Size(0x180, 0x108);
            this.listBoxTableLinks.TabIndex = 0;
            this.listBoxTableLinks.SelectedIndexChanged += new EventHandler(this.listBoxTableLinks_SelectedIndexChanged);
            this.listBoxTableLinks.DoubleClick += new EventHandler(this.listBoxTableLinks_DoubleClick);
            this.groupBoxTableProps.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBoxTableProps.Controls.Add(this.checkBoxQuote);
            this.groupBoxTableProps.Controls.Add(this.comboBoxTableHints);
            this.groupBoxTableProps.Controls.Add(this.labelHints);
            this.groupBoxTableProps.Controls.Add(this.labelAlias);
            this.groupBoxTableProps.Controls.Add(this.textBoxTableAlias);
            this.groupBoxTableProps.Location = new Point(4, 8);
            this.groupBoxTableProps.Name = "groupBoxTableProps";
            this.groupBoxTableProps.Size = new Size(500, 0x90);
            this.groupBoxTableProps.TabIndex = 4;
            this.groupBoxTableProps.TabStop = false;
            this.groupBoxTableProps.Text = "Table properties";
            this.checkBoxQuote.Location = new Point(0x41, 0x70);
            this.checkBoxQuote.Name = "checkBoxQuote";
            this.checkBoxQuote.Size = new Size(0xc7, 0x11);
            this.checkBoxQuote.TabIndex = 5;
            this.checkBoxQuote.Text = "Quote table name";
            this.checkBoxQuote.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.comboBoxTableHints.Items.AddRange(new object[] { "FASTFIRSTROW ", "HOLDLOCK ", "NOLOCK ", "PAGLOCK ", "READCOMMITTED ", "READPAST ", "READUNCOMMITTED ", "REPEATABLEREAD ", "ROWLOCK ", "SERIALIZABLE ", "TABLOCK ", "TABLOCKX ", "UPDLOCK ", "XLOCK " });
            this.comboBoxTableHints.Location = new Point(0x41, 0x4a);
            this.comboBoxTableHints.Name = "comboBoxTableHints";
            this.comboBoxTableHints.Size = new Size(0xc9, 0x15);
            this.comboBoxTableHints.TabIndex = 4;
            this.comboBoxTableHints.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelHints.AutoSize = true;
            this.labelHints.Location = new Point(8, 80);
            this.labelHints.Name = "labelHints";
            this.labelHints.Size = new Size(0x22, 13);
            this.labelHints.TabIndex = 3;
            this.labelHints.Text = "Hints:";
            this.labelAlias.AutoSize = true;
            this.labelAlias.Location = new Point(8, 0x22);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new Size(0x20, 13);
            this.labelAlias.TabIndex = 1;
            this.labelAlias.Text = "Alias:";
            this.textBoxTableAlias.Location = new Point(0x40, 0x20);
            this.textBoxTableAlias.Name = "textBoxTableAlias";
            this.textBoxTableAlias.Size = new Size(0xc9, 20);
            this.textBoxTableAlias.TabIndex = 0;
            this.textBoxTableAlias.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.listBoxTables.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listBoxTables.ContextMenu = this.contextMenuTables;
            this.listBoxTables.Location = new Point(6, 6);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new Size(0xea, 0x1be);
            this.listBoxTables.Sorted = true;
            this.listBoxTables.TabIndex = 0;
            this.listBoxTables.SelectedIndexChanged += new EventHandler(this.listBoxTables_SelectedIndexChanged);
            this.listBoxTables.KeyDown += new KeyEventHandler(this.listBoxTables_KeyDown);
            this.contextMenuTables.MenuItems.AddRange(new MenuItem[] { this.cmenuItemTableAdd, this.cmenuItemTableDelete });
            this.cmenuItemTableAdd.Index = 0;
            this.cmenuItemTableAdd.Text = "Add table(s)...";
            this.cmenuItemTableAdd.Click += new EventHandler(this.menuItemTableAdd_Click);
            this.cmenuItemTableDelete.Enabled = false;
            this.cmenuItemTableDelete.Index = 1;
            this.cmenuItemTableDelete.Text = "Delete selected";
            this.cmenuItemTableDelete.Click += new EventHandler(this.menuItemTableDelete_Click);
            this.tabEntities.Controls.Add(this.groupBoxEntityAttrProps);
            this.tabEntities.Controls.Add(this.treeViewEntities);
            this.tabEntities.Location = new Point(4, 0x16);
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.Size = new Size(0x2ea, 0x1c6);
            this.tabEntities.TabIndex = 1;
            this.tabEntities.Text = "Entities";
            this.groupBoxEntityAttrProps.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBoxEntityAttrProps.Controls.Add(this.tabControlAttrProps);
            this.groupBoxEntityAttrProps.Controls.Add(this.panelEntityProps);
            this.groupBoxEntityAttrProps.Location = new Point(0x10c, 0);
            this.groupBoxEntityAttrProps.Name = "groupBoxEntityAttrProps";
            this.groupBoxEntityAttrProps.Size = new Size(480, 0x1c8);
            this.groupBoxEntityAttrProps.TabIndex = 1;
            this.groupBoxEntityAttrProps.TabStop = false;
            this.groupBoxEntityAttrProps.Text = "Entity/Attribute properties";
            this.groupBoxEntityAttrProps.Visible = false;
            this.tabControlAttrProps.Controls.Add(this.tabPageAttrGeneral);
            this.tabControlAttrProps.Controls.Add(this.tabPageAttrOperators);
            this.tabControlAttrProps.Controls.Add(this.tabPageAttrValueEditors);
            this.tabControlAttrProps.Location = new Point(8, 0x10);
            this.tabControlAttrProps.Name = "tabControlAttrProps";
            this.tabControlAttrProps.SelectedIndex = 0;
            this.tabControlAttrProps.Size = new Size(0x1f0, 0x1b0);
            this.tabControlAttrProps.TabIndex = 1;
            this.tabControlAttrProps.Visible = false;
            this.tabPageAttrGeneral.Controls.Add(this.groupBoxAttrTables);
            this.tabPageAttrGeneral.Controls.Add(this.textBoxAttrCustomData);
            this.tabPageAttrGeneral.Controls.Add(this.labelAttrCustomData);
            this.tabPageAttrGeneral.Controls.Add(this.textBoxAttrDescription);
            this.tabPageAttrGeneral.Controls.Add(this.labelAttrDescription);
            this.tabPageAttrGeneral.Controls.Add(this.groupBoxAttrOptions);
            this.tabPageAttrGeneral.Controls.Add(this.numUpDownAttrSize);
            this.tabPageAttrGeneral.Controls.Add(this.labelAttrSize);
            this.tabPageAttrGeneral.Controls.Add(this.comboBoxAttrDataType);
            this.tabPageAttrGeneral.Controls.Add(this.labelAttrExpr);
            this.tabPageAttrGeneral.Controls.Add(this.textBoxAttrExpr);
            this.tabPageAttrGeneral.Controls.Add(this.textBoxAttrCaption);
            this.tabPageAttrGeneral.Controls.Add(this.labelAttrCaption);
            this.tabPageAttrGeneral.Controls.Add(this.labelAttrDataType);
            this.tabPageAttrGeneral.Location = new Point(4, 0x16);
            this.tabPageAttrGeneral.Name = "tabPageAttrGeneral";
            this.tabPageAttrGeneral.Size = new Size(0x1e8, 0x196);
            this.tabPageAttrGeneral.TabIndex = 0;
            this.tabPageAttrGeneral.Text = "General";
            this.groupBoxAttrTables.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBoxAttrTables.Controls.Add(this.buttonAttrDeleteTable);
            this.groupBoxAttrTables.Controls.Add(this.buttonAttrAddTable);
            this.groupBoxAttrTables.Controls.Add(this.listBoxAttrTables);
            this.groupBoxAttrTables.Location = new Point(8, 0x70);
            this.groupBoxAttrTables.Name = "groupBoxAttrTables";
            this.groupBoxAttrTables.Size = new Size(0x100, 0x60);
            this.groupBoxAttrTables.TabIndex = 4;
            this.groupBoxAttrTables.TabStop = false;
            this.groupBoxAttrTables.Text = "Used tables";
            this.buttonAttrDeleteTable.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonAttrDeleteTable.Enabled = false;
            this.buttonAttrDeleteTable.Location = new Point(0xb8, 0x30);
            this.buttonAttrDeleteTable.Name = "buttonAttrDeleteTable";
            this.buttonAttrDeleteTable.Size = new Size(0x40, 0x17);
            this.buttonAttrDeleteTable.TabIndex = 3;
            this.buttonAttrDeleteTable.Text = "Delete";
            this.buttonAttrDeleteTable.Click += new EventHandler(this.buttonAttrDeleteTable_Click);
            this.buttonAttrAddTable.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonAttrAddTable.Location = new Point(0xb8, 0x10);
            this.buttonAttrAddTable.Name = "buttonAttrAddTable";
            this.buttonAttrAddTable.Size = new Size(0x40, 0x17);
            this.buttonAttrAddTable.TabIndex = 1;
            this.buttonAttrAddTable.Text = "Add";
            this.buttonAttrAddTable.Click += new EventHandler(this.buttonAttrAddTable_Click);
            this.listBoxAttrTables.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listBoxAttrTables.Location = new Point(8, 0x10);
            this.listBoxAttrTables.Name = "listBoxAttrTables";
            this.listBoxAttrTables.Size = new Size(0xa8, 0x45);
            this.listBoxAttrTables.TabIndex = 0;
            this.listBoxAttrTables.SelectedIndexChanged += new EventHandler(this.listBoxAttrTables_SelectedIndexChanged);
            this.textBoxAttrCustomData.Location = new Point(8, 0x163);
            this.textBoxAttrCustomData.Multiline = true;
            this.textBoxAttrCustomData.Name = "textBoxAttrCustomData";
            this.textBoxAttrCustomData.Size = new Size(0x1c0, 0x2d);
            this.textBoxAttrCustomData.TabIndex = 13;
            this.textBoxAttrCustomData.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelAttrCustomData.AutoSize = true;
            this.labelAttrCustomData.Location = new Point(8, 0x153);
            this.labelAttrCustomData.Name = "labelAttrCustomData";
            this.labelAttrCustomData.Size = new Size(0x42, 13);
            this.labelAttrCustomData.TabIndex = 12;
            this.labelAttrCustomData.Text = "Custom data";
            this.textBoxAttrDescription.Location = new Point(8, 0x11b);
            this.textBoxAttrDescription.Multiline = true;
            this.textBoxAttrDescription.Name = "textBoxAttrDescription";
            this.textBoxAttrDescription.Size = new Size(0x1c0, 0x30);
            this.textBoxAttrDescription.TabIndex = 11;
            this.textBoxAttrDescription.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelAttrDescription.AutoSize = true;
            this.labelAttrDescription.Location = new Point(8, 0x10a);
            this.labelAttrDescription.Name = "labelAttrDescription";
            this.labelAttrDescription.Size = new Size(60, 13);
            this.labelAttrDescription.TabIndex = 10;
            this.labelAttrDescription.Text = "Description";
            this.groupBoxAttrOptions.Controls.Add(this.checkBoxAttrIsAggregate);
            this.groupBoxAttrOptions.Controls.Add(this.checkBoxAttrUseAlias);
            this.groupBoxAttrOptions.Controls.Add(this.checkBoxAttrQuote);
            this.groupBoxAttrOptions.Controls.Add(this.checkBoxAttrUseInSorting);
            this.groupBoxAttrOptions.Controls.Add(this.checkBoxAttrUseInResult);
            this.groupBoxAttrOptions.Controls.Add(this.checkBoxAttrUseInConditions);
            this.groupBoxAttrOptions.Location = new Point(0x110, 0x70);
            this.groupBoxAttrOptions.Name = "groupBoxAttrOptions";
            this.groupBoxAttrOptions.Size = new Size(0xb8, 0xa4);
            this.groupBoxAttrOptions.TabIndex = 9;
            this.groupBoxAttrOptions.TabStop = false;
            this.groupBoxAttrOptions.Text = "Other options";
            this.checkBoxAttrIsAggregate.Location = new Point(8, 0x88);
            this.checkBoxAttrIsAggregate.Name = "checkBoxAttrIsAggregate";
            this.checkBoxAttrIsAggregate.Size = new Size(0xa8, 0x18);
            this.checkBoxAttrIsAggregate.TabIndex = 5;
            this.checkBoxAttrIsAggregate.Text = "Aggregate";
            this.checkBoxAttrIsAggregate.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.checkBoxAttrUseAlias.Location = new Point(8, 0x70);
            this.checkBoxAttrUseAlias.Name = "checkBoxAttrUseAlias";
            this.checkBoxAttrUseAlias.Size = new Size(0xa8, 0x18);
            this.checkBoxAttrUseAlias.TabIndex = 4;
            this.checkBoxAttrUseAlias.Text = "Use alias";
            this.checkBoxAttrUseAlias.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.checkBoxAttrQuote.Location = new Point(8, 0x58);
            this.checkBoxAttrQuote.Name = "checkBoxAttrQuote";
            this.checkBoxAttrQuote.Size = new Size(0xa8, 0x18);
            this.checkBoxAttrQuote.TabIndex = 3;
            this.checkBoxAttrQuote.Text = "Quote field name in SQL";
            this.checkBoxAttrQuote.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.checkBoxAttrUseInSorting.Location = new Point(8, 0x40);
            this.checkBoxAttrUseInSorting.Name = "checkBoxAttrUseInSorting";
            this.checkBoxAttrUseInSorting.Size = new Size(0xa8, 0x18);
            this.checkBoxAttrUseInSorting.TabIndex = 2;
            this.checkBoxAttrUseInSorting.Text = "Use in sorting";
            this.checkBoxAttrUseInSorting.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.checkBoxAttrUseInResult.Location = new Point(8, 40);
            this.checkBoxAttrUseInResult.Name = "checkBoxAttrUseInResult";
            this.checkBoxAttrUseInResult.Size = new Size(0xa8, 0x18);
            this.checkBoxAttrUseInResult.TabIndex = 1;
            this.checkBoxAttrUseInResult.Text = "Use in result";
            this.checkBoxAttrUseInResult.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.checkBoxAttrUseInConditions.Location = new Point(8, 0x10);
            this.checkBoxAttrUseInConditions.Name = "checkBoxAttrUseInConditions";
            this.checkBoxAttrUseInConditions.Size = new Size(0xa8, 0x18);
            this.checkBoxAttrUseInConditions.TabIndex = 0;
            this.checkBoxAttrUseInConditions.Text = "Use in conditions";
            this.checkBoxAttrUseInConditions.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.numUpDownAttrSize.Location = new Point(0x98, 0xe8);
            int[] bits = new int[4];
            bits[0] = 0x186a0;
            this.numUpDownAttrSize.Maximum = new decimal(bits);
            this.numUpDownAttrSize.Name = "numUpDownAttrSize";
            this.numUpDownAttrSize.Size = new Size(0x40, 20);
            this.numUpDownAttrSize.TabIndex = 8;
            this.numUpDownAttrSize.ValueChanged += new EventHandler(this.SomeChangesOccured);
            this.labelAttrSize.AutoSize = true;
            this.labelAttrSize.Location = new Point(0x98, 0xd8);
            this.labelAttrSize.Name = "labelAttrSize";
            this.labelAttrSize.Size = new Size(0x1b, 13);
            this.labelAttrSize.TabIndex = 7;
            this.labelAttrSize.Text = "Size";
            this.comboBoxAttrDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxAttrDataType.Location = new Point(8, 0xe8);
            this.comboBoxAttrDataType.Name = "comboBoxAttrDataType";
            this.comboBoxAttrDataType.Size = new Size(0x80, 0x15);
            this.comboBoxAttrDataType.TabIndex = 6;
            this.comboBoxAttrDataType.SelectedIndexChanged += new EventHandler(this.SomeChangesOccured);
            this.labelAttrExpr.AutoSize = true;
            this.labelAttrExpr.Location = new Point(8, 0x37);
            this.labelAttrExpr.Name = "labelAttrExpr";
            this.labelAttrExpr.Size = new Size(0x3a, 13);
            this.labelAttrExpr.TabIndex = 2;
            this.labelAttrExpr.Text = "Expression";
            this.textBoxAttrExpr.Location = new Point(8, 0x48);
            this.textBoxAttrExpr.Multiline = true;
            this.textBoxAttrExpr.Name = "textBoxAttrExpr";
            this.textBoxAttrExpr.Size = new Size(0x1c0, 0x20);
            this.textBoxAttrExpr.TabIndex = 3;
            this.textBoxAttrExpr.Text = "11\r\n22\r\n33";
            this.textBoxAttrExpr.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.textBoxAttrExpr.Validated += new EventHandler(this.textBoxAttrExpr_Validated);
            this.textBoxAttrCaption.Location = new Point(8, 0x18);
            this.textBoxAttrCaption.Name = "textBoxAttrCaption";
            this.textBoxAttrCaption.Size = new Size(0x1c0, 20);
            this.textBoxAttrCaption.TabIndex = 1;
            this.textBoxAttrCaption.TextChanged += new EventHandler(this.textBoxAttrCaption_TextChanged);
            this.labelAttrCaption.AutoSize = true;
            this.labelAttrCaption.Location = new Point(8, 8);
            this.labelAttrCaption.Name = "labelAttrCaption";
            this.labelAttrCaption.Size = new Size(0x2b, 13);
            this.labelAttrCaption.TabIndex = 0;
            this.labelAttrCaption.Text = "Caption";
            this.labelAttrDataType.AutoSize = true;
            this.labelAttrDataType.Location = new Point(8, 0xd8);
            this.labelAttrDataType.Name = "labelAttrDataType";
            this.labelAttrDataType.Size = new Size(0x35, 13);
            this.labelAttrDataType.TabIndex = 5;
            this.labelAttrDataType.Text = "Data type";
            this.tabPageAttrOperators.Controls.Add(this.buttonAttrOpAddDefault);
            this.tabPageAttrOperators.Controls.Add(this.buttonAttrOpClear);
            this.tabPageAttrOperators.Controls.Add(this.buttonAttrOpDelete);
            this.tabPageAttrOperators.Controls.Add(this.buttonAttrOpAdd);
            this.tabPageAttrOperators.Controls.Add(this.listBoxAttrOperators);
            this.tabPageAttrOperators.Location = new Point(4, 0x16);
            this.tabPageAttrOperators.Name = "tabPageAttrOperators";
            this.tabPageAttrOperators.Size = new Size(0x1e8, 0x196);
            this.tabPageAttrOperators.TabIndex = 1;
            this.tabPageAttrOperators.Text = "Operators";
            this.buttonAttrOpAddDefault.Location = new Point(0x180, 120);
            this.buttonAttrOpAddDefault.Name = "buttonAttrOpAddDefault";
            this.buttonAttrOpAddDefault.Size = new Size(0x4b, 0x17);
            this.buttonAttrOpAddDefault.TabIndex = 4;
            this.buttonAttrOpAddDefault.Text = "Defaults";
            this.buttonAttrOpAddDefault.Click += new EventHandler(this.buttonAttrOpAddDefault_Click);
            this.buttonAttrOpClear.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonAttrOpClear.Location = new Point(0x180, 0x98);
            this.buttonAttrOpClear.Name = "buttonAttrOpClear";
            this.buttonAttrOpClear.Size = new Size(0x4b, 0x17);
            this.buttonAttrOpClear.TabIndex = 3;
            this.buttonAttrOpClear.Text = "Clear";
            this.buttonAttrOpClear.Click += new EventHandler(this.buttonAttrOpClear_Click);
            this.buttonAttrOpDelete.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonAttrOpDelete.Location = new Point(0x180, 0x38);
            this.buttonAttrOpDelete.Name = "buttonAttrOpDelete";
            this.buttonAttrOpDelete.Size = new Size(0x4b, 0x17);
            this.buttonAttrOpDelete.TabIndex = 2;
            this.buttonAttrOpDelete.Text = "Delete";
            this.buttonAttrOpDelete.Click += new EventHandler(this.buttonAttrOpDelete_Click);
            this.buttonAttrOpAdd.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonAttrOpAdd.Location = new Point(0x180, 0x10);
            this.buttonAttrOpAdd.Name = "buttonAttrOpAdd";
            this.buttonAttrOpAdd.Size = new Size(0x4b, 0x17);
            this.buttonAttrOpAdd.TabIndex = 1;
            this.buttonAttrOpAdd.Text = "Add";
            this.buttonAttrOpAdd.Click += new EventHandler(this.buttonAttrOpAdd_Click);
            this.listBoxAttrOperators.AllowDrop = true;
            this.listBoxAttrOperators.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listBoxAttrOperators.Location = new Point(8, 8);
            this.listBoxAttrOperators.Name = "listBoxAttrOperators";
            this.listBoxAttrOperators.Size = new Size(0x170, 0x18a);
            this.listBoxAttrOperators.TabIndex = 0;
            this.tabPageAttrValueEditors.Controls.Add(this.panelAttrValEditorsTop);
            this.tabPageAttrValueEditors.Location = new Point(4, 0x16);
            this.tabPageAttrValueEditors.Name = "tabPageAttrValueEditors";
            this.tabPageAttrValueEditors.Size = new Size(0x1e8, 0x196);
            this.tabPageAttrValueEditors.TabIndex = 2;
            this.tabPageAttrValueEditors.Text = "Value Editors";
            this.panelAttrValEditorsTop.BorderStyle = BorderStyle.Fixed3D;
            this.panelAttrValEditorsTop.Controls.Add(this.buttonAttrDefValEditorSettings);
            this.panelAttrValEditorsTop.Controls.Add(this.labelDefValEditor);
            this.panelAttrValEditorsTop.Controls.Add(this.comboBoxAttrValEditorType);
            this.panelAttrValEditorsTop.Location = new Point(0, 0);
            this.panelAttrValEditorsTop.Name = "panelAttrValEditorsTop";
            this.panelAttrValEditorsTop.Size = new Size(0x1d0, 40);
            this.panelAttrValEditorsTop.TabIndex = 0;
            this.buttonAttrDefValEditorSettings.Location = new Point(0x150, 8);
            this.buttonAttrDefValEditorSettings.Name = "buttonAttrDefValEditorSettings";
            this.buttonAttrDefValEditorSettings.Size = new Size(0x4b, 0x17);
            this.buttonAttrDefValEditorSettings.TabIndex = 2;
            this.buttonAttrDefValEditorSettings.Text = "Settings...";
            this.buttonAttrDefValEditorSettings.Click += new EventHandler(this.buttonAttrDefValEditorSettings_Click);
            this.labelDefValEditor.AutoSize = true;
            this.labelDefValEditor.Location = new Point(8, 11);
            this.labelDefValEditor.Name = "labelDefValEditor";
            this.labelDefValEditor.Size = new Size(0x66, 13);
            this.labelDefValEditor.TabIndex = 1;
            this.labelDefValEditor.Text = "Default value editor:";
            this.comboBoxAttrValEditorType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxAttrValEditorType.Items.AddRange(new object[] { "Auto", "Text editor", "Date/time editor", "List of constants", "Custom list", "SQL list", "Custom (user defined)" });
            this.comboBoxAttrValEditorType.Location = new Point(0x80, 8);
            this.comboBoxAttrValEditorType.Name = "comboBoxAttrValEditorType";
            this.comboBoxAttrValEditorType.Size = new Size(0xb0, 0x15);
            this.comboBoxAttrValEditorType.TabIndex = 0;
            this.comboBoxAttrValEditorType.SelectedIndexChanged += new EventHandler(this.comboBoxAttrValEditorType_SelectedIndexChanged);
            this.panelEntityProps.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panelEntityProps.Controls.Add(this.textBoxEntityUserData);
            this.panelEntityProps.Controls.Add(this.labelEntityUserData);
            this.panelEntityProps.Controls.Add(this.textBoxEntityName);
            this.panelEntityProps.Controls.Add(this.labelEntityCaption);
            this.panelEntityProps.Location = new Point(8, 0x10);
            this.panelEntityProps.Name = "panelEntityProps";
            this.panelEntityProps.Size = new Size(0x1d0, 0xd8);
            this.panelEntityProps.TabIndex = 0;
            this.panelEntityProps.Visible = false;
            this.textBoxEntityUserData.Location = new Point(0, 0x48);
            this.textBoxEntityUserData.Multiline = true;
            this.textBoxEntityUserData.Name = "textBoxEntityUserData";
            this.textBoxEntityUserData.Size = new Size(360, 120);
            this.textBoxEntityUserData.TabIndex = 3;
            this.textBoxEntityUserData.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelEntityUserData.AutoSize = true;
            this.labelEntityUserData.Location = new Point(0, 0x38);
            this.labelEntityUserData.Name = "labelEntityUserData";
            this.labelEntityUserData.Size = new Size(0x37, 13);
            this.labelEntityUserData.TabIndex = 2;
            this.labelEntityUserData.Text = "User Data";
            this.textBoxEntityName.Location = new Point(0, 0x18);
            this.textBoxEntityName.Name = "textBoxEntityName";
            this.textBoxEntityName.Size = new Size(360, 20);
            this.textBoxEntityName.TabIndex = 1;
            this.textBoxEntityName.TextChanged += new EventHandler(this.textBoxEntityName_TextChanged);
            this.labelEntityCaption.AutoSize = true;
            this.labelEntityCaption.Location = new Point(0, 8);
            this.labelEntityCaption.Name = "labelEntityCaption";
            this.labelEntityCaption.Size = new Size(0x40, 13);
            this.labelEntityCaption.TabIndex = 0;
            this.labelEntityCaption.Text = "Entity Name";
            this.treeViewEntities.AllowDrop = true;
            this.treeViewEntities.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.treeViewEntities.ContextMenu = this.contextMenuEntities;
            this.treeViewEntities.HideSelection = false;
            this.treeViewEntities.ImageIndex = 0;
            this.treeViewEntities.ImageList = this.imageListEntities;
            this.treeViewEntities.Location = new Point(0, 0);
            this.treeViewEntities.Name = "treeViewEntities";
            this.treeViewEntities.SelectedImageIndex = 0;
            this.treeViewEntities.Size = new Size(0x10c, 0x1c0);
            this.treeViewEntities.TabIndex = 0;
            this.treeViewEntities.DragDrop += new DragEventHandler(this.treeViewEntities_DragDrop);
            this.treeViewEntities.AfterSelect += new TreeViewEventHandler(this.treeViewEntities_AfterSelect);
            this.treeViewEntities.DragEnter += new DragEventHandler(this.treeViewEntities_DragEnter);
            this.treeViewEntities.ItemDrag += new ItemDragEventHandler(this.treeViewEntities_ItemDrag);
            this.treeViewEntities.DragOver += new DragEventHandler(this.treeViewEntities_DragOver);
            this.contextMenuEntities.MenuItems.AddRange(new MenuItem[] { this.cmenuItemEntAdd, this.cmenuItemEntAddSub, this.cmenuItemEntAddDataAttr, this.cmenuItemEntAddVirtAttr, this.cmenuItemEntDelete });
            this.contextMenuEntities.Popup += new EventHandler(this.contextMenuEntities_Popup);
            this.cmenuItemEntAdd.Index = 0;
            this.cmenuItemEntAdd.Text = "Add root level entity";
            this.cmenuItemEntAdd.Click += new EventHandler(this.menuItemAddEntity_Click);
            this.cmenuItemEntAddSub.Index = 1;
            this.cmenuItemEntAddSub.Text = "Add sub-entity";
            this.cmenuItemEntAddSub.Click += new EventHandler(this.menuItemAddSubEntity_Click);
            this.cmenuItemEntAddDataAttr.Index = 2;
            this.cmenuItemEntAddDataAttr.Text = "Add data attribute...";
            this.cmenuItemEntAddDataAttr.Click += new EventHandler(this.menuItemAddDataAttr_Click);
            this.cmenuItemEntAddVirtAttr.Index = 3;
            this.cmenuItemEntAddVirtAttr.Text = "Add virtual attribute...";
            this.cmenuItemEntAddVirtAttr.Click += new EventHandler(this.menuItemAddVirtualAttr_Click);
            this.cmenuItemEntDelete.Index = 4;
            this.cmenuItemEntDelete.Text = "Delete selected";
            this.cmenuItemEntDelete.Click += new EventHandler(this.menuItemEntitiesDelete_Click);
            this.imageListEntities.ImageStream = (ImageListStreamer) manager.GetObject("imageListEntities.ImageStream");
            this.imageListEntities.TransparentColor = Color.Transparent;
            this.tabOperators.Controls.Add(this.comboBoxOpGroupFilter);
            this.tabOperators.Controls.Add(this.labelOpGroupFilter);
            this.tabOperators.Controls.Add(this.panelOperatorProps);
            this.tabOperators.Controls.Add(this.listBoxOperators);
            this.tabOperators.Location = new Point(4, 0x16);
            this.tabOperators.Name = "tabOperators";
            this.tabOperators.Size = new Size(0x2ea, 0x1c6);
            this.tabOperators.TabIndex = 2;
            this.tabOperators.Text = "Operators";
            this.comboBoxOpGroupFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOpGroupFilter.Location = new Point(0x38, 8);
            this.comboBoxOpGroupFilter.Name = "comboBoxOpGroupFilter";
            this.comboBoxOpGroupFilter.Size = new Size(0xd0, 0x15);
            this.comboBoxOpGroupFilter.TabIndex = 8;
            this.comboBoxOpGroupFilter.SelectedIndexChanged += new EventHandler(this.comboBoxOpGroupFilter_SelectedIndexChanged);
            this.labelOpGroupFilter.AutoSize = true;
            this.labelOpGroupFilter.Location = new Point(4, 11);
            this.labelOpGroupFilter.Name = "labelOpGroupFilter";
            this.labelOpGroupFilter.Size = new Size(0x27, 13);
            this.labelOpGroupFilter.TabIndex = 7;
            this.labelOpGroupFilter.Text = "Group:";
            this.panelOperatorProps.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panelOperatorProps.Controls.Add(this.buttonOpDefValEditorSettings);
            this.panelOperatorProps.Controls.Add(this.comboBoxOpGroup);
            this.panelOperatorProps.Controls.Add(this.comboBoxOpDefValueEditor);
            this.panelOperatorProps.Controls.Add(this.labelOpDefValueEditor);
            this.panelOperatorProps.Controls.Add(this.checkedListBoxOpAppliedTypes);
            this.panelOperatorProps.Controls.Add(this.comboBoxOpValueKind);
            this.panelOperatorProps.Controls.Add(this.labelOpValueKind);
            this.panelOperatorProps.Controls.Add(this.comboBoxOpExprType);
            this.panelOperatorProps.Controls.Add(this.labelOpDataType);
            this.panelOperatorProps.Controls.Add(this.textBoxOpExpr);
            this.panelOperatorProps.Controls.Add(this.labelOpExpr);
            this.panelOperatorProps.Controls.Add(this.textBoxOpDisplayFormat);
            this.panelOperatorProps.Controls.Add(this.labelOpDispFormat);
            this.panelOperatorProps.Controls.Add(this.textBoxOpCaption);
            this.panelOperatorProps.Controls.Add(this.labelOpCaption);
            this.panelOperatorProps.Controls.Add(this.textBoxOpID);
            this.panelOperatorProps.Controls.Add(this.labelOpID);
            this.panelOperatorProps.Controls.Add(this.checkBoxOpCaseInsens);
            this.panelOperatorProps.Controls.Add(this.labelOpGroup);
            this.panelOperatorProps.Controls.Add(this.labelOpAppliedTypes);
            this.panelOperatorProps.Location = new Point(0x10c, 0);
            this.panelOperatorProps.Name = "panelOperatorProps";
            this.panelOperatorProps.Size = new Size(480, 0x1c8);
            this.panelOperatorProps.TabIndex = 6;
            this.panelOperatorProps.Visible = false;
            this.buttonOpDefValEditorSettings.Location = new Point(0xc0, 0xd6);
            this.buttonOpDefValEditorSettings.Name = "buttonOpDefValEditorSettings";
            this.buttonOpDefValEditorSettings.Size = new Size(0x4b, 0x17);
            this.buttonOpDefValEditorSettings.TabIndex = 0x1c;
            this.buttonOpDefValEditorSettings.Text = "Settings...";
            this.buttonOpDefValEditorSettings.Click += new EventHandler(this.buttonOpDefValEditorSettings_Click);
            this.labelOpGroup.AutoSize = true;
            this.labelOpGroup.Location = new Point(0x138, 0x98);
            this.labelOpGroup.Name = "labelOpGroup";
            this.labelOpGroup.Size = new Size(0x24, 13);
            this.labelOpGroup.TabIndex = 0x1b;
            this.labelOpGroup.Text = "Group";
            this.comboBoxOpGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOpGroup.Location = new Point(0x138, 0xa8);
            this.comboBoxOpGroup.Name = "comboBoxOpGroup";
            this.comboBoxOpGroup.Size = new Size(0x98, 0x15);
            this.comboBoxOpGroup.TabIndex = 0x1a;
            this.comboBoxOpGroup.SelectedIndexChanged += new EventHandler(this.SomeChangesOccured);
            this.comboBoxOpDefValueEditor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOpDefValueEditor.Items.AddRange(new object[] { "Auto", "Text editor", "Date/time editor", "List of constants", "Custom list", "SQL list", "Custom (user defined)" });
            this.comboBoxOpDefValueEditor.Location = new Point(8, 0xd8);
            this.comboBoxOpDefValueEditor.Name = "comboBoxOpDefValueEditor";
            this.comboBoxOpDefValueEditor.Size = new Size(160, 0x15);
            this.comboBoxOpDefValueEditor.TabIndex = 0x19;
            this.comboBoxOpDefValueEditor.SelectedIndexChanged += new EventHandler(this.comboBoxOpDefValueEditor_SelectedIndexChanged);
            this.labelOpDefValueEditor.AutoSize = true;
            this.labelOpDefValueEditor.Location = new Point(8, 200);
            this.labelOpDefValueEditor.Name = "labelOpDefValueEditor";
            this.labelOpDefValueEditor.Size = new Size(0x63, 13);
            this.labelOpDefValueEditor.TabIndex = 0x18;
            this.labelOpDefValueEditor.Text = "Default value editor";
            this.labelOpAppliedTypes.AutoSize = true;
            this.labelOpAppliedTypes.Location = new Point(8, 0x100);
            this.labelOpAppliedTypes.Name = "labelOpAppliedTypes";
            this.labelOpAppliedTypes.Size = new Size(70, 13);
            this.labelOpAppliedTypes.TabIndex = 0x17;
            this.labelOpAppliedTypes.Text = "Applied types";
            this.checkedListBoxOpAppliedTypes.Location = new Point(8, 0x110);
            this.checkedListBoxOpAppliedTypes.MultiColumn = true;
            this.checkedListBoxOpAppliedTypes.Name = "checkedListBoxOpAppliedTypes";
            this.checkedListBoxOpAppliedTypes.Size = new Size(0x1c8, 0x5e);
            this.checkedListBoxOpAppliedTypes.TabIndex = 0x15;
            this.checkedListBoxOpAppliedTypes.SelectedValueChanged += new EventHandler(this.SomeChangesOccured);
            this.comboBoxOpValueKind.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOpValueKind.Items.AddRange(new object[] { "Scalar", "List", "Sub-query" });
            this.comboBoxOpValueKind.Location = new Point(160, 0xa8);
            this.comboBoxOpValueKind.Name = "comboBoxOpValueKind";
            this.comboBoxOpValueKind.Size = new Size(120, 0x15);
            this.comboBoxOpValueKind.TabIndex = 0x13;
            this.comboBoxOpValueKind.SelectedIndexChanged += new EventHandler(this.SomeChangesOccured);
            this.labelOpValueKind.AutoSize = true;
            this.labelOpValueKind.Location = new Point(160, 0x98);
            this.labelOpValueKind.Name = "labelOpValueKind";
            this.labelOpValueKind.Size = new Size(0x4a, 13);
            this.labelOpValueKind.TabIndex = 0x12;
            this.labelOpValueKind.Text = "Kind of values";
            this.comboBoxOpExprType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxOpExprType.Location = new Point(8, 0xa8);
            this.comboBoxOpExprType.Name = "comboBoxOpExprType";
            this.comboBoxOpExprType.Size = new Size(0x88, 0x15);
            this.comboBoxOpExprType.TabIndex = 0x11;
            this.comboBoxOpExprType.SelectedIndexChanged += new EventHandler(this.SomeChangesOccured);
            this.labelOpDataType.AutoSize = true;
            this.labelOpDataType.Location = new Point(8, 0x98);
            this.labelOpDataType.Name = "labelOpDataType";
            this.labelOpDataType.Size = new Size(0x58, 13);
            this.labelOpDataType.TabIndex = 0x10;
            this.labelOpDataType.Text = "Default data type";
            this.textBoxOpExpr.Location = new Point(8, 120);
            this.textBoxOpExpr.Name = "textBoxOpExpr";
            this.textBoxOpExpr.Size = new Size(0x1c8, 20);
            this.textBoxOpExpr.TabIndex = 15;
            this.textBoxOpExpr.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelOpExpr.AutoSize = true;
            this.labelOpExpr.Location = new Point(8, 0x68);
            this.labelOpExpr.Name = "labelOpExpr";
            this.labelOpExpr.Size = new Size(0x3a, 13);
            this.labelOpExpr.TabIndex = 14;
            this.labelOpExpr.Text = "Expression";
            this.textBoxOpDisplayFormat.Location = new Point(8, 0x48);
            this.textBoxOpDisplayFormat.Name = "textBoxOpDisplayFormat";
            this.textBoxOpDisplayFormat.Size = new Size(0x1c8, 20);
            this.textBoxOpDisplayFormat.TabIndex = 11;
            this.textBoxOpDisplayFormat.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelOpDispFormat.AutoSize = true;
            this.labelOpDispFormat.Location = new Point(8, 0x38);
            this.labelOpDispFormat.Name = "labelOpDispFormat";
            this.labelOpDispFormat.Size = new Size(0x49, 13);
            this.labelOpDispFormat.TabIndex = 10;
            this.labelOpDispFormat.Text = "Display format";
            this.textBoxOpCaption.Location = new Point(0xb8, 0x18);
            this.textBoxOpCaption.Name = "textBoxOpCaption";
            this.textBoxOpCaption.Size = new Size(280, 20);
            this.textBoxOpCaption.TabIndex = 9;
            this.textBoxOpCaption.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.labelOpCaption.AutoSize = true;
            this.labelOpCaption.Location = new Point(0xb8, 8);
            this.labelOpCaption.Name = "labelOpCaption";
            this.labelOpCaption.Size = new Size(0x2b, 13);
            this.labelOpCaption.TabIndex = 8;
            this.labelOpCaption.Text = "Caption";
            this.textBoxOpID.Location = new Point(8, 0x18);
            this.textBoxOpID.Name = "textBoxOpID";
            this.textBoxOpID.Size = new Size(0x90, 20);
            this.textBoxOpID.TabIndex = 7;
            this.textBoxOpID.TextChanged += new EventHandler(this.SomeChangesOccured);
            this.textBoxOpID.Leave += new EventHandler(this.textBoxOpID_Leave);
            this.labelOpID.AutoSize = true;
            this.labelOpID.Location = new Point(8, 8);
            this.labelOpID.Name = "labelOpID";
            this.labelOpID.Size = new Size(0x12, 13);
            this.labelOpID.TabIndex = 6;
            this.labelOpID.Text = "ID";
            this.checkBoxOpCaseInsens.Location = new Point(0x138, 0xd8);
            this.checkBoxOpCaseInsens.Name = "checkBoxOpCaseInsens";
            this.checkBoxOpCaseInsens.Size = new Size(0x90, 0x18);
            this.checkBoxOpCaseInsens.TabIndex = 20;
            this.checkBoxOpCaseInsens.Text = "Case insensitive";
            this.checkBoxOpCaseInsens.CheckedChanged += new EventHandler(this.SomeChangesOccured);
            this.listBoxOperators.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listBoxOperators.Location = new Point(0, 0x20);
            this.listBoxOperators.Name = "listBoxOperators";
            this.listBoxOperators.Size = new Size(0x10c, 420);
            this.listBoxOperators.TabIndex = 1;
            this.listBoxOperators.SelectedIndexChanged += new EventHandler(this.listBoxOperators_SelectedIndexChanged);
            this.listBoxOperators.KeyDown += new KeyEventHandler(this.listBoxOperators_KeyDown);
            this.openFileDlg.Filter = "Data model files (*.xml)|*.xml";
            this.saveFileDlg.DefaultExt = "xml";
            this.saveFileDlg.Filter = "Data model files (*.xml)|*.xml";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(760, 0x1e9);
            base.Controls.Add(this.tabControlMain);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Menu = this.mainMenu1;
            base.Name = "ModelEditorForm";
            this.Text = "Data Model Editor";
            base.VisibleChanged += new EventHandler(this.ModelEditorForm_VisibleChanged);
            base.Closing += new CancelEventHandler(this.ModelEditorForm_Closing);
            this.tabControlMain.ResumeLayout(false);
            this.tabTables.ResumeLayout(false);
            this.panelTableProps.ResumeLayout(false);
            this.groupBoxLinkedTables.ResumeLayout(false);
            this.groupBoxTableProps.ResumeLayout(false);
            this.groupBoxTableProps.PerformLayout();
            this.tabEntities.ResumeLayout(false);
            this.groupBoxEntityAttrProps.ResumeLayout(false);
            this.tabControlAttrProps.ResumeLayout(false);
            this.tabPageAttrGeneral.ResumeLayout(false);
            this.tabPageAttrGeneral.PerformLayout();
            this.groupBoxAttrTables.ResumeLayout(false);
            this.groupBoxAttrOptions.ResumeLayout(false);
            this.numUpDownAttrSize.EndInit();
            this.tabPageAttrOperators.ResumeLayout(false);
            this.tabPageAttrValueEditors.ResumeLayout(false);
            this.panelAttrValEditorsTop.ResumeLayout(false);
            this.panelAttrValEditorsTop.PerformLayout();
            this.panelEntityProps.ResumeLayout(false);
            this.panelEntityProps.PerformLayout();
            this.tabOperators.ResumeLayout(false);
            this.tabOperators.PerformLayout();
            this.panelOperatorProps.ResumeLayout(false);
            this.panelOperatorProps.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InitModelControls()
        {
            DataType[] values = (DataType[]) Enum.GetValues(typeof(DataType));
            this.comboBoxAttrDataType.Items.Clear();
            this.comboBoxOpExprType.Items.Clear();
            this.comboBoxOpValueKind.Items.Clear();
            this.checkedListBoxOpAppliedTypes.Items.Clear();
            foreach (DataType type in values)
            {
                this.comboBoxAttrDataType.Items.Add(type);
                this.comboBoxOpExprType.Items.Add(type);
                if (type != DataType.Unknown)
                {
                    this.checkedListBoxOpAppliedTypes.Items.Add(type);
                }
            }
            this.comboBoxOpExprType.Items[0] = "Auto";
            DataKind[] kindArray = (DataKind[]) Enum.GetValues(typeof(DataKind));
            foreach (DataKind kind in kindArray)
            {
                this.comboBoxOpValueKind.Items.Add(kind);
            }
            this.comboBoxOpGroupFilter.Items.Clear();
            this.comboBoxOpGroupFilter.Items.Add(DataModel.AnyOperatorGroup);
            this.comboBoxOpGroup.Items.Clear();
            foreach (DataModel.OperatorGroup group in DataModel.OperatorGroups)
            {
                this.comboBoxOpGroupFilter.Items.Add(group);
                this.comboBoxOpGroup.Items.Add(group);
            }
            this.comboBoxOpGroupFilter.SelectedIndex = 0;
        }

        private bool IsLinkType(DataType dt)
        {
            return LinkDataTypes.Contains(dt);
        }

        private void listBoxAttrTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonAttrDeleteTable.Enabled = this.listBoxAttrTables.SelectedItem != null;
        }

        private void listBoxOperators_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                this.AddNewOperator();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.DeleteCurrentOperator();
            }
        }

        private void listBoxOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SaveCurrentOperator();
            this.RenderSelectedOperator();
        }

        private void listBoxTableLinks_DoubleClick(object sender, EventArgs e)
        {
            this.EditCurrentLink();
        }

        private void listBoxTableLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EnableLinkButtons();
        }

        private void listBoxTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                this.AddTables();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.DeleteCurrentTable();
            }
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SaveCurrentTable();
            this.RenderSelectedTable();
        }

        public virtual void LoadModelFromFile(string modelFilePath)
        {
            string path = Environment.ExpandEnvironmentVariables(modelFilePath);
            this.model.Clear();
            this.model.LoadFromFile(path);
            this.dbGate = Korzh.EasyQuery.ModelEditor.ModelEditor.DbGates.Find(this.model.DbParams.GateClass, null);
            if (this.dbGate == null)
            {
                if (Korzh.EasyQuery.ModelEditor.ModelEditor.DbGates.Count == 0)
                {
                    throw new InvalidOperationException("No database gate");
                }
                this.dbGate = Korzh.EasyQuery.ModelEditor.ModelEditor.DbGates[0];
            }
            this.dbGate.LoadParams(this.model.DbParams);
            this.RenderFormTitle();
            this.RenderModel();
            this.ModelChanged = false;
            this.menuItemEditModelSettings.Enabled = true;
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            if (this.aboutDlg == null)
            {
                this.aboutDlg = new AboutDlg();
            }
            this.aboutDlg.ShowDialog();
        }

        private void menuItemAddDataAttr_Click(object sender, EventArgs e)
        {
            this.AddDataAttr();
        }

        private void menuItemAddEntity_Click(object sender, EventArgs e)
        {
            this.AddEntity(null);
        }

        private void menuItemAddSubEntity_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeViewEntities.SelectedNode;
            if (selectedNode.Tag is DataModel.EntityAttr)
            {
                selectedNode = selectedNode.Parent;
            }
            this.AddEntity(selectedNode);
        }

        private void menuItemAddVirtualAttr_Click(object sender, EventArgs e)
        {
            this.AddVirtualAttr();
        }

        private void menuItemAutoAddLinks_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Model Editor will try to add links between tables automatically.\nDo you want to proceed?", this.DMETitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.AutoAddLinks();
                this.RenderModel();
                this.ModelChanged = true;
            }
        }

        private void menuItemAutoGenerateLinks_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Model Editor will try to generate links by field to field comparision.\nDo you want to proceed?", this.DMETitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.AutoGenerateLinks();
                this.RenderModel();
                this.ModelChanged = true;
            }
        }

        private void menuItemContents_Click(object sender, EventArgs e)
        {
            string environmentVariable = Environment.GetEnvironmentVariable("KORZH_NET");
            if (environmentVariable == null)
            {
                environmentVariable = @"..\..\..\..\..\";
            }
            if (environmentVariable[environmentVariable.Length - 1] != '\\')
            {
                environmentVariable = environmentVariable + @"\";
            }
            Help.ShowHelp(this, (environmentVariable + @"help\") + "eq_dme.chm");
        }

        private void menuItemEditModelSettings_Click(object sender, EventArgs e)
        {
            if (this.ShowModelParamsDlg(this.model, "Model Settings"))
            {
                this.RenderFormTitle();
            }
            this.ModelChanged = true;
        }

        private void menuItemEntitiesDelete_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedEntityObj();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void menuItemNewModel_Click(object sender, EventArgs e)
        {
            this.NewModelWizard();
        }

        private void menuItemOpenModel_Click(object sender, EventArgs e)
        {
            if (this.openFileDlg.ShowDialog() == DialogResult.OK)
            {
                this.LoadModelFromFile(this.openFileDlg.FileName);
            }
        }

        private void menuItemOperatorAdd_Click(object sender, EventArgs e)
        {
            this.AddNewOperator();
        }

        private void menuItemOperatorAddUpdateDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Currently existing default operators will be overwritten. Continue?", this.DMETitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.model.AddDefaultOperators();
                this.RenderOperatorList();
                this.ModelChanged = true;
            }
        }

        private void menuItemOperatorDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentOperator();
        }

        private void menuItemSaveModel_Click(object sender, EventArgs e)
        {
            if (this.model.FilePath != "")
            {
                this.SaveModelToFile(this.model.FilePath);
            }
            else
            {
                this.SaveModelAs();
            }
        }

        private void menuItemSaveModelAs_Click(object sender, EventArgs e)
        {
            this.SaveModelAs();
        }

        private void menuItemTableAdd_Click(object sender, EventArgs e)
        {
            this.AddTables();
        }

        private void menuItemTableDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentTable();
        }

        private void ModelEditorForm_Closing(object sender, CancelEventArgs e)
        {
            if (this.ModelChanged)
            {
                switch (MessageBox.Show("Model was modified. Save changes?", this.DMETitle, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        if (this.model.FilePath != "")
                        {
                            this.SaveModelToFile(this.model.FilePath);
                            return;
                        }
                        this.SaveModelAs();
                        return;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void ModelEditorForm_VisibleChanged(object sender, EventArgs e)
        {
            if (base.Visible && this.RunNewModelWizardOnStart)
            {
                this.RunNewModelWizardOnStart = false;
                Timer timer = new Timer();
                timer.Interval = 0x3e8;
                timer.Tick += new EventHandler(this.StartNewModelWizard);
                timer.Start();
            }
        }

        protected void NewModelWizard()
        {
            DataModel modelToEdit = new DataModel();
            modelToEdit.ModelName = "New data model";
            modelToEdit.StoreDbParams = true;
            if (this.ShowModelParamsDlg(modelToEdit, "New Model"))
            {
                this.dbGate = this.modelPropsDlg.DbGate;
                this.model = modelToEdit;
                this.model.AddDefaultOperators();
                this.ModelChanged = true;
                if (MessageBox.Show("Add tables to new data model?", this.DMETitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.AddTables();
                    if (MessageBox.Show("Data Model Editor will try to add links between selected tables automatiically.\nDo you want to proceed?", this.DMETitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.AutoAddLinks();
                    }
                    if ((this.model.Links.Count == 0) && (MessageBox.Show("Unfortunately Data Model Editor can not get information about table joins from the database\nDo you want to try to generate links by field to field comparision?", this.DMETitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        this.AutoGenerateLinks();
                    }
                    this.menuItemEditModelSettings.Enabled = true;
                }
                this.RenderFormTitle();
                this.RenderModel();
            }
        }

        private void RenderEntities()
        {
            this.currentEntityObj = null;
            this.panelEntityProps.Visible = false;
            this.tabControlAttrProps.Visible = false;
            this.treeViewEntities.AfterSelect -= new TreeViewEventHandler(this.treeViewEntities_AfterSelect);
            this.treeViewEntities.BeginUpdate();
            this.treeViewEntities.Nodes.Clear();
            this.AddSubEntityNodes(this.model.EntityRoot, this.treeViewEntities.Nodes);
            this.treeViewEntities.EndUpdate();
            this.treeViewEntities.AfterSelect += new TreeViewEventHandler(this.treeViewEntities_AfterSelect);
            this.EnableEntityControls();
        }

        protected void RenderEntity(DataModel.Entity entity)
        {
            this.StartRendering();
            try
            {
                this.currentEntityObj = entity;
                this.tabControlAttrProps.Visible = false;
                this.textBoxEntityName.Text = entity.Name;
                this.textBoxEntityUserData.Text = (entity.UserData != null) ? entity.UserData.ToString() : "";
                this.panelEntityProps.Visible = true;
            }
            finally
            {
                this.EndRendering();
            }
        }

        protected virtual void RenderEntityAttr(DataModel.EntityAttr attr)
        {
            this.StartRendering();
            try
            {
                this.currentEntityObj = attr;
                this.panelEntityProps.Visible = false;
                this.textBoxAttrCaption.Text = attr.Caption;
                if (attr.Kind == DataModel.EntAttrKind.Data)
                {
                    this.textBoxAttrExpr.ReadOnly = true;
                    this.textBoxAttrExpr.Text = string.Format("Table: {0}\r\nField: {1}", attr.Tables[0].FullName, attr.Expr);
                    this.buttonAttrAddTable.Enabled = false;
                    this.buttonAttrDeleteTable.Enabled = false;
                    this.checkBoxAttrIsAggregate.Enabled = false;
                }
                else
                {
                    this.textBoxAttrExpr.ReadOnly = false;
                    this.textBoxAttrExpr.Text = attr.Expr;
                    this.buttonAttrAddTable.Enabled = true;
                    this.buttonAttrDeleteTable.Enabled = false;
                    this.checkBoxAttrIsAggregate.Enabled = true;
                }
                this.comboBoxAttrDataType.SelectedItem = attr.DataType;
                this.numUpDownAttrSize.Value = attr.Size;
                this.checkBoxAttrUseInConditions.Checked = attr.UseInConditions;
                this.checkBoxAttrUseInResult.Checked = attr.UseInResult;
                this.checkBoxAttrUseInSorting.Checked = attr.UseInSorting;
                this.checkBoxAttrQuote.Checked = attr.Quote;
                this.checkBoxAttrUseAlias.Checked = attr.UseAlias;
                this.checkBoxAttrIsAggregate.Checked = attr.IsAggregate;
                this.textBoxAttrDescription.Text = attr.Description;
                if (attr.UserData != null)
                {
                    this.textBoxAttrCustomData.Text = attr.UserData.ToString();
                }
                else
                {
                    this.textBoxAttrCustomData.Text = "";
                }
                this.FillAttrTablesList(attr);
                this.listBoxAttrOperators.Items.Clear();
                foreach (DataModel.Operator @operator in attr.Operations)
                {
                    this.listBoxAttrOperators.Items.Add(@operator);
                }
                this.currentAttrValueEditor = attr.DefaultEditor;
                this.RenderValueEditorTypeCombo(this.comboBoxAttrValEditorType, this.currentAttrValueEditor);
                this.EnableValueEditorSettingsButton(this.buttonAttrDefValEditorSettings, this.currentAttrValueEditor);
                this.tabControlAttrProps.Visible = true;
            }
            finally
            {
                this.EndRendering();
            }
        }

        protected void RenderEntityNode(TreeNode node)
        {
            if (node != null)
            {
                if (node.Tag is DataModel.Entity)
                {
                    this.RenderEntity((DataModel.Entity) node.Tag);
                }
                else
                {
                    this.RenderEntityAttr((DataModel.EntityAttr) node.Tag);
                }
            }
            this.EnableEntityControls();
        }

        private void RenderFormTitle()
        {
            string str = this.DMETitle + " - " + System.IO.Path.GetFileName(this.model.FilePath);
            this.Text = str;
        }

        protected virtual void RenderModel()
        {
            this.StartRendering();
            try
            {
                this.currentTable = null;
                this.panelTableProps.Visible = this.currentTable != null;
                this.listBoxTables.Items.Clear();
                foreach (DataModel.Table table in this.model.Tables)
                {
                    this.listBoxTables.Items.Add(table);
                }
                this.EnableTableControls();
                this.RenderEntities();
                this.RenderOperatorList();
            }
            finally
            {
                this.EndRendering();
            }
            this.tabControlMain.Visible = true;
            this.EnableMenuItems();
        }

        private void RenderOperatorList()
        {
            this.currentOperator = null;
            this.panelOperatorProps.Visible = false;
            this.listBoxOperators.Items.Clear();
            DataModel.OperatorGroup selectedItem = (DataModel.OperatorGroup) this.comboBoxOpGroupFilter.SelectedItem;
            foreach (DataModel.Operator @operator in this.model.Operators)
            {
                if ((selectedItem == DataModel.AnyOperatorGroup) || (selectedItem == @operator.Group))
                {
                    this.listBoxOperators.Items.Add(@operator);
                }
            }
            this.EnableOperatorControls();
        }

        protected virtual void RenderOperatorProps(DataModel.Operator op)
        {
            this.StartRendering();
            try
            {
                this.textBoxOpID.Text = op.ID;
                this.textBoxOpCaption.Text = op.Caption;
                this.textBoxOpDisplayFormat.Text = op.DisplayFormat;
                this.textBoxOpExpr.Text = op.Expr;
                if (op.ExprDefType == DataType.Unknown)
                {
                    this.comboBoxOpExprType.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxOpExprType.SelectedItem = op.ExprDefType;
                }
                this.checkBoxOpCaseInsens.Checked = op.CaseInsensitive;
                this.comboBoxOpValueKind.SelectedItem = op.ValueKind;
                this.comboBoxOpGroup.SelectedItem = op.Group;
                for (int i = 0; i < this.checkedListBoxOpAppliedTypes.Items.Count; i++)
                {
                    DataType item = (DataType) this.checkedListBoxOpAppliedTypes.Items[i];
                    this.checkedListBoxOpAppliedTypes.SetItemChecked(i, op.AppliedTypes.Contains(item));
                }
                this.currentOpValueEditor = op.DefaultEditor;
                this.RenderValueEditorTypeCombo(this.comboBoxOpDefValueEditor, this.currentOpValueEditor);
                this.EnableValueEditorSettingsButton(this.buttonOpDefValEditorSettings, this.currentOpValueEditor);
            }
            finally
            {
                this.EndRendering();
            }
        }

        protected virtual void RenderSelectedOperator()
        {
            this.currentOperator = (DataModel.Operator) this.listBoxOperators.SelectedItem;
            this.currentTable = (DataModel.Table) this.listBoxTables.SelectedItem;
            this.panelOperatorProps.Visible = this.currentOperator != null;
            this.menuItemOperatorDelete.Enabled = this.currentOperator != null;
            if (this.currentOperator != null)
            {
                this.RenderOperatorProps(this.currentOperator);
            }
        }

        protected void RenderSelectedTable()
        {
            this.currentTable = (DataModel.Table) this.listBoxTables.SelectedItem;
            this.EnableTableControls();
            if (this.currentTable != null)
            {
                this.RenderTableProps(this.currentTable);
            }
        }

        protected void RenderTableProps(DataModel.Table table)
        {
            this.StartRendering();
            try
            {
                this.textBoxTableAlias.Text = table.Alias;
                this.comboBoxTableHints.Text = table.Hints;
                this.checkBoxQuote.Checked = table.Quote;
                this.listBoxTableLinks.Items.Clear();
                foreach (DataModel.Link link in table.Links)
                {
                    this.listBoxTableLinks.Items.Add(link);
                }
            }
            finally
            {
                this.EndRendering();
            }
            this.EnableLinkButtons();
        }

        private void RenderValueEditorTypeCombo(ComboBox combo, ValueEditor editor)
        {
            this.StartRendering();
            try
            {
                if (editor == null)
                {
                    combo.SelectedIndex = 0;
                }
                else if (editor is TextValueEditor)
                {
                    combo.SelectedIndex = 1;
                }
                else if (editor is DateTimeValueEditor)
                {
                    combo.SelectedIndex = 2;
                }
                else if (editor is ConstListValueEditor)
                {
                    combo.SelectedIndex = 3;
                }
                else if (editor is CustomListValueEditor)
                {
                    combo.SelectedIndex = 4;
                }
                else if (editor is SqlListValueEditor)
                {
                    combo.SelectedIndex = 5;
                }
                else if (editor is CustomValueEditor)
                {
                    combo.SelectedIndex = 6;
                }
            }
            finally
            {
                this.EndRendering();
            }
        }

        protected void SaveCurrentEntityObj()
        {
            if (this.currentEntityObj != null)
            {
                if (this.currentEntityObj is DataModel.Entity)
                {
                    this.SaveEntity((DataModel.Entity) this.currentEntityObj);
                }
                else
                {
                    this.SaveEntityAttr((DataModel.EntityAttr) this.currentEntityObj);
                }
            }
        }

        private void SaveCurrentOperator()
        {
            if (this.currentOperator != null)
            {
                this.SaveOperatorProps(this.currentOperator);
                this.UpdateListBoxItem(this.listBoxOperators, this.currentOperator);
            }
        }

        private void SaveCurrentTable()
        {
            if (this.currentTable != null)
            {
                this.SaveTableProps(this.currentTable);
            }
        }

        protected void SaveEntity(DataModel.Entity entity)
        {
            entity.Name = this.textBoxEntityName.Text;
            entity.UserData = this.textBoxEntityUserData.Text;
        }

        protected void SaveEntityAttr(DataModel.EntityAttr attr)
        {
            attr.Caption = this.textBoxAttrCaption.Text;
            if (attr.Kind == DataModel.EntAttrKind.Virtual)
            {
                attr.Expr = this.textBoxAttrExpr.Text;
            }
            attr.DataType = (DataType) this.comboBoxAttrDataType.SelectedItem;
            attr.Size = decimal.ToInt32(this.numUpDownAttrSize.Value);
            attr.UseInConditions = this.checkBoxAttrUseInConditions.Checked;
            attr.UseInResult = this.checkBoxAttrUseInResult.Checked;
            attr.UseInSorting = this.checkBoxAttrUseInSorting.Checked;
            attr.Quote = this.checkBoxAttrQuote.Checked;
            attr.UseAlias = this.checkBoxAttrUseAlias.Checked;
            attr.IsAggregate = this.checkBoxAttrIsAggregate.Checked;
            attr.Description = this.textBoxAttrDescription.Text;
            if (this.textBoxAttrCustomData.Text != "")
            {
                attr.UserData = this.textBoxAttrCustomData.Text;
            }
            else
            {
                attr.UserData = null;
            }
            attr.Tables.Clear();
            foreach (DataModel.Table table in this.listBoxAttrTables.Items)
            {
                attr.Tables.Add(table);
            }
            attr.Operations.Clear();
            foreach (DataModel.Operator @operator in this.listBoxAttrOperators.Items)
            {
                attr.Operations.Add(@operator);
            }
            attr.DefaultEditor = this.currentAttrValueEditor;
        }

        protected virtual void SaveModelAs()
        {
            if (this.model.FilePath != "")
            {
                this.saveFileDlg.InitialDirectory = System.IO.Path.GetDirectoryName(this.model.FilePath);
            }
            else
            {
                this.saveFileDlg.InitialDirectory = Directory.GetCurrentDirectory();
            }
            if (this.saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                this.SaveModelToFile(this.saveFileDlg.FileName);
            }
        }

        public virtual void SaveModelToFile(string modelFilePath)
        {
            this.SaveCurrentTable();
            this.SaveCurrentEntityObj();
            this.SaveCurrentOperator();
            this.dbGate.SaveParams(this.model.DbParams);
            this.model.SaveToFile(modelFilePath);
            this.ModelChanged = false;
        }

        protected virtual void SaveOperatorProps(DataModel.Operator op)
        {
            op.ID = this.textBoxOpID.Text;
            op.Caption = this.textBoxOpCaption.Text;
            op.DisplayFormat = this.textBoxOpDisplayFormat.Text;
            op.Expr = this.textBoxOpExpr.Text;
            op.Group = (DataModel.OperatorGroup) this.comboBoxOpGroup.SelectedItem;
            if (this.comboBoxOpExprType.SelectedIndex == 0)
            {
                op.ExprDefType = DataType.Unknown;
            }
            else
            {
                op.ExprDefType = (DataType) this.comboBoxOpExprType.SelectedItem;
            }
            op.CaseInsensitive = this.checkBoxOpCaseInsens.Checked;
            op.ValueKind = (DataKind) this.comboBoxOpValueKind.SelectedItem;
            op.DefaultEditor = this.currentOpValueEditor;
            op.AppliedTypes.Clear();
            foreach (DataType type in this.checkedListBoxOpAppliedTypes.CheckedItems)
            {
                op.AppliedTypes.Add(type);
            }
        }

        protected void SaveTableProps(DataModel.Table table)
        {
            table.Alias = this.textBoxTableAlias.Text;
            table.Hints = this.comboBoxTableHints.Text;
            table.Quote = this.checkBoxQuote.Checked;
        }

        private void SetAttrAggregation(DataModel.EntityAttr attr)
        {
            if (attr.Kind != DataModel.EntAttrKind.Data)
            {
                string str = attr.Expr.ToLower();
                if ((((str.IndexOf("sum(") >= 0) || (str.IndexOf("count(") >= 0)) || ((str.IndexOf("max(") >= 0) || (str.IndexOf("min(") >= 0))) || ((str.IndexOf("avg(") >= 0) || (str.IndexOf("list(") >= 0)))
                {
                    this.checkBoxAttrIsAggregate.Checked = true;
                }
            }
        }

        private bool ShowDbItemsListDlg(DbItemType itemType, string dlgTitle, DbItemsDlg.Params dlgParams)
        {
            if (this.dbItemsDialog == null)
            {
                this.dbItemsDialog = new DbItemsDlg();
            }
            return this.dbItemsDialog.ShowModal(this.dbGate, this.model, itemType, dlgTitle, dlgParams);
        }

        private bool ShowEditLinkDialog(DataModel.Link link, string dlgTitle)
        {
            if (this.linkPropsDlg == null)
            {
                this.linkPropsDlg = new LinkPropsDlg();
            }
            return this.linkPropsDlg.ShowModal(this.dbGate, this.model, link, dlgTitle);
        }

        private bool ShowModelParamsDlg(DataModel modelToEdit, string dlgTitle)
        {
            if (this.modelPropsDlg == null)
            {
                this.modelPropsDlg = new ModelPropsDlg();
            }
            this.modelPropsDlg.DbGate = this.dbGate;
            bool flag = this.modelPropsDlg.ShowModal(modelToEdit, dlgTitle);
            if (flag)
            {
                this.dbGate = this.modelPropsDlg.DbGate;
            }
            return flag;
        }

        protected virtual bool ShowValueEditorPropsDlg(ValueEditor valueEditor)
        {
            if (this.valueEditorPropsDlg == null)
            {
                this.valueEditorPropsDlg = new ValueEditorPropsDlg();
            }
            return this.valueEditorPropsDlg.ShowModal(valueEditor);
        }

        private void SomeChangesOccured(object sender, EventArgs e)
        {
            this.ModelChanged = true;
        }

        private void StartNewModelWizard(object sender, EventArgs e)
        {
            ((Timer) sender).Stop();
            this.NewModelWizard();
        }

        protected void StartRendering()
        {
            this.rendering++;
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EnableMenuItems();
        }

        private void textBoxAttrCaption_TextChanged(object sender, EventArgs e)
        {
            this.treeViewEntities.SelectedNode.Text = ((TextBox) sender).Text;
            this.ModelChanged = true;
        }

        private void textBoxAttrExpr_Validated(object sender, EventArgs e)
        {
            DataModel.EntityAttr currentEntityObj = (DataModel.EntityAttr) this.currentEntityObj;
            currentEntityObj.Expr = this.textBoxAttrExpr.Text;
            this.FillAttrTablesList(currentEntityObj);
            this.SetAttrAggregation(currentEntityObj);
        }

        private void textBoxEntityName_TextChanged(object sender, EventArgs e)
        {
            this.treeViewEntities.SelectedNode.Text = ((TextBox) sender).Text;
            this.ModelChanged = true;
        }

        private void textBoxOpID_Leave(object sender, EventArgs e)
        {
        }

        private void treeViewEntities_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.SaveCurrentEntityObj();
            this.RenderEntityNode(e.Node);
        }

        private void treeViewEntities_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = this.treeViewEntities.PointToClient(new Point(e.X, e.Y));
            TreeNode nodeAt = this.treeViewEntities.GetNodeAt(pt);
            TreeNode data = (TreeNode) e.Data.GetData(typeof(TreeNode));
            if (data.Tag is DataModel.EntityAttr)
            {
                DataModel.EntityAttr tag = (DataModel.EntityAttr) data.Tag;
                data.Parent.Nodes.Remove(data);
                tag.Entity.Attributes.Remove(tag);
                if (nodeAt.Tag is DataModel.EntityAttr)
                {
                    DataModel.EntityAttr attr2 = (DataModel.EntityAttr) nodeAt.Tag;
                    int index = attr2.Entity.Attributes.IndexOf(attr2);
                    int num2 = nodeAt.Index;
                    attr2.Entity.Attributes.Insert(index, tag);
                    nodeAt.Parent.Nodes.Insert(num2, data);
                }
                else
                {
                    ((DataModel.Entity) nodeAt.Tag).Attributes.Add(tag);
                    nodeAt.Nodes.Add(data);
                    nodeAt.Expand();
                }
            }
            else
            {
                DataModel.Entity entity = (DataModel.Entity) data.Tag;
                if (data.Parent != null)
                {
                    data.Parent.Nodes.Remove(data);
                }
                else
                {
                    this.treeViewEntities.Nodes.Remove(data);
                }
                entity.Parent.SubEntities.Remove(entity);
                if (nodeAt.Tag is DataModel.EntityAttr)
                {
                    int num3 = ((DataModel.Entity) nodeAt.Parent.Tag).SubEntities.Add(entity);
                    nodeAt.Parent.Nodes.Insert(num3, data);
                }
                else
                {
                    int num4 = nodeAt.Index;
                    ((nodeAt.Parent != null) ? nodeAt.Parent.Nodes : this.treeViewEntities.Nodes).Insert(num4, data);
                    ((DataModel.Entity) nodeAt.Tag).Parent.SubEntities.Insert(num4, entity);
                }
            }
            this.ModelChanged = true;
            this.treeViewEntities.SelectedNode = data;
        }

        private void treeViewEntities_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeViewEntities_DragOver(object sender, DragEventArgs e)
        {
            Point pt = this.treeViewEntities.PointToClient(new Point(e.X, e.Y));
            TreeNode nodeAt = this.treeViewEntities.GetNodeAt(pt);
            TreeNode data = (TreeNode) e.Data.GetData(typeof(TreeNode));
            if (!data.Equals(nodeAt) && !this.ContainsNode(data, nodeAt))
            {
                e.Effect = e.AllowedEffect;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeViewEntities_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.treeViewEntities.SelectedNode = (TreeNode) e.Item;
            base.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void UpdateListBoxItem(ListBox lb, object item)
        {
            int index = lb.Items.IndexOf(item);
            int selectedIndex = lb.SelectedIndex;
            lb.BeginUpdate();
            try
            {
                lb.ClearSelected();
                lb.Items[index] = item;
                lb.SelectedIndex = selectedIndex;
            }
            finally
            {
                lb.EndUpdate();
            }
        }

        protected bool IsRendering
        {
            get
            {
                return (this.rendering > 0);
            }
        }

        public bool ModelChanged
        {
            get
            {
                return this.modelChanged;
            }
            set
            {
                if (this.rendering == 0)
                {
                    this.modelChanged = value;
                    this.menuItemSaveModel.Enabled = this.ModelChanged;
                }
            }
        }

        public bool RunNewModelWizardOnStart
        {
            get
            {
                return this.runNewModelWizardOnStart;
            }
            set
            {
                this.runNewModelWizardOnStart = value;
            }
        }

        public string WorkFolder
        {
            get
            {
                return this.workFolder;
            }
            set
            {
                this.workFolder = value;
            }
        }
    }
}

