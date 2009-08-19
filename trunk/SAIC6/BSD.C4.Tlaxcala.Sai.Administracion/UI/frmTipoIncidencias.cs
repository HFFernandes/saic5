using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Administracion.Utilerias;
using System.Configuration;

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
            try
            {
                DataTable catTipoIncidencia = new DataTable();

                try
                {
                    catTipoIncidencia.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                    catTipoIncidencia.Columns.Add(new DataColumn("Descripcion", Type.GetType("System.String")));
                    catTipoIncidencia.Columns.Add(new DataColumn("ClaveSistema", Type.GetType("System.Int32")));
                    catTipoIncidencia.Columns.Add(new DataColumn("Sistema", Type.GetType("System.String")));
                    catTipoIncidencia.Columns.Add(new DataColumn("ClaveOperacion", Type.GetType("System.String")));
                    catTipoIncidencia.Columns.Add(new DataColumn("Prioridad", Type.GetType("System.Int32")));
                    Entidades.TipoIncidenciaList lstTipoIns = Mappers.TipoIncidenciaMapper.Instance().GetAll();

                    foreach (Entidades.TipoIncidencia tipoIncidencia in lstTipoIns)
                    {
                        object[] registro = new object[] { tipoIncidencia.Clave, tipoIncidencia.Descripcion, 
                            tipoIncidencia.ClaveSistema, Mappers.SistemaMapper.Instance().GetOne(tipoIncidencia.ClaveSistema).Descripcion,
                            tipoIncidencia.ClaveOperacion, tipoIncidencia.Prioridad};
                        catTipoIncidencia.Rows.Add(registro);
                    }

                    this.gvTipoIncidencias.DataSource = catTipoIncidencia;
                    this.gvTipoIncidencias.Columns["Clave"].Visible = false;
                    this.gvTipoIncidencias.Columns["ClaveSistema"].Visible = false;
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch(SAIExcepcion)
            { }
        }

        private void LlenarSistemas()
        {
            try
            {
                try
                {
                    Objetos.SistemaObjectList lstSistema = Mappers.SistemaMapper.Instance().GetAll();

                    foreach (Objetos.SistemaObject sistema in lstSistema)
                    {
                        if(sistema.Descripcion != "ADM")
                            this.ddlSistema.Items.Add(new ComboItem(sistema.Clave, sistema.Descripcion)); 
                    }
                    
                    this.ddlSistema.DisplayMember = "Descripcion";
                    this.ddlSistema.ValueMember = "Clave";
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
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
                try
                {
                    //int selectedRow = this.gvTipoIncidencias.CurrentRow.Index;
                    int selectedRow = this.gvTipoIncidencias.CurrentCellAddress.Y;
                    if (selectedRow > -1)
                    {
                        this.btnModificar.Enabled = true;
                        this.saiTxtDescripcion.Text = Convert.ToString(this.gvTipoIncidencias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
                        this.SeleccionarComboItem(Convert.ToInt32(this.gvTipoIncidencias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveSistema"].Value));
                        //this.ddlSistema.SelectedValue = this.gvTipoIncidencias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveSistema"].Value;
                        this.txtClaveoperacion.Text = Convert.ToString(this.gvTipoIncidencias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveOperacion"].Value);
                        this.ddlPrioridad.SelectedText = Convert.ToString(this.gvTipoIncidencias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Prioridad"].Value);
                        
                        this.btnAgregar.Enabled = false;
                        this.btnEliminar.Visible = true;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
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
            this.ddlSistema.SelectedIndex = -1;
            this.txtClaveoperacion.Text = string.Empty;
            this.ddlPrioridad.SelectedIndex = 0;
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
                try
                {
                    Entidades.TipoIncidencia newTipoIncidencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.TipoIncidencia();
                    //newTipoIncidencia.ClaveSistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
                    newTipoIncidencia.ClaveSistema = Convert.ToInt32(this.ObtieneValor(this.ddlSistema.SelectedIndex));
                    newTipoIncidencia.Descripcion = this.saiTxtDescripcion.Text;
                    newTipoIncidencia.ClaveOperacion = this.txtClaveoperacion.Text;
                    newTipoIncidencia.Prioridad = Convert.ToInt32(this.ddlPrioridad.SelectedItem);
                    Mappers.TipoIncidenciaMapper.Instance().Insert(newTipoIncidencia);

                    //this.gvTipoIncidencias.CurrentRow.Selected = false;

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego la incidencia: " + newTipoIncidencia.Descripcion;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Tipo Incidencias";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                    bitacora.Operacion = "INSERT";

                    Mappers.BitacoraMapper.Instance().Insert(bitacora);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Metodo para Actualizar un Tipo de Incidencia
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    int rowSelected = this.gvTipoIncidencias.CurrentCellAddress.Y;

                    int clave = Convert.ToInt32(this.gvTipoIncidencias.Rows[rowSelected].Cells["Clave"].Value);
                    Entidades.TipoIncidencia updTipoIncidencia = new Entidades.TipoIncidencia(clave);
                    updTipoIncidencia.ClaveSistema = Convert.ToInt32(this.ObtieneValor(this.ddlSistema.SelectedIndex));
                    //updTipoIncidencia.ClaveSistema = Convert.ToInt32(this.ddlSistema.SelectedValue);
                    updTipoIncidencia.Descripcion = Convert.ToString(this.saiTxtDescripcion.Text);
                    updTipoIncidencia.ClaveOperacion = this.txtClaveoperacion.Text;
                    updTipoIncidencia.Prioridad = Convert.ToInt32(this.ddlPrioridad.SelectedItem);

                    Mappers.TipoIncidenciaMapper.Instance().Save(updTipoIncidencia);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se modifico el Tipo de Incidencia: " + updTipoIncidencia.Descripcion;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Tipo Incidencias";
                    bitacora.Operacion = "UPDATE";
                    bitacora.ValorActual = this.saiTxtDescripcion.Text + ", " + this.txtClaveoperacion.Text;
                    bitacora.ValorAnterior = Convert.ToString(this.gvTipoIncidencias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
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
        /// Metodo para eliminar un Tipo de Incidencia
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    int rowSelected = this.gvTipoIncidencias.CurrentCellAddress.Y;
                    if (rowSelected > -1)
                    {
                        Mappers.TipoIncidenciaMapper.Instance().Delete(Convert.ToInt32(this.gvTipoIncidencias.Rows[rowSelected].Cells["Clave"].Value));

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se elimino el Tipo de Incidencia: " + Convert.ToString(this.gvTipoIncidencias.Rows[rowSelected].Cells["Descripcion"].Value);
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Tipo Incidencias";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "DELETE";

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
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

        private int ObtenerIndiceSeleccionado()
        {
            return this.gvTipoIncidencias.CurrentCellAddress.Y;
        }

        private object ObtieneValor(int indice)
        {
            return ((ComboItem)this.ddlSistema.Items[indice]).Valor;
        }

        private string ObtieneDescripcion(int indice)
        {
            return ((ComboItem)this.ddlSistema.Items[indice]).Descripcion;
        }

        private void SeleccionarComboItem(int Value)
        {
            foreach (ComboItem item in this.ddlSistema.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.ddlSistema.SelectedItem = item;
                    break;
                }
                else
                { this.ddlSistema.SelectedIndex = -1; }
            }
        }
    }
}
