namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    partial class CRIncidencias
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
            this.lblSistema = new System.Windows.Forms.Label();
            this.cboSistema = new System.Windows.Forms.ComboBox();
            this.cboTipoIncidencia = new System.Windows.Forms.ComboBox();
            this.cboPrioridad = new System.Windows.Forms.ComboBox();
            this.lblTipoIncidencia = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCierre = new System.Windows.Forms.CheckBox();
            this.chkDespacho = new System.Windows.Forms.CheckBox();
            this.chkRecepcion = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteCierreFin = new System.Windows.Forms.DateTimePicker();
            this.dteCierreIni = new System.Windows.Forms.DateTimePicker();
            this.dteDespachoFin = new System.Windows.Forms.DateTimePicker();
            this.dteDespachoIni = new System.Windows.Forms.DateTimePicker();
            this.dteRecepcionFin = new System.Windows.Forms.DateTimePicker();
            this.dteRecepcionIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboColonia = new System.Windows.Forms.ComboBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.cboCP = new System.Windows.Forms.ComboBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboMunicipio = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboDependencia = new System.Windows.Forms.ComboBox();
            this.lblDependencia = new System.Windows.Forms.Label();
            this.cboCorporacion = new System.Windows.Forms.ComboBox();
            this.lblCorporacion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpStsIncidencia = new System.Windows.Forms.GroupBox();
            this.rbtTodas = new System.Windows.Forms.RadioButton();
            this.rbtCanceladas = new System.Windows.Forms.RadioButton();
            this.rbtCerradas = new System.Windows.Forms.RadioButton();
            this.rbtPendientes = new System.Windows.Forms.RadioButton();
            this.rbtActivas = new System.Windows.Forms.RadioButton();
            this.rbtNuevas = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkDespachadores = new System.Windows.Forms.CheckedListBox();
            this.chkOperadores = new System.Windows.Forms.CheckedListBox();
            this.lblDespachadores = new System.Windows.Forms.Label();
            this.lblOperadores = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpStsIncidencia.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(12, 20);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(47, 13);
            this.lblSistema.TabIndex = 0;
            this.lblSistema.Text = "Sistema:";
            // 
            // cboSistema
            // 
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Location = new System.Drawing.Point(59, 17);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(90, 21);
            this.cboSistema.TabIndex = 1;
            this.cboSistema.SelectedIndexChanged += new System.EventHandler(this.cboSistema_SelectedIndexChanged);
            // 
            // cboTipoIncidencia
            // 
            this.cboTipoIncidencia.FormattingEnabled = true;
            this.cboTipoIncidencia.Location = new System.Drawing.Point(269, 17);
            this.cboTipoIncidencia.Name = "cboTipoIncidencia";
            this.cboTipoIncidencia.Size = new System.Drawing.Size(152, 21);
            this.cboTipoIncidencia.TabIndex = 2;
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.Location = new System.Drawing.Point(491, 17);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(121, 21);
            this.cboPrioridad.TabIndex = 3;
            // 
            // lblTipoIncidencia
            // 
            this.lblTipoIncidencia.AutoSize = true;
            this.lblTipoIncidencia.Location = new System.Drawing.Point(170, 20);
            this.lblTipoIncidencia.Name = "lblTipoIncidencia";
            this.lblTipoIncidencia.Size = new System.Drawing.Size(98, 13);
            this.lblTipoIncidencia.TabIndex = 4;
            this.lblTipoIncidencia.Text = "Tipo de Incidencia:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Location = new System.Drawing.Point(432, 20);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(51, 13);
            this.lblPrioridad.TabIndex = 5;
            this.lblPrioridad.Text = "Prioridad:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCierre);
            this.groupBox1.Controls.Add(this.chkDespacho);
            this.groupBox1.Controls.Add(this.chkRecepcion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dteCierreFin);
            this.groupBox1.Controls.Add(this.dteCierreIni);
            this.groupBox1.Controls.Add(this.dteDespachoFin);
            this.groupBox1.Controls.Add(this.dteDespachoIni);
            this.groupBox1.Controls.Add(this.dteRecepcionFin);
            this.groupBox1.Controls.Add(this.dteRecepcionIni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 216);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechas";
            // 
            // chkCierre
            // 
            this.chkCierre.AutoSize = true;
            this.chkCierre.Location = new System.Drawing.Point(13, 152);
            this.chkCierre.Name = "chkCierre";
            this.chkCierre.Size = new System.Drawing.Size(70, 17);
            this.chkCierre.TabIndex = 14;
            this.chkCierre.Text = "De Cierre";
            this.chkCierre.UseVisualStyleBackColor = true;
            this.chkCierre.CheckedChanged += new System.EventHandler(this.chkCierre_CheckedChanged);
            // 
            // chkDespacho
            // 
            this.chkDespacho.AutoSize = true;
            this.chkDespacho.Location = new System.Drawing.Point(13, 87);
            this.chkDespacho.Name = "chkDespacho";
            this.chkDespacho.Size = new System.Drawing.Size(92, 17);
            this.chkDespacho.TabIndex = 13;
            this.chkDespacho.Text = "De Despacho";
            this.chkDespacho.UseVisualStyleBackColor = true;
            this.chkDespacho.CheckedChanged += new System.EventHandler(this.chkDespacho_CheckedChanged);
            // 
            // chkRecepcion
            // 
            this.chkRecepcion.AutoSize = true;
            this.chkRecepcion.Location = new System.Drawing.Point(13, 26);
            this.chkRecepcion.Name = "chkRecepcion";
            this.chkRecepcion.Size = new System.Drawing.Size(95, 17);
            this.chkRecepcion.TabIndex = 12;
            this.chkRecepcion.Text = "De Recepción";
            this.chkRecepcion.UseVisualStyleBackColor = true;
            this.chkRecepcion.CheckedChanged += new System.EventHandler(this.chkRecepcion_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "al";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "al";
            // 
            // dteCierreFin
            // 
            this.dteCierreFin.Enabled = false;
            this.dteCierreFin.Location = new System.Drawing.Point(381, 176);
            this.dteCierreFin.Name = "dteCierreFin";
            this.dteCierreFin.Size = new System.Drawing.Size(200, 20);
            this.dteCierreFin.TabIndex = 8;
            // 
            // dteCierreIni
            // 
            this.dteCierreIni.Enabled = false;
            this.dteCierreIni.Location = new System.Drawing.Point(85, 176);
            this.dteCierreIni.Name = "dteCierreIni";
            this.dteCierreIni.Size = new System.Drawing.Size(200, 20);
            this.dteCierreIni.TabIndex = 7;
            // 
            // dteDespachoFin
            // 
            this.dteDespachoFin.Enabled = false;
            this.dteDespachoFin.Location = new System.Drawing.Point(381, 110);
            this.dteDespachoFin.Name = "dteDespachoFin";
            this.dteDespachoFin.Size = new System.Drawing.Size(200, 20);
            this.dteDespachoFin.TabIndex = 6;
            // 
            // dteDespachoIni
            // 
            this.dteDespachoIni.Enabled = false;
            this.dteDespachoIni.Location = new System.Drawing.Point(85, 110);
            this.dteDespachoIni.Name = "dteDespachoIni";
            this.dteDespachoIni.Size = new System.Drawing.Size(200, 20);
            this.dteDespachoIni.TabIndex = 5;
            // 
            // dteRecepcionFin
            // 
            this.dteRecepcionFin.Enabled = false;
            this.dteRecepcionFin.Location = new System.Drawing.Point(381, 49);
            this.dteRecepcionFin.Name = "dteRecepcionFin";
            this.dteRecepcionFin.Size = new System.Drawing.Size(200, 20);
            this.dteRecepcionFin.TabIndex = 4;
            // 
            // dteRecepcionIni
            // 
            this.dteRecepcionIni.Enabled = false;
            this.dteRecepcionIni.Location = new System.Drawing.Point(85, 49);
            this.dteRecepcionIni.Name = "dteRecepcionIni";
            this.dteRecepcionIni.Size = new System.Drawing.Size(200, 20);
            this.dteRecepcionIni.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboColonia);
            this.groupBox2.Controls.Add(this.lblColonia);
            this.groupBox2.Controls.Add(this.cboCP);
            this.groupBox2.Controls.Add(this.lblCP);
            this.groupBox2.Controls.Add(this.cboLocalidad);
            this.groupBox2.Controls.Add(this.lblLocalidad);
            this.groupBox2.Controls.Add(this.cboMunicipio);
            this.groupBox2.Controls.Add(this.lblMunicipio);
            this.groupBox2.Location = new System.Drawing.Point(12, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicación";
            // 
            // cboColonia
            // 
            this.cboColonia.FormattingEnabled = true;
            this.cboColonia.Location = new System.Drawing.Point(85, 70);
            this.cboColonia.Name = "cboColonia";
            this.cboColonia.Size = new System.Drawing.Size(200, 21);
            this.cboColonia.TabIndex = 8;
            this.cboColonia.SelectedIndexChanged += new System.EventHandler(this.cboColonia_SelectedIndexChanged);
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(30, 73);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(42, 13);
            this.lblColonia.TabIndex = 7;
            this.lblColonia.Text = "Colonia";
            // 
            // cboCP
            // 
            this.cboCP.FormattingEnabled = true;
            this.cboCP.Location = new System.Drawing.Point(381, 70);
            this.cboCP.Name = "cboCP";
            this.cboCP.Size = new System.Drawing.Size(200, 21);
            this.cboCP.TabIndex = 6;
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(306, 73);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(72, 13);
            this.lblCP.TabIndex = 5;
            this.lblCP.Text = "Código Postal";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(381, 27);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(200, 21);
            this.cboLocalidad.TabIndex = 4;
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboLocalidad_SelectedIndexChanged);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(319, 30);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 3;
            this.lblLocalidad.Text = "Localidad";
            // 
            // cboMunicipio
            // 
            this.cboMunicipio.FormattingEnabled = true;
            this.cboMunicipio.Location = new System.Drawing.Point(85, 27);
            this.cboMunicipio.Name = "cboMunicipio";
            this.cboMunicipio.Size = new System.Drawing.Size(200, 21);
            this.cboMunicipio.TabIndex = 1;
            this.cboMunicipio.SelectedIndexChanged += new System.EventHandler(this.cboMunicipio_SelectedIndexChanged);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(20, 30);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(52, 13);
            this.lblMunicipio.TabIndex = 0;
            this.lblMunicipio.Text = "Municipio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboDependencia);
            this.groupBox3.Controls.Add(this.lblDependencia);
            this.groupBox3.Controls.Add(this.cboCorporacion);
            this.groupBox3.Controls.Add(this.lblCorporacion);
            this.groupBox3.Location = new System.Drawing.Point(12, 563);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 54);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entidades Responsables";
            // 
            // cboDependencia
            // 
            this.cboDependencia.Enabled = false;
            this.cboDependencia.FormattingEnabled = true;
            this.cboDependencia.Location = new System.Drawing.Point(381, 22);
            this.cboDependencia.Name = "cboDependencia";
            this.cboDependencia.Size = new System.Drawing.Size(200, 21);
            this.cboDependencia.TabIndex = 3;
            // 
            // lblDependencia
            // 
            this.lblDependencia.AutoSize = true;
            this.lblDependencia.Location = new System.Drawing.Point(301, 25);
            this.lblDependencia.Name = "lblDependencia";
            this.lblDependencia.Size = new System.Drawing.Size(71, 13);
            this.lblDependencia.TabIndex = 2;
            this.lblDependencia.Text = "Dependencia";
            // 
            // cboCorporacion
            // 
            this.cboCorporacion.Enabled = false;
            this.cboCorporacion.FormattingEnabled = true;
            this.cboCorporacion.Location = new System.Drawing.Point(85, 22);
            this.cboCorporacion.Name = "cboCorporacion";
            this.cboCorporacion.Size = new System.Drawing.Size(200, 21);
            this.cboCorporacion.TabIndex = 1;
            // 
            // lblCorporacion
            // 
            this.lblCorporacion.AutoSize = true;
            this.lblCorporacion.Location = new System.Drawing.Point(10, 25);
            this.lblCorporacion.Name = "lblCorporacion";
            this.lblCorporacion.Size = new System.Drawing.Size(64, 13);
            this.lblCorporacion.TabIndex = 0;
            this.lblCorporacion.Text = "Corporación";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(64, 627);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(283, 627);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "&Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(491, 627);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpStsIncidencia
            // 
            this.grpStsIncidencia.Controls.Add(this.rbtTodas);
            this.grpStsIncidencia.Controls.Add(this.rbtCanceladas);
            this.grpStsIncidencia.Controls.Add(this.rbtCerradas);
            this.grpStsIncidencia.Controls.Add(this.rbtPendientes);
            this.grpStsIncidencia.Controls.Add(this.rbtActivas);
            this.grpStsIncidencia.Controls.Add(this.rbtNuevas);
            this.grpStsIncidencia.Location = new System.Drawing.Point(12, 44);
            this.grpStsIncidencia.Name = "grpStsIncidencia";
            this.grpStsIncidencia.Size = new System.Drawing.Size(600, 50);
            this.grpStsIncidencia.TabIndex = 12;
            this.grpStsIncidencia.TabStop = false;
            this.grpStsIncidencia.Text = "Estado de la Incidencia";
            // 
            // rbtTodas
            // 
            this.rbtTodas.AutoSize = true;
            this.rbtTodas.Location = new System.Drawing.Point(536, 21);
            this.rbtTodas.Name = "rbtTodas";
            this.rbtTodas.Size = new System.Drawing.Size(55, 17);
            this.rbtTodas.TabIndex = 5;
            this.rbtTodas.Text = "Todas";
            this.rbtTodas.UseVisualStyleBackColor = true;
            this.rbtTodas.CheckedChanged += new System.EventHandler(this.rbtTodas_CheckedChanged);
            // 
            // rbtCanceladas
            // 
            this.rbtCanceladas.AutoSize = true;
            this.rbtCanceladas.Location = new System.Drawing.Point(423, 21);
            this.rbtCanceladas.Name = "rbtCanceladas";
            this.rbtCanceladas.Size = new System.Drawing.Size(81, 17);
            this.rbtCanceladas.TabIndex = 4;
            this.rbtCanceladas.Text = "Canceladas";
            this.rbtCanceladas.UseVisualStyleBackColor = true;
            this.rbtCanceladas.CheckedChanged += new System.EventHandler(this.rbtCanceladas_CheckedChanged);
            // 
            // rbtCerradas
            // 
            this.rbtCerradas.AutoSize = true;
            this.rbtCerradas.Location = new System.Drawing.Point(321, 21);
            this.rbtCerradas.Name = "rbtCerradas";
            this.rbtCerradas.Size = new System.Drawing.Size(67, 17);
            this.rbtCerradas.TabIndex = 3;
            this.rbtCerradas.Text = "Cerradas";
            this.rbtCerradas.UseVisualStyleBackColor = true;
            this.rbtCerradas.CheckedChanged += new System.EventHandler(this.rbtCerradas_CheckedChanged);
            // 
            // rbtPendientes
            // 
            this.rbtPendientes.AutoSize = true;
            this.rbtPendientes.Location = new System.Drawing.Point(207, 21);
            this.rbtPendientes.Name = "rbtPendientes";
            this.rbtPendientes.Size = new System.Drawing.Size(78, 17);
            this.rbtPendientes.TabIndex = 2;
            this.rbtPendientes.Text = "Pendientes";
            this.rbtPendientes.UseVisualStyleBackColor = true;
            this.rbtPendientes.CheckedChanged += new System.EventHandler(this.rbtPendientes_CheckedChanged);
            // 
            // rbtActivas
            // 
            this.rbtActivas.AutoSize = true;
            this.rbtActivas.Location = new System.Drawing.Point(113, 21);
            this.rbtActivas.Name = "rbtActivas";
            this.rbtActivas.Size = new System.Drawing.Size(60, 17);
            this.rbtActivas.TabIndex = 1;
            this.rbtActivas.Tag = "";
            this.rbtActivas.Text = "Activas";
            this.rbtActivas.UseVisualStyleBackColor = true;
            this.rbtActivas.CheckedChanged += new System.EventHandler(this.rbtActivas_CheckedChanged);
            // 
            // rbtNuevas
            // 
            this.rbtNuevas.AutoSize = true;
            this.rbtNuevas.Checked = true;
            this.rbtNuevas.Location = new System.Drawing.Point(13, 21);
            this.rbtNuevas.Name = "rbtNuevas";
            this.rbtNuevas.Size = new System.Drawing.Size(62, 17);
            this.rbtNuevas.TabIndex = 0;
            this.rbtNuevas.TabStop = true;
            this.rbtNuevas.Tag = "";
            this.rbtNuevas.Text = "Nuevas";
            this.rbtNuevas.UseVisualStyleBackColor = true;
            this.rbtNuevas.CheckedChanged += new System.EventHandler(this.rbtNuevas_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkDespachadores);
            this.groupBox5.Controls.Add(this.chkOperadores);
            this.groupBox5.Controls.Add(this.lblDespachadores);
            this.groupBox5.Controls.Add(this.lblOperadores);
            this.groupBox5.Location = new System.Drawing.Point(12, 430);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(600, 127);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Usuarios";
            // 
            // chkDespachadores
            // 
            this.chkDespachadores.Enabled = false;
            this.chkDespachadores.FormattingEnabled = true;
            this.chkDespachadores.Location = new System.Drawing.Point(381, 19);
            this.chkDespachadores.Name = "chkDespachadores";
            this.chkDespachadores.Size = new System.Drawing.Size(200, 94);
            this.chkDespachadores.TabIndex = 3;
            // 
            // chkOperadores
            // 
            this.chkOperadores.Enabled = false;
            this.chkOperadores.FormattingEnabled = true;
            this.chkOperadores.Location = new System.Drawing.Point(85, 19);
            this.chkOperadores.Name = "chkOperadores";
            this.chkOperadores.Size = new System.Drawing.Size(200, 94);
            this.chkOperadores.TabIndex = 2;
            // 
            // lblDespachadores
            // 
            this.lblDespachadores.AutoSize = true;
            this.lblDespachadores.Location = new System.Drawing.Point(293, 19);
            this.lblDespachadores.Name = "lblDespachadores";
            this.lblDespachadores.Size = new System.Drawing.Size(82, 13);
            this.lblDespachadores.TabIndex = 1;
            this.lblDespachadores.Text = "Despachadores";
            // 
            // lblOperadores
            // 
            this.lblOperadores.AutoSize = true;
            this.lblOperadores.Location = new System.Drawing.Point(10, 17);
            this.lblOperadores.Name = "lblOperadores";
            this.lblOperadores.Size = new System.Drawing.Size(62, 13);
            this.lblOperadores.TabIndex = 0;
            this.lblOperadores.Text = "Operadores";
            // 
            // CRIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 657);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpStsIncidencia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.lblTipoIncidencia);
            this.Controls.Add(this.cboPrioridad);
            this.Controls.Add(this.cboTipoIncidencia);
            this.Controls.Add(this.cboSistema);
            this.Controls.Add(this.lblSistema);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CRIncidencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Formato de Reporte de Incidencias";
            this.Load += new System.EventHandler(this.CRIncidencias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpStsIncidencia.ResumeLayout(false);
            this.grpStsIncidencia.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.ComboBox cboSistema;
        private System.Windows.Forms.ComboBox cboTipoIncidencia;
        private System.Windows.Forms.ComboBox cboPrioridad;
        private System.Windows.Forms.Label lblTipoIncidencia;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dteCierreFin;
        private System.Windows.Forms.DateTimePicker dteCierreIni;
        private System.Windows.Forms.DateTimePicker dteDespachoFin;
        private System.Windows.Forms.DateTimePicker dteDespachoIni;
        private System.Windows.Forms.DateTimePicker dteRecepcionFin;
        private System.Windows.Forms.DateTimePicker dteRecepcionIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboColonia;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.ComboBox cboCP;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboMunicipio;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboDependencia;
        private System.Windows.Forms.Label lblDependencia;
        private System.Windows.Forms.ComboBox cboCorporacion;
        private System.Windows.Forms.Label lblCorporacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpStsIncidencia;
        private System.Windows.Forms.RadioButton rbtTodas;
        private System.Windows.Forms.RadioButton rbtCanceladas;
        private System.Windows.Forms.RadioButton rbtCerradas;
        private System.Windows.Forms.RadioButton rbtPendientes;
        private System.Windows.Forms.RadioButton rbtActivas;
        private System.Windows.Forms.RadioButton rbtNuevas;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox chkDespachadores;
        private System.Windows.Forms.CheckedListBox chkOperadores;
        private System.Windows.Forms.Label lblDespachadores;
        private System.Windows.Forms.Label lblOperadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCierre;
        private System.Windows.Forms.CheckBox chkDespacho;
        private System.Windows.Forms.CheckBox chkRecepcion;
    }
}