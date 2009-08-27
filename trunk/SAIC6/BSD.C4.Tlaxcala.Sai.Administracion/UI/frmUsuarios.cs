using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using System.Configuration;
using BSD.C4.Tlaxcala.Sai.Administracion.Utilerias;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmUsuarios : SAIFrmBase
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llama el metodo LlenarCorporaciones, LlenarGrid y Limpiar
        /// </summary>
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.tltUsuarios.SetToolTip(this.txtUsuario, "El usuario debe tener un maximo de 10 caracteres.");
            this.tltUsuarios.SetToolTip(this.saiTxtContrasena, "La Contraseña debe tener un maximo de 10 caracteres.");
            
            SAIBarraEstado.SizingGrip = false;
            SAIBarraEstado.TabIndex = 0;            
            this.LlenarCorporaciones();
            this.LlenarGrid();
            this.Limpiar();
        }

        /// <summary>
        /// Se carga el catalogo de corporaciones
        /// </summary>
        private void LlenarCorporaciones()
        {
            try
            {
                //se obtiene catalogo de corporaciones
                Entidades.CorporacionList lstCorporaciones = Mappers.CorporacionMapper.Instance().GetAll();
                foreach (Entidades.Corporacion corporaciones in lstCorporaciones)
                {
                    //se agrega en cada elemento del combo un ComboItem
                    this.ddlCorporaciones.Items.Add(new ComboItem(corporaciones.Clave, corporaciones.Descripcion));
                }
                //se asignan las propiedades display y value members
                this.ddlCorporaciones.DisplayMember = "Descripcion";
                this.ddlCorporaciones.ValueMember = "Clave";
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Llena el Grid de catalogo de usuarios
        /// </summary>
        private void LlenarGrid()
        {
            //Se crea un DataTable con las columnas correspondientes
            DataTable catUsuarios = new DataTable("CatUsuarios");
            try
            {                
                try
                {
                    //Esta columna no se mostrara
                    catUsuarios.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                    catUsuarios.Columns.Add(new DataColumn("NombreUsuario", Type.GetType("System.String")));
                    catUsuarios.Columns.Add(new DataColumn("NombrePropio", Type.GetType("System.String")));
                    catUsuarios.Columns.Add(new DataColumn("Activo", Type.GetType("System.Boolean")));
                    catUsuarios.Columns.Add(new DataColumn("Contrasena", Type.GetType("System.String")));
                    catUsuarios.Columns.Add(new DataColumn("Contraseña", Type.GetType("System.String")));
                    catUsuarios.Columns.Add(new DataColumn("Desp", Type.GetType("System.Boolean")));
                    //Columna para mostarse "SI" o "NO"
                    catUsuarios.Columns.Add(new DataColumn("Despachador", Type.GetType("System.String")));

                    Entidades.UsuarioList lstUsuarios = Mappers.UsuarioMapper.Instance().GetAll();

                    //Se llena el datatable
                    foreach (Entidades.Usuario usr in lstUsuarios)
                    {
                        object[] usuario = new object[] { usr.Clave, usr.NombreUsuario, usr.NombrePropio,
                        usr.Activo,  usr.Contraseña,"*******", usr.Despachador.Value, usr.Despachador.Value?"SI":"NO"};
                        catUsuarios.Rows.Add(usuario);
                    }

                    this.gvUsuarios.DataSource = catUsuarios;
                    //se ocultan columnas al usuario
                    this.gvUsuarios.Columns["Clave"].Visible = false;
                    this.gvUsuarios.Columns["Contrasena"].Visible = false;
                    this.gvUsuarios.Columns["Desp"].Visible = false;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
            finally { catUsuarios = null; }
        }

        /// <summary>
        /// Limpia todos los TextBox del formulario y los combobox deselecciona todo
        /// </summary>
        private void Limpiar()
        {
            try
            {
                //Se deselecciona registro del datagrid
                foreach (DataGridViewRow row in this.gvUsuarios.Rows)
                {
                    row.Selected = false;
                }
                this.lblUserExist.Text = "";
                this.ddlCorporaciones.SelectedIndex = -1;
                //Se limpian controles
                this.txtUsuario.Text = "";
                this.txtNombrePropio.Text = "";
                this.saiTxtContrasena.Text = "";
                this.rbOperador.Checked = true;
                this.chkActivado.Checked = false;
                this.txtNombrePropio.Focus();
                //Se ocultan los botones de eliminar y modificar
                this.btnEliminar.Visible = false;
                this.btnModificar.Enabled = false;
                this.btnAgregar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias)");
            }
        }

        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        private void Agregar()
        {
            try
            {
                /*try
                {*/
                Entidades.Usuario newUsuario = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Usuario();
                newUsuario.NombrePropio = this.txtNombrePropio.Text;
                newUsuario.NombreUsuario = this.txtUsuario.Text;
                newUsuario.Contraseña = this.saiTxtContrasena.Text;
                newUsuario.Despachador = this.rbDespachador.Checked ? true : false;
                newUsuario.Activo = this.chkActivado.Checked;
                Mappers.UsuarioMapper.Instance().Insert(newUsuario);

                Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                bitacora.Descripcion = "Se agrego el usuario: " + newUsuario.NombrePropio;
                bitacora.FechaOperacion = DateTime.Today;
                bitacora.NombreCatalogo = "Usuario";
                bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                bitacora.Operacion = "INSERT";

                Mappers.BitacoraMapper.Instance().Insert(bitacora);

                if (rbDespachador.Checked)
                {
                    if (this.ddlCorporaciones.SelectedIndex > -1)
                    {
                        Objetos.UsuarioCorporacionObject newUsuarioCorporacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.UsuarioCorporacionObject();
                        newUsuarioCorporacion.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporaciones.SelectedIndex));
                        newUsuarioCorporacion.ClaveUsuario = Mappers.UsuarioMapper.Instance().GetByUsuario(newUsuario.NombreUsuario).Clave;

                        Mappers.UsuarioCorporacionMapper.Instance().Insert(newUsuarioCorporacion);
                    }
                    else
                    {
                        throw new SAIExcepcion("Seleccione una corporacion para el despachador.");
                    }
                }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Actualiza un Usuario que este seleccionado del DataGrid
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    if (this.ObtieneIndiceSeleccionado() > -1)
                    {
                        //Obtiene los datos del usuario a modificar
                        int clave = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);
                        Entidades.Usuario updUsuario = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Usuario(clave);
                        updUsuario.NombrePropio = this.txtNombrePropio.Text;
                        updUsuario.NombreUsuario = this.txtUsuario.Text;
                        updUsuario.Contraseña = this.saiTxtContrasena.Text;
                        updUsuario.Despachador = this.rbDespachador.Checked ? true : false;
                        updUsuario.Activo = this.chkActivado.Checked;
                        Mappers.UsuarioMapper.Instance().Save(updUsuario);

                        //Agrega operacion en la bitacora
                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se modifico el usuario: " + updUsuario.NombrePropio;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Usuario";
                        bitacora.Operacion = "UPDATE";
                        bitacora.ValorActual = this.txtNombrePropio.Text + ", " + this.txtUsuario.Text;
                        bitacora.ValorAnterior = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombreUsuario"].Value);
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);
                    }
                }//Esta exepcion se atrapa para que no muestre error alguno (es un bug del cooperator)
                catch (Cooperator.Framework.Data.Exceptions.NoRowAffectedException)
                { return; }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Elimina un Usuario Seleccionado del DataGrid
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    //Si hay usuario seleccionado
                    if (this.ObtieneIndiceSeleccionado() > -1)
                    {
                        //Se obtiene la clave dle usuario que se va eliminar
                        int clave = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);

                        //se crea objeto para la relacion Susuario - Corporacion y se obtiene todas las relaciones
                        Objetos.UsuarioCorporacionObjectList lstUsuCorp =  Mappers.UsuarioCorporacionMapper.Instance().GetByUsuario(clave);
                        //si alguna relacion 
                        if (lstUsuCorp.Count > 0)
                        {
                            foreach (Objetos.UsuarioCorporacionObject usrCorp in lstUsuCorp)
                            {
                                Mappers.UsuarioCorporacionMapper.Instance().Delete(usrCorp.ClaveUsuario, usrCorp.ClaveCorporacion);
                            }
                        }
                        
                        //Se elimina usuario
                        Mappers.UsuarioMapper.Instance().Delete(clave);

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se elimino el usuario: " + Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombrePropio"].Value);
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Usuario";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "DELETE";

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Evento Click del boton agregar que referencia al metodo agregar, llenargrid y limpiar
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida los campos Obligatorios
                if (SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosUsuario))
                {
                    //se agrega un nuevo usuario
                    this.Agregar();
                    //se actualiza grid
                    this.LlenarGrid();
                    //se limpian los datos
                    this.Limpiar();
                }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Evento Click del boton Modificar que referencia alas funciones modificar, llenargrid y limpiar
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
            this.LlenarGrid();
            this.Limpiar();
        }

        /// <summary>
        /// Evento Click del boton Eliminar que verifica si esta relacionado el usuario a eliminar, con una o varias
        /// incidencias y permisos (eliminando solo permisos) y hace referencia a las funciones eliminar, llenargrid 
        /// y limpiar
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int usrSelected = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);

                if (Mappers.IncidenciaMapper.Instance().GetByUsuario(usrSelected).Count > 0)
                {
                    throw new SAIExcepcion("No se puede eliminar el usuario porque tiene insidencias asociadas. *Sugerencia: Puede desactivar el usuario.");
                }
                else
                {
                    //Pregunta si se desea eliminar el usuario
                    if (MessageBox.Show("Desea Eliminar el usuario", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //se obtiene el usuario selelcionado
                        //se obtienen todos los permisos del usuario, en caso de tener
                        Objetos.PermisoUsuarioObjectList lstPermisos = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(usrSelected);
                        //si tiene permisos el usuario
                        if (lstPermisos.Count > 0)
                        {
                            //Se agrega operacion en bitacora
                            Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                            bitacora.Descripcion = "Se elimino el permiso del usuario: " + Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombrePropio"].Value);
                            bitacora.FechaOperacion = DateTime.Today;
                            bitacora.NombreCatalogo = "Permiso Usuario";
                            bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                            bitacora.Operacion = "DELETE";

                            foreach (Objetos.PermisoUsuarioObject permiso in lstPermisos)
                            {
                                //se elimina permiso uno por uno
                                Mappers.PermisoUsuarioMapper.Instance().Delete(permiso.ClaveUsuario, permiso.ClaveSubmodulo, permiso.ClavePermiso, permiso.ClaveSistema);
                                //Se agrega en bitacora la operacion
                                Mappers.BitacoraMapper.Instance().Insert(bitacora);
                            }

                            //se manda a llamar la funcion que elimina el usuario
                            this.Eliminar();
                            //se actualiza el grid
                            this.LlenarGrid();
                            //Se limpia controles en caso de tener datos
                            this.Limpiar();
                        }
                        else
                        {
                            //se manda a llamar la funcion que elimina el usuario
                            this.Eliminar();
                            //se actualiza el grid
                            this.LlenarGrid();
                            //se limpian controles
                            this.Limpiar();
                        }
                    }//se limpian controles
                    else
                    {
                        this.Limpiar();
                    }
                }                
            }
            catch (SAIExcepcion) { }
        }

        /// <summary>
        /// Evento del SelectionChanged que obtiene los datos a modificar de un usuario seleccionado en el grid
        /// verifica si es despachador u operador para seleccionar los datos correspondientes
        /// </summary>        
        private void gvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.ObtieneIndiceSeleccionado() > -1)
                    {
                        //Llena los controles con los datos del Datagrid
                        this.txtNombrePropio.Text = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombrePropio"].Value);
                        this.txtUsuario.Text = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombreUsuario"].Value);
                        this.saiTxtContrasena.Text = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Contrasena"].Value);
                        this.chkActivado.Checked = Convert.ToBoolean(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Activo"].Value);

                        int corporacion = 0;

                        //si es despachador
                        if (Convert.ToBoolean(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Desp"].Value))
                        {
                            //selecciona el radiobuton correspondiente
                            this.rbDespachador.Checked = true;
                            this.rbOperador.Checked = false;
                            //si el usuario tiene relacion con una corporacion
                            Objetos.UsuarioCorporacionObjectList lstUCorp = Mappers.UsuarioCorporacionMapper.Instance().GetByUsuario(Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
                            foreach (Objetos.UsuarioCorporacionObject usrCorp in lstUCorp)
                            {
                                //obtiene la clave de la corporacion asociada
                                corporacion = usrCorp.ClaveCorporacion;
                            }

                            //si tiene corporacion asociada seleccionala en el combobox
                            if (corporacion > 0)
                            {
                                this.SeleccionarComboItem(corporacion);
                            }
                        }
                        else
                        {
                            this.rbOperador.Checked = true;
                            this.rbDespachador.Checked = false;
                        }
                        //Se muestran los botones de Eliminar y Modificar
                        this.btnEliminar.Visible = true;
                        this.btnModificar.Enabled = true;
                        this.btnAgregar.Enabled = false;
                        //Se limpia la etiqueta que indica si el usuario existe o no
                        this.lblUserExist.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        /// <summary>
        /// Obtiene el indice del registro seleccionado del datagrid
        /// </summary>
        /// <returns>Indice</returns>
        private int ObtieneIndiceSeleccionado()
        {
            return this.gvUsuarios.CurrentCellAddress.Y;
        }

        /// <summary>
        /// Cierra la ventana de Usuarios
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cierra el formulario
            this.Close();
        }

        /// <summary>
        /// Llama el metodo Limpiar
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpia controles
            this.Limpiar();
        }

        /// <summary>
        /// Obtiene el Valor(Value) del elemento seleccionado
        /// </summary>
        /// <param name="indice">Indice del elemento seleccionado</param>
        /// <returns>Un objeto con el valor del elemento seleccionado</returns>
        private object ObtieneValor(int indice)
        {
            return ((ComboItem)this.ddlCorporaciones.Items[indice]).Valor;
        }

        /// <summary>
        /// Obtiene la descripcion del elemento seleccionado
        /// </summary>
        /// <param name="indice">Indice del elemento seleccionado</param>
        /// <returns>Objeto con la descripcion del elemento</returns>
        private string ObtieneDescripcion(int indice)
        {
            return ((ComboItem)this.ddlCorporaciones.Items[indice]).Descripcion;
        }

        /// <summary>
        /// Selecciona un elemento dle combobox Corporaciones
        /// </summary>
        /// <param name="Value"></param>
        private void SeleccionarComboItem(int Value)
        {
            //recorre los elementos del combobox
            foreach (ComboItem item in this.ddlCorporaciones.Items)
            {
                //si el valor que se quiere seleccionar es igual al valor del elemento se selecciona
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.ddlCorporaciones.SelectedItem = item;
                    break;
                }
                else //en caso contrario no se selecciona nigun elemento
                { this.ddlCorporaciones.SelectedIndex = -1; }
            }
        }

        /// <summary>
        /// Evento CheckedChanged donde se muestra el catalogo de corporaciones si es un despachador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbDespachador_CheckedChanged(object sender, EventArgs e)
        {
            //Si el usuario nuevo es despachador se muestra las corporaciones, para asignar a ese usuario
            if (this.rbDespachador.Checked)
            {
                this.lblCorporacion.Visible = true;
                this.ddlCorporaciones.Visible = true;
            }
            else 
            {
                this.lblCorporacion.Visible = false;
                this.ddlCorporaciones.Visible = false;
            }
        }

        /// <summary>
        /// Evento TextChanged se valida que el usuario capturado no exista
        /// </summary>
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    //Obtiene una lista de todos los usuario existentes
                    Entidades.UsuarioList lstUsuarios = Mappers.UsuarioMapper.Instance().GetAll();
                    foreach(Entidades.Usuario usuario in lstUsuarios)
                    {
                        //recorre todos los usuarios y si el usuario capturado es igual uno existente
                        if (usuario.NombreUsuario == this.txtUsuario.Text)
                        {
                            //muestra un mensaje de que el usuario existe y deshabilita el boton de agregar
                            this.lblUserExist.Text = "El usuario ya existe favor indique otro.";
                            this.btnAgregar.Enabled = false;
                            break;
                        }
                        else
                        {
                            //limpia la etiqueta de mensaje y habilita el boton para agregar
                            this.lblUserExist.Text = string.Empty;
                            this.btnAgregar.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }
    }
}
