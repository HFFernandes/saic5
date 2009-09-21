using System;
using System.Globalization;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using System.Threading;

namespace BSD.C4
{
    ///<summary>
    ///</summary>
    public class Entrada
    {
        /// <summary>
        /// Punto de entrada de la aplicación
        /// indicando Single Thread Apartment
        /// </summary>
        [STAThread]
        public static void Main()
        {
            bool blnMutex;

            //Implementamos exclusión mutua
            using (var mutex = new Mutex(true, "SAICC4", out blnMutex))
            {
                if (blnMutex)
                {
                    //Establecemos la cultura para el hilo actual a español de México
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    //Establecemos el evento de control para aquellas excepciones que no fueron controladas
                    //dentro del dominio de la aplicación
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    Application.Run(new SAIFrmComandos());
                    mutex.ReleaseMutex();
                }
                else
                    MessageBox.Show("Ya esta ejecutandose otra instancia del aplicativo.", "SAI", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Manejador de excepciones que no fueron manejadas dentro del dominio de la aplicación
        /// </summary>
        /// <param name="sender">generador del evento</param>
        /// <param name="e">argumentos del evento</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                try
                {
                    var objetoExcepcion = (Exception) e.ExceptionObject;
                    if (e.IsTerminating)
                    {
                        throw new SAIExcepcion(objetoExcepcion.Message, null);
                    }
                }
                catch (SAIExcepcion)
                {
                }
            }
        }
    }
}