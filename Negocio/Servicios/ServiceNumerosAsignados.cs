using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocio.Interfaces;

namespace Negocio.Servicios
{
    public class ServiceNumerosAsignados: INumerosAsignados
    {
        private SorteosDbContext db;

        public ServiceNumerosAsignados(SorteosDbContext db)
        {
            this.db = db;
        }

        public NumerosAsignado CreateNumerosAsignados(int idCliente, int idUsuario, int idSorteo)
        {
            int numeroMaximo = 0;
            int numeroBuscadoDisponible = 0;
            NumerosDisponiblesCliente RegistroNumerosDisponiblesCliente;

            // 1. Obtener todos los números asignados para el cliente
            var numerosAsignados = db.NumerosAsignados
                .Where(n => n.IdCliente == idCliente)
                .ToList();

            // 2. Determinar el número máximo asignado
            numeroMaximo = numerosAsignados.Any()
                ? numerosAsignados.Max(n => n.NumeroAsignado)
                : 0;

            if ((numeroMaximo + 1) >= 99999)
            {
                NumerosDisponiblesCliente ? numeroDisponible = db.NumerosDisponiblesClientes
                    .Where(nd => nd.IdCliente == idCliente)
                    .OrderBy(nd => nd.Numero)
                    .FirstOrDefault();

                if (numeroDisponible == null)
                {
                    throw new Exception("No hay números disponibles para asignar al cliente.");
                }

                RegistroNumerosDisponiblesCliente = numeroDisponible;
                numeroBuscadoDisponible = numeroDisponible.Numero;

                NumerosAsignado nuevoRegistro = new NumerosAsignado
                {
                    IdCliente = idCliente,
                    IdUsuario = idUsuario,
                    IdSorteo = idSorteo,
                    NumeroAsignado = numeroBuscadoDisponible,
                    RepresentacionNumeroAsignado = numeroBuscadoDisponible.ToString("D5"),
                    FechaAsignacion = DateTime.Now
                };

                db.NumerosAsignados.Add(nuevoRegistro);
                db.NumerosDisponiblesClientes.Remove(RegistroNumerosDisponiblesCliente);
                db.SaveChanges();

                NumerosAsignado ? registroConfirmado = db.NumerosAsignados
                    .FirstOrDefault(n =>
                        n.IdCliente == idCliente &&
                        n.IdUsuario == idUsuario &&
                        n.IdSorteo == idSorteo &&
                        n.NumeroAsignado == numeroBuscadoDisponible);

                if (registroConfirmado == null)
                {
                    throw new Exception("Error al confirmar el registro del número asignado.");
                }

                return registroConfirmado;

            }

            NumerosAsignado nuevoRegistroNomral = new NumerosAsignado
            {
                IdCliente = idCliente,
                IdUsuario = idUsuario,
                IdSorteo = idSorteo,
                NumeroAsignado = numeroMaximo + 1,
                RepresentacionNumeroAsignado = (numeroMaximo + 1).ToString("D5"),
                FechaAsignacion = DateTime.Now
            };

            db.NumerosAsignados.Add(nuevoRegistroNomral);
            db.SaveChanges();
            return nuevoRegistroNomral;
        }

        public bool DeleteNumerosAsignados(int idCliente, int idUsuario, int idSorteo)
        {
            NumerosAsignado ? numeroAsignado = db.NumerosAsignados.FirstOrDefault(n => n.IdUsuario == idUsuario && n.IdSorteo == idSorteo && n.IdCliente == idCliente);

            if (numeroAsignado == null)
            {
                throw new InvalidOperationException($"No se encontró un número asignado para el usuario {idUsuario} en el sorteo {idSorteo}.");
            }

            NumerosDisponiblesCliente numeroDisponible = new NumerosDisponiblesCliente
            {
                IdCliente = idCliente,
                Numero = numeroAsignado.NumeroAsignado,
                FechaCreacion = DateTime.UtcNow
            };

            db.NumerosDisponiblesClientes.Add(numeroDisponible);
            db.NumerosAsignados.Remove(numeroAsignado);
            db.SaveChanges();
            return true;
        }

        public List<NumerosAsignado> GetNumerosAsignadosId(int idCliente)
        {
             return db.NumerosAsignados
            .Where(n => n.IdCliente == idCliente)
            .OrderBy(n => n.NumeroAsignado)
            .ToList();
        }
    }
}
