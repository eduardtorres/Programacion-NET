using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrdenesCore.DTO;

namespace OrdenesCore.Interfaces
{
    public interface IRestClientInventario
    {
        public Task<long> RemoveProductInventory(IList<DetalleOrden> listaProductos);
    }
}
