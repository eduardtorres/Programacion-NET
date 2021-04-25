using ProductosCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IClientesServices
    {
        Task<ListarClientesResponse> ListarClientes(ListarClientesRequest request);
    }
}
