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
        private IProductosRepository _productosRepository;        

        public ProductosService(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;            
        }

        public async Task<IList<ProductoDto>> ListarProductos(string moneda, string filtro )
        {
            var lista = await _productosRepository.ListarProductos(filtro);            

            var productos = lista.
                Select(
                x => new ProductoDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Fabricante = x.Fabricante,
                    TipoProveedor = x.TipoProveedor,
                    CodigoProveedor = x.CodigoProveedor,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Categoria = x.Categoria,
                    UrlImagen = x.UrlImagen,
                    Precio = x.Precio,
                    Moneda = x.Moneda,
                    Inventario = x.Inventario,
                    PrecioLocal = 500000,
                    MonedaLocal = "COP",
                    Disponibilidad = ( x.Inventario > 0 ? "DISPONIBLE" : "NODISPONIBLE" )
                }
                );

            return productos.ToList();
        }
    }
}
