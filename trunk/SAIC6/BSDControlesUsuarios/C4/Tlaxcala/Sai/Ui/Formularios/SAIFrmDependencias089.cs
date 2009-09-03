using System;
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
        //protected int _iFolio;
        protected Entidades.Incidencia _entIncidencia089;

        public SAIFrmDependencias089()
        {
            InitializeComponent();
        }

        public SAIFrmDependencias089(Entidades.Incidencia _Incidencia089)
        {
            this.InitializeComponent();
            this._entIncidencia089 = _Incidencia089;
            this.Text = "Folio " + Convert.ToString(this._entIncidencia089.Folio);
        }

        /// <summary>
        /// Evento que se ejecuta cuando se carga el Formulario de Dependencias
        /// </summary>
        private void SAIFrmDependencias089_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarGridView(this._entIncidencia089.Folio);
            this.LlenarDependencias();
        }
        /// <summary>
        /// Funcion que llena el listado de Dependencias y selecciona aquellas que ya estan agregadas a la incidencia
        /// </summary>
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
        /// <summary>
        /// Funcion que llena el DataGrid con las Dependencias que se han seleccionado para la incidencia
        /// </summary>
        /// <param name="iFolio"></param>
        private void LlenarGridView(int iFolio)
        {
            //Se crea DataTable para Mostrar la descripcion de las Dependencias
            DataTable dtDependencias = new DataTable("Depentencias");
            dtDependencias.Columns.Add(new DataColumn("ClaveDependencia", Type.GetType("System.Int32")));
            dtDependencias.Columns.Add(new DataColumn("Dependencia", Type.GetType("System.String")));
            dtDependencias.Columns.Add(new DataColumn("Folio", Type.GetType("System.Int32")));
            dtDependencias.Columns.Add(new DataColumn("Fecha de Envio Dependencia", Type.GetType("System.String")));
            dtDependencias.Columns.Add(new DataColumn("Fecha de Notificacion", Type.GetType("System.String")));            
            //Se obtiene los datos para el llenado del Datatable
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
            else
            {
                //Si no se ha asignado Dependencias o se han quitado de la lista
                //se regresa a Estatus 2
                this._entIncidencia089.ClaveEstatus = 2;
                Mappers.IncidenciaMapper.Instance().Save(this._entIncidencia089);
            }

            this.gvDependencias.DataSource = dtDependencias;
            //Se ocultan columnas al usuario
            this.gvDependencias.Columns["ClaveDependencia"].Visible = false;
            this.gvDependencias.Columns["Dependencia"].ReadOnly = true;
            this.gvDependencias.Columns["Folio"].Visible = false;
        }
        /// <summary>
        /// Evento que se ejecuta cuando se selecciona una dependencia de la lista
        /// </summary>
        private void chklstDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    //Se obtiene indice de la dependencia seleccionada
                    int indexSel = this.chklstDependencias.SelectedIndex;
                    //si la dependencia seleccionada esta checada
                    if (this.chklstDependencias.GetItemCheckState(indexSel) == CheckState.Checked)
                    {
                        //si no existen registros en el datagrid
                        if (this.gvDependencias.Rows.Count == 0)
                        {
                            //Se agrega una dependencia a la incidencia
                            Entidades.Dependencia dependencia = Mappers.DependenciaMapper.Instance().GetByDescripcion(Convert.ToString(this.chklstDependencias.Items[indexSel]));
                            Entidades.IncidenciaDependencia newInsDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.IncidenciaDependencia();
                            newInsDependencia.ClaveDependencia = dependencia.Clave;
                            newInsDependencia.Folio = this._entIncidencia089.Folio;
                            Mappers.IncidenciaDependenciaMapper.Instance().Insert(newInsDependencia);
                            //Se actualiza el estatus
                            this._entIncidencia089.ClaveEstatus = 3;
                            Mappers.IncidenciaMapper.Instance().Save(this._entIncidencia089);
                        }
                        else
                        {
                            bool existe = false;
                            //Se recorre los registros existentes 
                            foreach (DataGridViewRow rowGv in this.gvDependencias.Rows)
                            {
                                if (Convert.ToString(rowGv.Cells["Dependencia"].Value) == Convert.ToString(this.chklstDependencias.SelectedItem))
                                {
                                    //Si esiste ya la dependencia no se marca bandera
                                    existe = true;
                                    break;
                                }
                                else { existe = false; }
                            }
                            //si no existe se agrega la dependencia a la incidencia
                            if (!existe)
                            {
                                Entidades.Dependencia dependencia = Mappers.DependenciaMapper.Instance().GetByDescripcion(Convert.ToString(this.chklstDependencias.Items[indexSel]));
                                Entidades.IncidenciaDependencia newInsDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.IncidenciaDependencia();
                                newInsDependencia.ClaveDependencia = dependencia.Clave;
                                newInsDependencia.Folio = this._entIncidencia089.Folio;
                                Mappers.IncidenciaDependenciaMapper.Instance().Insert(newInsDependencia);
                                //Se actualiza el estatus de la incidencia
                                this._entIncidencia089.ClaveEstatus = 3;
                                Mappers.IncidenciaMapper.Instance().Save(this._entIncidencia089);
                            }
                        }
                    }//Si la dependencia seleccionada no esta checada
                    else if (this.chklstDependencias.GetItemCheckState(indexSel) == CheckState.Unchecked)
                    {
                        Entidades.Dependencia dependencia = Mappers.DependenciaMapper.Instance().GetByDescripcion(Convert.ToString(this.chklstDependencias.SelectedItem));
                        //Se recorren registros para eliminarse en caso de que ya se hubiese agregado
                        foreach (DataGridViewRow rowGv in this.gvDependencias.Rows)
                        {
                            if (Convert.ToString(rowGv.Cells["Dependencia"].Value) == dependencia.Descripcion)
                            {
                                Entidades.IncidenciaDependencia delInsDependencia = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.IncidenciaDependencia(dependencia.Clave, this._entIncidencia089.Folio);
                                Mappers.IncidenciaDependenciaMapper.Instance().Delete(delInsDependencia); 
                                break;
                            }                            
                        }
                    }
                    //Actualiza el DataGrid
                    this.LlenarGridView(this._entIncidencia089.Folio);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
            
        }
