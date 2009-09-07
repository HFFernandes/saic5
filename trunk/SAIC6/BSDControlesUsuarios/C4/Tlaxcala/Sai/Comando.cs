namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que define los parametros que deberá cumplir la
    /// definición de un nuevo comando
    /// </summary>
    public class Comando
    {
        /// <summary>
        /// Constructor con parametros
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

        public int Identificador { get; set; }
        public string Caption { get; set; }
        public string Descripcion { get; set; }
        public char? TeclaAccesoRapido { get; set; }
        public bool IniciaGrupo { get; set; }
        public bool EsVisible { get; set; }

        #endregion

    }
}