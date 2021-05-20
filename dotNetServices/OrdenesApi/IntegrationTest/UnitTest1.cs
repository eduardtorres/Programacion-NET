using MySql.Data.MySqlClient.Memcached;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using MySqlX.XDevAPI;
using Xunit.Abstractions;
using System.Net;

namespace IntegrationTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        private static readonly HttpClient client = new HttpClient();
        
        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Theory]
        [InlineData("https://api.github.com/orgs/dotnet/repos")]
        [InlineData("https://api.github.com/orgs/dotnet/repo")]
        public async Task Test1(string url)
        {
 
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            try
            {
                var stringTask = client.GetStringAsync(url);

                var msg = await stringTask;
                output.WriteLine(msg);
                Assert.NotNull(msg);
            } catch (HttpRequestException ex)
            {
                output.WriteLine("Message :{0}", ex.Message);
                Assert.Contains("404", ex.Message);
            }
        }

        [Theory]
        [InlineData("https://api.github.com/orgs/dotnet/repos")]
        [InlineData("https://api.github.com/orgs/dotnet/repo")]
        public async Task Test2(string url)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); //asegurar que se va cuando el resultado es exitoso (Codigo 200)
                var msg = await response.Content.ReadAsStringAsync();
                foreach (var header in response.Headers)
                {
                    output.WriteLine("{0} : {1}", header.Key, header.Value);
                }
                Assert.NotNull(msg);
                Assert.True(HttpStatusCode.OK == response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                output.WriteLine("Message :{0}", ex.Message);
                Assert.Contains("404", ex.Message);
            }
        }

    }
}
