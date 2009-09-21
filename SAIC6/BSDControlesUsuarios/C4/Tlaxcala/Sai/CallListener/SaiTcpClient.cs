//Autor : T.S.U. Angel Martinez Ortiz.
//Fecha : 24 de agosto del 2009
//Empresa : InfinitySoft IT Experts

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;

namespace BSD.C4.Tlaxcala.Sai.CallListener
{
    /// <summary>
    /// Clase que se encarga de escuchar el Caller Id de Avaya de forma Asíncrona.
    /// </summary>
    public class SaiTcpClient
    {
        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SaiTcpClient()
        {
            try
            {
                //Configuramos el EndPoint.
                this.LocalEndPoint = new IPEndPoint(ipAgente, puertoAgente);

                this.objTcpListener = new TcpListener(LocalEndPoint);

                //Iniciamos el Listener del TCP
                this.objTcpListener.Start();
            }
            catch
            {
            }
        }

        #endregion

        #region VARIABLES

        #region OBTENIDAS DEL App.Config

        /// <summary>
        /// IP para comunicarse con el agente de Avaya.
        /// </summary>
        private IPAddress ipAgente = IPAddress.Parse(ConfigurationManager.AppSettings["IpAgente"]);

        /// <summary>
        /// Puerto configurado para mandar información desde el agente Avaya
        /// </summary>
        private int puertoAgente = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoAgente"]);

        /// <summary>
        /// Nombre y ruta del Agente de Avaya
        /// </summary>
        private string RutaJava = ConfigurationManager.AppSettings["RutaJava"];

        /// <summary>
        /// Nombre del programa proporcionado por Avaya
        /// </summary>
        private string NombreAgenteAvaya = ConfigurationManager.AppSettings["NombreAgente"];

        #endregion

        /// <summary>
        /// Ip y numero de puerto para el Listener.
        /// </summary>
        private IPEndPoint LocalEndPoint;

        /// <summary>
        /// Cliente de conexiones para TCP.
        /// </summary>
        private TcpClient objTcpClient;

        /// <summary>
        /// Para escuchar las conexiones de TCP.
        /// </summary>
        private TcpListener objTcpListener;

        /// <summary>
        /// Para obtener el NetworkStream que manda el agente de Avaya.
        /// </summary>
        private NetworkStream netStream;

        /// <summary>
        /// BackGroundWorker para iniciar el Agente Java en segundo plano.
        /// </summary>
        private BackgroundWorker bgwIniciador;

        /// <summary>
        /// Hilo para escuchar el puerto TCP constantemente en segundo plano.
        /// </summary>
        private Thread ProcesoMonitor;

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Inicia la aplicación .jar
        /// </summary>
        private void IniciarAgenteAvaya()
        {
            try
            {
                //Configuramos el proceso.
                Process process = new Process();

                process.EnableRaisingEvents = false;

                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.UseShellExecute = false;

                process.StartInfo.WorkingDirectory = Application.StartupPath;

                process.StartInfo.FileName = RutaJava;

                process.StartInfo.Arguments = string.Format("-jar {0}", NombreAgenteAvaya);

                process.Start();

                FindMessajeEvent("Inició agente Avaya correctamente...");
            }
            catch (Exception ex)
            {
                FindMessajeEvent("Error al iniciar agente de Avaya :" + ex.Message);
            }
        }

        /// <summary>
        /// Inicia el sub proceso que inicia el agente de Avaya.
        /// </summary>
        public void IniciarCliente()
        {
            //Instanciamos el sub proceso que arranca el Java
            bgwIniciador = new BackgroundWorker();
            bgwIniciador.DoWork += new DoWorkEventHandler(bgwIniciador_DoWork);
            bgwIniciador.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwIniciador_RunWorkerCompleted);

            this.bgwIniciador.RunWorkerAsync();
        }

