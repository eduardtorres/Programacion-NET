using FabricantesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabricantesCore.Interfaces
{
    public interface IFabricantesRepository
    {
        Task<IList<FabricanteEntity>> ListarFabricantes();
        Task<IList<ProductoEntity>> ListarProductosFabricantes(long IdFabricante);
        Task<IList<InventarioEntity>> ConsultarInventario(IList<ProductoEntity> productos);
    }
}
