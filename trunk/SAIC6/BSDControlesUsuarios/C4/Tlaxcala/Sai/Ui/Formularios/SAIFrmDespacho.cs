using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using Microsoft.NetEnterpriseServers;
using XtremeReportControl;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
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
        private Corporacion _entCorporacion;
        private CorporacionIncidencia _entCorporacionIncidencia;
        private Incidencia _incidencia;
        private bool _blnComentarioNuevo;
        private bool _blnLlegadaManual;
        private bool _blnLiberadaManual;

        public SAIFrmDespacho(Incidencia incidencia)
        {
            InitializeComponent();
            ConfigurarGrid();

            _incidencia = incidencia;
            _entCorporacion = Aplicacion.UsuarioPersistencia.intCorporacion != null ?
                CorporacionMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intCorporacion.Value) : null;
            _entCorporacionIncidencia = _entCorporacion != null ?
                CorporacionIncidenciaMapper.Instance().GetOne(incidencia.Folio, _entCorporacion.Clave) : null;

            saiTxtTelefono.Text = !string.IsNullOrEmpty(incidencia.Telefono) ? incidencia.Telefono : ID.STR_DESCONOCIDO;
            saiTxtTipoIncidencia.Text = incidencia.ClaveTipo != null ? TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).Descripcion : ID.STR_DESCONOCIDO;
            saiTxtDireccion.Text = !string.IsNullOrEmpty(incidencia.Direccion) ? incidencia.Direccion : ID.STR_DESCONOCIDO;
            saiTxtMunicipio.Text = incidencia.ClaveMunicipio != null ? MunicipioMapper.Instance().GetOne(incidencia.ClaveMunicipio.Value).Nombre : ID.STR_DESCONOCIDO;
            saiTxtLocalidad.Text = incidencia.ClaveLocalidad != null ? LocalidadMapper.Instance().GetOne(incidencia.ClaveLocalidad.Value).Nombre : ID.STR_DESCONOCIDO;
            saiTxtCodigoPostal.Text = incidencia.ClaveCodigoPostal != null ? CodigoPostalMapper.Instance().GetOne(incidencia.ClaveCodigoPostal.Value).Valor : ID.STR_DESCONOCIDO;
            saiTxtColonia.Text = incidencia.ClaveColonia != null ? ColoniaMapper.Instance().GetOne(incidencia.ClaveColonia.Value).Nombre : ID.STR_DESCONOCIDO;
            saiTxtReferencia.Text = !string.IsNullOrEmpty(incidencia.Referencias) ? incidencia.Referencias : ID.STR_DESCONOCIDO;

            var datosAdicionales = new StringBuilder();
            switch (TipoIncidenciaMapper.Instance().GetOne(incidencia.ClaveTipo.Value).Clave)
            {
                case 103:
                    //personas extraviadas
                    var personasExtraviadas = PersonaExtraviadaMapper.Instance().GetByIncidencia(incidencia.Folio);
                    if (personasExtraviadas.Count > 0)
                    {
                        foreach (var e in personasExtraviadas)
                        {
                            var persona = PersonaExtraviadaMapper.Instance().GetOne(e.Clave);
                            if (persona == null) continue;
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
                    else
                        datosAdicionales.Append(ID.STR_DESCONOCIDO);
                    break;
                case 131:
                    //robo vehiculo total
                    var vehiculoTotal = VehiculoRobadoMapper.Instance().GetByIncidencia(incidencia.Folio);
                    if (vehiculoTotal.Count > 0)
                    {
                        foreach (var v in vehiculoTotal)
                        {
                            var vehiculo = VehiculoMapper.Instance().GetOne(v.ClaveVehiculo);
                            if (vehiculo == null) continue;
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
                    else
                        datosAdicionales.Append(ID.STR_DESCONOCIDO);
                    break;
                case 130:
                    //robo vehiculo accesorios
                    var roboAccesorios = RoboAccesoriosMapper.Instance().GetByIncidencia(incidencia.Folio);
                    if (roboAccesorios.Count > 0)
                    {
                        foreach (var roboAccesorio in roboAccesorios)
                        {
                            var accesorio =
                                RoboVehiculoAccesoriosMapper.Instance().GetOne(roboAccesorio.IdRoboAccesorio);
                            if (accesorio == null) continue;
                            datosAdicionales.AppendFormat("\nAccesorio Robado: {0}\n", accesorio.AccesorioRobado);
                            datosAdicionales.AppendFormat("Se percató: {0}\n", roboAccesorio.PersonaPercato);
                            datosAdicionales.AppendFormat("Descripción de los responsables: {0}\n", roboAccesorio.DescripcionResponsable);
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
            descripcionGral.AppendFormat("{0}", incidencia.Descripcion);
            descripcionGral.AppendLine();
            descripcionGral.AppendFormat("Información Adicional a la descripción:{0}", datosAdicionales);
            saiTxtDescripcion.Text = descripcionGral.ToString();

            //Obtener detalledespachoincidencia
            _despachoIncidencia =
                DespachoIncidenciaMapper.Instance().GetOneBySQLQuery(
                    string.Format(ID.SQL_OBTENERDESPACHOS2, incidencia.Folio));

            //cargar unidades,etc
            lblUnidadPrincipal.Text = ID.STR_DESCONOCIDO;
            lblUnidadApoyo.Text = ID.STR_DESCONOCIDO;
            if (_despachoIncidencia != null)
            {
                lblUnidadPrincipal.Text = _despachoIncidencia.ClaveUnidad != null ? UnidadMapper.Instance().GetOne(_despachoIncidencia.ClaveUnidad.Value).Codigo : ID.STR_DESCONOCIDO;
                _unidadAsignada = _despachoIncidencia.ClaveUnidad != null ? UnidadMapper.Instance().GetOne(_despachoIncidencia.ClaveUnidad.Value) : null;
                lblUnidadApoyo.Text = _despachoIncidencia.ClaveUnidadApoyo != null ? UnidadMapper.Instance().GetOne(_despachoIncidencia.ClaveUnidadApoyo.Value).Codigo : ID.STR_DESCONOCIDO;
                _unidadApoyo = _despachoIncidencia.ClaveUnidadApoyo != null ? UnidadMapper.Instance().GetOne(_despachoIncidencia.ClaveUnidadApoyo.Value) : null;

                saiTxtHoraRecepcion.Text = incidencia.HoraRecepcion.ToShortTimeString();
                saiTxtHoraDespacho.Text = _despachoIncidencia.HoraDespachada.Value.ToShortTimeString();
                if (_despachoIncidencia.HoraLlegada != null)
                {
                    saiTmpHoraLlegada.Value = _despachoIncidencia.HoraLlegada.Value;
                    chkHoraLlegada.Checked = true;
                    chkHoraLlegada.Enabled = true;
                }
                if (_despachoIncidencia.HoraLiberada != null)
                {
                    saiTmpHoraLiberacion.Value = _despachoIncidencia.HoraLiberada.Value;
                    chkHoraLiberacion.Checked = true;
                    chkHoraLiberacion.Enabled = true;
                }

                var comentariosDespacho =
                    DetalleDespachoIncidenciaMapper.Instance().GetByDespachoIncidencia(_despachoIncidencia.Clave);
                if (comentariosDespacho.Count > 0)
                {
                    foreach (var comentario in comentariosDespacho)
                    {
                        AgregarRegistro(comentario.Descripcion, UsuarioMapper.Instance().GetOne(comentario.ClaveUsuario).NombreUsuario);
                    }

                    _blnComentarioNuevo = false;
                    axComentarios.Populate();
                }
            }
            else
            {
                cmdQuitarUP.Enabled = false;
                cmdQuitarUA.Enabled = false;
            }

            if (_entCorporacion.UnidadesVirtuales)
            {
                lblUnidadPrincipal.Text = ID.STR_UNIDADVIRTUAL;
                lblUnidadApoyo.Text = ID.STR_UNIDADVIRTUAL;

                cmdQuitarUP.Enabled = false;
                cmdQuitarUA.Enabled = false;
            }

            Text = string.Format("{0} del Folio {1}", Text, incidencia.Folio);
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
                _blnComentarioNuevo = true;
                AgregarRegistro(strComentario.ToUpper(), Aplicacion.UsuarioPersistencia.strNombreUsuario);

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

                if (_despachoIncidencia == null)
                {
                    if (_entCorporacionIncidencia == null)
                    {
                        _entCorporacionIncidencia = new CorporacionIncidencia
                        {
                            Folio = _incidencia.Folio,
                            ClaveCorporacion = _entCorporacion.Clave
                        };
                        CorporacionIncidenciaMapper.Instance().Insert(_entCorporacionIncidencia);
                    }

                    _despachoIncidencia = new DespachoIncidencia
                    {
                        ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario,
                        ClaveCorporacion = _entCorporacion.Clave,
                        Folio = _incidencia.Folio,
                        HoraDespachada = DateTime.Now
                    };

                    DespachoIncidenciaMapper.Instance().Insert(_despachoIncidencia);
                    _incidencia.ClaveEstatus = (int)ESTATUSINCIDENCIAS.ACTIVA;
                    IncidenciaMapper.Instance().Save(_incidencia);
                }

                //guardar comentarios
                if (_blnComentarioNuevo)
                {
                    var _detalle = new DetalleDespachoIncidencia
                                                          {
                                                              ClaveDespacho = _despachoIncidencia.Clave,
                                                              ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario,
                                                              Descripcion = strComentario.Trim(),
                                                              HoraRegistro = DateTime.Now
                                                          };
                    DetalleDespachoIncidenciaMapper.Instance().Insert(_detalle);
                }
            }
        }

        private void axComentarios_MouseDownEvent(object sender, AxXtremeReportControl._DReportControlEvents_MouseDownEvent e)
        {
            int l = 0, t = 0, r = 0, b = 0;

            if (axComentarios.HeaderRows.Count <= 0) return;
            axComentarios.HeaderRows[0].GetRect(ref l, ref t, ref r, ref b);
            if (e.y > b)
                AgregarComentario();
            else
                if (Convert.ToString(axComentarios.HeaderRecords[0][0].Value) == ID.STR_NUEVOCOMENTARIO)
                    LimpiarEncabezado(false);
        }

        private void chkHoraLlegada_CheckedChanged(object sender, EventArgs e)
        {
            saiTmpHoraLlegada.Enabled = chkHoraLlegada.Checked;
            ActualizarHoraLlegada();
        }

        private void chkHoraLiberacion_CheckedChanged(object sender, EventArgs e)
        {
            saiTmpHoraLiberacion.Enabled = chkHoraLiberacion.Checked;
            ActualizaHoraLiberacion();
        }

        private void pnlUnidadPrincipal_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                try
                {
                    var intClaveUnidadDropped = Convert.ToInt32(RegresaValorDrop(e).ToString());
                    if (_unidadAsignada != null && _unidadAsignada.Clave == intClaveUnidadDropped)
                    {
                        MessageBox.Show("Esta unidad ya fue asignada.", "SAI C4");
                        e.Effect = DragDropEffects.None;
                        return;
                    }

                    if (_unidadAsignada != null)
                    {
                        if (MessageBox.Show("La incidencia ya tiene una unidad asignada, ¿Desea reemplazarla?", "SAI C4",
                                            MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }

                    var blnBorraUnidad = false;
                    if (_unidadApoyo != null && _unidadApoyo.Clave == intClaveUnidadDropped)
                    {
                        if (MessageBox.Show(
                                "La unidad que trata de asignar ya se encuentra como unidad de apoyo, ¿Desea reemplazarla?",
                                "SAI C4", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }

                        _unidadApoyo = null;
                        lblUnidadApoyo.Text = ID.STR_DESCONOCIDO;
                        blnBorraUnidad = true;
                    }
                    _unidadAsignada = UnidadMapper.Instance().GetOne(intClaveUnidadDropped);

                    if (_despachoIncidencia == null)
                    {
                        if (_entCorporacionIncidencia == null)
                        {
                            _entCorporacionIncidencia = new CorporacionIncidencia
                                                            {
                                                                Folio = _incidencia.Folio,
                                                                ClaveCorporacion = _entCorporacion.Clave
                                                            };
                            CorporacionIncidenciaMapper.Instance().Insert(_entCorporacionIncidencia);
                        }

                        _despachoIncidencia = new DespachoIncidencia
                                                  {
                                                      ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario,
                                                      ClaveCorporacion = _entCorporacion.Clave,
                                                      Folio = _incidencia.Folio,
                                                      ClaveUnidad = _unidadAsignada.Clave,
                                                      HoraDespachada = DateTime.Now
                                                  };
                        saiTxtHoraDespacho.Text = _despachoIncidencia.HoraDespachada.Value.ToShortTimeString();

                        if (blnBorraUnidad)
                        {
                            _despachoIncidencia.ClaveUnidadApoyo = null;
                        }

                        DespachoIncidenciaMapper.Instance().Insert(_despachoIncidencia);
                        _incidencia.ClaveEstatus = (int)ESTATUSINCIDENCIAS.ACTIVA;
                        IncidenciaMapper.Instance().Save(_incidencia);
                    }
                    else
                    {
                        _despachoIncidencia.ClaveUnidad = _unidadAsignada.Clave;
                        if (blnBorraUnidad)
                        {
                            _despachoIncidencia.ClaveUnidadApoyo = null;
                        }
                        _despachoIncidencia.HoraDespachada = DateTime.Now;
                        saiTxtHoraDespacho.Text = _despachoIncidencia.HoraDespachada.Value.ToShortTimeString();

                        DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);
                        _incidencia.ClaveEstatus = (int)ESTATUSINCIDENCIAS.ACTIVA;
                        IncidenciaMapper.Instance().Save(_incidencia);
                    }

                    lblUnidadPrincipal.Text = string.Format("{0}", _unidadAsignada.Codigo);
                    cmdQuitarUP.Enabled = true;
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
            try
            {
                try
                {
                    var intClaveUnidadDropped = int.Parse(RegresaValorDrop(e).ToString());
                    if (_unidadApoyo != null && _unidadApoyo.Clave == intClaveUnidadDropped)
                    {
                        MessageBox.Show("Esta unidad de apoyo ya fue asignada.", "SAI C4");
                        e.Effect = DragDropEffects.None;
                        return;
                    }


                    if (_unidadAsignada != null && _unidadAsignada.Clave == intClaveUnidadDropped)
                    {
                        MessageBox.Show("La unidad que trata de asignar como unidad de apoyo ya se encuentra como unidad principal.", "SAI C4");
                        e.Effect = DragDropEffects.None;
                        return;
                    }

                    if (_unidadApoyo != null)
                    {
                        if (MessageBox.Show("La incidencia ya tiene una unidad de apoyo asignada, ¿Desea reemplazarla?", "SAI C4", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }

                    _unidadApoyo = UnidadMapper.Instance().GetOne(intClaveUnidadDropped);
                    if (_despachoIncidencia == null)
                    {
                        if (_entCorporacionIncidencia == null)
                        {
                            _entCorporacionIncidencia = new CorporacionIncidencia
                                                            {
                                                                Folio = _incidencia.Folio,
                                                                ClaveCorporacion = _entCorporacion.Clave
                                                            };
                            CorporacionIncidenciaMapper.Instance().Insert(_entCorporacionIncidencia);
                        }

                        _despachoIncidencia = new DespachoIncidencia
                                                  {
                                                      ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario,
                                                      ClaveCorporacion = _entCorporacion.Clave,
                                                      Folio = _incidencia.Folio,
                                                      ClaveUnidadApoyo = _unidadApoyo.Clave
                                                  };

                        DespachoIncidenciaMapper.Instance().Insert(_despachoIncidencia);
                    }
                    else
                    {
                        _despachoIncidencia.ClaveUnidadApoyo = _unidadApoyo.Clave;
                        DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);
                    }

                    lblUnidadApoyo.Text = string.Format("{0}", _unidadApoyo.Codigo);
                    cmdQuitarUA.Enabled = true;
                }
                catch (Exception)
                {
                    throw new SAIExcepcion("Ocurrio un error al tratar de obtener la unidad.");
                }
            }
            catch (SAIExcepcion) { }
        }

        private void pnlUnidadApoyo_DragOver(object sender, DragEventArgs e)
        {
            if (RegresaValorDrop(e) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private static object RegresaValorDrop(DragEventArgs e)
        {
            var res = (MemoryStream)e.Data.GetData("SAIC4:iUnidades");
            if (res != null)
            {
                var rec = SAIReport.SAIInstancia.reportControl.CreateRecordsFromDropArray(res.ToArray());
                return rec[0][0].Value;
            }

            return null;
        }

        private void axComentarios_RequestEdit(object sender, AxXtremeReportControl._DReportControlEvents_RequestEditEvent e)
        {
            e.cancel = !axComentarios.Navigator.CurrentFocusInHeadersRows;
        }

        private void cmdQuitarUP_Click(object sender, EventArgs e)
        {
            var confirmacion = new ExceptionMessageBox("¿Desea remover la asignación de la unidad principal?", "SAI C4",
                                                          ExceptionMessageBoxButtons.YesNo,
                                                          ExceptionMessageBoxSymbol.Question,
                                                          ExceptionMessageBoxDefaultButton.Button2);

            if (DialogResult.Yes != confirmacion.Show(this)) return;
            _unidadAsignada = null;
            lblUnidadPrincipal.Text = ID.STR_DESCONOCIDO;

            _despachoIncidencia.ClaveUnidad = null;
            DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);

            cmdQuitarUP.Enabled = false;
        }

        private void cmdQuitarUA_Click(object sender, EventArgs e)
        {
            var confirmacion = new ExceptionMessageBox("¿Desea remover la asignación de la unidad de apoyo?", "SAI C4",
                                                          ExceptionMessageBoxButtons.YesNo,
                                                          ExceptionMessageBoxSymbol.Question,
                                                          ExceptionMessageBoxDefaultButton.Button2);

            if (DialogResult.Yes != confirmacion.Show(this)) return;
            _unidadApoyo = null;
            lblUnidadApoyo.Text = ID.STR_DESCONOCIDO;

            _despachoIncidencia.ClaveUnidadApoyo = null;
            DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);

            cmdQuitarUA.Enabled = false;
        }

        private void saiTmpHoraLlegada_ValueChanged(object sender, EventArgs e)
        {
            if (_blnLlegadaManual)
            {
                ActualizarHoraLlegada();
            }
        }

        private void ActualizarHoraLlegada()
        {
            try
            {
                try
                {
                    if (!chkHoraLlegada.Checked && _despachoIncidencia != null)
                    {
                        _despachoIncidencia.HoraLlegada = null;
                        DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);
                    }
                    else if (_despachoIncidencia != null)
                    {
                        _despachoIncidencia.HoraLlegada = saiTmpHoraLlegada.Value;
                        DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void saiTmpHoraLiberacion_ValueChanged(object sender, EventArgs e)
        {
            if (_blnLiberadaManual)
            {
                ActualizaHoraLiberacion();
            }
        }

        private void ActualizaHoraLiberacion()
        {
            try
            {
                try
                {
                    if (!chkHoraLiberacion.Checked && _despachoIncidencia != null)
                    {
                        _despachoIncidencia.HoraLiberada = null;

                        DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);
                        _incidencia.ClaveEstatus = (int)ESTATUSINCIDENCIAS.ACTIVA;
                        IncidenciaMapper.Instance().Save(_incidencia);
                    }
                    else if (_despachoIncidencia != null)
                    {
                        _despachoIncidencia.HoraLiberada = saiTmpHoraLiberacion.Value;
                        DespachoIncidenciaMapper.Instance().Save(_despachoIncidencia);
                        _incidencia.ClaveEstatus = (int)ESTATUSINCIDENCIAS.CERRADA;
                        IncidenciaMapper.Instance().Save(_incidencia);
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

        private void saiTmpHoraLlegada_KeyUp(object sender, KeyEventArgs e)
        {
            _blnLlegadaManual = true;
            ActualizarHoraLlegada();
        }

        private void saiTmpHoraLiberacion_KeyUp(object sender, KeyEventArgs e)
        {
            _blnLiberadaManual = true;
            ActualizaHoraLiberacion();
        }
    }
}
