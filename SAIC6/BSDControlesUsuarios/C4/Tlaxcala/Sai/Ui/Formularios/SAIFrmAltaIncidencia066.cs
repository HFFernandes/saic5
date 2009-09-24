//Autor : T.S.U. Angel Martinez Ortiz
//Fecha : Agosto del 2009
//Empresa :InfinitySoft TI Experts

using System;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using System.Collections;
using BSD.C4.Tlaxcala.Sai.Mapa;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// Formulario para altas de incidencias para el 066
    /// </summary>
    public partial class SAIFrmAltaIncidencia066 : SAIFrmBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="noTelefono">string, N�mero de tel�fono</param>
        public SAIFrmAltaIncidencia066(string noTelefono)
        {
            this._blnBloqueaEventos = true;
            InitializeComponent();

            //Creamos la nueva incidencia.
            this.CrearNuevaIncidencia();
            this.Text = string.Format("REGISTRO DE NUEVA INCIDENCIA FOLIO: {0}", this.entIncidencia.Folio);

            //Inicializamos las listas
            this.CargarMunicipios();
            this.CargarTiposIncidencias();
            this.CargarCoorporaciones();

            //Buscamos los datos del titular de la linea
            //this.ObtenerTitularLinea(noTelefono);

            this._blnBloqueaEventos = false;
            base.Activated += SAIFrmAltaIncidencia066_Activated;
        }

        private void SAIFrmAltaIncidencia066_Activated(object sender, EventArgs e)
        {
            Aplicacion.intFolioPorCancelar = entIncidencia.Folio;
            Aplicacion.frmIncidenciaActiva = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="oIncidencia">Incidencia,Objeto de tipo Incidencia.</param>
        /// <param name="esSoloLectura">bool, Indica si el formulario se debe mostrar con solo lectura.</param>
        public SAIFrmAltaIncidencia066(Incidencia oIncidencia, bool esSoloLectura)
        {
            InitializeComponent();
            this._blnBloqueaEventos = true;
            this.entIncidencia = oIncidencia;

            //Desplegamos la informaci�n de la incidencia.
            entUsuario = UsuarioMapper.Instance().GetOne(entIncidencia.ClaveUsuario);
            this.lblOperador.Text += entUsuario.NombrePropio;
            this.lblFechaHora.Text += entIncidencia.HoraRecepcion.ToString();
            this.Text = string.Format("EDICI�N DE INCIDENCIA FOLIO: {0}", this.entIncidencia.Folio);
            //this.EsModoEdicion = true;

            //Inicializamos las listas
            this.CargarMunicipios();
            this.CargarTiposIncidencias();
            this.CargarCoorporaciones();

            //this.ActualizaVentanaIncidencias();
            //Mostramos la informaci�n de la incidencia actual.
            this.MostrarDatosIncidencia();
            //Verificamos si debe estar como solo lectura.
            EsSoloLectura = esSoloLectura;
            this._blnBloqueaEventos = false;
            base.Activated += SAIFrmAltaIncidencia066_Activated;
        }

        #endregion

        #region VARIABLES

        /// <summary>
        /// Guarda la referencia a la entidad Incidencia que se maneja en el formulario
        /// </summary>
        protected Incidencia entIncidencia = new Incidencia();

        /// <summary>
        /// Persona que hace la denuncia.
        /// </summary>
        protected DenuncianteObject Denunciante;

        /// <summary>
        /// Objeto que guarda las claves de municipio, localidad, colonia y c�digo postal que se tienen escogidas por el 
        /// usuario a cada momento en el formulario
        /// </summary>
        /// <remarks>
        /// Este objeto se pasa al m�todo del la clase controladora del mapa para leer los valores de los id's correspondientes
        /// </remarks>
        private EstructuraUbicacion _objUbicacion = new EstructuraUbicacion();

        /// <summary>
        /// Esta bandera lleva el estado para saber si el usuario quiso cerrar la ventana, esto para saber
        /// si se va a guardar la incidencia en los eventos Leave de los controles, si est� en falso se guardan
        /// los datos en dichos eventos, de lo contrario no se guarda la incidencia en tales eventos.
        /// </summary>
        protected bool _blnSeActivoClosed;

        /// <summary>
        /// Bandera que se utiliza para detener el disparo en cascada de los eventos SelectedIndexChanged
        /// para las listas de municipios, localidades, colonias y c�digos postales.
        /// </summary>
        private bool _blnBloqueaEventos;

        #region PARA PERSONA EXTRAVIADA

        /// <summary>
        /// Lista de personas extraviadas para Incidencia de tipo Persona Extraviada.
        /// </summary>
        protected PersonaExtraviadaList ListaPersonasExtraviadas;

        #endregion

        #region PARA ROBO DE VEHICULO

        /// <summary>
        /// Guarda los datos del propietario del veh�culo, cuando la incidencia es del tipo robo de veh�culo
        /// </summary>
        protected PropietarioVehiculoObject objPropietarioVehiculo;

        /// <summary>
        /// Lista de vehiculos robados para incidencia de tipo robo de veh�culo.
        /// </summary>
        protected VehiculoObjectList ListaVehiculosRobados;

        #endregion

        #region PARA ROBO DE ACCESORIOS DE VEHICULO

        /// <summary>
        /// Objetos robados para incidencia de tipo Robo de accesorios de veh�culo.
        /// </summary>
        protected RoboVehiculoAccesoriosList ListaAccesoriosRobados;

        /// <summary>
        /// Datos generales del robo de accesorios de vehiculos.
        /// </summary>
        protected RoboAccesorios DatosRoboAccesorios;

        /// <summary>
        /// Lista de veh�culos involucrados en el robo de accesorios.
        /// </summary>
        protected VehiculoObjectList ListaVehiculosInvolucrados;

        #endregion

        /// <summary>
        /// Contiene la informaci�n del tel�fono registrado en la base de Telmex.
        /// </summary>
        private TelefonoTelmex DatosTitular;

        /// <summary>
        /// Contiene la lista de localidades por municipio.
        /// </summary>
        //LocalidadList objListaLocalidades;

        /// <summary>
        /// Contiene la lista de c�digos postales.
        /// </summary>
        //CodigoPostalList objListaCodigosPostales = new CodigoPostalList();

        /// <summary>
        /// Representa un c�digo postal.
        /// </summary>
        //CodigoPostal entCodigoPostal;

        /// <summary>
        /// Contiene todos los datos del usuario logueado.
        /// </summary>
        private Usuario entUsuario;

        /// <summary>
        /// Indica si el formulario esta en modo edici�n
        /// </summary>
        protected bool EsModoEdicion;

        /// <summary>
        /// Indica si se debe disparar los eventos en cascada desde Municipio,localidad,colonia,c�digo postal.
        /// </summary>
        //private bool DispararCascadaHaciaAbajo;

        /// <summary>
        /// Indica si se debe disparar los eventos en cascada desde Codigo Postal,colonia,localidad y municipio.
        /// </summary>
        private bool DispararCascadaHaciaArriba = true;

        #endregion

        #region PROPIEDADES

        private bool esSoloLectura;

        /// <summary>
        /// Obtiene o establece el valor que indica si el formulario ser� de solo lectura
        /// </summary>
        /// <remarks>Cuando esta propiedad es verdadera, los controles hijos del formulario se convierten a solo lectura</remarks>
        public bool EsSoloLectura
        {
            get { return esSoloLectura; }
            set
            {
                esSoloLectura = value;

                if (value)
                {
                    foreach (Control objControl in Controls)
                    {
                        if (objControl.GetType() == (new GroupBox()).GetType())
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
                    foreach (Control objControl in Controls)
                    {
                        if (objControl.GetType() == (new GroupBox()).GetType())
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
                    this.cmbTipoIncidencia.Enabled = false;
                }
            }
        }

        #endregion

        #region M�TODOS

        /// <summary>
        /// Muestra la informaci�n de la incidencia que se esta editando.
        /// </summary>
        private void MostrarDatosIncidencia()
        {
            try
            {
                //Mostramos datos planos de la incidencia.
                this.txtTelefono.Text = entIncidencia.Telefono;
                this.txtDireccion.Text = entIncidencia.Direccion;
                this.txtReferencias.Text = entIncidencia.Referencias;
                this.txtDescripcion.Text = entIncidencia.Descripcion;
                //Mostramos los datos del denunciante.
                if (entIncidencia.ClaveDenunciante.HasValue)
                {
                    Denunciante = this.ObtenerDenunciante(entIncidencia.ClaveDenunciante.Value);
                    this.txtNombreDenunciante.Text = Denunciante.Nombre;
                    this.txtDireccionDenunciante.Text = Denunciante.Direccion;
                    this.txtApellidosDenunciante.Text = Denunciante.Apellido;
                }

                if (this.entIncidencia.ClaveEstado.HasValue && this.entIncidencia.ClaveMunicipio.HasValue)
                {
                    //Selecciona el muncipio correspondiente
                    foreach (Municipio municipio in cmbMunicipio.Items)
                    {
                        if (municipio.Clave == this.entIncidencia.ClaveMunicipio.Value)
                        {
                            this.cmbMunicipio.SelectedItem = municipio;
                            break;
                        }
                    }

                    this._blnBloqueaEventos = false;
                    //Actualiza la lista de localidades dependiendo del municipio ya seleccionado
                    this.cbxMunicipioActualizaLocalidades();
                    //Si hay una clave de localidad especificada
                    if (this.entIncidencia.ClaveLocalidad.HasValue)
                    {
                        foreach (Localidad localidad in cmbLocalidad.Items)
                        {
                            if (localidad.Clave == this.entIncidencia.ClaveLocalidad.Value)
                            {
                                //selecciona la localidad correspondiente
                                this.cmbLocalidad.SelectedItem = localidad;
                                break;
                            }
                        }

                        if (this.entIncidencia.ClaveColonia.HasValue)
                        {
                            this.cbxLocalidadActualizaColonia();
                            foreach (Colonia colonia in cmbColonia.Items)
                            {
                                if (colonia.Clave == this.entIncidencia.ClaveColonia.Value)
                                {
                                    this.cmbColonia.SelectedItem = colonia;
                                    break;
                                }
                            }
                        }
                    }
                }

                //Seleccionamos el municipio
                /*if (entIncidencia.ClaveMunicipio.HasValue)
                { 
                    this.cmbMunicipio.SelectedValue = entIncidencia.ClaveMunicipio;
                    //Seleccionamos la localidad
                    if (entIncidencia.ClaveLocalidad.HasValue)
                    {
                        this.cmbLocalidad.SelectedValue = entIncidencia.ClaveLocalidad;
                        //Seleccionamos la colonia.
                        if (entIncidencia.ClaveColonia.HasValue)
                          {
                            this.cmbColonia.SelectedValue = entIncidencia.ClaveColonia;
                            //Seleccionamos el c�digo postal
                            if (entIncidencia.ClaveCodigoPostal.HasValue)
                             {this.cmbCP.SelectedValue = entIncidencia.ClaveCodigoPostal;}
                           }
                    }
                    
                    
                }*/

                //Buscamos las corporaciones y las seleccionamos.
                CorporacionIncidenciaList Corporaciones =
                    CorporacionIncidenciaMapper.Instance().GetByIncidencia(this.entIncidencia.Folio);
                foreach (CorporacionIncidencia corporacion in Corporaciones)
                {
                    Corporacion corp = CorporacionMapper.Instance().GetOne(corporacion.ClaveCorporacion);

                    for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                    {
                        var elemento = this.cklCorporacion.Items[i];
                        if (elemento.ToString() == corp.Descripcion)
                        {
                            this.cklCorporacion.SetItemChecked(i, true);
                        }
                    }
                }
                //Checamos el tipo de incidencia y obtenemos los objetos dependientes como Vehiculos Robados,Accesorios o Personas extraviadas.
                //Seleccionamos el tipo de incidencia.
                this.cmbTipoIncidencia.SelectedValue = entIncidencia.ClaveTipo.Value;
                this.cmbTipoIncidencia.Enabled = false;
                //Obtenemos la informaci�n extra en caso de ser robo de vehiculo,accesorios o persona extraviada.
                switch (entIncidencia.ClaveTipo.Value)
                {
                    //Robo de veh�culo totalidad.
                    case 131:
                        if (ListaVehiculosRobados == null)
                        {
                            ListaVehiculosRobados = new VehiculoObjectList();
                        }

                        VehiculoObject vehiculo;
                        //Obtenemos la lista de los vehiculos robados.
                        VehiculoRobadoObjectList VehiculosXIncidencia =
                            VehiculoRobadoMapper.Instance().GetByIncidencia(entIncidencia.Folio);
                        foreach (VehiculoRobadoObject vehiculoRobado in VehiculosXIncidencia)
                        {
                            //Obtenemos los datos del vehiculo y lo metemos en la lista
                            vehiculo = VehiculoMapper.Instance().GetOne(vehiculoRobado.ClaveVehiculo);
                            ListaVehiculosRobados.Add(vehiculo);
                        }
                        //Obtenemos los datos del propierario
                        objPropietarioVehiculo =
                            PropietarioVehiculoMapper.Instance().GetOne(VehiculosXIncidencia[0].ClavePropietario.Value);

                        break;

                    //Robo de vehiculos accesorios.
                    case 130:
                        //Obtenemos los datos generales del robo de accesorios
                        if (DatosRoboAccesorios == null)
                        {
                            DatosRoboAccesorios = new RoboAccesorios();
                        }
                        DatosRoboAccesorios = RoboAccesoriosMapper.Instance().GetByIncidencia(entIncidencia.Folio)[0];

                        //Obtenemos la lista de accesorios robados.
                        ListaAccesoriosRobados =
                            RoboVehiculoAccesoriosMapper.Instance().GetByRoboAccesorios(
                                DatosRoboAccesorios.IdRoboAccesorio);

                        //Obtenemos los vehiculos involucrados.
                        if (ListaVehiculosInvolucrados == null)
                        {
                            ListaVehiculosInvolucrados = new VehiculoObjectList();
                        }
                        VehiculoObject vehiculoInvolucrado;
                        foreach (RoboVehiculoAccesorios accesorio in ListaAccesoriosRobados)
                        {
                            //vehiculoInvolucrado = new VehiculoObject();
                            vehiculoInvolucrado = VehiculoMapper.Instance().GetOne(accesorio.ClaveVehiculo.Value);
                            if (!ListaVehiculosInvolucrados.Contains(vehiculoInvolucrado))
                            {
                                ListaVehiculosInvolucrados.Add(vehiculoInvolucrado);
                            }
                        }

                        break;

                    //Extravio de persona.
                    case 103:
                    case 235:
                        //Obtenemos las personas extraviadas para esta incidencia.
                        if (ListaPersonasExtraviadas == null)
                        {
                            ListaPersonasExtraviadas = new PersonaExtraviadaList();
                        }
                        ListaPersonasExtraviadas =
                            PersonaExtraviadaMapper.Instance().GetByIncidencia(entIncidencia.Folio);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar informaci�n de la incidencia : " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene la entidad denunciante
        /// </summary>
        /// <param name="idDenunciante">int,Id del denunciante</param>
        /// <returns>DenuncianteObject,Denunciante encontrado.</returns>
        private DenuncianteObject ObtenerDenunciante(int idDenunciante)
        {
            DenuncianteObject denunciante = DenuncianteMapper.Instance().GetOne(idDenunciante);
            return denunciante;
        }

        /*
                /// <summary>
                /// Actualiza la informaci�n en la colecci�n global de ventanas de la incidencia actual
                /// </summary>
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
                                    Aplicacion.VentanasIncidencias[i].Folio = entIncidencia.Folio.ToString();
                                    if (entIncidencia.Descripcion != string.Empty)
                                        Aplicacion.VentanasIncidencias[i].Informacion += "Descripci�n: " + entIncidencia.Descripcion;

                                    if (entIncidencia.Referencias != string.Empty)
                                        Aplicacion.VentanasIncidencias[i].Informacion += "Referencias: " + entIncidencia.Referencias;
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
        */

        /// <summary>
        /// Guarda las corporaciones asociadas a la incidencia
        /// </summary>
        private void GuardaCorporaciones()
        {
            //if (!_blnDirty)
            //    return;

            IEnumerator myEnumerator;
            CorporacionList ListaCorporaciones = this.ObtenerCorporaciones();
            bool blnTieneDatos = false;
            CorporacionIncidenciaList lstCorporacionIncidencia;

            try
            {
                try
                {
                    //Se revisa si la incidncia ya tiene despacho, si es as�, no se puede  modificar la infomraci�n
                    lstCorporacionIncidencia =
                        CorporacionIncidenciaMapper.Instance().GetByIncidencia(this.entIncidencia.Folio);
                    if (lstCorporacionIncidencia != null && lstCorporacionIncidencia.Count > 0)
                    {
                        foreach (CorporacionIncidencia entCorporacionIncidencia in lstCorporacionIncidencia)
                        {
                            if (
                                DespachoIncidenciaMapper.Instance().GetByCorporacionIncidencia(
                                    this.entIncidencia.Folio, entCorporacionIncidencia.ClaveCorporacion).Count > 0)
                            {
                                for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                                {
                                    this.cklCorporacion.SetItemChecked(i, false);
                                }

                                for (int j = 0; j < lstCorporacionIncidencia.Count; j++)
                                {
                                    Corporacion entCorporacion =
                                        CorporacionMapper.Instance().GetOne(lstCorporacionIncidencia[j].ClaveCorporacion);

                                    for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                                    {
                                        if (this.cklCorporacion.Items[i].ToString() == entCorporacion.Descripcion)
                                        {
                                            this.cklCorporacion.SetItemChecked(i, true);
                                        }
                                    }
                                }

                                throw new SAIExcepcion(
                                    "No es posible modificar la informaci�n de las corporaciones asociadas, la incidencia ya est� siendo despachada",
                                    this);
                            }
                        }
                    }

                    if (this._blnSeActivoClosed)
                    {
                        return;
                    }

                    if (this.entIncidencia == null)
                    {
                        return;
                    }
                    this.entIncidencia.ClaveEstatus = 1;

                    //IncidenciaMapper.Instance().Save(this.entIncidencia);

                    CorporacionIncidenciaMapper.Instance().DeleteByIncidencia(this.entIncidencia.Folio);

                    myEnumerator = this.cklCorporacion.CheckedIndices.GetEnumerator();
                    //int y;
                    while (myEnumerator.MoveNext())
                    {
                        var y = (int)myEnumerator.Current;
                        foreach (Corporacion objCorporacion in ListaCorporaciones)
                        {
                            if (this.cklCorporacion.Items[y].ToString() == objCorporacion.Descripcion)
                            {
                                blnTieneDatos = true;
                                CorporacionIncidenciaMapper.Instance().Insert(
                                    new CorporacionIncidencia(this.entIncidencia.Folio, objCorporacion.Clave));
                            }
                        }
                    }

                    if (blnTieneDatos)
                    {
                        this.entIncidencia.ClaveEstatus = 2;
                        //IncidenciaMapper.Instance().Save(this.entIncidencia);
                    }

                    IncidenciaMapper.Instance().Save(this.entIncidencia);
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
        /// Guarda los accesorios de un vehiculo especificado.
        /// </summary>
        /// <param name="idRoboAccesorio">int, Id del robo</param>
        /// <param name="idVehiculoActual">int,Id de vehiculo despues de guardar</param>
        /// <param name="idVehiculoAnterior">int,Id del vehiculo despues de guardar</param>
        private void GuardarAccesoriosPorVehiculo(int idRoboAccesorio, int idVehiculoActual, int idVehiculoAnterior)
        {
            //Guardamos los accesorios robados
            foreach (RoboVehiculoAccesorios accesorio in this.ListaAccesoriosRobados)
            {
                if (accesorio.ClaveVehiculo == idVehiculoAnterior)
                {
                    accesorio.IdRoboAccesorio = idRoboAccesorio;
                    accesorio.ClaveVehiculo = idVehiculoActual;
                    RoboVehiculoAccesoriosMapper.Instance().Insert(accesorio);
                }
            }
        }

        /// <summary>
        /// Actualiza la informaci�n de la incidencia.
        /// </summary>
        private void ActualizaIncidencia()
        {
            try
            {
                //Checamos si no son bromas o insultos.
                if (cmbTipoIncidencia.SelectedItem != null && (
                                                                  (cmbTipoIncidencia.SelectedItem as TipoIncidencia).
                                                                      Clave == 254
                                                                  ||
                                                                  (cmbTipoIncidencia.SelectedItem as TipoIncidencia).
                                                                      Clave == 256
                                                              ))
                {
                    txtDireccion.Text = "SIN REGISTRO";
                    //Se cambia a incidencia cancelada
                    entIncidencia.ClaveEstatus = 5;
                }

                //Se se est� editando no se modifica nada de lo capturado.

                //Checamos si existen Vehiculos con accesorios robados.
                if (ListaVehiculosInvolucrados != null && ListaAccesoriosRobados != null && DatosRoboAccesorios != null &&
                    (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 130)
                {
                    try
                    {
                        //Guardamos los datos del robo de accesorios
                        DatosRoboAccesorios.IdIncidencia = entIncidencia.Folio;
                        RoboAccesoriosMapper.Instance().Insert(DatosRoboAccesorios);
                        //Guardamos los vehiculos involucrados.
                        foreach (VehiculoObject vehiculo in this.ListaVehiculosInvolucrados)
                        {
                            int idAnterior = vehiculo.Clave;
                            VehiculoMapper.Instance().Insert(vehiculo);

                            //Guardamos los accesorios de este vehiculo.
                            this.GuardarAccesoriosPorVehiculo(DatosRoboAccesorios.IdRoboAccesorio, vehiculo.Clave,
                                                              idAnterior);
                        }
                    }
                    catch
                    {
                    }
                }

                //Checamos si existen Vehiculos robados.
                if (this.ListaVehiculosRobados != null && this.objPropietarioVehiculo != null &&
                    (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 131)
                {
                    //Guardamos el propietarios
                    if (PropietarioVehiculoMapper.Instance().GetOne(objPropietarioVehiculo.Clave) == null)
                    {
                        PropietarioVehiculoMapper.Instance().Insert(objPropietarioVehiculo);
                    }
                    else
                    {
                        PropietarioVehiculoMapper.Instance().Save(objPropietarioVehiculo);
                    }

                    //Guardamos los vehiculos.
                    foreach (VehiculoObject vehiculo in this.ListaVehiculosRobados)
                    {
                        if (VehiculoMapper.Instance().GetOne(vehiculo.Clave) == null)
                        {
                            VehiculoMapper.Instance().Insert(vehiculo);
                        }
                        else
                        {
                            VehiculoMapper.Instance().Save(vehiculo);
                        }
                    }


                    //Insertamos en la tabla de relaci�n los vehiculos robados
                    VehiculoRobadoObject vehiculoRobado;
                    bool EsNuevoVehiculoRobado;
                    foreach (VehiculoObject vehiculo in this.ListaVehiculosRobados)
                    {
                        vehiculoRobado = new VehiculoRobadoObject();
                        EsNuevoVehiculoRobado = true;
                        if (VehiculoRobadoMapper.Instance().GetByVehiculo(vehiculo.Clave).Count > 0)
                        {
                            vehiculoRobado = VehiculoRobadoMapper.Instance().GetByVehiculo(vehiculo.Clave)[0];
                            EsNuevoVehiculoRobado = false;
                        }
                        ;
                        if (vehiculoRobado == null)
                        {
                            vehiculoRobado = new VehiculoRobadoObject();
                            EsNuevoVehiculoRobado = true;
                        }
                        vehiculoRobado.ClavePropietario = objPropietarioVehiculo.Clave;
                        vehiculoRobado.ClaveVehiculo = vehiculo.Clave;
                        vehiculoRobado.Folio = this.entIncidencia.Folio;
                        if (EsNuevoVehiculoRobado)
                        {
                            VehiculoRobadoMapper.Instance().Insert(vehiculoRobado);
                        }
                        else
                        {
                            VehiculoRobadoMapper.Instance().Save(vehiculoRobado);
                        }
                    }
                }

                //Checamos si existen personas extraviadas
                if (this.ListaPersonasExtraviadas != null && this.ListaPersonasExtraviadas.Count > 0 &&
                    ((cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 103 |
                     (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 235))
                {
                    foreach (PersonaExtraviada persona in this.ListaPersonasExtraviadas)
                    {
                        persona.Folio = this.entIncidencia.Folio;
                        persona.Estatura = Math.Round(persona.Estatura.Value, 2);
                        //Si existe solo lo actualizamos.
                        if (PersonaExtraviadaMapper.Instance().GetOne(persona.Clave) != null)
                        {
                            PersonaExtraviadaMapper.Instance().Save(persona);
                        }
                        else
                        {
                            PersonaExtraviadaMapper.Instance().Insert(persona);
                        }
                    }
                }

                //Guardamos el denunciante y actualizamos el campo en la incidencia.
                bool EsNuevo = false;
                if (this.Denunciante == null)
                {
                    this.Denunciante = new DenuncianteObject();
                    EsNuevo = true;
                }
                Denunciante.Nombre = this.txtNombreDenunciante.Text;
                Denunciante.Apellido = this.txtApellidosDenunciante.Text;
                Denunciante.Direccion = this.txtDireccionDenunciante.Text;
                if (EsNuevo) //Insertamos.
                {
                    DenuncianteMapper.Instance().Insert(this.Denunciante);
                }
                else //Actualizamos.
                {
                    DenuncianteMapper.Instance().Save(this.Denunciante);
                }

                //Actualizamos la incidencia.
                this.entIncidencia.ClaveDenunciante = Denunciante.Clave;
                IncidenciaMapper.Instance().Save(entIncidencia);
                this.LiberarNoTelefono(this.txtTelefono.Text.Trim());
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message, this);
            }
        }

        /// <summary>
        /// Lee los datos del formulario y escribe la informaci�n en el objeto de incidencia
        /// </summary>
        protected void RecuperaDatosEnIncidencia()
        {
            //this.ActualizaMapaUbicacion();
            if (entIncidencia != null)
            {
                //Obtenemos el municipio
                if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
                {
                    entIncidencia.ClaveMunicipio = null;
                }
                else
                {
                    entIncidencia.ClaveMunicipio = _objUbicacion.IdMunicipio;
                }

                //Obtenemos la localidad.
                if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
                {
                    entIncidencia.ClaveLocalidad = null;
                }
                else
                {
                    entIncidencia.ClaveLocalidad = _objUbicacion.IdLocalidad;
                }

                //Obtenemos la colonia.
                if (cmbColonia.SelectedIndex == -1 || cmbColonia.Text.Trim() == string.Empty)
                {
                    entIncidencia.ClaveColonia = null;
                }
                else
                {
                    entIncidencia.ClaveColonia = _objUbicacion.IdColonia;
                }

                //Obtenemos el c�digo postal.
                if (cmbCP.SelectedIndex == -1 || cmbCP.Text.Trim() == string.Empty)
                {
                    entIncidencia.ClaveCodigoPostal = null;
                }
                else
                {
                    entIncidencia.ClaveCodigoPostal = _objUbicacion.IdCodigoPostal;
                }

                //Obtenemos el tipo de incidencia.
                if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
                {
                    entIncidencia.ClaveTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave;
                }
                else
                {
                    entIncidencia.ClaveTipo = null;
                }

                //Obtenemos el n�mero de tel�fono,descripci�n y la direcci�n.
                entIncidencia.Telefono = txtTelefono.Text;
                entIncidencia.Descripcion = txtDescripcion.Text;
                entIncidencia.Direccion = txtDireccion.Text;
                entIncidencia.Referencias = txtReferencias.Text;
            }
        }

        /// <summary>
        /// Crea una nueva incidencia y muestra sus datos al abrir el formilario.
        /// </summary>
        private void CrearNuevaIncidencia()
        {
            try
            {
                entIncidencia.Referencias = string.Empty;
                entIncidencia.Descripcion = string.Empty;
                entIncidencia.Activo = true;
                entIncidencia.HoraRecepcion = DateTime.Now;
                entIncidencia.ClaveEstatus = 1;
                entIncidencia.ClaveEstado = 29;
                entIncidencia.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;
                IncidenciaMapper.Instance().Insert(entIncidencia);
                entUsuario = UsuarioMapper.Instance().GetOne(entIncidencia.ClaveUsuario);
                this.lblOperador.Text += entUsuario.NombrePropio;
                this.lblFechaHora.Text += entIncidencia.HoraRecepcion.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la nueva incidencia : " + ex.Message, "Error");
                return;
            }
        }

        /// <summary>
        /// Llena la lista de municipios
        /// </summary>
        private void CargarMunicipios()
        {
            try
            {
                try
                {
                    //var lstMunicipios = MunicipioMapper.Instance().GetAll();
                    //DispararCascadaHaciaAbajo = false;
                    cmbMunicipio.DataSource = MunicipioMapper.Instance().GetAll(); //lstMunicipios;
                    cmbMunicipio.DisplayMember = "Nombre";
                    cmbMunicipio.ValueMember = "Clave";
                    //DispararCascadaHaciaAbajo = true;
                    cmbMunicipio.SelectedIndex = -1;
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
        /// Llena la lista de tipos de incidencia por tipo de sistema.
        /// </summary>
        private void CargarTiposIncidencias()
        {
            TipoIncidenciaList lstTipoIncidencias;
            lstTipoIncidencias = Aplicacion.UsuarioPersistencia.strSistemaActual == "066"
                                     ? TipoIncidenciaMapper.Instance().GetBySistema(2)
                                     : TipoIncidenciaMapper.Instance().GetBySistema(1);

            foreach (var objTipoIncidencia in lstTipoIncidencias)
            {
                objTipoIncidencia.Descripcion = objTipoIncidencia.ClaveOperacion + " " + objTipoIncidencia.Descripcion;
            }

            cmbTipoIncidencia.DataSource = lstTipoIncidencias;
            cmbTipoIncidencia.DisplayMember = "Descripcion";
            cmbTipoIncidencia.ValueMember = "Clave";
        }

        /// <summary>
        /// Actualiza el combo de localidades 
        /// </summary>
        /// <param name="objListaLocalidadesp">Lista de localidades que se mostrar�n en el control</param>
        private void ActualizaLocalidades(LocalidadList objListaLocalidadesp)
        {
            cmbLocalidad.DataSource = objListaLocalidadesp;
            cmbLocalidad.DisplayMember = "Nombre";
            cmbLocalidad.ValueMember = "Clave";
            cmbLocalidad.SelectedIndex = -1;
            //cmbLocalidad.Text = string.Empty;
        }

        /*
                /// <summary>
                /// Obtiene la lista de localidades de un municipio especificado.
                /// </summary>
                /// <param name="idMunicipio">int,Id del municipio.</param>
                private void CargarLocalidadesPorMunicipio(int idMunicipio)
                {
                    objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio(idMunicipio);
                    if (objListaLocalidades != null)
                    {
                        this.ActualizaLocalidades(objListaLocalidades);
                    }
                }
        */

        /*
                /// <summary>
                /// Obtiene la lista de colonias de una localidad especificada.
                /// </summary>
                /// <param name="idLocalidad"></param>
                private void CargarColoniasPorLocalidad(int idLocalidad)
                {
                    ColoniaList lstColonias;

                    try
                    {
                        try
                        {


                            LimpiaColonias();
                            lstColonias = ColoniaMapper.Instance().GetByLocalidad(idLocalidad);


                            if (lstColonias != null)
                            {
                                ActualizaColonias(lstColonias);
                                LimpiaTextoCodigoPostal();
                            }
                            //ActualizaMapaUbicacion(true);
                        }
                        catch (System.Exception ex)
                        {
                            throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                        }
                    }
                    catch (SAIExcepcion) { }
                }
        */

        /*
                /// <summary>
                /// Obtiene el c�digo postal de una colonia especificada.
                /// </summary>
                /// <param name="idCp">int, Id del c�digo postal</param>
                private void CargarCpPorColonia(int idCp)
                {

                    entCodigoPostal = CodigoPostalMapper.Instance().GetOne(idCp);
                    if (entCodigoPostal != null)
                    {
                        objListaCodigosPostales.Clear();
                        this.objListaCodigosPostales.Add(entCodigoPostal);
                        this.ActualizarCodigoPostal(objListaCodigosPostales);
                    }

                }
        */

        /// <summary>
        /// Actualiza la lista de los c�digos postales
        /// </summary>
        /// <param name="objListaCodigosPostalesp">Lista de los c�digos postales que se mostrar�n en el control</param>
        private void ActualizarCodigoPostal(CodigoPostalList objListaCodigosPostalesp)
        {
            this.cmbCP.DataSource = objListaCodigosPostalesp;
            this.cmbCP.DisplayMember = "Valor";
            this.cmbCP.ValueMember = "Clave";
            this.cmbCP.SelectedIndex = -1;
        }

        /*
                /// <summary>
                /// Selecciona el elemento del combo de codigos postales
                /// </summary>
                /// <param name="objElemento">Elemento que se va a seleccionar</param>
                private void SeleccionaCodigoPostal(Object objElemento)
                {
                    cmbCP.SelectedIndex = -1;
                    cmbCP.SelectedItem = objElemento;

                }
        */

        /// <summary>
        /// Actualiza el mapa con los datos de la ubicaci�n del formulario actuales
        /// </summary>
        private void ActualizaMapaUbicacion()
        {
            if (cmbCP.SelectedIndex == -1 || cmbCP.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdCodigoPostal = null;
            }
            else
            {
                _objUbicacion.IdCodigoPostal = (cmbCP.SelectedItem as CodigoPostal).Clave;
            }

            if (cmbColonia.SelectedIndex == -1 || cmbColonia.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdColonia = null;
            }
            else
            {
                _objUbicacion.IdColonia = (cmbColonia.SelectedItem as Colonia).Clave;
            }

            if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdLocalidad = null;
            }
            else
            {
                _objUbicacion.IdLocalidad = (cmbLocalidad.SelectedItem as Localidad).Clave;
            }

            if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdMunicipio = null;
            }
            else
            {
                _objUbicacion.IdMunicipio = int.Parse((cmbMunicipio.SelectedItem as Municipio).Clave.ToString());
            }

            Controlador.MuestraMapa(_objUbicacion, this);
        }

        protected override void OnActivated(EventArgs e)
        {
            try
            {
                try
                {
                    base.OnActivated(e);
                    ActualizaMapaUbicacion();
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

        /// <summary>
        /// Actualiza la lista de colonias del combo correspondiente
        /// </summary>
        /// <param name="lstColonias">Lista de colonias que se van a mostrar en el control</param>
        private void ActualizaColonias(ColoniaList lstColonias)
        {
            cmbColonia.DataSource = lstColonias;
            cmbColonia.DisplayMember = "Nombre";
            cmbColonia.ValueMember = "Clave";
            cmbColonia.SelectedIndex = -1;
            //cmbColonia.Text = string.Empty;
        }

        /*
                /// <summary>
                /// Limpia el texto del combo de c�digos postales
                /// </summary>
                private void LimpiaTextoCodigoPostal()
                {
                    cmbCP.Text = string.Empty;
                }
        */


        /// <summary>
        /// Busca el municipio,localidad al que pertenece un c�digo postal especificado.
        /// </summary>
        /// <param name="codigoPostal">string,Codigo postal</param>
        private void CargarCascadaPorCp(string codigoPostal)
        {
            if (codigoPostal.Trim().Length == 5 && DispararCascadaHaciaArriba)
            {
                ColoniaList lstColonias;
                CodigoPostalList lstCodigoPostal;
                Colonia objColonia;
                Municipio objMunicipio;
                Localidad objLocalidad;

                try
                {
                    //Buscamos el c�digo postal.
                    lstCodigoPostal =
                        CodigoPostalMapper.Instance().GetBySQLQuery(
                            "Select Clave, Valor from CodigoPostal where Valor = '" + codigoPostal + "'");

                    //Obtenemos una colonia con ese c�digo postal.
                    if (lstCodigoPostal != null && lstCodigoPostal.Count > 0)
                    {
                        //Obtenemos la lista de colonias con ese c�digo postal.
                        lstColonias = ColoniaMapper.Instance().GetByCodigoPostal(lstCodigoPostal[0].Clave);
                        if (lstColonias != null && lstColonias.Count > 0)
                        {
                            //Obtenemos una sola colonia.
                            objColonia = lstColonias[0];

                            //Obtenemos la localidad a la que pertenece la colonia.
                            objLocalidad = LocalidadMapper.Instance().GetOne(objColonia.ClaveLocalidad);

                            //Obtenemos el municipio al que pertenece la localidad
                            objMunicipio = MunicipioMapper.Instance().GetOne(objLocalidad.ClaveMunicipio);

                            //Selecionamos el municipio encontrado y se dispara el SelectedIndex
                            //que llena las localidades
                            this.cmbMunicipio.SelectedValue = objMunicipio.Clave;
                            this.cmbLocalidad.SelectedValue = objLocalidad.Clave;
                            //Actualizamos el codigo postal.
                            this.ActualizarCodigoPostal(lstCodigoPostal);
                            //Actualizamos el mapa
                            //this.ActualizaMapaUbicacion();

                            var esUbi = new EstructuraUbicacion() { IdColonia = objColonia.Clave };
                            Controlador.MuestraMapa(esUbi);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
        }

        /// <summary>
        /// Limpia el control que contiene la lista de localidades
        /// </summary>
        private void LimpiaLocalidades()
        {
            cmbLocalidad.DataSource = null;
        }

        /// <summary>
        /// Limpia el combo que contiene la lista de colonias
        /// </summary>
        private void LimpiaColonias()
        {
            cmbColonia.DataSource = null;
        }


        /// <summary>
        /// Limpia el combo que contiene los c�digos postales
        /// </summary>
        private void LimpiaCodigosPostales()
        {
            cmbCP.DataSource = null;
        }

        /*
                /// <summary>
                /// Limpia el texto del control del combo de colonias
                /// </summary>
                private void LimpiaTextoColonia()
                {
                    cmbColonia.SelectedIndex = -1;
                    cmbColonia.Text = string.Empty;
                }
        */

        private CorporacionList ObtenerCorporaciones()
        {
            return
                CorporacionMapper.Instance().GetBySQLQuery(
                    "SELECT [Clave],[Descripcion],[ClaveSistema],[UnidadesVirtuales],[Activo],[Zn] FROM [dbo].[Corporacion] Where Activo = 1");
        }

        /// <summary>
        /// Llena la lista de corporaciones.
        /// </summary>
        private void CargarCoorporaciones()
        {
            CorporacionList lstCorporaciones = new CorporacionList();
            try
            {
                try
                {
                    lstCorporaciones = this.ObtenerCorporaciones();
                    foreach (var corporacion in lstCorporaciones)
                    {
                        cklCorporacion.Items.Add(corporacion.Descripcion);
                    }

                    this.cklCorporacion.CheckOnClick = true;
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
        /// Obtiene la informaci�n del titular de la linea.
        /// </summary>
        /// <param name="noTelefono">string, N�mero telef�nico</param>
        public void ObtenerTitularLinea(string noTelefono)
        {
            if (!string.IsNullOrEmpty(noTelefono))
            {
                DatosTitular = TelefonoTelmexMapper.Instance()
                    .GetOneBySQLQuery(string.Format(ID.SQL_OBTENERINFOTITULARLINEA, noTelefono));
                this.txtTelefono.Text = noTelefono;
                if (DatosTitular != null)
                {
                    this.txtNombreDenunciante.Text = DatosTitular.Nombre;
                    this.txtApellidosDenunciante.Text = string.Format("{0} {1}", DatosTitular.ApellidoPaterno,
                                                                      DatosTitular.ApellidoMaterno);
                    this.txtDireccionDenunciante.Text = DatosTitular.Direccion;
                    CodigoPostal CodigoTitular =
                        CodigoPostalMapper.Instance().GetOneBySQLQuery(string.Format(ID.SQL_OBTENERCODIGOPOSTAL,
                                                                                     DatosTitular.ClaveCodigoPostal));
                    if (CodigoTitular != null)
                    {
                        this.cmbCP.Text = CodigoTitular.Valor;
                        this.CargarCascadaPorCp(CodigoTitular.Valor);
                    }
                }
            }
        }

        /// <summary>
        /// Inserta o actualiza los datos del titular de le linea.
        /// </summary>
        private void GuardarTitularLinea()
        {
            bool EsNuevoTitular = false;
            try
            {
                if (!string.IsNullOrEmpty(this.txtTelefono.Text))
                {
                    this.DatosTitular = new TelefonoTelmex();
                    this.DatosTitular = Mappers.TelefonoTelmexMapper.Instance()
                        .GetOneBySQLQuery(string.Format(ID.SQL_OBTENERINFOTITULARLINEA, this.txtTelefono.Text.Trim()));
                    if (DatosTitular == null)
                    {
                        DatosTitular = new TelefonoTelmex();
                        EsNuevoTitular = true;
                    }
                    this.DatosTitular.Telefono = this.txtTelefono.Text;
                    this.DatosTitular.Nombre = this.txtNombreDenunciante.Text;
                    this.DatosTitular.ApellidoPaterno = txtApellidosDenunciante.Text;
                    this.DatosTitular.Direccion = this.txtDireccionDenunciante.Text;
                    if (!string.IsNullOrEmpty(this.cmbCP.Text))
                    {
                        this.DatosTitular.ClaveCodigoPostal = Convert.ToInt32(this.cmbCP.Text);
                    }
                    if (EsNuevoTitular)
                    {
                        TelefonoTelmexMapper.Instance().Insert(DatosTitular);
                    }
                    else
                    {
                        TelefonoTelmexMapper.Instance().Save(DatosTitular);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar titular de linea : " + ex.Message, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra la pantalla de captura para personas extraviadas
        /// </summary>
        private void MostrarCapturaPersonaExtraviada()
        {
            SAIFrmAltaDatosPersonaExtraviada PantallaPersonaExtraviada = new SAIFrmAltaDatosPersonaExtraviada();
            //Pasamos la lista de personas
            PantallaPersonaExtraviada.ListaPersonas = this.ListaPersonasExtraviadas;
            PantallaPersonaExtraviada.ShowDialog(this);
            //Obtenemos las personas capturadas.
            this.ListaPersonasExtraviadas = PantallaPersonaExtraviada.ListaPersonas;
            this.btnVerDatos.Enabled = true;
        }


        /// <summary>
        /// Muestra la pantalla de captura para accesorios de veh�culos robados.
        /// </summary>
        private void MostrarCapturaAccesoriosRobados()
        {
            SAIFrmAltaAccesoriosAuto066 PantallaInfoAccesorios = new SAIFrmAltaAccesoriosAuto066();
            PantallaInfoAccesorios.ListaAccesoriosRobados = this.ListaAccesoriosRobados;
            PantallaInfoAccesorios.ListaVehiculosInvolucrados = this.ListaVehiculosInvolucrados;
            PantallaInfoAccesorios.DatosRoboAccesorio = this.DatosRoboAccesorios;
            PantallaInfoAccesorios.ShowDialog(this);
            this.ListaAccesoriosRobados = PantallaInfoAccesorios.ListaAccesoriosRobados;
            this.ListaVehiculosInvolucrados = PantallaInfoAccesorios.ListaVehiculosInvolucrados;
            this.DatosRoboAccesorios = PantallaInfoAccesorios.DatosRoboAccesorio;
            this.btnVerDatos.Enabled = true;
        }

        /// <summary>
        /// Muestra la pantalla de captura para veh�culos robados.
        /// </summary>
        private void MostrarCapturaVehiculoRobado()
        {
            SAIFrmAltaDatosAuto066 PantallaInfoAuto = new SAIFrmAltaDatosAuto066();
            //Pasamos el propietario y la lista de vehiculos robados.
            PantallaInfoAuto.Propietario = objPropietarioVehiculo;

            PantallaInfoAuto.ListaVehiculos = this.ListaVehiculosRobados;
            PantallaInfoAuto.ShowDialog(this);
            //Obtenemos los datos capturados sobre vehiculos robados
            this.objPropietarioVehiculo = PantallaInfoAuto.Propietario;
            this.ListaVehiculosRobados = PantallaInfoAuto.ListaVehiculos;
            this.btnVerDatos.Enabled = true;
        }

        /// <summary>
        /// Quita de la lista de llamadas capturadas actuales a el numero actual.
        /// </summary>
        /// <param name="noTelefono"></param>
        private void LiberarNoTelefono(string noTelefono)
        {
            if (Aplicacion.LlamadasActuales.Contains(noTelefono))
            {
                Aplicacion.LlamadasActuales.Remove(noTelefono);
            }
        }

        #endregion

        #region MANEJADORES DE EVENTOS

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxMunicipioActualizaLocalidades();
            /*if (DispararCascadaHaciaAbajo)
            {
                //Buscamos las localidades del municipio seleccionado.
                if (this.cmbMunicipio.SelectedItem != null && this.cmbMunicipio.SelectedIndex != -1)
                {
                    this.CargarLocalidadesPorMunicipio((cmbMunicipio.SelectedItem as Municipio).Clave);

                    //Actualizamos la ubicaci�n del mapa
                    this.ActualizaMapaUbicacion(true);
                }
                else
                {
                    this.LimpiaLocalidades();
                }
            }*/
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxLocalidadActualizaColonia();
            /*if(DispararCascadaHaciaAbajo)
            {
                //Buscamos las colonias de la localidad seleccionada.
                if (this.cmbLocalidad.SelectedItem != null && this.cmbLocalidad.SelectedIndex != -1)
                {
                    this.CargarColoniasPorLocalidad((cmbLocalidad.SelectedItem as Localidad).Clave);
                    //Actualizamos la ubicaci�n del mapa
                    this.ActualizaMapaUbicacion(true);
                }
                else
                {
                    this.LimpiaColonias();
                }
            }*/
        }

        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
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

                    var idCol = Convert.ToInt32(cmbColonia.SelectedValue);
                    var esUbi = new EstructuraUbicacion() { IdColonia = idCol };
                    Controlador.MuestraMapa(esUbi);

                    if (this.cmbCP.Items.Count > 0)
                    {
                        if (((Colonia)this.cmbColonia.SelectedItem).ClaveCodigoPostal.HasValue)
                        {
                            this.cmbCP.SelectedValue = ((Colonia)this.cmbColonia.SelectedItem).ClaveCodigoPostal;
                        }
                    }
                    else
                    {
                        if (this.cmbColonia.SelectedValue != null)
                        {
                            CodigoPostalList lstCodigoPostal = new CodigoPostalList();
                            lstCodigoPostal.Add(
                                CodigoPostalMapper.Instance().GetOne(Convert.ToInt32(this.cmbColonia.SelectedValue)));
                            this._blnBloqueaEventos = true;
                            if (lstCodigoPostal.Count > 0)
                            {
                                ActualizarCodigoPostal(lstCodigoPostal);
                                this.cmbCP.SelectedIndex = 0;
                            }
                            this._blnBloqueaEventos = false;
                        }
                    }

                    this._blnBloqueaEventos = false;
                    //this.ActualizaMapaUbicacion();
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message, this);
                }
            }
            catch (SAIExcepcion)
            {
            }
            /*if(DispararCascadaHaciaAbajo)
            {
                if (this.cmbColonia.SelectedItem != null && this.cmbColonia.SelectedIndex != -1)
                {
                    this.CargarCpPorColonia((this.cmbColonia.SelectedItem as Colonia).ClaveCodigoPostal.Value);
                    //Actualizamos la ubicaci�n del mapa
                    this.ActualizaMapaUbicacion(true);
                }
                else
                {
                    this.LimpiaCodigosPostales();
                    this.LimpiaTextoCodigoPostal();
                }
            }*/
        }

        /*
                private void cmbCP_TextChanged(object sender, EventArgs e)
                {
                    this.CargarCascadaPorCp(this.cmbCP.Text);
                }
        */

        private void cmbTipoIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EsModoEdicion)
            {
                //Limpiamos las listas que reciben datos de ventanas hijas
                this.objPropietarioVehiculo = null;
                this.ListaAccesoriosRobados = null;
                this.ListaPersonasExtraviadas = null;
                this.ListaVehiculosInvolucrados = null;
                this.ListaVehiculosRobados = null;
            }

            cmbMunicipio.Enabled = true;
            cmbLocalidad.Enabled = true;
            cmbColonia.Enabled = true;
            this.btnVerDatos.Enabled = false;
            cmbCP.Enabled = true;
            this.gbDenunciante.Enabled = true;

            try
            {
                try
                {
                    if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty &&
                        !EsModoEdicion)
                    {
                        TipoIncidencia objTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia);

                        if (objTipo != null)
                            switch (objTipo.Clave)
                            {
                                //Robo de veh�culo totalidad.
                                case 131:
                                    //this.MostrarCapturaVehiculoRobado();
                                    btnVerDatos.Enabled = true;

                                    break;

                                //Robo de vehiculos accesorios.
                                case 130:
                                    //this.MostrarCapturaAccesoriosRobados();
                                    btnVerDatos.Enabled = true;

                                    break;

                                //Extravio de persona.
                                case 103:
                                case 235:
                                    //this.MostrarCapturaPersonaExtraviada();
                                    btnVerDatos.Enabled = true;

                                    break;

                                //For�nea
                                case 259:

                                    cmbMunicipio.Enabled = false;
                                    cmbLocalidad.Enabled = false;
                                    cmbColonia.Enabled = false;
                                    cmbCP.Enabled = false;

                                    break;

                                //An�nima.
                                case 260:
                                    this.gbDenunciante.Enabled = false;
                                    break;

                                //BROMA O INSULTO.
                                case 254:
                                case 256:
                                    txtDireccion.Text = "SIN REGISTRO";
                                    break;
                            }
                    }
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

        private void SAIFrmAltaIncidencia066_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                try
                {
                    if (!base.SAIProveedorValidacion.ValidarCamposRequeridos(this))
                    {
                        if (cmbTipoIncidencia.Items.Count != 0)
                        {
                            e.Cancel = true;
                            throw new SAIExcepcion("Debe de indicar el tipo de incidencia", this);
                        }
                        return;
                    }


                    //Checamos si es Broma o Insulto.
                    if (cmbTipoIncidencia.SelectedItem != null && (
                                                                      (cmbTipoIncidencia.SelectedItem as TipoIncidencia)
                                                                          .Clave == 254
                                                                      ||
                                                                      (cmbTipoIncidencia.SelectedItem as TipoIncidencia)
                                                                          .Clave == 256
                                                                  )
                        && txtTelefono.Text.Trim() == string.Empty
                        )
                    {
                        e.Cancel = true;
                        throw new SAIExcepcion("Debe de indicar el n�mero de tel�fono de la incidencia", this);
                    }

                    this.RecuperaDatosEnIncidencia();
                    this.ActualizaIncidencia();
                    this.GuardaCorporaciones();
                    this.GuardarTitularLinea();


                    Mapa.Controlador.RevisaInstancias(this);
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

        private void cklCorporacion_Leave(object sender, EventArgs e)
        {
            GuardaCorporaciones();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            TipoIncidencia objTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia);

            if (objTipo != null)
                switch (objTipo.Clave)
                {
                    //Robo de veh�culo totalidad.
                    case 131:
                        this.MostrarCapturaVehiculoRobado();
                        break;

                    //Robo de vehiculos accesorios.
                    case 130:
                        this.MostrarCapturaAccesoriosRobados();
                        break;

                    //Extravio de persona.
                    case 103:
                    case 235:
                        this.MostrarCapturaPersonaExtraviada();
                        break;
                }
        }

        private void SAIFrmAltaIncidencia066_Load(object sender, EventArgs e)
        {
            //this.ActualizaMapaUbicacion(true);
        }

        #region EVENTOS GEN�RICOS

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No permite introducir texto
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            Control controlActual = (Control)sender;
            //Para pasar el foco al control siguiente.
            switch (e.KeyData)
            {
                case Keys.Enter:


                    this.FindForm().SelectNextControl(controlActual, true, false, true, true);

                    break;

                case Keys.Escape:

                    if (controlActual.Name == this.cmbMunicipio.Name)
                    {
                        this.LimpiaCodigosPostales();
                        this.LimpiaColonias();
                        this.LimpiaLocalidades();

                        this.cmbMunicipio.SelectedIndex = -1;
                    }


                    break;
            }
        }

        #endregion

        #endregion

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
                    var idMun = Convert.ToInt32(cmbMunicipio.SelectedValue);
                    var esUbi = new EstructuraUbicacion() { IdMunicipio = idMun };
                    Controlador.MuestraMapa(esUbi);

                    this._blnBloqueaEventos = true;

                    //Limpiar localidades y colonias
                    this.LimpiaLocalidades();
                    this.LimpiaColonias();
                    this.LimpiaCodigosPostales();

                    //obtener las localidades del municipio seleccionado
                    LocalidadList lstLocalidades =
                        LocalidadMapper.Instance().GetByMunicipio(idMun/*((Municipio)this.cmbMunicipio.SelectedItem).Clave*/);

                    if (lstLocalidades.Count > 0)
                    {
                        this.ActualizaLocalidades(lstLocalidades);
                    }
                    this._blnBloqueaEventos = false;
                    //this.ActualizaMapaUbicacion();
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

        private void cbxLocalidadActualizaColonia()
        {
            try
            {
                ColoniaList lstColonia;
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

                    var idLoc = Convert.ToInt32(cmbLocalidad.SelectedValue);
                    var esUbi = new EstructuraUbicacion() { IdLocalidad = idLoc };
                    Controlador.MuestraMapa(esUbi);

                    lstColonia =
                        ColoniaMapper.Instance().GetByLocalidad(idLoc/*((Localidad)this.cmbLocalidad.SelectedItem).Clave*/);
                    if (lstColonia.Count > 0)
                    {
                        //se agregan colonias al control correspondientes a la localidad seleccionada
                        //posteriormente se agregaran lo CP de la localidad agregada
                        this.ActualizaColonias(lstColonia);
                        //objeto que se que almacenara los CP
                        //Entidades.CodigoPostalList cpTemp = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.CodigoPostalList();
                        //SE OBTIENE LA LISTA DE CODIGOS POSTALES DE LA LOCALIDAD CORRESPONDIENTE
                        CodigoPostalList lstCodigoPostal =
                            CodigoPostalMapper.Instance().GetByLocalidad(idLoc/*
                                ((Localidad)this.cmbLocalidad.SelectedItem).Clave*/
                                                                                   );
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
                    //this.ActualizaMapaUbicacion();
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

        private void cmbCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.cmbCP.Text.Length == 5)
                    {
                        if (this._blnBloqueaEventos)
                        {
                            return;
                        }

                        var idCp = Convert.ToInt32(cmbCP.SelectedValue);
                        var esUbi = new EstructuraUbicacion() { IdCodigoPostal = idCp };
                        Controlador.MuestraMapa(esUbi);

                        if (this.cmbCP.Items.Count > 0 && this.cmbColonia.Items.Count > 0)
                        {
                            if (this.cmbCP.SelectedValue != null)
                            {
                                ColoniaList lstColonia =
                                    ColoniaMapper.Instance().GetByCodigoPostal(idCp/*Convert.ToInt32(this.cmbCP.SelectedValue)*/);
                                if (lstColonia.Count > 0)
                                {
                                    this._blnBloqueaEventos = true;
                                    this.cmbColonia.SelectedValue = lstColonia[0].Clave;
                                    this._blnBloqueaEventos = false;
                                }
                            }
                            //this.ActualizaMapaUbicacion();
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

        private void cmbCP_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.cmbCP.Text.Length == 5 && e.KeyCode == Keys.Enter)
            {
                string codigop = this.cmbCP.Text;
                try
                {
                    this._blnBloqueaEventos = true;
                    this.cmbCP.DataSource = null;
                    this._blnBloqueaEventos = false;
                }
                catch
                {
                }
                CargarPorCP(codigop);
                //this.ActualizaMapaUbicacion();
            }
        }

        private void CargarPorCP(string codigoPostal)
        {
            try
            {
                try
                {
                    //SE OBTIENE LA ENTIDAD DEL CODIGO POSTAL
                    CodigoPostal CP =
                        CodigoPostalMapper.Instance().GetOneBySQLQuery(
                            "Select Clave, Valor from CodigoPostal where Valor = '" + codigoPostal + "'");

                    //SI EXISTE
                    if (CP != null)
                    {
                        CodigoPostalList lstCodigoPostal = new CodigoPostalList();
                        lstCodigoPostal.Add(CP);

                        this._blnBloqueaEventos = true;
                        this.ActualizarCodigoPostal(lstCodigoPostal);
                        this.cmbCP.SelectedIndex = 0;
                        this._blnBloqueaEventos = false;

                        //SE OBTIENE LA LISTA DE COLONIAS POR EL CODIGO POSTAL
                        ColoniaList lstColonias = ColoniaMapper.Instance().GetByCodigoPostal(CP.Clave);

                        if (lstColonias.Count > 0)
                        {
                            //SE BLOQUEA EVENTO PARA LLENADO DE COLONIAS
                            this._blnBloqueaEventos = true;
                            this.ActualizaColonias(lstColonias);

                            //SE SELECCIONA LA PRIMERA COLONIA
                            //CABE MENCIONAR QUE UN CODIG POSTAL PUEDE CORRESPONDER A VARIAS COLONIAS
                            this.cmbColonia.SelectedIndex = 0;
                            this._blnBloqueaEventos = false;

                            //SE AGREGA LA COLONIA A LA LISTA
                            LocalidadList lstLocalidad = new LocalidadList();
                            lstLocalidad.Add(
                                LocalidadMapper.Instance().GetOne(((Colonia)this.cmbColonia.Items[0]).ClaveLocalidad));

                            //SE ACTUALIZA LA LISTA DE COLONIAS
                            this._blnBloqueaEventos = true;
                            this.ActualizaLocalidades(lstLocalidad);

                            this.cmbLocalidad.SelectedIndex = 0;

                            Localidad localidad =
                                LocalidadMapper.Instance().GetOne(Convert.ToInt32(this.cmbLocalidad.SelectedValue));
                            this.cmbMunicipio.SelectedValue = localidad.ClaveMunicipio;
                            this._blnBloqueaEventos = false;

                            //var idLoc = Convert.ToInt32(this.cmbLocalidad.SelectedValue);
                            var esUbi = new EstructuraUbicacion() {IdLocalidad = localidad.Clave };
                            Controlador.MuestraMapa(esUbi);
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

        private void cmbCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else e.Handled = !Char.IsControl(e.KeyChar);
        }

        private void cmbCP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbColonia.Focus();
            }
        }

        private void cklCorporacion_MouseUp(object sender, MouseEventArgs e)
        {
            GuardaCorporaciones();
        }

        private void cmbTipoIncidencia_Leave(object sender, EventArgs e)
        {
            if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
            {
                entIncidencia.ClaveTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave;
            }
            else
            {
                entIncidencia.ClaveTipo = null;
            }
            IncidenciaMapper.Instance().Save(entIncidencia);
        }

        private void cklCorporacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                GuardaCorporaciones();
        }

        private void SAIFrmAltaIncidencia066_FormClosed(object sender, FormClosedEventArgs e)
        {
            //para que no se quede en memoria
            Aplicacion.intFolioPorCancelar = null;
        }
    }
}