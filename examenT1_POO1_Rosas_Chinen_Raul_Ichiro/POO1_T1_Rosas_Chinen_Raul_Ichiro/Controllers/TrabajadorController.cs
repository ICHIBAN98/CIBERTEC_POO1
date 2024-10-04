using Microsoft.AspNetCore.Mvc;
using POO1_T1_Regalado_Quispe_Mateo.Models;

namespace POO1_T1_Regalado_Quispe_Mateo.Controllers
{
    public class TrabajadorController : Controller
    {
        public IActionResult Index()
        {
            List<TrabajadorEnt> listaTrabajador = new TrabajadorDto().ListarTrabajador();
            return View(listaTrabajador);
        }

        public IActionResult Create()
        {
            TrabajadorEnt ent = new TrabajadorEnt();    
            return View(ent);   
        }

        [HttpPost]

        public ActionResult Create(TrabajadorEnt ent)
        {
            if(string.IsNullOrWhiteSpace(ent.Nombres))
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "El campo nombre es Obligatorio";
                return View(ent);
            }
            if (string.IsNullOrWhiteSpace(ent.Apellidos))
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "El campo Apellidos es Obligatorio";
                return View(ent);
            }
            if (string.IsNullOrWhiteSpace(ent.NroDocumento))
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "El campo NroDocumento es Obligatorio";
                return View(ent);
            }
            if (ent.FechaNacimiento.Year == 1)
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "Ingrese una fecha de Nacimiento correcta";
                return View(ent);
            }
            if (ent.FechaContrato.Year == 1)
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "Ingrese una fecha de Contrato correcta";
                return View(ent);
            }

            if(ent.HorasTrabajadas <= 0)
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "Ingrese Correctamente las horas trabajadas";
                return View(ent);
            }

            if (ent.Tarifa <= 0)
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "Ingrese Correctamente la Tarifa";
                return View(ent);
            }

            string mensaje = new TrabajadorDto().RegistrarTrabajador(ent);
            ViewBag.Mensaje = mensaje;  
            return View(ent);   
        }
    }
}
