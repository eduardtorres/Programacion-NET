using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;

namespace ProductosCore.Interfaces
{
    public interface IProductosRepository
    {
        Task<IList<Productos>> ListarProductos(string filtro);
        Task<int> AgregarProducto(ProductoDto newProducto);
        Task<int> UpdateProducto(ProductoDto newProducto);
        Task<int> ObtenerPrioridadLocal();
    }
}
