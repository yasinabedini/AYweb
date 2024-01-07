using AYweb.Domain;
using AYweb.Infrastructure;
using AYweb.Application;
using AYweb.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddPresentation();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
