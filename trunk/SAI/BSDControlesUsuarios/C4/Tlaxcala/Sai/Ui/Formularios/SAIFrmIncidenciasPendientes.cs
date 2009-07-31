using System;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasPendientes : SAIFrmBase
    {
        public SAIFrmIncidenciasPendientes()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
        }

        private void SAIFrmIncidenciasPendientes_Load(object sender, EventArgs e)
        {
            saiReport1.AgregarColumna(0,"Número de Incidente",200,true);
            saiReport1.AgregarColumna(1, "Hora de Incidente", 200, true);
            saiReport1.AgregarColumna(2, "Corporación", 300, true);
            saiReport1.AgregarColumna(3, "Tipo de Incidente", 100, true);
            saiReport1.AgregarColumna(4, "Zn", 100, true);
            saiReport1.AgregarColumna(5, "Dividido En", 80, true);
            saiReport1.AgregarColumna(6, "Pendiente Desde", 150, true);
            saiReport1.AgregarColumna(7, "Nombre del Operador", 300, true);
        }
    }
}
