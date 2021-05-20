using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCore.Interfaces
{
    public interface IUnitOfWork
    {
        public void Confirmar();
        public Task ConfirmarAsync();
    }
}
