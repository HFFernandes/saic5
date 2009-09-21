using System;
using Microsoft.NetEnterpriseServers;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Excepciones
{
    /// <summary>
    /// Clase para manejar las excepciones generadas por el aplicativo
    /// </summary>
    public class SAIExcepcion : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">mensaje generado por la excepción</param>
        public SAIExcepcion(string message)
            : base(message)
        {
            var excepcion = new ApplicationException(ID.STR_TITULOERROR, this)
                                {
                                    Source = ID.STR_NOMBREAPLICATIVO
                                };

            var exceptionMessageBox = new ExceptionMessageBox(excepcion)
                                          {
                                              Symbol = ExceptionMessageBoxSymbol.Information,
                                              Beep = true
                                          };

            exceptionMessageBox.Show(null);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">mensaje generado por la excepción</param>
        /// <param name="formulario">formulario al cual pertenece el ExceptionMessageBox</param>
        public SAIExcepcion(string message, Form formulario)
            : base(message)
        {
            var excepcion = new ApplicationException(ID.STR_TITULOERROR, this)
                                {
                                    Source = ID.STR_NOMBREAPLICATIVO
                                };

            var exceptionMessageBox = new ExceptionMessageBox(excepcion)
                                          {
                                              Symbol = ExceptionMessageBoxSymbol.Information,
                                              Beep = true
                                          };

            exceptionMessageBox.Show(formulario);
        }
    }
}