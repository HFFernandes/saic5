using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class FrmPruebas : SAIFrmBase
    {
        public FrmPruebas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(base.SAIProveedorValidacion.ValidarCamposRequeridos(this))
            {
                MessageBox.Show("guardar");
            }
        }
    }
}
