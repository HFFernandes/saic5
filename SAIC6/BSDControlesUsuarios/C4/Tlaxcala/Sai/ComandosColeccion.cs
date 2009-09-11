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
            //retorna la colección definida
            return new List<Comando>
                       {                           
                           new Comando(ID.CMD_NI,"NI","Nuevo incidente.",'N',false,true),
                           new Comando(ID.CMD_A,"A","Mostrar incidentes activos.",'A',false,true),
                           new Comando(ID.CMD_P,"P","Mostrar incidentes pendientes.",'P',false,true),
                           new Comando(ID.CMD_AU,"AU","Mostrar unidades disponibles.",'D',false,true) ,
                           new Comando(ID.CMD_CAN,"CAN","Cancelar la incidencia activa.",null,false,true),
                           //new Comando(ID.CMD_HI,"HI","Mostrar el historial de un incidente.",'H',false,true),
                           new Comando(ID.CMD_PH,"PH","Historial de incidentes con la misma dirección.",null,false,true),
                           new Comando(ID.CMD_RPH,"RPH","Historial de incidentes con el mismo número telefónico.",null,false,true),
                           //new Comando(ID.CMD_SIF,"SIF","Selección de incidentes por filtros definidos.",null,false,true),
                           new Comando(ID.CMD_SLC,"SLC","Consulta de incidentes ligados.",null,false,true),
                           new Comando(ID.CMD_TEL,"TEL","Mostrar agenda telefónica de las instituciones del estado.",'T',false,true),
                           new Comando(ID.CMD_U,"U","Unidades de las distintas corporaciones.",'U',false,true),
                           new Comando(ID.CMD_M,"M","Muestra el mapa para la georeferenciación del incidente.",'M',false,true)
                       };
        }
    }
}