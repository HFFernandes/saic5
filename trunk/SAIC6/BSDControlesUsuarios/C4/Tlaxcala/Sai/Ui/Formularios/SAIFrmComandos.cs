using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.NetEnterpriseServers;
using XtremeCommandBars;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmComandos : Form
    {
        /// <summary>
        /// Indica si se ha presionado la tecla control
        /// </summary>
        private bool _blnCtrPresionado;

        public SAIFrmComandos()
        {
            var iniciarSesion = new SAIFrmIniciarSesion();
            var dialogResult = iniciarSesion.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                InitializeComponent();
                Aplicacion.frmComandos = this;

                SAIBarraComandos.DeleteAll(); //Se limpia la barra de comandos por si existiera alguno
                SAIBarraComandos.EnableCustomization(true);

                //Se crean los eventos de reacción para la personalización de los comandos y la funcionalidad
                //en su ejecución
                SAIBarraComandos.Customization += SAIBarraComandos_Customization;
                SAIBarraComandos.Execute += SAIBarraComandos_Execute;
                SAIBarraComandos.GlobalSettings.ResourceFile = Environment.CurrentDirectory +
                                                               "\\SuitePro.ResourceES.xml";
                SAIBarraComandos.KeyBindings.AllowDoubleKeyShortcuts = true;
                SAIBarraComandos.Icons.AddIcons(imgAdministrador.Icons);

                //Se establece el ancho,posición superior e izquierda en base a la definición
                //de la pantalla primaria
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Top = (Screen.PrimaryScreen.WorkingArea.Height - Height);
                Left = (Screen.PrimaryScreen.WorkingArea.Right - Width);
            }
        }

        void SAIBarraComandos_Execute(object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e)
        {
            try
            {
                //Switch a partir del identificador del control en el cual
                //se dio click
                switch (e.control.Id)
                {
                    case ID.CMD_A:
                        if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                        {
                            if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_A))
                            {
                                var activas089 = new SAIFrmIncidenciasActivas089();
                                MostrarEnSegundoMonitorSiEsPosible(activas089);
                            }
                            else
                                throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                        }
                        else if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                        {
                            if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_A))
                            {
                                var activas = new SAIFrmIncidenciasActivas();
                                MostrarEnSegundoMonitorSiEsPosible(activas);
                            }
                            else
                                throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                        }
                        break;
                    case ID.CMD_AU:
                        var corporacion =
                            CorporacionMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intCorporacion ?? -1);
                        if (corporacion != null && corporacion.UnidadesVirtuales == false)
                        {
                            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                            {
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_AU))
                                {
                                    var unidades = new SAIFrmEstadoUnidades();
                                    MostrarEnSegundoMonitorSiEsPosible(unidades);
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                            }
                        }
                        else
                            throw new SAIExcepcion("La corporación a la cual pertenece no está configurada para manejar unidades fisicas.");
                        break;
                    case ID.CMD_CAN:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_HI:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_NI:
                        TipoIncidenciaList lstTipoIncidencias = new TipoIncidenciaList();

                        if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                        {
                            lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(2);
                        }
                        else
                        {
                            lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(1);
                        }
                        if (lstTipoIncidencias.Count == 0)
                        {

                            throw new SAIExcepcion("No es posible registrar incidencias, no existen tipos de incidencias cargados en el sistema, favor de contactar al administrador", this);

                        }
                        //Se pregunta qué es el usuario y a qué sistema entró:
                        if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value &&
                            Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                        {

                            //if (Aplicacion.VentanasIncidencias.Count == 0)
                            //{
                            SAIFrmIncidencia066 frmIncidencia066 = new SAIFrmIncidencia066();
                            frmIncidencia066.Show(this);
                            //}

                        }
                        else if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value &&
                            Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                        {

                            SAIFrmIncidencia089 frmIncidencia089 = new SAIFrmIncidencia089();
                            frmIncidencia089.Show(this);

                        }
                        break;
                    case ID.CMD_P:
                        if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
                        {
                            if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_P))
                            {
                                var pendientes = new SAIFrmIncidenciasPendientes089();
                                MostrarEnSegundoMonitorSiEsPosible(pendientes);
                            }
                            else
                                throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                        }
                        else if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                        {
                            if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_P))
                            {
                                var pendientes = new SAIFrmIncidenciasPendientes();
                                MostrarEnSegundoMonitorSiEsPosible(pendientes);
                            }
                            else
                                throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                        }
                        break;
                    case ID.CMD_PH:
                        if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_PH))
                        {
                            var buscadorDir = new SAIFrmBuscadorIncidencias();
                            //if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                            //    buscadorDir.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                            //                                             "ConsultaPH.xml"));
                            MostrarEnSegundoMonitorSiEsPosible(buscadorDir);
                        }
                        break;
                    case ID.CMD_RPH:
                        if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_RPH))
                        {
                            var buscadorTel = new SAIFrmBuscadorIncidencias();
                            //if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                            //    buscadorTel.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                            //                                             "ConsultaRPH.xml"));
                            MostrarEnSegundoMonitorSiEsPosible(buscadorTel);
                        }
                        break;
                    case ID.CMD_S:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_SIF:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_SLC:
                        if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_SLC))
                        {
                            var buscadorLig = new SAIFrmBuscadorIncidencias();
                            //if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                            //    buscadorLig.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                            //                                             "ConsultaSLC.xml"));
                            MostrarEnSegundoMonitorSiEsPosible(buscadorLig);
                        }
                        break;
                    case ID.CMD_TEL:
                        if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_TEL))
                        {
                            var agenda = new SAIFrmAgendaTelefonica();
                            MostrarEnSegundoMonitorSiEsPosible(agenda);
                        }
                        break;
                    case ID.CMD_U:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    default:
                        break;
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        void SAIBarraComandos_Customization(object sender, AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent e)
        {
            var controls = SAIBarraComandos.DesignerControls;
            if (controls.Count == 0)
            {
                var coleccionComandos = ComandosColeccion.ColeccionComandos();
                foreach (var comando in coleccionComandos)
                {
                    //verificar el boton y si el usuario actual tiene permisos
                    if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(comando.Identificador))
                    {
                        AgregarBoton(controls, XTPControlType.xtpControlButton, comando.Identificador, comando.Caption,
                                     comando.IniciaGrupo, comando.Descripcion, comando.EsVisible);
                    }
                }
            }

            e.options.AllowNewToolbars = false;
            e.options.ShowToolbarsPage = false;
            e.options.ShowMenusPage = false;
        }

        /// <summary>
        /// Función sobrecargada para la creación de un botón de comando en la barra de comandos
        /// </summary>
        /// <param name="Controles">Contenedor al cual es perteneciente</param>
        /// <param name="TipoControl">Tipo de control del cual será derivado</param>
        /// <param name="Identificador">Constante que identifica al control de manera única</param>
        /// <param name="Caption">Texto que se mostrará identificando al control</param>
        /// <returns>Instancia generada</returns>
        public CommandBarControl AgregarBoton(CommandBarControls Controles, XTPControlType TipoControl, int Identificador, string Caption)
        {
            return AgregarBoton(Controles, TipoControl, Identificador, Caption, false, "", true);
        }

        /// <summary>
        /// Función sobrecargada para la creación de un botón de comando en la barra de comandos
        /// </summary>
        /// <param name="Controles">Contenedor al cual es perteneciente</param>
        /// <param name="TipoControl">Tipo de control del cual será derivado</param>
        /// <param name="Identificador">Constante que identifica al control de manera única</param>
        /// <param name="Caption">Texto que se mostrará identificando al control</param>
        /// <param name="IniciarGrupo">Propiedad que indica si el control iniciará un grupo y contendrá un separador</param>
        /// <returns>Instancia generada</returns>
        public CommandBarControl AgregarBoton(CommandBarControls Controles, XTPControlType TipoControl, int Identificador, string Caption, bool IniciarGrupo)
        {
            return AgregarBoton(Controles, TipoControl, Identificador, Caption, IniciarGrupo, "", true);
        }

        /// <summary>
        /// Función sobrecargada para la creación de un botón de comando en la barra de comandos
        /// </summary>
        /// <param name="Controles">Contenedor al cual es perteneciente</param>
        /// <param name="TipoControl">Tipo de control del cual será derivado</param>
        /// <param name="Identificador">Constante que identifica al control de manera única</param>
        /// <param name="Caption">Texto que se mostrará identificando al control</param>
        /// <param name="IniciarGrupo">Propiedad que indica si el control iniciará un grupo y contendrá un separador</param>
        /// <param name="Descripcion">Propiedad que describe al usuario la función del comando</param>
        /// <param name="EsVisible">Propiedad que indica si el control definido será o no visible para el usuario</param>
        /// <returns>Instancia generada</returns>
        public CommandBarControl AgregarBoton(CommandBarControls Controles, XTPControlType TipoControl, int Identificador, string Caption, bool IniciarGrupo, string Descripcion, bool EsVisible)
        {
            var controlBarra = Controles.Add(TipoControl, Identificador, Caption, -1, false);
            controlBarra.IconId = Identificador;
            controlBarra.Visible = EsVisible;
            controlBarra.BeginGroup = IniciarGrupo;
            controlBarra.DescriptionText = Descripcion;
            controlBarra.TooltipText = Descripcion;
            controlBarra.Category = "Comandos SAI";
            controlBarra.Style = XTPButtonStyle.xtpButtonAutomatic;
            return controlBarra;
        }

        private void SAIFrmComandos_Load(object sender, EventArgs e)
        {
            //SAIBarraComandos.LoadCommandBars("SAIC4", "Sistema de Administracion de Incidencias", "BarraComandos");
            if (SAIBarraComandos.Count == 0)
            {
                var barra = SAIBarraComandos.Add("Comandos", XTPBarPosition.xtpBarTop);
                barra.SetIconSize(32, 32); //Tamaño predeterminado para el item
                barra.Closeable = false;
                //Indicamos que no es posible cerrar la colección de items en la barra para evitar la lógica requerida
                barra.EnableAnimation = true; //Indicamos que mostraremos efectos de desvanecimiento
                barra.ShowGripper = false;
                //Indicamos que ocultaremos el gripper para evitar que pueda moverse de su ubicación predeterminada

                //Agregamos los comandos predeterminados que manejará el sistema y sus accesos rápidos
                var coleccionComandos = ComandosColeccion.ColeccionComandos();
                foreach (var comando in coleccionComandos)
                {
                    if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(comando.Identificador))
                    {
                        AgregarBoton(barra.Controls, XTPControlType.xtpControlButton, comando.Identificador, comando.Caption,
                                  comando.IniciaGrupo, comando.Descripcion, comando.EsVisible);

                        if (comando.TeclaAccesoRapido != null)
                            SAIBarraComandos.KeyBindings.Add(ID.FCONTROL, comando.TeclaAccesoRapido ?? '0', comando.Identificador);
                    }
                }
            }
        }

        /// <summary>
        /// Método estático para colocar un formulario en un
        /// segundo monitor si y solo si es posible
        /// </summary>
        /// <param name="form">Instancia del formulario a ubicar</param>
        static void MostrarEnSegundoMonitorSiEsPosible(Form form)
        {
            //Obtengo el listado de todas las pantallas activas
            var screens = Screen.AllScreens;

            //Comprueba si son exactamente dos monitores
            if (screens.Length == 2)
            {
                //Creamos un listado donde almacenaremos
                //aquellas pantallas que NO son primarias
                var lstScreens = new List<Screen>();
                foreach (var screen in Screen.AllScreens)
                {
                    if (screen.Primary == false)
                        lstScreens.Add(screen);
                }

                //Ubicamos el formulario en la área de trabajo
                //de la pantalla secundaria
                form.Location = lstScreens[0].WorkingArea.Location;
            }
            else
                form.Location = Screen.PrimaryScreen.WorkingArea.Location;

            //Mostramos el formulario que ya fue ubicado
            form.Show();
        }

        private void SAIFrmComandos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var confirmarSalida = new ExceptionMessageBox("¿Está usted seguro de querer salir del aplicativo?", "Salir",
                                                          ExceptionMessageBoxButtons.YesNo,
                                                          ExceptionMessageBoxSymbol.Question,
                                                          ExceptionMessageBoxDefaultButton.Button2);

                if (DialogResult.Yes == confirmarSalida.Show(this))
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Para indicar si se ha presionado la tecla control
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.ControlKey | Keys.Control))
            {
                _blnCtrPresionado = true;
            }

            return false;
        }

        /// <summary>
        /// Si se ha presionado control tab, se muestra la ventana de swicheo
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && _blnCtrPresionado)
            {
                MuestraSwitch();
            }
            _blnCtrPresionado = false;
        }

        /// <summary>
        /// Esta función se manda a llamar desde los demás formularios para mostrar la ventana del switch
        /// </summary>
        public void MuestraSwitch()
        {
            if (Aplicacion.VentanasIncidencias.Count > 0)
            {
                var objVentana = new SAIFrmVentana(Aplicacion.VentanasIncidencias, this);
                objVentana.Left = 200;
                objVentana.Top = 200;
                objVentana.Show(this);
            }
        }

        private void SAIFrmComandos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SAIBarraComandos.SaveCommandBars("SAIC4", "Sistema de Administracion de Incidencias", "BarraComandos");
        }

    }
}
