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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvDependencias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvDependencias
            // 
            this.gvDependencias.AllowUserToAddRows = false;
            this.gvDependencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDependencias.Location = new System.Drawing.Point(12, 198);
            this.gvDependencias.Name = "gvDependencias";
            this.gvDependencias.Size = new System.Drawing.Size(448, 173);
            this.gvDependencias.TabIndex = 0;
            // 
            // chklstDependencias
            // 
            this.chklstDependencias.FormattingEnabled = true;
            this.chklstDependencias.Location = new System.Drawing.Point(6, 19);
            this.chklstDependencias.Name = "chklstDependencias";
            this.chklstDependencias.Size = new System.Drawing.Size(436, 154);
            this.chklstDependencias.TabIndex = 1;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SAIFrmDependencias089
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 429);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvDependencias);
            this.Name = "SAIFrmDependencias089";
            this.Text = "SAIFrmDependencias089";
            this.Load += new System.EventHandler(this.SAIFrmDependencias089_Load);
            this.Controls.SetChildIndex(this.gvDependencias, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvDependencias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvDependencias;
        private System.Windows.Forms.CheckedListBox chklstDependencias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}