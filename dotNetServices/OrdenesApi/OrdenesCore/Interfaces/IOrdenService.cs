using OrdenesCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCore.Interfaces
{
    public interface IOrdenService
    {
        public Task<IEnumerable<Orden>> GetOrdenes();

        public Task<Orden> GetOrdenById(long codigoOrden);

        public Task<Orden> CreateOrden(Orden orden);

        public Task<Orden> UpdateEstadoOrden(long codigoOrden, Orden orden);

        public Task DeleteOrden(long codigoOrden);

    }
}
