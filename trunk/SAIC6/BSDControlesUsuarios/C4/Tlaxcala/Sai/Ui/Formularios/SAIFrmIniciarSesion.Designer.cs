namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    partial class SAIFrmIniciarSesion
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
            this.saiLogoControl = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAILogoControl();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.saiTxtContraseña = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.saiCmbSistema = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox(this.components);
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.saiTxtUsuario = new BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox(this.components);
            this.SuspendLayout();
            // 
            // saiLogoControl
            // 
            this.saiLogoControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.saiLogoControl.Location = new System.Drawing.Point(0, 0);
            this.saiLogoControl.Name = "saiLogoControl";
            this.saiLogoControl.Size = new System.Drawing.Size(414, 70);
            this.saiLogoControl.TabIndex = 0;
            this.saiLogoControl.VelocidadAnimacion = 8;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(23, 104);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(101, 13);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(60, 136);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 3;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(34, 170);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(90, 13);
            this.lblSistema.TabIndex = 5;
            this.lblSistema.Text = "Sistema a Utilizar:";
            // 
            // saiTxtContraseña
            // 
            this.saiTxtContraseña.BlnEsRequerido = true;
            this.saiTxtContraseña.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtContraseña.Location = new System.Drawing.Point(130, 136);
            this.saiTxtContraseña.Name = "saiTxtContraseña";
            this.saiTxtContraseña.PasswordChar = '*';
            this.saiTxtContraseña.Size = new System.Drawing.Size(233, 20);
            this.saiTxtContraseña.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtContraseña.TabIndex = 4;
            this.saiTxtContraseña.UseSystemPasswordChar = true;
            // 
            // saiCmbSistema
            // 
            this.saiCmbSistema.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiCmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saiCmbSistema.FormattingEnabled = true;
            this.saiCmbSistema.Location = new System.Drawing.Point(130, 170);
            this.saiCmbSistema.Name = "saiCmbSistema";
            this.saiCmbSistema.Size = new System.Drawing.Size(233, 21);
            this.saiCmbSistema.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiCmbSistema.TabIndex = 6;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(288, 217);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 7;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAceptar.Location = new System.Drawing.Point(207, 217);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 8;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // saiTxtUsuario
            // 
            this.saiTxtUsuario.BlnEsRequerido = true;
            this.saiTxtUsuario.ClrBackColorFoco = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.saiTxtUsuario.Location = new System.Drawing.Point(130, 104);
            this.saiTxtUsuario.Name = "saiTxtUsuario";
            this.saiTxtUsuario.Size = new System.Drawing.Size(233, 20);
            this.saiTxtUsuario.StrMensajeCampoRequerido = "El campo es requerido.";
            this.saiTxtUsuario.TabIndex = 2;
            // 
            // SAIFrmIniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 281);
            this.ControlBox = false;
            this.Controls.Add(this.saiTxtUsuario);
            this.Controls.Add(this.saiCmbSistema);
            this.Controls.Add(this.saiTxtContraseña);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.saiLogoControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAIFrmIniciarSesion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SAI - Iniciar Sesión";
            this.Controls.SetChildIndex(this.saiLogoControl, 0);
            this.Controls.SetChildIndex(this.lblNombreUsuario, 0);
            this.Controls.SetChildIndex(this.lblContraseña, 0);
            this.Controls.SetChildIndex(this.lblSistema, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.Controls.SetChildIndex(this.cmdAceptar, 0);
            this.Controls.SetChildIndex(this.saiTxtContraseña, 0);
            this.Controls.SetChildIndex(this.saiCmbSistema, 0);
            this.Controls.SetChildIndex(this.saiTxtUsuario, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAILogoControl saiLogoControl;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblSistema;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtContraseña;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAIComboBox saiCmbSistema;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private BSD.C4.Tlaxcala.Sai.Ui.Controles.SAITextBox saiTxtUsuario;
    }
}