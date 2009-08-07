using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<Incidencia> lstIncidenciasTemporales;
        private List<Incidencia> lstIncidenciasPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporales = new List<Incidencia>();
            lstIncidenciasPorRemover = new List<Incidencia>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            //int iCols = saiReport1.reportControl.Columns.Count;
            //int iRows = saiReport1.reportControl.Rows.Count;

            //ReportRecordItem itm = saiReport1.reportControl.Records.FindRecordItem(1, iRows, 1, iCols, 1, 1, "666666",XTPReportTextSearchParms.xtpReportTextSearchExactPhrase);
            saiReport1.reportControl.Records[0][2].Value = "jaja";
        }

        void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            saiReport1.AgregarColumna(0, "ID", 20, false, false, false);
            saiReport1.AgregarColumna(1, "No de Teléfono", 200, true, true, true);
            saiReport1.AgregarColumna(2, "Status", 200, true, true, true);
            saiReport1.AgregarColumna(3, "Hora de Entrada", 200, true, true, true);
            saiReport1.AgregarColumna(4, "Ubicación", 200, true, true, true);
            saiReport1.AgregarColumna(5, "Tipo de Incidencia", 200, true, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 200, true, true, true);
            saiReport1.AgregarColumna(7, "Folio", 200, true, true, true);
            ObtenerRegistros();
        }

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
        }

        private void ObtenerRegistros()
        {
            try
            {
                lstIncidenciasTemporales.Clear();
                foreach (var incidencia in (IncidenciaMapper.Instance().GetByEstatusIncidencia(1)))
                {
                    lstIncidenciasTemporales.Add(incidencia);
                    if (!lstIncidenciasRegistradas.Contains(incidencia))
                    {
                        lstIncidenciasRegistradas.Add(incidencia);
                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(incidencia.Folio,
                                                                       incidencia.Telefono,
                                                                       incidencia.ClaveEstatus.ToString(),
                                                                       incidencia.HoraRecepcion.ToString(),
                                                                       incidencia.Direccion,
                                                                       incidencia.ClaveTipo.ToString(),
                                                                       "",
                                                                       incidencia.Folio.ToString()));
                    }
                    else
                    {
                        //hacer un else aqui y verificar si cambio
                        var incidenciaTemp = lstIncidenciasRegistradas.Find(inc => inc.Folio == incidencia.Folio);
                        if (incidenciaTemp != null)
                        {
                            
                            //se encontró la incidencia
                            //comparar incidenciaTemp contra incidencia
                            if (!incidenciaTemp.Telefono.Equals(incidencia.Telefono))
                            {
                                Debug.WriteLine(string.Format("viejo tel: {0}", incidenciaTemp.Telefono));
                                Debug.WriteLine(string.Format("nuevo tel: {0}", incidencia.Telefono));
                            }
                        }
                    }

                }

                foreach (var incidencia in lstIncidenciasRegistradas)
                {
                    //comprobar si la incidencia registrada existe en la incidencia temporal
                    if (!lstIncidenciasTemporales.Contains(incidencia))
                    {
                        lstIncidenciasPorRemover.Add(incidencia);
                    }
                }

                foreach (var incidencia in lstIncidenciasPorRemover)
                {
                    foreach (var registro in lstRegistrosReporte)
                    {
                        if (Convert.ToInt32(registro.Tag) == incidencia.Folio)
                        {
                            saiReport1.QuitarRegistro(registro);
                        }
                    }
                    lstIncidenciasRegistradas.Remove(incidencia);
                }
                lstIncidenciasPorRemover.Clear();
            }
            catch (Exception ex)
            {
                tmrRegistros.Enabled = false;
                throw new SAIExcepcion(ex.Message);
            }
        }
    }
}
