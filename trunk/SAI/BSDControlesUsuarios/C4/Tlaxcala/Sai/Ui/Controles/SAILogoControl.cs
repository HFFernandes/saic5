using System;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    public partial class SAILogoControl : UserControl
    {
        #region Propiedades

        public int VelocidadAnimacion
        {
            get
            {
                return this.spinnerPicture.Velocidad;
            }
            set
            {
                this.spinnerPicture.Velocidad = value;
            }
        }

        #endregion

        public SAILogoControl()
        {
            InitializeComponent();
            this.spinnerPicture.Velocidad = 8;
            this.logoPicture.SizeChanged += this.VerificarTamaño;
        }

        public void DetenerAnimacion()
        {
            this.spinnerPicture.Desactivar();
        }

        public void IniciarAnimacion()
        {
            if (this.spinnerPicture.Velocidad < 0)
            {
                this.spinnerPicture.Velocidad = -this.spinnerPicture.Velocidad;
            }
            this.spinnerPicture.Activar();
        }

        public void RevertirAnimacion()
        {
            if (this.VelocidadAnimacion > 0)
            {
                this.spinnerPicture.Velocidad = -this.spinnerPicture.Velocidad;
            }
        }

        private void VerificarTamaño(object sender, EventArgs e)
        {
            if ((this.logoPicture.Size.Height < this.logoPicture.Image.Height) && (this.logoPicture.Size.Width < this.logoPicture.Image.Width))
            {
                this.logoPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                this.logoPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
    }
}
