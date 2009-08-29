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

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAltaIncidencia066 : Form
    {



        #region CONSTRUCTOR

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="noTelefono">string, Número de teléfono</param>
        public SAIFrmAltaIncidencia066(string noTelefono)
        {
            InitializeComponent();

            _blnLlenarEnCascada = true;

            //Creamos la nueva incidencia.
            this.CrearNuevaIncidencia();
            //Inicializamos las listas
            this.CargarMunicipios();
            this.CargarTiposIncidencias();

        }

        #endregion

        #region VARIABLES

        /// <summary>
        /// Guarda la referencia a la entidad Incidencia que se maneja en el formulario
        /// </summary>
        protected Incidencia _entIncidencia = new Incidencia();

        /// <summary>
        /// Bandera que indica si se va a limpiar el combo de colonias, lo cual se hace sólo cuando cambia el código postal
        /// </summary>
        private Boolean _blnLimpiarColonias;

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
        private Boolean _blnLlenarEnCascada;

        /// <summary>
        /// Esta bandera lleva el estado para saber si el usuario quiso cerrar la ventana, esto para saber
        /// si se va a guardar la incidencia en los eventos Leave de los controles, si está en falso se guardan
        /// los datos en dichos eventos, de lo contrario no se guarda la incidencia en tales eventos.
        /// </summary>
        protected Boolean _blnSeActivoClosed;

        /// <summary>
        /// Guarda los datos del propietario del vehículo, cuando la incidencia es del tipo robo de vehículo
        /// </summary>
        protected PropietarioVehiculoObject _objPropietarioVehiculo;

        /// <summary>
        /// Guarda los datos de la entidad de accesorios del vehículo, cuando la incidencia es del tipo robo de accesorios de vehículo
        /// </summary>
        protected RoboVehiculoAccesorios _entRoboVehiculoAccesorios;

        /// <summary>
        /// Guarda los datos de la entidad vehículo, cuando la incidencia es del tipo de robo de accesorios de vehículo
        /// </summary>
        protected VehiculoObject _objVeiculoAccesoriosRobado;

        /// <summary>
        /// Lleva el estado del caso de la tecla control presionada.
        /// </summary>
        protected bool _blnCtrPresionado;

        /// <summary>
        /// Guarda el valor de solo lectura del formulario
        /// </summary>
        private Boolean _blnSoloLectura;


        protected GroupBox _grpDenunciante;

        #endregion

        #region PROPIEDADES

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Crea una nueva incidencia y muestra sus datos al abrir el formilario.
        /// </summary>
        private void CrearNuevaIncidencia()
        {
            try
            { 
                _entIncidencia.Referencias = string.Empty;
                _entIncidencia.Descripcion = string.Empty;
                _entIncidencia.Activo = true;
                _entIncidencia.HoraRecepcion = DateTime.Now;
                _entIncidencia.ClaveEstatus = 1;
                _entIncidencia.ClaveEstado = 29;
                _entIncidencia.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;
                IncidenciaMapper.Instance().Insert(_entIncidencia);
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

        #endregion

        #region MANEJADORES DE EVENTOS

        #endregion


        
    }
}
