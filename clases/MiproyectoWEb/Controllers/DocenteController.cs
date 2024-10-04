using Microsoft.AspNetCore.Mvc;
using MiproyectoWEb.Models;

namespace MiproyectoWEb.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            List<DocenteEnt> Lista = new DocentoDto().ListaDocente();
            return View(Lista);
        }

        public IActionResult Create()
        {
            DocenteEnt ent = new DocenteEnt();
            return View(ent);
        }
        [HttpPost]
        public ActionResult Create(DocenteEnt ent)
        {
            if (string.IsNullOrWhiteSpace(ent.Nombres))
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeError = "El campo Nombre es obligatorio!";
                return View(ent);
            }

            String Mensaje = new DocentoDto().RegistrarDocente(ent);
            ViewBag.Mensaje = Mensaje;
            return View(ent);
        }
    }
}
