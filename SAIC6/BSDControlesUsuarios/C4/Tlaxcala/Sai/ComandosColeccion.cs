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
            //TODO: la colección no está completa, deberá completarse
            //retorna la nueva colección definida
            return new List<Comando>
                       {                           
                           new Comando(ID.CMD_NI,"NI","Nuevo incidente",'I',false,true),
                           new Comando(ID.CMD_A,"A","Mostrar incidentes activos.",'A',false,true),
                           new Comando(ID.CMD_P,"P","Mostrar incidencias pendientes.",'P',false,true),
                           new Comando(ID.CMD_AU,"AU","Mostrar unidades disponibles.",'U',false,true)                         
                       };
        }
    }
}