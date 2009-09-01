//Autor : T.S.U. Angel Martinez Ortiz
//Fecha : Agosto del 2009
//Empresa :InfinitySoft TI Experts

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using System.Collections;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAltaIncidencia066 : SAIFrmBase
    {

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="noTelefono">string, Número de teléfono</param>
        public SAIFrmAltaIncidencia066(string noTelefono)
        {
            InitializeComponent();

            

            //Creamos la nueva incidencia.
            this.CrearNuevaIncidencia();
            this.Text = string.Format("REGISTRO DE NUEVA INCIDENCIA FOLIO: {0}",this.entIncidencia.Folio);
            //Inicializamos las listas
            this.CargarMunicipios();
            this.CargarTiposIncidencias();
            this.CargarCoorporaciones();
            
            //Buscamos los datos del titular de la linea
            this.ObtenerTitularLinea(noTelefono);

        }

        #endregion

        #region VARIABLES

        /// <summary>
        /// Guarda la referencia a la entidad Incidencia que se maneja en el formulario
        /// </summary>
        protected Incidencia entIncidencia = new Incidencia();

        /// <summary>
        /// Objeto que guarda las claves de municipio, localidad, colonia y código postal que se tienen escogidas por el 
        /// usuario a cada momento en el formulario
        /// </summary>
        /// <remarks>
        /// Este objeto se pasa al método del la clase controladora del mapa para leer los valores de los id's correspondientes
        /// </remarks>
        private Mapa.EstructuraUbicacion _objUbicacion = new Mapa.EstructuraUbicacion();

        /// <summary>
        /// Esta bandera lleva el estado para saber si el usuario quiso cerrar la ventana, esto para saber
        /// si se va a guardar la incidencia en los eventos Leave de los controles, si está en falso se guardan
        /// los datos en dichos eventos, de lo contrario no se guarda la incidencia en tales eventos.
        /// </summary>
        protected Boolean _blnSeActivoClosed;

        

        



        #region PARA PERSONA EXTRAVIADA

        /// <summary>
        /// Lista de personas extraviadas para Incidencia de tipo Persona Extraviada.
        /// </summary>
        protected PersonaExtraviadaList ListaPersonasExtraviadas;


        #endregion

        #region PARA ROBO DE VEHICULO

        /// <summary>
        /// Guarda los datos del propietario del vehículo, cuando la incidencia es del tipo robo de vehículo
        /// </summary>
        protected PropietarioVehiculoObject objPropietarioVehiculo;

        /// <summary>
        /// Lista de vehiculos robados para incidencia de tipo robo de vehículo.
        /// </summary>
        protected VehiculoObjectList ListaVehiculosRobados;

        #endregion

        #region PARA ROBO DE ACCESORIOS DE VEHICULO

        /// <summary>
        /// Objetos robados para incidencia de tipo Robo de accesorios de vehículo.
        /// </summary>
        protected RoboVehiculoAccesoriosObjectList ListaAccesoriosRobados;

        /// <summary>
        /// Datos generales del robo de accesorios de vehiculos.
        /// </summary>
        protected RoboAccesoriosObject DatosRoboAccesorios;

        /// <summary>
        /// Lista de vehículos involucrados en el robo de accesorios.
        /// </summary>
        protected VehiculoObjectList ListaVehiculosInvolucrados;

        #endregion

        LocalidadList objListaLocalidades;
        CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
        CodigoPostal entCodigoPostal;

   

        #endregion

        #region PROPIEDADES

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Guarda las corporaciones asociadas a la incidencia
        /// </summary>
        private void GuardaCorporaciones()
        {
            IEnumerator myEnumerator;
            CorporacionList ListaCorporaciones = this.ObtenerCorporaciones();
            Boolean blnTieneDatos = false;
            CorporacionIncidenciaList lstCorporacionIncidencia;

            try
            {
                try
                {
                    //Se revisa si la incidncia ya tiene despacho, si es así, no se puede  modificar la infomración
                    lstCorporacionIncidencia = CorporacionIncidenciaMapper.Instance().GetByIncidencia(this.entIncidencia.Folio);
                    if (lstCorporacionIncidencia != null && lstCorporacionIncidencia.Count > 0)
                    {
                        foreach (CorporacionIncidencia entCorporacionIncidencia in lstCorporacionIncidencia)
                        {
                            if (DespachoIncidenciaMapper.Instance().GetByCorporacionIncidencia(this.entIncidencia.Folio, entCorporacionIncidencia.ClaveCorporacion).Count > 0)
                            {

                                for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                                {

                                    this.cklCorporacion.SetItemChecked(i, false);

                                }

                                for (int j = 0; j < lstCorporacionIncidencia.Count; j++)
                                {
                                    Corporacion entCorporacion = CorporacionMapper.Instance().GetOne(lstCorporacionIncidencia[j].ClaveCorporacion);

                                    for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                                    {
                                        if (this.cklCorporacion.Items[i].ToString() == entCorporacion.Descripcion)
                                        {
                                            this.cklCorporacion.SetItemChecked(i, true);
                                        }
                                    }
                                }

                                throw new SAIExcepcion("No es posible modificar la información de las corporaciones asociadas, la incidencia ya está siendo despachada", this);



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

                    IncidenciaMapper.Instance().Save(this.entIncidencia);

                    CorporacionIncidenciaMapper.Instance().DeleteByIncidencia(this.entIncidencia.Folio);

                    myEnumerator = this.cklCorporacion.CheckedIndices.GetEnumerator();
                    int y;
                    while (myEnumerator.MoveNext() != false)
                    {
                        y = (int)myEnumerator.Current;
                        foreach (Corporacion objCorporacion in ListaCorporaciones)
                        {
                            if (this.cklCorporacion.Items[y].ToString() == objCorporacion.Descripcion)
                            {
                                blnTieneDatos = true;
                                CorporacionIncidenciaMapper.Instance().Insert(new CorporacionIncidencia(this.entIncidencia.Folio, objCorporacion.Clave));
                            }
                        }
                    }

                    if (blnTieneDatos)
                    {
                        this.entIncidencia.ClaveEstatus = 2;
                        IncidenciaMapper.Instance().Save(this.entIncidencia);

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
        /// Actualiza la información de la incidencia.
        /// </summary>
        private void ActualizaIncidencia()
        {

             try
            {
                

                    //Checamos si no son bromas o insultos.
                    if (cmbTipoIncidencia.SelectedItem != null && (
                       (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 254
                        ||
                        (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 256
                        ))
                    {
                        txtDireccion.Text = "SIN REGISTRO";
                        //Se cambia a incidencia cancelada
                        entIncidencia.ClaveEstatus = 5;
                    }

                    //Checamos si existen Vehiculos con accesorios robados.
                    if (ListaVehiculosInvolucrados != null && ListaAccesoriosRobados != null && (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave==130)
                    {
                        try
                        {
                            foreach (VehiculoObject vehiculo in this.ListaVehiculosInvolucrados)
                            {
                                VehiculoMapper.Instance().Save(vehiculo);
                            }
                            foreach (RoboVehiculoAccesorios accesorio in this.ListaAccesoriosRobados)
                            {
                                RoboVehiculoAccesoriosMapper.Instance().Insert(accesorio);
                            }

                        }
                        catch { }
                    }
                    //Checamos si existen Vehiculos robados.
                    if (this.ListaVehiculosRobados != null && this.objPropietarioVehiculo != null && (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 131)
                    {
                        //Guardamos el propietarios
                        PropietarioVehiculoMapper.Instance().Insert(objPropietarioVehiculo);
                        //Guardamos los vehiculos.
                        foreach(VehiculoObject vehiculo in this.ListaVehiculosRobados)
                        {
                            VehiculoMapper.Instance().Insert(vehiculo);
                        }
                        //Insertamos en la tabla de relación los vehiculos robados
                        foreach (VehiculoObject vehiculo in this.ListaVehiculosRobados)
                        {
                            VehiculoRobadoMapper.Instance().Insert(new VehiculoRobadoObject() 
                            {
                                 ClavePropietario=objPropietarioVehiculo.Clave,
                                 ClaveVehiculo=vehiculo.Clave,
                                 Folio=this.entIncidencia.Folio
                                 
                            });
                        }
                    }

                    //Checamos si existen personas extraviadas
                    if (this.ListaPersonasExtraviadas != null && this.ListaPersonasExtraviadas.Count > 0 && ((cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 103 | (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 235))
                    {
                        foreach(PersonaExtraviada persona in this.ListaPersonasExtraviadas)
                        {
                            persona.Folio = this.entIncidencia.Folio;
                            PersonaExtraviadaMapper.Instance().Insert(persona);
                        }

                    }

                    IncidenciaMapper.Instance().Save(entIncidencia);
                
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            }
        
        }

        /// <summary>
        /// Lee los datos del formulario y escribe la información en el objeto de incidencia
        /// </summary>
        protected void RecuperaDatosEnIncidencia()
        {
            if (entIncidencia != null)
            {
                //Obtenemos el municipio
                if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
                { entIncidencia.ClaveMunicipio = null;}
                else
                { entIncidencia.ClaveMunicipio = _objUbicacion.IdMunicipio; }

                //Obtenemos la localidad.
                if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
                {entIncidencia.ClaveLocalidad = null;}
                else
                { entIncidencia.ClaveLocalidad = _objUbicacion.IdLocalidad;}

                //Obtenemos la colonia.
                if (cmbColonia.SelectedIndex == -1 || cmbColonia.Text.Trim() == string.Empty)
                {entIncidencia.ClaveColonia = null;}
                else
                {entIncidencia.ClaveColonia = _objUbicacion.IdColonia;}

                //Obtenemos el código postal.
                if (cmbCP.SelectedIndex == -1 || cmbCP.Text.Trim() == string.Empty)
                {entIncidencia.ClaveCodigoPostal = null;}
                else
                {entIncidencia.ClaveCodigoPostal = _objUbicacion.IdCodigoPostal;}

                //Obtenemos el tipo de incidencia.
                if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
                {entIncidencia.ClaveTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave;}
                else
                {entIncidencia.ClaveTipo = null;}

                //Obtenemos el número de teléfono,descripción y la dirección.
                entIncidencia.Telefono = txtTelefono.Text;
                entIncidencia.Descripcion = txtDescripcion.Text;
                entIncidencia.Direccion = txtDireccion.Text;


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
            }
            catch
            {
            }
        }
        
        /// <summary>
        /// Llena la lista de municipios
        /// </summary>
        private void CargarMunicipios()
        {
            try
            { 
                var lstMunicipios = MunicipioMapper.Instance().GetAll();
                cmbMunicipio.DataSource = lstMunicipios;
                cmbMunicipio.DisplayMember = "Nombre";
                cmbMunicipio.ValueMember = "Clave";

                cmbMunicipio.SelectedIndex = -1;

            }
            catch
            {
            }
            
        }

        /// <summary>
        /// Llena la lista de tipos de incidencia por tipo de sistema.
        /// </summary>
        private void CargarTiposIncidencias()
        {
            TipoIncidenciaList lstTipoIncidencias;
            if(Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
            {
                lstTipoIncidencias=TipoIncidenciaMapper.Instance().GetBySistema(2);
            }
            else
            {
                lstTipoIncidencias=TipoIncidenciaMapper.Instance().GetBySistema(1);
            }

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
        /// <param name="objListaLocalidades">Lista de localidades que se mostrarán en el control</param>
        private void ActualizaLocalidades(LocalidadList objListaLocalidades)
        {
            cmbLocalidad.DataSource = objListaLocalidades;
            cmbLocalidad.DisplayMember = "Nombre";
            cmbLocalidad.ValueMember = "Clave";
            cmbLocalidad.SelectedIndex = -1;
            cmbLocalidad.Text = string.Empty;

        }

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
                    ActualizaMapaUbicacion();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Obtiene el código postal de una colonia especificada.
        /// </summary>
        /// <param name="idCp">int, Id del código postal</param>
        private void CargarCpPorColonia(int idCp)
        {
            
               entCodigoPostal = CodigoPostalMapper.Instance().GetOne(idCp);
                if(entCodigoPostal!=null)
                {
                    objListaCodigosPostales.Clear();
                    this.objListaCodigosPostales.Add(entCodigoPostal);
                    this.ActualizarCodigoPostal(objListaCodigosPostales);
                } 
 
        }

        private void ActualizarCodigoPostal(CodigoPostalList objListaCodigosPostales)
        {
            cmbCP.DataSource = objListaCodigosPostales;
            cmbCP.DisplayMember = "Valor";
            cmbCP.ValueMember = "Clave";
            cmbCP.SelectedIndex =0;
            
        }

        /// <summary>
        /// Selecciona el elemento del combo de codigos postales
        /// </summary>
        /// <param name="objElemento">Elemento que se va a seleccionar</param>
        private void SeleccionaCodigoPostal(Object objElemento)
        {
            cmbCP.SelectedIndex = -1;
            cmbCP.SelectedItem = objElemento;

        }

        /// <summary>
        /// Actualiza el mapa con los datos de la ubicación del formulario actuales
        /// </summary>
        private void ActualizaMapaUbicacion()
        {

            if (cmbMunicipio.SelectedIndex == -1 || cmbMunicipio.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdMunicipio = null;
            }
            else
            {
                _objUbicacion.IdMunicipio = int.Parse((cmbMunicipio.SelectedItem as Municipio).Clave.ToString());

            }

            if (cmbLocalidad.SelectedIndex == -1 || cmbLocalidad.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdLocalidad = null;
            }
            else
            {
                _objUbicacion.IdLocalidad = (cmbLocalidad.SelectedItem as Localidad).Clave;
            }

            if (cmbColonia.SelectedIndex == -1 || cmbColonia.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdColonia = null;
            }
            else
            {
                _objUbicacion.IdColonia = (cmbColonia.SelectedItem as Colonia).Clave;

            }

            if (cmbCP.SelectedIndex == -1 || cmbCP.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdCodigoPostal = null;
            }
            else
            {
                _objUbicacion.IdCodigoPostal = (cmbCP.SelectedItem as CodigoPostal).Clave;

            }


            Mapa.Controlador.MuestraMapa(_objUbicacion);
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
            cmbColonia.Text = string.Empty;


        }

        /// <summary>
        /// Limpia el texto del combo de códigos postales
        /// </summary>
        private void LimpiaTextoCodigoPostal()
        {
            cmbCP.Text = string.Empty;
        }

        
        /// <summary>
        /// BUsca el municipio,localidad al que pertenece un código postal especificado.
        /// </summary>
        /// <param name="codigoPostal">string,Codigo postal</param>
        private void CargarCascadaPorCp(string codigoPostal)
        {
            if (codigoPostal.Trim().Length == 5)
            {
                ColoniaList lstColonias;
                CodigoPostalList lstCodigoPostal;
                Colonia objColonia;
                Municipio objMunicipio;
                Localidad objLocalidad;

                try
                {
                    //Buscamos el código postal.
                    lstCodigoPostal = CodigoPostalMapper.Instance().GetBySQLQuery("Select Clave, Valor from CodigoPostal where Valor = '" + cmbCP.Text + "'");

                    //Obtenemos una colonia con ese código postal.
                    if (lstCodigoPostal != null && lstCodigoPostal.Count > 0)
                    {
                        //Obtenemos la lista de colonias con ese código postal.
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
                            //Actualizamos el mapa
                            this.ActualizaMapaUbicacion();

                        }


                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
        }

        /// <summary>
        /// Limpia el control que contiene la lista de localidades
        /// </summary>
        private void LimpiaLocalidades()
        {
            cmbLocalidad.DataSource = null;
            //cmbLocalidad.Items.Clear();
        }

        /// <summary>
        /// Limpia el combo que contiene la lista de colonias
        /// </summary>
        private void LimpiaColonias()
        {
            cmbColonia.DataSource = null;
            //cmbColonia.Items.Clear();
        }


        /// <summary>
        /// Limpia el combo que contiene los códigos postales
        /// </summary>
        private void LimpiaCodigosPostales()
        {
            cmbCP.DataSource = null;
        }

        /// <summary>
        /// Limpia el texto del control del combo de colonias
        /// </summary>
        private void LimpiaTextoColonia()
        {
            cmbColonia.SelectedIndex = -1;
            cmbColonia.Text = string.Empty;
        }

        private CorporacionList ObtenerCorporaciones()
        {

            return CorporacionMapper.Instance().GetBySQLQuery("SELECT [Clave],[Descripcion],[ClaveSistema],[UnidadesVirtuales],[Activo],[Zn] FROM [dbo].[Corporacion] Where Activo = 1");
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }


           
            
 
        }

        /// <summary>
        /// Obtiene la información del titular de la linea.
        /// </summary>
        /// <param name="noTelefono">string, Número telefónico</param>
        public void ObtenerTitularLinea(string noTelefono)
        {
            if (!string.IsNullOrEmpty(noTelefono))
            {
                TelefonoTelmex DatosTitular = Mappers.TelefonoTelmexMapper.Instance()
                .GetOneBySQLQuery(string.Format(ID.SQL_OBTENERINFOTITULARLINEA, noTelefono));

                this.txtTelefono.Text = noTelefono;
                this.txtNombreDenunciante.Text = DatosTitular.Nombre;
                this.txtApellidosDenunciante.Text = string.Format("{0} {1}", DatosTitular.ApellidoPaterno, DatosTitular.ApellidoMaterno);
                this.txtDireccionDenunciante.Text = DatosTitular.Direccion;
                CodigoPostal CodigoTitular = Mappers.CodigoPostalMapper.Instance().GetOneBySQLQuery(string.Format(ID.SQL_OBTENERCODIGOPOSTAL, DatosTitular.ClaveCodigoPostal));
                this.cmbCP.Text = CodigoTitular.Valor;
            }

        }

        
        #endregion

        #region MANEJADORES DE EVENTOS

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Buscamos las localidades del municipio seleccionado.
            if (this.cmbMunicipio.SelectedItem != null)
            {
                this.CargarLocalidadesPorMunicipio((cmbMunicipio.SelectedItem as Municipio).Clave);
            }
            else
            {
                this.LimpiaLocalidades();
            }
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Buscamos las colonias de la localidad seleccionada.
            if (this.cmbLocalidad.SelectedItem != null)
            {
                this.CargarColoniasPorLocalidad((cmbLocalidad.SelectedItem as Localidad).Clave);
            }
            else
            {
                this.LimpiaColonias();
            }
        }

        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbColonia.SelectedItem != null)
            {
                this.CargarCpPorColonia((this.cmbColonia.SelectedItem as Colonia).ClaveCodigoPostal.Value);
            }
            else
            {
                this.LimpiaCodigosPostales(); 
                this.LimpiaTextoCodigoPostal();
            }
        }

        private void cmbCP_TextChanged(object sender, EventArgs e)
        {
            this.CargarCascadaPorCp(this.cmbCP.Text);
        }

        private void cmbTipoIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpiamos las listas que reciben datos de ventanas hijas
            this.objPropietarioVehiculo = null;
            this.ListaAccesoriosRobados = null;
            this.ListaPersonasExtraviadas = null;
            this.ListaVehiculosInvolucrados = null;
            this.ListaVehiculosRobados = null;

            cmbMunicipio.Enabled = true;
            cmbLocalidad.Enabled = true;
            cmbColonia.Enabled = true;
            cmbCP.Enabled = true;
            this.gbDenunciante.Enabled = true;

            try
            {
                try
                {
                   
                    if (cmbTipoIncidencia.SelectedIndex != -1 && cmbTipoIncidencia.Text.Trim() != string.Empty)
                    {
                        TipoIncidencia objTipo = (cmbTipoIncidencia.SelectedItem as TipoIncidencia);

                            switch (objTipo.Clave)
                            {
                                //Robo de vehículo totalidad.
                                case 131:
                                        SAIFrmAltaDatosAuto066 PantallaInfoAuto = new SAIFrmAltaDatosAuto066();
                                        //Pasamos el propietario y la lista de vehiculos robados.
                                        PantallaInfoAuto.Propietario = objPropietarioVehiculo;
                                        
                                        PantallaInfoAuto.ListaVehiculos = this.ListaVehiculosRobados;
                                        PantallaInfoAuto.ShowDialog(this);
                                        //Obtenemos los datos capturados sobre vehiculos robados
                                        this.objPropietarioVehiculo = PantallaInfoAuto.Propietario;
                                        this.ListaVehiculosRobados = PantallaInfoAuto.ListaVehiculos;
                                    break;

                                //Robo de vehiculos accesorios.
                                case 130:
                                    SAIFrmAltaAccesoriosAuto066 PantallaInfoAccesorios = new SAIFrmAltaAccesoriosAuto066();
                                    PantallaInfoAccesorios.ListaAccesoriosRobados = this.ListaAccesoriosRobados;
                                    PantallaInfoAccesorios.ListaVehiculosInvolucrados = this.ListaVehiculosInvolucrados;
                                    PantallaInfoAccesorios.DatosRoboAccesorio = this.DatosRoboAccesorios;
                                    PantallaInfoAccesorios.ShowDialog(this);
                                    this.ListaAccesoriosRobados = PantallaInfoAccesorios.ListaAccesoriosRobados;
                                    this.ListaVehiculosInvolucrados = PantallaInfoAccesorios.ListaVehiculosInvolucrados;
                                    this.DatosRoboAccesorios = PantallaInfoAccesorios.DatosRoboAccesorio;
                                    break;

                                //Extravio de persona.
                                case 103:
                                case 235:
                                    SAIFrmAltaDatosPersonaExtraviada PantallaPersonaExtraviada=new SAIFrmAltaDatosPersonaExtraviada();
                                    //Pasamos la lista de personas
                                    PantallaPersonaExtraviada.ListaPersonas = this.ListaPersonasExtraviadas;
                                    PantallaPersonaExtraviada.ShowDialog(this);
                                    //Obtenemos las personas capturadas.
                                    this.ListaPersonasExtraviadas = PantallaPersonaExtraviada.ListaPersonas;
                                    break;

                                //Foránea
                                case 259:

                                    cmbMunicipio.Enabled = false;
                                    cmbLocalidad.Enabled = false;
                                    cmbColonia.Enabled = false;
                                    cmbCP.Enabled = false;

                                    break;

                                //Anónima.
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
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
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

                    if (cmbTipoIncidencia.Enabled)
                    {
                        //Checamos si es Broma o Insulto.
                        if (cmbTipoIncidencia.SelectedItem != null && (
                           (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 254
                            ||
                            (cmbTipoIncidencia.SelectedItem as TipoIncidencia).Clave == 256
                            )
                            && txtTelefono.Text.Trim() == string.Empty
                            )
                        {
                            e.Cancel = true;
                            throw new SAIExcepcion("Debe de indicar el número de teléfono de la incidencia", this);
                        }
                        else
                        {
                            this.RecuperaDatosEnIncidencia();
                            this.ActualizaIncidencia();
                            
                        }
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


        #region EVENTOS GENÉRICOS

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No permite introducir texto
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            //Para pasar el foco al control siguiente.
            switch (e.KeyData)
            {
                case Keys.Enter:

                    Control controlActual = (Control)sender;
                    this.FindForm().SelectNextControl(controlActual, true, false, true, true);

                    break;
            }
        }


        #endregion

        


        private void cklCorporacion_Leave(object sender, EventArgs e)
        {
            try
            {
                this.GuardaCorporaciones();
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            }
        }


        #endregion

    }
}
