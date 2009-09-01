namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmAltaDatosAuto066
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpPropietario = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelefonoPropietario = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtDireccionPropietario = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtNombrePropietario = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.dgvVehiculo = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView(this.components);
            this.ClaveVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeñasParticulares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbVehiculo = new System.Windows.Forms.GroupBox();
            this.grpPropietario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).BeginInit();
            this.gbVehiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPropietario
            // 
            this.grpPropietario.Controls.Add(this.label11);
            this.grpPropietario.Controls.Add(this.txtTelefonoPropietario);
            this.grpPropietario.Controls.Add(this.label13);
            this.grpPropietario.Controls.Add(this.txtDireccionPropietario);
            this.grpPropietario.Controls.Add(this.label12);
            this.grpPropietario.Controls.Add(this.txtNombrePropietario);
            this.grpPropietario.Location = new System.Drawing.Point(10, 12);
            this.grpPropietario.Name = "grpPropietario";
            this.grpPropietario.Size = new System.Drawing.Size(821, 78);
            this.grpPropietario.TabIndex = 21;
            this.grpPropietario.TabStop = false;
            this.grpPropietario.Text = "Datos del propietario :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre completo :";
            // 
            // txtTelefonoPropietario
            // 
            this.txtTelefonoPropietario.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTelefonoPropietario.Location = new System.Drawing.Point(628, 16);
            this.txtTelefonoPropietario.MaxLength = 25;
            this.txtTelefonoPropietario.Name = "txtTelefonoPropietario";
            this.txtTelefonoPropietario.Size = new System.Drawing.Size(185, 20);
            this.txtTelefonoPropietario.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtTelefonoPropietario.TabIndex = 4;
            this.txtTelefonoPropietario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(570, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Teléfono:";
            // 
            // txtDireccionPropietario
            // 
            this.txtDireccionPropietario.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccionPropietario.Location = new System.Drawing.Point(111, 46);
            this.txtDireccionPropietario.MaxLength = 250;
            this.txtDireccionPropietario.Name = "txtDireccionPropietario";
            this.txtDireccionPropietario.Size = new System.Drawing.Size(702, 20);
            this.txtDireccionPropietario.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDireccionPropietario.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Dirección :";
            // 
            // txtNombrePropietario
            // 
            this.txtNombrePropietario.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombrePropietario.Location = new System.Drawing.Point(111, 16);
            this.txtNombrePropietario.MaxLength = 250;
            this.txtNombrePropietario.Name = "txtNombrePropietario";
            this.txtNombrePropietario.Size = new System.Drawing.Size(453, 20);
            this.txtNombrePropietario.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtNombrePropietario.TabIndex = 1;
            // 
            // dgvVehiculo
            // 
            this.dgvVehiculo.AllowUserToOrderColumns = true;
            this.dgvVehiculo.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClaveVehiculo,
            this.Marca,
            this.Tipo,
            this.Modelo,
            this.Placas,
            this.Color,
            this.NoMotor,
            this.NumeroSerie,
            this.SeñasParticulares});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiculo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVehiculo.Location = new System.Drawing.Point(5, 19);
            this.dgvVehiculo.Name = "dgvVehiculo";
            this.dgvVehiculo.RowHeadersVisible = false;
            this.dgvVehiculo.Size = new System.Drawing.Size(810, 119);
            this.dgvVehiculo.TabIndex = 5;
            // 
            // ClaveVehiculo
            // 
            this.ClaveVehiculo.HeaderText = "Clave";
            this.ClaveVehiculo.Name = "ClaveVehiculo";
            this.ClaveVehiculo.Visible = false;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.MaxInputLength = 50;
            this.Marca.Name = "Marca";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MaxInputLength = 50;
            this.Tipo.Name = "Tipo";
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.MaxInputLength = 50;
            this.Modelo.Name = "Modelo";
            // 
            // Placas
            // 
            this.Placas.HeaderText = "Placas";
            this.Placas.MaxInputLength = 50;
            this.Placas.Name = "Placas";
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.MaxInputLength = 50;
            this.Color.Name = "Color";
            // 
            // NoMotor
            // 
            this.NoMotor.HeaderText = "Número de Motor";
            this.NoMotor.MaxInputLength = 50;
            this.NoMotor.Name = "NoMotor";
            // 
            // NumeroSerie
            // 
            this.NumeroSerie.HeaderText = "Número de Serie";
            this.NumeroSerie.MaxInputLength = 50;
            this.NumeroSerie.Name = "NumeroSerie";
            // 
            // SeñasParticulares
            // 
            this.SeñasParticulares.HeaderText = "Señas Particulares";
            this.SeñasParticulares.MaxInputLength = 250;
            this.SeñasParticulares.Name = "SeñasParticulares";
            // 
            // gbVehiculo
            // 
            this.gbVehiculo.Controls.Add(this.dgvVehiculo);
            this.gbVehiculo.Location = new System.Drawing.Point(10, 96);
            this.gbVehiculo.Name = "gbVehiculo";
            this.gbVehiculo.Size = new System.Drawing.Size(821, 150);
            this.gbVehiculo.TabIndex = 22;
            this.gbVehiculo.TabStop = false;
            this.gbVehiculo.Text = "Datos del/los vehículo(s):";
            // 
            // SAIFrmAltaDatosAuto066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 253);
            this.Controls.Add(this.gbVehiculo);
            this.Controls.Add(this.grpPropietario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmAltaDatosAuto066";
            this.Text = "Datos del Vehículo";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmAltaDatosAuto066_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SAIFrmAltaDatosAuto066_KeyDown);
            this.grpPropietario.ResumeLayout(false);
            this.grpPropietario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).EndInit();
            this.gbVehiculo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPropietario;
        private System.Windows.Forms.Label label11;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtTelefonoPropietario;
        private System.Windows.Forms.Label label13;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtDireccionPropietario;
        private System.Windows.Forms.Label label12;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtNombrePropietario;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView dgvVehiculo;
        private System.Windows.Forms.GroupBox gbVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeñasParticulares;
    }
}