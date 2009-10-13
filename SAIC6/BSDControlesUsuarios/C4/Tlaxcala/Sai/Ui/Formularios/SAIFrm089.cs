/*
 * Hecho por: TSUI DAVID JESUS ENCISO GUADARRAMA
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    ///<summary>
    ///</summary>
    public partial class SAIFrm089 : SAIFrmBase
    {
        protected Entidades.Incidencia _Incidencia089;

        /// <summary>
        /// Objeto que guarda las claves de municipio, localidad, colonia y código postal que se tienen escogidas por el 
        /// usuario a cada momento en el formulario
        /// </summary>
        /// <remarks>
        /// Este objeto se pasa al método del la clase controladora del mapa para leer los valores de los id's correspondientes
        /// </remarks>
        private Mapa.EstructuraUbicacion _objUbicacion = new Mapa.EstructuraUbicacion();

        private Entidades.CodigoPostalList objListaCodigosPostales = new Entidades.CodigoPostalList();
        private Entidades.CodigoPostal entCodigoPostal;

        /// <summary>
        /// Bandera que se utiliza para detener el disparo en cascada de los eventos SelectedIndexChanged
        /// para las listas de municipios, localidades, colonias y códigos postales.
        /// </summary>
        private Boolean _blnBloqueaEventos;

        /// <summary>
        /// Lleva el estado del caso de la tecla control presionada.
        /// </summary>
        protected bool _blnCtrPresionado;

        /// <summary>
        /// Constructor para generar una nueva Incidencia 089
        /// </summary>
        public SAIFrm089()
        {
            _blnBloqueaEventos = true;
            InitializeComponent();
            this.InsertarIncidencia();
            this.Text = "Folio " + Convert.ToString(this._Incidencia089.Folio);
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarTipoIncidencias();
            this.LlenarMunicipios();
            this.lblFechaHora.Text += "  " + DateTime.Now.ToLocalTime();
            this.lblOperador.Text += "  " + Aplicacion.UsuarioPersistencia.strNombreUsuario;
            _blnBloqueaEventos = false;
            base.Activated += SAIFrm089_Activated;
        }

        private void SAIFrm089_Activated(object sender, EventArgs e)
        {
            Aplicacion.intFolioPorCancelar = _Incidencia089.Folio;
            Aplicacion.frmIncidenciaActiva = this;
        }

        /// <summary>
        /// Constructor para generar una nueva incidencia 089
        /// </summary>
        /// <param name="strTelefono">Numero de Telefono</param>
        public SAIFrm089(string strTelefono)
        {
            _blnBloqueaEventos = true;
            InitializeComponent();
            this.InsertarIncidencia();
            this.Text = "Folio " + Convert.ToString(this._Incidencia089.Folio);
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarTipoIncidencias();
            this.LlenarMunicipios();
            this.lblFechaHora.Text += "  " + DateTime.Now.ToLocalTime();
            this.lblOperador.Text += "  " + Aplicacion.UsuarioPersistencia.strNombreUsuario;
            _blnBloqueaEventos = false;
            base.Activated += SAIFrm089_Activated;
        }

        /// <summary>
        /// Constructor para una incidencia ya existente
        /// </summary>
        /// <param name="entIncidencia">Entidad ya existente(Consulta)</param>
        public SAIFrm089(Entidades.Incidencia entIncidencia)
        {
            InitializeComponent();
            _blnBloqueaEventos = true;
            _Incidencia089 = entIncidencia;
            this.LlenarTipoIncidencias();
            this.LlenarMunicipios();
            this._blnBloqueaEventos = false;
            this.Text = "Folio " + Convert.ToString(this._Incidencia089.Folio);
            this.lblFechaHora.Text += " " + DateTime.Now.ToLocalTime();
            this.lblOperador.Text += Aplicacion.UsuarioPersistencia.strNombreUsuario;
            this.LlenarDatosIncidencia();
            _blnBloqueaEventos = false;
        }

        private void SAIFrm089_Load(object sender, EventArgs e)
        {
            this.Bloquear(Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_NI));
            saiOrtografia.MainDictionary.FileName = string.Format(@"{0}\{1}", Environment.CurrentDirectory, "C1Spell_es-MX.dct");
        }

        /// <summary>
        /// Bloquea controles dependiendo de los permisos asignados
        /// </summary>
        /// <param name="bloquear">Valor booleano que determina si se bloquean o no</param>
        private void Bloquear(bool bloquear)
        {
            try
            {
                try
                {
                    this.txtAliasDelincuente.Enabled = bloquear;
                    this.txtDescripcionDenuncia.Enabled = bloquear;
                    this.txtDireccion.Enabled = bloquear;
                    this.txtOficioEnvio.Enabled = bloquear;

                    this.txtReferencias.Enabled = bloquear;
                    this.cbxColonia.Enabled = bloquear;
                    this.cbxCP.Enabled = bloquear;
                    this.cbxLocalidad.Enabled = bloquear;
                    this.cbxMunicipio.Enabled = bloquear;
                    this.cbxTipoDenuncia.Enabled = bloquear;

                    this.chkFechaDoc.Enabled = bloquear;

                    //this.btnDependencias.Enabled = bloquear;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Manda el foco al campo Dirección
        /// </summary>
        private void cbxTipoDenuncia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Municipio
        /// </summary>
        private void txtDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxMunicipio.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Localidad
        /// </summary>
        private void cbxMunicipio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxLocalidad.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Colonia
        /// </summary>
        private void cbxCP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxColonia.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo CodigoPostal
        /// </summary>
        private void cbxLocalidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxCP.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Referencias
        /// </summary>
        private void cbxColonia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtReferencias.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Oficio Envio
        /// </summary>
        private void txtAliasDelincuente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtOficioEnvio.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Fecha Documento
        /// </summary>
        private void txtOficioEnvio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpFechaDoc.Focus();
            }
        }

        /// <summary>
        /// Manda el foco al campo Llena los Tipos de Incidencias para 089
        /// </summary>
        private void LlenarTipoIncidencias()
        {
            try
            {
                try
                {
                    Entidades.TipoIncidenciaList lstTipoIncidencia =
                        Mappers.TipoIncidenciaMapper.Instance().GetBySistema(1);
                    foreach (Entidades.TipoIncidencia tIncidencia in lstTipoIncidencia)
                    {
                        tIncidencia.Descripcion = tIncidencia.ClaveOperacion + " " + tIncidencia.Descripcion;
                    }
                    this.cbxTipoDenuncia.DataSource = lstTipoIncidencia;
                    this.cbxTipoDenuncia.DisplayMember = "Descripcion";
                    this.cbxTipoDenuncia.ValueMember = "Clave";
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Llena los Municipio
        /// </summary>
        private void LlenarMunicipios()
        {
            try
            {
                try
                {
                    this.cbxMunicipio.DataSource = Mappers.MunicipioMapper.Instance().GetAll();
                    this.cbxMunicipio.DisplayMember = "Nombre";
                    this.cbxMunicipio.ValueMember = "Clave";
                    this.cbxMunicipio.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Agrega una nueva Incidencia
        /// </summary>
        private void InsertarIncidencia()
        {
            try
            {
                try
                {
                    _Incidencia089 = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Incidencia();

                    _Incidencia089.HoraRecepcion = DateTime.Now;
                    _Incidencia089.Referencias = string.Empty;
                    _Incidencia089.Descripcion = string.Empty;
                    _Incidencia089.Activo = true;
                    _Incidencia089.ClaveEstatus = 1;
                    _Incidencia089.ClaveEstado = 29; //Estado de Tlaxcala
                    _Incidencia089.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;

                    Mappers.IncidenciaMapper.Instance().Insert(_Incidencia089);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Actualiza una Incidencia
        /// </summary>
        private void ActualizarIncidencia()
        {
            try
            {
                try
                {
                    this.RecuperaDatosEnIncidencia();
                    Mappers.IncidenciaMapper.Instance().Save(_Incidencia089);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Actualiza la dependencia Activa y muestra la ventana modal de Dependencias
        /// </summary>
        private void btnDependencias_Click(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();

            SAIFrmDependencias089 frmDependencias = new SAIFrmDependencias089(this._Incidencia089);
            frmDependencias.TopMost = true;
            frmDependencias.ShowDialog(this);
        }

        /// <summary>
        /// Llena los controles con los datos de una incidencia
        /// </summary>
        private void LlenarDatosIncidencia()
        {
            try
            {
                try
                {
                    Entidades.CodigoPostalList objListaCodigosPostales = new Entidades.CodigoPostalList();
                    this.txtDireccion.Text = this._Incidencia089.Direccion;
                    this.txtReferencias.Text = this._Incidencia089.Referencias;
                    this.txtDescripcionDenuncia.Text = this._Incidencia089.Descripcion;
                    this.txtAliasDelincuente.Text = this._Incidencia089.AliasDelincuente;
                    this.txtOficioEnvio.Text = this._Incidencia089.NumeroOficio;
                    //Datos de la Ubicacion
                    //Si los valores del estado y municipio no estan vacios
                    if (this._Incidencia089.ClaveEstado.HasValue && this._Incidencia089.ClaveMunicipio.HasValue)
                    {
                        //Selecciona el muncipio correspondiente
                        foreach (Entidades.Municipio municipio in cbxMunicipio.Items)
                        {
                            if (municipio.Clave == this._Incidencia089.ClaveMunicipio.Value)
                            {
                                this.cbxMunicipio.SelectedItem = municipio;
                                break;
                            }
                        }

                        this._blnBloqueaEventos = false;
                        //Actualiza la lista de localidades dependiendo del municipio ya seleccionado
                        this.cbxMunicipioActualizaLocalidades();
                        //Si hay una clave de localidad especificada
                        if (this._Incidencia089.ClaveLocalidad.HasValue)
                        {
                            foreach (Entidades.Localidad localidad in cbxLocalidad.Items)
                            {
                                if (localidad.Clave == this._Incidencia089.ClaveLocalidad.Value)
                                {
                                    //selecciona la localidad correspondiente
                                    this.cbxLocalidad.SelectedItem = localidad;
                                    break;
                                }
                            }

                            if (this._Incidencia089.ClaveColonia.HasValue)
                            {
                                this.cbxLocalidadActualizaColonia();
                                foreach (Entidades.Colonia colonia in cbxColonia.Items)
                                {
                                    if (colonia.Clave == this._Incidencia089.ClaveColonia.Value)
                                    {
                                        this.cbxColonia.SelectedItem = colonia;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (this._Incidencia089.FechaDocumento.HasValue)
                    {
                        this.dtpFechaDoc.Value = this._Incidencia089.FechaDocumento.Value;
                        this.chkFechaDoc.Checked = true;
                    }
                    else
                    {
                        this.chkFechaDoc.Checked = false;
                        this.dtpFechaDoc.Value = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona un municipio
        /// </summary>
        private void cbxMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxMunicipioActualizaLocalidades();
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona una Localidad
        /// </summary>
        private void cbxLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxLocalidadActualizaColonia();
        }

        private void cbxLocalidadActualizaColonia()
        {
            try
            {
                Entidades.ColoniaList lstColonia;
                try
                {
                    //Si esta bloqueado no hace nada
                    if (_blnBloqueaEventos)
                    {
                        return;
                    }
                    //Bandera para bloquear evento
                    this._blnBloqueaEventos = true;
                    this.LimpiaColonias(); //limpia colonias
                    lstColonia =
                        Mappers.ColoniaMapper.Instance().GetByLocalidad(
                            ((Entidades.Localidad)this.cbxLocalidad.SelectedItem).Clave);
                    if (lstColonia.Count > 0)
                    {
                        //se agregan colonias al control correspondientes a la localidad seleccionada
                        //posteriormente se agregaran lo CP de la localidad agregada
                        this.ActualizaColonias(lstColonia);
                        //objeto que se que almacenara los CP
                        //Entidades.CodigoPostalList cpTemp = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.CodigoPostalList();
                        //SE OBTIENE LA LISTA DE CODIGOS POSTALES DE LA LOCALIDAD CORRESPONDIENTE
                        Entidades.CodigoPostalList lstCodigoPostal =
                            Mappers.CodigoPostalMapper.Instance().GetByLocalidad(
                                ((Entidades.Localidad)this.cbxLocalidad.SelectedItem).Clave);
                        //bool existe = false;//bandera para determinar si un cp esta repetido
                        if (lstCodigoPostal.Count > 0)
                        {
                            this._blnBloqueaEventos = true;
                            ActualizarCodigoPostal(lstCodigoPostal);
                            this._blnBloqueaEventos = false;
                        }
                    }
                    //Bandera para desbloquear
                    this._blnBloqueaEventos = false;
                    this.ActualizaMapaUbicacion();
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona una Colonia
        /// </summary>
        private void cbxColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._blnBloqueaEventos)
                    {
                        return;
                    }
                    this._blnBloqueaEventos = true;

                    if (this.cbxCP.Items.Count > 0)
                    {
                        if (((Entidades.Colonia)this.cbxColonia.SelectedItem).ClaveCodigoPostal.HasValue)
                        {
                            this.cbxCP.SelectedValue =
                                ((Entidades.Colonia)this.cbxColonia.SelectedItem).ClaveCodigoPostal;
                        }
                    }
                    else
                    {
                        if (this.cbxColonia.SelectedValue != null)
                        {
                            Entidades.CodigoPostalList lstCodigoPostal =
                                new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.CodigoPostalList();
                            lstCodigoPostal.Add(
                                Mappers.CodigoPostalMapper.Instance().GetOne(
                                    Convert.ToInt32(this.cbxColonia.SelectedValue)));
                            this._blnBloqueaEventos = true;
                            if (lstCodigoPostal.Count > 0)
                            {
                                ActualizarCodigoPostal(lstCodigoPostal);
                                this.cbxCP.SelectedIndex = 0;
                            }
                            this._blnBloqueaEventos = false;
                        }
                    }

                    this._blnBloqueaEventos = false;
                    this.ActualizaMapaUbicacion();
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /*
                /// <summary>
                /// Selecciona un CP
                /// </summary>
                /// <param name="cpSelect">Valor del CP que se quiere seleccionar</param>
                private void SeleccionaCP(int cpSelect)
                {
                    foreach (Entidades.CodigoPostal cpItem in this.cbxCP.Items)
                    {
                        if (cpItem.Clave == cpSelect)
                            this.cbxCP.SelectedItem = cpItem;
                    }
                }
        */

        /// <summary>
        /// Valida que solo se captren numeros al Capturar el Codigo Postal
        /// </summary>
        private void cbxCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Actualiza los datos de la incidencia cuando se ha capturado las referencias
        /// </summary>
        private void txtReferencias_Leave(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();
        }

        // <summary>
        /// Actualiza los datos de la incidencia cuando se ha capturado la direccion
        /// </summary>
        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();
        }

        /// <summary>
        /// Verifica que el tipo de Denuncia, si es broma se actualiza el Estatus a Cancelado
        /// </summary>
        private void cbxTipoDenuncia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoDenuncia.SelectedItem != null && (
                                                            (cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).
                                                                ClaveOperacion.Trim() == "133"
                                                            ||
                                                            (cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).
                                                                ClaveOperacion.Trim() == "5047"
                                                        ))
            {
                txtDireccion.Text = "SIN REGISTRO";
                this._Incidencia089.ClaveEstatus = 5;
                //this.ActualizarIncidencia();
                this.Close();
            }
        }

        /// <summary>
        /// Ocurre cuando se activa o desactiva el check de Fecha Documento, activando o desactivando el control Fecha Documento
        /// </summary>
        private void chkFechaDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkFechaDoc.Checked)
            {
                this.dtpFechaDoc.Enabled = true;
            }
            else
            {
                this.dtpFechaDoc.Enabled = false;
                this._Incidencia089.FechaDocumento = new Nullable<DateTime>();
            }
        }

        /// <summary>
        /// Se asigna fecha del documento del Oficio
        /// </summary>
        private void dtpFechaDoc_ValueChanged(object sender, EventArgs e)
        {
            _Incidencia089.FechaDocumento = this.dtpFechaDoc.Value;
            //this.ActualizarIncidencia();
        }

        /// <summary>
        /// Lee los datos del formulario y escribe la información en el objeto de incidencia
        /// </summary>
        protected void RecuperaDatosEnIncidencia()
        {
            if (this._Incidencia089 != null)
            {
                if (this.cbxMunicipio.SelectedIndex == -1 || this.cbxMunicipio.Text.Trim() == string.Empty)
                {
                    this._Incidencia089.ClaveMunicipio = null;
                }
                else
                {
                    this._Incidencia089.ClaveMunicipio = _objUbicacion.IdMunicipio;
                }
                if (this.cbxLocalidad.SelectedIndex == -1 || this.cbxLocalidad.Text.Trim() == string.Empty)
                {
                    this._Incidencia089.ClaveLocalidad = null;
                }
                else
                {
                    this._Incidencia089.ClaveLocalidad = _objUbicacion.IdLocalidad;
                }
                if (this.cbxColonia.SelectedIndex == -1 || this.cbxColonia.Text.Trim() == string.Empty)
                {
                    this._Incidencia089.ClaveColonia = null;
                }
                else
                {
                    this._Incidencia089.ClaveColonia = _objUbicacion.IdColonia;
                }
                if (this.cbxCP.SelectedIndex == -1 || this.cbxCP.Text.Trim() == string.Empty)
                {
                    this._Incidencia089.ClaveCodigoPostal = null;
                }
                else
                {
                    this._Incidencia089.ClaveCodigoPostal = _objUbicacion.IdCodigoPostal;
                }
                //this._Incidencia089.Telefono = txtTelefono.Text;
                if (this.cbxTipoDenuncia.SelectedIndex != -1 && this.cbxTipoDenuncia.Text.Trim() != string.Empty)
                {
                    this._Incidencia089.ClaveTipo =
                        (this.cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).Clave;
                }
                else
                {
                    this._Incidencia089.ClaveTipo = null;
                }
                this._Incidencia089.Descripcion = this.txtDescripcionDenuncia.Text;
                this._Incidencia089.Direccion = txtDireccion.Text;
                this._Incidencia089.Referencias = this.txtReferencias.Text;
                this._Incidencia089.AliasDelincuente = this.txtAliasDelincuente.Text;
                this._Incidencia089.NumeroOficio = this.txtOficioEnvio.Text;
            }
        }

        // <summary>
        /// Actualiza los datos de la incidencia cuando se cierra formulario
        /// </summary>
        private void SAIFrm089_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ActualizarIncidencia();
        }

        /// <summary>
        /// Si se captura un numero de oficio se actualiza el estatus a Pendiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOficioEnvio_Leave(object sender, EventArgs e)
        {
            Entidades.IncidenciaDependenciaList lstInsDependencia =
                Mappers.IncidenciaDependenciaMapper.Instance().GetByIncidencia(this._Incidencia089.Folio);
            if (lstInsDependencia.Count > 0) //Si tiene de pendencias
            {
                this.txtOficioEnvio.Text = this._Incidencia089.NumeroOficio;
                bool completo = false;
                //bandera para verificar si esta completo (cada dependencia tiene ambas fechas asignadas) o nel
                foreach (Entidades.IncidenciaDependencia dependencia in lstInsDependencia)
                {
                    if (dependencia.FechaEnvioDependencia.HasValue && dependencia.FechaNotificacion.HasValue)
                    //ambas fechas tienen valor asignado
                    {
                        completo = true;
                    }
                    else
                    {
                        completo = false;
                    }
                }
                if (!completo) //le faltan fechas a capturar
                {
                    this._Incidencia089.ClaveEstatus = 3;
                }
                else
                {
                    this._Incidencia089.ClaveEstatus = 4;
                } //esta completo
            }
            else //si no tiene dependencias
            {
                //si se ha capturado un numeor de oficio
                if (this.txtOficioEnvio.Text != string.Empty)
                {
                    this._Incidencia089.ClaveEstatus = 2;
                }
                else //si no se ha capturado numero de oficio
                {
                    this._Incidencia089.ClaveEstatus = 1;
                }
            }

            this.ActualizarIncidencia();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se modifica el numero de oficio
        /// </summary>
        private void txtOficioEnvio_TextChanged(object sender, EventArgs e)
        {
            //si se ha capturado texto
            if (this.txtOficioEnvio.Text != string.Empty || this.txtOficioEnvio.Text.Length > 0)
            {
                Entidades.IncidenciaDependenciaList lstIncidenciaDependencia =
                    Mappers.IncidenciaDependenciaMapper.Instance().GetByIncidencia(this._Incidencia089.Folio);
                if (lstIncidenciaDependencia.Count > 0) //se verifica si tiene dependencias
                {
                    //si tiene se escrie el numero de oficio No se puede cmabiar si tiene asignadas ya dependencias
                    this.txtOficioEnvio.Text = this._Incidencia089.NumeroOficio;
                }
                else
                {
                    //no tiene dependencias y se asigna el estatus a 2
                    this._Incidencia089.ClaveEstatus = 2;
                    this.ActualizarIncidencia();
                }
                this.btnDependencias.Enabled = true;
            }
            else
            {
                Entidades.IncidenciaDependenciaList lstIncidenciaDependencia =
                    Mappers.IncidenciaDependenciaMapper.Instance().GetByIncidencia(this._Incidencia089.Folio);
                if (lstIncidenciaDependencia.Count > 0) //tiene dependencias
                {
                    //el numeor de ofici ya asignado no puede cambiar
                    this.txtOficioEnvio.Text = this._Incidencia089.NumeroOficio;
                    this.btnDependencias.Enabled = true;
                }
                else
                {
                    //no tiene dependencias y si es borrado el numero de oficio, el estatus es 1
                    this._Incidencia089.ClaveEstatus = 1;
                    this.ActualizarIncidencia();
                    this.btnDependencias.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Actualiza el mapa con los datos de la ubicación del formulario actuales
        /// </summary>
        private void ActualizaMapaUbicacion()
        {
            if (cbxCP.SelectedIndex == -1 || cbxCP.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdCodigoPostal = null;
            }
            else
            {
                _objUbicacion.IdCodigoPostal = Convert.ToInt32(cbxCP.SelectedValue);
            }

            if (cbxColonia.SelectedIndex == -1 || cbxColonia.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdColonia = null;
            }
            else
            {
                _objUbicacion.IdColonia = Convert.ToInt32(cbxColonia.SelectedValue);
            }

            if (cbxLocalidad.SelectedIndex == -1 || cbxLocalidad.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdLocalidad = null;
            }
            else
            {
                _objUbicacion.IdLocalidad = Convert.ToInt32(cbxLocalidad.SelectedValue);
            }

            if (cbxMunicipio.SelectedIndex == -1 || cbxMunicipio.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdMunicipio = null;
            }
            else
            {
                _objUbicacion.IdMunicipio = Convert.ToInt32(cbxMunicipio.SelectedValue);
            }

            Mapa.Controlador.MuestraMapa(_objUbicacion, this);
        }

        /// <summary>
        /// Actualiza la ubicación del mapa cuando el formulario es activado
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            try
            {
                try
                {
                    base.OnActivated(e);
                    ActualizaMapaUbicacion();
                    //_blnSeActivoClosed = false;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Actualiza el combo de localidades 
        /// </summary>
        /// <param name="objListaLocalidades">Lista de localidades que se mostrarán en el control</param>
        private void ActualizaLocalidades(Entidades.LocalidadList objListaLocalidades)
        {
            cbxLocalidad.DataSource = objListaLocalidades;
            cbxLocalidad.DisplayMember = "Nombre";
            cbxLocalidad.ValueMember = "Clave";
            cbxLocalidad.SelectedIndex = -1;
            //cbxLocalidad.Text = string.Empty;
        }

        /// <summary>
        /// Actualiza la lista de colonias del combo correspondiente
        /// </summary>
        /// <param name="lstColonias">Lista de colonias que se van a mostrar en el control</param>
        private void ActualizaColonias(Entidades.ColoniaList lstColonias)
        {
            cbxColonia.DataSource = lstColonias;
            cbxColonia.DisplayMember = "Nombre";
            cbxColonia.ValueMember = "Clave";
            cbxColonia.SelectedIndex = -1;
            //cbxColonia.Text = string.Empty;
        }

        /// <summary>
        /// Actualiza la lista de los códigos postales
        /// </summary>
        /// <param name="objListaCodigosPostales">Lista de los códigos postales que se mostrarán en el control</param>
        private void ActualizarCodigoPostal(Entidades.CodigoPostalList objListaCodigosPostales)
        {
            this.cbxCP.DataSource = objListaCodigosPostales;
            this.cbxCP.DisplayMember = "Valor";
            this.cbxCP.ValueMember = "Clave";
            this.cbxCP.SelectedIndex = -1;
            //this.cbxCP.Text = string.Empty;
        }

        /// <summary>
        /// Limpia el control que contiene la lista de localidades
        /// </summary>
        private void LimpiaLocalidades()
        {
            this.cbxLocalidad.DataSource = null;
            //cmbLocalidad.Items.Clear();
        }

        /// <summary>
        /// Limpia el combo que contiene la lista de colonias
        /// </summary>
        private void LimpiaColonias()
        {
            this.cbxColonia.DataSource = null;
            //cmbColonia.Items.Clear();
        }

        /*
                /// <summary>
                /// Limpia el texto del combo de códigos postales
                /// </summary>
                private void LimpiaTextoCodigoPostal()
                {
                    this.cbxCP.Text = string.Empty;
                }
        */

        /// <summary>
        /// Limpia el combo que contiene los códigos postales
        /// </summary>
        private void LimpiaCodigosPostales()
        {
            this.cbxCP.DataSource = null;
            this.cbxCP.Items.Clear();
            this.cbxCP.Text = string.Empty;
        }

        /*
                /// <summary>
                /// Obtiene el código postal de una colonia especificada.
                /// </summary>
                /// <param name="iCp">int, Id del código postal</param>
                private void LlenarCpPorColonia(int iCp)
                {
                    entCodigoPostal = Mappers.CodigoPostalMapper.Instance().GetOne(iCp);
                    if (entCodigoPostal != null)
                    {
                        objListaCodigosPostales.Clear();
                        this.objListaCodigosPostales.Add(entCodigoPostal);
                        this.ActualizarCodigoPostal(objListaCodigosPostales);
                    }
                }
        */

        /// <summary>
        /// Actualiza las localidades por el municipio seleccionado
        /// </summary>
        private void cbxMunicipioActualizaLocalidades()
        {
            try
            {
                try
                {
                    if (this._blnBloqueaEventos)
                    {
                        return;
                    }
                    this._blnBloqueaEventos = true;
                    //Limpiar localidades y colonias
                    this.LimpiaLocalidades();
                    this.LimpiaColonias();
                    this.LimpiaCodigosPostales();
                    //obtener las localidades del municipio seleccionado
                    Entidades.LocalidadList lstLocalidades =
                        Mappers.LocalidadMapper.Instance().GetByMunicipio(
                            ((Entidades.Municipio)this.cbxMunicipio.SelectedItem).Clave);

                    if (lstLocalidades.Count > 0)
                    {
                        this.ActualizaLocalidades(lstLocalidades);
                    }
                    this._blnBloqueaEventos = false;
                    this.ActualizaMapaUbicacion();
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Selecciona el elemento del combo de codigos postales
        /// </summary>
        /// <param name="objElemento">Elemento que se va a seleccionar</param>
        private void SeleccionaCodigoPostal(Object objElemento)
        {
            //cbxCP.SelectedIndex = -1;
            cbxCP.SelectedItem = objElemento;
        }

        /*
                /// <summary>
                /// Limpia el texto del control del combo de colonias
                /// </summary>
                private void LimpiaTextoColonia()
                {
                    cbxColonia.SelectedIndex = -1;
                    cbxColonia.Text = string.Empty;
                }
        */

        /// <summary>
        /// Valida los controles obligatorios del formulario y cierra el mapa en caso de que ya no existan
        /// más instancias del formulario en memoria.
        /// </summary>
        /// <param name="e">Parámetros del evento</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                try
                {
                    if (!base.SAIProveedorValidacion.ValidarCamposRequeridos(this)) // && !_blnSoloLectura)
                    {
                        if (this.cbxTipoDenuncia.Items.Count != 0)
                        {
                            e.Cancel = true;
                            throw new SAIExcepcion("Debe de indicar el tipo de incidencia", this);
                        }
                        return;
                    }

                    //Mapa.Controlador.RevisaInstancias(this);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Carga las colonias, la localidad y el municipio 
        /// </summary>
        /// <param name="codigoPostal">Codigo Postal a buscar</param>
        private void CargarPorCP(string codigoPostal)
        {
            try
            {
                try
                {
                    //SE OBTIENE LA ENTIDAD DEL CODIGO POSTAL
                    Entidades.CodigoPostal CP =
                        Mappers.CodigoPostalMapper.Instance().GetOneBySQLQuery(
                            "Select Clave, Valor from CodigoPostal where Valor = '" + codigoPostal + "'");
                    //SI EXISTE
                    if (CP != null)
                    {
                        Entidades.CodigoPostalList lstCodigoPostal =
                            new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.CodigoPostalList();
                        lstCodigoPostal.Add(CP);
                        this._blnBloqueaEventos = true;
                        this.ActualizarCodigoPostal(lstCodigoPostal);
                        this.cbxCP.SelectedIndex = 0;
                        this._blnBloqueaEventos = false;
                        //SE OBTIENE LA LOSTA DE COLONIAS POR EL CODIGO POSTAL
                        Entidades.ColoniaList lstColonias = Mappers.ColoniaMapper.Instance().GetByCodigoPostal(CP.Clave);

                        if (lstColonias.Count > 0)
                        {
                            //SE BLOQUEA EVENTO PARA LLENADO DE COLONIAS
                            this._blnBloqueaEventos = true;
                            this.ActualizaColonias(lstColonias);
                            //SE SELECCIONA LA PRIMERA COLONIA
                            //CABE MENCIONAR QUE UN CODIG POSTAL PUEDE CORRESPONDER A VARIAS COLONIAS
                            this.cbxColonia.SelectedIndex = 0;
                            this._blnBloqueaEventos = false;
                            //SE AGREGA LA COLONIA A LA LISTA
                            Entidades.LocalidadList lstLocalidad =
                                new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.LocalidadList();
                            lstLocalidad.Add(
                                Mappers.LocalidadMapper.Instance().GetOne(
                                    ((Entidades.Colonia)this.cbxColonia.Items[0]).ClaveLocalidad));
                            //SE ACTUALIZA LA LISTA DE COLONIAS
                            this._blnBloqueaEventos = true;
                            this.ActualizaLocalidades(lstLocalidad);

                            this.cbxLocalidad.SelectedIndex = 0;

                            Entidades.Localidad localidad =
                                Mappers.LocalidadMapper.Instance().GetOne(
                                    ((Entidades.Localidad)this.cbxLocalidad.SelectedItem).Clave);
                            this.cbxMunicipio.SelectedValue = localidad.ClaveMunicipio;
                            this._blnBloqueaEventos = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Evento que se ejecua cuando se selecciona un CP de la lista, y selecciona la colonia correspondiente
        /// <remarks>
        /// Nota: Como varios Codigos postales pueden pertenecer a una colonia, se selecciona la primera que se encuentre 
        /// en la lista
        /// </remarks>
        /// </summary>
        private void cbxCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.cbxCP.Text.Length == 5)
                    {
                        if (this._blnBloqueaEventos)
                        {
                            return;
                        }
                        if (this.cbxCP.Items.Count > 0 && this.cbxColonia.Items.Count > 0)
                        {
                            if (this.cbxCP.SelectedValue != null)
                            {
                                Entidades.ColoniaList lstColonia =
                                    Mappers.ColoniaMapper.Instance().GetByCodigoPostal(
                                        Convert.ToInt32(this.cbxCP.SelectedValue));
                                if (lstColonia.Count > 0)
                                {
                                    this._blnBloqueaEventos = true;
                                    this.cbxColonia.SelectedValue = lstColonia[0].Clave;
                                    this._blnBloqueaEventos = false;
                                }
                            }
                            this.ActualizaMapaUbicacion();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se presiona una tecla, verifica que el codigo postal este capturado (5 digitos)
        /// y si se pulsa la tecla enter para buscar colonia, localidad y municipio por el cp capturado.
        /// </summary>
        private void cbxCP_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.cbxCP.Text.Length == 5 && e.KeyCode == Keys.Enter)
            {
                string codigop = this.cbxCP.Text;
                try
                {
                    this._blnBloqueaEventos = true;
                    this.cbxCP.DataSource = null;
                    this._blnBloqueaEventos = false;
                }
                catch
                {
                }
                CargarPorCP(codigop);
                this.ActualizaMapaUbicacion();
            }
        }
    }
}