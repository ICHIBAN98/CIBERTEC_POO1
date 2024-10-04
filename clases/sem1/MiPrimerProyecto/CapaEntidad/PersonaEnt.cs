using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PersonaEnt : CalculosEnt 
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad {  get; set; }
        public int user_Insert { get; set; }


        public PersonaEnt() { }

        public PersonaEnt(int idPersona, string nombre, string apellidoPaterno, string apellidoMaterno, string nroDocumento, DateTime fechaNacimiento, int edad, int _user)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            NroDocumento = nroDocumento;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
            user_Insert = _user;
        }
    }
}
