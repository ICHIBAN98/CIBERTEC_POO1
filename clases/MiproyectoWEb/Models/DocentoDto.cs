namespace MiproyectoWEb.Models
{
    public class DocentoDto
    {
        static List<DocenteEnt> objListaDocente = new List<DocenteEnt>();
        static int _IdPersona = 0;

        public List<DocenteEnt> ListaDocente()
        {
            return objListaDocente;
        }

        public string RegistrarDocente(DocenteEnt objDocente)
        {
            _IdPersona++;
            objDocente.IdPersona = _IdPersona;
            objListaDocente.Add(objDocente);
            return "Se ha registrado a: " + objDocente.Nombres;
        }
    }
}
