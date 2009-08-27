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
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Administracion.Utilerias;
using System.Configuration;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmCorporaciones : SAIFrmBase
    {
        public frmCorporaciones()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llenado de Catalogo de corporaciones en grid y sistemas en combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCorporaciones_Load(object sender, EventArgs e)
        {
            SAIBarraEstado.SizingGrip = false;
            this.LlenarSistemas();
            this.LlenarGrid();
            this.Limpiar();
        }

        /// <summary>
        /// Llenar el DataGrid con el catalogo de Corporaciones
        /// </summary>
        private void LlenarGrid()
        {
            DataTable catCorporaciones = new DataTable("CatCorporaciones");
            try
            {
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
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Limpia los controles del formulario de Corporaciones
        /// </summary>
        private void Limpiar()
        {
            try
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
                    this.btnAgregar.Enabled = true;
                    this.saiTxtZn.Text = string.Empty;
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Llena el catalogo de sistemas en el combobox
        /// </summary>
        private void LlenarSistemas()
        {
            try
            {
                try
                {
                    Objetos.SistemaObjectList lstSistemas = Mappers.SistemaMapper.Instance().GetAll();

                    foreach (Objetos.SistemaObject sistemas in lstSistemas)
                    {
                        if (sistemas.Descripcion != "ADM")
                        {
                            this.ddlSistema.Items.Add(new ComboItem(sistemas.Clave, sistemas.Descripcion));
                            this.ddlSistema.DisplayMember = "Descripcion";
                            this.ddlSistema.ValueMember = "Value";
                        }
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Obtiene el valor de un elemento seleccionado en el combobox
        /// </summary>
        /// <param name="indice">indice del elemento seleccionado</param>
        /// <returns></returns>
        private object ObtieneValor(int indice)
        {
            return ((ComboItem)this.ddlSistema.Items[indice]).Valor;
        }

        /// <summary>
        /// Obtiene la descripcion del elemento seleccionado
        /// </summary>
        /// <param name="indice">indice del elemento a obtener la descripcion</param>
        /// <returns></returns>
        private string ObtieneDescripcion(int indice)
        {
            return ((ComboItem)this.ddlSistema.Items[indice]).Descripcion;
        }

        /// <summary>
        /// Seleccionar un elemento dle combobox
        /// </summary>
        /// <param name="Value">valor del elemento a selaccionar</param>
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

        #region ABC
        /// <summary>
            /// Metodo que Agrega un nuevo registro
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
                    {
                        Entidades.Corporacion newCorporacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Corporacion();
                        newCorporacion.ClaveSistema = Convert.ToInt32(this.ObtieneValor(this.ddlSistema.SelectedIndex)); // Convert.ToInt32(this.ObtieneValor(this.ddlSistema.SelectedIndex)); // Convert.ToInt32(this.ddlSistema.SelectedValue);
                        newCorporacion.Descripcion = this.saiTxtDescripcion.Text;
                        newCorporacion.Activo = this.chkActivo.Checked;
                        newCorporacion.UnidadesVirtuales = this.chkUnidadVirtual.Checked;
                        newCorporacion.Zn = this.saiTxtZn.Text;

                        Mappers.CorporacionMapper.Instance().Insert(newCorporacion);

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se agrego la corporacion: " + newCorporacion.Descripcion;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Corporaciones";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "INSERT";

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Metodo que Actualiza los datos de un registro
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    int rowSelected = this.gvCorporaciones.CurrentCellAddress.Y;
                    if (rowSelected > -1)
                    {
                        int clave = Convert.ToInt32(this.gvCorporaciones.Rows[rowSelected].Cells["Clave"].Value);
                        Entidades.Corporacion updCorporacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Corporacion(clave);
                        updCorporacion.ClaveSistema = Convert.ToInt32(this.ObtieneValor(this.ddlSistema.SelectedIndex)); // Convert.ToInt32(this.ddlSistema.SelectedValue);
                        updCorporacion.Descripcion = this.saiTxtDescripcion.Text;
                        updCorporacion.UnidadesVirtuales = this.chkUnidadVirtual.Checked;
                        updCorporacion.Activo = this.chkActivo.Checked;
                        updCorporacion.Zn = this.saiTxtZn.Text;
                        Mappers.CorporacionMapper.Instance().Save(updCorporacion);

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se modifico la corporacion: " + updCorporacion.Descripcion;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Corporaciones";
                        bitacora.Operacion = "UPDATE";
                        bitacora.ValorActual = "Todos los campos";
                        bitacora.ValorAnterior = "Todos los campos";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Metodo que elimina un registro del catalogo Corporaciones
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    int selectedRow = this.gvCorporaciones.CurrentCellAddress.Y;
                    if (selectedRow > -1)
                    {
                        Mappers.CorporacionMapper.Instance().Delete(Convert.ToInt32(this.gvCorporaciones.Rows[selectedRow].Cells["Clave"].Value));
                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se elimino la corporacion: " + Convert.ToString(this.gvCorporaciones.Rows[selectedRow].Cells["Descripcion"].Value);
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Corporaciones";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "DELETE";

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);
                    }
                }                
                catch
                { throw new SAIExcepcion("No puede eliminar la corporcaion porque esta asociada."); }
            }
            catch (SAIExcepcion) { }
        
        }
        #endregion

        /// <summary>
        /// Llena los campos cuando se selecciona una corporacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvCorporaciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int selectedRow = this.gvCorporaciones.CurrentCellAddress.Y;
                    if (selectedRow > -1)
                    {
                        this.saiTxtDescripcion.Text = Convert.ToString(this.gvCorporaciones.Rows[selectedRow].Cells["Descripcion"].Value);
                        this.SeleccionarComboItem(Convert.ToInt32(this.gvCorporaciones.Rows[selectedRow].Cells["ClaveSistema"].Value));
                        this.chkActivo.Checked = Convert.ToBoolean(this.gvCorporaciones.Rows[selectedRow].Cells["Activo"].Value);
                        this.chkUnidadVirtual.Checked = Convert.ToBoolean(this.gvCorporaciones.Rows[selectedRow].Cells["UnidadesVirtuales"].Value);
                        this.saiTxtZn.Text = Convert.ToString(this.gvCorporaciones.Rows[selectedRow].Cells["Zn"].Value);
                        this.btnEliminar.Visible = true;
                        this.btnModificar.Enabled = true;
                        this.btnAgregar.Enabled = false;
                        this.btnLimpiar.Enabled = true;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Modifica los campos de una corporacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Valida que se haya seleccionado un sistema para poder agregar una nueva corporacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlSistema.SelectedIndex > -1)
                {
                    if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
                    {
                        this.Agregar();
                        this.LlenarGrid();
                        this.Limpiar();
                    }
                }
                else
                {
                    throw new SAIExcepcion("Seleccione un sistema");
                }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Valida si se va eliminar la corporacion seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Eliminar la corporaciòn?", "Sistema de Administracion de Incidencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Cierra la vantana de Corporaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Limpia controles de captura de la ventana de corporaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
