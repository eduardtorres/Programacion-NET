using System;
using System.Collections.Generic;
using System.Text;

namespace ProductosCore.DTO
{
    public class ListarClientesRequest
    {
        public ListarClientesRequest() { }
        public List<ClienteDTO> clientes { get; set; }
        public ClienteDTO cliente { get; set; }
    }
}
