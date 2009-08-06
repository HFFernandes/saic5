using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using System.Diagnostics;
using BSD.C4.Tlaxcala.Sai.Excepciones;

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

        private List<Incidencia> lstIncidenciasRegistradas;
        private List<Incidencia> lstIncidenciasTemporal;
        private List<Incidencia> lstIncidenciasRemover;

        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporal = new List<Incidencia>();
            lstIncidenciasRemover=new List<Incidencia>();
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
            try
            {
                IncidenciaList incidenciaList = IncidenciaMapper.Instance().GetByEstatusIncidencia(1);

                lstIncidenciasTemporal.Clear();
                foreach (var incidencia in incidenciaList)
                {
                    lstIncidenciasTemporal.Add(incidencia);

                    if (!lstIncidenciasRegistradas.Contains(incidencia))
                        lstIncidenciasRegistradas.Add(incidencia);
                }

                foreach (var i in lstIncidenciasRegistradas)
                {
                    //comprobar si la incidencia registrada existe en la incidencia temporal
                    if (lstIncidenciasTemporal.Contains(i))
                        Debug.WriteLine("no hacer nada");
                    else
                    {
                        //lstIncidenciasRegistradas.Remove(i); //no se puede eliminar de la colleccion mientras enumeramos sobre ella
                        lstIncidenciasRemover.Add(i);
                    }
                }

                foreach (var incidencia in lstIncidenciasRemover)
                {
                    lstIncidenciasRegistradas.Remove(incidencia);
                }
                lstIncidenciasRemover.Clear();
            }
            catch (Exception ex)
            {
                tmrRegistros.Enabled = false;
                throw new SAIExcepcion(ex.Message);
            }
        }
    }
}
