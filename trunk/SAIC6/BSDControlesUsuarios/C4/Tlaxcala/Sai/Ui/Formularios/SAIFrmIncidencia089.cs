using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidencia089 : SAIFrmIncidencia
    {
        public SAIFrmIncidencia089()
        {
            InitializeComponent();

            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }
        }

        private void chkFechaEnvio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaEnvioDependencia.Enabled = !this.dtmFechaEnvioDependencia.Enabled;
        }

        private void chkFechaDocumento_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaDocumento.Enabled = !this.dtmFechaDocumento.Enabled;
        }

        private void chkFechaNotificacion_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaNotificacion.Enabled = !this.dtmFechaNotificacion.Enabled;
        }

    }
}
