namespace POO1_T1_Regalado_Quispe_Mateo.Models
{
    public class CoordinadorDto
    {
        static List<CoordinadorEnt> objListaCoordinador = new List<CoordinadorEnt>();
        static int _IdCoordinador = 0;

        public List<CoordinadorEnt> ListarCoordinador()
        {
            return objListaCoordinador;
        }

        public string RegistrarCoordinador(CoordinadorEnt objCoordibnador)
        {
            _IdCoordinador++;
            objCoordibnador.IdTrabajador = _IdCoordinador;
            objListaCoordinador.Add(objCoordibnador);
            return "Se ha registrado a: " + objCoordibnador.Nombres;
        }

    }
}
