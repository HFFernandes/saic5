namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmBase
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
            this.components = new System.ComponentModel.Container();
            this.SAIBarraEstado = new System.Windows.Forms.StatusStrip();
            this.SAIEtiquetaEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.SAIProveedorValidacion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIProveedorValidacion(this.components);
            this.SAIBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // SAIBarraEstado
            // 
            this.SAIBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SAIEtiquetaEstado});
            this.SAIBarraEstado.Location = new System.Drawing.Point(0, 423);
            this.SAIBarraEstado.Name = "SAIBarraEstado";
            this.SAIBarraEstado.Size = new System.Drawing.Size(552, 22);
            this.SAIBarraEstado.TabIndex = 2;
            this.SAIBarraEstado.Text = "statusStrip1";
            // 
            // SAIEtiquetaEstado
            // 
            this.SAIEtiquetaEstado.Name = "SAIEtiquetaEstado";
            this.SAIEtiquetaEstado.Size = new System.Drawing.Size(33, 17);
            this.SAIEtiquetaEstado.Text = "Listo.";
            // 
            // SAIFrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 445);
            this.Controls.Add(this.SAIBarraEstado);
            this.Name = "SAIFrmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAI - Base";
            this.SAIBarraEstado.ResumeLayout(false);
            this.SAIBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIProveedorValidacion SAIProveedorValidacion;
        public System.Windows.Forms.StatusStrip SAIBarraEstado;
        public System.Windows.Forms.ToolStripStatusLabel SAIEtiquetaEstado;
    }
}