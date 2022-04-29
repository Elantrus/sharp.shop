using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Customers.Application;
using WebApi.Features.Metrics.Application;
using WebApi.Features.Reviews.Application;
using Xunit;

namespace Tests.Integration.Features.Metric;

public class TestGetProductMetric
{
    private readonly TestServerFixture _fixture;

    public TestGetProductMetric()
    {
        _fixture = new TestServerFixture();
    }
    
    [Fact]
    public async Task Product_Metric_Score_Should_Increase()
    {
        await _fixture.CreateLoginAndSetHeader("createreview@gmail.com");
        var createReviewCommand = new CreateReview.Command
        {
            Description = "Arrived very fast, and has a great quality",
            Score = 5,
            Title = "Very good product"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/review", createReviewCommand);

        response.EnsureSuccessStatusCode();
        
        var metricResponse = await _fixture.Client.GetAsync("/api/metric");

        metricResponse.EnsureSuccessStatusCode();

        var metricString = await metricResponse.Content.ReadAsStringAsync();

        var metricData = JsonConvert.DeserializeObject<GetProductMetric.Result>(metricString);

        metricData.Score.ShouldBeGreaterThan(0);
    }
}