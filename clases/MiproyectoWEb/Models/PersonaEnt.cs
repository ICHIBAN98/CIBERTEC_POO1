namespace MiproyectoWEb.Models
{
    public class PersonaEnt
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double sueldo { get; set; }

        public int CalcularEdad() 
        { 
            int _edad = DateTime.Now.Year - FechaNacimiento.Year;
            return _edad;
        }

        public virtual double Bonificacion() {
            return 150;
        }

        public double SueldoTotal() {
            double _sueldo = sueldo + Bonificacion();
            return _sueldo;
        }

    }
}
