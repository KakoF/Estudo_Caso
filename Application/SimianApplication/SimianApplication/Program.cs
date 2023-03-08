using NLog.Web;
using SimianApplication.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SimianApplication.Helpers.Filters;
using Prometheus;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using SimianApplication.Helpers.Middleware;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;

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
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

/*builder.Host.UseMetricsWebTracking();
builder.Host.UseMetrics(opt =>
{
    opt.EndpointOptions = endpointOptions =>
    {
        endpointOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
        endpointOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
        endpointOptions.EnvironmentInfoEndpointEnabled = false;
    };
});

*/

builder.Services.RegisterServices(builder);
builder.Services.RegisterMetrics(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpMetrics();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

/*FIM DA CONFIGURA��O - PROMETHEUS*/

app.UseAuthorization();

app.MapControllers();
app.UseMetricsAllEndpoints();
app.UseMetricsAllMiddleware();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
