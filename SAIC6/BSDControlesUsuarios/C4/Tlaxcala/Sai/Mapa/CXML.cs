using System;
using System.Xml;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public class CXML
    {
        public CMapa leerXML(string XMLstr)
        {
            try
            {
                var xDoc = new XmlDocument();
                xDoc.Load(XMLstr);

                var mapaXML = xDoc.GetElementsByTagName("map");
                var lista = ((XmlElement)mapaXML[0]).GetElementsByTagName("layer");
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

            catch (Exception exp)
            {
                CError.EscribeLog(exp);
                return null;
            }
            finally
            {
                CError.EscribeLog();
            }
        }

        /*public CCapa[] leerXML(string XMLstr)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(XMLstr);
                XmlNodeList mapa = xDoc.GetElementsByTagName("map");
                XmlNodeList lista = ((XmlElement)mapa[0]).GetElementsByTagName("layer");
                CCapa[] capas;
                capas = new CCapa[lista.Count];
                int n = 0;
                XmlNodeList file, id, labelfield, layername, type, filltype, fillcolor, linestyle, linecolor, pointstyle, labelsize, size, showlabel, visible;
                foreach (XmlElement nodo in lista)
                {
                    capas[n] = new CCapa();
                    file = nodo.GetElementsByTagName("file");
                    capas[n].File = file[0].InnerText;
                    id = nodo.GetElementsByTagName("id");
                    capas[n].Id = id[0].InnerText;
                    layername = nodo.GetElementsByTagName("layername");
                    capas[n].LayerName = layername[0].InnerText;
                    labelfield = nodo.GetElementsByTagName("labelfield");
                    capas[n].LabelField = labelfield[0].InnerText;
                    labelsize = nodo.GetElementsByTagName("labelsize");
                    capas[n].LabelSize = int.Parse(labelsize[0].InnerText);
                    showlabel = nodo.GetElementsByTagName("showlabel");
                    if (showlabel[0].InnerText.ToLower() == "true")
                        capas[n].ShowLabel = true;
                    else
                        capas[n].ShowLabel = false;
                    type = nodo.GetElementsByTagName("type");
                    capas[n].Type = type[0].InnerText;
                    switch (capas[n].Type)
                    {
                        case "poly":
                            filltype = nodo.GetElementsByTagName("fillstyle");
                            capas[n].FillStyle = filltype[0].InnerText;
                            fillcolor = nodo.GetElementsByTagName("fillcolor");
                            capas[n].FillColor = fillcolor[0].InnerText;
                            linestyle = nodo.GetElementsByTagName("linestyle");
                            capas[n].LineStyle = linestyle[0].InnerText;
                            linecolor = nodo.GetElementsByTagName("linecolor");
                            capas[n].LineColor = linecolor[0].InnerText;
                            break;
                        case "line":
                            linestyle = nodo.GetElementsByTagName("linestyle");
                            capas[n].LineStyle = linestyle[0].InnerText;
                            linecolor = nodo.GetElementsByTagName("linecolor");
                            capas[n].LineColor = linecolor[0].InnerText;
                            break;
                        case "point":
                            pointstyle = nodo.GetElementsByTagName("pointstyle");
                            capas[n].PointStyle = pointstyle[0].InnerText;
                            fillcolor = nodo.GetElementsByTagName("fillcolor");
                            capas[n].FillColor = fillcolor[0].InnerText;
                            linecolor = nodo.GetElementsByTagName("linecolor");
                            capas[n].LineColor = linecolor[0].InnerText;
                            break;
                        default:
                            return null;
                    }
                    size = nodo.GetElementsByTagName("size");
                    capas[n].Size = int.Parse(size[0].InnerText);
                    visible = nodo.GetElementsByTagName("visible");
                    if (visible[0].InnerText.ToLower() == "true")
                        capas[n].Visible = true;
                    else
                        capas[n].Visible = false;
                    n++;
                    //capas[n].Count = n;
                }
                return capas;
            }

            catch (Exception exp)
            {
                CError.EscribeLog(exp);
                return null;
            }
            finally
            {
                CError.EscribeLog();
            }
        }        */
    }
}