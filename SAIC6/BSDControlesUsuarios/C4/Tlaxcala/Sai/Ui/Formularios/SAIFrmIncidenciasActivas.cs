using System;
using System.Collections.Generic;
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
        /// Identificador del módulo en el sistema
        /// </summary>
        public static int intSubModulo
        {
            get
            {
                return ID.PNT_IA;
            }
        }

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
            lstIncidenciasRegistradas = new List<Incidencia>();
            lstIncidenciasTemporales = new List<Incidencia>();
            lstIncidenciasPorRemover = new List<Incidencia>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
        }

        void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            //Establecer permisos para los elementos de interacción con el usuario
            saiReport1.btnLigarIncidencias.Enabled = Aplicacion.UsuarioPersistencia.blnPuedeEscribir(intSubModulo);

            //Definir las columnas del listado y obtener los registros
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

        /// <summary>
        /// Timer que actualizará los registros de manera periodica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
            saiReport1.reportControl.Refresh();
        }

        private void ObtenerRegistros()
        {
            try
            {
                //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea activo
                //para iniciar nuevamente el ciclo
                lstIncidenciasTemporales.Clear();
                foreach (var incidencia in (IncidenciaMapper.Instance().GetByEstatusIncidencia((int)ESTATUSINCIDENCIAS.ACTIVA))) //vamos a la base para obtener los registros de estado activo
                {
                    lstIncidenciasTemporales.Add(incidencia);
                    //verificamos que la incidencia no esté ya en la lista de incidencias registradas
                    //que de no estarlo la agregamos al listado tipado y al grid
                    if (!lstIncidenciasRegistradas.Contains(incidencia))
                    {
                        lstIncidenciasRegistradas.Add(incidencia);
                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(incidencia.Folio,
                                                                       incidencia.Telefono,
                                                                       EstatusIncidenciaMapper.Instance().GetOne(incidencia.ClaveEstatus).Descripcion,
                                                                       incidencia.HoraRecepcion.ToString(),
                                                                       incidencia.Direccion,
                                                                       TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion,
                                                                       "",
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
                                        incidencia.HoraRecepcion.ToString();

                                if (!incidenciaTemp.Direccion.Equals(incidencia.Direccion))
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value = incidencia.Direccion;

                                if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion;
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
                throw new SAIExcepcion(ex.Message);
            }
        }
    }
}
