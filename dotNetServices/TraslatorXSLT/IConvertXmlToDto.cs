using ProveedoresCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TraslatorXSLT
{
    public interface IConvertXmlToDto
    {
        Task<IList<ProductoDTO>> ConvertToProductList(string xml, string template);
        Task<OrdenesDTO> ConvertToOrdersList(string xml, string template);
    }
}
