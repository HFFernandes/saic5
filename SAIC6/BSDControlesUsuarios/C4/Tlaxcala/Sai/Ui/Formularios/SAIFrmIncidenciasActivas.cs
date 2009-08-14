using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //Recuperar el folio y generar una instancia de la entidad para
            //pasarla al nuevo formulario
            var incidencia = IncidenciaMapper.Instance().GetOne(Convert.ToInt32(e.row.Record[0].Value));
            if (incidencia != null)
            {
                //TODO: Definir las acciones
            }
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
            var lstIncidenciasPorLigar = new List<int>();
            for (int i = 0; i < saiReport1.reportControl.SelectedRows.Count; i++)
            {
                lstIncidenciasPorLigar.Add(Convert.ToInt32(saiReport1.reportControl.SelectedRows[i].Record[0].Value));
            }
            
            //Mostrar ventana para la seleccion del padre
            var ligarIncidencias = new SAIFrmLigarIncidencias(lstIncidenciasPorLigar);
            var dialogResult = ligarIncidencias.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                Debug.WriteLine(ligarIncidencias.strFolioPadre);
            }
        }

        void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.btnDespacharIncidencias.Visible = false;
            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;

            //Establecer permisos para los elementos de interacción con el usuario
            //saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            //Definir las columnas del listado y obtener los registros
            //falta mostrar la unidad asignada
            saiReport1.AgregarColumna(0, "ID", 20, false, false, false, false);
            saiReport1.AgregarColumna(1, "No de Teléfono", 100, true, true, true, false);
            saiReport1.AgregarColumna(2, "Status", 100, true, true, true, false);  //Indica si esta "libre", "despchada" o "llegada"
            saiReport1.AgregarColumna(3, "Hora de Entrada", 100, true, true, true, false);
            saiReport1.AgregarColumna(4, "Ubicación", 250, true, true, true, false, true, 2);
            saiReport1.AgregarColumna(5, "Tipo de Incidencia", 250, true, true, true, false);
            saiReport1.AgregarColumna(6, "Dividido En", 70, true, true, true, false);
            saiReport1.AgregarColumna(7, "Folio", 150, true, true, true, false);
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

            saiReport1.btnLigarIncidencias.Enabled = saiReport1.reportControl.SelectedRows.Count > 1;
            saiReport1.btnDespacharIncidencias.Enabled = saiReport1.reportControl.SelectedRows.Count >= 1;
        }

        private void ObtenerRegistros()
        {
            IncidenciaList resIncidencias;

            try
            {
                //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea activo
                //para iniciar nuevamente el ciclo
                lstIncidenciasTemporales.Clear();
                if (Aplicacion.UsuarioPersistencia.blnEsDespachador == true)
                {
                    resIncidencias = IncidenciaMapper.Instance().GetBySQLQuery(string.Format(SQL_INCIDENCIASCORPORACION,
                                                                                Aplicacion.UsuarioPersistencia.
                                                                                    intCorporacion,
                                                                                (int)ESTATUSINCIDENCIAS.ACTIVA));
                }
                else
                {
                    resIncidencias =
                        IncidenciaMapper.Instance().GetBySQLQuery(string.Format(SQL_INCIDENCIAS,
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

                        CorporacionMapper.Instance().GetBySQLQuery(string.Format(SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                        {
                            corporaciones.Append(c.Descripcion);
                            corporaciones.Append(",");
                        });

                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(null, incidencia.Folio,
                                                                       incidencia.Telefono,
                                                                       EstatusIncidenciaMapper.Instance().GetOne(incidencia.ClaveEstatus).Descripcion,
                                                                       incidencia.HoraRecepcion.ToShortTimeString(),
                                                                       incidencia.Direccion,
                                                                       TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion,
                                                                       corporaciones.ToString().Trim().Length > 1 ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1) : string.Empty,
                                                                       incidencia.Folio.ToString()));
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
                                if (!incidenciaTemp.Telefono.Equals(incidencia.Telefono))
                                    saiReport1.reportControl.Records[itm.Record.Index][1].Value = incidencia.Telefono;

                                if (!incidenciaTemp.ClaveEstatus.Equals(incidencia.ClaveEstatus))
                                    saiReport1.reportControl.Records[itm.Record.Index][2].Value =
                                        EstatusIncidenciaMapper.Instance().GetOne(incidencia.ClaveEstatus).Descripcion;

                                if (!incidenciaTemp.HoraRecepcion.Equals(incidencia.HoraRecepcion))
                                    saiReport1.reportControl.Records[itm.Record.Index][3].Value =
                                        incidencia.HoraRecepcion.ToShortTimeString();

                                if (!incidenciaTemp.Direccion.Equals(incidencia.Direccion))
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value = incidencia.Direccion;

                                if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion;

                                var corporaciones = new StringBuilder();
                                CorporacionMapper.Instance().GetBySQLQuery(string.Format(SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                                {
                                    corporaciones.Append(c.Descripcion);
                                    corporaciones.Append(",");
                                });

                                saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                    corporaciones.ToString().Trim().Length > 1
                                        ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1)
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

        private const string SQL_CORPORACIONES =
            "SELECT Corporacion.* FROM Corporacion INNER JOIN CorporacionIncidencia ON Corporacion.Clave = CorporacionIncidencia.ClaveCorporacion INNER JOIN Incidencia ON CorporacionIncidencia.Folio = Incidencia.Folio WHERE (Incidencia.Folio = {0})";

        private const string SQL_INCIDENCIASCORPORACION =
            "SELECT Incidencia.* FROM Incidencia INNER JOIN CorporacionIncidencia ON Incidencia.Folio = CorporacionIncidencia.Folio WHERE (CorporacionIncidencia.ClaveCorporacion = {0}) AND (Incidencia.ClaveEstatus = {1})";

        private const string SQL_INCIDENCIAS =
            "SELECT Incidencia.* FROM Incidencia WHERE (Incidencia.ClaveEstatus = {0})";
    }
}
