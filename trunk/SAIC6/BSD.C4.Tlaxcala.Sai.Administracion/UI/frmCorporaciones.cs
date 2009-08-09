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
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;


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

        /// <summary>
        /// Llenar el DtataGrid con el catalogo de Corporaciones
        /// </summary>
        private void LlenarGrid()
        {
            DataTable catCorporaciones = new DataTable("CatCorporaciones");

            try
            {
                catCorporaciones.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                catCorporaciones.Columns.Add(new DataColumn("Descripcion", Type.GetType("System.String")));
                catCorporaciones.Columns.Add(new DataColumn("ClaveSistema", Type.GetType("System.Int32")));
                catCorporaciones.Columns.Add(new DataColumn("Sistema", Type.GetType("System.String")));
                catCorporaciones.Columns.Add(new DataColumn("UnidadesVirtuales", Type.GetType("System.Boolean")));
                catCorporaciones.Columns.Add(new DataColumn("Activo", Type.GetType("System.Boolean")));
                catCorporaciones.Columns.Add(new DataColumn("Zn", Type.GetType("System.String")));


                Entidades.CorporacionList lstCorporaciones = Mappers.CorporacionMapper.Instance().GetAll();
                foreach (Entidades.Corporacion corporacion in lstCorporaciones)
                {
                    object[] registro = new object[] { corporacion.Clave, corporacion.Descripcion, corporacion.ClaveSistema, 
                        Mappers.SistemaMapper.Instance().GetOne(corporacion.ClaveSistema.Value).Descripcion, corporacion.UnidadesVirtuales, corporacion.Activo, corporacion.Zn };
                    catCorporaciones.Rows.Add(registro);
                }

                this.gvCorporaciones.DataSource = catCorporaciones.DefaultView; //Mappers.CorporacionMapper.Instance().GetAll();
                this.gvCorporaciones.Columns["ClaveSistema"].Visible = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }

        private void Limpiar()
        {
            try
            {
                foreach (DataGridViewRow row in this.gvCorporaciones.Rows)
                {
                    row.Selected = false;
                }
                this.ddlSistema.SelectedIndex = -1;
                this.saiTxtDescripcion.Text = "";
                this.chkUnidadVirtual.Checked = false;
                this.chkActivo.Checked = false;
                this.btnEliminar.Visible = false;
                this.btnModificar.Enabled = false;
                this.btnLimpiar.Enabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
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
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
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
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
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
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
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
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }
        #endregion

        private void gvCorporaciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = this.gvCorporaciones.CurrentCellAddress.Y;
                if (selectedRow > -1)
                {
                    this.saiTxtDescripcion.Text = Convert.ToString(this.gvCorporaciones.Rows[selectedRow].Cells["Descripcion"].Value);
                    this.ddlSistema.SelectedValue = this.gvCorporaciones.Rows[selectedRow].Cells["ClaveSistema"].Value;
                    this.chkActivo.Checked = Convert.ToBoolean(this.gvCorporaciones.Rows[selectedRow].Cells["Activo"].Value);
                    this.chkUnidadVirtual.Checked = Convert.ToBoolean(this.gvCorporaciones.Rows[selectedRow].Cells["UnidadesVirtuales"].Value);
                    this.btnEliminar.Visible = true;
                    this.btnModificar.Enabled = true;
                    this.btnLimpiar.Enabled = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
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
            if (MessageBox.Show("¿Desea Eliminar la corporaciòn?", "Sistema de Administracion de Incidencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }        
    }
}
