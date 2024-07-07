using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaEnt:CalculosEnt
    {
        public int IdVenta {  get; set; }
        public string NombreProducto {  get; set; }
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario {  get; set; }
        public double SubTotal {  get; set; }
        public double IGV {  get; set; }
        public double MontoTotal {  get; set; }
    }
}
