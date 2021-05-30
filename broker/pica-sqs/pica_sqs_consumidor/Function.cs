using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Newtonsoft.Json;
using pica_sqs_consumidor.core.domain.entities;
using pica_sqs_consumidor.core.domain.interfaces;
using pica_sqs_consumidor.core.infraestructure.repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace pica_sqs_consumidor
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(SQSEvent sqsEvent, ILambdaContext context)
        {

            IOrdenesQueueRepository ordenesQueueRepository = new OrdenesQueueRepository();
            IConfirmarOrdenApiRepository confirmarOrdenApiRepository
                = new ConfirmarOrdenApiRepository("https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod");

            int count = 0;

            if (sqsEvent.Records != null)
            {
                foreach( var singleEvent in sqsEvent.Records )
                {

                    ConfirmarOrdenResponse orden;

                    string body = singleEvent.Body;

                    try
                    {
                        orden = JsonConvert.DeserializeObject<ConfirmarOrdenResponse>(body);
                    }
                    catch
                    {
                        orden = new ConfirmarOrdenResponse()
                        {
                            Id = 0
                        };
                    }

                    string response = string.Empty;

                    if( orden.Id > 0 )
                    {
                        try
                        {
                            var confirmarResponse =
                                confirmarOrdenApiRepository.ExecuteApi(body).GetAwaiter().GetResult();

                            response = JsonConvert.SerializeObject(confirmarResponse);
                        }
                        catch(Exception ex)
                        {
                            response = ex.ToString();
                        }
                    }

                    if (orden.Id >= 0)
                    {
                        OrdenQueueEvent ordenQueueEvent = new OrdenQueueEvent();
                        ordenQueueEvent.messageid = singleEvent.MessageId;
                        ordenQueueEvent.fecha = DateTime.Now.ToUniversalTime().AddHours(-5).ToString("s");
                        ordenQueueEvent.request = body;
                        ordenQueueEvent.response = response;

                        ordenesQueueRepository.InsertEvent(ordenQueueEvent).GetAwaiter().GetResult();
                    }

                }
            }

            return "ok:" + count.ToString();

        }
    }
}
