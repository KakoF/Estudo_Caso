using Domain.Abstractions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Notification;
using Infra.Repositories;
using Service.Implementations;
using Service.Services;

namespace SimianApplication.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
            //services.AddMvc(options => options.Filters.Add<NotificationMiddleware>());

            services.AddScoped<ISimianRepository, SimianRepository>();
            services.AddScoped<ISimianService, SimianService>();
            services.AddScoped<ISimianPatternsExecute, SimianPatternsExecute>();

            services.AddScoped<SimianPatternAbstract, DiagonalSimianPattern>();
            services.AddScoped<SimianPatternAbstract, HorizontalSimianPattern>();
            services.AddScoped<SimianPatternAbstract, VerticalSimianPattern>();
           
            return services;
        }
    }
}
