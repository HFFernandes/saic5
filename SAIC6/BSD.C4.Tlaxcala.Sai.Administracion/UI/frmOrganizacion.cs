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

        }

        private void LlenarGrid()
        {
            try { }
            catch(SAIExcepcion)
            {}
        }

        private void Agregar()
        { }

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
            this.Agregar();
            this.LlenarGrid();
            this.Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
            this.LlenarGrid();
            this.Limpiar();
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
