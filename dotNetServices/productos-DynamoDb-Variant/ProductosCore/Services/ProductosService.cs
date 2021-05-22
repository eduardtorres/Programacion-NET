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
        private IIntercambioApiRepository _iIntercambioApiRepository;

        public ProductosService(IProductosRepository productosRepository,
            IIntercambioApiRepository iIntercambioApiRepository)
        {
            _productosRepository = productosRepository;
            _iIntercambioApiRepository = iIntercambioApiRepository;
        }

        public async Task<IList<ProductoDto>> ListarProductos(string moneda, string filtro )
        {

            IntercambioResponse intercambioResponse = await _iIntercambioApiRepository.Obtener(moneda);

            var lista = await _productosRepository.ListarProductos(filtro);

            filtro = filtro.ToLower();

            var productos =  lista
                .Where(x => (x.Nombre.ToLower().Contains(filtro) || x.Categoria.ToLower().Contains(filtro) || filtro == "all" ))
                .Select(
                x => new ProductoDto()
                {
                    id = x.Id,
                    codigo = x.Codigo,
                    fabricante = x.Fabricante,
                    tipoProveedor = x.TipoProveedor,
                    codigoProveedor = x.CodigoProveedor,
                    nombre = x.Nombre,
                    descripcion = x.Descripcion,
                    categoria = x.Categoria,
                    urlImagen = x.UrlImagen,
                    precio = x.Precio * intercambioResponse.valUSD,
                    moneda = moneda,
                    inventario = x.Inventario,
                    precioOriginal = x.Precio,
                    monedaOriginal = x.Moneda,
                    disponibilidad = ( x.Inventario > 0 ? "DISPONIBLE" : "NODISPONIBLE" )
                }
                );

            return productos.ToList();
        }

        public async Task<int> AgregarProducto(List<ProductoDto> newProducto)
        {
            foreach(var item in newProducto )
                await _productosRepository.AgregarProducto(item);
            return newProducto.Count();
        }

        public async Task<int> UpdateProducto(ProductoDto newProducto)
        {
            return await _productosRepository.UpdateProducto(newProducto);
        }

    }
}
