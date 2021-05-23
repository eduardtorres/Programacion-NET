using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using pica_sqs_enviar.core.domain.interfaces;

namespace pica_sqs_enviar.core.infraestructure.persistence
{
    public class SecuenciaRepository : ISecuenciaRepository
    {


        public async Task<int> GetOrderId()
        {

            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "Secuencias";


            var request = new QueryRequest
            {
                TableName = tableName,
                KeyConditionExpression = "Id = :v_Id",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":v_Id", new AttributeValue { S =  "Orden" }}}
            };

            var response = await client.QueryAsync(request);

            int nextOrderId = 0;

            foreach (Dictionary<string, AttributeValue> item in response.Items)
            {
                AttributeValue avSecuencia = item["nextSecuencia"];
                nextOrderId = Convert.ToInt32( avSecuencia.N );
            }
            
            var requestUpdate = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { S = "Orden" } } },
                ExpressionAttributeNames = new Dictionary<string, string>()
    {
        {"#NS", "nextSecuencia"}
    },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
    {
        {":NS",new AttributeValue {N = ( nextOrderId + 1 ).ToString() }},
        {":OS",new AttributeValue {N = ( nextOrderId ).ToString() }}
    },
                ConditionExpression = "#NS = :OS",

                UpdateExpression = "SET #NS = :NS"
            };

            var responseUpdate = await client.UpdateItemAsync(requestUpdate);

            return nextOrderId;

        }
    }
}
