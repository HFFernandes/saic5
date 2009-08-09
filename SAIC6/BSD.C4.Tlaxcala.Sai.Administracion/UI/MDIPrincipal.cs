using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void catalogoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm_Usuarios = new frmUsuarios();
            frm_Usuarios.MdiParent = this;
            frm_Usuarios.Show();
            //frm_Usuarios.ShowDialog();
        }

        private void catalogoDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermisos frm_Permisos = new frmPermisos();
            frm_Permisos.MdiParent = this;
            frm_Permisos.Show();
        }

        private void catalogoDeTiposDeIncidenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoIncidencias frm_TiposIncidencias = new frmTipoIncidencias();
            frm_TiposIncidencias.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
