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

        public async Task<IList<Producto>> ListarProductos(string filtro)
        {
            var lista = _productContext.Producto.ToList();
            return await Task.FromResult(lista);
        }
    }
}
