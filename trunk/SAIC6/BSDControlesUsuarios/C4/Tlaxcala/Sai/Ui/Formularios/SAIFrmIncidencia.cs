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

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{

    /// <summary>
    /// El formulario SIAFrmIncidencia contiene la funcionalidad básica que comparten las incidencias
    /// del sistema 089 y 066, por lo tanto éste no es implementado directamente en la aplicación, sino que hereda
    /// hacia el formulario SIAFrmIncidencia089 y SIAFrmIncidencia066
    /// </summary>
    public partial class SAIFrmIncidencia : SAIFrmBase
    {

        Incidencia _entIncidencia = new Incidencia();
        TipoIncidenciaList _lstTipoIncidencias;
        MunicipioList _lstMunicipios;
        LocalidadList _lstLocalidades;
        ColoniaList _lstaColonias;
        CodigoPostalObjectList _lstCodigosPostales;

        /// <summary>
        /// Constructor del formulario SIAFrmIncidencia, se ejecuta cuando se registra una incidencia nueva
        /// <remarks>El constructor inserta una nueva incidencia en la base de datos y muestra su información en el formulario</remarks>
        /// </summary>
        public SAIFrmIncidencia()
        {
            try
            {
                InitializeComponent();
                this.InicializaListas();
                //****Crea una nueva incidencia, el formulario se abrió para insertar*******
                this._entIncidencia.Descripcion = string.Empty;
                this._entIncidencia.Referencias = string.Empty;
                this._entIncidencia.HoraRecepcion = DateTime.Now;
                this._entIncidencia.ClaveEstatus = 1;
                this._entIncidencia.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;
                IncidenciaMapper.Instance().Insert(this._entIncidencia);
                //*************************************************************************
                //Se actualiza la información de la incidencia en la lista de ventanas
                this.ActualizaVentanaIncidencias();
                //Se muestra la información de la incidencia en el formulario:
                this.InicializaCampos();
                
            }
            catch (Exception ex)
            {
                throw new SAIExcepcion("Se produjo un error al inicializar la ventana de incidencias: " + ex.Message + " Trace: " + ex.StackTrace );
            }
        }

        /// <summary>
        /// Constructor que toma la entidad incidencia que se va a mostrar en el formulario
        /// </summary>
        /// <param name="entIncidencia">Entidad incidencia que contiene los valores para mostrar</param>
        public SAIFrmIncidencia(Incidencia  entIncidencia)
        {
            try
            {

                InitializeComponent();
                this.InicializaListas();
                this._entIncidencia = entIncidencia;
                //Se actualiza la información de la incidencia en la lista de ventanas
                this.ActualizaVentanaIncidencias();
                //Se muestra la información de la incidencia en el formulario:
                this.InicializaCampos();
            
            }
            catch (Exception ex)
            {
                throw new SAIExcepcion("Se produjo un error al inicializar la ventana de incidencias: " + ex.Message + " Trace: " + ex.StackTrace);
            }

        }

        private void SAIFrmIncidencia_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Recupera la información de los catálogos que se utilizan en el formulario
        /// </summary>
        private void InicializaListas()
        {

            try
            {

                this._lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetAll();
                this._lstMunicipios  = MunicipioMapper.Instance().GetAll();
                this._lstLocalidades = LocalidadMapper.Instance().GetAll();
                this._lstaColonias = ColoniaMapper.Instance().GetAll();
                this._lstCodigosPostales = CodigoPostalMapper.Instance().GetAll();

                this.cmbTipoIncidencia.DataSource = this._lstTipoIncidencias;
                this.cmbTipoIncidencia.DisplayMember = "Descripcion";
                this.cmbTipoIncidencia.ValueMember = "Clave";

                this.cmbMunicipio.DataSource = this._lstMunicipios;
                this.cmbMunicipio.DisplayMember = "Nombre";
                this.cmbMunicipio.ValueMember = "Clave";

                this.cmbLocalidad.DataSource = this._lstLocalidades;
                this.cmbLocalidad.DisplayMember = "Nombre";
                this.cmbLocalidad.ValueMember = "Clave";

                this.cmbColonia.DataSource = this._lstaColonias;
                this.cmbColonia.DisplayMember = "Nombre";
                this.cmbColonia.ValueMember = "Clave";

                this.cmbCP.DataSource = this._lstCodigosPostales;
                this.cmbCP.DisplayMember = "Valor";
                this.cmbCP.ValueMember = "Clave";

            }
             catch (Exception ex)
             {
                 throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
             }
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
                entUsuario = UsuarioMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intClaveUsuario);

                this.lblOperador.Text  = entUsuario.NombrePropio;
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
                throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            }
        }


        /// <summary>
        /// Actualiza la información en la colección global de ventanas de la incidencia actual
        /// </summary>
        /// <param name="entIncidencia">Entidad incidencia que contiene la información</param>
        private void ActualizaVentanaIncidencias()
        {
            try
            {
                for (int i = 0; i < Aplicacion.VentanasIncidencias.Count; i++ )
                    {
                        if (Aplicacion.VentanasIncidencias[i].Ventana  == this)
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
            catch (Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Recupera las localidades del municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Municipio entMunicipio;
            LocalidadList objListaLocalidades;

            try
            {

                if (this.cmbMunicipio.SelectedIndex == -1)
                {
                    this.cmbLocalidad.DataSource = null;
                    this.cmbLocalidad.Items.Clear();
                    return;
                }

                entMunicipio = (Municipio)this.cmbMunicipio.SelectedItem;
                objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio(entMunicipio.Clave, entMunicipio.ClaveEstado);

                if (objListaLocalidades.Count > 0)
                {
                    this.cmbLocalidad.DataSource = objListaLocalidades;
                    this.cmbLocalidad.DisplayMember = "Nombre";
                    this.cmbLocalidad.ValueMember = "Clave";
                }
                else
                {
                    this.cmbLocalidad.DataSource = null;
                    this.cmbLocalidad.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Guarda la incidencia con el municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_Leave(object sender, EventArgs e)
        {
            Municipio entMunicipio;

            try
            {
                if (this.cmbMunicipio.SelectedIndex == -1)
                {
                    this._entIncidencia.ClaveMunicipio = null;

                    //this.cmbLocalidad.DataSource = null;
                    //this.cmbLocalidad.Items.Clear();
                    //this.cmbColonia.DataSource = null;
                    //this.cmbColonia.Items.Clear();
                    //this._entIncidencia.ClaveColonia = null;

                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
                else
                {
                    entMunicipio = (Municipio)this.cmbMunicipio.SelectedItem;
                    this._entIncidencia.ClaveMunicipio = entMunicipio.Clave;

                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
            }
            catch (Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            }
        }


        /// <summary>
        /// Recupera las colonias de la localidad seleccionada
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Localidad entLocalidad;
            ColoniaList lstColonias;

            try
            {
                if (this.cmbLocalidad.SelectedIndex == -1)
                {
                    this.cmbLocalidad.DataSource = null;
                    this.cmbLocalidad.Items.Clear();
                    return;
                }
                entLocalidad = (Localidad)this.cmbLocalidad.SelectedItem;
                lstColonias = ColoniaMapper.Instance().GetByLocalidad(entLocalidad.Clave, entLocalidad.ClaveEstado, entLocalidad.ClaveMunicipio);

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
            catch (Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Guarda la incidencia con la localidad seleccionada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbLocalidad_Leave(object sender, EventArgs e)
        {
            Localidad entLocalidad;
            try
            {
                if (this.cmbLocalidad.SelectedIndex == -1)
                {
                 
                    this._entIncidencia.ClaveLocalidad = null;
                    IncidenciaMapper.Instance().Save(this._entIncidencia);

                }
                else
                {
                    entLocalidad = (Localidad)this.cmbLocalidad.SelectedItem;
                    this._entIncidencia.ClaveLocalidad = entLocalidad.Clave;

                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
            }
            catch (Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            }
        }

       
        /// <summary>
        /// Guarda la incidencia con la colonia seleccionada y guarda la colonia en caso de ser una colonia nueva
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbColonia_Leave(object sender, EventArgs e)
        {
            //Colonia entColonia;

            //try
            //{
            //    if (this.cmbColonia.SelectedIndex == -1 && )
            //    {

            //        this._entIncidencia.ClaveColonia = null;
            //        IncidenciaMapper.Instance().Save(this._entIncidencia);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new SAIExcepcion(ex.Message + " Trace: " + ex.StackTrace);
            //}

        }


       
    }
}
