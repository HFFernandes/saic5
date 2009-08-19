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
            CorporacionList objListaCorporaciones = this.ObtenCorporaciones();
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

           
            this.lblTitulo.Text = "ACTUALIZACIÓN DE INCIDENCIA 066";
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
            CorporacionList objListaCorporaciones = this.ObtenCorporaciones();
            String[] arrCorporaciones = new String[objListaCorporaciones.Count];

            int i = 0;
            foreach (Corporacion objCorporacion in objListaCorporaciones)
            {
                arrCorporaciones[i] = objCorporacion.Descripcion;
                i++;
            }
            
            this.cklCorporacion.Items.AddRange(arrCorporaciones);

            //Ahora se palomean las corporaciones a la que la incidencia está asociada:

            CorporacionIncidenciaList lstCorporacionIncidencia = CorporacionIncidenciaMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);

            if (lstCorporacionIncidencia != null && lstCorporacionIncidencia.Count > 0)
            {
                for (int j=0;j< lstCorporacionIncidencia.Count ; j++)
                {
                    Corporacion entCorporacion = CorporacionMapper.Instance().GetOne(lstCorporacionIncidencia[j].ClaveCorporacion);

                    for (i=0; i<this.cklCorporacion.Items.Count; i++)
                    {
                        if (this.cklCorporacion.Items[i].ToString() == entCorporacion.Descripcion)
                        {
                            this.cklCorporacion.SetItemChecked(i, true);
                        }
                    }
                }
            }

            this.cklCorporacion.CheckOnClick = true;

            this._grpDenunciante = this.grpDenunciante;

            if (this._entIncidencia.ClaveDenunciante.HasValue)
            {
                DenuncianteObject objDenunciante = DenuncianteMapper.Instance().GetOne(this._entIncidencia.ClaveDenunciante.Value);

                this.txtNombreDenunciante.Text  = objDenunciante.Nombre;
                this.txtApellidoDenunciante.Text  = objDenunciante.Apellido;
                this.txtDenuncianteDireccion.Text  = objDenunciante.Direccion;
            }
            this.CambiaHabilitadoTipoIncidencia(false);

        }
            
      

        /// <summary>
        /// Guarda las corporaciones asociadas a la incidencia cuando se sale del control de corporaciones 
        /// </summary>
        ///<remarks>Según las corporaciones asociadas se hace el despacho de la incidencia </remarks>
        private void cklCorporacion_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    try
            //    {
            //        this.GuardaCorporaciones();
            //    }
            //    catch (System.Exception ex)
            //    {
            //        throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            //    }
            //}
            //catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia cuando se termina de editar el nombre del denunciante
        /// </summary>
        private void txtNombreDenunciante_Leave(object sender, EventArgs e)
        {
            try
            {
             try
             {
                
                if (!this._blnSeActivoClosed)
                {
                    base.RecuperaDatosEnIncidencia();
                    this.GuardaDenunciante();
                    this.GuardaIncidencia();
                }
             }
             catch (System.Exception ex)
             {
                 throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
             }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        ///Guarda la incidencia cuando se termina de editar el apellido del denunciante 
        /// </summary>
        private void txtApellidoDenunciante_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                   if (!this._blnSeActivoClosed)
                    {
                        base.RecuperaDatosEnIncidencia();
                        this.GuardaDenunciante();
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda la incidencia cuando se termina de editar la dirección del denunciante
        /// </summary>
        private void txtDenuncianteDireccion_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    
                    if (!this._blnSeActivoClosed)
                    {
                        base.RecuperaDatosEnIncidencia();
                        this.GuardaDenunciante();
                        this.GuardaIncidencia();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Manda el foco al control de corporaciones cuando se presiona la tecla enter en referencias
        /// </summary>
       
        private void txtReferencias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cklCorporacion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Manda el foco al control del nombre del denunciante cuando se presiona la tecla enter en el control de corporaciones
        /// </summary>
         private void cklCorporacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNombreDenunciante.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Manda el foco al control del apellido del denunciante cuando se presiona enter en el control del nombre del denunciante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreDenunciante_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtApellidoDenunciante.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        /// <summary>
        /// Manda el foco al control de la dirección del denunciante cuando se presiona enter en el control del apellido del denunciante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtApellidoDenunciante_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDenuncianteDireccion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

       
        /// <summary>
        /// Guarda la información de la incidencia al cerrar la ventana
        /// </summary>
       
        protected override void OnClosed(EventArgs e)
        {
            try
            {
                try
                {
                    //this.GuardaCorporaciones();
                    this.GuardaDenunciante();
                    base.OnClosed(e);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Guarda las corporaciones asociadas a la incidencia
        /// </summary>
        private void GuardaCorporaciones()
        {
            IEnumerator myEnumerator;
            CorporacionList ListaCorporaciones = this.ObtenCorporaciones();
            Boolean blnTieneDatos = false;
            CorporacionIncidenciaList lstCorporacionIncidencia;
           
            try
            {
                try
                {
                    //Se revisa si la incidncia ya tiene despacho, si es así, no se puede  modificar la infomración
                    lstCorporacionIncidencia = CorporacionIncidenciaMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                    if (lstCorporacionIncidencia != null && lstCorporacionIncidencia.Count > 0)
                    {
                        foreach (CorporacionIncidencia entCorporacionIncidencia in lstCorporacionIncidencia)
                        {
                            if (DespachoIncidenciaMapper.Instance().GetByCorporacionIncidencia(this._entIncidencia.Folio, entCorporacionIncidencia.ClaveCorporacion).Count > 0)
                            {

                                for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                                {
                                   
                                        this.cklCorporacion.SetItemChecked(i, false);
                                    
                                }

                                for (int j = 0; j < lstCorporacionIncidencia.Count; j++)
                                {
                                    Corporacion entCorporacion = CorporacionMapper.Instance().GetOne(lstCorporacionIncidencia[j].ClaveCorporacion);

                                    for (int i = 0; i < this.cklCorporacion.Items.Count; i++)
                                    {
                                        if (this.cklCorporacion.Items[i].ToString() == entCorporacion.Descripcion)
                                        {
                                            this.cklCorporacion.SetItemChecked(i, true);
                                        }
                                    }
                                }

                                throw new SAIExcepcion("No es posible modificar la información de las corporaciones asociadas, la incidencia ya está siendo despachada", this);



                            }
                        }
                    }

                    if (this._blnSeActivoClosed)
                    {
                        return;
                    }

                    if (this._entIncidencia == null)
                    {
                        return;
                    }
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
            
        }


        /// <summary>
        /// Guarda los datos del denunciante
        /// </summary>
        private void GuardaDenunciante()
        {
            if (this._entIncidencia == null)
                return;

            DenuncianteObject objDenunciante;

            try
            {
                try
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
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

        }

        private CorporacionList ObtenCorporaciones()
        {
            CorporacionList lstCorporaciones = new CorporacionList();
            try
            {
                try
                {
                     lstCorporaciones = CorporacionMapper.Instance().GetBySQLQuery("SELECT [Clave],[Descripcion],[ClaveSistema],[UnidadesVirtuales],[Activo],[Zn] FROM [dbo].[Corporacion] Where Activo = 1");
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }

            return lstCorporaciones;
        }

        private void cklCorporacion_MouseUp(object sender, MouseEventArgs e)
        {
            this.GuardaCorporaciones();
        }

    }
}
