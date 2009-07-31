using System;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Microsoft.NetEnterpriseServers;

namespace BSD.C4
{
    public class Entrada
    {
        /// <summary>
        /// Punto de entrada del aplicativo
        /// indicando Single Thread Apartment
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //TODO: Crear un dominio de aplicación
            //TODO: Implementar exclusión mutua

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            Application.Run(new SAIFrmIniciarSesion());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if(e.ExceptionObject is Exception)
            {
                var objetoExcepcion = (Exception) e.ExceptionObject;
                if(e.IsTerminating)
                {
                    //Mostrar formulario de error con strMensajeError
                    var excepcion=new ApplicationException("Error General",objetoExcepcion)
                                      {
                                          Source = "Sistema de Administración de Incidencias"
                                      };

                    var exceptionMessageBox=new ExceptionMessageBox(excepcion)
                                                {
                                                    HelpLink = "http://www.infinitysoft.com.mx",
                                                    Symbol = ExceptionMessageBoxSymbol.Error,
                                                    Beep = false
                                                };

                    exceptionMessageBox.Show(null);
                }
            }
        }
    }
}