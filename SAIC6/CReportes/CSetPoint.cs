using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActualMap;
using ActualMap.Windows;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using Microsoft.SqlServer.MessageBox;

namespace BSD.C4.Tlaxcala.Sai
{
    public partial class CSetPoint : Form
    {
        private const int cveEstado = 29;
        private CDats cdat;
        private CMapa mapXML;
        private CConn cnn;
        private string XMLconf;
        private string path;
        private string sqlStr;
        private int rowIndex=0;
        private bool clickView = false;
        private List<int> lstIdCoordenadas = new List<int>();
        private List<int> lstIdMunicipios = new List<int>();
        private List<int> lstIdLocalidades = new List<int>();
        private List<int> lstIdColonias = new List<int>();
        private List<int> lstIdCPs = new List<int>();
        private List<string> lstDescripciones = new List<string>();
        private List<int> lstFolios = new List<int>();
        private List<double> lstLongitud=new List<double>();
        private List<double> lstLatitud = new List<double>();
        
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
            try
            {
                cnn = new CConn(cdat);
                dataGridView1.DataSource = cnn.GetData(sqlStr);
                if (dataGridView1.RowCount != 0)
                {
                    AgregarCapas();
                    mapa.ZoomFull();
                    mapa.Refresh();
                    //Llenar la lista
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        //Llena los Folios
                        lstFolios.Add(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                        //Llena la lista de descripciones
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")                        
                            lstDescripciones.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        
                        else                        
                            lstDescripciones.Add("");                        
                        //Llena lista de idCoordenadas
                        if (dataGridView1.Rows[i].Cells["ClaveCoordenada"].Value.ToString() != "")
                        {
                            lstIdCoordenadas.Add(int.Parse(dataGridView1.Rows[i].Cells["ClaveCoordenada"].Value.ToString()));
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                            lstLongitud.Add(double.Parse(dataGridView1.Rows[i].Cells["Longitud"].Value.ToString()));
                            lstLatitud.Add(double.Parse(dataGridView1.Rows[i].Cells["Latitud"].Value.ToString()));                                                       
                        }
                        else
                        {
                            lstIdCoordenadas.Add(0);
                            lstLongitud.Add(0);
                            lstLatitud.Add(0);
                        }
                        //Llena lista de idMunicipio
                        if (dataGridView1.Rows[i].Cells["ClaveMunicipio"].Value.ToString() != "")
                            lstIdMunicipios.Add(int.Parse(dataGridView1.Rows[i].Cells["ClaveMunicipio"].Value.ToString()));
                        else
                            lstIdMunicipios.Add(0);
                        //Llena lista de idLocalidades
                        if (dataGridView1.Rows[i].Cells["ClaveLocalidad"].Value.ToString() != "")
                            lstIdLocalidades.Add(int.Parse(dataGridView1.Rows[i].Cells["ClaveLocalidad"].Value.ToString()));
                        else
                            lstIdLocalidades.Add(0);
                        //Llena lista de idColonias
                        if (dataGridView1.Rows[i].Cells["ClaveColonia"].Value.ToString() != "")
                            lstIdColonias.Add(int.Parse(dataGridView1.Rows[i].Cells["ClaveColonia"].Value.ToString()));
                        else
                            lstIdColonias.Add(0);
                        //Llena lista de idCPs
                        if (dataGridView1.Rows[i].Cells["ClaveCodigoPostal"].Value.ToString() != "")
                            lstIdCPs.Add(int.Parse(dataGridView1.Rows[i].Cells["ClaveCodigoPostal"].Value.ToString()));
                        else
                            lstIdCPs.Add(0);
                    }
                    dataGridView1.Columns.Remove("ClaveCoordenada");
                    dataGridView1.Columns.Remove("ClaveMunicipio");
                    dataGridView1.Columns.Remove("ClaveLocalidad");
                    dataGridView1.Columns.Remove("ClaveColonia");
                    dataGridView1.Columns.Remove("ClaveCodigoPostal");
                    dataGridView1.Columns.Remove("Longitud");
                    dataGridView1.Columns.Remove("Latitud");
                    fill_cboMunicipio();
                    fill_cboLocalidad();
                    fill_cboColonia();
                    fill_cboCP();
                    clickView = true;
                }
                else                
                    throw new ApplicationException("No se encontraron registros.");                                    
            }
            
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                this.Close();
            }
        }

        private void fill_cboMunicipio()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("Municipio");
            query.SelectColumns("Clave", "Nombre");
            query.AddWhere("ClaveEstado", Comparison.Equals, cveEstado);
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
            query.AddWhere("ClaveMunicipio", Comparison.Equals, cboMunicipio.SelectedValue);
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
            query.AddWhere("Localidad.Clave", Comparison.Equals, cboLocalidad.SelectedValue);
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
            query.AddWhere("Colonia.Clave", Comparison.Equals, cboColonia.SelectedValue);
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
                String directorio = path+@"\datos\";
                CXML cxml = new CXML();
                if ((mapXML = cxml.leerMapXML(path+@"\conf\"+XMLconf)) != null)
                {
                    for (int i = 0; i < mapXML.Count; i++)
                    {
                        switch (mapXML.Capas[i].Type.ToLower())
                        {
                            case "poly":
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File);
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
                                if (layer.Symbol.PointStyle == PointStyle.Bitmap)
                                {
                                    layer.Symbol.Bitmap = path + @"\symbols\" + mapXML.Capas[i].Symbol;
                                    layer.Symbol.TransparentColor = Color.White;
                                }
                                else
                                {
                                    layer.Symbol.FillColor = CEnums.getColor(mapXML.Capas[i].FillColor);
                                    layer.Symbol.LineColor = CEnums.getColor(mapXML.Capas[i].LineColor);
                                }
                                layer.Symbol.Size = mapXML.Capas[i].Size;
                                layer.Visible = mapXML.Capas[i].Visible;
                                break;
                        }
                    }                    
                    OcultarCapas(false);
                }
                else                
                    throw new Exception("Falló la carga del archivo de configuración de mapa.");                
            }
            catch(Exception ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
                this.Close();
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
                OcultarCapas(false);
                mapa.MapShapes.Clear();
                mapa.ZoomFull();
                mapa.Refresh();                
            }
        }
        
        //Refresca el Mapa centrándolo en la COLONIA elegída
        public void Colonia(int id)
        {
            try
            {              
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
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);                
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, new Exception("No se encuentra la etiqueta layername de Colonia.")),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);                                                                                                        
            }
        }

        //Refresca el Mapa centrándolo en el CP elegído
        public void CP(int id)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, new Exception("No se encuentra la etiqueta layername de Código Postal.")),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);     
            }
        }

        //Refresca el Mapa centrándolo en el MUNICIPIO elegído
        public void Municipio(int id)
        {
            try
            {                
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
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, new Exception("No se encuentra la etiqueta layername de Municipio.")),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);    
            }
        }

        //Refresca el Mapa centrándolo en la LOCALIDAD elegída
        public void Localidad(int id)
        {
            try
            {
                Recordset state;
                state = mapa["LOCALIDAD"].SearchExpression("ID = \"" + id + "\"");
                if (!state.EOF)
                {
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
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, new Exception("No se encuentra la etiqueta layername de Localidad.")),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);      
            }
        }

        public void UbicarNI(int id_colonia, int cp, int id_localidad, int id_municipio)
        {
            if (id_colonia > 0)
                Colonia(id_colonia);
            else
                if (cp > 0)
                    CP(cp);
                else
                    if (id_localidad > 0)
                        Localidad(id_localidad);
                    else
                        if (id_municipio > 0)
                            Municipio(id_municipio);
                        else
                            CentrarEstado();
        }                

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                if (rowIndex != e.RowIndex)
                {
                    if (clickView)
                    {
                        rowIndex = e.RowIndex;
                        lblRowIndex.Text = rowIndex.ToString();                       
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                        //Ubicar los municipios.
                        //Si tiene Municipio asignado
                        if (lstIdMunicipios[rowIndex] != 0)
                        {
                            cboMunicipio.SelectedValue = lstIdMunicipios[rowIndex];
                            cboMunicipio.Enabled = false;
                            fill_cboLocalidad();
                            //Si tiene Localidad asig
                            if (lstIdLocalidades[rowIndex] != 0)
                            {
                                cboLocalidad.SelectedValue = lstIdLocalidades[rowIndex];
                                cboLocalidad.Enabled = false;
                                fill_cboColonia();
                                //Si tiene Colonia asignada
                                if (lstIdColonias[rowIndex] != 0)
                                {
                                    cboColonia.SelectedValue = lstIdColonias[rowIndex];
                                    cboColonia.Enabled = false;
                                    fill_cboCP();
                                    //Si tiene Código Postal Asignado
                                    if (lstIdCPs[rowIndex] != 0)
                                    {
                                        cboCP.SelectedValue = lstIdCPs[rowIndex];
                                        cboCP.Enabled = false;
                                    }
                                    else
                                        cboCP.Enabled = true;
                                }
                                else
                                    cboColonia.Enabled = true;
                            }
                            else
                                cboLocalidad.Enabled = true;
                        }
                        else
                            cboMunicipio.Enabled = true;
                        //Modificar esta linea para que renderice si hay Municipio, Localidad, Colonia y C.P.            
                        //Renderizar si ya tiene coordenada asignada.
                        if (lstIdCoordenadas[rowIndex] != 0)
                            renderClip(new ActualMap.Point(lstLongitud[rowIndex], lstLatitud[rowIndex]));
                        if (btnVerIncidencias.Checked)
                            verIncidencias();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.EscribeLog(ex);
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, new Exception("No se encuentra el registro seleccionado.")),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
                cboMunicipio.Enabled = false;
                cboLocalidad.Enabled = false;
                cboColonia.Enabled = false;
                cboCP.Enabled = false;
            }                      
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

        private void renderClip(ActualMap.Point p)
        {
            MapShape mapShape = mapa.MapShapes.Add(p);
            if (System.IO.File.Exists(path + "\\imagenes\\clipmap.bmp"))
            {
                mapShape.Symbol.PointStyle = PointStyle.Bitmap;
                mapShape.Symbol.Bitmap = path + "\\imagenes\\clipmap.bmp";
                mapShape.Symbol.Size = 20;
                mapShape.Symbol.TransparentColor = Color.FromArgb(0,0,255);
            }
            else
            {
                mapShape.Symbol.PointStyle = PointStyle.Circle;
                mapShape.Symbol.FillColor = Color.Red;
                mapShape.Symbol.Size = 10;
            }
            mapa.Refresh();
            lblLongitud.Text = p.X.ToString();
            lblLatitud.Text = p.Y.ToString();
        }

        private void mapa_PointTool(object sender, PointToolEventArgs e)
        {
            SqlDataReader rdr = null;            
            try
            {
                int lastId;
                mapa.MapShapes.Clear();
                renderClip(new ActualMap.Point(e.Point.X,e.Point.Y));                
                //Si tiene coordenada
                lastId = lstIdCoordenadas[rowIndex];
                if (lastId > 0)
                {
                    //Actualiza si tiene coordenada
                    //Consulta generada. Sustituir por la que entre del formulario
                    sqlStr = "UPDATE Coordenada SET Longitud=" + e.Point.X.ToString() + ",Latitud=" + e.Point.Y.ToString() + " WHERE ClaveCoordenada=" + lstIdCoordenadas[rowIndex];
                    if (!cnn.EjecUpdate(sqlStr))                    
                        throw new ApplicationException("No se pudo acualizar la coordenada de la Incidencia.");                  
                }
                else
                {
                    sqlStr = "SELECT MAX(ClaveCoordenada) FROM Coordenada";
                    rdr = cnn.EjecQuery(sqlStr);
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        lastId = int.Parse(rdr.GetValue(0).ToString()) + 1;
                        rdr.Close();

                        sqlStr = "INSERT INTO Coordenada (\"ClaveCoordenada\",\"Longitud\",\"Latitud\") VALUES (" + lastId + "," + e.Point.X.ToString() + "," + e.Point.Y.ToString() + ")";
                        if (!cnn.EjecInsert(sqlStr))
                            throw new ApplicationException("No se pudo acualizar la coordenada de la Incidencia.");                  
                        rdr.Close();
                        sqlStr = "UPDATE Incidencia SET ClaveCoordenada=" + lastId + " WHERE Folio=" + lstFolios[rowIndex];
                        if (!cnn.EjecUpdate(sqlStr))
                            throw new ApplicationException("No se pudo acualizar la coordenada de la Incidencia.");                  
                        lstIdCoordenadas[rowIndex] = lastId;
                    }
                    else
                    {
                        lastId = 0;
                        sqlStr = "INSERT INTO Coordenada (\"ClaveCoordenada\",\"Longitud\",\"Latitud\") VALUES (" + lastId + "," + e.Point.X.ToString() + "," + e.Point.Y.ToString() + ")";
                        if (!cnn.EjecInsert(sqlStr))
                            throw new ApplicationException("No se pudo acualizar la coordenada de la Incidencia.");
                        rdr.Close();
                        sqlStr = "UPDATE Incidencia SET ClaveCoordenada=" + lastId + " WHERE Folio=" + lstFolios[rowIndex];
                        if (!cnn.EjecUpdate(sqlStr))
                            throw new ApplicationException("No se pudo acualizar la coordenada de la Incidencia.");
                        lstIdCoordenadas[rowIndex] = lastId;
                    }
                }
                lstLongitud[rowIndex] = e.Point.X;
                lstLatitud[rowIndex] = e.Point.Y;
                mapa.Refresh();
            }             
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }
            catch (Exception ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }            
        }       

        private void cboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {           
            try
            {
                if (clickView == true)
                {
                    cboLocalidad.Enabled = false;
                    cboColonia.Enabled = false;
                    cboCP.Enabled = false;
                    if (int.Parse(cboMunicipio.SelectedValue.ToString()) != 0)
                    {
                        sqlStr = "UPDATE Incidencia SET ClaveMunicipio=" + cboMunicipio.SelectedValue + " WHERE Folio=" + lstFolios[rowIndex];
                        if (cnn.EjecUpdate(sqlStr))
                        {
                            dataGridView1.Rows[rowIndex].Cells["Municipio"].Value = cboMunicipio.Text;
                            lstIdMunicipios[rowIndex] = int.Parse(cboMunicipio.SelectedValue.ToString());
                            if(lstIdLocalidades[rowIndex] == 0)
                                cboLocalidad.Enabled = true;
                        }
                        else
                            throw new ApplicationException("No se pudo acualizar el Municipio la Incidencia.");
                    }
                    if((lstIdCPs[rowIndex] == 0) && (lstIdColonias[rowIndex] == 0) && (lstIdLocalidades[rowIndex] == 0))
                        Municipio(int.Parse(cboMunicipio.SelectedValue.ToString()));
                    fill_cboLocalidad();
                }
            }
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }            
        }

        private void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlStr = "";
            try
            {
                if (clickView == true)
                {
                    cboColonia.Enabled = false;
                    cboCP.Enabled = false;
                    if (int.Parse(cboLocalidad.SelectedValue.ToString()) != 0)
                    {
                        sqlStr = "UPDATE Incidencia SET ClaveLocalidad=" + cboLocalidad.SelectedValue + " WHERE Folio=" + lstFolios[rowIndex];                        
                        if (cnn.EjecUpdate(sqlStr))
                        {
                            dataGridView1.Rows[rowIndex].Cells["Localidad"].Value = cboLocalidad.Text;
                            lstIdLocalidades[rowIndex] = int.Parse(cboLocalidad.SelectedValue.ToString());
                            if (lstIdColonias[rowIndex] == 0)
                                cboColonia.Enabled = true;
                        }
                        else
                            throw new ApplicationException("No se pudo acualizar la Localidad de la Incidencia.");
                    }
                    if ((lstIdCPs[rowIndex] == 0) && (lstIdColonias[rowIndex] == 0))
                        Localidad(int.Parse(cboLocalidad.SelectedValue.ToString()));
                    fill_cboColonia();                    
                }
            }
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }           
        }

        private void cboColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlStr = "";
            try
            {
                if (clickView == true)
                {                    
                    cboCP.Enabled = false;
                    if (int.Parse(cboColonia.SelectedValue.ToString()) != 0)
                    {
                        sqlStr = "UPDATE Incidencia SET ClaveColonia=" + cboColonia.SelectedValue + " WHERE Folio=" + lstFolios[rowIndex];                        
                        if (cnn.EjecUpdate(sqlStr))
                        {
                            dataGridView1.Rows[rowIndex].Cells["Colonia"].Value = cboColonia.Text;
                            lstIdColonias[rowIndex] = int.Parse(cboColonia.SelectedValue.ToString());
                            if (lstIdCPs[rowIndex] == 0)
                                cboCP.Enabled = true;
                        }
                        else
                            throw new ApplicationException("No se pudo acualizar la Colonia de la Incidencia.");
                    }
                    if (lstIdCPs[rowIndex] == 0)
                        Colonia(int.Parse(cboColonia.SelectedValue.ToString()));
                    fill_cboCP();                                        
                }
            }
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }                
        }

        private void cboCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlStr = "";
            try
            {
                if (clickView == true)
                {
                    if (int.Parse(cboCP.SelectedValue.ToString()) != 0)
                    {
                        sqlStr = "UPDATE Incidencia SET ClaveCodigoPostal=" + cboCP.SelectedValue + " WHERE Folio=" + lstFolios[rowIndex];                        
                        if (cnn.EjecUpdate(sqlStr))
                        {
                            dataGridView1.Rows[rowIndex].Cells["CP"].Value = cboCP.Text;
                            lstIdCPs[rowIndex] = int.Parse(cboCP.SelectedValue.ToString());
                        }
                        else
                            throw new ApplicationException("No se pudo acualizar el Código Postal de la Incidencia.");
                    }
                    CP(int.Parse(cboCP.SelectedValue.ToString()));                                                        
                }
            }
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }                  
        }            

        private void btnVerIncidencias_Click(object sender, EventArgs e)
        {
            verIncidencias();                      
        }
        private void verIncidencias()
        {
            try
            {
                if (btnVerIncidencias.Checked)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (lstLongitud[i] != 0 && lstLatitud[i] != 0)
                        {
                            renderClip(new ActualMap.Point(lstLongitud[i], lstLatitud[i]));
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
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.ErrorMsg, new Exception("Ocurrio un error inesperado al tratar de visualizar todas las incidencias.")),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
            }  
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {           
            if (clickView)
            {
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;                               
                if (lstIdCoordenadas[rowIndex] != 0)
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;                
            } 
        }

        private void btnShapeFile_Click(object sender, EventArgs e)
        {
            try
            {
                DynamicLayer dl;
                SaveFileDialog myDialog = new SaveFileDialog();
                myDialog.Filter = "Shape Files (*.shp)|*.shp";
                myDialog.FilterIndex = 1;
                myDialog.RestoreDirectory = true;
                myDialog.AddExtension = true;
                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    dl = new DynamicLayer(LayerType.Point);                    
                    for(int i=0;i<dataGridView1.RowCount;i++)
                    {                                         
                        if(lstLongitud[i]!=0 && lstLatitud[i]!=0)
                            dl.Add(new ActualMap.Point(lstLongitud[i], lstLatitud[i]), lstFolios[i].ToString(),lstDescripciones[i].ToString());                     
                    }                                        
                    if (dl.Export(myDialog.FileName))
                        throw new ApplicationException("Archivo "+ myDialog.FileName+" generado con éxito.");
                    else                        
                        throw new Exception("No se pudo generar el archivo " + myDialog.FileName);                    
                }
            }
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException(CMsgs.InfoMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Information,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption =   CMsgs.Caption;
                box.Show(this);
            }
            catch (Exception ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception(CMsgs.ErrorMsg, ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = CMsgs.Caption;
                box.Show(this);
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Down) && (rowIndex < dataGridView1.Rows.Count - 1))
            {                
                dataGridView1.Rows[rowIndex].Selected = false;
                rowIndex += 1;
                dataGridView1.Rows[rowIndex].Selected = true;
            }
            if ((e.KeyChar == (char)Keys.Up) && (rowIndex > 0))
            {
                dataGridView1.Rows[rowIndex].Selected = false;
                rowIndex -= 1;
                dataGridView1.Rows[rowIndex].Selected = true;
            }
        }

        private void cboMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {                
                SendKeys.Send("{TAB}");
                return;
            }
        }

        private void cboLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }

        private void cboColonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }

        private void cboCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }        
    }
}
