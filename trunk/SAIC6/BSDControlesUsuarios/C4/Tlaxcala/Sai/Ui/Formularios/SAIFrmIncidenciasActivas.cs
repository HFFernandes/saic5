using System;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasActivas : SAIFrmBase
    {
        public int intSubModulo
        {
            get
            {
                return ID.PNT_IA;
            }
        }

        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();
            Width = Screen.GetWorkingArea(this).Width;
        }

        private void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);
        }
    }
}
