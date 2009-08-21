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

        private void LlenarCorporaciones()
        {
            try
            {
                Entidades.CorporacionList lstCorporaciones = Mappers.CorporacionMapper.Instance().GetAll();
                foreach (Entidades.Corporacion corporaciones in lstCorporaciones)
                {
                    this.ddlCorporaciones.Items.Add(new ComboItem(corporaciones.Clave, corporaciones.Descripcion));
                }
                
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
                /*}
                catch (Cooperator.Framework.Data.Exceptions.InvalidConnectionStringException)
                {
                    throw new SAIExcepcion("No es posible conectarse a la BD, la cadena de conexion es erronea, consute con el Administrador del sistema;");
                }
                catch (Cooperator.Framework.Data.Exceptions.NoRowAffectedException)
                { }*/
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
                        int clave = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);
                        Entidades.Usuario updUsuario = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Usuario(clave);
                        updUsuario.NombrePropio = this.txtNombrePropio.Text;
                        updUsuario.NombreUsuario = this.txtUsuario.Text;
                        updUsuario.Contraseña = this.saiTxtContrasena.Text;
                        updUsuario.Despachador = this.rbDespachador.Checked ? true : false;
                        updUsuario.Activo = this.chkActivado.Checked;
                        Mappers.UsuarioMapper.Instance().Save(updUsuario);

                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se modifico el usuario: " + updUsuario.NombrePropio;
                        bitacora.FechaOperacion = DateTime.Today;
                        bitacora.NombreCatalogo = "Usuario";
                        bitacora.Operacion = "UPDATE";
                        bitacora.ValorActual = this.txtNombrePropio.Text + ", " + this.txtUsuario.Text;
                        bitacora.ValorAnterior = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombreUsuario"].Value);
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];

                        Mappers.BitacoraMapper.Instance().Insert(bitacora);

                        /*Objetos.UsuarioCorporacionObject updUsuarioCorporacion = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects.UsuarioCorporacionObject();
                        updUsuarioCorporacion.ClaveCorporacion = Convert.ToInt32(this.ObtieneValor(this.ddlCorporaciones.SelectedIndex));
                        updUsuarioCorporacion.ClaveUsuario = Mappers.UsuarioMapper.Instance().GetByUsuario(updUsuario.NombreUsuario).Clave;

                        Mappers.UsuarioCorporacionMapper.Instance().Save(updUsuarioCorporacion);*/
                    }
                }
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
                    //int selectedRow = this.gvUsuarios.CurrentCellAddress.Y;
                    if (this.ObtieneIndiceSeleccionado() > -1)
                    {
                        Objetos.UsuarioCorporacionObjectList lstUsuCorp =  Mappers.UsuarioCorporacionMapper.Instance().GetAll();
                        if (lstUsuCorp.Count > 0)
                        {
                            foreach (Objetos.UsuarioCorporacionObject usrCorp in lstUsuCorp)
                            {
                                Mappers.UsuarioCorporacionMapper.Instance().Delete(usrCorp.ClaveUsuario, usrCorp.ClaveCorporacion);
                            }
                        }

                        int clave = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida los campos Obligatorios
                if (SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosUsuario))
                {
                    this.Agregar();
                    this.LlenarGrid();
                    this.Limpiar();
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            /*if (SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosUsuario))
            {*/
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea Eliminar el usuario", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int usrSelected = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);
                Objetos.PermisoUsuarioObjectList lstPermisos = Mappers.PermisoUsuarioMapper.Instance().GetByUsuario(usrSelected);
                if (lstPermisos.Count > 0)
                {
                    if (MessageBox.Show("El usuario tiene permisos asignados, ¿Desea borrar de todas formas?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                        bitacora.Descripcion = "Se elimino el permiso del usuario: " + Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombrePropio"].Value);
                        bitacora.FechaOperacion = DateTime.Today; 
                        bitacora.NombreCatalogo = "Permiso Usuario";
                        bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                        bitacora.Operacion = "DELETE";

                        foreach (Objetos.PermisoUsuarioObject permiso in lstPermisos)
                        {
                            Mappers.PermisoUsuarioMapper.Instance().Delete(permiso.ClaveUsuario, permiso.ClaveSubmodulo, permiso.ClavePermiso, permiso.ClaveSistema);
                            Mappers.BitacoraMapper.Instance().Insert(bitacora);
                        }

                        this.Eliminar();
                        this.LlenarGrid();
                        this.Limpiar();
                    }
                }
                else
                {
                    this.Eliminar();
                    this.LlenarGrid();
                    this.Limpiar();
                }                
            }
            else { this.Limpiar(); }
        }

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
                        Objetos.UsuarioCorporacionObjectList lstUCorp = Mappers.UsuarioCorporacionMapper.Instance().GetByUsuario(Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value));
                        foreach(Objetos.UsuarioCorporacionObject usrCorp in lstUCorp )
                        {
                            corporacion =  usrCorp.ClaveCorporacion;

                        }

                        if (corporacion > 0)
                        {
                            this.SeleccionarComboItem(corporacion);
                        }

                        if (Convert.ToBoolean(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Desp"].Value))
                        {
                            this.rbDespachador.Checked = true;
                            this.rbOperador.Checked = false;
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
                        this.lblUserExist.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }

        private int ObtieneIndiceSeleccionado()
        {
            return this.gvUsuarios.CurrentCellAddress.Y;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private object ObtieneValor(int indice)
        {
            return ((ComboItem)this.ddlCorporaciones.Items[indice]).Valor;
        }

        private string ObtieneDescripcion(int indice)
        {
            return ((ComboItem)this.ddlCorporaciones.Items[indice]).Descripcion;
        }

        private void SeleccionarComboItem(int Value)
        {
            foreach (ComboItem item in this.ddlCorporaciones.Items)
            {
                if (Convert.ToInt32(item.Valor) == Value)
                {
                    this.ddlCorporaciones.SelectedItem = item;
                    break;
                }
                else
                { this.ddlCorporaciones.SelectedIndex = -1; }
            }
        }

        private void rbDespachador_CheckedChanged(object sender, EventArgs e)
        {
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

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Entidades.UsuarioList lstUsuarios = Mappers.UsuarioMapper.Instance().GetAll();
                    foreach(Entidades.Usuario usuario in lstUsuarios)
                    {
                        if (usuario.NombreUsuario == this.txtUsuario.Text)
                        {
                            this.lblUserExist.Text = "El usuario ya existe favor indique otro.";
                            break;
                        }
                        else
                        {
                            this.lblUserExist.Text = string.Empty;
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
