using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;

namespace ProveedoresCore.Interfaces
{
    public interface IProveedoresApiRepository
    {
        Task<IList<ProductoDTO>> BuscarProductos(string filtro, ProveedorEntity proveedorEntity);
        Task<IList<ProveedorEntity>> ListarProveedores();
    }
}
