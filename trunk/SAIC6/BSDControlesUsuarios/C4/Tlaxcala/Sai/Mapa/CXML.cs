using System;
using System.Xml;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    ///<summary>
    ///</summary>
    public class CXML
    {
        ///<summary>
        ///</summary>
        ///<param name="XMLstr"></param>
        ///<returns></returns>
        public CMapa leerXML(string XMLstr)
        {
            try
            {
                var xDoc = new XmlDocument();
                xDoc.Load(XMLstr);

                var mapaXML = xDoc.GetElementsByTagName("map");
                var lista = ((XmlElement) mapaXML[0]).GetElementsByTagName("layer");
                //CCapa[] capas;
                var mapa = new CMapa(lista.Count);
                //capas = new CCapa[lista.Count];
                int n = 0;
                XmlNodeList file,
                            labelfield,
                            layername,
                            type,
                            filltype,
                            fillcolor,
                            linestyle,
                            linecolor,
                            pointstyle,
                            labelsize,
                            size,
                            showlabel,
                            visible;

                foreach (XmlElement nodo in lista)
                {
                    mapa.Capas[n] = new CCapa();
                    file = nodo.GetElementsByTagName("file");
                    mapa.Capas[n].File = file[0].InnerText;
                    layername = nodo.GetElementsByTagName("layername");
                    mapa.Capas[n].LayerName = layername[0].InnerText;
                    labelfield = nodo.GetElementsByTagName("labelfield");
                    mapa.Capas[n].LabelField = labelfield[0].InnerText;
                    labelsize = nodo.GetElementsByTagName("labelsize");
                    mapa.Capas[n].LabelSize = int.Parse(labelsize[0].InnerText);
                    showlabel = nodo.GetElementsByTagName("showlabel");

                    mapa.Capas[n].ShowLabel = showlabel[0].InnerText.ToLower() == "true";
                    type = nodo.GetElementsByTagName("type");
                    mapa.Capas[n].Type = type[0].InnerText;

                    switch (mapa.Capas[n].Type)
                    {
                        case "poly":
                            filltype = nodo.GetElementsByTagName("fillstyle");
                            mapa.Capas[n].FillStyle = filltype[0].InnerText;
                            fillcolor = nodo.GetElementsByTagName("fillcolor");
                            mapa.Capas[n].FillColor = fillcolor[0].InnerText;
                            linestyle = nodo.GetElementsByTagName("linestyle");
                            mapa.Capas[n].LineStyle = linestyle[0].InnerText;
                            linecolor = nodo.GetElementsByTagName("linecolor");
                            mapa.Capas[n].LineColor = linecolor[0].InnerText;
                            break;
                        case "line":
                            linestyle = nodo.GetElementsByTagName("linestyle");
                            mapa.Capas[n].LineStyle = linestyle[0].InnerText;
                            linecolor = nodo.GetElementsByTagName("linecolor");
                            mapa.Capas[n].LineColor = linecolor[0].InnerText;
                            break;
                        case "point":
                            pointstyle = nodo.GetElementsByTagName("pointstyle");
                            mapa.Capas[n].PointStyle = pointstyle[0].InnerText;
                            fillcolor = nodo.GetElementsByTagName("fillcolor");
                            mapa.Capas[n].FillColor = fillcolor[0].InnerText;
                            linecolor = nodo.GetElementsByTagName("linecolor");
                            mapa.Capas[n].LineColor = linecolor[0].InnerText;
                            break;
                        default:
                            return null;
                    }

                    size = nodo.GetElementsByTagName("size");
                    mapa.Capas[n].Size = int.Parse(size[0].InnerText);
                    visible = nodo.GetElementsByTagName("visible");
                    mapa.Capas[n].Visible = visible[0].InnerText.ToLower() == "true";
                    n++;
                }
                mapa.Count = n;
                return mapa;
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}