using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.MessageBox;

namespace BSD.C4.Tlaxcala.Sai
{
    public partial class CfrmPrincipal : Form
    {
        CDats cdat;
        public CfrmPrincipal()
        {
            InitializeComponent();
        }        

        private void CfrmPrincipal_Load(object sender, EventArgs e)
        {
            CConn cnn;
            try
            {
                cdat = new CDats();
                cdat = CXML.leerRegXML("conf.xml");
                if (cdat != null)
                {
                    cnn = new CConn();
                    if (!cnn.TestConn(cdat))
                        throw new ApplicationException("Es necesaro configurar la conexión a la base de datos.");
                }
                else                
                    throw new Exception("No se encuentra el archivo de configuración \"conf.xml\".");                
            }            
            catch (ApplicationException ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new ApplicationException("Error en la aplicación", ex),
                    ExceptionMessageBoxButtons.OKCancel,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = "Sistema de Administración de Incidencias.";

                DialogResult result = box.Show(this); ;
                if (result == DialogResult.OK)
                    new CFrmConfDB().ShowDialog();
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception("Error en la aplicación", ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Error,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = "Sistema de Administración de Incidencias.";
                DialogResult result = box.Show(this);
                this.Close();
            }
        }

        private void btnPunteo_Click(object sender, EventArgs e)
        {
            new CRIncidencias(ref cdat, CRIncidencias.TIPOREPORTE.Punteo).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CRIncidencias(ref cdat, CRIncidencias.TIPOREPORTE.XLS).ShowDialog();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CRIncidencias(ref cdat, CRIncidencias.TIPOREPORTE.Supervisor).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CDats cd = new CDats();
            
            CXML.escribirRegXML(cd);
        }
    }
}
