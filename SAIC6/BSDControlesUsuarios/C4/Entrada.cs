using System;
using System.Globalization;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using System.Threading;

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
            bool blnMutex;
            using (var mutex = new Mutex(true, "SAICC4", out blnMutex))
            {
                if (blnMutex)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    Application.Run(new SAIFrmComandos());

                    mutex.ReleaseMutex();
                }
                else
                    MessageBox.Show("Ya esta ejecutandose otra instancia del aplicativo.", "SAI", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                try
                {
                    var objetoExcepcion = (Exception)e.ExceptionObject;
                    if (e.IsTerminating)
                    {
                        throw new SAIExcepcion(objetoExcepcion.Message);
                    }
                }
                catch (SAIExcepcion)
                {
                }
            }
        }
    }
}