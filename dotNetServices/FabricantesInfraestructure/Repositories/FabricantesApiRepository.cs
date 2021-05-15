using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricantesCore.DTO;
using FabricantesCore.Interfaces;
using RESTConector.Util;

namespace FabricantesInfraestructure.Repositories
{
    public class FabricantesApiRepository : IFabricantesApiRepository
    {
        public FabricantesApiRepository()
        {

        }

        public async Task<IList<ProductoDTO>> BuscarProductos(string url, string filtro, string jsltRequest, string jslResponse)
        {

            RestClient restClient = new RestClient();

            string body = string.Empty; // armar body con filtro

            string respuestaJSON = await restClient.MakeRequest
                (requestUrlApi: url,
                JSONRequest: body,
                JSONmethod: "GET",
                JSONContentType: "application/json",
                msTimeOut: -1);

            // translate


            return new List<ProductoDTO>();

        }

    }
}
