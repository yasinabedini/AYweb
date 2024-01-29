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

            #region DbContext
            services.AddDbContext<AyWebDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-AyWeb2;integrated Security=true;TrustServerCertificate=True"));
            #endregion

            services.AddHttpContextAccessor();

            #region Razor And Views
            services.AddControllersWithViews();

            services.AddRazorPages(); 
            #endregion

            #region Session
            services.AddTransient<ISessionAdaptor, SessionAdaptor>();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(15);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion

            #region Authentication And Cookie

            services.AddAuthentication();

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
                    options.Cookie = new CookieBuilder()
                    {
                        SecurePolicy = CookieSecurePolicy.Always,
                        HttpOnly = true,
                        SameSite = SameSiteMode.None
                    };
                });
            #endregion

            return services;
        }
    }
}
