using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;
using ProveedoresCore.Interfaces;
using Newtonsoft.Json;
using RESTConector.Util;
using SOAPConector.Util;

namespace ProveedoresInfraestructure.Repositories
{
    public class ProveedoresApiRepository : IProveedoresApiRepository
    {
        public ProveedoresApiRepository()
        {

        }

        public async Task<IList<ProductoDTO>> BuscarProductos(string filtro, ProveedorEntity fabricanteEntity)
        {


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

                List<ProductoDTO> objetoLocal = JsonConvert.DeserializeObject<List<ProductoDTO>>(formatoEsperadoJSON);

                return objetoLocal;

            }
            else if (fabricanteEntity.TipoApi == "SOAP")
            {
                SoapClient soapClient = new SoapClient(fabricanteEntity.UrlServicio, string.Empty);
                await soapClient.PostAsync("POST");
                return null;
            }

            return null;
        }

    }
}