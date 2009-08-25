using System;
using System.IO;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
   public class CError
    {
       public static void EscribeLog(Object value)
        {
            try
            {
                string fileName = "Error.log";
                StreamWriter writer = File.AppendText(fileName);
                writer.WriteLine("----------------------------------------");
                writer.WriteLine(value);
                writer.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
        public static void EscribeLog()
        {
            try
            {
                string fileName = "Error.log";
                StreamWriter writer = File.AppendText(fileName);
                writer.WriteLine("----------------------------------------");
                writer.WriteLine("Ocurrió un error durante la lectura el archivo XML para el despliegue del mapa.");
                writer.WriteLine("Verifique la sintaxis del archivo XML.");
                writer.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
