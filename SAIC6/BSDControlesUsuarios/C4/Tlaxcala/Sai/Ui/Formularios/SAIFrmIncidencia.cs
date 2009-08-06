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

        Incidencia _entIncidencia = new Incidencia();
        public event txtDescripcionOnKeyEnterUp txtDescripcion_OnKeyEnterUp;
        private Boolean _blnLimpiarColonias = false;

        /// <summary>
        /// Constructor del formulario SIAFrmIncidencia, se ejecuta cuando se registra una incidencia nueva
        /// <remarks>El constructor inserta una nueva incidencia en la base de datos y muestra su información en el formulario</remarks>
        /// </summary>
        public SAIFrmIncidencia()
        {
          
                InitializeComponent();
               
                try
                {
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
                catch { }
        }

        /// <summary>
        /// Constructor que toma la entidad incidencia que se va a mostrar en el formulario
        /// </summary>
        /// <param name="entIncidencia">Entidad incidencia que contiene los valores para mostrar</param>
        public SAIFrmIncidencia(Incidencia  entIncidencia)
        {
           

                InitializeComponent();
                this.InicializaListas();
                this._entIncidencia = entIncidencia;
                //Se actualiza la información de la incidencia en la lista de ventanas
                this.ActualizaVentanaIncidencias();
                //Se muestra la información de la incidencia en el formulario:
                this.InicializaCampos();
            
            

        }

        /// <summary>
        /// Recupera la información de los catálogos que se utilizan en el formulario
        /// </summary>
        private void InicializaListas()
        {

            TipoIncidenciaList lstTipoIncidencias;
            MunicipioList lstMunicipios;



           
                lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetAll();
                lstMunicipios = MunicipioMapper.Instance().GetAll();

                this.cmbTipoIncidencia.DataSource = lstTipoIncidencias;
                this.cmbTipoIncidencia.DisplayMember = "Descripcion";
                this.cmbTipoIncidencia.ValueMember = "Clave";

                this.cmbMunicipio.DataSource = lstMunicipios;
                this.cmbMunicipio.DisplayMember = "Nombre";
                this.cmbMunicipio.ValueMember = "Clave";

                this.cmbMunicipio.SelectedIndex = -1;
                this.cmbMunicipio.Text = string.Empty;

         

          
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

        /// <summary>
        /// Recupera las localidades y los códigos postales del municipio seleccionado
        /// </summary>
        /// <param name="sender">Objeto que causó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Municipio entMunicipio;
            LocalidadList objListaLocalidades;
            ColoniaList objListaColonias;
            CodigoPostalList objListaCodigosPostales = new CodigoPostalList();
            CodigoPostal entCodigoPostal;
            Boolean blnExisteCodigoPostal;

            try
            {

                if (this.cmbMunicipio.SelectedIndex == -1)
                {
                    this.cmbLocalidad.DataSource = null;
                    this.cmbLocalidad.Items.Clear();
                    this.cmbColonia.DataSource = null;
                    this.cmbColonia.Items.Clear();
                    this.cmbCP.DataSource = null;
                    this.cmbCP.Items.Clear();

                    return;
                }

                entMunicipio = (Municipio)this.cmbMunicipio.SelectedItem;
                objListaLocalidades = LocalidadMapper.Instance().GetByMunicipio(entMunicipio.Clave);

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
                else
                {
                    this.cmbLocalidad.DataSource = null;
                    this.cmbLocalidad.Items.Clear();
                    this.cmbColonia.DataSource = null;
                    this.cmbColonia.Items.Clear();
                    this.cmbCP.DataSource = null;
                    this.cmbCP.Items.Clear();
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

                if (this.cmbMunicipio.SelectedIndex == -1)
                {
                    this._entIncidencia.ClaveMunicipio = null;
                    this.cmbLocalidad.DataSource = null;
                    this.cmbLocalidad.Items.Clear();
                    this.cmbColonia.DataSource = null;
                    this.cmbColonia.Items.Clear();
                    this._entIncidencia.ClaveColonia = null;
                    this._entIncidencia.ClaveCodigoPostal = null;

                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
                else
                {
                    entMunicipio = (Municipio)this.cmbMunicipio.SelectedItem;
                    this._entIncidencia.ClaveMunicipio = entMunicipio.Clave;
                    

                    IncidenciaMapper.Instance().Save(this._entIncidencia);
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

         
                if (this.cmbLocalidad.SelectedIndex == -1)
                {
                   
                    this.cmbColonia.DataSource = null;
                    this.cmbColonia.Items.Clear();
                    return;
                }
                entLocalidad = (Localidad)this.cmbLocalidad.SelectedItem;
                lstColonias = ColoniaMapper.Instance().GetByLocalidad(entLocalidad.Clave);

                if (lstColonias.Count > 0)
                {
                    this.cmbColonia.DataSource = lstColonias;
                    this.cmbColonia.DisplayMember = "Nombre";
                    this.cmbColonia.ValueMember = "Clave";
                    this.cmbColonia.Text = String.Empty;
                    this.cmbCP.Text = string.Empty;
                }
                else
                {
                    this.cmbColonia.DataSource = null;
                    this.cmbColonia.Items.Clear();
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
            
                if (this.cmbLocalidad.SelectedIndex == -1)
                {
                 
                    this._entIncidencia.ClaveLocalidad = null;
                    this.cmbColonia.DataSource = null;
                    this.cmbColonia.Items.Clear();
                    this._entIncidencia.ClaveColonia = null;
                    this._entIncidencia.ClaveCodigoPostal = null;
                    IncidenciaMapper.Instance().Save(this._entIncidencia);

                }
                else
                {
                    entLocalidad = (Localidad)this.cmbLocalidad.SelectedItem;
                    this._entIncidencia.ClaveLocalidad = entLocalidad.Clave;

                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
          
        }


        /// <summary>
        /// Selecciona el código postal del combo de códigos postales según la colonia seleccionada
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Colonia entColonia = null;

            if (this.cmbColonia.SelectedIndex != -1 && this.cmbColonia.Text.Trim() != string.Empty)
            {
                entColonia = (Colonia)this.cmbColonia.SelectedItem;

                if (entColonia.ClaveCodigoPostal.HasValue)
                {

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
            }
          
        }

        /// <summary>
        /// Quita la selección de la colonia
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._blnLimpiarColonias)
            {
                this.cmbColonia.SelectedIndex = -1;
                this.cmbColonia.Text = string.Empty;
            }
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

                            ColoniaMapper.Instance().Save(entColonia);

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
                            this._entIncidencia.ClaveColonia = null;
                            this.cmbColonia.Text = string.Empty;
                        }
                    }
                    else if (entColonia != null)
                    {
                        this._entIncidencia.ClaveColonia = entColonia.Clave;
                        if (entColonia.ClaveCodigoPostal.HasValue)
                        {
                            this._entIncidencia.ClaveCodigoPostal = entColonia.ClaveCodigoPostal.Value;

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


                    IncidenciaMapper.Instance().Save(this._entIncidencia);

                }
                else if (this.cmbColonia.Text.Trim() != string.Empty)
                {
                    entColonia = (Colonia)this.cmbColonia.SelectedItem;

                    this._entIncidencia.ClaveColonia = entColonia.Clave;
                    if (entColonia.ClaveCodigoPostal.HasValue)
                    {
                        this._entIncidencia.ClaveCodigoPostal = entColonia.ClaveCodigoPostal.Value;
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
                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
                else
                {
                    this._entIncidencia.ClaveColonia = null;
                    IncidenciaMapper.Instance().Save(this._entIncidencia);
                }
           
        }


        /// <summary>
        /// Guarda la incidencia con el código postal seleccionado
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void cmbCP_Leave(object sender, EventArgs e)
        {
            CodigoPostal entCodigoPostal = null;

            if (this.cmbCP.SelectedIndex != -1 && this.cmbCP.Text != string.Empty)
            {
                entCodigoPostal = (CodigoPostal)this.cmbCP.SelectedItem;
                if (entCodigoPostal != null)
                {
                    this._entIncidencia.ClaveCodigoPostal = entCodigoPostal.Clave;
                }
                else
                {
                    this._entIncidencia.ClaveCodigoPostal = null;
                }
            }
            else
            {
                this._entIncidencia.ClaveCodigoPostal = null;
            }

            IncidenciaMapper.Instance().Save(this._entIncidencia);
        }

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
        }


        /// <summary>
        /// Lanza el evento txtDescripcion_OnKeyEnterUp cuando se presona y suelta la tecla intro en el campo descripcion
        /// </summary>
        /// <param name="sender">Objeto que ocasionó el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtDescripcion_OnKeyEnterUp != null)
            {
                txtDescripcion_OnKeyEnterUp(this, e); 
            }
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
                return;
            }

            Mapa.Controlador.RevisaInstancias(this);
        }

        private void TomaDatosUbicacion(Mapa.EstructuraUbicacion objUbicacion)
        {
            if (this._entIncidencia != null)
            {
                if (this._entIncidencia.ClaveCodigoPostal.HasValue)
                {
                    objUbicacion.IdCodigoPostal = this._entIncidencia.ClaveCodigoPostal.Value;
                }
                else
                {
                    objUbicacion.IdCodigoPostal = null;
                }
                if (this._entIncidencia.ClaveColonia.HasValue)
                {
                    objUbicacion.IdColonia = this._entIncidencia.ClaveColonia.Value;
                }
                else
                {
                    objUbicacion.IdColonia = null;
                }
                if (this._entIncidencia.ClaveLocalidad.HasValue)
                {
                    objUbicacion.IdLocalidad = this._entIncidencia.ClaveLocalidad.Value;
                }
                else
                {
                    objUbicacion.IdLocalidad = null;
                }
                if (this._entIncidencia.ClaveMunicipio.HasValue)
                {
                    objUbicacion.IdMunicipio = this._entIncidencia.ClaveMunicipio.Value;
                }
                else
                {
                    objUbicacion.IdMunicipio = null;
                }

            }
        }

        protected override void OnLoad(EventArgs e)
        {
           Mapa.EstructuraUbicacion objUbicacion = new Mapa.EstructuraUbicacion();
           this.TomaDatosUbicacion(objUbicacion);
           Mapa.Controlador.MuestraMapa(objUbicacion, this);
           base.OnLoad(e);
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

      

       


       
    }
}
