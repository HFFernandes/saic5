using System;
using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIniciarSesion : SAIFrmBase
    {
        private List<string> sistemas;

        public SAIFrmIniciarSesion()
        {
            InitializeComponent();

            sistemas = new List<string>(3);
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SAIProveedorValidacion.ValidarCamposRequeridos(this))
                {
                    var usuario = ReglaUsuarios.AutenticarUsuario(saiTxtUsuario.Text.Trim(), saiTxtContraseña.Text.Trim());
                    if (usuario != null)
                    {
                        //TODO: Clonar la entidad usuario y pasarla al siguiente nivel
                        BSD.C4.Tlaxcala.Sai.Aplicacion.UsuarioPersistencia.intClaveUsuario = usuario.Clave;
                        BSD.C4.Tlaxcala.Sai.Aplicacion.UsuarioPersistencia.strNombreUsuario = usuario.NombreUsuario;

                        //Se genera una identidad y se aplica al hilo del aplicativo
                        var miIdentidad = new GenericIdentity(BSD.C4.Tlaxcala.Sai.Aplicacion.UsuarioPersistencia.strNombreUsuario);
                        //var miPrincipal = new GenericPrincipal(miIdentidad, new[] {"Usuario"});
                        var miPrincipal = new GenericPrincipal(miIdentidad, new[]{"Lectura","Escritura"});
                        Thread.CurrentPrincipal = miPrincipal;

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        throw new SAIExcepcion("Las credenciales de autenticación no son válidas.");
                }
                else
                    throw new SAIExcepcion("Existen campos requeridos vacios.");
            }
            catch (SAIExcepcion)
            {
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void ObtenerSistemas(SAITextBox sender)
        {
            saiCmbSistema.Items.Clear();
            if (sender.Text.Length >= 5)
            {
                sistemas = ReglaUsuarios.ObtenerSistemas(saiTxtUsuario.Text.Trim(), saiTxtContraseña.Text.Trim());
                if (sistemas != null && sistemas.Count >= 1)
                {
                    saiCmbSistema.Items.Clear();
                    foreach (var s in sistemas)
                    {
                        saiCmbSistema.Items.Add(s);
                    }
                    BSD.C4.Tlaxcala.Sai.Aplicacion.UsuarioPersistencia.strSistemas = sistemas.ToArray();

                    saiCmbSistema.Enabled = true;
                    saiCmbSistema.SelectedIndex = 0;
                }
            }
        }

        private void saiTxtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            saiCmbSistema.Enabled = false;
            ObtenerSistemas(saiTxtUsuario);
        }
    }
}