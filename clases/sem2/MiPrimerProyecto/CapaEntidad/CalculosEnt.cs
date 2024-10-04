using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CalculosEnt
    {
        public int CalcularEdad(DateTime fecha) 
        {
            int _edad = 0;
            _edad = DateTime.Now.Year - fecha.Year;
            return _edad;
        }
    }
}
