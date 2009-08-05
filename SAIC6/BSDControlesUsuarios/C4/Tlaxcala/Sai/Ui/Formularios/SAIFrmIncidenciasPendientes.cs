using System;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasPendientes : SAIFrmBase
    {
        public static int intSubModulo
        {
            get
            {
                return ID.PNT_IP;
            }
        }

        public SAIFrmIncidenciasPendientes()
        {
            InitializeComponent();
            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += new EventHandler(btnLigarIncidencias_Click);
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ligar incidencias pendientes");
        }

        private void SAIFrmIncidenciasPendientes_Load(object sender, EventArgs e)
        {
            saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            saiReport1.AgregarColumna(0, "Folio", 200, true);
            saiReport1.AgregarColumna(1, "Hora de Entrada", 200, true);
            saiReport1.AgregarColumna(2, "Corporación", 300, true);
            saiReport1.AgregarColumna(3, "Tipo de Incidencia", 100, true);
            saiReport1.AgregarColumna(4, "Zn", 100, true);
            saiReport1.AgregarColumna(5, "Dividido En", 80, true);
            saiReport1.AgregarColumna(6, "Pendiente Desde", 150, true);
            saiReport1.AgregarColumna(7, "Nombre del Operador", 300, true);
        }
    }
}
