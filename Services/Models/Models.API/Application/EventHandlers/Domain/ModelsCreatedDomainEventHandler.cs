using System.Threading;
using System.Threading.Tasks;
using Models.Domain.Events;
using BuildingBlocks.Common.Events;
using Microsoft.Extensions.Logging;

namespace Models.API.Application.DomainEventHandlers
{
    public class ModelsCreatedDomainEventHandler : DomainEventHandler<ModelsCreatedDomainEvent>
    {
        private readonly ILogger<ModelsCreatedDomainEventHandler> _logger;
        public ModelsCreatedDomainEventHandler(ILogger<ModelsCreatedDomainEventHandler> logger)
        {
            _logger = logger;

        }
        public override async Task Handle(ModelsCreatedDomainEvent request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _logger.LogInformation("Models created domain event");

        }
    }
}