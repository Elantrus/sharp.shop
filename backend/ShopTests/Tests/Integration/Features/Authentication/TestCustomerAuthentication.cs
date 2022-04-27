using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Authentication.Application;
using WebApi.Features.Customers.Application;
using Xunit;

namespace Tests.Integration.Features.Authentication;

public class TestCustomerAuthentication
{
    private readonly TestServerFixture _fixture;

    public TestCustomerAuthentication()
    {
        _fixture = new TestServerFixture();
    }
    
    [Fact]
    public async Task Customer_Login_Should_Return_Jwt()
    {
        var command = new CreateCustomer.Command
        {
            Email = "customerjwt@sharp.io",
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "v3r%StroNgp4ssw0rd"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/customer", command);

        response.EnsureSuccessStatusCode();
        
        var deviceIdMoc = Guid.NewGuid().ToString();

        var loginCommand = new CustomerAuthentication.Command
        {
            Email = "customerjwt@sharp.io",
            Password = "v3r%StroNgp4ssw0rd",
            DeviceId = deviceIdMoc
        };

        var loginResponse = await _fixture.Client.PostAsJsonAsync("/api/authentication", loginCommand);

        loginResponse.EnsureSuccessStatusCode();

        var responseAsString = await loginResponse.Content.ReadAsStringAsync();

        var responseData = JsonConvert.DeserializeObject<CustomerAuthentication.Result>(responseAsString);
        
        responseData.Token.ShouldNotBeNull();
        responseData.RefreshToken.ShouldNotBe(default);
    }
    
    [Fact]
    public async Task Customer_Refresh_Should_Return_Jwt()
    {
        var command = new CreateCustomer.Command
        {
            Email = "customerrefreshjwt@sharp.io",
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "v3r%StroNgp4ssw0rd"
        };

        var response = await _fixture.Client.PostAsJsonAsync("/api/customer", command);

        response.EnsureSuccessStatusCode();

        var deviceIdMoc = Guid.NewGuid().ToString();
        
        var loginCommand = new CustomerAuthentication.Command
        {
            Email = "customerrefreshjwt@sharp.io",
            Password = "v3r%StroNgp4ssw0rd",
            DeviceId =deviceIdMoc
        };

        var loginResponse = await _fixture.Client.PostAsJsonAsync("/api/authentication", loginCommand);

        loginResponse.EnsureSuccessStatusCode();
        
        var responseAsString = await loginResponse.Content.ReadAsStringAsync();

        var responseData = JsonConvert.DeserializeObject<CustomerAuthentication.Result>(responseAsString);
        
        
        var refreshCommand = new RefreshAuthentication.Command
        {
            RefreshToken = responseData.RefreshToken,
            DeviceId = deviceIdMoc
        };

        var refreshResponse = await _fixture.Client.PostAsJsonAsync("/api/authentication/refresh", refreshCommand);

        refreshResponse.EnsureSuccessStatusCode();
        
        var refreshResponseAsString = await loginResponse.Content.ReadAsStringAsync();

        var refreshResponseData = JsonConvert.DeserializeObject<RefreshAuthentication.Result>(refreshResponseAsString);
        
        refreshResponseData.Token.ShouldNotBeNullOrWhiteSpace();
    }
}