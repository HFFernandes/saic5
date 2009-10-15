using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CReportes
{
    public partial class CFrmGenReportes : Form
    {
        CDats cdat;
        public CFrmGenReportes()
        {
            InitializeComponent();           
        }

        private void conexiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CFrmConfDB frmConn = new CFrmConfDB();
            frmConn.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CConn cnn;
            cdat = new CDats();
            cdat = CXML.leerRegXML("conf.xml");
            if (cdat != null)
            {
                cnn = new CConn();
                cnn.TestConn(cdat);
            }
            else
            {
                MessageBox.Show("Es necesario configurar la conexión a la base de datos");
                new CFrmConfDB().ShowDialog();
            }
        }

        private void exportarAXLSExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CExportXLS cxls = new CExportXLS(ref cdat);                        
            cxls.ShowDialog();            
        }

        private void setPointToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //Consulta generada. Sustituir por la que entre del formulario
            string sql;
            /*
            sql = "SELECT Incidencia.Folio, Incidencia.FolioPadre, Incidencia.Descripcion, Incidencia.Direccion, Incidencia.Referencias, Incidencia.ClaveDenunciante," 
                +"Incidencia.ClaveEstatus, Municipio.Nombre AS MunicipioN, Localidad.Nombre AS LocalidadN, Colonia.Nombre AS ColoniaN, CodigoPostal.Valor AS CodigoPostalN, " 
                +"Incidencia.ClaveCoordenada " 
                +"FROM  Incidencia, Municipio, Localidad, Colonia ,  CodigoPostal " 
                +"WHERE Incidencia.ClaveMunicipio=Municipio.Clave and Incidencia.ClaveLocalidad=Localidad.Clave and Incidencia.ClaveColonia=Colonia.Clave " 
                +"and Incidencia.ClaveCodigoPostal=CodigoPostal.Clave";
             */
            sql = "SELECT Incidencia.Folio, Incidencia.FolioPadre, Incidencia.Descripcion, Incidencia.Direccion, Incidencia.Referencias, Incidencia.ClaveDenunciante,"
               + "Incidencia.ClaveEstatus, Municipio.Nombre AS MunicipioN, Incidencia.ClaveCoordenada "
               + "FROM  Incidencia, Municipio "
               + "WHERE Incidencia.ClaveMunicipio=Municipio.Clave";
            CSetPoint csp = new CSetPoint(ref cdat, "map.xml", Application.StartupPath,sql);
            csp.ShowDialog();
        }

        private void cRIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRIncidencias cri = new CRIncidencias(ref cdat,CRIncidencias.TIPOREPORTE.Punteo);
            cri.ShowDialog();
        }
    }
}
