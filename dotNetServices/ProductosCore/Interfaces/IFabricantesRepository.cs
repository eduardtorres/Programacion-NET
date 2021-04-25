using ProductosCore.DTO;
using ProductosCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IFabricantesRepository
    {
        Task<IReadOnlyList<FabricanteEntity>> ListarFabricantes(ListarFabricantesRequest request);
    }
}
