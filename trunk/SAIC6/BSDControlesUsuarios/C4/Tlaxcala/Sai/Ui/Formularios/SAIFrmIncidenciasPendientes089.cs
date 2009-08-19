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
    public partial class SAIFrmIncidenciasPendientes089 : SAIFrmBase
    {
        private List<Incidencia> lstIncidenciasRegistradas;
        private List<Incidencia> lstIncidenciasTemporales;
        private List<Incidencia> lstIncidenciasPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        public SAIFrmIncidenciasPendientes089()
        {
            InitializeComponent();
            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnBajaUnidad.Click += btnBajaUnidad_Click;
            saiReport1.btnAltaUnidad.Click += btnAltaUnidad_Click;
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
                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_P))
                {
                    saiReport1.reportControl.PrintPreviewOptions.Title = "Reporte de Incidencias 089";
                    saiReport1.reportControl.PrintPreview(true);
                }
                else
                    throw new SAIExcepcion("No tiene los permisos suficientes para realizar esta acción.");
            }
            catch (SAIExcepcion)
            {
            }
        }

        void reportControl_RowDblClick(object sender, AxXtremeReportControl._DReportControlEvents_RowDblClickEvent e)
        {
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_NI))
                {
                    //Recuperar el folio y generar una instancia de la entidad para
                    //pasarla al nuevo formulario
                    var incidencia = IncidenciaMapper.Instance().GetOne(Convert.ToInt32(e.row.Record[0].Value));
                    if (incidencia != null)
                    {
                        var incidenciaInfo = new SAIFrmIncidencia089(incidencia);
                        incidenciaInfo.Show();
                    }
                }
                else
                    throw new SAIExcepcion("No tiene los permisos suficientes para realizar esta acción.");
            }
            catch (SAIExcepcion)
            {
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
        }

        private void SAIFrmIncidenciasPendientes089_Load(object sender, EventArgs e)
        {
            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;
            saiReport1.btnDespacharIncidencias.Visible = false;

            //Falta mostrar la prioridad del incidente
            saiReport1.AgregarColumna(0, "ID", 20, false, false, false, false);
            saiReport1.AgregarColumna(1, "Folio", 150, true, true, true, true);
            saiReport1.AgregarColumna(2, "Hora de Entrada", 100, true, true, true, false);
            saiReport1.AgregarColumna(3, "Tipo de Incidencia", 200, true, true, true, false);
            saiReport1.AgregarColumna(4, "Descripción", 200, true, true, true, false);
            saiReport1.AgregarColumna(5, "Localización", 200, true, false, true, false);
            saiReport1.AgregarColumna(6, "Dependencias", 100, true, true, true, false);
            saiReport1.AgregarColumna(7, "Número de Oficio", 100, true, true, true, false);
            saiReport1.AgregarColumna(8, "Nombre del Operador", 90, true, true, true, false);
            saiReport1.AgregarColumna(9, "Ligado a", 90, true, true, true, false);
            ObtenerRegistros();
        }

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
            ObtenerRegistros();
            saiReport1.reportControl.Redraw();

            saiReport1.btnLigarIncidencias.Enabled = saiReport1.reportControl.SelectedRows.Count > 1;
        }

        private void ObtenerRegistros()
        {
            try
            {
                //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea pendiente
                //para iniciar nuevamente el ciclo
                lstIncidenciasTemporales.Clear();
                foreach (var incidencia in (IncidenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_INCIDENCIAS089,
                                                                                (int)ESTATUSINCIDENCIAS.PENDIENTE, Aplicacion.UsuarioPersistencia.ObtenerClaveSistema())))) //vamos a la base para obtener los registros de estado pendiente y de la corporación del usuario
                {
                    lstIncidenciasTemporales.Add(incidencia);
                    //verificamos que la incidencia no esté ya en la lista de incidencias registradas
                    //que de no estarlo la agregamos al listado tipado y al grid
                    if (!lstIncidenciasRegistradas.Contains(incidencia))
                    {
                        lstIncidenciasRegistradas.Add(incidencia);
                        var dependencias = new StringBuilder();
                        DependenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_DEPENDENCIAS089, incidencia.Folio)).ForEach(delegate(Dependencia d)
                                                                                                                                       {
                                                                                                                                           if (d.Descripcion != string.Empty)
                                                                                                                                           {
                                                                                                                                               dependencias.Append(d.Descripcion);
                                                                                                                                               dependencias.Append(",");
                                                                                                                                           }
                                                                                                                                       });

                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(null, incidencia.Folio,
                                                                       incidencia.Folio.ToString(),
                                                                       incidencia.HoraRecepcion.ToShortTimeString(),
                                                                       TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? -1).Descripcion,
                                                                       incidencia.Descripcion,
                                                                       incidencia.Direccion,
                                                                       dependencias.ToString().Trim().Length > 1 ? dependencias.ToString().Trim().Remove(dependencias.Length - 1) : string.Empty,
                                                                       incidencia.NumeroOficio,
                                                                       UsuarioMapper.Instance().GetOne(incidencia.ClaveUsuario).NombreUsuario,
                                                                       incidencia.FolioPadre.ToString()));
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

                                if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][3].Value =
                                        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? -1).Descripcion;

                                if (!incidenciaTemp.Descripcion.Equals(incidencia.Descripcion))
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value = incidencia.Descripcion != string.Empty
                                            ? incidencia.Descripcion
                                            : ID.STR_DESCONOCIDO;

                                if (!incidenciaTemp.Direccion.Equals(incidencia.Direccion))
                                    saiReport1.reportControl.Records[itm.Record.Index][5].Value = incidencia.Direccion != string.Empty
                                            ? incidencia.Direccion
                                            : ID.STR_DESCONOCIDO;

                                var dependencias = new StringBuilder();
                                DependenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_DEPENDENCIAS089, incidencia.Folio)).ForEach(delegate(Dependencia d)
                                {
                                    if (d.Descripcion != string.Empty)
                                    {
                                        dependencias.Append(d.Descripcion);
                                        dependencias.Append(",");
                                    }
                                });
                                saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                    dependencias.ToString().Trim().Length > 1
                                        ? dependencias.ToString().Trim().Remove(dependencias.Length - 1)
                                        : ID.STR_DESCONOCIDO;

                                if (!incidenciaTemp.NumeroOficio.Equals(incidencia.NumeroOficio))
                                    saiReport1.reportControl.Records[itm.Record.Index][7].Value =
                                        incidencia.NumeroOficio != string.Empty
                                            ? incidencia.NumeroOficio
                                            : ID.STR_DESCONOCIDO;

                                saiReport1.reportControl.Records[itm.Record.Index][9].Value =
                                    incidencia.FolioPadre.ToString() != string.Empty
                                        ? incidencia.Folio.ToString()
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
                base.Close();
            }
        }
    }
}
