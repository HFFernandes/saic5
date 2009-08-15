using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using Microsoft.NetEnterpriseServers;
using XtremeReportControl;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using System.Diagnostics;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmEstadoUnidades : SAIFrmBase
    {

        private List<Unidad> lstUnidadesRegistradas;
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
            saiReport1.btnVistaPrevia.Click += btnVistaPrevia_Click;
            saiReport1.reportControl.RowDblClick += reportControl_RowDblClick;

            lstUnidadesRegistradas = new List<Unidad>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            saiReport1.reportControl.PrintPreviewOptions.Title = "Reporte de Unidades";
            saiReport1.reportControl.PrintPreview(true);
        }

        void reportControl_RowDblClick(object sender, AxXtremeReportControl._DReportControlEvents_RowDblClickEvent e)
        {
        }

        void btnAltaUnidad_Click(object sender, EventArgs e)
        {
            //TODO: Falta el procedimiento para agregar la unidad

            var agregarUnidad = new SAIFrmAgregarUnidad();
            var dialogResult = agregarUnidad.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {

            }
        }

        void btnBajaUnidad_Click(object sender, EventArgs e)
        {
            var confirmarBaja = new ExceptionMessageBox("¿Desea dar de baja la unidad?", "Confirmar Baja",
                                                          ExceptionMessageBoxButtons.YesNo,
                                                          ExceptionMessageBoxSymbol.Question,
                                                          ExceptionMessageBoxDefaultButton.Button2);

            if (DialogResult.Yes == confirmarBaja.Show(this))
                Debug.WriteLine("dar de baja la unidad.");
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
            saiReport1.reportControl.Redraw();
        }

        private void SAIFrmEstadoUnidades_Load(object sender, EventArgs e)
        {
            saiReport1.btnDespacharIncidencias.Visible = false;
            saiReport1.btnLigarIncidencias.Visible = false;
            saiReport1.btnSeparador2.Visible = false;

            saiReport1.AgregarColumna(0, "ID", 20, false, false, false, false);
            saiReport1.AgregarColumna(1, "Folio", 150, true, true, true, false);
            saiReport1.AgregarColumna(2, "Unidad", 100, true, true, true, false);
            saiReport1.AgregarColumna(3, "Nombre", 200, true, true, true, false);
            saiReport1.AgregarColumna(4, "Status", 100, true, true, true, false);
            saiReport1.AgregarColumna(5, "Hora", 100, true, true, true, false);
            saiReport1.AgregarColumna(6, "Localizacion", 250, true, true, true, false);
            saiReport1.AgregarColumna(7, "Motivo", 250, true, true, true, false);
            ObtenerRegistros();
        }

        private void ObtenerRegistros()
        {
            try
            {
                //Limpiamos el listado donde se almacenan las unidades 
                //para iniciar nuevamente el ciclo
                //lstUnidadesTemporales.Clear();
                foreach (var unidad in (UnidadMapper.Instance().GetByCorporacion(Aplicacion.UsuarioPersistencia.intCorporacion ?? -1))) //vamos a la base para obtener las unidades de la corporacion del usuario
                {
                    //lstUnidadesTemporales.Add(unidad);
                    //verificamos que la unidad no esté ya en la lista de unidades registradas
                    //que de no estarlo la agregamos al listado tipado y al grid
                    if (!lstUnidadesRegistradas.Contains(unidad))
                    {
                        lstUnidadesRegistradas.Add(unidad);
                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(null, unidad.Clave,
                            string.Empty,
                            unidad.Codigo,
                            string.Empty,
                            ID.STR_ESTATUSLIBRE,
                            DateTime.Now.ToShortTimeString(),
                            string.Empty,
                            string.Empty));
                    }
                    else
                    {
                        //contamos las columnas y los registros actuales para
                        //delimitar la busqueda del Row
                        var iCols = saiReport1.reportControl.Columns.Count;
                        var iRows = saiReport1.reportControl.Rows.Count;

                        //buscamos el Row por el código de la unidad para obtener su posición dentro del grid
                        var itm = saiReport1.reportControl.Records.FindRecordItem(0, iRows, 0, iCols, 0, 1, unidad.Codigo, XTPReportTextSearchParms.xtpReportTextSearchExactPhrase);
                        if (itm != null && itm.Index >= 0)
                        {
                            var dtHora = new DateTime();
                            var strStatus = string.Empty;

                            //Obtenemos todos los datos de las unidades que estan libres, en despacho o en llegada
                            var unidadDespachoList =
                                DespachoIncidenciaMapper.Instance().GetBySQLQuery(string.Format(
                                                                                      SQL_OBTENERDESPACHOS,
                                                                                      Aplicacion.UsuarioPersistencia
                                                                                          .intCorporacion ?? -1, itm.Record[0].Value));
                            foreach (var unidadDespacho in unidadDespachoList)
                            {
                                saiReport1.reportControl.Records[itm.Record.Index][1].Value = ID.STR_DESCONOCIDO;

                                if (unidadDespacho.HoraLiberada != null)
                                {
                                    dtHora = unidadDespacho.HoraLiberada ?? DateTime.Now;
                                    strStatus = ID.STR_ESTATUSLIBRE;

                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value = ID.STR_DESCONOCIDO;   //por ser libre no tiene folio
                                    saiReport1.reportControl.Records[itm.Record.Index][2].Value = unidad.Codigo;
                                    saiReport1.reportControl.Records[itm.Record.Index][3].Value = ID.STR_DESCONOCIDO;   //falta el campo para colocar el responsable de la unidad
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value = strStatus;
                                    saiReport1.reportControl.Records[itm.Record.Index][4].BackColor = ID.COLOR_VERDE;
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value = dtHora.ToShortTimeString();
                                    saiReport1.reportControl.Records[itm.Record.Index][6].Value = ID.STR_DESCONOCIDO;
                                    saiReport1.reportControl.Records[itm.Record.Index][7].Value = ID.STR_DESCONOCIDO;
                                    continue;
                                }

                                if (unidadDespacho.HoraLlegada != null)
                                {
                                    dtHora = unidadDespacho.HoraLlegada ?? DateTime.Now;
                                    strStatus = ID.STR_ESTATUSLLEGADA;

                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value = unidadDespacho.Folio;
                                    saiReport1.reportControl.Records[itm.Record.Index][4].BackColor = ID.COLOR_VERDE2;
                                    goto Actualizar;
                                }

                                if (unidadDespacho.HoraDespachada != null)
                                {
                                    dtHora = unidadDespacho.HoraDespachada ?? DateTime.Now;
                                    strStatus = ID.STR_ESTATUSLLEGADA;

                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value = unidadDespacho.Folio;
                                    saiReport1.reportControl.Records[itm.Record.Index][4].BackColor =
                                        ID.COLOR_NARANJA;
                                    goto Actualizar;
                                }

                            Actualizar:
                                saiReport1.reportControl.Records[itm.Record.Index][3].Value = ID.STR_DESCONOCIDO;   //falta el campo para colocar el responsable de la unidad
                                saiReport1.reportControl.Records[itm.Record.Index][4].Value = strStatus != string.Empty ? strStatus : ID.STR_DESCONOCIDO;
                                saiReport1.reportControl.Records[itm.Record.Index][5].Value = dtHora.ToShortTimeString();
                                saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                    IncidenciaMapper.Instance().GetOne(unidadDespacho.Folio).Direccion != string.Empty
                                        ? IncidenciaMapper.Instance().GetOne(unidadDespacho.Folio).Direccion
                                        : ID.STR_DESCONOCIDO;
                                saiReport1.reportControl.Records[itm.Record.Index][7].Value =
                                    TipoIncidenciaMapper.Instance().GetOne(
                                        IncidenciaMapper.Instance().GetOne(unidadDespacho.Folio).ClaveTipo ?? -1).
                                        Descripcion ?? ID.STR_DESCONOCIDO;
                            }

                            //TODO: La hora no es la de la liberación 
                            if (unidadDespachoList.Count == 0)
                            {
                                dtHora = DateTime.Now;
                                strStatus = ID.STR_ESTATUSLIBRE;

                                saiReport1.reportControl.Records[itm.Record.Index][1].Value = ID.STR_DESCONOCIDO;   //por ser libre no tiene folio
                                saiReport1.reportControl.Records[itm.Record.Index][2].Value = unidad.Codigo;
                                saiReport1.reportControl.Records[itm.Record.Index][3].Value = ID.STR_DESCONOCIDO;   //falta el campo para colocar el responsable de la unidad
                                saiReport1.reportControl.Records[itm.Record.Index][4].Value = strStatus;
                                saiReport1.reportControl.Records[itm.Record.Index][4].BackColor = ID.COLOR_VERDE;
                                saiReport1.reportControl.Records[itm.Record.Index][5].Value = dtHora.ToShortTimeString();
                                saiReport1.reportControl.Records[itm.Record.Index][6].Value = ID.STR_DESCONOCIDO;
                                saiReport1.reportControl.Records[itm.Record.Index][7].Value = ID.STR_DESCONOCIDO;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tmrRegistros.Enabled = false;
                throw new SAIExcepcion(ex.Message, this);
            }
        }

        public const string SQL_OBTENERDESPACHOS = "SELECT DespachoIncidencia.* FROM DespachoIncidencia WHERE (HoraLiberada IS NULL OR HoraLlegada IS NULL OR HoraDespachada IS NULL) AND (ClaveCorporacion={0}) AND (ClaveUnidad={1})";
    }
}
