using System;
using System.Collections.Generic;

namespace Datos;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<NumerosAsignado> NumerosAsignados { get; set; } = new List<NumerosAsignado>();

    public virtual ICollection<NumerosDisponiblesCliente> NumerosDisponiblesClientes { get; set; } = new List<NumerosDisponiblesCliente>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
