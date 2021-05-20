using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrdenesCore.Interfaces;
using OrdenesInfraestructure.Data;

namespace OrdenesInfraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Confirmar()
        {
            _dbContext.SaveChanges();
        }

        public async Task ConfirmarAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
