using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            ResultDS.ConnectionString = ConfigurationManager.ConnectionStrings["SAI_Conn"].ConnectionString;
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

        protected void query_ColumnsChanged(object sender, ColumnsChangeEventArgs e)
        {
            UpdateSql();
        }

        protected void query_ConditionsChanged(object sender, ConditionsChangeEventArgs e)
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
            ExportGridView();
        }

        private void ExportGridView()
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            var htw = new HtmlTextWriter(sw);

            var page = new Page();
            var form = new HtmlForm();
            ResultGrid.EnableViewState = false;
            page.EnableEventValidation = false;
            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(ResultGrid);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }
    }
}
