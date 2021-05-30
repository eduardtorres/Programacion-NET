using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;

namespace ProductosCore.Interfaces
{
    public interface IProveedoresApiRepository
    {
        Task<List<ProductoDto>> ListarProductos(string filtro);
    }
}
