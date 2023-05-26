using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace MDT.Web.Test
{
    public class TestHomeController
    {
        private HttpClient _client { get; }
        public TestServer Server { get; }
        public TestHomeController()
        {
            var builder = new WebHostBuilder()
                            .UseEnvironment("Testing")
                            .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: true))
                            .UseStartup<TestStartup>();

            Server = new TestServer(builder);

            this._client = Server.CreateClient();
        }


        [Fact]
        public async Task GetFood()
        {
            var response = await _client.GetAsync($"api/Home/GetFood");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            String jsonResponse = await response.Content.ReadAsStringAsync();
            JObject foodResponse = JObject.Parse(jsonResponse);
            Assert.Equal("Burger", foodResponse["food"]);
        }

        [Fact]
        public async Task GetFoo()
        {
            var foo = "foo";
            var response = await _client.GetAsync($"api/Home/GetFoo?foo={foo}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            JObject fooResponse = JObject.Parse(jsonResponse);
            Assert.Equal(foo, fooResponse["foo"]);
        }

        [Fact]
        public async Task GetEmpleados()
        {
            var response = await _client.GetAsync($"api/Home/GetEmpleados");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            JObject fooResponse = JObject.Parse(jsonResponse);
            Assert.True(jsonResponse.Length > 0);
        }

        [Fact]
        public async Task GetEmpleadoPorCodigo()
        {
            var codigo = "12345";
            var response = await _client.GetAsync($"api/Home/GetEmpleado?codigo={codigo}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            JObject empleadoResponse = JObject.Parse(jsonResponse);
            Assert.Equal(codigo, empleadoResponse["empleado"]["codigo"]);
        }

    }
}
