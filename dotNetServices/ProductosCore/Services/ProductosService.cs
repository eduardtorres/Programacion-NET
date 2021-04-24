using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using System.Linq;

namespace ProductosCore.Services
{
    public class ProductosService : IProductosService
    {
        IProductosRepository iProductosRepository;

        public ProductosService(IProductosRepository _iProductosRepository)
        {
            iProductosRepository = _iProductosRepository;
        }

        public async Task<ListarProductosResponse> ListarProductos( ListarProductosRequest request )
        {
            IReadOnlyList<Producto> lista = await iProductosRepository.ListarProductos(request);

            ListarProductosResponse response = new ListarProductosResponse();

            var productos = lista.
                Select(
                x => new ProductoDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Precio = x.Precio
                }
                );

            response.productos = productos.ToList();

            return response;
        }
    }
}
