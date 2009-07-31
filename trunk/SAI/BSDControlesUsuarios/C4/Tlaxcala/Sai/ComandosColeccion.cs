using System.Collections.Generic;

namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase estática para definir la colección de comandos
    /// que se deberá presentar en la pantalla principal
    /// </summary>
    internal static class ComandosColeccion
    {
        public static List<Comando> ColeccionComandos()
        {
            //retorna la nueva colección definida
            return new List<Comando>
                       {
                           new Comando(ID.CMD_NI, "NI", "Nueva Incidencia", 'N', false, true),
                           new Comando(ID.CMD_BSC,"BSC","Mostrar incidentes guardados",'B',false,true),
                           new Comando(ID.CMD_CAN,"CAN","Cancelar incidente",'C',false,true),
                           new Comando(ID.CMD_DT,"DT","Dividir incidente",'D',false,true)
                       };
        }
    }
}