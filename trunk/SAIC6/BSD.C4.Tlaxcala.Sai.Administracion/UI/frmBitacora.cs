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
            if (this.ddlOperacion.SelectedIndex > -1)
            {
                string operacion = Convert.ToString(this.ddlOperacion.SelectedItem);
                this.gvBitacora.DataSource = Mappers.BitacoraMapper.Instance().GetByOperacion(operacion);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Llenar()
        {
            //this.ddlCatalogos.Items.Add(new ComboItem("Usuarios", "Usuarios"));
        }
    }
}
