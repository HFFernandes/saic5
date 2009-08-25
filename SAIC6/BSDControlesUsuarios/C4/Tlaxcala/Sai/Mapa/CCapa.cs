namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public class CCapa
    {
        public string File { get; set; }

        public string LabelField { get; set; }

        public string LayerName { get; set; }

        public string Type { get; set; }

        public string FillStyle //Solo se utiliza con capas de objetos poligonales
        { get; set; }

        public string FillColor //Solo se utiliza con capas de objetos poligonales
        { get; set; }

        public string LineStyle { get; set; }

        public string LineColor { get; set; }

        public string PointStyle //Solo se utiliza con capas de objetos puntuales
        { get; set; }

        public int Size { get; set; }

        public int LabelSize { get; set; }

        public bool Visible { get; set; }

        public bool ShowLabel { get; set; }

        public CCapa()
        {
            LabelField = "";
            LayerName = "";
            Type = "";
            FillStyle = "";
            FillColor = "";
            LineStyle = "";
            LineColor = "";
            PointStyle = "";
            Size = 0;
            LabelSize = 10;
            ShowLabel = true;
            Visible = false;
        }
    }
}
