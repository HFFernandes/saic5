using System.Windows.Forms;
namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmAltaIncidencia066
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmAltaIncidencia066));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOperador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReferencias = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.cmbColonia = new System.Windows.Forms.ComboBox();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbTipoIncidencia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.txtDescripcion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblDescripcionIncidencia = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblTipoIncidencia = new System.Windows.Forms.Label();
            this.txtTelefono = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cklCorporacion = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDenunciante = new System.Windows.Forms.GroupBox();
            this.txtDireccionDenunciante = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtApellidosDenunciante = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtNombreDenunciante = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnVerDatos = new System.Windows.Forms.Button();
            this.cmbCP = new System.Windows.Forms.ComboBox();
            this.saiOrtografia = new C1.Win.C1SpellChecker.C1SpellChecker(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbDenunciante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saiOrtografia)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 50);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(181, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(318, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REGISTRO DE NUEVA INCIDENCIA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOperador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFechaHora);
            this.groupBox1.Location = new System.Drawing.Point(2, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 29);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.lblOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperador.Location = new System.Drawing.Point(360, 10);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(0, 13);
            this.lblOperador.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha/Hora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operador:";
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.Location = new System.Drawing.Point(85, 10);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(0, 13);
            this.lblFechaHora.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Referencias:";
            // 
            // txtReferencias
            // 
            this.txtReferencias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencias.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtReferencias.Location = new System.Drawing.Point(94, 207);
            this.txtReferencias.Multiline = true;
            this.txtReferencias.Name = "txtReferencias";
            this.txtReferencias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferencias.Size = new System.Drawing.Size(528, 44);
            this.saiOrtografia.SetSpellChecking(this.txtReferencias, true);
            this.txtReferencias.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtReferencias.TabIndex = 17;
            this.txtReferencias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // cmbColonia
            // 
            this.cmbColonia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColonia.FormattingEnabled = true;
            this.cmbColonia.Location = new System.Drawing.Point(374, 177);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(248, 21);
            this.cmbColonia.TabIndex = 15;
            this.cmbColonia.SelectedIndexChanged += new System.EventHandler(this.cmbColonia_SelectedIndexChanged);
            this.cmbColonia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Location = new System.Drawing.Point(64, 146);
            this.cmbMunicipio.MaxLength = 75;
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(205, 21);
            this.cmbMunicipio.TabIndex = 9;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            this.cmbMunicipio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(374, 146);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(248, 21);
            this.cmbLocalidad.TabIndex = 11;
            this.cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            this.cmbLocalidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // cmbTipoIncidencia
            // 
            this.cmbTipoIncidencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoIncidencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbTipoIncidencia.BlnEsRequerido = true;
            this.cmbTipoIncidencia.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbTipoIncidencia.Location = new System.Drawing.Point(408, 88);
            this.cmbTipoIncidencia.MaxLength = 150;
            this.cmbTipoIncidencia.Name = "cmbTipoIncidencia";
            this.cmbTipoIncidencia.Size = new System.Drawing.Size(214, 21);
            this.cmbTipoIncidencia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cmbTipoIncidencia.TabIndex = 5;
            this.cmbTipoIncidencia.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIncidencia_SelectedIndexChanged);
            this.cmbTipoIncidencia.Leave += new System.EventHandler(this.cmbTipoIncidencia_Leave);
            this.cmbTipoIncidencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescripcion.Location = new System.Drawing.Point(93, 259);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(529, 44);
            this.saiOrtografia.SetSpellChecking(this.txtDescripcion, true);
            this.txtDescripcion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDescripcion.TabIndex = 19;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // lblDescripcionIncidencia
            // 
            this.lblDescripcionIncidencia.AutoSize = true;
            this.lblDescripcionIncidencia.Location = new System.Drawing.Point(-1, 259);
            this.lblDescripcionIncidencia.Name = "lblDescripcionIncidencia";
            this.lblDescripcionIncidencia.Size = new System.Drawing.Size(91, 26);
            this.lblDescripcionIncidencia.TabIndex = 18;
            this.lblDescripcionIncidencia.Text = "  Descripción \r\n  de la Incidencia:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Colonia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "C.P.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Localidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Municipio:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccion.Location = new System.Drawing.Point(64, 119);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(558, 20);
            this.txtDireccion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDireccion.TabIndex = 7;
            this.txtDireccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Dirección:";
            // 
            // lblTipoIncidencia
            // 
            this.lblTipoIncidencia.AutoSize = true;
            this.lblTipoIncidencia.Location = new System.Drawing.Point(272, 91);
            this.lblTipoIncidencia.Name = "lblTipoIncidencia";
            this.lblTipoIncidencia.Size = new System.Drawing.Size(98, 13);
            this.lblTipoIncidencia.TabIndex = 4;
            this.lblTipoIncidencia.Text = "Tipo de Incidencia:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTelefono.Location = new System.Drawing.Point(64, 89);
            this.txtTelefono.MaxLength = 25;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(203, 20);
            this.txtTelefono.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(3, 91);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // cklCorporacion
            // 
            this.cklCorporacion.CheckOnClick = true;
            this.cklCorporacion.FormattingEnabled = true;
            this.cklCorporacion.Location = new System.Drawing.Point(94, 311);
            this.cklCorporacion.Name = "cklCorporacion";
            this.cklCorporacion.Size = new System.Drawing.Size(528, 94);
            this.cklCorporacion.TabIndex = 21;
            this.cklCorporacion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cklCorporacion_MouseUp);
            this.cklCorporacion.Leave += new System.EventHandler(this.cklCorporacion_Leave);
            this.cklCorporacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cklCorporacion_KeyUp);
            this.cklCorporacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Corporaciones :";
            // 
            // gbDenunciante
            // 
            this.gbDenunciante.Controls.Add(this.txtDireccionDenunciante);
            this.gbDenunciante.Controls.Add(this.label13);
            this.gbDenunciante.Controls.Add(this.label12);
            this.gbDenunciante.Controls.Add(this.txtApellidosDenunciante);
            this.gbDenunciante.Controls.Add(this.label11);
            this.gbDenunciante.Controls.Add(this.txtNombreDenunciante);
            this.gbDenunciante.Location = new System.Drawing.Point(94, 411);
            this.gbDenunciante.Name = "gbDenunciante";
            this.gbDenunciante.Size = new System.Drawing.Size(528, 79);
            this.gbDenunciante.TabIndex = 23;
            this.gbDenunciante.TabStop = false;
            // 
            // txtDireccionDenunciante
            // 
            this.txtDireccionDenunciante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccionDenunciante.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccionDenunciante.Location = new System.Drawing.Point(62, 42);
            this.txtDireccionDenunciante.MaxLength = 500;
            this.txtDireccionDenunciante.Name = "txtDireccionDenunciante";
            this.txtDireccionDenunciante.Size = new System.Drawing.Size(460, 20);
            this.txtDireccionDenunciante.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDireccionDenunciante.TabIndex = 5;
            this.txtDireccionDenunciante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Dirección :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Apellidos :";
            // 
            // txtApellidosDenunciante
            // 
            this.txtApellidosDenunciante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidosDenunciante.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtApellidosDenunciante.Location = new System.Drawing.Point(272, 16);
            this.txtApellidosDenunciante.MaxLength = 50;
            this.txtApellidosDenunciante.Name = "txtApellidosDenunciante";
            this.txtApellidosDenunciante.Size = new System.Drawing.Size(250, 20);
            this.txtApellidosDenunciante.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtApellidosDenunciante.TabIndex = 3;
            this.txtApellidosDenunciante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre :";
            // 
            // txtNombreDenunciante
            // 
            this.txtNombreDenunciante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreDenunciante.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombreDenunciante.Location = new System.Drawing.Point(62, 16);
            this.txtNombreDenunciante.MaxLength = 50;
            this.txtNombreDenunciante.Name = "txtNombreDenunciante";
            this.txtNombreDenunciante.Size = new System.Drawing.Size(137, 20);
            this.txtNombreDenunciante.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtNombreDenunciante.TabIndex = 1;
            this.txtNombreDenunciante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Denunciante :";
            // 
            // btnVerDatos
            // 
            this.btnVerDatos.Enabled = false;
            this.btnVerDatos.Location = new System.Drawing.Point(373, 87);
            this.btnVerDatos.Name = "btnVerDatos";
            this.btnVerDatos.Size = new System.Drawing.Size(33, 23);
            this.btnVerDatos.TabIndex = 24;
            this.btnVerDatos.Text = "(...)";
            this.btnVerDatos.UseVisualStyleBackColor = true;
            this.btnVerDatos.Click += new System.EventHandler(this.btnVerDatos_Click);
            // 
            // cmbCP
            // 
            this.cmbCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCP.FormattingEnabled = true;
            this.cmbCP.Location = new System.Drawing.Point(64, 177);
            this.cmbCP.MaxLength = 5;
            this.cmbCP.Name = "cmbCP";
            this.cmbCP.Size = new System.Drawing.Size(205, 21);
            this.cmbCP.TabIndex = 13;
            this.cmbCP.SelectedIndexChanged += new System.EventHandler(this.cmbCP_SelectedIndexChanged);
            this.cmbCP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCP_KeyPress);
            this.cmbCP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbCP_KeyUp);
            this.cmbCP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCP_KeyDown);
            // 
            // saiOrtografia
            // 
            this.saiOrtografia.Options.DialogLanguage = C1.Win.C1SpellChecker.DialogLanguage.Spanish;
            // 
            // SAIFrmAltaIncidencia066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 516);
            this.Controls.Add(this.cmbCP);
            this.Controls.Add(this.btnVerDatos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbDenunciante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cklCorporacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtReferencias);
            this.Controls.Add(this.cmbColonia);
            this.Controls.Add(this.cmbMunicipio);
            this.Controls.Add(this.cmbLocalidad);
            this.Controls.Add(this.cmbTipoIncidencia);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcionIncidencia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTipoIncidencia);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmAltaIncidencia066";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "REGISTRO DE NUEVA INCIDENCIA";
            this.Load += new System.EventHandler(this.SAIFrmAltaIncidencia066_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SAIFrmAltaIncidencia066_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmAltaIncidencia066_FormClosing);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTelefono, 0);
            this.Controls.SetChildIndex(this.txtTelefono, 0);
            this.Controls.SetChildIndex(this.lblTipoIncidencia, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblDescripcionIncidencia, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.cmbTipoIncidencia, 0);
            this.Controls.SetChildIndex(this.cmbLocalidad, 0);
            this.Controls.SetChildIndex(this.cmbMunicipio, 0);
            this.Controls.SetChildIndex(this.cmbColonia, 0);
            this.Controls.SetChildIndex(this.txtReferencias, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cklCorporacion, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.gbDenunciante, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnVerDatos, 0);
            this.Controls.SetChildIndex(this.cmbCP, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDenunciante.ResumeLayout(false);
            this.gbDenunciante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saiOrtografia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label label10;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtReferencias;
        private ComboBox cmbColonia;
        private ComboBox cmbMunicipio;
        private ComboBox cmbLocalidad;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cmbTipoIncidencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcionIncidencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTipoIncidencia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.CheckedListBox cklCorporacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDenunciante;
        private System.Windows.Forms.Label label4;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDireccionDenunciante;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtApellidosDenunciante;
        private System.Windows.Forms.Label label11;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtNombreDenunciante;
        private System.Windows.Forms.Button btnVerDatos;
        private ComboBox cmbCP;
        private C1.Win.C1SpellChecker.C1SpellChecker saiOrtografia;
    }
}