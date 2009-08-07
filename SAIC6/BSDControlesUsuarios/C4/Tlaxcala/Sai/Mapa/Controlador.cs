﻿using System;
using System.Collections.Generic;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using BSD.C4.Tlaxcala.Sai;
using System.Configuration;
using System.Windows.Forms;


namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public static class Controlador
    {
        public static SAIFrmMapa _frmMapa;

        /// <summary>
        /// Muestra el mapa con la información del formulario que lo manda a llamar
        /// </summary>
        /// <remarks>
        /// Si la ventana no se encuentra abierta o instanciada, crea una nueva instancia y la muestra según el caso, 
        /// éste método debe de llamarse desde el evento activate de cada formulario o cuando el usuario cambia la información de la ubicación.
        /// </remarks>
        /// <param name="objDatosUbicacion">Clase que contiene los identificadores de municipio, localidad, colonia y código postal</param>
        /// <param name="frmIncidencia">Referencia del formulario que manda a llamar el método</param>
        public static void MuestraMapa(EstructuraUbicacion objDatosUbicacion, SAIFrmIncidencia frmIncidencia)
        {
            Boolean blnPrimeraVez = false;

            if (_frmMapa == null)
            {
                blnPrimeraVez = true;
                _frmMapa = new SAIFrmMapa(ConfigurationSettings.AppSettings["XmlCartografia"], Application.StartupPath + @"\");
            }

            if (objDatosUbicacion.IdCodigoPostal.HasValue)
            {
                _frmMapa.CP(objDatosUbicacion.IdCodigoPostal.Value);
            }
            else if (objDatosUbicacion.IdColonia.HasValue)
            {
                _frmMapa.Colonia(objDatosUbicacion.IdColonia.Value);
            }
            else if (objDatosUbicacion.IdLocalidad.HasValue)
            {
                _frmMapa.Localidad(objDatosUbicacion.IdLocalidad.Value);
            }
            else if (objDatosUbicacion.IdMunicipio.HasValue)
            {
                _frmMapa.Municipio(objDatosUbicacion.IdMunicipio.Value);
            }
            else
            {
                //Se ubica el estado
                _frmMapa.CentrarEstado();
            }

            if (blnPrimeraVez)
            {
                _frmMapa.Show();
                frmIncidencia.Focus();
            }

        }

        /// <summary>
        /// Revisa si existen más instancias de formularios de incidencias abiertos, para que en caso de que ya no haya más, se cierre la ventana del mapa.
        /// </summary>
        /// <remarks>
        /// Este método debe de llamarse al cerrar cada formulario
        /// </remarks>
        public static void RevisaInstancias()
        {
            if (Aplicacion.VentanasIncidencias.Count == 0)
            {
                _frmMapa.Close();
                _frmMapa = null;
            }
        }

        /// <summary>
        /// Revisa si existen más instancias de formularios de incidencias abiertos, para que en caso de que ya no haya más, se cierre la ventana del mapa.
        /// </summary>
        /// <remarks>
        /// Este método debe de llamarse al cerrar cada formulario
        /// </remarks>
        public static void RevisaInstancias(SAIFrmIncidencia frmIncidencia)
        {
            if (Aplicacion.VentanasIncidencias.Count == 0 || (Aplicacion.VentanasIncidencias.Count == 1 && Aplicacion.VentanasIncidencias[0].Ventana  == (frmIncidencia as Form)))
            {
                _frmMapa.Close();
                _frmMapa = null;
            }
          
        }

    }
}