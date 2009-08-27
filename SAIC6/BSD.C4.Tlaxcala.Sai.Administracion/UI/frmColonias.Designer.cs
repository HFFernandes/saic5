namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class frmColonias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColonias));
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.ddlLocalidad = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.saiTxtNombre = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.gvColonias = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saiClave = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlMunicipio = new System.Windows.Forms.ComboBox();
            this.ddlEstado = new System.Windows.Forms.ComboBox();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.lblOtro = new System.Windows.Forms.Label();
            this.ddlCodigoPostal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColonias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.logoPicture.TabIndex = 9;
            this.logoPicture.TabStop = false;
            // 
            // ddlLocalidad
            // 
            this.ddlLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLocalidad.FormattingEnabled = true;
            this.ddlLocalidad.Location = new System.Drawing.Point(134, 99);
            this.ddlLocalidad.Name = "ddlLocalidad";
            this.ddlLocalidad.Size = new System.Drawing.Size(175, 21);
            this.ddlLocalidad.TabIndex = 4;
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(236, 479);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(317, 479);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(497, 479);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(479, 171);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // saiTxtNombre
            // 
            this.saiTxtNombre.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtNombre.Location = new System.Drawing.Point(134, 126);
            this.saiTxtNombre.Name = "saiTxtNombre";
            this.saiTxtNombre.Size = new System.Drawing.Size(259, 20);
            this.saiTxtNombre.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtNombre.TabIndex = 5;
            // 
            // gvColonias
            // 
            this.gvColonias.AllowUserToAddRows = false;
            this.gvColonias.AllowUserToDeleteRows = false;
            this.gvColonias.AllowUserToResizeColumns = false;
            this.gvColonias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvColonias.Location = new System.Drawing.Point(6, 19);
            this.gvColonias.Name = "gvColonias";
            this.gvColonias.ReadOnly = true;
            this.gvColonias.RowHeadersVisible = false;
            this.gvColonias.Size = new System.Drawing.Size(548, 156);
            this.gvColonias.TabIndex = 0;
            this.gvColonias.TabStop = false;
            this.gvColonias.SelectionChanged += new System.EventHandler(this.gvColonias_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvColonias);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colonias";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saiClave);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ddlMunicipio);
            this.groupBox2.Controls.Add(this.ddlEstado);
            this.groupBox2.Controls.Add(this.txtCP);
            this.groupBox2.Controls.Add(this.lblOtro);
            this.groupBox2.Controls.Add(this.ddlCodigoPostal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.saiTxtNombre);
            this.groupBox2.Controls.Add(this.ddlLocalidad);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Location = new System.Drawing.Point(12, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 200);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Generales";
            // 
            // saiClave
            // 
            this.saiClave.BlnEsRequerido = true;
            this.saiClave.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiClave.Location = new System.Drawing.Point(134, 19);
            this.saiClave.Name = "saiClave";
            this.saiClave.Size = new System.Drawing.Size(100, 20);
            this.saiClave.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiClave.TabIndex = 1;
            this.saiClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saiClave_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Clave Cartografia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Municipio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Estado:";
            // 
            // ddlMunicipio
            // 
            this.ddlMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMunicipio.Enabled = false;
            this.ddlMunicipio.FormattingEnabled = true;
            this.ddlMunicipio.Location = new System.Drawing.Point(134, 72);
            this.ddlMunicipio.Name = "ddlMunicipio";
            this.ddlMunicipio.Size = new System.Drawing.Size(175, 21);
            this.ddlMunicipio.TabIndex = 3;
            // 
            // ddlEstado
            // 
            this.ddlEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEstado.Enabled = false;
            this.ddlEstado.FormattingEnabled = true;
            this.ddlEstado.Location = new System.Drawing.Point(134, 45);
            this.ddlEstado.Name = "ddlEstado";
            this.ddlEstado.Size = new System.Drawing.Size(175, 21);
            this.ddlEstado.TabIndex = 2;
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(332, 152);
            this.txtCP.MaxLength = 5;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(100, 20);
            this.txtCP.TabIndex = 6;
            this.txtCP.Visible = false;
            // 
            // lblOtro
            // 
            this.lblOtro.AutoSize = true;
            this.lblOtro.Location = new System.Drawing.Point(261, 155);
            this.lblOtro.Name = "lblOtro";
            this.lblOtro.Size = new System.Drawing.Size(65, 13);
            this.lblOtro.TabIndex = 0;
            this.lblOtro.Text = "Especifique:";
            this.lblOtro.Visible = false;
            // 
            // ddlCodigoPostal
            // 
            this.ddlCodigoPostal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCodigoPostal.FormattingEnabled = true;
            this.ddlCodigoPostal.Location = new System.Drawing.Point(134, 152);
            this.ddlCodigoPostal.Name = "ddlCodigoPostal";
            this.ddlCodigoPostal.Size = new System.Drawing.Size(107, 21);
            this.ddlCodigoPostal.TabIndex = 6;
            this.ddlCodigoPostal.SelectedIndexChanged += new System.EventHandler(this.ddlCodigoPostal_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo Postal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Localidad:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(399, 479);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmColonias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(584, 527);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.logoPicture);
            this.Name = "frmColonias";
            this.Text = "Colonias";
            this.Load += new System.EventHandler(this.frmColonias_Load);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColonias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.ComboBox ddlLocalidad;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtNombre;
        private System.Windows.Forms.DataGridView gvColonias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlCodigoPostal;
        private System.Windows.Forms.Label lblOtro;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlMunicipio;
        private System.Windows.Forms.ComboBox ddlEstado;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiClave;
        private System.Windows.Forms.Label label6;
    }
}