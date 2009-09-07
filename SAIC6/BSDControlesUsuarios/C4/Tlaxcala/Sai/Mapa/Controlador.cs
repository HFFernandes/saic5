using System;
using System.Collections.Generic;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using BSD.C4.Tlaxcala.Sai;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;


namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public static class Controlador
    {
        public static SAIFrmMapa _frmMapa;
        private static Thread tr;

        public delegate void DelegadoActualizarMapa(EstructuraUbicacion objDatosUbicacion);

        private static void ActualizarMapa(EstructuraUbicacion objDatosUbicacion)
        {
            if (objDatosUbicacion.IdColonia.HasValue)
            {
                _frmMapa.Colonia(objDatosUbicacion.IdColonia.Value);
                _frmMapa.Refresh();
            }
            else if (objDatosUbicacion.IdLocalidad.HasValue)
            {
                _frmMapa.Localidad(objDatosUbicacion.IdLocalidad.Value);
                _frmMapa.Refresh();
            }
            else if (objDatosUbicacion.IdMunicipio.HasValue)
            {
                _frmMapa.Municipio(objDatosUbicacion.IdMunicipio.Value);
                _frmMapa.Refresh();
            }
            else
            {
                //Se ubica el estado
                _frmMapa.CentrarEstado();
            }
        }


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
            if (_frmMapa == null)
            {
                _frmMapa = new SAIFrmMapa(ConfigurationSettings.AppSettings["XmlCartografia"],
                                          Application.StartupPath + @"\");
                _frmMapa.Show();
            }

            tr = new Thread(delegate()
                                {
                                    try
                                    {
                                        _frmMapa.Invoke(new DelegadoActualizarMapa(ActualizarMapa),
                                                        new object[] {objDatosUbicacion});
                                    }
                                    catch
                                    {
                                    }
                                }) {IsBackground = true};
            tr.Start();
            //frmIncidencia.Focus();
        }

        /// <summary>
        /// Muestra el mapa con la información del formulario que lo manda a llamar
        /// </summary>
        public static void MuestraMapa(EstructuraUbicacion objDatosUbicacion)
        {
            if (_frmMapa == null)
            {
                _frmMapa = new SAIFrmMapa(ConfigurationSettings.AppSettings["XmlCartografia"],
                                          Application.StartupPath + @"\");
                _frmMapa.Show();
            }
            tr = new Thread(delegate()
                                {
                                    try
                                    {
                                        _frmMapa.Invoke(new DelegadoActualizarMapa(ActualizarMapa),
                                                        new object[] {objDatosUbicacion});
                                    }
                                    catch
                                    {
                                    }
                                }) {IsBackground = true};
            tr.Start();
        }

        /// <summary>
        /// Revisa si existen más instancias de formularios de incidencias abiertos, para que en caso de que ya no haya más, se cierre la ventana del mapa.
        /// </summary>
        /// <remarks>
        /// Este método debe de llamarse al cerrar cada formulario
        /// </remarks>
        public static void RevisaInstancias()
        {
            //if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            //    return;

            if (Aplicacion.VentanasIncidencias.Count == 0)
            {
                _frmMapa.Close();
                _frmMapa.Dispose();
                _frmMapa = null;
            }
        }

        /// <summary>
        /// Revisa si existen más instancias de formularios de incidencias abiertos, para que en caso de que ya no haya más, se cierre la ventana del mapa.
        /// </summary>
        /// <remarks>
        /// Este método debe de llamarse al cerrar cada formulario
        /// </remarks>
        public static void RevisaInstancias(Form frmIncidencia)
        {
            //if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            //    return;

            if (Aplicacion.VentanasIncidencias.Count == 0 ||
                (Aplicacion.VentanasIncidencias.Count == 1 &&
                 Aplicacion.VentanasIncidencias[0].Ventana == (frmIncidencia as Form)))
            {
                if (_frmMapa != null)
                {
                    _frmMapa.Close();
                    _frmMapa.Dispose();
                    _frmMapa = null;
                }
            }
        }

        /// <summary>
        /// Revisa si existen más instancias de formularios de incidencias abiertos, para que en caso de que ya no haya más, se cierre la ventana del mapa.
        /// </summary>
        /// <remarks>
        /// Este método debe de llamarse al cerrar cada formulario
        /// </remarks>
        public static void RevisaInstancias(SAIFrm089 frmIncidencia)
        {
            //if (Aplicacion.UsuarioPersistencia.strSistemaActual == "089")
            //    return;

            if (Aplicacion.VentanasIncidencias.Count == 0 ||
                (Aplicacion.VentanasIncidencias.Count == 1 &&
                 Aplicacion.VentanasIncidencias[0].Ventana == (frmIncidencia as Form)))
            {
                _frmMapa.Close();
                _frmMapa.Dispose();
                _frmMapa = null;
            }
        }
    }
}