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

        public ResultadoTransationE PersonaUpdate(PersonaEnt obj) { 
            return new PersonaDto().PersonaUpdate(obj);
        }

        public ResultadoTransationE PersonaDelete(PersonaEnt obj) { 
            return new PersonaDto().PersonaDelete(obj);
        }

        public List<PersonaEnt> PersonaList(int Orden, string Buscar, int Idpersona) {
            return new PersonaDto().PersonaList(Orden, Buscar, Idpersona);
        }

        public PersonaEnt PersonaList_X_ID(int Orden, string Buscar, int Idpersona) {
            return new PersonaDto().PersonaList_X_ID(Orden, Buscar, Idpersona);
        }
    }
}
