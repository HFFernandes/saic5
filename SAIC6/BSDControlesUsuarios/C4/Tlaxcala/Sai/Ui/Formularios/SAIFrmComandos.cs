//Modific� : T.S.U. Angel Martinez Ortiz
//Fecha : 25 de agosto del 2009
//Cambios : Se agreg� el monitor para el Agente de Avaya.
//          Se organiz� el c�digo fuente
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.NetEnterpriseServers;
using XtremeCommandBars;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.CallListener;
using BSD.C4.Tlaxcala.Sai.Mapa;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    ///<summary>
    ///</summary>
    public partial class SAIFrmComandos : Form
    {
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
                SAIBarraComandos.DeleteAll(); //Se limpia la barra de comandos por si existiera alguno
                SAIBarraComandos.EnableCustomization(true);

                //Se crean los eventos de reacci�n para la personalizaci�n de los comandos y la funcionalidad
                //en su ejecuci�n
                SAIBarraComandos.Customization += SAIBarraComandos_Customization;
                SAIBarraComandos.Execute += SAIBarraComandos_Execute;
                SAIBarraComandos.UpdateEvent += SAIBarraComandos_UpdateEvent;
                SAIBarraComandos.CustomizationResetToolBar += SAIBarraComandos_CustomizationResetToolBar;
                SAIBarraComandos.GlobalSettings.ResourceFile = Environment.CurrentDirectory +
                                                               "\\SuitePro.ResourceES.xml";
                SAIBarraComandos.KeyBindings.AllowDoubleKeyShortcuts = true;
                SAIBarraComandos.Icons.AddIcons(imgAdministrador.Icons);

                //Se establece el ancho,posici�n superior e izquierda en base a la definici�n
                //de la pantalla primaria
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Top = (Screen.PrimaryScreen.WorkingArea.Height - Height);
                Left = (Screen.PrimaryScreen.WorkingArea.Right - Width);

                //Se crean los eventos para el monitor de Avaya
                TcpListener.ListenerFindDataEvent += TcpListener_ListenerFindDataEvent;
                TcpListener.ListenerMessageDataEvent += TcpListener_ListenerMessageDataEvent;
            }
        }

        #endregion

        #region VARIABLES

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

        /*
                /// <summary>
                /// Indica si se ha presionado la tecla control
                /// </summary>
                private bool _blnCtrPresionado;
        */

        /// <summary>
        /// Monitor de actividad telef�nica Asincrono
        /// </summary>
        private SaiTcpClient TcpListener = new SaiTcpClient();

        ///<summary>
        ///</summary>
        ///<param name="dato"></param>
        public delegate void DelegadoEscribirDato(string dato);

        /// <summary>
        /// Numero de telefono que manda el evento de telefonia.
        /// </summary>
        private string NoTelefono = string.Empty;

        #endregion

        #region M�TODOS

        /// <summary>
        /// Funci�n sobrecargada para la creaci�n de un bot�n de comando en la barra de comandos
        /// </summary>
        /// <param name="Controles">Contenedor al cual es perteneciente</param>
        /// <param name="TipoControl">Tipo de control del cual ser� derivado</param>
        /// <param name="Identificador">Constante que identifica al control de manera �nica</param>
        /// <param name="Caption">Texto que se mostrar� identificando al control</param>
        /// <returns>Instancia generada</returns>
        public CommandBarControl AgregarBoton(CommandBarControls Controles, XTPControlType TipoControl,
                                              int Identificador, string Caption)
        {
            return AgregarBoton(Controles, TipoControl, Identificador, Caption, false, "", true);
        }

        /// <summary>
        /// Funci�n sobrecargada para la creaci�n de un bot�n de comando en la barra de comandos
        /// </summary>
        /// <param name="Controles">Contenedor al cual es perteneciente</param>
        /// <param name="TipoControl">Tipo de control del cual ser� derivado</param>
        /// <param name="Identificador">Constante que identifica al control de manera �nica</param>
        /// <param name="Caption">Texto que se mostrar� identificando al control</param>
        /// <param name="IniciarGrupo">Propiedad que indica si el control iniciar� un grupo y contendr� un separador</param>
        /// <returns>Instancia generada</returns>
        public CommandBarControl AgregarBoton(CommandBarControls Controles, XTPControlType TipoControl,
                                              int Identificador, string Caption, bool IniciarGrupo)
        {
            return AgregarBoton(Controles, TipoControl, Identificador, Caption, IniciarGrupo, "", true);
        }

        /// <summary>
        /// Funci�n sobrecargada para la creaci�n de un bot�n de comando en la barra de comandos
        /// </summary>
        /// <param name="Controles">Contenedor al cual es perteneciente</param>
        /// <param name="TipoControl">Tipo de control del cual ser� derivado</param>
        /// <param name="Identificador">Constante que identifica al control de manera �nica</param>
        /// <param name="Caption">Texto que se mostrar� identificando al control</param>
        /// <param name="IniciarGrupo">Propiedad que indica si el control iniciar� un grupo y contendr� un separador</param>
        /// <param name="Descripcion">Propiedad que describe al usuario la funci�n del comando</param>
        /// <param name="EsVisible">Propiedad que indica si el control definido ser� o no visible para el usuario</param>
        /// <returns>Instancia generada</returns>
        public CommandBarControl AgregarBoton(CommandBarControls Controles, XTPControlType TipoControl,
                                              int Identificador, string Caption, bool IniciarGrupo, string Descripcion,
                                              bool EsVisible)
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
        /// M�todo est�tico para colocar un formulario en un
        /// segundo monitor si y solo si es posible
        /// </summary>
        /// <param name="form">Instancia del formulario a ubicar</param>
        private static void MostrarEnSegundoMonitorSiEsPosible(Form form)
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

                //Ubicamos el formulario en la �rea de trabajo
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
        /// Esta funci�n se manda a llamar desde los dem�s formularios para mostrar la ventana del switch
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

        private void EscribirMensaje(string mensaje)
        {
            tssInfo.Text = mensaje;
        }

        private void EscribirDato(string dato)
        {
            NoTelefono = dato;
            tssInfo.Text = string.Format("�ltima llamada : {0} ", dato);

            //var lstTipoIncidencias = new TipoIncidenciaList();
            var lstTipoIncidencias = Aplicacion.UsuarioPersistencia.strSistemaActual == "066"
                                         ? TipoIncidenciaMapper.Instance().GetBySistema(2)
                                         : TipoIncidenciaMapper.Instance().GetBySistema(1);
            if (lstTipoIncidencias.Count == 0)
            {
                throw new SAIExcepcion(
                    "No es posible registrar incidencias, no existen tipos de incidencias cargados en el sistema, favor de contactar al administrador",
                    this);
            }

            //Se pregunta qu� es el usuario y a qu� sistema entr�:
            if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value &&
                Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
            {
                var frmIncidencia066 = new SAIFrmAltaIncidencia066(NoTelefono);
                frmIncidencia066.Show();
            }
            else if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value &&
                     Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            {
                //Se pasa el n�mero telef�nico solo para determinar la ubicaci�n
                //geogr�fica en caso de que exista y no para datos del denunciante
                var frmIncidencia089 = new SAIFrm089(NoTelefono);
                frmIncidencia089.Show();
            }
        }

        #endregion

        #region EVENTOS

        private void SAIBarraComandos_Execute(object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

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
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS, this);
                                break;
                            case ID.CMD_NI:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeEscribir(e.control.Id))
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
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS, this);
                                break;
                            case ID.CMD_PH:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorDir.Dispose();
                                    else
                                    {
                                        buscadorDir = new SAIFrmBuscadorIncidencias();
                                        buscadorDir.CargarConsulta(string.Format("{0}\\{1}",
                                                                                 Environment.CurrentDirectory,
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
                                        buscadorLig.CargarConsulta(string.Format("{0}\\{1}",
                                                                                 Environment.CurrentDirectory,
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
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS, this);
                                break;
                            case ID.CMD_NI:
                                //if (!Aplicacion.UsuarioPersistencia.blnEsDespachador.Value)
                                //{
                                var frmAltaIncidencia = new SAIFrmAltaIncidencia066(string.Empty);
                                frmAltaIncidencia.Show();
                                //}
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
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS, this);
                                break;
                            case ID.CMD_AU:
                                var corporacion = Aplicacion.UsuarioPersistencia.intCorporacion != null
                                                      ?
                                                          CorporacionMapper.Instance().GetOne(
                                                              Aplicacion.UsuarioPersistencia.intCorporacion.Value)
                                                      : null;

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
                                        throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS, this);
                                }
                                else
                                    throw new SAIExcepcion(ID.STR_CORPORACIONESVIRTUALES, this);
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
                                    throw new SAIExcepcion(ID.STR_SINPRIVILEGIOS, this);

                                break;
                            case ID.CMD_PH:
                                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(e.control.Id))
                                {
                                    if (e.control.Checked)
                                        buscadorDir.Dispose();
                                    else
                                    {
                                        buscadorDir = new SAIFrmBuscadorIncidencias();
                                        buscadorDir.CargarConsulta(string.Format("{0}\\{1}",
                                                                                 Environment.CurrentDirectory,
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
                                        buscadorTel.CargarConsulta(string.Format("{0}\\{1}",
                                                                                 Environment.CurrentDirectory,
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
                                        buscadorLig.CargarConsulta(string.Format("{0}\\{1}",
                                                                                 Environment.CurrentDirectory,
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
                        var confirmarSalida =
                            new ExceptionMessageBox(
                                string.Format("�Desea cancelar el Folio {0}?", Aplicacion.intFolioPorCancelar),
                                "Confirmar Cancelaci�n.",
                                ExceptionMessageBoxButtons.YesNo,
                                ExceptionMessageBoxSymbol.Question,
                                ExceptionMessageBoxDefaultButton.Button2);
                        if (DialogResult.Yes == confirmarSalida.Show(this))
                        {
                            var incidencia = Aplicacion.intFolioPorCancelar != null
                                                 ? IncidenciaMapper.Instance().GetOne(
                                                       Aplicacion.intFolioPorCancelar.Value)
                                                 : null;
                            if (incidencia != null)
                            {
                                incidencia.ClaveEstatus = (int)ESTATUSINCIDENCIAS.CANCELADA;
                                IncidenciaMapper.Instance().Save(incidencia);

                                Aplicacion.frmIncidenciaActiva.Dispose();
                                Aplicacion.frmIncidenciaActiva = null;
                                Aplicacion.intFolioPorCancelar = null;
                            }
                            else
                            {
                                throw new SAIExcepcion("No existe una incidencia activa que se pueda cancelar.", this);
                            }
                        }
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
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SAIBarraComandos_UpdateEvent(object sender, AxXtremeCommandBars._DCommandBarsEvents_UpdateEvent e)
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
                case ID.CMD_CAN:
                    e.control.Enabled = (Aplicacion.intFolioPorCancelar > 0);
                    break;
                case ID.CMD_PH:
                    e.control.Checked = buscadorDir.Created;
                    break;
                //case ID.CMD_SIF:
                //    break;
                case ID.CMD_SLC:
                    e.control.Checked = buscadorLig.Created;
                    break;
                case ID.CMD_TEL:
                    e.control.Checked = agendaTelefonica.Created;
                    break;
            }
        }

        private void SAIBarraComandos_Customization(object sender,
                                                    AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent e)
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
            e.options.ShowMenusPage = false;
        }

        private void SAIBarraComandos_CustomizationResetToolBar(object sender,
                                                                AxXtremeCommandBars.
                                                                    _DCommandBarsEvents_CustomizationResetToolBarEvent e)
        {
            SAIBarraComandos.DeleteAll();
            if (SAIBarraComandos.Count == 0)
            {
                var barra = SAIBarraComandos.Add("Comandos", XTPBarPosition.xtpBarTop);
                barra.SetIconSize(32, 32); //Tama�o predeterminado para el item
                barra.Closeable = false;
                //Indicamos que no es posible cerrar la colecci�n de items en la barra para evitar la l�gica requerida
                barra.EnableAnimation = true; //Indicamos que mostraremos efectos de desvanecimiento
                barra.ShowGripper = false;
                //Indicamos que ocultaremos el gripper para evitar que pueda moverse de su ubicaci�n predeterminada

                //Agregamos los comandos predeterminados que manejar� el sistema y sus accesos r�pidos
                var coleccionComandos = ComandosColeccion.ColeccionComandos();
                foreach (var comando in coleccionComandos)
                {
                    if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(comando.Identificador))
                    {
                        AgregarBoton(barra.Controls, XTPControlType.xtpControlButton, comando.Identificador,
                                     comando.Caption,
                                     comando.IniciaGrupo, comando.Descripcion, comando.EsVisible);

                        if (comando.TeclaAccesoRapido != null)
                            SAIBarraComandos.KeyBindings.Add(ID.FCONTROL, comando.TeclaAccesoRapido ?? '0',
                                                             comando.Identificador);
                    }
                }
            }
        }

        private void SAIFrmComandos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                SAIBarraComandos.SaveCommandBars("SAIC4", "Sistema de Administracion de Incidencias",
                                                 "BarraComandos066");
            else
                SAIBarraComandos.SaveCommandBars("SAIC4", "Sistema de Administracion de Incidencias",
                                                 "BarraComandos089");
        }

        private void SAIFrmComandos_Load(object sender, EventArgs e)
        {
            if (Aplicacion.UsuarioPersistencia.strSistemaActual == "066")
                SAIBarraComandos.LoadCommandBars("SAIC4", "Sistema de Administracion de Incidencias", "BarraComandos066");
            else
                SAIBarraComandos.LoadCommandBars("SAIC4", "Sistema de Administracion de Incidencias", "BarraComandos089");

            if (SAIBarraComandos.Count == 0)
            {
                var barra = SAIBarraComandos.Add("Comandos", XTPBarPosition.xtpBarTop);
                barra.SetIconSize(32, 32); //Tama�o predeterminado para el item
                barra.Closeable = false;
                //Indicamos que no es posible cerrar la colecci�n de items en la barra para evitar la l�gica requerida
                barra.EnableAnimation = true; //Indicamos que mostraremos efectos de desvanecimiento
                barra.ShowGripper = false;
                //Indicamos que ocultaremos el gripper para evitar que pueda moverse de su ubicaci�n predeterminada

                //Agregamos los comandos predeterminados que manejar� el sistema y sus accesos r�pidos
                var coleccionComandos = ComandosColeccion.ColeccionComandos();
                foreach (var comando in coleccionComandos)
                {
                    if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(comando.Identificador))
                    {
                        AgregarBoton(barra.Controls, XTPControlType.xtpControlButton, comando.Identificador,
                                     comando.Caption,
                                     comando.IniciaGrupo, comando.Descripcion, comando.EsVisible);

                        if (comando.TeclaAccesoRapido != null)
                            SAIBarraComandos.KeyBindings.Add(ID.FCONTROL, comando.TeclaAccesoRapido ?? '0',
                                                             comando.Identificador);
                    }
                }
            }

            //Iniciamos el monitor del agente de Avaya
            IniciarMonitorLlamadas();
            Controlador.MuestraMapa(new EstructuraUbicacion());
        }

        private void SAIFrmComandos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var confirmarSalida = new ExceptionMessageBox(ID.STR_CONFIRMARSALIDA, "Salir",
                                                              ExceptionMessageBoxButtons.YesNo,
                                                              ExceptionMessageBoxSymbol.Question,
                                                              ExceptionMessageBoxDefaultButton.Button2);

                if (DialogResult.Yes == confirmarSalida.Show(this))
                {
                    //Detenemos el monitor de llamadas
                    DetenerMonitorLlamadas();

                    //Cerramos la aplicaci�n.
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

        private void TcpListener_ListenerMessageDataEvent(object sender, FindMessageEventArgs e)
        {
            Invoke(new DelegadoEscribirDato(EscribirMensaje), new object[] { e.Mensaje });
        }

        private void TcpListener_ListenerFindDataEvent(object sender, FindDataEventArgs e)
        {
            Invoke(new DelegadoEscribirDato(EscribirDato), new object[] { e.Datos });
        }

        #endregion

        #endregion
    }
}