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
                    this.cbxColonia.DisplayMember = "Clave";
                    this.cbxColonia.ValueMember = "Nombre";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();
            SAIFrmDependencias089 frmDependencias = new SAIFrmDependencias089(this._Incidencia089.Folio);
            frmDependencias.ShowDialog();
        }
        /// <summary>
        /// Llena los controles con los datos de una incidencia
        /// </summary>
        private void LlenarDatosIncidencia()
        { }

        /// <summary>
        /// Se ejecuta cuando se selecciona un municipio
        /// </summary>
        private void cbxMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarLocalidadesPorMunicipio(((Entidades.Municipio)this.cbxMunicipio.SelectedItem).Clave);
            this.cbxLocalidad.Focus();
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

        private void cbxColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SeleccionaCP(((Entidades.Colonia)this.cbxColonia.SelectedItem).ClaveCodigoPostal.Value);
            this.cbxCP.Focus();
        }

        private void SeleccionaCP(int cpSelect)
        {
            foreach (Entidades.CodigoPostal cpItem in this.cbxCP.Items)
            {
                if (cpItem.Clave == cpSelect)
                    this.cbxCP.SelectedItem = cpItem;
            }
        }

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

        private void cbxCP_TextUpdate(object sender, EventArgs e)
        {

        }

        private void txtReferencias_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReferencias_Leave(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            this.ActualizarIncidencia();
        }

        private void cbxTipoDenuncia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoDenuncia.SelectedItem != null && (
                           (cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).ClaveOperacion.Trim() == "133"
                            ||
                            (cbxTipoDenuncia.SelectedItem as Entidades.TipoIncidencia).ClaveOperacion.Trim() == "5047"
                            ))
            {
                txtDireccion.Text = "SIN REGISTRO";
                //Se cambia a incidencia cancelada
                this._Incidencia089.ClaveEstatus = 5;
            }
        }

        private void cbxTipoDenuncia_Leave(object sender, EventArgs e)
        {
            //this.ActualizarIncidencia();
        }

        private void chkFechaDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkFechaDoc.Checked)
            {
                this.dtpFechaDoc.Enabled = true;
            }
            else 
            {
                this.dtpFechaDoc.Enabled = false;
            }
        }

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

        private void SAIFrm089_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ActualizarIncidencia();
        }




    }
}
