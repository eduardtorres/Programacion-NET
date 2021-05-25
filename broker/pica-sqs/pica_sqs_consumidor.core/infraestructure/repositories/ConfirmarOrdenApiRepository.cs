using System;
using System.Threading.Tasks;
using pica_sqs_consumidor.core.domain.entities;
using pica_sqs_consumidor.core.domain.interfaces;
using Util;

namespace pica_sqs_consumidor.core.infraestructure.repositories
{
    public class ConfirmarOrdenApiRepository : IConfirmarOrdenApiRepository
    {
        string baseUrl;

        public ConfirmarOrdenApiRepository(string _baseUrl)
        {
            baseUrl = _baseUrl;
        }

        public async Task<ConfirmarOrdenResponse> ExecuteApi(string OrdenMensaje)
        {
            RestClient restClient = new RestClient();

            string finalUrl = baseUrl + "/orden/confirmar";

            var response = await restClient.MakeRequest<ConfirmarOrdenResponse>
                (requestUrlApi: finalUrl,
                JSONobject: OrdenMensaje,
                JSONmethod: "POST" ,
                JSONContentType: "application/json",
                msTimeOut: -1);

            return response;
        }

    }
}
