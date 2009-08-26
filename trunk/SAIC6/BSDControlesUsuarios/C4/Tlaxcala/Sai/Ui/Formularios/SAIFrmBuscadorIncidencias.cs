using System;
using System.IO;
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

            CargarModelo();
        }

        private void ModeloQuery_ColumnsChanged(object sender, Korzh.EasyQuery.ColumnsChangeEventArgs e)
        {
            ActualizarResultado();
        }

        private void ModeloQuery_ConditionsChanged(object sender, Korzh.EasyQuery.ConditionsChangeEventArgs e)
        {
            ActualizarResultado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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
                catch (Exception ex) { throw new SAIExcepcion(ID.STR_ERRORFILTRO); }
            }
            catch (SAIExcepcion)
            {
                QueryColumnas.Model = null;
                QueryCondiciones.Model = null;
                CargarModelo();
            }
        }

        public void CargarConsulta(string strPath)
        {
            try
            {
                try
                {
                    ModeloQuery.LoadFromFile(strPath);
                }
                catch (FileNotFoundException)
                {
                    throw new SAIExcepcion(ID.STR_NOSELOCALIZOARCHIVO);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        private void CargarModelo()
        {
            var strArchivo = Aplicacion.UsuarioPersistencia.strSistemaActual == "066" ? string.Format("{0}\\{1}", Environment.CurrentDirectory, "SAI066.xml") : string.Format("{0}\\{1}", Environment.CurrentDirectory, "SAI089.xml");

            try
            {
                try
                {
                    ModeloDatos.LoadFromFile(strArchivo);

                    QueryColumnas.Model = ModeloDatos;
                    QueryCondiciones.Model = ModeloDatos;
                    QueryColumnas.Query = ModeloQuery;
                    QueryCondiciones.Query = ModeloQuery;

                    QueryColumnas.Activate();
                    QueryCondiciones.Activate();
                }
                catch (FileNotFoundException)
                {
                    throw new SAIExcepcion(ID.STR_NOSELOCALIZOARCHIVO);
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
            //ModeloQuery.LoadFromFile(@"D:\nplantilla.xml");
        }

        private void GridResultados_DoubleClick(object sender, EventArgs e)
        {
            //ModeloQuery.SaveToFile(@"D:\SLC.xml");
        }
    }
}
