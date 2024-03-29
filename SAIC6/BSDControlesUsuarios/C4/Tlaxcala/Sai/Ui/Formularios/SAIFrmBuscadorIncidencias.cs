using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    ///<summary>
    ///</summary>
    public partial class SAIFrmBuscadorIncidencias : SAIFrmBase
    {
        ///<summary>
        ///</summary>
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

                    var conexion =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["CooperatorConnectionString"].ConnectionString);
                    if (conexion.State == ConnectionState.Closed)
                        conexion.Open();

                    var adaptador = new SqlDataAdapter(QueryColumnas.Query.Result.SQL, conexion);
                    adaptador.Fill(ResultadoDS, "Resultado");
                    GridResultados.Refresh();
                }
                catch (Exception)
                {
                    throw new SAIExcepcion(ID.STR_ERRORFILTRO,this);
                }
            }
            catch (SAIExcepcion)
            {
                QueryColumnas.Model = null;
                QueryCondiciones.Model = null;
                CargarModelo();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="strPath"></param>
        ///<exception cref="SAIExcepcion"></exception>
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
                    throw new SAIExcepcion(ID.STR_NOSELOCALIZOARCHIVO,this);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message,this);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        private void CargarModelo()
        {
            var strArchivo = Aplicacion.UsuarioPersistencia.strSistemaActual == "066"
                                 ? string.Format("{0}\\{1}", Environment.CurrentDirectory, "SAI066.xml")
                                 : string.Format("{0}\\{1}", Environment.CurrentDirectory, "SAI089.xml");

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
                    throw new SAIExcepcion(ID.STR_NOSELOCALIZOARCHIVO,this);
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message,this);
                }
            }
            catch (SAIExcepcion)
            {
                Close();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
        }
    }
}