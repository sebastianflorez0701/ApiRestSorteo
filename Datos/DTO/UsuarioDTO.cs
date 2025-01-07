using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTO
{
    public class UsuarioDTO
    {
        public int IdCliente { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string? Correo { get; set; }

    }
}
