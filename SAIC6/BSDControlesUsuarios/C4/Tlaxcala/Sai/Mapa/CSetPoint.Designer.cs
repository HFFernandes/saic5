namespace BSD.C4.Tlaxcala.Sai.Mapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSetPoint));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnFullExtend = new System.Windows.Forms.ToolStripButton();
            this.btnPanning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPoint = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLongitud = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLatitud = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRowIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.cboColonia = new System.Windows.Forms.ComboBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboMunicipio = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mapa = new ActualMap.Windows.Map();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIncidencias = new System.Windows.Forms.CheckBox();
            this.cboCP = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.btnPoint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnFullExtend
            // 
            this.btnFullExtend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullExtend.Image = ((System.Drawing.Image)(resources.GetObject("btnFullExtend.Image")));
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
            this.btnPanning.Image = ((System.Drawing.Image)(resources.GetObject("btnPanning.Image")));
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
            this.btnPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnPoint.Image")));
            this.btnPoint.ImageTransparentColor = System.Drawing.Color.White;
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(23, 22);
            this.btnPoint.Text = "toolStripButton1";
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mapa, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.2719F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.7281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 519);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
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
            this.panel1.Location = new System.Drawing.Point(3, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 50);
            this.panel1.TabIndex = 0;
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
            this.cboColonia.FormattingEnabled = true;
            this.cboColonia.Location = new System.Drawing.Point(409, 23);
            this.cboColonia.Name = "cboColonia";
            this.cboColonia.Size = new System.Drawing.Size(160, 21);
            this.cboColonia.TabIndex = 5;
            this.cboColonia.SelectedIndexChanged += new System.EventHandler(this.cboColonia_SelectedIndexChanged);
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
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(214, 22);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(160, 21);
            this.cboLocalidad.TabIndex = 2;
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboLocalidad_SelectedIndexChanged);
            // 
            // cboMunicipio
            // 
            this.cboMunicipio.FormattingEnabled = true;
            this.cboMunicipio.Location = new System.Drawing.Point(20, 23);
            this.cboMunicipio.Name = "cboMunicipio";
            this.cboMunicipio.Size = new System.Drawing.Size(160, 21);
            this.cboMunicipio.TabIndex = 1;
            this.cboMunicipio.SelectedIndexChanged += new System.EventHandler(this.cboMunicipio_SelectedIndexChanged);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(786, 126);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter_2);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // mapa
            // 
            this.mapa.BackColor = System.Drawing.Color.White;
            this.mapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapa.FontQuality = ActualMap.FontQuality.Default;
            this.mapa.Location = new System.Drawing.Point(3, 37);
            this.mapa.MapTool = ActualMap.Windows.MapTool.ZoomIn;
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
            this.mapa.Size = new System.Drawing.Size(786, 291);
            this.mapa.SmoothingMode = ActualMap.SmoothingMode.None;
            this.mapa.TabIndex = 3;
            this.mapa.ToolShape.FillColor = System.Drawing.Color.Transparent;
            this.mapa.ToolShape.LineColor = System.Drawing.Color.Red;
            this.mapa.Click += new System.EventHandler(this.mapa_Click_1);
            this.mapa.PointTool += new ActualMap.Windows.PointToolEventHandler(this.mapa_PointTool_2);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkIncidencias);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 28);
            this.panel2.TabIndex = 4;
            // 
            // chkIncidencias
            // 
            this.chkIncidencias.AutoSize = true;
            this.chkIncidencias.Location = new System.Drawing.Point(8, 6);
            this.chkIncidencias.Name = "chkIncidencias";
            this.chkIncidencias.Size = new System.Drawing.Size(226, 17);
            this.chkIncidencias.TabIndex = 0;
            this.chkIncidencias.Text = "Visualizar todas las incidencias en el mapa";
            this.chkIncidencias.UseVisualStyleBackColor = true;
            // 
            // cboCP
            // 
            this.cboCP.FormattingEnabled = true;
            this.cboCP.Location = new System.Drawing.Point(601, 22);
            this.cboCP.Name = "cboCP";
            this.cboCP.Size = new System.Drawing.Size(150, 21);
            this.cboCP.TabIndex = 7;
            this.cboCP.SelectedIndexChanged += new System.EventHandler(this.cboCP_SelectedIndexChanged);
            // 
            // CSetPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CSetPoint";
            this.Text = "Seleciona punto de incidencia";
            this.Load += new System.EventHandler(this.CSetPoint_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.ComboBox cboColonia;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.ComboBox cboMunicipio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ActualMap.Windows.Map mapa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkIncidencias;
        private System.Windows.Forms.ComboBox cboCP;
    }
}