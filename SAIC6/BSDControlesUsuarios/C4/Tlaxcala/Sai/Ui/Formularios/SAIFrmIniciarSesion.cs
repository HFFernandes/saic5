﻿using System;
using System.Collections.Generic;
using System.Threading;
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
                if (base.SAIProveedorValidacion.ValidarCamposRequeridos(this))
                {
                    var usuario = ReglaUsuarios.AutenticarUsuario(saiTxtUsuario.Text.Trim(), saiTxtContraseña.Text.Trim());
                    if (usuario != null)
                    {
                        DialogResult = DialogResult.OK;
                        base.Close();
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
            base.Close();
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

                    saiCmbSistema.Enabled = true;
                    //cmdAceptar.Enabled = true;
                    saiCmbSistema.SelectedIndex = 0;
                }
            }
        }

        private void saiTxtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            //cmdAceptar.Enabled = false;
            saiCmbSistema.Enabled = false;
            ObtenerSistemas(saiTxtUsuario);
        }

        private void saiTxtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            //cmdAceptar.Enabled = false;
            //saiCmbSistema.Enabled = false;
            //ObtenerSistemas(saiTxtContraseña);
        }
    }
}