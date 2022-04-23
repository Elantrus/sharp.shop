using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Product.Application;
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
    public async Task Should_Have_Product()
    {
        var command = new GetLatestProduct.Command();

        var response = await _fixture.Client.GetAsync("/api/product");

        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<GetLatestProduct.Result>(stringResponse);

        result.ShouldNotBeNull();
        result.ProductDescription.ShouldNotBeNull();
        result.ProductId.ShouldNotBeNull();
        result.ProductPrice.ShouldBeGreaterThan(0);
    }
}