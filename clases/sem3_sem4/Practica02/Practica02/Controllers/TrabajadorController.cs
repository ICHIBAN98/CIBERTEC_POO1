using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using Practica02.Models;

namespace Practica02.Controllers
{
    public class TrabajadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarTrabajador([FromBody] TrabajadorEnt objtrabajador) 
        {
            try {
                var respuesta = await new TrabajadorDto().RegistrarTrabajador(objtrabajador);
                return Ok(respuesta);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarTrabajador(int Orden, int IdTrabajador, string Buscar) {
            try {
                var listado = await new TrabajadorDto().ListarTrabajador(Orden, IdTrabajador, Buscar);
                return Ok(listado);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
