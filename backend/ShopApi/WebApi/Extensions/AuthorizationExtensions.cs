using System.Security.Claims;

namespace WebApi.Extensions;

public static class AuthorizationExtensions
{
    public static Guid GetCustomerId(this ClaimsPrincipal User)
    {
        return Guid.Parse(User.Claims.First(i => i.Type == "Id").Value);
    }
}