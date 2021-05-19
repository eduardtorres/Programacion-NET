using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using ProductosInfraestructure.Data;
using System.Linq;

namespace ProductosInfraestructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {        
        ProductContext _productContext;
        public ProductosRepository(ProductContext context)
        {            
            _productContext = context;
        }        

        public async Task<IList<Productos>> ListarProductos(string filtro)
        {
            var lista = _productContext.Productos.ToList();
            return await Task.FromResult(lista);
        }

        public async Task<int> UpdateProducto(ProductoDto newProducto)
        {
            var producto = _productContext.Productos.Where(x => x.Id == newProducto.Id).FirstOrDefault();
            if( producto != null )
            {
                producto.Inventario = newProducto.Inventario;
                return await _productContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
