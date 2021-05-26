using ProveedoresCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TraslatorJSLT
{
    public interface IConvertJsonToDto
    {
        Task<IList<ProductoDTO>> ConvertToProductList(Dictionary<string, object> routes_list, string template);
        Task<OrdenesDTO> ConvertToOrdersList(Dictionary<string, object> routes_list, string template);
    }
}
