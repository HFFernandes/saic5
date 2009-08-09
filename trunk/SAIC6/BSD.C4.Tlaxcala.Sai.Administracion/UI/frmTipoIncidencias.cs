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
    public partial class frmTipoIncidencias : SAIFrmBase
    {
        public frmTipoIncidencias()
        {
            InitializeComponent();
        }

        private void frmTipoIncidencias_Load(object sender, EventArgs e)
        {
            SAIBarraEstado.SizingGrip = false;
            this.LlenarGrid();
            this.LlenarSistemas();
            this.Limpiar();
        }

        private void LlenarGrid()
        {
            DataTable catTipoIncidencia = new DataTable();

            try 
            {

                this.gvTipoIncidencias.DataSource = Mappers.TipoIncidenciaMapper.Instance().GetAll();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }

        private void LlenarSistemas()
        {
            try {
                this.ddlSistema.DataSource = Mappers.SistemaMapper.Instance().GetAll();
                this.ddlSistema.DisplayMember = "Descripcion";
                this.ddlSistema.ValueMember = "Clave";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }

        private void gvTipoIncidencias_Click(object sender, EventArgs e)
        {

        }

        private void gvTipoIncidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Evento del DataGrid para obtener los datos que del regitro que se ha seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvTipoIncidencias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //int selectedRow = this.gvTipoIncidencias.CurrentRow.Index;
                int selectedRow = this.gvTipoIncidencias.CurrentCellAddress.Y;
                if (selectedRow > -1)
                {
                    this.btnModificar.Enabled = true;
                    this.saiTxtDescripcion.Text = Convert.ToString(this.gvTipoIncidencias.CurrentRow.Cells["Descripcion"].Value);
                    this.ddlSistema.SelectedValue = this.gvTipoIncidencias.CurrentRow.Cells["ClaveSistema"].Value;
                    this.btnAgregar.Enabled = false;
                    this.btnEliminar.Visible = true;
                }                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }

        /// <summary>
        /// Deselecciona algun registro del DataGrid y limpia el campo Descripcion
        /// </summary>
        private void Limpiar()
        {            
            foreach (DataGridViewRow row in this.gvTipoIncidencias.Rows)
            {
                row.Selected = false;
            }
            //this.gvTipoIncidencias.ClearSelection();
            this.saiTxtDescripcion.Text = "";
            this.btnModificar.Enabled = false;
            this.btnAgregar.Enabled = true;
            this.btnEliminar.Visible = false;
        }

        private void gvTipoIncidencias_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        #region ABC

        /// <summary>
        /// Metodo para acgregar un nuevo tipo de incidencia
        /// </summary>
        private void Agregar()
        {
            try 
            {
                Entidades.TipoIncidencia newTipoIncidencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.TipoIncidencia();
                newTipoIncidencia.ClaveSistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
                newTipoIncidencia.Descripcion = this.saiTxtDescripcion.Text;
                Mappers.TipoIncidenciaMapper.Instance().Insert(newTipoIncidencia);
                //this.gvTipoIncidencias.CurrentRow.Selected = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }

        /// <summary>
        /// Metodo para Actualizar un Tipo de Incidencia
        /// </summary>
        private void Modificar()
        {
            try 
            {
                int rowSelected = this.gvTipoIncidencias.CurrentCellAddress.Y;
                
                int clave = Convert.ToInt32(this.gvTipoIncidencias.Rows[rowSelected].Cells["Clave"].Value);
                Entidades.TipoIncidencia updTipoIncidencia = new Entidades.TipoIncidencia(clave);
                updTipoIncidencia.ClaveSistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
                updTipoIncidencia.Descripcion = Convert.ToString(this.saiTxtDescripcion.Text);

                Mappers.TipoIncidenciaMapper.Instance().Save(updTipoIncidencia);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }

        /// <summary>
        /// Metodo para eliminar un Tipo de Incidencia
        /// </summary>
        private void Eliminar()
        {
            try 
            {
                int rowSelected = this.gvTipoIncidencias.CurrentCellAddress.Y;
                if (rowSelected > -1)
                {
                    Mappers.TipoIncidenciaMapper.Instance().Delete(Convert.ToInt32(this.gvTipoIncidencias.Rows[rowSelected].Cells["Clave"].Value));
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias"); }
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool abc = this.saiTxtDescripcion.BlnFueValido;
            if (SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox1))
            {
                this.Agregar();
                this.LlenarGrid();
            }
            this.Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox1))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.btnModificar.Enabled = false;
            //this.btnAgregar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Tipo de Incidencia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
