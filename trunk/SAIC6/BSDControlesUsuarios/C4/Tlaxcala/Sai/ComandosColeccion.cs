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
                           new Comando(ID.CMD_NI,"NI","Nuevo incidente",'I',false,true),
                           new Comando(ID.CMD_A,"A","Mostrar incidentes activos.",'A',false,true),
                           new Comando(ID.CMD_P,"P","Mostrar incidencias pendientes.",'P',false,true),
                           new Comando(ID.CMD_AU,"AU","Mostrar unidades disponibles.",'U',false,true) ,
                           new Comando(ID.CMD_BSC,"BSC","Mostrar incidentes guardados",'B',false,true),
                           new Comando(ID.CMD_CAN,"CAN","Cancelar la incidencia activa",null,false,true),
                           new Comando(ID.CMD_DT,"DT","",'D',false,true),
                           new Comando(ID.CMD_FIN,"FIN","",null,false,true),
                           new Comando(ID.CMD_HI,"HI","",'H',false,true),
                           new Comando(ID.CMD_INF,"INF","",'F',false,true),
                           new Comando(ID.CMD_LAC,"LAC","",'L',false,true),
                           new Comando(ID.CMD_MAP,"MAP","",null,false,true),
                           new Comando(ID.CMD_MIA,"MIA","",null,false,true),
                           new Comando(ID.CMD_MIP,"MIP","",null,false,true),
                           new Comando(ID.CMD_MN,"MN","",'M',false,true),
                           new Comando(ID.CMD_MUS,"MUS","",null,false,true),
                           new Comando(ID.CMD_N,"N","",null,false,true),
                           new Comando(ID.CMD_PH,"PH","",null,false,true),
                           new Comando(ID.CMD_RNC,"RNC","",null,false,true),
                           new Comando(ID.CMD_RPH,"RPH","",null,false,true),
                           new Comando(ID.CMD_S,"S","",'S',false,true),
                           new Comando(ID.CMD_SDT,"SDT","",null,false,true),
                           new Comando(ID.CMD_SIF,"SIF","",null,false,true),
                           new Comando(ID.CMD_SLC,"SLC","",null,false,true),
                           new Comando(ID.CMD_SS,"SS","",null,false,true),
                           new Comando(ID.CMD_TEL,"TEL","",'E',false,true),
                           new Comando(ID.CMD_U,"U","",'U',false,true),
                           new Comando(ID.CMD_UA,"UA","",null,false,true),
                           new Comando(ID.CMD_UB,"UB","",null,false,true),
                           new Comando(ID.CMD_V,"V","",null,false,true)
                       };
        }
    }
}