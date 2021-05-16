using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricantesCore.DTO;
using FabricantesCore.Entities;

namespace FabricantesCore.Interfaces
{
    public interface IFabricantesApiRepository
    {
        Task<IList<ProductoDTO>> BuscarProductos(string filtro, FabricanteEntity fabricanteEntity);
    }
}
