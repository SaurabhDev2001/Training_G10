using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CalculatorSystemTests
{
    public class CalculatorTests : IClassFixture<WebApplicationFactory<CalculatorApplication.Program>>
    {
        private readonly HttpClient _client;

        public CalculatorTests(WebApplicationFactory<CalculatorApplication.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Add_ShouldReturnCorrectResult()
        {
            var response = await _client.GetAsync("/api/calculator/add?a=5&b=3");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ResultDto>();
            Assert.Equal(8, result.Result);
        }

        [Fact]
        public async Task Post_Add_ShouldReturnCorrectResult()
        {
            var request = new { A = 10, B = 4 };
            var response = await _client.PostAsJsonAsync("/api/calculator/add", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ResultDto>();
            Assert.Equal(14, result.Result);
        }

        [Fact]
        public async Task Post_Add_ShouldReturnError_WhenBodyIsMissing()
        {
            var response = await _client.PostAsync("/api/calculator/add", null);
            Assert.False(response.IsSuccessStatusCode);
        }

        private class ResultDto
        {
            public int Result { get; set; }
        }
    }
}