namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que define los parametros que deberá cumplir la
    /// definición de un nuevo comando
    /// </summary>
    public class Comando
    {
        public int Identificador { get; set; }
        public string Caption { get; set; }
        public string Descripcion { get; set; }
        public char TeclaAccesoRapido { get; set; }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="identificador">Clave interna que define al comando en base a las constantes declaradas en la clase <see cref="ID">ID</see></param>
        /// <param name="caption">Texto para el comando</param>
        /// <param name="descripcion">Descripción tooltip</param>
        /// <param name="teclaaccesorapido">Combinación de tecla de acceso rápido</param>
        public Comando(int identificador, string caption, string descripcion, char teclaaccesorapido)
        {
            this.Identificador = identificador;
            this.Caption = caption;
            this.Descripcion = descripcion;
            this.TeclaAccesoRapido = teclaaccesorapido;
        }
    }
}
