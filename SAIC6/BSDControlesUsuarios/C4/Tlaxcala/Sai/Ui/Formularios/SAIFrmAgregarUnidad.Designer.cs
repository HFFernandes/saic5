namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmAgregarUnidad
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
            this.lblCodigoUnidad = new System.Windows.Forms.Label();
            this.saiTxtUnidad = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCodigoUnidad
            // 
            this.lblCodigoUnidad.AutoSize = true;
            this.lblCodigoUnidad.Location = new System.Drawing.Point(12, 9);
            this.lblCodigoUnidad.Name = "lblCodigoUnidad";
            this.lblCodigoUnidad.Size = new System.Drawing.Size(103, 13);
            this.lblCodigoUnidad.TabIndex = 0;
            this.lblCodigoUnidad.Text = "&Código de la Unidad";
            // 
            // saiTxtUnidad
            // 
            this.saiTxtUnidad.BlnEsRequerido = true;
            this.saiTxtUnidad.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtUnidad.Location = new System.Drawing.Point(15, 25);
            this.saiTxtUnidad.Name = "saiTxtUnidad";
            this.saiTxtUnidad.Size = new System.Drawing.Size(215, 20);
            this.saiTxtUnidad.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtUnidad.TabIndex = 1;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(155, 65);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 2;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(74, 65);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 3;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // SAIFrmAgregarUnidad
            // 
            this.AcceptButton = this.cmdAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(247, 122);
            this.Controls.Add(this.saiTxtUnidad);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.lblCodigoUnidad);
            this.Controls.Add(this.cmdCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmAgregarUnidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAI - Agregar Unidad";
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.lblCodigoUnidad, 0);
            this.Controls.SetChildIndex(this.cmdAceptar, 0);
            this.Controls.SetChildIndex(this.saiTxtUnidad, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigoUnidad;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtUnidad;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
    }
}
