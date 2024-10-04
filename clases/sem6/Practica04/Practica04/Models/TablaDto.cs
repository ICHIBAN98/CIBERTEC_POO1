using CapaEntidad;
using System.Data.SqlClient;

namespace Practica04.Models
{
    public class TablaDto
    {
        public async Task<List<TablaEnt>> ListarTabla(string codtabla)
        {
            List<TablaEnt> Listar = new List<TablaEnt>();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx))
            {

                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Tabla_List", cnn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codtabla", codtabla);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                TablaEnt ventacab = new TablaEnt();
                                ventacab.Nombre = reader["Nombre"].ToString();
                                Listar.Add(ventacab);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Listar = new List<TablaEnt>();
                    }
                }
            }
            return Listar;
        }
    }
}
