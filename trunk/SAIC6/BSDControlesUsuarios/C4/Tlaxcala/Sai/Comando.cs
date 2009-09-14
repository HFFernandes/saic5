namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que define los parametros que deberá cumplir la
    /// definición de un nuevo comando
    /// </summary>
    public class Comando
    {
        /// <summary>
        /// Constructor de la clase con parametros para la nueva definición
        /// </summary>
        /// <param name="identificador">Clave interna que define al comando en base a las constantes declaradas en la clase <see cref="ID">ID</see></param>
        /// <param name="caption">Texto para el comando</param>
        /// <param name="descripcion">Descripción tooltip</param>
        /// <param name="teclaaccesorapido">Combinación de tecla de acceso rápido</param>
        /// <param name="iniciagrupo">Propiedad que indica si el comando definido iniciará un grupo</param>
        /// <param name="esvisible">Propiedad que indica si el comando será o no visible</param>
        public Comando(int identificador, string caption, string descripcion, char? teclaaccesorapido, bool iniciagrupo,
                       bool esvisible)
        {
            Identificador = identificador;
            Caption = caption;
            Descripcion = descripcion;
            TeclaAccesoRapido = teclaaccesorapido;
            IniciaGrupo = iniciagrupo;
            EsVisible = esvisible;
        }

        #region Campos

        ///<summary>
        /// Campo identificador de la clave interna
        ///</summary>
        public int Identificador { get; set; }
        ///<summary>
        /// Campo para la definición del texto
        ///</summary>
        public string Caption { get; set; }
        ///<summary>
        /// Campo para la descripción del comando
        ///</summary>
        public string Descripcion { get; set; }
        ///<summary>
        /// Campo para la definición del método abreviado
        ///</summary>
        public char? TeclaAccesoRapido { get; set; }
        ///<summary>
        /// Campo para definir el inicio de un separator
        ///</summary>
        public bool IniciaGrupo { get; set; }
        ///<summary>
        /// Campo para definir la visibilidad
        ///</summary>
        public bool EsVisible { get; set; }

        #endregion

    }
}