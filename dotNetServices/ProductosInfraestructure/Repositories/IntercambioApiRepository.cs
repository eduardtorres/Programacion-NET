using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProductosCore.Entities;
using ProductosCore.Interfaces;

namespace ProductosInfraestructure.Repositories
{
    public class IntercambioApiRepository : IIntercambioApiRepository
    {
        IConfiguration configuration;
        public IntercambioApiRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<IntercambioResponse> Obtener( string moneda )
        {
            string apiUrl = configuration["ApiGatewayUrl"] + "/precio/tasa/obtener/" + moneda ;

            IntercambioResponse response;

            Util.RestClient restClient = new Util.RestClient();

            try
            {
                response = await restClient.MakeGetRequest<IntercambioResponse>(requestUrlApi: apiUrl, JSONobject: null, msTimeOut: 10000);
            }
            catch(Exception ex)
            {
                response = new IntercambioResponse();
                response.valUSD = 1;
            }

            return response;
        }
    }
}
