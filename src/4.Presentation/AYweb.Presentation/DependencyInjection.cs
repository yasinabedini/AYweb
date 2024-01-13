using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Ayweb.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddDbContext<AyWebDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-AyWeb2;integrated Security=true;TrustServerCertificate=True"));

        return services;
    }
}
