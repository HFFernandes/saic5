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

        protected void LoadBtn_Click(object sender, EventArgs e)
        {
            //if (SavedQueryUpload.HasFile)
            //{
            //    try
            //    {
            //        // Initialize the reader.
            //        System.IO.TextReader reader = new StreamReader(SavedQueryUpload.PostedFile.InputStream);

            //        // Copy the byte array into a string.
            //        string QueryText = reader.ReadToEnd();

            //        reader.Close();

            //        QueryPanel1.Query.LoadFromString(QueryText);
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorLabel.Text = "Error during loading: " + ex.Message;
            //        ErrorLabel.Visible = true;
            //    }
            //}
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            //Response.ClearHeaders();
            //Response.ContentType = "text/xml";
            //Response.Clear();

            //Response.BufferOutput = true;
            //Response.AddHeader("Content-Disposition", "attachment;filename=query.xml");

            //string QueryText = QueryPanel1.Query.SaveToString();
            //byte[] output = System.Text.UnicodeEncoding.UTF8.GetBytes(QueryText);

            //Response.OutputStream.Write(output, 0, output.GetLength(0));

            //Response.End();
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
            //System.Threading.Thread.Sleep(1500);

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
            ExportResultTo("text/csv", "result.txt");
        }

        protected void ExportResultTo(string contentType, string fileName)
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
