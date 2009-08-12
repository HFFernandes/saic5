using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;


namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmLocalidades : SAIFrmBase
    {
        public frmLocalidades()
        {
            InitializeComponent();
        }

        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            this.LlenarMunicipios();
            this.LlenarEstados();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void LlenarGrid()
        {
            DataTable catLocalidades = new DataTable("catLocalidades");

            try
            {                
                catLocalidades.Columns.Add("Clave", Type.GetType("System.Int32"));
                catLocalidades.Columns.Add("ClaveMunicipio", Type.GetType("System.Int32"));
                catLocalidades.Columns.Add("Municipio", Type.GetType("System.String"));
                catLocalidades.Columns.Add("ClaveLocalidadCartografia", Type.GetType("System.Int32"));
                catLocalidades.Columns.Add("Localidad", Type.GetType("System.String"));

                Entidades.LocalidadList lstLocalidad = Mappers.LocalidadMapper.Instance().GetAll();

                foreach (Entidades.Localidad localidad in lstLocalidad)
                {
                    object[] registro = new object[] { localidad.Clave, localidad.ClaveMunicipio, 
                        Mappers.MunicipioMapper.Instance().GetOne(localidad.ClaveMunicipio).Nombre, localidad.ClaveLocalidadCartografia, localidad.Nombre };
                    catLocalidades.Rows.Add(registro);
                }

                this.gvLocalidades.DataSource = catLocalidades;
                this.gvLocalidades.Columns["Clave"].Visible = false;
                this.gvLocalidades.Columns["ClaveMunicipio"].Visible = false;
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
                { }
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
                    this.ddlMunicipio.DataSource = Mappers.MunicipioMapper.Instance().GetAll();
                    this.ddlMunicipio.DisplayMember = "Nombre";
                    this.ddlMunicipio.ValueMember = "Clave";
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
                    Entidades.Localidad newLocalidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Localidad();
                    newLocalidad.ClaveMunicipio = Convert.ToInt32(this.ddlMunicipio.SelectedValue);
                    newLocalidad.Nombre = this.saiTxtNombre.Text;
                    newLocalidad.ClaveLocalidadCartografia = this.txtClaveLocalidadCartografia.Text != string.Empty ? Convert.ToInt32(this.txtClaveLocalidadCartografia.Text) : 0;
                    Mappers.LocalidadMapper.Instance().Insert(newLocalidad);
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
                    Entidades.Localidad updLocalidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Localidad(Convert.ToInt32(this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));
                    updLocalidad.ClaveMunicipio = Convert.ToInt32(this.ddlMunicipio.SelectedValue);
                    updLocalidad.Nombre = this.saiTxtNombre.Text;
                    updLocalidad.ClaveLocalidadCartografia = this.txtClaveLocalidadCartografia.Text != string.Empty ? Convert.ToInt32(this.saiTxtNombre.Text) : 0;
                    Mappers.LocalidadMapper.Instance().Save(updLocalidad);
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
                    Mappers.LocalidadMapper.Instance().Delete(Convert.ToInt32(this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvLocalidades.Rows)
            {
                row.Selected = false;
            }

            this.ddlMunicipio.SelectedIndex = -1;
            this.ddlEstado.SelectedIndex = 0;
            this.saiTxtNombre.Text = string.Empty;
            this.btnAgregar.Enabled = true;
            this.btnEliminar.Visible = false;
            this.btnModificar.Enabled = false;
        }

        #endregion

        private int ObtenerIndiceSeleccionado()
        { return this.gvLocalidades.CurrentCellAddress.Y; }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Agregar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvLocalidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.ObtenerIndiceSeleccionado() > -1)
                    {
                        this.saiTxtNombre.Text = Convert.ToString(this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Localidad"].Value);
                        this.ddlMunicipio.SelectedValue = this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveMunicipio"].Value;
                        //this.ddlEstado.SelectedIndex = 0;
                        this.txtClaveLocalidadCartografia.Text = Convert.ToString(this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveLocalidadCartografia"].Value);
                        this.btnAgregar.Enabled = false;
                        this.btnEliminar.Visible = true;
                        this.btnModificar.Enabled = true;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
    }
}
