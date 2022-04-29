
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
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
        await _fixture.CreateLoginAndSetHeader("createreview@gmail.com");
        var createReviewCommand = new CreateReview.Command
        {
            Description = "Arrived very fast, and has a great quality",
            Score = 5,
            Title = "Very good product"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/review", createReviewCommand);

        response.EnsureSuccessStatusCode();
        
        
        var getReviewsResponse = await _fixture.Client.GetAsync("/api/review");

        getReviewsResponse.EnsureSuccessStatusCode();

        var getReviewsDataSerialized = await getReviewsResponse.Content.ReadAsStringAsync();

        var getReviewsData = JsonConvert.DeserializeObject<GetReviews.Result>(getReviewsDataSerialized);

        getReviewsData.ShouldNotBeNull();
        getReviewsData.Reviews.ShouldNotBeNull();
        var firstReview = getReviewsData.Reviews.First();

        firstReview.Description.ShouldNotBeNullOrEmpty();
        firstReview.Id.ShouldBeGreaterThan(0);
        firstReview.Score.ShouldBeGreaterThan(0);
        firstReview.Title.ShouldNotBeNullOrEmpty();
        firstReview.CustomerName.ShouldNotBeNullOrEmpty();
    }
}