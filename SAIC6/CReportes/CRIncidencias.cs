using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using Microsoft.SqlServer.MessageBox;

namespace BSD.C4.Tlaxcala.Sai
{
    public partial class CRIncidencias : Form
    {
        private const int cveEstado = 29;
        private int tipoReporte;
        private CDats cdat;
        private CConn cnn;
        private enum STSINCIDENCIA {Todas,Nueva,Pendiente,Activa,Cerrada,Cancelada}; //Inicia en Todas=0
        public  enum TIPOREPORTE { Punteo, XLS, Supervisor }; //Inicia en Punteo=0
        EventHandler chkTodosEvent;
        
        public CRIncidencias()
        {
            InitializeComponent();
        }

        public CRIncidencias(ref CDats cdat, TIPOREPORTE tipoReporte)
        {
            InitializeComponent();
            this.cdat = cdat;
            this.tipoReporte = (int) tipoReporte;
        }

        private void CRIncidencias_Load(object sender, EventArgs e)
        {
            cnn = new CConn(cdat);
            chkTodosEvent = new System.EventHandler(chkTodos_CheckedChanged);
            cboSistema.BackColor = Color.FromArgb(255, 255, 192);
            cboSistema.Focus();
            Fill_cboSistema();
            Fill_cboTipoIncidencia();
            Fill_Prioridad();
            Fill_cboMunicipio();
            Fill_cboLocalidad();
            Fill_cboColonia();
            Fill_cboCP();
        }

        private void Fill_cboSistema()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Sistema");
            query.SelectColumns("Clave", "Descripcion");
            query.AddWhere("Descripcion", Comparison.Like, "%066%",1);
            query.AddWhere("Descripcion", Comparison.Like, "%089%",2);
            query.AddOrderBy("Descripcion", Sorting.Ascending);

            string statement = "SELECT 0 AS Clave, '<- - Sistema - ->' AS Descripcion UNION " + query.BuildQuery();

            cboSistema.DataSource = cnn.GetData(statement);
            cboSistema.DisplayMember = "Descripcion";
            cboSistema.ValueMember = "Clave"; 
        }

        private void Fill_Prioridad()
        { 
            DataSet prioridadDataSet = new DataSet();
            prioridadDataSet.Tables.Add("prioridad");

            prioridadDataSet.Tables["prioridad"].Columns.Add("Descripcion");
            prioridadDataSet.Tables["prioridad"].Columns.Add("Valor");

            // add sample rows with values
            prioridadDataSet.Tables["prioridad"].Rows.Add();
            prioridadDataSet.Tables["prioridad"].Rows[0][0] = "<- - - - Todas - - - ->";
            prioridadDataSet.Tables["prioridad"].Rows[0][1] = 0;
            for (int i = 1; i <= 5; i++)
            {
                prioridadDataSet.Tables["prioridad"].Rows.Add();
                prioridadDataSet.Tables["prioridad"].Rows[i][0] = i.ToString();
                prioridadDataSet.Tables["prioridad"].Rows[i][1] = i;
            }
            
            cboPrioridad.DataSource = prioridadDataSet;
            cboPrioridad.DisplayMember = "prioridad.Descripcion";
            cboPrioridad.ValueMember = "prioridad.Valor";
        }

        private void Fill_cboTipoIncidencia()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("TipoIncidencia");
            query.SelectColumns("Clave", "Descripcion");
            //query.TopRecords = maxRecords;

            query.AddWhere("ClaveSistema", Comparison.Equals,
                                cboSistema.SelectedValue);
            query.AddOrderBy("Descripcion", Sorting.Ascending);

            string statement = "SELECT 0 AS Clave, '<- - - - Todos - - - ->' AS Descripcion UNION " + query.BuildQuery();

