using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;

namespace ProductosCore.Interfaces
{
    public interface IProductosService
    {
        Task<IList<ProductoDto>> ListarProductos(string moneda, string filtro);
        Task<int> AgregarProducto(List<ProductoDto> newProducto);
        Task<int> UpdateProducto(ProductoDto newProducto);
    }
}
