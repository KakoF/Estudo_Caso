using App.Metrics;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;

namespace SimianApplication.Extensions
{
    public static class MetricsExtensions
    {
        public static IServiceCollection RegisterMetrics(this IServiceCollection services, WebApplicationBuilder builder)
        {
            /*services.Configure<KestrelServerOptions>(opt =>
            {
                opt.AllowSynchronousIO = true;
            });
            services.AddMetrics();*/

            var metrics = new MetricsBuilder().Configuration.Configure(opt =>
            {
                opt.AddServerTag();
                opt.AddEnvTag();
                opt.AddAppTag();
            }).OutputMetrics.AsPrometheusPlainText().Build();
            services.AddMetrics(metrics);
            services.AddMetricsReportingHostedService();
            services.AddMetricsEndpoints();
            services.AddMetricsTrackingMiddleware();


            services.AddHealthChecks()
            .AddNpgSql(builder.Configuration["ConnectionStrings:postgree"], healthQuery: "SELECT 1;", failureStatus: HealthStatus.Degraded, name: "Postgre Database")
            .AddMongoDb(builder.Configuration["ConnectionStrings:mongo"], name: "Mongo Log")
            .AddRedis(builder.Configuration["ConnectionStrings:redis:connection"], name: "Redis Database")
            .ForwardToPrometheus();

            return services;
        }
    }
}
