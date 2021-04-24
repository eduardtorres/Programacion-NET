using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductosCore.DTO
{
    public class ListarProductosResponse
    {
        public ListarProductosResponse()
        {
        }

        public List<ProductoDto> productos { get; set; }
    }
}
