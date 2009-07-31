namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que implementa los valores constantes
    /// para los indices de los controles
    /// </summary>
    public class ID
    {
        //Definición de comandos
        public const int CMD_BSC = 100; //Muestra incidentes guardados con F9
        public const int CMD_CAN = 200; //Cancelar incidencia
        public const int CMD_DT = 300;  //Dividir incidente
        public const int CMD_FIN = 400; //Cerrar el programa HIWIN
        public const int CMD_INF = 500; //Capturar información en ventana
        public const int CMD_LAC = 600; //Ventana que nos permite ligar incidentes
        public const int CMD_MN = 700;  //Mostrar notas
        public const int CMD_N = 800;   //Capturar notas
        public const int CMD_NI = 900;  //Nuevo incidente
        public const int CMD_P = 1000;  //Pendientes
        public const int CMD_SDT = 1100;    //Seleccionar división de ticket
        public const int CMD_SIF = 1200;    //Seleccion de incidentes por fecha

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
    }
}