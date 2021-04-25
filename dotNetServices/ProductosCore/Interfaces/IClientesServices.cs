using ProductosCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IClientesServices
    {
        Task<IList<ClienteDTO>> ListarClientes();
        Task<ClienteDTO> AuthenticarCliente(string UserName, string Password);
        Task<ClienteDTO> RegistrarCliente(ClienteDTO cliente);
    }
}
