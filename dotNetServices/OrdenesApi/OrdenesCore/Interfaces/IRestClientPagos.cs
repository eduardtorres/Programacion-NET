using OrdenesCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCore.Interfaces
{
    public interface IRestClientPagos
    {
        public Task<int> AuthPaymentOrden(DatosPago datosPago);
    }
}
