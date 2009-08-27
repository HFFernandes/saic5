//Autor : T.S.U. Angel Martinez Ortiz.
//Fecha : 24 de agosto del 2009
//Empresa : InfinitySoft IT Experts

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
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

                //Inicializamos el SubProceso.
                AsyncWorker = new BackgroundWorker();
                AsyncWorker.WorkerSupportsCancellation = true;
                AsyncWorker.WorkerReportsProgress = true;
                AsyncWorker.DoWork += new DoWorkEventHandler(AsyncWorker_DoWork);

            }
            catch(Exception ex)
            {
                this.FindMessajeEvent("Error al Inicializar listener : "+ex.Message);
            }

            
        }

        

        
        #endregion

        #region VARIABLES

        /// <summary>
        /// IP para comunicarse con el agente de Avaya.
        /// </summary>
        IPAddress ipAgente = IPAddress.Parse(ConfigurationManager.AppSettings["IpAgente"]);

        /// <summary>
        /// Puerto configurado para mandar información desde el agente Avaya
        /// </summary>
        int puertoAgente = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoAgente"]);

        /// <summary>
        /// Nombre y ruta del Agente de Avaya
        /// </summary>
        string aplicacionAgente = ConfigurationManager.AppSettings["AplicacionAgente"];

        /// <summary>
        /// Ip y numero de puerto para el Listener.
        /// </summary>
        IPEndPoint LocalEndPoint; 

        /// <summary>
        /// Cliente de conexiones para TCP.
        /// </summary>
        TcpClient objTcpClient;

        /// <summary>
        /// Para escuchar las conexiones de TCP.
        /// </summary>
        TcpListener objTcpListener;
        
        /// <summary>
        /// Para obtener el NetworkStream que manda el agente de Avaya.
        /// </summary>
        NetworkStream netStream;

        public AsyncCallback pfnCallBack;

        System.Windows.Forms.Timer monitor = new System.Windows.Forms.Timer();

        BackgroundWorker AsyncWorker;

        

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Inicia la aplicación .jar
        /// </summary>
        /// <param name="nombreAplicacion"></param>
        private void Shell(string nombreAplicacion)
        {
            try
            {
                Process process = new Process(); //creamos un proceso
                process.EnableRaisingEvents = true;
                process.StartInfo.FileName = nombreAplicacion;
                process.StartInfo.Arguments = "java -jar";
                process.Start();  //ejecutamos el programa
                
                this.FindMessajeEvent("Inició .jar...");
            }
            catch(Exception ex)
            {
                this.FindMessajeEvent("Error al iniciar .jar :" + ex.Message);
            }
            
        }

        /// <summary>
        /// Inicia el Listener para Caller Id.
        /// </summary>
        public void IniciarCliente()
        {
            try
            {
                //Iniciamos el .jar (Aplicación agente de Avaya)
                Shell(aplicacionAgente);

                //Abrimos la conexión con el Agente Avaya
                objTcpClient = objTcpListener.AcceptTcpClient();

                //Escuchamos el puerto de forma asincrona.
                this.AsyncWorker.RunWorkerAsync();

               
            }
            catch (SocketException se)
            {
                this.FindMessajeEvent(se.Message);
            }
           
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

                while (netStream.CanRead )
                {
                    if(objTcpClient.Available > 0)
                    {
                        byte[] bytes = new byte[objTcpClient.ReceiveBufferSize];

                        netStream.Read(bytes, 0, (int)objTcpClient.ReceiveBufferSize);

                        //Mostramos los datos recibidos.
                        string returndata = Encoding.UTF8.GetString(bytes);

                        //OBtenemos el mensaje del Agente
                        if (returndata.Contains("@"))
                        {
                            string datosAgente = returndata.Split("@".ToCharArray())[1];
                            datosAgente = datosAgente.Substring(0, datosAgente.IndexOf('%'));
                            this.FindMessajeEvent(string.Format("En extensión :{0}", datosAgente));
                        }
                        //Obtenemos el No de telefono de la llamada entrante.
                        if (returndata.Contains("&"))
                        {
                            string datosLlamada = returndata.Split("&".ToCharArray())[1];
                            datosLlamada = datosLlamada.Substring(0, datosLlamada.IndexOf('&'));
                            //Mandamos el telefono obtenido
                            this.FindDataEvent(datosLlamada);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.FindMessajeEvent("Error al obtener datos : " + ex.Message);

            }

        }


        /// <summary>
        /// Envia el mensaje para cerrar el Agente de Avaya.
        /// </summary>
        public void DetenerCliente()
        {
            try
            {
                //Detebemos el monitor asincrono.
                this.AsyncWorker.CancelAsync();

                //Mandamos el comando que interpreta el .jar para detenerse.
                string responseString = "Exit%";
                Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
                netStream.Write(sendBytes, 0, sendBytes.Length);
                

                this.FindMessajeEvent("Se envió deneter agente");
                
                
            }
            catch(Exception ex)
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

        /// <summary>
        /// Se dispara cuando el Listener encuentra un dato.
        /// </summary>
        public event EventHandler<FindDataEventArgs> ListenerFindDataEvent;

        public void FindDataEvent(string val)
        {
            EventHandler<FindDataEventArgs> temp = ListenerFindDataEvent;
            if (temp != null)
                temp(this, new FindDataEventArgs(val));
        }

        /// <summary>
        /// Se dispara cuando el Listener manda un mensaje.
        /// </summary>
        public event EventHandler<FindMessageEventArgs> ListenerMessageDataEvent;

        public void FindMessajeEvent(string msg)
        {
            EventHandler<FindMessageEventArgs> temp = ListenerMessageDataEvent;
            if (temp != null)
                temp(this, new FindMessageEventArgs(msg));
        }

        void AsyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.BuscarDatos();
        }
        

        #endregion

    }

    public class FindDataEventArgs : EventArgs
    {
        private string datos;

        public FindDataEventArgs(string datosTelefono)
        {
            datos = datosTelefono;
        }


        public string Datos
        {
            get { return datos; }
            set { datos = value; }
        }
    }

    public class FindMessageEventArgs : EventArgs
    {
        private string mensaje;

        public FindMessageEventArgs(string msg)
        {
            mensaje = msg;
        }


        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
    }

  

}
