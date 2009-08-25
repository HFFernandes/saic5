namespace BSD.C4.Tlaxcala.Sai.Mapa
{

    /// <summary>
    /// Guarda la información que se maneja para la comunicación entre el formulario de incidencia y el formulario del mapa, a través de la clase controlador
    /// </summary>
    public class EstructuraUbicacion
    {
        /// <summary>
        /// Obtiene o establece el valord del identificador del municipio seleccionado
        /// </summary>
        public int? IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el valor del identificador de la localidad seleccionada
        /// </summary>
        public int? IdLocalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el valor del identificador de la colonia seleccionada
        /// </summary>
        public int? IdColonia { get; set; }

        /// <summary>
        /// Obtiene o establece el valor del identificador del código postal seleccionado
        /// </summary>
        public int? IdCodigoPostal { get; set; }
    }
}
