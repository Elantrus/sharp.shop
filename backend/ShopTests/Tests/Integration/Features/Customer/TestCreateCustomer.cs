using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Authentication.Application;
using WebApi.Features.Customers.Application;
using Xunit;

namespace Tests.Integration.Features.Customer;

public class TestCreateCustomer
{
    private readonly TestServerFixture _fixture;

    public TestCreateCustomer()
    {
        _fixture = new TestServerFixture();
    }

    [Fact]
    public async Task Customer_Should_Be_Created()
    {
        var command = new CreateCustomer.Command
        {
            Email = "customershouldbecreated@sharp.io",
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "v3r%StroNgp4ssw0rd"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/customer", command);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Customer_Create_Password_Should_Be_Invalid()
    {
        var command = new CreateCustomer.Command
        {
            Email = "customerpasswordinvalid@sharp.io",
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "notstrongPassword"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/customer", command);

        response.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
    }
    
    
    
}