using System;
using System.Collections.Generic;

using System.Text;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public class CCapa
    {
        private string file, labelfield, layername, type, fillstyle, fillcolor, linestyle, linecolor, pointstyle;
        private int size,labelsize;
        private bool visible,showlabel;
        public string File
        {
            get { return file; }
            set { file = value; }
        }
        public string LabelField
        {
            get { return labelfield; }
            set { labelfield = value; }
        }
        public string LayerName
        {
            get { return layername; }
            set { layername = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string FillStyle//Solo se utiliza con capas de objetos poligonales
        {
            get { return fillstyle; }
            set { fillstyle = value; }
        }
        public string FillColor//Solo se utiliza con capas de objetos poligonales
        {
            get { return fillcolor; }
            set { fillcolor = value; }
        }
        public string LineStyle
        {
            get { return linestyle; }
            set { linestyle = value; }
        }
        public string LineColor
        {
            get { return linecolor; }
            set { linecolor = value; }
        }
        public string PointStyle//Solo se utiliza con capas de objetos puntuales
        {
            get { return pointstyle; }
            set { pointstyle = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public int LabelSize
        {
            get { return labelsize; }
            set { labelsize = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        public bool ShowLabel
        {
            get { return showlabel; }
            set { showlabel = value; }
        }
        public CCapa()
        {
            labelfield = "";
            layername = "";
            type = "";
            fillstyle = "";
            fillcolor = "";
            linestyle = "";
            linecolor = "";
            pointstyle = "";
            size = 0;
            labelsize = 10;
            showlabel = true;
            visible = false;
        }
    }
}
