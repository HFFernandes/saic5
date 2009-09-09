namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmBuscadorIncidencias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmBuscadorIncidencias));
            this.ContenedorSplit = new System.Windows.Forms.SplitContainer();
            this.QueryColumnas = new Korzh.EasyQuery.WinControls.QueryColumnsPanel();
            this.QueryCondiciones = new Korzh.EasyQuery.WinControls.QueryPanel();
            this.ModeloDatos = new Korzh.EasyQuery.DataModel();
            this.ModeloQuery = new Korzh.EasyQuery.Query();
            this.barComandos = new System.Windows.Forms.ToolStrip();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.GridResultados = new System.Windows.Forms.DataGrid();
            this.ResultadoDataTable = new System.Data.DataTable();
            this.ResultadoDS = new System.Data.DataSet();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabDefinicionConsulta = new System.Windows.Forms.TabPage();
            this.tabResultados = new System.Windows.Forms.TabPage();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.ContenedorSplit.Panel1.SuspendLayout();
            this.ContenedorSplit.Panel2.SuspendLayout();
            this.ContenedorSplit.SuspendLayout();
            this.barComandos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultadoDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultadoDS)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabDefinicionConsulta.SuspendLayout();
            this.tabResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContenedorSplit
            // 
            this.ContenedorSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorSplit.Location = new System.Drawing.Point(3, 3);
            this.ContenedorSplit.Name = "ContenedorSplit";
            this.ContenedorSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContenedorSplit.Panel1
            // 
            this.ContenedorSplit.Panel1.Controls.Add(this.QueryColumnas);
            // 
            // ContenedorSplit.Panel2
            // 
            this.ContenedorSplit.Panel2.Controls.Add(this.QueryCondiciones);
            this.ContenedorSplit.Size = new System.Drawing.Size(912, 439);
            this.ContenedorSplit.SplitterDistance = 264;
            this.ContenedorSplit.TabIndex = 3;
            // 
            // QueryColumnas
            // 
            this.QueryColumnas.Active = false;
            this.QueryColumnas.ActiveRowIndex = -1;
            this.QueryColumnas.Appearance.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.QueryColumnas.Appearance.ActiveForeColor = System.Drawing.SystemColors.HighlightText;
            this.QueryColumnas.Appearance.AdjustChildLevel = true;
            this.QueryColumnas.Appearance.AttrElementFormat = "{entity} {attr}";
            this.QueryColumnas.Appearance.BackColor = System.Drawing.Color.White;
            this.QueryColumnas.Appearance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueryColumnas.Appearance.ButtonActiveBodyColor = System.Drawing.Color.Gray;
            this.QueryColumnas.Appearance.ButtonActiveBorderColor = System.Drawing.Color.Black;
            this.QueryColumnas.Appearance.ButtonClickBodyColor = System.Drawing.Color.White;
            this.QueryColumnas.Appearance.ButtonClickBorderColor = System.Drawing.Color.Black;
            this.QueryColumnas.Appearance.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.QueryColumnas.Appearance.ButtonInactiveBodyColor = System.Drawing.Color.Transparent;
            this.QueryColumnas.Appearance.ButtonInactiveBorderColor = System.Drawing.Color.Black;
            this.QueryColumnas.Appearance.ButtonRounded = true;
            this.QueryColumnas.Appearance.EditMode = Korzh.EasyQuery.WinControls.QueryColumnsPanel.EditModeKind.All;
            this.QueryColumnas.Appearance.ElementSpacing = 2;
            this.QueryColumnas.Appearance.LeftMargin = 2;
            this.QueryColumnas.Appearance.LevelSpacing = 30;
            this.QueryColumnas.Appearance.LinkColor = System.Drawing.Color.Blue;
            this.QueryColumnas.Appearance.ReadOnlyColor = System.Drawing.Color.Black;
            this.QueryColumnas.Appearance.RowCheckBoxes = true;
            this.QueryColumnas.Appearance.RowHeight = 18;
            this.QueryColumnas.Appearance.Title = "";
            this.QueryColumnas.Appearance.TuneElementSizes = false;
            this.QueryColumnas.BackColor = System.Drawing.Color.White;
            this.QueryColumnas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueryColumnas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryColumnas.Location = new System.Drawing.Point(0, 0);
            this.QueryColumnas.Model = null;
            this.QueryColumnas.Name = "QueryColumnas";
            this.QueryColumnas.Query = null;
            this.QueryColumnas.Size = new System.Drawing.Size(912, 264);
            this.QueryColumnas.TabIndex = 0;
            this.QueryColumnas.TabStop = true;
            // 
            // QueryCondiciones
            // 
            this.QueryCondiciones.Active = false;
            this.QueryCondiciones.ActiveRowIndex = -1;
            this.QueryCondiciones.Appearance.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.QueryCondiciones.Appearance.ActiveForeColor = System.Drawing.SystemColors.HighlightText;
            this.QueryCondiciones.Appearance.AdjustChildLevel = true;
            this.QueryCondiciones.Appearance.AttrElementFormat = "{attr}";
            this.QueryCondiciones.Appearance.ButtonActiveBodyColor = System.Drawing.Color.Gray;
            this.QueryCondiciones.Appearance.ButtonActiveBorderColor = System.Drawing.Color.Black;
            this.QueryCondiciones.Appearance.ButtonClickBodyColor = System.Drawing.Color.White;
            this.QueryCondiciones.Appearance.ButtonClickBorderColor = System.Drawing.Color.Black;
            this.QueryCondiciones.Appearance.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.QueryCondiciones.Appearance.ButtonInactiveBodyColor = System.Drawing.Color.Transparent;
            this.QueryCondiciones.Appearance.ButtonInactiveBorderColor = System.Drawing.Color.Black;
            this.QueryCondiciones.Appearance.ButtonRounded = true;
            this.QueryCondiciones.Appearance.EditMode = Korzh.EasyQuery.WinControls.QueryPanel.EditModeKind.All;
            this.QueryCondiciones.Appearance.ElementSpacing = 2;
            this.QueryCondiciones.Appearance.EmptyEditText = "";
            this.QueryCondiciones.Appearance.EmptyListText = "";
            this.QueryCondiciones.Appearance.LeftMargin = 2;
            this.QueryCondiciones.Appearance.LevelSpacing = 30;
            this.QueryCondiciones.Appearance.LinkColor = System.Drawing.Color.Blue;
            this.QueryCondiciones.Appearance.ReadOnlyColor = System.Drawing.Color.Black;
            this.QueryCondiciones.Appearance.RowCheckBoxes = true;
            this.QueryCondiciones.Appearance.RowHeight = 18;
            this.QueryCondiciones.Appearance.ShowRootRow = true;
            this.QueryCondiciones.Appearance.TuneElementSizes = false;
            this.QueryCondiciones.BackColor = System.Drawing.Color.White;
            this.QueryCondiciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueryCondiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryCondiciones.Location = new System.Drawing.Point(0, 0);
            this.QueryCondiciones.Model = null;
            this.QueryCondiciones.Name = "QueryCondiciones";
            this.QueryCondiciones.Query = null;
            this.QueryCondiciones.Size = new System.Drawing.Size(912, 171);
            this.QueryCondiciones.TabIndex = 0;
            this.QueryCondiciones.TabStop = true;
            // 
            // ModeloDatos
            // 
            this.ModeloDatos.CustomInfo = "";
            this.ModeloDatos.DefQueryFilePath = "";
            this.ModeloDatos.Description = null;
            this.ModeloDatos.ModelName = null;
            // 
            // ModeloQuery
            // 
            this.ModeloQuery.FilePath = "";
            this.ModeloQuery.Formats.DateFormat = "MM-dd-yyyy";
            this.ModeloQuery.Formats.DateTimeFormat = "MM-dd-yyyy HH:mm:ss";
            this.ModeloQuery.Formats.EOL = Korzh.EasyQuery.EOLSymbol.CRLF;
            this.ModeloQuery.Formats.OrderByStyle = Korzh.EasyQuery.OrderByStyles.Numbers;
            this.ModeloQuery.Formats.SqlSyntax = Korzh.EasyQuery.SqlSyntax.SQL2;
            this.ModeloQuery.Formats.UseColumnAliases = Korzh.EasyQuery.ColumnAliasesUsage.IfNecessary;
            this.ModeloQuery.Formats.WildSymbol = '%';
            this.ModeloQuery.Model = this.ModeloDatos;
            this.ModeloQuery.ColumnsChanged += new Korzh.EasyQuery.ColumnsChangedEventHandler(this.ModeloQuery_ColumnsChanged);
            this.ModeloQuery.ConditionsChanged += new Korzh.EasyQuery.ConditionsChangedEventHandler(this.ModeloQuery_ConditionsChanged);
            // 
            // barComandos
            // 
            this.barComandos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.barComandos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.btnExportar});
            this.barComandos.Location = new System.Drawing.Point(3, 3);
            this.barComandos.Name = "barComandos";
            this.barComandos.Size = new System.Drawing.Size(912, 25);
            this.barComandos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(23, 22);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.ToolTipText = "Actualizar resultados";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // GridResultados
            // 
            this.GridResultados.BackgroundColor = System.Drawing.Color.White;
            this.GridResultados.CaptionText = "Resultados";
            this.GridResultados.DataMember = "";
            this.GridResultados.DataSource = this.ResultadoDataTable;
            this.GridResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridResultados.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GridResultados.Location = new System.Drawing.Point(3, 3);
            this.GridResultados.Name = "GridResultados";
            this.GridResultados.ReadOnly = true;
            this.GridResultados.RowHeadersVisible = false;
            this.GridResultados.RowHeaderWidth = 15;
            this.GridResultados.Size = new System.Drawing.Size(912, 439);
            this.GridResultados.TabIndex = 2;
            this.GridResultados.DoubleClick += new System.EventHandler(this.GridResultados_DoubleClick);
            // 
            // ResultadoDataTable
            // 
            this.ResultadoDataTable.TableName = "Resultado";
            // 
            // ResultadoDS
            // 
            this.ResultadoDS.DataSetName = "ResultadoDataSet";
            this.ResultadoDS.Tables.AddRange(new System.Data.DataTable[] {
            this.ResultadoDataTable});
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabDefinicionConsulta);
            this.tabPrincipal.Controls.Add(this.tabResultados);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(926, 471);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabDefinicionConsulta
            // 
            this.tabDefinicionConsulta.Controls.Add(this.ContenedorSplit);
            this.tabDefinicionConsulta.Location = new System.Drawing.Point(4, 22);
            this.tabDefinicionConsulta.Name = "tabDefinicionConsulta";
            this.tabDefinicionConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefinicionConsulta.Size = new System.Drawing.Size(918, 445);
            this.tabDefinicionConsulta.TabIndex = 0;
            this.tabDefinicionConsulta.Text = "Definición de la consulta";
            this.tabDefinicionConsulta.UseVisualStyleBackColor = true;
            // 
            // tabResultados
            // 
            this.tabResultados.Controls.Add(this.barComandos);
            this.tabResultados.Controls.Add(this.GridResultados);
            this.tabResultados.Location = new System.Drawing.Point(4, 22);
            this.tabResultados.Name = "tabResultados";
            this.tabResultados.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultados.Size = new System.Drawing.Size(918, 445);
            this.tabResultados.TabIndex = 1;
            this.tabResultados.Text = "Resultados Obtenidos";
            this.tabResultados.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(23, 22);
            this.btnExportar.ToolTipText = "Exportar los resultados a excel";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // SAIFrmBuscadorIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(926, 493);
            this.Controls.Add(this.tabPrincipal);
            this.MinimumSize = new System.Drawing.Size(934, 527);
            this.Name = "SAIFrmBuscadorIncidencias";
            this.Text = "SAI - Buscador de Incidencias";
            this.Load += new System.EventHandler(this.SAIFrmBuscadorIncidencias_Load);
            this.Controls.SetChildIndex(this.tabPrincipal, 0);
            this.ContenedorSplit.Panel1.ResumeLayout(false);
            this.ContenedorSplit.Panel2.ResumeLayout(false);
            this.ContenedorSplit.ResumeLayout(false);
            this.barComandos.ResumeLayout(false);
            this.barComandos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultadoDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultadoDS)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tabDefinicionConsulta.ResumeLayout(false);
            this.tabResultados.ResumeLayout(false);
            this.tabResultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer ContenedorSplit;
        private Korzh.EasyQuery.DataModel ModeloDatos;
        private Korzh.EasyQuery.Query ModeloQuery;
        private Korzh.EasyQuery.WinControls.QueryColumnsPanel QueryColumnas;
        private Korzh.EasyQuery.WinControls.QueryPanel QueryCondiciones;
        private System.Data.DataSet ResultadoDS;
        private System.Data.DataTable ResultadoDataTable;
        private System.Windows.Forms.DataGrid GridResultados;
        private System.Windows.Forms.ToolStrip barComandos;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabDefinicionConsulta;
        private System.Windows.Forms.TabPage tabResultados;
        private System.Windows.Forms.ToolStripButton btnExportar;
    }
}
