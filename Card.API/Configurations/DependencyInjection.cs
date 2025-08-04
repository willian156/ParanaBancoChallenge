using Card.Application.Consumers;
using Card.Application.Interfaces;
using Card.Application.Repositories;
using MassTransit;

namespace Card.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICardRepository, CardRepository>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreditProposalCreatedEventConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMq:Host"], "/", h =>
                    {
                        h.Username(configuration["RabbitMq:Username"]);
                        h.Password(configuration["RabbitMq:Password"]);
                    });

                    cfg.ReceiveEndpoint("card-creditproposal-created-queue", e =>
                    {
                        e.ConfigureConsumer<CreditProposalCreatedEventConsumer>(context);
                    });
                });
            });


            return services;
        }
    }
}

