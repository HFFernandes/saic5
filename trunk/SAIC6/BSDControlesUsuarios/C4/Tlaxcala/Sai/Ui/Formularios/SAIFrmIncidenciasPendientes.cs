using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XtremeReportControl;
using System.Reflection;

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
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
        }

        private void SAIFrmIncidenciasPendientes_Load(object sender, EventArgs e)
        {
            saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            saiReport1.AgregarColumna(0, "ID", 20, false, false);
            saiReport1.AgregarColumna(1, "Folio", 200, true,true);
            saiReport1.AgregarColumna(2, "Hora de Entrada", 200, true,true);
            saiReport1.AgregarColumna(3, "Corporación", 300, true, true);
            saiReport1.AgregarColumna(4, "Tipo de Incidencia", 100, true, true);
            saiReport1.AgregarColumna(5, "Zn", 100, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 80, true, true);
            saiReport1.AgregarColumna(7, "Pendiente Desde", 150, true, true);
            saiReport1.AgregarColumna(8, "Nombre del Operador", 300, true, true);
        }
    }
}
