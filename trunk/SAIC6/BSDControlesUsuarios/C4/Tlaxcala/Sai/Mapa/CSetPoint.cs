using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ActualMap;
using ActualMap.Windows;
using CPw;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;


namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public partial class CSetPoint : Form
    {
        private const int cveEstado = 29;
        private CDats cdat;
        private CMapa mapXML;
        private CConn cnn;
        private string XMLconf;
        private string path;
        private int rowIndex;
        private List<int> MiListado = new List<int>();
        private string sqlStr;
        private bool ok = false;

        public CSetPoint()
        {
            InitializeComponent();
        }

        public CSetPoint(string sql)
        {
            InitializeComponent();
            sqlStr = sql;
        }

        public CSetPoint(ref CDats cdat, string XMLconf, string path, string sqlStr)
        {
            InitializeComponent();
            this.cdat = cdat;
            this.XMLconf = XMLconf;
            this.path = path;
            this.sqlStr = sqlStr;
        }

        private void CSetPoint_Load(object sender, EventArgs e)
        {
            AgregarCapas();
            mapa.ZoomFull();
            mapa.Refresh();
            //CConn cnn = new CConn(cdat);     
            cnn = new CConn(cdat);
            dataGridView1.DataSource = cnn.GetData(sqlStr);
            //Llenar la lista
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                //Cambiar esta línea
                MiListado.Add(
                    int.Parse(string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["ClaveCoordenada"].Value.ToString())
                                  ? "0"
                                  : dataGridView1.Rows[i].Cells["ClaveCoordenada"].Value.ToString()));
            }
            dataGridView1.Columns.Remove("ClaveCoordenada");


            fill_cboMunicipio();
            fill_cboLocalidad();
            fill_cboColonia();
            fill_cboCP();
            ok = true;
        }

        private void fill_cboMunicipio()
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

        private void fill_cboLocalidad()
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

        private void fill_cboColonia()
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

        private void fill_cboCP()
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

        private void AgregarCapas()
        {
            try
            {
                Layer layer;
                String directorio = path + "\\datos\\";
                CXML cxml = new CXML();
                if ((mapXML = cxml.leerXML(XMLconf)) != null)
                {
                    for (int i = 0; i < mapXML.Count; i++)
                    {
                        switch (mapXML.Capas[i].Type.ToLower())
                        {
                            case "poly":
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File, new Ccpd().getPd());
                                layer.Name = mapXML.Capas[i].LayerName;
                                layer.LabelField = mapXML.Capas[i].LabelField;
                                layer.LabelFont.Size = mapXML.Capas[i].LabelSize;
                                layer.ShowLabels = mapXML.Capas[i].ShowLabel;
                                layer.Symbol.FillStyle = CEnums.getFillStyle(mapXML.Capas[i].FillStyle);
                                layer.Symbol.FillColor = CEnums.getColor(mapXML.Capas[i].FillColor);
                                layer.Symbol.LineStyle = CEnums.getLineStyle(mapXML.Capas[i].LineStyle);
                                layer.Symbol.LineColor = CEnums.getColor(mapXML.Capas[i].LineColor);
                                layer.Symbol.Size = mapXML.Capas[i].Size;
                                layer.Visible = mapXML.Capas[i].Visible;
                                break;
                            case "line":
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File);
                                layer.Name = mapXML.Capas[i].LayerName;
                                layer.LabelField = mapXML.Capas[i].LabelField;
                                layer.LabelFont.Size = mapXML.Capas[i].LabelSize;
                                layer.ShowLabels = mapXML.Capas[i].ShowLabel;
                                layer.Symbol.LineStyle = CEnums.getLineStyle(mapXML.Capas[i].LineStyle);
                                layer.Symbol.LineColor = CEnums.getColor(mapXML.Capas[i].LineColor);
                                layer.Symbol.Size = mapXML.Capas[i].Size;
                                layer.Visible = mapXML.Capas[i].Visible;
                                break;
                            case "point":
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File);
                                layer.Name = mapXML.Capas[i].LayerName;
                                layer.LabelField = mapXML.Capas[i].LabelField;
                                layer.LabelFont.Size = mapXML.Capas[i].LabelSize;
                                layer.ShowLabels = mapXML.Capas[i].ShowLabel;
                                layer.Symbol.PointStyle = CEnums.getPointStyle(mapXML.Capas[i].PointStyle);
                                layer.Symbol.FillColor = CEnums.getColor(mapXML.Capas[i].FillColor);
                                layer.Symbol.LineColor = CEnums.getColor(mapXML.Capas[i].LineColor);
                                layer.Symbol.Size = mapXML.Capas[i].Size;
                                layer.Visible = mapXML.Capas[i].Visible;
                                break;
                        }
                    }
                    AgregarLeyenda();
                    OcultarCapas(false);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la lectura el archivo XML", "Error al cargar mapa");
                }
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void OcultarCapas(bool val)
        {
            /*for (int i = 0; i < mapXML.Count; i++)
            {
                if (mapXML.Capas[i].LayerName.ToUpper() != "MUNICIPIO")
                {
                    mapa[mapXML.Capas[i].LayerName].Visible = val;                    
                }
            }
             * */
        }

        private void AgregarLeyenda()
        {
            //leyenda.Populate(mapa);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (!btnZoomIn.Checked)
            {
                btnZoomIn.Checked = true;
                mapa.MapTool = MapTool.ZoomIn;
                btnPoint.Checked = false;
                btnPanning.Checked = false;
                btnZoomOut.Checked = false;
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (!btnZoomOut.Checked)
            {
                btnZoomOut.Checked = true;
                mapa.MapTool = MapTool.ZoomOut;
                btnPoint.Checked = false;
                btnPanning.Checked = false;
                btnZoomIn.Checked = false;
            }
        }

        private void btnFullExtend_Click(object sender, EventArgs e)
        {
            mapa.ZoomFull();
            mapa.Refresh();
            ActivarPoint();
        }

        private void btnPanning_Click(object sender, EventArgs e)
        {
            ActivarPanning();
        }

        private void ActivarPanning()
        {
            if (!btnPanning.Checked)
            {
                btnPanning.Checked = true;
                mapa.MapTool = MapTool.Pan;
                btnPoint.Checked = false;
                btnZoomIn.Checked = false;
                btnZoomOut.Checked = false;
            }
        }

        public void CentrarEstado()
        {
            if (mapa.LayerCount > 0)
            {
                ActualizaLbl(true);
                OcultarCapas(false);
                mapa.MapShapes.Clear();
                mapa.ZoomFull();
                mapa.Refresh();
                ActualizaLbl(false);
            }
        }

        //Refresca el Mapa centrándolo en la COLONIA elegída
        public void Colonia(int id)
        {
            try
            {
                ActualizaLbl(true);
                Recordset state;
                state = mapa["COLONIA"].SearchExpression("ID = \"" + id + "\"");
                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    MapShape shape = mapa.MapShapes.Add(state.Shape);
                    Symbol s = new Symbol();
                    s.FillStyle = FillStyle.DiagonalCross;
                    s.FillColor = Color.Yellow;
                    s.LineColor = Color.Red;
                    s.Size = 3;
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        //Refresca el Mapa centrándolo en el CP elegído
        public void CP(int id)
        {
            try
            {
                ActualizaLbl(true);
                Recordset state;
                state = mapa["COLONIA"].SearchExpression("CP = \"" + id + "\"");
                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    MapShape shape = mapa.MapShapes.Add(state.Shape);
                    Symbol s = new Symbol();
                    s.FillStyle = FillStyle.DiagonalCross;
                    s.FillColor = Color.Yellow;
                    s.LineColor = Color.Red;
                    s.Size = 3;
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        //Refresca el Mapa centrándolo en el MUNICIPIO elegído
        public void Municipio(int id)
        {
            try
            {
                ActualizaLbl(true);
                Recordset state;
                state = mapa["MUNICIPIO"].SearchExpression("ID = \"" + id + "\"");
                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    MapShape shape = mapa.MapShapes.Add(state.Shape);
                    Symbol s = new Symbol();
                    s.FillStyle = FillStyle.DiagonalCross;
                    s.FillColor = Color.Yellow;
                    s.LineColor = Color.Red;
                    s.Size = 3;
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        //Refresca el Mapa centrándolo en la LOCALIDAD elegída
        public void Localidad(int id)
        {
            try
            {
                ActualizaLbl(true);
                Recordset state;
                state = mapa["LOCALIDAD"].SearchExpression("ID = \"" + id + "\"");
                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    MapShape shape = mapa.MapShapes.Add(state.Shape);
                    Symbol s = new Symbol();
                    s.FillStyle = FillStyle.Invisible;
                    s.LineColor = Color.Red;
                    s.Size = 17;
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        public void UbicarNI(int id_colonia, int cp, int id_localidad, int id_municipio)
        {
            if (id_colonia > 0)
                Colonia(id_colonia);
            else if (cp > 0)
                CP(cp);
            else if (id_localidad > 0)
                Localidad(id_localidad);
            else if (id_municipio > 0)
                Municipio(id_municipio);
            else
                CentrarEstado();
        }

        private void ActualizaLbl(bool flag)
        {
            //lblUpdate.Location = new System.Drawing.Point(this.Size.Width / 2, this.Size.Height / 2);
            //lblUpdate.Visible = flag;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Checar si conviene hacerlo de esta manera
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            ActivarPoint();
        }

        private void ActivarPoint()
        {
            if (!btnPoint.Checked)
            {
                btnPoint.Checked = true;
                mapa.MapTool = MapTool.Point;
                btnPanning.Checked = false;
                btnZoomIn.Checked = false;
                btnZoomOut.Checked = false;
            }
        }

        private void mapa_Click(object sender, EventArgs e)
        {
        }

        private void mapa_PointTool(object sender, PointToolEventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cnn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                double longitud = 0;
                double latitud = 0;
                string sql;
                CConn cconn = new CConn(cdat);
                //Descomentar
                rowIndex = e.RowIndex;
                if ((rowIndex >= 0) && (rowIndex < dataGridView1.RowCount - 1))
                {
                    lblRowIndex.Text = rowIndex.ToString();
                    //Modificar esta linea para que renderice si hay Municipio, Localidad, Colonia y C.P.           
                    Municipio(int.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString()));
                    //Renderizar si ya tiene coordenada asignada.
                    if (MiListado[rowIndex] != 0)
                    {
                        cnn = new System.Data.SqlClient.SqlConnection();
                        cnn.ConnectionString = cconn.ConnectionString;
                        cnn.Open();
                        sql = "SELECT Longitud, Latitud FROM Coordenada WHERE ClaveCoordenada=" + MiListado[rowIndex];
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        rdr = cmd.ExecuteReader();

                        rdr.Read();
                        longitud = double.Parse(rdr.GetValue(0).ToString());
                        latitud = double.Parse(rdr.GetValue(1).ToString());

                        //mapa.MapShapes.Clear();
                        MapShape mapShape = mapa.MapShapes.Add(new ActualMap.Point(longitud, latitud));
                        mapShape.Symbol.PointStyle = PointStyle.Bitmap;
                        mapShape.Symbol.Bitmap = path + "\\Symbols\\clip.bmp";
                        mapShape.Symbol.Size = 16;
                        mapShape.Symbol.TransparentColor = Color.White;

                        //Tambien ubicar dentro de lo más cercano
                    }
                        //Ubicar si no tiene coordenada asignada
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString() + rowIndex);
            }
            finally
            {
                //cmd.Dispose();
                //cnn.Close();
            }
        }

        private void mapa_PointTool_1(object sender, PointToolEventArgs e)
        {
            SqlConnection cnn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                int lastId;
                String sql;
                CConn cconn = new CConn(cdat);

                //mapa.MapShapes.Clear();
                MapShape mapShape = mapa.MapShapes.Add(e.Point);
                mapShape.Symbol.PointStyle = PointStyle.Bitmap;
                mapShape.Symbol.Bitmap = path + "\\Symbols\\clip.bmp";
                mapShape.Symbol.Size = 16;
                mapShape.Symbol.TransparentColor = Color.White;
                lblLongitud.Text = e.Point.X.ToString();
                lblLatitud.Text = e.Point.Y.ToString();

                //Si tiene coordenada
                lastId = MiListado[rowIndex];
                if (lastId > 0)
                {
                    //Actualiza si tiene coordenada
                    //Consulta generada. Sustituir por la que entre del formulario
                    sql = "UPDATE Coordenada SET Longitud=" + e.Point.X.ToString() + ",Latitud=" + e.Point.Y.ToString() +
                          " WHERE ClaveCoordenada=" + MiListado[rowIndex];
                    cnn = new System.Data.SqlClient.SqlConnection();
                    cnn.ConnectionString = cconn.ConnectionString;
                    cnn.Open();

                    cmd.Connection = cnn;
                    cmd.CommandText = sql;

                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("Actualizaco con exito");
                    //Acualizar el registro de la Incidencia
                    cmd.Dispose();
                }
                else
                {
                    //Si no tiene coordenada
                    cnn = new System.Data.SqlClient.SqlConnection();
                    cnn.ConnectionString = cconn.ConnectionString;
                    cnn.Open();

                    sql = "SELECT MAX(ClaveCoordenada) FROM Coordenada";
                    cmd.Connection = cnn;
                    cmd.CommandText = sql;
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        lastId = int.Parse(rdr.GetValue(0).ToString()) + 1;
                        //Cierra el comando actual abierto
                        cmd.Dispose();
                        rdr.Close();
                        sql = "INSERT INTO Coordenada (\"ClaveCoordenada\",\"Longitud\",\"Latitud\") VALUES (" + lastId +
                              "," + e.Point.X.ToString() + "," + e.Point.Y.ToString() + ")";
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                        rdr.Close();
                        sql = "UPDATE Incidencia SET ClaveCoordenada=" + lastId + " WHERE Folio=" +
                              dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MiListado[rowIndex] = lastId;
                    }
                }

                mapa.Refresh();
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                cnn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                int ClaveCoordenada = 0;
                double longitud = 0;
                double latitud = 0;
                string sql;
                CConn cconn = new CConn(cdat);
                if (chkIncidencias.Checked)
                {
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        //Cambiar esta línea
                        ClaveCoordenada = MiListado[i];
                        if (ClaveCoordenada != 0)
                        {
                            cnn = new System.Data.SqlClient.SqlConnection();
                            cnn.ConnectionString = cconn.ConnectionString;
                            cnn.Open();
                            sql = "SELECT Longitud, Latitud FROM Coordenada WHERE ClaveCoordenada=" + ClaveCoordenada;
                            cmd.Connection = cnn;
                            cmd.CommandText = sql;
                            rdr = cmd.ExecuteReader();

                            rdr.Read();
                            longitud = double.Parse(rdr.GetValue(0).ToString());
                            latitud = double.Parse(rdr.GetValue(1).ToString());

                            //mapa.MapShapes.Clear();
                            MapShape mapShape = mapa.MapShapes.Add(new ActualMap.Point(longitud, latitud));
                            mapShape.Symbol.PointStyle = PointStyle.Bitmap;
                            mapShape.Symbol.Bitmap = path + "\\Symbols\\clip.bmp";
                            mapShape.Symbol.Size = 16;
                            mapShape.Symbol.TransparentColor = Color.White;

                            cmd.Dispose();
                            cnn.Close();
                        }
                    }
                    mapa.Refresh();
                }
                else
                {
                    mapa.MapShapes.Clear();
                    mapa.Refresh();
                }
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void cboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_cboLocalidad();
            if (ok)
            {
                Municipio(int.Parse(cboMunicipio.SelectedValue.ToString()));
            }
        }

        private void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_cboColonia();
            if (ok)
            {
                Localidad(int.Parse(cboLocalidad.SelectedValue.ToString()));
            }
        }

        private void cboColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_cboCP();
            if (ok)
            {
                Colonia(int.Parse(cboColonia.SelectedValue.ToString()));
            }
        }

        private void cboCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ok)
            {
                CP(int.Parse(cboCP.SelectedValue.ToString()));
            }
        }

        private void dataGridView1_RowEnter_2(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cnn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                double longitud = 0;
                double latitud = 0;
                string sql;
                CConn cconn = new CConn(cdat);
                //Descomentar
                rowIndex = e.RowIndex;
                if ((rowIndex >= 0) && (rowIndex < dataGridView1.RowCount - 1))
                {
                    lblRowIndex.Text = rowIndex.ToString();
                    //Modificar esta linea para que renderice si hay Municipio, Localidad, Colonia y C.P.           
                    Municipio(int.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString()));
                    //cboMunicipio.SelectedValue = dataGridView1.Rows[rowIndex].Cells["MunicipioN"].Value.ToString();                    
                    //Renderizar si ya tiene coordenada asignada.
                    if (MiListado[rowIndex] != 0)
                    {
                        cnn = new System.Data.SqlClient.SqlConnection();
                        cnn.ConnectionString = cconn.ConnectionString;
                        cnn.Open();
                        sql = "SELECT Longitud, Latitud FROM Coordenada WHERE ClaveCoordenada=" + MiListado[rowIndex];
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        rdr = cmd.ExecuteReader();

                        rdr.Read();
                        longitud = double.Parse(rdr.GetValue(0).ToString());
                        latitud = double.Parse(rdr.GetValue(1).ToString());

                        //mapa.MapShapes.Clear();
                        MapShape mapShape = mapa.MapShapes.Add(new ActualMap.Point(longitud, latitud));
                        mapShape.Symbol.PointStyle = PointStyle.Bitmap;
                        mapShape.Symbol.Bitmap = path + "\\Symbols\\clip.bmp";
                        mapShape.Symbol.Size = 16;
                        mapShape.Symbol.TransparentColor = Color.White;

                        //Tambien ubicar dentro de lo más cercano
                    }
                        //Ubicar si no tiene coordenada asignada
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString() + rowIndex);
            }
            finally
            {
                //cmd.Dispose();
                //cnn.Close();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void mapa_Click_1(object sender, EventArgs e)
        {
        }

        private void mapa_PointTool_2(object sender, PointToolEventArgs e)
        {
            SqlConnection cnn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                int lastId;
                String sql;
                CConn cconn = new CConn(cdat);

                mapa.MapShapes.Clear();
                MapShape mapShape = mapa.MapShapes.Add(e.Point);
                mapShape.Symbol.PointStyle = PointStyle.Bitmap;
                mapShape.Symbol.Bitmap = path + "\\Symbols\\clip.bmp";
                mapShape.Symbol.Size = 16;
                mapShape.Symbol.TransparentColor = Color.White;
                lblLongitud.Text = e.Point.X.ToString();
                lblLatitud.Text = e.Point.Y.ToString();

                //Si tiene coordenada
                lastId = MiListado[rowIndex];
                if (lastId > 0)
                {
                    //Actualiza si tiene coordenada
                    //Consulta generada. Sustituir por la que entre del formulario
                    sql = "UPDATE Coordenada SET Longitud=" + e.Point.X.ToString() + ",Latitud=" + e.Point.Y.ToString() +
                          " WHERE ClaveCoordenada=" + MiListado[rowIndex];
                    cnn = new System.Data.SqlClient.SqlConnection();
                    cnn.ConnectionString = cconn.ConnectionString;
                    cnn.Open();

                    cmd.Connection = cnn;
                    cmd.CommandText = sql;

                    cmd.ExecuteNonQuery();
                    //Acualizar el registro de la Incidencia
                    cmd.Dispose();
                }
                else
                {
                    //Si no tiene coordenada
                    cnn = new System.Data.SqlClient.SqlConnection();
                    cnn.ConnectionString = cconn.ConnectionString;
                    cnn.Open();

                    sql = "SELECT MAX(ClaveCoordenada) FROM Coordenada";
                    cmd.Connection = cnn;
                    cmd.CommandText = sql;
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        lastId = int.Parse(rdr.GetValue(0).ToString()) + 1;
                        //Cierra el comando actual abierto
                        cmd.Dispose();
                        rdr.Close();
                        sql = "INSERT INTO Coordenada (\"ClaveCoordenada\",\"Longitud\",\"Latitud\") VALUES (" + lastId +
                              "," + e.Point.X.ToString() + "," + e.Point.Y.ToString() + ")";
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                        rdr.Close();
                        sql = "UPDATE Incidencia SET ClaveCoordenada=" + lastId + " WHERE Folio=" +
                              dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MiListado[rowIndex] = lastId;
                    }
                }

                mapa.Refresh();
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                if (cnn != null)
                    cnn.Close();
            }
        }
    }
}