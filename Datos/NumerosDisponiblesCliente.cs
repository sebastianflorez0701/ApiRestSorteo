using System;
using System.Collections.Generic;

namespace Datos;

public partial class NumerosDisponiblesCliente
{
    public int IdNumeroDisponible { get; set; }

    public int IdCliente { get; set; }

    public int Numero { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
