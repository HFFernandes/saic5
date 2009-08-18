using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmBuscadorIncidencias : SAIFrmBase
    {
        public SAIFrmBuscadorIncidencias()
        {
            InitializeComponent();

            QueryColumnas.Model = this.ModeloDatos;
            QueryCondiciones.Model = this.ModeloDatos;
            QueryColumnas.Query = this.ModeloQuery;
            QueryCondiciones.Query = this.ModeloQuery;

            var en =
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "BSD.C4.Tlaxcala.Sai.RecursosEmbebidos.SAI066.xml");

            if (en != null)
            {
                var stmArchivo = string.Format("{0}{1}", Path.GetTempPath(), "modelo066.xml");
                var xmlDocumento = new XmlDocument();
                xmlDocumento.Load(en);
                xmlDocumento.Save(stmArchivo);

                ModeloDatos.LoadFromFile(stmArchivo);
                QueryColumnas.Activate();
                QueryCondiciones.Activate();
            }
        }

        private void SAIFrmBuscadorIncidencias_Load(object sender, EventArgs e)
        {

        }

        private void ModeloQuery_ColumnsChanged(object sender, Korzh.EasyQuery.ColumnsChangeEventArgs e)
        {
            ActualizarResultado();
        }

        private void ModeloQuery_ConditionsChanged(object sender, Korzh.EasyQuery.ConditionsChangeEventArgs e)
        {
            ActualizarResultado();
        }

        private void ActualizarResultado()
        {
            try
            {
                ModeloQuery.BuildSQL();

                ResultadoDS.Tables[0].Rows.Clear();
                ResultadoDS.Tables[0].Columns.Clear();

                var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CooperatorConnectionString"].ConnectionString);
                var adaptador = new SqlDataAdapter(QueryColumnas.Query.Result.SQL, conexion);
                adaptador.Fill(ResultadoDS, "Resultado");
            }
            catch (SqlException) { }
            catch (Exception) { }
        }
    }
}
