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
    public class RestClientBroker : IRestClientBroker
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RestClientBroker(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<long> CreateOrdenBroker(Orden orden)
        {

            var ordenJson = new StringContent(JsonSerializer.Serialize(orden), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient("colocarOrdenBroker");
            var result = await client.PostAsync($"Prod/broker/orden/colocar", ordenJson);
            if (result.IsSuccessStatusCode)
            {
                var responseStream = await result.Content.ReadAsStreamAsync();
                var responseList = await JsonSerializer.DeserializeAsync<ResponseCreateOrdenBroker>(responseStream);
                if (responseList.code == 1)
                    //return true;
                    return responseList.orderId;
                return 0;
            }
            return 0;
        }
    }
}