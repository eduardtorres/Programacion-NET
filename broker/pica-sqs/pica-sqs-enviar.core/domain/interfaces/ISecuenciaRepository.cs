using System;
using System.Threading.Tasks;

namespace pica_sqs_enviar.core.domain.interfaces
{
    public interface ISecuenciaRepository
    {
        public Task<int> GetOrderId();
    }
}
