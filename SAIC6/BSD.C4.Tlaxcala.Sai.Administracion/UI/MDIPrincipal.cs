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
            frm_TiposIncidencias.MdiParent = this;
            frm_TiposIncidencias.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void catalogoDeCorporacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorporaciones frm_Corporaciones = new frmCorporaciones();
            frm_Corporaciones.MdiParent = this;
            frm_Corporaciones.Show();
        }

        private void catalogoDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnidades frm_Unidades = new frmUnidades();
            frm_Unidades.MdiParent = this;
            frm_Unidades.Show();

        }

        private void catalogoDeColoniasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColonias frm_Colonias = new frmColonias();
            frm_Colonias.MdiParent = this;
            frm_Colonias.Show();
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void catalogoDeMunicipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMunicipios frm_Municipios = new frmMunicipios();
            frm_Municipios.MdiParent = this;
            frm_Municipios.Show();
        }

        private void catalogoDeLocalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidades frm_Localidades = new frmLocalidades();
            frm_Localidades.MdiParent = this;
            frm_Localidades.Show();
        }
    }
}
