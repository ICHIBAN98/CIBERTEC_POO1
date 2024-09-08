using Microsoft.AspNetCore.Mvc;
using POO1_T1_Regalado_Quispe_Mateo.Models;

namespace POO1_T1_Regalado_Quispe_Mateo.Controllers
{
    public class CoordinadorController : Controller
    {
        public IActionResult Index()
        {
            List<CoordinadorEnt> listaCoordinador = new CoordinadorDto().ListarCoordinador();
            return View(listaCoordinador);
        }

        public IActionResult Create()
        {
            CoordinadorEnt ent = new CoordinadorEnt();
            return View(ent);
        }

        [HttpPost]

        public ActionResult Create(CoordinadorEnt ent)
        {
            if (string.IsNullOrWhiteSpace(ent.Nombres))
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

            if (ent.HorasTrabajadas <= 0)
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

            if (ent.AniosServicio <= 0)
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "Ingrese Correctamente los Años de servicio";
                return View(ent);
            }

            if (ent.Titulado != 0 && ent.Titulado != 1)
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "Ingrese Correctamente el Titulado (Solo acepta 1 y 0)";
                return View(ent);
            }

            string mensaje = new CoordinadorDto().RegistrarCoordinador(ent);
            ViewBag.Mensaje = mensaje;
            return View(ent);
        }
    }
}
