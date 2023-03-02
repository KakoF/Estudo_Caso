using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;

namespace SimianApplication.Extensions
{
    public static class MetricsExtensions
    {
        public static IServiceCollection RegisterMetrics(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddHealthChecks()
            .AddNpgSql(builder.Configuration["ConnectionStrings:postgree"], healthQuery: "SELECT 1;", failureStatus: HealthStatus.Degraded, name: "Postgre Database")
            .AddMongoDb(builder.Configuration["ConnectionStrings:mongo"], name: "Mongo Log")
            .ForwardToPrometheus();

            return services;
        }
    }
}
