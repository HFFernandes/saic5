using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

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

        private List<int> lstIncidenciasRegistradas;

        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            lstIncidenciasRegistradas = new List<int>();
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
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

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            //saiReport1.LimpiarListado();

            IncidenciaList incidenciaList = IncidenciaMapper.Instance().GetByEstatusIncidencia(1);
            foreach (var incidencia in incidenciaList)
            {
                //falta revisar estado...switch(estatus)1->agregar2->eliminar (ejemplo)
                if (!lstIncidenciasRegistradas.Contains(incidencia.Folio))
                {
                    lstIncidenciasRegistradas.Add(incidencia.Folio);
                    saiReport1.AgregarRegistro(incidencia.Telefono,
                        incidencia.ClaveEstatus.ToString(),
                        incidencia.HoraRecepcion.ToString(),
                        incidencia.Direccion,
                        incidencia.ClaveTipo.ToString(), "",
                        incidencia.Folio.ToString());
                }
            }
        }
    }
}
