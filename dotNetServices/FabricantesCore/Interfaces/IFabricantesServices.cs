using FabricantesCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabricantesCore.Interfaces
{
    public interface IFabricantesServices
    {
        Task<IList<FabricanteDTO>> ListarFabricantes();
        Task<IList<ProductoDTO>> ListarProductosFabricantes(long IdFabricante);
        Task<IList<InventarioDTO>> ConsultarInventario(IList<ProductoDTO> productos);
    }
}
