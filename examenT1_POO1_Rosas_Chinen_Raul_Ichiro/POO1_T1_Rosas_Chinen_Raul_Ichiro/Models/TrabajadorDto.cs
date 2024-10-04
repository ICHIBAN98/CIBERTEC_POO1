namespace POO1_T1_Regalado_Quispe_Mateo.Models
{
    public class TrabajadorDto
    {
        static List<TrabajadorEnt> objListaTrabajador = new List<TrabajadorEnt>();
        static int _IdTrabajador = 0;

        public List<TrabajadorEnt> ListarTrabajador()
        {
            return objListaTrabajador;
        }

        public string RegistrarTrabajador(TrabajadorEnt obj)
        {
            _IdTrabajador++;
            obj.IdTrabajador = _IdTrabajador;
            objListaTrabajador.Add(obj);
            return "Se ha registrado a: " + obj.Nombres;
        }
    }
}
