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

        public async Task<IList<ProductoDto>> ListarProductos(string moneda, string filtro )
        {
            IList<Producto> lista = await iProductosRepository.ListarProductos(filtro);
            
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
                    Disponibilidad = ( x.Inventario > 0 ? "DISPONIBLE" : "NODISPONIBLE" )
                }
                );

            return productos.ToList();
        }
    }
}
