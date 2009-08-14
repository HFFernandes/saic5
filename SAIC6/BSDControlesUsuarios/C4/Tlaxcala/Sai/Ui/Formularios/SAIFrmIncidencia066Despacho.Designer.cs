namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIncidencia066Despacho
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHoraLiberacion = new System.Windows.Forms.CheckBox();
            this.chkHoraLlegada = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlUnidadAsignada = new System.Windows.Forms.Panel();
            this.lblUnidadApoyo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlUnidad = new System.Windows.Forms.Panel();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.dtpHoraLiberacion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker(this.components);
            this.dtpHoraLlegada = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker(this.components);
            this.txtHoraDespacho = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.txtHoraRecepcion = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dgvComentarios = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView(this.components);
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlUnidadAsignada.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlUnidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkHoraLiberacion);
            this.groupBox2.Controls.Add(this.chkHoraLlegada);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dtpHoraLiberacion);
            this.groupBox2.Controls.Add(this.dtpHoraLlegada);
            this.groupBox2.Controls.Add(this.txtHoraDespacho);
            this.groupBox2.Controls.Add(this.txtHoraRecepcion);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.dgvComentarios);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 312);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Del Despacho";
            // 
            // chkHoraLiberacion
            // 
            this.chkHoraLiberacion.AutoSize = true;
            this.chkHoraLiberacion.Location = new System.Drawing.Point(532, 292);
            this.chkHoraLiberacion.Name = "chkHoraLiberacion";
            this.chkHoraLiberacion.Size = new System.Drawing.Size(15, 14);
            this.chkHoraLiberacion.TabIndex = 17;
            this.chkHoraLiberacion.UseVisualStyleBackColor = true;
            this.chkHoraLiberacion.CheckedChanged += new System.EventHandler(this.chkHoraLiberacion_CheckedChanged);
            // 
            // chkHoraLlegada
            // 
            this.chkHoraLlegada.AutoSize = true;
            this.chkHoraLlegada.Location = new System.Drawing.Point(384, 291);
            this.chkHoraLlegada.Name = "chkHoraLlegada";
            this.chkHoraLlegada.Size = new System.Drawing.Size(15, 14);
            this.chkHoraLlegada.TabIndex = 16;
            this.chkHoraLlegada.UseVisualStyleBackColor = true;
            this.chkHoraLlegada.CheckedChanged += new System.EventHandler(this.chkHoraLlegada_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnlUnidadAsignada);
            this.groupBox4.Location = new System.Drawing.Point(299, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 81);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Unidad De Apoyo Asignada";
            // 
            // pnlUnidadAsignada
            // 
            this.pnlUnidadAsignada.AllowDrop = true;
            this.pnlUnidadAsignada.Controls.Add(this.lblUnidadApoyo);
            this.pnlUnidadAsignada.Location = new System.Drawing.Point(7, 11);
            this.pnlUnidadAsignada.Name = "pnlUnidadAsignada";
            this.pnlUnidadAsignada.Size = new System.Drawing.Size(255, 64);
            this.pnlUnidadAsignada.TabIndex = 0;
            this.pnlUnidadAsignada.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlUnidadAsignada_DragOver);
            this.pnlUnidadAsignada.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlUnidadAsignada_DragDrop);
            // 
            // lblUnidadApoyo
            // 
            this.lblUnidadApoyo.AutoSize = true;
            this.lblUnidadApoyo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadApoyo.Location = new System.Drawing.Point(20, 22);
            this.lblUnidadApoyo.Name = "lblUnidadApoyo";
            this.lblUnidadApoyo.Size = new System.Drawing.Size(0, 20);
            this.lblUnidadApoyo.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlUnidad);
            this.groupBox3.Location = new System.Drawing.Point(6, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 81);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Unidad Asignada";
            // 
            // pnlUnidad
            // 
            this.pnlUnidad.AllowDrop = true;
            this.pnlUnidad.Controls.Add(this.lblUnidad);
            this.pnlUnidad.Location = new System.Drawing.Point(7, 11);
            this.pnlUnidad.Name = "pnlUnidad";
            this.pnlUnidad.Size = new System.Drawing.Size(251, 67);
            this.pnlUnidad.TabIndex = 0;
            this.pnlUnidad.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlUnidad_DragOver);
            this.pnlUnidad.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlUnidad_DragDrop);
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.Location = new System.Drawing.Point(26, 24);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(0, 20);
            this.lblUnidad.TabIndex = 0;
            // 
            // dtpHoraLiberacion
            // 
            this.dtpHoraLiberacion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dtpHoraLiberacion.CustomFormat = "hh:mm";
            this.dtpHoraLiberacion.Enabled = false;
            this.dtpHoraLiberacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraLiberacion.Location = new System.Drawing.Point(433, 285);
            this.dtpHoraLiberacion.Name = "dtpHoraLiberacion";
            this.dtpHoraLiberacion.ShowUpDown = true;
            this.dtpHoraLiberacion.Size = new System.Drawing.Size(93, 20);
            this.dtpHoraLiberacion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.dtpHoraLiberacion.TabIndex = 13;
            this.dtpHoraLiberacion.ValueChanged += new System.EventHandler(this.dtpHoraLiberacion_ValueChanged);
            this.dtpHoraLiberacion.Leave += new System.EventHandler(this.dtpHoraLiberacion_Leave);
            // 
            // dtpHoraLlegada
            // 
            this.dtpHoraLlegada.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dtpHoraLlegada.CustomFormat = "hh:mm";
            this.dtpHoraLlegada.Enabled = false;
            this.dtpHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraLlegada.Location = new System.Drawing.Point(285, 286);
            this.dtpHoraLlegada.Name = "dtpHoraLlegada";
            this.dtpHoraLlegada.ShowUpDown = true;
            this.dtpHoraLlegada.Size = new System.Drawing.Size(93, 20);
            this.dtpHoraLlegada.StrMensajeCampoRequerido = "El campo es requerido.";
            this.dtpHoraLlegada.TabIndex = 12;
            this.dtpHoraLlegada.ValueChanged += new System.EventHandler(this.dtpHoraLlegada_ValueChanged);
            this.dtpHoraLlegada.Leave += new System.EventHandler(this.dtpHoraLlegada_Leave);
            this.dtpHoraLlegada.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpHoraLlegada_KeyUp);
            // 
            // txtHoraDespacho
            // 
            this.txtHoraDespacho.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.txtHoraDespacho.Location = new System.Drawing.Point(137, 286);
            this.txtHoraDespacho.Name = "txtHoraDespacho";
            this.txtHoraDespacho.ReadOnly = true;
            this.txtHoraDespacho.Size = new System.Drawing.Size(91, 20);
            this.txtHoraDespacho.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtHoraDespacho.TabIndex = 11;
            this.txtHoraDespacho.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHoraDespacho_KeyUp);
            // 
            // txtHoraRecepcion
            // 
            this.txtHoraRecepcion.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.txtHoraRecepcion.Location = new System.Drawing.Point(10, 286);
            this.txtHoraRecepcion.Name = "txtHoraRecepcion";
            this.txtHoraRecepcion.ReadOnly = true;
            this.txtHoraRecepcion.Size = new System.Drawing.Size(91, 20);
            this.txtHoraRecepcion.StrMensajeCampoRequerido = "El campo es requerido.";
            this.txtHoraRecepcion.TabIndex = 10;
            this.txtHoraRecepcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHoraRecepcion_KeyUp);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(430, 256);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(97, 26);
            this.label24.TabIndex = 7;
            this.label24.Text = "Hora de Liberación\r\nde Unidad:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(286, 256);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(94, 26);
            this.label23.TabIndex = 6;
            this.label23.Text = "Hora De  Llegada \r\nDe Unidad:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(134, 256);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 26);
            this.label22.TabIndex = 5;
            this.label22.Text = "Hora de Despacho  \r\nde Incidencia:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 256);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 26);
            this.label21.TabIndex = 4;
            this.label21.Text = "Hora de Recepción \r\nde Incidencia:";
            // 
            // dgvComentarios
            // 
            this.dgvComentarios.AllowUserToDeleteRows = false;
            this.dgvComentarios.AllowUserToOrderColumns = true;
            this.dgvComentarios.ClrBackColorFoco = System.Drawing.Color.Empty;
            this.dgvComentarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComentarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Descripcion,
            this.Usuario,
            this.HoraRegistro});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComentarios.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComentarios.Location = new System.Drawing.Point(10, 107);
            this.dgvComentarios.Name = "dgvComentarios";
            this.dgvComentarios.RowHeadersVisible = false;
            this.dgvComentarios.Size = new System.Drawing.Size(560, 149);
            this.dgvComentarios.TabIndex = 3;
            this.dgvComentarios.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComentarios_CellLeave);
            this.dgvComentarios.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComentarios_CellValidated);
            this.dgvComentarios.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvComentarios_KeyUp);
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 300;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Despachador";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 200;
            // 
            // HoraRegistro
            // 
            this.HoraRegistro.HeaderText = "Fecha / Hora";
            this.HoraRegistro.Name = "HoraRegistro";
            this.HoraRegistro.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Comentarios:";
            // 
            // SAIFrmIncidencia066Despacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 778);
            this.Controls.Add(this.groupBox2);
            this.Name = "SAIFrmIncidencia066Despacho";
            this.Text = "SAIFrmIncidencia066Despacho";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SAIFrmIncidencia066Despacho_KeyUp);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.pnlUnidadAsignada.ResumeLayout(false);
            this.pnlUnidadAsignada.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.pnlUnidad.ResumeLayout(false);
            this.pnlUnidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIDataGridView dgvComentarios;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtHoraDespacho;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox txtHoraRecepcion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker dtpHoraLiberacion;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITimePicker dtpHoraLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraRegistro;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkHoraLiberacion;
        private System.Windows.Forms.CheckBox chkHoraLlegada;
        private System.Windows.Forms.Panel pnlUnidadAsignada;
        private System.Windows.Forms.Label lblUnidadApoyo;
        private System.Windows.Forms.Panel pnlUnidad;
        private System.Windows.Forms.Label lblUnidad;
    }
}