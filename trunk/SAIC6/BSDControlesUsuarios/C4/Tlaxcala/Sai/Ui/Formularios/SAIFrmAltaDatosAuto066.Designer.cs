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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIFrmAltaDatosAuto066));
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
            this.tbComandos = new System.Windows.Forms.ToolStrip();
            this.btnEliminarFila = new System.Windows.Forms.ToolStripButton();
            this.grpPropietario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).BeginInit();
            this.gbVehiculo.SuspendLayout();
            this.tbComandos.SuspendLayout();
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
            this.grpPropietario.TabIndex = 0;
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
            this.txtTelefonoPropietario.TabIndex = 3;
            this.txtTelefonoPropietario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
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
            this.txtDireccionPropietario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccionPropietario.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccionPropietario.Location = new System.Drawing.Point(111, 46);
            this.txtDireccionPropietario.MaxLength = 250;
            this.txtDireccionPropietario.Name = "txtDireccionPropietario";
            this.txtDireccionPropietario.Size = new System.Drawing.Size(702, 20);
            this.txtDireccionPropietario.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtDireccionPropietario.TabIndex = 5;
            this.txtDireccionPropietario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Dirección :";
            // 
            // txtNombrePropietario
            // 
            this.txtNombrePropietario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombrePropietario.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombrePropietario.Location = new System.Drawing.Point(111, 16);
            this.txtNombrePropietario.MaxLength = 250;
            this.txtNombrePropietario.Name = "txtNombrePropietario";
            this.txtNombrePropietario.Size = new System.Drawing.Size(453, 20);
            this.txtNombrePropietario.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtNombrePropietario.TabIndex = 1;
            this.txtNombrePropietario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // dgvVehiculo
            // 
            this.dgvVehiculo.AllowUserToOrderColumns = true;
            this.dgvVehiculo.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiculo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehiculo.Location = new System.Drawing.Point(3, 40);
            this.dgvVehiculo.Name = "dgvVehiculo";
            this.dgvVehiculo.RowHeadersVisible = false;
            this.dgvVehiculo.RowHeadersWidth = 15;
            this.dgvVehiculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehiculo.Size = new System.Drawing.Size(815, 119);
            this.dgvVehiculo.TabIndex = 1;
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
            this.gbVehiculo.Controls.Add(this.tbComandos);
            this.gbVehiculo.Controls.Add(this.dgvVehiculo);
            this.gbVehiculo.Location = new System.Drawing.Point(10, 96);
            this.gbVehiculo.Name = "gbVehiculo";
            this.gbVehiculo.Size = new System.Drawing.Size(821, 170);
            this.gbVehiculo.TabIndex = 1;
            this.gbVehiculo.TabStop = false;
            this.gbVehiculo.Text = "Datos del/los vehículo(s):";
            // 
            // tbComandos
            // 
            this.tbComandos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbComandos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEliminarFila});
            this.tbComandos.Location = new System.Drawing.Point(3, 16);
            this.tbComandos.Name = "tbComandos";
            this.tbComandos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tbComandos.Size = new System.Drawing.Size(815, 25);
            this.tbComandos.TabIndex = 0;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarFila.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarFila.Image")));
            this.btnEliminarFila.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarFila.ToolTipText = "Eliminar el registro actual.";
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // SAIFrmAltaDatosAuto066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 275);
            this.Controls.Add(this.gbVehiculo);
            this.Controls.Add(this.grpPropietario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmAltaDatosAuto066";
            this.Text = "Datos del Vehículo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SAIFrmAltaDatosAuto066_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmAltaDatosAuto066_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SAIFrmAltaDatosAuto066_KeyDown);
            this.grpPropietario.ResumeLayout(false);
            this.grpPropietario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculo)).EndInit();
            this.gbVehiculo.ResumeLayout(false);
            this.gbVehiculo.PerformLayout();
            this.tbComandos.ResumeLayout(false);
            this.tbComandos.PerformLayout();
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
        private System.Windows.Forms.ToolStrip tbComandos;
        private System.Windows.Forms.ToolStripButton btnEliminarFila;
    }
}