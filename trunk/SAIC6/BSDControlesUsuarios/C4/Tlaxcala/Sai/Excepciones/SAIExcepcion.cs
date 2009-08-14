using System;
using Microsoft.NetEnterpriseServers;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Excepciones
{
    public class SAIExcepcion : Exception
    {
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
