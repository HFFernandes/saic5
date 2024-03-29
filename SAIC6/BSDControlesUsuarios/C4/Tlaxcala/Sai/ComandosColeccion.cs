using System.Collections.Generic;

namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase est�tica para definir la colecci�n de comandos
    /// que se deber� presentar en la pantalla principal
    /// </summary>
    internal static class ComandosColeccion
    {
        public static List<Comando> ColeccionComandos()
        {
            //retorna la colecci�n definida
            return new List<Comando>
                       {
                           new Comando(ID.CMD_NI, "NI", "Nuevo incidente.", 'N', false, true),
                           new Comando(ID.CMD_A, "A", "Mostrar incidentes activos.", 'A', false, true),
                           new Comando(ID.CMD_P, "P", "Mostrar incidentes pendientes.", 'P', false, true),
                           new Comando(ID.CMD_AU, "AU", "Mostrar unidades disponibles.", 'D', false, true),
                           new Comando(ID.CMD_CAN, "CAN", "Cancelar la incidencia activa.", null, false, true),
                           new Comando(ID.CMD_PH, "PH", "Historial de incidentes con la misma direcci�n.", null, false,true),
                           new Comando(ID.CMD_RPH, "RPH", "Historial de incidentes con el mismo n�mero telef�nico.",null, false, true),
                           new Comando(ID.CMD_SLC, "SLC", "Consulta de incidentes ligados.", null, false, true),
                           new Comando(ID.CMD_TEL, "TEL", "Mostrar agenda telef�nica de las instituciones del estado.",'T', false, true),
                           new Comando(ID.CMD_U, "U", "Unidades de las distintas corporaciones.", 'U', false, true),
                           new Comando(ID.CMD_M, "M", "Muestra el mapa para la referenciaci�n geogr�fica del incidente.",'M', false, true)
                       };
        }
    }
}