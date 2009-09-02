//Modificó : T.S.U. Angel Martinez Ortiz
//Fecha : 25 de agosto del 2009
//Cambios : Se agregó el monitor para el Agente de Avaya.
//          Se organizó el código fuente
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.NetEnterpriseServers;
using XtremeCommandBars;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.CallListener;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmComandos : Form
    {
        private SAIFrmUnidades unidadesCorporaciones;
        private SAIFrmIncidenciasActivas iactivas066;
        private SAIFrmIncidenciasActivas089 iactivas089;
        private SAIFrmIncidenciasPendientes ipendientes066;
        private SAIFrmIncidenciasPendientes089 ipendientes089;
        private SAIFrmEstadoUnidades asignacionUnidades;
        private SAIFrmAgendaTelefonica agendaTelefonica;
        private SAIFrmBuscadorIncidencias buscadorDir;
        private SAIFrmBuscadorIncidencias buscadorTel;
        private SAIFrmBuscadorIncidencias buscadorLig;

        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SAIFrmComandos()
        {
            var iniciarSesion = new SAIFrmIniciarSesion();
            var dialogResult = iniciarSesion.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                InitializeComponent();
                //Aplicacion.frmComandos = this;

                SAIBarraComandos.DeleteAll(); //Se limpia la barra de comandos por si existiera alguno
                SAIBarraComandos.EnableCustomization(true);

                //Se crean los eventos de reacción para la personalización de los comandos y la funcionalidad
                //en su ejecución
                SAIBarraComandos.Customization += SAIBarraComandos_Customization;
                SAIBarraComandos.Execute += SAIBarraComandos_Execute;
                SAIBarraComandos.UpdateEvent += SAIBarraComandos_UpdateEvent;
                SAIBarraComandos.GlobalSettings.ResourceFile = Environment.CurrentDirectory +
                                                               "\\SuitePro.ResourceES.xml";
                SAIBarraComandos.KeyBindings.AllowDoubleKeyShortcuts = true;
                SAIBarraComandos.Icons.AddIcons(imgAdministrador.Icons);

                //Se establece el ancho,posición superior e izquierda en base a la definición
                //de la pantalla primaria
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Top = (Screen.PrimaryScreen.WorkingArea.Height - Height);
                Left = (Screen.PrimaryScreen.WorkingArea.Right - Width);

                //Se crean los eventos para el monitor de Avaya
                //this.TcpListener.ListenerFindDataEvent += new EventHandler<FindDataEventArgs>(TcpListener_ListenerFindDataEvent);
                //this.TcpListener.ListenerMessageDataEvent += new EventHandler<FindMessageEventArgs>(TcpListener_ListenerMessageDataEvent);
            }
        }

        #endregion

        #region VARIABLES

        /// <summary>
        /// Indica si se ha presionado la tecla control
        /// </summary>
        private bool _blnCtrPresionado;

        /// <summary>
        /// Monitor de actividad telefónica Asincrono
        /// </summary>
        private SaiTcpClient TcpListener = new SaiTcpClient();

        public delegate void DelegadoEscribirDato(string dato);

        /// <summary>
        /// Numero de telefono que manda el evento de telefonia.
        /// </summary>
        private string NoTelefono = string.Empty;

        #endregion

        #region MÉTODOS

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


        /// <summary>
        /// Para indicar si se ha presionado la tecla control
        /// </summary>
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.ControlKey | Keys.Control))
        //    {
        //        _blnCtrPresionado = true;
        //    }

        //    return false;
        //}

        /// <summary>
        /// Esta función se manda a llamar desde los demás formularios para mostrar la ventana del switch
        /// </summary>
        //public void MuestraSwitch()
        //{
        //    if (Aplicacion.VentanasIncidencias.Count > 0)
        //    {
        //        var objVentana = new SAIFrmVentana(Aplicacion.VentanasIncidencias, this);
        //        objVentana.Left = 200;
        //        objVentana.Top = 200;
        //        objVentana.Show(this);
        //    }
        //}

        /// <summary>
        /// Inicia el monitor para el Agente de Avaya
        /// </summary>
        private void IniciarMonitorLlamadas()
        {
            TcpListener.IniciarCliente();


        }

        /// <summary>
        /// Detiene el monitor de llamadas para el Agente de Avaya.
        /// </summary>
        private void DetenerMonitorLlamadas()
        {

            TcpListener.DetenerCliente();
        }

        void EscribirMensaje(string mensaje)
        {
            this.tssInfo.Text = mensaje;
        }

        void EscribirDato(string dato)
        {
            this.NoTelefono = dato;
            this.tssInfo.Text = string.Format("Última llamada : {0} ", dato);
        }

        #endregion

        #region EVENTOS

        void SAIBarraComandos_Execute(object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e)
        {
            //TODO: faltan Las consultas del buscador para 089
            try
            {
                switch (Aplicacion.UsuarioPersistencia.strSistemaActual)
                {
                    case "089":
                        switch (e.control.Id)
                        {
                            case ID.CMD_A:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        iactivas089.Dispose();
                                    else
                                    {
                                        iactivas089 = new SAIFrmIncidenciasActivas089();
                                        MostrarEnSegundoMonitorSiEsPosible(iactivas089);
                                    }
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                                break;
                            case ID.CMD_NI:
                                if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value)
                                {
                                    var frmIncidencia089 = new SAIFrm089();
                                    frmIncidencia089.Show();
                                }
                                break;
                            case ID.CMD_P:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        ipendientes089.Dispose();
                                    else
                                    {
                                        ipendientes089 = new SAIFrmIncidenciasPendientes089();
                                        MostrarEnSegundoMonitorSiEsPosible(ipendientes089);
                                    }
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                                break;
                            case ID.CMD_PH:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorDir.Dispose();
                                    else
                                    {
                                        buscadorDir = new SAIFrmBuscadorIncidencias();
                                        buscadorDir.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                                                                                 "ConsultaPH89.xml"));
                                        MostrarEnSegundoMonitorSiEsPosible(buscadorDir);
                                    }
                                }
                                break;
                            case ID.CMD_SLC:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorLig.Dispose();
                                    else
                                    {
                                        buscadorLig = new SAIFrmBuscadorIncidencias();
                                        buscadorLig.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                                                                                 "ConsultaSLC89.xml"));
                                        MostrarEnSegundoMonitorSiEsPosible(buscadorLig);
                                    }
                                }
                                break;
                        }
                        break;
                    case "066":
                        switch (e.control.Id)
                        {
                            case ID.CMD_A:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        iactivas066.Dispose();
                                    else
                                    {
                                        iactivas066 = new SAIFrmIncidenciasActivas();
                                        MostrarEnSegundoMonitorSiEsPosible(iactivas066);
                                    }
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                                break;
                            case ID.CMD_NI:
                                if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value)
                                {
                                    var frmAltaIncidencia = new SAIFrmAltaIncidencia066(string.Empty);
                                    frmAltaIncidencia.Show();
                                }
                                break;
                            case ID.CMD_P:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        ipendientes066.Dispose();
                                    else
                                    {
                                        ipendientes066 = new SAIFrmIncidenciasPendientes();
                                        MostrarEnSegundoMonitorSiEsPosible(ipendientes066);
                                    }
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                                break;
                            case ID.CMD_AU:
                                var corporacion = Aplicacion.UsuarioPersistencia.intCorporacion != null ?
                                CorporacionMapper.Instance().GetOne(Aplicacion.UsuarioPersistencia.intCorporacion.Value) : null;

                                if (corporacion != null && corporacion.UnidadesVirtuales == false)
                                {
                                    if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                    {
                                        if (e.control.Checked)
                                            asignacionUnidades.Dispose();
                                        else
                                        {
                                            asignacionUnidades = new SAIFrmEstadoUnidades();
                                            MostrarEnSegundoMonitorSiEsPosible(asignacionUnidades);
                                        }
                                    }
                                    else
                                        throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);
                                }
                                else
                                    throw new SAIExcepcion("La corporación a la cual pertenece no está configurada para manejar unidades fisicas, solo virtuales.");
                                break;
                            case ID.CMD_U:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        unidadesCorporaciones.Dispose();
                                    else
                                    {
                                        unidadesCorporaciones = new SAIFrmUnidades();
                                        unidadesCorporaciones.Show();
                                    }
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS);

                                break;
                            case ID.CMD_PH:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorDir.Dispose();
                                    else
                                    {
                                        buscadorDir = new SAIFrmBuscadorIncidencias();
                                        buscadorDir.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                                                                                 "ConsultaPH.xml"));
                                        MostrarEnSegundoMonitorSiEsPosible(buscadorDir);
                                    }
                                }
                                break;
                            case ID.CMD_RPH:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorTel.Dispose();
                                    else
                                    {
                                        buscadorTel = new SAIFrmBuscadorIncidencias();
                                        buscadorTel.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                                                                                 "ConsultaRPH.xml"));
                                        MostrarEnSegundoMonitorSiEsPosible(buscadorTel);
                                    }
                                }
                                break;
                            case ID.CMD_SLC:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorLig.Dispose();
                                    else
                                    {
                                        buscadorLig = new SAIFrmBuscadorIncidencias();
                                        buscadorLig.CargarConsulta(string.Format("{0}\\{1}", Environment.CurrentDirectory,
                                                                                 "ConsultaSLC.xml"));
                                        MostrarEnSegundoMonitorSiEsPosible(buscadorLig);
                                    }
                                }
                                break;
                        }
                        break;
                }

                switch (e.control.Id)
                {
                    case ID.CMD_CAN:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_HI:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_SIF:
                        throw new SAIExcepcion("Funcionalidad no implementada.");
                        break;
                    case ID.CMD_TEL:
                        if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                        {
                            if (e.control.Checked)
                                agendaTelefonica.Dispose();
                            else
                            {
                                agendaTelefonica = new SAIFrmAgendaTelefonica();
                                MostrarEnSegundoMonitorSiEsPosible(agendaTelefonica);
                            }
                        }
                        break;
                }
            }
            catch (SAIExcepcion)
            {
            }
        }

        void SAIBarraComandos_UpdateEvent(object sender, AxXtremeCommandBars._DCommandBarsEvents_UpdateEvent e)
        {
            switch (Aplicacion.UsuarioPersistencia.strSistemaActual)
            {
                case "089":
                    switch (e.control.Id)
                    {
                        case ID.CMD_A:
                            e.control.Checked = iactivas089.Created;
                            break;
                        case ID.CMD_AU:
                            e.control.Enabled = false;
                            break;
                        case ID.CMD_P:
                            e.control.Checked = ipendientes089.Created;
                            break;
                        case ID.CMD_U:
                            e.control.Enabled = false;
                            break;
                        case ID.CMD_RPH:
                            e.control.Enabled = false;
                            break;
                    }
                    break;
                case "066":
                    switch (e.control.Id)
                    {
                        case ID.CMD_A:
                            e.control.Checked = iactivas066.Created;
                            break;
                        case ID.CMD_AU:
                            e.control.Checked = asignacionUnidades.Created;
                            break;
                        case ID.CMD_P:
                            e.control.Checked = ipendientes066.Created;
                            break;
                        case ID.CMD_U:
                            e.control.Checked = unidadesCorporaciones.Created;
                            break;
                        case ID.CMD_RPH:
                            e.control.Checked = buscadorTel.Created;
                            break;
                    }
                    break;
            }

            switch (e.control.Id)
            {
                case ID.CMD_PH:
                    e.control.Checked = buscadorDir.Created;
                    break;
                case ID.CMD_SIF:
                    break;
                case ID.CMD_SLC:
                    e.control.Checked = buscadorLig.Created;
                    break;
                case ID.CMD_TEL:
                    e.control.Checked = agendaTelefonica.Created;
                    break;
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

        private void SAIFrmComandos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SAIBarraComandos.SaveCommandBars("SAIC4", "Sistema de Administracion de Incidencias", "BarraComandos");
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

                //Iniciamos el monitor del agente de Avaya
                // this.IniciarMonitorLlamadas();

            }
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
                {
                    //Detenemos el monitor de llamadas
                    this.DetenerMonitorLlamadas();
                    //Cerramos la aplicación.
                    Application.Exit();
                }

                else
                {

                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Si se ha presionado control tab, se muestra la ventana de swicheo
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnKeyUp(KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Tab && _blnCtrPresionado)
        //    {
        //        MuestraSwitch();
        //    }
        //    _blnCtrPresionado = false;
        //}

        #region EVENTOS PARA MONITOR DE TCP

        void TcpListener_ListenerMessageDataEvent(object sender, FindMessageEventArgs e)
        {
            this.Invoke(new DelegadoEscribirDato(EscribirMensaje), new object[] { e.Mensaje });
        }

        void TcpListener_ListenerFindDataEvent(object sender, FindDataEventArgs e)
        {
            this.Invoke(new DelegadoEscribirDato(EscribirDato), new object[] { e.Datos });

            var lstTipoIncidencias = new TipoIncidenciaList();
            lstTipoIncidencias = Aplicacion.UsuarioPersistencia.strSistemaActual == "066" ? TipoIncidenciaMapper.Instance().GetBySistema(2) : TipoIncidenciaMapper.Instance().GetBySistema(1);
            if (lstTipoIncidencias.Count == 0)
            {

                throw new SAIExcepcion("No es posible registrar incidencias, no existen tipos de incidencias cargados en el sistema, favor de contactar al administrador", this);

            }

            //Se pregunta qué es el usuario y a qué sistema entró:
            if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value &&
                Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
            {

                //var frmIncidencia066 = new SAIFrmIncidencia066(this.NoTelefono);
                //frmIncidencia066.Show();

            }
            else if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value &&
                Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            {
                //var frmIncidencia089 = new SAIFrmIncidencia089(this.NoTelefono);
                //frmIncidencia089.Show();

            }
        }

        #endregion

        private void Monitor_Tick(object sender, EventArgs e)
        {
            TcpListener.BuscarDatos();
        }

        #endregion


    }
}
