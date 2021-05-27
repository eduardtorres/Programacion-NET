using OrdenesCore.DTO;
using OrdenesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrdenesInfraestructure.WebServices
{
    public class RestClientInventario : IRestClientInventario
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RestClientInventario(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<long> RemoveProductInventory(IList<DetalleOrden> listaProductos)
        {

            foreach (var elemento in listaProductos)
            {
                var productoJson = new StringContent(JsonSerializer.Serialize(elemento), Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient("descargarInventario");
                var result = await client.PostAsync($"/Prod/inventario/descargar/{elemento.ProductoId}", productoJson);
                if (result.IsSuccessStatusCode)
                {
                    var responseStream = await result.Content.ReadAsStreamAsync();
                    var responseList = await JsonSerializer.DeserializeAsync<ResponseDescargarInventario>(responseStream);
                    if (responseList.codigo == 1)
                        //elemento.OrdenProveedorId = responseList.ordenId;
                        return 1;
                    return 0;
                }
                return 0;
            }
            return 0;
        }



    }
}
