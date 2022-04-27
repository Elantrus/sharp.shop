using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApi.Features.Authentication.Application;
using WebApi.Features.Customers.Application;

namespace Tests.Utilities;

public class TestServerFixture 
{
    public readonly HttpClient Client;
    
    public TestServerFixture()
    {
        var webFactory = new WebApplicationFactory<Program>();

        Client = webFactory.CreateDefaultClient();
    }
    
    public async Task CreateLoginAndSetHeader(string email)
    {
        var command = new CreateCustomer.Command
        {
            Email = email,
            Name = "Lazaro",
            SurName = "Junior Silva",
            Password = "v3r%StroNgp4ssw0rd"
        };

        var response = await Client.PostAsJsonAsync("/api/customer", command);

        response.EnsureSuccessStatusCode();
        
        var deviceIdMoc = Guid.NewGuid().ToString();
        
        var loginCommand = new CustomerAuthentication.Command
        {
            Email = email,
            Password = "v3r%StroNgp4ssw0rd",
            DeviceId =deviceIdMoc
        };

        var loginResponse = await Client.PostAsJsonAsync("/api/authentication", loginCommand);

        loginResponse.EnsureSuccessStatusCode();
        
        var responseAsString = await loginResponse.Content.ReadAsStringAsync();

        var responseData = JsonConvert.DeserializeObject<CustomerAuthentication.Result>(responseAsString);
        
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {responseData.Token}");
    }
    
}