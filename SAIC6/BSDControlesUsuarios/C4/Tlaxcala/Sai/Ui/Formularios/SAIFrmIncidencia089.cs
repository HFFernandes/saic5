using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidencia089 : SAIFrmIncidencia
    {
        public SAIFrmIncidencia089()
        {
            InitializeComponent();
            this.lblTitulo.Text = "REGISTRO DE INCIDENCIA 089";
            this.SuspendLayout();
            this.Height = 485;
            this.Width = 600;
            this.ResumeLayout(false);
            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }
            this.InicializaCampos();
        }

        private void SIAFrmIncidencia089(Incidencia EntIncidencia)
        {
            this.lblTitulo.Text = "INCIDENCIA 089";
            InitializeComponent();
            this.InicializaCampos();
            this.SuspendLayout();
            this.Height = 650;
            this.Width = 647;
            this.ResumeLayout(false);
        }

        private void InicializaCampos()
        {
            if (this._entIncidencia != null)
            {
                if (this._entIncidencia.FechaNotificacion.HasValue)
                {
                    this.dtmFechaNotificacion.Value = this._entIncidencia.FechaNotificacion.Value;
                    this.dtmFechaNotificacion.Enabled = true;
                    this.chkFechaNotificacion.Checked = true;
                }
                else
                {
                    this.dtmFechaNotificacion.Enabled = false;
                    this.chkFechaNotificacion.Checked = false;
                }

                if (this._entIncidencia.FechaEnvio.HasValue)
                {
                    this.dtmFechaDocumento.Value = this._entIncidencia.FechaEnvio.Value;
                    this.dtmFechaDocumento.Enabled = true;
                    this.chkFechaDocumento.Checked  = true;
                }
                else
                {
                    this.dtmFechaDocumento.Enabled = false;
                    this.chkFechaDocumento.Checked = false;
                }

                if (this._entIncidencia.FechaEnvioDependencia.HasValue)
                {
                    this.dtmFechaEnvioDependencia.Value = this._entIncidencia.FechaEnvioDependencia.Value;
                    this.dtmFechaEnvioDependencia.Enabled = true;
                    this.chkFechaEnvio.Checked = true;
                }
                else
                {
                    this.dtmFechaEnvioDependencia.Enabled = false;
                    this.chkFechaEnvio.Checked = false;
                }

                this.txtNumeroOficio.Text = this._entIncidencia.NumeroOficio;
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

        private void dtmFechaEnvioDependencia_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void dtmFechaDocumento_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void dtmFechaNotificacion_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void txtNumeroOficio_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void RecuperaDatosEnIncidencia()
        {
           
            if (this._entIncidencia != null)
            {
                this._entIncidencia.FechaEnvioDependencia = this.dtmFechaEnvioDependencia.Value;
                this._entIncidencia.FechaEnvio = this.dtmFechaDocumento.Value;
                this._entIncidencia.FechaNotificacion = this.dtmFechaNotificacion.Value;
                this._entIncidencia.NumeroOficio = this.txtNumeroOficio.Text;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            this.RecuperaDatosEnIncidencia();
            base.OnClosed(e);
        }

        private void dtmFechaEnvioDependencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtmFechaDocumento.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void dtmFechaDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtmFechaNotificacion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void dtmFechaNotificacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNumeroOficio.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }
       

        // public override void txtDescripcion_OnKeyEnterUp(object sender,KeyEventArgs e)
        //{
        //    string s = string.Empty;
        //}
    }
}
