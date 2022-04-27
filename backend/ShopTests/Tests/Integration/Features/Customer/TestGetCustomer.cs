using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Tests.Utilities;
using WebApi.Features.Authentication.Application;
using WebApi.Features.Customers.Application;
using Xunit;

namespace Tests.Integration.Features.Customer;

public class TestGetCustomer
{
    private readonly TestServerFixture _fixture;

    public TestGetCustomer()
    {
        _fixture = new TestServerFixture();
    }

    [Fact]
    public async Task Customer_Get_Should_Return_Data()
    {
        await _fixture.CreateLoginAndSetHeader("customerget@sharp.io");
        var response = await _fixture.Client.GetAsync("/api/customer");

        response.EnsureSuccessStatusCode();

        var responseAsString = await response.Content.ReadAsStringAsync();

        var responseData = JsonConvert.DeserializeObject<GetCustomer.Result>(responseAsString);

        responseData.Email.ShouldNotBeNullOrWhiteSpace();
        responseData.Name.ShouldNotBeNullOrWhiteSpace();
        responseData.SurName.ShouldNotBeNullOrWhiteSpace();
    }
    
}