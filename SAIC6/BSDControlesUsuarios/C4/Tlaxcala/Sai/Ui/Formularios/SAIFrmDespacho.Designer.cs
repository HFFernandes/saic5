namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmDespacho));
            this.SAILogoControl = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAILogoControl();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.saiTxtTelefono = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblTipoIncidencia = new System.Windows.Forms.Label();
            this.saiTxtTipoIncidencia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblDireccion = new System.Windows.Forms.Label();
            this.saiTxtDireccion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.saiTxtMunicipio = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtLocalidad = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.saiTxtCodigoPostal = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblColonia = new System.Windows.Forms.Label();
            this.saiTxtColonia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblReferencia = new System.Windows.Forms.Label();
            this.saiTxtReferencia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.saiTxtDescripcion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.gprUnidadPrincipal = new System.Windows.Forms.GroupBox();
            this.gprUnidadApoyo = new System.Windows.Forms.GroupBox();
            this.axComentarios = new AxXtremeReportControl.AxReportControl();
            this.saiTmpHoraLlegada = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker(this.components);
            this.saiTmpHoraLiberacion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker(this.components);
            this.chkHoraLiberacion = new System.Windows.Forms.CheckBox();
            this.chkHoraLlegada = new System.Windows.Forms.CheckBox();
            this.saiTxtHoraRecepcion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtHoraDespacho = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblHoraRecepcion = new System.Windows.Forms.Label();
            this.lblHoraDespacho = new System.Windows.Forms.Label();
            this.lblHoraLlegada = new System.Windows.Forms.Label();
            this.lblHoraLiberacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axComentarios)).BeginInit();
            this.SuspendLayout();
            // 
            // SAILogoControl
            // 
            this.SAILogoControl.BackColor = System.Drawing.Color.White;
            this.SAILogoControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SAILogoControl.Location = new System.Drawing.Point(0, 0);
            this.SAILogoControl.Name = "SAILogoControl";
            this.SAILogoControl.Size = new System.Drawing.Size(551, 70);
            this.SAILogoControl.TabIndex = 0;
            this.SAILogoControl.VelocidadAnimacion = 8;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(8, 87);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 1;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // saiTxtTelefono
            // 
            this.saiTxtTelefono.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtTelefono.Location = new System.Drawing.Point(70, 83);
            this.saiTxtTelefono.Name = "saiTxtTelefono";
            this.saiTxtTelefono.Size = new System.Drawing.Size(135, 20);
            this.saiTxtTelefono.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtTelefono.TabIndex = 2;
            // 
            // lblTipoIncidencia
            // 
            this.lblTipoIncidencia.AutoSize = true;
            this.lblTipoIncidencia.Location = new System.Drawing.Point(211, 87);
            this.lblTipoIncidencia.Name = "lblTipoIncidencia";
            this.lblTipoIncidencia.Size = new System.Drawing.Size(98, 13);
            this.lblTipoIncidencia.TabIndex = 3;
            this.lblTipoIncidencia.Text = "Tipo de Incidencia:";
            // 
            // saiTxtTipoIncidencia
            // 
            this.saiTxtTipoIncidencia.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtTipoIncidencia.Location = new System.Drawing.Point(315, 83);
            this.saiTxtTipoIncidencia.Name = "saiTxtTipoIncidencia";
            this.saiTxtTipoIncidencia.Size = new System.Drawing.Size(224, 20);
            this.saiTxtTipoIncidencia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtTipoIncidencia.TabIndex = 4;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(8, 110);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Dirección:";
            // 
            // saiTxtDireccion
            // 
            this.saiTxtDireccion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtDireccion.Location = new System.Drawing.Point(70, 110);
            this.saiTxtDireccion.Name = "saiTxtDireccion";
            this.saiTxtDireccion.Size = new System.Drawing.Size(469, 20);
            this.saiTxtDireccion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtDireccion.TabIndex = 6;
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(8, 139);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(55, 13);
            this.lblMunicipio.TabIndex = 7;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(8, 165);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 9;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // saiTxtMunicipio
            // 
            this.saiTxtMunicipio.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtMunicipio.Location = new System.Drawing.Point(70, 136);
            this.saiTxtMunicipio.Name = "saiTxtMunicipio";
            this.saiTxtMunicipio.Size = new System.Drawing.Size(469, 20);
            this.saiTxtMunicipio.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtMunicipio.TabIndex = 8;
            // 
            // saiTxtLocalidad
            // 
            this.saiTxtLocalidad.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtLocalidad.Location = new System.Drawing.Point(70, 162);
            this.saiTxtLocalidad.Name = "saiTxtLocalidad";
            this.saiTxtLocalidad.Size = new System.Drawing.Size(286, 20);
            this.saiTxtLocalidad.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtLocalidad.TabIndex = 10;
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(362, 165);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(75, 13);
            this.lblCodigoPostal.TabIndex = 11;
            this.lblCodigoPostal.Text = "Código Postal:";
            // 
            // saiTxtCodigoPostal
            // 
            this.saiTxtCodigoPostal.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtCodigoPostal.Location = new System.Drawing.Point(443, 162);
            this.saiTxtCodigoPostal.Name = "saiTxtCodigoPostal";
            this.saiTxtCodigoPostal.Size = new System.Drawing.Size(96, 20);
            this.saiTxtCodigoPostal.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtCodigoPostal.TabIndex = 12;
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(8, 191);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(45, 13);
            this.lblColonia.TabIndex = 13;
            this.lblColonia.Text = "Colonia:";
            // 
            // saiTxtColonia
            // 
            this.saiTxtColonia.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtColonia.Location = new System.Drawing.Point(70, 188);
            this.saiTxtColonia.Name = "saiTxtColonia";
            this.saiTxtColonia.Size = new System.Drawing.Size(469, 20);
            this.saiTxtColonia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtColonia.TabIndex = 14;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(8, 217);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(64, 13);
            this.lblReferencia.TabIndex = 15;
            this.lblReferencia.Text = "Referencias";
            // 
            // saiTxtReferencia
            // 
            this.saiTxtReferencia.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtReferencia.Location = new System.Drawing.Point(11, 233);
            this.saiTxtReferencia.Multiline = true;
            this.saiTxtReferencia.Name = "saiTxtReferencia";
            this.saiTxtReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.saiTxtReferencia.Size = new System.Drawing.Size(528, 76);
            this.saiTxtReferencia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtReferencia.TabIndex = 16;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(8, 312);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "Descripción";
            // 
            // saiTxtDescripcion
            // 
            this.saiTxtDescripcion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtDescripcion.Location = new System.Drawing.Point(11, 328);
            this.saiTxtDescripcion.Multiline = true;
            this.saiTxtDescripcion.Name = "saiTxtDescripcion";
            this.saiTxtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.saiTxtDescripcion.Size = new System.Drawing.Size(528, 76);
            this.saiTxtDescripcion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtDescripcion.TabIndex = 18;
            // 
            // gprUnidadPrincipal
            // 
            this.gprUnidadPrincipal.Location = new System.Drawing.Point(11, 410);
            this.gprUnidadPrincipal.Name = "gprUnidadPrincipal";
            this.gprUnidadPrincipal.Size = new System.Drawing.Size(253, 70);
            this.gprUnidadPrincipal.TabIndex = 19;
            this.gprUnidadPrincipal.TabStop = false;
            this.gprUnidadPrincipal.Text = "Unidad Asignada";
            // 
            // gprUnidadApoyo
            // 
            this.gprUnidadApoyo.Location = new System.Drawing.Point(286, 410);
            this.gprUnidadApoyo.Name = "gprUnidadApoyo";
            this.gprUnidadApoyo.Size = new System.Drawing.Size(253, 70);
            this.gprUnidadApoyo.TabIndex = 20;
            this.gprUnidadApoyo.TabStop = false;
            this.gprUnidadApoyo.Text = "Unidad de Apoyo";
            // 
            // axComentarios
            // 
            this.axComentarios.Location = new System.Drawing.Point(11, 486);
            this.axComentarios.Name = "axComentarios";
            this.axComentarios.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axComentarios.OcxState")));
            this.axComentarios.Size = new System.Drawing.Size(528, 205);
            this.axComentarios.TabIndex = 21;
            // 
            // saiTmpHoraLlegada
            // 
            this.saiTmpHoraLlegada.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTmpHoraLlegada.CustomFormat = "hh:mm";
            this.saiTmpHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saiTmpHoraLlegada.Location = new System.Drawing.Point(292, 718);
            this.saiTmpHoraLlegada.Name = "saiTmpHoraLlegada";
            this.saiTmpHoraLlegada.ShowUpDown = true;
            this.saiTmpHoraLlegada.Size = new System.Drawing.Size(97, 20);
            this.saiTmpHoraLlegada.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTmpHoraLlegada.TabIndex = 27;
            // 
            // saiTmpHoraLiberacion
            // 
            this.saiTmpHoraLiberacion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTmpHoraLiberacion.CustomFormat = "hh:mm";
            this.saiTmpHoraLiberacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saiTmpHoraLiberacion.Location = new System.Drawing.Point(421, 718);
            this.saiTmpHoraLiberacion.Name = "saiTmpHoraLiberacion";
            this.saiTmpHoraLiberacion.ShowUpDown = true;
            this.saiTmpHoraLiberacion.Size = new System.Drawing.Size(97, 20);
            this.saiTmpHoraLiberacion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTmpHoraLiberacion.TabIndex = 30;
            // 
            // chkHoraLiberacion
            // 
            this.chkHoraLiberacion.AutoSize = true;
            this.chkHoraLiberacion.Location = new System.Drawing.Point(524, 722);
            this.chkHoraLiberacion.Name = "chkHoraLiberacion";
            this.chkHoraLiberacion.Size = new System.Drawing.Size(15, 14);
            this.chkHoraLiberacion.TabIndex = 31;
            this.chkHoraLiberacion.UseVisualStyleBackColor = true;
            // 
            // chkHoraLlegada
            // 
            this.chkHoraLlegada.AutoSize = true;
            this.chkHoraLlegada.Location = new System.Drawing.Point(395, 722);
            this.chkHoraLlegada.Name = "chkHoraLlegada";
            this.chkHoraLlegada.Size = new System.Drawing.Size(15, 14);
            this.chkHoraLlegada.TabIndex = 28;
            this.chkHoraLlegada.UseVisualStyleBackColor = true;
            // 
            // saiTxtHoraRecepcion
            // 
            this.saiTxtHoraRecepcion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtHoraRecepcion.Location = new System.Drawing.Point(11, 718);
            this.saiTxtHoraRecepcion.Name = "saiTxtHoraRecepcion";
            this.saiTxtHoraRecepcion.Size = new System.Drawing.Size(97, 20);
            this.saiTxtHoraRecepcion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtHoraRecepcion.TabIndex = 23;
            // 
            // saiTxtHoraDespacho
            // 
            this.saiTxtHoraDespacho.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtHoraDespacho.Location = new System.Drawing.Point(118, 718);
            this.saiTxtHoraDespacho.Name = "saiTxtHoraDespacho";
            this.saiTxtHoraDespacho.Size = new System.Drawing.Size(97, 20);
            this.saiTxtHoraDespacho.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtHoraDespacho.TabIndex = 25;
            // 
            // lblHoraRecepcion
            // 
            this.lblHoraRecepcion.AutoSize = true;
            this.lblHoraRecepcion.Location = new System.Drawing.Point(8, 702);
            this.lblHoraRecepcion.Name = "lblHoraRecepcion";
            this.lblHoraRecepcion.Size = new System.Drawing.Size(100, 13);
            this.lblHoraRecepcion.TabIndex = 22;
            this.lblHoraRecepcion.Text = "Hora de Recepción";
            // 
            // lblHoraDespacho
            // 
            this.lblHoraDespacho.AutoSize = true;
            this.lblHoraDespacho.Location = new System.Drawing.Point(115, 702);
            this.lblHoraDespacho.Name = "lblHoraDespacho";
            this.lblHoraDespacho.Size = new System.Drawing.Size(97, 13);
            this.lblHoraDespacho.TabIndex = 24;
            this.lblHoraDespacho.Text = "Hora de Despacho";
            // 
            // lblHoraLlegada
            // 
            this.lblHoraLlegada.AutoSize = true;
            this.lblHoraLlegada.Location = new System.Drawing.Point(289, 702);
            this.lblHoraLlegada.Name = "lblHoraLlegada";
            this.lblHoraLlegada.Size = new System.Drawing.Size(86, 13);
            this.lblHoraLlegada.TabIndex = 26;
            this.lblHoraLlegada.Text = "Hora de Llegada";
            // 
            // lblHoraLiberacion
            // 
            this.lblHoraLiberacion.AutoSize = true;
            this.lblHoraLiberacion.Location = new System.Drawing.Point(418, 702);
            this.lblHoraLiberacion.Name = "lblHoraLiberacion";
            this.lblHoraLiberacion.Size = new System.Drawing.Size(97, 13);
            this.lblHoraLiberacion.TabIndex = 29;
            this.lblHoraLiberacion.Text = "Hora de Liberación";
            // 
            // SAIFrmDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 748);
            this.Controls.Add(this.axComentarios);
            this.Controls.Add(this.lblHoraLiberacion);
            this.Controls.Add(this.lblHoraLlegada);
            this.Controls.Add(this.lblHoraDespacho);
            this.Controls.Add(this.lblHoraRecepcion);
            this.Controls.Add(this.saiTxtHoraDespacho);
            this.Controls.Add(this.saiTxtHoraRecepcion);
            this.Controls.Add(this.chkHoraLlegada);
            this.Controls.Add(this.chkHoraLiberacion);
            this.Controls.Add(this.saiTmpHoraLiberacion);
            this.Controls.Add(this.saiTmpHoraLlegada);
            this.Controls.Add(this.gprUnidadApoyo);
            this.Controls.Add(this.gprUnidadPrincipal);
            this.Controls.Add(this.saiTxtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.saiTxtReferencia);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.saiTxtColonia);
            this.Controls.Add(this.lblColonia);
            this.Controls.Add(this.saiTxtCodigoPostal);
            this.Controls.Add(this.lblCodigoPostal);
            this.Controls.Add(this.saiTxtLocalidad);
            this.Controls.Add(this.saiTxtMunicipio);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.saiTxtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.saiTxtTipoIncidencia);
            this.Controls.Add(this.lblTipoIncidencia);
            this.Controls.Add(this.saiTxtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.SAILogoControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SAIFrmDespacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAI - Despacho de Incidencia";
            this.Load += new System.EventHandler(this.SAIFrmDespacho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axComentarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAILogoControl SAILogoControl;
        private System.Windows.Forms.Label lblTelefono;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtTelefono;
        private System.Windows.Forms.Label lblTipoIncidencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtTipoIncidencia;
        private System.Windows.Forms.Label lblDireccion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtDireccion;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblLocalidad;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtMunicipio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtLocalidad;
        private System.Windows.Forms.Label lblCodigoPostal;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtCodigoPostal;
        private System.Windows.Forms.Label lblColonia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtColonia;
        private System.Windows.Forms.Label lblReferencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtReferencia;
        private System.Windows.Forms.Label lblDescripcion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtDescripcion;
        private System.Windows.Forms.GroupBox gprUnidadPrincipal;
        private System.Windows.Forms.GroupBox gprUnidadApoyo;
        private AxXtremeReportControl.AxReportControl axComentarios;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker saiTmpHoraLlegada;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker saiTmpHoraLiberacion;
        private System.Windows.Forms.CheckBox chkHoraLiberacion;
        private System.Windows.Forms.CheckBox chkHoraLlegada;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtHoraRecepcion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtHoraDespacho;
        private System.Windows.Forms.Label lblHoraRecepcion;
        private System.Windows.Forms.Label lblHoraDespacho;
        private System.Windows.Forms.Label lblHoraLlegada;
        private System.Windows.Forms.Label lblHoraLiberacion;
    }
}