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
using System.Configuration;
using BSD.C4.Tlaxcala.Sai.Administracion.Utilerias;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmOrganizacion : SAIFrmBase
    {
        public frmOrganizacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llama los metodos correspondientes al llenado del Datagrid y llenado de las Clasificaciones
        /// </summary>
        private void frmOrganizacion_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();
            this.LlenarClasificacion();
        }

        /// <summary>
        /// Llena el combobox de las clasificaciones
        /// </summary>
        private void LlenarClasificacion()
        {
            try
            {
                Entidades.ClasificacionOrganizacionList lstClasificacionOrg =
                    Mappers.ClasificacionOrganizacionMapper.Instance().GetAll();
                //Valida que el catalogo de Clasificaciones no este vacio
                if (lstClasificacionOrg.Count == 0)
                {
                    throw new SAIExcepcion(
                        "No puede agregar o Modificar una Organizacion ya que el catalogo de Clasificaciones esta vacio, Agrege por lo menos una clasificación para las Organizaciones.");
                }
                foreach (Entidades.ClasificacionOrganizacion ClasificacionOrg in lstClasificacionOrg)
                {
                    this.saiDdlClasificacion.Items.Add(new ComboItem(ClasificacionOrg.Clave,
                                                                     ClasificacionOrg.Descripcion));
                }
                this.saiDdlClasificacion.DisplayMember = "Descripcion";
                this.saiDdlClasificacion.ValueMember = "Valor";
            }
            catch (SAIExcepcion)
            {
                //Deshabilita botones
                this.gvOrganizaciones.DataSource = null;
                this.Limpiar();
                this.btnLimpiar.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnModificar.Enabled = false;
                this.btnEliminar.Enabled = false;
                //this.Limpiar();
            }
        }

        /// <summary>
        /// Llena el Datagrid de Organizaciones
        /// </summary>
        private void LlenarGrid()
        {
            try
            {
                DataTable catOrganizacion = new DataTable("catOrganizacion");
                catOrganizacion.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                catOrganizacion.Columns.Add(new DataColumn("Nombre", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("Direccion", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("Telefono", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("Fax", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("Email", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("DireccionWeb", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("ClaveClasificacion", Type.GetType("System.Int32")));
                catOrganizacion.Columns.Add(new DataColumn("Clasificacion", Type.GetType("System.String")));

                Entidades.OrganizacionList lstOrganizacion = Mappers.OrganizacionMapper.Instance().GetAll();

                foreach (Entidades.Organizacion organizacion in lstOrganizacion)
                {
                    object[] registro = new object[]
                                            {
                                                organizacion.Clave, organizacion.Nombre, organizacion.Dirección,
                                                organizacion.Telefono, organizacion.Fax, organizacion.Email,
                                                organizacion.DireccionWeb,
                                                organizacion.ClaveClasificacion,
                                                Mappers.ClasificacionOrganizacionMapper.Instance().GetOne(
                                                    organizacion.ClaveClasificacion).Descripcion
                                            };
                    catOrganizacion.Rows.Add(registro);
                }
                this.gvOrganizaciones.DataSource = catOrganizacion;
                this.gvOrganizaciones.Columns["Clave"].Visible = false;
                this.gvOrganizaciones.Columns["ClaveClasificacion"].Visible = false;
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Agrega una nueva Organizacion
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.Organizacion newOrganizacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Organizacion();
                    newOrganizacion.ClaveClasificacion =
                        Convert.ToInt32(this.ObtieneValor(this.saiDdlClasificacion.SelectedIndex));
                    newOrganizacion.Dirección = this.saiTxtDireccion.Text;
                    newOrganizacion.DireccionWeb = this.saiTxtDireccionWeb.Text;
                    newOrganizacion.Email = this.saiTxtEmail.Text;
                    newOrganizacion.Fax = this.saiTxtFax.Text;
                    newOrganizacion.Nombre = this.saiTxtNombre.Text;
                    newOrganizacion.Telefono = this.saiTxtTelefono.Text;

                    Mappers.OrganizacionMapper.Instance().Insert(newOrganizacion);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego la Organizacion: " + newOrganizacion.Nombre;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Organizaciones";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                    bitacora.Operacion = "INSERT";

                    Mappers.BitacoraMapper.Instance().Insert(bitacora);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Modifica una Organizacion existente
        /// </summary>
        private void Modificar()
        {
            try
            {
                Entidades.Organizacion updOrganizacion =
                    Mappers.OrganizacionMapper.Instance().GetOne(
                        Convert.ToInt32(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
                updOrganizacion.ClaveClasificacion =
                    Convert.ToInt32(this.ObtieneValor(this.saiDdlClasificacion.SelectedIndex));
                updOrganizacion.Dirección = this.saiTxtDireccion.Text;
                updOrganizacion.DireccionWeb = this.saiTxtDireccionWeb.Text;
                updOrganizacion.Email = this.saiTxtEmail.Text;
                updOrganizacion.Fax = this.saiTxtFax.Text;
                updOrganizacion.Nombre = this.saiTxtNombre.Text;
                updOrganizacion.Telefono = this.saiTxtTelefono.Text;

                Mappers.OrganizacionMapper.Instance().Save(updOrganizacion);

                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se modifico la Organizacion: " + updOrganizacion.Nombre;
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Organizaciones";
                bitacora.Operacion = "UPDATE";
                bitacora.ValorActual = saiTxtNombre.Text + ", " + this.saiTxtDireccion.Text;
                bitacora.ValorAnterior =
                    Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Nombre"].Value);
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];

                Mappers.BitacoraMapper.Instance().Insert(bitacora);
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Elimina una organizacion
        /// </summary>
        private void Eliminar()
        {
            try
            {
                Mappers.OrganizacionMapper.Instance().Delete(
                    Convert.ToInt32(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));

                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se elimino la Organizacion: " +
                                       Convert.ToString(
                                           this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Nombre"].
                                               Value);
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Organizaciones";
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                bitacora.Operacion = "DELETE";

                Mappers.BitacoraMapper.Instance().Insert(bitacora);
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Limpia los controles del formulario de Organizaciones
        /// </summary>
        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvOrganizaciones.Rows)
            {
                row.Selected = false;
            }

            this.btnAgregar.Enabled = true;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Visible = false;

            this.saiTxtDireccion.Text = string.Empty;
            this.saiTxtDireccionWeb.Text = string.Empty;
            this.saiTxtEmail.Text = string.Empty;
            this.saiTxtFax.Text = string.Empty;
            this.saiTxtNombre.Text = string.Empty;
            this.saiTxtTelefono.Text = string.Empty;
            this.saiDdlClasificacion.SelectedIndex = -1;
        }

        /// <summary>
        /// Obtiene el indice del registro seleccionado
        /// </summary>
        /// <returns>Indice</returns>
        private int ObtieneIndiceSeleccionado()
        {
            return this.gvOrganizaciones.CurrentCellAddress.Y;
        }

        /// <summary>
        /// Cierra la ventana de Organizaciones
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Llama el metodo Eliminar, Actualiza el Datagrid
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Esta seguro de Eliminar la Organización?", "Eliminar", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Valida campos obligatorios y llama el metodo Agregar, Actualiza el Datagrid
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Valida campos obligatorios y llama el metodo Modificar, Actualiza el Datagrid
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosGenerales))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// LLama el metodo Limpiar
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Obtiene los datos de la organizacion seleccionada para su modificacion
        /// </summary>
        private void gvOrganizaciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtieneIndiceSeleccionado() > -1)
                {
                    this.saiTxtNombre.Text =
                        Convert.ToString(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Nombre"].Value);
                    this.saiTxtDireccion.Text =
                        Convert.ToString(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Direccion"].Value);
                    this.saiTxtTelefono.Text =
                        Convert.ToString(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Telefono"].Value);
                    this.saiTxtFax.Text =
                        Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Fax"].Value);
                    this.saiTxtEmail.Text =
                        Convert.ToString(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Email"].Value);
                    this.saiTxtDireccionWeb.Text =
                        Convert.ToString(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["DireccionWeb"].Value);
                    this.SeleccionarComboItem(
                        Convert.ToInt32(
                            this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["ClaveClasificacion"].
                                Value));
                    //this.saiDdlClasificacion.SelectedValue();
                    this.btnAgregar.Enabled = false;
                    this.btnEliminar.Visible = true;
                    this.btnModificar.Enabled = true;
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Obtiene el valor del elemento seleccionado de un ComoboBox
        /// </summary>
        /// <param name="indice">Indice del elemento</param>
        /// <returns>Objeto que representa el Valor</returns>
        private object ObtieneValor(int indice)
        {
            return ((ComboItem) this.saiDdlClasificacion.Items[indice]).Valor;
        }

        /// <summary>
        /// Obtiene la descripcion de un elemento del Combobox
        /// </summary>
        /// <param name="indice">Indice del elemento</param>
        /// <returns>Objeto que representa la Descripcion</returns>
        private string ObtieneDescripcion(int indice)
        {
            return ((ComboItem) this.saiDdlClasificacion.Items[indice]).Descripcion;
        }

        /// <summary>
        /// Selecciona un elemento del ComboBox Clasificación
        /// </summary>
        /// <param name="Value">Valor que representa el elemento a seleccionar</param>
        private void SeleccionarComboItem(int Value)
        {
            foreach (ComboItem item in this.saiDdlClasificacion.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.saiDdlClasificacion.SelectedItem = item;
                    break;
                }
                else
                {
                    this.saiDdlClasificacion.SelectedIndex = -1;
                }
            }
        }
    }
}