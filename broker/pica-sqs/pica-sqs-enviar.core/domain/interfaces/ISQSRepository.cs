using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pica_sqs_enviar.core.domain.entities;

namespace pica_sqs_enviar.core.domain.interfaces
{
    public interface ISQSRepository
    {
        Task<string> SendMessage(Orden orden);
    }
}
