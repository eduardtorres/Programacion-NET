using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCore.Interfaces
{
    public interface IRestClientCarritoCompras
    {
        public Task<bool> GetProductAvailability(long CarritoId);

    }
}
