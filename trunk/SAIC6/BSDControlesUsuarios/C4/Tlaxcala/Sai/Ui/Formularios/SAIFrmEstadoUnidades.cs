using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using XtremeReportControl;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmEstadoUnidades : SAIFrmBase
    {

        private List<Unidad> lstUnidadesRegistradas;
        private List<Unidad> lstUnidadesTemporales;
        private List<Unidad> lstUnidadesPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        public SAIFrmEstadoUnidades()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            var intReg = saiReport1.reportControl.EnableDragDrop("SAIC4:iUnidades",
                                          XTPReportDragDrop.xtpReportAllowDrag |
                                          XTPReportDragDrop.xtpReportAllowDrop);
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnBajaUnidad.Click += btnBajaUnidad_Click;
            saiReport1.btnAltaUnidad.Click += btnAltaUnidad_Click;

            lstUnidadesRegistradas = new List<Unidad>();
            lstUnidadesTemporales = new List<Unidad>();
            lstUnidadesPorRemover = new List<Unidad>();
            lstRegistrosReporte = new List<ReportRecord>();
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

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
            saiReport1.reportControl.Refresh();
        }

        private void SAIFrmEstadoUnidades_Load(object sender, EventArgs e)
        {
            saiReport1.btnDespacharIncidencias.Visible = false;
            saiReport1.btnLigarIncidencias.Visible = false;
            saiReport1.btnSeparador2.Visible = false;

            saiReport1.AgregarColumna(0, "ID", 20, false, false, false);
            saiReport1.AgregarColumna(1, "Folio", 200, true, true, true);
            saiReport1.AgregarColumna(2, "Unidad", 200, true, true, true);
            saiReport1.AgregarColumna(3, "Nombre", 200, true, true, true);
            saiReport1.AgregarColumna(4, "Status", 200, true, true, true);
            saiReport1.AgregarColumna(5, "Hora", 200, true, true, true);
            saiReport1.AgregarColumna(6, "Localizacion", 200, true, true, true);
            saiReport1.AgregarColumna(7, "Motivo", 200, true, true, true);
            ObtenerRegistros();
        }

        private void ObtenerRegistros()
        {
            try
            {
                //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea activo
                //para iniciar nuevamente el ciclo
                lstUnidadesTemporales.Clear();
                foreach (var unidad in (UnidadMapper.Instance().GetByCorporacion(Aplicacion.UsuarioPersistencia.intCorporacion ?? -1))) //vamos a la base para obtener los registros de estado pendiente
                {
                    lstUnidadesTemporales.Add(unidad);
                    //verificamos que la incidencia no esté ya en la lista de incidencias registradas
                    //que de no estarlo la agregamos al listado tipado y al grid
                    if (!lstUnidadesRegistradas.Contains(unidad))
                    {
                        lstUnidadesRegistradas.Add(unidad);
                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(unidad.Clave,
                            "",
                            unidad.Codigo,
                            "",
                            "Libre",
                            DateTime.Now.ToShortTimeString(),
                            "",
                            ""));
                    }
                    else
                    {
                        //la incidencia ya existe en la colección,ahora la
                        //buscamos y verificamos si algún registro cambio para su actualizacion
                        //var unidadTemp = lstUnidadesRegistradas.Find(inc => inc.Clave == unidad.Clave);
                        //if (unidadTemp != null)
                        //{
                        //contamos las columnas y los registros actuales para
                        //delimitar la busqueda del Row
                        var iCols = saiReport1.reportControl.Columns.Count;
                        var iRows = saiReport1.reportControl.Rows.Count;

                        //buscamos el Row por el número único de folio para obtener su posición dentro del grid
                        var itm = saiReport1.reportControl.Records.FindRecordItem(1, iRows, 1, iCols, 1, 1, unidad.Codigo, XTPReportTextSearchParms.xtpReportTextSearchExactPhrase);
                        if (itm != null && itm.Index >= 0)
                        {
                            var dtHora = new DateTime();
                            var strStatus = string.Empty;

                            //DespachoIncidenciaList despachoIncidencias =
                            //    DespachoIncidenciaMapper.Instance().GetBySQLQuery(string.Format(
                            //                                                          SQL_OBTENERDESPACHOS, Aplicacion.UsuarioPersistencia.intCorporacion ?? -1));

                            //El case lo manejo desde codigo y no desde t-sql
                            var unidadDespachoList =
                                DespachoIncidenciaMapper.Instance().GetBySQLQuery(string.Format(
                                                                                      SQL_OBTENERDESPACHOS,
                                                                                      Aplicacion.UsuarioPersistencia
                                                                                          .intCorporacion ?? -1));
                            foreach (var unidadDespacho in unidadDespachoList)
                            {
                                if (unidadDespacho.HoraLiberada != null)
                                {
                                    dtHora = unidadDespacho.HoraLiberada ?? DateTime.Now;
                                    strStatus = "Libre";

                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value = "";   //por ser libre no tiene folio
                                    saiReport1.reportControl.Records[itm.Record.Index][2].Value = unidad.Codigo;
                                    saiReport1.reportControl.Records[itm.Record.Index][3].Value = "";   //falta el campo para coloca el responsable de la unidad
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value = strStatus;
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                        dtHora.ToShortTimeString();
                                    saiReport1.reportControl.Records[itm.Record.Index][6].Value = "";
                                    saiReport1.reportControl.Records[itm.Record.Index][7].Value = "";
                                    continue;
                                }

                                if (unidadDespacho.HoraLlegada != null)
                                {
                                    dtHora = unidadDespacho.HoraLlegada ?? DateTime.Now;
                                    strStatus = "Llegada";

                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value =
                                        unidadDespacho.Folio;
                                    goto Actualizar;
                                }

                                if (unidadDespacho.HoraDespachada != null)
                                {
                                    dtHora = unidadDespacho.HoraDespachada ?? DateTime.Now;
                                    strStatus = "Despachada";

                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value =
                                        unidadDespacho.Folio;
                                    goto Actualizar;
                                }

                            Actualizar:
                                //saiReport1.reportControl.Records[itm.Record.Index][1].Value = "";
                                //saiReport1.reportControl.Records[itm.Record.Index][2].Value = ""; //Nunca cambia siempre es la misma
                                saiReport1.reportControl.Records[itm.Record.Index][3].Value = "";   //falta el campo para coloca el responsable de la unidad
                                saiReport1.reportControl.Records[itm.Record.Index][4].Value = strStatus;
                                saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                    dtHora.ToShortTimeString();
                                saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                    IncidenciaMapper.Instance().GetOne(unidadDespacho.Folio).Direccion;
                                saiReport1.reportControl.Records[itm.Record.Index][7].Value =
                                    TipoIncidenciaMapper.Instance().GetOne(
                                        IncidenciaMapper.Instance().GetOne(unidadDespacho.Folio).ClaveTipo ?? -1).
                                        Descripcion;
                            }
                        }
                        //}
                    }
                }

                foreach (var unidad in lstUnidadesRegistradas)
                {
                    //comprobar si la incidencia registrada existe en la incidencia temporal
                    //para luego entonces determinar cuales deberan ser eliminadas del grid
                    if (!lstUnidadesTemporales.Contains(unidad))
                    {
                        lstUnidadesPorRemover.Add(unidad);
                    }
                }

                //recorremos la colección de incidencias por remover
                //y hacemos match contra el número único de folio para proceder
                //a eliminar el registro del grid
                foreach (var unidad in lstUnidadesPorRemover)
                {
                    foreach (var registro in lstRegistrosReporte)
                    {
                        if (Convert.ToInt32(registro.Tag) == unidad.Clave)
                        {
                            saiReport1.QuitarRegistro(registro);
                        }
                    }
                    lstUnidadesRegistradas.Remove(unidad);
                }
                lstUnidadesPorRemover.Clear();   //limpiamos la colección para el nuevo ciclo
            }
            catch (Exception ex)
            {
                tmrRegistros.Enabled = false;
                throw new SAIExcepcion(ex.Message, this);
            }
        }

        public const string SQL_OBTENERDESPACHOS = "SELECT DespachoIncidencia.* FROM DespachoIncidencia WHERE ClaveCorporacion={0}";

    }
}
