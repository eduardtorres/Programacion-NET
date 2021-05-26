using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;

namespace ProveedoresCore.Interfaces
{
    public interface IProveedoresApiRepository
    {
        Task<IList<ProductoDTO>> BuscarProductos(ProveedorDTO fabricanteEntity);
        Task<IList<ProveedorEntity>> ListarProveedores();
    }
}
