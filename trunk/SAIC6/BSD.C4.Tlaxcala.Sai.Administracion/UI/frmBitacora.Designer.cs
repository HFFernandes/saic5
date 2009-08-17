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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlOperacion = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBitacora)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 328);
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
            this.gvBitacora.Size = new System.Drawing.Size(542, 303);
            this.gvBitacora.TabIndex = 13;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(445, 31);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlOperacion);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 71);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
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
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(364, 31);
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.logoPicture);
            this.Name = "frmBitacora";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            this.Controls.SetChildIndex(this.logoPicture, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBitacora)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvBitacora;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlOperacion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
    }
}