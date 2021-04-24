using System;
using System.Threading.Tasks;
using ProductosCore.DTO;

namespace ProductosCore.Interfaces
{
    public interface IProductosService
    {
        Task<ListarProductosResponse> ListarProductos(ListarProductosRequest request);
    }
}
