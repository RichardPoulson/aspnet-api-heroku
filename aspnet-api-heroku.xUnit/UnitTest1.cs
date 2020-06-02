using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace aspnet_api_heroku.xUnit
{
    public class IntegrationTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public IntegrationTest1()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ArticleItems_SuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("api/ArticleItems");
            // Assert
            response.EnsureSuccessStatusCode();
            //var responseString = await response.Content.ReadAsStringAsync();
            //Assert.Equal("[]", responseString);
        }

        [Fact]
        public async Task Swagger_SuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("swagger/index.html");
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
