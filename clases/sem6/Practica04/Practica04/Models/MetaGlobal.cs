namespace Practica04.Models
{
    public class MetaGlobal
    {
        public static string Cnx = "";
        public static void LoadConectionString(string conexion) 
        {
            Cnx = conexion;
        }

    }
}
