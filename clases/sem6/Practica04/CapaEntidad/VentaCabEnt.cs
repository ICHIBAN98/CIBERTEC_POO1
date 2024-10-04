using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public partial class VentaCabEnt
    {
        public int  Id_Venta {  get; set; }
        public int Id_Persona { get; set; }
        public int Id_TipoDocumento { get;set; }
        public string Nro_Documento {  get; set; }
        public DateTime Fecha_Venta { get; set; }
        public double Sub_Total{get;set;}
        public double Descuento{get;set;}
        public double Igv      {get;set;}
        public double Total { get; set; }

        public List<VentaDetEnt> ListadoProducto {  get; set; }
    }

    public partial class VentaCabEnt 
    { 
        public string NombreCliente { get; set; }
        public string NombreTipoDocumento { get; set; }
    }
}
