using System.Reflection;
using MediatR;

namespace WebApi.Configuration.IoC;

public static class MediatorModule
{
    public static void AddMediator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
    }
}