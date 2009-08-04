using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.NetEnterpriseServers;
using XtremeCommandBars;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmComandos : Form
    {
        /// <summary>
        /// Indica si se ha presionado la tecla control
        /// </summary>
        private bool bCtrPresionado;

        /// <summary>
        /// Lista de elementos que tienen la referencia hacia los formularios que se van abriendo
        /// <remarks>Cada ventana Incidencia que se levente tiene que incluirse en esta lista</remarks>
        /// </summary>
        List<SAIWinSwitchItem> Elementos = new List<SAIWinSwitchItem>();

        public SAIFrmComandos()
        {
            var iniciarSesion = new SAIFrmIniciarSesion();
            var dialogResult = iniciarSesion.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                InitializeComponent();

                SAIBarraComandos.DeleteAll(); //Se limpia la barra de comandos por si existiera alguno
                SAIBarraComandos.EnableCustomization(true);

                //Se crean los eventos de reacción para la personalización de los comandos y la funcionalidad
                //en su ejecución
                SAIBarraComandos.Customization += SAIBarraComandos_Customization;
                SAIBarraComandos.Execute += SAIBarraComandos_Execute;
                SAIBarraComandos.GlobalSettings.ResourceFile = Environment.CurrentDirectory +
                                                               "\\SuitePro.ResourceES.xml";
                SAIBarraComandos.KeyBindings.AllowDoubleKeyShortcuts = true;

                //Se establece el ancho,posición superior e izquierda en base a la definición
                //de la pantalla primaria
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Top = (Screen.PrimaryScreen.WorkingArea.Height - Height);
                Left = (Screen.PrimaryScreen.WorkingArea.Right - Width);
            }

        }

        void SAIBarraComandos_Execute(object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e)
        {
            //Switch a partir del identificador del control en el cual
            //se dio click
            switch (e.control.Id)
            {
                case ID.CMD_A:
                    var activas = new SAIFrmIncidenciasActivas();
                    MostrarEnSegundoMonitorSiEsPosible(activas);
                    break;
                case ID.CMD_AU:
                    break;
                case ID.CMD_BSC:
                    break;
                case ID.CMD_CAN:
                    break;
                case ID.CMD_DT:
                    break;
                case ID.CMD_FIN:
                    break;
                case ID.CMD_HI:
                    break;
                case ID.CMD_INF:
                    break;
                case ID.CMD_LAC:
                    break;
                case ID.CMD_MAP:
                    break;
                case ID.CMD_MIA:
                    break;
                case ID.CMD_MIP:
                    break;
                case ID.CMD_MN:
                    break;
                case ID.CMD_MUS:
                    break;
                case ID.CMD_N:
                    break;
                case ID.CMD_NI:
                    SAIFrmIncidencia frmIncidencia = new SAIFrmIncidencia();
                    Elementos.Add(new SAIWinSwitchItem("0000" + Elementos.Count, "Ventana No.", frmIncidencia));
                    frmIncidencia.Show(this);
                    break;
                case ID.CMD_P:
                    var pendientes = new SAIFrmIncidenciasPendientes();
                    MostrarEnSegundoMonitorSiEsPosible(pendientes);
                    break;
                case ID.CMD_PH:
                    break;
                case ID.CMD_RNC:
                    break;
                case ID.CMD_RPH:
                    break;
                case ID.CMD_S:
                    break;
                case ID.CMD_SDT:
                    break;
                case ID.CMD_SIF:
                    break;
                case ID.CMD_SLC:
                    break;
                case ID.CMD_SS:
                    break;
                case ID.CMD_TEL:
                    break;
                case ID.CMD_U:
                    break;
                case ID.CMD_UA:
                    break;
                case ID.CMD_UB:
                    break;
                case ID.CMD_V:
                    break;
                default:
                    break;
            }
        }

        void SAIBarraComandos_Customization(object sender, AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent e)
        {
            //No se mostrará la página correspondiente a menús ya que no existe alguno
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
            controlBarra.Visible = EsVisible;
            controlBarra.BeginGroup = IniciarGrupo;
            //controlBarra.DescriptionText = Descripcion;
            controlBarra.TooltipText = Descripcion;
            return controlBarra;
        }

        private void SAIFrmComandos_Load(object sender, EventArgs e)
        {
            var barra = SAIBarraComandos.Add("Comandos", XTPBarPosition.xtpBarTop);
            barra.SetIconSize(32, 32);  //Tamaño predeterminado para el item
            barra.Closeable = false;    //Indicamos que no es posible cerrar la colección de items en la barra para evitar la lógica requerida
            barra.EnableAnimation = true;   //Indicamos que mostraremos efectos de desvanecimiento
            barra.ShowGripper = false;  //Indicamos que ocultaremos el gripper para evitar que pueda moverse de su ubicación predeterminada

            //Agregamos los comandos predeterminados que manejará el sistema y sus accesos rápidos
            var coleccionComandos = ComandosColeccion.ColeccionComandos();
            foreach (var comando in coleccionComandos)
            {
                AgregarBoton(barra.Controls, XTPControlType.xtpControlButton, comando.Identificador, comando.Caption,
                             comando.IniciaGrupo, comando.Descripcion, comando.EsVisible);

                SAIBarraComandos.KeyBindings.Add(ID.FCONTROL, comando.TeclaAccesoRapido, comando.Identificador);
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
                this.bCtrPresionado = true;
            }

            return false;
        }

        /// <summary>
        /// Si se ha presionado control tab, se muestra la ventana de swicheo
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && this.bCtrPresionado)
            {
                this.MuestraSwitch();
            }
            this.bCtrPresionado = false;
        }


        /// <summary>
        /// Esta función se manda a llamar desde los demás formularios para mostrar la ventana del switch
        /// </summary>
        public void MuestraSwitch()
        {
            if (this.Elementos.Count > 0)
            {
                SAIFrmVentana objVentana = new SAIFrmVentana(Elementos, this);
                objVentana.Left = 200;
                objVentana.Top = 200;
                objVentana.Show(this);
            }
        }

    }
}
