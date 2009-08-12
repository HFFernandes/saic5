using System.Drawing;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    partial class SAIReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIReport));
            this.reportControl = new AxXtremeReportControl.AxReportControl();
            this.barraHerramientas = new System.Windows.Forms.ToolStrip();
            this.btnCampos = new System.Windows.Forms.ToolStripButton();
            this.btnSeparador1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLigarIncidencias = new System.Windows.Forms.ToolStripButton();
            this.btnDespacharIncidencias = new System.Windows.Forms.ToolStripButton();
            this.btnSeparador2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBajaUnidad = new System.Windows.Forms.ToolStripButton();
            this.btnAltaUnidad = new System.Windows.Forms.ToolStripButton();
            this.btnSeparador3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFiltroRegistros = new System.Windows.Forms.ToolStripLabel();
            this.txtFiltroRegistros = new System.Windows.Forms.ToolStripTextBox();
            this.reportContenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.reportControl)).BeginInit();
            this.barraHerramientas.SuspendLayout();
            this.reportContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportControl
            // 
            this.reportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportControl.Location = new System.Drawing.Point(0, 0);
            this.reportControl.Name = "reportControl";
            this.reportControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reportControl.OcxState")));
            this.reportControl.Size = new System.Drawing.Size(446, 173);
            this.reportControl.TabIndex = 0;
            // 
            // barraHerramientas
            // 
            this.barraHerramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.barraHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCampos,
            this.btnSeparador1,
            this.btnLigarIncidencias,
            this.btnDespacharIncidencias,
            this.btnSeparador2,
            this.btnBajaUnidad,
            this.btnAltaUnidad,
            this.btnSeparador3,
            this.lblFiltroRegistros,
            this.txtFiltroRegistros});
            this.barraHerramientas.Location = new System.Drawing.Point(0, 0);
            this.barraHerramientas.Name = "barraHerramientas";
            this.barraHerramientas.Size = new System.Drawing.Size(446, 25);
            this.barraHerramientas.TabIndex = 1;
            this.barraHerramientas.Text = "toolStrip1";
            // 
            // btnCampos
            // 
            this.btnCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCampos.Image = ((System.Drawing.Image)(resources.GetObject("btnCampos.Image")));
            this.btnCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCampos.Name = "btnCampos";
            this.btnCampos.Size = new System.Drawing.Size(23, 22);
            this.btnCampos.ToolTipText = "Mostrar u ocultar campos";
            this.btnCampos.Click += new System.EventHandler(this.btnCampos_Click);
            // 
            // btnSeparador1
            // 
            this.btnSeparador1.Name = "btnSeparador1";
            this.btnSeparador1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLigarIncidencias
            // 
            this.btnLigarIncidencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLigarIncidencias.Image = ((System.Drawing.Image)(resources.GetObject("btnLigarIncidencias.Image")));
            this.btnLigarIncidencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLigarIncidencias.Name = "btnLigarIncidencias";
            this.btnLigarIncidencias.Size = new System.Drawing.Size(23, 22);
            this.btnLigarIncidencias.ToolTipText = "Ligar incidencias";
            // 
            // btnDespacharIncidencias
            // 
            this.btnDespacharIncidencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDespacharIncidencias.Image = ((System.Drawing.Image)(resources.GetObject("btnDespacharIncidencias.Image")));
            this.btnDespacharIncidencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDespacharIncidencias.Name = "btnDespacharIncidencias";
            this.btnDespacharIncidencias.Size = new System.Drawing.Size(23, 22);
            this.btnDespacharIncidencias.ToolTipText = "Despachar incidencia(s)";
            // 
            // btnSeparador2
            // 
            this.btnSeparador2.Name = "btnSeparador2";
            this.btnSeparador2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBajaUnidad
            // 
            this.btnBajaUnidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBajaUnidad.Image = ((System.Drawing.Image)(resources.GetObject("btnBajaUnidad.Image")));
            this.btnBajaUnidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBajaUnidad.Name = "btnBajaUnidad";
            this.btnBajaUnidad.Size = new System.Drawing.Size(23, 22);
            this.btnBajaUnidad.ToolTipText = "Borrar unidad";
            // 
            // btnAltaUnidad
            // 
            this.btnAltaUnidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAltaUnidad.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaUnidad.Image")));
            this.btnAltaUnidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAltaUnidad.Name = "btnAltaUnidad";
            this.btnAltaUnidad.Size = new System.Drawing.Size(23, 22);
            this.btnAltaUnidad.ToolTipText = "Agregar unidad";
            // 
            // btnSeparador3
            // 
            this.btnSeparador3.Name = "btnSeparador3";
            this.btnSeparador3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblFiltroRegistros
            // 
            this.lblFiltroRegistros.Name = "lblFiltroRegistros";
            this.lblFiltroRegistros.Size = new System.Drawing.Size(31, 22);
            this.lblFiltroRegistros.Text = "Filtro";
            // 
            // txtFiltroRegistros
            // 
            this.txtFiltroRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroRegistros.Name = "txtFiltroRegistros";
            this.txtFiltroRegistros.Size = new System.Drawing.Size(100, 25);
            this.txtFiltroRegistros.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroRegistros_KeyUp);
            // 
            // reportContenedor
            // 
            this.reportContenedor.Controls.Add(this.reportControl);
            this.reportContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportContenedor.Location = new System.Drawing.Point(0, 25);
            this.reportContenedor.Name = "reportContenedor";
            this.reportContenedor.Size = new System.Drawing.Size(446, 173);
            this.reportContenedor.TabIndex = 2;
            // 
            // SAIReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportContenedor);
            this.Controls.Add(this.barraHerramientas);
            this.Name = "SAIReport";
            this.Size = new System.Drawing.Size(446, 198);
            ((System.ComponentModel.ISupportInitialize)(this.reportControl)).EndInit();
            this.barraHerramientas.ResumeLayout(false);
            this.barraHerramientas.PerformLayout();
            this.reportContenedor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraHerramientas;
        private System.Windows.Forms.Panel reportContenedor;
        private System.Windows.Forms.ToolStripLabel lblFiltroRegistros;
        private System.Windows.Forms.ToolStripTextBox txtFiltroRegistros;
        public System.Windows.Forms.ToolStripButton btnCampos;
        public System.Windows.Forms.ToolStripButton btnLigarIncidencias;
        public AxXtremeReportControl.AxReportControl reportControl;
        public System.Windows.Forms.ToolStripButton btnDespacharIncidencias;
        public System.Windows.Forms.ToolStripButton btnBajaUnidad;
        public System.Windows.Forms.ToolStripButton btnAltaUnidad;
        public System.Windows.Forms.ToolStripSeparator btnSeparador3;
        public System.Windows.Forms.ToolStripSeparator btnSeparador1;
        public System.Windows.Forms.ToolStripSeparator btnSeparador2;

    }
}
