using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Models.Infrastructure;
using Models.Domain.Aggregates;
using Models.Domain.Events;

namespace Models.API.Commands
{
    public class CreateModelsAggregateCommandHandler : CommandHandler<CreateModelsAggregateCommand, bool>
    {

        private readonly ILogger<CreateModelsAggregateCommandHandler> _logger;
        private readonly IModelsEntityRepository _models;

        public CreateModelsAggregateCommandHandler(ILogger<CreateModelsAggregateCommandHandler> logger, IModelsEntityRepository entities)
        {
            _models = entities;
            _logger = logger;
        }

        public override async Task<bool> Handle(CreateModelsAggregateCommand command, CancellationToken token)
        {
            _logger.LogInformation("Models aggregate created with name: " + command.name);

            var model = new ModelsEntity(command.name);
            
            model.setVisibility(Visibility.FromName<Visibility>(command.visibility));
            model.setClassifiction(Classification.FromName<Classification>(command.classification));

            _models.Create(model);

            if (_models.GetById(model.Id) == null) _logger.LogInformation("Could not create models entity: " + command.name); 

            await Task.CompletedTask;

            return true;
        }
    }
}