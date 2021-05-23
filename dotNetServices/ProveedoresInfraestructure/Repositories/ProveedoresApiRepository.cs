using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresCore.DTO;
using ProveedoresCore.Interfaces;
using Newtonsoft.Json;
using RESTConector.Util;
using SOAPConector.Util;
using System.Xml;
using ProveedoresInfraestructure.Data;
using System.Linq;
using TraslatorJSLT;
using ProveedoresCore.Entities;

namespace ProveedoresInfraestructure.Repositories
{
    public class ProveedoresApiRepository : IProveedoresApiRepository
    {
        ProvidersContext _providersContext;
        public ProveedoresApiRepository(ProvidersContext context)
        {
            _providersContext = context;
        }

        public async Task<IList<ProductoDTO>> BuscarProductos(string filtro, ProveedorDTO fabricanteEntity)
        {
            IList<ProductoDTO> objetoLocal = null;
            ConvertJsonToDto convert = new ConvertJsonToDto();

            if (fabricanteEntity.TipoApi == "REST")
            {
                RestClient restClient = new RestClient();                

                string respuestaJSON = await restClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicio,
                    JSONRequest: fabricanteEntity.Body,
                    JSONmethod: fabricanteEntity.MetodoApi,
                    JSONContentType: "application/json",
                    msTimeOut: -1);
                
                var routes_list = (Dictionary<string, object>)JsonConvert.DeserializeObject(respuestaJSON);                

                objetoLocal = await convert.ConvertToProductList(routes_list, fabricanteEntity.TransformacionProductos);                
            }
            else if (fabricanteEntity.TipoApi == "SOAP")
            {

                string body = fabricanteEntity.Body; 

                System.Net.WebHeaderCollection collection = new System.Net.WebHeaderCollection();
                collection.Add("SOAPAction", fabricanteEntity.SOAPAction );
                collection.Add("Content-Type", "text/xml");

                RestClient soapClient = new RestClient();

                string respuestaXML = await soapClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicio ,
                    JSONRequest: fabricanteEntity.Body,
                    JSONmethod: fabricanteEntity.MetodoApi,
                    JSONContentType: "text/xml",
                    msTimeOut: -1,
                    headers: collection);

                objetoLocal = new List<ProductoDTO>();
            }

            return objetoLocal;
        }

        public async Task<IList<ProveedorEntity>> ListarProveedores()
        {
            var lista = _providersContext.Proveedores.ToList();
            return await Task.FromResult(lista);
        }
    }
}