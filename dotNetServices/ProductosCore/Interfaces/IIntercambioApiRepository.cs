using System;
using System.Threading.Tasks;
using ProductosCore.Entities;

namespace ProductosCore.Interfaces
{
    public interface IIntercambioApiRepository
    {
        Task<IntercambioResponse> Obtener(string moneda);
    }
}
