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
    public partial class frmClasificacionOrganizacion : SAIFrmBase
    {
        public frmClasificacionOrganizacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llama el metodo Llenar Grid
        /// </summary>
        private void frmClasificacionOrganizacion_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarGrid();
        }

        /// <summary>
        /// Llena el Datatgrid con el catalogo de Clasificacion de Organización
        /// </summary>
        private void LlenarGrid()
        {
            try
            {
                try
                {
                    this.gvClasificacionOrg.DataSource = Mappers.ClasificacionOrganizacionMapper.Instance().GetAll();
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
        /// Agrega una nueva Clasificación
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.ClasificacionOrganizacion newClasificacionOrg =
                        new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ClasificacionOrganizacion();
                    newClasificacionOrg.Descripcion = this.saiTxtDescripcion.Text;
                    Mappers.ClasificacionOrganizacionMapper.Instance().Insert(newClasificacionOrg);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego la Clasificacion: " + newClasificacionOrg.Descripcion;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Clasificacion Organizacion";
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
        /// Modifica una Casificación
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    Entidades.ClasificacionOrganizacion updClasificacionOrg =
                        Mappers.ClasificacionOrganizacionMapper.Instance().GetOne(
                            Convert.ToInt32(
                                this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));
                    updClasificacionOrg.Descripcion = this.saiTxtDescripcion.Text;
                    Mappers.ClasificacionOrganizacionMapper.Instance().Save(updClasificacionOrg);

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se modifico la Clasificacion de Organizacion: " +
                                           updClasificacionOrg.Descripcion;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Clasificacion Organizacion";
                    bitacora.Operacion = "UPDATE";
                    bitacora.ValorActual = this.saiTxtDescripcion.Text;
                    bitacora.ValorAnterior =
                        Convert.ToString(
                            this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
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
        /// Elimina una clasificaciòn de Organizaciones del catalogo
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    Mappers.ClasificacionOrganizacionMapper.Instance().Delete(
                        Convert.ToInt32(
                            this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));

                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se elimino la Clasificacion de Organizacion: " +
                                           Convert.ToString(
                                               this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells[
                                                   "Descripcion"].Value);
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Clasificacion Organizacion";
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
        /// Limpia los controles del formulario de Clasificaciones
        /// </summary>
        private void Limpiar()
        {
            this.saiTxtDescripcion.Text = string.Empty;
            this.btnEliminar.Visible = false;
            this.btnAgregar.Enabled = true;
            this.btnModificar.Enabled = false;
        }

        /// <summary>
        /// Obtiene el indice del registro seleccionado
        /// </summary>
        /// <returns>Indice</returns>
        private int ObtenerIndiceSeleccionado()
        {
            return this.gvClasificacionOrg.CurrentCellAddress.Y;
        }

        /// <summary>
        /// Evanto que obtiene los datos de la clasificación seleccionada para su modificación
        /// </summary>
        private void gvClasificacionOrg_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerIndiceSeleccionado() > -1)
                {
                    this.saiTxtDescripcion.Text =
                        Convert.ToString(
                            this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
                    this.btnEliminar.Visible = true;
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
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
        /// Valida campos obligatorios y llama el metodo modificar
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gbpDatosGenerales))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Valida campos obligatorios y llama el metodo agregar
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gbpDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Llama el metodo Eliminar
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Esta seguro de Eliminar la Clasificacion?", "Eliminar", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Cierra la ventana de Clasificación de Organizaciones
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}