using OrdenesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using OrdenesCore.DTO;

namespace OrdenesInfraestructure.WebServices
{
    public class RestClientCarritoCompras : IRestClientCarritoCompras
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RestClientCarritoCompras(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> GetProductAvailability(long CarritoId)
        {
            var client = _httpClientFactory.CreateClient("disponibilidad");
            var result = await client.GetAsync($"Prod/carrito/productos/disponibilidad/{CarritoId}");
            if (result.IsSuccessStatusCode) 
            {
                var responseStream = await result.Content.ReadAsStreamAsync();
                var responseList = await JsonSerializer.DeserializeAsync<List<ResponseAvailabilityCarritoCompras>> (responseStream);
                foreach (var parameter in responseList)
                {
                    if (parameter.disponibilidad == "NODISPONIBLE")
                        return false;                   
                }
                return true;
            }
            return false;
        }
    }
}
