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
using System.Configuration;

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

        private void LlenarEstado()
        {
            try
            {
                try
                {
                    Entidades.EstadoList lstEstado = Mappers.EstadoMapper.Instance().GetAll();

                    foreach (Entidades.Estado estado in lstEstado)
                    {
                        this.ddlEstado.Items.Add(new ComboItem(estado.Clave, estado.Nombre));
                    }

                    this.ddlMunicipio.DisplayMember = "Descripcion";
                    this.ddlMunicipio.ValueMember = "Valor";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void LlenarMunicipio()
        {
            try
            {
                try
                {
                    Entidades.MunicipioList lstMunicipio = Mappers.MunicipioMapper.Instance().GetAll();

                    foreach (Entidades.Municipio municipio in lstMunicipio)
                    {
                        this.ddlMunicipio.Items.Add(new ComboItem(municipio.Clave, municipio.Nombre));
                    }

                    this.ddlMunicipio.DisplayMember = "Descripcion";
                    this.ddlMunicipio.ValueMember = "Valor";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private object ObtieneValor(ComboBox comboBox)
        {
            return ((ComboItem)comboBox.Items[comboBox.SelectedIndex]).Valor;
        }

        private string ObtieneDescripcion(ComboBox comboBox)
        {
            return ((ComboItem)comboBox.Items[comboBox.SelectedIndex]).Descripcion;
        }

        private void SeleccionarComboItem(int Value, ComboBox comboBox)
        {
            foreach (ComboItem item in comboBox.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    comboBox.SelectedItem = item;
                    break;
                }
                else
                { comboBox.SelectedIndex = -1; }
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
                    newUnidad.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporacion)); // Convert.ToInt32(this.ddlCorporacion.SelectedValue);
                    newUnidad.Codigo = saiTxtCodigo.Text;
                    newUnidad.Activo = this.chkActivo.Checked;

                    Mappers.ListaUnidadesMapper.Instance().Insert(newUnidad);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego la unidad: " + newUnidad.Codigo;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Unidades";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                    bitacora.Operacion = "INSERT";

                    Mappers.BitacoraMapper.Instance().Insert(bitacora);
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
                    updUnidad.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporacion));
                    updUnidad.Codigo = this.saiTxtCodigo.Text;
                    updUnidad.Activo = this.chkActivo.Checked;

                    Mappers.ListaUnidadesMapper.Instance().Save(updUnidad);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se modifico la Unidad: " + updUnidad.Codigo;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Unidades";
                    bitacora.Operacion = "UPDATE";
                    bitacora.ValorActual = "Todos los campos";
                    bitacora.ValorAnterior = "Todos los campos";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];

                    Mappers.BitacoraMapper.Instance().Insert(bitacora);
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

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se elimino la Unidad: " + Convert.ToString(this.gvUnidades.Rows[selectedRow].Cells["Codigo"].Value);
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Unidades";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "DELETE";
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
                        this.SeleccionarComboItem(Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["ClaveCorporacion"].Value), this.ddlCorporacion);
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

        private void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
