using System;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;

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
            //TODO: Implementar exclusión mutua

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.Run(new SAIFrmComandos());
        }

        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    if (e.ExceptionObject is Exception)
        //    {
        //        var objetoExcepcion = (Exception)e.ExceptionObject;
        //        if (e.IsTerminating)
        //        {
        //            throw new SAIExcepcion(objetoExcepcion.Message);
        //        }
        //    }
        //}
    }
}