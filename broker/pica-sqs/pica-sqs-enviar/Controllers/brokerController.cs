using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pica_sqs_enviar.core.domain.entities;
using pica_sqs_enviar.core.domain.interfaces;

namespace pica_sqs_enviar.Controllers
{
    [Route("broker")]
    [ApiController]
    public class brokerController : ControllerBase
    {
        IBrokerService iBrokerService;

        public brokerController(IBrokerService _iBrokerService)
        {
            iBrokerService = _iBrokerService;
        }

        [HttpPost("orden/colocar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> enviarOrden(Orden orden)
        {                        
            return Ok(await iBrokerService.enviarOrden(orden));
        }
    }
}