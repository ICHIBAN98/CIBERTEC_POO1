namespace POOI_T2_RosasChinen.Models
{
    public class MetaGlobal
    {
        public static string Cnx = "";
        public static void LoadConnectionString(string conexion)
        {
            Cnx = conexion;
        }
    }
}
