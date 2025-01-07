using System;
using System.Collections.Generic;

namespace Datos;

public partial class Sorteo
{
    public int IdSorteo { get; set; }

    public string NombreSorteo { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual ICollection<NumerosAsignado> NumerosAsignados { get; set; } = new List<NumerosAsignado>();

    public virtual ICollection<UsuarioSorteo> UsuarioSorteos { get; set; } = new List<UsuarioSorteo>();
}
