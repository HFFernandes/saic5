namespace BSD.C4.Tlaxcala.Sai
{
    partial class CfrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CfrmPrincipal));
            this.btnPunteo = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSupervisor = new System.Windows.Forms.Button();
            this.toolTipPunteo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnPunteo
            // 
            this.btnPunteo.BackColor = System.Drawing.SystemColors.Control;
            this.btnPunteo.Image = ((System.Drawing.Image)(resources.GetObject("btnPunteo.Image")));
            this.btnPunteo.Location = new System.Drawing.Point(15, 8);
            this.btnPunteo.Name = "btnPunteo";
            this.btnPunteo.Size = new System.Drawing.Size(150, 150);
            this.btnPunteo.TabIndex = 0;
            this.toolTipPunteo.SetToolTip(this.btnPunteo, "Punto de incidencias");
            this.btnPunteo.UseVisualStyleBackColor = false;
            this.btnPunteo.Click += new System.EventHandler(this.btnPunteo_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(171, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 150);
            this.btnExport.TabIndex = 1;
            this.toolTipPunteo.SetToolTip(this.btnExport, "Descagar en Excel");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSupervisor
            // 
            this.btnSupervisor.Image = ((System.Drawing.Image)(resources.GetObject("btnSupervisor.Image")));
            this.btnSupervisor.Location = new System.Drawing.Point(327, 8);
            this.btnSupervisor.Name = "btnSupervisor";
            this.btnSupervisor.Size = new System.Drawing.Size(150, 150);
            this.btnSupervisor.TabIndex = 2;
            this.toolTipPunteo.SetToolTip(this.btnSupervisor, "Supervisor");
            this.btnSupervisor.UseVisualStyleBackColor = true;
            this.btnSupervisor.Click += new System.EventHandler(this.button3_Click);
            // 
            // CfrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 166);
            this.Controls.Add(this.btnSupervisor);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPunteo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "CfrmPrincipal";
            this.ShowIcon = false;
            this.Text = "Módulo de punteo de incidencias y reportes";
            this.Load += new System.EventHandler(this.CfrmPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPunteo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSupervisor;
        private System.Windows.Forms.ToolTip toolTipPunteo;
    }
}