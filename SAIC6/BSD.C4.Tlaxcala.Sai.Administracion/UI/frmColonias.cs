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
    public partial class frmColonias : SAIFrmBase
    {
        public frmColonias()
        {
            InitializeComponent();
        }

        private void frmColonias_Load(object sender, EventArgs e)
        {
            this.LlenarEstado();
            //this.LlenarMunicipio();
            this.LlenarGrid();
            this.LlenarLocalidad();
            this.LlenarCodigoPostal();
        }

        private void LlenarEstado()
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

        private void LlenarMunicipio(int idlocalidad)
        {
            try
            {
                try 
                {
                    Entidades.Localidad localidad = Mappers.LocalidadMapper.Instance().GetOne(idlocalidad);
                    Entidades.Municipio municipio = Mappers.MunicipioMapper.Instance().GetOne(localidad.ClaveMunicipio);
                    Entidades.MunicipioList municipios = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.MunicipioList();
                    municipios.Add(municipio);
                    this.ddlMunicipio.DataSource = municipios;
                    this.ddlMunicipio.DisplayMember = "Nombre";
                    this.ddlMunicipio.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }

        }

        private void LlenarGrid()
        {
            try
            {
                DataTable catColonias = new DataTable("catColonias");
                try
                {
                    catColonias.Columns.Add(new DataColumn("ClaveCartografia", Type.GetType("System.Int32")));
                    catColonias.Columns.Add(new DataColumn("ClaveLocalidad", Type.GetType("System.Int32")));
                    catColonias.Columns.Add(new DataColumn("Localidad", Type.GetType("System.String")));
                    catColonias.Columns.Add(new DataColumn("Nombre", Type.GetType("System.String")));
                    catColonias.Columns.Add(new DataColumn("ClaveCodigo", Type.GetType("System.Int32")));
                    catColonias.Columns.Add(new DataColumn("CodigoPostal", Type.GetType("System.Int32")));

                    Entidades.ColoniaList lstColonias = Mappers.ColoniaMapper.Instance().GetAll();

                    foreach (Entidades.Colonia colonia in lstColonias)
                    {
                        object[] registro = new object[] { colonia.Clave, colonia.ClaveLocalidad, 
                        Mappers.LocalidadMapper.Instance().GetOne(colonia.ClaveLocalidad).Nombre, colonia.Nombre,
                        colonia.ClaveCodigoPostal, Mappers.CodigoPostalMapper.Instance().GetOne(colonia.ClaveCodigoPostal.Value).Valor };
                        catColonias.Rows.Add(registro);
                    }

                    this.gvColonias.DataSource = catColonias;
                    //this.gvColonias.Columns["Clave"].Visible = false;
                    this.gvColonias.Columns["ClaveLocalidad"].Visible = false;
                    this.gvColonias.Columns["ClaveCodigo"].Visible = false;
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void LlenarLocalidad()
        {
            try 
            {
                this.ddlLocalidad.DataSource = Mappers.LocalidadMapper.Instance().GetAll();
                this.ddlLocalidad.DisplayMember = "Nombre";
                this.ddlLocalidad.ValueMember = "Clave";

            }
            catch
            { }
        }

        private void LlenarCodigoPostal()
        {
            this.ddlCodigoPostal.Items.Clear();
            try
            {
                try
                {
                    this.ddlCodigoPostal.Items.Add(new Utilerias.ComboItem("000", "Otro..."));
                    Entidades.CodigoPostalList lstCodigoPostal = Mappers.CodigoPostalMapper.Instance().GetAll();
                    foreach (Entidades.CodigoPostal cp in lstCodigoPostal)
                    {
                        this.ddlCodigoPostal.Items.Add(new Utilerias.ComboItem(cp.Clave, cp.Valor));
                    }

                    this.ddlCodigoPostal.ValueMember = "Valor";
                    this.ddlCodigoPostal.DisplayMember = "Descripcion";
                }
                catch(Exception ex)
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
                    Entidades.Colonia newColonia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Colonia();
                    newColonia.Clave = Convert.ToInt32(this.saiClave.Text);
                    newColonia.ClaveLocalidad = Convert.ToInt32(this.ddlLocalidad.SelectedValue);
                    newColonia.Nombre = this.saiTxtNombre.Text;
                    if (Convert.ToString(ObtenerValor()) == "000")
                    {
                        newColonia.ClaveCodigoPostal = this.ObtenerCodigoPostal(this.txtCP.Text);
                    }
                    else
                    {
                        newColonia.ClaveCodigoPostal = Convert.ToInt32(this.ObtenerValor());
                    }

                    Mappers.ColoniaMapper.Instance().Insert(newColonia);
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
                    int selectedColonia = Convert.ToInt32(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value);
                    Entidades.Colonia updColonia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Colonia(selectedColonia);
                    updColonia.Clave = Convert .ToInt32(this.saiClave.Text);
                    updColonia.ClaveLocalidad = Convert.ToInt32(this.ddlLocalidad.SelectedValue);
                    updColonia.Nombre = this.saiTxtNombre.Text;

                    if (Convert.ToString(ObtenerValor()) == "000")
                    {
                        updColonia.ClaveCodigoPostal = this.ObtenerCodigoPostal(this.txtCP.Text);
                    }
                    else
                    {
                        updColonia.ClaveCodigoPostal = Convert.ToInt32(this.ObtenerValor());
                    }

                    Mappers.ColoniaMapper.Instance().Save(updColonia);
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
                    Mappers.ColoniaMapper.Instance().Delete(Convert.ToInt32(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value));
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvColonias.Rows)
            {
                row.Selected = false;
            }
            this.saiClave.Text = string.Empty;
            this.ddlCodigoPostal.SelectedIndex = -1;
            this.ddlLocalidad.SelectedIndex = -1;
            this.saiTxtNombre.Text = string.Empty;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Visible = false;
            this.btnAgregar.Enabled = true;
        }

        #endregion

        private int ObtenerIndiceSeleccionado()
        { return this.gvColonias.CurrentCellAddress.Y; }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Colonia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
            {
                this.Agregar();
                this.LlenarGrid();
                this.LlenarCodigoPostal();
                this.Limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
            {
                this.Modificar();
                this.LlenarGrid();
                this.LlenarCodigoPostal();
                this.Limpiar();
            }
        }

        
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void gvColonias_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                if (this.ObtenerIndiceSeleccionado() > -1)
                {
                    this.saiClave.Text = Convert.ToString(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value);
                    this.saiTxtNombre.Text = Convert.ToString(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Nombre"].Value);
                    this.SeleccionarComboItem(Convert.ToInt32(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCodigo"].Value));
                    this.ddlLocalidad.SelectedValue = this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveLocalidad"].Value;
                    this.LlenarMunicipio(Convert.ToInt32(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveLocalidad"].Value));
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Visible = true;
                    this.btnAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            { }
        }

        private void ddlCodigoPostal_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToString(this.ObtenerValor()) == "000")
            {
                this.txtCP.Visible = true;
                this.lblOtro.Visible = true;
            }
            else 
            {
                this.txtCP.Visible = false;
                this.lblOtro.Visible = false;
            }
        }

        private object ObtenerValor()
        {
            if (this.ddlCodigoPostal.SelectedItem != null)
                return ((Utilerias.ComboItem)this.ddlCodigoPostal.SelectedItem).Valor;
            else
                return 0;
        }

        private void SeleccionarComboItem(int Value)
        {
            foreach (Utilerias.ComboItem item in this.ddlCodigoPostal.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.ddlCodigoPostal.SelectedItem = item;
                    break;
                }
                /*else
                { this.ddlCodigoPostal.SelectedIndex = -1; }*/
            }
        }

        /// <summary>
        /// Obtiene la clave del codigo postal
        /// </summary>
        /// <param name="cp">Especifica el cp que no esta en la lista</param>
        /// <returns></returns>
        private int ObtenerCodigoPostal(string cp)
        {
            try
            {
                try 
                {
                    bool existe = false;
                    int max = 0;
                    Entidades.CodigoPostalList lstCodigoPostal = Mappers.CodigoPostalMapper.Instance().GetAll();
                    foreach (Entidades.CodigoPostal codigoPostal in lstCodigoPostal) 
                    {
                        if (codigoPostal.Valor == cp)
                        {
                            existe = true;
                            max = codigoPostal.Clave;
                            break;
                        }

                        if(codigoPostal.Clave > max)
                            max = codigoPostal.Clave;
                    }
                    
                    if (!existe)
                    {
                        Entidades.CodigoPostal newCP = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.CodigoPostal();
                        newCP.Clave = max + 1;
                        newCP.Valor = cp;
                        Mappers.CodigoPostalMapper.Instance().Insert(newCP);
                        return newCP.Clave;
                    }
                    return max;
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
            return 0;
        }


    }
}
