using System;

namespace pica_sqs_enviar.core.domain.entities
{
    public class ResponseBase
    {
        public long orderId { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
