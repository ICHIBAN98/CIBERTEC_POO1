using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using Practica04.Models;

namespace Practica04.Controllers
{
    [ApiController]
    [Route("Venta")]
    public class VentaController : ControllerBase
    {
        [Route("ListarVentaCab")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarVentaCab(int orden, int idventa) 
        {
            try {
                var lista = await new VentaDto().ListarVentaCab(orden, idventa);
                return Ok(lista);

            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        
        }
        [Route("ListarVentaGeneral")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarVentaGeneral(int orden, int idventa)
        {
            try
            {
                var lista = await new VentaDto().ListarVentaGeneral(orden, idventa);
                return Ok(lista);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Route("RegistrarVenta")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarVenta([FromBody] VentaCabEnt objVenta)
        {
            try
            {
                ResultadoTransationE respuesta = new ResultadoTransationE();
                if (objVenta.Id_Venta == 0) // Registro Nuevo
                {

                }
                else // Actualizacion Registro
                {
                    respuesta = await new VentaDto().ActualizarVenta(objVenta);
                }
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
