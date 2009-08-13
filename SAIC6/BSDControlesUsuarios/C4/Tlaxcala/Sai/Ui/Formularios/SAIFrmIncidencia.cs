﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

using Mapa = BSD.C4.Tlaxcala.Sai.Mapa;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{

    public delegate void txtDescripcionOnKeyEnterUp(object sender,KeyEventArgs e);


    /// <summary>
    /// El formulario SIAFrmIncidencia contiene la funcionalidad básica que comparten las incidencias
    /// del sistema 089 y 066, por lo tanto éste no es implementado directamente en la aplicación, sino que hereda
    /// hacia el formulario SIAFrmIncidencia089 y SIAFrmIncidencia066
    /// </summary>
    public partial class SAIFrmIncidencia : SAIFrmBase
    {

        protected Incidencia _entIncidencia = new Incidencia();
        public event txtDescripcionOnKeyEnterUp txtDescripcion_OnKeyEnterUp;
        private Boolean _blnLimpiarColonias = false;
        private Mapa.EstructuraUbicacion _objUbicacion = new Mapa.EstructuraUbicacion();
        private Boolean _blnBloqueaEventos;
        protected Boolean _blnSeActivoClosed = false;
        protected Boolean _blnSeDesactivoVentana = false;
        protected PropietarioVehiculoObject _objPropietarioVehiculo = null;
        protected RoboVehiculoAccesorios _entRoboVehiculoAccesorios = null;
        protected VehiculoObject _objVeiculoAccesoriosRobado = null;
        /// <summary>
        /// Lleva el estado del caso de la tecla control presionada.
        /// </summary>
        private bool _blnCtrPresionado = false;

        private Control _ctlSiguiente;
        private Boolean _blnSoloLectura;

        public Boolean  SoloLectura 
        {
            get { return this._blnSoloLectura; } 
            set 
            {
                this._blnSoloLectura = value;

                if (value)
                {
                    foreach (Control objControl in this.Controls)
                    {
                        objControl.Enabled = false;
                    }
                }
                else
                {
                    foreach (Control objControl in this.Controls)
                    {
                        objControl.Enabled = true;
                    }
                }
            } 
        }


        /// <summary>
        /// Constructor del formulario SIAFrmIncidencia, se ejecuta cuando se registra una incidencia nueva
        /// <remarks>El constructor inserta una nueva incidencia en la base de datos y muestra su información en el formulario</remarks>
        /// </summary>
        public SAIFrmIncidencia()
        {
            //El try se puso porque en tiempo de diseño se genera una excepción cuando se abren los formularios hijos
            try
            {
                this._blnBloqueaEventos = true;
                
                InitializeComponent();



                this.InicializaListas();
                //****Crea una nueva incidencia, el formulario se abrió para insertar*******
                this._entIncidencia.Referencias = string.Empty;
                this._entIncidencia.Descripcion = string.Empty;
                this._entIncidencia.Activo = true;
                this._entIncidencia.HoraRecepcion = DateTime.Now;
                this._entIncidencia.ClaveEstatus = 1;
                this._entIncidencia.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;
                IncidenciaMapper.Instance().Insert(this._entIncidencia);

                //*************************************************************************
                //Se actualiza la información de la incidencia en la lista de ventanas
                this.ActualizaVentanaIncidencias();
                //Se muestra la información de la incidencia en el formulario:
                this.InicializaCampos();
                this.SuspendLayout();
                if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                {
                    this.lblDescripcionIncidencia.Text  = "Descripción de  \n la Denuncia:";
                    this.lblTelefono.Visible = false;
                    this.txtTelefono.Visible = false;
                    this.lblTipoIncidencia.Left = lblTelefono.Left-5;
                    this.cmbTipoIncidencia.Left = this.txtTelefono.Left;
                    this.lblTipoIncidencia.Text = "Tipo de \n la Denuncia:";
                    this.lblTipoIncidencia.Top -= 10;

                }
                else
                {
                    this.lblDescripcionIncidencia.Text  = "Descripción de  \n la Incidencia:";
                }
                this.ResumeLayout(false);
                this._blnBloqueaEventos = false;

                Aplicacion.VentanasIncidencias.Add(new SAIWinSwitchItem(this._entIncidencia.Folio.ToString(),"",(this as Form)));

            }
            catch { }
               
        }

        /// <summary>
        /// Constructor que toma la entidad incidencia que se va a mostrar en el formulario
        /// </summary>
        /// <param name="entIncidencia">Entidad incidencia que contiene los valores para mostrar</param>
        public SAIFrmIncidencia(Incidencia entIncidencia)
        {
            this._blnBloqueaEventos = true;
            InitializeComponent();
            this.SuspendLayout();
            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            {
                this.lblDescripcionIncidencia.Text  = "Descripción de  \n la Denuncia:";

            }
            else
            {
                this.lblDescripcionIncidencia.Text  = "Descripción de  \n la Incidencia:";


            }
            this.ResumeLayout(false);
            this.InicializaListas();
            this._entIncidencia = entIncidencia;
            //Se actualiza la información de la incidencia en la lista de ventanas
            this.ActualizaVentanaIncidencias();
            //Se muestra la información de la incidencia en el formulario:
            this.InicializaCampos();
            this._blnBloqueaEventos = false;
            Aplicacion.VentanasIncidencias.Add(new SAIWinSwitchItem(this._entIncidencia.Folio.ToString(), "", (this as Form)));

        }

        /// <summary>
        /// Hace la llamada a la función de la ventana Owner para mostrar el control switch
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && this._blnCtrPresionado)
            {
                if (this.Owner != null)
                {
                    SAIFrmComandos frmPrincipal = (SAIFrmComandos)this.Owner;
                    frmPrincipal.MuestraSwitch();
                }

            }
            this._blnCtrPresionado = false;
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Detecta cuando se presionó la tecla control
        /// </summary>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.ControlKey | Keys.Control))
            {
                this._blnCtrPresionado = true;
            }
            return false;
        }

       

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //Se actualiza el mapa:
            //if (this._blnSeDesactivoVentana)
            //{
                this.actualizaMapaUbicacion();
                this._blnSeDesactivoVentana = false;
            //}
            this._blnSeActivoClosed = false;
        }

        protected override void OnDeactivate(EventArgs e)
        {

            base.OnDeactivate(e);
            this._blnSeDesactivoVentana = true;
        }
        /// <summary>
        /// Recupera la información de los catálogos que se utilizan en el formulario
        /// </summary>
        private void InicializaListas()
        {

            TipoIncidenciaList lstTipoIncidencias;
            MunicipioList lstMunicipios;

            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
            {
                lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(2);
            }
            else
            {
                lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(1);
            }
                
                lstMunicipios = MunicipioMapper.Instance().GetAll();

                this.cmbTipoIncidencia.DataSource = lstTipoIncidencias;
                this.cmbTipoIncidencia.DisplayMember = "Descripcion";
                this.cmbTipoIncidencia.ValueMember = "Clave";

                this.cmbMunicipio.DataSource = lstMunicipios;
                this.cmbMunicipio.DisplayMember = "Nombre";
                this.cmbMunicipio.ValueMember = "Clave";

                this.cmbMunicipio.SelectedIndex = -1;
                this.cmbMunicipio.Text = string.Empty;


                this.cmbMunicipio.AllowDrop = this.cmbTipoIncidencia.AllowDrop;
                this.cmbMunicipio.DropDownStyle = this.cmbTipoIncidencia.DropDownStyle;

          
        }


        /// <summary>
        /// Pone los valores correspondientes en los controles del formulario, según los datos de la incidencia
        /// </summary>
        /// <param name="entIncidencia">Entidad incidencia que contiene la información</param>
        private void InicializaCampos()
        {
            Usuario entUsuario;
            TipoIncidencia entTipoIncidenciaElemento;
            Municipio entMunicipio;

            try
            {

                try
                {
                    entUsuario = UsuarioMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intClaveUsuario);

                    this.lblOperador.Text = entUsuario.NombrePropio;
                    this.lblFechaHora.Text = this._entIncidencia.HoraRecepcion.ToString();
                    this.Text = this._entIncidencia.Folio.ToString();
                    this.txtTelefono.Text = this._entIncidencia.Telefono;
                    this.txtDireccion.Text = this._entIncidencia.Direccion;


                    if (this._entIncidencia.ClaveTipo.HasValue)
                    {
                        foreach (Object elemento in this.cmbTipoIncidencia.Items)
                        {
                            entTipoIncidenciaElemento = (TipoIncidencia)elemento;
                            if (this._entIncidencia.ClaveTipo.Value == entTipoIncidenciaElemento.Clave)
                            {
                                this.cmbTipoIncidencia.SelectedIndex = -1;
                                this.cmbTipoIncidencia.SelectedItem = entTipoIncidenciaElemento;
                                break;
                            }
                        }
                    }

                    if (this._entIncidencia.ClaveEstado.HasValue && this._entIncidencia.ClaveMunicipio.HasValue)
                    {
                        foreach (Object elemento in this.cmbMunicipio.Items)
                        {
                            entMunicipio = (Municipio)elemento;
                            if (this._entIncidencia.ClaveMunicipio.Value == entMunicipio.Clave)
                            {
                                this.cmbMunicipio.SelectedIndex = -1;
                                this.cmbMunicipio.SelectedItem = entMunicipio;
                                break;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

           
        }


        /// <summary>
        /// Actualiza la información en la colección global de ventanas de la incidencia actual
        /// </summary>
        /// <param name="entIncidencia">Entidad incidencia que contiene la información</param>
        private void ActualizaVentanaIncidencias()
        {

            
                for (int i = 0; i < Aplicacion.VentanasIncidencias.Count; i++)
                {
                    if (Aplicacion.VentanasIncidencias[i].Ventana == this)
                    {
                        Aplicacion.VentanasIncidencias[i].Folio = this._entIncidencia.Folio.ToString();
                        if (this._entIncidencia.Descripcion != string.Empty)
                            Aplicacion.VentanasIncidencias[i].Informacion += "Descripción: " + this._entIncidencia.Descripcion;
                        if (this._entIncidencia.ClaveDenunciante.HasValue)
                        {
                            DenuncianteObject objDenunciante = DenuncianteMapper.Instance().GetOne(this._entIncidencia.ClaveDenunciante.Value);
                            if (objDenunciante.Nombre != string.Empty)
                            {
                                Aplicacion.VentanasIncidencias[i].Informacion += "Denunciante: " + objDenunciante.Nombre + " " + objDenunciante.Apellido;
                            }
                        }
                        if (this._entIncidencia.Referencias != string.Empty)
                            Aplicacion.VentanasIncidencias[i].Informacion += "Referencias: " + this._entIncidencia.Referencias;
                    }
                }

        }

        #region Eventos del combo MUNICIPIO
        /// <summary>
        /// Recupera las localidades y los códigos postales del municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            LocalidadList objListaLocalidades;
            ColoniaList objListaColonias;
            CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
            CodigoPostal entCodigoPostal;
            Boolean blnExisteCodigoPostal;

            if (this._blnBloqueaEventos == true)
            {
                return;
            }

            this._blnBloqueaEventos = true;

            this.cmbLocalidad.DataSource = null;
            this.cmbLocalidad.Items.Clear();
            this.cmbColonia.DataSource = null;
            this.cmbColonia.Items.Clear();
            this.cmbCP.DataSource = null;
            this.cmbCP.Items.Clear();

            objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio((this.cmbMunicipio.SelectedItem as Municipio).Clave);
            if (objListaLocalidades.Count > 0)
            {
                    this.cmbLocalidad.DataSource = objListaLocalidades;
                    this.cmbLocalidad.DisplayMember = "Nombre";
                    this.cmbLocalidad.ValueMember = "Clave";
                    this.cmbLocalidad.SelectedIndex = -1;
                    this.cmbLocalidad.Text  = string.Empty;

                    //Se recuperan los códigos postales del municipio
                    for (int i = 0; i < objListaLocalidades.Count; i++)
                    {
                        objListaColonias = ColoniaMapper.Instance().GetByLocalidad(objListaLocalidades[i].Clave);
                        for (int j = 0; j < objListaColonias.Count; j++)
                        {
                            if (objListaColonias[j].ClaveCodigoPostal.HasValue)
                            {
                                entCodigoPostal = CodigoPostalMapper.Instance().GetOne(objListaColonias[j].ClaveCodigoPostal.Value );
                                blnExisteCodigoPostal = false;
                                //Se revisa que el código postal no exista en la lista
                                for (int k = 0; k < objListaCodigosPostales.Count; k++)
                                {
                                    if (objListaCodigosPostales[k].Valor == entCodigoPostal.Valor)
                                    {
                                        blnExisteCodigoPostal = true;
                                        break;
                                    }
                                }

                                if (!blnExisteCodigoPostal)
                                {
                                    objListaCodigosPostales.Add(entCodigoPostal);
                                }
                            }
                        }
                        
                    }

                    if (objListaCodigosPostales.Count > 0)
                    {
                        this.cmbCP.DataSource = objListaCodigosPostales;
                        this.cmbCP.DisplayMember = "Valor";
                        this.cmbCP.ValueMember = "Clave";
                        this.cmbCP.SelectedIndex = -1;
                        this.cmbCP.Text = string.Empty;
                    }

                }
              

            this._blnBloqueaEventos = false;
            this.actualizaMapaUbicacion();
        }

        /// <summary>
        /// Guarda la incidencia con el municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_Leave(object sender, EventArgs e)
        {
           

            if (this.cmbMunicipio.SelectedIndex == -1 || this.cmbMunicipio.Text.Trim() == string.Empty)
            {
               this.cmbLocalidad.DataSource = null;
               this.cmbLocalidad.Items.Clear();
               this.cmbColonia.DataSource = null;
               this.cmbColonia.Items.Clear();
            }
            
            this.actualizaMapaUbicacion();
            if (!this._blnSeActivoClosed)
            {
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        /// <summary>
        /// Actualiza el mapa cuando cambia el texto de la lista de municipios
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_TextUpdate(object sender, EventArgs e)
        {
            this.actualizaMapaUbicacion();
        }

        /// <summary>
        /// Manda el foco del campo Municipio al campo Localidad cuando se presiona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbLocalidad.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }
        #endregion

        #region Eventos del combo LOCALIDAD
        /// <summary>
        /// Recupera las colonias de la localidad seleccionada
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ColoniaList lstColonias;

            if (this._blnBloqueaEventos == true)
            {
                return;
            }

            this._blnBloqueaEventos = true;
            
            this.cmbColonia.DataSource = null;
            this.cmbColonia.Items.Clear();
            
            lstColonias = ColoniaMapper.Instance().GetByLocalidad((this.cmbLocalidad.SelectedItem as Localidad).Clave);
            
            if (lstColonias.Count > 0)
            {
                 this.cmbColonia.DataSource = lstColonias;
                 this.cmbColonia.DisplayMember = "Nombre";
                 this.cmbColonia.ValueMember = "Clave";
                 this.cmbColonia.Text = String.Empty;
                 this.cmbCP.Text = string.Empty;
            }
            

            this._blnBloqueaEventos = false;
            this.actualizaMapaUbicacion();
           
        }

        /// <summary>
        /// Actualiza el mapa cuando cambia el texto del combo de localidad
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_TextUpdate(object sender, EventArgs e)
        {
            this.actualizaMapaUbicacion();
        }

        /// <summary>
        /// Manda el foco del campo Localidad al campo Codigo postal cuando se presiona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbCP.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }


        /// <summary>
        /// Guarda la incidencia con la localidad seleccionada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_Leave(object sender, EventArgs e)
        {
            if (this.cmbLocalidad.SelectedIndex == -1 || this.cmbLocalidad.Text.Trim() == string.Empty)
            {
                this.cmbColonia.DataSource = null;
                this.cmbColonia.Items.Clear();
            }
            this.actualizaMapaUbicacion();
            if (!this._blnSeActivoClosed)
            {
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        #endregion

        #region Eventos del combo COLONIA
        /// <summary>
        /// Selecciona el código postal del combo de códigos postales según la colonia seleccionada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Colonia entColonia = null;

            if (this._blnBloqueaEventos == true)
            {
                return;
            }

            this._blnBloqueaEventos = true;
            if (this.cmbColonia.SelectedIndex != -1 && this.cmbColonia.Text.Trim() != string.Empty)
            {
                entColonia = (Colonia)this.cmbColonia.SelectedItem;

                if (entColonia.ClaveCodigoPostal.HasValue)
                {
                    this._entIncidencia.ClaveCodigoPostal = entColonia.ClaveCodigoPostal.Value;
                    foreach (var objElemento in this.cmbCP.Items)
                    {
                        if ((objElemento as CodigoPostal).Clave == entColonia.ClaveCodigoPostal)
                        {
                            
                            this._blnLimpiarColonias = false;
                            this.cmbCP.SelectedIndex = -1;
                            this.cmbCP.SelectedItem = objElemento;
                           
                            break;
                        }
                    }
                }
                else
                {
                    this._entIncidencia.ClaveCodigoPostal = null;
                }
                this._entIncidencia.ClaveColonia = entColonia.Clave;
            }
            else
            {
                this._entIncidencia.ClaveColonia = null;
            }

            this._blnBloqueaEventos = false;
            this.actualizaMapaUbicacion();
          
        }

        /// <summary>
        /// Guarda la incidencia con la colonia seleccionada y guarda la colonia en caso de ser una colonia nueva
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbColonia_Leave(object sender, EventArgs e)
        {
            Colonia entColonia = null;
            ColoniaList lstColonias;
            CodigoPostal entCP;
            Localidad entLoc;

            this._blnBloqueaEventos = true;

            if (this.cmbColonia.SelectedIndex == -1 && this.cmbColonia.Text.Trim() != string.Empty)
            {

                //Se revisa que sea una colonia nueva:
                lstColonias = ColoniaMapper.Instance().GetAll();
                for (int i = 0; i < lstColonias.Count; i++)
                {
                    if (this.cmbColonia.Text.Trim().ToLower().Replace(" ", "").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u") ==
                        lstColonias[i].Nombre.ToLower().Replace(" ", "").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u"))
                    {
                        entColonia = lstColonias[i];
                        break;
                    }
                }
                //Si entColonia es nulo, entonces se trata de una nueva colonia:
                if (entColonia == null && this.cmbLocalidad.SelectedIndex != -1 && this.cmbCP.SelectedIndex != -1)
                {
                    if (MessageBox.Show("La colonia indicada no se encuentra en la base de datos. ¿Desea Agregarla?", "SAI C4", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        entColonia = new Colonia();
                        entCP = (CodigoPostal)this.cmbCP.SelectedItem;
                        entLoc = (Localidad)this.cmbLocalidad.SelectedItem;
                        entColonia.ClaveCodigoPostal = entCP.Clave;
                        entColonia.ClaveLocalidad = entLoc.Clave;
                        entColonia.Nombre = this.cmbColonia.Text;
                        ColoniaMapper.Instance().Insert(entColonia);
                        MessageBox.Show("La colonia se registró satisfactoriamente");
                        lstColonias = ColoniaMapper.Instance().GetByLocalidad(entLoc.Clave);
                        if (lstColonias.Count > 0)
                        {
                            this.cmbColonia.DataSource = lstColonias;
                            this.cmbColonia.DisplayMember = "Nombre";
                            this.cmbColonia.ValueMember = "Clave";
                        }
                        else
                        {
                            this.cmbColonia.DataSource = null;
                            this.cmbColonia.Items.Clear();
                        }
                    }
                    else
                    {
                       this.cmbColonia.Text = string.Empty;
                    }
                }
                else if (entColonia != null)
                {
                     if (entColonia.ClaveCodigoPostal.HasValue)
                    {
                       foreach (var objElemento in this.cmbCP.Items)
                        {
                            if ((objElemento as CodigoPostal).Clave == entColonia.ClaveCodigoPostal)
                            {
                                this.cmbCP.SelectedIndex = -1;
                                this.cmbCP.SelectedItem = objElemento;
                                break;
                            }
                        }
                    }
                }
            }
            else if (this.cmbColonia.Text.Trim() != string.Empty)
            {
                entColonia = (Colonia)this.cmbColonia.SelectedItem;
                if (entColonia.ClaveCodigoPostal.HasValue)
                {
                    foreach (var objElemento in this.cmbCP.Items)
                    {
                        if ((objElemento as CodigoPostal).Clave == entColonia.ClaveCodigoPostal)
                        {
                            this.cmbCP.SelectedIndex = -1;
                            this.cmbCP.SelectedItem = objElemento;
                            break;
                        }
                    }
                }
            }
            this._blnBloqueaEventos = false;
            this.actualizaMapaUbicacion();
            if (!this._blnSeActivoClosed)
            {
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        /// <summary>
        /// Manda el foco del campo Colonia al campo Descripción cuando se presiona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbColonia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDescripcion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }

        /// <summary>
        /// Actualiza el mapa cuando cambia el texto del como colonia
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbColonia_TextUpdate(object sender, EventArgs e)
        {
            this.actualizaMapaUbicacion();
        }

        #endregion

        #region Eventos del combo CP

        /// <summary>
        /// Quita la selección de la colonia
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._blnBloqueaEventos == true)
            {
                return;
            }

            this._blnBloqueaEventos = true;
            if (this._blnLimpiarColonias)
            {
                this.cmbColonia.SelectedIndex = -1;
                this.cmbColonia.Text = string.Empty;
            }
            this._blnBloqueaEventos = false;

            if (this.cmbCP.SelectedIndex != -1 && this.cmbCP.Text.Trim() != string.Empty)
            {
                this._entIncidencia.ClaveCodigoPostal  = (this.cmbCP.SelectedItem as CodigoPostal).Clave;
            }
            else
            {
                this._entIncidencia.ClaveCodigoPostal = null;
            }

           

            this.actualizaMapaUbicacion();
        }

        /// <summary>
        /// Guarda la incidencia con el código postal seleccionado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_Leave(object sender, EventArgs e)
        {
            this.actualizaMapaUbicacion();
            if (!this._blnSeActivoClosed)
            {
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        /// <summary>
        /// Manda el foco del campo Código Postal al campo Colonia cuando se presiona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbColonia.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }

        /// <summary>
        /// Actualiza el mapa cuando se cambia el texto de la lista de códigos postales
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_TextUpdate(object sender, EventArgs e)
        {
            this.actualizaMapaUbicacion();

        }


#endregion

        /// <summary>
        /// Manda el foco del campo teléfono al campo Tipo Incidencia cuando se presiona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámentros del evento</param>
        private void txtTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbTipoIncidencia.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }


        /// <summary>
        /// Manda el foco del campo Tipo Incidencia al campo Dirección cuando se presona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbTipoIncidencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDireccion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }

        /// <summary>
        /// Manda el foco del campo Direccion al campo Municipio cuando se presiona y se suelta la tecla intro
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbMunicipio.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }

        private void txtReferencias_KeyUp(object sender, KeyEventArgs e)
        {

        }
       


        /// <summary>
        /// Lanza el evento txtDescripcion_OnKeyEnterUp cuando se presona y suelta la tecla intro en el campo descripcion
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtDescripcion_OnKeyEnterUp != null && this._ctlSiguiente != null)
            {
                this._ctlSiguiente.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);

        }


        


        /// <summary>
        /// Se ejecuta cuando se cierra el formulario
        /// </summary>
        /// <param name="e">Parámetros del evento</param>
        protected override void OnClosing(CancelEventArgs e)
        {
                        
            if (!base.SAIProveedorValidacion.ValidarCamposRequeridos(this))
            {
                e.Cancel = true;

                throw new SAIExcepcion("Debe de indicar el tipo de incidencia",this);
                return;

            }

            Mapa.Controlador.RevisaInstancias(this);
        }

       

        

        /// <summary>
        /// Quita el elemento de la lista de ventanas cuando la ventana ya se ha cerrado
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            this._blnSeActivoClosed = true;
            try
            {
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
            catch { }
           
            base.OnClosed(e);
            foreach(SAIWinSwitchItem objVentanaSwitch in Aplicacion.VentanasIncidencias)
            {
                if (this == objVentanaSwitch.Ventana)
                {
                    Aplicacion.VentanasIncidencias.Remove(objVentanaSwitch);
                    break;
                }
            }
        }

        /// <summary>
        /// Prende la bandera que indica que se puede limpiar el texto de la lista de colonias
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_Enter(object sender, EventArgs e)
        {
            this._blnLimpiarColonias = true;
        }

        /// <summary>
        /// Recupera los datos de la incidencia que están en el formulario y los guarda en la BD.
        /// </summary>
        protected  void GuardaIncidencia()
        {
            if (this._entIncidencia != null)
            {
               
                IncidenciaMapper.Instance().Save(this._entIncidencia);
            }
        }

        /// <summary>
        /// Recupera los datos del formulario en el objeto de incidencia
        /// </summary>
        protected void RecuperaDatosEnIncidencia()
        {
            if (this._entIncidencia != null)
            {
                if (this.cmbMunicipio.SelectedIndex == -1 || this.cmbMunicipio.Text.Trim() == string.Empty)
                {
                    this._entIncidencia.ClaveMunicipio = null;
                }
                else
                {
                    this._entIncidencia.ClaveMunicipio = this._objUbicacion.IdMunicipio;
                }
                if (this.cmbLocalidad.SelectedIndex == -1 || this.cmbLocalidad.Text.Trim() == string.Empty)
                {
                    this._entIncidencia.ClaveLocalidad = null;
                }
                else
                {
                    this._entIncidencia.ClaveLocalidad = this._objUbicacion.IdLocalidad;
                }
                if (this.cmbColonia.SelectedIndex == -1 || this.cmbColonia.Text.Trim() == string.Empty)
                {
                    this._entIncidencia.ClaveColonia = null;
                }
                else
                {
                    this._entIncidencia.ClaveColonia = this._objUbicacion.IdColonia;
                }
                if (this.cmbCP.SelectedIndex == -1 || this.cmbCP.Text.Trim() == string.Empty)
                {
                    this._entIncidencia.ClaveCodigoPostal = null;
                }
                else
                {
                    this._entIncidencia.ClaveCodigoPostal = this._objUbicacion.IdCodigoPostal;
                }
                this._entIncidencia.Telefono = this.txtTelefono.Text;
                if (this.cmbTipoIncidencia.SelectedIndex != -1 && this.cmbTipoIncidencia.Text.Trim() != string.Empty)
                {
                    this._entIncidencia.ClaveTipo = (this.cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave;

                }
                else
                {
                    this._entIncidencia.ClaveTipo = null;
                }
                this._entIncidencia.Descripcion = this.txtDescripcion.Text;
                this._entIncidencia.Direccion = this.txtDireccion.Text;
            }
           
        }


        /// <summary>
        /// Actualiza el mapa con los datos de la ubicación del formulario actuales
        /// </summary>
        private void actualizaMapaUbicacion()
        {
            
               if (this.cmbMunicipio.SelectedIndex == -1 || this.cmbMunicipio.Text.Trim() == string.Empty)
                {
                    this._objUbicacion.IdMunicipio = null;
                }
                else
                {
                    this._objUbicacion.IdMunicipio = (this.cmbMunicipio.SelectedItem as Municipio).Clave;
                }

                if (this.cmbLocalidad.SelectedIndex == -1 || this.cmbLocalidad.Text.Trim() == string.Empty)
                {
                    this._objUbicacion.IdLocalidad = null;
                }
                else
                {
                    this._objUbicacion.IdLocalidad = (this.cmbLocalidad.SelectedItem as Localidad).Clave;
                }

                if (this.cmbColonia.SelectedIndex == -1 || this.cmbColonia.Text.Trim() == string.Empty)
                {
                    this._objUbicacion.IdColonia = null;
                }
                else
                {
                    this._objUbicacion.IdColonia = (this.cmbColonia.SelectedItem as Colonia).Clave;
                   
                }

                if (this.cmbCP.SelectedIndex == -1 || this.cmbCP.Text.Trim() == string.Empty)
                {
                    this._objUbicacion.IdCodigoPostal = null;
                }
                else
                {
                    this._objUbicacion.IdCodigoPostal = (this.cmbCP.SelectedItem as CodigoPostal).Clave;
                    
                }
            

            Mapa.Controlador.MuestraMapa(this._objUbicacion, this);
        }

        /// <summary>
        /// Guarda la incidencia con el teléfono actualizado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            this._entIncidencia.Telefono  = this.txtTelefono.Text;
            if (!this._blnSeActivoClosed)
            {
                this.GuardaIncidencia();
            }
        }

        /// <summary>
        /// Guarda la incidencia con el tipo de incidencia actualizado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbTipoIncidencia_Leave(object sender, EventArgs e)
        {
            if (this.cmbTipoIncidencia.SelectedIndex != -1 && this.cmbTipoIncidencia.Text.Trim() != string.Empty)
            {
                this._entIncidencia.ClaveTipo = (this.cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave; 
            }
            else
            {
                this._entIncidencia.ClaveTipo = null;
            }
            if (!this._blnSeActivoClosed)
            {
                this.GuardaIncidencia();
            }
        }

        /// <summary>
        /// Guarda la incidencia con la descripción de la incidencia actualizada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            this._entIncidencia.Descripcion = this.txtDescripcion.Text;
            if (!this._blnSeActivoClosed)
            {
                this.GuardaIncidencia();

                //Se actualiza la información de la incidencia en la ventana switch

                foreach (SAIWinSwitchItem objSwitch in Aplicacion.VentanasIncidencias)
                {
                    if ((this as Form) == objSwitch.Ventana)
                    {
                        objSwitch.Informacion = this.txtDescripcion.Text;
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// Guarda la incidencia con la dirección de la incidencia actualizada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            this._entIncidencia.Direccion  = this.txtDireccion.Text;
            if (!this._blnSeActivoClosed)
            {
                this.GuardaIncidencia();
            }
        }

        private void txtReferencias_Leave(object sender, EventArgs e)
        {
            this._entIncidencia.Referencias = this.txtReferencias.Text;
            if (!this._blnSeActivoClosed)
            {
                this.GuardaIncidencia();
            }
        }



        protected void SAIFrmIncidenciaKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && this._blnCtrPresionado)
            {
                if (this.Owner != null)
                {
                    SAIFrmComandos frmPrincipal = (SAIFrmComandos)this.Owner;
                    frmPrincipal.MuestraSwitch();
                }

            }
            this._blnCtrPresionado = false;
        }

        private void cmbTipoIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Aplicacion.UsuarioPersistencia.blnEsDespachador.HasValue && Aplicacion.UsuarioPersistencia.blnEsDespachador.Value == true)
            {
                return;
            }

            if (this.cmbTipoIncidencia.SelectedIndex != -1 && this.cmbTipoIncidencia.Text.Trim() != string.Empty)
            {
                TipoIncidencia objTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia);

                if (objTipo.Descripcion.ToUpper().Contains("ROBO") && objTipo.Descripcion.ToUpper().Contains("VEHICULO") && !objTipo.Descripcion.ToUpper().Contains("ACCESORIOS"))
                {
                    this.SuspendLayout();
                    this.grpExtravio.Visible = false;
                    this.grpRoboVehiculo.Visible = true;
                    this.grpRoboAccesorios.Visible = false;

                   
                    this.grpRoboAccesorios.SuspendLayout();
                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                    {

                        this.Height = 720;
                        this.Width = 600;
                        this.grpRoboVehiculo.Top = 425;
                       

                    }
                    else
                    {
                        this.Height = 830;
                        this.Width = 600;
                        this.grpRoboVehiculo.Top = 534;
                    
                    }
                    this.grpRoboVehiculo.Left = 10;
                    this.grpRoboVehiculo.Refresh();
                    this.grpRoboAccesorios.ResumeLayout(true);

                    this.ResumeLayout(false);
                    this.PerformLayout();
                }
                else if (objTipo.Descripcion.ToUpper().Contains("ROBO") && objTipo.Descripcion.ToUpper().Contains("ACCESORIOS"))
                {
                    this.SuspendLayout();
                    this.grpExtravio.Visible = false;
                    this.grpRoboVehiculo.Visible = false;
                    
                    this.grpRoboAccesorios.SuspendLayout();
                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                    {
                        this.Height = 720;
                        this.Width = 600;
                        this.grpRoboAccesorios.Top = 425;
                    }
                    else
                    {
                        this.Height = 830;
                        this.Width = 600;
                        this.grpRoboAccesorios.Top = 534;
                    }
                    this.grpRoboAccesorios.Left = 10;
                    this.grpRoboAccesorios.Refresh();
                    this.grpRoboAccesorios.ResumeLayout(true);
                    this.grpRoboAccesorios.Visible = true;

                    this.ResumeLayout(false);
                    this.PerformLayout();

                }
                else if ((objTipo.Descripcion.ToUpper().Contains("EXTRAVÍO") && objTipo.Descripcion.ToUpper().Contains("PERSONA")) || (objTipo.Descripcion.ToUpper().Contains("EXTRAVIO") && objTipo.Descripcion.ToUpper().Contains("PERSONA")))
                {
                    this.SuspendLayout();
                    this.grpExtravio.Visible = true;
                    this.grpRoboVehiculo.Visible = false;
                    this.grpRoboAccesorios.Visible = false;
                   
                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                    {
                        this.Height = 720;
                        this.Width = 600;
                        this.grpExtravio.Top = 425;
                    }
                    else
                    {
                        this.Height = 830;
                        this.Width = 600;
                        this.grpExtravio.Top = 534;
                    }
                    this.grpExtravio.Left = 10;
                    this.ResumeLayout(false);
                    this.PerformLayout();

                }
                else
                {
                    this.SuspendLayout();
                    this.grpExtravio.Visible = false;
                    this.grpRoboVehiculo.Visible = false;
                    this.grpRoboAccesorios.Visible = false;
                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                    {
                        this.Height = 485;
                        this.Width = 600;
                       
                    }
                    else
                    {
                        this.Height = 630;
                        this.Width = 600;
                       
                    }
                    this.ResumeLayout(false);
                    this.PerformLayout();

                }
                

            }
        }

        private void grpExtravio_Enter(object sender, EventArgs e)
        {

        }

        private void saiTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccesoriosRobados_TextChanged(object sender, EventArgs e)
        {

        }

        private void SAIFrmIncidencia_Load(object sender, EventArgs e)
        {

        }

       
        private void dgvPersonaExtraviada_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Boolean blnExiste = false;
            PersonaExtraviada entPersonaExtraviada = new PersonaExtraviada();

           
            try
            {
                if (this._entIncidencia == null)
                {
                    this.dgvPersonaExtraviada.Rows.Clear();
                    throw new SAIExcepcion("No es posible registrar personas extraviadas", this);
                }


                if (!(this.dgvPersonaExtraviada[0,e.RowIndex].Value  == null))
                {
                    blnExiste = true;
                    int Clave = int.Parse(this.dgvPersonaExtraviada[0, e.RowIndex].Value.ToString());
                    entPersonaExtraviada = PersonaExtraviadaMapper.Instance().GetOne((Clave));
                }

                entPersonaExtraviada.FechaExtravio = DateTime.Now;

                switch (e.ColumnIndex)
                {
                    case 0: //Calve
                        break;
                    case 1: //Folio
                        break;
                    case 2: //Nombre
                        String strNombre;
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            strNombre = e.FormattedValue.ToString();
                            strNombre = strNombre.ToUpper();
                            if (strNombre.Length > 250)
                            {
                                strNombre = strNombre.Substring(0, 250);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strNombre;
                            entPersonaExtraviada.Nombre = strNombre;
                        }

                        break;
                    case 3: //Edad
                        int intEdad;
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            try
                            {
                                intEdad = int.Parse(e.FormattedValue.ToString());
                                if (intEdad <= 0)
                                {
                                    dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                    e.Cancel = true;
                                    throw new SAIExcepcion("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", this);
                                }
                                entPersonaExtraviada.Edad = intEdad;
                            }
                            catch
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                e.Cancel = true;
                                throw new SAIExcepcion("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", this);
                            }
                        }

                        break;
                    case 4: //Sexo
                        String strSexo;
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            strSexo = e.FormattedValue.ToString();
                            strSexo = strSexo.ToUpper();
                            if (strSexo != "F" && strSexo != "M")
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                e.Cancel = true;
                                throw new SAIExcepcion("El valor del sexo no se encuentra en el formato correcto, debe de ser F (Femenino) y M (Masculino)", this);
                            }

                            dgvPersonaExtraviada.CurrentCell.Value = strSexo;
                            entPersonaExtraviada.Sexo = strSexo;
                        }

                        break;
                    case 5://Estatura
                        float fltEstatura;
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            try
                            {
                                fltEstatura = float.Parse(e.FormattedValue.ToString());
                                if (fltEstatura <= 0)
                                {
                                    dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                    dgvPersonaExtraviada.Refresh();
                                    e.Cancel = true;
                                    throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
                                }
                                entPersonaExtraviada.Estatura = fltEstatura;
                            }
                            catch
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                dgvPersonaExtraviada.Refresh();
                                e.Cancel = true;
                                throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
                            }
                        }
                        break;
                    case 6: //Parentesco

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strParentesco;
                            strParentesco = e.FormattedValue.ToString();
                            strParentesco = strParentesco.ToUpper();
                            if (strParentesco.Length > 15)
                            {
                                strParentesco = strParentesco.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strParentesco;
                            entPersonaExtraviada.Parentesco = strParentesco;
                        }

                        break;
                    case 7://Fecha de extravío
                        DateTime dtmFecha;
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            try
                            {
                                dtmFecha = DateTime.Parse(e.FormattedValue.ToString());
                                if (dtmFecha > DateTime.Today)
                                {
                                    dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                    e.Cancel = true;
                                    throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                                }
                                entPersonaExtraviada.FechaExtravio = dtmFecha;
                            }
                            catch
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                e.Cancel = true;
                                throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                            }
                        }
                        break;
                    case 8:// Tez

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strTez;
                            strTez = e.FormattedValue.ToString();
                            strTez = strTez.ToUpper();
                            if (strTez.Length > 50)
                            {
                                strTez = strTez.Substring(0, 50);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strTez;
                            entPersonaExtraviada.Tez = strTez;
                        }

                        break;
                    case 9://Tipo cabello

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strTipoCabello;
                            strTipoCabello = e.FormattedValue.ToString();
                            strTipoCabello = strTipoCabello.ToUpper();
                            if (strTipoCabello.Length > 15)
                            {
                                strTipoCabello = strTipoCabello.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strTipoCabello;
                            entPersonaExtraviada.TipoCabello = strTipoCabello;
                        }

                        break;
                    case 10://Color cabello

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strColorCabello;
                            strColorCabello = e.FormattedValue.ToString();
                            strColorCabello = strColorCabello.ToUpper();
                            if (strColorCabello.Length > 15)
                            {
                                strColorCabello = strColorCabello.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strColorCabello;
                            entPersonaExtraviada.ColorCabello = strColorCabello;
                        }

                        break;
                    case 11://Largo cabello

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strLargoCabello;
                            strLargoCabello = e.FormattedValue.ToString();
                            strLargoCabello = strLargoCabello.ToUpper();
                            if (strLargoCabello.Length > 15)
                            {
                                strLargoCabello = strLargoCabello.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strLargoCabello;
                            entPersonaExtraviada.LargoCabello = strLargoCabello;
                        }

                        break;
                    case 12://Frente

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strFrente;
                            strFrente = e.FormattedValue.ToString();
                            strFrente = strFrente.ToUpper();
                            if (strFrente.Length > 15)
                            {
                                strFrente = strFrente.Substring(0, 15);
                            }

                            dgvPersonaExtraviada.CurrentCell.Value = strFrente;
                            entPersonaExtraviada.Frente = strFrente;
                        }

                        break;
                    case 13://Cejas

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strCejas;
                            strCejas = e.FormattedValue.ToString();
                            if (strCejas.Length > 15)
                            {
                                strCejas = strCejas.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strCejas.ToUpper();
                            entPersonaExtraviada.Cejas = strCejas;
                        }

                        break;
                    case 14:// Color de ojos

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strColorOjos;
                            strColorOjos = e.FormattedValue.ToString();
                            strColorOjos = strColorOjos.ToUpper();
                            if (strColorOjos.Length > 15)
                            {
                                strColorOjos = strColorOjos.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strColorOjos;
                            entPersonaExtraviada.OjosColor = strColorOjos;
                        }

                        break;
                    case 15:// tamaño de boca

                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strTamañoBoca;
                            strTamañoBoca = e.FormattedValue.ToString();
                            strTamañoBoca = strTamañoBoca.ToUpper();
                            if (strTamañoBoca.Length > 15)
                            {
                                strTamañoBoca = strTamañoBoca.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strTamañoBoca;
                            entPersonaExtraviada.BocaTamaño = strTamañoBoca;
                        }

                        break;
                    case 16:// labios
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strLabios;
                            strLabios = e.FormattedValue.ToString();
                            strLabios = strLabios.ToUpper();
                            if (strLabios.Length > 15)
                            {
                                strLabios = strLabios.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strLabios;
                            entPersonaExtraviada.Labios = strLabios;
                        }
                        break;
                    case 17:// vestimenta
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strVestimenta;
                            strVestimenta = e.FormattedValue.ToString();
                            strVestimenta = strVestimenta.ToUpper();
                            if (strVestimenta.Length > 250)
                            {
                                strVestimenta = strVestimenta.Substring(0, 250);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strVestimenta;
                            entPersonaExtraviada.Vestimenta = strVestimenta;
                        }
                        break;
                    case 18:// destino
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strDestino;
                            strDestino = e.FormattedValue.ToString();
                            strDestino = strDestino.ToUpper();
                            if (strDestino.Length > 250)
                            {
                                strDestino = strDestino.Substring(0, 250);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strDestino;
                            entPersonaExtraviada.Destino = strDestino;
                        }
                        break;
                    case 19:// caracteristicas
                        if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                        {
                            String strCaracteristicas;
                            strCaracteristicas = e.FormattedValue.ToString();
                            strCaracteristicas = strCaracteristicas.ToUpper();
                            if (strCaracteristicas.Length > 250)
                            {
                                strCaracteristicas = strCaracteristicas.Substring(0, 250);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strCaracteristicas;
                            entPersonaExtraviada.Caracteristicas = strCaracteristicas;
                        }
                        break;
                }

                entPersonaExtraviada.Folio = this._entIncidencia.Folio;

                try
                {
                    if (blnExiste)
                    {
                        PersonaExtraviadaMapper.Instance().Save(entPersonaExtraviada);
                    }
                    else
                    {
                        PersonaExtraviadaMapper.Instance().Insert(entPersonaExtraviada);
                        dgvPersonaExtraviada[0, e.RowIndex].Value = entPersonaExtraviada.Clave;
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void dgvPersonaExtraviada_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void txtNombrePropietario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTelefonoPropietario.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtNombrePropietario_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._objPropietarioVehiculo == null)
                    {
                        this._objPropietarioVehiculo = new PropietarioVehiculoObject();
                        this._objPropietarioVehiculo.Nombre = this.txtNombrePropietario.Text;
                        PropietarioVehiculoMapper.Instance().Insert(this._objPropietarioVehiculo);
                    }
                    else
                    {
                        this._objPropietarioVehiculo.Nombre = this.txtNombrePropietario.Text;
                        PropietarioVehiculoMapper.Instance().Save(this._objPropietarioVehiculo);
                    }
                    //Se revisa si ya hay vehículos para este folio y se actualizan con el id del propietario:
                    VehiculoRobadoObjectList ListaVehiculos = VehiculoRobadoMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    foreach (VehiculoRobadoObject objVehiculo in ListaVehiculos)
                    {
                        objVehiculo.ClavePropietario = this._objPropietarioVehiculo.Clave;
                    }
                    if (ListaVehiculos.Count > 0)
                    {
                        VehiculoRobadoMapper.Instance().Update(ListaVehiculos);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

        }

        private void txtTelefonoPropietario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDireccionPropietario.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtTelefonoPropietario_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._objPropietarioVehiculo == null)
                    {
                        this._objPropietarioVehiculo = new PropietarioVehiculoObject();
                        this._objPropietarioVehiculo.Telefono  = this.txtTelefono.Text;
                        PropietarioVehiculoMapper.Instance().Insert(this._objPropietarioVehiculo);
                    }
                    else
                    {
                        this._objPropietarioVehiculo.Telefono = this.txtTelefono.Text;
                        PropietarioVehiculoMapper.Instance().Save(this._objPropietarioVehiculo);
                    }
                    //Se revisa si ya hay vehículos para este folio y se actualizan con el id del propietario:
                    VehiculoRobadoObjectList ListaVehiculos = VehiculoRobadoMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    foreach (VehiculoRobadoObject objVehiculo in ListaVehiculos)
                    {
                        objVehiculo.ClavePropietario = this._objPropietarioVehiculo.Clave;
                    }
                    if (ListaVehiculos.Count > 0)
                    {
                        VehiculoRobadoMapper.Instance().Update(ListaVehiculos);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

       
        private void txtDireccionPropietario_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._objPropietarioVehiculo == null)
                    {
                        this._objPropietarioVehiculo = new PropietarioVehiculoObject();
                        this._objPropietarioVehiculo.Domicilio = this.txtDireccionPropietario.Text;
                        PropietarioVehiculoMapper.Instance().Insert(this._objPropietarioVehiculo);
                    }
                    else
                    {
                        this._objPropietarioVehiculo.Telefono = this.txtTelefono.Text;
                        this._objPropietarioVehiculo.Domicilio = this.txtDireccionPropietario.Text;
                        PropietarioVehiculoMapper.Instance().Save(this._objPropietarioVehiculo);
                    }
                    //Se revisa si ya hay vehículos para este folio y se actualizan con el id del propietario:
                    VehiculoRobadoObjectList ListaVehiculos = VehiculoRobadoMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    foreach (VehiculoRobadoObject objVehiculo in ListaVehiculos)
                    {
                        objVehiculo.ClavePropietario = this._objPropietarioVehiculo.Clave;
                    }
                    if (ListaVehiculos.Count > 0)
                    {
                        VehiculoRobadoMapper.Instance().Update(ListaVehiculos);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dgvVehiculo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Boolean blnExiste = false;
            VehiculoObject  objVehiculo = new VehiculoObject();

           
            try
            {
                if (this._entIncidencia == null)
                {
                    this.dgvVehiculo.Rows.Clear();
                    throw new SAIExcepcion("No es posible registrar vehiculos robados", this);
                }
                try
                  {
                      if (!(this.dgvVehiculo[0, e.RowIndex].Value == null))
                      {
                          blnExiste = true;
                          int Clave = int.Parse(this.dgvVehiculo[0, e.RowIndex].Value.ToString());
                          objVehiculo = VehiculoMapper.Instance().GetOne((Clave));
                      }
                      switch (e.ColumnIndex)
                      {
                          case 0: //Clave
                              break;
                          case 1: //Marca
                              
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strMarca;
                                  strMarca = e.FormattedValue.ToString();
                                  if (strMarca.Length > 50)
                                  {
                                      strMarca = strMarca.Substring(0, 50);
                                  }
                                  strMarca = strMarca.ToUpper();
                                  dgvVehiculo.CurrentCell.Value = strMarca;
                                  objVehiculo.Marca = strMarca;
                              }
                              break;
                          case 2://Tipo
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strTipo;
                                  strTipo = e.FormattedValue.ToString();
                                  if (strTipo.Length > 50)
                                  {
                                      strTipo = strTipo.Substring(0, 50);
                                  }
                                  strTipo = strTipo.ToUpper();
                                  dgvVehiculo.CurrentCell.Value = strTipo;
                                  objVehiculo.Tipo = strTipo;
                              }
                              break;
                          case 3://Modelo
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strModelo;
                                  strModelo = e.FormattedValue.ToString();
                                  if (strModelo.Length > 50)
                                  {
                                      strModelo = strModelo.Substring(0, 50);
                                  }
                                  strModelo = strModelo.ToUpper();
                                  dgvVehiculo.CurrentCell.Value = strModelo;
                                  objVehiculo.Modelo = strModelo;
                              }
                              break;
                          case 4://Color
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strColor;
                                  strColor = e.FormattedValue.ToString();
                                  if (strColor.Length > 50)
                                  {
                                      strColor = strColor.Substring(0, 50);
                                  }
                                  strColor = strColor.ToUpper();
                                  dgvVehiculo.CurrentCell.Value = strColor;
                                  objVehiculo.Color = strColor;
                              }
                              break;
                          case 5://Número de Serie
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strNumeroSerie;
                                  strNumeroSerie = e.FormattedValue.ToString();
                                  if (strNumeroSerie.Length > 50)
                                  {
                                      strNumeroSerie = strNumeroSerie.Substring(0, 50);
                                  }
                                  strNumeroSerie = strNumeroSerie.ToUpper();
                                  dgvVehiculo.CurrentCell.Value = strNumeroSerie;
                                  objVehiculo.NumeroSerie = strNumeroSerie;
                              }
                              break;
                          case 6://Señas Particulares
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strSeñasParticulares;
                                  strSeñasParticulares = e.FormattedValue.ToString();
                                  if (strSeñasParticulares.Length > 250)
                                  {
                                      strSeñasParticulares = strSeñasParticulares.Substring(0, 250);
                                  }
                                  strSeñasParticulares = strSeñasParticulares.ToUpper();
                                  dgvVehiculo.CurrentCell.Value = strSeñasParticulares;
                                  objVehiculo.SeñasParticulares = strSeñasParticulares;
                              }
                              break;
                      }

                      try
                      {
                          if (blnExiste)
                          {
                              VehiculoMapper.Instance().Save(objVehiculo);
                              if (this._objPropietarioVehiculo != null)
                              {
                                    VehiculoRobadoObject objVehiculoRobado = VehiculoRobadoMapper.Instance().GetOne(objVehiculo.Clave, this._entIncidencia.Folio);
                                    objVehiculoRobado.ClavePropietario = this._objPropietarioVehiculo.Clave;
                                    VehiculoRobadoMapper.Instance().Save(objVehiculoRobado);
                              }
                              
                          }
                          else
                          {
                              VehiculoRobadoObject objVehiculoRobado = new VehiculoRobadoObject();
                              VehiculoMapper.Instance().Insert(objVehiculo);
                              objVehiculoRobado.ClaveVehiculo = objVehiculo.Clave;
                              dgvVehiculo[0, e.RowIndex].Value = objVehiculo.Clave;
                              if (this._objPropietarioVehiculo != null)
                              {
                                  objVehiculoRobado.ClavePropietario = this._objPropietarioVehiculo.Clave;
                              }
                              objVehiculoRobado.Folio = this._entIncidencia.Folio;
                              VehiculoRobadoMapper.Instance().Insert(objVehiculoRobado);

                          }
                      }
                      catch (System.Exception ex)
                      {
                          throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                      }

                  }
                  catch (System.Exception ex)
                  {
                      throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                  }
            }
              catch (SAIExcepcion)
              { }
        }

        private void chkAccesoriosPercato_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpAccesoriosFechaPercato.Enabled = this.chkAccesoriosPercato.Checked;
        }

        private void txtAccesoriosPlacas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosSerie.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtAccesoriosPlacas_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._objVeiculoAccesoriosRobado == null)
                    {
                        this._objVeiculoAccesoriosRobado = new VehiculoObject();
                        this._objVeiculoAccesoriosRobado.Placas = this.txtAccesoriosPlacas.Text;
                        VehiculoMapper.Instance().Insert(this._objVeiculoAccesoriosRobado);
                        if (this._entRoboVehiculoAccesorios != null)
                        {
                          this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                    }
                    else
                    {
                        if (this._entRoboVehiculoAccesorios != null)
                        {
                          this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        this._objVeiculoAccesoriosRobado.Placas = this.txtAccesoriosPlacas.Text;
                        VehiculoMapper.Instance().Save(this._objVeiculoAccesoriosRobado);
                    }
                   
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

        }

        private void txtAccesoriosSerie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosRobados.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtAccesoriosSerie_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._objVeiculoAccesoriosRobado == null)
                    {
                        this._objVeiculoAccesoriosRobado = new VehiculoObject();
                        this._objVeiculoAccesoriosRobado.NumeroSerie = this.txtAccesoriosSerie.Text;
                        VehiculoMapper.Instance().Insert(this._objVeiculoAccesoriosRobado);

                       if (this._entRoboVehiculoAccesorios != null)
                        {
                          this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                          RoboVehiculoAccesoriosMapper.Instance().Save(this._entRoboVehiculoAccesorios);
                        }
                    }
                    else
                    {
                        if (this._entRoboVehiculoAccesorios != null)
                        {
                          this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                          RoboVehiculoAccesoriosMapper.Instance().Save(this._entRoboVehiculoAccesorios);
                        }
                        this._objVeiculoAccesoriosRobado.NumeroSerie = this.txtAccesoriosSerie.Text;
                        VehiculoMapper.Instance().Save(this._objVeiculoAccesoriosRobado);
                    }

                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

        }

        private void txtAccesoriosRobados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosPersonaSePercato.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtAccesoriosRobados_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._entRoboVehiculoAccesorios  == null)
                    {
                        this._entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
                        this._entRoboVehiculoAccesorios.AccesoriosRobados = this.txtAccesoriosRobados.Text;
                        this._entRoboVehiculoAccesorios.Folio = this._entIncidencia.Folio;
                        if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                            
                        }
                        RoboVehiculoAccesoriosMapper.Instance().Insert(this._entRoboVehiculoAccesorios);
                        for (int i = 0; i < this.dgvVehiculoAccesorios.Rows.Count; i++)
                        {
                            try
                            {
                                int Clave = int.Parse(this.dgvVehiculoAccesorios[0, i].Value.ToString());
                                RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
                                objVehiculoInvolucrado.ClaveVehiculo = Clave;
                                objVehiculoInvolucrado.ClaveRoboAccesorios = this._entRoboVehiculoAccesorios.Clave;
                                RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
                            }
                            catch { }

                        }   
                    }
                    else
                    {
                        if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                         }
                        this._entRoboVehiculoAccesorios.AccesoriosRobados = this.txtAccesoriosRobados.Text;
                        RoboVehiculoAccesoriosMapper.Instance().Save(this._entRoboVehiculoAccesorios);
                    
                    }

                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void txtAccesoriosPersonaSePercato_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpAccesoriosFechaPercato.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtAccesoriosPersonaSePercato_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._entRoboVehiculoAccesorios == null)
                    {
                        this._entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
                        this._entRoboVehiculoAccesorios.SePercato = this.txtAccesoriosPersonaSePercato.Text;
                        this._entRoboVehiculoAccesorios.Folio = this._entIncidencia.Folio;
                        if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        RoboVehiculoAccesoriosMapper.Instance().Insert(this._entRoboVehiculoAccesorios);
                        for (int i = 0; i < this.dgvVehiculoAccesorios.Rows.Count;i++ )
                        {
                            try
                            {
                                int Clave = int.Parse(this.dgvVehiculoAccesorios[0, i].Value.ToString());
                                RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
                                objVehiculoInvolucrado.ClaveVehiculo = Clave;
                                objVehiculoInvolucrado.ClaveRoboAccesorios = this._entRoboVehiculoAccesorios.Clave;
                                RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
                            }
                            catch { }

                        }
                    }
                    else
                    {
                         if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        this._entRoboVehiculoAccesorios.SePercato = this.txtAccesoriosPersonaSePercato.Text;
                        RoboVehiculoAccesoriosMapper.Instance().Save(this._entRoboVehiculoAccesorios);
                    }

                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dtpAccesoriosFechaPercato_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosResponsables.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void dtpAccesoriosFechaPercato_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._entRoboVehiculoAccesorios == null)
                    {
                        this._entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
                        this._entRoboVehiculoAccesorios.FechaPercato = this.dtpAccesoriosFechaPercato.Value;
                        this._entRoboVehiculoAccesorios.Folio = this._entIncidencia.Folio;
                         if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        RoboVehiculoAccesoriosMapper.Instance().Insert(this._entRoboVehiculoAccesorios);
                        //Ahora se inserta en RoboVehiculoAccesoriosRoboVehiculo
                        for (int i = 0; i < this.dgvVehiculoAccesorios.Rows.Count; i++)
                        {
                            try
                            {
                                int Clave = int.Parse(this.dgvVehiculoAccesorios[0, i].Value.ToString());
                                RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
                                objVehiculoInvolucrado.ClaveVehiculo = Clave;
                                objVehiculoInvolucrado.ClaveRoboAccesorios = this._entRoboVehiculoAccesorios.Clave;
                                RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
                            }
                            catch { }

                        }
                    }
                    else
                    {
                         if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        this._entRoboVehiculoAccesorios.FechaPercato = this.dtpAccesoriosFechaPercato.Value;
                        RoboVehiculoAccesoriosMapper.Instance().Save(this._entRoboVehiculoAccesorios);
                    }

                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void txtAccesoriosResponsables_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvVehiculoAccesorios.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtAccesoriosResponsables_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._entRoboVehiculoAccesorios == null)
                    {
                        this._entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
                        this._entRoboVehiculoAccesorios.DescripcionResponsables = this.txtAccesoriosResponsables.Text;
                        this._entRoboVehiculoAccesorios.Folio = this._entIncidencia.Folio;
                        if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        RoboVehiculoAccesoriosMapper.Instance().Insert(this._entRoboVehiculoAccesorios);
                        //Ahora se inserta en RoboVehiculoAccesoriosRoboVehiculo
                        for (int i = 0; i < this.dgvVehiculoAccesorios.Rows.Count; i++)
                        {
                            try
                            {
                                int Clave = int.Parse(this.dgvVehiculoAccesorios[0, i].Value.ToString());
                                RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
                                objVehiculoInvolucrado.ClaveVehiculo = Clave;
                                objVehiculoInvolucrado.ClaveRoboAccesorios = this._entRoboVehiculoAccesorios.Clave;
                                RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
                            }
                            catch { }

                        }
                    }
                    else
                    {
                         if (this._objVeiculoAccesoriosRobado != null)
                        {
                            this._entRoboVehiculoAccesorios.ClaveVehiculo = this._objVeiculoAccesoriosRobado.Clave;
                        }
                        this._entRoboVehiculoAccesorios.DescripcionResponsables = this.txtAccesoriosResponsables.Text;
                        RoboVehiculoAccesoriosMapper.Instance().Save(this._entRoboVehiculoAccesorios);
                    }

                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dgvVehiculoAccesorios_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Boolean blnExiste = false;
            VehiculoObject objVehiculo = new VehiculoObject();
               try
            {
                
               
                   try
                  {
                      if (!(this.dgvVehiculoAccesorios[0, e.RowIndex].Value == null))
                      {
                          blnExiste = true;
                          int Clave = int.Parse(this.dgvVehiculoAccesorios[0, e.RowIndex].Value.ToString());
                          objVehiculo = VehiculoMapper.Instance().GetOne((Clave));
                      }
                      switch (e.ColumnIndex)
                      {
                          case 0:
                              break;
                          case 1: //Marca
                              
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strMarca;
                                  strMarca = e.FormattedValue.ToString();
                                  if (strMarca.Length > 50)
                                  {
                                      strMarca = strMarca.Substring(0, 50);
                                  }
                                  strMarca = strMarca.ToUpper();
                                  dgvVehiculoAccesorios.CurrentCell.Value = strMarca;
                                  objVehiculo.Marca = strMarca;
                              }
                              break;
                          case 2://Tipo
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strTipo;
                                  strTipo = e.FormattedValue.ToString();
                                  if (strTipo.Length > 50)
                                  {
                                      strTipo = strTipo.Substring(0, 50);
                                  }
                                  strTipo = strTipo.ToUpper();
                                  dgvVehiculoAccesorios.CurrentCell.Value = strTipo;
                                  objVehiculo.Tipo = strTipo;
                              }
                              break;
                          case 3://Modelo
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strModelo;
                                  strModelo = e.FormattedValue.ToString();
                                  if (strModelo.Length > 50)
                                  {
                                      strModelo = strModelo.Substring(0, 50);
                                  }
                                  strModelo = strModelo.ToUpper();
                                  dgvVehiculoAccesorios.CurrentCell.Value = strModelo;
                                  objVehiculo.Modelo = strModelo;
                              }
                              break;
                          case 4://Color
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strColor;
                                  strColor = e.FormattedValue.ToString();
                                  if (strColor.Length > 50)
                                  {
                                      strColor = strColor.Substring(0, 50);
                                  }
                                  strColor = strColor.ToUpper();
                                  dgvVehiculoAccesorios.CurrentCell.Value = strColor;
                                  objVehiculo.Color = strColor;
                              }
                              break;
                          case 5://Número de Serie
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strNumeroSerie;
                                  strNumeroSerie = e.FormattedValue.ToString();
                                  if (strNumeroSerie.Length > 50)
                                  {
                                      strNumeroSerie = strNumeroSerie.Substring(0, 50);
                                  }
                                  strNumeroSerie = strNumeroSerie.ToUpper();
                                  dgvVehiculoAccesorios.CurrentCell.Value = strNumeroSerie;
                                  objVehiculo.NumeroSerie = strNumeroSerie;
                              }
                              break;
                          case 6://Señas Particulares
                              if (e.FormattedValue != null && e.FormattedValue.ToString().Trim() != string.Empty)
                              {
                                  String strSeñasParticulares;
                                  strSeñasParticulares = e.FormattedValue.ToString();
                                  if (strSeñasParticulares.Length > 250)
                                  {
                                      strSeñasParticulares = strSeñasParticulares.Substring(0, 250);
                                  }
                                  strSeñasParticulares = strSeñasParticulares.ToUpper();
                                  dgvVehiculoAccesorios.CurrentCell.Value = strSeñasParticulares;
                                  objVehiculo.SeñasParticulares = strSeñasParticulares;
                              }
                              break;
                      }
                    
                      if (blnExiste)
                      {
                              VehiculoMapper.Instance().Save(objVehiculo);
                              
                      }
                      else
                          {
                              RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
                              VehiculoMapper.Instance().Insert(objVehiculo);

                              objVehiculoInvolucrado.ClaveVehiculo = objVehiculo.Clave;
                              dgvVehiculoAccesorios[0, e.RowIndex].Value = objVehiculo.Clave;

                              if (_entRoboVehiculoAccesorios != null)
                              {
                                  objVehiculoInvolucrado.ClaveRoboAccesorios = this._entRoboVehiculoAccesorios.Clave;
                                  RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
                              }
                          }
                     }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }     
    }
}
