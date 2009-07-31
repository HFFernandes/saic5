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
            base.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.saiLogoControl.DetenerAnimacion();
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}