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
    public class UsuarioController : ControllerBase
    {
        IUsuario serviceUsuario;
        public UsuarioController(IUsuario serviceUsuario) {
            this.serviceUsuario = serviceUsuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("El cliente no puede ser nulo.");
            }

            try
            {
                var usuario = new Usuario
                {
                    IdCliente = usuarioDTO.IdCliente,
                    NombreUsuario = usuarioDTO.NombreUsuario,
                    Correo = usuarioDTO.Correo
                };
                var usuarioCreado = serviceUsuario.CreateUsuario(usuario);
                return Ok(usuarioCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cliente: {ex.Message}");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
