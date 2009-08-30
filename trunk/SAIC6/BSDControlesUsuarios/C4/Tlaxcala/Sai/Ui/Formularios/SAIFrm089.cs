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

        public SAIFrm089()
        {
            InitializeComponent();
        }

        private void SAIFrm089_Load(object sender, EventArgs e)
        {
            this.LlenarTipoIncidencias();
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

        private void cbxMunicipio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxLocalidad.Focus();
            }
        }

        private void cbxCP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxColonia.Focus();
            }
        }

        private void cbxLocalidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxCP.Focus();
            }
        }

        private void cbxColonia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtReferencias.Focus();
            }
        }

        private void txtAliasDelincuente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtOficioEnvio.Focus();
            }
        }

        private void txtOficioEnvio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpFechaDoc.Focus();
            }
        }

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

        private void LlenarLocalidades(int iMunicipio)
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

        private void LlenarColonias(int iLocalidad)
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

        private void LlenarCodigosPostales()
        {
            try
            {
                try { }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
        }


        private void InsertarInsidencia()
        {
            try 
            {
                try 
                {
                    _Incidencia089 = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Incidencia();

                    _Incidencia089.HoraRecepcion = DateTime.Now;
                    _Incidencia089.Referencias = "";
                    _Incidencia089.Descripcion = "";
                    _Incidencia089.Activo = true;
                    _Incidencia089.ClaveEstatus = 1;
                    _Incidencia089.ClaveEstado = 29;
                    _Incidencia089.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;

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

        private void ActualizarInsidencia()
        {
            try
            {
                try
                {
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
            SAIFrmDependencias089 frmDependencias = new SAIFrmDependencias089(9);
            frmDependencias.ShowDialog();
        }

    }
}
