using BL.Listados;
using BL.Manejadoras;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenJS_API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public List<clsPersona> Get()
        {
            return clsListadoPersonasBL.ObtenerListadoPersonasBL();
        }

        // PUT api/<PersonasController>/5
        [HttpPut]
        public IActionResult Put([FromBody] clsPersona persona)
        {
            IActionResult result = null;
            int numeroFilasAfectadas = 0;

            try
            {
                numeroFilasAfectadas = clsManejadoraPersonasBL.ActualizarPersonaBL(persona);
            }
            catch (Exception e)
            {
                result = BadRequest();
            }
            if (numeroFilasAfectadas == 0)
            {
                result = NoContent();
            }
            else
            {
                result = Ok();
            }
            return result;
        }

        
    }
}
