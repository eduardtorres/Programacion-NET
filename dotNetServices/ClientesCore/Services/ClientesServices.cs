using ClientesCore.DTO;
using ClientesCore.Entities;
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

        public async Task<AutenticarDTO> AuthenticarCliente(string UserName, string Password)
        {
            ClienteEntity cliente = await iClientesRepository.AuthenticarCliente(UserName, Password);
            AutenticarDTO autenticarDTO = new AutenticarDTO();
            if ( cliente != null )
            {
                ClientesAssembler assembler = new ClientesAssembler();
                autenticarDTO.cliente = assembler.AssembleDTO(cliente);
                autenticarDTO.code = 1;
                autenticarDTO.token = Seguridad.CrearJwt(cliente);
            }
            else
            {
                autenticarDTO.code = 0;
            }

            return autenticarDTO;
        }       

        public async Task<ClienteDTO> RegistrarCliente(ClienteDTO cliente)
        {
            ClientesAssembler assembler = new ClientesAssembler();            
            ClienteDTO clienteResult = assembler.assemblyDTO(await iClientesRepository.RegistrarCliente(assembler.assemblyEntity(cliente)));
            return clienteResult;
        }
    }
}
