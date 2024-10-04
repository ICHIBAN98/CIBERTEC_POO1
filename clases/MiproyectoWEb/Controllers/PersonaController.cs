using Microsoft.AspNetCore.Mvc;
using MiproyectoWEb.Models;

namespace MiproyectoWEb.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            List<PersonaEnt> Lista = new PersonaDto().ListaPersona();
            return View(Lista);
        }

        public IActionResult Create()
        { 
            PersonaEnt ent = new PersonaEnt();
            return View(ent);
        }
        [HttpPost]
        public ActionResult Create(PersonaEnt ent)
        { 
            if(string.IsNullOrWhiteSpace(ent.Nombres))
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "El campo Nombre es obligatorio!";
                return View(ent);
            }



            String Mensaje = new PersonaDto().RegistrarPersona(ent);
            ViewBag.Mensaje = Mensaje;
            return View(ent);
        }
    }
}
