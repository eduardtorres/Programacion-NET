using System;
namespace pica_sqs_consumidor.core.domain.entities
{
    public class OrdenQueueEvent
    {
        public string messageid { get; set; }
        public string fecha { get; set; }
        public string request { get; set; }
        public string response { get; set; }
    }
}
