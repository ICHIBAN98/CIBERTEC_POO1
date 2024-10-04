using Microsoft.AspNetCore.Mvc;
using Practica04.Models;

namespace Practica04.Controllers
{
    [ApiController]
    [Route("Tabla")]
    public class TablaController : ControllerBase
    {
        [Route("ListarTabla")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarTabla(string codtabla)
        {
            try
            {
                var lista = await new TablaDto().ListarTabla(codtabla);
                return Ok(lista);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
