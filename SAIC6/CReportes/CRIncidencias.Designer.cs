namespace BSD.C4.Tlaxcala.Sai
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
            this.components = new System.ComponentModel.Container();
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
            this.cboEntidades = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpStsIncidencia = new System.Windows.Forms.GroupBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.chkCanceladas = new System.Windows.Forms.CheckBox();
            this.chkCerradas = new System.Windows.Forms.CheckBox();
            this.chkPendientes = new System.Windows.Forms.CheckBox();
            this.chkActivas = new System.Windows.Forms.CheckBox();
            this.chkNuevas = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkDespachadoresTodos = new System.Windows.Forms.CheckBox();
            this.chkOperadoresTodos = new System.Windows.Forms.CheckBox();
            this.chkDespachadores = new System.Windows.Forms.CheckedListBox();
            this.chkOperadores = new System.Windows.Forms.CheckedListBox();
            this.lblDespachadores = new System.Windows.Forms.Label();
            this.lblOperadores = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpStsIncidencia.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
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
            this.cboSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Location = new System.Drawing.Point(59, 17);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(90, 21);
            this.cboSistema.TabIndex = 1;
            this.cboSistema.SelectedIndexChanged += new System.EventHandler(this.cboSistema_SelectedIndexChanged);
            this.cboSistema.Leave += new System.EventHandler(this.cboSistema_Leave);
            this.cboSistema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSistema_KeyPress);
            // 
            // cboTipoIncidencia
            // 
            this.cboTipoIncidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboTipoIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIncidencia.FormattingEnabled = true;
            this.cboTipoIncidencia.Location = new System.Drawing.Point(269, 17);
            this.cboTipoIncidencia.Name = "cboTipoIncidencia";
            this.cboTipoIncidencia.Size = new System.Drawing.Size(152, 21);
            this.cboTipoIncidencia.TabIndex = 2;
            this.cboTipoIncidencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipoIncidencia_KeyPress);
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.Location = new System.Drawing.Point(491, 17);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(121, 21);
            this.cboPrioridad.TabIndex = 3;
            this.cboPrioridad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPrioridad_KeyPress);
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
            this.groupBox1.Size = new System.Drawing.Size(600, 188);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechas";
            // 
            // chkCierre
            // 
            this.chkCierre.AutoSize = true;
            this.chkCierre.Location = new System.Drawing.Point(13, 126);
            this.chkCierre.Name = "chkCierre";
            this.chkCierre.Size = new System.Drawing.Size(70, 17);
            this.chkCierre.TabIndex = 17;
            this.chkCierre.Text = "De Cierre";
            this.chkCierre.UseVisualStyleBackColor = true;
            this.chkCierre.Leave += new System.EventHandler(this.chkCierre_Leave);
            this.chkCierre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkCierre_KeyPress);
            this.chkCierre.Enter += new System.EventHandler(this.chkCierre_Enter);
            this.chkCierre.CheckedChanged += new System.EventHandler(this.chkCierre_CheckedChanged);
            // 
            // chkDespacho
            // 
            this.chkDespacho.AutoSize = true;
            this.chkDespacho.Location = new System.Drawing.Point(13, 76);
            this.chkDespacho.Name = "chkDespacho";
            this.chkDespacho.Size = new System.Drawing.Size(92, 17);
            this.chkDespacho.TabIndex = 14;
            this.chkDespacho.Text = "De Despacho";
            this.chkDespacho.UseVisualStyleBackColor = true;
            this.chkDespacho.Leave += new System.EventHandler(this.chkDespacho_Leave);
            this.chkDespacho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkDespacho_KeyPress);
            this.chkDespacho.Enter += new System.EventHandler(this.chkDespacho_Enter);
            this.chkDespacho.CheckedChanged += new System.EventHandler(this.chkDespacho_CheckedChanged);
            // 
            // chkRecepcion
            // 
            this.chkRecepcion.AutoSize = true;
            this.chkRecepcion.Location = new System.Drawing.Point(13, 26);
            this.chkRecepcion.Name = "chkRecepcion";
            this.chkRecepcion.Size = new System.Drawing.Size(95, 17);
            this.chkRecepcion.TabIndex = 11;
            this.chkRecepcion.Text = "De Recepción";
            this.chkRecepcion.UseVisualStyleBackColor = true;
            this.chkRecepcion.Leave += new System.EventHandler(this.chkRecepcion_Leave);
            this.chkRecepcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkRecepcion_KeyPress);
            this.chkRecepcion.Enter += new System.EventHandler(this.chkRecepcion_Enter);
            this.chkRecepcion.CheckedChanged += new System.EventHandler(this.chkRecepcion_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "al";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 103);
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
            this.dteCierreFin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dteCierreFin.Enabled = false;
            this.dteCierreFin.Location = new System.Drawing.Point(381, 150);
            this.dteCierreFin.Name = "dteCierreFin";
            this.dteCierreFin.Size = new System.Drawing.Size(200, 20);
            this.dteCierreFin.TabIndex = 19;
            this.dteCierreFin.Validating += new System.ComponentModel.CancelEventHandler(this.dteCierreFin_Validating);
            this.dteCierreFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteCierreFin_KeyPress);
            // 
            // dteCierreIni
            // 
            this.dteCierreIni.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dteCierreIni.Enabled = false;
            this.dteCierreIni.Location = new System.Drawing.Point(85, 150);
            this.dteCierreIni.Name = "dteCierreIni";
            this.dteCierreIni.Size = new System.Drawing.Size(200, 20);
            this.dteCierreIni.TabIndex = 18;
            this.dteCierreIni.Validating += new System.ComponentModel.CancelEventHandler(this.dteCierreIni_Validating);
            this.dteCierreIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteCierreIni_KeyPress);
            // 
            // dteDespachoFin
            // 
            this.dteDespachoFin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dteDespachoFin.Enabled = false;
            this.dteDespachoFin.Location = new System.Drawing.Point(381, 99);
            this.dteDespachoFin.Name = "dteDespachoFin";
            this.dteDespachoFin.Size = new System.Drawing.Size(200, 20);
            this.dteDespachoFin.TabIndex = 16;
            this.dteDespachoFin.Validating += new System.ComponentModel.CancelEventHandler(this.dteDespachoFin_Validating);
            this.dteDespachoFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteDespachoFin_KeyPress);
            // 
            // dteDespachoIni
            // 
            this.dteDespachoIni.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dteDespachoIni.Enabled = false;
            this.dteDespachoIni.Location = new System.Drawing.Point(85, 99);
            this.dteDespachoIni.Name = "dteDespachoIni";
            this.dteDespachoIni.Size = new System.Drawing.Size(200, 20);
            this.dteDespachoIni.TabIndex = 15;
            this.dteDespachoIni.Validating += new System.ComponentModel.CancelEventHandler(this.dteDespachoIni_Validating);
            this.dteDespachoIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteDespachoIni_KeyPress);
            // 
            // dteRecepcionFin
            // 
            this.dteRecepcionFin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dteRecepcionFin.Enabled = false;
            this.dteRecepcionFin.Location = new System.Drawing.Point(381, 49);
            this.dteRecepcionFin.Name = "dteRecepcionFin";
            this.dteRecepcionFin.Size = new System.Drawing.Size(200, 20);
            this.dteRecepcionFin.TabIndex = 13;
            this.dteRecepcionFin.Validating += new System.ComponentModel.CancelEventHandler(this.dteRecepcionFin_Validating);
            this.dteRecepcionFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteRecepcionFin_KeyPress);
            // 
            // dteRecepcionIni
            // 
            this.dteRecepcionIni.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dteRecepcionIni.Enabled = false;
            this.dteRecepcionIni.Location = new System.Drawing.Point(85, 49);
            this.dteRecepcionIni.Name = "dteRecepcionIni";
            this.dteRecepcionIni.Size = new System.Drawing.Size(200, 20);
            this.dteRecepcionIni.TabIndex = 12;
            this.dteRecepcionIni.Validating += new System.ComponentModel.CancelEventHandler(this.dteRecepcionIni_Validating);
            this.dteRecepcionIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteRecepcionIni_KeyPress);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 109);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicación";
            // 
            // cboColonia
            // 
            this.cboColonia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColonia.FormattingEnabled = true;
            this.cboColonia.Location = new System.Drawing.Point(85, 70);
            this.cboColonia.Name = "cboColonia";
            this.cboColonia.Size = new System.Drawing.Size(200, 21);
            this.cboColonia.TabIndex = 22;
            this.cboColonia.SelectedIndexChanged += new System.EventHandler(this.cboColonia_SelectedIndexChanged);
            this.cboColonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboColonia_KeyPress);
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
            this.cboCP.BackColor = System.Drawing.Color.White;
            this.cboCP.FormattingEnabled = true;
            this.cboCP.Location = new System.Drawing.Point(381, 70);
            this.cboCP.Name = "cboCP";
            this.cboCP.Size = new System.Drawing.Size(200, 21);
            this.cboCP.TabIndex = 23;
            this.cboCP.Validating += new System.ComponentModel.CancelEventHandler(this.cboCP_Validating);
            this.cboCP.Leave += new System.EventHandler(this.cboCP_Leave);
            this.cboCP.Enter += new System.EventHandler(this.cboCP_Enter);
            this.cboCP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCP_KeyPress);
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
            this.cboLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(381, 27);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(200, 21);
            this.cboLocalidad.TabIndex = 21;
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboLocalidad_SelectedIndexChanged);
            this.cboLocalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLocalidad_KeyPress);
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
            this.cboMunicipio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMunicipio.FormattingEnabled = true;
            this.cboMunicipio.Location = new System.Drawing.Point(85, 27);
            this.cboMunicipio.Name = "cboMunicipio";
            this.cboMunicipio.Size = new System.Drawing.Size(200, 21);
            this.cboMunicipio.TabIndex = 20;
            this.cboMunicipio.SelectedIndexChanged += new System.EventHandler(this.cboMunicipio_SelectedIndexChanged);
            this.cboMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMunicipio_KeyPress);
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
            this.groupBox3.Controls.Add(this.cboEntidades);
            this.groupBox3.Location = new System.Drawing.Point(12, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 54);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entidades Responsables";
            // 
            // cboEntidades
            // 
            this.cboEntidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboEntidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidades.FormattingEnabled = true;
            this.cboEntidades.Location = new System.Drawing.Point(16, 17);
            this.cboEntidades.Name = "cboEntidades";
            this.cboEntidades.Size = new System.Drawing.Size(568, 21);
            this.cboEntidades.TabIndex = 24;
            this.cboEntidades.SelectedIndexChanged += new System.EventHandler(this.cboEntidades_SelectedIndexChanged);
            this.cboEntidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboEntidades_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(64, 627);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 29;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.Leave += new System.EventHandler(this.btnAceptar_Leave);
            this.btnAceptar.Enter += new System.EventHandler(this.btnAceptar_Enter);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(283, 627);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "&Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnLimpiar.Leave += new System.EventHandler(this.btnLimpiar_Leave);
            this.btnLimpiar.Enter += new System.EventHandler(this.btnLimpiar_Enter);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(491, 627);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Leave += new System.EventHandler(this.btnCancelar_Leave);
            this.btnCancelar.Enter += new System.EventHandler(this.btnCancelar_Enter);
            // 
            // grpStsIncidencia
            // 
            this.grpStsIncidencia.Controls.Add(this.chkTodos);
            this.grpStsIncidencia.Controls.Add(this.chkCanceladas);
            this.grpStsIncidencia.Controls.Add(this.chkCerradas);
            this.grpStsIncidencia.Controls.Add(this.chkPendientes);
            this.grpStsIncidencia.Controls.Add(this.chkActivas);
            this.grpStsIncidencia.Controls.Add(this.chkNuevas);
            this.grpStsIncidencia.Location = new System.Drawing.Point(12, 44);
            this.grpStsIncidencia.Name = "grpStsIncidencia";
            this.grpStsIncidencia.Size = new System.Drawing.Size(600, 50);
            this.grpStsIncidencia.TabIndex = 4;
            this.grpStsIncidencia.TabStop = false;
            this.grpStsIncidencia.Text = "Estado de la Incidencia";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(501, 18);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 10;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.Leave += new System.EventHandler(this.chkTodos_Leave);
            this.chkTodos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkTodos_KeyPress);
            this.chkTodos.Enter += new System.EventHandler(this.chkTodos_Enter);
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // chkCanceladas
            // 
            this.chkCanceladas.AutoSize = true;
            this.chkCanceladas.Location = new System.Drawing.Point(398, 19);
            this.chkCanceladas.Name = "chkCanceladas";
            this.chkCanceladas.Size = new System.Drawing.Size(82, 17);
            this.chkCanceladas.TabIndex = 9;
            this.chkCanceladas.Text = "Canceladas";
            this.chkCanceladas.UseVisualStyleBackColor = true;
            this.chkCanceladas.Leave += new System.EventHandler(this.chkCanceladas_Leave);
            this.chkCanceladas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkCanceladas_KeyPress);
            this.chkCanceladas.Enter += new System.EventHandler(this.chkCanceladas_Enter);
            this.chkCanceladas.CheckedChanged += new System.EventHandler(this.chkCanceladas_CheckedChanged);
            // 
            // chkCerradas
            // 
            this.chkCerradas.AutoSize = true;
            this.chkCerradas.Location = new System.Drawing.Point(303, 19);
            this.chkCerradas.Name = "chkCerradas";
            this.chkCerradas.Size = new System.Drawing.Size(68, 17);
            this.chkCerradas.TabIndex = 8;
            this.chkCerradas.Text = "Cerradas";
            this.chkCerradas.UseVisualStyleBackColor = true;
            this.chkCerradas.Leave += new System.EventHandler(this.chkCerradas_Leave);
            this.chkCerradas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkCerradas_KeyPress);
            this.chkCerradas.Enter += new System.EventHandler(this.chkCerradas_Enter);
            this.chkCerradas.CheckedChanged += new System.EventHandler(this.chkCerradas_CheckedChanged);
            // 
            // chkPendientes
            // 
            this.chkPendientes.AutoSize = true;
            this.chkPendientes.Location = new System.Drawing.Point(197, 19);
            this.chkPendientes.Name = "chkPendientes";
            this.chkPendientes.Size = new System.Drawing.Size(79, 17);
            this.chkPendientes.TabIndex = 7;
            this.chkPendientes.Text = "Pendientes";
            this.chkPendientes.UseVisualStyleBackColor = true;
            this.chkPendientes.Leave += new System.EventHandler(this.chkPendientes_Leave);
            this.chkPendientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkPendientes_KeyPress);
            this.chkPendientes.Enter += new System.EventHandler(this.chkPendientes_Enter);
            this.chkPendientes.CheckedChanged += new System.EventHandler(this.chkPendientes_CheckedChanged);
            // 
            // chkActivas
            // 
            this.chkActivas.AutoSize = true;
            this.chkActivas.Location = new System.Drawing.Point(109, 19);
            this.chkActivas.Name = "chkActivas";
            this.chkActivas.Size = new System.Drawing.Size(61, 17);
            this.chkActivas.TabIndex = 6;
            this.chkActivas.Text = "Activas";
            this.chkActivas.UseVisualStyleBackColor = true;
            this.chkActivas.Leave += new System.EventHandler(this.chkActivas_Leave);
            this.chkActivas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkActivas_KeyPress);
            this.chkActivas.Enter += new System.EventHandler(this.chkActivas_Enter);
            this.chkActivas.CheckedChanged += new System.EventHandler(this.chkActivas_CheckedChanged);
            // 
            // chkNuevas
            // 
            this.chkNuevas.AutoSize = true;
            this.chkNuevas.BackColor = System.Drawing.SystemColors.Control;
            this.chkNuevas.Location = new System.Drawing.Point(19, 18);
            this.chkNuevas.Name = "chkNuevas";
            this.chkNuevas.Size = new System.Drawing.Size(63, 17);
            this.chkNuevas.TabIndex = 5;
            this.chkNuevas.Text = "Nuevas";
            this.chkNuevas.UseVisualStyleBackColor = false;
            this.chkNuevas.Leave += new System.EventHandler(this.chkNuevas_Leave);
            this.chkNuevas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkNuevas_KeyPress);
            this.chkNuevas.Enter += new System.EventHandler(this.chkNuevas_Enter);
            this.chkNuevas.CheckedChanged += new System.EventHandler(this.chkNuevas_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkDespachadoresTodos);
            this.groupBox5.Controls.Add(this.chkOperadoresTodos);
            this.groupBox5.Controls.Add(this.chkDespachadores);
            this.groupBox5.Controls.Add(this.chkOperadores);
            this.groupBox5.Controls.Add(this.lblDespachadores);
            this.groupBox5.Controls.Add(this.lblOperadores);
            this.groupBox5.Location = new System.Drawing.Point(12, 457);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(600, 159);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Usuarios";
            // 
            // chkDespachadoresTodos
            // 
            this.chkDespachadoresTodos.AutoSize = true;
            this.chkDespachadoresTodos.Enabled = false;
            this.chkDespachadoresTodos.Location = new System.Drawing.Point(384, 28);
            this.chkDespachadoresTodos.Name = "chkDespachadoresTodos";
            this.chkDespachadoresTodos.Size = new System.Drawing.Size(115, 17);
            this.chkDespachadoresTodos.TabIndex = 27;
            this.chkDespachadoresTodos.Text = "Seleccionar Todos";
            this.chkDespachadoresTodos.UseVisualStyleBackColor = true;
            this.chkDespachadoresTodos.Leave += new System.EventHandler(this.chkDespachadoresTodos_Leave);
            this.chkDespachadoresTodos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkDespachadoresTodos_KeyPress);
            this.chkDespachadoresTodos.Enter += new System.EventHandler(this.chkDespachadoresTodos_Enter);
            this.chkDespachadoresTodos.CheckedChanged += new System.EventHandler(this.chkDespachadoresTodos_CheckedChanged);
            // 
            // chkOperadoresTodos
            // 
            this.chkOperadoresTodos.AutoSize = true;
            this.chkOperadoresTodos.Enabled = false;
            this.chkOperadoresTodos.Location = new System.Drawing.Point(88, 28);
            this.chkOperadoresTodos.Name = "chkOperadoresTodos";
            this.chkOperadoresTodos.Size = new System.Drawing.Size(115, 17);
            this.chkOperadoresTodos.TabIndex = 25;
            this.chkOperadoresTodos.Text = "Seleccionar Todos";
            this.chkOperadoresTodos.UseVisualStyleBackColor = true;
            this.chkOperadoresTodos.Leave += new System.EventHandler(this.chkOperadoresTodos_Leave);
            this.chkOperadoresTodos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkOperadoresTodos_KeyPress);
            this.chkOperadoresTodos.Enter += new System.EventHandler(this.chkOperadoresTodos_Enter);
            this.chkOperadoresTodos.CheckedChanged += new System.EventHandler(this.chkOperadoresTodos_CheckedChanged);
            // 
            // chkDespachadores
            // 
            this.chkDespachadores.Enabled = false;
            this.chkDespachadores.FormattingEnabled = true;
            this.chkDespachadores.Location = new System.Drawing.Point(381, 51);
            this.chkDespachadores.Name = "chkDespachadores";
            this.chkDespachadores.Size = new System.Drawing.Size(200, 94);
            this.chkDespachadores.TabIndex = 28;
            this.chkDespachadores.Leave += new System.EventHandler(this.chkDespachadores_Leave);
            this.chkDespachadores.Enter += new System.EventHandler(this.chkDespachadores_Enter);
            this.chkDespachadores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkDespachadores_KeyPress);
            // 
            // chkOperadores
            // 
            this.chkOperadores.Enabled = false;
            this.chkOperadores.FormattingEnabled = true;
            this.chkOperadores.Location = new System.Drawing.Point(85, 51);
            this.chkOperadores.Name = "chkOperadores";
            this.chkOperadores.Size = new System.Drawing.Size(200, 94);
            this.chkOperadores.TabIndex = 26;
            this.chkOperadores.Leave += new System.EventHandler(this.chkOperadores_Leave);
            this.chkOperadores.Enter += new System.EventHandler(this.chkOperadores_Enter);
            this.chkOperadores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkOperadores_KeyPress);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
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
            this.Text = "SAI - Reporte de Incidencias";
            this.Load += new System.EventHandler(this.CRIncidencias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grpStsIncidencia.ResumeLayout(false);
            this.grpStsIncidencia.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
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
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpStsIncidencia;
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
        private System.Windows.Forms.CheckBox chkNuevas;
        private System.Windows.Forms.CheckBox chkActivas;
        private System.Windows.Forms.CheckBox chkPendientes;
        private System.Windows.Forms.CheckBox chkCanceladas;
        private System.Windows.Forms.CheckBox chkCerradas;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cboEntidades;
        private System.Windows.Forms.CheckBox chkOperadoresTodos;
        private System.Windows.Forms.CheckBox chkDespachadoresTodos;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}