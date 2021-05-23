using OrdenesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using OrdenesCore.Entities;
using System.Threading.Tasks;
using OrdenesInfraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OrdenesInfraestructure.Repositories
{
    public class DetalleOrdenesRepository : IAsyncRepository<DetalleOrdenes>
    {
        protected readonly DataContext _dbContext;

        public DetalleOrdenesRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DetalleOrdenes> AddAsync(DetalleOrdenes entity)
        {
            await _dbContext.DetalleOrden.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<DetalleOrdenes>> AddRangeAsync(IList<DetalleOrdenes> entity)
        {
            await _dbContext.DetalleOrden.AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(DetalleOrdenes entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DetalleOrdenes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DetalleOrdenes>> GetByCustomerAsync(string emailCliente)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleOrdenes> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<DetalleOrdenes>> GetOrdenDetailByOrdenIdAsync(long ordenId)
        {
            try
            {
                return await _dbContext.DetalleOrden.Where(resultado => resultado.OrdenId == ordenId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task UpdateAsync(DetalleOrdenes entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
