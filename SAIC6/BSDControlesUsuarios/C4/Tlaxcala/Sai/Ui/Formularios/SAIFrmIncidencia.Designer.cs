namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIncidencia
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOperador = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDireccion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescripcion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.cmbTipoIncidencia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cmbLocalidad = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cmbMunicipio = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cmbCP = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cmbColonia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.saiLogoControl = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAILogoControl();
            this.grpExtravio = new System.Windows.Forms.GroupBox();
            this.dgvPersonaExtraviada = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView(this.components);
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaExtravio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tez = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCabello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorCabello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LargoCabello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cejas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OjosColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OjosForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NarizForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BocaTamaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vestimenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caracteristicas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuBorrarExtravio = new System.Windows.Forms.MenuStrip();
            this.grpRoboVehiculo = new System.Windows.Forms.GroupBox();
            this.dgvVehiculo = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView(this.components);
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeñasParticulares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.grpExtravio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonaExtraviada)).BeginInit();
            this.grpRoboVehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha/Hora:";
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.Location = new System.Drawing.Point(82, 16);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(0, 13);
            this.lblFechaHora.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operador:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOperador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFechaHora);
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 33);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.lblOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperador.Location = new System.Drawing.Point(360, 16);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(0, 13);
            this.lblOperador.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTelefono.Location = new System.Drawing.Point(67, 117);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(203, 20);
            this.txtTelefono.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtTelefono.TabIndex = 6;
            this.txtTelefono.Leave += new System.EventHandler(this.txtTelefono_Leave);
            this.txtTelefono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTelefono_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo de Incidencia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccion.Location = new System.Drawing.Point(67, 150);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(517, 20);
            this.txtDireccion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDireccion.TabIndex = 10;
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            this.txtDireccion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDireccion_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Municipio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Localidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "C.P.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Clolonia:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 26);
            this.label10.TabIndex = 19;
            this.label10.Text = "  Descripción \r\nde la Incidencia:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescripcion.Location = new System.Drawing.Point(96, 257);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(488, 90);
            this.txtDescripcion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDescripcion.TabIndex = 20;
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // cmbTipoIncidencia
            // 
            this.cmbTipoIncidencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoIncidencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoIncidencia.BlnEsRequerido = true;
            this.cmbTipoIncidencia.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbTipoIncidencia.FormattingEnabled = true;
            this.cmbTipoIncidencia.Location = new System.Drawing.Point(377, 116);
            this.cmbTipoIncidencia.Name = "cmbTipoIncidencia";
            this.cmbTipoIncidencia.Size = new System.Drawing.Size(205, 21);
            this.cmbTipoIncidencia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbTipoIncidencia.TabIndex = 8;
            this.cmbTipoIncidencia.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIncidencia_SelectedIndexChanged);
            this.cmbTipoIncidencia.Leave += new System.EventHandler(this.cmbTipoIncidencia_Leave);
            this.cmbTipoIncidencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbTipoIncidencia_KeyUp);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(377, 177);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(205, 21);
            this.cmbLocalidad.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbLocalidad.TabIndex = 14;
            this.cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            this.cmbLocalidad.Leave += new System.EventHandler(this.cmbLocalidad_Leave);
            this.cmbLocalidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbLocalidad_KeyUp);
            this.cmbLocalidad.TextUpdate += new System.EventHandler(this.cmbLocalidad_TextUpdate);
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMunicipio.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(67, 179);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(205, 21);
            this.cmbMunicipio.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbMunicipio.TabIndex = 12;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            this.cmbMunicipio.Leave += new System.EventHandler(this.cmbMunicipio_Leave);
            this.cmbMunicipio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbMunicipio_KeyUp);
            this.cmbMunicipio.TextUpdate += new System.EventHandler(this.cmbMunicipio_TextUpdate);
            // 
            // cmbCP
            // 
            this.cmbCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCP.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbCP.FormattingEnabled = true;
            this.cmbCP.Location = new System.Drawing.Point(67, 215);
            this.cmbCP.Name = "cmbCP";
            this.cmbCP.Size = new System.Drawing.Size(205, 21);
            this.cmbCP.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbCP.TabIndex = 16;
            this.cmbCP.SelectedIndexChanged += new System.EventHandler(this.cmbCP_SelectedIndexChanged);
            this.cmbCP.Leave += new System.EventHandler(this.cmbCP_Leave);
            this.cmbCP.Enter += new System.EventHandler(this.cmbCP_Enter);
            this.cmbCP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbCP_KeyUp);
            this.cmbCP.TextUpdate += new System.EventHandler(this.cmbCP_TextUpdate);
            // 
            // cmbColonia
            // 
            this.cmbColonia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbColonia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColonia.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbColonia.FormattingEnabled = true;
            this.cmbColonia.Location = new System.Drawing.Point(377, 217);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(205, 21);
            this.cmbColonia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbColonia.TabIndex = 18;
            this.cmbColonia.SelectedIndexChanged += new System.EventHandler(this.cmbColonia_SelectedIndexChanged);
            this.cmbColonia.Leave += new System.EventHandler(this.cmbColonia_Leave);
            this.cmbColonia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbColonia_KeyUp);
            this.cmbColonia.TextUpdate += new System.EventHandler(this.cmbColonia_TextUpdate);
            // 
            // saiLogoControl
            // 
            this.saiLogoControl.BackColor = System.Drawing.Color.White;
            this.saiLogoControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.saiLogoControl.Location = new System.Drawing.Point(0, 0);
            this.saiLogoControl.Name = "saiLogoControl";
            this.saiLogoControl.Size = new System.Drawing.Size(599, 70);
            this.saiLogoControl.TabIndex = 21;
            this.saiLogoControl.VelocidadAnimacion = 8;
            // 
            // grpExtravio
            // 
            this.grpExtravio.Controls.Add(this.dgvPersonaExtraviada);
            this.grpExtravio.Location = new System.Drawing.Point(6, 12);
            this.grpExtravio.Name = "grpExtravio";
            this.grpExtravio.Size = new System.Drawing.Size(572, 224);
            this.grpExtravio.TabIndex = 22;
            this.grpExtravio.TabStop = false;
            this.grpExtravio.Text = "Extravío de Persona";
            this.grpExtravio.Visible = false;
            this.grpExtravio.Enter += new System.EventHandler(this.grpExtravio_Enter);
            // 
            // dgvPersonaExtraviada
            // 
            this.dgvPersonaExtraviada.AllowUserToOrderColumns = true;
            this.dgvPersonaExtraviada.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dgvPersonaExtraviada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonaExtraviada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Folio,
            this.Nombre,
            this.Edad,
            this.Sexo,
            this.Estatura,
            this.Parentesco,
            this.FechaExtravio,
            this.Tez,
            this.TipoCabello,
            this.ColorCabello,
            this.LargoCabello,
            this.Frente,
            this.Cejas,
            this.OjosColor,
            this.OjosForma,
            this.NarizForma,
            this.BocaTamaño,
            this.Labios,
            this.Vestimenta,
            this.Destino,
            this.Caracteristicas});
            this.dgvPersonaExtraviada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonaExtraviada.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPersonaExtraviada.Location = new System.Drawing.Point(3, 16);
            this.dgvPersonaExtraviada.Name = "dgvPersonaExtraviada";
            this.dgvPersonaExtraviada.RowHeadersVisible = false;
            this.dgvPersonaExtraviada.Size = new System.Drawing.Size(566, 205);
            this.dgvPersonaExtraviada.TabIndex = 0;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.Visible = false;
            // 
            // Folio
            // 
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 300;
            // 
            // Edad
            // 
            this.Edad.HeaderText = "Edad";
            this.Edad.Name = "Edad";
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            // 
            // Estatura
            // 
            this.Estatura.HeaderText = "Estatura";
            this.Estatura.Name = "Estatura";
            // 
            // Parentesco
            // 
            this.Parentesco.HeaderText = "Parentesco";
            this.Parentesco.Name = "Parentesco";
            // 
            // FechaExtravio
            // 
            this.FechaExtravio.HeaderText = "Fecha de Extravío";
            this.FechaExtravio.Name = "FechaExtravio";
            // 
            // Tez
            // 
            this.Tez.HeaderText = "Tez";
            this.Tez.Name = "Tez";
            // 
            // TipoCabello
            // 
            this.TipoCabello.HeaderText = "Tipo de Cabello";
            this.TipoCabello.Name = "TipoCabello";
            // 
            // ColorCabello
            // 
            this.ColorCabello.HeaderText = "Color de Cabello";
            this.ColorCabello.Name = "ColorCabello";
            // 
            // LargoCabello
            // 
            this.LargoCabello.HeaderText = "Largo de Cabello";
            this.LargoCabello.Name = "LargoCabello";
            // 
            // Frente
            // 
            this.Frente.HeaderText = "Frente";
            this.Frente.Name = "Frente";
            // 
            // Cejas
            // 
            this.Cejas.HeaderText = "Cejas";
            this.Cejas.Name = "Cejas";
            // 
            // OjosColor
            // 
            this.OjosColor.HeaderText = "Color de Ojos";
            this.OjosColor.Name = "OjosColor";
            // 
            // OjosForma
            // 
            this.OjosForma.HeaderText = "Forma de Ojos";
            this.OjosForma.Name = "OjosForma";
            // 
            // NarizForma
            // 
            this.NarizForma.HeaderText = "Forma de Nariz";
            this.NarizForma.Name = "NarizForma";
            // 
            // BocaTamaño
            // 
            this.BocaTamaño.HeaderText = "Tamaño de Boca";
            this.BocaTamaño.Name = "BocaTamaño";
            // 
            // Labios
            // 
            this.Labios.HeaderText = "Labios";
            this.Labios.Name = "Labios";
            // 
            // Vestimenta
            // 
            this.Vestimenta.HeaderText = "Vestimenta";
            this.Vestimenta.Name = "Vestimenta";
            // 
            // Destino
            // 
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            // 
            // Caracteristicas
            // 
            this.Caracteristicas.HeaderText = "Caracteristicas";
            this.Caracteristicas.Name = "Caracteristicas";
            // 
            // mnuBorrarExtravio
            // 
            this.mnuBorrarExtravio.Location = new System.Drawing.Point(0, 70);
            this.mnuBorrarExtravio.Name = "mnuBorrarExtravio";
            this.mnuBorrarExtravio.Size = new System.Drawing.Size(599, 24);
            this.mnuBorrarExtravio.TabIndex = 23;
            this.mnuBorrarExtravio.Text = "Borrar";
            // 
            // grpRoboVehiculo
            // 
            this.grpRoboVehiculo.Controls.Add(this.dgvVehiculo);
            this.grpRoboVehiculo.Location = new System.Drawing.Point(6, 251);
            this.grpRoboVehiculo.Name = "grpRoboVehiculo";
            this.grpRoboVehiculo.Size = new System.Drawing.Size(572, 224);
            this.grpRoboVehiculo.TabIndex = 24;
            this.grpRoboVehiculo.TabStop = false;
            this.grpRoboVehiculo.Text = "Robo de Vehículo";
            this.grpRoboVehiculo.Visible = false;
            // 
            // dgvVehiculo
            // 
            this.dgvVehiculo.AllowUserToOrderColumns = true;
            this.dgvVehiculo.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dgvVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Marca,
            this.Tipo,
            this.Modelo,
            this.Placas,
            this.Color,
            this.NumeroSerie,
            this.SeñasParticulares});
            this.dgvVehiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVehiculo.Location = new System.Drawing.Point(3, 16);
            this.dgvVehiculo.Name = "dgvVehiculo";
            this.dgvVehiculo.RowHeadersVisible = false;
            this.dgvVehiculo.Size = new System.Drawing.Size(566, 205);
            this.dgvVehiculo.TabIndex = 0;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            // 
            // Placas
            // 
            this.Placas.HeaderText = "Placas";
            this.Placas.Name = "Placas";
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            // 
            // NumeroSerie
            // 
            this.NumeroSerie.HeaderText = "Número de Serie";
            this.NumeroSerie.Name = "NumeroSerie";
            // 
            // SeñasParticulares
            // 
            this.SeñasParticulares.HeaderText = "Señas Particulares";
            this.SeñasParticulares.Name = "SeñasParticulares";
            // 
            // SAIFrmIncidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(599, 489);
            this.Controls.Add(this.grpRoboVehiculo);
            this.Controls.Add(this.mnuBorrarExtravio);
            this.Controls.Add(this.grpExtravio);
            this.Controls.Add(this.saiLogoControl);
            this.Controls.Add(this.cmbColonia);
            this.Controls.Add(this.cmbCP);
            this.Controls.Add(this.cmbMunicipio);
            this.Controls.Add(this.cmbLocalidad);
            this.Controls.Add(this.cmbTipoIncidencia);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label3);
            this.MainMenuStrip = this.mnuBorrarExtravio;
            this.MaximizeBox = false;
            this.Name = "SAIFrmIncidencia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SAIFrmIncidencia";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTelefono, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.cmbTipoIncidencia, 0);
            this.Controls.SetChildIndex(this.cmbLocalidad, 0);
            this.Controls.SetChildIndex(this.cmbMunicipio, 0);
            this.Controls.SetChildIndex(this.cmbCP, 0);
            this.Controls.SetChildIndex(this.cmbColonia, 0);
            this.Controls.SetChildIndex(this.saiLogoControl, 0);
            this.Controls.SetChildIndex(this.grpExtravio, 0);
            this.Controls.SetChildIndex(this.mnuBorrarExtravio, 0);
            this.Controls.SetChildIndex(this.grpRoboVehiculo, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpExtravio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonaExtraviada)).EndInit();
            this.grpRoboVehiculo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label label3;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDescripcion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbTipoIncidencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbLocalidad;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbMunicipio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbCP;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbColonia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAILogoControl saiLogoControl;
        private System.Windows.Forms.GroupBox grpExtravio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView dgvPersonaExtraviada;
        private System.Windows.Forms.MenuStrip mnuBorrarExtravio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaExtravio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tez;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCabello;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorCabello;
        private System.Windows.Forms.DataGridViewTextBoxColumn LargoCabello;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cejas;
        private System.Windows.Forms.DataGridViewTextBoxColumn OjosColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn OjosForma;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarizForma;
        private System.Windows.Forms.DataGridViewTextBoxColumn BocaTamaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vestimenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caracteristicas;
        private System.Windows.Forms.GroupBox grpRoboVehiculo;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView dgvVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeñasParticulares;
    }
}