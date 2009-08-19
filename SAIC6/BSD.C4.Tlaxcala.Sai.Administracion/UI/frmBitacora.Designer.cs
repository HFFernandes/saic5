namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class frmBitacora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBitacora));
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvBitacora = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gpbFiltro = new System.Windows.Forms.GroupBox();
            this.chkCatalogo = new System.Windows.Forms.CheckBox();
            this.chkOperacion = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.ddlCatalogos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlOperacion = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBitacora)).BeginInit();
            this.gpbFiltro.SuspendLayout();
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
            this.logoPicture.TabIndex = 10;
            this.logoPicture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvBitacora);
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 274);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bitacora";
            // 
            // gvBitacora
            // 
            this.gvBitacora.AllowUserToAddRows = false;
            this.gvBitacora.AllowUserToDeleteRows = false;
            this.gvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBitacora.Location = new System.Drawing.Point(12, 19);
            this.gvBitacora.Name = "gvBitacora";
            this.gvBitacora.ReadOnly = true;
            this.gvBitacora.Size = new System.Drawing.Size(542, 249);
            this.gvBitacora.TabIndex = 13;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(445, 97);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Mostrar Todo";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(497, 504);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gpbFiltro
            // 
            this.gpbFiltro.Controls.Add(this.chkCatalogo);
            this.gpbFiltro.Controls.Add(this.chkOperacion);
            this.gpbFiltro.Controls.Add(this.btnLimpiar);
            this.gpbFiltro.Controls.Add(this.ddlCatalogos);
            this.gpbFiltro.Controls.Add(this.label3);
            this.gpbFiltro.Controls.Add(this.ddlOperacion);
            this.gpbFiltro.Controls.Add(this.btnFiltrar);
            this.gpbFiltro.Controls.Add(this.btnBuscar);
            this.gpbFiltro.Controls.Add(this.label1);
            this.gpbFiltro.Location = new System.Drawing.Point(12, 73);
            this.gpbFiltro.Name = "gpbFiltro";
            this.gpbFiltro.Size = new System.Drawing.Size(560, 132);
            this.gpbFiltro.TabIndex = 14;
            this.gpbFiltro.TabStop = false;
            this.gpbFiltro.Text = "Filtro";
            this.gpbFiltro.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkCatalogo
            // 
            this.chkCatalogo.AutoSize = true;
            this.chkCatalogo.Location = new System.Drawing.Point(277, 68);
            this.chkCatalogo.Name = "chkCatalogo";
            this.chkCatalogo.Size = new System.Drawing.Size(15, 14);
            this.chkCatalogo.TabIndex = 11;
            this.chkCatalogo.UseVisualStyleBackColor = true;
            this.chkCatalogo.CheckedChanged += new System.EventHandler(this.chkCatalogo_CheckedChanged);
            // 
            // chkOperacion
            // 
            this.chkOperacion.AutoSize = true;
            this.chkOperacion.Location = new System.Drawing.Point(277, 32);
            this.chkOperacion.Name = "chkOperacion";
            this.chkOperacion.Size = new System.Drawing.Size(15, 14);
            this.chkOperacion.TabIndex = 10;
            this.chkOperacion.UseVisualStyleBackColor = true;
            this.chkOperacion.CheckedChanged += new System.EventHandler(this.chkOperacion_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(457, 68);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(97, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Reestablecer";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ddlCatalogos
            // 
            this.ddlCatalogos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCatalogos.FormattingEnabled = true;
            this.ddlCatalogos.Items.AddRange(new object[] {
            "Clasificacion Organizacion",
            "Colonias",
            "Corporaciones",
            "Dependencias",
            "Localidades",
            "Municipios",
            "Organizaciones",
            "Permiso Usuario",
            "Tipo Incidencias",
            "Unidades",
            "Usuario"});
            this.ddlCatalogos.Location = new System.Drawing.Point(81, 64);
            this.ddlCatalogos.Name = "ddlCatalogos";
            this.ddlCatalogos.Size = new System.Drawing.Size(189, 21);
            this.ddlCatalogos.TabIndex = 8;
            this.ddlCatalogos.SelectedIndexChanged += new System.EventHandler(this.ddlCatalogos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Catalogo:";
            // 
            // ddlOperacion
            // 
            this.ddlOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOperacion.FormattingEnabled = true;
            this.ddlOperacion.Items.AddRange(new object[] {
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.ddlOperacion.Location = new System.Drawing.Point(81, 28);
            this.ddlOperacion.Name = "ddlOperacion";
            this.ddlOperacion.Size = new System.Drawing.Size(189, 21);
            this.ddlOperacion.TabIndex = 2;
            this.ddlOperacion.SelectedIndexChanged += new System.EventHandler(this.ddlOperacion_SelectedIndexChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(364, 97);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operacion:";
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 552);
            this.Controls.Add(this.gpbFiltro);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.logoPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBitacora";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.gpbFiltro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBitacora)).EndInit();
            this.gpbFiltro.ResumeLayout(false);
            this.gpbFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvBitacora;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gpbFiltro;
        private System.Windows.Forms.ComboBox ddlOperacion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlCatalogos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkCatalogo;
        private System.Windows.Forms.CheckBox chkOperacion;
    }
}