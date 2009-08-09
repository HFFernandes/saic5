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
    public partial class frmCorporaciones : SAIFrmBase
    {
        public frmCorporaciones()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmCorporaciones_Load(object sender, EventArgs e)
        {
            SAIBarraEstado.SizingGrip = false;
            this.LlenarSistemas();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void LlenarGrid()
        {
            try 
            {
                this.gvCorporaciones.DataSource = Mappers.CorporacionMapper.Instance().GetAll();
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        private void Limpiar()
        {            
            foreach (DataGridViewRow row in this.gvCorporaciones.Rows)
            {
                row.Selected = false;
            }
            this.ddlSistema.SelectedIndex = -1;
            this.saiTxtDescripcion.Text = "";
            this.chkUnidadVirtual.Checked = false;
            this.chkActivo.Checked = false;
        }

        private void LlenarSistemas()
        {
            try
            {
                this.ddlSistema.DataSource = Mappers.SistemaMapper.Instance().GetAll();
                this.ddlSistema.DisplayMember = "Descripcion";
                this.ddlSistema.ValueMember = "Clave";
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        #region ABC
        /// <summary>
            /// Metodo que Agrega un nuevo registro
        /// </summary>
        private void Agregar()
        {
            try 
            {
                if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
                {
                    Entidades.Corporacion newCorporacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Corporacion();
                    newCorporacion.ClaveSistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
                    newCorporacion.Descripcion = this.saiTxtDescripcion.Text;
                    newCorporacion.Activo = this.chkActivo.Checked;
                    newCorporacion.UnidadesVirtuales = this.chkUnidadVirtual.Checked;

                    Mappers.CorporacionMapper.Instance().Insert(newCorporacion);
                }
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        /// <summary>
        /// Metodo que Actualiza los datos de un registro
        /// </summary>
        private void Modificar()
        {
            try 
            {
                int rowSelected = this.gvCorporaciones.CurrentCellAddress.Y;
                if (rowSelected > -1)
                {
                    int clave = Convert.ToInt32(this.gvCorporaciones.Rows[rowSelected].Cells["Clave"].Value);
                    Entidades.Corporacion updCorporacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Corporacion(clave);
                    updCorporacion.ClaveSistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
                    updCorporacion.Descripcion = this.saiTxtDescripcion.Text;
                    updCorporacion.UnidadesVirtuales = this.chkUnidadVirtual.Checked;
                    updCorporacion.Activo = this.chkActivo.Checked;
                    Mappers.CorporacionMapper.Instance().Save(updCorporacion);
                }
            }
            catch (Exception ex)
            {
                this.SAIEtiquetaEstado.Text = ex.Message;
            }
        }

        /// <summary>
        /// Metodo que elimina un registro del catalogo Corporaciones
        /// </summary>
        private void Eliminar()
        {
            try 
            {
                int selectedRow = this.gvCorporaciones.CurrentCellAddress.Y;
                if (selectedRow > -1)
                {
                    Mappers.CorporacionMapper.Instance().Delete(Convert.ToInt32(this.gvCorporaciones.Rows[selectedRow].Cells["Clave"].Value));
                }
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }
        #endregion

        private void gvCorporaciones_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRow = this.gvCorporaciones.CurrentCellAddress.Y;
            if (selectedRow > -1)
            {
                this.saiTxtDescripcion.Text = Convert.ToString(this.gvCorporaciones.Rows[selectedRow].Cells["Descripcion"].Value);
                this.ddlSistema.SelectedValue = this.gvCorporaciones.Rows[selectedRow].Cells["ClaveSistema"].Value;
                this.chkActivo.Checked = Convert.ToBoolean(this.gvCorporaciones.Rows[selectedRow].Cells["Activo"].Value);
                this.chkUnidadVirtual.Checked = Convert.ToBoolean(this.gvCorporaciones.Rows[selectedRow].Cells["UnidadesVirtuales"].Value);
                this.btnEliminar.Visible = true;
            }
        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
