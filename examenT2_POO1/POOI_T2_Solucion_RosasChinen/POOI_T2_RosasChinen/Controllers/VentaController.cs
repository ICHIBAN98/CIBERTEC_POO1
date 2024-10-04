using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using POOI_T2_RosasChinen.Models;

namespace POOI_T2_RosasChinen.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarVenta([FromBody] VentaEnt objVenta)
        {
            try
            {
                var respuesta = await new VentaDto().RegistrarVenta(objVenta);
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
        public async Task<IActionResult> ListarVenta(int Orden, int IdTrabajador, string Buscar)
        {
            try
            {
                var listado = await new VentaDto().ListarVenta(Orden, IdTrabajador, Buscar);
                return Ok(listado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
