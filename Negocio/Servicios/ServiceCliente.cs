using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.DTO;
using Microsoft.EntityFrameworkCore;
using Negocio.Interfaces;

namespace Negocio.Servicios
{
    public class ServiceCliente: ICliente
    {
        private SorteosDbContext db;
        public ServiceCliente(SorteosDbContext db) {
            this.db = db;
        }

        public Cliente CreateCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return cliente;
        }

        public List<Cliente> GetClientes()
        {
            return db.Clientes.ToList();
        }

        public Cliente GetClientesId(int idCliente)
        {
            Cliente ? cliente = db.Clientes.FirstOrDefault(n => n.IdCliente == idCliente);
            if (cliente == null)
            {
                throw new InvalidOperationException("No se encontró el cliente");
            }
            return cliente;
        }
    }
}
