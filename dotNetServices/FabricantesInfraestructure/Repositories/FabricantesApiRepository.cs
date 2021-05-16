using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricantesCore.DTO;
using FabricantesCore.Interfaces;
using Newtonsoft.Json;
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

    }
}
