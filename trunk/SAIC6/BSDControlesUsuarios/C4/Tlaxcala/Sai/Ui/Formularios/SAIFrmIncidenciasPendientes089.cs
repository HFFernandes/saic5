﻿using System;
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
            //TODO: implementar si el usuario es operador debe poder abrir la incidencia para agregar más datos
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_P))
                {
                    //Recuperar el folio y generar una instancia de la entidad para
                    //pasarla al nuevo formulario
                    var incidencia = IncidenciaMapper.Instance().GetOne(Convert.ToInt32(e.row.Record[0].Value));
                    if (incidencia != null)
                    {
                        var incidenciaInfo = new SAIFrmIncidencia089();
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
            //TODO: implementar si el usuario es operador debe poder abrir la incidencia para agregar más datos
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_P))
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
                            var incidenciaInfo = new SAIFrmIncidencia089();
                            incidenciaInfo.Show();
                        }
                    }
                }
                else
                    throw new SAIExcepcion("No tiene los permisos suficientes para realizar esta acción.");
            }
            catch (SAIExcepcion)
            {
            }
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            //Actualizar el foliopadre, pero antes verificar que no este ligada
            //organizar los nodos para desplegar el tree
            //y verificar que al momento del despacho si es hijo se pase la incidencia
            //del padre..para prevenir el despacho a una misma incidencia

            if (Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_P))
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

        private void SAIFrmIncidenciasPendientes089_Load(object sender, EventArgs e)
        {
            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;
            saiReport1.btnDespacharIncidencias.Visible = Aplicacion.UsuarioPersistencia.blnEsDespachador ?? false;

            //Falta mostrar la prioridad del incidente
            saiReport1.AgregarColumna(0, "ID", 20, false, false, false, false);
            saiReport1.AgregarColumna(1, "Folio", 150, true, true, true, true);
            saiReport1.AgregarColumna(2, "Hora de Entrada", 100, true, true, true, false);
            saiReport1.AgregarColumna(3, "Corporación", 150, true, true, true, false);
            saiReport1.AgregarColumna(4, "Tipo de Incidencia", 250, true, true, true, false);
            saiReport1.AgregarColumna(5, "Zn", 70, true, true, true, false);
            saiReport1.AgregarColumna(6, "Dividido En", 70, true, false, true, false);
            saiReport1.AgregarColumna(7, "Pendiente Desde", 200, true, true, true, false);
            saiReport1.AgregarColumna(8, "Nombre del Operador", 90, true, true, true, false);
            saiReport1.AgregarColumna(9, "Ligado a", 90, true, true, true, false);
            ObtenerRegistros();
        }

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
                //Limpiamos el listado donde se almacenan las incidencias cuyo estado sea pendiente
                //para iniciar nuevamente el ciclo
                lstIncidenciasTemporales.Clear();
                if (Aplicacion.UsuarioPersistencia.blnEsDespachador == true)
                {
                    resIncidencias = IncidenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_INCIDENCIASCORPORACION,
                                                                                Aplicacion.UsuarioPersistencia.
                                                                                    intCorporacion,
                                                                                (int)ESTATUSINCIDENCIAS.PENDIENTE));
                }
                else
                {
                    resIncidencias =
                        IncidenciaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_INCIDENCIAS,
                                                                                (int)ESTATUSINCIDENCIAS.PENDIENTE));
                }

                foreach (var incidencia in resIncidencias) //vamos a la base para obtener los registros de estado pendiente y de la corporación del usuario
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

                        CorporacionMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_CORPORACIONES,
                                                                                 incidencia.Folio)).ForEach(
                            delegate(Corporacion c)
                            {
                                if (Aplicacion.UsuarioPersistencia.blnEsDespachador == true)
                                {
                                    if (c.Clave == Aplicacion.UsuarioPersistencia.intCorporacion)
                                    {
                                        corporaciones.Append(c.Descripcion);
                                        zonas.Append(c.Zn);
                                    }
                                }
                                else
                                {
                                    corporaciones.Append(c.Descripcion);
                                    corporaciones.Append(",");

                                    zonas.Append(c.Zn);
                                    zonas.Append(",");
                                }

                                if (c.Descripcion != string.Empty)
                                    totalCorporaciones += 1;
                            });

                        lstRegistrosReporte.Add(saiReport1.AgregarRegistro(null, incidencia.Folio,
                                                                       incidencia.Folio.ToString(),
                                                                       incidencia.HoraRecepcion.ToShortTimeString(),
                                                                       corporaciones.ToString().Trim().Length > 1 ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1) : string.Empty,
                                                                       TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion,
                                                                       zonas.ToString().Trim().Length > 1 ? zonas.ToString().Trim().Remove(zonas.Length - 1) : string.Empty,
                                                                       totalCorporaciones.ToString(),
                                                                       ObtenerLapso(incidencia.HoraRecepcion),
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

                                var corporaciones = new StringBuilder();
                                var zonas = new StringBuilder();
                                var totalCorporaciones = 0;

                                CorporacionMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_CORPORACIONES, incidencia.Folio)).ForEach(delegate(Corporacion c)
                                {
                                    if (Aplicacion.UsuarioPersistencia.blnEsDespachador == true)
                                    {
                                        if (c.Clave == Aplicacion.UsuarioPersistencia.intCorporacion)
                                        {
                                            corporaciones.Append(c.Descripcion);
                                            zonas.Append(c.Zn);
                                        }
                                    }
                                    else
                                    {
                                        corporaciones.Append(c.Descripcion);
                                        corporaciones.Append(",");

                                        zonas.Append(c.Zn);
                                        zonas.Append(",");
                                    }

                                    if (c.Descripcion != string.Empty)
                                        totalCorporaciones += 1;
                                });

                                saiReport1.reportControl.Records[itm.Record.Index][3].Value =
                                    corporaciones.ToString().Trim().Length > 1
                                        ? corporaciones.ToString().Trim().Remove(corporaciones.Length - 1)
                                        : ID.STR_DESCONOCIDO;

                                if (!incidenciaTemp.ClaveTipo.Equals(incidencia.ClaveTipo))
                                    saiReport1.reportControl.Records[itm.Record.Index][4].Value =
                                        TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo ?? 1).Descripcion;

                                saiReport1.reportControl.Records[itm.Record.Index][5].Value =
                                    zonas.ToString().Trim().Length > 1
                                        ? zonas.ToString().Trim().Remove(zonas.Length - 1)
                                        : ID.STR_DESCONOCIDO;

                                saiReport1.reportControl.Records[itm.Record.Index][6].Value =
                                    totalCorporaciones.ToString();
                                saiReport1.reportControl.Records[itm.Record.Index][7].Value = ObtenerLapso(incidencia.HoraRecepcion);

                                var lapso = DateTime.Now.Subtract(incidencia.HoraRecepcion);
                                saiReport1.reportControl.Records[itm.Record.Index][7].BackColor = (int)lapso.TotalMinutes < 3 ? ID.COLOR_AMARILLO : ID.COLOR_ROJO;

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
            catch (Exception)
            {
                tmrRegistros.Enabled = false;
                base.Close();
            }
        }

        private static string ObtenerLapso(DateTime dtFecha)
        {
            try
            {
                string strMensaje;
                var ahora = DateTime.Now;
                var lapso = ahora.Subtract(dtFecha);

                if (lapso.TotalHours > 0)
                    strMensaje = string.Format("{0:0} horas y {1:0} minutos", lapso.TotalHours, lapso.TotalMinutes);
                else strMensaje = lapso.TotalDays > 0 ? string.Format("{0:0} dias {1:0} horas y {2:0} minutos", lapso.TotalDays,
                                                                      lapso.TotalHours,
                                                                      lapso.TotalMinutes) : string.Format("{0:0} minutos", lapso.TotalMinutes);

                return strMensaje;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}