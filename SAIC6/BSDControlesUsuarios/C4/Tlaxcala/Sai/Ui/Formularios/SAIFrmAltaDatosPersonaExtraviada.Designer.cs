namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmAltaDatosPersonaExtraviada
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
            this.grpExtravio = new System.Windows.Forms.GroupBox();
            this.dgvPersonaExtraviada = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView(this.components);
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Estatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaExtravio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tez = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCabello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorCabello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LargoCabello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cejas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OjosColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OjosForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NarizForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BocaTamaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vestimenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caracteristicas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpExtravio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonaExtraviada)).BeginInit();
            this.SuspendLayout();
            // 
            // grpExtravio
            // 
            this.grpExtravio.Controls.Add(this.dgvPersonaExtraviada);
            this.grpExtravio.Location = new System.Drawing.Point(12, 12);
            this.grpExtravio.Name = "grpExtravio";
            this.grpExtravio.Size = new System.Drawing.Size(746, 182);
            this.grpExtravio.TabIndex = 20;
            this.grpExtravio.TabStop = false;
            this.grpExtravio.Text = "Extravío de Persona";
            // 
            // dgvPersonaExtraviada
            // 
            this.dgvPersonaExtraviada.AllowUserToOrderColumns = true;
            this.dgvPersonaExtraviada.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvPersonaExtraviada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonaExtraviada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Folio,
            this.Nombre,
            this.Edad,
            this.Sexo,
            this.Estatura,
            this.Parentesco,
            this.FechaExtravio,
            this.Tez,
            this.TipoCabello,
            this.ColorCabello,
            this.LargoCabello,
            this.Frente,
            this.Cejas,
            this.OjosColor,
            this.OjosForma,
            this.NarizForma,
            this.BocaTamaño,
            this.Labios,
            this.Vestimenta,
            this.Destino,
            this.Caracteristicas});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonaExtraviada.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonaExtraviada.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPersonaExtraviada.Location = new System.Drawing.Point(3, 16);
            this.dgvPersonaExtraviada.MultiSelect = false;
            this.dgvPersonaExtraviada.Name = "dgvPersonaExtraviada";
            this.dgvPersonaExtraviada.RowHeadersVisible = false;
            this.dgvPersonaExtraviada.Size = new System.Drawing.Size(737, 152);
            this.dgvPersonaExtraviada.TabIndex = 0;
            this.dgvPersonaExtraviada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPersonaExtraviada_KeyDown);
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.Visible = false;
            // 
            // Folio
            // 
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MaxInputLength = 250;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 300;
            // 
            // Edad
            // 
            this.Edad.HeaderText = "Edad";
            this.Edad.Name = "Edad";
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.Sexo.Name = "Sexo";
            this.Sexo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sexo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Estatura
            // 
            this.Estatura.HeaderText = "Estatura";
            this.Estatura.Name = "Estatura";
            // 
            // Parentesco
            // 
            this.Parentesco.HeaderText = "Parentesco";
            this.Parentesco.MaxInputLength = 15;
            this.Parentesco.Name = "Parentesco";
            // 
            // FechaExtravio
            // 
            this.FechaExtravio.HeaderText = "Fecha de Extravío";
            this.FechaExtravio.Name = "FechaExtravio";
            // 
            // Tez
            // 
            this.Tez.HeaderText = "Tez";
            this.Tez.MaxInputLength = 50;
            this.Tez.Name = "Tez";
            // 
            // TipoCabello
            // 
            this.TipoCabello.HeaderText = "Tipo de Cabello";
            this.TipoCabello.MaxInputLength = 15;
            this.TipoCabello.Name = "TipoCabello";
            // 
            // ColorCabello
            // 
            this.ColorCabello.HeaderText = "Color de Cabello";
            this.ColorCabello.MaxInputLength = 15;
            this.ColorCabello.Name = "ColorCabello";
            // 
            // LargoCabello
            // 
            this.LargoCabello.HeaderText = "Largo de Cabello";
            this.LargoCabello.MaxInputLength = 15;
            this.LargoCabello.Name = "LargoCabello";
            // 
            // Frente
            // 
            this.Frente.HeaderText = "Frente";
            this.Frente.MaxInputLength = 15;
            this.Frente.Name = "Frente";
            // 
            // Cejas
            // 
            this.Cejas.HeaderText = "Cejas";
            this.Cejas.MaxInputLength = 15;
            this.Cejas.Name = "Cejas";
            // 
            // OjosColor
            // 
            this.OjosColor.HeaderText = "Color de Ojos";
            this.OjosColor.MaxInputLength = 15;
            this.OjosColor.Name = "OjosColor";
            // 
            // OjosForma
            // 
            this.OjosForma.HeaderText = "Forma de Ojos";
            this.OjosForma.MaxInputLength = 15;
            this.OjosForma.Name = "OjosForma";
            // 
            // NarizForma
            // 
            this.NarizForma.HeaderText = "Forma de Nariz";
            this.NarizForma.MaxInputLength = 15;
            this.NarizForma.Name = "NarizForma";
            // 
            // BocaTamaño
            // 
            this.BocaTamaño.HeaderText = "Tamaño de Boca";
            this.BocaTamaño.MaxInputLength = 15;
            this.BocaTamaño.Name = "BocaTamaño";
            // 
            // Labios
            // 
            this.Labios.HeaderText = "Labios";
            this.Labios.MaxInputLength = 15;
            this.Labios.Name = "Labios";
            // 
            // Vestimenta
            // 
            this.Vestimenta.HeaderText = "Vestimenta";
            this.Vestimenta.MaxInputLength = 250;
            this.Vestimenta.Name = "Vestimenta";
            // 
            // Destino
            // 
            this.Destino.HeaderText = "Destino";
            this.Destino.MaxInputLength = 250;
            this.Destino.Name = "Destino";
            // 
            // Caracteristicas
            // 
            this.Caracteristicas.HeaderText = "Caracteristicas";
            this.Caracteristicas.MaxInputLength = 250;
            this.Caracteristicas.Name = "Caracteristicas";
            // 
            // SAIFrmAltaDatosPersonaExtraviada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 200);
            this.Controls.Add(this.grpExtravio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmAltaDatosPersonaExtraviada";
            this.Text = "Datos de persona extraviada";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAIFrmAltaDatosPersonaExtraviada_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SAIFrmAltaDatosPersonaExtraviada_KeyDown);
            this.grpExtravio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonaExtraviada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpExtravio;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView dgvPersonaExtraviada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewComboBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaExtravio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tez;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCabello;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorCabello;
        private System.Windows.Forms.DataGridViewTextBoxColumn LargoCabello;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cejas;
        private System.Windows.Forms.DataGridViewTextBoxColumn OjosColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn OjosForma;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarizForma;
        private System.Windows.Forms.DataGridViewTextBoxColumn BocaTamaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vestimenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caracteristicas;
    }
}