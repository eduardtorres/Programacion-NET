using ClientesCore.DTO;
using ClientesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApi.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        IClientesServices iClientesServices;
        public ClientesController(IClientesServices _iClientesServices)
        {
            iClientesServices = _iClientesServices;
        }

        [HttpPost]        
        public async Task<ActionResult<ClienteDTO>> RegistrarCliente(ClienteDTO cliente)
        {
            return Ok(await iClientesServices.RegistrarCliente(cliente));
        }

        [HttpGet]
        public async Task<ActionResult<ClienteDTO>> ListarClientes()
        {
            return Ok(await iClientesServices.ListarClientes());
        }
    }
}