using System;
using System.Collections.Generic;

namespace Datos;

public partial class NumerosAsignado
{
    private string? _representacionNumeroAsignado;
    public int IdNumeroAsignado { get; set; }

    public int IdUsuario { get; set; }

    public int IdCliente { get; set; }

    public int IdSorteo { get; set; }

    public int NumeroAsignado { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public string RepresentacionNumeroAsignado
    {
        get => _representacionNumeroAsignado ??= NumeroAsignado.ToString("D5");
        set => _representacionNumeroAsignado = NumeroAsignado.ToString("D5");
    }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Sorteo IdSorteoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
