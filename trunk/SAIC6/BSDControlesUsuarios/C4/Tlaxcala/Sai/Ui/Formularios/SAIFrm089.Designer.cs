namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrm089
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrm089));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.lblOperador = new System.Windows.Forms.Label();
            this.lblTipoDenuncia = new System.Windows.Forms.Label();
            this.llblDireccion = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblDenuncia = new System.Windows.Forms.Label();
            this.lblAliasDelincuente = new System.Windows.Forms.Label();
            this.lblOficioEnvio = new System.Windows.Forms.Label();
            this.cbxTipoDenuncia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.txtDireccion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtReferencias = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtDescripcionDenuncia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtAliasDelincuente = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtOficioEnvio = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.cbxMunicipio = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cbxLocalidad = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cbxColonia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.lblFechaDocumento = new System.Windows.Forms.Label();
            this.dtpFechaDoc = new System.Windows.Forms.DateTimePicker();
            this.chkFechaDoc = new System.Windows.Forms.CheckBox();
            this.btnDependencias = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbxCP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.pictureBox1.Size = new System.Drawing.Size(584, 50);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFechaHora);
            this.groupBox1.Controls.Add(this.lblOperador);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 40);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.Location = new System.Drawing.Point(6, 16);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(87, 13);
            this.lblFechaHora.TabIndex = 28;
            this.lblFechaHora.Text = "Fecha / Hora:";
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.lblOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperador.Location = new System.Drawing.Point(278, 16);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(63, 13);
            this.lblOperador.TabIndex = 29;
            this.lblOperador.Text = "Operador:";
            // 
            // lblTipoDenuncia
            // 
            this.lblTipoDenuncia.AutoSize = true;
            this.lblTipoDenuncia.Location = new System.Drawing.Point(12, 104);
            this.lblTipoDenuncia.Name = "lblTipoDenuncia";
            this.lblTipoDenuncia.Size = new System.Drawing.Size(106, 13);
            this.lblTipoDenuncia.TabIndex = 30;
            this.lblTipoDenuncia.Text = "Tipo de la Denuncia:";
            // 
            // llblDireccion
            // 
            this.llblDireccion.AutoSize = true;
            this.llblDireccion.Location = new System.Drawing.Point(12, 131);
            this.llblDireccion.Name = "llblDireccion";
            this.llblDireccion.Size = new System.Drawing.Size(55, 13);
            this.llblDireccion.TabIndex = 31;
            this.llblDireccion.Text = "Dirección:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(310, 157);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 32;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(310, 184);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(45, 13);
            this.lblColonia.TabIndex = 33;
            this.lblColonia.Text = "Colonia:";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(12, 157);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(55, 13);
            this.lblMunicipio.TabIndex = 34;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(12, 184);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(30, 13);
            this.lblCP.TabIndex = 35;
            this.lblCP.Text = "C.P.:";
            // 
            // lblReferencias
            // 
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Location = new System.Drawing.Point(9, 215);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(67, 13);
            this.lblReferencias.TabIndex = 36;
            this.lblReferencias.Text = "Referencias:";
            // 
            // lblDenuncia
            // 
            this.lblDenuncia.Location = new System.Drawing.Point(9, 302);
            this.lblDenuncia.Name = "lblDenuncia";
            this.lblDenuncia.Size = new System.Drawing.Size(67, 63);
            this.lblDenuncia.TabIndex = 37;
            this.lblDenuncia.Text = "Descripción de la Denuncia:";
            // 
            // lblAliasDelincuente
            // 
            this.lblAliasDelincuente.AutoSize = true;
            this.lblAliasDelincuente.Location = new System.Drawing.Point(9, 393);
            this.lblAliasDelincuente.Name = "lblAliasDelincuente";
            this.lblAliasDelincuente.Size = new System.Drawing.Size(92, 13);
            this.lblAliasDelincuente.TabIndex = 38;
            this.lblAliasDelincuente.Text = "Alias Delincuente:";
            // 
            // lblOficioEnvio
            // 
            this.lblOficioEnvio.Location = new System.Drawing.Point(9, 413);
            this.lblOficioEnvio.Name = "lblOficioEnvio";
            this.lblOficioEnvio.Size = new System.Drawing.Size(93, 29);
            this.lblOficioEnvio.TabIndex = 39;
            this.lblOficioEnvio.Text = "Número de oficio para envío:";
            // 
            // cbxTipoDenuncia
            // 
            this.cbxTipoDenuncia.BlnEsRequerido = true;
            this.cbxTipoDenuncia.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxTipoDenuncia.FormattingEnabled = true;
            this.cbxTipoDenuncia.Location = new System.Drawing.Point(130, 101);
            this.cbxTipoDenuncia.Name = "cbxTipoDenuncia";
            this.cbxTipoDenuncia.Size = new System.Drawing.Size(300, 21);
            this.cbxTipoDenuncia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cbxTipoDenuncia.TabIndex = 1;
            this.cbxTipoDenuncia.SelectedIndexChanged += new System.EventHandler(this.cbxTipoDenuncia_SelectedIndexChanged);
            this.cbxTipoDenuncia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxTipoDenuncia_KeyUp);
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccion.Location = new System.Drawing.Point(82, 128);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(490, 20);
            this.txtDireccion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            this.txtDireccion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDireccion_KeyUp);
            // 
            // txtReferencias
            // 
            this.txtReferencias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencias.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtReferencias.Location = new System.Drawing.Point(82, 208);
            this.txtReferencias.Multiline = true;
            this.txtReferencias.Name = "txtReferencias";
            this.txtReferencias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferencias.Size = new System.Drawing.Size(490, 85);
            this.txtReferencias.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtReferencias.TabIndex = 7;
            this.txtReferencias.Leave += new System.EventHandler(this.txtReferencias_Leave);
            // 
            // txtDescripcionDenuncia
            // 
            this.txtDescripcionDenuncia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionDenuncia.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescripcionDenuncia.Location = new System.Drawing.Point(82, 299);
            this.txtDescripcionDenuncia.Multiline = true;
            this.txtDescripcionDenuncia.Name = "txtDescripcionDenuncia";
            this.txtDescripcionDenuncia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionDenuncia.Size = new System.Drawing.Size(490, 85);
            this.txtDescripcionDenuncia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDescripcionDenuncia.TabIndex = 8;
            // 
            // txtAliasDelincuente
            // 
            this.txtAliasDelincuente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAliasDelincuente.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAliasDelincuente.Location = new System.Drawing.Point(107, 390);
            this.txtAliasDelincuente.MaxLength = 50;
            this.txtAliasDelincuente.Name = "txtAliasDelincuente";
            this.txtAliasDelincuente.Size = new System.Drawing.Size(175, 20);
            this.txtAliasDelincuente.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtAliasDelincuente.TabIndex = 9;
            this.txtAliasDelincuente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAliasDelincuente_KeyUp);
            // 
            // txtOficioEnvio
            // 
            this.txtOficioEnvio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOficioEnvio.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOficioEnvio.Location = new System.Drawing.Point(107, 419);
            this.txtOficioEnvio.MaxLength = 50;
            this.txtOficioEnvio.Name = "txtOficioEnvio";
            this.txtOficioEnvio.Size = new System.Drawing.Size(175, 20);
            this.txtOficioEnvio.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtOficioEnvio.TabIndex = 10;
            this.txtOficioEnvio.TextChanged += new System.EventHandler(this.txtOficioEnvio_TextChanged);
            this.txtOficioEnvio.Leave += new System.EventHandler(this.txtOficioEnvio_Leave);
            this.txtOficioEnvio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOficioEnvio_KeyUp);
            // 
            // cbxMunicipio
            // 
            this.cbxMunicipio.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMunicipio.FormattingEnabled = true;
            this.cbxMunicipio.Location = new System.Drawing.Point(82, 154);
            this.cbxMunicipio.Name = "cbxMunicipio";
            this.cbxMunicipio.Size = new System.Drawing.Size(200, 21);
            this.cbxMunicipio.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cbxMunicipio.TabIndex = 3;
            this.cbxMunicipio.SelectedIndexChanged += new System.EventHandler(this.cbxMunicipio_SelectedIndexChanged);
            this.cbxMunicipio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxMunicipio_KeyUp);
            // 
            // cbxLocalidad
            // 
            this.cbxLocalidad.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLocalidad.FormattingEnabled = true;
            this.cbxLocalidad.Location = new System.Drawing.Point(372, 154);
            this.cbxLocalidad.Name = "cbxLocalidad";
            this.cbxLocalidad.Size = new System.Drawing.Size(200, 21);
            this.cbxLocalidad.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cbxLocalidad.TabIndex = 4;
            this.cbxLocalidad.SelectedIndexChanged += new System.EventHandler(this.cbxLocalidad_SelectedIndexChanged);
            this.cbxLocalidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxLocalidad_KeyUp);
            // 
            // cbxColonia
            // 
            this.cbxColonia.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxColonia.FormattingEnabled = true;
            this.cbxColonia.Location = new System.Drawing.Point(372, 181);
            this.cbxColonia.Name = "cbxColonia";
            this.cbxColonia.Size = new System.Drawing.Size(200, 21);
            this.cbxColonia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.cbxColonia.TabIndex = 6;
            this.cbxColonia.SelectedIndexChanged += new System.EventHandler(this.cbxColonia_SelectedIndexChanged);
            this.cbxColonia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxColonia_KeyUp);
            // 
            // lblFechaDocumento
            // 
            this.lblFechaDocumento.AutoSize = true;
            this.lblFechaDocumento.Location = new System.Drawing.Point(315, 419);
            this.lblFechaDocumento.Name = "lblFechaDocumento";
            this.lblFechaDocumento.Size = new System.Drawing.Size(115, 13);
            this.lblFechaDocumento.TabIndex = 50;
            this.lblFechaDocumento.Text = "Fecha del Documento:";
            // 
            // dtpFechaDoc
            // 
            this.dtpFechaDoc.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDoc.Enabled = false;
            this.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDoc.Location = new System.Drawing.Point(436, 416);
            this.dtpFechaDoc.Name = "dtpFechaDoc";
            this.dtpFechaDoc.Size = new System.Drawing.Size(115, 20);
            this.dtpFechaDoc.TabIndex = 11;
            this.dtpFechaDoc.ValueChanged += new System.EventHandler(this.dtpFechaDoc_ValueChanged);
            // 
            // chkFechaDoc
            // 
            this.chkFechaDoc.AutoSize = true;
            this.chkFechaDoc.Location = new System.Drawing.Point(557, 419);
            this.chkFechaDoc.Name = "chkFechaDoc";
            this.chkFechaDoc.Size = new System.Drawing.Size(15, 14);
            this.chkFechaDoc.TabIndex = 52;
            this.chkFechaDoc.UseVisualStyleBackColor = true;
            this.chkFechaDoc.CheckedChanged += new System.EventHandler(this.chkFechaDoc_CheckedChanged);
            // 
            // btnDependencias
            // 
            this.btnDependencias.Enabled = false;
            this.btnDependencias.Location = new System.Drawing.Point(466, 475);
            this.btnDependencias.Name = "btnDependencias";
            this.btnDependencias.Size = new System.Drawing.Size(106, 23);
            this.btnDependencias.TabIndex = 53;
            this.btnDependencias.Text = "Dependencias...";
            this.btnDependencias.UseVisualStyleBackColor = true;
            this.btnDependencias.Click += new System.EventHandler(this.btnDependencias_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(233, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(318, 24);
            this.lblTitulo.TabIndex = 54;
            this.lblTitulo.Text = "REGISTRO DE NUEVA INCIDENCIA";
            // 
            // cbxCP
            // 
            this.cbxCP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxCP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCP.FormattingEnabled = true;
            this.cbxCP.Location = new System.Drawing.Point(82, 181);
            this.cbxCP.MaxLength = 5;
            this.cbxCP.Name = "cbxCP";
            this.cbxCP.Size = new System.Drawing.Size(200, 21);
            this.cbxCP.TabIndex = 55;
            this.cbxCP.SelectedIndexChanged += new System.EventHandler(this.cbxCP_SelectedIndexChanged);
            this.cbxCP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxCP_KeyPress);
            this.cbxCP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxCP_KeyUp);
            this.cbxCP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxCP_KeyDown);
            // 
            // SAIFrm089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 531);
            this.Controls.Add(this.cbxCP);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnDependencias);
            this.Controls.Add(this.chkFechaDoc);
            this.Controls.Add(this.dtpFechaDoc);
            this.Controls.Add(this.lblFechaDocumento);
            this.Controls.Add(this.cbxColonia);
            this.Controls.Add(this.cbxLocalidad);
            this.Controls.Add(this.cbxMunicipio);
            this.Controls.Add(this.txtOficioEnvio);
            this.Controls.Add(this.txtAliasDelincuente);
            this.Controls.Add(this.txtDescripcionDenuncia);
            this.Controls.Add(this.txtReferencias);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cbxTipoDenuncia);
            this.Controls.Add(this.lblOficioEnvio);
            this.Controls.Add(this.lblAliasDelincuente);
            this.Controls.Add(this.lblDenuncia);
            this.Controls.Add(this.lblReferencias);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.lblColonia);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.llblDireccion);
            this.Controls.Add(this.lblTipoDenuncia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SAIFrm089";
            this.Text = "Denuncias 089";
            this.Load += new System.EventHandler(this.SAIFrm089_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrm089_FormClosing);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTipoDenuncia, 0);
            this.Controls.SetChildIndex(this.llblDireccion, 0);
            this.Controls.SetChildIndex(this.lblLocalidad, 0);
            this.Controls.SetChildIndex(this.lblColonia, 0);
            this.Controls.SetChildIndex(this.lblMunicipio, 0);
            this.Controls.SetChildIndex(this.lblCP, 0);
            this.Controls.SetChildIndex(this.lblReferencias, 0);
            this.Controls.SetChildIndex(this.lblDenuncia, 0);
            this.Controls.SetChildIndex(this.lblAliasDelincuente, 0);
            this.Controls.SetChildIndex(this.lblOficioEnvio, 0);
            this.Controls.SetChildIndex(this.cbxTipoDenuncia, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.txtReferencias, 0);
            this.Controls.SetChildIndex(this.txtDescripcionDenuncia, 0);
            this.Controls.SetChildIndex(this.txtAliasDelincuente, 0);
            this.Controls.SetChildIndex(this.txtOficioEnvio, 0);
            this.Controls.SetChildIndex(this.cbxMunicipio, 0);
            this.Controls.SetChildIndex(this.cbxLocalidad, 0);
            this.Controls.SetChildIndex(this.cbxColonia, 0);
            this.Controls.SetChildIndex(this.lblFechaDocumento, 0);
            this.Controls.SetChildIndex(this.dtpFechaDoc, 0);
            this.Controls.SetChildIndex(this.chkFechaDoc, 0);
            this.Controls.SetChildIndex(this.btnDependencias, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.cbxCP, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label lblTipoDenuncia;
        private System.Windows.Forms.Label llblDireccion;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblDenuncia;
        private System.Windows.Forms.Label lblAliasDelincuente;
        private System.Windows.Forms.Label lblOficioEnvio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cbxTipoDenuncia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDireccion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtReferencias;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDescripcionDenuncia;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtAliasDelincuente;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtOficioEnvio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cbxMunicipio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cbxLocalidad;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox cbxColonia;
        private System.Windows.Forms.Label lblFechaDocumento;
        private System.Windows.Forms.DateTimePicker dtpFechaDoc;
        private System.Windows.Forms.CheckBox chkFechaDoc;
        private System.Windows.Forms.Button btnDependencias;
        protected System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbxCP;
    }
}