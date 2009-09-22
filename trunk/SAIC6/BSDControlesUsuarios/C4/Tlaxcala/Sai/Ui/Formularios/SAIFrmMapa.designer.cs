namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmMapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmMapa));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnFullExtend = new System.Windows.Forms.ToolStripButton();
            this.btnPanning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLeyenda = new System.Windows.Forms.ToolStripLabel();
            this.contenedorMapa = new System.Windows.Forms.SplitContainer();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.mapa = new ActualMap.Windows.Map();
            this.leyenda = new ActualMap.Windows.Legend();
            this.toolStrip1.SuspendLayout();
            this.contenedorMapa.Panel1.SuspendLayout();
            this.contenedorMapa.Panel2.SuspendLayout();
            this.contenedorMapa.SuspendLayout();
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
            this.btnLeyenda});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(592, 25);
            this.toolStrip1.TabIndex = 6;
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
            this.btnFullExtend.Click += new System.EventHandler(this.mnuFullExtend_Click);
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
            // btnLeyenda
            // 
            this.btnLeyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLeyenda.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLeyenda.Name = "btnLeyenda";
            this.btnLeyenda.Size = new System.Drawing.Size(106, 22);
            this.btnLeyenda.Text = "Mostrar leyendas";
            this.btnLeyenda.Click += new System.EventHandler(this.btnLeyenda_Click);
            // 
            // contenedorMapa
            // 
            this.contenedorMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedorMapa.Location = new System.Drawing.Point(0, 25);
            this.contenedorMapa.Name = "contenedorMapa";
            // 
            // contenedorMapa.Panel1
            // 
            this.contenedorMapa.Panel1.Controls.Add(this.lblUpdate);
            this.contenedorMapa.Panel1.Controls.Add(this.mapa);
            // 
            // contenedorMapa.Panel2
            // 
            this.contenedorMapa.Panel2.Controls.Add(this.leyenda);
            this.contenedorMapa.Size = new System.Drawing.Size(592, 341);
            this.contenedorMapa.SplitterDistance = 450;
            this.contenedorMapa.TabIndex = 7;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblUpdate.Location = new System.Drawing.Point(240, 181);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(128, 20);
            this.lblUpdate.TabIndex = 2;
            this.lblUpdate.Text = "Actualizando...";
            this.lblUpdate.Visible = false;
            // 
            // mapa
            // 
            this.mapa.BackColor = System.Drawing.Color.White;
            this.mapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapa.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.mapa.Size = new System.Drawing.Size(450, 341);
            this.mapa.SmoothingMode = ActualMap.SmoothingMode.None;
            this.mapa.TabIndex = 1;
            this.mapa.ToolShape.FillColor = System.Drawing.Color.Transparent;
            this.mapa.ToolShape.LineColor = System.Drawing.Color.Red;
            // 
            // leyenda
            // 
            this.leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leyenda.IconHeight = 16;
            this.leyenda.IconWidth = 20;
            this.leyenda.Location = new System.Drawing.Point(0, 0);
            this.leyenda.Name = "leyenda";
            this.leyenda.Size = new System.Drawing.Size(138, 341);
            this.leyenda.TabIndex = 2;
            // 
            // SAIFrmMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.ControlBox = false;
            this.Controls.Add(this.contenedorMapa);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "SAIFrmMapa";
            this.Text = "SAI - Mapa";
            this.Deactivate += new System.EventHandler(this.CMapa_Deactivate);
            this.Load += new System.EventHandler(this.CMapa_Load);
            this.Activated += new System.EventHandler(this.CMapa_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contenedorMapa.Panel1.ResumeLayout(false);
            this.contenedorMapa.Panel1.PerformLayout();
            this.contenedorMapa.Panel2.ResumeLayout(false);
            this.contenedorMapa.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripLabel btnLeyenda;
        private System.Windows.Forms.SplitContainer contenedorMapa;
        private ActualMap.Windows.Map mapa;
        private ActualMap.Windows.Legend leyenda;
        private System.Windows.Forms.Label lblUpdate;
    }
}