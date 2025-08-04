using Customer.Application.Interfaces;
using Customer.Application.Repositories;
using MassTransit;
using Shared.Contracts;

namespace Customer.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMq:Host"], "/", h =>
                    {
                        h.Username(configuration["RabbitMq:Username"]);
                        h.Password(configuration["RabbitMq:Password"]);
                    });

                    cfg.ConfigureEndpoints(context);
                    cfg.Publish<UserCreatedEvent>(e =>
                    {
                        e.Durable = true;
                    });

                });
            });

            return services;
        }
    }
}
