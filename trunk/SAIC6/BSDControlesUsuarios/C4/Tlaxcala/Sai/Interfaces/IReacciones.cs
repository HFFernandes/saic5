﻿namespace BSD.C4.Tlaxcala.Sai.Interfaces
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

        /// <summary>
        /// Método para la obtención de una entidad especifica mediante su identificador
        /// </summary>
        /// <param name="mapper">Objeto mapper del cual depende la entidad</param>
        /// <param name="identificadorEntidad">Identificador único del registro</param>
        /// <returns>Una instancia del tipo especificado</returns>
        T ObtenerEntidad(U mapper,object identificadorEntidad);
    }
}
