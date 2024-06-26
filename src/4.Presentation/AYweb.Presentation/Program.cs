using AYweb.Domain;
using AYweb.Infrastructure;
using AYweb.Application;
using AYweb.Domain.Models.Service.Entities;
using AYweb.Presentation;
using NWebsec;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();

builder.Services.AddHsts(t =>
{
    t.MaxAge = TimeSpan.FromDays(30);
    t.Preload = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseCors(t =>
{
    t.DisallowCredentials();
});

app.UseHsts();

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseExceptionHandler("/Error");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         ).RequireAuthorization();
app.MapRazorPages();
app.Run();
