using System;
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
using System.Threading;

using Mapa = BSD.C4.Tlaxcala.Sai.Mapa;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// El formulario SIAFrmIncidencia contiene la funcionalidad básica que comparten las incidencias
    /// del sistema 089 y 066, por lo tanto éste no es implementado directamente en la aplicación, sino que hereda
    /// hacia el formulario SIAFrmIncidencia089 y SIAFrmIncidencia066
    /// </summary>
    public partial class SAIFrmIncidencia : SAIFrmBase
    {
        /// <summary>
        /// Guarda la referencia a la entidad Incidencia que se maneja en el formulario
        /// </summary>
        protected Incidencia _entIncidencia = new Incidencia();
        
        /// <summary>
        /// Bandera que indica si se va a limpiar el combo de colonias, lo cual se hace sólo cuando cambia el código postal
        /// </summary>
        private Boolean _blnLimpiarColonias = false;

        /// <summary>
        /// Objeto que guarda las claves de municipio, localidad, colonia y código postal que se tienen escogidas por el 
        /// usuario a cada momento en el formulario
        /// </summary>
        /// <remarks>
        /// Este objeto se pasa al método del la clase controladora del mapa para leer los valores de los id's correspondientes
        /// </remarks>
        private Mapa.EstructuraUbicacion _objUbicacion = new Mapa.EstructuraUbicacion();

        /// <summary>
        /// Bandera que se utiliza para detener el disparo en cascada de los eventos SelectedIndexChanged
        /// para las listas de municipios, localidades, colonias y códigos postales.
        /// </summary>
        private Boolean _blnBloqueaEventos;

        /// <summary>
        /// Esta bandera lleva el estado para saber si el usuario quiso cerrar la ventana, esto para saber
        /// si se va a guardar la incidencia en los eventos Leave de los controles, si está en falso se guardan
        /// los datos en dichos eventos, de lo contrario no se guarda la incidencia en tales eventos.
        /// </summary>
        protected Boolean _blnSeActivoClosed = false;

        /// <summary>
        /// Guarda los datos del propietario del vehículo, cuando la incidencia es del tipo robo de vehículo
        /// </summary>
        protected PropietarioVehiculoObject _objPropietarioVehiculo = null;

        /// <summary>
        /// Guarda los datos de la entidad de accesorios del vehículo, cuando la incidencia es del tipo robo de accesorios de vehículo
        /// </summary>
        protected RoboVehiculoAccesorios _entRoboVehiculoAccesorios = null;

        /// <summary>
        /// Guarda los datos de la entidad vehículo, cuando la incidencia es del tipo de robo de accesorios de vehículo
        /// </summary>
        protected VehiculoObject _objVeiculoAccesoriosRobado = null;

        /// <summary>
        /// Lleva el estado del caso de la tecla control presionada.
        /// </summary>
        private bool _blnCtrPresionado = false;

        /// <summary>
        /// Guarda el valor de solo lectura del formulario
        /// </summary>
        private Boolean _blnSoloLectura;

        protected GroupBox _grpDenunciante =null;

        public delegate  void DelegadoActualizaLocalidades(LocalidadList lstLocalidades);
        public delegate void DelegadoLimpiaLocalidades();
        public delegate void DelegadoActualizaCodigosPostales(CodigoPostalList  lstCodigosPostales);
        public delegate void DelegadoLimpiaCodigosPostales();
        public delegate void DelegadoActualizaColonias(ColoniaList lstColonias);
        public delegate void DelegadoLimpiaColonias();
        public delegate void DelegadoLimpiaTextoCodigPostal();
        public delegate void DelegadoSeleccionaCodigoPostal(Object objElemento);
        public delegate void DelegadoLimpiaTextoColonia();

        /// <summary>
        /// Actualiza el combo de localidades 
        /// </summary>
        /// <param name="objListaLocalidades">Lista de localidades que se mostrarán en el control</param>
        private void ActualizaLocalidades(LocalidadList objListaLocalidades)
        {
            this.cmbLocalidad.DataSource = objListaLocalidades;
            this.cmbLocalidad.DisplayMember = "Nombre";
            this.cmbLocalidad.ValueMember = "Clave";
            this.cmbLocalidad.SelectedIndex = -1;
            this.cmbLocalidad.Text = string.Empty;

        }

        /// <summary>
        /// Limpia el control que contiene la lista de localidades
        /// </summary>
        private void LimpiaLocalidades()
        {
            this.cmbLocalidad.DataSource = null;
            this.cmbLocalidad.Items.Clear();
        }

        /// <summary>
        /// Actualiza la lista de los códigos postales
        /// </summary>
        /// <param name="objListaCodigosPostales">Lista de los códigos postales que se mostrarán en el control</param>
        private void ActualizaCodigosPostales(CodigoPostalList objListaCodigosPostales)
        {
            this.cmbCP.DataSource = objListaCodigosPostales;
            this.cmbCP.DisplayMember = "Valor";
            this.cmbCP.ValueMember = "Clave";
            this.cmbCP.SelectedIndex = -1;
            this.cmbCP.Text = string.Empty;
        }

        /// <summary>
        /// Limpia el texto del combo de códigos postales
        /// </summary>
        private void LimpiaTextoCodigoPostal()
        {
            this.cmbCP.Text = string.Empty;
        }

        /// <summary>
        /// Selecciona el elemento del combo de codigos postales
        /// </summary>
        /// <param name="objElemento">Elemento que se va a seleccionar</param>
        private void SeleccionaCodigoPostal(Object objElemento)
        {
            this.cmbCP.SelectedIndex = -1;
            this.cmbCP.SelectedItem = objElemento;
                                   
        }

        /// <summary>
        /// Limpia el combo que contiene los códigos postales
        /// </summary>
        private void LimpiaCodigosPostales()
        {
            this.cmbCP.DataSource = null;
            this.cmbCP.Items.Clear();
        }

        /// <summary>
        /// Actualiza la lista de colonias del combo correspondiente
        /// </summary>
        /// <param name="lstColonias">Lista de colonias que se van a mostrar en el control</param>
        private void ActualizaColonias(ColoniaList lstColonias)
        {
            this.cmbColonia.DataSource = lstColonias;
            this.cmbColonia.DisplayMember = "Nombre";
            this.cmbColonia.ValueMember = "Clave";
            this.cmbColonia.SelectedIndex = -1;
            this.cmbColonia.Text = String.Empty;


        }

        /// <summary>
        /// Limpia el texto del control del combo de colonias
        /// </summary>
        private void LimpiaTextoColonia()
        {
            this.cmbColonia.SelectedIndex = -1;
            this.cmbColonia.Text = string.Empty;
        }

        /// <summary>
        /// Limpia el combo que contiene la lista de colonias
        /// </summary>
        private void LimpiaColonias()
        {
            this.cmbColonia.DataSource = null;
            this.cmbColonia.Items.Clear();
        }

        /// <summary>
        /// Obtiene o establece el valor que indica si el formulario será de solo lectura
        /// </summary>
        /// <remarks>Cuando esta propiedad es verdadera, los controles hijos del formulario se convierten a solo lectura</remarks>
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
                        if (objControl.GetType() == (new System.Windows.Forms.GroupBox()).GetType())
                        {
                            continue;
                        }
                        if (objControl.GetType().GetProperty("ReadOnly") != null)
                        {
                            objControl.GetType().GetProperty("ReadOnly").SetValue(objControl, true, null);
                        }
                        else
                        {
                            objControl.Enabled = false;
                        }
                        
                    }
                }
                else
                {
                    foreach (Control objControl in this.Controls)
                    {
                        if (objControl.GetType() == (new System.Windows.Forms.GroupBox()).GetType())
                        {
                            continue;
                        }
                        if (objControl.GetType().GetProperty("ReadOnly") != null)
                        {
                            objControl.GetType().GetProperty("ReadOnly").SetValue(objControl, false, null);
                        }
                        else
                        {
                            objControl.Enabled = true;
                        }

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
                if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                {
                    this.Height = 515;
                    this.Width = 600;
                }
                else
                {
                    this.Height = 630;
                    this.Width = 600;
                }
                this.InicializaListas();
                //****Crea una nueva incidencia, el formulario se abrió para insertar*******
                this._entIncidencia.Referencias = string.Empty;
                this._entIncidencia.Descripcion = string.Empty;
                this._entIncidencia.Activo = true;
                this._entIncidencia.HoraRecepcion = DateTime.Now;
                this._entIncidencia.ClaveEstatus = 1;
                this._entIncidencia.ClaveEstado = 29;
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
        /// <param name="SoloLectura"> Indica si el formulario será de solo lectura </param>
        public SAIFrmIncidencia(Incidencia entIncidencia, Boolean SoloLectura)
        {
            entIncidencia.ClaveEstado = 29;
            this._blnBloqueaEventos = true;
            InitializeComponent();
            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            {
                this.Height = 515;
                this.Width = 600;
            }
            else
            {
                this.Height = 630;
                this.Width = 600;
            }
            this.SuspendLayout();
            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            {
                this.lblDescripcionIncidencia.Text  = "Descripción de  \n la Denuncia:";
                this.lblTelefono.Visible = false;
                this.txtTelefono.Visible = false;
                this.lblTipoIncidencia.Left = lblTelefono.Left - 5;
                this.cmbTipoIncidencia.Left = this.txtTelefono.Left;
                this.lblTipoIncidencia.Text = "Tipo de \n la Denuncia:";
                this.lblTipoIncidencia.Top -= 10;
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
            this.SoloLectura = SoloLectura;
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
                    this.actualizaMapaUbicacion();
                    this._blnSeActivoClosed = false;
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Llena la lista para mostrar los tipos de incidencias y municipios
        /// </summary>
        private void InicializaListas()
        {

            TipoIncidenciaList lstTipoIncidencias;
            MunicipioList lstMunicipios;

            try
            {
                try
                {
                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                    {
                        lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(2);
                    }
                    else
                    {
                        lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(1);
                    }
                        
                        lstMunicipios = MunicipioMapper.Instance().GetAll();

                        foreach (TipoIncidencia objTipoIncidencia in lstTipoIncidencias)
                        {
                            objTipoIncidencia.Descripcion += " " + objTipoIncidencia.ClaveOperacion;
                        }
                        this.cmbTipoIncidencia.DataSource = lstTipoIncidencias;
                        this.cmbTipoIncidencia.DisplayMember = "Descripcion";
                        this.cmbTipoIncidencia.ValueMember = "Clave";

                        //int j = 0;
                        //foreach(Object objTipoIncidencia in cmbTipoIncidencia.Items)
                        //{
                        //    //for (j = 0; j < objTipoIncidencia.GetType().GetProperties().Length; j++)
                        //    //{
                        //    //    if (objElemento.GetType().GetProperties()[j].Name == "Descripcion")
                        //    //    {
                        //    //        break;
                        //    //    }
                        //    //}                        
                        //    objTipoIncidencia.GetType().GetProperty("Descripcion").SetValue
                        //        (objTipoIncidencia,
                        //         objTipoIncidencia.GetType().GetProperty("Descripcion").GetValue(objTipoIncidencia,null).ToString() + " " +
                        //         objTipoIncidencia.GetType().GetProperty("ClaveOperacion").GetValue(objTipoIncidencia,null).ToString(),null);

                        //}

                        this.cmbMunicipio.DataSource = lstMunicipios;
                        this.cmbMunicipio.DisplayMember = "Nombre";
                        this.cmbMunicipio.ValueMember = "Clave";

                        this.cmbMunicipio.SelectedIndex = -1;
                        this.cmbMunicipio.Text = string.Empty;


                       }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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
            LocalidadList objListaLocalidades;
            ColoniaList objListaColonias;
            CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
            CodigoPostal entCodigoPostal;
            Boolean blnExisteCodigoPostal = false;
            int i;

            try
            {
                try
                {
                    entUsuario = UsuarioMapper.Instance().GetOne(this._entIncidencia.ClaveUsuario);
                    this.lblOperador.Text = entUsuario.NombrePropio;
                    this.lblFechaHora.Text = this._entIncidencia.HoraRecepcion.ToString();
                    this.Text = this._entIncidencia.Folio.ToString();
                    this.txtTelefono.Text = this._entIncidencia.Telefono;
                    this.txtDireccion.Text = this._entIncidencia.Direccion;

                    if (this._entIncidencia.ClaveTipo.HasValue)
                    {
                        //TipoIncidencia entTipoIncidencia = TipoIncidenciaMapper.Instance().GetOne(this._entIncidencia.ClaveTipo.Value);
                        //this.cmbTipoIncidencia.SelectedItem = entTipoIncidencia;

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
                    //Datos de la ubicación
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

                        //Se recuperan las localidades del municipio
                        if (this._entIncidencia.ClaveLocalidad.HasValue)
                        {
                            objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio((this.cmbMunicipio.SelectedItem as Municipio).Clave);
                            if (objListaLocalidades != null)
                            {
                                this.cmbLocalidad.DataSource = objListaLocalidades;
                                this.cmbLocalidad.DisplayMember = "Nombre";
                                this.cmbLocalidad.ValueMember = "Clave";
                                this.cmbLocalidad.SelectedIndex = -1;
                            }


                                //Se ubica la localidad
                                foreach (Object elemento in this.cmbLocalidad.Items)
                                {
                                    
                                    if (this._entIncidencia.ClaveLocalidad.Value == (elemento as Localidad ).Clave)
                                    {
                                        this.cmbLocalidad.SelectedIndex = -1;
                                        this.cmbLocalidad.SelectedItem = elemento;
                                        break;
                                    }
                                }

                                if (this._entIncidencia.ClaveCodigoPostal.HasValue)
                                {
                                    //Se recuperan los códigos postales del municipio
                                    for (i = 0; i < objListaLocalidades.Count; i++)
                                    {
                                        objListaColonias = ColoniaMapper.Instance().GetByLocalidad(objListaLocalidades[i].Clave);
                                        for (int j = 0; j < objListaColonias.Count; j++)
                                        {
                                            if (objListaColonias[j].ClaveCodigoPostal.HasValue)
                                            {
                                                entCodigoPostal = CodigoPostalMapper.Instance().GetOne(objListaColonias[j].ClaveCodigoPostal.Value);
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
                                        

                                         //Se el código postal
                                        foreach (Object elemento in this.cmbCP.Items)
                                        {
                                            
                                            if (this._entIncidencia.ClaveCodigoPostal.Value == (elemento as CodigoPostal ).Clave)
                                            {
                                                this.cmbCP.SelectedIndex = -1;
                                                this.cmbCP.SelectedItem = elemento;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (this._entIncidencia.ClaveColonia.HasValue)
                                {
                                    objListaColonias = ColoniaMapper.Instance().GetByLocalidad(this._entIncidencia.ClaveColonia.Value);
                                    if (objListaColonias != null)
                                    {
                                        this.cmbColonia.DataSource = objListaColonias;
                                        this.cmbColonia.DisplayMember = "Valor";
                                        this.cmbColonia.ValueMember = "Clave";
                                        this.cmbColonia.SelectedIndex = -1;

                                        //Se ubica la colonia
                                        foreach (Object elemento in this.cmbColonia.Items)
                                        {
                                            if (this._entIncidencia.ClaveColonia.Value == (elemento as Colonia).Clave)
                                            {
                                                this.cmbColonia.SelectedIndex = -1;
                                                this.cmbColonia.SelectedItem = elemento;
                                                break;
                                            }
                                        }


                                    }
                                }
                            }
                            
                            this.actualizaMapaUbicacion();
                        }
                    //Terminan los datos de la ubicación
                    this.txtReferencias.Text = this._entIncidencia.Referencias;
                    this.txtDescripcion.Text = this._entIncidencia.Descripcion;
                    //Datos de Extravio de persona
                    PersonaExtraviadaList lstPersonasExtraviadas = PersonaExtraviadaMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    i = 1;
                    foreach (PersonaExtraviada entPersonaExtraviada in lstPersonasExtraviadas)
                    {
                        
                        dgvPersonaExtraviada.Rows.Add();

                        dgvPersonaExtraviada[0, i - 1].Value = entPersonaExtraviada.Clave;
                        dgvPersonaExtraviada[1, i - 1].Value = entPersonaExtraviada.Folio;
                        dgvPersonaExtraviada[2, i - 1].Value = entPersonaExtraviada.Nombre;
                        if (entPersonaExtraviada.Edad.HasValue)
                        {
                            dgvPersonaExtraviada[3, i - 1].Value = entPersonaExtraviada.Edad;
                        }
                        dgvPersonaExtraviada[4, i - 1].Value = entPersonaExtraviada.Sexo;
                        if (entPersonaExtraviada.Estatura.HasValue)
                        {
                            dgvPersonaExtraviada[5, i - 1].Value = entPersonaExtraviada.Estatura;
                        }
                        dgvPersonaExtraviada[6, i - 1].Value = entPersonaExtraviada.Parentesco;
                        dgvPersonaExtraviada[7, i - 1].Value = entPersonaExtraviada.FechaExtravio.ToString("dd/MM/aaaa");
                        dgvPersonaExtraviada[8, i - 1].Value = entPersonaExtraviada.Tez;
                        dgvPersonaExtraviada[9, i - 1].Value = entPersonaExtraviada.TipoCabello;
                        dgvPersonaExtraviada[10, i - 1].Value = entPersonaExtraviada.ColorCabello;
                        dgvPersonaExtraviada[11, i - 1].Value = entPersonaExtraviada.LargoCabello;
                        dgvPersonaExtraviada[12, i - 1].Value = entPersonaExtraviada.Frente;
                        dgvPersonaExtraviada[13, i - 1].Value = entPersonaExtraviada.Cejas;
                        dgvPersonaExtraviada[14, i - 1].Value = entPersonaExtraviada.OjosColor;
                        dgvPersonaExtraviada[15, i - 1].Value = entPersonaExtraviada.OjosForma;
                        dgvPersonaExtraviada[16, i - 1].Value = entPersonaExtraviada.NarizForma;
                        dgvPersonaExtraviada[17, i - 1].Value = entPersonaExtraviada.BocaTamaño;
                        dgvPersonaExtraviada[18, i - 1].Value = entPersonaExtraviada.Labios;
                        dgvPersonaExtraviada[19, i - 1].Value = entPersonaExtraviada.Vestimenta;
                        dgvPersonaExtraviada[20, i - 1].Value = entPersonaExtraviada.Destino;
                        dgvPersonaExtraviada[21, i - 1].Value = entPersonaExtraviada.Caracteristicas;
                        
                        i++;

                    }
                    //Datos de robo de vehículo
                    VehiculoRobadoObjectList lstVehiculosRobados = VehiculoRobadoMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    i = 1;
                    foreach (VehiculoRobadoObject objVehiculoRobado in lstVehiculosRobados)
                    {
                       

                        if (objVehiculoRobado.ClavePropietario.HasValue)
                        {
                            PropietarioVehiculoObject objPropietarioVehiculo = PropietarioVehiculoMapper.Instance().GetOne(objVehiculoRobado.ClavePropietario.Value);
                            if (objPropietarioVehiculo != null)
                            {
                                this.txtNombrePropietario.Text  = objPropietarioVehiculo.Nombre;
                                this.txtDireccionPropietario.Text = objPropietarioVehiculo.Domicilio;
                                this.txtTelefonoPropietario.Text = objPropietarioVehiculo.Telefono; 
                            }
                        }
                        VehiculoObject objVehiculo = VehiculoMapper.Instance().GetOne(objVehiculoRobado.ClaveVehiculo);
                        if (objVehiculo != null)
                        {
                            dgvVehiculo.Rows.Add();
                            dgvVehiculo[0,i-1].Value = objVehiculo.Clave;
                            dgvVehiculo[1,i-1].Value = objVehiculo.Marca;
                            dgvVehiculo[2,i-1].Value = objVehiculo.Tipo;
                            dgvVehiculo[3,i-1].Value = objVehiculo.Modelo;
                            dgvVehiculo[4,i-1].Value = objVehiculo.Placas;
                            dgvVehiculo[5,i-1].Value = objVehiculo.Color;
                            dgvVehiculo[6,i-1].Value = objVehiculo.NumeroMotor;
                            dgvVehiculo[7,i-1].Value = objVehiculo.NumeroSerie;
                            dgvVehiculo[8,i-1].Value = objVehiculo.SeñasParticulares;
                            i++;
                        }

                       
                    }
                    //Datos de robo de accesorios de vehiculo
                    //-Se revisa si la incidencia tiene un registro en RoboVehiculoAccesorios:
                    RoboVehiculoAccesoriosList lstRoboVehiculoAccesorios = RoboVehiculoAccesoriosMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    if (lstRoboVehiculoAccesorios != null && lstRoboVehiculoAccesorios.Count > 0)
                    {
                        RoboVehiculoAccesorios entRoboVehiculoAccesorios = lstRoboVehiculoAccesorios[0];
                        if (entRoboVehiculoAccesorios.ClaveVehiculo.HasValue)
                        {
                            VehiculoObject objVehiculo = VehiculoMapper.Instance().GetOne(entRoboVehiculoAccesorios.ClaveVehiculo.Value);
                            this.txtAccesoriosPlacas.Text = objVehiculo.Placas;
                            this.txtAccesoriosSerie.Text = objVehiculo.NumeroSerie;
                        }
                        this.txtAccesoriosRobados.Text = entRoboVehiculoAccesorios.AccesoriosRobados;
                        this.txtAccesoriosPersonaSePercato.Text = entRoboVehiculoAccesorios.SePercato;
                        if (entRoboVehiculoAccesorios.FechaPercato.HasValue)
                        {
                            this.dtpAccesoriosFechaPercato.Value = entRoboVehiculoAccesorios.FechaPercato.Value;
                            this.dtpAccesoriosFechaPercato.Enabled = true;
                            this.chkAccesoriosPercato.Checked = true;
                        }
                        else
                        {
                            this.dtpAccesoriosFechaPercato.Enabled = false;
                            this.chkAccesoriosPercato.Checked = false;
                        }
                        this.txtAccesoriosResponsables.Text = entRoboVehiculoAccesorios.DescripcionResponsables;

                        //Se revisa si hay vehículos involucrados
                        RoboVehiculoAccesoriosVehiculoInvolucradoObjectList lstRoboVehiculosInv = RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().GetByRoboVehiculoAccesorios(entRoboVehiculoAccesorios.Clave);

                        if (lstRoboVehiculosInv != null && lstRoboVehiculosInv.Count > 0)
                        {
                            i = 1;
                            foreach(RoboVehiculoAccesoriosVehiculoInvolucradoObject objRoboVehiculoInv in lstRoboVehiculosInv)
                            {
                                VehiculoObject objVehiculoInv = VehiculoMapper.Instance().GetOne(objRoboVehiculoInv.ClaveVehiculo);
                                if (objVehiculoInv != null)
                                {
                                    dgvVehiculoAccesorios.Rows.Add();
                                    dgvVehiculoAccesorios[0, i - 1].Value = objVehiculoInv.Clave;
                                    dgvVehiculoAccesorios[1, i - 1].Value = objVehiculoInv.Marca;
                                    dgvVehiculoAccesorios[2, i - 1].Value = objVehiculoInv.Tipo;
                                    dgvVehiculoAccesorios[3, i - 1].Value = objVehiculoInv.Modelo;
                                    dgvVehiculoAccesorios[4, i - 1].Value = objVehiculoInv.Placas;
                                    dgvVehiculoAccesorios[5, i - 1].Value = objVehiculoInv.Color;
                                    dgvVehiculoAccesorios[6, i - 1].Value = objVehiculoInv.NumeroMotor;
                                    dgvVehiculoAccesorios[7, i - 1].Value = objVehiculoInv.NumeroSerie;
                                    dgvVehiculoAccesorios[8, i - 1].Value = objVehiculoInv.SeñasParticulares;
                                    i++;
                                }
                                i++;
                            }
                        }


                    }
                    this.txtDireccion.Text = this._entIncidencia.Direccion;

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
            try
            {
                try
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

        }

        #region Eventos del combo MUNICIPIO


        /// <summary>
        /// Implementa el evento cambia mapa del control SAIComboBox
        /// </summary>
        private void cmbMunicipio_CambiaMapa()
        {
            this.cmbMunicipioRefrescaControles();   
        }

        /// <summary>
        /// Recarga los controles de localidades y códigos postales con base al municipio seleccioando
        /// </summary>
        private void cmbMunicipioRefrescaControles()
        {
            LocalidadList objListaLocalidades;
            ColoniaList objListaColonias;
            CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
            CodigoPostal entCodigoPostal;
            Boolean blnExisteCodigoPostal;
            //Thread tr1;
            //Thread tr2;
            //Thread tr3;

            try
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (this._blnBloqueaEventos == true)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    this._blnBloqueaEventos = true;
                    //tr1 = new Thread(delegate()
                    //{
                    //    this.cmbLocalidad.Invoke(new DelegadoLimpiaLocalidades(LimpiaLocalidades));
                    //    this.cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));
                    //    this.cmbCP.Invoke(new DelegadoLimpiaCodigosPostales(LimpiaCodigosPostales));

                    //}) { IsBackground = false };
                    
                    //tr1.Start();
                    this.LimpiaLocalidades();
                    this.LimpiaColonias();
                    this.LimpiaCodigosPostales();
                    
                    if (this.cmbMunicipio.SelectedItem == null)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio((this.cmbMunicipio.SelectedItem as Municipio).Clave);
                    if (objListaLocalidades != null)
                    {
                        //tr1.Abort();
                        //tr1 = new Thread(delegate()
                        //{
                        //    this.cmbLocalidad.Invoke(new DelegadoActualizaLocalidades(ActualizaLocalidades), new object[] { objListaLocalidades });
                        //}) { IsBackground = false };
                        //tr1.Start();

                        this.ActualizaLocalidades(objListaLocalidades);
                        //Se recuperan los códigos postales del municipio
                        for (int i = 0; i < objListaLocalidades.Count; i++)
                        {
                            objListaColonias = ColoniaMapper.Instance().GetByLocalidad(objListaLocalidades[i].Clave);
                            for (int j = 0; j < objListaColonias.Count; j++)
                            {
                                if (objListaColonias[j].ClaveCodigoPostal.HasValue)
                                {
                                    entCodigoPostal = CodigoPostalMapper.Instance().GetOne(objListaColonias[j].ClaveCodigoPostal.Value);
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
                            //tr1.Abort();
                            //tr1 = new Thread(delegate()
                            //{
                            //    this.cmbCP.Invoke(new DelegadoActualizaCodigosPostales(ActualizaCodigosPostales), new object[] { objListaCodigosPostales });
                            //}) { IsBackground = false };
                            //tr1.Start();
                            this.ActualizaCodigosPostales(objListaCodigosPostales);
                        }

                    }
                    this._blnBloqueaEventos = false;
                    this.actualizaMapaUbicacion();
                    
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        
        }

        /// <summary>
        /// Recupera las localidades y los códigos postales del municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.cmbMunicipioRefrescaControles();    

        }

        /// <summary>
        /// Guarda la incidencia con el municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_Leave(object sender, EventArgs e)
        {

            try
            {          
                try
                {
                    if (this.cmbMunicipio.SelectedIndex == -1 || this.cmbMunicipio.Text.Trim() == string.Empty)
                    {
                        //var tr = new Thread(delegate()
                        //{
                        //    this.cmbLocalidad.Invoke(new DelegadoLimpiaLocalidades(LimpiaLocalidades));
                        //    this.cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));

                        //}) { IsBackground = false };
                        //tr.Start();
                        this.LimpiaLocalidades();
                        this.LimpiaColonias();
                    }
                    
                    this.actualizaMapaUbicacion();
                    if (!this._blnSeActivoClosed)
                    {
                        this.RecuperaDatosEnIncidencia();
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Actualiza el mapa cuando cambia el texto de la lista de municipios
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.actualizaMapaUbicacion();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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

            try
            {
                try
                {
                    if (this._blnBloqueaEventos == true)
                    {
                        return;
                    }

                    this._blnBloqueaEventos = true;



                    //var tr = new Thread(delegate()
                    //{
                    //    this.cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));

                    //}) { IsBackground = false };
                    //tr.Start();
                    this.LimpiaColonias();

                    if (this.cmbLocalidad.SelectedItem != null)
                    {
                        lstColonias = ColoniaMapper.Instance().GetByLocalidad((this.cmbLocalidad.SelectedItem as Localidad).Clave);
                    }
                    else
                    {
                        lstColonias = null;
                    }

                    if (lstColonias != null)
                    {

                       //Actualiza colonias
                       //limpia el texto del codigo postal
                        //var tr2 = new Thread(delegate()
                        //{
                        //    this.cmbColonia.Invoke(new DelegadoActualizaColonias (ActualizaColonias),new object[]{lstColonias});
                        //    this.cmbCP.Invoke(new DelegadoLimpiaTextoCodigPostal(LimpiaTextoCodigoPostal));

                        //}) { IsBackground = false };
                        //tr2.Start();
                        this.ActualizaColonias(lstColonias);
                        this.LimpiaTextoCodigoPostal();
                    }


                    this._blnBloqueaEventos = false;
                    this.actualizaMapaUbicacion();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
           
        }

        /// <summary>
        /// Actualiza el mapa cuando cambia el texto del combo de localidad
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.actualizaMapaUbicacion();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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
            try
            {
                try
                {
                    if (this.cmbLocalidad.SelectedIndex == -1 || this.cmbLocalidad.Text.Trim() == string.Empty)
                    {
                        //var tr = new Thread(delegate()
                        //{
                        //    try
                        //    {
                        //        this.cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));
                        //    }
                        //    catch { }
                        //}) { IsBackground = false };
                        //tr.Start();
                        this.LimpiaColonias();

                    }
                    this.actualizaMapaUbicacion();
                    if (!this._blnSeActivoClosed)
                    {
                        this.RecuperaDatosEnIncidencia();
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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

            try
            {
                try
                {
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
                                    //selecciona codigo postal
                                    //var tr = new Thread(delegate()
                                    //{
                                    //    this.cmbCP.Invoke(new DelegadoSeleccionaCodigoPostal(SeleccionaCodigoPostal), new object[]{objElemento});

                                    //}) { IsBackground = false };
                                    //tr.Start();
                                    this.SeleccionaCodigoPostal(objElemento);
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
          
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

            try
            {
                try
                {
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
                                   //var tr = new Thread(delegate()
                                   // {
                                   //     this.cmbCP.Invoke(new DelegadoActualizaColonias(ActualizaColonias), new object[] { lstColonias });

                                   // }) { IsBackground = false };
                                   // tr.Start();
                                    this.ActualizaColonias(lstColonias);

                                }
                                else
                                {
                                    
                                    //var tr2 = new Thread(delegate()
                                    //{
                                    //    this.cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));

                                    //}) { IsBackground = false };
                                    //tr2.Start();
                                    this.LimpiaColonias();

                                }
                            }
                            else
                            {
                                //var trd = new Thread(delegate()
                                //{
                                //    this.cmbColonia.Invoke(new DelegadoLimpiaTextoColonia (LimpiaTextoColonia));

                                //}) { IsBackground = false };
                                //trd.Start();
                                this.LimpiaTextoColonia();
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
                                        //var tr3 = new Thread(delegate()
                                        //{
                                        //    this.cmbCP.Invoke(new DelegadoSeleccionaCodigoPostal(SeleccionaCodigoPostal), new object[] { objElemento });

                                        //}) { IsBackground = false };
                                        //tr3.Start();
                                        this.SeleccionaCodigoPostal(objElemento);
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
                                    //var tr4 = new Thread(delegate()
                                    //{
                                    //    this.cmbCP.Invoke(new DelegadoSeleccionaCodigoPostal(SeleccionaCodigoPostal), new object[] { objElemento });

                                    //}) { IsBackground = false };
                                    //tr4.Start();
                                    this.SeleccionaCodigoPostal(objElemento);
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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
            try
            {
                try
                {
                    this.actualizaMapaUbicacion();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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
            try
            {
                try
                {
                    if (this._blnBloqueaEventos == true)
                    {
                        return;
                    }

                    this._blnBloqueaEventos = true;
                    if (this._blnLimpiarColonias)
                    {
                        //var trd = new Thread(delegate()
                        //{
                        //    this.cmbColonia.Invoke(new DelegadoLimpiaTextoColonia(LimpiaTextoColonia));

                        //}) { IsBackground = false };
                        //trd.Start();
                        this.LimpiaTextoColonia();
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia con el código postal seleccionado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.actualizaMapaUbicacion();
                    if (!this._blnSeActivoClosed)
                    {
                        this.RecuperaDatosEnIncidencia();
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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
            try
            {
                try
                {
                    this.actualizaMapaUbicacion();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

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
                    if (!base.SAIProveedorValidacion.ValidarCamposRequeridos(this) && !this._blnSoloLectura)
                    {
                        e.Cancel = true;

                        throw new SAIExcepcion("Debe de indicar el tipo de incidencia",this);
                        return;

                    }

                    Mapa.Controlador.RevisaInstancias(this);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Quita el elemento de la lista de ventanas cuando la ventana ya se ha cerrado
        /// </summary>
        /// <param name="e">Parámetros del evento</param>
        protected override void OnClosed(EventArgs e)
        {
            try
            {
                try
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Recupera los datos de la incidencia que están en el formulario y los guarda en la BD.
        /// </summary>
        protected  void GuardaIncidencia()
        {
            try
            { 
                try
                {
                    if (this._entIncidencia != null)
                    {
                       
                        IncidenciaMapper.Instance().Save(this._entIncidencia);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Lee los datos del formulario y escribe la información en el objeto de incidencia
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
                    this._objUbicacion.IdMunicipio = int.Parse((this.cmbMunicipio.SelectedItem as Municipio).Clave.ToString());
                   
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
            try
            {
                try
                {
                    this._entIncidencia.Telefono  = this.txtTelefono.Text;
                    if (!this._blnSeActivoClosed)
                    {
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia con el tipo de incidencia actualizado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbTipoIncidencia_Leave(object sender, EventArgs e)
        {
            try
            {
                try
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia con la descripción de la incidencia actualizada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            try
            {
                try
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia con la dirección de la incidencia actualizada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this._entIncidencia.Direccion  = this.txtDireccion.Text;
                    if (!this._blnSeActivoClosed)
                    {
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia con las referencias de la incidencia actualizada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtReferencias_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this._entIncidencia.Referencias = this.txtReferencias.Text;
                    if (!this._blnSeActivoClosed)
                    {
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }
        
        /// <summary>
        /// Muestra la ventana para hacer el switch entre incidencias abiertas en caso de que Ctrl+tab estén presionados
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Muestra u oculta la información adicional según el tipo de incidencia
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbTipoIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
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

                                this.Height = 750;
                                this.Width = 600;
                                this.grpRoboVehiculo.Top = 455;
                               

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
                                this.Height = 750;
                                this.Width = 600;
                                this.grpRoboAccesorios.Top = 455;
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
                                this.Height = 750;
                                this.Width = 600;
                                this.grpExtravio.Top = 455;
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
                                this.Height = 515;
                                this.Width = 600;
                               
                            }
                            else
                            {
                                this.Height = 630;
                                this.Width = 600;
                               
                            }
                            this.ResumeLayout(false);
                            this.PerformLayout();
                            if ((objTipo.Descripcion.ToUpper().Contains("FORANEO") || objTipo.Descripcion.ToUpper().Contains("FORÁNEO")) || (objTipo.Descripcion.ToUpper().Contains("FORÁNEA") || objTipo.Descripcion.ToUpper().Contains("FORANEA")))
                            {
                                this.cmbMunicipio.Enabled = false;
                                this.cmbLocalidad.Enabled = false;
                                this.cmbColonia.Enabled = false;
                                this.cmbCP.Enabled = false;
                            }
                            else
                            {
                                this.cmbMunicipio.Enabled = true;
                                this.cmbLocalidad.Enabled = true;
                                this.cmbColonia.Enabled = true;
                                this.cmbCP.Enabled = true;
                            }
                            if (this._grpDenunciante != null)
                            {
                                if ((objTipo.Descripcion.ToUpper().Contains("ANONIMO") || objTipo.Descripcion.ToUpper().Contains("ANÓNIMO")) || (objTipo.Descripcion.ToUpper().Contains("ANONIMA") || objTipo.Descripcion.ToUpper().Contains("ANÓNIMA")))
                                {
                                    this._grpDenunciante.Enabled = false;
                                }
                                else
                                {
                                    this._grpDenunciante.Enabled = true;
                                }
                            }
                            if (objTipo.Descripcion.ToUpper().Contains("BROMA"))
                            {
                                //Se cambia a incidencia cerrada
                                this._entIncidencia.ClaveEstatus = 5;
                            }
                            else
                            {
                                //Se verifica si tiene coorporación para ponerle estado 2:
                                CorporacionIncidenciaList lstCorporacionIncidencia = CorporacionIncidenciaMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                                if (lstCorporacionIncidencia != null && lstCorporacionIncidencia.Count > 0)
                                {
                                    //Se cambia a pendiente
                                    this._entIncidencia.ClaveEstatus = 2;
                                }
                                else
                                {
                                    //Se cambia a nueva incidencia
                                    this._entIncidencia.ClaveEstatus = 1;
                                }

                            }

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

        /// <summary>
        /// Guarda la información en el grid de persona extraviada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void dgvPersonaExtraviada_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        /// <summary>
        /// Activa el control de teléfono del propietario cuando se presiona la tecla enter
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtNombrePropietario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTelefonoPropietario.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Guarda los datos del propiterio actualizado en la entidad propietario del vehículo
        /// </summary>
        /// <remarks>Actualiza las tablas de PropietarioVehiculo y VehiculoRobado</remarks>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Activa el control de la descripción del propietario del vehículo cuando se presiona la tecla enter
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtTelefonoPropietario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDireccionPropietario.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Guarda los datos del propiterio actualizado en la entidad propietario del vehículo
        /// </summary>
        /// <remarks>Actualiza las tablas de PropietarioVehiculo y VehiculoRobado</remarks>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Guarda los datos del propiterio actualizado en la entidad propietario del vehículo
        /// </summary>
        /// <remarks>Actualiza las tablas de PropietarioVehiculo y VehiculoRobado</remarks>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Guarda los datos de los vehículos robados
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void dgvVehiculo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        /// <summary>
        /// Activa la fecha para capturar la fecha en que se percataron del robo de accesorios al vehículo
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void chkAccesoriosPercato_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.dtpAccesoriosFechaPercato.Enabled = this.chkAccesoriosPercato.Checked;
                    if (this._entRoboVehiculoAccesorios == null)
                    {
                        this._entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
                        if (this.chkAccesoriosPercato.Checked)
                        {
                            this._entRoboVehiculoAccesorios.FechaPercato = this.dtpAccesoriosFechaPercato.Value;
                        }
                        else
                        {
                            this._entRoboVehiculoAccesorios.FechaPercato = null;
                        }
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
                        if (this.chkAccesoriosPercato.Checked)
                        {
                            this._entRoboVehiculoAccesorios.FechaPercato = this.dtpAccesoriosFechaPercato.Value;
                        }
                        else
                        {
                            this._entRoboVehiculoAccesorios.FechaPercato = null;
                        }
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

        /// <summary>
        /// Activa el control de número de serie cuando se presona la tecla enter en el control de  placas
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtAccesoriosPlacas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosSerie.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Guarda la información del vehículo al cual le robaron los accesorios, cuando se sale del control placas
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Activa el control de accesorios robados cuando se presiona la tecla enter
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtAccesoriosSerie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosRobados.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Guarda la información del vehículo al cual le robaron accesorios se sale del control serie
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Activa el control de la persona que se percató del robo cuando se presiona la tecla enter en el control de accesorios robados
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtAccesoriosRobados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosPersonaSePercato.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Guarda la información de los accesorios robados cuando se sale del control de texto de la persona que se percató del robo
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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


        /// <summary>
        /// Activa el control de fecha en que se percataron del robo cuando se presiona enter en el control  de la persona que se percató del robo
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtAccesoriosPersonaSePercato_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpAccesoriosFechaPercato.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Guarda la información de los accesorios robados cuando se sale del control de la persona que se percató del robo
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void dtpAccesoriosFechaPercato_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAccesoriosResponsables.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtAccesoriosResponsables_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvVehiculoAccesorios.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
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

        /// <summary>
        /// Guarda la información de los vehículos involucrados cuando la incidencia es sobre un robo de accesorios de vehículo
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void dgvVehiculoAccesorios_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        /// <summary>
        /// Guarda la información en el grid de persona extraviada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPersonaExtraviada_CellValidated(object sender, DataGridViewCellEventArgs e)
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


                if (!(this.dgvPersonaExtraviada[0, e.RowIndex].Value == null))
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            strNombre = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            try
                            {
                                intEdad = int.Parse(dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString());
                                if (intEdad <= 0)
                                {
                                    dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                    //e.Cancel = true;
                                    throw new SAIExcepcion("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", this);
                                }
                                entPersonaExtraviada.Edad = intEdad;
                            }
                            catch
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                //e.Cancel = true;
                                throw new SAIExcepcion("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", this);
                            }
                        }

                        break;
                    case 4: //Sexo
                        String strSexo;
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            strSexo = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
                            strSexo = strSexo.ToUpper();
                            if (strSexo != "F" && strSexo != "M")
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                //e.Cancel = true;
                                throw new SAIExcepcion("El valor del sexo no se encuentra en el formato correcto, debe de ser F (Femenino) y M (Masculino)", this);
                            }

                            dgvPersonaExtraviada.CurrentCell.Value = strSexo;
                            entPersonaExtraviada.Sexo = strSexo;
                        }

                        break;
                    case 5://Estatura
                        float fltEstatura;
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            try
                            {
                                fltEstatura = float.Parse(dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString());
                                if (fltEstatura <= 0)
                                {
                                    dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                    dgvPersonaExtraviada.Refresh();
                                    //e.Cancel = true;
                                    throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
                                }
                                entPersonaExtraviada.Estatura = fltEstatura;
                            }
                            catch
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                dgvPersonaExtraviada.Refresh();
                                //e.Cancel = true;
                                throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
                            }
                        }
                        break;
                    case 6: //Parentesco

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strParentesco;
                            strParentesco = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            try
                            {
                                dtmFecha = DateTime.Parse(dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString());
                                if (dtmFecha > DateTime.Today)
                                {
                                    dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                    //e.Cancel = true;
                                    throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                                }
                                entPersonaExtraviada.FechaExtravio = dtmFecha;
                            }
                            catch
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                //e.Cancel = true;
                                throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                            }
                        }
                        break;
                    case 8:// Tez

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strTez;
                            strTez = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strTipoCabello;
                            strTipoCabello = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strColorCabello;
                            strColorCabello = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strLargoCabello;
                            strLargoCabello = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strFrente;
                            strFrente = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strCejas;
                            strCejas = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
                            if (strCejas.Length > 15)
                            {
                                strCejas = strCejas.Substring(0, 15);
                            }
                            dgvPersonaExtraviada.CurrentCell.Value = strCejas.ToUpper();
                            entPersonaExtraviada.Cejas = strCejas;
                        }

                        break;
                    case 14:// Color de ojos

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strColorOjos;
                            strColorOjos = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strTamañoBoca;
                            strTamañoBoca = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strLabios;
                            strLabios = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strVestimenta;
                            strVestimenta = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strDestino;
                            strDestino = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                        if (dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                        {
                            String strCaracteristicas;
                            strCaracteristicas = dgvPersonaExtraviada[e.ColumnIndex,e.RowIndex].Value.ToString();
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

        /// <summary>
        /// Guarda la información en el grid de vehículo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVehiculo_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            Boolean blnExiste = false;
            VehiculoObject objVehiculo = new VehiculoObject();


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

                            if (dgvVehiculo[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strMarca;
                                strMarca = dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                            if (dgvVehiculo[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strTipo;
                                strTipo = dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                            if (dgvVehiculo[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strModelo;
                                strModelo = dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                            if (dgvVehiculo[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strColor;
                                strColor = dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString();
                                if (strColor.Length > 50)
                                {
                                    strColor = strColor.Substring(0, 50);
                                }
                                strColor = strColor.ToUpper();
                                dgvVehiculo.CurrentCell.Value = strColor;
                                objVehiculo.Color = strColor;
                            }
                            break;

                        case 6://Número de Motor
                            if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strNumeroMotor;
                                strNumeroMotor = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
                                if (strNumeroMotor.Length > 50)
                                {
                                    strNumeroMotor = strNumeroMotor.Substring(0, 50);
                                }
                                strNumeroMotor = strNumeroMotor.ToUpper();
                                dgvVehiculo.CurrentCell.Value = strNumeroMotor;
                                objVehiculo.NumeroMotor = strNumeroMotor;
                            }
                            break;
                        case 7://Número de Serie
                            if (dgvVehiculo[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strNumeroSerie;
                                strNumeroSerie = dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString();
                                if (strNumeroSerie.Length > 50)
                                {
                                    strNumeroSerie = strNumeroSerie.Substring(0, 50);
                                }
                                strNumeroSerie = strNumeroSerie.ToUpper();
                                dgvVehiculo.CurrentCell.Value = strNumeroSerie;
                                objVehiculo.NumeroSerie = strNumeroSerie;
                            }
                            break;
                        case 8://Señas Particulares
                            if (dgvVehiculo[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strSeñasParticulares;
                                strSeñasParticulares = dgvVehiculo[e.ColumnIndex,e.RowIndex].Value.ToString();
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

        /// <summary>
        /// Guarda la información en el grid de vehículos involucrados en un robo a accesorio de vehículos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVehiculoAccesorios_CellValidated(object sender, DataGridViewCellEventArgs e)
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

                            if (dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strMarca;
                                strMarca = dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                            if (dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strTipo;
                                strTipo = dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                            if (dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strModelo;
                                strModelo = dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString();
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
                            if (dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strColor;
                                strColor = dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString();
                                if (strColor.Length > 50)
                                {
                                    strColor = strColor.Substring(0, 50);
                                }
                                strColor = strColor.ToUpper();
                                dgvVehiculoAccesorios.CurrentCell.Value = strColor;
                                objVehiculo.Color = strColor;
                            }
                            break;
                        case 6://Número de Motor
                            if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strNumeroMotor;
                                strNumeroMotor = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
                                if (strNumeroMotor.Length > 50)
                                {
                                    strNumeroMotor = strNumeroMotor.Substring(0, 50);
                                }
                                strNumeroMotor = strNumeroMotor.ToUpper();
                                dgvVehiculo.CurrentCell.Value = strNumeroMotor;
                                objVehiculo.NumeroMotor = strNumeroMotor;
                            }
                            break;
                        case 7://Número de Serie
                            if (dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strNumeroSerie;
                                strNumeroSerie = dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString();
                                if (strNumeroSerie.Length > 50)
                                {
                                    strNumeroSerie = strNumeroSerie.Substring(0, 50);
                                }
                                strNumeroSerie = strNumeroSerie.ToUpper();
                                dgvVehiculoAccesorios.CurrentCell.Value = strNumeroSerie;
                                objVehiculo.NumeroSerie = strNumeroSerie;
                            }
                            break;
                        case 8://Señas Particulares
                            if (dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString().Trim() != string.Empty)
                            {
                                String strSeñasParticulares;
                                strSeñasParticulares = dgvVehiculoAccesorios[e.ColumnIndex,e.RowIndex].Value.ToString();
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

        /// <summary>
        /// Se manda a llamar desde las clases hijas y cambia el estado del control de la lista de tipo de incidencias
        /// </summary>
        /// <param name="blnHabilitado"></param>
        protected void CambiaHabilitadoTipoIncidencia(Boolean blnHabilitado)
        {
            this.cmbTipoIncidencia.Enabled = blnHabilitado;
        }
       
    }
}
