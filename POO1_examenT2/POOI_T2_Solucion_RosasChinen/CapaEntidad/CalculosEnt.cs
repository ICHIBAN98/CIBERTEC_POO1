using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CalculosEnt
    {
        public double CalcuSubTotal(int cantidad, double precio)
        {
            double resultado = cantidad * precio;
            return resultado;
        }

        public double CalcuIGV(double SubTotal)
        {
            double resultado = SubTotal * 0.18;
            return resultado;
        }
        public double CalcuMontoTotal(double subTotal, double IGV)
        {
            double resultado = subTotal + IGV;
            return resultado;
        }         

    }
}
