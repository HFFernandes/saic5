namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIncidenciasPendientes
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
            this.saiReport1 = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIReport();
            this.tmrRegistros = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // saiReport1
            // 
            this.saiReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saiReport1.Location = new System.Drawing.Point(0, 0);
            this.saiReport1.Name = "saiReport1";
            this.saiReport1.Size = new System.Drawing.Size(647, 274);
            this.saiReport1.TabIndex = 0;
            // 
            // tmrRegistros
            // 
            this.tmrRegistros.Enabled = true;
            this.tmrRegistros.Interval = 1500;
            this.tmrRegistros.Tick += new System.EventHandler(this.tmrRegistros_Tick);
            // 
            // SAIFrmIncidenciasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 296);
            this.Controls.Add(this.saiReport1);
            this.Name = "SAIFrmIncidenciasPendientes";
            this.Text = "SAI - Incidencias Pendientes";
            this.Load += new System.EventHandler(this.SAIFrmIncidenciasPendientes_Load);
            this.Controls.SetChildIndex(this.saiReport1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIReport saiReport1;
        private System.Windows.Forms.Timer tmrRegistros;
    }
}