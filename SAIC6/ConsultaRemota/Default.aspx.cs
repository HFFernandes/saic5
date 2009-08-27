using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Web.UI;
using Korzh.EasyQuery;
using System.Diagnostics;

namespace ConsultaRemota
{
    public partial class _Default : Page
    {
        private string baseDataPath;
        private DataModel modelo;
        private Query consulta;

        protected void Page_Init(object sender, EventArgs e)
        {
            baseDataPath = MapPath("./data");
            modelo = (DataModel)Session["DataModel"];
            consulta = (Query)Session["Query"];
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            var lang = (string)Session["currentLanguage"];
            Culture = lang;
            UICulture = lang;

            var ci = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var queryName = Page.Request.QueryString.Get("query");
                if (queryName != null)
                {
                    consulta.LoadFromFile(baseDataPath + "\\" + queryName + ".xml");
                }
            }

            modelo.ReloadResources();
            modelo.UpdateOperatorsTexts();

            QueryPanel1.BackColor = Color.White;
            QueryPanel1.Model = modelo;
            QueryPanel1.Query = consulta;

            QueryColumnsPanel1.BackColor = Color.White;
            QueryColumnsPanel1.Model = QueryPanel1.Model;
            QueryColumnsPanel1.Query = QueryPanel1.Query;

            consulta.ColumnsChanged += query_ColumnsChanged;
            consulta.ConditionsChanged += query_ConditionsChanged;

            var versionAttr =
                (System.Reflection.AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(QueryPanel1.GetType().Assembly, typeof(System.Reflection.AssemblyFileVersionAttribute));

            LabelVersion.Text = "Version: " + versionAttr.Version;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            QueryPanel1.Query.ColumnsChanged -= query_ColumnsChanged;
            QueryPanel1.Query.ConditionsChanged -= query_ConditionsChanged;
        }

        protected void query_ColumnsChanged(object sender, Korzh.EasyQuery.ColumnsChangeEventArgs e)
        {
            UpdateSql();
        }

        protected void query_ConditionsChanged(object sender, Korzh.EasyQuery.ConditionsChangeEventArgs e)
        {
            UpdateSql();
        }

        protected void UpdateSql()
        {
            System.Threading.Thread.Sleep(1000);

            var query = (Query)Session["Query"];
            try
            {
                query.BuildSQL();
                var formats = new QueryTextFormats { UseHtml = true, UseMathSymbolsForOperators = true };
                Debug.WriteLine(query.GetConditionsText(formats));
                ResultDS.SelectCommand = query.Result.SQL;
                ResultDS.Select(DataSourceSelectArguments.Empty);
                ResultLabel.Visible = false;
                ResultGrid.Visible = true;
            }
            catch (Exception)
            {
            }
        }

        protected void ExportExcelBtn_Click(object sender, EventArgs e)
        {
            ExportarResultados("text/csv", "result.txt");
        }

        protected void ExportarResultados(string contentType, string fileName)
        {
            ResultDS.SelectCommand = consulta.Result.SQL;
            var view = (DataView)ResultDS.Select(DataSourceSelectArguments.Empty);
            if (view == null) return;
            var result = new StringBuilder("");

            foreach (DataRowView row in view)
            {
                int i = 0;
                foreach (DataColumn col in view.Table.Columns)
                {
                    var obj = row[i];
                    var s = obj == null ? string.Empty : obj.ToString();
                    if (i > 0) result.Append(',');
                    result.Append("\"" + ConvertToCSV(s) + "\"");
                    i++;
                }
                result.Append(Environment.NewLine);
            }

            Response.ClearHeaders();
            Response.Clear();
            Response.ContentType = contentType;
            Response.BufferOutput = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);

            var output = Encoding.UTF8.GetBytes(result.ToString());
            Response.OutputStream.Write(output, 0, output.GetLength(0));
            Response.End();
        }

        protected string ConvertToCSV(string s)
        {
            var result = s.Replace(",", "\\,");
            result = result.Replace("\"", "\\\"");
            return result;
        }
    }
}
