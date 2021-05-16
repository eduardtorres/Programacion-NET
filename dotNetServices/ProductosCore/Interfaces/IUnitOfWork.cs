
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Interfaces
{
    public interface IUnitOfWork
    {
        void Confirmar();
        Task CofirmarAsync();
    }
}
