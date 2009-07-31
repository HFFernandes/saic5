
using System.Collections.Generic;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmVentana
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
        private void InitializeComponent(List<SAIWinSwitchItem> Elementos, Form Owner)
        {
            this.winSwitch1 = new SAIWinSwitch(Elementos, Owner);
            this.SuspendLayout();
            // 
            // winSwitch1
            // 
            this.winSwitch1.Location = new System.Drawing.Point(12, 12);
            this.winSwitch1.Name = "winSwitch1";
            this.winSwitch1.Size = new System.Drawing.Size(447, 264);
            this.winSwitch1.TabIndex = 0;
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 288);
            this.Controls.Add(this.winSwitch1);
            this.Name = "Ventana";
            this.Text = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);


        }

        private void InitializeComponent()
        {
            this.winSwitch1 = new SAIWinSwitch();
            this.SuspendLayout();
            // 
            // winSwitch1
            // 
            this.winSwitch1.Location = new System.Drawing.Point(2, 1);
            this.winSwitch1.Name = "winSwitch1";
            this.winSwitch1.Size = new System.Drawing.Size(406, 226);
            this.winSwitch1.TabIndex = 0;
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 204);
            this.Controls.Add(this.winSwitch1);
            this.Name = "SAIFrmVentana";
            this.Text = "Form5";
            this.ResumeLayout(false);

        }

        #endregion

        private SAIWinSwitch winSwitch1;
    }
}