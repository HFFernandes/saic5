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
            this.LlenarGrid();
            this.LlenarLocalidad();
            this.LlenarCodigoPostal();
        }

        private void LlenarGrid()
        {
            try
            {
                DataTable catColonias = new DataTable("catColonias");
                try
                {
                    catColonias.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
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
                    this.gvColonias.Columns["Clave"].Visible = false;
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
                    /*this.ddlCodigoPostal.DataSource = Mappers.CodigoPostalMapper.Instance().GetAll();
                    this.ddlCodigoPostal.DisplayMember = "Valor";
                    this.ddlCodigoPostal.ValueMember = "Clave";*/
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
                try { }
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
                try { }
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
                try { }
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
            this.Agregar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
            this.LlenarGrid();
            this.Limpiar();
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
                    this.saiTxtNombre.Text = Convert.ToString(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Nombre"].Value);
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
            if (Convert.ToString(this.ddlCodigoPostal.SelectedValue) == "000")
            {
                this.saiTxtCP.Visible = true;
                this.lblOtro.Visible = true;
            }
            else 
            {
                this.saiTxtCP.Visible = false;
                this.lblOtro.Visible = false;
            }
        }
    }
}
