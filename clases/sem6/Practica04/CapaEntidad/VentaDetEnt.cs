using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaDetEnt
    {
        public int Id_VentaDetalle {  get; set; }
        public int Id_Venta { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad        { get; set; }
        public double Precio       { get; set; }
        public double Subtotal     { get; set; }
        public double Descuento    { get; set; }
        public double Igv          { get; set; }
        public double Total { get; set; }
    }
}
