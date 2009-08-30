using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Mapa;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
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

        public SAIFrm089()
        {
            InitializeComponent();
            this.InsertarIncidencia();
        }

        public SAIFrm089(Entidades.Incidencia entIncidencia)
        {
            InitializeComponent();
            _Incidencia089 = entIncidencia;
            this.LlenarDatosIncidencia();
        }

        private void SAIFrm089_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarTipoIncidencias();
            this.LlenarMunicipios();
            this.LlenarCodigosPostales();
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
                    Entidades.TipoIncidenciaList lstTipoIncidencia = Mappers.TipoIncidenciaMapper.Instance().GetBySistema(1);
                    foreach (Entidades.TipoIncidencia tIncidencia in lstTipoIncidencia)
                    {
                        tIncidencia.Descripcion = tIncidencia.ClaveOperacion + " " + tIncidencia.Descripcion;
                    }

                    this.cbxTipoDenuncia.DataSource = lstTipoIncidencia;
                    this.cbxTipoDenuncia.DisplayMember = "Descripcion";
                    this.cbxTipoDenuncia.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
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
                    this.cbxColonia.SelectedIndex = -1;
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Llena las Localidades por Municipio
        /// </summary>
        /// <param name="iMunicipio"></param>
        private void LlenarLocalidadesPorMunicipio(int iMunicipio)
        {
            try
            {
                try
                {
                    this.cbxLocalidad.DataSource = Mappers.LocalidadMapper.Instance().GetByMunicipio(iMunicipio);
                    this.cbxLocalidad.DisplayMember = "Nombre";
                    this.cbxLocalidad.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Llena Las localidades por colonia
        /// </summary>
        /// <param name="iColonia"></param>
        private void LlenarLocalidadesPorColonia(int iColonia)
        {
            try
            {
                try
                {
                    /*this.cbxLocalidad.DataSource = Mappers.LocalidadMapper.Instance().GetBySQLQuery("Select Clave, Nombre from Localidad where Colonia = '" + iColonia.ToString() + "'");
                    this.cbxLocalidad.DisplayMember = "Nombre";
                    this.cbxLocalidad.ValueMember = "Clave";*/
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Llena las Colonias Por Localidad
        /// </summary>
        /// <param name="iLocalidad"></param>
        private void LlenarColoniasPorLocalidad(int iLocalidad)
        {
            try 
            {
                try
                {
                    this.cbxColonia.DataSource = Mappers.ColoniaMapper.Instance().GetByLocalidad(iLocalidad);
                    this.cbxColonia.DisplayMember = "Nombre";
                    this.cbxColonia.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Llena las Colonias por Codigo Postal
        /// </summary>
        /// <param name="iCp"></param>
        private void LlenarColoniasPorCP(int iCp)
        {
            try
            {
                try
                {
                    this.cbxColonia.DataSource = Mappers.ColoniaMapper.Instance().GetByCodigoPostal(iCp);
                    this.cbxColonia.DisplayMember = "Nombre";
                    this.cbxColonia.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Llena los Codigos Postales por Localidad
        /// </summary>
        /// <param name="iLocalidad"></param>
        private void LlenarCodigosPostales()
        {
            try
            {
                try 
                {
                    this.cbxCP.DataSource = Mappers.CodigoPostalMapper.Instance().GetAll();
                    this.cbxCP.DisplayMember = "Valor";
                    this.cbxCP.ValueMember = "Clave";
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
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
                    _Incidencia089.ClaveEstado = 29;
                    _Incidencia089.ClaveUsuario = 2;// Aplicacion.UsuarioPersistencia.intClaveUsuario;

                    Mappers.IncidenciaMapper.Instance().Insert(_Incidencia089);
                }
                catch(Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
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
                catch(Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
 
        }

        /// <summary>
        /// Actualiza la dependencia Activa y muestra la ventana modal de Dependencias
        /// </summary>
        private void btnDependencias_Click(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();
            SAIFrmDependencias089 frmDependencias = new SAIFrmDependencias089(this._Incidencia089);
            frmDependencias.ShowDialog();
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
                    this.txtDireccion.Text = this._Incidencia089.Direccion;
                    this.txtReferencias.Text = this._Incidencia089.Referencias;
                    this.txtDescripcionDenuncia.Text = this._Incidencia089.Descripcion;
                    this.txtAliasDelincuente.Text = this._Incidencia089.AliasDelincuente;
                    this.txtOficioEnvio.Text = this._Incidencia089.NumeroOficio;
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
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Se ejecuta cuando se selecciona un municipio
        /// </summary>
        private void cbxMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LlenarLocalidadesPorMunicipio(((Entidades.Municipio)this.cbxMunicipio.SelectedItem).Clave);
            //this.cbxLocalidad.Focus();
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona una Localidad
        /// </summary>
        private void cbxLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LlenarColoniasPorLocalidad(((Entidades.Localidad)this.cbxLocalidad.SelectedItem).Clave);
            this.cbxColonia.Focus();
        }

        /// <summary>
        /// se ejecuta cuando se delecciona un Codigo Postal
        /// </summary>
        private void cbxCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.LlenarColoniasPorCP(((Entidades.CodigoPostal)this.cbxCP.SelectedItem).Clave);
            this.txtReferencias.Focus();
        }
        /// <summary>
        /// Se ejecuta cuando se selecciona una Colonia
        /// </summary>
        private void cbxColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SeleccionaCP(((Entidades.Colonia)this.cbxColonia.SelectedItem).ClaveCodigoPostal.Value);
            this.cbxCP.Focus();
        }

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
        /// <summary>
        /// Se ejecuta cuando se captura un Codigo Postal
        /// </summary>
        private void cbxCP_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                Entidades.CodigoPostalList lstCodigoPostal = Mappers.CodigoPostalMapper.Instance().GetBySQLQuery("Select Clave, Valor from CodigoPostal where Valor = '" + this.cbxCP.Text + "'");
                if (lstCodigoPostal.Count > 0)
                {
                    this.LlenarColoniasPorCP(lstCodigoPostal[0].Clave);                    
                }
            }
            catch(SAIExcepcion)
            {}
        }        
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
                           (cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).ClaveOperacion.Trim() == "133"
                            ||
                            (cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).ClaveOperacion.Trim() == "5047"
                            ))
            {
                txtDireccion.Text = "SIN REGISTRO";
                this._Incidencia089.ClaveEstatus = 5;
                this.ActualizarIncidencia();
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
                    this._Incidencia089.ClaveTipo = (this.cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).Clave;

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
            if (this.txtOficioEnvio.Text != string.Empty)
            {
                this._Incidencia089.ClaveEstatus = 2;
                this.ActualizarIncidencia();
            }
        }

        private void txtOficioEnvio_TextChanged(object sender, EventArgs e)
        {
            if (this.txtOficioEnvio.Text != string.Empty)
            {
                this.btnDependencias.Enabled = true;
            }
            else
            {
                this.btnDependencias.Enabled = false;
            }
        }

        private void actualizaMapaUbicacion()
        {

            if (cbxMunicipio.SelectedIndex == -1 || cbxMunicipio.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdMunicipio = null;
            }
            else
            {
                _objUbicacion.IdMunicipio = int.Parse((cbxMunicipio.SelectedItem as Entidades.Municipio).Clave.ToString());

            }

            if (cbxLocalidad.SelectedIndex == -1 || cbxLocalidad.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdLocalidad = null;
            }
            else
            {
                _objUbicacion.IdLocalidad = (cbxLocalidad.SelectedItem as Entidades.Localidad).Clave;
            }

            if (cbxColonia.SelectedIndex == -1 || cbxColonia.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdColonia = null;
            }
            else
            {
                _objUbicacion.IdColonia = (cbxColonia.SelectedItem as Entidades.Colonia).Clave;

            }

            if (cbxCP.SelectedIndex == -1 || cbxCP.Text.Trim() == string.Empty)
            {
                _objUbicacion.IdCodigoPostal = null;
            }
            else
            {
                _objUbicacion.IdCodigoPostal = (cbxCP.SelectedItem as Entidades.CodigoPostal).Clave;

            }

            //Mapa.Controlador.MuestraMapa(_objUbicacion);
        }




    }
}
