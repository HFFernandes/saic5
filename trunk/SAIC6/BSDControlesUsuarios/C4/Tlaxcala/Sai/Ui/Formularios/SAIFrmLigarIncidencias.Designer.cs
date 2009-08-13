namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmLigarIncidencias
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.saiCmbFolioPadre = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 9);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(257, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Indique el número de folio padre para realizar el ligue.";
            // 
            // saiCmbFolioPadre
            // 
            this.saiCmbFolioPadre.BlnEsRequerido = true;
            this.saiCmbFolioPadre.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiCmbFolioPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saiCmbFolioPadre.FormattingEnabled = true;
            this.saiCmbFolioPadre.Location = new System.Drawing.Point(15, 25);
            this.saiCmbFolioPadre.Name = "saiCmbFolioPadre";
            this.saiCmbFolioPadre.Size = new System.Drawing.Size(254, 21);
            this.saiCmbFolioPadre.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiCmbFolioPadre.TabIndex = 1;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(194, 62);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 2;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(113, 62);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 3;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // SAIFrmLigarIncidencias
            // 
            this.AcceptButton = this.cmdAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.saiCmbFolioPadre);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmLigarIncidencias";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAI - Ligar Incidencias";
            this.Controls.SetChildIndex(this.cmdAceptar, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.saiCmbFolioPadre, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescripcion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox saiCmbFolioPadre;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
    }
}
