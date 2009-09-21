using System;
using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using System.Windows.Forms;
using System.Threading;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    ///<summary>
    ///</summary>
    public partial class SAIFrmIniciarSesion : SAIFrmBase
    {
        /// <summary>
        /// Listado que almacenará la colección de sistemas a los cuales tiene acceso el usuario
        /// </summary>
        private List<string> sistemas;

        /// <summary>
        /// Delegado para la ejecución del método LimpiarCombo
        /// </summary>
        public delegate void DelegadoLimpiarCombo();

        /// <summary>
        /// Delegado para la ejecución del método AgregarItem
        /// </summary>
        /// <param name="strItem"></param>
        public delegate void DelegadoAgregarItem(string strItem);

        /// <summary>
        /// Constructor
        /// </summary>
        public SAIFrmIniciarSesion()
        {
            InitializeComponent();

            //Inicializamos la capacidad de la colección a 2 por ser 089,066
            sistemas = new List<string>(2);
        }

        /// <summary>
        /// Método utilizado para limpiar todos los items del combo saiCmbSistema
        /// </summary>
        private void LimpiarCombo()
        {
            saiCmbSistema.Items.Clear();
        }

        /// <summary>
        /// Método para agregar un item a la colección de items del saiCmbSistema
        /// </summary>
        /// <param name="strItem">Elemento enviado por el delegado</param>
        private void AgregarItem(string strItem)
        {
            saiCmbSistema.Enabled = true;
            saiCmbSistema.Items.Add(strItem);
            saiCmbSistema.SelectedIndex = 0;

            saiLogoControl.DetenerAnimacion();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Usamos el proveedore de validación para verificar que todos los controles
                //marcados como requeridos tengan un valor
                if (SAIProveedorValidacion.ValidarCamposRequeridos(this))
                {
                    //Comprobamos las credenciales y deberá regresar almenos un registro, que de ser nulo no existe
                    var usuario = ReglaUsuarios.AutenticarUsuario(saiTxtUsuario.Text.Trim(),
                                                                  saiTxtContraseña.Text.Trim());
                    if (usuario != null)
                    {
                        //Almacenamos las propiedades de la entidad que persistirán durante la ejecución
                        Aplicacion.UsuarioPersistencia.intClaveUsuario = usuario.Clave;
                        Aplicacion.UsuarioPersistencia.strNombreUsuario = usuario.NombreUsuario;
                        Aplicacion.UsuarioPersistencia.blnEsDespachador = usuario.Despachador ?? false;
                            //si es nulo asignamos falso
                        Aplicacion.UsuarioPersistencia.strSistemaActual = saiCmbSistema.SelectedItem.ToString();

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        throw new SAIExcepcion("Las credenciales de autenticación no son válidas.", this);
                }
                else
                    throw new SAIExcepcion("Existen campos requeridos vacios.", this);
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

        private void ObtenerSistemas()
        {
            //Ejecutamos en segundo plano la consulta de los sistemas a los cuales tiene
            //acceso para no trabar la UI mediante la invocación de los delegados, ya que no
            //es posible actualizar un control desde otro hilo al que pertenece la aplicación
            var tr = new Thread(delegate()
                                    {
                                        saiCmbSistema.Invoke(new DelegadoLimpiarCombo(LimpiarCombo));

                                        if (saiTxtUsuario.Text.Length < 5) return;
                                        sistemas =
                                            Aplicacion.removerDuplicados(
                                                ReglaUsuarios.ObtenerSistemas(saiTxtUsuario.Text.Trim(),
                                                                              saiTxtContraseña.Text.Trim()));

                                        if (sistemas.Count < 1) return;
                                        saiCmbSistema.Invoke(new DelegadoLimpiarCombo(LimpiarCombo));
                                        foreach (var s in sistemas)
                                        {
                                            saiCmbSistema.Invoke(new DelegadoAgregarItem(AgregarItem),
                                                                 new object[] {s});
                                        }
                                        Aplicacion.UsuarioPersistencia.strSistemas = sistemas.ToArray();
                                    }) {IsBackground = true};
            tr.Start();
        }

        private void saiTxtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            saiCmbSistema.Enabled = false;
            saiLogoControl.IniciarAnimacion();
            ObtenerSistemas();
        }
    }
}