using System;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasActivas : SAIFrmBase
    {
        public static int intSubModulo
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
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ligar incidencias activas");
        }

        void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            saiReport1.AgregarColumna(0, "No de Teléfono", 200, true);
            saiReport1.AgregarColumna(1, "Status", 200, true);
            saiReport1.AgregarColumna(2, "Hora de Entrada", 200, true);
            saiReport1.AgregarColumna(3, "Ubicación", 200, true);
            saiReport1.AgregarColumna(4, "Tipo de Incidencia", 200, true);
            saiReport1.AgregarColumna(5, "Dividido En", 200, true);
            saiReport1.AgregarColumna(6, "Folio", 200, true);
        }
    }
}
