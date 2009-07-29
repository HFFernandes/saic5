
        
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Dal.Incidencias
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

