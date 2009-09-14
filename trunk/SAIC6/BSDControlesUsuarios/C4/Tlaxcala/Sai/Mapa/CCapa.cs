namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    ///<summary>
    ///</summary>
    public class CCapa
    {
        ///<summary>
        ///</summary>
        public string File { get; set; }

        ///<summary>
        ///</summary>
        public string LabelField { get; set; }

        ///<summary>
        ///</summary>
        public string LayerName { get; set; }

        ///<summary>
        ///</summary>
        public string Type { get; set; }

        ///<summary>
        ///</summary>
        public string FillStyle //Solo se utiliza con capas de objetos poligonales
        { get; set; }

        ///<summary>
        ///</summary>
        public string FillColor //Solo se utiliza con capas de objetos poligonales
        { get; set; }

        ///<summary>
        ///</summary>
        public string LineStyle { get; set; }

        ///<summary>
        ///</summary>
        public string LineColor { get; set; }

        ///<summary>
        ///</summary>
        public string PointStyle //Solo se utiliza con capas de objetos puntuales
        { get; set; }

        ///<summary>
        ///</summary>
        public int Size { get; set; }

        ///<summary>
        ///</summary>
        public int LabelSize { get; set; }

        ///<summary>
        ///</summary>
        public bool Visible { get; set; }

        ///<summary>
        ///</summary>
        public bool ShowLabel { get; set; }

        ///<summary>
        ///</summary>
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