using System;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIniciarSesion : SAIFrmBase
    {
        public SAIFrmIniciarSesion()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            this.saiLogoControl.IniciarAnimacion();
            if (base.SAIProveedorValidacion.ValidarCamposRequeridos(this))
            {
                base.DialogResult = System.Windows.Forms.DialogResult.OK;    
            }
            else
            {
                base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.saiLogoControl.DetenerAnimacion();
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}