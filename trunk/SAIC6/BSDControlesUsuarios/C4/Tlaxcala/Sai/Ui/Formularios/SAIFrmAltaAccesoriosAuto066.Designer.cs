namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmAltaAccesoriosAuto066
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
            this.gbAccesorios = new System.Windows.Forms.GroupBox();
            this.dgvAccesorios = new System.Windows.Forms.DataGridView();
            this.gcIdAccesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcAccesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccesoriosResponsables = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.dtpAccesoriosFechaPercato = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker(this.components);
            this.txtAccesoriosPersonaSePercato = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvVehiculoAccesorios = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView(this.components);
            this.ClaveVehiculoInvolucrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosRobo = new System.Windows.Forms.GroupBox();
            this.gbDatosVehiculo = new System.Windows.Forms.GroupBox();
            this.btnAgregarVehiculo = new System.Windows.Forms.Button();
            this.txtPlacas = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtModelo = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtMarca = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbVehiculos = new System.Windows.Forms.GroupBox();
            this.gbAccesorios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculoAccesorios)).BeginInit();
            this.gbDatosRobo.SuspendLayout();
            this.gbDatosVehiculo.SuspendLayout();
            this.gbVehiculos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAccesorios
            // 
            this.gbAccesorios.Controls.Add(this.dgvAccesorios);
            this.gbAccesorios.Location = new System.Drawing.Point(11, 48);
            this.gbAccesorios.Name = "gbAccesorios";
            this.gbAccesorios.Size = new System.Drawing.Size(621, 138);
            this.gbAccesorios.TabIndex = 3;
            this.gbAccesorios.TabStop = false;
            this.gbAccesorios.Text = "Accesorios robados a este vehiculo :";
            // 
            // dgvAccesorios
            // 
            this.dgvAccesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccesorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gcIdAccesorio,
            this.gcAccesorio});
            this.dgvAccesorios.Location = new System.Drawing.Point(6, 17);
            this.dgvAccesorios.Name = "dgvAccesorios";
            this.dgvAccesorios.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAccesorios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccesorios.Size = new System.Drawing.Size(609, 115);
            this.dgvAccesorios.TabIndex = 0;
            // 
            // gcIdAccesorio
            // 
            this.gcIdAccesorio.HeaderText = "IdAccesorio";
            this.gcIdAccesorio.Name = "gcIdAccesorio";
            this.gcIdAccesorio.Visible = false;
            // 
            // gcAccesorio
            // 
            this.gcAccesorio.HeaderText = "Accesorio";
            this.gcAccesorio.Name = "gcAccesorio";
            // 
            // txtAccesoriosResponsables
            // 
            this.txtAccesoriosResponsables.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccesoriosResponsables.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAccesoriosResponsables.Location = new System.Drawing.Point(169, 48);
            this.txtAccesoriosResponsables.MaxLength = 500;
            this.txtAccesoriosResponsables.Name = "txtAccesoriosResponsables";
            this.txtAccesoriosResponsables.Size = new System.Drawing.Size(463, 20);
            this.txtAccesoriosResponsables.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtAccesoriosResponsables.TabIndex = 3;
            this.txtAccesoriosResponsables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // dtpAccesoriosFechaPercato
            // 
            this.dtpAccesoriosFechaPercato.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpAccesoriosFechaPercato.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpAccesoriosFechaPercato.CustomFormat = "dd/MM/yyyy";
            this.dtpAccesoriosFechaPercato.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccesoriosFechaPercato.Location = new System.Drawing.Point(506, 22);
            this.dtpAccesoriosFechaPercato.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtpAccesoriosFechaPercato.Name = "dtpAccesoriosFechaPercato";
            this.dtpAccesoriosFechaPercato.Size = new System.Drawing.Size(126, 20);
            this.dtpAccesoriosFechaPercato.StrMensajeCampoRequerido = "El campo es requerido.";
            this.dtpAccesoriosFechaPercato.TabIndex = 2;
            this.dtpAccesoriosFechaPercato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // txtAccesoriosPersonaSePercato
            // 
            this.txtAccesoriosPersonaSePercato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccesoriosPersonaSePercato.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAccesoriosPersonaSePercato.Location = new System.Drawing.Point(141, 19);
            this.txtAccesoriosPersonaSePercato.MaxLength = 150;
            this.txtAccesoriosPersonaSePercato.Name = "txtAccesoriosPersonaSePercato";
            this.txtAccesoriosPersonaSePercato.Size = new System.Drawing.Size(217, 20);
            this.txtAccesoriosPersonaSePercato.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtAccesoriosPersonaSePercato.TabIndex = 1;
            this.txtAccesoriosPersonaSePercato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(151, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Descripción de Responsables:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(371, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Fecha en que se percató:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Persona que se percató:";
            // 
            // dgvVehiculoAccesorios
            // 
            this.dgvVehiculoAccesorios.AllowUserToAddRows = false;
            this.dgvVehiculoAccesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehiculoAccesorios.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvVehiculoAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculoAccesorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClaveVehiculoInvolucrado,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiculoAccesorios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehiculoAccesorios.Location = new System.Drawing.Point(11, 19);
            this.dgvVehiculoAccesorios.Name = "dgvVehiculoAccesorios";
            this.dgvVehiculoAccesorios.RowHeadersVisible = false;
            this.dgvVehiculoAccesorios.Size = new System.Drawing.Size(621, 109);
            this.dgvVehiculoAccesorios.TabIndex = 13;
            this.dgvVehiculoAccesorios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehiculoAccesorios_CellClick);
            // 
            // ClaveVehiculoInvolucrado
            // 
            this.ClaveVehiculoInvolucrado.HeaderText = "Clave";
            this.ClaveVehiculoInvolucrado.Name = "ClaveVehiculoInvolucrado";
            this.ClaveVehiculoInvolucrado.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Marca";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Modelo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Placas";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // gbDatosRobo
            // 
            this.gbDatosRobo.Controls.Add(this.txtAccesoriosResponsables);
            this.gbDatosRobo.Controls.Add(this.txtAccesoriosPersonaSePercato);
            this.gbDatosRobo.Controls.Add(this.label15);
            this.gbDatosRobo.Controls.Add(this.label20);
            this.gbDatosRobo.Controls.Add(this.dtpAccesoriosFechaPercato);
            this.gbDatosRobo.Controls.Add(this.label16);
            this.gbDatosRobo.Location = new System.Drawing.Point(12, 12);
            this.gbDatosRobo.Name = "gbDatosRobo";
            this.gbDatosRobo.Size = new System.Drawing.Size(644, 81);
            this.gbDatosRobo.TabIndex = 0;
            this.gbDatosRobo.TabStop = false;
            this.gbDatosRobo.Text = "Datos del robo";
            // 
            // gbDatosVehiculo
            // 
            this.gbDatosVehiculo.Controls.Add(this.btnAgregarVehiculo);
            this.gbDatosVehiculo.Controls.Add(this.txtPlacas);
            this.gbDatosVehiculo.Controls.Add(this.gbAccesorios);
            this.gbDatosVehiculo.Controls.Add(this.txtModelo);
            this.gbDatosVehiculo.Controls.Add(this.txtMarca);
            this.gbDatosVehiculo.Controls.Add(this.label4);
            this.gbDatosVehiculo.Controls.Add(this.label3);
            this.gbDatosVehiculo.Controls.Add(this.label1);
            this.gbDatosVehiculo.Location = new System.Drawing.Point(12, 99);
            this.gbDatosVehiculo.Name = "gbDatosVehiculo";
            this.gbDatosVehiculo.Size = new System.Drawing.Size(644, 223);
            this.gbDatosVehiculo.TabIndex = 1;
            this.gbDatosVehiculo.TabStop = false;
            this.gbDatosVehiculo.Text = "Datos del vehículo involucrado :";
            // 
            // btnAgregarVehiculo
            // 
            this.btnAgregarVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarVehiculo.Location = new System.Drawing.Point(597, 192);
            this.btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            this.btnAgregarVehiculo.Size = new System.Drawing.Size(35, 23);
            this.btnAgregarVehiculo.TabIndex = 4;
            this.btnAgregarVehiculo.Text = "+";
            this.btnAgregarVehiculo.UseVisualStyleBackColor = true;
            this.btnAgregarVehiculo.Click += new System.EventHandler(this.btnAgregarVehiculo_Click);
            // 
            // txtPlacas
            // 
            this.txtPlacas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlacas.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPlacas.Location = new System.Drawing.Point(492, 22);
            this.txtPlacas.MaxLength = 250;
            this.txtPlacas.Name = "txtPlacas";
            this.txtPlacas.Size = new System.Drawing.Size(140, 20);
            this.txtPlacas.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtPlacas.TabIndex = 2;
            this.txtPlacas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtModelo.Location = new System.Drawing.Point(277, 22);
            this.txtModelo.MaxLength = 250;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(140, 20);
            this.txtModelo.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtModelo.TabIndex = 1;
            this.txtModelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // txtMarca
            // 
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMarca.Location = new System.Drawing.Point(52, 22);
            this.txtMarca.MaxLength = 250;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(140, 20);
            this.txtMarca.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtMarca.TabIndex = 0;
            this.txtMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Modelo :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Placas :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Marca :";
            // 
            // gbVehiculos
            // 
            this.gbVehiculos.Controls.Add(this.dgvVehiculoAccesorios);
            this.gbVehiculos.Location = new System.Drawing.Point(12, 328);
            this.gbVehiculos.Name = "gbVehiculos";
            this.gbVehiculos.Size = new System.Drawing.Size(644, 138);
            this.gbVehiculos.TabIndex = 2;
            this.gbVehiculos.TabStop = false;
            this.gbVehiculos.Text = "Vehículos Involucrados :";
            // 
            // SAIFrmAltaAccesoriosAuto066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 473);
            this.Controls.Add(this.gbVehiculos);
            this.Controls.Add(this.gbDatosVehiculo);
            this.Controls.Add(this.gbDatosRobo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmAltaAccesoriosAuto066";
            this.Text = "SAI - Información de accesorios robados";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SAIFrmAltaAccesoriosAuto066_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmAltaAccesoriosAuto066_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SAIAltaAccesoriosAuto066_KeyDown);
            this.gbAccesorios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculoAccesorios)).EndInit();
            this.gbDatosRobo.ResumeLayout(false);
            this.gbDatosRobo.PerformLayout();
            this.gbDatosVehiculo.ResumeLayout(false);
            this.gbDatosVehiculo.PerformLayout();
            this.gbVehiculos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAccesorios;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtAccesoriosResponsables;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDatePicker dtpAccesoriosFechaPercato;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtAccesoriosPersonaSePercato;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView dgvVehiculoAccesorios;
        private System.Windows.Forms.GroupBox gbDatosRobo;
        private System.Windows.Forms.GroupBox gbDatosVehiculo;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtModelo;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtPlacas;
        private System.Windows.Forms.Button btnAgregarVehiculo;
        private System.Windows.Forms.GroupBox gbVehiculos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveVehiculoInvolucrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvAccesorios;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcIdAccesorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcAccesorio;
    }
}