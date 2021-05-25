using System;
using System.Threading.Tasks;
using pica_sqs_consumidor.core.domain.entities;

namespace pica_sqs_consumidor.core.domain.interfaces
{
    public interface IOrdenesQueueRepository
    {
        Task<bool> InsertEvent(OrdenQueueEvent ordenQueueEvent);
    }
}
