using System.Net;
using System.Net.Http.Json;
using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace CalculatorAppTests.IntegrationTests
{
    public class CalculatorControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CalculatorControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // Positive Test - GET Add
        [Fact]
        public async Task GetAdd_ShouldReturnCorrectResult()
        {
            var response = await _client.GetAsync("/api/Calculator/add?number1=10&number2=20");
            var result = await response.Content.ReadFromJsonAsync<double>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(30, result);
        }

        // Negative Test - GET Add with missing query params
        [Fact]
        public async Task GetAdd_ShouldReturnDefaultBehavior_WhenParametersAreMissing()
        {
            var response = await _client.GetAsync("/api/Calculator/add?number1=10");
            var result = await response.Content.ReadFromJsonAsync<double>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(10, result);
        }

        // Positive Test - POST Add
        [Fact]
        public async Task PostAdd_ShouldReturnCorrectResult()
        {
            var request = new CalculationRequest { Number1 = 5, Number2 = 7 };

            var response = await _client.PostAsJsonAsync("/api/Calculator/add", request);
            var result = await response.Content.ReadFromJsonAsync<double>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(12, result);
        }

        // Negative Test - POST Add with null body
        [Fact]
        public async Task PostAdd_ShouldReturn500_WhenRequestBodyIsNull()
        {
            var content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Calculator/add", content);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        // Positive Test - GET Subtract
        [Fact]
        public async Task GetSubtract_ShouldReturnCorrectResult()
        {
            var response = await _client.GetAsync("/api/Calculator/subtract?number1=20&number2=5");
            var result = await response.Content.ReadFromJsonAsync<double>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(15, result);
        }

        // Negative Test - GET Subtract with invalid input
        [Fact]
        public async Task GetSubtract_ShouldReturnDefaultBehavior_WhenInputIsInvalid()
        {
            var response = await _client.GetAsync("/api/Calculator/subtract?number1=abc&number2=10");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<double>();
            Assert.Equal(-10, result); // because 0 - 10
        }

        // Positive Test - POST Subtract
        [Fact]
        public async Task PostSubtract_ShouldReturnCorrectResult()
        {
            var request = new CalculationRequest { Number1 = 20, Number2 = 8 };

            var response = await _client.PostAsJsonAsync("/api/Calculator/subtract", request);
            var result = await response.Content.ReadFromJsonAsync<double>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(12, result);
        }

        // Negative Test - POST Subtract with null body (forces controller catch)
        [Fact]
        public async Task PostSubtract_ShouldReturn500_WhenRequestBodyIsNull()
        {
            var content = new StringContent("", System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Calculator/subtract", content);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
