using System;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasActivas : SAIFrmBase
    {
        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
        }

        private void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
        }
    }
}
