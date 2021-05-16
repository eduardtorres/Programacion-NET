using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
