namespace MiproyectoWEb.Models
{
    public class DocenteEnt : PersonaEnt
    {
        public int TiempoServicio { get; set; }
        public int TipoServicio { get; set; }  //1 = parcial , 2= completo

        public override  double Bonificacion() {
            double _bonificacion = 150;
            double _bono1 = 0;
            double _bono2 = 0;

            if (TiempoServicio > 4) {
                _bono1 = _bonificacion * 0.30;
            }
            if (TipoServicio == 2) {
                _bono2 = _bonificacion * 0.15;
            }

            _bonificacion = _bonificacion + _bono1 + _bono2;
            return _bonificacion;
        }
    }
}
