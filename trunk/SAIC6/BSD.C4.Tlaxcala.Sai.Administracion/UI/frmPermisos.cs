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
using BSD.C4.Tlaxcala.Sai.Excepciones;
using System.Configuration;

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
            try
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
                { throw new Exception(ex.Message); }
                finally { catUsuarios = null; }
            }
            catch (SAIExcepcion) { }
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
                nodo.Collapse();
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
            try
            {
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
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void LlenarTreeView() //int claveUsr)
        {
            try
            {
                try
                {
                    Objetos.SistemaObjectList lstSistemas = Mappers.SistemaMapper.Instance().GetAll();
                    Entidades.SubmoduloList lstSubModulos = Mappers.SubmoduloMapper.Instance().GetAll();
                    Objetos.PermisoObjectList lstPermisos = Mappers.PermisoMapper.Instance().GetAll();
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

                            /*if (sistema.Name == Convert.ToString(submodulo.ClaveSistema))
                            {*/
                                sistema.Nodes.Add(Convert.ToString(submodulo.Clave), submodulo.Descripcion);
                            //}
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
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Se cargan los permisos que tiene el usuario y se seleccionan en el treeview
        /// </summary>
        /// <param name="claveUsuario"></param>
        private void CargarPermisos(int claveUsuario)
        {
            bool expander = false;
            try
            {
                try
                {
                    Objetos.PermisoUsuarioObjectList permisosReal = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(claveUsuario); //.GetAll();

                    foreach (Objetos.PermisoUsuarioObject permisoActual in permisosReal)
                    {
                        foreach (TreeNode sistemas in this.trvwPermisos.Nodes)
                        {
                            if (Convert.ToInt32(sistemas.Name) == permisoActual.ClaveSistema)
                            {
                                foreach (TreeNode submodulo in sistemas.Nodes)
                                {
                                    if (Convert.ToInt32(submodulo.Name) == permisoActual.ClaveSubmodulo)
                                    {
                                        foreach (TreeNode permiso in submodulo.Nodes)
                                        {
                                            if (Convert.ToInt32(permiso.Name) == permisoActual.ClavePermiso)
                                            {
                                                permiso.Checked = true;
                                                expander = true;
                                            }
                                        }
                                    }
                                    if (expander)
                                    {
                                        submodulo.Expand();
                                        submodulo.Parent.Expand();
                                        expander = false;
                                    }
                                }                                
                            }
                        }
                    }


                    //----
                    /*foreach (TreeNode sistemas in this.trvwPermisos.Nodes)
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
                                        expander = true;
                                    }
                                }
                            }
                            if (expander)
                            {
                                submodulo.Expand();
                                submodulo.Parent.Expand();
                                expander = false;
                            }
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void trvwPermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode nodo = e.Node;
            bool checado = nodo.Checked;
            //si el nodo tiene hijos, checa o no el los hijos
            if (nodo.Nodes.Count > 0)
            {
                foreach (TreeNode nodoHijo in nodo.Nodes)
                {
                    nodoHijo.Checked = checado;
                }
            }
        }

        /// <summary>
        /// Se agregan los permisos correspondientes
        /// </summary>
        /// <param name="claveUsr">clave del usuario al que se le asignaran los permisos</param>
        /// <param name="lstPermisosUsuarioAdd">Lista de los permisos que se van a agregar</param>
        private void AgregarPermisos(int claveUsr, Objetos.PermisoUsuarioObjectList lstPermisosUsuarioAdd)
        {
            try
            {
                try
                {
                    Objetos.PermisoUsuarioObjectList pTieneUsuario = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(claveUsr); //.GetAll();
                    if (pTieneUsuario.Count > 0)
                    {
                        
                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se agregaron Permisos al usuario: " + this.lblDatos.Text;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "PermisoUsuario";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "INSERT";

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
                                            Objetos.PermisoUsuarioObject pExiste = Mappers.PermisoUsuarioMapper.Instance().GetOne(pAgregar.ClaveUsuario, pAgregar.ClaveSubmodulo, pAgregar.ClavePermiso, pAgregar.ClaveSistema);
                                            if (pExiste == null)
                                            {
                                                string descripcion = "Permiso de " + Mappers.PermisoMapper.Instance().GetOne(pAgregar.ClavePermiso).Descripcion + " para " + Mappers.SubmoduloMapper.Instance().GetOne(pAgregar.ClaveSubmodulo).Descripcion;
                                                Mappers.PermisoUsuarioMapper.Instance().Insert(pAgregar);
                                                bitacora.ValorActual = descripcion;
                                                Mappers.BitacoraMapper.Instance().Insert(bitacora);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (pAgregar.ClavePermiso != pTUsuario.ClavePermiso)
                                        {
                                            Objetos.PermisoUsuarioObject pExiste = Mappers.PermisoUsuarioMapper.Instance().GetOne(pAgregar.ClaveUsuario, pAgregar.ClaveSubmodulo, pAgregar.ClavePermiso, pAgregar.ClaveSistema);
                                            if (pExiste == null)
                                            {
                                                string descripcion = "Permiso de " + Mappers.PermisoMapper.Instance().GetOne(pAgregar.ClavePermiso).Descripcion + " para " + Mappers.SubmoduloMapper.Instance().GetOne(pAgregar.ClaveSubmodulo).Descripcion;
                                                Mappers.PermisoUsuarioMapper.Instance().Insert(pAgregar);
                                                bitacora.ValorActual = descripcion;
                                                Mappers.BitacoraMapper.Instance().Insert(bitacora);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (pTieneUsuario.Count == 0)
                    {
                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se agregaron Permisos al usuario: " + this.lblDatos.Text;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "PermisoUsuario";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "INSERT";

                        foreach (Objetos.PermisoUsuarioObject pAgregar in lstPermisosUsuarioAdd)
                        {
                            string descripcion = "Permiso de " + Mappers.PermisoMapper.Instance().GetOne(pAgregar.ClavePermiso).Descripcion + " para " + Mappers.SubmoduloMapper.Instance().GetOne(pAgregar.ClaveSubmodulo).Descripcion;
                            Mappers.PermisoUsuarioMapper.Instance().Insert(pAgregar);
                            bitacora.ValorActual = descripcion;
                            Mappers.BitacoraMapper.Instance().Insert(bitacora);    
                        }

                        
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
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
                try
                {
                    Objetos.PermisoUsuarioObjectList pTieneUsuario = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(claveUsr);
                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se quitaron permisos para el usuario: " + this.lblDatos.Text;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "PermisoUsuario";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                    bitacora.Operacion = "DELETE";

                    if (pTieneUsuario.Count > 0) //si el usuario tiene permisos
                    {
                        //Se recorre cada permiso que tiene actualmente el usuario
                        foreach (Objetos.PermisoUsuarioObject pTUsuario in pTieneUsuario)
                        {
                            foreach (Objetos.PermisoUsuarioObject pQuitar in lstPermisosUsuarioDel)
                            {
                                //se compara el permiso por persmiso que tiene el usuario
                                //contra los permisos que no se seleccionaron
                                //solo se quitan aquellos que el usuario deselecciono
                                if (pTUsuario.ClavePermiso == pQuitar.ClavePermiso && pTUsuario.ClaveSubmodulo == pQuitar.ClaveSubmodulo && pQuitar.ClaveUsuario == claveUsr && pTUsuario.ClaveSistema == pQuitar.ClaveSistema)
                                {
                                    string descripcion = "Permiso de " + Mappers.PermisoMapper.Instance().GetOne(pQuitar.ClavePermiso).Descripcion + " para " + Mappers.SubmoduloMapper.Instance().GetOne(pQuitar.ClaveSubmodulo).Descripcion;
                                    Mappers.PermisoUsuarioMapper.Instance().Delete(pQuitar.ClaveUsuario, pQuitar.ClaveSubmodulo, pQuitar.ClavePermiso, pQuitar.ClaveSistema);
                                    bitacora.ValorActual = descripcion;
                                    Mappers.BitacoraMapper.Instance().Insert(bitacora);
                                }
                            }
                        }
                    }

                    

                    
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
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
            try
            {
                Objetos.PermisoUsuarioObjectList lstPermisosAdd = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObjectList();
                Objetos.PermisoUsuarioObjectList lstPermisosDel = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObjectList();

                try
                {
                    //Se recorre los nodos del TreeView por cada Sistema
                    foreach (TreeNode sistemas in this.trvwPermisos.Nodes)
                    {
                        foreach (TreeNode submodulo in sistemas.Nodes)
                        {
                            //por cada Submodulo
                            foreach (TreeNode permiso in submodulo.Nodes)
                            {
                                if (permiso.Checked)
                                {
                                    //se agregan los nodos (permisos) checados y se agregan a una lista de objetos tipo PermisoUsuarios
                                    Objetos.PermisoUsuarioObject tempPermiso = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObject();
                                    tempPermiso.ClavePermiso = Convert.ToInt32(permiso.Name);
                                    tempPermiso.ClaveSubmodulo = Convert.ToInt32(submodulo.Name);
                                    tempPermiso.ClaveUsuario = claveUsuario;
                                    tempPermiso.ClaveSistema = Convert.ToInt32(sistemas.Name);
                                    lstPermisosAdd.Add(tempPermiso);
                                }
                                else
                                {
                                    //se agrega los nodos (permisos) que no estan checados para quitarlos de la BD
                                    Objetos.PermisoUsuarioObject tempPermiso = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.PermisoUsuarioObject();
                                    tempPermiso.ClavePermiso = Convert.ToInt32(permiso.Name);
                                    tempPermiso.ClaveSubmodulo = Convert.ToInt32(submodulo.Name);
                                    tempPermiso.ClaveUsuario = claveUsuario;
                                    tempPermiso.ClaveSistema = Convert.ToInt32(sistemas.Name);
                                    lstPermisosDel.Add(tempPermiso);
                                }
                            }
                        }
                    }

                    //Se agregan los permisos checados
                    this.AgregarPermisos(claveUsuario, lstPermisosAdd);
                    //se quitan los permisos no checados de la lista
                    this.QuitarPermisos(claveUsuario, lstPermisosDel);                    
                    this.Limpiar();
                    //se cargan permisos actualizados
                    this.CargarPermisos(claveUsuario);
                    MessageBox.Show("Operacion completada.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
