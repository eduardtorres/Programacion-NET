using ProveedoresCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProveedoresCore.Interfaces
{
    public interface IProveedoresServices
    {
        Task<IList<ProveedorDTO>> ListarProveedores();        
        Task<IList<ProductoDTO>> BuscarProductosProveedores(string filtro);
        Task<IList<InventarioDTO>> ConsultarInventario(IList<ProductoDTO> productos);        
    }
}
