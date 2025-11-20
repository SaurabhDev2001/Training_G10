using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class MultiplySystemTests : IClassFixture<TestServerFixture>
{
    private readonly HttpClient _client;

    public MultiplySystemTests(TestServerFixture fixture)
    {
        _client = fixture.Client;
    }

    [Fact]
    public async Task Multiply_ValidNumbers_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/Calculator/Multiply?number1=5&number2=3");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        Assert.Equal("15", result);
    }

    [Fact]
    public async Task Multiply_InvalidNumbers_ReturnsBadRequest()
    {
        var response = await _client.GetAsync("/Multiply?number1=abc&number2=3");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}