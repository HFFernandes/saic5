﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Mapa;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidencia066Despacho : SAIFrmIncidencia
    {
        private DespachoIncidencia _despachoIncidencia;
        private Unidad _unidadAsignada;
        private Unidad _unidadApoyo;
        private Corporacion _entCorporacion;
        private CorporacionIncidencia _entCorporacionIncidencia;
        

        public SAIFrmIncidencia066Despacho(Incidencia entIncidencia) : base(entIncidencia,true)
        {

            //try
            //{
            //    try
            //    {
               
                                           
                InitializeComponent();
                if (!Aplicacion.UsuarioPersistencia.intCorporacion.HasValue)
                {
                    Controlador.RevisaInstancias(this);
                    throw new SAIExcepcion("No es posible hacer el despacho de la incidencia, falta corporación del usuario. Favor de acudir al administrador del sistema", this);
                }
                this.lblTitulo.Text = "DESPACHO DE INCIDENCIA 066";
                this.SuspendLayout();
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.Height = 740;
                this.Width = 600;
                this.ResumeLayout(false);
                if (this._entIncidencia != null)
                {
                    this.Text = this._entIncidencia.Folio.ToString();
                }
                //Solo lectura para los datos de la incidencia para el formulario padre:
                this.SoloLectura = true;

               
                
                //Si se manejan unidades virtuales, entonces se indica al usuario:
                _entCorporacion = CorporacionMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intCorporacion.Value);


                if (_entCorporacion.UnidadesVirtuales)
                {
                    this.lblUnidad.Text = "VIRTUAL";
                }

                this._entCorporacionIncidencia = CorporacionIncidenciaMapper.Instance().GetOne(this._entIncidencia.Folio, this._entCorporacion.Clave);

                //****Obtiene los datos del despacho****
                DespachoIncidenciaList lstDespacho = DespachoIncidenciaMapper.Instance().GetByCorporacionIncidencia(this._entIncidencia.Folio, Aplicacion.UsuarioPersistencia.intCorporacion.Value);
                if (lstDespacho != null && lstDespacho.Count > 0)
                {
                    this._despachoIncidencia = lstDespacho[0];
                }
                else
                {
                    return;
                }

                DetalleDespachoIncidenciaList lstDetalleDespacho = DetalleDespachoIncidenciaMapper.Instance().GetByDespachoIncidencia(this._despachoIncidencia.Clave);


                if (!this._entCorporacion.UnidadesVirtuales)
                {
                    if (this._despachoIncidencia.ClaveUnidad.HasValue)
                    {
                        this._unidadAsignada = UnidadMapper.Instance().GetOne(this._despachoIncidencia.ClaveUnidad.Value);
                        this.lblUnidad.Text = this._unidadAsignada.Codigo;
                    }

                    if (this._despachoIncidencia.ClaveUnidadApoyo.HasValue)
                    {
                        this._unidadApoyo = UnidadMapper.Instance().GetOne(this._despachoIncidencia.ClaveUnidadApoyo.Value);
                        this.lblUnidadApoyo.Text = this._unidadApoyo.Clave.ToString();
                    }

                }

               
                if (lstDetalleDespacho != null && lstDetalleDespacho.Count > 0)
                {
                    int i = 1;
                    foreach (DetalleDespachoIncidencia objDetalleDespacho in lstDetalleDespacho)
                    {

                        Usuario entUsuario = UsuarioMapper.Instance().GetOne(objDetalleDespacho.ClaveUsuario);
                        

                        dgvComentarios.Rows.Add();

                        dgvComentarios[0,i -1].Value = objDetalleDespacho.Clave;
                        dgvComentarios[1, i - 1].Value = objDetalleDespacho.Descripcion;
                        dgvComentarios[2, i - 1].Value = entUsuario.NombrePropio;
                        dgvComentarios[3, i - 1].Value = objDetalleDespacho.HoraRegistro.ToString("dd/MM/aaaa hh:mm:ss");


                        i++;
                        
                    }
                    this.txtHoraDespacho.Focus();
                }
                //*********Carga los datos en el formulario*****
                this.txtHoraRecepcion.Text  = this._entIncidencia.HoraRecepcion.ToString("hh:mm:ss");
                if (this._despachoIncidencia.HoraDespachada.HasValue)
                {
                    this.txtHoraDespacho.Text = this._despachoIncidencia.HoraDespachada.Value.ToString("hh:mm:ss");
                }
                if (this._despachoIncidencia.HoraLlegada.HasValue)
                {
                    this.dtpHoraLlegada.Value = this._despachoIncidencia.HoraLlegada.Value;
                }
                if (this._despachoIncidencia.HoraLiberada.HasValue)
                {
                    this.dtpHoraLiberacion.Value = this._despachoIncidencia.HoraLiberada.Value;
                }

                //***********************************************


            //    }
            //    catch (System.Exception ex)
            //    {
            //        throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            //    }
            //}
            //catch (SAIExcepcion) { }
        }

        private void chkHoraLiberacion_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpHoraLiberacion.Enabled = this.chkHoraLiberacion.Checked;
        }

        private void SAIFrmIncidencia066Despacho_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void chkHoraLlegada_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpHoraLlegada.Enabled = this.chkHoraLlegada.Checked;
        }

        private void dgvComentarios_KeyUp(object sender, KeyEventArgs e)
        {
           
            base.SAIFrmIncidenciaKeyUp(e);

        }

        private void txtHoraRecepcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtHoraDespacho.Focus();
            }
            base.SAIFrmIncidenciaKeyUp(e);

        }

        private void txtHoraDespacho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpHoraLlegada.Focus();
            }
            base.SAIFrmIncidenciaKeyUp(e);

        }

        private void dtpHoraLlegada_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpHoraLiberacion.Focus();
            }
            base.SAIFrmIncidenciaKeyUp(e);

        }

        private void dtpHoraLlegada_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._despachoIncidencia != null)
                    {
                        this._despachoIncidencia.HoraLlegada = dtpHoraLlegada.Value;
                    }
                    DespachoIncidenciaMapper.Instance().Save(this._despachoIncidencia);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dtpHoraLiberacion_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._despachoIncidencia != null)
                    {
                        this._despachoIncidencia.HoraLiberada = dtpHoraLiberacion.Value;
                    }
                    DespachoIncidenciaMapper.Instance().Save(this._despachoIncidencia);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dtpHoraLlegada_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this._despachoIncidencia != null)
                    {
                        this._despachoIncidencia.HoraLlegada = dtpHoraLlegada.Value;
                    }
                    DespachoIncidenciaMapper.Instance().Save(this._despachoIncidencia);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dtpHoraLiberacion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {

                    if (this._despachoIncidencia != null)
                    {
                        this._despachoIncidencia.HoraLiberada = dtpHoraLiberacion.Value;
                    }
                    DespachoIncidenciaMapper.Instance().Save(this._despachoIncidencia);
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void dgvComentarios_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvComentarios_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    if (e.ColumnIndex != 1)
                    {
                        return;
                    }
                    if (dgvComentarios[e.ColumnIndex, e.RowIndex].Value == null)
                    {
                        return;
                    }

                    Usuario entUsuario = UsuarioMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intClaveUsuario);

                    dgvComentarios[2, e.RowIndex].Value = entUsuario.NombrePropio.ToUpper();
                    dgvComentarios[3, e.RowIndex].Value = DateTime.Now.ToString("dd/MM/aaaa hh:mm:ss").ToUpper();

                    if (this._despachoIncidencia == null)
                    {
                        if (this._entCorporacionIncidencia == null)
                        {
                            this._entCorporacionIncidencia = new CorporacionIncidencia();
                            this._entCorporacionIncidencia.Folio = this._entIncidencia.Folio;
                            this._entCorporacionIncidencia.ClaveCorporacion = this._entCorporacion.Clave;
                            CorporacionIncidenciaMapper.Instance().Insert(this._entCorporacionIncidencia);

                        }

                        this._despachoIncidencia = new DespachoIncidencia();

                        this._despachoIncidencia.ClaveUsuario = Aplicacion.UsuarioPersistencia.intClaveUsuario;
                        this._despachoIncidencia.ClaveCorporacion = this._entCorporacion.Clave;
                        this._despachoIncidencia.Folio = this._entIncidencia.Folio;
                        DespachoIncidenciaMapper.Instance().Insert(this._despachoIncidencia);

                    }

                    DetalleDespachoIncidencia entDetalleDespacho;

                    if (dgvComentarios[0, e.RowIndex].Value == null)
                    {
                        entDetalleDespacho = new DetalleDespachoIncidencia();
                        entDetalleDespacho.ClaveDespacho = this._despachoIncidencia.Clave;
                        entDetalleDespacho.ClaveUsuario = entUsuario.Clave;
                        entDetalleDespacho.Descripcion = dgvComentarios[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                        entDetalleDespacho.HoraRegistro = DateTime.Now;
                        DetalleDespachoIncidenciaMapper.Instance().Insert(entDetalleDespacho);
                        dgvComentarios[0, e.RowIndex].Value = entDetalleDespacho.Clave;
                    }
                    else
                    {
                        int Clave = int.Parse(dgvComentarios[0, e.RowIndex].Value.ToString());
                        entDetalleDespacho = DetalleDespachoIncidenciaMapper.Instance().GetOne(Clave);
                        entDetalleDespacho.ClaveDespacho = this._despachoIncidencia.Clave;
                        entDetalleDespacho.ClaveUsuario = entUsuario.Clave;
                        entDetalleDespacho.Descripcion = dgvComentarios[e.ColumnIndex, e.RowIndex].Value.ToString();
                        entDetalleDespacho.HoraRegistro = DateTime.Now;
                        DetalleDespachoIncidenciaMapper.Instance().Save(entDetalleDespacho);

                    }
                    //dgvComentarios[e.ColumnIndex, e.RowIndex].Value = dgvComentarios[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }
    }
}
