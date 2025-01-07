using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio.Interfaces
{
    public interface INumerosAsignados
    {
        List<NumerosAsignado> GetNumerosAsignadosId(int idCliente);
        NumerosAsignado CreateNumerosAsignados(int idCliente, int idUsuario, int idSorteo);

        bool DeleteNumerosAsignados(int idCliente, int idUsuario, int idSorteo);

    }
}