        /// <summary>
        /// Recibe los datos que vienen por TCP.
        /// </summary>
        public void BuscarDatos()
        {
            try
            {
                //Obtenemos el NetWorkStream
                netStream = objTcpClient.GetStream();

                while (netStream.CanRead)
                {
                    Thread.Sleep(100);
                    if (objTcpClient.Available > 0)
                    {
                        byte[] bytes = new byte[objTcpClient.ReceiveBufferSize];

                        netStream.Read(bytes, 0, (int) objTcpClient.ReceiveBufferSize);

                        //Mostramos los datos recibidos.
                        string returndata = Encoding.UTF8.GetString(bytes);

                        //OBtenemos el mensaje del Agente
                        if (returndata.Contains("@"))
                        {
                            string datosAgente = returndata.Split("@".ToCharArray())[1];
                            datosAgente = datosAgente.Substring(0, datosAgente.IndexOf('%'));
                            FindMessajeEvent(string.Format("En extensión :{0}", datosAgente));
                        }
                        //Obtenemos el No de telefono de la llamada entrante.
                        if (returndata.Contains("&"))
                        {
                            string datosLlamada = returndata.Split("&".ToCharArray())[1];
                            datosLlamada = datosLlamada.Substring(0, datosLlamada.IndexOf('%'));
                            if (!Aplicacion.LlamadasActuales.Contains(datosLlamada))
                            {
                                //Guardamos la llamada entrante.
                                Aplicacion.LlamadasActuales.Add(datosLlamada);

                                //Mandamos el telefono obtenido
                                FindDataEvent(datosLlamada);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FindMessajeEvent("Error al obtener datos : " + ex.Message);
            }
        }


        /// <summary>
        /// Envia el mensaje para cerrar el Agente de Avaya.
        /// </summary>
        public void DetenerCliente()
        {
            try
            {
                //Detenemos el proceso que monitorea el puerto
                this.ProcesoMonitor.Abort();

                //Mandamos el comando que interpreta el .jar para detenerse.
                string responseString = "Exit%";
                Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
                netStream.Write(sendBytes, 0, sendBytes.Length);

                this.FindMessajeEvent("Se envió deneter agente");
            }
            catch (Exception ex)
            {
                this.FindMessajeEvent("Error al detener :" + ex.Message);
            }
        }

        /// <summary>
        /// Invia datos por medio de TCP a localHost por el puerto 9999
        /// </summary>
        /// <param name="dato">string,Dato a enviar.</param>
        public void EnviarDatos(string dato)
        {
            try
            {
                netStream = objTcpClient.GetStream();
                if (netStream.CanWrite)
                {
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(dato);

                    netStream.Write(sendBytes, 0, sendBytes.Length);
                }
            }
            catch (Exception ex)
            {
                this.FindMessajeEvent("Error al enviar : " + ex.Message);
            }
        }

        #endregion

        #region EVENTOS

        private void bgwIniciador_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Iniciamos el sub-proceso.
            ProcesoMonitor = new Thread(BuscarDatos);
            ProcesoMonitor.IsBackground = true;
            ProcesoMonitor.Priority = ThreadPriority.Lowest;
            ProcesoMonitor.Start();
        }

        private void bgwIniciador_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Iniciamos el .jar (Aplicación agente de Avaya)
                IniciarAgenteAvaya();
                objTcpListener.Start();
                //Aceptamos la conexión entrante.
                objTcpClient = objTcpListener.AcceptTcpClient();
            }
            catch (SocketException se)
            {
                this.FindMessajeEvent(se.Message);
            }
        }

        /// <summary>
        /// Se dispara cuando el Listener encuentra un dato.
        /// </summary>
        public event EventHandler<FindDataEventArgs> ListenerFindDataEvent;

        protected void FindDataEvent(string val)
        {
            EventHandler<FindDataEventArgs> temp = ListenerFindDataEvent;
            if (temp != null)
                temp(this, new FindDataEventArgs(val));
        }

        /// <summary>
        /// Se dispara cuando el Listener manda un mensaje.
        /// </summary>
        public event EventHandler<FindMessageEventArgs> ListenerMessageDataEvent;

        protected void FindMessajeEvent(string msg)
        {
            EventHandler<FindMessageEventArgs> temp = ListenerMessageDataEvent;
            if (temp != null)
                temp(this, new FindMessageEventArgs(msg));
        }

        #endregion
    }

    #region CLASES AUXILIAES PARA MANEJO DE EVENTOS

    ///<summary>
    ///</summary>
    public class FindDataEventArgs : EventArgs
    {
        ///<summary>
        ///</summary>
        ///<param name="datosTelefono"></param>
        public FindDataEventArgs(string datosTelefono)
        {
            Datos = datosTelefono;
        }


        ///<summary>
        ///</summary>
        public string Datos { get; set; }
    }

    ///<summary>
    ///</summary>
    public class FindMessageEventArgs : EventArgs
    {
        ///<summary>
        ///</summary>
        ///<param name="msg"></param>
        public FindMessageEventArgs(string msg)
        {
            Mensaje = msg;
        }


        ///<summary>
        ///</summary>
        public string Mensaje { get; set; }
    }

    #endregion
}