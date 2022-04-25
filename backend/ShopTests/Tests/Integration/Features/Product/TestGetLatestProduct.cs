using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Products.Application;
using Xunit;

namespace Tests.Integration.Features.Product;

public class TestGetLatestProduct: IClassFixture<TestServerFixture>
{
    private readonly TestServerFixture _fixture;

    public TestGetLatestProduct()
    {
        _fixture = new TestServerFixture();
    }

    [Fact]
    public async Task Product_Should_Exist()
    {
        var response = await _fixture.Client.GetAsync("/api/product");

        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<GetLatestProduct.Result>(stringResponse);

        result.ShouldNotBeNull();
        
    }

    [Fact]
    public async Task Product_Should_Have_Props()
    {
        var response = await _fixture.Client.GetAsync("/api/product");

        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<GetLatestProduct.Result>(stringResponse);
        
        result.Description.ShouldNotBeNull();
        result.Id.ShouldNotBeNull();
        result.SalePrice.ShouldBeGreaterThan(0);
    }
}