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
    public partial class frmLocalidades : SAIFrmBase
    {
        public frmLocalidades()
        {
            InitializeComponent();
        }

        /// <summary>
        /// llena combobox y Datatgrid con los datos correspondientes a cada control
        /// </summary>
        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            this.LlenarMunicipios();
            this.LlenarEstados();
            this.LlenarGrid();
            this.Limpiar();
        }

        /// <summary>
        /// Llena el datatgrid con los datos del catalogo de Localidades
        /// </summary>
        private void LlenarGrid()
        {
            DataTable catLocalidades = new DataTable("catLocalidades");

            try
            {
                catLocalidades.Columns.Add("Clave", Type.GetType("System.Int32"));
                catLocalidades.Columns.Add("ClaveMunicipio", Type.GetType("System.Int32"));
                catLocalidades.Columns.Add("Municipio", Type.GetType("System.String"));
                catLocalidades.Columns.Add("ClaveLocalidadCartografia", Type.GetType("System.Int32"));
                catLocalidades.Columns.Add("Localidad", Type.GetType("System.String"));

                Entidades.LocalidadList lstLocalidad = Mappers.LocalidadMapper.Instance().GetAll();

                foreach (Entidades.Localidad localidad in lstLocalidad)
                {
                    object[] registro = new object[]
                                            {
                                                localidad.Clave, localidad.ClaveMunicipio,
                                                Mappers.MunicipioMapper.Instance().GetOne(localidad.ClaveMunicipio).
                                                    Nombre, localidad.ClaveLocalidadCartografia, localidad.Nombre
                                            };
                    catLocalidades.Rows.Add(registro);
                }

                this.gvLocalidades.DataSource = catLocalidades;
                this.gvLocalidades.Columns["Clave"].Visible = false;
                this.gvLocalidades.Columns["ClaveMunicipio"].Visible = false;
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Llena el combobox de Estados
        /// </summary>
        private void LlenarEstados()
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
        /// Llena el combobox de Municipios
        /// </summary>
        private void LlenarMunicipios()
        {
            try
            {
                try
                {
                    this.ddlMunicipio.DataSource = Mappers.MunicipioMapper.Instance().GetAll();
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

        #region ABC

        /// <summary>
        /// Agrega una nueva Localidad
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.Localidad newLocalidad = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Localidad();
                    newLocalidad.Clave = this.txtClaveLocalidadCartografia.Text != string.Empty
                                             ? Convert.ToInt32(this.txtClaveLocalidadCartografia.Text)
                                             : 0;
                    newLocalidad.ClaveMunicipio = Convert.ToInt32(this.ddlMunicipio.SelectedValue);
                    newLocalidad.Nombre = this.saiTxtNombre.Text;
                    newLocalidad.ClaveLocalidadCartografia = this.txtClaveLocalidadCartografia.Text != string.Empty
                                                                 ? Convert.ToInt32(
                                                                       this.txtClaveLocalidadCartografia.Text)
                                                                 : 0;
                    Mappers.LocalidadMapper.Instance().Insert(newLocalidad);

                    //Agrega operacion a bitacora
                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego la Localidad: " + newLocalidad.Nombre;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Localidades";
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
        /// Modifica datos de un Localidad (Deshabilitado)
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    Entidades.Localidad updLocalidad =
                        new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Localidad(
                            Convert.ToInt32(
                                this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));
                    updLocalidad.Clave = this.txtClaveLocalidadCartografia.Text != string.Empty
                                             ? Convert.ToInt32(this.txtClaveLocalidadCartografia.Text)
                                             : 0;
                    updLocalidad.ClaveMunicipio = Convert.ToInt32(this.ddlMunicipio.SelectedValue);
                    updLocalidad.Nombre = this.saiTxtNombre.Text;
                    updLocalidad.ClaveLocalidadCartografia = this.txtClaveLocalidadCartografia.Text != string.Empty
                                                                 ? Convert.ToInt32(
                                                                       this.txtClaveLocalidadCartografia.Text)
                                                                 : 0;
                    Mappers.LocalidadMapper.Instance().Save(updLocalidad);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se modifico la Localidad: " + updLocalidad.Nombre;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Localidades";
                    bitacora.Operacion = "UPDATE";
                    bitacora.ValorActual = updLocalidad.Nombre;
                    bitacora.ValorAnterior =
                        Convert.ToString(
                            this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Localidad"].Value);
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
        /// Elimina una Localidad (Deshabilitado)
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    Mappers.LocalidadMapper.Instance().Delete(
                        Convert.ToInt32(this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se elimino la Localidad: " +
                                           Convert.ToString(
                                               this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells[
                                                   "Localidad"].Value);
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Localidades";
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
        /// Limpia los controles del fromulario de Localidades
        /// </summary>
        private void Limpiar()
        {
            foreach (DataGridViewRow row in this.gvLocalidades.Rows)
            {
                row.Selected = false;
            }

            this.txtClaveLocalidadCartografia.Text = string.Empty;
            this.ddlMunicipio.SelectedIndex = -1;
            this.ddlEstado.SelectedIndex = 0;
            this.saiTxtNombre.Text = string.Empty;
            this.btnAgregar.Enabled = true;
        }

        #endregion

        /// <summary>
        /// Obtiene el indice del registro seleccionado
        /// </summary>
        /// <returns>Indice</returns>
        private int ObtenerIndiceSeleccionado()
        {
            return this.gvLocalidades.CurrentCellAddress.Y;
        }

        /// <summary>
        /// Valida que los campos esten correctos para poder Agregar y actualiza el Datagrid
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlMunicipio.SelectedIndex > -1)
                {
                    if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.groupBox2))
                    {
                        this.Agregar();
                        this.LlenarGrid();
                        this.Limpiar();
                    }
                    else
                    {
                        throw new SAIExcepcion("Capture todos los campos.");
                    }
                }
                else
                {
                    throw new SAIExcepcion("Seleccione un Municipio.");
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        /// <summary>
        /// Llama el metodo Limpiar
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Cierra la ventana de localidades
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que selecciona los datos correspondientes a la localidad seleccionada
        /// </summary>
        private void gvLocalidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.ObtenerIndiceSeleccionado() > -1)
                    {
                        this.saiTxtNombre.Text =
                            Convert.ToString(
                                this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["Localidad"].Value);
                        this.ddlMunicipio.SelectedValue =
                            this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells["ClaveMunicipio"].Value;
                        //this.ddlEstado.SelectedIndex = 0;
                        this.txtClaveLocalidadCartografia.Text =
                            Convert.ToString(
                                this.gvLocalidades.Rows[this.ObtenerIndiceSeleccionado()].Cells[
                                    "ClaveLocalidadCartografia"].Value);
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
        /// Valida solo aceptar digitos
        /// </summary>
        private void txtClaveLocalidadCartografia_KeyPress(object sender, KeyPressEventArgs e)
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