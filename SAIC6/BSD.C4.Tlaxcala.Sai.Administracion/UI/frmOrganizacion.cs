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
    public partial class frmOrganizacion : SAIFrmBase
    {
        public frmOrganizacion()
        {
            InitializeComponent();
        }

        private void frmOrganizacion_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }

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
                catOrganizacion.Columns.Add(new DataColumn("ClaveClasificacion", Type.GetType("System.String")));
                catOrganizacion.Columns.Add(new DataColumn("Clasificacion", Type.GetType("System.Int32")));

                Entidades.OrganizacionList lstOrganizacion = Mappers.OrganizacionMapper.Instance().GetAll();

                foreach (Entidades.Organizacion organizacion in lstOrganizacion)
                {
                    object[] registro = new object[] { organizacion.Clave, organizacion.Nombre, organizacion.Dirección,
                        organizacion.Telefono, organizacion.Fax, organizacion.Email, organizacion.DireccionWeb,
                        organizacion.ClaveClasificacion, Mappers.ClasificacionOrganizacionMapper.Instance().GetOne(organizacion.ClaveClasificacion).Descripcion };
                    catOrganizacion.Rows.Add(registro);
                }

                this.gvOrganizaciones.DataSource = catOrganizacion;
                this.gvOrganizaciones.Columns["Clave"].Visible = false;
                this.gvOrganizaciones.Columns["ClaveClasificacion"].Visible = false;

            }
            catch(SAIExcepcion)
            {}
        }

        private void Agregar()
        {
            try
            {

            }
            catch (SAIExcepcion)
            { }
        }

        private void Modificar()
        { }

        private void Eliminar()
        { }

        private void Limpiar()
        { }

        private int ObtieneIndiceSeleccionado()
        {
            return this.gvOrganizaciones.CurrentCellAddress.Y;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Eliminar la Organización?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosGenerales))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void gvOrganizaciones_SystemColorsChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.ObtieneIndiceSeleccionado() > -1)
                {
                    this.saiTxtNombre.Text = Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Nombre"].Value);
                    this.saiTxtDireccion.Text = Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Direccion"].Value);
                    this.saiTxtTelefono.Text = Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Telefono"].Value);
                    this.saiTxtFax.Text = Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Fax"].Value);
                    this.saiTxtEmail.Text = Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["Email"].Value);
                    this.saiTxtDireccionWeb.Text = Convert.ToString(this.gvOrganizaciones.Rows[this.ObtieneIndiceSeleccionado()].Cells["DireccionWeb"].Value);

                    //this.saiDdlClasificacion.SelectedValue();
                    this.btnAgregar.Enabled = false;
                    this.btnEliminar.Visible = true;
                    this.btnModificar.Enabled = true;
                }
            }
            catch (SAIExcepcion)
            { }
        }

      

    

    }
}
