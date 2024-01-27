using AIPFramework.Session;
using AYweb.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddDbContext<AyWebDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-AyWeb2;integrated Security=true;TrustServerCertificate=True"));

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
           
            services.AddAuthentication();

            services.AddTransient<ISessionAdaptor, SessionAdaptor>();
            services.AddSession(t =>
            {
                t.IOTimeout = TimeSpan.FromDays(15);
                t.IdleTimeout = TimeSpan.FromDays(15);                                
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/LogOut";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

            });

            return services;
        }
    }
}
