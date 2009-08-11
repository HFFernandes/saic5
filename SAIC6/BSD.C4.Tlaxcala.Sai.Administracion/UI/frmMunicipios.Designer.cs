namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class frmMunicipios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMunicipios));
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvMunicipios = new System.Windows.Forms.DataGridView();
            this.gpbDatosGenerales = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.ddlEstado = new System.Windows.Forms.ComboBox();
            this.saiTxtNombre = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMunicipios)).BeginInit();
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
            this.logoPicture.TabIndex = 1;
            this.logoPicture.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvMunicipios);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Catalogo de Municipios";
            // 
            // gvMunicipios
            // 
            this.gvMunicipios.AllowUserToAddRows = false;
            this.gvMunicipios.AllowUserToDeleteRows = false;
            this.gvMunicipios.AllowUserToResizeRows = false;
            this.gvMunicipios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMunicipios.Location = new System.Drawing.Point(6, 19);
            this.gvMunicipios.Name = "gvMunicipios";
            this.gvMunicipios.ReadOnly = true;
            this.gvMunicipios.RowHeadersVisible = false;
            this.gvMunicipios.Size = new System.Drawing.Size(548, 144);
            this.gvMunicipios.TabIndex = 0;
            this.gvMunicipios.TabStop = false;
            this.gvMunicipios.SelectionChanged += new System.EventHandler(this.gvMunicipios_SelectionChanged);
            // 
            // gpbDatosGenerales
            // 
            this.gpbDatosGenerales.Controls.Add(this.ddlEstado);
            this.gpbDatosGenerales.Controls.Add(this.saiTxtNombre);
            this.gpbDatosGenerales.Controls.Add(this.label2);
            this.gpbDatosGenerales.Controls.Add(this.label1);
            this.gpbDatosGenerales.Controls.Add(this.btnLimpiar);
            this.gpbDatosGenerales.Location = new System.Drawing.Point(12, 248);
            this.gpbDatosGenerales.Name = "gpbDatosGenerales";
            this.gpbDatosGenerales.Size = new System.Drawing.Size(560, 116);
            this.gpbDatosGenerales.TabIndex = 3;
            this.gpbDatosGenerales.TabStop = false;
            this.gpbDatosGenerales.Text = "Datos Generales";
            this.gpbDatosGenerales.Enter += new System.EventHandler(this.gpbDatosGenerales_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Municipio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estado:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(479, 87);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(228, 394);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(309, 394);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(497, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(390, 394);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ddlEstado
            // 
            this.ddlEstado.Enabled = false;
            this.ddlEstado.FormattingEnabled = true;
            this.ddlEstado.Location = new System.Drawing.Point(117, 24);
            this.ddlEstado.Name = "ddlEstado";
            this.ddlEstado.Size = new System.Drawing.Size(157, 21);
            this.ddlEstado.TabIndex = 7;
            // 
            // saiTxtNombre
            // 
            this.saiTxtNombre.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtNombre.Location = new System.Drawing.Point(117, 51);
            this.saiTxtNombre.Name = "saiTxtNombre";
            this.saiTxtNombre.Size = new System.Drawing.Size(209, 20);
            this.saiTxtNombre.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtNombre.TabIndex = 6;
            // 
            // frmMunicipios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(584, 442);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gpbDatosGenerales);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.logoPicture);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "frmMunicipios";
            this.Text = "Municipios";
            this.Load += new System.EventHandler(this.frmMunicipios_Load);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.gpbDatosGenerales, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMunicipios)).EndInit();
            this.gpbDatosGenerales.ResumeLayout(false);
            this.gpbDatosGenerales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvMunicipios;
        private System.Windows.Forms.GroupBox gpbDatosGenerales;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlEstado;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtNombre;
    }
}