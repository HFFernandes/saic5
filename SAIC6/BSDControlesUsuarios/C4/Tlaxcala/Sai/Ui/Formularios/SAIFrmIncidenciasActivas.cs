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

            //obtenemos el tama�o del �rea de trabajo principal
            Width = Screen.GetWorkingArea(this).Width;
            //creamos los eventos de respuesta
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnVistaPrevia.Click += btnVistaPrevia_Click;
            saiReport1.reportControl.RowDblClick += reportControl_RowDblClick;

            //generamos un listado tipado para la manipulaci�n de registros
            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporales = new List<Incidencia>();
            lstIncidenciasPorRemover = new List<Incidencia>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        /// <summary>
        /// Genera una vista previa de impresi�n de los registros enlistados
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                //verificamos los permisos de lectura o escritura para este m�dulo
                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_A))
                {
                    //Iniciamos la vista previa de impresi�n de los registros enlistados
                    saiReport1.reportControl.PrintPreviewOptions.Title = "Reporte de Incidencias Activas";
                    saiReport1.reportControl.PrintPreview(true);
                }
                else
                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS); //indicamos que no tiene los privilegios
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// evento para instanciar una entidad de tipo Incidencia y pasarla al form correspondiente
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private void reportControl_RowDblClick(object sender,
                                               AxXtremeReportControl._DReportControlEvents_RowDblClickEvent e)
        {
            try
            {
                //Verificamos el perfil del usuario actual para mostrar lo correspondiente
                if (Aplicacion.UsuarioPersistencia.blnEsDespachador ?? false)
                {
                    //Recuperamos el folio del registro seleccionado y comprobamos que exista
                    //para que pueda ser despachado
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
                        var incidenciaInfo = new SAIFrmAltaIncidencia066(incidencia, false);
                        incidenciaInfo.Show();
                    }
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// m�todo para instanciar las entidades de tipo incidencia que fueron seleccionadas desde el listado
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private void btnDespacharIncidencias_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificamos el perfil del usuario actual para mostrar lo correspondiente
                if (Aplicacion.UsuarioPersistencia.blnEsDespachador ?? false)
                {
                    //Por cada ciclo recuperar el folio y generar una instancia de la entidad para
                    //pasarla al nuevo formulario
                    for (var i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
                    {
                        var incidencia =
                            IncidenciaMapper.Instance().GetOne(
                                Convert.ToInt32(saiReport1.reportControl.SelectedRows[i].Record[0].Value));
                        if (incidencia == null) continue;
                        var incidenciaDespacho = new SAIFrmDespacho(incidencia);
                        incidenciaDespacho.Show();
                    }
                }
                else
                {
                    for (var i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
                    {
                        var incidencia =
                            IncidenciaMapper.Instance().GetOne(
                                Convert.ToInt32(saiReport1.reportControl.SelectedRows[i].Record[0].Value));
                        if (incidencia == null) continue;
                        var incidenciaInfo = new SAIFrmAltaIncidencia066(incidencia, false);
                        incidenciaInfo.Show();
                    }
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// m�todo para relacionar una o mas entidades de tipo incidencia a un padre
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            //Verificamos los permisos de lectura o escritura del usuario actual al m�dulo correspondiente
            if (Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_A))
            {
                try
                {
                    try
                    {
                        //generamos un listado tipado donde ser�n almacenados los folios por ligar
                        var lstIncidenciasPorLigar = new List<string>();
                        for (var i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
                        {
                            lstIncidenciasPorLigar.Add(
                                saiReport1.reportControl.SelectedRows[i].Record[0].Value.ToString());
                        }

                        //eliminamos de la colecci�n aquellos registros duplicados
                        var lstLigarResultado = Aplicacion.removerDuplicados(lstIncidenciasPorLigar);
                        //pasamos la colecci�n como parametro al constructor de la nueva instancia del form LigarIncidencias
                        var ligarIncidencias = new SAIFrmLigarIncidencias(lstLigarResultado);
                        var dialogResult = ligarIncidencias.ShowDialog(this);
                        if (dialogResult == DialogResult.OK)
                        {
                            //Obtenemos el folio que fue definido como Padre dentro de la colecci�n pasada
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
                                                  stbFolios.ToString().Trim().Remove(
                                                      stbFolios.ToString().Trim().Length - 1)));
                            foreach (var incidencia in listadoIncidencias)
                            {
                                if (incidencia.FolioPadre == null)
                                    incidencia.FolioPadre = Convert.ToInt32(folioPadre);
                            }
                            if (listadoIncidencias.Count > 0)
                            {
                                IncidenciaMapper.Instance().Update(listadoIncidencias);
                            }

                            //Ejecutmos el procedimiento almacenado para el ligue de incidencias
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

        /// <summary>
        /// evento que al cargar el formulario configura la UI y obtiene los registros
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            //Ocultamos comandos de acci�n que no son necesarios para incidencias activas
            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;
            saiReport1.btnDespacharIncidencias.Visible = false;

            //Definimos las columnas del listado y obtenemos los registros
            saiReport1.AgregarColumna(0, "ID", 20, false, false);
            saiReport1.AgregarColumna(1, "No de Tel�fono", 100, true, true, true);
            saiReport1.AgregarColumna(2, "Status", 100, true, false, false);
            saiReport1.AgregarColumna(3, "Hora de Entrada", 100, true, true, true);
            saiReport1.AgregarColumna(4, "Ubicaci�n", 250, true, true, true, false, true, 2);
            saiReport1.AgregarColumna(5, "Tipo de Incidencia", 250, true, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 70, true, true, true);
            saiReport1.AgregarColumna(7, "Folio", 150, true, true, true);
            saiReport1.AgregarColumna(8, "Prioridad", 20, true, true, true);
            ObtenerRegistros();
        }

        /// <summary>
        /// evento que actualizar� los registros de manera periodica
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
            saiReport1.reportControl.Redraw();
            //saiReport1.reportControl.Populate();

            saiReport1.btnLigarIncidencias.Enabled = saiReport1.reportControl.SelectedRows.Count > 1;
        }

        /// <summary>
        /// evento principal para la obtenci�n de registros de entidad incidencia y de estado activo
        /// </summary>
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
                    resIncidencias = Aplicacion.UsuarioPersistencia.blnEsDespachador == true
                                         ? IncidenciaMapper.Instance().GetBySQLQuery(
                                               string.Format(ID.SQL_INCIDENCIASCORPORACION,
                                                             Aplicacion.UsuarioPersistencia.
                                                                 intCorporacion,
                                                             (int) ESTATUSINCIDENCIAS.ACTIVA))
                                         : IncidenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_INCIDENCIAS,
                                                                                                   (int)
                                                                                                   ESTATUSINCIDENCIAS.
                                                                                                       ACTIVA));


                    foreach (var incidencia in resIncidencias)
                        //vamos a la base para obtener los registros de estado activo
                    {
                        lstIncidenciasTemporales.Add(incidencia);
                        //verificamos que la incidencia no est� ya en la lista de incidencias registradas
                        //que de no estarlo la agregamos al listado tipado y al grid
                        if (!lstIncidenciasRegistradas.Contains(incidencia))
                        {
                            lstIncidenciasRegistradas.Add(incidencia);
                            var corporaciones = new StringBuilder();

                            CorporacionMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_CORPORACIONES,
                                                                                     incidencia.Folio)).ForEach(
                                delegate(Corporacion c)
                                    {
                                        corporaciones.Append(c.Descripcion);
                                        corporaciones.Append(",");
                                    });

                            lstRegistrosReporte.Add(saiReport1.AgregarRegistro(null, incidencia.Folio,
                                                                               incidencia.Telefono,
                                                                               EstatusIncidenciaMapper.Instance().GetOne
                                                                                   (incidencia.ClaveEstatus).Descripcion,
                                                                               incidencia.HoraRecepcion.
                                                                                   ToShortTimeString(),
                                                                               incidencia.Direccion,
                                                                               incidencia.ClaveTipo != null
                                                                                   ? TipoIncidenciaMapper.Instance().
                                                                                         GetOne(
                                                                                         incidencia.ClaveTipo.Value).
                                                                                         Descripcion
                                                                                   : ID.STR_DESCONOCIDO,
                                                                               corporaciones.ToString().Trim().Length >
                                                                               1
                                                                                   ? corporaciones.ToString().Trim().
                                                                                         Remove(corporaciones.Length - 1)
                                                                                   : string.Empty,
                                                                               incidencia.Folio.ToString(),
                                                                               incidencia.ClaveTipo != null
                                                                                   ? TipoIncidenciaMapper.Instance().
                                                                                         GetOne(
                                                                                         incidencia.ClaveTipo.Value).
                                                                                         Prioridad.ToString()
                                                                                   : ID.STR_DESCONOCIDO));
                        }
                        else
                        {
                            //la incidencia ya existe en la colecci�n,ahora la
                            //buscamos y verificamos si alg�n registro cambio para su actualizacion
                            var incidenciaTemp = lstIncidenciasRegistradas.Find(inc => inc.Folio == incidencia.Folio);
                            if (incidenciaTemp != null)
                            {
                                //contamos las columnas y los registros actuales para
                                //delimitar la busqueda del Row
                                var iCols = saiReport1.reportControl.Columns.Count;
                                var iRows = saiReport1.reportControl.Rows.Count;

                                //buscamos el Row por el n�mero �nico de folio para obtener su posici�n dentro del grid
                                var itm = saiReport1.reportControl.Records.FindRecordItem(1, iRows, 1, iCols, 1, 1,
                                                                                          incidencia.Folio.ToString(),
                                                                                          XTPReportTextSearchParms.
                                                                                              xtpReportTextSearchExactPhrase);
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
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                        incidencia.ClaveTipo != null
                                            ?
                                                TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).
                                                    Descripcion
                                            : ID.STR_DESCONOCIDO;

                                    var corporaciones = new StringBuilder();
                                    CorporacionMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_CORPORACIONES,
                                                                                             incidencia.Folio)).ForEach(
                                        delegate(Corporacion c)
                                            {
                                                corporaciones.Append(c.Descripcion);
                                                corporaciones.Append(",");
                                            });

                                    saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                        corporaciones.ToString().Trim().Length > 1
                                            ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1)
                                            : ID.STR_DESCONOCIDO;

                                    //if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][8].Value =
                                        incidencia.ClaveTipo != null
                                            ? TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).
                                                  Prioridad.ToString()
                                            : ID.STR_DESCONOCIDO;
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

                    //recorremos la colecci�n de incidencias por remover
                    //y hacemos match contra el n�mero �nico de folio para proceder
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
                    lstIncidenciasPorRemover.Clear(); //limpiamos la colecci�n para el nuevo ciclo

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