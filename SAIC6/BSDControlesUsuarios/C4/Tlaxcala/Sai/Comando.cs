namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que define los parametros que deber� cumplir la
    /// definici�n de un nuevo comando
    /// </summary>
    public class Comando
    {
        /// <summary>
        /// Constructor de la clase con parametros para la nueva definici�n
        /// </summary>
        /// <param name="identificador">Clave interna que define al comando en base a las constantes declaradas en la clase <see cref="ID">ID</see></param>
        /// <param name="caption">Texto para el comando</param>
        /// <param name="descripcion">Descripci�n tooltip</param>
        /// <param name="teclaaccesorapido">Combinaci�n de tecla de acceso r�pido</param>
        /// <param name="iniciagrupo">Propiedad que indica si el comando definido iniciar� un grupo</param>
        /// <param name="esvisible">Propiedad que indica si el comando ser� o no visible</param>
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
        /// Campo para la definici�n del texto
        ///</summary>
        public string Caption { get; set; }

        ///<summary>
        /// Campo para la descripci�n del comando
        ///</summary>
        public string Descripcion { get; set; }

        ///<summary>
        /// Campo para la definici�n del m�todo abreviado
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