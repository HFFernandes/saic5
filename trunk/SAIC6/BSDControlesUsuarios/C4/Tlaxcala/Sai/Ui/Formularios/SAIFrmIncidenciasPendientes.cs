using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using XtremeReportControl;
using System.Text;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasPendientes : SAIFrmBase
    {
        private List<Incidencia> lstIncidenciasRegistradas;
        private List<Incidencia> lstIncidenciasTemporales;
        private List<Incidencia> lstIncidenciasPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        public SAIFrmIncidenciasPendientes()
        {
            InitializeComponent();
            Width = Screen.GetWorkingArea(this).Width;
            //var intReg = saiReport1.reportControl.EnableDragDrop("SAIC4:iPendientes",
            //                              XTPReportDragDrop.xtpReportAllowDrag |
            //                              XTPReportDragDrop.xtpReportAllowDrop);
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnBajaUnidad.Click += btnBajaUnidad_Click;
            saiReport1.btnAltaUnidad.Click += btnAltaUnidad_Click;
            saiReport1.reportControl.RowDblClick += reportControl_RowDblClick;

            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporales = new List<Incidencia>();
            lstIncidenciasPorRemover = new List<Incidencia>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        void reportControl_RowDblClick(object sender, AxXtremeReportControl._DReportControlEvents_RowDblClickEvent e)
        {
        }

        void btnAltaUnidad_Click(object sender, EventArgs e)
        {
        }

        void btnBajaUnidad_Click(object sender, EventArgs e)
        {
        }

        void btnDespacharIncidencias_Click(object sender, EventArgs e)
        {
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
        }

        private void SAIFrmIncidenciasPendientes_Load(object sender, EventArgs e)
        {
            //saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);
            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;

            //Falta mostrar la prioridad del incidente
            saiReport1.AgregarColumna(0, "ID", 20, false, false, false);
            saiReport1.AgregarColumna(1, "Folio", 150, true, true, true);
            saiReport1.AgregarColumna(2, "Hora de Entrada", 200, true, true, true);
            saiReport1.AgregarColumna(3, "Corporación", 300, true, true, true);
            saiReport1.AgregarColumna(4, "Tipo de Incidencia", 150, true, true, true);
            saiReport1.AgregarColumna(5, "Zn", 100, true, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 80, true, false, true);
            saiReport1.AgregarColumna(7, "Pendiente Desde", 150, true, true, true);
            saiReport1.AgregarColumna(8, "Nombre del Operador", 200, true, true, true);
            ObtenerRegistros();
        }

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
            //saiReport1.reportControl.Refresh();
            saiReport1.reportControl.Redraw();
        }

        private void ObtenerRegistros()
        {
            try
            {
                //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea pendiente
                //para iniciar nuevamente el ciclo
                lstIncidenciasTemporales.Clear();
                foreach (var incidencia in (IncidenciaMapper.Instance().GetByEstatusIncidencia((int)ESTATUSINCIDENCIAS.PENDIENTE))) //vamos a la base para obtener los registros de estado pendiente
                {
                    lstIncidenciasTemporales.Add(incidencia);
                    //verificamos que la incidencia no esté ya en la lista de incidencias registradas
                    //que de no estarlo la agregamos al listado tipado y al grid
                    if (!lstIncidenciasRegistradas.Contains(incidencia))
                    {
                        lstIncidenciasRegistradas.Add(incidencia);
                        var corporaciones = new StringBuilder();
                        var zonas = new StringBuilder();
                        var totalCorporaciones = 0;

                        CorporacionMapper.Instance().GetBySQLQuery(string.Format(SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                        {
                            corporaciones.Append(c.Descripcion);
                            corporaciones.Append(",");

                            zonas.Append(c.Zn);
                            zonas.Append(",");

                            if (c.Descripcion != string.Empty)
                                totalCorporaciones += 1;
                        });

                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(incidencia.Folio,
                                                                       incidencia.Folio.ToString(),
                                                                       incidencia.HoraRecepcion.ToShortTimeString(),
                                                                       corporaciones.ToString().Trim().Length > 0 ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1) : string.Empty,
                                                                       TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion,
                                                                       zonas.ToString().Trim().Length > 0 ? zonas.ToString().Trim().Remove(zonas.Length - 1) : string.Empty,
                                                                       totalCorporaciones.ToString(),
                                                                       ObtenerLapso(incidencia.HoraRecepcion),
                                                                       UsuarioMapper.Instance().GetOne(incidencia.ClaveUsuario).NombreUsuario));
                    }
                    else
                    {
                        //la incidencia ya existe en la colección,ahora la
                        //buscamos y verificamos si algún registro cambio para su actualizacion
                        var incidenciaTemp = lstIncidenciasRegistradas.Find(inc => inc.Folio == incidencia.Folio);
                        if (incidenciaTemp != null)
                        {
                            //contamos las columnas y los registros actuales para
                            //delimitar la busqueda del Row
                            var iCols = saiReport1.reportControl.Columns.Count;
                            var iRows = saiReport1.reportControl.Rows.Count;

                            //buscamos el Row por el número único de folio para obtener su posición dentro del grid
                            var itm = saiReport1.reportControl.Records.FindRecordItem(1, iRows, 1, iCols, 1, 1, incidencia.Folio.ToString(), XTPReportTextSearchParms.xtpReportTextSearchExactPhrase);
                            if (itm != null && itm.Index >= 0)
                            {
                                //comparamos el valor anterior con el actual y si cambio entonces actualizamos
                                if (!incidenciaTemp.HoraRecepcion.Equals(incidencia.HoraRecepcion))
                                    saiReport1.reportControl.Records[itm.Record.Index][2].Value =
                                        incidencia.HoraRecepcion.ToShortTimeString();

                                var corporaciones = new StringBuilder();
                                var zonas = new StringBuilder();
                                var totalCorporaciones = 0;

                                CorporacionMapper.Instance().GetBySQLQuery(string.Format(SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                                {
                                    corporaciones.Append(c.Descripcion);
                                    corporaciones.Append(",");

                                    zonas.Append(c.Zn);
                                    zonas.Append(",");

                                    if (c.Descripcion != string.Empty)
                                        totalCorporaciones += 1;
                                });

                                saiReport1.reportControl.Records[itm.Record.Index][3].Value =
                                    corporaciones.ToString().Trim().Length > 0
                                        ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1)
                                        : "(desconocido)";

                                if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value =
                                        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion;

                                saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                    zonas.ToString().Trim().Length > 0
                                        ? zonas.ToString().Trim().Remove(zonas.Length - 1)
                                        : "(desconocido)";

                                saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                    totalCorporaciones.ToString();
                                saiReport1.reportControl.Records[itm.Record.Index][7].Value = ObtenerLapso(incidencia.HoraRecepcion);
                            }
                        }
                    }
                }

                foreach (var incidencia in lstIncidenciasRegistradas)
                {
                    //comprobar si la incidencia registrada existe en la incidencia temporal
                    //para luego entonces determinar cuales deberan ser eliminadas del grid
                    if (!lstIncidenciasTemporales.Contains(incidencia))
                    {
                        lstIncidenciasPorRemover.Add(incidencia);
                    }
                }

                //recorremos la colección de incidencias por remover
                //y hacemos match contra el número único de folio para proceder
                //a eliminar el registro del grid
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
                lstIncidenciasPorRemover.Clear();   //limpiamos la colección para el nuevo ciclo
            }
            catch (Exception ex)
            {
                tmrRegistros.Enabled = false;
                throw new SAIExcepcion(ex.Message, this);
            }
        }

        private string ObtenerLapso(DateTime dtFecha)
        {
            try
            {
                var ahora = DateTime.Now;
                var lapso = ahora.Subtract(dtFecha);

                return string.Format("{0:0} dias {1:0} horas y {2:0} minutos", lapso.TotalDays, lapso.TotalHours,
                                     lapso.TotalMinutes);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private const string SQL_CORPORACIONES =
            "SELECT Corporacion.* FROM Corporacion INNER JOIN CorporacionIncidencia ON Corporacion.Clave = CorporacionIncidencia.ClaveCorporacion INNER JOIN Incidencia ON CorporacionIncidencia.Folio = Incidencia.Folio WHERE (Incidencia.Folio = {0})";
    }
}
