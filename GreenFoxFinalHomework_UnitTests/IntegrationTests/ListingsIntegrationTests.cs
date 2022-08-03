using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GreenFoxFinalHomework.Database;
using System.Text;
using GreenFoxFinalHomework_UnitTests.IntegrationTests;

namespace GreenFoxFinalHomework.IntegrationTests.ListingsIntegrationTests
{
    public class ListingsControllerTests
    {
    [Fact]
        public async void UnauthorizedResponseIfUserIdNotFound()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            int id = 35423;
            var response = await httpClient.GetAsync($"listings/{id}");
            var expectedStatusCode = 401;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}


