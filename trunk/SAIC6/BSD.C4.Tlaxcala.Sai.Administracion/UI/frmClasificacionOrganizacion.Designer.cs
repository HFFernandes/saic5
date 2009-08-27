namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class frmClasificacionOrganizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClasificacionOrganizacion));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbpDatosGenerales = new System.Windows.Forms.GroupBox();
            this.saiTxtDescripcion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvClasificacionOrg = new System.Windows.Forms.DataGridView();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.gbpDatosGenerales.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvClasificacionOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(391, 340);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(310, 340);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(229, 340);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(497, 340);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbpDatosGenerales
            // 
            this.gbpDatosGenerales.Controls.Add(this.saiTxtDescripcion);
            this.gbpDatosGenerales.Controls.Add(this.btnLimpiar);
            this.gbpDatosGenerales.Controls.Add(this.label1);
            this.gbpDatosGenerales.Location = new System.Drawing.Point(12, 239);
            this.gbpDatosGenerales.Name = "gbpDatosGenerales";
            this.gbpDatosGenerales.Size = new System.Drawing.Size(560, 68);
            this.gbpDatosGenerales.TabIndex = 0;
            this.gbpDatosGenerales.TabStop = false;
            this.gbpDatosGenerales.Text = "Datos generales";
            // 
            // saiTxtDescripcion
            // 
            this.saiTxtDescripcion.BlnEsRequerido = true;
            this.saiTxtDescripcion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.saiTxtDescripcion.Location = new System.Drawing.Point(100, 20);
            this.saiTxtDescripcion.MaxLength = 250;
            this.saiTxtDescripcion.Name = "saiTxtDescripcion";
            this.saiTxtDescripcion.Size = new System.Drawing.Size(286, 20);
            this.saiTxtDescripcion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtDescripcion.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(479, 39);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dependencia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvClasificacionOrg);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clasificación de Organizaciones";
            // 
            // gvClasificacionOrg
            // 
            this.gvClasificacionOrg.AllowUserToAddRows = false;
            this.gvClasificacionOrg.AllowUserToDeleteRows = false;
            this.gvClasificacionOrg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvClasificacionOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClasificacionOrg.Location = new System.Drawing.Point(17, 19);
            this.gvClasificacionOrg.Name = "gvClasificacionOrg";
            this.gvClasificacionOrg.ReadOnly = true;
            this.gvClasificacionOrg.RowHeadersVisible = false;
            this.gvClasificacionOrg.Size = new System.Drawing.Size(537, 135);
            this.gvClasificacionOrg.TabIndex = 0;
            this.gvClasificacionOrg.TabStop = false;
            this.gvClasificacionOrg.SelectionChanged += new System.EventHandler(this.gvClasificacionOrg_SelectionChanged);
            // 
            // logoPicture
            // 
            this.logoPicture.BackColor = System.Drawing.Color.White;
            this.logoPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPicture.Image = ((System.Drawing.Image)(resources.GetObject("logoPicture.Image")));
            this.logoPicture.Location = new System.Drawing.Point(0, 0);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(584, 67);
            this.logoPicture.TabIndex = 18;
            this.logoPicture.TabStop = false;
            // 
            // frmClasificacionOrganizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(584, 388);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gbpDatosGenerales);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logoPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClasificacionOrganizacion";
            this.Text = "Clasificacion de Organizaciones";
            this.Load += new System.EventHandler(this.frmClasificacionOrganizacion_Load);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.gbpDatosGenerales, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.gbpDatosGenerales.ResumeLayout(false);
            this.gbpDatosGenerales.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvClasificacionOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gbpDatosGenerales;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtDescripcion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvClasificacionOrg;
        private System.Windows.Forms.PictureBox logoPicture;
    }
}