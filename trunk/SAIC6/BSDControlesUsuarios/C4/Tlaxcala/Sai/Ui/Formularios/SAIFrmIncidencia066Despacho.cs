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
            this.lblTitulo.Text = "DESPACHO DE INCIDENCIA";
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = 630;
            this.Width = 600;
            this.ResumeLayout(false);


            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }

            this.SoloLectura = true;
        }
    }
}
