namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIncidencia089
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
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumeroOficio = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.dtmFechaEnvioDependencia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker(this.components);
            this.dtmFechaDocumento = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker(this.components);
            this.dtmFechaNotificacion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker(this.components);
            this.chkFechaEnvio = new System.Windows.Forms.CheckBox();
            this.chkFechaDocumento = new System.Windows.Forms.CheckBox();
            this.chkFechaNotificacion = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDependencia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.txtAlias = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 26);
            this.label11.TabIndex = 25;
            this.label11.Text = "Fecha de Envío\r\na Dependencia";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(319, 391);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 26);
            this.label12.TabIndex = 28;
            this.label12.Text = "Fecha del\r\nDocumento:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 418);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 26);
            this.label13.TabIndex = 31;
            this.label13.Text = "Fecha de\r\nNotificación:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(318, 416);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 26);
            this.label14.TabIndex = 27;
            this.label14.Text = "Número de Oficio\r\nPara Envío:";
            // 
            // txtNumeroOficio
            // 
            this.txtNumeroOficio.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNumeroOficio.Location = new System.Drawing.Point(414, 418);
            this.txtNumeroOficio.MaxLength = 50;
            this.txtNumeroOficio.Name = "txtNumeroOficio";
            this.txtNumeroOficio.Size = new System.Drawing.Size(169, 20);
            this.txtNumeroOficio.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtNumeroOficio.TabIndex = 34;
            this.txtNumeroOficio.Leave += new System.EventHandler(this.txtNumeroOficio_Leave);
            // 
            // dtmFechaEnvioDependencia
            // 
            this.dtmFechaEnvioDependencia.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtmFechaEnvioDependencia.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dtmFechaEnvioDependencia.CustomFormat = "dd/MM/yyyy";
            this.dtmFechaEnvioDependencia.Enabled = false;
            this.dtmFechaEnvioDependencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaEnvioDependencia.Location = new System.Drawing.Point(97, 393);
            this.dtmFechaEnvioDependencia.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtmFechaEnvioDependencia.Name = "dtmFechaEnvioDependencia";
            this.dtmFechaEnvioDependencia.Size = new System.Drawing.Size(110, 20);
            this.dtmFechaEnvioDependencia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.dtmFechaEnvioDependencia.TabIndex = 26;
            this.dtmFechaEnvioDependencia.Leave += new System.EventHandler(this.dtmFechaEnvioDependencia_Leave);
            this.dtmFechaEnvioDependencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtmFechaEnvioDependencia_KeyUp);
            // 
            // dtmFechaDocumento
            // 
            this.dtmFechaDocumento.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtmFechaDocumento.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dtmFechaDocumento.CustomFormat = "dd/MM/yyyy";
            this.dtmFechaDocumento.Enabled = false;
            this.dtmFechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaDocumento.Location = new System.Drawing.Point(415, 393);
            this.dtmFechaDocumento.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtmFechaDocumento.Name = "dtmFechaDocumento";
            this.dtmFechaDocumento.Size = new System.Drawing.Size(110, 20);
            this.dtmFechaDocumento.StrMensajeCampoRequerido = "El campo es requerido.";
            this.dtmFechaDocumento.TabIndex = 29;
            this.dtmFechaDocumento.Value = new System.DateTime(2009, 8, 8, 0, 0, 0, 0);
            this.dtmFechaDocumento.Leave += new System.EventHandler(this.dtmFechaDocumento_Leave);
            this.dtmFechaDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtmFechaDocumento_KeyUp);
            // 
            // dtmFechaNotificacion
            // 
            this.dtmFechaNotificacion.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtmFechaNotificacion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dtmFechaNotificacion.CustomFormat = "dd/MM/yyyy";
            this.dtmFechaNotificacion.Enabled = false;
            this.dtmFechaNotificacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaNotificacion.Location = new System.Drawing.Point(97, 418);
            this.dtmFechaNotificacion.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtmFechaNotificacion.Name = "dtmFechaNotificacion";
            this.dtmFechaNotificacion.Size = new System.Drawing.Size(110, 20);
            this.dtmFechaNotificacion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.dtmFechaNotificacion.TabIndex = 32;
            this.dtmFechaNotificacion.Leave += new System.EventHandler(this.dtmFechaNotificacion_Leave);
            this.dtmFechaNotificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtmFechaNotificacion_KeyUp);
            // 
            // chkFechaEnvio
            // 
            this.chkFechaEnvio.AutoSize = true;
            this.chkFechaEnvio.Location = new System.Drawing.Point(213, 400);
            this.chkFechaEnvio.Name = "chkFechaEnvio";
            this.chkFechaEnvio.Size = new System.Drawing.Size(15, 14);
            this.chkFechaEnvio.TabIndex = 27;
            this.chkFechaEnvio.UseVisualStyleBackColor = true;
            this.chkFechaEnvio.CheckedChanged += new System.EventHandler(this.chkFechaEnvio_CheckedChanged);
            // 
            // chkFechaDocumento
            // 
            this.chkFechaDocumento.AutoSize = true;
            this.chkFechaDocumento.Location = new System.Drawing.Point(531, 399);
            this.chkFechaDocumento.Name = "chkFechaDocumento";
            this.chkFechaDocumento.Size = new System.Drawing.Size(15, 14);
            this.chkFechaDocumento.TabIndex = 30;
            this.chkFechaDocumento.UseVisualStyleBackColor = true;
            this.chkFechaDocumento.CheckedChanged += new System.EventHandler(this.chkFechaDocumento_CheckedChanged);
            // 
            // chkFechaNotificacion
            // 
            this.chkFechaNotificacion.AutoSize = true;
            this.chkFechaNotificacion.Location = new System.Drawing.Point(213, 425);
            this.chkFechaNotificacion.Name = "chkFechaNotificacion";
            this.chkFechaNotificacion.Size = new System.Drawing.Size(15, 14);
            this.chkFechaNotificacion.TabIndex = 33;
            this.chkFechaNotificacion.UseVisualStyleBackColor = true;
            this.chkFechaNotificacion.CheckedChanged += new System.EventHandler(this.chkFechaNotificacion_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Dependencia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Alias Delincuente:";
            // 
            // cmbDependencia
            // 
            this.cmbDependencia.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.cmbDependencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDependencia.FormattingEnabled = true;
            this.cmbDependencia.Location = new System.Drawing.Point(97, 367);
            this.cmbDependencia.Name = "cmbDependencia";
            this.cmbDependencia.Size = new System.Drawing.Size(216, 21);
            this.cmbDependencia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbDependencia.TabIndex = 22;
            this.cmbDependencia.SelectedIndexChanged += new System.EventHandler(this.cmbDependencia_SelectedIndexChanged);
            // 
            // txtAlias
            // 
            this.txtAlias.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.txtAlias.Location = new System.Drawing.Point(414, 366);
            this.txtAlias.MaxLength = 50;
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(168, 20);
            this.txtAlias.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtAlias.TabIndex = 24;
            this.txtAlias.Leave += new System.EventHandler(this.txtAlias_Leave);
            this.txtAlias.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAlias_KeyUp);
            // 
            // SAIFrmIncidencia089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 763);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.cmbDependencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFechaNotificacion);
            this.Controls.Add(this.chkFechaDocumento);
            this.Controls.Add(this.chkFechaEnvio);
            this.Controls.Add(this.dtmFechaNotificacion);
            this.Controls.Add(this.dtmFechaDocumento);
            this.Controls.Add(this.dtmFechaEnvioDependencia);
            this.Controls.Add(this.txtNumeroOficio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SAIFrmIncidencia089";
            this.Text = "SAIFrmIncidencia089";
            this.Load += new System.EventHandler(this.SAIFrmIncidencia089_Load);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtNumeroOficio, 0);
            this.Controls.SetChildIndex(this.dtmFechaEnvioDependencia, 0);
            this.Controls.SetChildIndex(this.dtmFechaDocumento, 0);
            this.Controls.SetChildIndex(this.dtmFechaNotificacion, 0);
            this.Controls.SetChildIndex(this.chkFechaEnvio, 0);
            this.Controls.SetChildIndex(this.chkFechaDocumento, 0);
            this.Controls.SetChildIndex(this.chkFechaNotificacion, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbDependencia, 0);
            this.Controls.SetChildIndex(this.txtAlias, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtNumeroOficio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker  dtmFechaEnvioDependencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker dtmFechaDocumento;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker dtmFechaNotificacion;
        private System.Windows.Forms.CheckBox chkFechaEnvio;
        private System.Windows.Forms.CheckBox chkFechaDocumento;
        private System.Windows.Forms.CheckBox chkFechaNotificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbDependencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtAlias;

    }
}