/// <summary>
/// Evento que se ejecuta para cerrar la ventana
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Se recorre el Datagrid para actualizar el estatus para cuando las fechas de envio y de notificacion
        /// esten lleneas en todas las dependencias agregadas
        /// </summary>
        private void ChecarParaActualizarEstatus()
        {
            try 
            {
                try 
                {
                    bool bCompleto = false;
                    foreach (DataGridViewRow row in this.gvDependencias.Rows)
                    {
                        if (row.Cells["Fecha de Envio Dependencia"].Value != DBNull.Value && Convert.ToString(row.Cells["Fecha de Envio Dependencia"].Value) != string.Empty)
                        {
                            bCompleto = true;
                        }
                        else 
                        {
                            bCompleto = false;
                        }

                        if (row.Cells["Fecha de Notificacion"].Value != DBNull.Value && Convert.ToString(row.Cells["Fecha de Notificacion"].Value) != string.Empty)
                        {
                            bCompleto = true;
                        }
                        else
                        {
                            bCompleto = false;
                        }
                    }
                    if (bCompleto)
                    {
                        //Si estan llenas todas las fechas se actualiza estatus
                        this._entIncidencia089.ClaveEstatus = 4;
                        Mappers.IncidenciaMapper.Instance().Save(this._entIncidencia089);
                    }
                    else 
                    {
                        if (this.gvDependencias.Rows.Count == 0)
                        {
                            this._entIncidencia089.ClaveEstatus = 2;                            
                        }
                        else if (this.gvDependencias.Rows.Count > 0)
                        {
                            this._entIncidencia089.ClaveEstatus = 3;                            
                        }
                        Mappers.IncidenciaMapper.Instance().Save(this._entIncidencia089);
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message, this); }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Se actualiza las fechas en la base de datos, cuando se modifica los campos fecha de notificacion y fecha de envio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDependencias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                                    throw new SAIExcepcion("La fecha de envío a dependencia no se encuentra en el formato correcto (dd/MM/AAAA), debe de ser una fecha menor o igual al dia actual", this);
                                }
                                else
                                {
                                    Entidades.IncidenciaDependencia updInsDependencia = Mappers.IncidenciaDependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias["ClaveDependencia", e.RowIndex].Value), Convert.ToInt32(this.gvDependencias["Folio", e.RowIndex].Value)); ;
                                    if (this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value != DBNull.Value && Convert.ToString(this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value) != string.Empty)
                                        updInsDependencia.FechaEnvioDependencia = Convert.ToDateTime(this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value);
                                    else
                                        updInsDependencia.FechaEnvioDependencia = new Nullable<DateTime>();
                                    if (this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value != DBNull.Value && Convert.ToString(this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value) != string.Empty)
                                        updInsDependencia.FechaNotificacion = Convert.ToDateTime(this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value);
                                    else
                                        updInsDependencia.FechaNotificacion = new Nullable<DateTime>();
                                    Mappers.IncidenciaDependenciaMapper.Instance().Save(updInsDependencia);
                                }
                            }
                            else
                            {
                                this.gvDependencias[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                                throw new SAIExcepcion("El campo capturado no es valido.", this);
                            }
                        }
                        else if (Convert.ToString(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value) == string.Empty)
                        {
                            Entidades.IncidenciaDependencia updInsDependencia = Mappers.IncidenciaDependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias["ClaveDependencia", e.RowIndex].Value), Convert.ToInt32(this.gvDependencias["Folio", e.RowIndex].Value)); ;

                            updInsDependencia.FechaEnvioDependencia = new Nullable<DateTime>();
                            if (this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value != DBNull.Value && Convert.ToString(this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value) != string.Empty)
                                updInsDependencia.FechaNotificacion = Convert.ToDateTime(this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value);
                            else
                                updInsDependencia.FechaNotificacion = new Nullable<DateTime>();
                            Mappers.IncidenciaDependenciaMapper.Instance().Save(updInsDependencia);
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
                                    throw new SAIExcepcion("La fecha de envío a dependencia no se encuentra en el formato correcto (dd/MM/AAAA), debe de ser una fecha menor o igual al dia actual", this);
                                }
                                else
                                {
                                    Entidades.IncidenciaDependencia updInsDependencia = Mappers.IncidenciaDependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias["ClaveDependencia", e.RowIndex].Value), Convert.ToInt32(this.gvDependencias["Folio", e.RowIndex].Value)); ;
                                    if (this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value != DBNull.Value && Convert.ToString(this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value) != string.Empty)
                                        updInsDependencia.FechaEnvioDependencia = Convert.ToDateTime(this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value);
                                    else
                                        updInsDependencia.FechaEnvioDependencia = new Nullable<DateTime>();
                                    if (this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value != DBNull.Value && Convert.ToString(this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value) != string.Empty)
                                        updInsDependencia.FechaNotificacion = Convert.ToDateTime(this.gvDependencias["Fecha de Notificacion", e.RowIndex].Value);
                                    else
                                        updInsDependencia.FechaNotificacion = new Nullable<DateTime>();
                                    Mappers.IncidenciaDependenciaMapper.Instance().Save(updInsDependencia);
                                }
                            }
                            else if (Convert.ToString(this.gvDependencias[e.ColumnIndex, e.RowIndex].Value) != string.Empty)
                            {
                                this.gvDependencias[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                                throw new SAIExcepcion("El campo capturado no es valido.", this);
                            }
                        }
                        else
                        {
                            Entidades.IncidenciaDependencia updInsDependencia = Mappers.IncidenciaDependenciaMapper.Instance().GetOne(Convert.ToInt32(this.gvDependencias["ClaveDependencia", e.RowIndex].Value), Convert.ToInt32(this.gvDependencias["Folio", e.RowIndex].Value)); ;
                            if (this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value != DBNull.Value && Convert.ToString(this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value) != string.Empty)
                                updInsDependencia.FechaEnvioDependencia = Convert.ToDateTime(this.gvDependencias["Fecha de Envio Dependencia", e.RowIndex].Value);
                            else
                                updInsDependencia.FechaEnvioDependencia = new Nullable<DateTime>();
                            updInsDependencia.FechaNotificacion = new Nullable<DateTime>();
                            Mappers.IncidenciaDependenciaMapper.Instance().Save(updInsDependencia);
                        }
                        break;
                }
            }
            catch (SAIExcepcion)
            { }
        }
        /// <summary>
        /// Evento que se ejecuta antes de cerrar la vantana por completo, y valida los campos para actualizar estatus
        /// </summary>
        private void SAIFrmDependencias089_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChecarParaActualizarEstatus();
        }
    }
}
