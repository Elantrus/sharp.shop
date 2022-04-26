using System.Security.Claims;

namespace WebApi.Extensions;

public static class AuthorizationExtensions
{
    public static long GetCustomerId(this ClaimsPrincipal User)
    {
        return long.Parse(User.Claims.First(i => i.Type == "Id").Value);
    }
}