using System;
using System.Collections.Generic;

namespace Datos;

public partial class UsuarioSorteo
{
    public int IdUsuarioSorteo { get; set; }

    public int IdUsuario { get; set; }

    public int IdSorteo { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Sorteo IdSorteoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
