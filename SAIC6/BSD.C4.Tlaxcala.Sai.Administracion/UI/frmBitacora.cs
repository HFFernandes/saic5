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
    public partial class frmBitacora : SAIFrmBase
    {
        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            SAIBarraEstado.SizingGrip = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.gvBitacora.DataSource = Mappers.BitacoraMapper.Instance().GetAll();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string sqlFiltro = string.Empty;
            try
            {

                if (this.chkOperacion.Checked)
                {
                    sqlFiltro = " Operacion = '" + this.ddlOperacion.SelectedItem + "' ";
                }

                if (sqlFiltro.Length > 0)
                    sqlFiltro += " and ";

                if (this.chkCatalogo.Checked)
                {
                    sqlFiltro += " NombreCatalogo = '" + this.ddlCatalogos.SelectedItem + "' ";
                }

                if (sqlFiltro.Length > 0)
                {
                    this.gvBitacora.DataSource = Mappers.BitacoraMapper.Instance().GetFiltrado(sqlFiltro);
                }
                else 
                {
                    throw new SAIExcepcion("Seleccione un filtro.");
                }
            }
            catch (SAIExcepcion)
            { }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Llenar()
        {
            //this.ddlCatalogos.Items.Add(new ComboItem("Usuarios", "Usuarios"));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.ddlCatalogos.SelectedIndex = -1;
            this.ddlOperacion.SelectedIndex = -1;

            this.chkCatalogo.Checked = false;
            this.chkOperacion.Checked = false;

        }

        private void ddlOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOperacion.SelectedIndex > -1)
                this.chkOperacion.Checked = true;
            else
                this.chkOperacion.Checked = false;
        }

        private void ddlCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlCatalogos.SelectedIndex > -1)
                this.chkCatalogo.Checked = true;
            else
                this.chkCatalogo.Checked = false;
        }

        private void chkOperacion_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkOperacion.Checked)
                this.ddlOperacion.SelectedIndex = -1;
        }

        private void chkCatalogo_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkCatalogo.Checked)
                this.ddlCatalogos.SelectedIndex = -1;

        }
    }
}
