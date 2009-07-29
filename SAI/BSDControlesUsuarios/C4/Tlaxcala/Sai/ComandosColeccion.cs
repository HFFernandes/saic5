using System.Collections.Generic;

namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase estática para definir la colección de comandos
    /// que se deberá presentar en la pantalla principal
    /// </summary>
    static class ComandosColeccion
    {
        public static List<Comando> ColeccionComandos()
        {
            //retorna la nueva colección definida
            return new List<Comando>
                                {
                                    new Comando(ID.CMD_NI, "NI", "Nueva Incidencia", 'N',false,true),
                                    new Comando(ID.CMD_IA,"IA","Incidencias Activas",'A',false,true),
                                    new Comando(ID.CMD_IP,"IP","Incidencias Pendientes",'P',false,true)
                                };
        }
    }
}
