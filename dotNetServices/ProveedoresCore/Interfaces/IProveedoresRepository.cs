using ProveedoresCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProveedoresCore.Interfaces
{
    public interface IProveedoresRepository
    {
        Task<IList<ProveedorEntity>> ListarProveedores();
        Task<IList<ProductoEntity>> ListarProductosProveedores(long IdFabricante);
        Task<IList<InventarioEntity>> ConsultarInventario(IList<ProductoEntity> productos);
    }
}
