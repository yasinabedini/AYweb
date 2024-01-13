using AYweb.Domain;
using AYweb.Infrastructure;
using AYweb.Application;
using AYweb.Presentation;
using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AyWebDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-AyWeb2;integrated Security=true;TrustServerCertificate=True"));

builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddPresentation();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
