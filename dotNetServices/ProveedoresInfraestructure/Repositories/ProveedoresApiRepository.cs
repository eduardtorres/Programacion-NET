using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;
using ProveedoresCore.Interfaces;
using Newtonsoft.Json;
using RESTConector.Util;
using SOAPConector.Util;
using System.Xml;
using ProveedoresInfraestructure.Data;
using System.Linq;

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
            List<ProductoDTO> objetoLocal = new List<ProductoDTO>();
            
            if (fabricanteEntity.TipoApi == "REST")
            {
                RestClient restClient = new RestClient();

                string body = string.Empty; // armar body con filtro

                string respuestaJSON = await restClient.MakeRequest
                    (requestUrlApi: fabricanteEntity.UrlServicio,
                    JSONRequest: body,
                    JSONmethod: fabricanteEntity.MetodoApi, // GET
                    JSONContentType: "application/json",
                    msTimeOut: -1);

                // Invokar translator JSLT
                // translate respuestaJSON A formatoEsperadoJSON                

                string template = @"[{
                                      ""id"": ""@id"",
                                      ""codigo"": ""@codigo"",
                                      ""proveedor"": ""@proveedor"",
                                      ""tipoProveedor"": ""@tipoProveedor"",
                                      ""codigoProveedor"": ""@codigoProveedor"",
                                      ""nombre"": ""@name"",
                                      ""descripcion"": ""@description"",
                                      ""categoria"": ""@brand_name"",
                                      ""urlImagen"": ""@image_url"",
                                      ""precio"": ""@price"",
                                      ""moneda"": ""@moneda"",
                                      ""inventario"": ""@inventario"",
                                      ""disponibilidad"": ""@availability""
                                    }]";

                //dynamic alertObj = JsonConvert.DeserializeObject(respuestaJSON);
                var routes_list = (Dictionary<string, object>)JsonConvert.DeserializeObject(respuestaJSON);

                foreach (var item in routes_list)
                {
                    template.Replace("@" + item.Key, item.Value.ToString());
                }

                string formatoEsperadoJSON = @"
                [
                    {
                        ""id"": 100,
                        ""codigo"": ""NS"",
                        ""fabricante"": ""NINTENDO"",
                        ""tipoProveedor"": ""Externo"",
                        ""codigoProveedor"": ""Exito"",
                        ""nombre"": ""Nintendo Switch Diablo Edition"",
                        ""descripcion"": ""<p><span>Lorem ipsum dolor sit amet consectetur adipiscing elit. Morbi vel metus ac est egestas porta sed quis erat. Integer id nulla massa. Proin vitae enim nisi. Praesent non dignissim nulla. Nulla mattis id massa ac pharetra. Mauris et nisi in dolor aliquam sodales. Aliquam dui nisl dictum quis leo sit amet rutrum volutpat metus. Curabitur libero nunc interdum ac libero non tristique porttitor metus. Ut non dignissim lorem in vestibulum leo. Vivamus sodales quis turpis eget.</span></p>"",
                        ""categoria"": ""Common Good"",
                        ""urlImagen"": ""1.png"",
                        ""precio"": 0,
                        ""moneda"": ""COP"",
                        ""inventario"": 0,
                        ""disponibilidad"": ""NODISPONIBLE""
                    },
                    {
                        ""id"": 102,
                        ""codigo"": ""PS"",
                        ""fabricante"": ""SONY"",
                        ""tipoProveedor"": ""Externo"",
                        ""codigoProveedor"": ""Exito"",
                        ""nombre"": ""Nintendo Switch Animal Crossing Edition"",
                        ""descripcion"": ""Portable"",
                        ""categoria"": ""Consolas"",
                        ""urlImagen"": ""1.png"",
                        ""precio"": 900000,
                        ""moneda"": ""COP"",
                        ""inventario"": 0,
                        ""disponibilidad"": ""DISPONIBLE""
                    }
                ]";

                objetoLocal = JsonConvert.DeserializeObject<List<ProductoDTO>>(formatoEsperadoJSON);

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
                    JSONRequest: body,
                    JSONmethod: "POST",
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