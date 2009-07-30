namespace BSD.C4.Tlaxcala.Sai.Interfaces
{
    /// <summary>
    /// Interfaz para la definición de eventos para los formularios de la aplicación
    /// </summary>
    interface IEventosFormulario<T,U> 
        where T : class
        where U : class
    {
        /// <summary>
        /// Método para la implementación de guardar el registro
        /// </summary>
        void Guardar(T entidad,U mapper);
    }
}
