using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ActualMap;
using ActualMap.Windows;
using BSD.C4.Tlaxcala.Sai.Mapa;
using CPw;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{

    public partial class SAIFrmMapa : Form
    {
        //CCapa[] mapXML.Capas;
        CMapa mapXML;
        private string XMLconf;
        private string path;
        public SAIFrmMapa(string XMLconf, string path)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(640, 480);
            this.XMLconf = XMLconf;
            this.path = path;
        }
        public SAIFrmMapa(string XMLconf, string path, int width, int height)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(width, height);
            this.XMLconf = XMLconf;
            this.path = path;
        }

        private void CMapa_Load(object sender, EventArgs e)
        {
            AgregarCapas();
            mapa.ZoomFull();
            mapa.Refresh();
        }

        private void AgregarCapas()
        {
            try
            {
                Layer layer;
                String directorio = path;
                CXML cxml = new CXML();
                if ((mapXML = cxml.leerXML(XMLconf)) != null)
                {
                    for (int i = 0; i < mapXML.Count; i++)
                    {
                        switch (mapXML.Capas[i].Type.ToLower())
                        {
                            case "poly":
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File, Abrir());
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
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File, Abrir());
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
                                layer = mapa.AddLayer(directorio + mapXML.Capas[i].File, Abrir());
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
        private void AgregarLeyenda()
        {
            leyenda.Populate(mapa);
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
        private void OcultarCapas(bool val)
        {
            for (int i = 0; i < mapXML.Count; i++)
            {
                if (mapXML.Capas[i].LayerName.ToUpper() != "MUNICIPIO")
                {
                    mapa[mapXML.Capas[i].LayerName].Visible = val;
                }
            }
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
                btnZoomIn.Checked = false;
                btnZoomOut.Checked = false;
            }
        }
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (!btnZoomIn.Checked)
            {
                btnZoomIn.Checked = true;
                mapa.MapTool = MapTool.ZoomIn;
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
                btnPanning.Checked = false;
                btnZoomIn.Checked = false;
            }
        }

        private void mnuFullExtend_Click(object sender, EventArgs e)
        {
            mapa.ZoomFull();
            mapa.Refresh();
            ActivarPanning();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLeyenda_Click(object sender, EventArgs e)
        {
            if (leyenda.Visible)
            {
                leyenda.Visible = !leyenda.Visible;
                btnLeyenda.ForeColor = Color.Red;
                contenedorMapa.Panel2Collapsed = true;
            }
            else
            {
                leyenda.Visible = !leyenda.Visible;
                btnLeyenda.ForeColor = Color.Blue;
                contenedorMapa.Panel2Collapsed = false;
            }
        }

        private void BuscaDentroDe()
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mapa_Click(object sender, EventArgs e)
        {

        }

        private void CMapa_Activated(object sender, EventArgs e)
        {
            ActivarPanning();
            mapa.Enabled = true;
        }

        private void CMapa_Deactivate(object sender, EventArgs e)
        {
            mapa.Enabled = false;
        }

        private void ActualizaLbl(bool flag)
        {
            lblUpdate.Location = new System.Drawing.Point(this.Size.Width / 2, this.Size.Height / 2);
            lblUpdate.Visible = flag;
        }
        private string Abrir()
        {
            return new Ccpd().getPd();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (Aplicacion.VentanasIncidencias.Count > 0)
            {
                e.Cancel = true;
                return;
            }
            base.OnClosing(e);
        }
    }
}
