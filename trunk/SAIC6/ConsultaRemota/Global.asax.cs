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
            var ci = System.Threading.Thread.CurrentThread.CurrentUICulture;
            var lang = ci.ToString();

            if (lang.Length < 3)
            {
                lang = System.Globalization.CultureInfo.CreateSpecificCulture(lang).ToString();
            }

            Session["currentLanguage"] = lang;
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path += "data\\SAI066.xml";

            var model = new Korzh.EasyQuery.DataModel { UseResourcesForOperators = true };

            model.LoadFromFile(path);
            Session["DataModel"] = model;

            var query = new Korzh.EasyQuery.Query { Model = model };
            query.Formats.DateFormat = "#MM-dd-yyyy#";
            query.Formats.DateTimeFormat = "#MM-dd-yyyy hh:mm:ss#";
            query.Formats.QuoteBool = false;
            query.Formats.QuoteTime = false;
            query.Formats.SqlQuote1 = '[';
            query.Formats.SqlQuote2 = ']';
            query.Formats.SqlSyntax = Korzh.EasyQuery.SqlSyntax.SQL2;
            query.Formats.TimeFormat = "#hh:mm:ss#";
            Session["Query"] = query;
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