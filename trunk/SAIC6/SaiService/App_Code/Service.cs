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
            throw new Exception(ex.Message);
        }
        return exito;
    }

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

    public MunicipioList GetMunicipios()
    {
        return MunicipioMapper.Instance().GetAll();
    }
   


    public enum TipoSistema
    {
        Sistema_066 = 066,
        Sistema_089 = 089
    }


           
}
