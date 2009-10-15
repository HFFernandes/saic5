namespace CReportes
{
    partial class CFrmGenReportes
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarAXLSExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexiToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // conexiToolStripMenuItem
            // 
            this.conexiToolStripMenuItem.Name = "conexiToolStripMenuItem";
            this.conexiToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.conexiToolStripMenuItem.Text = "Conexión a BD";
            this.conexiToolStripMenuItem.Click += new System.EventHandler(this.conexiToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarAXLSExcelToolStripMenuItem,
            this.setPointToolStripMenuItem,
            this.cRIToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // exportarAXLSExcelToolStripMenuItem
            // 
            this.exportarAXLSExcelToolStripMenuItem.Name = "exportarAXLSExcelToolStripMenuItem";
            this.exportarAXLSExcelToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exportarAXLSExcelToolStripMenuItem.Text = "Exportar a .XLS (Excel)";
            this.exportarAXLSExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarAXLSExcelToolStripMenuItem_Click);
            // 
            // setPointToolStripMenuItem
            // 
            this.setPointToolStripMenuItem.Name = "setPointToolStripMenuItem";
            this.setPointToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.setPointToolStripMenuItem.Text = "SetPoint";
            this.setPointToolStripMenuItem.Click += new System.EventHandler(this.setPointToolStripMenuItem_Click);
            // 
            // cRIToolStripMenuItem
            // 
            this.cRIToolStripMenuItem.Name = "cRIToolStripMenuItem";
            this.cRIToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.cRIToolStripMenuItem.Text = "CRI";
            this.cRIToolStripMenuItem.Click += new System.EventHandler(this.cRIToolStripMenuItem_Click);
            // 
            // CFrmGenReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 341);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CFrmGenReportes";
            this.Text = "Generador de reportes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarAXLSExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRIToolStripMenuItem;
    }
}

