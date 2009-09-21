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

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmColonias : SAIFrmBase
    {
        public frmColonias()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llena los datos correspondientes a cada control
        /// </summary>
        private void frmColonias_Load(object sender, EventArgs e)
        {
            this.LlenarEstado();
            //this.LlenarMunicipio();
            this.LlenarGrid();
            this.LlenarLocalidad();
            this.LlenarCodigoPostal();
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
                    this.ddlEstado.DataSource = Mappers.EstadoMapper.Instance().GetAll();
                    this.ddlEstado.DisplayMember = "Nombre";
                    this.ddlEstado.ValueMember = "Clave";
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
        /// Llena el combobox de municipio dependiendo de la localidad seleccionada
        /// </summary>
        /// <param name="idlocalidad">Id Localidad</param>
        private void LlenarMunicipio(int idlocalidad)
        {
            try
            {
                try
                {
                    Entidades.Localidad localidad = Mappers.LocalidadMapper.Instance().GetOne(idlocalidad);
                    Entidades.Municipio municipio = Mappers.MunicipioMapper.Instance().GetOne(localidad.ClaveMunicipio);
                    Entidades.MunicipioList municipios = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.MunicipioList();
                    municipios.Add(municipio);
                    this.ddlMunicipio.DataSource = municipios;
                    this.ddlMunicipio.DisplayMember = "Nombre";
                    this.ddlMunicipio.ValueMember = "Clave";
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
        /// Llena el Datagrid con los datos del catalogo de Colonias
        /// </summary>
        private void LlenarGrid()
        {
            try
            {
                DataTable catColonias = new DataTable("catColonias");
                try
                {
                    catColonias.Columns.Add(new DataColumn("ClaveCartografia", Type.GetType("System.Int32")));
                    catColonias.Columns.Add(new DataColumn("ClaveLocalidad", Type.GetType("System.Int32")));
                    catColonias.Columns.Add(new DataColumn("Localidad", Type.GetType("System.String")));
                    catColonias.Columns.Add(new DataColumn("Nombre", Type.GetType("System.String")));
                    catColonias.Columns.Add(new DataColumn("ClaveCodigo", Type.GetType("System.Int32")));
                    catColonias.Columns.Add(new DataColumn("CodigoPostal", Type.GetType("System.Int32")));

                    Entidades.ColoniaList lstColonias = Mappers.ColoniaMapper.Instance().GetAll();

                    foreach (Entidades.Colonia colonia in lstColonias)
                    {
                        object[] registro = new object[]
                                                {
                                                    colonia.Clave, colonia.ClaveLocalidad,
                                                    Mappers.LocalidadMapper.Instance().GetOne(colonia.ClaveLocalidad).
                                                        Nombre, colonia.Nombre,
                                                    colonia.ClaveCodigoPostal,
                                                    Mappers.CodigoPostalMapper.Instance().GetOne(
                                                        colonia.ClaveCodigoPostal.Value).Valor
                                                };
                        catColonias.Rows.Add(registro);
                    }

                    this.gvColonias.DataSource = catColonias;
                    //this.gvColonias.Columns["Clave"].Visible = false;
                    this.gvColonias.Columns["ClaveLocalidad"].Visible = false;
                    this.gvColonias.Columns["ClaveCodigo"].Visible = false;
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
        /// Llena el combobox de Localidades
        /// </summary>
        private void LlenarLocalidad()
        {
            try
            {
                this.ddlLocalidad.DataSource = Mappers.LocalidadMapper.Instance().GetAll();
                this.ddlLocalidad.DisplayMember = "Nombre";
                this.ddlLocalidad.ValueMember = "Clave";
            }
            catch
            {
            }
        }

        /// <summary>
        /// Llena el combobox de Codigo Postal
        /// </summary>
        private void LlenarCodigoPostal()
        {
            this.ddlCodigoPostal.Items.Clear();
            try
            {
                try
                {
                    this.ddlCodigoPostal.Items.Add(new Utilerias.ComboItem("000", "Otro..."));
                    Entidades.CodigoPostalList lstCodigoPostal = Mappers.CodigoPostalMapper.Instance().GetAll();
                    foreach (Entidades.CodigoPostal cp in lstCodigoPostal)
                    {
                        this.ddlCodigoPostal.Items.Add(new Utilerias.ComboItem(cp.Clave, cp.Valor));
                    }

                    this.ddlCodigoPostal.ValueMember = "Valor";
                    this.ddlCodigoPostal.DisplayMember = "Descripcion";
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

        #region ABC

        /// <summary>
        /// Agrega una nueva Colonia
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.Colonia newColonia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Colonia();
                    newColonia.Clave = Convert.ToInt32(this.saiClave.Text);
                    newColonia.ClaveLocalidad = Convert.ToInt32(this.ddlLocalidad.SelectedValue);
                    newColonia.Nombre = this.saiTxtNombre.Text;
                    if (Convert.ToString(ObtenerValor()) == "000")
                    {
                        newColonia.ClaveCodigoPostal = this.ObtenerCodigoPostal(this.txtCP.Text);
                    }
                    else
                    {
                        newColonia.ClaveCodigoPostal = Convert.ToInt32(this.ObtenerValor());
                    }

                    Mappers.ColoniaMapper.Instance().Insert(newColonia);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego la Colonia: " + newColonia.Nombre;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Colonias";
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
        /// Modifica datos de una Colonia
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    int selectedColonia =
                        Convert.ToInt32(
                            this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value);
                    Entidades.Colonia updColonia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Colonia(selectedColonia);
                    updColonia.Clave = Convert.ToInt32(this.saiClave.Text);
                    updColonia.ClaveLocalidad = Convert.ToInt32(this.ddlLocalidad.SelectedValue);
                    updColonia.Nombre = this.saiTxtNombre.Text;

                    if (Convert.ToString(ObtenerValor()) == "000")
                    {
                        updColonia.ClaveCodigoPostal = this.ObtenerCodigoPostal(this.txtCP.Text);
                    }
                    else
                    {
                        updColonia.ClaveCodigoPostal = Convert.ToInt32(this.ObtenerValor());
                    }

                    Mappers.ColoniaMapper.Instance().Save(updColonia);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se modifico la Colonia: " + updColonia.Nombre;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Colonias";
                    bitacora.Operacion = "UPDATE";
                    bitacora.ValorActual = this.saiTxtNombre.Text;
                    bitacora.ValorAnterior =
                        Convert.ToString(this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Nombre"].Value);
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
        /// Elimina una colonia existente
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    Mappers.ColoniaMapper.Instance().Delete(
                        Convert.ToInt32(
                            this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value));

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se elimino la colonia: " +
                                           Convert.ToString(
                                               this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Nombre"].
                                                   Value);
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Colonias";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                    bitacora.Operacion = "DELETE";

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
        /// Limpia los controles del formulario de Colonias
        /// </summary>
        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvColonias.Rows)
            {
                row.Selected = false;
            }
            this.saiClave.Text = string.Empty;
            this.ddlCodigoPostal.SelectedIndex = -1;
            this.ddlLocalidad.SelectedIndex = -1;
            this.saiTxtNombre.Text = string.Empty;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Visible = false;
            this.btnAgregar.Enabled = true;
        }

        #endregion

        /// <summary>
        /// Obtiene el inidce dle registro seleccionado
        /// </summary>
        /// <returns>Inidce</returns>
        private int ObtenerIndiceSeleccionado()
        {
            return this.gvColonias.CurrentCellAddress.Y;
        }

        /// <summary>
        /// Llama el metodo Limpiar
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Cierra la ventana de Colonias
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Pregunta al usuario si se va eliminar el aColonia seleccionada
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Esta seguro de eliminar la Colonia?", "Eliminar", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Valida datos obligatorios y llama metodo agregar, Actualiza Datagrid
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
            {
                this.Agregar();
                this.LlenarGrid();
                this.LlenarCodigoPostal();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Valida campos requeridos y llama metodo modificar, Actualiza Datagrid
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
            {
                this.Modificar();
                this.LlenarGrid();
                this.LlenarCodigoPostal();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Obtiene datos de una colonia seleccionada
        /// </summary>
        private void gvColonias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.ObtenerIndiceSeleccionado() > -1)
                    {
                        this.saiClave.Text =
                            Convert.ToString(
                                this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCartografia"].Value);
                        this.saiTxtNombre.Text =
                            Convert.ToString(
                                this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["Nombre"].Value);
                        this.SeleccionarComboItem(
                            Convert.ToInt32(
                                this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveCodigo"].Value));
                        this.ddlLocalidad.SelectedValue =
                            this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveLocalidad"].Value;
                        this.LlenarMunicipio(
                            Convert.ToInt32(
                                this.gvColonias.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveLocalidad"].Value));
                        this.btnModificar.Enabled = true;
                        this.btnEliminar.Visible = true;
                        this.btnAgregar.Enabled = false;
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
        /// Muestra control para capturar nuevo CP, si la opcion seleccionada es Otro...
        /// </summary>
        private void ddlCodigoPostal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(this.ObtenerValor()) == "000")
            {
                this.txtCP.Visible = true;
                this.lblOtro.Visible = true;
            }
            else
            {
                this.txtCP.Visible = false;
                this.lblOtro.Visible = false;
            }
        }

        /// <summary>
        /// Obtiene valor del Codigo postal seleccionado
        /// </summary>
        /// <returns></returns>
        private object ObtenerValor()
        {
            if (this.ddlCodigoPostal.SelectedItem != null)
                return ((Utilerias.ComboItem) this.ddlCodigoPostal.SelectedItem).Valor;
            else
                return 0;
        }

        /// <summary>
        /// Selecciona un elemento del Combobox
        /// </summary>
        /// <param name="Value">Selecciona un elemento del Combobox de Codigp Postal</param>
        private void SeleccionarComboItem(int Value)
        {
            foreach (Utilerias.ComboItem item in this.ddlCodigoPostal.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.ddlCodigoPostal.SelectedItem = item;
                    break;
                }
            }
        }

        /// <summary>
        /// Obtiene la clave del codigo postal, si no existe el cp se agrega al catalogo
        /// </summary>
        /// <param name="cp">Especifica el cp que no esta en la lista</param>
        /// <returns>Valor(Clave) del CP seleccionado </returns>
        private int ObtenerCodigoPostal(string cp)
        {
            try
            {
                try
                {
                    bool existe = false;
                    int max = 0;
                    Entidades.CodigoPostalList lstCodigoPostal = Mappers.CodigoPostalMapper.Instance().GetAll();
                    foreach (Entidades.CodigoPostal codigoPostal in lstCodigoPostal)
                    {
                        if (codigoPostal.Valor == cp)
                        {
                            existe = true;
                            max = codigoPostal.Clave;
                            break;
                        }

                        if (codigoPostal.Clave > max)
                            max = codigoPostal.Clave;
                    }

                    if (!existe) //Si no existe CP en el catalogo loa grega
                    {
                        Entidades.CodigoPostal newCP = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.CodigoPostal();
                        newCP.Clave = max + 1;
                            //Genera id para el codigo postal, [se hace asi de esta forma porque no se establecio un identity]
                        newCP.Valor = cp;
                        Mappers.CodigoPostalMapper.Instance().Insert(newCP);

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se agrego el Codigo Postal: " + newCP.Valor;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Codigo Postal";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "INSERT";

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);

                        return newCP.Clave;
                    }
                    return max;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
            return 0;
        }

        /// <summary>
        /// Valida que solo acepte digitos
        /// </summary>
        private void saiClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}