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
using TraslatorXSLT;

namespace ProveedoresInfraestructure.Repositories
{
    public class ProveedoresApiRepository : IProveedoresApiRepository
    {
        ProvidersContext _providersContext;
        IConvertJsonToDto _convertJsonToDto;
        IConvertXmlToDto _convertXmlToDto;
        public ProveedoresApiRepository(ProvidersContext context, IConvertJsonToDto convertJsonToDto, IConvertXmlToDto convertXmlToDto)
        {
            _providersContext = context;
            _convertJsonToDto = convertJsonToDto;
            _convertXmlToDto = convertXmlToDto;
        }

        public async Task<IList<ProductoDTO>> BuscarProductos(ProveedorDTO fabricanteEntity)
        {
            IList<ProductoDTO> objetoLocal = null;

            if (fabricanteEntity.TipoApi == "REST")
            {
                RestClient restClient = new RestClient();

                string respuestaJSON = await restClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicio,
                    JSONRequest: fabricanteEntity.Body,
                    JSONmethod: fabricanteEntity.MetodoApi,
                    JSONContentType: "application/json",
                    msTimeOut: -1);

                var routes_list = JsonConvert.DeserializeObject<Dictionary<string, object>>(respuestaJSON);

                objetoLocal = await _convertJsonToDto.ConvertToProductList(routes_list, fabricanteEntity.TransformacionProductos);
            }
            else if (fabricanteEntity.TipoApi == "SOAP")
            {
                string body = fabricanteEntity.Body;

                System.Net.WebHeaderCollection collection = new System.Net.WebHeaderCollection();
                collection.Add("SOAPAction", fabricanteEntity.SOAPAction);
                collection.Add("Content-Type", "text/xml");

                RestClient soapClient = new RestClient();

                string respuestaXML = await soapClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicio,
                    JSONRequest: fabricanteEntity.Body,
                    JSONmethod: fabricanteEntity.MetodoApi,
                    JSONContentType: "text/xml",
                    msTimeOut: -1,
                    headers: collection);

                objetoLocal = await _convertXmlToDto.ConvertToProductList(respuestaXML, fabricanteEntity.TransformacionProductos);
            }

            return objetoLocal;
        }

        public async Task<OrdenesDTO> BuscarOrden(ProveedorDTO fabricanteEntity)
        {
            OrdenesDTO objetoLocal = null;

            if (fabricanteEntity.TipoApi == "REST")
            {
                RestClient restClient = new RestClient();

                string respuestaJSON = await restClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicioOrden,
                    JSONRequest: fabricanteEntity.Body,
                    JSONmethod: fabricanteEntity.MetodoApi,
                    JSONContentType: "application/json",
                    msTimeOut: -1);

                var routes_list = JsonConvert.DeserializeObject<Dictionary<string, object>>(respuestaJSON);

                objetoLocal = await _convertJsonToDto.ConvertToOrdersList(routes_list, fabricanteEntity.TransformacionOrdenes);
            }
            else if (fabricanteEntity.TipoApi == "SOAP")
            {
                string body = fabricanteEntity.Body;

                System.Net.WebHeaderCollection collection = new System.Net.WebHeaderCollection();
                collection.Add("SOAPAction", fabricanteEntity.SOAPActionOrden);
                collection.Add("Content-Type", "text/xml");

                RestClient soapClient = new RestClient();

                string respuestaXML = await soapClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicioOrden,
                    JSONRequest: fabricanteEntity.Body,
                    JSONmethod: fabricanteEntity.MetodoApi,
                    JSONContentType: "text/xml",
                    msTimeOut: -1,
                    headers: collection);

                objetoLocal = await _convertXmlToDto.ConvertToOrdersList(respuestaXML, fabricanteEntity.TransformacionOrdenes);
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