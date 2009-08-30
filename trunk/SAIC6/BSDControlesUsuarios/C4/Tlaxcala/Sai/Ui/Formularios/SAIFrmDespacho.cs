using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using XtremeReportControl;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmDespacho : Form
    {
        private ReportRecord _registro;
        private ReportColumn _columna;
        private ReportRecordItem _item;
        private ReportRecord _registroActual;
        private Unidad _unidadAsignada;
        private Unidad _unidadApoyo;
        private DespachoIncidencia _despachoIncidencia;

        public SAIFrmDespacho()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        public SAIFrmDespacho(Incidencia incidencia)
        {
            InitializeComponent();
            ConfigurarGrid();

            saiTxtTelefono.Text = incidencia.Telefono;
            saiTxtTipoIncidencia.Text = incidencia.TipoIncidenciaEntity.Descripcion;
            saiTxtDireccion.Text = incidencia.Direccion;
            saiTxtMunicipio.Text = incidencia.ClaveMunicipio != null ? MunicipioMapper.Instance().GetOne(incidencia.ClaveMunicipio ?? -1).Nombre : ID.STR_DESCONOCIDO;
            saiTxtLocalidad.Text = incidencia.ClaveLocalidad != null ? LocalidadMapper.Instance().GetOne(incidencia.ClaveLocalidad ?? -1).Nombre : ID.STR_DESCONOCIDO;
            saiTxtCodigoPostal.Text = incidencia.ClaveCodigoPostal != null ? CodigoPostalMapper.Instance().GetOne(incidencia.ClaveCodigoPostal ?? -1).Valor : ID.STR_DESCONOCIDO;
            saiTxtColonia.Text = incidencia.ClaveColonia != null ? ColoniaMapper.Instance().GetOne(incidencia.ClaveColonia ?? 0).Nombre : ID.STR_DESCONOCIDO;
            saiTxtReferencia.Text = incidencia.Referencias;

            var datosAdicionales = new StringBuilder();
            switch (incidencia.TipoIncidenciaEntity.ClaveOperacion)
            {
                case "111":
                    //personas extraviadas
                    var personasExtraviadas = PersonaExtraviadaMapper.Instance().GetByIncidencia(incidencia.Folio);
                    if (personasExtraviadas.Count > 0)
                    {
                        foreach (var e in personasExtraviadas)
                        {
                            var persona = PersonaExtraviadaMapper.Instance().GetOne(e.Clave);
                            if (persona != null)
                            {
                                datosAdicionales.AppendFormat("\nNombre: {0}\n",
                                                              persona.Nombre != string.Empty
                                                                  ? persona.Nombre
                                                                  : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Edad: {0}\n",
                                                              persona.Edad ?? 0);
                                datosAdicionales.AppendFormat("Sexo: {0}\n",
                                                              persona.Sexo != string.Empty
                                                                  ? persona.Sexo
                                                                  : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Estatura: {0}\n",
                                                              persona.Estatura ?? 0);
                            }
                        }
                    }
                    else
                        datosAdicionales.Append(ID.STR_DESCONOCIDO);
                    break;
                case "2003":
                    //robo vehiculo total
                    var vehiculoTotal = VehiculoRobadoMapper.Instance().GetByIncidencia(incidencia.Folio);
                    if (vehiculoTotal.Count > 0)
                    {
                        foreach (var v in vehiculoTotal)
                        {
                            var vehiculo = VehiculoMapper.Instance().GetOne(v.ClaveVehiculo);
                            if (vehiculo != null)
                            {
                                datosAdicionales.AppendFormat("\nMarca: {0}\n", vehiculo.Marca != string.Empty ? vehiculo.Marca : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Tipo: {0}\n", vehiculo.Tipo != string.Empty ? vehiculo.Tipo : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Modelo: {0}\n", vehiculo.Modelo != string.Empty ? vehiculo.Modelo : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Placas: {0}\n", vehiculo.Placas != string.Empty ? vehiculo.Placas : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Color: {0}\n", vehiculo.Color != string.Empty ? vehiculo.Color : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Número de Serie: {0}\n", vehiculo.NumeroSerie != string.Empty ? vehiculo.NumeroSerie : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Señas Particulares: {0}\n", vehiculo.SeñasParticulares != string.Empty ? vehiculo.SeñasParticulares : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Número de Motor: {0}", vehiculo.NumeroMotor != string.Empty ? vehiculo.NumeroMotor : ID.STR_DESCONOCIDO);
                            }
                        }
                    }
                    else
                        datosAdicionales.Append(ID.STR_DESCONOCIDO);
                    break;
                case "2004":
                    //robo vehiculo accesorios
                    var vehiculoAccesorios =
                        RoboVehiculoAccesoriosMapper.Instance().GetByIncidencia(incidencia.Folio);
                    if (vehiculoAccesorios.Count > 0)
                    {
                        foreach (var a in vehiculoAccesorios)
                        {
                            var accesorios = RoboVehiculoAccesoriosMapper.Instance().GetOne(a.Clave);
                            if (accesorios != null)
                            {
                                datosAdicionales.AppendFormat("\nAccesorios Robados: {0}\n",
                                                              accesorios.AccesoriosRobados != string.Empty
                                                                  ? accesorios.AccesoriosRobados
                                                                  : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Se percató: {0}\n", accesorios.SePercato != string.Empty ? accesorios.SePercato : ID.STR_DESCONOCIDO);
                                datosAdicionales.AppendFormat("Descripción Responsables: {0}\n",
                                                              accesorios.DescripcionResponsables != string.Empty
                                                                  ? accesorios.DescripcionResponsables
                                                                  : ID.STR_DESCONOCIDO);
                            }
                        }
                    }
                    else
                        datosAdicionales.Append(ID.STR_DESCONOCIDO);
                    break;
                default:
                    datosAdicionales.Append(ID.STR_DESCONOCIDO);
                    break;
            }

            var descripcionGral = new StringBuilder();
            descripcionGral.AppendFormat("{0}\n Información Adicional a la descripción:{1}", incidencia.Descripcion, datosAdicionales);
            saiTxtDescripcion.Text = descripcionGral.ToString();

            //Obtener detalledespachoincidencia
            _despachoIncidencia =
                DespachoIncidenciaMapper.Instance().GetOneBySQLQuery(
                    string.Format(ID.SQL_OBTENERDESPACHOS2, incidencia.Folio));

            //cargar unidades,etc
            if (_despachoIncidencia != null)
            {
                lbUnidadPrincipal.Text = _despachoIncidencia.ClaveUnidad != null ? UnidadMapper.Instance().GetOne(_despachoIncidencia.ClaveUnidad ?? -1).Codigo : ID.STR_DESCONOCIDO;
                lblUnidadApoyo.Text = _despachoIncidencia.ClaveUnidadApoyo != null ? UnidadMapper.Instance().GetOne(_despachoIncidencia.ClaveUnidadApoyo ?? -1).Codigo : ID.STR_DESCONOCIDO;
                saiTxtHoraRecepcion.Text = incidencia.HoraRecepcion.ToString();
                saiTxtHoraDespacho.Text = _despachoIncidencia.HoraDespachada.ToString();
                if (_despachoIncidencia.HoraLlegada != null)
                    saiTmpHoraLlegada.Value = _despachoIncidencia.HoraLlegada.Value;
                if (_despachoIncidencia.HoraLiberada != null)
                    saiTmpHoraLiberacion.Value = _despachoIncidencia.HoraLiberada.Value;

                var comentariosDespacho =
                    DetalleDespachoIncidenciaMapper.Instance().GetByDespachoIncidencia(_despachoIncidencia.Clave);
                if (comentariosDespacho.Count > 0)
                {
                    foreach (var comentario in comentariosDespacho)
                    {
                        AgregarRegistro(comentario.Descripcion, UsuarioMapper.Instance().GetOne(comentario.ClaveUsuario).NombreUsuario);
                    }

                    axComentarios.Populate();
                }
            }
        }

        private void SAIFrmDespacho_Load(object sender, EventArgs e)
        {
        }

        private void ConfigurarGrid()
        {
            axComentarios.PaintManager.HeaderRowsDividerStyle =
                XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerOutlook;

            _columna = axComentarios.Columns.Add(0, "Comentarios", 250, true);
            _columna = axComentarios.Columns.Add(1, "Despachador", 100, true);
            _columna.EditOptions.AllowEdit = false;

            _registro = axComentarios.HeaderRecords.Add();
            _item = _registro.AddItem(string.Empty);
            _item = _registro.AddItem(string.Empty);

            LimpiarEncabezado(true);
            axComentarios.Populate();
        }

        private void LimpiarEncabezado(bool blnLimpiar)
        {
            _registroActual = axComentarios.HeaderRecords[0];
            _registroActual[0].Value = blnLimpiar ? ID.STR_NUEVOCOMENTARIO : string.Empty;
            _registroActual[1].Value = Aplicacion.UsuarioPersistencia.strNombreUsuario;
        }

        private void axComentarios_KeyUpEvent(object sender, AxXtremeReportControl._DReportControlEvents_KeyUpEvent e)
        {
            if (axComentarios.Navigator.CurrentFocusInHeadersRows && (e.keyCode == 13 && e.shift == 0))
                AgregarComentario();
        }

        private void AgregarComentario()
        {
            _registroActual = axComentarios.HeaderRecords[0];

            var strComentario = Convert.ToString(_registroActual[0].Value);
            if (strComentario != ID.STR_NUEVOCOMENTARIO)
            {
                AgregarRegistro(strComentario, Aplicacion.UsuarioPersistencia.strNombreUsuario);

                LimpiarEncabezado(true);
                axComentarios.Populate();
                axComentarios.Navigator.CurrentFocusInHeadersRows = true;
            }
        }

        private void AgregarRegistro(string strComentario, string strDespachador)
        {
            if (strComentario.Trim() != string.Empty)
            {
                _registroActual = axComentarios.Records.Insert(0);
                _item = _registroActual.AddItem(strComentario);
                _item = _registroActual.AddItem(strDespachador);
            }
        }

        private void axComentarios_MouseDownEvent(object sender, AxXtremeReportControl._DReportControlEvents_MouseDownEvent e)
        {
            int l, t, r, b;
            l = t = r = b = 0;

            if (axComentarios.HeaderRows.Count > 0)
            {
                axComentarios.HeaderRows[0].GetRect(ref l, ref t, ref r, ref b);
                if (e.y > b)
                    AgregarComentario();
                else
                    if (Convert.ToString(axComentarios.HeaderRecords[0][0].Value) == ID.STR_NUEVOCOMENTARIO)
                        LimpiarEncabezado(false);
            }
        }

        private void chkHoraLlegada_CheckedChanged(object sender, EventArgs e)
        {
            saiTmpHoraLlegada.Enabled = chkHoraLlegada.Checked;
        }

        private void chkHoraLiberacion_CheckedChanged(object sender, EventArgs e)
        {
            saiTmpHoraLiberacion.Enabled = chkHoraLiberacion.Checked;
        }

        private void pnlUnidadPrincipal_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                try
                {
                    int intClaveUnidadDropped = Convert.ToInt32(RegresaValorDrop(e).ToString());
                    if (_unidadAsignada != null)
                    {
                        if (MessageBox.Show("La incidencia ya tiene una unidad asignada ¿Desea reemplazarla?", "SAI C4",
                                            MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }

                    if (_unidadApoyo != null && _unidadApoyo.Clave == intClaveUnidadDropped)
                    {
                        if (MessageBox.Show(
                                "La unidad que trata de asignar ya se encuentra como unidad de apoyo de la incidencia  ¿Desea reemplazarla?",
                                "SAI C4", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }

                    _unidadAsignada = UnidadMapper.Instance().GetOne(intClaveUnidadDropped);


                }
                catch (Exception)
                {
                    throw new SAIExcepcion("Ocurrio un error al tratar de obtener la unidad.");
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        private void pnlUnidadPrincipal_DragOver(object sender, DragEventArgs e)
        {
            if (RegresaValorDrop(e) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pnlUnidadApoyo_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void pnlUnidadApoyo_DragOver(object sender, DragEventArgs e)
        {
            if (RegresaValorDrop(e) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private object RegresaValorDrop(DragEventArgs e)
        {

            var res = (MemoryStream)e.Data.GetData("SAIC4:iUnidades");
            if (res != null)
            {
                var rec = SAIReport.SAIInstancia.reportControl.CreateRecordsFromDropArray(res.ToArray());
                return rec[0][0].Value;
            }

            return null;
        }
    }
}
