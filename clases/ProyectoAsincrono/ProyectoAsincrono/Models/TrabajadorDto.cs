using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoAsincrono.Models
{
    public class TrabajadorDto
    {
        public async Task<ResultadoTransationE> registroTrabajador(TrabajadorEnt objTrabajador)
        {
            ResultadoTransationE resultadoTransationE = new ResultadoTransationE();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.cnx))
            {
                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("SP_Trabajador_Insert", cnn, trans))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombres", objTrabajador.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", objTrabajador.Apellidos);
                        cmd.Parameters.AddWithValue("@NroDocumento", objTrabajador.NroDocumento);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", objTrabajador.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@HorasTrabajadas", objTrabajador.HorasTrabajadas);
                        cmd.Parameters.AddWithValue("@SueldoBasico", objTrabajador.SueldoBasico);
                        cmd.Parameters.AddWithValue("@user_insert", 1);

                        cmd.Parameters.Add("@exito", SqlDbType.Int, 11).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        await cmd.ExecuteNonQueryAsync();

                        int _exito = Convert.ToInt32(cmd.Parameters["@exito"].Value.ToString());
                        string _mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                        resultadoTransationE.IdRegistro = 0;
                        resultadoTransationE.Resultado = _mensaje;
                        resultadoTransationE.Value = (_exito == 1) ? true:false;
                        trans.Commit();
                        trans.Dispose();    

                    } catch (Exception ex) { 
                        trans.Rollback();
                        resultadoTransationE.IdRegistro = -1;
                        resultadoTransationE.Resultado = ex.Message;
                    }
                }
            }
                return resultadoTransationE;
        }

        public async Task<List<TrabajadorEnt>> ListadoTrabajador(int orden, string buscar, int idTrabajador)
        {
            List<TrabajadorEnt> listaTrabajador = new List<TrabajadorEnt>();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.cnx))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Trabajador_List", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orden", orden);
                        cmd.Parameters.AddWithValue("@Buscar", buscar);
                        cmd.Parameters.AddWithValue("@idTrabajador", idTrabajador);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while(reader.Read())
                            {
                                TrabajadorEnt objTrabajador = new TrabajadorEnt();
                                objTrabajador.IdTrabajador = Convert.ToInt32(reader["IdTrabajador"].ToString());
                                objTrabajador.Nombres = reader["Nombres"].ToString();
                                objTrabajador.Apellidos = reader["Apellidos"].ToString();
                                objTrabajador.NroDocumento = reader["NroDocumento"].ToString();
                                objTrabajador.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                objTrabajador.HorasTrabajadas = Convert.ToInt32(reader["HorasTrabajadas"].ToString());
                                objTrabajador.SueldoBasico = Convert.ToDouble(reader["SueldoBasico"].ToString());
                                listaTrabajador.Add(objTrabajador);
                            }
                        }

                    } catch (Exception ex)
                    {
                        listaTrabajador = new List<TrabajadorEnt>();
                    }
                }
            }
                return listaTrabajador;
        }


    }
}
