using System;
using System.Threading.Tasks;

namespace pica_sqs_enviar.core.domain.interfaces
{
    public interface IBrokerService
    {
        Task<int> GetOrderId();
    }
}
