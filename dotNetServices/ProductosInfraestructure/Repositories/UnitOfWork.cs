using ProductosCore.Interfaces;
using ProductosInfraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosInfraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _productContext;
        public UnitOfWork(ProductContext productContext)
        {
            _productContext = productContext;
        }        
        public void Confirmar()
        {
            _productContext.SaveChanges();
        }
        public async Task CofirmarAsync()
        {
            await _productContext.SaveChangesAsync();
        }
    }
}
