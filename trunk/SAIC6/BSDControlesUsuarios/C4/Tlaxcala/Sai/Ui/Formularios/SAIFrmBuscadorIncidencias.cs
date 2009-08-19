using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmBuscadorIncidencias : SAIFrmBase
    {
        public SAIFrmBuscadorIncidencias()
        {
            InitializeComponent();

            QueryColumnas.Model = ModeloDatos;
            QueryCondiciones.Model = ModeloDatos;
            QueryColumnas.Query = ModeloQuery;
            QueryCondiciones.Query = ModeloQuery;

            var strArchivo = Aplicacion.UsuarioPersistencia.strSistemaActual == "066" ? string.Format("{0}\\{1}", Environment.CurrentDirectory, "SAI066.xml") : string.Format("{0}\\{1}", Environment.CurrentDirectory, "SAI089.xml");

            try
            {
                try
                {
                    ModeloDatos.LoadFromFile(strArchivo);
                    QueryColumnas.Activate();
                    QueryCondiciones.Activate();
                }
                catch (FileNotFoundException)
                {
                    throw new SAIExcepcion("No se localizo el archivo de configuracion para los filtros de busqueda.");
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
                Close();
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
                try
                {
                    ModeloQuery.BuildSQL();

                    ResultadoDS.Tables[0].Rows.Clear();
                    ResultadoDS.Tables[0].Columns.Clear();

                    var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CooperatorConnectionString"].ConnectionString);
                    var adaptador = new SqlDataAdapter(QueryColumnas.Query.Result.SQL, conexion);
                    adaptador.Fill(ResultadoDS, "Resultado");

                    GridResultados.Refresh();
                }
                catch (SqlException ex) { throw new SAIExcepcion("Ha ocurrido un error al tratar de generar el filtro."); }
                catch (Exception ex) { throw new SAIExcepcion("Ha ocurrido un error al tratar de generar el filtro."); }
            }
            catch (SAIExcepcion)
            {
                Close();
            }
        }
    }
}
