using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

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