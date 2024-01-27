using AIPFramework.Serializer;
using AIPFramework.Session;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using Zamin.Extensions.DependencyInjection;

namespace AYweb.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       
      var assembly = typeof(DependencyInjection).Assembly;

        services.AddZaminAutoMapperProfiles(option =>
        {
            option.AssmblyNamesForLoadProfiles = assembly.ToString();
        });

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient<ISessionAdaptor, SessionAdaptor>();
        services.AddTransient<IJsonSerializer, NewtonSoftSerializer>();

        return services;
    }
}
