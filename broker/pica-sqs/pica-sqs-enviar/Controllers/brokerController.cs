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
            var response = new ResponseBase();

            try
            {
                if (orden.DetallesOrden == null) throw new Exception("orden.DetallesOrden == null");

                orden.Id = await iBrokerService.GetOrderId();

                response.message = await iBrokerService.SendMessage(orden);
                response.code = 1;
                response.orderId = orden.Id;
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                response.code = 0;
                response.orderId = 0;
            }
            
            return Ok(response);
        }

        [HttpPost("orden/test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> enviarTest()
        {

            string responseStr;

            try
            {
                string strBody = await (new System.IO.StreamReader(Request.Body)).ReadToEndAsync();
                responseStr = strBody;
            }
            catch (Exception ex)
            {
                responseStr = ex.ToString();
            }

            var response = new ResponseBase();
            response.message = responseStr;
            return Ok(response);
        }

    }
}