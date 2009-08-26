using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace BSD.C4.Tlaxcala.Sai.CallListener
{
    public partial class PruebaListener : Form
    {
        public PruebaListener()
        {
            InitializeComponent();
        }

        IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

        public delegate void DelegadoMostrarDato(string dato);

        Listener myListener = new Listener();
        private void PruebaListener_Load(object sender, EventArgs e)
        {
            myListener.ListenerFindEvent += new EventHandler<ListenerEventArgs>(myListener_ListenerFindEvent);
        }

        void myListener_ListenerFindEvent(object sender, ListenerEventArgs e)
        {
            this.Invoke(new DelegadoMostrarDato(MostrarDato), new object[] { e.Datos });
        }

        void MostrarDato(string dato)
        {
            this.lblInfo.Text = string.Format("Dato encontrado : {0}",dato);
        }
        

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            myListener.Iniciar();
            this.tmrMonitor.Enabled = true;
            this.tmrMonitor.Start();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            myListener.Detener();
            this.tmrMonitor.Stop();
            this.tmrMonitor.Enabled = false;
            
        }

        private void btnEnviarDatos_Click(object sender, EventArgs e)
        {
            myListener.EnviarDatos(this.txtEnviar.Text);
            
        }

        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            myListener.BuscarDatos();
        }
    }
}
