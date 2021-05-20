using System;
using System.Collections.Generic;
using System.Text;
using OrdenesCore.Interfaces;
using OrdenesCore.Entities;
using System.Threading.Tasks;
using OrdenesInfraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OrdenesInfraestructure.Repositories
{
    public class OrdenesRepository : IAsyncRepository<Ordenes>
    {
        protected readonly DataContext _dbContext;

        public OrdenesRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ordenes> AddAsync(Ordenes entity)
        {
            await _dbContext.Ordenes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(Ordenes resultado)
        {
              _dbContext.Ordenes.Remove(resultado);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<Ordenes> GetByIdAsync(long id)
        {
            return await _dbContext.Ordenes.FindAsync(id);
        }

        public async Task<IReadOnlyList<Ordenes>> GetAllAsync()
        {
            return await _dbContext.Ordenes.ToListAsync();
        }

        public async Task UpdateAsync(Ordenes entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public Task<IList<Ordenes>> AddRangeAsync(IList<Ordenes> entity)
        {
            throw new NotImplementedException();
        }
    }
}
