namespace POO1_T1_Regalado_Quispe_Mateo.Models
{
    public class CoordinadorEnt : TrabajadorEnt
    {
        public int AniosServicio { get; set; }
        public int Titulado { get; set; }

        public override double Bonificacion()
        {
            double bonificacion = 100;
            
            if(AniosServicio < 5)
            {
                bonificacion = 100;
            } else if(AniosServicio > 5 && AniosServicio < 10)
            {
                bonificacion = 150;
            } else
            {
                bonificacion = 300;
            }

            return bonificacion;
        }

        public double Incentivo()
        {
            double _incentivo = 0;

            if(Titulado == 1)
            {
                _incentivo = 200;
            }

            return _incentivo;
        }

        public override double Monto()
        {
            return SueldoBasico() + Bonificacion() + Incentivo();
        }



    }
}
