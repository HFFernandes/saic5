using XtremeReportControl;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    partial class SAICamposReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAICamposReportControl));
            this.axFieldChooser1 = new AxXtremeReportControl.AxFieldChooser();
            ((System.ComponentModel.ISupportInitialize)(this.axFieldChooser1)).BeginInit();
            this.SuspendLayout();
            // 
            // axFieldChooser1
            // 
            this.axFieldChooser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFieldChooser1.Location = new System.Drawing.Point(0, 0);
            this.axFieldChooser1.Name = "axFieldChooser1";
            this.axFieldChooser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFieldChooser1.OcxState")));
            this.axFieldChooser1.Size = new System.Drawing.Size(167, 252);
            this.axFieldChooser1.TabIndex = 0;
            // 
            // SAICamposReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 252);
            this.Controls.Add(this.axFieldChooser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SAICamposReportControl";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAI - Campos Adicionales";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SAICamposReportControl_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAICamposReportControl_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axFieldChooser1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxXtremeReportControl.AxFieldChooser axFieldChooser1;



    }
}