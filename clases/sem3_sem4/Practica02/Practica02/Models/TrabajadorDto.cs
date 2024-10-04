using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace Practica02.Models
{
    public class TrabajadorDto
    {
        public async Task<ResultadoTrasationE> RegistrarTrabajador(TrabajadorEnt objTrabajador) 
        {
            ResultadoTrasationE resultado = new ResultadoTrasationE();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx)) {
                cnn.Open();
                SqlTransaction sqlTransaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("SP_Trabajador_Insert", cnn, sqlTransaction))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NroDocumento", objTrabajador.NroDocumento);
                        cmd.Parameters.AddWithValue("@Nombres", objTrabajador.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", objTrabajador.Apellidos);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", objTrabajador.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@FechaContrato", objTrabajador.FechaContrato);
                        cmd.Parameters.AddWithValue("@HorasTrabajadas", objTrabajador.HorasTrabajadas);
                        cmd.Parameters.AddWithValue("@Tarifa", objTrabajador.Tarifa);
                        cmd.Parameters.Add("@exito", SqlDbType.Int, 11).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        await cmd.ExecuteNonQueryAsync();

                        int _exito = Convert.ToInt32(cmd.Parameters["@exito"].Value.ToString());
                        string _mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                        resultado.IdRegistro = 0;
                        resultado.Mensaje = _mensaje;
                        resultado.Value = (_exito==1)? true:false;
                        sqlTransaction.Commit();
                        sqlTransaction.Dispose();

                    }
                    catch (Exception ex) {
                    
                        sqlTransaction.Rollback();
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;
                    }
                }
                return resultado;
            }

        }

        public async Task<List<TrabajadorEnt>> ListarTrabajador(int Orden, int IdTrabajador, string Buscar) 
        {
            List<TrabajadorEnt> objListaTrabajador = new List<TrabajadorEnt>();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx)) {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Trabajador_List", cnn)) 
                {
                    try { 
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orden", Orden);
                        cmd.Parameters.AddWithValue("@IdTrabajador", IdTrabajador);
                        cmd.Parameters.AddWithValue("@Buscar", Buscar);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                TrabajadorEnt objtrabajador = new TrabajadorEnt();
                                objtrabajador.IdTrabajador = Convert.ToInt32(reader["IdTrabajador"].ToString());
                                objtrabajador.Nombres = reader["Nombres"].ToString();
                                objtrabajador.Apellidos = reader["Apellidos"].ToString();
                                objtrabajador.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                objtrabajador.FechaContrato = Convert.ToDateTime(reader["FechaContrato"].ToString());
                                objtrabajador.Tarifa = Convert.ToDouble(reader["Tarifa"].ToString());
                                objtrabajador.HorasTrabajadas = Convert.ToInt32(reader["HorasTrabajadas"].ToString());
                                objListaTrabajador.Add(objtrabajador);
                            }
                        }
                    }
                    catch (Exception ex) 
                    {
                        objListaTrabajador = new List<TrabajadorEnt>();
                    }                
                }
            }return objListaTrabajador;
        }

    }
}
