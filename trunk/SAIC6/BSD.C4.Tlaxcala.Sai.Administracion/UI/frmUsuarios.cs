using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

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
            SAIBarraEstado.SizingGrip = false;
            SAIBarraEstado.TabIndex = 0;
            this.LlenarGrid();
            this.Limpiar();
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
                //Esta columna no se mostrara
                catUsuarios.Columns.Add(new DataColumn("Clave", Type.GetType("System.Int32")));
                catUsuarios.Columns.Add(new DataColumn("NombreUsuario", Type.GetType("System.String")));
                catUsuarios.Columns.Add(new DataColumn("NombrePropio", Type.GetType("System.String")));
                catUsuarios.Columns.Add(new DataColumn("Activo", Type.GetType("System.Boolean")));
                catUsuarios.Columns.Add(new DataColumn("Contraseña", Type.GetType("System.String")));
                catUsuarios.Columns.Add(new DataColumn("Desp", Type.GetType("System.Boolean")));
                //Columna para mostarse "SI" o "NO"
                catUsuarios.Columns.Add(new DataColumn("Despachador", Type.GetType("System.String")));

                Entidades.UsuarioList lstUsuarios = Mappers.UsuarioMapper.Instance().GetAll();

                //Se llena el datatable
                foreach (Entidades.Usuario usr in lstUsuarios)
                {
                    object[] usuario = new object[] { usr.Clave, usr.NombreUsuario, usr.NombrePropio,
                        usr.Activo, usr.Contraseña, usr.Despachador.Value, usr.Despachador.Value?"SI":"NO"};
                    catUsuarios.Rows.Add(usuario);
                }

                this.gvUsuarios.DataSource = catUsuarios;
                //se ocultan columnas al usuario
                this.gvUsuarios.Columns["Clave"].Visible = false;
                this.gvUsuarios.Columns["Desp"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias");
            }
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
                //Se limpian controles
                this.txtUsuario.Text = "";
                this.txtNombrePropio.Text = "";
                this.txtContrasena.Text = "";
                this.rbOperador.Checked = true;
                this.chkActivado.Checked = false;
                this.txtNombrePropio.Focus();
                //Se ocultan los botones de eliminar y modificar
                this.btnEliminar.Visible = false;
                this.btnModificar.Enabled = false;
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
                Entidades.Usuario newUsuario = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Usuario();
                newUsuario.NombrePropio = this.txtNombrePropio.Text;
                newUsuario.NombreUsuario = this.txtUsuario.Text;
                newUsuario.Contraseña = this.txtContrasena.Text;
                newUsuario.Despachador = this.rbDespachador.Checked ? true : false;
                newUsuario.Activo = this.chkActivado.Checked;
                Mappers.UsuarioMapper.Instance().Insert(newUsuario);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias)"); }
        }

        /// <summary>
        /// Actualiza un Usuario que este seleccionado del DataGrid
        /// </summary>
        private void Modificar()
        {
            try 
            {                
                if (this.ObtieneIndiceSeleccionado() > -1)
                {
                    int clave = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);
                    Entidades.Usuario updUsuario = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Usuario(clave);
                    updUsuario.NombrePropio = this.txtNombrePropio.Text;
                    updUsuario.NombreUsuario = this.txtUsuario.Text;
                    updUsuario.Contraseña = this.txtContrasena.Text;
                    updUsuario.Despachador = this.rbDespachador.Checked ? true : false;
                    updUsuario.Activo = this.chkActivado.Checked;
                    Mappers.UsuarioMapper.Instance().Save(updUsuario);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias)"); }
        }

        /// <summary>
        /// Elimina un Usuario Seleccionado del DataGrid
        /// </summary>
        private void Eliminar()
        {
            try 
            {
                //int selectedRow = this.gvUsuarios.CurrentCellAddress.Y;
                if (this.ObtieneIndiceSeleccionado() > -1)
                {
                    int clave = Convert.ToInt32(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Clave"].Value);
                    Mappers.UsuarioMapper.Instance().Delete(clave);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias)"); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Valida los campos Obligatorios
            if (SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosUsuario))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosUsuario))
            {
                this.Modificar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea Eliminar el usuario", "Sistema de Administracion de Incidencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Eliminar();
                this.LlenarGrid();
                this.Limpiar();
            }
            else { this.Limpiar(); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void gvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtieneIndiceSeleccionado() > -1)
                {
                    //Llena los controles con los datos del Datagrid
                    this.txtNombrePropio.Text = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombrePropio"].Value);
                    this.txtUsuario.Text = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["NombreUsuario"].Value);
                    this.txtContrasena.Text = Convert.ToString(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Contraseña"].Value);
                    this.chkActivado.Checked = Convert.ToBoolean(this.gvUsuarios.Rows[this.ObtieneIndiceSeleccionado()].Cells["Activo"].Value);
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
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Sistema de Administración de Incidencias)"); }
        }

        private int ObtieneIndiceSeleccionado()
        {
            return this.gvUsuarios.CurrentCellAddress.Y;
        }
    }
}
