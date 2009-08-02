namespace BSD.C4.Tlaxcala.Sai.Interfaces
{
    /// <summary>
    /// Interfaz para la definición de eventos para los formularios de la aplicación
    /// </summary>
    interface IReacciones<T, U>
        where T : class
        where U : class
    {
        /// <summary>
        /// Método para la implementación de guardar el registro
        /// <example>
        /// <code>
        /// try{
        ///     mapper.Insert(entidad);
        /// }catch(Exception){
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// </summary>
        void GuardarEntidad(T entidad, U mapper);

        T ObtenerEntidad(U mapper,object identificadorEntidad);
    }
}
