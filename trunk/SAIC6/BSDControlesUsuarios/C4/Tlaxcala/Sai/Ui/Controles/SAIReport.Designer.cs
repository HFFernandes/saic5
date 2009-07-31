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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.barraHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCampos,
            this.toolStripSeparator1,
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
            this.btnCampos.Image = (Image)resources.GetObject("Folder Options");
            this.btnCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCampos.Name = "btnCampos";
            this.btnCampos.Size = new System.Drawing.Size(23, 22);
            this.btnCampos.Text = "Ocultar o Mostrar Campos";
            this.btnCampos.Click += new System.EventHandler(this.btnCampos_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
        private AxXtremeReportControl.AxReportControl reportControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblFiltroRegistros;
        private System.Windows.Forms.ToolStripTextBox txtFiltroRegistros;
        public System.Windows.Forms.ToolStripButton btnCampos;

    }
}
