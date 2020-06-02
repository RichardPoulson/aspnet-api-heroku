using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aspnet_api_heroku.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        private static TestServer _server;
        private static HttpClient _client;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Executes once after the test run. (Optional)
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
        }

        [TestCleanup]
        public void TearDown()
        {
            // Runs after each test. (Optional)
        }

        [TestMethod]
        public async Task ArticleItems_SuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("api/ArticleItems");
            // Assert
            response.EnsureSuccessStatusCode();
            //var responseString = await response.Content.ReadAsStringAsync();
            //Assert.Equal("[]", responseString);
        }

        [TestMethod]
        public async Task Swagger_SuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("swagger/index.html");
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
