using NLog.Web;
using Infra.Interfaces;
using Infra.DataConnector;
using SimianApplication.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SimianApplication.Helpers.Filters;
using Prometheus;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SimianApplication.Helpers.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidationFilter));
    options.Filters.Add(typeof(NotificationFilter));
}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(typeof(Program).Assembly));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration["ConnectionStrings:postgree"], healthQuery: "SELECT 1;", failureStatus: HealthStatus.Degraded, name: "Postgre Database").ForwardToPrometheus()
    .AddMongoDb(builder.Configuration["ConnectionStrings:mongo"], name: "Mongo Log").ForwardToPrometheus()
    .ForwardToPrometheus();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
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

/*INICIO DA CONFIGURA��O - PROMETHEUS*/
// Custom Metrics to count requests for each endpoint and the method
var counter = Metrics.CreateCounter("SimianApplicationEndpointCounter", "Counts requests to the SimianApplication API endpoints",
    new CounterConfiguration
    {
        LabelNames = new[] { "method", "endpoint" }
    });

app.Use((context, next) =>
{
    counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
    return next();
});

// Use the prometheus middleware
app.UseMetricServer();
app.UseHttpMetrics();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

/*FIM DA CONFIGURA��O - PROMETHEUS*/

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
