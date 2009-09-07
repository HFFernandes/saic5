using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public partial class CExportXLS : Form
    {
        private CDats cdat;

        public CExportXLS()
        {
            InitializeComponent();
        }

        public CExportXLS(ref CDats cdat)
        {
            InitializeComponent();
            this.cdat = cdat;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
        }

        private void btnMoveButton_Click(object sender, EventArgs e)
        {
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
        }

        private void CExportXLS_Load(object sender, EventArgs e)
        {
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Excel Files (*.xls)|*.xls";
            myDialog.FilterIndex = 1;
            myDialog.RestoreDirectory = true;
            myDialog.AddExtension = true;
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                CConn cconn = new CConn(cdat);
                SqlDataReader rdr = cconn.EjecQuery(txtSql.Text);
                if (rdr != null)
                {
                    CXls xls = new CXls(cconn);
                    xls.saveToXLS(rdr, myDialog.FileName);
                }
                MessageBox.Show("Archivo generado con éxito");
            }
        }

        private void btnDropOne_Click(object sender, EventArgs e)
        {
        }

        private void btnDropAll_Click(object sender, EventArgs e)
        {
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
        }
    }
}