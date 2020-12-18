using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models.Infrastructure;
using Models.Infrastructure.IntegrationEvents;
using Models.Domain.Events;
using Models.Domain.Aggregates;

namespace Models.Api.EventHandlers
{
    public class ModelsCreatedIntegrationEventHandler : IEventHandler<ModelsCreatedIntegrationEvent>
    {
        private readonly IModelsEntityRepository _entities;
        // private readonly ILogger _logger;

        public ModelsCreatedIntegrationEventHandler(IModelsEntityRepository entities)
        {
            // _logger = logger;
            _entities = entities;
        }

        public Task Handle(ModelsCreatedIntegrationEvent @event)
        {
            // _logger.LogInformation("Created new transfer : " + @event.Amount);
            _entities.Create(new ModelsEntity(@event.ModelsID));

            return Task.CompletedTask;
        }
    }
}
