namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que implementa los valores constantes
    /// para los indices de los controles,cadenas y consultas
    /// </summary>
    public class ID
    {
        #region Teclas de Comando

        //Definición de comandos (deberá existir en la base de submodulos)
        public const int CMD_BSC = 100; //Muestra incidentes guardados (089)
        public const int CMD_CAN = 200; //Cancelar incidencia (089 y 066)
        public const int CMD_DT = 300;  //Dividir incidente (089 y 066)
        public const int CMD_FIN = 400; //Cerrar el programa SafetyNet CAD (089 y 066)
        public const int CMD_INF = 500; //Capturar información en ventana (089)
        public const int CMD_LAC = 600; //Ventana que nos permite ligar incidentes (089 y 066) (089 no lo utiliza)
        public const int CMD_MN = 700;  //Mostrar notas (089 y 066)
        public const int CMD_N = 800;   //Capturar notas (089 y 066)
        public const int CMD_NI = 900;  //Nuevo incidente (089 y 066)
        public const int CMD_P = 1000;  //Pendientes (089 y 066)
        public const int CMD_SDT = 1100;    //Muestra Lista de incidentes divididos (089 y 066)
        public const int CMD_SIF = 1200;    //Seleccion de incidentes por fecha y/o corporacion (089 y 066)
        public const int CMD_A = 1300;  //Incidentes Activos (066)
        public const int CMD_AU = 1400; //Unidades Activas (066)
        public const int CMD_HI = 1500; //Historial de un incidente (066)
        public const int CMD_MAP = 1600;    //Localización de la llamada activa (066)
        public const int CMD_MIA = 1700;    //Localización de un incidente activo (066)
        public const int CMD_MIP = 1800;    //Localización de incidentes pendientes (066)
        public const int CMD_MUS = 1900;    //Localización de unidades activas (066)
        public const int CMD_PH = 2000; //Historial de incidencias con la misma dirección (066)
        public const int CMD_RNC = 2100;    //Generar consecutivo por corporación (066)
        public const int CMD_RPH = 2200;    //Historial de incidencias con el mismo numero telefónico (066)
        public const int CMD_S = 2300;  //Introducción de datos de persona sospechosa (066)
        public const int CMD_SS = 2400; //Cambiar o seleccionar corporación (066)
        public const int CMD_SLC = 2500;    //Consulta de incidentes ligados (066)
        public const int CMD_TEL = 2600;    //Agenda telefónica de las instituciones del estado (DIF,LOCATEL,etc) (066)
        public const int CMD_U = 2700;  //Unidades dispuestas y ocupadas de las diferentes corporaciones (066)
        public const int CMD_UA = 2800; //Dar de alta unidades (066)
        public const int CMD_UB = 2900; //Dar de baja unidades (066)
        public const int CMD_V = 3000;  //Introducción de datos de vehiculo sospechoso (066)

        #endregion

        #region Teclas de función

        public const int FALT = 16;
        public const int FCONTROL = 8;
        public const int FSHIFT = 4;
        public const int VK_ADD = 0x6B;
        public const int VK_BACK = 0x8;
        public const int VK_DECIMAL = 0x6E;
        public const int VK_DELETE = 0x2E;
        public const int VK_DIVIDE = 0x6F;
        public const int VK_DOWN = 0x28;
        public const int VK_END = 0x23;
        public const int VK_ESCAPE = 0x1B;
        public const int VK_F1 = 0x70;
        public const int VK_F10 = 0x79;
        public const int VK_F11 = 0x7A;
        public const int VK_F12 = 0x7B;
        public const int VK_F2 = 0x71;
        public const int VK_F3 = 0x72;
        public const int VK_F4 = 0x73;
        public const int VK_F5 = 0x74;
        public const int VK_F6 = 0x75;
        public const int VK_F7 = 0x76;
        public const int VK_F8 = 0x77;
        public const int VK_F9 = 0x78;
        public const int VK_HOME = 0x24;
        public const int VK_INSERT = 0x2D;
        public const int VK_LEFT = 0x25;
        public const int VK_MULTIPLY = 0x6A;
        public const int VK_NEXT = 0x22;
        public const int VK_PRIOR = 0x21;
        public const int VK_RIGHT = 0x27;
        public const int VK_SEPARATOR = 0x6C;
        public const int VK_SPACE = 0x20;
        public const int VK_SUBTRACT = 0x6D;
        public const int VK_TAB = 0x9;
        public const int VK_UP = 0x26;

        #endregion

        #region Consultas SQL
        
        public const string SQL_CORPORACIONES =
            "SELECT Corporacion.* FROM Corporacion INNER JOIN CorporacionIncidencia ON Corporacion.Clave = CorporacionIncidencia.ClaveCorporacion INNER JOIN Incidencia ON CorporacionIncidencia.Folio = Incidencia.Folio WHERE (Incidencia.Folio = {0}) AND (Corporacion.Activo=1)";

        public const string SQL_INCIDENCIASCORPORACION =
            "SELECT Incidencia.* FROM Incidencia INNER JOIN CorporacionIncidencia ON Incidencia.Folio = CorporacionIncidencia.Folio LEFT JOIN TipoIncidencia ON Incidencia.ClaveTipo = TipoIncidencia.Clave WHERE (CorporacionIncidencia.ClaveCorporacion = {0}) AND (Incidencia.ClaveEstatus = {1}) AND (Incidencia.Activo=1) ORDER BY TipoIncidencia.Prioridad DESC";

        public const string SQL_INCIDENCIAS =
            "SELECT Incidencia.* FROM Incidencia LEFT JOIN TipoIncidencia ON Incidencia.ClaveTipo = dbo.TipoIncidencia.Clave WHERE (Incidencia.ClaveEstatus = {0}) AND (Incidencia.Activo=1) ORDER BY TipoIncidencia.Prioridad DESC";

        public const string SQL_OBTENERDESPACHOS =
            "SELECT DespachoIncidencia.* FROM DespachoIncidencia WHERE (HoraLiberada IS NULL OR HoraLlegada IS NULL OR HoraDespachada IS NULL) AND (ClaveCorporacion={0}) AND (ClaveUnidad={1} OR ClaveUnidadApoyo={1})";

        public const string SQL_OBTENERPERMISOS =
                "SELECT Permiso.* FROM PermisoUsuario INNER JOIN Permiso ON PermisoUsuario.ClavePermiso = Permiso.Clave WHERE (PermisoUsuario.ClaveUsuario = {0}) AND (PermisoUsuario.ClaveSubmodulo = {1}) AND (PermisoUsuario.ClaveSistema={2})";

        public const string SQL_OBTENERUSUARIO = "SELECT TOP 1 * FROM Usuario WHERE (NombreUsuario='{0}') AND (Activo=1)";

        public const string SQL_OBTENERSISTEMAS = "SELECT DISTINCT Sistema.* FROM Sistema INNER JOIN PermisoUsuario ON Sistema.Clave = PermisoUsuario.ClaveSistema INNER JOIN Submodulo ON PermisoUsuario.ClaveSubmodulo = Submodulo.Clave WHERE (PermisoUsuario.ClaveUsuario = {0})";

        public const string SQL_AUTENTICARUSUARIO =
            "SELECT TOP 1 * FROM Usuario WHERE (NombreUsuario='{0}') AND (Contraseña='{1}')";

        public const string SQL_VERIFICARUNIDAD = "SELECT Unidad.* FROM Unidad WHERE (Codigo='{0}')";

        public const string SQL_UNIDADENDESPACHO =
            "SELECT DespachoIncidencia.* FROM DespachoIncidencia WHERE (ClaveUnidad={0} OR ClaveUnidadApoyo={0})";

        public const string SQL_UNIDADESCORPORACION =
            "SELECT Unidad.* FROM Unidad WHERE (ClaveCorporacion={0}) AND (Activo=1)";

        public const string SQL_INCIDENCIASLIGADAS = "SELECT Incidencia.* FROM Incidencia WHERE Folio IN ({0})";

        public const string SQL_INCIDENCIAS089 =
           "SELECT Incidencia.* FROM Incidencia LEFT OUTER JOIN TipoIncidencia ON Incidencia.ClaveTipo = TipoIncidencia.Clave WHERE (Incidencia.ClaveEstatus = {0} OR Incidencia.ClaveEstatus = {1}) AND (TipoIncidencia.ClaveSistema={2}) AND (Incidencia.Activo=1) ORDER BY TipoIncidencia.Prioridad DESC";

        public const string SQL_INCIDENCIAS0892 =
           "SELECT Incidencia.* FROM Incidencia LEFT OUTER JOIN TipoIncidencia ON Incidencia.ClaveTipo = TipoIncidencia.Clave WHERE (Incidencia.ClaveEstatus = {0}) AND (TipoIncidencia.ClaveSistema={1}) AND (Incidencia.Activo=1) ORDER BY TipoIncidencia.Prioridad DESC";

        public const string SQL_DEPENDENCIAS089 =
            "SELECT Dependencia.* FROM Dependencia INNER JOIN IncidenciaDependencia ON Dependencia.Clave = IncidenciaDependencia.ClaveDependencia INNER JOIN Incidencia ON IncidenciaDependencia.Folio = Incidencia.Folio WHERE (Incidencia.Folio = {0})";

        public const string SQL_OBTENERINFOTITULARLINEA = "SELECT TelefonoTelmex.* FROM TelefonoTelmex WHERE Telefono='{0}'";

        public const string SQL_OBTENERCODIGOPOSTAL = "SELECT * FROM CodigoPostal WHERE Valor={0}";

        public const string SQL_OBTENERDESPACHOS2 = "SELECT * FROM DespachoIncidencia WHERE Folio={0}";

        #endregion

        #region Cadenas

        public const string STR_DESCONOCIDO = "(sin registro)";
        public const string STR_NOMBREAPLICATIVO = "Sistema de Administración de Incidencias.";
        public const string STR_TITULOERROR = "Error en la aplicación.";
        public const string STR_ESTATUSLIBRE = "Libre";
        public const string STR_ESTATUSLLEGADA = "Llegada";
        public const string STR_ESTATUSDESPACHADA = "Despachada";
        public const string STR_SINPRIVILEGIOS = "No cuenta con los privilegios suficientes para realizar esta acción.";
        public const string STR_ERROROBTENERREGISTROS = "Ocurrio un error al tratar de obtener los registros. Solicite al administrador revisar los catálogos.";
        public const string STR_NOSELOCALIZOARCHIVO = "No se localizo el archivo de configuracion para los filtros de busqueda.";
        public const string STR_ERRORFILTRO = "Ha ocurrido un error al tratar de generar el filtro.";
        public const string STR_NUEVOCOMENTARIO = "Inserte aquí su nuevo comentario";
        public const string STR_UNIDADVIRTUAL = "Virtual";

        #endregion

        #region Colores

        public static readonly uint COLOR_VERDE = (uint)Aplicacion.HexadecimalADecimal("00FF66");
        public static readonly uint COLOR_NARANJA = (uint)Aplicacion.HexadecimalADecimal("3399FF");
        public static readonly uint COLOR_ROJO = (uint)Aplicacion.HexadecimalADecimal("0033FF");
        public static readonly uint COLOR_AMARILLO = (uint)Aplicacion.HexadecimalADecimal("00FFFF");
        public static readonly uint COLOR_AZURE = (uint)Aplicacion.HexadecimalADecimal("99FFFF");

        #endregion


    }
}