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
        private IProveedoresApiRepository _iProveedoresApiRepository;

        public ProductosService(IProductosRepository productosRepository,
            IIntercambioApiRepository iIntercambioApiRepository,
            IProveedoresApiRepository iProveedoresApiRepository)
        {
            _productosRepository = productosRepository;
            _iIntercambioApiRepository = iIntercambioApiRepository;
            _iProveedoresApiRepository = iProveedoresApiRepository;
        }

        public async Task<IList<ProductoDto>> ListarProductos(string moneda, string filtro )
        {

            var task_intercambioResponse = _iIntercambioApiRepository.Obtener(moneda);
            var task_productos_proveedores = _iProveedoresApiRepository.ListarProductos(filtro);
            var task_lista_productos = _productosRepository.ListarProductos(filtro);
            var task_prioridad = _productosRepository.ObtenerPrioridadLocal();

            List<Task> listaprocesos = new List<Task>();
            listaprocesos.Add(task_intercambioResponse);
            listaprocesos.Add(task_productos_proveedores);
            listaprocesos.Add(task_lista_productos);
            listaprocesos.Add(task_prioridad);

            await Task.WhenAll(listaprocesos);

            var intercambioResponse = task_intercambioResponse.Result;
            var lista_productos = task_lista_productos.Result;
            var lista_proveedores = task_productos_proveedores.Result;
            int prioridad_local = task_prioridad.Result;
            
            filtro = filtro.ToLower();

            var productosDto = lista_productos
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
                    precio = x.Precio,
                    inventario = x.Inventario,
                    precioOriginal = x.Precio,
                    monedaOriginal = x.Moneda,
                    prioridad = prioridad_local                   
                }
                );

            List<ProductoDto> merge = productosDto.ToList();
            merge.AddRange(lista_proveedores);

            var ordenada = merge
                .Where(x => (x.nombre.ToLower().Contains(filtro) || x.categoria.ToLower().Contains(filtro) || filtro == "all"))
                .OrderBy(x => x.prioridad);

            var final = ordenada.ToList();

            final.ForEach(x =>
           {
               x.moneda = moneda;
               x.precio = x.precio * intercambioResponse.valUSD;
               x.disponibilidad = (x.inventario > 0 ? "DISPONIBLE" : "NODISPONIBLE");
               if (string.IsNullOrEmpty(x.urlImagen))
                   x.urlImagen = "ud.png";
           });

            return final;
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
