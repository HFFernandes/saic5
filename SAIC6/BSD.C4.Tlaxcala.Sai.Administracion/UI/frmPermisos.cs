using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmPermisos : SAIFrmBase
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            SAIBarraEstado.SizingGrip = false;
            this.trvwPermisos.CheckBoxes = true;
            this.LlenarGrid();
            this.LlenarTreeView();
            this.Limpiar();
        }

        private void LlenarGrid()
        {
            DataTable catUsuarios = new DataTable("CatUsuarios");
            try
            {
                //Esta columna no se mostrara
                catUsuarios.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                catUsuarios.Columns.Add(new DataColumn("NombreUsuario", Type.GetType("System.String")));
                catUsuarios.Columns.Add(new DataColumn("NombrePropio", Type.GetType("System.String")));
                catUsuarios.Columns.Add(new DataColumn("Desp", Type.GetType("System.Boolean")));
                //Columna para mostarse "SI" o "NO"
                catUsuarios.Columns.Add(new DataColumn("Despachador", Type.GetType("System.String")));

                Entidades.UsuarioList lstUsuarios = Mappers.UsuarioMapper.Instance().GetAll();

                //Se llena el datatable por cada entidad Usuario
                foreach (Entidades.Usuario usr in lstUsuarios)
                {
                    object[] usuario = new object[] { usr.Clave, usr.NombreUsuario, usr.NombrePropio,
                        usr.Despachador.Value, usr.Despachador.Value?"SI":"NO"};
                    catUsuarios.Rows.Add(usuario);
                }

                this.gvUsuarios.DataSource = catUsuarios; // Mappers.UsuarioMapper.Instance().GetAll();
                //se ocultan columnas al usuario
                this.gvUsuarios.Columns["Clave"].Visible = false;
                this.gvUsuarios.Columns["Desp"].Visible = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administracion de Incidencias"); }
            finally { catUsuarios = null; }
        }

        private void gvUsuarios_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Deselecciona algun registro seleccionado del GridView
        /// </summary>
        private void Limpiar()
        {
            foreach (TreeNode nodo in this.trvwPermisos.Nodes)
            {
                nodo.Checked = false;
            }
        }

        /// <summary>
        /// Se activa cada que seleccionan un registro o se pulsa sobre alguna celda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            //se limpia el TreeView
            this.Limpiar();
            try 
            {
                //se obtiene el registro seleccionado
                int selectedRow = this.gvUsuarios.CurrentCellAddress.Y;
                if (selectedRow > -1)//si hay registro seleccionado?
                {
                    int clave = Convert.ToInt32(this.gvUsuarios.Rows[selectedRow].Cells["Clave"].Value);
                    this.CargarPermisos(clave);
                    this.lblDatos.Text = Convert.ToString(this.gvUsuarios.Rows[selectedRow].Cells["NombrePropio"].Value);
                }
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        private void LlenarTreeView() //int claveUsr)
        {
            try
            {
                Objetos.SistemaObjectList lstSistemas = Mappers.SistemaMapper.Instance().GetAll();
                Entidades.SubmoduloList lstSubModulos = Mappers.SubmoduloMapper.Instance().GetAll();
                Objetos.PermisoObjectList lstPermisos = Mappers.PermisoMapper.Instance().GetAll();

                /*DataTable dtPermisos = new DataTable("Permisos");
                dtPermisos.Columns.Add(new DataColumn("SubModulo_Clave", Type.GetType("System.Int32")));
                dtPermisos.Columns.Add(new DataColumn("SubModulo_Descripcion", Type.GetType("System.String")));
                dtPermisos.Columns.Add(new DataColumn("Permiso_Clave", Type.GetType("System.Int32")));
                dtPermisos.Columns.Add(new DataColumn("Permiso_Descripcion", Type.GetType("System.String")));                
                dtPermisos.Columns.Add(new DataColumn("Sistema_Clave", Type.GetType("System.Int32")));
                dtPermisos.Columns.Add(new DataColumn("Sistema_Descripcion", Type.GetType("System.String")));


                foreach (Objetos.SubmoduloObject submodulo in lstSubModulos)
                {
                    foreach (Objetos.PermisoObject permiso in lstPermisos)
                    {
                        foreach (Objetos.SistemaObject sistema in lstSistemas)
                        {
                            if (sistema.Clave == submodulo.ClaveSistema)
                            {
                                if (sistema.Descripcion != "ADM")
                                {
                                    object[] registro = new object[] { submodulo.Clave, submodulo.Descripcion, permiso.Clave, permiso.Descripcion, sistema.Clave, sistema.Descripcion };
                                    dtPermisos.Rows.Add(registro);
                                }
                            }
                        }
                    }
                }*/

                foreach (Objetos.SistemaObject sistema in lstSistemas)
                {
                    if (sistema.Descripcion != "ADM")
                    {
                        this.trvwPermisos.Nodes.Add(Convert.ToString(sistema.Clave), sistema.Descripcion);
                    }
                }

                foreach (TreeNode sistema in this.trvwPermisos.Nodes)
                {
                    foreach (Entidades.Submodulo submodulo in lstSubModulos)
                    {

                        if (sistema.Name == Convert.ToString(submodulo.ClaveSistema))
                        {
                            sistema.Nodes.Add(Convert.ToString(submodulo.Clave), submodulo.Descripcion);
                        }
                    }
                }
                foreach (TreeNode sistema in this.trvwPermisos.Nodes)
                {
                    foreach (TreeNode submodulo in sistema.Nodes)
                    {
                        foreach (Objetos.PermisoObject permiso in lstPermisos)
                        {
                            submodulo.Nodes.Add(Convert.ToString(permiso.Clave), permiso.Descripcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.SAIEtiquetaEstado.Text = ex.Message;
            }
        }

        private void CargarPermisos(int claveUsuario)
        {
            try
            {
                Objetos.PermisoUsuarioObjectList permisosReal = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(claveUsuario); //.GetAll();
                //bool checaP = false;
                foreach (TreeNode sistemas in this.trvwPermisos.Nodes)
                {
                    foreach (TreeNode submodulo in sistemas.Nodes)
                    {
                        foreach (TreeNode permiso in submodulo.Nodes)
                        {
                            foreach (Objetos.PermisoUsuarioObject permisoReal in permisosReal)
                            {
                                if (permisoReal.ClaveSubmodulo == Convert.ToInt32(submodulo.Name) && permisoReal.ClavePermiso == Convert.ToInt32(permiso.Name))
                                {
                                    permiso.Checked = true;
                                    //checaP = true;
                                }
                            }
                        }
                        /*if (checaP)
                        {
                            submodulo.Checked = true;
                        }
                        checaP = false;*/
                    }
                    
                }
            }
            catch (Exception ex)
            {
                this.SAIEtiquetaEstado.Text = ex.Message;
            }
        }

        private void trvwPermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }

        private void AgregarPermisos(int claveUsr, Objetos.PermisoUsuarioObjectList lstPermisosUsuarioAdd)
        {
            try
            {
                Objetos.PermisoUsuarioObjectList pTieneUsuario = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(claveUsr); //.GetAll();
                if (pTieneUsuario.Count > 0)
                {
                    foreach (Objetos.PermisoUsuarioObject pTUsuario in pTieneUsuario)
                    {
                        foreach (Objetos.PermisoUsuarioObject pAgregar in lstPermisosUsuarioAdd)
                        {
                            if (pAgregar.ClaveUsuario == pTUsuario.ClaveUsuario)
                            {
                                if (pAgregar.ClaveSubmodulo == pTUsuario.ClaveSubmodulo)
                                {
                                    if (pAgregar.ClavePermiso != pTUsuario.ClavePermiso)
                                    {
                                        Objetos.PermisoUsuarioObject pExiste = Mappers.PermisoUsuarioMapper.Instance().GetOne(pAgregar.ClaveUsuario, pAgregar.ClaveSubmodulo, pAgregar.ClavePermiso);
                                        if (pExiste == null)
                                        {
                                            Mappers.PermisoUsuarioMapper.Instance().Insert(pAgregar);
                                        }
                                    }
                                }
                                else
                                {
                                    if (pAgregar.ClavePermiso != pTUsuario.ClavePermiso)
                                    {
                                        Objetos.PermisoUsuarioObject pExiste = Mappers.PermisoUsuarioMapper.Instance().GetOne(pAgregar.ClaveUsuario, pAgregar.ClaveSubmodulo, pAgregar.ClavePermiso);
                                        if (pExiste == null)
                                        {
                                            Mappers.PermisoUsuarioMapper.Instance().Insert(pAgregar);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                if(pTieneUsuario.Count == 0)
                {
                    foreach (Objetos.PermisoUsuarioObject pAgregar in lstPermisosUsuarioAdd)
                    {
                        Mappers.PermisoUsuarioMapper.Instance().Insert(pAgregar);
                    }
                }
            }
            catch (Exception ex)
            {
                this.SAIEtiquetaEstado.Text = ex.Message;
            }
        }

        /// <summary>
        /// Se quitan permisos para un usuario
        /// </summary>
        /// <param name="claveUsr">Clave del usuario seleccionado</param>
        /// <param name="lstPermisosUsuarioDel">Lista de permisos que no se seleccionaron en el TreeView</param>
        private void QuitarPermisos(int claveUsr, Objetos.PermisoUsuarioObjectList lstPermisosUsuarioDel)
        {
            try 
            {
                Objetos.PermisoUsuarioObjectList pTieneUsuario = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(claveUsr);
                if (pTieneUsuario.Count > 0) //si el usuario tiene permisos
                {
                    //Se recorre cada permiso que tiene actualmente el usuario
                    foreach (Objetos.PermisoUsuarioObject pTUsuario in pTieneUsuario)
                    {
                        foreach(Objetos.PermisoUsuarioObject pQuitar in lstPermisosUsuarioDel)
                        {
                            //se compara el permiso por persmiso que tiene el usuario
                            //contra los permisos que no se seleccionaron
                            //solo se quitan aquellos que el usuario deselecciono
                            if (pTUsuario.ClavePermiso == pQuitar.ClavePermiso && pTUsuario.ClaveSubmodulo == pQuitar.ClaveSubmodulo && pQuitar.ClaveUsuario == claveUsr)
                            {
                                Mappers.PermisoUsuarioMapper.Instance().Delete(pQuitar.ClaveUsuario, pQuitar.ClaveSubmodulo, pQuitar.ClavePermiso); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int selectedRow = this.gvUsuarios.CurrentCellAddress.Y;
            if (selectedRow > -1)
            {
                this.RecorrerTreeView(Convert.ToInt32(this.gvUsuarios.Rows[selectedRow].Cells["Clave"].Value));
            }
        }

        private void RecorrerTreeView(int claveUsuario)
        {
            Objetos.PermisoUsuarioObjectList lstPermisosAdd = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObjectList();
            Objetos.PermisoUsuarioObjectList lstPermisosDel = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObjectList();

            try 
            {
                foreach (TreeNode sistemas in this.trvwPermisos.Nodes)
                {
                    foreach (TreeNode submodulo in sistemas.Nodes)
                    {
                        foreach (TreeNode permiso in submodulo.Nodes)
                        {
                            if (permiso.Checked)
                            {
                                Objetos.PermisoUsuarioObject tempPermiso = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObject();
                                tempPermiso.ClavePermiso = Convert.ToInt32(permiso.Name);
                                tempPermiso.ClaveSubmodulo = Convert.ToInt32(submodulo.Name);
                                tempPermiso.ClaveUsuario = claveUsuario;
                                lstPermisosAdd.Add(tempPermiso);
                            }
                            else
                            {
                                Objetos.PermisoUsuarioObject tempPermiso = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObject();
                                tempPermiso.ClavePermiso = Convert.ToInt32(permiso.Name);
                                tempPermiso.ClaveSubmodulo = Convert.ToInt32(submodulo.Name);
                                tempPermiso.ClaveUsuario = claveUsuario;
                                lstPermisosDel.Add(tempPermiso); 
                            }
                        }
                    }
                }

                this.AgregarPermisos(claveUsuario, lstPermisosAdd);
                this.QuitarPermisos(claveUsuario, lstPermisosDel);
                MessageBox.Show("Los permisos se agregaron", "SAI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Limpiar();
                this.CargarPermisos(claveUsuario);
            }
            catch (Exception ex)
            { this.SAIEtiquetaEstado.Text = ex.Message; }
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
