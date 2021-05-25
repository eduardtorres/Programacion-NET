using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using pica_sqs_consumidor.core.domain.entities;
using pica_sqs_consumidor.core.domain.interfaces;

namespace pica_sqs_consumidor.core.infraestructure.repositories
{
    public class OrdenesQueueRepository : IOrdenesQueueRepository
    {

        IDynamoDBContext DDBContext { get; set; }

        public async Task<bool> InsertEvent(OrdenQueueEvent ordenQueueEvent)
        {
            var tableName = "OrdenesQueue";
            AWSConfigsDynamoDB.Context.TypeMappings[typeof(OrdenQueueEvent)] = new Amazon.Util.TypeMapping(typeof(OrdenQueueEvent), tableName);

            var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };
            this.DDBContext = new DynamoDBContext(new AmazonDynamoDBClient(), config);

            await DDBContext.SaveAsync<OrdenQueueEvent>(ordenQueueEvent);

            return true;
        }
    }
}
