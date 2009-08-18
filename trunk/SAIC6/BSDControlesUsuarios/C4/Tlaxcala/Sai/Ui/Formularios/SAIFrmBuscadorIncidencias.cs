using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmBuscadorIncidencias : SAIFrmBase
    {
        public string ConsultaGenerada { get; set; }

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
                var stmArchivo = string.Format("{0}{1}", Path.GetTempPath(), "modelo.xml");
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
            ConsultaGenerada = Consulta();
        }

        private void ModeloQuery_ConditionsChanged(object sender, Korzh.EasyQuery.ConditionsChangeEventArgs e)
        {
            ConsultaGenerada = Consulta();
        }

        private string Consulta()
        {
            ModeloQuery.BuildSQL();
            return QueryCondiciones.Query.Result.SQL ?? string.Empty;
        }
    }
}
