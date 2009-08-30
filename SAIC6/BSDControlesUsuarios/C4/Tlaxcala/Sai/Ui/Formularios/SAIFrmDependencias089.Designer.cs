namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmDependencias089
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
            this.gvDependencias = new System.Windows.Forms.DataGridView();
            this.chklstDependencias = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvDependencias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvDependencias
            // 
            this.gvDependencias.AllowUserToAddRows = false;
            this.gvDependencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvDependencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDependencias.Location = new System.Drawing.Point(12, 199);
            this.gvDependencias.MultiSelect = false;
            this.gvDependencias.Name = "gvDependencias";
            this.gvDependencias.Size = new System.Drawing.Size(448, 173);
            this.gvDependencias.TabIndex = 0;
            this.gvDependencias.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDependencias_CellValueChanged);
            this.gvDependencias.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDependencias_CellValidated);
            // 
            // chklstDependencias
            // 
            this.chklstDependencias.FormattingEnabled = true;
            this.chklstDependencias.Location = new System.Drawing.Point(6, 19);
            this.chklstDependencias.Name = "chklstDependencias";
            this.chklstDependencias.Size = new System.Drawing.Size(436, 154);
            this.chklstDependencias.TabIndex = 1;
            this.chklstDependencias.SelectedIndexChanged += new System.EventHandler(this.chklstDependencias_SelectedIndexChanged);
            this.chklstDependencias.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstDependencias_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklstDependencias);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencias:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(385, 377);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // SAIFrmDependencias089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(472, 429);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvDependencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SAIFrmDependencias089";
            this.Text = "SAIFrmDependencias089";
            this.Load += new System.EventHandler(this.SAIFrmDependencias089_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmDependencias089_FormClosing);
            this.Controls.SetChildIndex(this.gvDependencias, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvDependencias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvDependencias;
        private System.Windows.Forms.CheckedListBox chklstDependencias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
    }
}