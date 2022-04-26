using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Customers.Application;
using WebApi.Features.Security.Application;
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
            Email = "test@sharp.io",
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
            Email = "test@sharp.io",
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "notstrongPassword"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/customer", command);

        response.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
    }
    
    [Fact]
    public async Task Customer_Login_Should_Return_Jwt()
    {
        var command = new CreateCustomer.Command
        {
            Email = "test@sharp.io",
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "v3r%StroNgp4ssw0rd"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/customer", command);

        response.EnsureSuccessStatusCode();
        
        var loginCommand = new CustomerAuthentication.Command
        {
            Email = "test@sharp.io",
            Password = "v3r%StroNgp4ssw0rd"
        };

        var loginResponse = await _fixture.Client.PostAsJsonAsync("/api/authentication", loginCommand);

        loginResponse.EnsureSuccessStatusCode();
    }
    
}