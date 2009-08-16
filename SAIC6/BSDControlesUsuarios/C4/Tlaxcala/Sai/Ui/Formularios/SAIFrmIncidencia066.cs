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
using System.Collections;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidencia066 : SAIFrmIncidencia
    {
        public SAIFrmIncidencia066()
        {
            int intHeight = base.Height;
            int intWidth = base.Width;

            InitializeComponent();


            this.lblTitulo.Text = "REGISTRO DE INCIDENCIA 066";
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Height = intHeight;
            base.Width = intWidth;
            this.ResumeLayout(false);
            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }

            //Se recupera la lista de las corporaciones
            CorporacionList objListaCorporaciones = CorporacionMapper.Instance().GetAll();
            String[] arrCorporaciones = new String[objListaCorporaciones.Count];

            int i=0;
            foreach (Corporacion objCorporacion in objListaCorporaciones)
            {
                arrCorporaciones[i] = objCorporacion.Descripcion;
                    i++;
            }

            this.cklCorporacion.Items.AddRange(arrCorporaciones);

            this.cklCorporacion.CheckOnClick = true;

            this._grpDenunciante = this.grpDenunciante;
        }

        public SAIFrmIncidencia066(Incidencia entIncidencia)
            : base(entIncidencia, false)
        {
            int intHeight = base.Height;
            int intWidth = base.Width;

            InitializeComponent();

           
            this.lblTitulo.Text = "REGISTRO DE INCIDENCIA 066";
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Height = intHeight;
            base.Width = intWidth;
            this.ResumeLayout(false);
            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }

            //Se recupera la lista de las corporaciones
            CorporacionList objListaCorporaciones = CorporacionMapper.Instance().GetAll();
            String[] arrCorporaciones = new String[objListaCorporaciones.Count];

            int i = 0;
            foreach (Corporacion objCorporacion in objListaCorporaciones)
            {
                arrCorporaciones[i] = objCorporacion.Descripcion;
                i++;
            }

            this.cklCorporacion.Items.AddRange(arrCorporaciones);

            this.cklCorporacion.CheckOnClick = true;

            this._grpDenunciante = this.grpDenunciante;

            if (this._entIncidencia.ClaveDenunciante.HasValue)
            {
                DenuncianteObject objDenunciante = DenuncianteMapper.Instance().GetOne(this._entIncidencia.ClaveDenunciante.Value);

                this.txtNombreDenunciante.Text  = objDenunciante.Nombre;
                this.txtApellidoDenunciante.Text  = objDenunciante.Apellido;
                this.txtDenuncianteDireccion.Text  = objDenunciante.Direccion;
            }

        }

        private void SAIFrmIncidencia066_Load(object sender, EventArgs e)
        {

        }

        private void grpDenunciante_Enter(object sender, EventArgs e)
        {

        }

        private void txtReferencias_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void cklCorporacion_Leave(object sender, EventArgs e)
        {
            this.GuardaCorporaciones();
        }

        private void txtNombreDenunciante_Leave(object sender, EventArgs e)
        {
            this.GuardaDenunciante();
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void txtApellidoDenunciante_Leave(object sender, EventArgs e)
        {
            this.GuardaDenunciante();
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void txtDenuncianteDireccion_Leave(object sender, EventArgs e)
        {
            this.GuardaDenunciante();
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void txtReferencias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cklCorporacion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void cklCorporacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNombreDenunciante.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtNombreDenunciante_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtApellidoDenunciante.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void txtApellidoDenunciante_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDenuncianteDireccion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        private void RecuperaDatosEnIncidencia()
        {

          
        }

        protected override void OnClosed(EventArgs e)
        {
            this.RecuperaDatosEnIncidencia();
            this.GuardaCorporaciones();
            this.GuardaDenunciante();
            base.OnClosed(e);
        }

        private void GuardaCorporaciones()
        {
            IEnumerator myEnumerator;
            CorporacionList ListaCorporaciones = CorporacionMapper.Instance().GetAll();
            Boolean blnTieneDatos = false;
            


            if (this._entIncidencia == null)
                return;

            this._entIncidencia.ClaveEstatus = 1;
            
            IncidenciaMapper.Instance().Save(this._entIncidencia);

            CorporacionIncidenciaMapper.Instance().DeleteByIncidencia(this._entIncidencia.Folio);

            myEnumerator = this.cklCorporacion.CheckedIndices.GetEnumerator();
            int y;
            while (myEnumerator.MoveNext() != false)
            {
                y = (int)myEnumerator.Current;
                foreach (Corporacion objCorporacion in ListaCorporaciones)
                {
                    if (this.cklCorporacion.Items[y].ToString() == objCorporacion.Descripcion)
                    {
                        blnTieneDatos = true;
                        CorporacionIncidenciaMapper.Instance().Insert(new CorporacionIncidencia(this._entIncidencia.Folio, objCorporacion.Clave));
                    }
                }
            }

            if (blnTieneDatos)
            {
                this._entIncidencia.ClaveEstatus = 2;
                IncidenciaMapper.Instance().Save(this._entIncidencia);

            }
            
        }

        private void GuardaDenunciante()
        {
            if (this._entIncidencia == null)
                return;

            DenuncianteObject objDenunciante;

            if (this.txtNombreDenunciante.Text.Trim() != string.Empty || this.txtApellidoDenunciante.Text.Trim() != string.Empty
                || this.txtDenuncianteDireccion.Text.Trim() != string.Empty)
            {
                

                if (this._entIncidencia.ClaveDenunciante.HasValue)
                {
                    objDenunciante = DenuncianteMapper.Instance().GetOne(this._entIncidencia.ClaveDenunciante.Value);
                    objDenunciante.Apellido = this.txtApellidoDenunciante.Text;
                    objDenunciante.Direccion = this.txtDenuncianteDireccion.Text;
                    objDenunciante.Nombre = this.txtNombreDenunciante.Text;
                    DenuncianteMapper.Instance().Save(objDenunciante);
                }
                else
                {
                    objDenunciante = new DenuncianteObject();
                    objDenunciante.Apellido = this.txtApellidoDenunciante.Text;
                    objDenunciante.Direccion = this.txtDenuncianteDireccion.Text;
                    objDenunciante.Nombre = this.txtNombreDenunciante.Text;
                    DenuncianteMapper.Instance().Insert(objDenunciante);
                }

                this._entIncidencia.ClaveDenunciante = objDenunciante.Clave;


            }

        }

        private void cklCorporacion_MouseUp(object sender, MouseEventArgs e)
        {
            this.GuardaCorporaciones();
        }

    }
}
