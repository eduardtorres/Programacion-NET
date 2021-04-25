using System;
using System.Collections.Generic;
using System.Text;

namespace ProductosCore.DTO
{
    public class ListarFabricantesResponse
    {
        public ListarFabricantesResponse() { }
        public List<FabricanteDTO> fabricantes { get; set; }
    }
}
