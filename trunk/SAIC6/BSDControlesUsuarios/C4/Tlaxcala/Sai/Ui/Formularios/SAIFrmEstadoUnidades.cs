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
                foreach (var unidad in (UnidadMapper.Instance().GetByCorporacion(2))) //vamos a la base para obtener los registros de estado pendiente
                {
                    lstUnidadesTemporales.Add(unidad);
                    //verificamos que la incidencia no esté ya en la lista de incidencias registradas
                    //que de no estarlo la agregamos al listado tipado y al grid
                    if (!lstUnidadesRegistradas.Contains(unidad))
                    {
                        lstUnidadesRegistradas.Add(unidad);
                        //var corporaciones = new StringBuilder();
                        //var zonas = new StringBuilder();
                        //var totalCorporaciones = 0;

                        //CorporacionMapper.Instance().GetBySQLQuery(string.Format(SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                        //{
                        //    corporaciones.Append(c.Descripcion);
                        //    corporaciones.Append(",");

                        //    zonas.Append(c.Zn);
                        //    zonas.Append(",");

                        //    if (c.Descripcion != string.Empty)
                        //        totalCorporaciones += 1;
                        //});

                        //lstRegistrosReporte.Add(saiReport1.AgregarRegistro(incidencia.Folio,
                        //                                               incidencia.Folio.ToString(),
                        //                                               incidencia.HoraRecepcion.ToShortTimeString(),
                        //                                               corporaciones.ToString().Trim().Length > 0 ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1) : string.Empty,
                        //                                               TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion,
                        //                                               zonas.ToString().Trim().Length > 0 ? zonas.ToString().Trim().Remove(zonas.Length - 1) : string.Empty,
                        //                                               totalCorporaciones.ToString(),
                        //                                               ObtenerLapso(incidencia.HoraRecepcion),
                        //                                               UsuarioMapper.Instance().GetOne(incidencia.ClaveUsuario).NombreUsuario));
                    }
                    else
                    {
                        //la incidencia ya existe en la colección,ahora la
                        //buscamos y verificamos si algún registro cambio para su actualizacion
                        var unidadTemp = lstUnidadesRegistradas.Find(inc => inc.Codigo == unidad.Codigo);
                        if (unidadTemp != null)
                        {
                            //contamos las columnas y los registros actuales para
                            //delimitar la busqueda del Row
                            var iCols = saiReport1.reportControl.Columns.Count;
                            var iRows = saiReport1.reportControl.Rows.Count;

                            //buscamos el Row por el número único de folio para obtener su posición dentro del grid
                            var itm = saiReport1.reportControl.Records.FindRecordItem(1, iRows, 1, iCols, 1, 1, unidad.Codigo, XTPReportTextSearchParms.xtpReportTextSearchExactPhrase);
                            if (itm != null && itm.Index >= 0)
                            {
                                //comparamos el valor anterior con el actual y si cambio entonces actualizamos
                                //if (!incidenciaTemp.HoraRecepcion.Equals(incidencia.HoraRecepcion))
                                //    saiReport1.reportControl.Records[itm.Record.Index][2].Value =
                                //        incidencia.HoraRecepcion.ToShortTimeString();

                                //var corporaciones = new StringBuilder();
                                //var zonas = new StringBuilder();
                                //var totalCorporaciones = 0;

                                //CorporacionMapper.Instance().GetBySQLQuery(string.Format(SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                                //{
                                //    corporaciones.Append(c.Descripcion);
                                //    corporaciones.Append(",");

                                //    zonas.Append(c.Zn);
                                //    zonas.Append(",");

                                //    if (c.Descripcion != string.Empty)
                                //        totalCorporaciones += 1;
                                //});

                                //saiReport1.reportControl.Records[itm.Record.Index][3].Value =
                                //    corporaciones.ToString().Trim().Length > 0
                                //        ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1)
                                //        : "(desconocido)";

                                //if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                //    saiReport1.reportControl.Records[itm.Record.Index][4].Value =
                                //        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion;

                                //saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                //    zonas.ToString().Trim().Length > 0
                                //        ? zonas.ToString().Trim().Remove(zonas.Length - 1)
                                //        : "(desconocido)";

                                //saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                //    totalCorporaciones.ToString();
                                //saiReport1.reportControl.Records[itm.Record.Index][7].Value = ObtenerLapso(incidencia.HoraRecepcion);
                            }
                        }
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
                        if (registro.Tag == unidad.Codigo)
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
                throw new SAIExcepcion(ex.Message,this);
            }
        }

    }
}
