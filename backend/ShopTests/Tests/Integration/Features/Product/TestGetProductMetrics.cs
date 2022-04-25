using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Products.Application;
using Xunit;

namespace Tests.Integration.Features.Product;

public class TestGetProductMetrics
{
    private readonly TestServerFixture _fixture;

    public TestGetProductMetrics()
    {
        _fixture = new TestServerFixture();
    }

    [Fact]
    public async Task Product_Should_Have_Metric()
    {
        var response = await _fixture.Client.GetAsync("/api/product/1/metrics");

        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<GetProductMetrics.Result>(stringResponse);

        result.ShouldNotBeNull();
    }
    
    
}