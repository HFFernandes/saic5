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
            this.lblOtro = new System.Windows.Forms.Label();
            this.saiTxtCP = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
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
            this.ddlLocalidad.Location = new System.Drawing.Point(124, 19);
            this.ddlLocalidad.Name = "ddlLocalidad";
            this.ddlLocalidad.Size = new System.Drawing.Size(141, 21);
            this.ddlLocalidad.TabIndex = 10;
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(202, 445);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(283, 445);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(497, 445);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(479, 121);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // saiTxtNombre
            // 
            this.saiTxtNombre.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtNombre.Location = new System.Drawing.Point(124, 46);
            this.saiTxtNombre.Name = "saiTxtNombre";
            this.saiTxtNombre.Size = new System.Drawing.Size(222, 20);
            this.saiTxtNombre.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtNombre.TabIndex = 15;
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
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colonias";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOtro);
            this.groupBox2.Controls.Add(this.saiTxtCP);
            this.groupBox2.Controls.Add(this.ddlCodigoPostal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.saiTxtNombre);
            this.groupBox2.Controls.Add(this.ddlLocalidad);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Location = new System.Drawing.Point(12, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 154);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Generales";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblOtro
            // 
            this.lblOtro.AutoSize = true;
            this.lblOtro.Location = new System.Drawing.Point(334, 76);
            this.lblOtro.Name = "lblOtro";
            this.lblOtro.Size = new System.Drawing.Size(30, 13);
            this.lblOtro.TabIndex = 21;
            this.lblOtro.Text = "Otro:";
            this.lblOtro.Visible = false;
            // 
            // saiTxtCP
            // 
            this.saiTxtCP.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtCP.Location = new System.Drawing.Point(385, 73);
            this.saiTxtCP.Name = "saiTxtCP";
            this.saiTxtCP.Size = new System.Drawing.Size(129, 20);
            this.saiTxtCP.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtCP.TabIndex = 20;
            this.saiTxtCP.Visible = false;
            // 
            // ddlCodigoPostal
            // 
            this.ddlCodigoPostal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCodigoPostal.FormattingEnabled = true;
            this.ddlCodigoPostal.Location = new System.Drawing.Point(124, 72);
            this.ddlCodigoPostal.Name = "ddlCodigoPostal";
            this.ddlCodigoPostal.Size = new System.Drawing.Size(141, 21);
            this.ddlCodigoPostal.TabIndex = 19;
            this.ddlCodigoPostal.SelectedIndexChanged += new System.EventHandler(this.ddlCodigoPostal_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Codigo Postal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Localidad:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(365, 445);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmColonias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 493);
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
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtCP;
        private System.Windows.Forms.Label lblOtro;
    }
}