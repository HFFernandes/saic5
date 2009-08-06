using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using XtremeReportControl;

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
        private List<ReportRecord> lstReportRecord;

        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporal = new List<Incidencia>();
            lstIncidenciasRemover = new List<Incidencia>();
            lstReportRecord = new List<ReportRecord>();
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
        }

        void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            saiReport1.AgregarColumna(0, "ID", 20, false, false);
            saiReport1.AgregarColumna(1, "No de Teléfono", 200, true, true);
            saiReport1.AgregarColumna(2, "Status", 200, true, true);
            saiReport1.AgregarColumna(3, "Hora de Entrada", 200, true, true);
            saiReport1.AgregarColumna(4, "Ubicación", 200, true, true);
            saiReport1.AgregarColumna(5, "Tipo de Incidencia", 200, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 200, true, true);
            saiReport1.AgregarColumna(7, "Folio", 200, true, true);
        }

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            try
            {
                //IncidenciaList incidenciaList = IncidenciaMapper.Instance().GetByEstatusIncidencia(1);

                lstIncidenciasTemporal.Clear();
                foreach (var incidencia in (IncidenciaMapper.Instance().GetByEstatusIncidencia(1)))
                {
                    lstIncidenciasTemporal.Add(incidencia);
                    if (!lstIncidenciasRegistradas.Contains(incidencia))
                    {
                        lstIncidenciasRegistradas.Add(incidencia);

                        //agregar record
                        lstReportRecord.Add(saiReport1.AgregarRegistro(incidencia.Folio,
                            incidencia.Telefono,
                            incidencia.ClaveEstatus.ToString(),
                            incidencia.HoraRecepcion.ToString(),
                            incidencia.Direccion,
                            incidencia.ClaveTipo.ToString(),
                            "",
                            incidencia.Folio.ToString()));
                    }
                }

                foreach (var i in lstIncidenciasRegistradas)
                {
                    //comprobar si la incidencia registrada existe en la incidencia temporal
                    if (!lstIncidenciasTemporal.Contains(i))
                    {
                        lstIncidenciasRemover.Add(i);
                    }
                }

                foreach (var incidencia in lstIncidenciasRemover)
                {
                    foreach (var record in lstReportRecord)
                    {
                        if (Convert.ToInt32(record.Tag) == incidencia.Folio)
                        {
                            saiReport1.QuitarRegistro(record);
                        }
                    }
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
