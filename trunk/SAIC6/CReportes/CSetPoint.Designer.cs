namespace BSD.C4.Tlaxcala.Sai
{
    partial class CSetPoint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSetPoint));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnFullExtend = new System.Windows.Forms.ToolStripButton();
            this.btnPanning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPoint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVerIncidencias = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShapeFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLongitud = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLatitud = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRowIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboCP = new System.Windows.Forms.ComboBox();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.cboColonia = new System.Windows.Forms.ComboBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboMunicipio = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mapa = new ActualMap.Windows.Map();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnFullExtend,
            this.btnPanning,
            this.toolStripSeparator1,
            this.btnPoint,
            this.toolStripSeparator2,
            this.btnVerIncidencias,
            this.toolStripSeparator3,
            this.btnShapeFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.SystemColors.Control;
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.zoomIn16;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.zoomOut16;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnFullExtend
            // 
            this.btnFullExtend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullExtend.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.zoomFull16;
            this.btnFullExtend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullExtend.Name = "btnFullExtend";
            this.btnFullExtend.Size = new System.Drawing.Size(23, 22);
            this.btnFullExtend.Text = "Full extend";
            this.btnFullExtend.Click += new System.EventHandler(this.btnFullExtend_Click);
            // 
            // btnPanning
            // 
            this.btnPanning.Checked = true;
            this.btnPanning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnPanning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPanning.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.hand16;
            this.btnPanning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPanning.Name = "btnPanning";
            this.btnPanning.Size = new System.Drawing.Size(23, 22);
            this.btnPanning.Text = "Panning";
            this.btnPanning.Click += new System.EventHandler(this.btnPanning_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPoint
            // 
            this.btnPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPoint.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.clip16;
            this.btnPoint.ImageTransparentColor = System.Drawing.Color.White;
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(23, 22);
            this.btnPoint.Text = "Punteo de incidencia";
            this.btnPoint.ToolTipText = "Punteo de incidencia";
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnVerIncidencias
            // 
            this.btnVerIncidencias.CheckOnClick = true;
            this.btnVerIncidencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVerIncidencias.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.satelite16;
            this.btnVerIncidencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerIncidencias.Name = "btnVerIncidencias";
            this.btnVerIncidencias.Size = new System.Drawing.Size(23, 22);
            this.btnVerIncidencias.Text = "Mostrar todas las incidencias";
            this.btnVerIncidencias.Click += new System.EventHandler(this.btnVerIncidencias_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShapeFile
            // 
            this.btnShapeFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShapeFile.Image = global::BSD.C4.Tlaxcala.Sai.Properties.Resources.shapefile16;
            this.btnShapeFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShapeFile.Name = "btnShapeFile";
            this.btnShapeFile.Size = new System.Drawing.Size(23, 22);
            this.btnShapeFile.Text = "Exportar a Shapefile";
            this.btnShapeFile.Click += new System.EventHandler(this.btnShapeFile_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Longitud:";
            // 
            // lblLongitud
            // 
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(13, 17);
            this.lblLongitud.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel3.Text = "Latitud";
            // 
            // lblLatitud
            // 
            this.lblLatitud.Name = "lblLatitud";
            this.lblLatitud.Size = new System.Drawing.Size(13, 17);
            this.lblLatitud.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "RowIndex";
            // 
            // lblRowIndex
            // 
            this.lblRowIndex.Name = "lblRowIndex";
            this.lblRowIndex.Size = new System.Drawing.Size(17, 17);
            this.lblRowIndex.Text = "-1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblLongitud,
            this.toolStripStatusLabel3,
            this.lblLatitud,
            this.toolStripStatusLabel2,
            this.lblRowIndex});
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(790, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 517);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 380);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(784, 134);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboCP);
            this.panel1.Controls.Add(this.lblCodigoPostal);
            this.panel1.Controls.Add(this.cboColonia);
            this.panel1.Controls.Add(this.lblColonia);
            this.panel1.Controls.Add(this.lblLocalidad);
            this.panel1.Controls.Add(this.cboLocalidad);
            this.panel1.Controls.Add(this.cboMunicipio);
            this.panel1.Controls.Add(this.lblMunicipio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 49);
            this.panel1.TabIndex = 5;
            // 
            // cboCP
            // 
            this.cboCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCP.Enabled = false;
            this.cboCP.FormattingEnabled = true;
            this.cboCP.Location = new System.Drawing.Point(601, 22);
            this.cboCP.Name = "cboCP";
            this.cboCP.Size = new System.Drawing.Size(150, 21);
            this.cboCP.TabIndex = 7;
            this.cboCP.SelectedIndexChanged += new System.EventHandler(this.cboCP_SelectedIndexChanged);
            this.cboCP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCP_KeyPress);
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(598, 7);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(72, 13);
            this.lblCodigoPostal.TabIndex = 6;
            this.lblCodigoPostal.Text = "Código Postal";
            // 
            // cboColonia
            // 
            this.cboColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColonia.Enabled = false;
            this.cboColonia.FormattingEnabled = true;
            this.cboColonia.Location = new System.Drawing.Point(409, 23);
            this.cboColonia.Name = "cboColonia";
            this.cboColonia.Size = new System.Drawing.Size(160, 21);
            this.cboColonia.TabIndex = 5;
            this.cboColonia.SelectedIndexChanged += new System.EventHandler(this.cboColonia_SelectedIndexChanged);
            this.cboColonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboColonia_KeyPress);
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(406, 7);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(42, 13);
            this.lblColonia.TabIndex = 4;
            this.lblColonia.Text = "Colonia";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(211, 7);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 3;
            this.lblLocalidad.Text = "Localidad";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.Enabled = false;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(214, 22);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(160, 21);
            this.cboLocalidad.TabIndex = 2;
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboLocalidad_SelectedIndexChanged);
            this.cboLocalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLocalidad_KeyPress);
            // 
            // cboMunicipio
            // 
            this.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMunicipio.Enabled = false;
            this.cboMunicipio.FormattingEnabled = true;
            this.cboMunicipio.Location = new System.Drawing.Point(20, 23);
            this.cboMunicipio.Name = "cboMunicipio";
            this.cboMunicipio.Size = new System.Drawing.Size(160, 21);
            this.cboMunicipio.TabIndex = 1;
            this.cboMunicipio.SelectedIndexChanged += new System.EventHandler(this.cboMunicipio_SelectedIndexChanged);
            this.cboMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMunicipio_KeyPress);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(17, 7);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(52, 13);
            this.lblMunicipio.TabIndex = 0;
            this.lblMunicipio.Text = "Municipio";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mapa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 316);
            this.panel2.TabIndex = 4;
            // 
            // mapa
            // 
            this.mapa.BackColor = System.Drawing.Color.White;
            this.mapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapa.EnableScrollWheelZoom = false;
            this.mapa.FontQuality = ActualMap.FontQuality.Default;
            this.mapa.Location = new System.Drawing.Point(0, 0);
            this.mapa.MapTool = ActualMap.Windows.MapTool.Pan;
            this.mapa.MapUnit = ActualMap.MeasureUnit.Degree;
            this.mapa.Name = "mapa";
            this.mapa.PixelPerInch = 96;
            this.mapa.ScaleBar.BarUnit = ActualMap.UnitSystem.Imperial;
            this.mapa.ScaleBar.FeetString = "ft";
            this.mapa.ScaleBar.Font.Alignment = ActualMap.TextAlign.Left;
            this.mapa.ScaleBar.Font.Bold = false;
            this.mapa.ScaleBar.Font.Charset = 1;
            this.mapa.ScaleBar.Font.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapa.ScaleBar.Font.Italic = false;
            this.mapa.ScaleBar.Font.Name = "Arial";
            this.mapa.ScaleBar.Font.Outline = false;
            this.mapa.ScaleBar.Font.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mapa.ScaleBar.Font.Size = 12;
            this.mapa.ScaleBar.Font.StrikeThrough = false;
            this.mapa.ScaleBar.Font.Underline = false;
            this.mapa.ScaleBar.KilometersString = "km";
            this.mapa.ScaleBar.MaxWidth = 0;
            this.mapa.ScaleBar.MetersString = "m";
            this.mapa.ScaleBar.MilesString = "mi";
            this.mapa.ScaleBar.Position = ActualMap.ScaleBarPosition.BottomRight;
            this.mapa.ScaleBar.Symbol.Bitmap = "";
            this.mapa.ScaleBar.Symbol.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mapa.ScaleBar.Symbol.FillStyle = ActualMap.FillStyle.Solid;
            this.mapa.ScaleBar.Symbol.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mapa.ScaleBar.Symbol.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mapa.ScaleBar.Symbol.LineStyle = ActualMap.LineStyle.Solid;
            this.mapa.ScaleBar.Symbol.PointStyle = ActualMap.PointStyle.Circle;
            this.mapa.ScaleBar.Symbol.Rotation = 0;
            this.mapa.ScaleBar.Symbol.Size = 1;
            this.mapa.ScaleBar.Symbol.TransparentColor = System.Drawing.Color.Empty;
            this.mapa.ScaleBar.Visible = false;
            this.mapa.Size = new System.Drawing.Size(784, 316);
            this.mapa.SmoothingMode = ActualMap.SmoothingMode.None;
            this.mapa.TabIndex = 4;
            this.mapa.ToolShape.FillColor = System.Drawing.Color.Transparent;
            this.mapa.ToolShape.LineColor = System.Drawing.Color.Red;
            this.mapa.PointTool += new ActualMap.Windows.PointToolEventHandler(this.mapa_PointTool);
            // 
            // CSetPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CSetPoint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SAI - Punteo de Incidencias.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CSetPoint_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnFullExtend;
        private System.Windows.Forms.ToolStripButton btnPanning;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPoint;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblLongitud;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblLatitud;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblRowIndex;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnVerIncidencias;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboCP;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.ComboBox cboColonia;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.ComboBox cboMunicipio;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Panel panel2;
        private ActualMap.Windows.Map mapa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnShapeFile;
    }
}