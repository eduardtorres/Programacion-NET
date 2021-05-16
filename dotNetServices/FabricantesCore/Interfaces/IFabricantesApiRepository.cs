using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricantesCore.DTO;

namespace FabricantesCore.Interfaces
{
    public interface IFabricantesApiRepository
    {
        Task<IList<ProductoDTO>> BuscarProductos(string url, string filtro, string jsltRequest, string jslResponse);
    }
}
