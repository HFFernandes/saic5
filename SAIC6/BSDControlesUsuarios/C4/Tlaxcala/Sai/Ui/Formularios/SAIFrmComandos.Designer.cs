namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmComandos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmComandos));
            this.SAIBarraComandos = new AxXtremeCommandBars.AxCommandBars();
            this.imgAdministrador = new AxXtremeCommandBars.AxImageManager();
            ((System.ComponentModel.ISupportInitialize)(this.SAIBarraComandos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAdministrador)).BeginInit();
            this.SuspendLayout();
            // 
            // SAIBarraComandos
            // 
            this.SAIBarraComandos.Enabled = true;
            this.SAIBarraComandos.Location = new System.Drawing.Point(12, 12);
            this.SAIBarraComandos.Name = "SAIBarraComandos";
            this.SAIBarraComandos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SAIBarraComandos.OcxState")));
            this.SAIBarraComandos.Size = new System.Drawing.Size(24, 24);
            this.SAIBarraComandos.TabIndex = 0;
            // 
            // imgAdministrador
            // 
            this.imgAdministrador.Enabled = true;
            this.imgAdministrador.Location = new System.Drawing.Point(42, 12);
            this.imgAdministrador.Name = "imgAdministrador";
            this.imgAdministrador.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("imgAdministrador.OcxState")));
            this.imgAdministrador.Size = new System.Drawing.Size(24, 24);
            this.imgAdministrador.TabIndex = 1;
            // 
            // SAIFrmComandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(108, 88);
            this.Controls.Add(this.imgAdministrador);
            this.Controls.Add(this.SAIBarraComandos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmComandos";
            this.ShowInTaskbar = false;
            this.Text = "SAI - Comandos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SAIFrmComandos_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SAIFrmComandos_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmComandos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SAIBarraComandos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAdministrador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxXtremeCommandBars.AxCommandBars SAIBarraComandos;
        private AxXtremeCommandBars.AxImageManager imgAdministrador;
    }
}