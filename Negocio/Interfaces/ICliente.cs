using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio.Interfaces
{
    public interface ICliente
    {
        List<Cliente> GetClientes();
        Cliente  GetClientesId(int idCliente);
        Cliente CreateCliente(Cliente cliente);

    }
}
