namespace BSD.C4.Tlaxcala.Sai.SAIAdmin
{
    partial class frmTipoIncidencia
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgCatalogo = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.toosMenu = new System.Windows.Forms.ToolStrip();
            this.mnuBtnAgregar = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnModificar = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLblEspacio = new System.Windows.Forms.ToolStripLabel();
            this.mnuBtnCerrar = new System.Windows.Forms.ToolStripButton();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCatalogo)).BeginInit();
            this.toosMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblClave);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblDesc);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblSistema);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgCatalogo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblTitulo);
            this.toolStripContainer1.ContentPanel.Font = new System.Drawing.Font("Arial", 9.209303F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripContainer1.ContentPanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(517, 360);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(517, 407);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toosMenu);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(517, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // dgCatalogo
            // 
            this.dgCatalogo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCatalogo.Location = new System.Drawing.Point(12, 48);
            this.dgCatalogo.Name = "dgCatalogo";
            this.dgCatalogo.ReadOnly = true;
            this.dgCatalogo.Size = new System.Drawing.Size(483, 154);
            this.dgCatalogo.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 9.209303F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitulo.Location = new System.Drawing.Point(318, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(40, 15);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "...........";
            // 
            // toosMenu
            // 
            this.toosMenu.BackColor = System.Drawing.Color.Azure;
            this.toosMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.toosMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBtnAgregar,
            this.mnuBtnModificar,
            this.mnuBtnEliminar,
            this.toolStripSeparator1,
            this.mnuLblEspacio,
            this.mnuBtnCerrar});
            this.toosMenu.Location = new System.Drawing.Point(3, 0);
            this.toosMenu.Name = "toosMenu";
            this.toosMenu.Size = new System.Drawing.Size(190, 25);
            this.toosMenu.TabIndex = 0;
            // 
            // mnuBtnAgregar
            // 
            this.mnuBtnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnAgregar.Image = global::BSD.C4.Tlaxcala.Sai.SAIAdmin.Resource1.Alta_Azul;
            this.mnuBtnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnAgregar.Name = "mnuBtnAgregar";
            this.mnuBtnAgregar.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnAgregar.Text = "toolStripButton1";
            this.mnuBtnAgregar.ToolTipText = "Agregar Elemento al Catálogo";
            // 
            // mnuBtnModificar
            // 
            this.mnuBtnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnModificar.Image = global::BSD.C4.Tlaxcala.Sai.SAIAdmin.Resource1.Modificar_Azul;
            this.mnuBtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnModificar.Name = "mnuBtnModificar";
            this.mnuBtnModificar.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnModificar.ToolTipText = "Modificar Elemento";
            // 
            // mnuBtnEliminar
            // 
            this.mnuBtnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnEliminar.Image = global::BSD.C4.Tlaxcala.Sai.SAIAdmin.Resource1.Eliminar_Azul;
            this.mnuBtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnEliminar.Name = "mnuBtnEliminar";
            this.mnuBtnEliminar.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnEliminar.ToolTipText = "Eliminar Elemento";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuLblEspacio
            // 
            this.mnuLblEspacio.Name = "mnuLblEspacio";
            this.mnuLblEspacio.Size = new System.Drawing.Size(80, 22);
            this.mnuLblEspacio.Text = "                         ";
            // 
            // mnuBtnCerrar
            // 
            this.mnuBtnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnCerrar.Image = global::BSD.C4.Tlaxcala.Sai.SAIAdmin.Resource1.Cerrar_Roja;
            this.mnuBtnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnCerrar.Name = "mnuBtnCerrar";
            this.mnuBtnCerrar.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnCerrar.ToolTipText = "Cerrar Catálogo";
            this.mnuBtnCerrar.Click += new System.EventHandler(this.mnuBtnCerrar_Click);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(54, 268);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(41, 15);
            this.lblClave.TabIndex = 9;
            this.lblClave.Text = "Clave:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(17, 311);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(78, 15);
            this.lblDesc.TabIndex = 8;
            this.lblDesc.Text = "Descripción:";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(38, 222);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(57, 15);
            this.lblSistema.TabIndex = 7;
            this.lblSistema.Text = "Sistema:";
            // 
            // frmTipoIncidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(517, 407);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Arial", 9.209303F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTipoIncidencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCatalogo)).EndInit();
            this.toosMenu.ResumeLayout(false);
            this.toosMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dgCatalogo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolStrip toosMenu;
        private System.Windows.Forms.ToolStripButton mnuBtnAgregar;
        private System.Windows.Forms.ToolStripButton mnuBtnModificar;
        private System.Windows.Forms.ToolStripButton mnuBtnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel mnuLblEspacio;
        private System.Windows.Forms.ToolStripButton mnuBtnCerrar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblSistema;

    }
}

