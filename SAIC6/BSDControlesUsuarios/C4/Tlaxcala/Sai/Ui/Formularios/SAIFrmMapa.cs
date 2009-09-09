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
    /// <summary>
    /// Formulario que presenta la cartografia del estado
    /// </summary>
    public partial class SAIFrmMapa : Form
    {
        CMapa mapXML;
        private readonly string XMLconf;
        private readonly string path;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="XMLconf">archivo xml que almacena la configuración</param>
        /// <param name="path">ruta del archivo</param>
        public SAIFrmMapa(string XMLconf, string path)
        {
            InitializeComponent();

            Size = new Size(640, 480);
            this.XMLconf = XMLconf;
            this.path = path;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="XMLconf">archivo xml que almacena la configuración</param>
        /// <param name="path">ruta del archivo</param>
        /// <param name="width">ancho en pixeles del formulario</param>
        /// <param name="height">alto en pixeles del formulario</param>
        public SAIFrmMapa(string XMLconf, string path, int width, int height)
        {
            InitializeComponent();

            Size = new Size(width, height);
            this.XMLconf = XMLconf;
            this.path = path;
        }

        private void CMapa_Load(object sender, EventArgs e)
        {
            AgregarCapas();

            mapa.ZoomFull();
            mapa.Refresh();

            btnLeyenda_Click(sender,e);
        }

        /// <summary>
        /// Método que establece las n capas que deberá presentar el control
        /// </summary>
        private void AgregarCapas()
        {
            try
            {
                Layer layer;
                var directorio = path;
                var cxml = new CXML();

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
                MessageBox.Show(ex.ToString());
            }
        }

        private void AgregarLeyenda()
        {
            leyenda.Populate(mapa);
        }

        /// <summary>
        /// Método para ubicar el mapa en la capa de colonias con el ID pasado
        /// </summary>
        /// <param name="id">Identificador de la colonia</param>
        public void Colonia(int id)
        {
            try
            {
                ActualizaLbl(true);
                var state = mapa["COLONIA"].SearchExpression("ID = \"" + id + "\"");

                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    var shape = mapa.MapShapes.Add(state.Shape);
                    var s = new Symbol
                                {
                                    FillStyle = FillStyle.DiagonalCross,
                                    FillColor = Color.Yellow,
                                    LineColor = Color.Red,
                                    Size = 3
                                };
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Método para ubicar el mapa en la capa de cp con el ID pasado
        /// </summary>
        /// <param name="id">Identificador del cp</param>
        public void CP(int id)
        {
            try
            {
                ActualizaLbl(true);
                var state = mapa["COLONIA"].SearchExpression("CP = \"" + id + "\"");

                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    var shape = mapa.MapShapes.Add(state.Shape);
                    var s = new Symbol
                                {
                                    FillStyle = FillStyle.DiagonalCross,
                                    FillColor = Color.Yellow,
                                    LineColor = Color.Red,
                                    Size = 3
                                };
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Método para ubicar el mapa en la capa de municipios con el ID pasado
        /// </summary>
        /// <param name="id">Identificador del municipio</param>
        public void Municipio(int id)
        {
            try
            {
                ActualizaLbl(true);
                var state = mapa["MUNICIPIO"].SearchExpression("ID = \"" + id + "\"");

                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    var shape = mapa.MapShapes.Add(state.Shape);
                    var s = new Symbol
                                {
                                    FillStyle = FillStyle.DiagonalCross,
                                    FillColor = Color.Yellow,
                                    LineColor = Color.Red,
                                    Size = 3
                                };
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Método para ubicar el mapa en la capa de localidades con el ID pasado
        /// </summary>
        /// <param name="id">Identificador de la localidad</param>
        public void Localidad(int id)
        {
            try
            {
                ActualizaLbl(true);
                var state = mapa["LOCALIDAD"].SearchExpression("ID = \"" + id + "\"");

                if (!state.EOF)
                {
                    OcultarCapas(true);
                    mapa.Extent = state.RecordExtent;
                    mapa.MapShapes.Clear();
                    var shape = mapa.MapShapes.Add(state.Shape);
                    var s = new Symbol { FillStyle = FillStyle.Invisible, LineColor = Color.Red, Size = 17 };
                    shape.Symbol = s;
                    mapa.Refresh();
                }
                ActualizaLbl(false);
            }
            catch (Exception ex)
            {
                ActualizaLbl(false);
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
            lblUpdate.Location = new System.Drawing.Point(Size.Width / 2, Size.Height / 2);
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
