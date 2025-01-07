using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio.Interfaces
{
    public interface ISorteo
    {
        List<Sorteo> GetSorteos();

        Sorteo GetSorteoId(int idSorteo);

        Sorteo CreateSorteo(Sorteo sorteo);


    }
}
