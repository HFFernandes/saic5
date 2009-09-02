using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmLigarIncidencias : SAIFrmBase
    {
        public string strFolioPadre;

        public SAIFrmLigarIncidencias(List<string> lstRegistros)
        {
            InitializeComponent();

            saiCmbFolioPadre.Items.Clear();
            foreach (var registro in lstRegistros)
            {
                saiCmbFolioPadre.Items.Add(registro);
            }

            saiCmbFolioPadre.SelectedIndex = 0;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (SAIProveedorValidacion.ValidarCamposRequeridos(this))
            {
                strFolioPadre = saiCmbFolioPadre.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void SAIFrmLigarIncidencias_Load(object sender, EventArgs e)
        {
            saiCmbFolioPadre.SelectedIndex = -1;
        }
    }
}
