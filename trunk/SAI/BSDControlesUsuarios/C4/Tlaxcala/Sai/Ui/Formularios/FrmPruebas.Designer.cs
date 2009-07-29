namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class FrmPruebas
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
            this.saiTextBox1 = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTextBox2 = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saiTextBox1
            // 
            this.saiTextBox1.BlnEsRequerido = true;
            this.saiTextBox1.ClrBackColorFoco = System.Drawing.Color.Yellow;
            this.saiTextBox1.Location = new System.Drawing.Point(37, 27);
            this.saiTextBox1.Name = "saiTextBox1";
            this.saiTextBox1.Size = new System.Drawing.Size(100, 20);
            this.saiTextBox1.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTextBox1.TabIndex = 0;
            // 
            // saiTextBox2
            // 
            this.saiTextBox2.BlnEsRequerido = true;
            this.saiTextBox2.ClrBackColorFoco = System.Drawing.Color.Yellow;
            this.saiTextBox2.Location = new System.Drawing.Point(37, 83);
            this.saiTextBox2.Name = "saiTextBox2";
            this.saiTextBox2.Size = new System.Drawing.Size(100, 20);
            this.saiTextBox2.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTextBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPruebas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saiTextBox2);
            this.Controls.Add(this.saiTextBox1);
            this.Name = "FrmPruebas";
            this.Text = "FrmPruebas";
            this.Controls.SetChildIndex(this.saiTextBox1, 0);
            this.Controls.SetChildIndex(this.saiTextBox2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTextBox1;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTextBox2;
        private System.Windows.Forms.Button button1;
    }
}