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

        private void frmDependecias_Load(object sender, EventArgs e)
        {
             this.SAIBarraEstado.SizingGrip = false;
             this.LlenarGrid();

        }

        private void LlenarGrid()
        {
            try 
            {
                this.gvDependencias.DataSource = Mappers.DependenciaMapper.Instance().GetAll();
            }
            catch (SAIExcepcion)
            { }
        }

        private void Agregar()
        {
            try 
            {
                Entidades.Dependencia newDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Dependencia();
                newDependencia.Descripcion = this.saiTxtDependencia.Text;
                Mappers.DependenciaMapper.Instance().Insert(newDependencia);

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

        private void Modificar()
        {
            try
            {
                Entidades.Dependencia updDependencia = Mappers.DependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
                updDependencia.Descripcion = this.saiTxtDependencia.Text;
                Mappers.DependenciaMapper.Instance().Save(updDependencia);

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

        private void Eliminar()
        {
            try
            {
                Mappers.DependenciaMapper.Instance().Delete(Convert.ToInt32(this.gvDependencias.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
            }
            catch (SAIExcepcion)
            { }
        }

        private void Limpiar()
        {
            this.saiTxtDependencia.Text = string.Empty;
            this.btnAgregar.Enabled = true;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Visible = false;
        }

        private int ObtieneIndiceSeleccionado()
        {
            return this.gvDependencias.CurrentCellAddress.Y;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gbpDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar la dependencia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void gvDependencias_SelectionChanged(object sender, EventArgs e)
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
            catch (SAIExcepcion)
            { }
        }


    }
}
