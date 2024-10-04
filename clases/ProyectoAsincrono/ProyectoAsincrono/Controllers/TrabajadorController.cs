using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using ProyectoAsincrono.Models;

namespace ProyectoAsincrono.Controllers
{
    public class TrabajadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ListadoTrabajador(int orden, string buscar, int idTrabajador)
        {
            var lista = await new TrabajadorDto().ListadoTrabajador(orden, buscar, idTrabajador);
            return Ok(lista);
        }

        [HttpPost]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> registroTrabajador([FromBody] TrabajadorEnt objTrabajador)
        {
            try
            {
                var resultado = await new TrabajadorDto().registroTrabajador(objTrabajador);
                return Ok(resultado);
            } 
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
        }
    }
}
