using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Interfaces;
using Util;

namespace ProductosInfraestructure.Repositories
{
    public class ProveedoresApiRepository : IProveedoresApiRepository
    {
        string apiUrl;

        public ProveedoresApiRepository(string _apiUrl)
        {
            apiUrl = _apiUrl;
        }

        public async Task<List<ProductoDto>> ListarProductos(string filtro)
        {
            try
            {
                RestClient restClient = new RestClient();
                string finalUrl = apiUrl + "/proveedor/productos/obtener/" + filtro;
                var response = await restClient.MakeGetRequest<List<ProductoDto>>(requestUrlApi: finalUrl, JSONobject: null, msTimeOut: 3000);

                response.ForEach(x =>
                {
                    x.urlImagen = "";
                });

                return response;
            }
            catch
            {
                return new List<ProductoDto>();
            }
        }
    }
}
