using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace POO1_T1_Regalado_Quispe_Mateo.Models
{
    public class TrabajadorEnt
    {
        public int IdTrabajador { get; set; }
        public string NroDocumento { get; set; }    
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContrato { get; set; }
        public int HorasTrabajadas { get; set; }
        public double Tarifa { get; set; }

        public double SueldoBasico()
        {
            return HorasTrabajadas * Tarifa;
        }

        public virtual double Bonificacion()
        {
            return 100;
        }

        public virtual double Monto()
        {
            return SueldoBasico() + Bonificacion();
        }



    }
}
