namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    partial class MDIPrincipal
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDeTiposDeIncidenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDeUnidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDeCorporacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mnuStripPrincipal
            // 
            this.mnuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.operacionesToolStripMenuItem});
            this.mnuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuStripPrincipal.Name = "mnuStripPrincipal";
            this.mnuStripPrincipal.Size = new System.Drawing.Size(940, 24);
            this.mnuStripPrincipal.TabIndex = 2;
            this.mnuStripPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogoDeUsuariosToolStripMenuItem,
            this.catalogoDePermisosToolStripMenuItem,
            this.catalogoDeTiposDeIncidenciasToolStripMenuItem,
            this.catalogoDeUnidadesToolStripMenuItem,
            this.catalogoDeCorporacionesToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.operacionesToolStripMenuItem.Text = "&Catalogos";
            // 
            // catalogoDeUsuariosToolStripMenuItem
            // 
            this.catalogoDeUsuariosToolStripMenuItem.Name = "catalogoDeUsuariosToolStripMenuItem";
            this.catalogoDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.catalogoDeUsuariosToolStripMenuItem.Text = "Catalogo de Usuarios";
            this.catalogoDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.catalogoDeUsuariosToolStripMenuItem_Click);
            // 
            // catalogoDePermisosToolStripMenuItem
            // 
            this.catalogoDePermisosToolStripMenuItem.Name = "catalogoDePermisosToolStripMenuItem";
            this.catalogoDePermisosToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.catalogoDePermisosToolStripMenuItem.Text = "Catalogo de Permisos";
            this.catalogoDePermisosToolStripMenuItem.Click += new System.EventHandler(this.catalogoDePermisosToolStripMenuItem_Click);
            // 
            // catalogoDeTiposDeIncidenciasToolStripMenuItem
            // 
            this.catalogoDeTiposDeIncidenciasToolStripMenuItem.Name = "catalogoDeTiposDeIncidenciasToolStripMenuItem";
            this.catalogoDeTiposDeIncidenciasToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.catalogoDeTiposDeIncidenciasToolStripMenuItem.Text = "Catalogo de Tipos de Incidencias";
            this.catalogoDeTiposDeIncidenciasToolStripMenuItem.Click += new System.EventHandler(this.catalogoDeTiposDeIncidenciasToolStripMenuItem_Click);
            // 
            // catalogoDeUnidadesToolStripMenuItem
            // 
            this.catalogoDeUnidadesToolStripMenuItem.Name = "catalogoDeUnidadesToolStripMenuItem";
            this.catalogoDeUnidadesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.catalogoDeUnidadesToolStripMenuItem.Text = "Catalogo de Unidades";
            // 
            // catalogoDeCorporacionesToolStripMenuItem
            // 
            this.catalogoDeCorporacionesToolStripMenuItem.Name = "catalogoDeCorporacionesToolStripMenuItem";
            this.catalogoDeCorporacionesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.catalogoDeCorporacionesToolStripMenuItem.Text = "Catalogo de Corporaciones";
            // 
            // MDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 484);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuStripPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuStripPrincipal;
            this.Name = "MDIPrincipal";
            this.Text = "MDIPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuStripPrincipal.ResumeLayout(false);
            this.mnuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip mnuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDePermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDeTiposDeIncidenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDeUnidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDeCorporacionesToolStripMenuItem;
    }
}