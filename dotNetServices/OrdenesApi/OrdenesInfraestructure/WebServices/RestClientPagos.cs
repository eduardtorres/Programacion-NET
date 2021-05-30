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
    public class RestClientPagos : IRestClientPagos
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RestClientPagos(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> AuthPaymentOrden(DatosPago datosPago)
        {
            
            var pagoJson = new StringContent(JsonSerializer.Serialize(datosPago), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient("autorizarPago");
            var result = await client.PostAsync($"Prod/pago/orden/authorizar", pagoJson);
            if (result.IsSuccessStatusCode)
            {
                var responseStream = await result.Content.ReadAsStreamAsync();
                var response = await JsonSerializer.DeserializeAsync<int>(responseStream);
                if (response > 0 )
                    return response;
                return 0;
            }
            return 0;
        }
    }
}
