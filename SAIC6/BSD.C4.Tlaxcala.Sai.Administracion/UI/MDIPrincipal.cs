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

        /// <summary>
        /// Crea una instancia del formulario de Usuarios
        /// </summary>
        private void catalogoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm_Usuarios = new frmUsuarios();
            frm_Usuarios.MdiParent = this;
            frm_Usuarios.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Permisos
        /// </summary>
        private void catalogoDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermisos frm_Permisos = new frmPermisos();
            frm_Permisos.MdiParent = this;
            frm_Permisos.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Tipos Incidencias
        /// </summary>
        private void catalogoDeTiposDeIncidenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoIncidencias frm_TiposIncidencias = new frmTipoIncidencias();
            frm_TiposIncidencias.MdiParent = this;
            frm_TiposIncidencias.Show();
        }

        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Crea una instancia del formulario de Corporaciones
        /// </summary>
        private void catalogoDeCorporacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorporaciones frm_Corporaciones = new frmCorporaciones();
            frm_Corporaciones.MdiParent = this;
            frm_Corporaciones.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Unidades
        /// </summary>
        private void catalogoDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnidades frm_Unidades = new frmUnidades();
            frm_Unidades.MdiParent = this;
            frm_Unidades.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Colonias
        /// </summary>
        private void catalogoDeColoniasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColonias frm_Colonias = new frmColonias();
            frm_Colonias.MdiParent = this;
            frm_Colonias.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario Municipios 
        /// </summary>
        private void catalogoDeMunicipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMunicipios frm_Municipios = new frmMunicipios();
            frm_Municipios.MdiParent = this;
            frm_Municipios.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Localidades
        /// </summary>
        private void catalogoDeLocalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidades frm_Localidades = new frmLocalidades();
            frm_Localidades.MdiParent = this;
            frm_Localidades.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Bitacora
        /// </summary>
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacora frm_Bitacora = new frmBitacora();
            frm_Bitacora.MdiParent = this;
            frm_Bitacora.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Dependencias
        /// </summary>
        private void catalogoDeDependenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDependecias frm_Dependencias = new frmDependecias();
            frm_Dependencias.MdiParent = this;
            frm_Dependencias.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Clasificacion de Organizaciones
        /// </summary>
        private void catalogoClasificacionDeOrganizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClasificacionOrganizacion frm_ClasificacionOrganizacion = new frmClasificacionOrganizacion();
            frm_ClasificacionOrganizacion.MdiParent = this;
            frm_ClasificacionOrganizacion.Show();
        }

        /// <summary>
        /// Crea una instancia del formulario de Organizaciones
        /// </summary>
        private void catalogoDeOrganizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrganizacion frm_Organizacion = new frmOrganizacion();
            frm_Organizacion.MdiParent = this;
            frm_Organizacion.Show();
        }
    }
}