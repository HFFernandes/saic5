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
            this.dtmFechaEnvioDependencia = new System.Windows.Forms.DateTimePicker();
            this.dtmFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.dtmFechaNotificacion = new System.Windows.Forms.DateTimePicker();
            this.chkFechaEnvio = new System.Windows.Forms.CheckBox();
            this.chkFechaDocumento = new System.Windows.Forms.CheckBox();
            this.chkFechaNotificacion = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 356);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 26);
            this.label11.TabIndex = 21;
            this.label11.Text = "Fecha de Envío\r\na Dependencia";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(287, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 26);
            this.label12.TabIndex = 23;
            this.label12.Text = "Fecha del\r\nDocumento:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 407);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 26);
            this.label13.TabIndex = 25;
            this.label13.Text = "Fecha de\r\nNotificación:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(286, 407);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 26);
            this.label14.TabIndex = 27;
            this.label14.Text = "Número de Oficio\r\nPara Envío:";
            // 
            // txtNumeroOficio
            // 
            this.txtNumeroOficio.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.txtNumeroOficio.Location = new System.Drawing.Point(377, 413);
            this.txtNumeroOficio.Name = "txtNumeroOficio";
            this.txtNumeroOficio.Size = new System.Drawing.Size(205, 20);
            this.txtNumeroOficio.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtNumeroOficio.TabIndex = 28;
            // 
            // dtmFechaEnvioDependencia
            // 
            this.dtmFechaEnvioDependencia.Enabled = false;
            this.dtmFechaEnvioDependencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaEnvioDependencia.Location = new System.Drawing.Point(96, 362);
            this.dtmFechaEnvioDependencia.Name = "dtmFechaEnvioDependencia";
            this.dtmFechaEnvioDependencia.Size = new System.Drawing.Size(110, 20);
            this.dtmFechaEnvioDependencia.TabIndex = 22;
            // 
            // dtmFechaDocumento
            // 
            this.dtmFechaDocumento.Enabled = false;
            this.dtmFechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaDocumento.Location = new System.Drawing.Point(375, 362);
            this.dtmFechaDocumento.Name = "dtmFechaDocumento";
            this.dtmFechaDocumento.Size = new System.Drawing.Size(110, 20);
            this.dtmFechaDocumento.TabIndex = 24;
            this.dtmFechaDocumento.Value = new System.DateTime(2009, 8, 8, 0, 0, 0, 0);
            // 
            // dtmFechaNotificacion
            // 
            this.dtmFechaNotificacion.Enabled = false;
            this.dtmFechaNotificacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaNotificacion.Location = new System.Drawing.Point(96, 413);
            this.dtmFechaNotificacion.Name = "dtmFechaNotificacion";
            this.dtmFechaNotificacion.Size = new System.Drawing.Size(110, 20);
            this.dtmFechaNotificacion.TabIndex = 26;
            // 
            // chkFechaEnvio
            // 
            this.chkFechaEnvio.AutoSize = true;
            this.chkFechaEnvio.Location = new System.Drawing.Point(212, 369);
            this.chkFechaEnvio.Name = "chkFechaEnvio";
            this.chkFechaEnvio.Size = new System.Drawing.Size(15, 14);
            this.chkFechaEnvio.TabIndex = 29;
            this.chkFechaEnvio.UseVisualStyleBackColor = true;
            this.chkFechaEnvio.CheckedChanged += new System.EventHandler(this.chkFechaEnvio_CheckedChanged);
            // 
            // chkFechaDocumento
            // 
            this.chkFechaDocumento.AutoSize = true;
            this.chkFechaDocumento.Location = new System.Drawing.Point(491, 368);
            this.chkFechaDocumento.Name = "chkFechaDocumento";
            this.chkFechaDocumento.Size = new System.Drawing.Size(15, 14);
            this.chkFechaDocumento.TabIndex = 30;
            this.chkFechaDocumento.UseVisualStyleBackColor = true;
            this.chkFechaDocumento.CheckedChanged += new System.EventHandler(this.chkFechaDocumento_CheckedChanged);
            // 
            // chkFechaNotificacion
            // 
            this.chkFechaNotificacion.AutoSize = true;
            this.chkFechaNotificacion.Location = new System.Drawing.Point(212, 420);
            this.chkFechaNotificacion.Name = "chkFechaNotificacion";
            this.chkFechaNotificacion.Size = new System.Drawing.Size(15, 14);
            this.chkFechaNotificacion.TabIndex = 31;
            this.chkFechaNotificacion.UseVisualStyleBackColor = true;
            this.chkFechaNotificacion.CheckedChanged += new System.EventHandler(this.chkFechaNotificacion_CheckedChanged);
            // 
            // SAIFrmIncidencia089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 495);
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
            this.Name = "SAIFrmIncidencia089";
            this.Text = "SAIFrmIncidencia089";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtNumeroOficio;
        private System.Windows.Forms.DateTimePicker dtmFechaEnvioDependencia;
        private System.Windows.Forms.DateTimePicker dtmFechaDocumento;
        private System.Windows.Forms.DateTimePicker dtmFechaNotificacion;
        private System.Windows.Forms.CheckBox chkFechaEnvio;
        private System.Windows.Forms.CheckBox chkFechaDocumento;
        private System.Windows.Forms.CheckBox chkFechaNotificacion;

    }
}