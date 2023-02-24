using Domain.Interfaces.Services;
using Service.Services;
using Service.Implementations;
using Domain.Abstractions;
using NLog.Web;
using Microsoft.Extensions.Configuration;
using System.Data;
using Infra.Interfaces;
using Infra.DataConnector;
using SimianApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddScoped<IDbConnector>(db => new PostgreeConnector(builder.Configuration["ConnectionStrings:postgree"]));
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
