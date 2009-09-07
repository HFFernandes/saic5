using System;
using System.Windows.Forms;
using System.IO;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public partial class CFrmConfDB : Form
    {
        public CFrmConfDB()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CDats cdat = new CDats();
            cdat.Server = txtServer.Text;
            cdat.User = txtUser.Text;
            cdat.Password = txtPassword.Text;
            cdat.Catalog = txtCatalogo.Text;

            CConn cconn = new CConn();
            if (cconn.TestConn(cdat))
            {
                CReg.WReg(cdat);
            }
            else
            {
                MessageBox.Show("Error, verifique los parámetros", "ERROR");
            }
        }

        private static void EscribeLog(Object value)
        {
            try
            {
                string fileName = "Error.log";
                StreamWriter writer = File.AppendText(fileName);
                writer.WriteLine("----------------------------------------");
                writer.WriteLine(value);
                writer.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void CFrmConfDB_Load(object sender, EventArgs e)
        {
            CDats cdat = new CDats();
            if ((cdat = CReg.RReg()) == null)
            {
                MessageBox.Show("Es necesario que configure la conexión a la base de datos", "Conexìón DB");
                txtServer.Text = "";
                txtUser.Text = "";
                txtPassword.Text = "";
                txtCatalogo.Text = "";
            }
            else
            {
                txtServer.Text = cdat.Server;
                txtUser.Text = cdat.User;
                txtPassword.Text = cdat.Password;
                txtCatalogo.Text = cdat.Catalog;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}