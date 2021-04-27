using ClientesCore.DTO;
using ClientesCore.Interfaces;
using ClientesCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesCore.Services
{
    public class ClientesServices : IClientesServices
    {
        IClientesRepository iClientesRepository;
        public ClientesServices(IClientesRepository _iClientesRepository)
        {
            iClientesRepository = _iClientesRepository;
        }

        public async Task<IList<ClienteDTO>> ListarClientes()
        {            
            ClientesAssembler assembler = new ClientesAssembler();
            IList<ClienteDTO> listaClientes = assembler.assemblyDTOs(await iClientesRepository.ListarClientes());    
            return listaClientes;
        }

        public async Task<ClienteDTO> AuthenticarCliente(string UserName, string Password)
        {
            ClientesAssembler assembler = new ClientesAssembler();
            ClienteDTO cliente = assembler.assemblyDTO(await iClientesRepository.AuthenticarCliente(UserName, Password));
            return cliente;
        }       

        public async Task<ClienteDTO> RegistrarCliente(ClienteDTO cliente)
        {
            ClientesAssembler assembler = new ClientesAssembler();            
            ClienteDTO clienteResult = assembler.assemblyDTO(await iClientesRepository.RegistrarCliente(assembler.assemblyEntity(cliente)));
            return clienteResult;
        }
    }
}
