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
            RequestDescargarInventario requestDescargarInventario = new RequestDescargarInventario();
            foreach (var elemento in listaProductos)
            {
                requestDescargarInventario.codigo = elemento.CodigoProducto;
                requestDescargarInventario.codigoProveedor = elemento.CodigoProveedor;
                requestDescargarInventario.CantidadOrdenada = elemento.CantidadOrdenada;
                requestDescargarInventario.tipoProveedor = elemento.TipoProveedor;
                var productoJson = new StringContent(JsonSerializer.Serialize(requestDescargarInventario), Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient("descargarInventario");
                var result = await client.PutAsync($"/Prod/inventario/descargar/{elemento.ProductoId}", productoJson);
                if (!result.IsSuccessStatusCode)
                    return 0;
                var responseStream = await result.Content.ReadAsStreamAsync();
                var responseList = await JsonSerializer.DeserializeAsync<ResponseDescargarInventario>(responseStream);
                if (responseList.codigo == 0)
                    return 0;
                elemento.OrdenProveedorId = responseList.ordenId;
            }
            return 1;
        }



    }
}
