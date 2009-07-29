using System.ComponentModel;
using System.Drawing;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    partial class SAILogoControl
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
            System.ComponentModel.ComponentResourceManager resources=new ComponentResourceManager(typeof(SAILogoControl));
            this.spinnerPicture = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAISpinnerBox();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // spinnerPicture
            // 
            this.spinnerPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spinnerPicture.Intervalo = 33;
            this.spinnerPicture.Image = (Image) resources.GetObject("Connection_band");
            this.spinnerPicture.Location = new System.Drawing.Point(0, 67);
            this.spinnerPicture.Name = "spinnerPicture";
            this.spinnerPicture.Size = new System.Drawing.Size(410, 3);
            this.spinnerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spinnerPicture.TabIndex = 1;
            this.spinnerPicture.TabStop = false;
            this.spinnerPicture.Velocidad = 1;
            // 
            // logoPicture
            // 
            this.logoPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPicture.Image = (Image)resources.GetObject("Server_Connection2");
            this.logoPicture.Location = new System.Drawing.Point(0, 0);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(410, 67);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoPicture.TabIndex = 0;
            this.logoPicture.TabStop = false;
            // 
            // SAILogoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinnerPicture);
            this.Controls.Add(this.logoPicture);
            this.Name = "SAILogoControl";
            this.Size = new System.Drawing.Size(410, 70);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private SAISpinnerBox spinnerPicture;
    }
}
