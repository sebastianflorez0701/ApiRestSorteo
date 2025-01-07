using System;
using System.Collections.Generic;

namespace Datos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdCliente { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string? Correo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<NumerosAsignado> NumerosAsignados { get; set; } = new List<NumerosAsignado>();

    public virtual ICollection<UsuarioSorteo> UsuarioSorteos { get; set; } = new List<UsuarioSorteo>();
}
