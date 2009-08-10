using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using System.Data.SqlClient;
using BSD.C4.Tlaxcala.Sai.Administracion.Utilerias;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmUnidades : SAIFrmBase
    {
        public frmUnidades()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmUnidades_Load(object sender, EventArgs e)
        {
            SAIBarraEstado.SizingGrip = false;
            this.LlenarGrid();
            this.LlenarCorporaciones();
        }

        private void LlenarCorporaciones()
        {
            try
            {
                try
                {
                    Entidades.CorporacionList lstCorporaciones = Mappers.CorporacionMapper.Instance().GetAll();

                    foreach (Entidades.Corporacion corporacion in lstCorporaciones)
                    {
                        if (!corporacion.UnidadesVirtuales)
                        {
                            this.ddlCorporacion.Items.Add(new ComboItem(corporacion.Clave, corporacion.Descripcion));
                            this.ddlCorporacion.DisplayMember = "Descripcion";
                            this.ddlCorporacion.ValueMember = "Value";
                        }
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private object ObtieneValor(int indice)
        {
            return ((ComboItem)this.ddlCorporacion.Items[indice]).Valor;
        }

        private string ObtieneDescripcion(int indice)
        {
            return ((ComboItem)this.ddlCorporacion.Items[indice]).Descripcion;
        }

        private void SeleccionarComboItem(int Value)
        {
            foreach (ComboItem item in this.ddlCorporacion.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.ddlCorporacion.SelectedItem = item;
                    break;
                }
                else
                { this.ddlCorporacion.SelectedIndex = -1; }
            }
        }

        private void LlenarGrid()
        {
            try
            {
                DataTable catUbicacion = new DataTable("CatUbicaciones");
                try
                {
                    catUbicacion.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                    catUbicacion.Columns.Add(new DataColumn("Codigo", Type.GetType("System.String")));
                    catUbicacion.Columns.Add(new DataColumn("ClaveCorporacion", Type.GetType("System.Int32")));
                    catUbicacion.Columns.Add(new DataColumn("Corporacion", Type.GetType("System.String")));
                    catUbicacion.Columns.Add(new DataColumn("Activo", Type.GetType("System.Boolean")));

                    Entidades.ListaUnidadesList lstUnidades = Mappers.ListaUnidadesMapper.Instance().GetAll();

                    foreach (Entidades.ListaUnidades unidad in lstUnidades)
                    {
                        object[] registro = new object[] { unidad.Clave, unidad.Codigo, unidad.ClaveCorporacion,
                       Mappers.CorporacionMapper.Instance().GetOne(unidad.ClaveCorporacion).Descripcion, unidad.Activo};
                        catUbicacion.Rows.Add(registro);
                    }


                    this.gvUnidades.DataSource = catUbicacion;
                    this.gvUnidades.Columns["Clave"].Visible = false;
                    this.gvUnidades.Columns["ClaveCorporacion"].Visible = false;
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
        /// Deselecciona el registro seleccionado del grid y limpialos controles
        /// </summary>
        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvUnidades.Rows)
            {
                row.Selected = false;
            }
            this.ddlCorporacion.SelectedIndex = -1;
            this.saiTxtCodigo.Text = "";
            this.chkActivo.Checked = false;
            this.btnEliminar.Visible = false;
            this.btnModificar.Enabled = false;
            this.btnAgregar.Enabled = true;
        }
        #region ABC
        /// <summary>
        /// Agrega una nueva Unidad
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.ListaUnidades newUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ListaUnidades();
                    newUnidad.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporacion.SelectedIndex)); // Convert.ToInt32(this.ddlCorporacion.SelectedValue);
                    newUnidad.Codigo = saiTxtCodigo.Text;
                    newUnidad.Activo = this.chkActivo.Checked;

                    Mappers.ListaUnidadesMapper.Instance().Insert(newUnidad);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion) //Exception ex)
            { }//this.SAIEtiquetaEstado.Text = ex.Message; }
        }
        /// <summary>
        /// Modifica lo datos de una Unidad existente
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                    int clave = Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["Clave"].Value);
                    Entidades.ListaUnidades updUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ListaUnidades(clave);
                    updUnidad.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporacion.SelectedIndex));
                    updUnidad.Codigo = this.saiTxtCodigo.Text;
                    updUnidad.Activo = this.chkActivo.Checked;

                    Mappers.ListaUnidadesMapper.Instance().Save(updUnidad);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Elimina una Unidad del Catalogo
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                    if (selectedRow > -1)
                    {
                        Mappers.ListaUnidadesMapper.Instance().Delete(Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["Clave"].Value));
                    }
                    else { throw new SAIExcepcion("Seleccione la unidad que desea eliminar."); }
                }
                catch (Exception ex)
                { throw new SAIExcepcion("No puede eliminar la Unidad porque esta Asociada."); }
            }
            catch (SAIExcepcion)
            { }
        }
        #endregion

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
            if (MessageBox.Show("¿Desea eliminar la Unidad?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void bnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvUnidades_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                try
                {
                    int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                    if (selectedRow > -1)
                    {
                        this.saiTxtCodigo.Text = Convert.ToString(this.gvUnidades.Rows[selectedRow].Cells["Codigo"].Value);
                        //this.ddlCorporacion.SelectedValue = this.gvUnidades.Rows[selectedRow].Cells["ClaveCorporacion"].Value;
                        this.SeleccionarComboItem(Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["ClaveCorporacion"].Value));
                        this.chkActivo.Checked = Convert.ToBoolean(this.gvUnidades.Rows[selectedRow].Cells["Activo"].Value);
                        this.btnEliminar.Visible = true;
                        this.btnModificar.Enabled = true;
                        btnAgregar.Enabled = false;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch(SAIExcepcion)
            { } //this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
