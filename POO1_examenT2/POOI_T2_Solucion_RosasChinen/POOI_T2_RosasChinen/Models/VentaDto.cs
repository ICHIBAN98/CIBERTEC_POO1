using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace POOI_T2_RosasChinen.Models
{
    public class VentaDto
    {
        public async Task<ResultadoTransactionEnt> RegistrarVenta(VentaEnt objVenta)
        {
            ResultadoTransactionEnt resultado = new ResultadoTransactionEnt();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx))
            {
                cnn.Open();
                SqlTransaction sqlTransaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("SP_Venta_Insert", cnn, sqlTransaction))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreProducto", objVenta.NombreProducto);
                        cmd.Parameters.AddWithValue("@FechaVenta", objVenta.FechaVenta);
                        cmd.Parameters.AddWithValue("@Cantidad", objVenta.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", objVenta.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@SubTotal", objVenta.SubTotal);
                        cmd.Parameters.AddWithValue("@IGV", objVenta.IGV);
                        cmd.Parameters.AddWithValue("@MontoTotal", objVenta.MontoTotal);
                        cmd.Parameters.Add("@exito", SqlDbType.Int, 11).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        await cmd.ExecuteNonQueryAsync();

                        int _exito = Convert.ToInt32(cmd.Parameters["@exito"].Value.ToString());
                        string _mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                        resultado.IdRegistro = 0;
                        resultado.Mensaje = _mensaje;
                        resultado.Value = (_exito == 1) ? true : false;
                        sqlTransaction.Commit();
                        sqlTransaction.Dispose();
                    }
                    catch (Exception ex) 
                    {
                        sqlTransaction.Rollback();
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;
                    }
                }
                return resultado;
            }
        }

        public async Task<List<VentaEnt>> ListarVenta(int Orden, int IdVenta, string Buscar)
        {
            List<VentaEnt> objListaVenta = new List<VentaEnt>();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Venta_List", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orden", Orden);
                        cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                        cmd.Parameters.AddWithValue("@Buscar", Buscar);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                VentaEnt objVenta = new VentaEnt();
                                objVenta.IdVenta = Convert.ToInt32(reader["IdVenta"].ToString());
                                objVenta.NombreProducto = reader["NombreProducto"].ToString();
                                objVenta.FechaVenta = Convert.ToDateTime(reader["FechaVenta"].ToString());
                                objVenta.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
                                objVenta.PrecioUnitario = Convert.ToDouble(reader["PrecioUnitario"].ToString());
                                objVenta.SubTotal = Convert.ToDouble(reader["SubTotal"].ToString());
                                objVenta.IGV = Convert.ToDouble(reader["IGV"].ToString());
                                objVenta.MontoTotal = Convert.ToDouble(reader["MontoTotal"].ToString());
                                objListaVenta.Add(objVenta);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        objListaVenta = new List<VentaEnt>();
                    }
                }
            }
            return objListaVenta;
        }
    }
}
