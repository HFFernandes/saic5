using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

//Autor : T.S.U. Angel Martinez Ortiz.
//Fecha : 24 de agosto del 2009
//Empresa : InfinitySoft IT Experts

namespace BSD.C4.Tlaxcala.Sai.CallListener
{
    /// <summary>
    /// Clase que se encarga de escuchar el Caller Id de Avaya
    /// </summary>
    public class Listener
    {

        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Listener()
        {

            this.objTcpListener = new TcpListener(LocalEndPoint);
            this.objTcpListener.Start();
        }

        #endregion

        #region VARIABLES


        /// <summary>
        /// Ip y numero de puerto para el Listener.
        /// </summary>
        IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

        /// <summary>
        /// Cliente de conexiones para TCP.
        /// </summary>
        TcpClient objTcpClient;

        /// <summary>
        /// Para escuchar las conexiones de TCP.
        /// </summary>
        TcpListener objTcpListener;
        
        /// <summary>
        /// Para obtener el NetworkStream que manda el sistema.
        /// </summary>
        NetworkStream netStream;

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
                process.EnableRaisingEvents = false;
                process.StartInfo.FileName = nombreAplicacion;
                process.Start();  //ejecutamos el programa
                this.CallerIdEvent("Inició .jar...");
            }
            catch(Exception ex)
            {
                this.CallerIdEvent("Error al iniciar .jar :"+ex.Message);
            }
            
        }

        /// <summary>
        /// Inicia el Listener para Caller Id.
        /// </summary>
        public void Iniciar()
        {
            //Iniciamos el .jar
            Shell("CTIMedicaMovil.jar");
  
        }

        /// <summary>
        /// Recibe los datos que vienen por TCP.
        /// </summary>
        public void BuscarDatos()
        {
            try
            {
                //Checamos si hay conexiones pendientes.
                if (objTcpListener.Pending())
                {
                    objTcpClient = objTcpListener.AcceptTcpClient();

                    //Checamos si podemos leer.
                    if (netStream.CanRead)
                    {
                        //Obtenemos el NetWorkStream
                        netStream = objTcpClient.GetStream();

                        byte[] bytes = new byte[objTcpClient.ReceiveBufferSize];

                        netStream.Read(bytes, 0, (int)objTcpClient.ReceiveBufferSize);

                        //Mostramos los datos recibidos.
                        string returndata = Encoding.UTF8.GetString(bytes);

                        //Mostramos el valor obtenido.
                        this.CallerIdEvent(returndata);

                    }   
                }
                
            }
            catch(Exception ex)
            {
                this.CallerIdEvent("Error al obtener datos : "+ex.Message);

            }
           
        }

        /// <summary>
        /// Finaliza el Listener para Caller Id.
        /// </summary>
        public void Detener()
        {
            try
            {
                //Mandamos el comando que interpreta el .jar para detenerse.
                string responseString = "Exit%";
                Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
                netStream.Write(sendBytes, 0, sendBytes.Length);
                this.CallerIdEvent("Se envió comando salida...");
            }
            catch(Exception ex)
            {
                this.CallerIdEvent("Error al detener :" + ex.Message);
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
                objTcpClient = new TcpClient();
                objTcpClient.Connect(LocalEndPoint);
                netStream = objTcpClient.GetStream();
                if (netStream.CanWrite)
                {
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(dato);

                    netStream.Write(sendBytes, 0, sendBytes.Length);
                    this.CallerIdEvent("Se enviaron los datos...");
                }
            }
            catch (Exception ex)
            {
                this.CallerIdEvent("Error al enviar : " + ex.Message);
            }
        }

        #endregion

        #region EVENTOS

        public event EventHandler<ListenerEventArgs> ListenerFindEvent;

        public void CallerIdEvent(string val)
        {
            EventHandler<ListenerEventArgs> temp = ListenerFindEvent;
            if (temp != null)
                temp(this, new ListenerEventArgs(val));
        }


        #endregion

    }

    public class ListenerEventArgs : EventArgs
    {
        private string datos;

        public ListenerEventArgs(string datosTelefono)
        {
            datos = datosTelefono;
        }


        public string Datos
        {
            get { return datos; }
            set { datos = value; }
        }
    }


}
