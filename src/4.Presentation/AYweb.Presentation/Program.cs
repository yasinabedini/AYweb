using AYweb.Domain;
using AYweb.Application;
using AYweb.Infrastructure;
using Ayweb.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
