using System;
using Microsoft.NetEnterpriseServers;

namespace BSD.C4.Tlaxcala.Sai.Excepciones
{
    public class SAIExcepcion : Exception
    {
        public SAIExcepcion(string message)
            : base(message)
        {
            var excepcion = new ApplicationException("Error en la aplicación", this)
            {
                Source = "Sistema de Administración de Incidencias"
            };

            var exceptionMessageBox = new ExceptionMessageBox(excepcion)
            {
                HelpLink = "http://www.infinitysoft.com.mx",
                Symbol = ExceptionMessageBoxSymbol.Information,
                Beep = true
            };

            exceptionMessageBox.Show(null);
        }
    }
}
