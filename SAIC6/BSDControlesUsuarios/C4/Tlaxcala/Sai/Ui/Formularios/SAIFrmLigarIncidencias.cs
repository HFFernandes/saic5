using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmLigarIncidencias : BSD.C4.Tlaxcala.Sai.Ui.Formularios.SAIFrmBase
    {
        public SAIFrmLigarIncidencias(List<int> lstRegistros)
        {
            InitializeComponent();

            saiCmbFolioPadre.Items.Clear();
            foreach (var registro in lstRegistros)
            {
                saiCmbFolioPadre.Items.Add(registro.ToString());
            }

            saiCmbFolioPadre.SelectedIndex = -1;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (base.SAIProveedorValidacion.ValidarCamposRequeridos(this))
            {
                base.DialogResult = System.Windows.Forms.DialogResult.OK;
                base.Close();
            }
        }
    }
}
