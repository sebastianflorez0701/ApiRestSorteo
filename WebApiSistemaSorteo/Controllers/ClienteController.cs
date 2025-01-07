using Datos;
using Datos.DTO;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using Negocio.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSistemaSorteo.Controllers
{
    [Route("apiSorteo/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ICliente servicecliente;

        public ClienteController (ICliente servicecliente)
        {
            this.servicecliente = servicecliente;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return servicecliente.GetClientes();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateClienteDTO clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("El cliente no puede ser nulo.");
            }

            try
            {
                // Mapear el DTO a la entidad Cliente
                var cliente = new Cliente
                {
                    NombreCliente = clienteDto.NombreCliente
                };
                var clienteCreado = servicecliente.CreateCliente(cliente);
                return Ok(clienteCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cliente: {ex.Message}");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
