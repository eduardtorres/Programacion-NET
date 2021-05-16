using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;

namespace ProductosCore.Interfaces
{
    public interface IProductosRepository
    {
        Task<IList<Producto>> ListarProductos(string filtro);
    }
}
