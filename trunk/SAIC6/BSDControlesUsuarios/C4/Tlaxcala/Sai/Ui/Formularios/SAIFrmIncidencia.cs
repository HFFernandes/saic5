using System;
using System.ComponentModel;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// El formulario SIAFrmIncidencia contiene la funcionalidad básica que comparten las incidencias
    /// del sistema 089 y 066, por lo tanto éste no es implementado directamente en la aplicación, sino que hereda
    /// hacia el formulario SIAFrmIncidencia089 y SIAFrmIncidencia066
    /// </summary>
    public partial class SAIFrmIncidencia : SAIFrmBase
    {


        //#region CONSTRUCTORES

        ///// <summary>
        ///// Constructor del formulario SIAFrmIncidencia, se ejecuta cuando se registra una incidencia nueva
        ///// <remarks>El constructor inserta una nueva incidencia en la base de datos y muestra su información en el formulario</remarks>
        ///// </summary>
        //public SAIFrmIncidencia()
        //{
        //    //El try se puso porque en tiempo de diseño se genera una excepción cuando se abren los formularios hijos
        //    try
        //    {

        //        _blnBloqueaEventos = true;

        //        InitializeComponent();

        //        if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //        {
        //            Height = 515;
        //            Width = 600;
        //        }
        //        else
        //        {
        //            Height = 630;
        //            Width = 600;
        //        }

        //        InicializaListas();


        //        //****Crea una nueva incidencia, el formulario se abrió para insertar*******
        //        _entIncidencia.Referencias = string.Empty;
        //        _entIncidencia.Descripcion = string.Empty;
        //        _entIncidencia.Activo = true;
        //        _entIncidencia.HoraRecepcion = DateTime.Now;
        //        _entIncidencia.ClaveEstatus = 1;
        //        _entIncidencia.ClaveEstado = 29;
        //        _entIncidencia.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;
        //        IncidenciaMapper.Instance().Insert(_entIncidencia);

        //        //*************************************************************************
        //        //Se actualiza la información de la incidencia en la lista de ventanas
        //        ActualizaVentanaIncidencias();
        //        //Se muestra la información de la incidencia en el formulario:
        //        // InicializaCampos();
        //        SuspendLayout();
        //        if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //        {
        //            lblDescripcionIncidencia.Text = "Descripción de  \n la Denuncia:";
        //            lblTelefono.Visible = false;
        //            txtTelefono.Visible = false;
        //            lblTipoIncidencia.Left = lblTelefono.Left - 5;
        //            cmbTipoIncidencia.Left = txtTelefono.Left;
        //            lblTipoIncidencia.Text = "Tipo de \n la Denuncia:";
        //            lblTipoIncidencia.Top -= 10;


        //        }
        //        else
        //        {

        //            lblDescripcionIncidencia.Text = "Descripción de  \n la Incidencia:";
        //        }
        //        ResumeLayout(false);
        //        _blnBloqueaEventos = false;

        //        Aplicacion.VentanasIncidencias.Add(new SAIWinSwitchItem(_entIncidencia.Folio.ToString(), "", (this as Form)));
        //    }
        //    catch
        //    {
        //    }


        //}

        ///// <summary>
        ///// Constructor que toma la entidad incidencia que se va a mostrar en el formulario
        ///// </summary>
        ///// <param name="entIncidencia">Entidad incidencia que contiene los valores para mostrar</param>
        ///// <param name="sololectura"> Indica si el formulario será de solo lectura </param>
        //public SAIFrmIncidencia(Incidencia entIncidencia, Boolean sololectura)
        //{

        //    entIncidencia.ClaveEstado = 29;
        //    _blnBloqueaEventos = true;
        //    InitializeComponent();
        //    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //    {
        //        Height = 515;
        //        Width = 600;
        //    }
        //    else
        //    {
        //        Height = 630;
        //        Width = 600;
        //    }
        //    SuspendLayout();
        //    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //    {
        //        lblDescripcionIncidencia.Text = "Descripción de  \n la Denuncia:";
        //        lblTelefono.Visible = false;
        //        txtTelefono.Visible = false;
        //        lblTipoIncidencia.Left = lblTelefono.Left - 5;
        //        cmbTipoIncidencia.Left = txtTelefono.Left;
        //        lblTipoIncidencia.Text = "Tipo de \n la Denuncia:";
        //        lblTipoIncidencia.Top -= 10;
        //    }
        //    else
        //    {
        //        lblDescripcionIncidencia.Text = "Descripción de  \n la Incidencia:";
        //    }

        //    ResumeLayout(false);
        //    InicializaListas();
        //    _entIncidencia = entIncidencia;
        //    _entIncidencia.Activo = true;
        //    //Se actualiza la información de la incidencia en la lista de ventanas
        //    ActualizaVentanaIncidencias();
        //    //Se muestra la información de la incidencia en el formulario:
        //    InicializaCampos();
        //    _blnBloqueaEventos = false;
        //    Aplicacion.VentanasIncidencias.Add(new SAIWinSwitchItem(_entIncidencia.Folio.ToString(), "", (this as Form)));
        //    SoloLectura = sololectura;
        //    cmbTipoIncidencia.BlnEsRequerido = false;
        //}


        //#endregion

        //#region VARIABLES

        ///// <summary>
        ///// Guarda la referencia a la entidad Incidencia que se maneja en el formulario
        ///// </summary>
        //protected Incidencia _entIncidencia = new Incidencia();

        ///// <summary>
        ///// Bandera que indica si se va a limpiar el combo de colonias, lo cual se hace sólo cuando cambia el código postal
        ///// </summary>
        //private Boolean _blnLimpiarColonias;

        ///// <summary>
        ///// Objeto que guarda las claves de municipio, localidad, colonia y código postal que se tienen escogidas por el 
        ///// usuario a cada momento en el formulario
        ///// </summary>
        ///// <remarks>
        ///// Este objeto se pasa al método del la clase controladora del mapa para leer los valores de los id's correspondientes
        ///// </remarks>
        //private Mapa.EstructuraUbicacion _objUbicacion = new Mapa.EstructuraUbicacion();

        ///// <summary>
        ///// Bandera que se utiliza para detener el disparo en cascada de los eventos SelectedIndexChanged
        ///// para las listas de municipios, localidades, colonias y códigos postales.
        ///// </summary>
        //private Boolean _blnBloqueaEventos;

        ///// <summary>
        ///// Esta bandera lleva el estado para saber si el usuario quiso cerrar la ventana, esto para saber
        ///// si se va a guardar la incidencia en los eventos Leave de los controles, si está en falso se guardan
        ///// los datos en dichos eventos, de lo contrario no se guarda la incidencia en tales eventos.
        ///// </summary>
        //protected Boolean _blnSeActivoClosed;

        ///// <summary>
        ///// Guarda los datos del propietario del vehículo, cuando la incidencia es del tipo robo de vehículo
        ///// </summary>
        //protected PropietarioVehiculoObject _objPropietarioVehiculo;

        ///// <summary>
        ///// Guarda los datos de la entidad de accesorios del vehículo, cuando la incidencia es del tipo robo de accesorios de vehículo
        ///// </summary>
        //protected RoboVehiculoAccesorios _entRoboVehiculoAccesorios;

        ///// <summary>
        ///// Guarda los datos de la entidad vehículo, cuando la incidencia es del tipo de robo de accesorios de vehículo
        ///// </summary>
        //protected VehiculoObject _objVeiculoAccesoriosRobado;

        ///// <summary>
        ///// Lleva el estado del caso de la tecla control presionada.
        ///// </summary>
        //protected bool _blnCtrPresionado;

        ///// <summary>
        ///// Guarda el valor de solo lectura del formulario
        ///// </summary>
        //private Boolean _blnSoloLectura;


        //protected GroupBox _grpDenunciante;

        //#endregion

        //#region PROPIEDADES

        ///// <summary>
        ///// Obtiene o establece el valor que indica si el formulario será de solo lectura
        ///// </summary>
        ///// <remarks>Cuando esta propiedad es verdadera, los controles hijos del formulario se convierten a solo lectura</remarks>
        //public Boolean SoloLectura
        //{
        //    get { return _blnSoloLectura; }
        //    set
        //    {
        //        _blnSoloLectura = value;

        //        if (value)
        //        {
        //            foreach (Control objControl in Controls)
        //            {
        //                if (objControl.GetType() == (new GroupBox()).GetType())
        //                {
        //                    continue;
        //                }
        //                if (objControl.GetType().GetProperty("ReadOnly") != null)
        //                {
        //                    objControl.GetType().GetProperty("ReadOnly").SetValue(objControl, true, null);
        //                }
        //                else
        //                {
        //                    objControl.Enabled = false;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            foreach (Control objControl in Controls)
        //            {
        //                if (objControl.GetType() == (new GroupBox()).GetType())
        //                {
        //                    continue;
        //                }
        //                if (objControl.GetType().GetProperty("ReadOnly") != null)
        //                {
        //                    objControl.GetType().GetProperty("ReadOnly").SetValue(objControl, false, null);
        //                }
        //                else
        //                {
        //                    objControl.Enabled = true;
        //                }

        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Establece el texto del combo de código postal.
        ///// </summary>
        //public string TextoCodigoPostal
        //{
        //    set
        //    {
        //        cmbCP.Text = value;
        //    }
        //}

        //public string TextoTelefono
        //{
        //    set
        //    {
        //        txtTelefono.Text = value;
        //    }
        //    get
        //    {
        //        return txtTelefono.Text;
        //    }
        //}

        //#endregion

        //#region MÉTODOS

        ///// <summary>
        ///// Actualiza el combo de localidades 
        ///// </summary>
        ///// <param name="objListaLocalidades">Lista de localidades que se mostrarán en el control</param>
        //private void ActualizaLocalidades(LocalidadList objListaLocalidades)
        //{
        //    cmbLocalidad.DataSource = objListaLocalidades;
        //    cmbLocalidad.DisplayMember = "Nombre";
        //    cmbLocalidad.ValueMember = "Clave";
        //    cmbLocalidad.SelectedIndex = -1;
        //    cmbLocalidad.Text = string.Empty;

        //}

        ///// <summary>
        ///// Limpia el control que contiene la lista de localidades
        ///// </summary>
        //private void LimpiaLocalidades()
        //{
        //    cmbLocalidad.DataSource = null;
        //    cmbLocalidad.Items.Clear();
        //}

        ///// <summary>
        ///// Actualiza la lista de los códigos postales
        ///// </summary>
        ///// <param name="objListaCodigosPostales">Lista de los códigos postales que se mostrarán en el control</param>
        //private void ActualizaCodigosPostales(CodigoPostalList objListaCodigosPostales)
        //{
        //    cmbCP.DataSource = objListaCodigosPostales;
        //    cmbCP.DisplayMember = "Valor";
        //    cmbCP.ValueMember = "Clave";
        //    cmbCP.SelectedIndex = -1;
        //    cmbCP.Text = string.Empty;
        //}

        ///// <summary>
        ///// Limpia el texto del combo de códigos postales
        ///// </summary>
        //private void LimpiaTextoCodigoPostal()
        //{
        //    cmbCP.Text = string.Empty;
        //}

        ///// <summary>
        ///// Selecciona el elemento del combo de codigos postales
        ///// </summary>
        ///// <param name="objElemento">Elemento que se va a seleccionar</param>
        //private void SeleccionaCodigoPostal(Object objElemento)
        //{
        //    cmbCP.SelectedIndex = -1;
        //    cmbCP.SelectedItem = objElemento;

        //}

        ///// <summary>
        ///// Limpia el combo que contiene los códigos postales
        ///// </summary>
        //private void LimpiaCodigosPostales()
        //{
        //    cmbCP.DataSource = null;
        //    cmbCP.Items.Clear();
        //}

        ///// <summary>
        ///// Actualiza la lista de colonias del combo correspondiente
        ///// </summary>
        ///// <param name="lstColonias">Lista de colonias que se van a mostrar en el control</param>
        //private void ActualizaColonias(ColoniaList lstColonias)
        //{
        //    cmbColonia.DataSource = lstColonias;
        //    cmbColonia.DisplayMember = "Nombre";
        //    cmbColonia.ValueMember = "Clave";
        //    cmbColonia.SelectedIndex = -1;
        //    cmbColonia.Text = string.Empty;


        //}

        ///// <summary>
        ///// Limpia el texto del control del combo de colonias
        ///// </summary>
        //private void LimpiaTextoColonia()
        //{
        //    cmbColonia.SelectedIndex = -1;
        //    cmbColonia.Text = string.Empty;
        //}

        ///// <summary>
        ///// Limpia el combo que contiene la lista de colonias
        ///// </summary>
        //private void LimpiaColonias()
        //{
        //    cmbColonia.DataSource = null;
        //    cmbColonia.Items.Clear();
        //}

        ///// <summary>
        ///// Llena la lista para mostrar los tipos de incidencias y municipios
        ///// </summary>
        //private void InicializaListas()
        //{
        //    try
        //    {
        //        try
        //        {
        //            TipoIncidenciaList lstTipoIncidencias = Aplicacion.UsuarioPersistencia.strSistemaActual == "066" ? TipoIncidenciaMapper.Instance().GetBySistema(2) : TipoIncidenciaMapper.Instance().GetBySistema(1);

        //            foreach (var objTipoIncidencia in lstTipoIncidencias)
        //            {
        //                objTipoIncidencia.Descripcion = objTipoIncidencia.ClaveOperacion + " " + objTipoIncidencia.Descripcion;
        //            }
        //            cmbTipoIncidencia.DataSource = lstTipoIncidencias;
        //            cmbTipoIncidencia.DisplayMember = "Descripcion";
        //            cmbTipoIncidencia.ValueMember = "Clave";

                   

        //            var lstMunicipios = MunicipioMapper.Instance().GetAll();
        //            cmbMunicipio.DataSource = lstMunicipios;
        //            cmbMunicipio.DisplayMember = "Nombre";
        //            cmbMunicipio.ValueMember = "Clave";

        //            cmbMunicipio.SelectedIndex = -1;
        //            //cmbMunicipio.Text = string.Empty;


        //        }
        //        catch (Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Pone los valores correspondientes en los controles del formulario, según los datos de la incidencia
        ///// </summary>
        //private void InicializaCampos()
        //{
        //    Usuario entUsuario;
        //    TipoIncidencia entTipoIncidenciaElemento;
        //    Municipio entMunicipio;
        //    LocalidadList objListaLocalidades;
        //    ColoniaList objListaColonias;
        //    CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
        //    CodigoPostal entCodigoPostal;
        //    bool blnExisteCodigoPostal = false;
        //    int i;

        //    try
        //    {
        //        try
        //        {
        //            entUsuario = UsuarioMapper.Instance().GetOne(_entIncidencia.ClaveUsuario);
        //            lblOperador.Text = entUsuario.NombrePropio;
        //            lblFechaHora.Text = _entIncidencia.HoraRecepcion.ToString();
        //            Text = _entIncidencia.Folio.ToString();
        //            txtTelefono.Text = _entIncidencia.Telefono;
        //            txtDireccion.Text = _entIncidencia.Direccion;

        //            if (_entIncidencia.ClaveTipo.HasValue)
        //            {
        //                //TipoIncidencia entTipoIncidencia = TipoIncidenciaMapper.Instance().GetOne( _entIncidencia.ClaveTipo.Value);
        //                // cmbTipoIncidencia.SelectedItem = entTipoIncidencia;

        //                foreach (var elemento in cmbTipoIncidencia.Items)
        //                {
        //                    entTipoIncidenciaElemento = (TipoIncidencia)elemento;
        //                    if (_entIncidencia.ClaveTipo.Value == entTipoIncidenciaElemento.Clave)
        //                    {
        //                        cmbTipoIncidencia.SelectedIndex = -1;
        //                        cmbTipoIncidencia.SelectedItem = entTipoIncidenciaElemento;
        //                        break;
        //                    }
        //                }
        //            }
        //            //Datos de la ubicación
        //            if (_entIncidencia.ClaveEstado.HasValue && _entIncidencia.ClaveMunicipio.HasValue)
        //            {
        //                foreach (var elemento in cmbMunicipio.Items)
        //                {
        //                    entMunicipio = (Municipio)elemento;
        //                    if (_entIncidencia.ClaveMunicipio.Value == entMunicipio.Clave)
        //                    {
        //                        cmbMunicipio.SelectedIndex = -1;
        //                        cmbMunicipio.SelectedItem = entMunicipio;
        //                        break;
        //                    }
        //                }

        //                //Se recuperan las localidades del municipio
        //                if (_entIncidencia.ClaveLocalidad.HasValue)
        //                {
        //                    objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio((cmbMunicipio.SelectedItem as Municipio).Clave);
        //                    if (objListaLocalidades != null)
        //                    {
        //                        cmbLocalidad.DataSource = objListaLocalidades;
        //                        cmbLocalidad.DisplayMember = "Nombre";
        //                        cmbLocalidad.ValueMember = "Clave";
        //                        cmbLocalidad.SelectedIndex = -1;
        //                    }


        //                    //Se ubica la localidad
        //                    foreach (var elemento in cmbLocalidad.Items)
        //                    {

        //                        if (_entIncidencia.ClaveLocalidad.Value == (elemento as Localidad).Clave)
        //                        {
        //                            cmbLocalidad.SelectedIndex = -1;
        //                            cmbLocalidad.SelectedItem = elemento;
        //                            break;
        //                        }
        //                    }

        //                    if (_entIncidencia.ClaveCodigoPostal.HasValue)
        //                    {
        //                        //Se recuperan los códigos postales del municipio
        //                        for (i = 0; i < objListaLocalidades.Count; i++)
        //                        {
        //                            objListaColonias = ColoniaMapper.Instance().GetByLocalidad(objListaLocalidades[i].Clave);
        //                            for (int j = 0; j < objListaColonias.Count; j++)
        //                            {
        //                                if (objListaColonias[j].ClaveCodigoPostal.HasValue)
        //                                {
        //                                    entCodigoPostal = CodigoPostalMapper.Instance().GetOne(objListaColonias[j].ClaveCodigoPostal.Value);
        //                                    blnExisteCodigoPostal = false;
        //                                    //Se revisa que el código postal no exista en la lista
        //                                    for (int k = 0; k < objListaCodigosPostales.Count; k++)
        //                                    {
        //                                        if (objListaCodigosPostales[k].Valor == entCodigoPostal.Valor)
        //                                        {
        //                                            blnExisteCodigoPostal = true;
        //                                            break;
        //                                        }
        //                                    }

        //                                    if (!blnExisteCodigoPostal)
        //                                    {
        //                                        objListaCodigosPostales.Add(entCodigoPostal);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        if (objListaCodigosPostales.Count > 0)
        //                        {
        //                            cmbCP.DataSource = objListaCodigosPostales;
        //                            cmbCP.DisplayMember = "Valor";
        //                            cmbCP.ValueMember = "Clave";
        //                            cmbCP.SelectedIndex = -1;


        //                            //Se el código postal
        //                            foreach (var elemento in cmbCP.Items)
        //                            {
        //                                if (_entIncidencia.ClaveCodigoPostal.Value == (elemento as CodigoPostal).Clave)
        //                                {
        //                                    cmbCP.SelectedIndex = -1;
        //                                    cmbCP.SelectedItem = elemento;
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                    if (_entIncidencia.ClaveColonia.HasValue)
        //                    {
        //                        objListaColonias =
        //                            ColoniaMapper.Instance().GetByCodigoPostal(_entIncidencia.ClaveCodigoPostal ?? 0);
        //                        if (objListaColonias != null)
        //                        {
        //                            cmbColonia.DataSource = objListaColonias;
        //                            cmbColonia.DisplayMember = "Nombre";
        //                            cmbColonia.ValueMember = "Clave";
        //                            cmbColonia.SelectedIndex = -1;

        //                            //Se ubica la colonia
        //                            foreach (var elemento in cmbColonia.Items)
        //                            {
        //                                if (_entIncidencia.ClaveColonia.Value == (elemento as Colonia).Clave)
        //                                {
        //                                    cmbColonia.SelectedIndex = -1;
        //                                    cmbColonia.SelectedItem = elemento;
        //                                    break;
        //                                }
        //                            }


        //                        }
        //                    }
        //                }

        //                actualizaMapaUbicacion();
        //            }
        //            //Terminan los datos de la ubicación
        //            txtReferencias.Text = _entIncidencia.Referencias;
        //            txtDescripcion.Text = _entIncidencia.Descripcion;

        //            if (_entIncidencia.TipoIncidenciaEntity.ClaveOperacion == "111")
        //            {
        //                //Datos de Extravio de persona
        //                PersonaExtraviadaList lstPersonasExtraviadas =
        //                    PersonaExtraviadaMapper.Instance().GetByIncidencia(_entIncidencia.Folio);
        //                i = 1;
        //                foreach (PersonaExtraviada entPersonaExtraviada in lstPersonasExtraviadas)
        //                {

        //                    dgvPersonaExtraviada.Rows.Add();

        //                    dgvPersonaExtraviada[0, i - 1].Value = entPersonaExtraviada.Clave;
        //                    dgvPersonaExtraviada[1, i - 1].Value = entPersonaExtraviada.Folio;
        //                    dgvPersonaExtraviada[2, i - 1].Value = entPersonaExtraviada.Nombre;
        //                    if (entPersonaExtraviada.Edad.HasValue)
        //                    {
        //                        dgvPersonaExtraviada[3, i - 1].Value = entPersonaExtraviada.Edad;
        //                    }
        //                    dgvPersonaExtraviada[4, i - 1].Value = entPersonaExtraviada.Sexo;
        //                    if (entPersonaExtraviada.Estatura.HasValue)
        //                    {
        //                        dgvPersonaExtraviada[5, i - 1].Value = entPersonaExtraviada.Estatura;
        //                    }
        //                    dgvPersonaExtraviada[6, i - 1].Value = entPersonaExtraviada.Parentesco;
        //                    dgvPersonaExtraviada[7, i - 1].Value =
        //                        entPersonaExtraviada.FechaExtravio.ToString("dd/MM/aaaa");
        //                    dgvPersonaExtraviada[8, i - 1].Value = entPersonaExtraviada.Tez;
        //                    dgvPersonaExtraviada[9, i - 1].Value = entPersonaExtraviada.TipoCabello;
        //                    dgvPersonaExtraviada[10, i - 1].Value = entPersonaExtraviada.ColorCabello;
        //                    dgvPersonaExtraviada[11, i - 1].Value = entPersonaExtraviada.LargoCabello;
        //                    dgvPersonaExtraviada[12, i - 1].Value = entPersonaExtraviada.Frente;
        //                    dgvPersonaExtraviada[13, i - 1].Value = entPersonaExtraviada.Cejas;
        //                    dgvPersonaExtraviada[14, i - 1].Value = entPersonaExtraviada.OjosColor;
        //                    dgvPersonaExtraviada[15, i - 1].Value = entPersonaExtraviada.OjosForma;
        //                    dgvPersonaExtraviada[16, i - 1].Value = entPersonaExtraviada.NarizForma;
        //                    dgvPersonaExtraviada[17, i - 1].Value = entPersonaExtraviada.BocaTamaño;
        //                    dgvPersonaExtraviada[18, i - 1].Value = entPersonaExtraviada.Labios;
        //                    dgvPersonaExtraviada[19, i - 1].Value = entPersonaExtraviada.Vestimenta;
        //                    dgvPersonaExtraviada[20, i - 1].Value = entPersonaExtraviada.Destino;
        //                    dgvPersonaExtraviada[21, i - 1].Value = entPersonaExtraviada.Caracteristicas;

        //                    i++;

        //                }
        //            }

        //            if (_entIncidencia.TipoIncidenciaEntity.ClaveOperacion == "2003")
        //            {
        //                //Datos de robo de vehículo
        //                VehiculoRobadoObjectList lstVehiculosRobados =
        //                    VehiculoRobadoMapper.Instance().GetByIncidencia(_entIncidencia.Folio);
        //                i = 1;
        //                foreach (VehiculoRobadoObject objVehiculoRobado in lstVehiculosRobados)
        //                {


        //                    if (objVehiculoRobado.ClavePropietario.HasValue)
        //                    {
        //                        PropietarioVehiculoObject objPropietarioVehiculo =
        //                            PropietarioVehiculoMapper.Instance().GetOne(objVehiculoRobado.ClavePropietario.Value);
        //                        if (objPropietarioVehiculo != null)
        //                        {
        //                            txtNombrePropietario.Text = objPropietarioVehiculo.Nombre;
        //                            txtDireccionPropietario.Text = objPropietarioVehiculo.Domicilio;
        //                            txtTelefonoPropietario.Text = objPropietarioVehiculo.Telefono;
        //                            _objPropietarioVehiculo = objPropietarioVehiculo;
        //                        }
        //                    }
        //                    VehiculoObject objVehiculo =
        //                        VehiculoMapper.Instance().GetOne(objVehiculoRobado.ClaveVehiculo);
        //                    if (objVehiculo != null)
        //                    {
        //                        dgvVehiculo.Rows.Add();
        //                        dgvVehiculo[0, i - 1].Value = objVehiculo.Clave;
        //                        dgvVehiculo[1, i - 1].Value = objVehiculo.Marca;
        //                        dgvVehiculo[2, i - 1].Value = objVehiculo.Tipo;
        //                        dgvVehiculo[3, i - 1].Value = objVehiculo.Modelo;
        //                        dgvVehiculo[4, i - 1].Value = objVehiculo.Placas;
        //                        dgvVehiculo[5, i - 1].Value = objVehiculo.Color;
        //                        dgvVehiculo[6, i - 1].Value = objVehiculo.NumeroMotor;
        //                        dgvVehiculo[7, i - 1].Value = objVehiculo.NumeroSerie;
        //                        dgvVehiculo[8, i - 1].Value = objVehiculo.SeñasParticulares;
        //                        i++;
        //                    }


        //                }
        //            }


        //            if (_entIncidencia.TipoIncidenciaEntity.ClaveOperacion == "2004")
        //            {
        //                //Datos de robo de accesorios de vehiculo
        //                //-Se revisa si la incidencia tiene un registro en RoboVehiculoAccesorios:
        //                RoboVehiculoAccesoriosList lstRoboVehiculoAccesorios =
        //                    RoboVehiculoAccesoriosMapper.Instance().GetByIncidencia(_entIncidencia.Folio);
        //                if (lstRoboVehiculoAccesorios != null && lstRoboVehiculoAccesorios.Count > 0)
        //                {
        //                    RoboVehiculoAccesorios entRoboVehiculoAccesorios = lstRoboVehiculoAccesorios[0];
        //                    _entRoboVehiculoAccesorios = entRoboVehiculoAccesorios;

        //                    if (entRoboVehiculoAccesorios.ClaveVehiculo.HasValue)
        //                    {
        //                        VehiculoObject objVehiculo =
        //                            VehiculoMapper.Instance().GetOne(entRoboVehiculoAccesorios.ClaveVehiculo.Value);
        //                        txtAccesoriosPlacas.Text = objVehiculo.Placas;
        //                        txtAccesoriosSerie.Text = objVehiculo.NumeroSerie;
        //                        _objVeiculoAccesoriosRobado = objVehiculo;
        //                    }
        //                    txtAccesoriosRobados.Text = entRoboVehiculoAccesorios.AccesoriosRobados;
        //                    txtAccesoriosPersonaSePercato.Text = entRoboVehiculoAccesorios.SePercato;
        //                    if (entRoboVehiculoAccesorios.FechaPercato.HasValue)
        //                    {
        //                        dtpAccesoriosFechaPercato.Value = entRoboVehiculoAccesorios.FechaPercato.Value;
        //                        dtpAccesoriosFechaPercato.Enabled = true;
        //                        chkAccesoriosPercato.Checked = true;
        //                    }
        //                    else
        //                    {
        //                        dtpAccesoriosFechaPercato.Enabled = false;
        //                        chkAccesoriosPercato.Checked = false;
        //                    }
        //                    txtAccesoriosResponsables.Text = entRoboVehiculoAccesorios.DescripcionResponsables;

        //                    //Se revisa si hay vehículos involucrados
        //                    RoboVehiculoAccesoriosVehiculoInvolucradoObjectList lstRoboVehiculosInv =
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().GetByRoboVehiculoAccesorios(
        //                            entRoboVehiculoAccesorios.Clave);

        //                    if (lstRoboVehiculosInv != null && lstRoboVehiculosInv.Count > 0)
        //                    {
        //                        i = 1;
        //                        foreach (
        //                            RoboVehiculoAccesoriosVehiculoInvolucradoObject objRoboVehiculoInv in
        //                                lstRoboVehiculosInv)
        //                        {
        //                            VehiculoObject objVehiculoInv =
        //                                VehiculoMapper.Instance().GetOne(objRoboVehiculoInv.ClaveVehiculo);
        //                            if (objVehiculoInv != null)
        //                            {
        //                                dgvVehiculoAccesorios.Rows.Add();
        //                                dgvVehiculoAccesorios[0, i - 1].Value = objVehiculoInv.Clave;
        //                                dgvVehiculoAccesorios[1, i - 1].Value = objVehiculoInv.Marca;
        //                                dgvVehiculoAccesorios[2, i - 1].Value = objVehiculoInv.Tipo;
        //                                dgvVehiculoAccesorios[3, i - 1].Value = objVehiculoInv.Modelo;
        //                                dgvVehiculoAccesorios[4, i - 1].Value = objVehiculoInv.Placas;
        //                                dgvVehiculoAccesorios[5, i - 1].Value = objVehiculoInv.Color;
        //                                dgvVehiculoAccesorios[6, i - 1].Value = objVehiculoInv.NumeroMotor;
        //                                dgvVehiculoAccesorios[7, i - 1].Value = objVehiculoInv.NumeroSerie;
        //                                dgvVehiculoAccesorios[8, i - 1].Value = objVehiculoInv.SeñasParticulares;
        //                                i++;
        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //            txtDireccion.Text = _entIncidencia.Direccion;

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }


        //}


        ///// <summary>
        ///// Actualiza la información en la colección global de ventanas de la incidencia actual
        ///// </summary>
        //private void ActualizaVentanaIncidencias()
        //{
        //    try
        //    {
        //        try
        //        {
        //            for (int i = 0; i < Aplicacion.VentanasIncidencias.Count; i++)
        //            {
        //                if (Aplicacion.VentanasIncidencias[i].Ventana == this)
        //                {
        //                    Aplicacion.VentanasIncidencias[i].Folio = _entIncidencia.Folio.ToString();
        //                    if (_entIncidencia.Descripcion != string.Empty)
        //                        Aplicacion.VentanasIncidencias[i].Informacion += "Descripción: " + _entIncidencia.Descripcion;
        //                    //if ( _entIncidencia.ClaveDenunciante.HasValue)
        //                    //{
        //                    //    DenuncianteObject objDenunciante = DenuncianteMapper.Instance().GetOne( _entIncidencia.ClaveDenunciante.Value);
        //                    //    if (objDenunciante.Nombre != string.Empty)
        //                    //    {
        //                    //        Aplicacion.VentanasIncidencias[i].Informacion += "Denunciante: " + objDenunciante.Nombre + " " + objDenunciante.Apellido;
        //                    //    }
        //                    //}
        //                    if (_entIncidencia.Referencias != string.Empty)
        //                        Aplicacion.VentanasIncidencias[i].Informacion += "Referencias: " + _entIncidencia.Referencias;
        //                }
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}

        ///// <summary>
        ///// Recupera los datos de la incidencia que están en el formulario y los guarda en la BD.
        ///// </summary>
        //protected void GuardaIncidencia()
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_entIncidencia != null)
        //            {

        //                if (cmbTipoIncidencia.SelectedItem != null && (
        //                   (cmbTipoIncidencia.SelectedItem as TipoIncidencia).ClaveOperacion.Trim() == "133"
        //                    ||
        //                    (cmbTipoIncidencia.SelectedItem as TipoIncidencia).ClaveOperacion.Trim() == "5047"
        //                    ))
        //                {
        //                    txtDireccion.Text = "SIN REGISTRO";
        //                    //Se cambia a incidencia cancelada
        //                    _entIncidencia.ClaveEstatus = 5;
        //                }

        //                //Si existen objetos de propietario del vehículo, vehiculoaccesorios robados y accesorios robados, se guardan:

        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _objVeiculoAccesoriosRobado.Placas = txtAccesoriosPlacas.Text;
        //                    _objVeiculoAccesoriosRobado.NumeroSerie = txtAccesoriosSerie.Text;
        //                    try
        //                    {
        //                        VehiculoMapper.Instance().Save(_objVeiculoAccesoriosRobado);
        //                    }
        //                    catch { }
        //                }
        //                else if (txtAccesoriosPlacas.Text.Trim() != string.Empty ||
        //                     txtAccesoriosSerie.Text.Trim() != string.Empty)
        //                {
        //                    RoboVehiculoAccesoriosList lstRoboVehiculoAccesorios = RoboVehiculoAccesoriosMapper.Instance().GetByIncidencia(_entIncidencia.Folio);

        //                    if (lstRoboVehiculoAccesorios != null && lstRoboVehiculoAccesorios.Count > 0)
        //                    {
        //                        RoboVehiculoAccesorios objRoboVehiculoAccesorios = lstRoboVehiculoAccesorios[0];
        //                        _objVeiculoAccesoriosRobado = new VehiculoObject();
        //                        _objVeiculoAccesoriosRobado.Placas = txtAccesoriosPlacas.Text;
        //                        _objVeiculoAccesoriosRobado.NumeroSerie = txtAccesoriosSerie.Text;
        //                        VehiculoMapper.Instance().Insert(_objVeiculoAccesoriosRobado);
        //                        objRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                        try
        //                        {
        //                            RoboVehiculoAccesoriosMapper.Instance().Save(objRoboVehiculoAccesorios);
        //                        }
        //                        catch { }
        //                    }



        //                }


        //                if (_objPropietarioVehiculo != null)
        //                {
        //                    _objPropietarioVehiculo.Domicilio = txtNombrePropietario.Text;
        //                    _objPropietarioVehiculo.Nombre = txtNombrePropietario.Text;
        //                    _objPropietarioVehiculo.Telefono = txtTelefono.Text;

        //                    try
        //                    {
        //                        PropietarioVehiculoMapper.Instance().Save(_objPropietarioVehiculo);
        //                    }
        //                    catch { }

        //                }
        //                else if (txtNombrePropietario.Text.Trim() != string.Empty ||
        //                     txtNombrePropietario.Text.Trim() != string.Empty ||
        //                     txtTelefono.Text != string.Empty)
        //                {
        //                    VehiculoRobadoObjectList lstVehiculoRobado = VehiculoRobadoMapper.Instance().GetByIncidencia(_entIncidencia.Folio);

        //                    if (lstVehiculoRobado != null && lstVehiculoRobado.Count > 0)
        //                    {
        //                        _objPropietarioVehiculo = new PropietarioVehiculoObject();
        //                        _objPropietarioVehiculo.Domicilio = txtNombrePropietario.Text;
        //                        _objPropietarioVehiculo.Nombre = txtNombrePropietario.Text;
        //                        _objPropietarioVehiculo.Telefono = txtTelefono.Text;

        //                        PropietarioVehiculoMapper.Instance().Insert(_objPropietarioVehiculo);

        //                        foreach (VehiculoRobadoObject objVehiculoRobado in lstVehiculoRobado)
        //                        {
        //                            objVehiculoRobado.ClavePropietario = _objPropietarioVehiculo.Clave;

        //                            try
        //                            {
        //                                VehiculoRobadoMapper.Instance().Save(objVehiculoRobado);
        //                            }
        //                            catch { }
        //                        }
        //                    }

        //                }

        //                if (_entRoboVehiculoAccesorios != null)
        //                {
        //                    _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                    _entRoboVehiculoAccesorios.SePercato = txtAccesoriosPersonaSePercato.Text;
        //                    if (chkAccesoriosPercato.Checked)
        //                    {
        //                        _entRoboVehiculoAccesorios.FechaPercato = dtpAccesoriosFechaPercato.Value;
        //                    }
        //                    _entRoboVehiculoAccesorios.DescripcionResponsables = txtAccesoriosResponsables.Text;
        //                    try
        //                    {
        //                        RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //                    }
        //                    catch { }
        //                }
        //                else if (txtAccesoriosRobados.Text.Trim() != string.Empty ||
        //                     txtAccesoriosPersonaSePercato.Text.Trim() != string.Empty ||
        //                     chkAccesoriosPercato.Checked ||
        //                      txtAccesoriosResponsables.Text.Trim() != string.Empty)
        //                {
        //                    _entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
        //                    _entRoboVehiculoAccesorios.Folio = _entIncidencia.Folio;
        //                    _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                    _entRoboVehiculoAccesorios.SePercato = txtAccesoriosPersonaSePercato.Text;
        //                    if (chkAccesoriosPercato.Checked)
        //                    {
        //                        _entRoboVehiculoAccesorios.FechaPercato = dtpAccesoriosFechaPercato.Value;
        //                    }
        //                    _entRoboVehiculoAccesorios.DescripcionResponsables = txtAccesoriosResponsables.Text;
        //                    RoboVehiculoAccesoriosMapper.Instance().Insert(_entRoboVehiculoAccesorios);
        //                }
        //                IncidenciaMapper.Instance().Save(_entIncidencia);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Lee los datos del formulario y escribe la información en el objeto de incidencia
        ///// </summary>
        //protected void RecuperaDatosEnIncidencia()
        //{
        //    if (_entIncidencia != null)
        //    {
        //        if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
        //        {
        //            _entIncidencia.ClaveMunicipio = null;
        //        }
        //        else
        //        {
        //            _entIncidencia.ClaveMunicipio = _objUbicacion.IdMunicipio;
        //        }
        //        if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
        //        {
        //            _entIncidencia.ClaveLocalidad = null;
        //        }
        //        else
        //        {
        //            _entIncidencia.ClaveLocalidad = _objUbicacion.IdLocalidad;
        //        }
        //        if (cmbColonia.SelectedIndex == -1 || cmbColonia.Text.Trim() == string.Empty)
        //        {
        //            _entIncidencia.ClaveColonia = null;
        //        }
        //        else
        //        {
        //            _entIncidencia.ClaveColonia = _objUbicacion.IdColonia;
        //        }
        //        if (cmbCP.SelectedIndex == -1 || cmbCP.Text.Trim() == string.Empty)
        //        {
        //            _entIncidencia.ClaveCodigoPostal = null;
        //        }
        //        else
        //        {
        //            _entIncidencia.ClaveCodigoPostal = _objUbicacion.IdCodigoPostal;
        //        }
        //        _entIncidencia.Telefono = txtTelefono.Text;
        //        if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
        //        {
        //            _entIncidencia.ClaveTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave;

        //        }
        //        else
        //        {
        //            _entIncidencia.ClaveTipo = null;
        //        }
        //        _entIncidencia.Descripcion = txtDescripcion.Text;
        //        _entIncidencia.Direccion = txtDireccion.Text;


        //    }

        //}

        ///// <summary>
        ///// Actualiza el mapa con los datos de la ubicación del formulario actuales
        ///// </summary>
        //private void actualizaMapaUbicacion()
        //{

        //    if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
        //    {
        //        _objUbicacion.IdMunicipio = null;
        //    }
        //    else
        //    {
        //        _objUbicacion.IdMunicipio = int.Parse((cmbMunicipio.SelectedItem as Municipio).Clave.ToString());

        //    }

        //    if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
        //    {
        //        _objUbicacion.IdLocalidad = null;
        //    }
        //    else
        //    {
        //        _objUbicacion.IdLocalidad = (cmbLocalidad.SelectedItem as Localidad).Clave;
        //    }

        //    if (cmbColonia.SelectedIndex == -1 || cmbColonia.Text.Trim() == string.Empty)
        //    {
        //        _objUbicacion.IdColonia = null;
        //    }
        //    else
        //    {
        //        _objUbicacion.IdColonia = (cmbColonia.SelectedItem as Colonia).Clave;

        //    }

        //    if (cmbCP.SelectedIndex == -1 || cmbCP.Text.Trim() == string.Empty)
        //    {
        //        _objUbicacion.IdCodigoPostal = null;
        //    }
        //    else
        //    {
        //        _objUbicacion.IdCodigoPostal = (cmbCP.SelectedItem as CodigoPostal).Clave;

        //    }


        //    Mapa.Controlador.MuestraMapa(_objUbicacion, this);
        //}

        //#endregion

        //#region DELEGADOS

        ////public delegate void DelegadoActualizaLocalidades(LocalidadList lstLocalidades);
        ////public delegate void DelegadoLimpiaLocalidades();
        ////public delegate void DelegadoActualizaCodigosPostales(CodigoPostalList lstCodigosPostales);
        ////public delegate void DelegadoLimpiaCodigosPostales();
        ////public delegate void DelegadoActualizaColonias(ColoniaList lstColonias);
        ////public delegate void DelegadoLimpiaColonias();
        ////public delegate void DelegadoLimpiaTextoCodigPostal();
        ////public delegate void DelegadoSeleccionaCodigoPostal(Object objElemento);
        ////public delegate void DelegadoLimpiaTextoColonia();

        //#endregion

        //#region MANEJADORES DE EVENTOS

        ///// <summary>
        ///// Hace la llamada a la función de la ventana Owner para mostrar el control switch
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnKeyUp(KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Tab && _blnCtrPresionado)
        //    {
        //        if (Owner != null)
        //        {
        //            var frmPrincipal = (SAIFrmComandos)Owner;
        //            frmPrincipal.MuestraSwitch();
        //        }

        //    }
        //    _blnCtrPresionado = false;
        //    base.OnKeyUp(e);
        //}



        ///// <summary>
        ///// Actualiza la ubicación del mapa cuando el formulario es activado
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnActivated(EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            base.OnActivated(e);
        //            actualizaMapaUbicacion();
        //            _blnSeActivoClosed = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}



        //#region Eventos del combo MUNICIPIO


        ///// <summary>
        ///// Implementa el evento cambia mapa del control SAIComboBox
        ///// </summary>
        //private void cmbMunicipio_CambiaMapa()
        //{
        //    cmbMunicipioRefrescaControles();
        //}

        ///// <summary>
        ///// Recarga los controles de localidades y códigos postales con base al municipio seleccioando
        ///// </summary>
        //private void cmbMunicipioRefrescaControles()
        //{
        //    LocalidadList objListaLocalidades;
        //    ColoniaList objListaColonias;
        //    CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
        //    CodigoPostal entCodigoPostal;
        //    bool blnExisteCodigoPostal;
        //    //Thread tr1;
        //    //Thread tr2;
        //    //Thread tr3;

        //    try
        //    {
        //        try
        //        {
        //            Cursor = Cursors.WaitCursor;

        //            if (_blnBloqueaEventos)
        //            {
        //                Cursor = Cursors.Default;
        //                return;
        //            }

        //            _blnBloqueaEventos = true;
        //            //tr1 = new Thread(delegate()
        //            //{
        //            //     cmbLocalidad.Invoke(new DelegadoLimpiaLocalidades(LimpiaLocalidades));
        //            //     cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));
        //            //     cmbCP.Invoke(new DelegadoLimpiaCodigosPostales(LimpiaCodigosPostales));

        //            //}) { IsBackground = false };

        //            //tr1.Start();
        //            LimpiaLocalidades();
        //            LimpiaColonias();
        //            LimpiaCodigosPostales();

        //            if (cmbMunicipio.SelectedItem == null)
        //            {
        //                Cursor = Cursors.Default;
        //                return;
        //            }

        //            objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio((cmbMunicipio.SelectedItem as Municipio).Clave);
        //            if (objListaLocalidades != null)
        //            {
        //                //tr1.Abort();
        //                //tr1 = new Thread(delegate()
        //                //{
        //                //     cmbLocalidad.Invoke(new DelegadoActualizaLocalidades(ActualizaLocalidades), new object[] { objListaLocalidades });
        //                //}) { IsBackground = false };
        //                //tr1.Start();

        //                ActualizaLocalidades(objListaLocalidades);
        //                //Se recuperan los códigos postales del municipio
        //                for (int i = 0; i < objListaLocalidades.Count; i++)
        //                {
        //                    objListaColonias = ColoniaMapper.Instance().GetByLocalidad(objListaLocalidades[i].Clave);
        //                    for (int j = 0; j < objListaColonias.Count; j++)
        //                    {
        //                        if (objListaColonias[j].ClaveCodigoPostal.HasValue)
        //                        {
        //                            entCodigoPostal = CodigoPostalMapper.Instance().GetOne(objListaColonias[j].ClaveCodigoPostal.Value);
        //                            blnExisteCodigoPostal = false;
        //                            //Se revisa que el código postal no exista en la lista
        //                            for (int k = 0; k < objListaCodigosPostales.Count; k++)
        //                            {
        //                                if (objListaCodigosPostales[k].Valor == entCodigoPostal.Valor)
        //                                {
        //                                    blnExisteCodigoPostal = true;
        //                                    break;
        //                                }
        //                            }

        //                            if (!blnExisteCodigoPostal)
        //                            {
        //                                objListaCodigosPostales.Add(entCodigoPostal);
        //                            }
        //                        }
        //                    }

        //                }

        //                if (objListaCodigosPostales.Count > 0)
        //                {
        //                    //tr1.Abort();
        //                    //tr1 = new Thread(delegate()
        //                    //{
        //                    //     cmbCP.Invoke(new DelegadoActualizaCodigosPostales(ActualizaCodigosPostales), new object[] { objListaCodigosPostales });
        //                    //}) { IsBackground = false };
        //                    //tr1.Start();
        //                    ActualizaCodigosPostales(objListaCodigosPostales);
        //                }

        //            }
        //            _blnBloqueaEventos = false;
        //            actualizaMapaUbicacion();

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }

        //}

        ///// <summary>
        ///// Recupera las localidades y los códigos postales del municipio seleccionado
        ///// </summary>
        ///// <param name="sender">Objeto que causó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    cmbMunicipioRefrescaControles();

        //}




        //#endregion

        //#region Eventos del combo LOCALIDAD

        ///// <summary>
        ///// Recupera las colonias de la localidad seleccionada
        ///// </summary>
        ///// <param name="sender">Objeto que causó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    ColoniaList lstColonias;

        //    try
        //    {
        //        try
        //        {
        //            if (_blnBloqueaEventos)
        //            {
        //                return;
        //            }

        //            _blnBloqueaEventos = true;

        //            LimpiaColonias();

        //            if (cmbLocalidad.SelectedItem != null)
        //            {
        //                lstColonias = ColoniaMapper.Instance().GetByLocalidad((cmbLocalidad.SelectedItem as Localidad).Clave);
        //            }
        //            else
        //            {
        //                lstColonias = null;
        //            }

        //            if (lstColonias != null)
        //            {
        //                ActualizaColonias(lstColonias);
        //                LimpiaTextoCodigoPostal();
        //            }


        //            _blnBloqueaEventos = false;
        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}

        ///// <summary>
        ///// Actualiza el mapa cuando cambia el texto del combo de localidad
        ///// </summary>
        ///// <param name="sender">Objeto que causó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbLocalidad_TextUpdate(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Manda el foco del campo Localidad al campo Codigo postal cuando se presiona y se suelta la tecla intro
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbLocalidad_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        cmbCP.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);

        //}


        ///// <summary>
        ///// Guarda la incidencia con la localidad seleccionada
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbLocalidad_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
        //            {
        //                //var tr = new Thread(delegate()
        //                //{
        //                //    try
        //                //    {
        //                //         cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));
        //                //    }
        //                //    catch { }
        //                //}) { IsBackground = false };
        //                //tr.Start();
        //                LimpiaColonias();

        //            }
        //            actualizaMapaUbicacion();
        //            if (!_blnSeActivoClosed)
        //            {
        //                RecuperaDatosEnIncidencia();
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        //#endregion

        //#region Eventos del combo COLONIA
        ///// <summary>
        ///// Selecciona el código postal del combo de códigos postales según la colonia seleccionada
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Colonia entColonia = null;

        //    try
        //    {
        //        try
        //        {
        //            if (_blnBloqueaEventos)
        //            {
        //                return;
        //            }

        //            _blnBloqueaEventos = true;
        //            if (cmbColonia.SelectedIndex != -1 && cmbColonia.Text.Trim() != string.Empty)
        //            {
        //                entColonia = (Colonia)cmbColonia.SelectedItem;

        //                if (entColonia.ClaveCodigoPostal.HasValue)
        //                {
        //                    _entIncidencia.ClaveCodigoPostal = entColonia.ClaveCodigoPostal.Value;
        //                    foreach (var objElemento in cmbCP.Items)
        //                    {
        //                        if ((objElemento as CodigoPostal).Clave == entColonia.ClaveCodigoPostal)
        //                        {

        //                            _blnLimpiarColonias = false;
        //                            //selecciona codigo postal
        //                            //var tr = new Thread(delegate()
        //                            //{
        //                            //     cmbCP.Invoke(new DelegadoSeleccionaCodigoPostal(SeleccionaCodigoPostal), new object[]{objElemento});

        //                            //}) { IsBackground = false };
        //                            //tr.Start();
        //                            SeleccionaCodigoPostal(objElemento);
        //                            break;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    _entIncidencia.ClaveCodigoPostal = null;
        //                }
        //                _entIncidencia.ClaveColonia = entColonia.Clave;
        //            }
        //            else
        //            {
        //                _entIncidencia.ClaveColonia = null;
        //            }

        //            _blnBloqueaEventos = false;
        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}

        ///// <summary>
        ///// Guarda la incidencia con la colonia seleccionada y guarda la colonia en caso de ser una colonia nueva
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbColonia_Leave(object sender, EventArgs e)
        //{
        //    Colonia entColonia = null;
        //    ColoniaList lstColonias;
        //    CodigoPostal entCP;
        //    Localidad entLoc;

        //    _blnBloqueaEventos = true;

        //    try
        //    {
        //        try
        //        {
        //            if (cmbColonia.SelectedIndex == -1 && cmbColonia.Text.Trim() != string.Empty)
        //            {

        //                //Se revisa que sea una colonia nueva:
        //                lstColonias = ColoniaMapper.Instance().GetAll();
        //                for (int i = 0; i < lstColonias.Count; i++)
        //                {
        //                    if (cmbColonia.Text.Trim().ToLower().Replace(" ", "").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u") ==
        //                        lstColonias[i].Nombre.ToLower().Replace(" ", "").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u"))
        //                    {
        //                        entColonia = lstColonias[i];
        //                        break;
        //                    }
        //                }
        //                //Si entColonia es nulo, entonces se trata de una nueva colonia:
        //                if (entColonia == null && cmbLocalidad.SelectedIndex != -1 && cmbCP.SelectedIndex != -1)
        //                {
        //                    if (MessageBox.Show("La colonia indicada no se encuentra en la base de datos. ¿Desea Agregarla?", "SAI C4", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //                    {
        //                        entColonia = new Colonia();
        //                        entCP = (CodigoPostal)cmbCP.SelectedItem;
        //                        entLoc = (Localidad)cmbLocalidad.SelectedItem;
        //                        entColonia.ClaveCodigoPostal = entCP.Clave;
        //                        entColonia.ClaveLocalidad = entLoc.Clave;
        //                        entColonia.Nombre = cmbColonia.Text;
        //                        ColoniaMapper.Instance().Insert(entColonia);
        //                        MessageBox.Show("La colonia se registró satisfactoriamente");
        //                        lstColonias = ColoniaMapper.Instance().GetByLocalidad(entLoc.Clave);
        //                        if (lstColonias.Count > 0)
        //                        {
        //                            //var tr = new Thread(delegate()
        //                            // {
        //                            //      cmbCP.Invoke(new DelegadoActualizaColonias(ActualizaColonias), new object[] { lstColonias });

        //                            // }) { IsBackground = false };
        //                            // tr.Start();
        //                            ActualizaColonias(lstColonias);

        //                        }
        //                        else
        //                        {

        //                            //var tr2 = new Thread(delegate()
        //                            //{
        //                            //     cmbColonia.Invoke(new DelegadoLimpiaColonias(LimpiaColonias));

        //                            //}) { IsBackground = false };
        //                            //tr2.Start();
        //                            LimpiaColonias();

        //                        }
        //                    }
        //                    else
        //                    {
        //                        //var trd = new Thread(delegate()
        //                        //{
        //                        //     cmbColonia.Invoke(new DelegadoLimpiaTextoColonia (LimpiaTextoColonia));

        //                        //}) { IsBackground = false };
        //                        //trd.Start();
        //                        LimpiaTextoColonia();
        //                    }
        //                }
        //                else if (entColonia != null)
        //                {
        //                    if (entColonia.ClaveCodigoPostal.HasValue)
        //                    {
        //                        foreach (var objElemento in cmbCP.Items)
        //                        {
        //                            if ((objElemento as CodigoPostal).Clave == entColonia.ClaveCodigoPostal)
        //                            {
        //                                //var tr3 = new Thread(delegate()
        //                                //{
        //                                //     cmbCP.Invoke(new DelegadoSeleccionaCodigoPostal(SeleccionaCodigoPostal), new object[] { objElemento });

        //                                //}) { IsBackground = false };
        //                                //tr3.Start();
        //                                SeleccionaCodigoPostal(objElemento);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else if (cmbColonia.Text.Trim() != string.Empty)
        //            {
        //                entColonia = (Colonia)cmbColonia.SelectedItem;
        //                if (entColonia.ClaveCodigoPostal.HasValue)
        //                {
        //                    foreach (var objElemento in cmbCP.Items)
        //                    {
        //                        if ((objElemento as CodigoPostal).Clave == entColonia.ClaveCodigoPostal)
        //                        {
        //                            //var tr4 = new Thread(delegate()
        //                            //{
        //                            //     cmbCP.Invoke(new DelegadoSeleccionaCodigoPostal(SeleccionaCodigoPostal), new object[] { objElemento });

        //                            //}) { IsBackground = false };
        //                            //tr4.Start();
        //                            SeleccionaCodigoPostal(objElemento);
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            _blnBloqueaEventos = false;
        //            actualizaMapaUbicacion();
        //            if (!_blnSeActivoClosed)
        //            {
        //                RecuperaDatosEnIncidencia();
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Manda el foco del campo Colonia al campo Descripción cuando se presiona y se suelta la tecla intro
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbColonia_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtReferencias.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);

        //}

        ///// <summary>
        ///// Actualiza el mapa cuando cambia el texto del como colonia
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbColonia_TextUpdate(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        //#endregion

        //#region Eventos del combo CP

        ///// <summary>
        ///// Quita la selección de la colonia
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbCP_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_blnBloqueaEventos)
        //            {
        //                return;
        //            }

        //            _blnBloqueaEventos = true;
        //            if (_blnLimpiarColonias)
        //            {
        //                //var trd = new Thread(delegate()
        //                //{
        //                //     cmbColonia.Invoke(new DelegadoLimpiaTextoColonia(LimpiaTextoColonia));

        //                //}) { IsBackground = false };
        //                //trd.Start();
        //                LimpiaTextoColonia();
        //            }
        //            _blnBloqueaEventos = false;

        //            if (cmbCP.SelectedIndex != -1 && cmbCP.Text.Trim() != string.Empty)
        //            {
        //                _entIncidencia.ClaveCodigoPostal = (cmbCP.SelectedItem as CodigoPostal).Clave;
        //            }
        //            else
        //            {
        //                _entIncidencia.ClaveCodigoPostal = null;
        //            }



        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la incidencia con el código postal seleccionado
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbCP_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            actualizaMapaUbicacion();
        //            if (!_blnSeActivoClosed)
        //            {
        //                RecuperaDatosEnIncidencia();
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Manda el foco del campo Código Postal al campo Colonia cuando se presiona y se suelta la tecla intro
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbCP_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        cmbColonia.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);

        //}

        ///// <summary>
        ///// Actualiza el mapa cuando se cambia el texto de la lista de códigos postales
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbCP_TextUpdate(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}


        ///// <summary>
        ///// Prende la bandera que indica que se puede limpiar el texto de la lista de colonias
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbCP_Enter(object sender, EventArgs e)
        //{
        //    _blnLimpiarColonias = true;
        //}

        //#endregion


        //private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //No permite introducir texto
        //    if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
        //        e.Handled = true;
        //}

        ///// <summary>
        ///// Manda el foco del campo teléfono al campo Tipo Incidencia cuando se presiona y se suelta la tecla intro
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámentros del evento</param>
        //private void txtTelefono_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        cmbTipoIncidencia.Focus();
        //    }


        //    SAIFrmIncidenciaKeyUp(e);

        //}


        ///// <summary>
        ///// Manda el foco del campo Tipo Incidencia al campo Dirección cuando se presona y se suelta la tecla intro
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbTipoIncidencia_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtDireccion.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);

        //}

        ///// <summary>
        ///// Manda el foco del campo Direccion al campo Municipio cuando se presiona y se suelta la tecla intro
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtDireccion_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        cmbMunicipio.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);

        //}


        ///// <summary>
        ///// Valida los controles obligatorios del formulario y cierra el mapa en caso de que ya no existan
        ///// más instancias del formulario en memoria.
        ///// </summary>
        ///// <param name="e">Parámetros del evento</param>
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (!base.SAIProveedorValidacion.ValidarCamposRequeridos(this) && !_blnSoloLectura)
        //            {

        //                if (cmbTipoIncidencia.Items.Count != 0)
        //                {
        //                    e.Cancel = true;
        //                    throw new SAIExcepcion("Debe de indicar el tipo de incidencia", this);
        //                }
        //                return;

        //            }

        //            if (cmbTipoIncidencia.Enabled)
        //            {
        //                if (cmbTipoIncidencia.SelectedItem != null && (
        //                   (cmbTipoIncidencia.SelectedItem as TipoIncidencia).ClaveOperacion.Trim() == "133"
        //                    ||
        //                    (cmbTipoIncidencia.SelectedItem as TipoIncidencia).ClaveOperacion.Trim() == "5047"
        //                    )
        //                    && txtTelefono.Text.Trim() == string.Empty
        //                    )
        //                {
        //                    e.Cancel = true;
        //                    throw new SAIExcepcion("Debe de indicar el número de teléfono de la incidencia", this);
        //                }
        //            }

        //            Mapa.Controlador.RevisaInstancias(this);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Quita el elemento de la lista de ventanas cuando la ventana ya se ha cerrado
        ///// </summary>
        ///// <param name="e">Parámetros del evento</param>
        //protected override void OnClosed(EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            _blnSeActivoClosed = true;
        //            try
        //            {
        //                RecuperaDatosEnIncidencia();
        //                GuardaIncidencia();
        //            }
        //            catch { }

        //            base.OnClosed(e);
        //            foreach (SAIWinSwitchItem objVentanaSwitch in Aplicacion.VentanasIncidencias)
        //            {
        //                if (this == objVentanaSwitch.Ventana)
        //                {
        //                    Aplicacion.VentanasIncidencias.Remove(objVentanaSwitch);
        //                    break;
        //                }
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}



        ///// <summary>
        ///// Guarda la incidencia con el teléfono actualizado
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtTelefono_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            _entIncidencia.Telefono = txtTelefono.Text;
        //            if (!_blnSeActivoClosed)
        //            {
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la incidencia con el tipo de incidencia actualizado
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbTipoIncidencia_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
        //            {
        //                _entIncidencia.ClaveTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave;
        //            }
        //            else
        //            {
        //                _entIncidencia.ClaveTipo = null;
        //            }
        //            if (!_blnSeActivoClosed)
        //            {
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la incidencia con la descripción de la incidencia actualizada
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtDescripcion_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            _entIncidencia.Descripcion = txtDescripcion.Text;
        //            if (!_blnSeActivoClosed)
        //            {
        //                GuardaIncidencia();
        //                //Se actualiza la información de la incidencia en la ventana switch

        //                foreach (SAIWinSwitchItem objSwitch in Aplicacion.VentanasIncidencias)
        //                {
        //                    if ((this as Form) == objSwitch.Ventana)
        //                    {
        //                        objSwitch.Informacion = txtDescripcion.Text;
        //                        break;
        //                    }
        //                }

        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la incidencia con la dirección de la incidencia actualizada
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtDireccion_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            _entIncidencia.Direccion = txtDireccion.Text;
        //            if (!_blnSeActivoClosed)
        //            {
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la incidencia con las referencias de la incidencia actualizada
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtReferencias_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            _entIncidencia.Referencias = txtReferencias.Text;
        //            if (!_blnSeActivoClosed)
        //            {
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Muestra la ventana para hacer el switch entre incidencias abiertas en caso de que Ctrl+tab estén presionados
        ///// </summary>
        ///// <param name="e">Parámetros del evento</param>
        //protected void SAIFrmIncidenciaKeyUp(KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Tab &&  _blnCtrPresionado)
        //    //{
        //    //    if ( Owner != null)
        //    //    {
        //    //        SAIFrmComandos frmPrincipal = (SAIFrmComandos) Owner;
        //    //        frmPrincipal.MuestraSwitch();
        //    //    }

        //    //}
        //    // _blnCtrPresionado = false;
        //}

        ///// <summary>
        ///// Detecta cuando se presionó la tecla control
        ///// </summary>
        ///// <returns></returns>
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    //if (keyData == (Keys.ControlKey | Keys.Control))
        //    //{
        //    //     _blnCtrPresionado = true;
        //    //}
        //    if ((keyData == (Keys.LButton | Keys.Back | Keys.Control)))
        //    {
        //        if (Owner != null)
        //        {
        //            SAIFrmComandos frmPrincipal = (SAIFrmComandos)Owner;
        //            frmPrincipal.MuestraSwitch();
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Muestra u oculta la información adicional según el tipo de incidencia
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void cmbTipoIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (Aplicacion.UsuarioPersistencia.blnEsDespachador.HasValue && Aplicacion.UsuarioPersistencia.blnEsDespachador.Value == true)
        //            {
        //                return;
        //            }

        //            if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
        //            {
        //                TipoIncidencia objTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia);



        //                if (objTipo.ClaveOperacion.Trim() == "2003")
        //                {
        //                    //Robo de vehículo totalidad
        //                    SuspendLayout();
        //                    grpExtravio.Visible = false;
        //                    grpRoboVehiculo.Visible = true;
        //                    grpRoboAccesorios.Visible = false;


        //                    grpRoboAccesorios.SuspendLayout();
        //                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //                    {

        //                        Height = 870;
        //                        Width = 620;
        //                        grpRoboVehiculo.Top = 645;


        //                    }
        //                    else
        //                    {
        //                        Height = 830;
        //                        Width = 600;
        //                        grpRoboVehiculo.Top = 534;

        //                    }
        //                    grpRoboVehiculo.Left = 10;
        //                    grpRoboVehiculo.Refresh();
        //                    grpRoboAccesorios.ResumeLayout(true);

        //                    ResumeLayout(false);
        //                    PerformLayout();
        //                }


        //                else if (objTipo.ClaveOperacion.Trim() == "2004")
        //                {
        //                    //Robo de vehículo accesorios
        //                    SuspendLayout();
        //                    grpExtravio.Visible = false;
        //                    grpRoboVehiculo.Visible = false;

        //                    grpRoboAccesorios.SuspendLayout();
        //                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //                    {
        //                        Height = 870;
        //                        Width = 620;
        //                        grpRoboAccesorios.Top = 645;
        //                    }
        //                    else
        //                    {
        //                        Height = 830;
        //                        Width = 600;
        //                        grpRoboAccesorios.Top = 534;
        //                    }
        //                    grpRoboAccesorios.Left = 10;
        //                    grpRoboAccesorios.Refresh();
        //                    grpRoboAccesorios.ResumeLayout(true);
        //                    grpRoboAccesorios.Visible = true;

        //                    ResumeLayout(false);
        //                    PerformLayout();

        //                }
        //                else if (objTipo.ClaveOperacion.Trim() == "111")
        //                {
        //                    //Extravío de persona
        //                    SuspendLayout();
        //                    grpExtravio.Visible = true;
        //                    grpRoboVehiculo.Visible = false;
        //                    grpRoboAccesorios.Visible = false;

        //                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //                    {
        //                        Height = 870;
        //                        Width = 620;
        //                        grpExtravio.Top = 645;
        //                    }
        //                    else
        //                    {
        //                        Height = 830;
        //                        Width = 600;
        //                        grpExtravio.Top = 534;
        //                    }
        //                    grpExtravio.Left = 10;
        //                    ResumeLayout(false);
        //                    PerformLayout();

        //                }
        //                else
        //                {
        //                    SuspendLayout();
        //                    grpExtravio.Visible = false;
        //                    grpRoboVehiculo.Visible = false;
        //                    grpRoboAccesorios.Visible = false;
        //                    if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
        //                    {
        //                        Height = 715;
        //                        Width = 600;

        //                    }
        //                    else
        //                    {
        //                        Height = 630;
        //                        Width = 600;

        //                    }
        //                    ResumeLayout(false);
        //                    PerformLayout();
        //                    if ((objTipo.Descripcion.ToUpper().Contains("FORANEO") || objTipo.Descripcion.ToUpper().Contains("FORÁNEO")) || (objTipo.Descripcion.ToUpper().Contains("FORÁNEA") || objTipo.Descripcion.ToUpper().Contains("FORANEA")))
        //                    {
        //                        cmbMunicipio.Enabled = false;
        //                        cmbLocalidad.Enabled = false;
        //                        cmbColonia.Enabled = false;
        //                        cmbCP.Enabled = false;
        //                    }
        //                    else
        //                    {
        //                        cmbMunicipio.Enabled = true;
        //                        cmbLocalidad.Enabled = true;
        //                        cmbColonia.Enabled = true;
        //                        cmbCP.Enabled = true;
        //                    }
        //                    if (_grpDenunciante != null)
        //                    {
        //                        if ((objTipo.Descripcion.ToUpper().Contains("ANONIMO") || objTipo.Descripcion.ToUpper().Contains("ANÓNIMO")) || (objTipo.Descripcion.ToUpper().Contains("ANONIMA") || objTipo.Descripcion.ToUpper().Contains("ANÓNIMA")))
        //                        {
        //                            _grpDenunciante.Enabled = false;
        //                        }
        //                        else
        //                        {
        //                            _grpDenunciante.Enabled = true;
        //                        }
        //                    }
        //                    if (objTipo.ClaveOperacion.Trim() == "5047" || objTipo.ClaveOperacion.Trim() == "133")
        //                    {
        //                        txtDireccion.Text = "SIN REGISTRO";
        //                    }


        //                }


        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la información en el grid de persona extraviada
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void dgvPersonaExtraviada_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{

        //}

        ///// <summary>
        ///// Activa el control de teléfono del propietario cuando se presiona la tecla enter
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtNombrePropietario_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtTelefonoPropietario.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// Guarda los datos del propiterio actualizado en la entidad propietario del vehículo
        ///// </summary>
        ///// <remarks>Actualiza las tablas de PropietarioVehiculo y VehiculoRobado</remarks>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtNombrePropietario_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_objPropietarioVehiculo == null)
        //            {
        //                _objPropietarioVehiculo = new PropietarioVehiculoObject();
        //                _objPropietarioVehiculo.Nombre = txtNombrePropietario.Text;
        //                PropietarioVehiculoMapper.Instance().Insert(_objPropietarioVehiculo);
        //            }
        //            else
        //            {
        //                _objPropietarioVehiculo.Nombre = txtNombrePropietario.Text;
        //                PropietarioVehiculoMapper.Instance().Save(_objPropietarioVehiculo);
        //            }
        //            //Se revisa si ya hay vehículos para este folio y se actualizan con el id del propietario:
        //            VehiculoRobadoObjectList ListaVehiculos = VehiculoRobadoMapper.Instance().GetByIncidencia(_entIncidencia.Folio);
        //            foreach (VehiculoRobadoObject objVehiculo in ListaVehiculos)
        //            {
        //                objVehiculo.ClavePropietario = _objPropietarioVehiculo.Clave;
        //            }
        //            if (ListaVehiculos.Count > 0)
        //            {
        //                VehiculoRobadoMapper.Instance().Update(ListaVehiculos);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}

        ///// <summary>
        ///// Activa el control de la descripción del propietario del vehículo cuando se presiona la tecla enter
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtTelefonoPropietario_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtDireccionPropietario.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// Guarda los datos del propiterio actualizado en la entidad propietario del vehículo
        ///// </summary>
        ///// <remarks>Actualiza las tablas de PropietarioVehiculo y VehiculoRobado</remarks>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtTelefonoPropietario_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_objPropietarioVehiculo == null)
        //            {
        //                _objPropietarioVehiculo = new PropietarioVehiculoObject();
        //                _objPropietarioVehiculo.Telefono = txtTelefono.Text;
        //                PropietarioVehiculoMapper.Instance().Insert(_objPropietarioVehiculo);
        //            }
        //            else
        //            {
        //                _objPropietarioVehiculo.Telefono = txtTelefono.Text;
        //                PropietarioVehiculoMapper.Instance().Save(_objPropietarioVehiculo);
        //            }
        //            //Se revisa si ya hay vehículos para este folio y se actualizan con el id del propietario:
        //            VehiculoRobadoObjectList ListaVehiculos = VehiculoRobadoMapper.Instance().GetByIncidencia(_entIncidencia.Folio);
        //            foreach (VehiculoRobadoObject objVehiculo in ListaVehiculos)
        //            {
        //                objVehiculo.ClavePropietario = _objPropietarioVehiculo.Clave;
        //            }
        //            if (ListaVehiculos.Count > 0)
        //            {
        //                VehiculoRobadoMapper.Instance().Update(ListaVehiculos);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda los datos del propiterio actualizado en la entidad propietario del vehículo
        ///// </summary>
        ///// <remarks>Actualiza las tablas de PropietarioVehiculo y VehiculoRobado</remarks>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtDireccionPropietario_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_objPropietarioVehiculo == null)
        //            {
        //                _objPropietarioVehiculo = new PropietarioVehiculoObject();
        //                _objPropietarioVehiculo.Domicilio = txtDireccionPropietario.Text;
        //                PropietarioVehiculoMapper.Instance().Insert(_objPropietarioVehiculo);
        //            }
        //            else
        //            {
        //                _objPropietarioVehiculo.Telefono = txtTelefono.Text;
        //                _objPropietarioVehiculo.Domicilio = txtDireccionPropietario.Text;
        //                PropietarioVehiculoMapper.Instance().Save(_objPropietarioVehiculo);
        //            }
        //            //Se revisa si ya hay vehículos para este folio y se actualizan con el id del propietario:
        //            VehiculoRobadoObjectList ListaVehiculos = VehiculoRobadoMapper.Instance().GetByIncidencia(_entIncidencia.Folio);
        //            foreach (VehiculoRobadoObject objVehiculo in ListaVehiculos)
        //            {
        //                objVehiculo.ClavePropietario = _objPropietarioVehiculo.Clave;
        //            }
        //            if (ListaVehiculos.Count > 0)
        //            {
        //                VehiculoRobadoMapper.Instance().Update(ListaVehiculos);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda los datos de los vehículos robados
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void dgvVehiculo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{

        //}

        ///// <summary>
        ///// Activa la fecha para capturar la fecha en que se percataron del robo de accesorios al vehículo
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void chkAccesoriosPercato_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            dtpAccesoriosFechaPercato.Enabled = chkAccesoriosPercato.Checked;
        //            if (_entRoboVehiculoAccesorios == null)
        //            {
        //                _entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
        //                _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;

        //                if (chkAccesoriosPercato.Checked)
        //                {
        //                    _entRoboVehiculoAccesorios.FechaPercato = dtpAccesoriosFechaPercato.Value;
        //                }
        //                else
        //                {
        //                    _entRoboVehiculoAccesorios.FechaPercato = null;
        //                }
        //                _entRoboVehiculoAccesorios.Folio = _entIncidencia.Folio;
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                RoboVehiculoAccesoriosMapper.Instance().Insert(_entRoboVehiculoAccesorios);
        //                //Ahora se inserta en RoboVehiculoAccesoriosRoboVehiculo
        //                for (int i = 0; i < dgvVehiculoAccesorios.Rows.Count; i++)
        //                {
        //                    try
        //                    {
        //                        int Clave = int.Parse(dgvVehiculoAccesorios[0, i].Value.ToString());
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
        //                        objVehiculoInvolucrado.ClaveVehiculo = Clave;
        //                        objVehiculoInvolucrado.ClaveRoboAccesorios = _entRoboVehiculoAccesorios.Clave;
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
        //                    }
        //                    catch { }

        //                }
        //            }
        //            else
        //            {
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                if (chkAccesoriosPercato.Checked)
        //                {
        //                    _entRoboVehiculoAccesorios.FechaPercato = dtpAccesoriosFechaPercato.Value;
        //                }
        //                else
        //                {
        //                    _entRoboVehiculoAccesorios.FechaPercato = null;
        //                }
        //                RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Activa el control de número de serie cuando se presona la tecla enter en el control de  placas
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosPlacas_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtAccesoriosSerie.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// Guarda la información del vehículo al cual le robaron los accesorios, cuando se sale del control placas
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosPlacas_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_objVeiculoAccesoriosRobado == null)
        //            {
        //                _objVeiculoAccesoriosRobado = new VehiculoObject();
        //                _objVeiculoAccesoriosRobado.Placas = txtAccesoriosPlacas.Text;
        //                VehiculoMapper.Instance().Insert(_objVeiculoAccesoriosRobado);
        //                if (_entRoboVehiculoAccesorios != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //            }
        //            else
        //            {
        //                if (_entRoboVehiculoAccesorios != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                _objVeiculoAccesoriosRobado.Placas = txtAccesoriosPlacas.Text;
        //                VehiculoMapper.Instance().Save(_objVeiculoAccesoriosRobado);
        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}

        ///// <summary>
        ///// Activa el control de accesorios robados cuando se presiona la tecla enter
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosSerie_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtAccesoriosRobados.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// Guarda la información del vehículo al cual le robaron accesorios se sale del control serie
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosSerie_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_objVeiculoAccesoriosRobado == null)
        //            {
        //                _objVeiculoAccesoriosRobado = new VehiculoObject();
        //                _objVeiculoAccesoriosRobado.NumeroSerie = txtAccesoriosSerie.Text;
        //                VehiculoMapper.Instance().Insert(_objVeiculoAccesoriosRobado);

        //                if (_entRoboVehiculoAccesorios != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                    RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //                }
        //            }
        //            else
        //            {
        //                if (_entRoboVehiculoAccesorios != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                    RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //                }
        //                _objVeiculoAccesoriosRobado.NumeroSerie = txtAccesoriosSerie.Text;
        //                VehiculoMapper.Instance().Save(_objVeiculoAccesoriosRobado);
        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }

        //}

        ///// <summary>
        ///// Activa el control de la persona que se percató del robo cuando se presiona la tecla enter en el control de accesorios robados
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosRobados_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtAccesoriosPersonaSePercato.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// Guarda la información de los accesorios robados cuando se sale del control de texto de la persona que se percató del robo
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosRobados_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_entRoboVehiculoAccesorios == null)
        //            {
        //                _entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();

        //                _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                _entRoboVehiculoAccesorios.Folio = _entIncidencia.Folio;
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;

        //                }
        //                RoboVehiculoAccesoriosMapper.Instance().Insert(_entRoboVehiculoAccesorios);
        //                for (int i = 0; i < dgvVehiculoAccesorios.Rows.Count; i++)
        //                {
        //                    try
        //                    {
        //                        int Clave = int.Parse(dgvVehiculoAccesorios[0, i].Value.ToString());
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
        //                        objVehiculoInvolucrado.ClaveVehiculo = Clave;
        //                        objVehiculoInvolucrado.ClaveRoboAccesorios = _entRoboVehiculoAccesorios.Clave;
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
        //                    }
        //                    catch { }

        //                }
        //            }
        //            else
        //            {
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);

        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}


        ///// <summary>
        ///// Activa el control de fecha en que se percataron del robo cuando se presiona enter en el control  de la persona que se percató del robo
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosPersonaSePercato_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        dtpAccesoriosFechaPercato.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// Guarda la información de los accesorios robados cuando se sale del control de la persona que se percató del robo
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosPersonaSePercato_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_entRoboVehiculoAccesorios == null)
        //            {
        //                _entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
        //                _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                _entRoboVehiculoAccesorios.SePercato = txtAccesoriosPersonaSePercato.Text;
        //                _entRoboVehiculoAccesorios.Folio = _entIncidencia.Folio;
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                RoboVehiculoAccesoriosMapper.Instance().Insert(_entRoboVehiculoAccesorios);
        //                for (int i = 0; i < dgvVehiculoAccesorios.Rows.Count; i++)
        //                {
        //                    try
        //                    {
        //                        int Clave = int.Parse(dgvVehiculoAccesorios[0, i].Value.ToString());
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
        //                        objVehiculoInvolucrado.ClaveVehiculo = Clave;
        //                        objVehiculoInvolucrado.ClaveRoboAccesorios = _entRoboVehiculoAccesorios.Clave;
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
        //                    }
        //                    catch { }

        //                }
        //            }
        //            else
        //            {
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                _entRoboVehiculoAccesorios.SePercato = txtAccesoriosPersonaSePercato.Text;
        //                RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void dtpAccesoriosFechaPercato_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtAccesoriosResponsables.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void dtpAccesoriosFechaPercato_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_entRoboVehiculoAccesorios == null)
        //            {
        //                _entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
        //                _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                _entRoboVehiculoAccesorios.FechaPercato = dtpAccesoriosFechaPercato.Value;
        //                _entRoboVehiculoAccesorios.Folio = _entIncidencia.Folio;
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                RoboVehiculoAccesoriosMapper.Instance().Insert(_entRoboVehiculoAccesorios);
        //                //Ahora se inserta en RoboVehiculoAccesoriosRoboVehiculo
        //                for (int i = 0; i < dgvVehiculoAccesorios.Rows.Count; i++)
        //                {
        //                    try
        //                    {
        //                        int Clave = int.Parse(dgvVehiculoAccesorios[0, i].Value.ToString());
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
        //                        objVehiculoInvolucrado.ClaveVehiculo = Clave;
        //                        objVehiculoInvolucrado.ClaveRoboAccesorios = _entRoboVehiculoAccesorios.Clave;
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
        //                    }
        //                    catch { }

        //                }
        //            }
        //            else
        //            {
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                _entRoboVehiculoAccesorios.FechaPercato = dtpAccesoriosFechaPercato.Value;
        //                RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosResponsables_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        dgvVehiculoAccesorios.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void txtAccesoriosResponsables_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (_entRoboVehiculoAccesorios == null)
        //            {
        //                _entRoboVehiculoAccesorios = new RoboVehiculoAccesorios();
        //                _entRoboVehiculoAccesorios.AccesoriosRobados = txtAccesoriosRobados.Text;
        //                _entRoboVehiculoAccesorios.DescripcionResponsables = txtAccesoriosResponsables.Text;
        //                _entRoboVehiculoAccesorios.Folio = _entIncidencia.Folio;
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                RoboVehiculoAccesoriosMapper.Instance().Insert(_entRoboVehiculoAccesorios);
        //                //Ahora se inserta en RoboVehiculoAccesoriosRoboVehiculo
        //                for (int i = 0; i < dgvVehiculoAccesorios.Rows.Count; i++)
        //                {
        //                    try
        //                    {
        //                        int Clave = int.Parse(dgvVehiculoAccesorios[0, i].Value.ToString());
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
        //                        objVehiculoInvolucrado.ClaveVehiculo = Clave;
        //                        objVehiculoInvolucrado.ClaveRoboAccesorios = _entRoboVehiculoAccesorios.Clave;
        //                        RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
        //                    }
        //                    catch { }

        //                }
        //            }
        //            else
        //            {
        //                if (_objVeiculoAccesoriosRobado != null)
        //                {
        //                    _entRoboVehiculoAccesorios.ClaveVehiculo = _objVeiculoAccesoriosRobado.Clave;
        //                }
        //                _entRoboVehiculoAccesorios.DescripcionResponsables = txtAccesoriosResponsables.Text;
        //                RoboVehiculoAccesoriosMapper.Instance().Save(_entRoboVehiculoAccesorios);
        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Guarda la información de los vehículos involucrados cuando la incidencia es sobre un robo de accesorios de vehículo
        ///// </summary>
        ///// <param name="sender">Objeto que ocasionó el evento</param>
        ///// <param name="e">Parámetros del evento</param>
        //private void dgvVehiculoAccesorios_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{

        //}

        ///// <summary>
        ///// Guarda la información en el grid de persona extraviada
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void dgvPersonaExtraviada_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    Boolean blnExiste = false;
        //    PersonaExtraviada entPersonaExtraviada = new PersonaExtraviada();


        //    try
        //    {
        //        if (_entIncidencia == null)
        //        {
        //            dgvPersonaExtraviada.Rows.Clear();
        //            throw new SAIExcepcion("No es posible registrar personas extraviadas", this);
        //        }


        //        if (!(dgvPersonaExtraviada[0, e.RowIndex].Value == null))
        //        {
        //            blnExiste = true;
        //            int Clave = int.Parse(dgvPersonaExtraviada[0, e.RowIndex].Value.ToString());
        //            entPersonaExtraviada = PersonaExtraviadaMapper.Instance().GetOne((Clave));
        //        }

        //        entPersonaExtraviada.FechaExtravio = DateTime.Now;

        //        switch (e.ColumnIndex)
        //        {
        //            case 0: //Calve
        //                break;
        //            case 1: //Folio
        //                break;
        //            case 2: //Nombre
        //                String strNombre;
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    strNombre = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strNombre = strNombre.ToUpper();
        //                    if (strNombre.Length > 250)
        //                    {
        //                        strNombre = strNombre.Substring(0, 250);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strNombre;
        //                    entPersonaExtraviada.Nombre = strNombre;
        //                }

        //                break;
        //            case 3: //Edad
        //                int intEdad;
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    try
        //                    {
        //                        intEdad = int.Parse(dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString());
        //                        if (intEdad <= 0)
        //                        {
        //                            dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                            //e.Cancel = true;
        //                            throw new SAIExcepcion("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", this);
        //                        }
        //                        entPersonaExtraviada.Edad = intEdad;
        //                    }
        //                    catch
        //                    {
        //                        dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                        //e.Cancel = true;
        //                        throw new SAIExcepcion("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", this);
        //                    }
        //                }

        //                break;
        //            case 4: //Sexo
        //                String strSexo;
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    strSexo = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strSexo = strSexo.ToUpper();
        //                    if (strSexo != "F" && strSexo != "M")
        //                    {
        //                        dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                        //e.Cancel = true;
        //                        throw new SAIExcepcion("El valor del sexo no se encuentra en el formato correcto, debe de ser F (Femenino) y M (Masculino)", this);
        //                    }

        //                    dgvPersonaExtraviada.CurrentCell.Value = strSexo;
        //                    entPersonaExtraviada.Sexo = strSexo;
        //                }

        //                break;
        //            case 5://Estatura
        //                float fltEstatura;
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    try
        //                    {
        //                        fltEstatura = float.Parse(dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString());
        //                        if (fltEstatura <= 0)
        //                        {
        //                            dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                            dgvPersonaExtraviada.Refresh();
        //                            //e.Cancel = true;
        //                            throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
        //                        }
        //                        entPersonaExtraviada.Estatura = fltEstatura;
        //                    }
        //                    catch
        //                    {
        //                        dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                        dgvPersonaExtraviada.Refresh();
        //                        //e.Cancel = true;
        //                        throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
        //                    }
        //                }
        //                break;
        //            case 6: //Parentesco

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strParentesco;
        //                    strParentesco = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strParentesco = strParentesco.ToUpper();
        //                    if (strParentesco.Length > 15)
        //                    {
        //                        strParentesco = strParentesco.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strParentesco;
        //                    entPersonaExtraviada.Parentesco = strParentesco;
        //                }

        //                break;
        //            case 7://Fecha de extravío
        //                DateTime dtmFecha;
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    try
        //                    {
        //                        dtmFecha = DateTime.Parse(dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString());
        //                        if (dtmFecha > DateTime.Today)
        //                        {
        //                            dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                            //e.Cancel = true;
        //                            throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
        //                        }
        //                        entPersonaExtraviada.FechaExtravio = dtmFecha;
        //                    }
        //                    catch
        //                    {
        //                        dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
        //                        //e.Cancel = true;
        //                        throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
        //                    }
        //                }
        //                break;
        //            case 8:// Tez

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strTez;
        //                    strTez = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strTez = strTez.ToUpper();
        //                    if (strTez.Length > 50)
        //                    {
        //                        strTez = strTez.Substring(0, 50);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strTez;
        //                    entPersonaExtraviada.Tez = strTez;
        //                }

        //                break;
        //            case 9://Tipo cabello

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strTipoCabello;
        //                    strTipoCabello = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strTipoCabello = strTipoCabello.ToUpper();
        //                    if (strTipoCabello.Length > 15)
        //                    {
        //                        strTipoCabello = strTipoCabello.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strTipoCabello;
        //                    entPersonaExtraviada.TipoCabello = strTipoCabello;
        //                }

        //                break;
        //            case 10://Color cabello

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strColorCabello;
        //                    strColorCabello = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strColorCabello = strColorCabello.ToUpper();
        //                    if (strColorCabello.Length > 15)
        //                    {
        //                        strColorCabello = strColorCabello.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strColorCabello;
        //                    entPersonaExtraviada.ColorCabello = strColorCabello;
        //                }

        //                break;
        //            case 11://Largo cabello

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strLargoCabello;
        //                    strLargoCabello = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strLargoCabello = strLargoCabello.ToUpper();
        //                    if (strLargoCabello.Length > 15)
        //                    {
        //                        strLargoCabello = strLargoCabello.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strLargoCabello;
        //                    entPersonaExtraviada.LargoCabello = strLargoCabello;
        //                }

        //                break;
        //            case 12://Frente

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strFrente;
        //                    strFrente = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strFrente = strFrente.ToUpper();
        //                    if (strFrente.Length > 15)
        //                    {
        //                        strFrente = strFrente.Substring(0, 15);
        //                    }

        //                    dgvPersonaExtraviada.CurrentCell.Value = strFrente;
        //                    entPersonaExtraviada.Frente = strFrente;
        //                }

        //                break;
        //            case 13://Cejas

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strCejas;
        //                    strCejas = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    if (strCejas.Length > 15)
        //                    {
        //                        strCejas = strCejas.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strCejas.ToUpper();
        //                    entPersonaExtraviada.Cejas = strCejas;
        //                }

        //                break;
        //            case 14:// Color de ojos

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strColorOjos;
        //                    strColorOjos = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strColorOjos = strColorOjos.ToUpper();
        //                    if (strColorOjos.Length > 15)
        //                    {
        //                        strColorOjos = strColorOjos.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strColorOjos;
        //                    entPersonaExtraviada.OjosColor = strColorOjos;
        //                }

        //                break;
        //            case 15:// tamaño de boca

        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strTamañoBoca;
        //                    strTamañoBoca = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strTamañoBoca = strTamañoBoca.ToUpper();
        //                    if (strTamañoBoca.Length > 15)
        //                    {
        //                        strTamañoBoca = strTamañoBoca.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strTamañoBoca;
        //                    entPersonaExtraviada.BocaTamaño = strTamañoBoca;
        //                }

        //                break;
        //            case 16:// labios
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strLabios;
        //                    strLabios = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strLabios = strLabios.ToUpper();
        //                    if (strLabios.Length > 15)
        //                    {
        //                        strLabios = strLabios.Substring(0, 15);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strLabios;
        //                    entPersonaExtraviada.Labios = strLabios;
        //                }
        //                break;
        //            case 17:// vestimenta
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strVestimenta;
        //                    strVestimenta = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strVestimenta = strVestimenta.ToUpper();
        //                    if (strVestimenta.Length > 250)
        //                    {
        //                        strVestimenta = strVestimenta.Substring(0, 250);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strVestimenta;
        //                    entPersonaExtraviada.Vestimenta = strVestimenta;
        //                }
        //                break;
        //            case 18:// destino
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strDestino;
        //                    strDestino = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strDestino = strDestino.ToUpper();
        //                    if (strDestino.Length > 250)
        //                    {
        //                        strDestino = strDestino.Substring(0, 250);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strDestino;
        //                    entPersonaExtraviada.Destino = strDestino;
        //                }
        //                break;
        //            case 19:// caracteristicas
        //                if (dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value != null && dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                {
        //                    String strCaracteristicas;
        //                    strCaracteristicas = dgvPersonaExtraviada[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                    strCaracteristicas = strCaracteristicas.ToUpper();
        //                    if (strCaracteristicas.Length > 250)
        //                    {
        //                        strCaracteristicas = strCaracteristicas.Substring(0, 250);
        //                    }
        //                    dgvPersonaExtraviada.CurrentCell.Value = strCaracteristicas;
        //                    entPersonaExtraviada.Caracteristicas = strCaracteristicas;
        //                }
        //                break;
        //        }

        //        entPersonaExtraviada.Folio = _entIncidencia.Folio;

        //        try
        //        {
        //            if (blnExiste)
        //            {
        //                PersonaExtraviadaMapper.Instance().Save(entPersonaExtraviada);
        //            }
        //            else
        //            {
        //                PersonaExtraviadaMapper.Instance().Insert(entPersonaExtraviada);
        //                dgvPersonaExtraviada[0, e.RowIndex].Value = entPersonaExtraviada.Clave;
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion)
        //    { }
        //}

        ///// <summary>
        ///// Guarda la información en el grid de vehículo
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void dgvVehiculo_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    Boolean blnExiste = false;
        //    VehiculoObject objVehiculo = new VehiculoObject();


        //    try
        //    {
        //        if (_entIncidencia == null)
        //        {
        //            dgvVehiculo.Rows.Clear();
        //            throw new SAIExcepcion("No es posible registrar vehiculos robados", this);
        //        }
        //        try
        //        {
        //            if (!(dgvVehiculo[0, e.RowIndex].Value == null))
        //            {
        //                blnExiste = true;
        //                int Clave = int.Parse(dgvVehiculo[0, e.RowIndex].Value.ToString());
        //                objVehiculo = VehiculoMapper.Instance().GetOne((Clave));
        //            }
        //            switch (e.ColumnIndex)
        //            {
        //                case 0: //Clave
        //                    break;
        //                case 1: //Marca

        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strMarca;
        //                        strMarca = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strMarca.Length > 50)
        //                        {
        //                            strMarca = strMarca.Substring(0, 50);
        //                        }
        //                        strMarca = strMarca.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strMarca;
        //                        objVehiculo.Marca = strMarca;
        //                    }
        //                    break;
        //                case 2://Tipo
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strTipo;
        //                        strTipo = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strTipo.Length > 50)
        //                        {
        //                            strTipo = strTipo.Substring(0, 50);
        //                        }
        //                        strTipo = strTipo.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strTipo;
        //                        objVehiculo.Tipo = strTipo;
        //                    }
        //                    break;
        //                case 3://Modelo
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strModelo;
        //                        strModelo = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strModelo.Length > 50)
        //                        {
        //                            strModelo = strModelo.Substring(0, 50);
        //                        }
        //                        strModelo = strModelo.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strModelo;
        //                        objVehiculo.Modelo = strModelo;
        //                    }
        //                    break;
        //                case 4://Color
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strColor;
        //                        strColor = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strColor.Length > 50)
        //                        {
        //                            strColor = strColor.Substring(0, 50);
        //                        }
        //                        strColor = strColor.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strColor;
        //                        objVehiculo.Color = strColor;
        //                    }
        //                    break;

        //                case 6://Número de Motor
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strNumeroMotor;
        //                        strNumeroMotor = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strNumeroMotor.Length > 50)
        //                        {
        //                            strNumeroMotor = strNumeroMotor.Substring(0, 50);
        //                        }
        //                        strNumeroMotor = strNumeroMotor.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strNumeroMotor;
        //                        objVehiculo.NumeroMotor = strNumeroMotor;
        //                    }
        //                    break;
        //                case 7://Número de Serie
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strNumeroSerie;
        //                        strNumeroSerie = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strNumeroSerie.Length > 50)
        //                        {
        //                            strNumeroSerie = strNumeroSerie.Substring(0, 50);
        //                        }
        //                        strNumeroSerie = strNumeroSerie.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strNumeroSerie;
        //                        objVehiculo.NumeroSerie = strNumeroSerie;
        //                    }
        //                    break;
        //                case 8://Señas Particulares
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strSeñasParticulares;
        //                        strSeñasParticulares = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strSeñasParticulares.Length > 250)
        //                        {
        //                            strSeñasParticulares = strSeñasParticulares.Substring(0, 250);
        //                        }
        //                        strSeñasParticulares = strSeñasParticulares.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strSeñasParticulares;
        //                        objVehiculo.SeñasParticulares = strSeñasParticulares;
        //                    }
        //                    break;
        //            }

        //            try
        //            {
        //                if (blnExiste)
        //                {
        //                    VehiculoMapper.Instance().Save(objVehiculo);
        //                    if (_objPropietarioVehiculo != null)
        //                    {
        //                        VehiculoRobadoObject objVehiculoRobado = VehiculoRobadoMapper.Instance().GetOne(objVehiculo.Clave, _entIncidencia.Folio);
        //                        objVehiculoRobado.ClavePropietario = _objPropietarioVehiculo.Clave;
        //                        VehiculoRobadoMapper.Instance().Save(objVehiculoRobado);
        //                    }

        //                }
        //                else
        //                {
        //                    VehiculoRobadoObject objVehiculoRobado = new VehiculoRobadoObject();
        //                    VehiculoMapper.Instance().Insert(objVehiculo);
        //                    objVehiculoRobado.ClaveVehiculo = objVehiculo.Clave;
        //                    dgvVehiculo[0, e.RowIndex].Value = objVehiculo.Clave;
        //                    if (_objPropietarioVehiculo != null)
        //                    {
        //                        objVehiculoRobado.ClavePropietario = _objPropietarioVehiculo.Clave;
        //                    }
        //                    objVehiculoRobado.Folio = _entIncidencia.Folio;
        //                    VehiculoRobadoMapper.Instance().Insert(objVehiculoRobado);

        //                }
        //            }
        //            catch (System.Exception ex)
        //            {
        //                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //            }

        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion)
        //    { }
        //}

        ///// <summary>
        ///// Guarda la información en el grid de vehículos involucrados en un robo a accesorio de vehículos
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void dgvVehiculoAccesorios_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    Boolean blnExiste = false;
        //    VehiculoObject objVehiculo = new VehiculoObject();
        //    try
        //    {


        //        try
        //        {
        //            if (!(dgvVehiculoAccesorios[0, e.RowIndex].Value == null))
        //            {
        //                blnExiste = true;
        //                int Clave = int.Parse(dgvVehiculoAccesorios[0, e.RowIndex].Value.ToString());
        //                objVehiculo = VehiculoMapper.Instance().GetOne((Clave));
        //            }
        //            switch (e.ColumnIndex)
        //            {
        //                case 0:
        //                    break;
        //                case 1: //Marca

        //                    if (dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strMarca;
        //                        strMarca = dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strMarca.Length > 50)
        //                        {
        //                            strMarca = strMarca.Substring(0, 50);
        //                        }
        //                        strMarca = strMarca.ToUpper();
        //                        dgvVehiculoAccesorios.CurrentCell.Value = strMarca;
        //                        objVehiculo.Marca = strMarca;
        //                    }
        //                    break;
        //                case 2://Tipo
        //                    if (dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strTipo;
        //                        strTipo = dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strTipo.Length > 50)
        //                        {
        //                            strTipo = strTipo.Substring(0, 50);
        //                        }
        //                        strTipo = strTipo.ToUpper();
        //                        dgvVehiculoAccesorios.CurrentCell.Value = strTipo;
        //                        objVehiculo.Tipo = strTipo;
        //                    }
        //                    break;
        //                case 3://Modelo
        //                    if (dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strModelo;
        //                        strModelo = dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strModelo.Length > 50)
        //                        {
        //                            strModelo = strModelo.Substring(0, 50);
        //                        }
        //                        strModelo = strModelo.ToUpper();
        //                        dgvVehiculoAccesorios.CurrentCell.Value = strModelo;
        //                        objVehiculo.Modelo = strModelo;
        //                    }
        //                    break;
        //                case 4://Color
        //                    if (dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strColor;
        //                        strColor = dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strColor.Length > 50)
        //                        {
        //                            strColor = strColor.Substring(0, 50);
        //                        }
        //                        strColor = strColor.ToUpper();
        //                        dgvVehiculoAccesorios.CurrentCell.Value = strColor;
        //                        objVehiculo.Color = strColor;
        //                    }
        //                    break;
        //                case 6://Número de Motor
        //                    if (dgvVehiculo[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strNumeroMotor;
        //                        strNumeroMotor = dgvVehiculo[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strNumeroMotor.Length > 50)
        //                        {
        //                            strNumeroMotor = strNumeroMotor.Substring(0, 50);
        //                        }
        //                        strNumeroMotor = strNumeroMotor.ToUpper();
        //                        dgvVehiculo.CurrentCell.Value = strNumeroMotor;
        //                        objVehiculo.NumeroMotor = strNumeroMotor;
        //                    }
        //                    break;
        //                case 7://Número de Serie
        //                    if (dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strNumeroSerie;
        //                        strNumeroSerie = dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strNumeroSerie.Length > 50)
        //                        {
        //                            strNumeroSerie = strNumeroSerie.Substring(0, 50);
        //                        }
        //                        strNumeroSerie = strNumeroSerie.ToUpper();
        //                        dgvVehiculoAccesorios.CurrentCell.Value = strNumeroSerie;
        //                        objVehiculo.NumeroSerie = strNumeroSerie;
        //                    }
        //                    break;
        //                case 8://Señas Particulares
        //                    if (dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value != null && dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != string.Empty)
        //                    {
        //                        String strSeñasParticulares;
        //                        strSeñasParticulares = dgvVehiculoAccesorios[e.ColumnIndex, e.RowIndex].Value.ToString();
        //                        if (strSeñasParticulares.Length > 250)
        //                        {
        //                            strSeñasParticulares = strSeñasParticulares.Substring(0, 250);
        //                        }
        //                        strSeñasParticulares = strSeñasParticulares.ToUpper();
        //                        dgvVehiculoAccesorios.CurrentCell.Value = strSeñasParticulares;
        //                        objVehiculo.SeñasParticulares = strSeñasParticulares;
        //                    }
        //                    break;
        //            }

        //            if (blnExiste)
        //            {
        //                VehiculoMapper.Instance().Save(objVehiculo);

        //            }
        //            else
        //            {
        //                RoboVehiculoAccesoriosVehiculoInvolucradoObject objVehiculoInvolucrado = new RoboVehiculoAccesoriosVehiculoInvolucradoObject();
        //                VehiculoMapper.Instance().Insert(objVehiculo);

        //                objVehiculoInvolucrado.ClaveVehiculo = objVehiculo.Clave;
        //                dgvVehiculoAccesorios[0, e.RowIndex].Value = objVehiculo.Clave;

        //                if (_entRoboVehiculoAccesorios != null)
        //                {
        //                    objVehiculoInvolucrado.ClaveRoboAccesorios = _entRoboVehiculoAccesorios.Clave;
        //                    RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance().Insert(objVehiculoInvolucrado);
        //                }
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        ///// <summary>
        ///// Se manda a llamar desde las clases hijas y cambia el estado del control de la lista de tipo de incidencias
        ///// </summary>
        ///// <param name="blnHabilitado"></param>
        //protected void CambiaHabilitadoTipoIncidencia(Boolean blnHabilitado)
        //{
        //    cmbTipoIncidencia.Enabled = blnHabilitado;
        //    cmbTipoIncidencia.BlnEsRequerido = blnHabilitado;
        //}

        ///// <summary>
        ///// Busca el municipio, localidad y colonia del código introducido
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void cmbCP_TextChanged(object sender, EventArgs e)
        //{

        //    if (cmbCP.Text.Length == 5)
        //    {
        //        ColoniaList lstColonias;
        //        CodigoPostalList lstCodigoPostal;
        //        Localidad entLocalidad;
        //        LocalidadList lstLocalidades;

        //        if (_blnBloqueaEventos)
        //        {
        //            return;
        //        }

        //        try
        //        {
        //            try
        //            {

        //                lstCodigoPostal = CodigoPostalMapper.Instance().GetBySQLQuery("Select Clave, Valor from CodigoPostal where Valor = '" + cmbCP.Text + "'");
        //                if (lstCodigoPostal != null && lstCodigoPostal.Count > 0)
        //                {
        //                    lstColonias = ColoniaMapper.Instance().GetByCodigoPostal(lstCodigoPostal[0].Clave);

        //                    if (lstColonias != null && lstColonias.Count > 0)
        //                    {
        //                        _blnBloqueaEventos = true;
        //                        ActualizaColonias(lstColonias);
        //                        entLocalidad = LocalidadMapper.Instance().GetOne(lstColonias[0].ClaveLocalidad);
        //                        lstLocalidades = LocalidadMapper.Instance().GetByMunicipio(entLocalidad.ClaveMunicipio);
        //                        ActualizaLocalidades(lstLocalidades);
        //                        foreach (Object objElemento in cmbLocalidad.Items)
        //                        {
        //                            if ((objElemento as Localidad).Clave == entLocalidad.Clave)
        //                            {
        //                                cmbLocalidad.SelectedItem = objElemento;
        //                                break;
        //                            }
        //                        }
        //                        foreach (Object objElemento in cmbMunicipio.Items)
        //                        {
        //                            if ((objElemento as Municipio).Clave == entLocalidad.ClaveMunicipio)
        //                            {
        //                                cmbMunicipio.SelectedItem = objElemento;
        //                                break;
        //                            }
        //                        }


        //                        _blnBloqueaEventos = false;
        //                    }
        //                }

        //                actualizaMapaUbicacion();
        //            }
        //            catch (System.Exception ex)
        //            {
        //                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //            }
        //        }
        //        catch (SAIExcepcion) { }
        //    }


        //}

        //private void txtReferencias_KeyUp(object sender, KeyEventArgs e)
        //{
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        //private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        //{
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        //private void cmbCP_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //No permite introducir texto
        //    if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
        //        e.Handled = true;
        //}

        //private void SAIFrmIncidencia_Load(object sender, EventArgs e)
        //{
        //    if (!Aplicacion.UsuarioPersistencia.blnPuedeEscribir(ID.CMD_NI))
        //    {
        //        foreach (Control objControl in Controls)
        //        {
        //            if (objControl.GetType() == (new System.Windows.Forms.GroupBox()).GetType())
        //            {
        //                continue;
        //            }
        //            if (objControl.GetType().GetProperty("ReadOnly") != null)
        //            {
        //                objControl.GetType().GetProperty("ReadOnly").SetValue(objControl, true, null);
        //            }
        //            else
        //            {
        //                objControl.Enabled = false;
        //            }

        //        }
        //    }
        //}

        //private void cmbMunicipio_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        cmbLocalidad.Focus();
        //    }
        //    SAIFrmIncidenciaKeyUp(e);
        //}

        //private void cmbMunicipio_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
        //            {
        //                LimpiaLocalidades();
        //                LimpiaColonias();
        //            }

        //            actualizaMapaUbicacion();
        //            if (!_blnSeActivoClosed)
        //            {
        //                RecuperaDatosEnIncidencia();
        //                GuardaIncidencia();
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}

        //private void cmbMunicipio_TextUpdate(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            actualizaMapaUbicacion();
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
        //        }
        //    }
        //    catch (SAIExcepcion) { }
        //}


        //#endregion


    }
}
