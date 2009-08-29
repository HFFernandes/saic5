using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () 
    {

        
    }

    
    /// <summary>
    /// Guarda una nueva incidencia.
    /// </summary>
    /// <param name="newIncidence">Incidencia,Objeto de tipo incidencia.</param>
    /// <returns>bool,True si la inserción fué correcta,false caso contrario</returns>
    [WebMethod]
    public bool InsertNewIncidence(Incidencia newIncidence) 
    {
        Incidencia NuevaIncidencia=new Incidencia();
        bool exito = true;
        try
        {
            if(newIncidence!=null)
            {

                NuevaIncidencia.FolioPadre=null;
                NuevaIncidencia.Descripcion=newIncidence.Descripcion;
                NuevaIncidencia.Direccion=newIncidence.Direccion;
                NuevaIncidencia.Referencias=newIncidence.Referencias;
                NuevaIncidencia.HoraRecepcion=newIncidence.HoraRecepcion;
                NuevaIncidencia.ClaveEstado=newIncidence.ClaveEstado;
                NuevaIncidencia.ClaveMunicipio=newIncidence.ClaveMunicipio;
                NuevaIncidencia.ClaveLocalidad=newIncidence.ClaveLocalidad;
                NuevaIncidencia.ClaveCodigoPostal=newIncidence.ClaveCodigoPostal;
                NuevaIncidencia.Telefono=newIncidence.Telefono;
                NuevaIncidencia.ClaveDenunciante=newIncidence.ClaveDenunciante;
                NuevaIncidencia.ClaveEstatus=2;//Pendiente
                NuevaIncidencia.ClaveUsuario=1;//UsuarioWeb
                NuevaIncidencia.Activo=true;
                NuevaIncidencia.ClaveTipo=newIncidence.ClaveTipo;
                NuevaIncidencia.Prioridad=null;
                NuevaIncidencia.FechaDocumento=null;
                NuevaIncidencia.NumeroOficio=null;
                NuevaIncidencia.FechaSuceso=null;
                NuevaIncidencia.AliasDelincuente=newIncidence.AliasDelincuente;
                NuevaIncidencia.Imagen=newIncidence.Imagen;
                IncidenciaMapper.Instance().Save(NuevaIncidencia);
            }
            
        }
        catch(Exception ex)
        {
            exito = false;
            throw new Exception(ex.Message);
        }
        return exito;
    }

    /// <summary>
    /// Obtiene el catálogo de incidencias de SAI(Sistema de Administración de Incidencias) por tipo 066 ó 089
    /// </summary>
    /// <param name="tipo">TipoSistema, especifica el tipo de sistema(066 ó 089)</param>
    /// <returns>TipoIncidenciaList,Lista de tipos de incidencia.</returns>
    [WebMethod]
    public TipoIncidenciaList GetTypesIncidence(TipoSistema tipo)
    {

        TipoIncidenciaList lstTipoIncidencias;

        if (tipo== TipoSistema.Sistema_066)
        {
            lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(2);
        }
        else
        {
            lstTipoIncidencias = TipoIncidenciaMapper.Instance().GetBySistema(1);
        }

        return lstTipoIncidencias;
    }

    /// <summary>
    /// Obtiene el catálogo de municipios de SAI para el estado de Tlaxcala.
    /// </summary>
    /// <returns>MunicipioList, Lista del catálogo de Municipios.</returns>
    [WebMethod]
    public MunicipioList GetMunicipios()
    {
        return MunicipioMapper.Instance().GetAll();
    }

    /// <summary>
    /// Obtiene las localidades de un municipio especificado según el catálogo de SAI.
    /// </summary>
    /// <param name="IdMunicipio">int, Id del municipio seleccionado.</param>
    /// <returns>LocalidadList, Lista de localidades.</returns>
    [WebMethod]
    public LocalidadList GetLocalidadesPorMunicipio(int IdMunicipio)
    {

        return LocalidadMapper.Instance().GetByMunicipio(IdMunicipio);
    }


    /// <summary>
    /// Obtiene las colonias de una localidad especificada según el catálogo de SAI.
    /// </summary>
    /// <param name="IdLocalidad">int,Id de localidad seleccionada.</param>
    /// <returns>ColoniaList, Lista de colonias.</returns>
    [WebMethod]
    public ColoniaList GetColoniasPorLocalidad(int IdLocalidad)
    {
        return ColoniaMapper.Instance().GetByLocalidad(IdLocalidad);
    }

    public enum TipoSistema
    {
        Sistema_066 = 066,
        Sistema_089 = 089
    }


           
}
