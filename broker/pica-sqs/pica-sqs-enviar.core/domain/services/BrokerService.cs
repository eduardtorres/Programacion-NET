using System;
using System.Threading.Tasks;
using pica_sqs_enviar.core.domain.entities;
using pica_sqs_enviar.core.domain.interfaces;

namespace pica_sqs_enviar.core.domain.services
{
    public class BrokerService : IBrokerService
    {
        ISecuenciaRepository iSecuenciaRepository;
        ISQSRepository iSQSRepository;

        public BrokerService(ISecuenciaRepository _iSecuenciaRepository,
            ISQSRepository _iSQSRepository)
        {
            iSecuenciaRepository = _iSecuenciaRepository;
            iSQSRepository = _iSQSRepository;
        }

        public async Task<string> SendMessage(Orden orden)
        {
            return await iSQSRepository.SendMessage(orden);
        }

        public async Task<int> GetOrderId()
        {
            return await iSecuenciaRepository.GetOrderId();
        }
    }
}
