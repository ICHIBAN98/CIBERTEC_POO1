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
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        transaction.Dispose();
                        resultadoTransationE.IdRegistro = 0;
                        resultadoTransationE.Mensaje = "Registro Correcto";
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
        
    }
}
