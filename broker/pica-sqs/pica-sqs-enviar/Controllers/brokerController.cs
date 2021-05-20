using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pica_sqs_enviar.Model;

namespace pica_sqs_enviar.Controllers
{
    [Route("broker")]
    [ApiController]
    public class brokerController : ControllerBase
    {

        [HttpPost("orden/colocar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> enviarOrden()
        {

            var response = new ResponseBase();

            try
            {
                string strBody = await (new System.IO.StreamReader(Request.Body)).ReadToEndAsync();

                var client = new AmazonSQSClient();

                var request = new SendMessageRequest
                {
                    DelaySeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds,
                    MessageAttributes = new Dictionary<string, MessageAttributeValue>
                    {
                        {
                            "orderid", new MessageAttributeValue
                            { DataType = "String", StringValue = "1" }
                        }
                    },
                    MessageBody = strBody,
                    QueueUrl = "https://sqs.us-east-2.amazonaws.com/528726598722/pica-queue"
                };

                var sendMessageResponse = await client.SendMessageAsync(request);
                response.message = sendMessageResponse.MessageId;
                response.code = 1;
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                response.code = 0;
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