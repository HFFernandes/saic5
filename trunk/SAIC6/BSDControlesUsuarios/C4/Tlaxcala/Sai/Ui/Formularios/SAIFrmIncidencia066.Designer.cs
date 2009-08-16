namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIncidencia066
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
            this.label12 = new System.Windows.Forms.Label();
            this.cklCorporacion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAICheckedListBox(this.components);
            this.grpDenunciante = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDenuncianteDireccion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidoDenunciante = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreDenunciante = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpDenunciante.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Corporación:";
            // 
            // cklCorporacion
            // 
            this.cklCorporacion.CheckOnClick = true;
            this.cklCorporacion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.cklCorporacion.FormattingEnabled = true;
            this.cklCorporacion.Location = new System.Drawing.Point(97, 366);
            this.cklCorporacion.Name = "cklCorporacion";
            this.cklCorporacion.ScrollAlwaysVisible = true;
            this.cklCorporacion.Size = new System.Drawing.Size(486, 94);
            this.cklCorporacion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cklCorporacion.TabIndex = 25;
            this.cklCorporacion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cklCorporacion_MouseUp);
            this.cklCorporacion.Leave += new System.EventHandler(this.cklCorporacion_Leave);
            this.cklCorporacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cklCorporacion_KeyUp);
            // 
            // grpDenunciante
            // 
            this.grpDenunciante.Controls.Add(this.label21);
            this.grpDenunciante.Controls.Add(this.txtDenuncianteDireccion);
            this.grpDenunciante.Controls.Add(this.label4);
            this.grpDenunciante.Controls.Add(this.txtApellidoDenunciante);
            this.grpDenunciante.Controls.Add(this.label3);
            this.grpDenunciante.Controls.Add(this.txtNombreDenunciante);
            this.grpDenunciante.Location = new System.Drawing.Point(9, 466);
            this.grpDenunciante.Name = "grpDenunciante";
            this.grpDenunciante.Size = new System.Drawing.Size(576, 64);
            this.grpDenunciante.TabIndex = 26;
            this.grpDenunciante.TabStop = false;
            this.grpDenunciante.Text = "Denunciante";
            this.grpDenunciante.Enter += new System.EventHandler(this.grpDenunciante_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 45);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Dirección:";
            // 
            // txtDenuncianteDireccion
            // 
            this.txtDenuncianteDireccion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDenuncianteDireccion.Location = new System.Drawing.Point(83, 38);
            this.txtDenuncianteDireccion.MaxLength = 500;
            this.txtDenuncianteDireccion.Name = "txtDenuncianteDireccion";
            this.txtDenuncianteDireccion.Size = new System.Drawing.Size(484, 20);
            this.txtDenuncianteDireccion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDenuncianteDireccion.TabIndex = 5;
            this.txtDenuncianteDireccion.Leave += new System.EventHandler(this.txtDenuncianteDireccion_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Apellido:";
            // 
            // txtApellidoDenunciante
            // 
            this.txtApellidoDenunciante.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtApellidoDenunciante.Location = new System.Drawing.Point(328, 13);
            this.txtApellidoDenunciante.MaxLength = 50;
            this.txtApellidoDenunciante.Name = "txtApellidoDenunciante";
            this.txtApellidoDenunciante.Size = new System.Drawing.Size(239, 20);
            this.txtApellidoDenunciante.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtApellidoDenunciante.TabIndex = 3;
            this.txtApellidoDenunciante.Leave += new System.EventHandler(this.txtApellidoDenunciante_Leave);
            this.txtApellidoDenunciante.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApellidoDenunciante_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nombre:";
            // 
            // txtNombreDenunciante
            // 
            this.txtNombreDenunciante.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombreDenunciante.Location = new System.Drawing.Point(83, 13);
            this.txtNombreDenunciante.MaxLength = 50;
            this.txtNombreDenunciante.Name = "txtNombreDenunciante";
            this.txtNombreDenunciante.Size = new System.Drawing.Size(174, 20);
            this.txtNombreDenunciante.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtNombreDenunciante.TabIndex = 1;
            this.txtNombreDenunciante.Leave += new System.EventHandler(this.txtNombreDenunciante_Leave);
            this.txtNombreDenunciante.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombreDenunciante_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Dirección:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(277, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Apellido:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nombre:";
            // 
            // SAIFrmIncidencia066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 772);
            this.Controls.Add(this.grpDenunciante);
            this.Controls.Add(this.cklCorporacion);
            this.Controls.Add(this.label12);
            this.Name = "SAIFrmIncidencia066";
            this.Text = "SAIFrmIncidencia066";
            this.Load += new System.EventHandler(this.SAIFrmIncidencia066_Load);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.cklCorporacion, 0);
            this.Controls.SetChildIndex(this.grpDenunciante, 0);
            this.grpDenunciante.ResumeLayout(false);
            this.grpDenunciante.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAICheckedListBox cklCorporacion;
        private System.Windows.Forms.GroupBox grpDenunciante;
        private System.Windows.Forms.Label label14;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtNombreDenunciante;
        private System.Windows.Forms.Label label13;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtApellidoDenunciante;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDenuncianteDireccion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}