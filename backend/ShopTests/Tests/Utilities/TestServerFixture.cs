using System.Net.Http;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Utilities;

public class TestServerFixture 
{
    public readonly HttpClient Client;
    
    public TestServerFixture()
    {
        var webFactory = new WebApplicationFactory<Program>();

        Client = webFactory.CreateDefaultClient();
    }
    
}