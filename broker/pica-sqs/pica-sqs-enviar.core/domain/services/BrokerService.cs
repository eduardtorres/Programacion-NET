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

        public async Task<ResponseBase> enviarOrden(Orden orden)
        {
            var response = new ResponseBase();
            try
            {
                if (orden.DetallesOrden != null)
                {
                    orden.Id = await iSecuenciaRepository.GetOrderId();
                }
                else
                {
                    orden.Id = -1;
                }                
                response.message = await iSQSRepository.SendMessage(orden);
                response.code = 1;
                response.orderId = orden.Id;
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                response.code = 0;
                response.orderId = 0;
            }
            return response;
        }
    }
}
