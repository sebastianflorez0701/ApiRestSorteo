using Datos.DTO;
using Datos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using Negocio.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSistemaSorteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignarNumeroController : ControllerBase
    {
        INumerosAsignados serviceNumerosAsignados;

        public AsignarNumeroController(INumerosAsignados serviceNumerosAsignados)
        {
            this.serviceNumerosAsignados = serviceNumerosAsignados;
        }
        // GET: api/<AsignarNumeroController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AsignarNumeroController>/5
        [HttpGet("{idCliente}/{idSorteo}/{idUSuario}")]
        public IActionResult Get(int idCliente, int idUSuario, int idSorteo)
        {
            if (idCliente == 0 )
            {
                return BadRequest("El cliente no puede ser nulo.");
            }

            try
            {
                var NuevoNumeroAsignadoCreado = serviceNumerosAsignados.CreateNumerosAsignados(idCliente, idUSuario, idSorteo);
                return Ok(NuevoNumeroAsignadoCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cliente: {ex.Message}");
            }
        }

        // POST api/<AsignarNumeroController>
 
        // PUT api/<AsignarNumeroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsignarNumeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