            cboTipoIncidencia.DataSource = cnn.GetData(statement);
            cboTipoIncidencia.DisplayMember = "Descripcion";
            cboTipoIncidencia.ValueMember = "Clave";
        }

        private void Fill_cboMunicipio()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Municipio");
            query.SelectColumns("Clave", "Nombre");

            query.AddWhere("ClaveEstado", Comparison.Equals,
                                cveEstado);
            query.AddOrderBy("Nombre",Sorting.Ascending);
            
            string statement = "SELECT 0 AS Clave, '<- - - - Todos - - - ->' AS Nombre UNION " + query.BuildQuery();

            cboMunicipio.DataSource = cnn.GetData(statement);
            cboMunicipio.DisplayMember = "Nombre";
            cboMunicipio.ValueMember = "Clave";
        }

        private void Fill_cboLocalidad()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Localidad");
            query.SelectColumns("Clave", "Nombre");

            query.AddWhere("ClaveMunicipio", Comparison.Equals,
                                cboMunicipio.SelectedValue);
            query.AddOrderBy("Nombre", Sorting.Ascending);
            
            string statement = "SELECT 0 AS Clave, '<- - - - Todas - - - ->' AS Nombre UNION " + query.BuildQuery();
            
            cboLocalidad.DataSource = cnn.GetData(statement);
            cboLocalidad.DisplayMember = "Nombre";
            cboLocalidad.ValueMember = "Clave";
        }

        private void Fill_cboColonia()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Colonia");
            query.SelectColumns("Colonia.Clave As Clave", "Colonia.Nombre As Nombre");
            query.AddJoin(JoinType.InnerJoin, "Localidad", "Clave", Comparison.Equals, "Colonia", "ClaveLocalidad");
            query.AddWhere("Localidad.Clave", Comparison.Equals,
                                cboLocalidad.SelectedValue);
            
            query.AddOrderBy("Colonia.Nombre", Sorting.Ascending);

            string statement = query.BuildQuery();
            string statement2 = "UNION SELECT 0 AS Clave, '<- - - - Todas - - - ->' AS Nombre ";
            statement = statement.Insert(statement.IndexOf("ORDER BY"), statement2);
            
            cboColonia.DataSource = cnn.GetData(statement);
            cboColonia.DisplayMember = "Nombre";
            cboColonia.ValueMember = "Clave";
        }

        private void Fill_cboCP()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("CodigoPostal");
            query.SelectColumns("CodigoPostal.Clave AS Clave", "CodigoPostal.Valor AS Valor");
            query.AddJoin(JoinType.InnerJoin, "Colonia", "ClaveCodigoPostal", Comparison.Equals, "CodigoPostal", "Clave");
            query.AddWhere("Colonia.Clave", Comparison.Equals,
                                cboColonia.SelectedValue);

            query.AddOrderBy("CodigoPostal.Valor", Sorting.Ascending);

            string statement = query.BuildQuery();
            string statement2 = "UNION SELECT 0 AS Clave, '<- - - - Todos - - - ->' AS Valor ";
            statement = statement.Insert(statement.IndexOf("ORDER BY"), statement2);

            cboCP.DataSource = cnn.GetData(statement);
            cboCP.DisplayMember = "Valor";
            cboCP.ValueMember = "Clave";
        }

        private void Fill_chkUsuarios()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            string statement;
            //Llena la lista de Operadores
            if (cboSistema.Text.Trim() == "066" || cboSistema.Text.Trim() == "089")
            {
                query.SelectFromTable("Usuario");
                query.SelectColumns("Usuario.Clave", "Usuario.NombrePropio");

                query.AddWhere("Activo", Comparison.Equals, true);
                query.AddWhere("Despachador", Comparison.Equals, false);
                if (cboEntidades.SelectedIndex != 0 && cboSistema.Text.Trim() == "066")
                {
                    query.AddJoin(JoinType.LeftJoin, "UsuarioCorporacion", "ClaveUsuario", Comparison.Equals, "Usuario", "Clave");
                    query.AddWhere("UsuarioCorporacion.ClaveCorporacion", Comparison.Equals, cboEntidades.SelectedValue);
                }
                statement = query.BuildQuery();
                
                chkOperadores.DataSource = cnn.GetData(statement);
                chkOperadores.DisplayMember = "NombrePropio";
                chkOperadores.ValueMember = "Clave";
            }

            //Llena la lista de Despachadores
            chkDespachadores.DataSource = null;
            if (cboSistema.Text.Trim() == "066")
            {
                query = new SelectQueryBuilder();
                query.SelectFromTable("Usuario");
                query.SelectColumns("Usuario.Clave", "Usuario.NombrePropio");

                query.AddWhere("Activo", Comparison.Equals, true);
                query.AddWhere("Despachador", Comparison.Equals, true);
                if (cboEntidades.SelectedIndex != 0 && cboSistema.Text.Trim() == "066")
                {
                    query.AddJoin(JoinType.LeftJoin, "UsuarioCorporacion", "ClaveUsuario", Comparison.Equals, "Usuario", "Clave");
                    query.AddWhere("UsuarioCorporacion.ClaveCorporacion", Comparison.Equals, cboEntidades.SelectedValue);
                }
                statement = query.BuildQuery();

                chkDespachadores.DataSource = cnn.GetData(statement);
                chkDespachadores.DisplayMember = "NombrePropio";
                chkDespachadores.ValueMember = "Clave";
            }
        }

        private void Fill_cboEntidades()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            if (cboSistema.Text.Trim() == "066")
            {
                query.SelectFromTable("Corporacion");
                query.SelectColumns("Clave", "Descripcion");

                query.AddWhere("Activo", Comparison.Equals,
                                    true);
                query.AddWhere("ClaveSistema", Comparison.Equals,
                                    cboSistema.SelectedValue);
                query.AddOrderBy("Descripcion", Sorting.Ascending);

                string statement = "SELECT 0 AS Clave, '<- - - - Todas - - - ->' AS Descripcion UNION " + query.BuildQuery();

                cboEntidades.DataSource = cnn.GetData(statement);
                cboEntidades.DisplayMember = "Descripcion";
                cboEntidades.ValueMember = "Clave";
            }
            else if (cboSistema.Text.Trim() == "089")
            {
                query.SelectFromTable("Dependencia");
                query.SelectColumns("Clave", "Descripcion");

                query.AddOrderBy("Descripcion", Sorting.Ascending);

                string statement = "SELECT 0 AS Clave, '<- - - - Todas - - - ->' AS Descripcion UNION " + query.BuildQuery();

                cboEntidades.DataSource = cnn.GetData(statement);
                cboEntidades.DisplayMember = "Descripcion";
                cboEntidades.ValueMember = "Clave";
            }
            return;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /*MRV*/
            /*
            if (tipoReporte.Equals((int)TIPOREPORTE.Punteo))
            {
                cboCP.Text = generateQueryPunteo();
                //MessageBox.Show(generateQueryPunteo());
            }
            return;
            */
            /*MIKE*/
            
            try
            {
                if (tipoReporte.Equals((int)TIPOREPORTE.Punteo))
                {                    
                    new CSetPoint(ref cdat, "map.xml", Application.StartupPath, generateQueryPunteo()).ShowDialog();
                }
                if (tipoReporte.Equals((int)TIPOREPORTE.XLS))
                {
                    SaveFileDialog myDialog = new SaveFileDialog();
                    myDialog.Filter = "Excel Files (*.xls)|*.xls";
                    myDialog.FilterIndex = 1;
                    myDialog.RestoreDirectory = true;
                    myDialog.AddExtension = true;
                    if (myDialog.ShowDialog() == DialogResult.OK)
                    {
                        SqlDataReader rdr = cnn.EjecQuery(generateQueryPunteo());
                        if (rdr != null)
                        {
                            CXls xls = new CXls(cnn);
                            if(!xls.saveToXLS(rdr, myDialog.FileName))
                                throw new Exception("No se pudo generar el archivo " + myDialog.FileName);
                        }                    
                        else                        
                            throw new ApplicationException("Archivo generado con éxito.");                                            
                    }
                }
                if (tipoReporte.Equals((int)TIPOREPORTE.Supervisor))
                {                    
                    new CfrmSupervisor(ref cdat, generateQueryPunteo()).ShowDialog();
                }
                this.Close();
            }
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException("Información de la aplicación", ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Information,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = "Sistema de Administración de Incidencias.";

                DialogResult result = box.Show(this); ;
                if (result == DialogResult.OK)
                    new CFrmConfDB().ShowDialog();
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception("Error en la aplicación", ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = "Sistema de Administración de Incidencias.";
                DialogResult result = box.Show(this);
                this.Close();
            }
        }
       
        private void cboSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            cboSistema.BackColor = Color.FromArgb(255, 255, 192);
            
            if (cboSistema.SelectedIndex == 0)
            {
                cboEntidades.Enabled = false;
                chkOperadoresTodos.Enabled = false;
                chkOperadores.Enabled = false;
                chkDespachadoresTodos.Enabled = false;
                chkDespachadores.Enabled = false;
                return;
            }

            Fill_cboTipoIncidencia();
            cboEntidades.Enabled = true;
            Fill_cboEntidades();
            if (cboSistema.Text.Trim() == "066")
            {
                chkOperadoresTodos.Enabled = true;
                chkOperadores.Enabled = true;
                chkDespachadoresTodos.Enabled = true;
                chkDespachadores.Enabled = true;
            }
            else
                if (cboSistema.Text.Trim() == "089")
                {
                    chkOperadoresTodos.Enabled = true;
                    chkOperadores.Enabled = true;
                    chkDespachadoresTodos.Enabled = false;
                    chkDespachadores.Enabled = false;
                }

            Fill_chkUsuarios();
            return;
        }

        private void cboPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cboPrioridad.ValueMember.ToString());
        }

        private void cboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_cboLocalidad();
        }

        private void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_cboColonia();
        }

        private void cboColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_cboCP();
        }

        private void chkRecepcion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecepcion.Checked == true)
            {
                dteRecepcionIni.Enabled = true;
                dteRecepcionFin.Enabled = true;
            }
            else
            {
                dteRecepcionIni.Enabled = false;
                dteRecepcionFin.Enabled = false;
            }
        }

        private void chkDespacho_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDespacho.Checked == true)
            {
                dteDespachoIni.Enabled = true;
                dteDespachoFin.Enabled = true;
            }
            else
            {
                dteDespachoIni.Enabled = false;
                dteDespachoFin.Enabled = false;
            }
        }

        private void chkCierre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCierre.Checked == true)
            {
                dteCierreIni.Enabled = true;
                dteCierreFin.Enabled = true;
            }
            else
            {
                dteCierreIni.Enabled = false;
                dteCierreFin.Enabled = false;
            }
        }

        private string generateQueryPunteo()
        {
            string statement;
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Incidencia");
            query.Distinct=true;
            query.SelectColumns("Incidencia.Folio", "Incidencia.Descripcion", "Incidencia.ClaveDenunciante", "EstatusIncidencia.Descripcion AS Estatus", "TipoIncidencia.Descripcion AS Tipo",
                "Municipio.Nombre AS NombreMpo", "Localidad.Nombre AS NombreLoc", "Colonia.Nombre AS NombreCol", "CodigoPostal.Valor AS CP", 
                "Incidencia.ClaveCoordenada", "Incidencia.ClaveMunicipio", "Incidencia.ClaveLocalidad", "Incidencia.ClaveColonia", "Incidencia.ClaveCodigoPostal");
            
            query.AddJoin(JoinType.InnerJoin, "EstatusIncidencia", "Clave", Comparison.Equals, "Incidencia", "ClaveEstatus");
            query.AddJoin(JoinType.InnerJoin, "TipoIncidencia", "Clave", Comparison.Equals, "Incidencia", "ClaveTipo");
            query.AddJoin(JoinType.LeftJoin, "DespachoIncidencia", "Folio", Comparison.Equals, "Incidencia", "Folio");
            query.AddJoin(JoinType.LeftJoin, "Municipio", "Clave", Comparison.Equals, "Incidencia", "ClaveMunicipio");
            query.AddJoin(JoinType.LeftJoin, "Colonia", "Clave", Comparison.Equals, "Incidencia", "ClaveColonia");
            query.AddJoin(JoinType.LeftJoin, "CodigoPostal", "Clave", Comparison.Equals, "Incidencia", "ClaveCodigoPostal");
            query.AddJoin(JoinType.LeftJoin, "Localidad", "Clave", Comparison.Equals, "Incidencia", "ClaveLocalidad");
            query.AddJoin(JoinType.LeftJoin, "CorporacionIncidencia", "Folio", Comparison.Equals, "Incidencia", "Folio");
            query.AddJoin(JoinType.LeftJoin, "IncidenciaDependencia", "Folio", Comparison.Equals, "Incidencia", "Folio");

            if (int.Parse(cboSistema.SelectedValue.ToString()) != 0)
                query.AddWhere("TipoIncidencia.ClaveSistema", Comparison.Equals, cboSistema.SelectedValue, 1);
            if (int.Parse(cboTipoIncidencia.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveTipo", Comparison.Equals, cboTipoIncidencia.SelectedValue, 1);
            if (int.Parse(cboPrioridad.SelectedValue.ToString()) != 0)
                query.AddWhere("TipoIncidencia.Prioridad", Comparison.Equals, cboPrioridad.SelectedValue, 1);
            
                string strListaEstatus = "";
                if (chkNuevas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Nueva + ",";
                if (chkPendientes.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Pendiente + ",";
                if (chkActivas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Activa + ",";
                if (chkCerradas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Cerrada + ",";
                if (chkCanceladas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Cancelada + ",";
                if (chkTodos.Checked == false && strListaEstatus!="")
            {
                strListaEstatus = strListaEstatus.Substring(0, strListaEstatus.Length - 1);
                query.AddWhere("Incidencia.ClaveEstatus", Comparison.In, new SqlLiteral(strListaEstatus), 1);
            }
            if (int.Parse(cboMunicipio.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveMunicipio", Comparison.Equals, cboMunicipio.SelectedValue, 1);
            if (int.Parse(cboLocalidad.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveLocalidad", Comparison.Equals, cboLocalidad.SelectedValue, 1);
            if (int.Parse(cboColonia.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveColonia", Comparison.Equals, cboColonia.SelectedValue, 1);
            if (int.Parse(cboCP.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveCodigoPostal", Comparison.Equals, cboCP.SelectedValue, 1);

            if (chkRecepcion.Checked == true)
            {
                query.AddWhere("Incidencia.HoraRecepcion", Comparison.GreaterOrEquals, dteRecepcionIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("Incidencia.HoraRecepcion", Comparison.LessOrEquals, dteRecepcionFin.Value.ToString("yyyy-MM-dd"), 1);
            }
            if (chkDespacho.Checked == true)
            {
                query.AddWhere("DespachoIncidencia.HoraDespachada", Comparison.GreaterOrEquals, dteDespachoIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("DespachoIncidencia.HoraDespachada", Comparison.LessOrEquals, dteDespachoFin.Value.ToString("yyyy-MM-dd"), 1);
            }
            if (chkCierre.Checked == true)
            {
                query.AddWhere("DespachoIncidencia.HoraLiberada", Comparison.GreaterOrEquals, dteCierreIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("DespachoIncidencia.HoraLiberada", Comparison.LessOrEquals, dteCierreFin.Value.ToString("yyyy-MM-dd"), 1);
            }

            if (chkOperadores.CheckedItems.Count > 0 || chkDespachadores.CheckedItems.Count > 0)
            {
                string strListaUsr = "";
                if (chkOperadores.Enabled == true && chkOperadores.CheckedItems.Count > 0)
                    foreach (DataRowView myRow in chkOperadores.CheckedItems)
                    {
                        //   do something with myRow[0].ToString();
                        strListaUsr += myRow[0].ToString() + ",";
                    }

                if (chkDespachadores.Enabled == true && chkDespachadores.CheckedItems.Count > 0)
                    foreach (DataRowView myRow in chkDespachadores.CheckedItems)
                    {
                        //   do something with myRow[0].ToString();
                        strListaUsr += myRow[0].ToString() + ",";
                    }

                if (chkOperadores.Enabled == true || chkDespachadores.Enabled == true)
                {
                    strListaUsr = strListaUsr.Substring(0, strListaUsr.Length - 1);
                    query.AddWhere("Incidencia.ClaveUsuario", Comparison.In, new SqlLiteral(strListaUsr), 1);
                }
            }
             
            if (cboEntidades.Enabled == true && int.Parse(cboEntidades.SelectedValue.ToString()) != 0)
                if (cboSistema.Text.Trim() == "066")
                    query.AddWhere("CorporacionIncidencia.ClaveCorporacion", Comparison.Equals, cboEntidades.SelectedValue, 1);
                else if (cboSistema.Text.Trim() == "089")
                    query.AddWhere("IncidenciaDependencia.ClaveDependencia", Comparison.Equals, cboEntidades.SelectedValue, 1);
                
                statement = query.BuildQuery();

            return statement;
        }

        private string generateQueryXLS()
        {
            string statement;
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Incidencia");
            query.Distinct = true;
            query.SelectColumns("Incidencia.Folio", "Incidencia.Descripcion", "Incidencia.ClaveDenunciante", "EstatusIncidencia.Descripcion AS Estatus", "TipoIncidencia.Descripcion AS Tipo",
                "Municipio.Nombre AS NombreMpo", "Localidad.Nombre AS NombreLoc", "Colonia.Nombre AS NombreCol", "CodigoPostal.Valor AS CP",
                "Incidencia.ClaveCoordenada", "Incidencia.ClaveMunicipio", "Incidencia.ClaveLocalidad", "Incidencia.ClaveColonia", "Incidencia.ClaveCodigoPostal");

            query.AddJoin(JoinType.InnerJoin, "EstatusIncidencia", "Clave", Comparison.Equals, "Incidencia", "ClaveEstatus");
            query.AddJoin(JoinType.InnerJoin, "TipoIncidencia", "Clave", Comparison.Equals, "Incidencia", "ClaveTipo");
            query.AddJoin(JoinType.LeftJoin, "DespachoIncidencia", "Folio", Comparison.Equals, "Incidencia", "Folio");
            query.AddJoin(JoinType.LeftJoin, "Municipio", "Clave", Comparison.Equals, "Incidencia", "ClaveMunicipio");
            query.AddJoin(JoinType.LeftJoin, "Colonia", "Clave", Comparison.Equals, "Incidencia", "ClaveColonia");
            query.AddJoin(JoinType.LeftJoin, "CodigoPostal", "Clave", Comparison.Equals, "Incidencia", "ClaveCodigoPostal");
            query.AddJoin(JoinType.LeftJoin, "Localidad", "Clave", Comparison.Equals, "Incidencia", "ClaveLocalidad");
            query.AddJoin(JoinType.LeftJoin, "CorporacionIncidencia", "Folio", Comparison.Equals, "Incidencia", "Folio");
            query.AddJoin(JoinType.LeftJoin, "IncidenciaDependencia", "Folio", Comparison.Equals, "Incidencia", "Folio");

            if (int.Parse(cboSistema.SelectedValue.ToString()) != 0)
                query.AddWhere("TipoIncidencia.ClaveSistema", Comparison.Equals, cboSistema.SelectedValue, 1);
            if (int.Parse(cboTipoIncidencia.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveTipo", Comparison.Equals, cboTipoIncidencia.SelectedValue, 1);
            if (int.Parse(cboPrioridad.SelectedValue.ToString()) != 0)
                query.AddWhere("TipoIncidencia.Prioridad", Comparison.Equals, cboPrioridad.SelectedValue, 1);

            string strListaEstatus = "";
            if (chkNuevas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Nueva + ",";
            if (chkPendientes.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Pendiente + ",";
            if (chkActivas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Activa + ",";
            if (chkCerradas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Cerrada + ",";
            if (chkCanceladas.Checked == true) strListaEstatus += (int)STSINCIDENCIA.Cancelada + ",";
            if (chkTodos.Checked == false && strListaEstatus != "")
            {
                strListaEstatus = strListaEstatus.Substring(0, strListaEstatus.Length - 1);
                query.AddWhere("Incidencia.ClaveEstatus", Comparison.In, new SqlLiteral(strListaEstatus), 1);
            }
            if (int.Parse(cboMunicipio.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveMunicipio", Comparison.Equals, cboMunicipio.SelectedValue, 1);
            if (int.Parse(cboLocalidad.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveLocalidad", Comparison.Equals, cboLocalidad.SelectedValue, 1);
            if (int.Parse(cboColonia.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveColonia", Comparison.Equals, cboColonia.SelectedValue, 1);
            if (int.Parse(cboCP.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveCodigoPostal", Comparison.Equals, cboCP.SelectedValue, 1);

            if (chkRecepcion.Checked == true)
            {
                query.AddWhere("Incidencia.HoraRecepcion", Comparison.GreaterOrEquals, dteRecepcionIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("Incidencia.HoraRecepcion", Comparison.LessOrEquals, dteRecepcionFin.Value.ToString("yyyy-MM-dd"), 1);
            }
            if (chkDespacho.Checked == true)
            {
                query.AddWhere("DespachoIncidencia.HoraDespachada", Comparison.GreaterOrEquals, dteDespachoIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("DespachoIncidencia.HoraDespachada", Comparison.LessOrEquals, dteDespachoFin.Value.ToString("yyyy-MM-dd"), 1);
            }
            if (chkCierre.Checked == true)
            {
                query.AddWhere("DespachoIncidencia.HoraLiberada", Comparison.GreaterOrEquals, dteCierreIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("DespachoIncidencia.HoraLiberada", Comparison.LessOrEquals, dteCierreFin.Value.ToString("yyyy-MM-dd"), 1);
            }

            if (chkOperadores.CheckedItems.Count > 0 || chkDespachadores.CheckedItems.Count > 0)
            {
                string strListaUsr = "";
                if (chkOperadores.Enabled == true && chkOperadores.CheckedItems.Count > 0)
                    foreach (DataRowView myRow in chkOperadores.CheckedItems)
                    {
                        //   do something with myRow[0].ToString();
                        strListaUsr += myRow[0].ToString() + ",";
                    }

                if (chkDespachadores.Enabled == true && chkDespachadores.CheckedItems.Count > 0)
                    foreach (DataRowView myRow in chkDespachadores.CheckedItems)
                    {
                        //   do something with myRow[0].ToString();
                        strListaUsr += myRow[0].ToString() + ",";
                    }

                if (chkOperadores.Enabled == true || chkDespachadores.Enabled == true)
                {
                    strListaUsr = strListaUsr.Substring(0, strListaUsr.Length - 1);
                    query.AddWhere("Incidencia.ClaveUsuario", Comparison.In, new SqlLiteral(strListaUsr), 1);
                }
            }

            if (cboEntidades.Enabled == true && int.Parse(cboEntidades.SelectedValue.ToString()) != 0)
                if (cboSistema.Text.Trim() == "066")
                    query.AddWhere("CorporacionIncidencia.ClaveCorporacion", Comparison.Equals, cboEntidades.SelectedValue, 1);
                else if (cboSistema.Text.Trim() == "089")
                    query.AddWhere("IncidenciaDependencia.ClaveDependencia", Comparison.Equals, cboEntidades.SelectedValue, 1);

            statement = query.BuildQuery();

            return statement;
        }

        private void Limpiar_Forma()
        {
            cboSistema.SelectedIndex = 0;
            cboTipoIncidencia.SelectedIndex = 0;
            cboPrioridad.SelectedIndex = 0;
            chkNuevas.Checked = false;
            chkActivas.Checked = false;
            chkPendientes.Checked = false;
            chkCerradas.Checked = false;
            chkCanceladas.Checked = false;
            chkTodos.Checked = false;
            chkRecepcion.Checked = false;
            chkDespacho.Checked = false;
            chkCierre.Checked = false;
            dteRecepcionIni.Value = DateTime.Now;
            dteRecepcionFin.Value = DateTime.Now;
            dteDespachoIni.Value = DateTime.Now;
            dteDespachoFin.Value = DateTime.Now;
            dteCierreIni.Value = DateTime.Now;
            dteCierreFin.Value = DateTime.Now;
            cboMunicipio.SelectedIndex = 0;
            cboEntidades.SelectedIndex = 0;
            chkOperadoresTodos.Checked = false;
            chkDespachadoresTodos.Checked = false;
            chkOperadores.DataSource = null;
            chkDespachadores.DataSource = null;
            errorProvider1.Clear();
            errorProvider2.Clear();
            cboSistema.Focus();
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Forma();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                chkNuevas.Checked = true;
                chkActivas.Checked = true;
                chkPendientes.Checked = true;
                chkCerradas.Checked = true;
                chkCanceladas.Checked = true;
            }
            else
            {
                chkNuevas.Checked = false;
                chkActivas.Checked = false;
                chkPendientes.Checked = false;
                chkCerradas.Checked = false;
                chkCanceladas.Checked = false;
            }
        }

        private void chkNuevas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNuevas.Checked == true &&
                chkActivas.Checked == true &&
                chkPendientes.Checked == true &&
                chkCerradas.Checked == true &&
                chkCanceladas.Checked == true)
                chkTodos.Checked = true;
            else
            {
                chkTodos.CheckedChanged -= chkTodosEvent;
                chkTodos.Checked = false;
                chkTodos.CheckedChanged += chkTodosEvent;
            }
        }

        private void chkActivas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNuevas.Checked == true &&
                chkActivas.Checked == true &&
                chkPendientes.Checked == true &&
                chkCerradas.Checked == true &&
                chkCanceladas.Checked == true)
                chkTodos.Checked = true;
            else
            {
                chkTodos.CheckedChanged -= chkTodosEvent;
                chkTodos.Checked = false;
                chkTodos.CheckedChanged += chkTodosEvent;
            }
        }

        private void chkPendientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNuevas.Checked == true &&
                chkActivas.Checked == true &&
                chkPendientes.Checked == true &&
                chkCerradas.Checked == true &&
                chkCanceladas.Checked == true)
                chkTodos.Checked = true;
            else
            {
                chkTodos.CheckedChanged -= chkTodosEvent;
                chkTodos.Checked = false;
                chkTodos.CheckedChanged += chkTodosEvent;
            }
        }

        private void chkCerradas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNuevas.Checked == true &&
                chkActivas.Checked == true &&
                chkPendientes.Checked == true &&
                chkCerradas.Checked == true &&
                chkCanceladas.Checked == true)
                chkTodos.Checked = true;
            else
            {
                chkTodos.CheckedChanged -= chkTodosEvent;
                chkTodos.Checked = false;
                chkTodos.CheckedChanged += chkTodosEvent;
            }
        }

        private void chkCanceladas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNuevas.Checked == true &&
                chkActivas.Checked == true &&
                chkPendientes.Checked == true &&
                chkCerradas.Checked == true &&
                chkCanceladas.Checked == true)
                chkTodos.Checked = true;
            else
            {
                chkTodos.CheckedChanged -= chkTodosEvent;
                chkTodos.Checked = false;
                chkTodos.CheckedChanged += chkTodosEvent;
            }
        }
        
        private bool Fechas_Validate()
        {
            string msgError = "La FECHA INICIAL debe ser menor o igual que la FECHA FINAL.";
            errorProvider1.Clear(); // Borra todos los Mensajes de Error
            try
            {
                if (chkRecepcion.Checked)
                    if (DateTime.Compare(dteRecepcionIni.Value.Date, dteRecepcionFin.Value.Date) > 0)
                    {
                        errorProvider1.SetError(chkRecepcion, msgError);
                        throw new Exception(msgError);
                    }
                if (chkDespacho.Checked)
                    if (DateTime.Compare(dteDespachoIni.Value.Date, dteDespachoFin.Value.Date) > 0)
                    {
                        errorProvider1.SetError(chkDespacho, msgError);
                        throw new Exception(msgError);
                    }
                if (chkCierre.Checked)
                    if (DateTime.Compare(dteCierreIni.Value.Date, dteCierreFin.Value.Date) > 0)
                    {
                        errorProvider1.SetError(chkCierre, msgError);
                        throw new Exception(msgError);
                    }
                return true;
            }
            catch (Exception ex)
            {
                ApplicationException Appex = new ApplicationException("Error en la aplicación.", ex)
                {
                    Source = this.Text
                };

                ExceptionMessageBox exMsgBox = new ExceptionMessageBox(Appex)
                {
                    Symbol = ExceptionMessageBoxSymbol.Exclamation,
                    Beep = true
                };
                exMsgBox.Show(this);
                return false;
            }
            
        }

        private void cboCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite Backspace en el combo de CP
            if (e.KeyChar == (char)08) return;
            
            //Si presiona ENTER revisa que exista el CP
            if (e.KeyChar == (char)13)
            {
                /*if ((cboMunicipio.SelectedIndex + cboLocalidad.SelectedIndex + cboColonia.SelectedIndex) == 0)
                {
                    Fill_Ubicacion_Por_CP();
                }*/
                SendKeys.Send("{TAB}");
                return;
            }

            //Verifica que solo escriba numeros
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
            {
                if (cboMunicipio.SelectedIndex != 0)
                {
                    cboMunicipio.SelectedIndex = 0;
                    cboCP.Text = ""; //Borra el texto <--Todos--> del combo CP
                }
            } 
        }

        private void Fill_Ubicacion_Por_CP()
        {
            string statement;
            string strCP = cboCP.Text;
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("CodigoPostal");
            query.SelectColumns("Municipio.Clave", "Colonia.ClaveLocalidad", "Colonia.Clave", "CodigoPostal.Clave");
            query.AddJoin(JoinType.InnerJoin, "Colonia", "ClaveCodigoPostal", Comparison.Equals, "CodigoPostal", "Clave");
            query.AddJoin(JoinType.InnerJoin, "Localidad", "Clave", Comparison.Equals, "Colonia", "ClaveLocalidad");
            query.AddJoin(JoinType.LeftJoin, "Municipio", "Clave", Comparison.Equals, "Localidad", "ClaveMunicipio");
            query.AddWhere("CodigoPostal.Valor", Comparison.Equals, cboCP.Text);
            statement = query.BuildQuery();
            DataTable tabUbicacion = cnn.GetData(statement);

            if (tabUbicacion.Rows.Count == 0)
            {
                MensajeError("Código Postal no encontrado.");
                cboCP.Focus();
            }
            else if (tabUbicacion.Rows.Count >= 1)
            {
                cboMunicipio.SelectedValue = tabUbicacion.Rows[0][0].ToString();
                Fill_cboLocalidad();
                cboLocalidad.SelectedValue = tabUbicacion.Rows[0][1].ToString();
                Fill_cboColonia();
                cboColonia.SelectedValue = tabUbicacion.Rows[0][2].ToString();
                Fill_cboCP();
                cboCP.SelectedValue = tabUbicacion.Rows[0][3].ToString();
            }
        }

        private void MensajeError(string strText)
        {
            ApplicationException Appex = new ApplicationException(strText)
            {
                Source = this.Text
            };

            ExceptionMessageBox exMsgBox = new ExceptionMessageBox(Appex)
            {
                Symbol = ExceptionMessageBoxSymbol.Information,
                Beep = true
            };

            exMsgBox.Show(this);
            return;
        }

        private void cboEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboEntidades.Enabled)
                Fill_chkUsuarios();
        }

        private void chkOperadoresTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkOperadores.Items.Count; i++)
            {
                chkOperadores.SetItemChecked(i, chkOperadoresTodos.Checked);
            } 
        }

        private void chkDespachadoresTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkDespachadores.Items.Count; i++)
            {
                chkDespachadores.SetItemChecked(i, chkDespachadoresTodos.Checked);
            } 
        }

        private void cboSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cboSistema_Validate())
                    SendKeys.Send("{TAB}");
                else
                    e.Handled = true;
            }
        }

        private void cboTipoIncidencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboPrioridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkNuevas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkActivas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkPendientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkCerradas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkCanceladas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkTodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkRecepcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteRecepcionIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteRecepcionFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkDespacho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDespachoIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDespachoFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteCierreIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteCierreFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboColonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboEntidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkOperadoresTodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkOperadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkDespachadoresTodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkDespachadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chkNuevas_Enter(object sender, EventArgs e)
        {
            chkNuevas.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkNuevas_Leave(object sender, EventArgs e)
        {
            chkNuevas.BackColor = SystemColors.Control;
        }

        private void chkActivas_Enter(object sender, EventArgs e)
        {
            chkActivas.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkActivas_Leave(object sender, EventArgs e)
        {
            chkActivas.BackColor = SystemColors.Control;
        }

        private void chkPendientes_Enter(object sender, EventArgs e)
        {
            chkPendientes.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkPendientes_Leave(object sender, EventArgs e)
        {
            chkPendientes.BackColor = SystemColors.Control;
        }

        private void chkCerradas_Enter(object sender, EventArgs e)
        {
            chkCerradas.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkCerradas_Leave(object sender, EventArgs e)
        {
            chkCerradas.BackColor = SystemColors.Control;
        }

        private void chkCanceladas_Enter(object sender, EventArgs e)
        {
            chkCanceladas.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkCanceladas_Leave(object sender, EventArgs e)
        {
            chkCanceladas.BackColor = SystemColors.Control;
        }

        private void chkTodos_Enter(object sender, EventArgs e)
        {
            chkTodos.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkTodos_Leave(object sender, EventArgs e)
        {
            chkTodos.BackColor = SystemColors.Control;
        }

        private void chkRecepcion_Enter(object sender, EventArgs e)
        {
            chkRecepcion.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkRecepcion_Leave(object sender, EventArgs e)
        {
            chkRecepcion.BackColor = SystemColors.Control;
        }

        private void chkDespacho_Enter(object sender, EventArgs e)
        {
            chkDespacho.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkDespacho_Leave(object sender, EventArgs e)
        {
            chkDespacho.BackColor = SystemColors.Control;
        }

        private void chkCierre_Enter(object sender, EventArgs e)
        {
            chkCierre.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkCierre_Leave(object sender, EventArgs e)
        {
            chkCierre.BackColor = SystemColors.Control;
        }

        private void cboCP_Enter(object sender, EventArgs e)
        {
            cboCP.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void cboCP_Leave(object sender, EventArgs e)
        {
            cboCP.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void chkOperadoresTodos_Enter(object sender, EventArgs e)
        {
            chkOperadoresTodos.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkOperadoresTodos_Leave(object sender, EventArgs e)
        {
            chkOperadoresTodos.BackColor = SystemColors.Control;
        }

        private void chkOperadores_Enter(object sender, EventArgs e)
        {
            chkOperadores.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkOperadores_Leave(object sender, EventArgs e)
        {
            chkOperadores.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void chkDespachadoresTodos_Enter(object sender, EventArgs e)
        {
            chkDespachadoresTodos.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkDespachadoresTodos_Leave(object sender, EventArgs e)
        {
            chkDespachadoresTodos.BackColor = SystemColors.Control;
        }

        private void chkDespachadores_Enter(object sender, EventArgs e)
        {
            chkDespachadores.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void chkDespachadores_Leave(object sender, EventArgs e)
        {
            chkDespachadores.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void btnAceptar_Enter(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void btnAceptar_Leave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void btnLimpiar_Enter(object sender, EventArgs e)
        {
            btnLimpiar.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void btnLimpiar_Leave(object sender, EventArgs e)
        {
            btnLimpiar.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void btnCancelar_Enter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void btnCancelar_Leave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(255, 255, 255);
        }

        private bool cboSistema_Validate()
        {
            try
            {
                errorProvider2.Clear();
                if (int.Parse(cboSistema.SelectedValue.ToString()) == 0)
                {
                    errorProvider2.SetError(cboSistema, "Debe elegir un sistema.");
                    throw new Exception("Debe elegir un sistema.");
                }
                return true;
            }
            catch (Exception ex)
            {
                ApplicationException Appex = new ApplicationException("Error en la aplicación.",ex)
                {
                    Source = this.Text
                };

                ExceptionMessageBox exMsgBox = new ExceptionMessageBox(Appex)
                {
                    Symbol = ExceptionMessageBoxSymbol.Exclamation,
                    Beep = true
                };
                exMsgBox.Show(this);
                return false;
            }
        }

        private void cboSistema_Leave(object sender, EventArgs e)
        {
            if (!cboSistema_Validate())
                cboSistema.Focus();
            return;
        }

        private void cboCP_Validating(object sender, CancelEventArgs e)
        {
            if ((cboMunicipio.SelectedIndex + cboLocalidad.SelectedIndex + cboColonia.SelectedIndex) == 0 &&
                System.Text.RegularExpressions.Regex.IsMatch(cboCP.Text, "\\d+"))
            {
                Fill_Ubicacion_Por_CP();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dteRecepcionIni_Validating(object sender, CancelEventArgs e)
        {
            if (!Fechas_Validate())
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void dteRecepcionFin_Validating(object sender, CancelEventArgs e)
        {
            if (!Fechas_Validate())
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void dteDespachoIni_Validating(object sender, CancelEventArgs e)
        {
            if (!Fechas_Validate())
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void dteDespachoFin_Validating(object sender, CancelEventArgs e)
        {
            if (!Fechas_Validate())
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void dteCierreIni_Validating(object sender, CancelEventArgs e)
        {
            if (!Fechas_Validate())
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void dteCierreFin_Validating(object sender, CancelEventArgs e)
        {
            if (!Fechas_Validate())
                e.Cancel = true;
            else
                e.Cancel = false;
        }
    }
}