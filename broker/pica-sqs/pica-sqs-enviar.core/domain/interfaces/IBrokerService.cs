using System;
using System.Threading.Tasks;
using pica_sqs_enviar.core.domain.entities;

namespace pica_sqs_enviar.core.domain.interfaces
{
    public interface IBrokerService
    {
        Task<ResponseBase> enviarOrden(Orden orden);
    }
}
