using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidencia066Despacho : SAIFrmIncidencia
    {
        public SAIFrmIncidencia066Despacho()
        {
            InitializeComponent();
            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }
        }
    }
}
