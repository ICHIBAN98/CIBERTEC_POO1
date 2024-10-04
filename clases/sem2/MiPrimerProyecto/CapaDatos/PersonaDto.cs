using CapaEntidad; 
using System.Data.SqlClient;
using System.Data; 

namespace CapaDatos
{
    public class PersonaDto 
    {
        private string cnx = "";
        public PersonaDto() 
        { 
            cnx = new ConexionDto().getConexionString();
        }

        public ResultadoTransationE PersonaInsert(PersonaEnt obj)
        { 
            ResultadoTransationE resultadoTransationE = new ResultadoTransationE();
            using (SqlConnection cnn = new SqlConnection(cnx)) 
            { 
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();
                try 
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Persona_Insert", cnn, transaction)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", obj.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", obj.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@NroDocumento", obj.NroDocumento);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Edad", obj.Edad);
                        cmd.Parameters.AddWithValue("@user_insert", obj.user_Insert);
                        cmd.Parameters.Add("@exito", SqlDbType.Int, 11).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        int _exito = Convert.ToInt32(cmd.Parameters["@exito"].Value.ToString());
                        string _mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                        transaction.Commit();
                        transaction.Dispose();
                        resultadoTransationE.IdRegistro = 0;
                        resultadoTransationE.Mensaje = _mensaje;
                        resultadoTransationE.value = (_exito==1) ? true: false;
                    }                        
                }
                catch (Exception ex) 
                {
                    transaction.Rollback();
                    resultadoTransationE.IdRegistro = -1;
                    resultadoTransationE.Mensaje = ex.Message;
                }
            }
            return resultadoTransationE;
        }

        public ResultadoTransationE PersonaUpdate(PersonaEnt obj) 
        {
            ResultadoTransationE resultadoTransationE = new ResultadoTransationE();
            using (SqlConnection cnn = new SqlConnection(cnx))
            { 
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("SP_Persona_Update", cnn, transaction)) 
                {
                    try {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPersona", obj.IdPersona);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", obj.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", obj.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Edad", obj.Edad);
                        cmd.Parameters.AddWithValue("@user_insert", obj.user_Insert);
                        cmd.Parameters.Add("@exito", SqlDbType.Int, 11).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        int _exito = Convert.ToInt32(cmd.Parameters["@exito"].Value.ToString());
                        string _mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                        transaction.Commit();
                        transaction.Dispose();
                        resultadoTransationE.IdRegistro = 0;
                        resultadoTransationE.Mensaje = _mensaje;
                        resultadoTransationE.value = (_exito == 1) ? true : false;

                    }
                    catch (Exception ex) 
                    {
                        transaction.Rollback();
                        resultadoTransationE.IdRegistro = -1;
                        resultadoTransationE.Mensaje = ex.Message;
                    }
                }
            }
            return resultadoTransationE;
        }


        public ResultadoTransationE PersonaDelete(PersonaEnt obj) 
        {
            ResultadoTransationE resultadoTransationE = new ResultadoTransationE();
            using (SqlConnection cnn = new SqlConnection(cnx))
            {
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("SP_Persona_Delete", cnn, transaction)) 
                {
                    try {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPersona", obj.IdPersona);
                        cmd.Parameters.AddWithValue("@user_insert", obj.user_Insert);
                        cmd.Parameters.Add("@exito", SqlDbType.Int, 11).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        int _exito = Convert.ToInt32(cmd.Parameters["@exito"].Value.ToString());
                        string _mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                        transaction.Commit();
                        transaction.Dispose();
                        resultadoTransationE.IdRegistro = 0;
                        resultadoTransationE.Mensaje = _mensaje;
                        resultadoTransationE.value = (_exito == 1) ? true : false;
                    }
                    catch (Exception ex) {
                        transaction.Rollback();
                        resultadoTransationE.IdRegistro = -1;
                        resultadoTransationE.Mensaje = ex.Message;
                    }
                }
            }
            return resultadoTransationE;
        }

        public List<PersonaEnt> PersonaList(int Orden, string Buscar, int Idpersona) 
        { 
            List<PersonaEnt> objLista = new List<PersonaEnt>();
            using (SqlConnection cnn = new SqlConnection(cnx))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Persona_List", cnn))
                {
                    try 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orden", Orden);
                        cmd.Parameters.AddWithValue("@Buscar", Buscar);
                        cmd.Parameters.AddWithValue("@Idpersona", Idpersona);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                PersonaEnt personaEnt = new PersonaEnt();
                                personaEnt.IdPersona = Convert.ToInt32(reader["IdPersona"].ToString());
                                personaEnt.Nombre = reader["Nombre"].ToString();
                                personaEnt.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                                personaEnt.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                                personaEnt.NroDocumento = reader["NroDocumento"].ToString();
                                personaEnt.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                personaEnt.Edad = Convert.ToInt32(reader["Edad"].ToString());
                                objLista.Add(personaEnt);
                            }
                        }

                    }
                    catch (Exception ex) 
                    {
                        objLista = new List<PersonaEnt>();
                    }
                }
            }

            return objLista;
        }


        public PersonaEnt PersonaList_X_ID(int Orden, string Buscar, int Idpersona)
        {
            PersonaEnt personaEnt = new PersonaEnt();
            using (SqlConnection cnn = new SqlConnection(cnx)) {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Persona_List", cnn)) 
                {
                    try {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orden", Orden);
                        cmd.Parameters.AddWithValue("@Buscar", Buscar);
                        cmd.Parameters.AddWithValue("@Idpersona", Idpersona);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read())
                            {
                                personaEnt.IdPersona = Convert.ToInt32(reader["IdPersona"].ToString());
                                personaEnt.Nombre = reader["Nombre"].ToString();
                                personaEnt.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                                personaEnt.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                                personaEnt.NroDocumento = reader["NroDocumento"].ToString();
                                personaEnt.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                                personaEnt.Edad = Convert.ToInt32(reader["Edad"].ToString());
                            }
                        }
                    }
                    catch (Exception ex) {
                        personaEnt = new PersonaEnt();
                    }
                }
            }
            return personaEnt;
        }
    }
}
