using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.MessageBox;

namespace BSD.C4.Tlaxcala.Sai
{
    public partial class CFrmConfDB : Form
    {
        public CFrmConfDB()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CDats cdat = new CDats();

                cdat.Server = txtServer.Text;
                cdat.User = txtUser.Text;
                cdat.Password = txtPassword.Text;
                cdat.Catalog = txtCatalogo.Text;
                CConn cnn = new CConn();
                if (cnn.TestConn(cdat))                
                    CXML.escribirRegXML(cdat);                                                                   
                else
                    throw new Exception("No fue posible conectarse con la base de datos. Por favor verifique la información proporsionada.");                                     
            }
            catch (Exception ex)
            {
                ex.Source = "";
                ExceptionMessageBox box = new ExceptionMessageBox(new Exception("Error en la aplicación", ex),
                    ExceptionMessageBoxButtons.OK,
                    ExceptionMessageBoxSymbol.Exclamation,
                    ExceptionMessageBoxDefaultButton.Button1);
                box.Caption = "Sistema de Administración de Incidencias.";
            }
        }
        

        private void CFrmConfDB_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtServer_Enter(object sender, EventArgs e)
        {
            txtServer.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void txtCatalogo_Enter(object sender, EventArgs e)
        {
            txtCatalogo.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void txtServer_Leave(object sender, EventArgs e)
        {
            txtServer.BackColor = Color.White;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.White;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }

        private void txtCatalogo_Leave(object sender, EventArgs e)
        {
            txtCatalogo.BackColor = Color.White;
        }

        private void txtServer_Validating(object sender, CancelEventArgs e)
        {           
            validateServer();
        }
        private bool validateServer()
        {
            bool bStatus = true;
            if (txtServer.Text == "")
            {
                eProvider.SetError (txtServer,"Por favor, proporsiona el servidor.");
                bStatus = false;
            }
            else
                eProvider.SetError(txtServer, "");
            return bStatus;
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            validateUser();
        }
        private bool validateUser()
        {
            bool bStatus = true;
            if (txtUser.Text == "")
            {
                eProvider.SetError(txtUser, "Por favor, proporsiona el nombre de usuario.");
                bStatus = false;
            }
            else
                eProvider.SetError(txtUser, "");
            return bStatus;
        }

        
        private bool validatePassword()
        {
            bool bStatus = true;
            if (txtUser.Text == "")
            {
                eProvider.SetError(txtPassword , "Por favor, proporsiona el password.");
                bStatus = false;
            }
            else
                eProvider.SetError(txtPassword, "");
            return bStatus;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            validatePassword();
        }

        private void txtCatalogo_Validating(object sender, CancelEventArgs e)
        {
            validateCatalogo();
        }
        private bool validateCatalogo()
        {
            bool bStatus = true;
            if (txtUser.Text == "")
            {
                eProvider.SetError(txtCatalogo, "Por favor, proporsiona el catálogo.");
                bStatus = false;
            }
            else
                eProvider.SetError(txtCatalogo, "");
            return bStatus;
        }
    }
}
