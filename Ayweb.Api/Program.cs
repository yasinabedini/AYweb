using AYweb.Application;
using AYweb.Domain;
using AYweb.Domain.Models.Service.Entities;
using AYweb.Infrastructure;
using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AyWebDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-AyWeb2;integrated Security=true;TrustServerCertificate=True"));

// Add services to the container.
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
