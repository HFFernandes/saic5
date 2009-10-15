using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace BSD.C4.Tlaxcala.Sai
{
    class CXML
    {
        public CXML()
        {
        }
        public CMapa leerXML(string XMLstr)
        {            
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(XMLstr);
                XmlNodeList mapaXML = xDoc.GetElementsByTagName("map");
                XmlNodeList lista = ((XmlElement)mapaXML[0]).GetElementsByTagName("layer");
                //CCapa[] capas;
                CMapa mapa = new CMapa(lista.Count);                
                //capas = new CCapa[lista.Count];
                int n = 0;
                XmlNodeList file, labelfield, layername, type, filltype, fillcolor, linestyle, linecolor, pointstyle, labelsize, size, showlabel, visible;
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
                    if (showlabel[0].InnerText.ToLower() == "true")
                        mapa.Capas[n].ShowLabel = true;
                    else
                        mapa.Capas[n].ShowLabel = false;
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
                    if (visible[0].InnerText.ToLower() == "true")
                        mapa.Capas[n].Visible = true;
                    else
                        mapa.Capas[n].Visible = false;
                    n++;                    
                }
                mapa.Count = n;
                return mapa;
            }
                      
            catch(Exception ex)
            {                
                CError.EscribeLog(ex);
                return null;
            }
            finally
            {
                CError.EscribeLog();
            }
        }
        public static CDats leerRegXML(string XMLstr)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(XMLstr);
                XmlNodeList regXML = xDoc.GetElementsByTagName("config");
                XmlNodeList lista = ((XmlElement)regXML[0]).GetElementsByTagName("cfg");
                CMapa mapa = new CMapa(lista.Count);

                CDats cdat = new CDats();
                
                XmlNodeList user, password, server, catalog;
                foreach (XmlElement nodo in lista)
                {
                    user = nodo.GetElementsByTagName("user");
                    cdat.User = user[0].InnerText;
                    password = nodo.GetElementsByTagName("password");
                    cdat.Password = password[0].InnerText;
                    server = nodo.GetElementsByTagName("server");
                    cdat.Server = server[0].InnerText;
                    catalog = nodo.GetElementsByTagName("catalog");
                    cdat.Catalog = catalog[0].InnerText;                 
                }

                return cdat;
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
        public static bool escribirRegXML(CDats cdat)
        {
            try
            {
                XmlTextWriter myXmlTextWriter = new XmlTextWriter("conf.xml", null);
                myXmlTextWriter.Formatting = Formatting.Indented;
                myXmlTextWriter.WriteStartDocument(false);
                myXmlTextWriter.WriteStartElement("config");
                myXmlTextWriter.WriteStartElement("cfg", null);
                myXmlTextWriter.WriteElementString("user", cdat.User);
                myXmlTextWriter.WriteElementString("password", cdat.Password);
                myXmlTextWriter.WriteElementString("server", cdat.Server);
                myXmlTextWriter.WriteElementString("catalog", cdat.Catalog);
                myXmlTextWriter.WriteEndElement();
                myXmlTextWriter.Flush();
                myXmlTextWriter.Close();
                return true;
            }

            catch (Exception exp)
            {
                CError.EscribeLog(exp);
                return false;
            }
            finally
            {
                CError.EscribeLog();
            }
        }
    }
}
