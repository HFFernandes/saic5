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
                           new Comando(ID.CMD_BSC,"BSC","Mostrar incidentes guardados",'B',false,true),
                           new Comando(ID.CMD_CAN,"CAN","Cancelar incidencia activa",'C',false,true),
                           new Comando(ID.CMD_DT,"DT","Dividir el incidente",'D',false,true),
                           new Comando(ID.CMD_FIN,"FIN","Salir del aplicativo",'S',false,true),
                           new Comando(ID.CMD_INF,"INF","Capturar información en ventana",'I',false,true),
                           new Comando(ID.CMD_LAC,"LAC","Ligar incidentes",'L',false,true),
                           new Comando(ID.CMD_MN,"MN","Mostrar notas",'M',false,true),
                           new Comando(ID.CMD_N,"N","Capturar notas",'N',false,true),
                           new Comando(ID.CMD_NI,"NI","Nuevo incidente",'I',false,true),
                           new Comando(ID.CMD_P,"P","Incidentes pendientes",'P',false,true),
                           new Comando(ID.CMD_SDT,"SDT","Seleccionar división de ticket",'S',false,true)
                       };
        }
    }
}