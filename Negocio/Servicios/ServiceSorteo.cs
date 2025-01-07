using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocio.Interfaces;

namespace Negocio.Servicios
{
    public class ServiceSorteo: ISorteo
    {
        private SorteosDbContext db;
        public ServiceSorteo(SorteosDbContext db) {
            this.db = db;
        }

        public Sorteo CreateSorteo(Sorteo sorteo)
        {
            db.Sorteos.Add(sorteo);
            db.SaveChanges();
            return sorteo;
        }

        public Sorteo GetSorteoId(int idSorteo)
        {
            Sorteo? sorteo = db.Sorteos.FirstOrDefault(n => n.IdSorteo == idSorteo);
            if (sorteo == null)
            {
                throw new InvalidOperationException("No se encontró el usuario");
            }
            return sorteo;
        }

        public List<Sorteo> GetSorteos()
        {
            return db.Sorteos.ToList();
        }
    }
}
