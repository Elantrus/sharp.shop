using System.Reflection;

namespace WebApi.Security;

public static class RoleProvider
{
    public static string CustomerRoles()
    {
        var modules = Assembly.GetExecutingAssembly().Modules;

        throw new NotImplementedException();
    }
}