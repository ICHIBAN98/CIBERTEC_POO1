using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TrabajadorEnt
    {
       public int IdTrabajador {  get; set; } 
        public string NroDocumento { get; set; }
        public string Nombres{ get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento{ get; set; }
        public DateTime FechaContrato {  get; set; } 
        public int HorasTrabajadas {  get; set; } 
        public double Tarifa {  get; set; } 
    }
}
