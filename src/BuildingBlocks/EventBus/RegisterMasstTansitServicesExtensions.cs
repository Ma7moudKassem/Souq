

namespace BuildingBlocks.EventBus
{
    public static class RegisterMasstTansitServicesExtensions
    {
        /// <summary>
        /// Register MassTransit and RabbitMq Services to DI Container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterMasstTansitServices(this IServiceCollection services, BusConfig conf, List<Type>? consumerTypes = null, List<Type>? requestResponseTypes = null)
        {
            services.AddMassTransit(x =>
            {
                if (consumerTypes is not null && consumerTypes.Count != 0)
                    consumerTypes.ForEach(consumer => x.AddConsumer(consumer));

                if (requestResponseTypes is not null && requestResponseTypes.Count != 0)
                    requestResponseTypes.ForEach(requestResponse => x.AddRequestClient(requestResponse));

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);

                    cfg.Host(conf.QueueUrl, "/", h =>
                    {
                        h.Username(conf.Username);
                        h.Password(conf.Password);
                    });

                    cfg.ExchangeType = conf.ExchangeType;
                });
            });

            return services;
        }
    }
}