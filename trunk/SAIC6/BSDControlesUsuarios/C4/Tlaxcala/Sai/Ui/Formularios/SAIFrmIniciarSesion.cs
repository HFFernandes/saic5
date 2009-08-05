using System;
using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using System.Windows.Forms;

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
                        Aplicacion.UsuarioPersistencia.intClaveUsuario = usuario.Clave;
                        Aplicacion.UsuarioPersistencia.strNombreUsuario = usuario.NombreUsuario;
                        Aplicacion.UsuarioPersistencia.blnEsDespachador = usuario.Despachador ?? false; //si es nulo asignamos falso
                        Aplicacion.UsuarioPersistencia.strSistemaActual = saiCmbSistema.SelectedItem.ToString();

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
                    Aplicacion.UsuarioPersistencia.strSistemas = sistemas.ToArray();

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