using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using pica_sqs_enviar.core.domain.entities;
using pica_sqs_enviar.core.domain.interfaces;

namespace pica_sqs_enviar.core.infraestructure.persistence
{
    public class SQSRepository : ISQSRepository
    {
        public async Task<string> SendMessage(Orden orden)
        {
            string strBody = JsonConvert.SerializeObject(orden);

            var client = new AmazonSQSClient();

            var sendMessageRequest = new SendMessageRequest
            {
                MessageAttributes = new Dictionary<string, MessageAttributeValue>
                    {
                        {
                            "orderid", new MessageAttributeValue
                            { DataType = "String", StringValue = orden.Id.ToString() }
                        }
                    },
                MessageBody = strBody,
                QueueUrl = "https://sqs.us-east-2.amazonaws.com/528726598722/pica-ordenes-queue.fifo",
                MessageDeduplicationId = orden.Id.ToString(),
                MessageGroupId = "ordenes-queue"
            };

            var sendMessageResponse = await client.SendMessageAsync(sendMessageRequest);

            return sendMessageResponse.MessageId;
        }
    }
}
