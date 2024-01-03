using AYweb.Core.Caching;
using AYweb.Core.Serializer;
using AYweb.Core.Services;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Zamin.Extensions.Caching.Abstractions;
using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

#region IOC
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(t =>
{
    t.IOTimeout = TimeSpan.FromDays(15);    
});

builder.Services.AddHttpContextAccessor();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


//builder.Services.AddSingleton<ICacheAdaptor, DistributedCacheAdaptor>();
builder.Services.AddSingleton<ISessionAdaptor, SessionAdaptor>();
builder.Services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPlanService, PlanService>();
builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();
#endregion

#region Context
builder.Services.AddDbContext<AYWebDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AyWebConnectionString"), t => t.MigrationsAssembly("AYweb.Web")));
#endregion

builder.Services.AddAuthentication();

#region AddAuthentication
builder.Services.AddAuthentication(options =>
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
#endregion



var app = builder.Build();


app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"            
          ).RequireAuthorization();

app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePagesWithReExecute("/Error/Error");
app.Run();
