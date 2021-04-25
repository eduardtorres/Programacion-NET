using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Services
{
    public class ClientesServices : IClientesServices
    {
        IClientesRepository iClientesRepository;
        public ClientesServices(IClientesRepository _iClientesRepository)
        {
            iClientesRepository = _iClientesRepository;
        }
        public async Task<ListarClientesResponse> ListarClientes(ListarClientesRequest request)
        {
            IReadOnlyList<ClienteEntity> lista = await iClientesRepository.ListarClientes(request);
            ListarClientesResponse response = new ListarClientesResponse();

            var clientes = lista.Select(x => new ClienteDTO()
            {
                IdCliente = x.IdCliente,
                Nombre = x.Nombre,
                Direccion = x.Direccion,
                Nit = x.Nit,
                Telefono = x.Telefono
            });

            response.clientes = clientes.ToList();
            return response;
        }
    }
}
