using System;
using System.Collections.Generic;
using System.Text;

namespace ProductosCore.DTO
{
    public class ListarClientesResponse
    {
        public ListarClientesResponse() { }
        public List<ClienteDTO> clientes { get; set; }
        public ClienteDTO cliente { get; set; }
    }
}
