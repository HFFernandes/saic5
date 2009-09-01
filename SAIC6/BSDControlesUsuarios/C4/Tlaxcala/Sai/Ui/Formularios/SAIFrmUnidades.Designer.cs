namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmUnidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmUnidades));
            this.axUnidadesDispuestasOcupadas = new AxXtremeReportControl.AxReportControl();
            ((System.ComponentModel.ISupportInitialize)(this.axUnidadesDispuestasOcupadas)).BeginInit();
            this.SuspendLayout();
            // 
            // axUnidadesDispuestasOcupadas
            // 
            this.axUnidadesDispuestasOcupadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axUnidadesDispuestasOcupadas.Location = new System.Drawing.Point(0, 0);
            this.axUnidadesDispuestasOcupadas.Name = "axUnidadesDispuestasOcupadas";
            this.axUnidadesDispuestasOcupadas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUnidadesDispuestasOcupadas.OcxState")));
            this.axUnidadesDispuestasOcupadas.Size = new System.Drawing.Size(484, 470);
            this.axUnidadesDispuestasOcupadas.TabIndex = 0;
            // 
            // SAIFrmUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 492);
            this.Controls.Add(this.axUnidadesDispuestasOcupadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SAIFrmUnidades";
            this.Text = "SAI - Unidades de las corporaciones.";
            this.Load += new System.EventHandler(this.SAIFrmUnidades_Load);
            this.Controls.SetChildIndex(this.axUnidadesDispuestasOcupadas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.axUnidadesDispuestasOcupadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxXtremeReportControl.AxReportControl axUnidadesDispuestasOcupadas;
    }
}