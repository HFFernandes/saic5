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
    public partial class frmDependecias : SAIFrmBase
    {
        public frmDependecias()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se llama el metodo LlenarGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDependecias_Load(object sender, EventArgs e)
        {
             this.SAIBarraEstado.SizingGrip = false;
             this.LlenarGrid();
        }

        /// <summary>
        /// LLena el Datagrid con el catalogo de Dependencias
        /// </summary>
        private void LlenarGrid()
        {
            try 
            {
                try
                {
                    this.gvDependencias.DataSource = Mappers.DependenciaMapper.Instance().GetAll();
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Agrega una nueva dependencia al catalogo
        /// </summary>
        private void Agregar()
        {
            try 
            {
                Entidades.Dependencia newDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Dependencia();
                newDependencia.Descripcion = this.saiTxtDependencia.Text;
                Mappers.DependenciaMapper.Instance().Insert(newDependencia);
                //Agrega operacion a la bitacora
                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se agrego la Dependencia: " + newDependencia.Descripcion;
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Dependencias";
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                bitacora.Operacion = "INSERT";

                Mappers.BitacoraMapper.Instance().Insert(bitacora);
            }
            catch(SAIExcepcion)
            {}        
        }
        /// <summary>
        /// Modifica la Descripcion de una Dependencia
        /// </summary>
        private void Modificar()
        {
            try
            {
                Entidades.Dependencia updDependencia = Mappers.DependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
                updDependencia.Descripcion = this.saiTxtDependencia.Text;
                Mappers.DependenciaMapper.Instance().Save(updDependencia);
                //Agrega operacion al catalogo
                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se modifico la Dependencia: " + updDependencia.Descripcion;
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Dependencias";
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                bitacora.Operacion = "UPDATE";

                Mappers.BitacoraMapper.Instance().Insert(bitacora);
            }
            catch (SAIExcepcion)
            { } 
        }
        /// <summary>
        /// Elimina una dependencia del catalogo
        /// </summary>
        private void Eliminar()
        {
            try
            {
                Mappers.DependenciaMapper.Instance().Delete(Convert.ToInt32(this.gvDependencias.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
                //Agrega operacion en la bitacora
                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se elimino la Dependencia: " + Convert.ToString(this.gvDependencias.Rows[this.ObtieneIndiceSeleccionado()].Cells["Descripcion"].Value);
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Dependencias";
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                bitacora.Operacion = "DELETE";

                Mappers.BitacoraMapper.Instance().Insert(bitacora);
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Limpia los controles del formulario de Dependencias
        /// </summary>
        private void Limpiar()
        {
            this.saiTxtDependencia.Text = string.Empty;
            this.btnAgregar.Enabled = true;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Visible = false;
        }
        /// <summary>
        /// Obtiene el indice del registro sleccionado
        /// </summary>
        /// <returns>Indice</returns>
        private int ObtieneIndiceSeleccionado()
        {
            return this.gvDependencias.CurrentCellAddress.Y;
        }
        /// <summary>
        /// Cierra la ventana de Dependencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Llama el metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Valida el campo obligatorio y llama al metodo Modificar, Actualiza Datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Valida campos obligatorios y llama al metodo Agregar, Actualiza Datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Llama el metodo Eliminar, Actualiza el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar la dependencia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Evento que obtiene los datos de un regitro seleccionado para modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDependencias_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                try
                {
                    if (this.ObtieneIndiceSeleccionado() > -1)
                    {
                        this.saiTxtDependencia.Text = Convert.ToString(this.gvDependencias.Rows[this.ObtieneIndiceSeleccionado()].Cells["Descripcion"].Value);
                        this.btnEliminar.Visible = true;
                        this.btnAgregar.Enabled = false;
                        this.btnModificar.Enabled = true;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
    }
}
