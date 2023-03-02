using Domain.Abstractions;
using Domain.DTO.IsSimianDTO.Validators;
using Domain.DTO.IsSimianDTO;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation;
using Infra.Repositories;
using Service.Implementations;
using Service.Services;
using Domain.Interfaces.Notifications;
using Domain.Notifications;

namespace SimianApplication.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
            services.AddScoped<ISimianRepository, SimianRepository>();
            services.AddScoped<ISimianCalcRepository, SimianCalcRepository>();
            services.AddScoped<IStatsService, StatsService>();
            services.AddScoped<ISimianService, SimianService>();
            services.AddScoped<ISimianPatternsExecute, SimianPatternsExecute>();

            services.AddScoped<SimianPatternAbstract, DiagonalSimianPattern>();
            services.AddScoped<SimianPatternAbstract, HorizontalSimianPattern>();
            services.AddScoped<SimianPatternAbstract, VerticalSimianPattern>();

            services.AddTransient<IValidator<IsSimianRequestDTO>, IsSimianValidator>();

            return services;
        }
    }
}
