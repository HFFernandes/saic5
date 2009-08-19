namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class frmOrganizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrganizacion));
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvOrganizaciones = new System.Windows.Forms.DataGridView();
            this.gpbDatosGenerales = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.saiDdlClasificacion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.saiTxtTelefono = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtDireccion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtDireccionWeb = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtEmail = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtFax = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiTxtNombre = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrganizaciones)).BeginInit();
            this.gpbDatosGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPicture
            // 
            this.logoPicture.BackColor = System.Drawing.Color.White;
            this.logoPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPicture.Image = ((System.Drawing.Image)(resources.GetObject("logoPicture.Image")));
            this.logoPicture.Location = new System.Drawing.Point(0, 0);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(584, 67);
            this.logoPicture.TabIndex = 19;
            this.logoPicture.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(391, 516);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(310, 516);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(229, 516);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 26;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(497, 516);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 25;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvOrganizaciones);
            this.groupBox1.Location = new System.Drawing.Point(13, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 197);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Organizaciones";
            // 
            // gvOrganizaciones
            // 
            this.gvOrganizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrganizaciones.Location = new System.Drawing.Point(7, 20);
            this.gvOrganizaciones.Name = "gvOrganizaciones";
            this.gvOrganizaciones.Size = new System.Drawing.Size(546, 171);
            this.gvOrganizaciones.TabIndex = 0;
            this.gvOrganizaciones.SystemColorsChanged += new System.EventHandler(this.gvOrganizaciones_SystemColorsChanged);
            // 
            // gpbDatosGenerales
            // 
            this.gpbDatosGenerales.Controls.Add(this.btnLimpiar);
            this.gpbDatosGenerales.Controls.Add(this.saiDdlClasificacion);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtTelefono);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtDireccion);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtDireccionWeb);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtEmail);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtFax);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtNombre);
            this.gpbDatosGenerales.Controls.Add(this.label7);
            this.gpbDatosGenerales.Controls.Add(this.label6);
            this.gpbDatosGenerales.Controls.Add(this.label5);
            this.gpbDatosGenerales.Controls.Add(this.label4);
            this.gpbDatosGenerales.Controls.Add(this.label3);
            this.gpbDatosGenerales.Controls.Add(this.label2);
            this.gpbDatosGenerales.Controls.Add(this.label1);
            this.gpbDatosGenerales.Location = new System.Drawing.Point(12, 277);
            this.gpbDatosGenerales.Name = "gpbDatosGenerales";
            this.gpbDatosGenerales.Size = new System.Drawing.Size(560, 233);
            this.gpbDatosGenerales.TabIndex = 30;
            this.gpbDatosGenerales.TabStop = false;
            this.gpbDatosGenerales.Text = "Datos Generales";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(479, 204);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // saiDdlClasificacion
            // 
            this.saiDdlClasificacion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiDdlClasificacion.FormattingEnabled = true;
            this.saiDdlClasificacion.Location = new System.Drawing.Point(109, 177);
            this.saiDdlClasificacion.Name = "saiDdlClasificacion";
            this.saiDdlClasificacion.Size = new System.Drawing.Size(228, 21);
            this.saiDdlClasificacion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiDdlClasificacion.TabIndex = 14;
            // 
            // saiTxtTelefono
            // 
            this.saiTxtTelefono.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtTelefono.Location = new System.Drawing.Point(109, 73);
            this.saiTxtTelefono.Name = "saiTxtTelefono";
            this.saiTxtTelefono.Size = new System.Drawing.Size(301, 20);
            this.saiTxtTelefono.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtTelefono.TabIndex = 13;
            // 
            // saiTxtDireccion
            // 
            this.saiTxtDireccion.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtDireccion.Location = new System.Drawing.Point(109, 47);
            this.saiTxtDireccion.Name = "saiTxtDireccion";
            this.saiTxtDireccion.Size = new System.Drawing.Size(301, 20);
            this.saiTxtDireccion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtDireccion.TabIndex = 12;
            // 
            // saiTxtDireccionWeb
            // 
            this.saiTxtDireccionWeb.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtDireccionWeb.Location = new System.Drawing.Point(109, 151);
            this.saiTxtDireccionWeb.Name = "saiTxtDireccionWeb";
            this.saiTxtDireccionWeb.Size = new System.Drawing.Size(301, 20);
            this.saiTxtDireccionWeb.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtDireccionWeb.TabIndex = 10;
            // 
            // saiTxtEmail
            // 
            this.saiTxtEmail.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtEmail.Location = new System.Drawing.Point(109, 125);
            this.saiTxtEmail.Name = "saiTxtEmail";
            this.saiTxtEmail.Size = new System.Drawing.Size(301, 20);
            this.saiTxtEmail.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtEmail.TabIndex = 9;
            // 
            // saiTxtFax
            // 
            this.saiTxtFax.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtFax.Location = new System.Drawing.Point(109, 99);
            this.saiTxtFax.Name = "saiTxtFax";
            this.saiTxtFax.Size = new System.Drawing.Size(301, 20);
            this.saiTxtFax.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtFax.TabIndex = 8;
            // 
            // saiTxtNombre
            // 
            this.saiTxtNombre.BlnEsRequerido = true;
            this.saiTxtNombre.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtNombre.Location = new System.Drawing.Point(109, 21);
            this.saiTxtNombre.Name = "saiTxtNombre";
            this.saiTxtNombre.Size = new System.Drawing.Size(301, 20);
            this.saiTxtNombre.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtNombre.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Clasificación:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Direccion Web:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fax:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dirección:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // frmOrganizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 564);
            this.Controls.Add(this.gpbDatosGenerales);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.logoPicture);
            this.Name = "frmOrganizacion";
            this.Text = "frmOrganizacion";
            this.Load += new System.EventHandler(this.frmOrganizacion_Load);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.gpbDatosGenerales, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrganizaciones)).EndInit();
            this.gpbDatosGenerales.ResumeLayout(false);
            this.gpbDatosGenerales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvOrganizaciones;
        private System.Windows.Forms.GroupBox gpbDatosGenerales;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtTelefono;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtDireccion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtDireccionWeb;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtEmail;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtFax;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox saiDdlClasificacion;
        private System.Windows.Forms.Button btnLimpiar;
    }
}