using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace pica_sqs_consumidor
{
    public class Function
    {

        IDynamoDBContext DDBContext { get; set; }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(SQSEvent sqsEvent, ILambdaContext context)
        {
            int count = 0;

            if (sqsEvent.Records != null)
            {
                foreach( var singleEvent in sqsEvent.Records )
                {

                    EventoBE eventoBE = new EventoBE();
                    eventoBE.messageid = singleEvent.MessageId;
                    eventoBE.fecha = DateTime.Now.ToUniversalTime().AddHours(-5).ToString("s");
                    eventoBE.message = singleEvent.Body;

                    var tableName = "OrdenesQueue";
                    AWSConfigsDynamoDB.Context.TypeMappings[typeof(EventoBE)] = new Amazon.Util.TypeMapping(typeof(EventoBE), tableName);

                    var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };
                    this.DDBContext = new DynamoDBContext(new AmazonDynamoDBClient(), config);

                    Task t = DDBContext.SaveAsync<EventoBE>(eventoBE);
                    t.Wait();

                }
            }

            return "ok:" + count.ToString();

        }
    }

    public class EventoBE
    {
        public string messageid { get; set; }
        public string fecha { get; set; }
        public string message { get; set; }
    }
}
