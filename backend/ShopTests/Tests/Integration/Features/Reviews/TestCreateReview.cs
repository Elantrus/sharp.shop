using System.Net.Http.Json;
using System.Threading.Tasks;
using Tests.Utilities;
using WebApi.Features.Reviews;
using WebApi.Features.Reviews.Application;
using Xunit;

namespace Tests.Integration.Features.Reviews;

public class TestCreateReview
{
    private readonly TestServerFixture _fixture;

    public TestCreateReview()
    {
        _fixture = new TestServerFixture();
    }

    [Fact]
    public async Task Review_Should_Be_Created()
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
    }

    [Fact]
    public async Task Should_Be_At_Least_One_Review()
    {
        
    }
}