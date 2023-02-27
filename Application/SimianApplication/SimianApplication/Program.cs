using NLog.Web;
using Infra.Interfaces;
using Infra.DataConnector;
using SimianApplication.Extensions;
using FluentValidation.AspNetCore;
using System.Reflection;
using Domain.DTO.IsSimianDTO.Validators;
using Domain.DTO.IsSimianDTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimianApplication.Helpers.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidationMiddleware));
}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(typeof(Program).Assembly));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddTransient<IValidator<IsSimianRequestDTO>, IsSimianValidator>();

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
