﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmDependencias089 : SAIFrmBase
    {
        protected int _iFolio;

        public SAIFrmDependencias089()
        {
            InitializeComponent();
        }

        public SAIFrmDependencias089(int iFolio)
        {
            this.InitializeComponent();
            _iFolio = iFolio;
        }

        private void SAIFrmDependencias089_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarGridView(_iFolio);
            this.LlenarDependencias();            
        }

        private void LlenarDependencias()
        {
            try
            {
                try
                {
                    Entidades.DependenciaList lstDependencia = Mappers.DependenciaMapper.Instance().GetAll();
                    if (lstDependencia.Count > 0)
                    {
                        foreach (Entidades.Dependencia dependencia in lstDependencia)
                        {
                            this.chklstDependencias.Items.Add(dependencia.Descripcion);
                        }
                        
                        this.chklstDependencias.CheckOnClick = true;
                    }

                    for(int i= 0; i < this.chklstDependencias.Items.Count; i++)
                    {                    
                        foreach(DataGridViewRow row in this.gvDependencias.Rows)
                        {
                            if (Convert.ToString(row.Cells["Dependencia"].Value) == Convert.ToString(this.chklstDependencias.Items[i]))
                            {
                                this.chklstDependencias.SetItemChecked(i, true);
                            }
                        }
                    }
                    lstDependencia = null;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void LlenarGridView(int iFolio)
        {

            DataTable dtDependencias = new DataTable("Depentencias");
            dtDependencias.Columns.Add(new DataColumn("ClaveDependencia", Type.GetType("System.Int32")));
            dtDependencias.Columns.Add(new DataColumn("Dependencia", Type.GetType("System.String")));
            dtDependencias.Columns.Add(new DataColumn("Folio", Type.GetType("System.Int32")));
            dtDependencias.Columns.Add(new DataColumn("FechaEnvioDependencia", Type.GetType("System.String")));
            dtDependencias.Columns.Add(new DataColumn("FechaNotificacion", Type.GetType("System.String")));            

            Entidades.IncidenciaDependenciaList lstIncidenciaDependencias = Mappers.IncidenciaDependenciaMapper.Instance().GetByIncidencia(iFolio);
            if (lstIncidenciaDependencias.Count > 0)
            {
                foreach (Entidades.IncidenciaDependencia insDependencia in lstIncidenciaDependencias)
                {
                    string fed = insDependencia.FechaEnvioDependencia.HasValue ? insDependencia.FechaEnvioDependencia.Value.ToShortDateString() : string.Empty;
                    string fn = insDependencia.FechaNotificacion.HasValue ? insDependencia.FechaNotificacion.Value.ToShortDateString() : string.Empty;
                    object[] registro = { insDependencia.ClaveDependencia, Mappers.DependenciaMapper.Instance().GetOne(insDependencia.ClaveDependencia).Descripcion,
                                            insDependencia.Folio, 
                                            fed, fn};
                    dtDependencias.Rows.Add(registro);
                }
            }

            this.gvDependencias.DataSource = dtDependencias;
            this.gvDependencias.Columns["ClaveDependencia"].Visible = false;
            this.gvDependencias.Columns["Dependencia"].ReadOnly = true;
            this.gvDependencias.Columns["Folio"].ReadOnly = true;
        }

        private void chklstDependencias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }       

        private void chklstDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int indexSel = this.chklstDependencias.SelectedIndex;
                    if (this.chklstDependencias.GetItemCheckState(indexSel) == CheckState.Checked)
                    {
                        if (this.gvDependencias.Rows.Count == 0)
                        {
                            Entidades.Dependencia dependencia = Mappers.DependenciaMapper.Instance().GetByDescripcion(Convert.ToString(this.chklstDependencias.Items[indexSel]));
                            Entidades.IncidenciaDependencia newInsDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.IncidenciaDependencia();
                            newInsDependencia.ClaveDependencia = dependencia.Clave;
                            newInsDependencia.Folio = _iFolio;
                            Mappers.IncidenciaDependenciaMapper.Instance().Insert(newInsDependencia);
                        }
                        else
                        {
                            bool existe = false;
                            foreach (DataGridViewRow rowGv in this.gvDependencias.Rows)
                            {
                                if (Convert.ToString(rowGv.Cells["Dependencia"].Value) == Convert.ToString(this.chklstDependencias.SelectedItem))
                                {
                                    existe = true;
                                    break;
                                }
                                else { existe = false; }
                            }
                            if (!existe)
                            {
                                Entidades.Dependencia dependencia = Mappers.DependenciaMapper.Instance().GetByDescripcion(Convert.ToString(this.chklstDependencias.Items[indexSel]));
                                Entidades.IncidenciaDependencia newInsDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.IncidenciaDependencia();
                                newInsDependencia.ClaveDependencia = dependencia.Clave;
                                newInsDependencia.Folio = _iFolio;
                                Mappers.IncidenciaDependenciaMapper.Instance().Insert(newInsDependencia);
                            }
                        }
                    }
                    else if (this.chklstDependencias.GetItemCheckState(indexSel) == CheckState.Unchecked)
                    {
                        Entidades.Dependencia dependencia = Mappers.DependenciaMapper.Instance().GetByDescripcion(Convert.ToString(this.chklstDependencias.SelectedItem));
                        foreach (DataGridViewRow rowGv in this.gvDependencias.Rows)
                        {
                            if (Convert.ToString(rowGv.Cells["Dependencia"].Value) == dependencia.Descripcion)
                            {
                                Entidades.IncidenciaDependencia delInsDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.IncidenciaDependencia(dependencia.Clave, _iFolio);
                                Mappers.IncidenciaDependenciaMapper.Instance().Delete(delInsDependencia); 
                                break;
                            }                            
                        }
                    }
                    this.LlenarGridView(_iFolio);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDependencias_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                switch (e.ColumnIndex)
                {
                    case 3:
                        if (this.gvDependencias[e.ColumnIndex, e.RowIndex].Value != null && Convert.ToString(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value) != string.Empty)
                        {
                            DateTime fechaCapturada;
                            if (DateTime.TryParse(Convert.ToString(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value), out fechaCapturada))
                            {
                                if (Convert.ToDateTime(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value) > DateTime.Today)
                                {
                                    this.gvDependencias[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                                    throw new SAIExcepcion("La fecha de envío a dependencia no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                                }
                                else
                                {
                                    Entidades.IncidenciaDependencia updInsDependencia = Mappers.IncidenciaDependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias["ClaveDependencia", e.RowIndex].Value), Convert.ToInt32(this.gvDependencias["Folio", e.RowIndex].Value)); ;
                                    if (this.gvDependencias["FechaEnvioDependencia", e.RowIndex].Value != DBNull.Value)
                                        updInsDependencia.FechaEnvioDependencia = Convert.ToDateTime(this.gvDependencias["FechaEnvioDependencia", e.RowIndex].Value);
                                    if (this.gvDependencias["FechaNotificacion", e.RowIndex].Value != DBNull.Value)
                                        updInsDependencia.FechaNotificacion = Convert.ToDateTime(this.gvDependencias["FechaNotificacion", e.RowIndex].Value);
                                    Mappers.IncidenciaDependenciaMapper.Instance().Save(updInsDependencia);
                                }
                            }
                            else
                            {
                                this.gvDependencias[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                                throw new SAIExcepcion("El campo capturado no es valido.", this);
                            }
                        }
                        break;
                    case 4:
                        if (this.gvDependencias[e.ColumnIndex, e.RowIndex].Value != null && Convert.ToString(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value) != string.Empty)
                        {
                            DateTime fechaCapturada;
                            if (DateTime.TryParse(Convert.ToString(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value), out fechaCapturada))
                            {
                                if (Convert.ToDateTime(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value) > DateTime.Today)
                                {
                                    this.gvDependencias[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                                    throw new SAIExcepcion("La fecha de envío a dependencia no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                                }
                                else
                                {
                                    Entidades.IncidenciaDependencia updInsDependencia = Mappers.IncidenciaDependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias["ClaveDependencia", e.RowIndex].Value), Convert.ToInt32(this.gvDependencias["Folio", e.RowIndex].Value)); ;
                                    if (this.gvDependencias["FechaEnvioDependencia", e.RowIndex].Value != DBNull.Value)
                                        updInsDependencia.FechaEnvioDependencia = Convert.ToDateTime(this.gvDependencias["FechaEnvioDependencia", e.RowIndex].Value);
                                    if (this.gvDependencias["FechaNotificacion", e.RowIndex].Value != DBNull.Value)
                                        updInsDependencia.FechaNotificacion = Convert.ToDateTime(this.gvDependencias["FechaNotificacion", e.RowIndex].Value);
                                    Mappers.IncidenciaDependenciaMapper.Instance().Save(updInsDependencia);
                                }
                            }
                            else
                            {
                                this.gvDependencias[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                                throw new SAIExcepcion("El campo capturado no es valido.", this);
                            }
                        }
                        break;
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void gvDependencias_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvDependencias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }        
    }
}
