using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmMunicipios : SAIFrmBase
    {
        public frmMunicipios()
        {
            InitializeComponent();
        }

        private void frmMunicipios_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarEstados();
            this.LlenarGrid();
            this.Limpiar();

        }

        private void LlenarGrid()
        {
            try 
            {
                DataTable catMunicipios = new DataTable("CatMunicipios");
                try
                {
                    catMunicipios.Columns.Add(new DataColumn("ClaveCartografia", Type.GetType("System.Int32")));
                    catMunicipios.Columns.Add(new DataColumn("ClaveEstado", Type.GetType("System.Int32")));
                    catMunicipios.Columns.Add(new DataColumn("Estado", Type.GetType("System.String")));
                    catMunicipios.Columns.Add(new DataColumn("Nombre", Type.GetType("System.String")));

                    Entidades.MunicipioList lstMunicipios = Mappers.MunicipioMapper.Instance().GetAll();

                    foreach (Entidades.Municipio municipio in lstMunicipios)
                    {
                        object[] registro = new object[] { municipio.Clave, municipio.ClaveEstado, 
                            Mappers.EstadoMapper.Instance().GetOne(municipio.ClaveEstado.Value).Nombre, municipio.Nombre };

                        catMunicipios.Rows.Add(registro);
                    }

                    this.gvMunicipios.DataSource = catMunicipios;
                    //this.gvMunicipios.Columns["ClaveCartografia"].Visible = false;
                    this.gvMunicipios.Columns["ClaveEstado"].Visible = false;

                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void LlenarEstados()
        {
            try
            {
                try 
                {
                    this.ddlEstado.DataSource = Mappers.EstadoMapper.Instance().GetAll();
                    this.ddlEstado.DisplayMember = "Nombre";
                    this.ddlEstado.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
    

        #region ABC
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.Municipio newMunicipio = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Municipio();
                    newMunicipio.Clave = Convert.ToInt32(this.saiClave.Text);
                    newMunicipio.ClaveEstado = Convert.ToInt32(this.ddlEstado.SelectedValue);
                    newMunicipio.Nombre = this.saiTxtNombre.Text;
                    Mappers.MunicipioMapper.Instance().Insert(newMunicipio);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void Modificar()
        {
            try
            {
                try 
                {
                    int municipioSelected = Convert.ToInt32(this.gvMunicipios.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value);
                    Entidades.Municipio updMunicipio = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Municipio(municipioSelected);
                    updMunicipio.Clave = Convert.ToInt32(this.saiClave.Text);
                    updMunicipio.Nombre = this.saiTxtNombre.Text;
                    updMunicipio.ClaveEstado = Convert.ToInt32(this.ddlEstado.SelectedValue);
                    Mappers.MunicipioMapper.Instance().Save(updMunicipio);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void Eliminar()
        {
            try
            {
                try 
                {
                    int municipioSelected = Convert.ToInt32(this.gvMunicipios.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value);
                    Mappers.MunicipioMapper.Instance().Delete(municipioSelected);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void Limpiar()
        {
            this.saiClave.Text = string.Empty;
            this.saiTxtNombre.Text = string.Empty;
            //this.btnAgregar.Enabled = true;
        }

        #endregion

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }
        /*

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el municipio?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }
        */
        private int ObtenerIndiceSeleccionado()
        {
            return this.gvMunicipios.CurrentCellAddress.Y;
        }

        private void gpbDatosGenerales_Enter(object sender, EventArgs e)
        {

        }

        private void gvMunicipios_SelectionChanged(object sender, EventArgs e)
        {
            /*try
            {
                try
                {
                    if (this.ObtenerIndiceSeleccionado() > -1)
                    {
                        this.saiClave.Text = Convert.ToString(this.gvMunicipios.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value);
                        this.saiTxtNombre.Text = Convert.ToString(this.gvMunicipios.Rows[this.ObtenerIndiceSeleccionado()].Cells["Nombre"].Value);
                        //this.btnAgregar.Enabled = false;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }*/
        }
    }
}
