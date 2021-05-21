using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.Entities;
using ProductosCore.Interfaces;

namespace ProductosInfraestructure.Repositories
{
    public class IntercambioApiRepository : IIntercambioApiRepository
    {
        string apiUrl;

        Dictionary<string, IntercambioResponse> cache;

        public IntercambioApiRepository(string _apiUrl)
        {
            apiUrl = _apiUrl;
        }

        public async Task<IntercambioResponse> Obtener( string moneda )
        {            
            IntercambioResponse response;

            if (cache == null)
                cache = new Dictionary<string, IntercambioResponse>();

            if(cache.ContainsKey(moneda))
            {
                return cache[moneda];
            }

            try
            {
                Util.RestClient restClient = new Util.RestClient();
                string finalUrl = apiUrl + "/precio/tasa/obtener/" + moneda;
                response = await restClient.MakeGetRequest<IntercambioResponse>(requestUrlApi: finalUrl, JSONobject: null, msTimeOut: 10000);
                cache[moneda] = response;
            }
            catch
            {
                response = new IntercambioResponse();
                response.valUSD = 1;
            }
            
            return response;
        }
    }
}
