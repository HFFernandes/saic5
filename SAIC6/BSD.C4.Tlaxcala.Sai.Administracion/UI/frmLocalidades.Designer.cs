namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class frmLocalidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalidades));
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvLocalidades = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saiTxtNombre = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlMunicipio = new System.Windows.Forms.ComboBox();
            this.ddlEstado = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtClaveLocalidadCartografia = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLocalidades)).BeginInit();
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
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(219, 416);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(301, 415);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Argregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(383, 415);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(479, 102);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvLocalidades);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 162);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Localidades";
            // 
            // gvLocalidades
            // 
            this.gvLocalidades.AllowUserToAddRows = false;
            this.gvLocalidades.AllowUserToDeleteRows = false;
            this.gvLocalidades.AllowUserToResizeRows = false;
            this.gvLocalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLocalidades.Location = new System.Drawing.Point(7, 20);
            this.gvLocalidades.Name = "gvLocalidades";
            this.gvLocalidades.ReadOnly = true;
            this.gvLocalidades.RowHeadersVisible = false;
            this.gvLocalidades.Size = new System.Drawing.Size(547, 136);
            this.gvLocalidades.TabIndex = 0;
            this.gvLocalidades.TabStop = false;
            this.gvLocalidades.SelectionChanged += new System.EventHandler(this.gvLocalidades_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtClaveLocalidadCartografia);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.saiTxtNombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ddlMunicipio);
            this.groupBox2.Controls.Add(this.ddlEstado);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Location = new System.Drawing.Point(12, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 131);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Generales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Clave Localidad Cartografia:";
            // 
            // saiTxtNombre
            // 
            this.saiTxtNombre.BlnEsRequerido = true;
            this.saiTxtNombre.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtNombre.Location = new System.Drawing.Point(110, 74);
            this.saiTxtNombre.Name = "saiTxtNombre";
            this.saiTxtNombre.Size = new System.Drawing.Size(205, 20);
            this.saiTxtNombre.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtNombre.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Municipio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Estado:";
            // 
            // ddlMunicipio
            // 
            this.ddlMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMunicipio.FormattingEnabled = true;
            this.ddlMunicipio.Location = new System.Drawing.Point(110, 46);
            this.ddlMunicipio.Name = "ddlMunicipio";
            this.ddlMunicipio.Size = new System.Drawing.Size(181, 21);
            this.ddlMunicipio.TabIndex = 15;
            // 
            // ddlEstado
            // 
            this.ddlEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEstado.Enabled = false;
            this.ddlEstado.FormattingEnabled = true;
            this.ddlEstado.Location = new System.Drawing.Point(110, 19);
            this.ddlEstado.Name = "ddlEstado";
            this.ddlEstado.Size = new System.Drawing.Size(181, 21);
            this.ddlEstado.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(497, 416);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtClaveLocalidadCartografia
            // 
            this.txtClaveLocalidadCartografia.BlnEsRequerido = true;
            this.txtClaveLocalidadCartografia.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.txtClaveLocalidadCartografia.Location = new System.Drawing.Point(159, 100);
            this.txtClaveLocalidadCartografia.Name = "txtClaveLocalidadCartografia";
            this.txtClaveLocalidadCartografia.Size = new System.Drawing.Size(156, 20);
            this.txtClaveLocalidadCartografia.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtClaveLocalidadCartografia.TabIndex = 23;
            // 
            // frmLocalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 464);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.logoPicture);
            this.Name = "frmLocalidades";
            this.Text = "Localidades";
            this.Load += new System.EventHandler(this.frmLocalidades_Load);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLocalidades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvLocalidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlMunicipio;
        private System.Windows.Forms.ComboBox ddlEstado;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtNombre;
        private System.Windows.Forms.Label label4;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtClaveLocalidadCartografia;
    }
}