using System.Threading.Tasks;
using Tests.Utilities;
using Xunit;

namespace Tests.Integration.Features.Reviews;

public class TestGetReviews
{
    private readonly TestServerFixture _fixture;

    public TestGetReviews()
    {
        _fixture = new TestServerFixture();
    }

    [Fact]
    public async Task Get_Review_Should_Be_Success()
    {
        
    }
    
}