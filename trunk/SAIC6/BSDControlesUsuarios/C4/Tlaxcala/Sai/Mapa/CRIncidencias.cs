using System;
using System.Data;
using System.Windows.Forms;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public partial class CRIncidencias : Form
    {
        private const int cveEstado = 29;
        private int tipoReporte;
        private CDats cdat;
        private CConn cnn;

        private enum STSINCIDENCIA
        {
            Todas,
            Nueva,
            Pendiente,
            Activa,
            Cerrada,
            Cancelada
        } ; //Inicia en Todas=0
        public enum TIPOREPORTE
        {
            Punteo,
            XLS,
            Supervisor
        } ; //Inicia en Punteo=0
        private int intStsIncidencia;

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
            Fill_cboSistema();
            Fill_cboTipoIncidencia();
            Fill_Prioridad();
            intStsIncidencia = (int) STSINCIDENCIA.Nueva;
            Fill_cboMunicipio();
            Fill_cboLocalidad();
            Fill_cboColonia();
            Fill_cboCP();
            Fill_chkUsuarios();
            Fill_cboCorporacion();
            Fill_cboDependencia();
        }

        private void Fill_cboSistema()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Sistema");
            query.SelectColumns("Clave", "Descripcion");
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
            query.AddOrderBy("Nombre", Sorting.Ascending);

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
            //Llena la lista de Operadores
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Usuario");
            query.SelectColumns("Clave", "NombrePropio");

            query.AddWhere("Activo", Comparison.Equals,
                           true);
            query.AddWhere("Despachador", Comparison.Equals,
                           false);
            string statement = query.BuildQuery();

            chkOperadores.DataSource = cnn.GetData(statement);
            chkOperadores.DisplayMember = "NombrePropio";
            chkOperadores.ValueMember = "Clave";

            //Llena la lista de Despachadores
            query = new SelectQueryBuilder();
            query.SelectFromTable("Usuario");
            query.SelectColumns("Clave", "NombrePropio");

            query.AddWhere("Activo", Comparison.Equals,
                           true);
            query.AddWhere("Despachador", Comparison.Equals,
                           true);
            statement = query.BuildQuery();

            chkDespachadores.DataSource = cnn.GetData(statement);
            chkDespachadores.DisplayMember = "NombrePropio";
            chkDespachadores.ValueMember = "Clave";
        }

        private void Fill_cboCorporacion()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Corporacion");
            query.SelectColumns("Clave", "Descripcion");

            query.AddWhere("Activo", Comparison.Equals,
                           true);
            query.AddWhere("ClaveSistema", Comparison.Equals,
                           cboSistema.SelectedValue);
            query.AddOrderBy("Descripcion", Sorting.Ascending);

            string statement = "SELECT 0 AS Clave, '<- - - - Todas - - - ->' AS Descripcion UNION " + query.BuildQuery();

            cboCorporacion.DataSource = cnn.GetData(statement);
            cboCorporacion.DisplayMember = "Descripcion";
            cboCorporacion.ValueMember = "Clave";
        }

        private void Fill_cboDependencia()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Dependencia");
            query.SelectColumns("Clave", "Descripcion");

            query.AddOrderBy("Descripcion", Sorting.Ascending);

            string statement = "SELECT 0 AS Clave, '<- - - - Todas - - - ->' AS Descripcion UNION " + query.BuildQuery();

            cboDependencia.DataSource = cnn.GetData(statement);
            cboDependencia.DisplayMember = "Descripcion";
            cboDependencia.ValueMember = "Clave";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /*MRV*/
            if (tipoReporte.Equals((int) TIPOREPORTE.Punteo))
            {
                //cboTipoIncidencia.Text = generateQueryPunteo();
                CSetPoint csp = new CSetPoint(ref cdat, "map.xml", Application.StartupPath, generateQueryPunteo());
                csp.ShowDialog();
                //MessageBox.Show(generateQueryPunteo());
            }
            return;
        }

        private void cboSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSistema.SelectedIndex == 0)
            {
                cboCorporacion.Enabled = false;
                cboDependencia.Enabled = false;
                chkOperadores.Enabled = false;
                chkDespachadores.Enabled = false;
                return;
            }

            Fill_cboTipoIncidencia();
            if (cboSistema.Text.Trim() == "066")
            {
                Fill_cboCorporacion();
                cboCorporacion.Enabled = true;
                cboDependencia.Enabled = false;
                chkOperadores.Enabled = true;
                chkDespachadores.Enabled = true;
            }
            else if (cboSistema.Text.Trim() == "089")
            {
                cboCorporacion.Enabled = false;
                cboDependencia.Enabled = true;
                chkOperadores.Enabled = true;
                chkDespachadores.Enabled = false;
            }
            else if (cboSistema.Text.Trim() == "ADM")
            {
                cboCorporacion.Enabled = false;
                cboDependencia.Enabled = false;
                chkOperadores.Enabled = false;
                chkDespachadores.Enabled = false;
            }
            return;
        }

        private void cboPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cboPrioridad.ValueMember.ToString());
        }

        private void rbtNuevas_CheckedChanged(object sender, EventArgs e)
        {
            intStsIncidencia = (int) STSINCIDENCIA.Nueva;
        }

        private void rbtActivas_CheckedChanged(object sender, EventArgs e)
        {
            intStsIncidencia = (int) STSINCIDENCIA.Activa;
        }

        private void rbtPendientes_CheckedChanged(object sender, EventArgs e)
        {
            intStsIncidencia = (int) STSINCIDENCIA.Pendiente;
        }

        private void rbtCerradas_CheckedChanged(object sender, EventArgs e)
        {
            intStsIncidencia = (int) STSINCIDENCIA.Cerrada;
        }

        private void rbtCanceladas_CheckedChanged(object sender, EventArgs e)
        {
            intStsIncidencia = (int) STSINCIDENCIA.Cancelada;
        }

        private void rbtTodas_CheckedChanged(object sender, EventArgs e)
        {
            intStsIncidencia = (int) STSINCIDENCIA.Todas;
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
            query.SelectColumns("Incidencia.Folio", "Incidencia.Descripcion", "Incidencia.ClaveDenunciante",
                                "EstatusIncidencia.Descripcion AS Estatus", "TipoIncidencia.Descripcion AS Tipo",
                                "Municipio.Nombre AS NombreMpo", "Localidad.Nombre AS NombreLoc",
                                "Colonia.Nombre AS NombreCol", "CodigoPostal.Valor AS CP", "ClaveCoordenada");

            query.AddJoin(JoinType.InnerJoin, "EstatusIncidencia", "Clave", Comparison.Equals, "Incidencia",
                          "ClaveEstatus");
            query.AddJoin(JoinType.InnerJoin, "TipoIncidencia", "Clave", Comparison.Equals, "Incidencia", "ClaveTipo");
            query.AddJoin(JoinType.InnerJoin, "DespachoIncidencia", "Folio", Comparison.Equals, "Incidencia", "Folio");
            query.AddJoin(JoinType.InnerJoin, "Municipio", "Clave", Comparison.Equals, "Incidencia", "ClaveMunicipio");
            query.AddJoin(JoinType.InnerJoin, "Colonia", "Clave", Comparison.Equals, "Incidencia", "ClaveColonia");
            query.AddJoin(JoinType.InnerJoin, "CodigoPostal", "Clave", Comparison.Equals, "Incidencia",
                          "ClaveCodigoPostal");
            query.AddJoin(JoinType.InnerJoin, "Localidad", "Clave", Comparison.Equals, "Incidencia", "ClaveLocalidad");
            query.AddJoin(JoinType.LeftJoin, "CorporacionIncidencia", "Folio", Comparison.Equals, "Incidencia", "Folio");
            query.AddJoin(JoinType.LeftJoin, "IncidenciaDependencia", "Folio", Comparison.Equals, "Incidencia", "Folio");

            if (int.Parse(cboTipoIncidencia.SelectedValue.ToString()) != 0)
                query.AddWhere("Incidencia.ClaveTipo", Comparison.Equals, cboTipoIncidencia.SelectedValue, 1);
            if (int.Parse(cboPrioridad.SelectedValue.ToString()) != 0)
                query.AddWhere("TipoIncidencia.Prioridad", Comparison.Equals, cboPrioridad.SelectedValue, 1);
            if (intStsIncidencia != 0)
                query.AddWhere("Incidencia.ClaveEstatus", Comparison.Equals, intStsIncidencia, 1);
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
                query.AddWhere("Incidencia.HoraRecepcion", Comparison.GreaterOrEquals,
                               dteRecepcionIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("Incidencia.HoraRecepcion", Comparison.LessOrEquals,
                               dteRecepcionFin.Value.ToString("yyyy-MM-dd"), 1);
            }
            if (chkDespacho.Checked == true)
            {
                query.AddWhere("DespachoIncidencia.HoraDespachada", Comparison.GreaterOrEquals,
                               dteDespachoIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("DespachoIncidencia.HoraDespachada", Comparison.LessOrEquals,
                               dteDespachoFin.Value.ToString("yyyy-MM-dd"), 1);
            }
            if (chkCierre.Checked == true)
            {
                query.AddWhere("DespachoIncidencia.HoraLiberada", Comparison.GreaterOrEquals,
                               dteCierreIni.Value.ToString("yyyy-MM-dd"), 1);
                query.AddWhere("DespachoIncidencia.HoraLiberada", Comparison.LessOrEquals,
                               dteCierreFin.Value.ToString("yyyy-MM-dd"), 1);
            }

            if (chkOperadores.CheckedItems.Count > 0 || chkDespachadores.CheckedItems.Count > 0)
            {
                string strListaUsr = "";
                if (chkOperadores.Enabled == true)
                    foreach (DataRowView myRow in chkOperadores.CheckedItems)
                    {
                        //   do something with myRow[0].ToString();
                        strListaUsr += myRow[0].ToString() + ",";
                    }

                if (chkDespachadores.Enabled == true)
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
            string strTmp1 = query.BuildQuery();

            SelectQueryBuilder query2 = new SelectQueryBuilder();

            if (cboCorporacion.Enabled == true && int.Parse(cboCorporacion.SelectedValue.ToString()) != 0)
                query2.AddWhere("CorporacionIncidencia.ClaveCorporacion", Comparison.Equals,
                                cboCorporacion.SelectedValue, 1);
            if (cboDependencia.Enabled == true && int.Parse(cboDependencia.SelectedValue.ToString()) != 0)
                query2.AddWhere("IncidenciaDependencia.ClaveDependencia", Comparison.Equals,
                                cboDependencia.SelectedValue, 2);

            if ((cboCorporacion.Enabled == true || cboDependencia.Enabled == true) &&
                (int.Parse(cboCorporacion.SelectedValue.ToString()) != 0 ||
                 int.Parse(cboDependencia.SelectedValue.ToString()) != 0))
            {
                string strTmp2 = query2.BuildQuery();
                int posACortar = strTmp2.IndexOf("(CorporacionI");
                strTmp2 = strTmp2.Substring(posACortar);
                statement = strTmp1 + " AND (" + strTmp2 + ")";
            }
            else
                statement = strTmp1;

            return statement;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //cboSistema.SelectedIndex = 0;
        }
    }
}