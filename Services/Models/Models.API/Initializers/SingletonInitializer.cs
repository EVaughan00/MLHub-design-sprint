
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.SeedWork;
using BuildingBlocks.Common.Events;
using Models.Domain.Events;
using Models.Api.EventHandlers;
using Models.Infrastructure.IntegrationEvents;

namespace Models.API.Initializers
{

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            services.AddTransient<IDatabaseContext, MongoDbContext>();

            // Events and event handlers
            services.AddTransient<ModelsCreatedIntegrationEventHandler>();
            services.AddTransient<IEventHandler<ModelsCreatedIntegrationEvent>, ModelsCreatedIntegrationEventHandler>();

        }
    }
}
