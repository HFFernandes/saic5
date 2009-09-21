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

        /// <summary>
        /// Carga los catalogos de Municipio, corporaciones y estado, asi mismo carga las unidades en el grid
        /// </summary>
        private void frmUnidades_Load(object sender, EventArgs e)
        {
            this.LlenarEstado();
            this.LlenarMunicipio();
            this.ddlEstado.SelectedIndex = 0;

            SAIBarraEstado.SizingGrip = false;
            this.LlenarGrid();
            this.LlenarCorporaciones();
        }

        /// <summary>
        /// Llena el combobox de Corporaciones
        /// </summary>
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
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Llena el combobox de Estado (Solo Tlaxcala)
        /// </summary>
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
                    this.ddlEstado.DisplayMember = "Descripcion";
                    this.ddlEstado.ValueMember = "Valor";
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
        /// Llena el combobox de municipios
        /// </summary>
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
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Obtiene el valor del elemento seleccionado de un combobox
        /// </summary>
        /// <param name="comboBox">Combobox del cual se requiere el valor</param>
        /// <returns>Objeto con el valor</returns>
        private object ObtieneValor(ComboBox comboBox)
        {
            return ((ComboItem) comboBox.Items[comboBox.SelectedIndex]).Valor;
        }

        /// <summary>
        /// Obtiene la descripcion de un elemento seleccionado
        /// </summary>
        /// <param name="comboBox">Combobox del cual se requiere la descripcion</param>
        /// <returns>Objeto que representa la descripcion</returns>
        private string ObtieneDescripcion(ComboBox comboBox)
        {
            return ((ComboItem) comboBox.Items[comboBox.SelectedIndex]).Descripcion;
        }

        /// <summary>
        /// Selecciona un elemento de un Combobox que concuerde ocn el valor que recibe
        /// </summary>
        /// <param name="Value">Valor a seleccionar</param>
        /// <param name="comboBox">Combobox al que se seleccionara un elemento</param>
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
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// Llena el DataGrid con el catalogo de Ubicaciones
        /// </summary>
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
                    catUbicacion.Columns.Add(new DataColumn("ClaveMunicipio", Type.GetType("System.Int32")));
                    //Se agrega esta columna para mostrar la descripcion del MUnicipio
                    catUbicacion.Columns.Add(new DataColumn("Municipio", Type.GetType("System.String")));

                    Entidades.UnidadList lstUnidades = Mappers.UnidadMapper.Instance().GetAll();

                    foreach (Entidades.Unidad unidad in lstUnidades)
                    {
                        object[] registro = new object[]
                                                {
                                                    unidad.Clave, unidad.Codigo, unidad.ClaveCorporacion,
                                                    Mappers.CorporacionMapper.Instance().GetOne(unidad.ClaveCorporacion)
                                                        .Descripcion,
                                                    unidad.Activo, unidad.ClaveMunicipio,
                                                    Mappers.MunicipioMapper.Instance().GetOne(
                                                        unidad.ClaveMunicipio.Value).Nombre
                                                };
                        catUbicacion.Rows.Add(registro);
                    }

                    this.gvUnidades.DataSource = catUbicacion;
                    this.gvUnidades.Columns["Clave"].Visible = false;
                    this.gvUnidades.Columns["ClaveCorporacion"].Visible = false;
                    this.gvUnidades.Columns["ClaveMunicipio"].Visible = false;
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
        /// Deselecciona el registro seleccionado del grid y limpialos controles
        /// </summary>
        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvUnidades.Rows)
            {
                row.Selected = false;
            }
            this.ddlCorporacion.SelectedIndex = -1;
            this.ddlMunicipio.SelectedIndex = -1;
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
                    Entidades.Unidad newUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Unidad();
                    //Entidades.ListaUnidades newUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ListaUnidades();
                    newUnidad.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporacion));
                        // Convert.ToInt32(this.ddlCorporacion.SelectedValue);
                    newUnidad.Codigo = saiTxtCodigo.Text;
                    newUnidad.Activo = this.chkActivo.Checked;
                    newUnidad.ClaveMunicipio = Convert.ToInt32(this.ObtieneValor(this.ddlMunicipio));

                    Mappers.UnidadMapper.Instance().Insert(newUnidad);

                    //Agrega en bitacora la operacion realizada
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
            {
            } //this.SAIEtiquetaEstado.Text = ex.Message; }
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
                    Entidades.Unidad updUnidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Unidad(clave);
                    updUnidad.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporacion));
                    updUnidad.ClaveMunicipio = Convert.ToInt32(this.ObtieneValor(this.ddlMunicipio));
                    updUnidad.Codigo = this.saiTxtCodigo.Text;
                    updUnidad.Activo = this.chkActivo.Checked;

                    Mappers.UnidadMapper.Instance().Save(updUnidad);
                    //Agrega en bitacora la operacion realizada
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
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
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
                        Mappers.UnidadMapper.Instance().Delete(
                            Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["Clave"].Value));

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se elimino la Unidad: " +
                                               Convert.ToString(this.gvUnidades.Rows[selectedRow].Cells["Codigo"].Value);
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Unidades";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "DELETE";

                        Mappers.BitacoraMapper.Instance().Delete(bitacora);
                    }
                    else
                    {
                        throw new SAIExcepcion("Seleccione la unidad que desea eliminar.");
                    }
                }
                catch (Exception)
                {
                    throw new SAIExcepcion("No puede eliminar la Unidad porque esta Asociada.");
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        #endregion

        /// <summary>
        /// Valida si hay corporacion seleccionada y municipio para poder modificar
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlCorporacion.SelectedIndex > -1)
                {
                    if (this.ddlMunicipio.SelectedIndex > -1)
                    {
                        this.Modificar();
                        this.LlenarGrid();
                        this.Limpiar();
                    }
                    else
                    {
                        throw new SAIExcepcion("Seleccione un Municipio.");
                    }
                }
                else
                {
                    throw new SAIExcepcion("Seleccione una Coroporacion.");
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Valida que haya corporacion seleccionada y municipio para poder agregar
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlCorporacion.SelectedIndex > -1)
                {
                    if (this.ddlMunicipio.SelectedIndex > -1)
                    {
                        this.Agregar();
                        this.LlenarGrid();
                        this.Limpiar();
                    }
                    else
                    {
                        throw new SAIExcepcion("Seleccione un Municipio.");
                    }
                }
                else
                {
                    throw new SAIExcepcion("Seleccione una Coroporacion.");
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Pregunta al usuario si desea eliminar la unidad seleccionada
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Desea eliminar la Unidad?", "Eliminar", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Cierra la vantana de Unidades
        /// </summary>
        private void bnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que obtiene los datos para su modificacion
        /// </summary>
        private void gvUnidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int selectedRow = this.gvUnidades.CurrentCellAddress.Y;
                    if (selectedRow > -1)
                    {
                        this.saiTxtCodigo.Text =
                            Convert.ToString(this.gvUnidades.Rows[selectedRow].Cells["Codigo"].Value);
                        //this.ddlCorporacion.SelectedValue = this.gvUnidades.Rows[selectedRow].Cells["ClaveCorporacion"].Value;
                        this.SeleccionarComboItem(
                            Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["ClaveCorporacion"].Value),
                            this.ddlCorporacion);
                        this.SeleccionarComboItem(
                            Convert.ToInt32(this.gvUnidades.Rows[selectedRow].Cells["ClaveMunicipio"].Value),
                            this.ddlMunicipio);
                        this.chkActivo.Checked =
                            Convert.ToBoolean(this.gvUnidades.Rows[selectedRow].Cells["Activo"].Value);
                        this.btnEliminar.Visible = true;
                        this.btnModificar.Enabled = true;
                        btnAgregar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            } //this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        /// <summary>
        /// Limpia los controles
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}