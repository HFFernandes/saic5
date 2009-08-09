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
                this.ddlCorporacion.DataSource = Mappers.CorporacionMapper.Instance().GetAll();
                this.ddlCorporacion.DisplayMember = "Descripcion";
                this.ddlCorporacion.ValueMember = "Clave";
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        private void LlenarGrid()
        {
            try
            {
            /*    DataTable catUbicacion = new DataTable("CatUbicaciones");
                catUbicacion.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                catUbicacion.Columns.Add(new DataColumn("Codigo", Type.GetType("System.String")));
                catUbicacion.Columns.Add(new DataColumn("ClaveCorporacion", Type.GetType("System.String")));
                catUbicacion.Columns.Add(new DataColumn("Activo", Type.GetType("System.Boolean")));

                catUbicacion.Rows.Add(new object[] { 1, "COD456", "ClaveCorporacion", true });

                this.gvUnidades.DataSource = catUbicacion;*/
                this.gvUnidades.DataSource = Mappers.ListaUnidadesMapper.Instance().GetAll();
            }
            catch(Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
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
        }
        #region ABC
        /// <summary>
        /// Agrega una nueva Unidad
        /// </summary>
        private void Agregar()
        {
            try 
            {
                Entidades.ListaUnidades newUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ListaUnidades();
                newUnidad.ClaveCorporacion = Convert.ToInt32(this.ddlCorporacion.SelectedValue);
                newUnidad.Codigo = saiTxtCodigo.Text;
                newUnidad.Activo = this.chkActivo.Checked;

                Mappers.ListaUnidadesMapper.Instance().Insert(newUnidad);
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }
        /// <summary>
        /// Modifica lo datos de una Unidad existente
        /// </summary>
        private void Modificar()
        {
            try 
            {
                int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                int clave = Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["Clave"].Value);
                Entidades.ListaUnidades updUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ListaUnidades(clave);
                updUnidad.ClaveCorporacion = Convert.ToInt32(this.ddlCorporacion.SelectedValue);
                updUnidad.Codigo = this.saiTxtCodigo.Text;
                updUnidad.Activo = this.chkActivo.Checked;

                Mappers.ListaUnidadesMapper.Instance().Save(updUnidad);
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }
        /// <summary>
        /// Elimina una Unidad del Catalogo
        /// </summary>
        private void Eliminar()
        {
            try 
            {
                int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                if (selectedRow > -1)
                {
                    Mappers.ListaUnidadesMapper.Instance().Delete(Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["Clave"].Value));
                }
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
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
            this.Eliminar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void bnCancelar_Click(object sender, EventArgs e)
        {            
            this.LlenarGrid();
            this.Limpiar();
        }

        private void gvUnidades_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                if (selectedRow > -1)
                {
                    this.saiTxtCodigo.Text = Convert.ToString(this.gvUnidades.Rows[selectedRow].Cells["Codigo"].Value);
                    this.ddlCorporacion.SelectedValue = this.gvUnidades.Rows[selectedRow].Cells["ClaveCorporacion"].Value;
                    this.chkActivo.Checked = Convert.ToBoolean(this.gvUnidades.Rows[selectedRow].Cells["Activo"].Value);
                }
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }
    }
}
