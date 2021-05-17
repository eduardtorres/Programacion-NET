using ProveedoresCore.Entities;
using ProveedoresCore.Interfaces;
using ProveedoresInfraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace ProveedoresInfraestructure.Repositories
{
    public class ProveedoresRepository : IProveedoresRepository
    {
        ProvidersContext _providersContext;
        public ProveedoresRepository(ProvidersContext context)
        {
            _providersContext = context;
        }
        public async Task<IList<ProveedorEntity>> ListarProveedores()
        {
            var lista = _providersContext.Proveedores.ToList();
            return await Task.FromResult(lista);
        }

        public async Task<IList<ProductoEntity>> ListarProductosProveedores(long IdProveedor)
        {
            var lista = (from i in _providersContext.Proveedores
                         where i.IdProveedor == IdProveedor
                         select i).ToList();                
            return await Task.FromResult(new List<ProductoEntity>());
        }

        public async Task<IList<InventarioEntity>> ConsultarInventario(IList<ProductoEntity> productos)
        {
            var lista = (from i in _providersContext.Proveedores                        
                         select i).ToList();
            return await Task.FromResult(new List<InventarioEntity>());
        }
    }
}
