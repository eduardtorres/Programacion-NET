using System;
using System.Threading.Tasks;
using pica_sqs_enviar.core.domain.interfaces;

namespace pica_sqs_enviar.core.domain.services
{
    public class BrokerService : IBrokerService
    {
        ISecuenciaRepository iSecuenciaRepository;

        public BrokerService(ISecuenciaRepository _iSecuenciaRepository)
        {
            iSecuenciaRepository = _iSecuenciaRepository;
        }

        public async Task<int> GetOrderId()
        {
            return await iSecuenciaRepository.GetOrderId();
        }
    }
}
