namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIncidenciasPendientes089
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
            this.tmrRegistros = new System.Windows.Forms.Timer(this.components);
            this.saiReport1 = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIReport();
            this.SAIChkOrdenarPrioridad = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tmrRegistros
            // 
            this.tmrRegistros.Enabled = true;
            this.tmrRegistros.Interval = 4000;
            this.tmrRegistros.Tick += new System.EventHandler(this.tmrRegistros_Tick);
            // 
            // saiReport1
            // 
            this.saiReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saiReport1.Location = new System.Drawing.Point(0, 0);
            this.saiReport1.Name = "saiReport1";
            this.saiReport1.Size = new System.Drawing.Size(647, 251);
            this.saiReport1.TabIndex = 0;
            // 
            // SAIChkOrdenarPrioridad
            // 
            this.SAIChkOrdenarPrioridad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SAIChkOrdenarPrioridad.Location = new System.Drawing.Point(0, 257);
            this.SAIChkOrdenarPrioridad.Name = "SAIChkOrdenarPrioridad";
            this.SAIChkOrdenarPrioridad.Size = new System.Drawing.Size(647, 17);
            this.SAIChkOrdenarPrioridad.TabIndex = 1;
            this.SAIChkOrdenarPrioridad.Text = "&Ordenar por prioridad automáticamente.";
            this.SAIChkOrdenarPrioridad.UseVisualStyleBackColor = true;
            // 
            // SAIFrmIncidenciasPendientes089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(647, 296);
            this.Controls.Add(this.SAIChkOrdenarPrioridad);
            this.Controls.Add(this.saiReport1);
            this.Name = "SAIFrmIncidenciasPendientes089";
            this.Text = "SAI - Incidencias Pendientes 089";
            this.Load += new System.EventHandler(this.SAIFrmIncidenciasPendientes089_Load);
            this.Controls.SetChildIndex(this.saiReport1, 0);
            this.Controls.SetChildIndex(this.SAIChkOrdenarPrioridad, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrRegistros;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIReport saiReport1;
        private System.Windows.Forms.CheckBox SAIChkOrdenarPrioridad;
    }
}
