using ProductosCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IFabricantesServices
    {
        Task<IList<FabricanteDTO>> ListarFabricantes();
    }
}
