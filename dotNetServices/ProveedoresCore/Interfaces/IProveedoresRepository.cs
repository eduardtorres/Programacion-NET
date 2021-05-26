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
        Task<ProveedorEntity> BuscarProveedor(string nombre);
        Task<IList<InventarioEntity>> ConsultarInventario(IList<ProductoEntity> productos);
    }
}
