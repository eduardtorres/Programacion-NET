using ProductosCore.DTO;
using ProductosCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IClientesRepository
    {
        Task<IList<ClienteEntity>> ListarClientes();
        Task<ClienteEntity> AuthenticarCliente(string UserName, string Password);
        Task<ClienteEntity> RegistrarCliente(ClienteEntity clienteEntity);
    }
}
