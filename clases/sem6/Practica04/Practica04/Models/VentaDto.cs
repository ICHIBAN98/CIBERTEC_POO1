using CapaEntidad;
using System.Data.SqlClient;

namespace Practica04.Models
{
    public class VentaDto
    {
        public async Task<List<VentaCabEnt>> ListarVentaCab(int orden, int idventa) 
        {
            List<VentaCabEnt> Listar = new List<VentaCabEnt>();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx)) { 
            
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Venta_List", cnn))
                {
                    try {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@orden", orden);
                        cmd.Parameters.AddWithValue("@idventa", idventa);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                VentaCabEnt ventacab = new VentaCabEnt();
                                ventacab.Id_Venta = Convert.ToInt32(reader["Id_Venta"].ToString());
                                ventacab.NombreCliente = reader["NombreCliente"].ToString();
                                ventacab.NombreTipoDocumento = reader["NombreTipoDocumento"].ToString();
                                ventacab.Nro_Documento = reader["Nro_Documento"].ToString();
                                Listar.Add(ventacab);
                            }
                        }

                    }
                    catch (Exception ex) 
                    {
                        Listar = new List<VentaCabEnt>();
                    }
                }
            }
            return Listar;
        }

        public async Task<VentaCabEnt> ListarVentaGeneral(int orden, int idventa)
        {
            VentaCabEnt ventacab = new VentaCabEnt();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx))
            {

                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Venta_List", cnn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@orden", orden);
                        cmd.Parameters.AddWithValue("@idventa", idventa);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                 
                                ventacab.Id_Venta = Convert.ToInt32(reader["Id_Venta"].ToString());
                                ventacab.NombreCliente = reader["NombreCliente"].ToString();
                                ventacab.NombreTipoDocumento = reader["NombreTipoDocumento"].ToString();
                                ventacab.Nro_Documento = reader["Nro_Documento"].ToString();
                                ventacab.Fecha_Venta = Convert.ToDateTime(reader["Fecha_Venta"].ToString());
                                if (await reader.NextResultAsync()) 
                                {
                                    ventacab.ListadoProducto = new List<VentaDetEnt>();
                                    while (reader.Read()) 
                                    { 
                                        VentaDetEnt ventaDetEnt = new VentaDetEnt();
                                        ventaDetEnt.Id_VentaDetalle = Convert.ToInt32(reader["Id_VentaDetalle"].ToString());
                                        ventaDetEnt.Id_Venta = Convert.ToInt32(reader["Id_Venta"].ToString());
                                        ventaDetEnt.NombreProducto = reader["NombreProducto"].ToString();
                                        ventaDetEnt.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
                                        ventaDetEnt.Precio = Convert.ToDouble(reader["Precio"].ToString());
                                        ventaDetEnt.Subtotal = Convert.ToDouble(reader["Subtotal"].ToString());
                                        ventaDetEnt.Descuento =  Convert.ToDouble(reader["Descuento"].ToString());
                                        ventaDetEnt.Igv = Convert.ToDouble(reader["Igv"].ToString());
                                        ventaDetEnt.Total = Convert.ToDouble(reader["Total"].ToString());
                                        ventacab.ListadoProducto.Add(ventaDetEnt);                                    
                                    }
                                }
                                
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        ventacab = new VentaCabEnt();
                    }
                }
            }
            return ventacab;
        }


        public async Task<ResultadoTransationE> ActualizarVenta(VentaCabEnt objventa) 
        {
            ResultadoTransationE resultado = new ResultadoTransationE();
            using (SqlConnection cnn = new SqlConnection(MetaGlobal.Cnx)) 
            {
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction(); 
                using (SqlCommand cmd = new SqlCommand("SP_VentaCab_Update", cnn, transaction))
                {
                    try 
                    { 
                        if (objventa.ListadoProducto.Count() > 0)
                        {
                            //Registra
                            foreach (var item in objventa.ListadoProducto.Where(w => w.Id_VentaDetalle == 0))
                            {
                                var respuestaRegistrar = await RegistrarProducto(item, objventa.Id_Venta, cnn, transaction);
                                
                                if (respuestaRegistrar.IdRegistro == -1)
                                {
                                    transaction.Rollback();
                                    resultado.IdRegistro = -1;
                                    resultado.Mensaje = respuestaRegistrar.Mensaje;

                                    return resultado;
                                }
                            }

                            //Editar
                            foreach (var item in objventa.ListadoProducto.Where(w => w.Id_VentaDetalle > 0)) 
                            {
                                var respuestaEditar = await EditarProducto(item, cnn, transaction);
                                if (respuestaEditar.IdRegistro == -1)
                                {
                                    transaction.Rollback();
                                    resultado.IdRegistro = -1;
                                    resultado.Mensaje = respuestaEditar.Mensaje;

                                    return resultado;
                                }
                            }

                        }

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Idventa", objventa.Id_Venta);
                        cmd.Parameters.AddWithValue("@SubTotal", objventa.Sub_Total);
                        cmd.Parameters.AddWithValue("@Igv", objventa.Igv);
                        cmd.Parameters.AddWithValue("@Total", objventa.Total);
                        await cmd.ExecuteNonQueryAsync();

                        transaction.Commit();
                        transaction.Dispose();

                        resultado.IdRegistro = 0;
                        resultado.Mensaje = "Registro Correcto";
                    }
                    catch (Exception ex) { 
                        transaction.Rollback();
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;

                    }
                }            
            }
            return resultado;
        }

        public async Task<ResultadoTransationE> RegistrarProducto(VentaDetEnt objventadetalle, int IdVenta, SqlConnection cnn, SqlTransaction transaction) 
        {
            ResultadoTransationE resultado = new ResultadoTransationE();
            using (SqlCommand cmd = new SqlCommand("SP_VentaDet_Insert", cnn, transaction)) 
            {
                try 
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_VentaDetalle", objventadetalle.Id_VentaDetalle);
                    cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                    cmd.Parameters.AddWithValue("@NombreProducto", objventadetalle.NombreProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", objventadetalle.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", objventadetalle.Precio);
                    cmd.Parameters.AddWithValue("@Subtotal", objventadetalle.Subtotal);
                    cmd.Parameters.AddWithValue("@Igv", objventadetalle.Igv);
                    cmd.Parameters.AddWithValue("@Descuento", objventadetalle.Descuento);
                    cmd.Parameters.AddWithValue("@Total", objventadetalle.Total);
                    await cmd.ExecuteNonQueryAsync();

                    resultado.IdRegistro = 0;
                    resultado.Mensaje = "Registro Correcto";
                }
                catch (Exception ex) 
                {
                    resultado.IdRegistro = -1;
                    resultado.Mensaje = ex.Message;
                }
            }
           return resultado;
        }

        public async Task<ResultadoTransationE> EditarProducto(VentaDetEnt objventadetalle, SqlConnection cnn, SqlTransaction transaction) 
        {
            ResultadoTransationE resultado = new ResultadoTransationE();
            using (SqlCommand cmd = new SqlCommand("SP_VentaDet_Update", cnn, transaction))
            {
                try 
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_VentaDetalle", objventadetalle.Id_VentaDetalle);
                    cmd.Parameters.AddWithValue("@NombreProducto", objventadetalle.NombreProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", objventadetalle.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", objventadetalle.Precio);
                    cmd.Parameters.AddWithValue("@Subtotal", objventadetalle.Subtotal);
                    cmd.Parameters.AddWithValue("@Igv", objventadetalle.Igv);
                    cmd.Parameters.AddWithValue("@Descuento", objventadetalle.Descuento);
                    cmd.Parameters.AddWithValue("@Total", objventadetalle.Total);
                    await cmd.ExecuteNonQueryAsync();

                    resultado.IdRegistro = 0;
                    resultado.Mensaje = "Registro Correcto";
                }
                catch (Exception ex) 
                {
                    resultado.IdRegistro = -1;
                    resultado.Mensaje = ex.Message;

                }
            }
            return resultado;
        }
    }
}
