using System;
using System.Collections.Generic;
using System.Text;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{

/// <summary>
/// Guarda la información que se maneja para la comunicación entre el formulario de incidencia y el formulario del mapa, a través de la clase controlador
/// </summary>
   public class EstructuraUbicacion
   {
       private int? _idMunicipio;
       private int? _idLocalidad;
       private int? _idColonia;
       private int? _idCodigoPostal;

       /// <summary>
       /// Obtiene o establece el valord del identificador del municipio seleccionado
       /// </summary>
       public int ?IdMunicipio { 
           get
           {
               return this._idMunicipio;
           }
           set
           {
               this._idMunicipio = value;
           }
       }
       /// <summary>
       /// Obtiene o establece el valor del identificador de la localidad seleccionada
       /// </summary>
       public int ?IdLocalidad {
           get
           {
               return this._idLocalidad;
           }
           set
           {
               this._idLocalidad = value;
           }
       }
       /// <summary>
       /// Obtiene o establece el valor del identificador de la colonia seleccionada
       /// </summary>
       public int ?IdColonia
       {
           get
           {
               return this._idColonia;
           }
           set
           {
               this._idColonia = value;
           }
       }
       /// <summary>
       /// Obtiene o establece el valor del identificador del código postal seleccionado
       /// </summary>
       public int? IdCodigoPostal
       {
           get
           {
               return this._idCodigoPostal;
           }
           set
           {
               this._idCodigoPostal = value;
           }
       }
   }
}
