using AYweb.Infrastructure;
using AYweb.Domain;
using AYweb.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
