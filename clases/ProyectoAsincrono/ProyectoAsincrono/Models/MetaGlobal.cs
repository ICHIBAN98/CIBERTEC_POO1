namespace ProyectoAsincrono.Models
{
    public class MetaGlobal
    {
        public static string cnx = "";

        public static void LoadConnectionString(String conexion)
        {
            try
            {
                cnx = conexion;
            }
            catch (Exception ex)
            {
                cnx = "";
            }
        }

    }
}
