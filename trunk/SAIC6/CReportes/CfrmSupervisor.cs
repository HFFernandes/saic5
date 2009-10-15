using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai
{
    public partial class CfrmSupervisor : Form
    {
        private const int cveEstado = 29;
        private CDats cdat;
        private CConn cnn;
        private string sqlStr;


        public CfrmSupervisor()
        {
            InitializeComponent();
        }

        public CfrmSupervisor(ref CDats cdat, string sqlStr)
        {
            InitializeComponent();
            this.cdat = cdat;
            this.sqlStr = sqlStr;
        }

        private void CfrmSupervisor_Load(object sender, EventArgs e)
        {
            //CConn cnn = new CConn(cdat);     
            cnn = new CConn(cdat);
            dataGridView1.DataSource = cnn.GetData(sqlStr);
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No se encontraron registros");
                this.Close();
            }
        }
        
    }
}
