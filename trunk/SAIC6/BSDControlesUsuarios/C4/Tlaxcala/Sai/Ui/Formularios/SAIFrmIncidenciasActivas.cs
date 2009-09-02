using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using XtremeReportControl;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// Formulario para enlistar todas las incidencias activas.
    /// El form debe comportarse de tal manera que el grid no vuelva a cargar los registros
    /// cada vez, sino unicamente los que fueron eliminados,agregados o cambiados 
    /// </summary>
    public partial class SAIFrmIncidenciasActivas : SAIFrmBase
    {

        /// <summary>
        /// listado tipado de incidencias para manipular cuando han cambiado de estado
        /// </summary>
        private List<Incidencia> lstIncidenciasRegistradas;
        private List<Incidencia> lstIncidenciasTemporales;
        private List<Incidencia> lstIncidenciasPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        /// <summary>
        /// Constructor
        /// </summary>
        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnVistaPrevia.Click += btnVistaPrevia_Click;
            saiReport1.reportControl.RowDblClick += reportControl_RowDblClick;

            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporales = new List<Incidencia>();
            lstIncidenciasPorRemover = new List<Incidencia>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_A))
                {
                    saiReport1.reportControl.PrintPreviewOptions.Title = "Reporte de Incidencias Activas";
                    saiReport1.reportControl.PrintPreview(true);
                }
                else
                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
            }
            catch (SAIExcepcion)
            {
            }
        }

        void reportControl_RowDblClick(object sender, AxXtremeReportControl._DReportControlEvents_RowDblClickEvent e)
        {
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnEsDespachador ?? false)
                {
                    //Recuperar el folio y generar una instancia de la entidad para
                    //pasarla al nuevo formulario
                    var incidencia = IncidenciaMapper.Instance().GetOne(Convert.ToInt32(e.row.Record[0].Value));
                    if (incidencia != null)
                    {
                        var incidenciaDespacho = new SAIFrmDespacho(incidencia);
                        incidenciaDespacho.Show();
                    }
                }
                else
                {
                    var incidencia = IncidenciaMapper.Instance().GetOne(Convert.ToInt32(e.row.Record[0].Value));
                    if (incidencia != null)
                    {
                        //var incidenciaInfo = new SAIFrmAltaIncidencia066(incidencia);
                        //incidenciaInfo.Show();
                    }
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        void btnDespacharIncidencias_Click(object sender, EventArgs e)
        {
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnEsDespachador ?? false)
                {
                    //Recuperar el folio y generar una instancia de la entidad para
                    //pasarla al nuevo formulario
                    for (int i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
                    {
                        var incidencia =
                            IncidenciaMapper.Instance().GetOne(
                                Convert.ToInt32(saiReport1.reportControl.SelectedRows[i].Record[0].Value));
                        if (incidencia != null)
                        {
                            var incidenciaDespacho = new SAIFrmDespacho(incidencia);
                            incidenciaDespacho.Show();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
                    {
                        var incidencia =
                            IncidenciaMapper.Instance().GetOne(
                                Convert.ToInt32(saiReport1.reportControl.SelectedRows[i].Record[0].Value));
                        if (incidencia != null)
                        {
                            //var incidenciaInfo = new SAIFrmIncidencia066(incidencia);
                            //incidenciaInfo.Show();
                        }
                    }
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            if (Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_A))
            {
                try
                {
                    try
                    {
                        var lstIncidenciasPorLigar = new List<string>();
                        for (int i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
                        {
                            lstIncidenciasPorLigar.Add(saiReport1.reportControl.SelectedRows[i].Record[0].Value.ToString());
                        }

                        var lstLigarResultado = Aplicacion.removerDuplicados(lstIncidenciasPorLigar);
                        var ligarIncidencias = new SAIFrmLigarIncidencias(lstLigarResultado);
                        var dialogResult = ligarIncidencias.ShowDialog(this);
                        if (dialogResult == DialogResult.OK)
                        {
                            var folioPadre = ligarIncidencias.strFolioPadre;
                            lstLigarResultado.Remove(folioPadre);

                            var stbFolios = new StringBuilder();
                            foreach (var s in lstLigarResultado)
                            {
                                stbFolios.Append(s);
                                stbFolios.Append(",");
                            }

                            //recorro los nodos hijos para asignarles el padre
                            var listadoIncidencias =
                                IncidenciaMapper.Instance().GetBySQLQuery(
                                    string.Format(ID.SQL_INCIDENCIASLIGADAS,
                                                  stbFolios.ToString().Trim().Remove(stbFolios.ToString().Trim().Length - 1)));
                            foreach (var incidencia in listadoIncidencias)
                            {
                                if (incidencia.FolioPadre == null)
                                    incidencia.FolioPadre = Convert.ToInt32(folioPadre);
                            }
                            if (listadoIncidencias.Count > 0)
                            {
                                IncidenciaMapper.Instance().Update(listadoIncidencias);
                            }

                            //Ejecutar el stored procedure
                            IncidenciaMapper.Instance().LigaIncidencia(Convert.ToInt32(folioPadre), "066");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new SAIExcepcion(ex.Message);
                    }
                }
                catch (SAIExcepcion)
                {
                }
            }
        }

        void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;
            saiReport1.btnDespacharIncidencias.Visible = false;

            //Definir las columnas del listado y obtener los registros
            saiReport1.AgregarColumna(0, "ID", 20, false, false);
            saiReport1.AgregarColumna(1, "No de Teléfono", 100, true, true, true);
            saiReport1.AgregarColumna(2, "Status", 100, true, false, false);
            saiReport1.AgregarColumna(3, "Hora de Entrada", 100, true, true, true);
            saiReport1.AgregarColumna(4, "Ubicación", 250, true, true, true, false, true, 2);
            saiReport1.AgregarColumna(5, "Tipo de Incidencia", 250, true, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 70, true, true, true);
            saiReport1.AgregarColumna(7, "Folio", 150, true, true, true);
            saiReport1.AgregarColumna(8, "Prioridad", 20, true, true, true);
            ObtenerRegistros();
        }

        /// <summary>
        /// Timer que actualizará los registros de manera periodica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
            saiReport1.reportControl.Redraw();
            //saiReport1.reportControl.Populate();

            saiReport1.btnLigarIncidencias.Enabled = saiReport1.reportControl.SelectedRows.Count > 1;
        }

        private void ObtenerRegistros()
        {
            IncidenciaList resIncidencias;

            try
            {
                try
                {
                    //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea activo
                    //para iniciar nuevamente el ciclo
                    lstIncidenciasTemporales.Clear();
                    if (Aplicacion.UsuarioPersistencia.blnEsDespachador == true)
                    {
                        resIncidencias = IncidenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_INCIDENCIASCORPORACION,
                                                                                    Aplicacion.UsuarioPersistencia.
                                                                                        intCorporacion,
                                                                                    (int)ESTATUSINCIDENCIAS.ACTIVA));
                    }
                    else
                    {
                        resIncidencias =
                            IncidenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_INCIDENCIAS,
                                                                                    (int)ESTATUSINCIDENCIAS.ACTIVA));
                    }

                    foreach (var incidencia in resIncidencias) //vamos a la base para obtener los registros de estado activo
                    {
                        lstIncidenciasTemporales.Add(incidencia);
                        //verificamos que la incidencia no esté ya en la lista de incidencias registradas
                        //que de no estarlo la agregamos al listado tipado y al grid
                        if (!lstIncidenciasRegistradas.Contains(incidencia))
                        {
                            lstIncidenciasRegistradas.Add(incidencia);
                            var corporaciones = new StringBuilder();

                            CorporacionMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                            {
                                corporaciones.Append(c.Descripcion);
                                corporaciones.Append(",");
                            });

                            lstRegistrosReporte.Add(saiReport1.AgregarRegistro(null, incidencia.Folio,
                                                                           incidencia.Telefono,
                                                                           EstatusIncidenciaMapper.Instance().GetOne(incidencia.ClaveEstatus).Descripcion,
                                                                           incidencia.HoraRecepcion.ToShortTimeString(),
                                                                           incidencia.Direccion,
                                                                           incidencia.ClaveTipo != null ? TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).Descripcion : ID.STR_DESCONOCIDO,
                                                                           corporaciones.ToString().Trim().Length > 1 ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1) : string.Empty,
                                                                           incidencia.Folio.ToString(),
                                                                           incidencia.ClaveTipo != null ? TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).Prioridad.ToString() : ID.STR_DESCONOCIDO));
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
                                    //if (!incidenciaTemp.Telefono.Equals(incidencia.Telefono))
                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value = incidencia.Telefono;

                                    //if (!incidenciaTemp.ClaveEstatus.Equals(incidencia.ClaveEstatus))
                                    saiReport1.reportControl.Records[itm.Record.Index][2].Value =
                                        EstatusIncidenciaMapper.Instance().GetOne(incidencia.ClaveEstatus).Descripcion;

                                    //if (!incidenciaTemp.HoraRecepcion.Equals(incidencia.HoraRecepcion))
                                    saiReport1.reportControl.Records[itm.Record.Index][3].Value =
                                        incidencia.HoraRecepcion.ToShortTimeString();

                                    //if (!incidenciaTemp.Direccion.Equals(incidencia.Direccion))
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value = incidencia.Direccion;

                                    //if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value = incidencia.ClaveTipo != null ?
                                        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).Descripcion : ID.STR_DESCONOCIDO;

                                    var corporaciones = new StringBuilder();
                                    CorporacionMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                                    {
                                        corporaciones.Append(c.Descripcion);
                                        corporaciones.Append(",");
                                    });

                                    saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                        corporaciones.ToString().Trim().Length > 1
                                            ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1)
                                            : ID.STR_DESCONOCIDO;

                                    //if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][8].Value = incidencia.ClaveTipo != null ? TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).Prioridad.ToString() : ID.STR_DESCONOCIDO;
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

                    //ordenamiento
                    //if (SAIChkOrdenarPrioridad.Checked)
                    //    saiReport1.reportControl.SortOrder.Add(saiReport1.reportControl.Columns[8]);
                }
                catch (Exception)
                {
                    tmrRegistros.Enabled = false;
                    throw new SAIExcepcion(ID.STR_ERROROBTENERREGISTROS);
                }
            }
            catch (SAIExcepcion)
            {
                Close();
            }
        }
    }
}
