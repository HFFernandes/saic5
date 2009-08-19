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

        private void frmClasificacionOrganizacion_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarGrid();
            
        }

        private void LlenarGrid()
        {
            try
            {
                this.gvClasificacionOrg.DataSource = Mappers.ClasificacionOrganizacionMapper.Instance().GetAll();
            }
            catch (SAIExcepcion)
            { }
        }

        private void Agregar()
        {
            try 
            {
                Entidades.ClasificacionOrganizacion newClasificacionOrg = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.ClasificacionOrganizacion();
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
            catch (SAIExcepcion)
            { }
        }

        private void Modificar()
        {
            try
            {
                Entidades.ClasificacionOrganizacion updClasificacionOrg = Mappers.ClasificacionOrganizacionMapper.Instance().GetOne(Convert.ToInt32(this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));
                updClasificacionOrg.Descripcion = this.saiTxtDescripcion.Text;
                Mappers.ClasificacionOrganizacionMapper.Instance().Save(updClasificacionOrg);

                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se modifico la Clasificacion de Organizacion: " + updClasificacionOrg.Descripcion;
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Clasificacion Organizacion";
                bitacora.Operacion = "UPDATE";
                bitacora.ValorActual = this.saiTxtDescripcion.Text;
                bitacora.ValorAnterior = Convert.ToString(this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];

                Mappers.BitacoraMapper.Instance().Insert(bitacora);

            }
            catch (SAIExcepcion)
            { }
        }

        private void Eliminar()
        {
            try
            {
                Mappers.ClasificacionOrganizacionMapper.Instance().Delete(Convert.ToInt32(this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value));
                
                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se elimino la Clasificacion de Organizacion: " + Convert.ToString(this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Clasificacion Organizacion";
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                bitacora.Operacion = "DELETE";

                Mappers.BitacoraMapper.Instance().Insert(bitacora);
            }
            catch (SAIExcepcion)
            { }
        }

        private void Limpiar()
        {
            this.saiTxtDescripcion.Text = string.Empty;
            this.btnEliminar.Visible = false;
            this.btnAgregar.Enabled = true;
            this.btnModificar.Enabled = false;
        }

        private int ObtenerIndiceSeleccionado()
        {
            return this.gvClasificacionOrg.CurrentCellAddress.Y;
        }

        private void gvClasificacionOrg_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.ObtenerIndiceSeleccionado() > -1)
                {
                    this.saiTxtDescripcion.Text = Convert.ToString(this.gvClasificacionOrg.Rows[this.ObtenerIndiceSeleccionado()].Cells["Descripcion"].Value);
                    this.btnEliminar.Visible = true;
                    this.btnAgregar.Enabled = false;
                    this.btnModificar.Enabled = true;
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gbpDatosGenerales))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gbpDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Eliminar la Clasificacion?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
