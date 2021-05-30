using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using System.Linq;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon;
using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using System;

namespace ProductosInfraestructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {        
        public ProductosRepository()
        {
        }

        IDynamoDBContext DDBContext { get; set; }

        public async Task<IList<Productos>> ListarProductos(string filtro)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();

            List<string> attr = new List<string>();
            attr.Add("Data");
            attr.Add("Inventario");

            var response = await client.ScanAsync("Productos", attr);

            List<Productos> productos = new List<Productos>();

            foreach( var item in response.Items )
            {
                AttributeValue avData = item["Data"];
                AttributeValue avInventario = item["Inventario"];
                Productos producto = JsonConvert.DeserializeObject<Productos>(avData.S);
                producto.Inventario = Convert.ToInt32( avInventario.N ) ;
                productos.Add(producto);
            }
            return productos;
        }

        public async Task<int> AgregarProducto(ProductoDto newProducto)
        {
                var temporalProducto = new ProductoData()
                {
                    Id = newProducto.id,
                    Data = JsonConvert.SerializeObject(newProducto),
                    Inventario = newProducto.inventario
                };

                var tableName = "Productos";
                AWSConfigsDynamoDB.Context.TypeMappings[typeof(ProductoData)] = new Amazon.Util.TypeMapping(typeof(ProductoData), tableName);

                var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };
                this.DDBContext = new DynamoDBContext(new AmazonDynamoDBClient(), config);

                await DDBContext.SaveAsync<ProductoData>(temporalProducto);

                return 1;
        }

        public async Task<int> UpdateProducto(ProductoDto newProducto)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "Productos";

            var request = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { N = newProducto.id.ToString() } } },
                ExpressionAttributeNames = new Dictionary<string, string>()
    {
        {"#I", "Inventario"}
    },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
    {
        {":inventario",new AttributeValue {N = newProducto.inventario.ToString()}}
    },

                UpdateExpression = "SET #I = :inventario"
            };
            var response = await client.UpdateItemAsync(request);

            return 1;
        }

        public async Task<int> ObtenerPrioridadLocal()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "Configuracion";

            var request = new QueryRequest
            {
                TableName = tableName,
                KeyConditionExpression = "nombre = :v_nombre",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":v_nombre", new AttributeValue { S =  "prioridad" }}}
            };

            var response = await client.QueryAsync(request);

            int prioridad = 0;

            foreach (Dictionary<string, AttributeValue> item in response.Items)
            {
                AttributeValue cellValue = item["valor"];
                prioridad = Convert.ToInt32(cellValue.N);
            }

            return prioridad;
        }

    }

    public class ProductoData
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int Inventario { get; set; }
    }
}
