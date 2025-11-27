using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CalculatorAppTests.IntegrationTests
{
    public class AdditionControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AdditionControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // Positive Test - GET Add
        [Fact]
        public async Task GetAdd_ShouldReturnCorrectResult()
        {
            var url = "/api/Addition/add?number1=10&number2=20";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content), "Response content is empty");

            var result = await response.Content.ReadFromJsonAsync<double>();
            Assert.Equal(30, result);
        }

        [Fact]
        public async Task GetAdd_ShouldReturnDefaultBehavior_WhenParametersAreMissing()
        {
            var url = "/api/Addition/add?number1=10";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content), "Response content is empty");

            var result = await response.Content.ReadFromJsonAsync<double>();
            Assert.Equal(10, result);
        }
    }
}