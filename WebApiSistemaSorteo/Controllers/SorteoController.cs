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
    public class SorteoController : ControllerBase
    {
        ISorteo serviceSorteo;
        public SorteoController(ISorteo serviceSorteo)
        {
            this.serviceSorteo = serviceSorteo;
        }
        // GET: api/<SorteoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SorteoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SorteoController>
        [HttpPost]
        public IActionResult Post([FromBody] SorteoDTO sorteoDTO)
        {
            if (sorteoDTO == null)
            {
                return BadRequest("El cliente no puede ser nulo.");
            }

            try
            {
                var sorteo = new Sorteo
                {

                    NombreSorteo = sorteoDTO.NombreSorteo,
                    FechaInicio = sorteoDTO.FechaInicio,
                    FechaFin = sorteoDTO.FechaFin
                };
                var SorteoCreado = serviceSorteo.CreateSorteo(sorteo);
                return Ok(SorteoCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cliente: {ex.Message}");
            }
        }

        // PUT api/<SorteoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SorteoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
