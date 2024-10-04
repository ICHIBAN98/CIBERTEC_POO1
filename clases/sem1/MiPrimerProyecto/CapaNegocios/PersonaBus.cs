using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class PersonaBus
    {
        public ResultadoTransationE PersonaInsert(PersonaEnt obj)
        { 
            return new PersonaDto().PersonaInsert(obj);
        }
    }
}
