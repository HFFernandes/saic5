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
            int intHeight = base.Height;
            int intWidth = base.Width;

            InitializeComponent();
            this.lblTitulo.Text = "REGISTRO DE DENUNCIA 089";
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = intHeight;
            this.Width = intWidth;
            this.ResumeLayout(false);
            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }
            this.InicializaCampos();
        }

        public SAIFrmIncidencia089(Incidencia EntIncidencia)
            : base(EntIncidencia, false)
        {
            int intHeight = base.Height;
            int intWidth = base.Width;

            this.lblTitulo.Text = "ACTUALIZACIÓN DE DENUNCIA 089";
            InitializeComponent();
            this.Height = intHeight;
            this.Width = intWidth;
            this.InicializaCampos();
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = base.Height;
            this.Width = base.Width;
            this.ResumeLayout(false);
            this.CambiaHabilitadoTipoIncidencia(false);
           
        }

        private void InicializaCampos()
        {
            //Se cargan los elementos en dependencias
            DependenciaList lstDependencias = DependenciaMapper.Instance().GetAll();
            if (lstDependencias != null && lstDependencias.Count > 0)
            {
                this.cmbDependencia.DataSource = lstDependencias;
                this.cmbDependencia.ValueMember = "Clave";
                this.cmbDependencia.DisplayMember = "Descripcion";
               
            }

            if (this._entIncidencia != null)
            {
                //if (this._entIncidencia.FechaNotificacion.HasValue)
                //{
                //    this.dtmFechaNotificacion.Value = this._entIncidencia.FechaNotificacion.Value;
                //    this.dtmFechaNotificacion.Enabled = true;
                //    this.chkFechaNotificacion.Checked = true;
                //}
                //else
                //{
                //    this.dtmFechaNotificacion.Enabled = false;
                //    this.chkFechaNotificacion.Checked = false;
                //}

                //if (this._entIncidencia.FechaEnvio.HasValue)
                //{
                //    this.dtmFechaDocumento.Value = this._entIncidencia.FechaEnvio.Value;
                //    this.dtmFechaDocumento.Enabled = true;
                //    this.chkFechaDocumento.Checked  = true;
                //}
                //else
                //{
                //    this.dtmFechaDocumento.Enabled = false;
                //    this.chkFechaDocumento.Checked = false;
                //}

                //if (this._entIncidencia.FechaEnvioDependencia.HasValue)
                //{
                //    this.dtmFechaEnvioDependencia.Value = this._entIncidencia.FechaEnvioDependencia.Value;
                //    this.dtmFechaEnvioDependencia.Enabled = true;
                //    this.chkFechaEnvio.Checked = true;
                //}
                //else
                //{
                //    this.dtmFechaEnvioDependencia.Enabled = false;
                //    this.chkFechaEnvio.Checked = false;
                //}
                //if (this._entIncidencia.ClaveDependencia.HasValue && this.cmbDependencia.Items.Count > 0)
                //{
                //    foreach (Object objElemento in this.cmbDependencia.Items)
                //    {
                //        if ((objElemento as Dependencia).Clave == this._entIncidencia.ClaveDependencia)
                //        {
                //            this.cmbDependencia.SelectedItem = objElemento;
                //            break;
                //        }
                //    }
                //}

                this.txtAlias.Text = this._entIncidencia.AliasDelincuente;
                this.txtNumeroOficio.Text = this._entIncidencia.NumeroOficio;
            }

           
        }

        private void chkFechaEnvio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaEnvioDependencia.Enabled = !this.dtmFechaEnvioDependencia.Enabled;
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void chkFechaDocumento_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaDocumento.Enabled = !this.dtmFechaDocumento.Enabled;
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void chkFechaNotificacion_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaNotificacion.Enabled = !this.dtmFechaNotificacion.Enabled;
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
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
                //if (this.chkFechaEnvio.Checked)
                //{
                //    this._entIncidencia.ClaveEstatus = 3;
                //    this._entIncidencia.FechaEnvioDependencia = this.dtmFechaEnvioDependencia.Value;
                //}
                //else
                //{
                //    this._entIncidencia.ClaveEstatus = 2;
                //    this._entIncidencia.FechaEnvioDependencia = null;
                //}
                //if (this.chkFechaDocumento.Checked)
                //{

                //    this._entIncidencia.FechaEnvio = this.dtmFechaDocumento.Value;
                //}
                //else
                //{
                //    this._entIncidencia.FechaEnvio = null;
                //}
                //if (this.chkFechaNotificacion.Checked)
                //{
                //    this._entIncidencia.FechaNotificacion = this.dtmFechaNotificacion.Value;
                //}
                //else
                //{
                //    this._entIncidencia.FechaNotificacion = null;
                //}
                if (this.txtNumeroOficio.Text != string.Empty)
                {
                    this._entIncidencia.ClaveEstatus = 4;
                }
                else
                {
                    //if (this._entIncidencia.FechaEnvioDependencia == null)
                    //{
                    //    this._entIncidencia.ClaveEstatus = 2;
                    //}
                    //else
                    //{
                    //    this._entIncidencia.ClaveEstatus = 3;
                    //}
                }
                this._entIncidencia.NumeroOficio = this.txtNumeroOficio.Text; 
                this._entIncidencia.AliasDelincuente = this.txtAlias.Text;
                if (this.cmbDependencia.Items.Count > 0)
                {
                    if (this.cmbDependencia.SelectedIndex != 1)
                    {
                        //if (this._entIncidencia.FechaEnvioDependencia == null)
                        //{
                        //    this._entIncidencia.ClaveEstatus = 2;
                        //}
                        //else
                        //{
                        //    this._entIncidencia.ClaveEstatus = 3;
                        //}
                        if (this.txtNumeroOficio.Text != string.Empty)
                        {
                            this._entIncidencia.ClaveEstatus = 4;
                        }
                        //this._entIncidencia.ClaveDependencia = (this.cmbDependencia.SelectedItem as Dependencia).Clave;
                    }
                }
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

        private void SAIFrmIncidencia089_Load(object sender, EventArgs e)
        {

        }

        private void cmbDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();

                this.GuardaIncidencia();
            }
        }

        private void txtAlias_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void txtAlias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtmFechaEnvioDependencia.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }
       

      
    }
}
