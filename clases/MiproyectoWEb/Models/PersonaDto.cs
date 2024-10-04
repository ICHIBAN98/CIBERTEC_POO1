namespace MiproyectoWEb.Models
{
    public class PersonaDto
    {
        static List<PersonaEnt> objListaPersona = new List<PersonaEnt>();
        static int _IdPersona = 0;

        public List<PersonaEnt> ListaPersona() { 
            return objListaPersona;
        }

        public string RegistrarPersona(PersonaEnt objPersona) { 
            _IdPersona++;
            objPersona.IdPersona = _IdPersona;
            objListaPersona.Add(objPersona);
            return "Se ha registrado a: " + objPersona.Nombres;
        }
    }
}
