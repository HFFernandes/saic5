using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasPendientes : SAIFrmBase
    {
        public SAIFrmIncidenciasPendientes()
        {
            InitializeComponent();
        }

        private void SAIFrmIncidenciasPendientes_Load(object sender, EventArgs e)
        {
            saiReport1.AgregarColumna(0,"Tipo",150,false);
        }
    }
}
