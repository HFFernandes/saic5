using System;
using System.Web;

namespace ConsultaRemota
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var cultura = System.Threading.Thread.CurrentThread.CurrentUICulture;
            var lengua = cultura.ToString();
            if (lengua.Length < 3)
            {
                lengua = System.Globalization.CultureInfo.CreateSpecificCulture(lengua).ToString();
            }

            Session["currentLanguage"] = lengua;
            var ruta = AppDomain.CurrentDomain.BaseDirectory;
            ruta += "data\\SAI066.xml";

            var modelo = new Korzh.EasyQuery.DataModel {UseResourcesForOperators = true};
            modelo.LoadFromFile(ruta);
            Session["DataModel"] = modelo;

            var consulta = new Korzh.EasyQuery.Query {Model = modelo};
            consulta.Formats.DateFormat = "#MM-dd-yyyy#";
            consulta.Formats.DateTimeFormat = "#MM-dd-yyyy hh:mm:ss#";
            consulta.Formats.QuoteBool = false;
            consulta.Formats.QuoteTime = false;
            consulta.Formats.SqlQuote1 = '[';
            consulta.Formats.SqlQuote2 = ']';
            consulta.Formats.SqlSyntax = Korzh.EasyQuery.SqlSyntax.SQL2;
            consulta.Formats.TimeFormat = "#hh:mm:ss#";
            Session["Query"] = consulta;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}