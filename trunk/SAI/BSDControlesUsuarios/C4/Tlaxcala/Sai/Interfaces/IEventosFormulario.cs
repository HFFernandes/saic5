namespace BSD.C4.Tlaxcala.Sai.Interfaces
{
    /// <summary>
    /// Interfaz para la definición de eventos para los formularios de la aplicación
    /// </summary>
    interface IEventosFormulario
    {
        /// <summary>
        /// Método para la implementación de guardar el registro
        /// </summary>
        void Guardar();
        /// <summary>
        /// Método para la implementación de cerrar el formulario sin guardar el registro
        /// </summary>
        void Cancelar();
    }
}
