using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Models.Infrastructure;
using Models.Domain.Aggregates;
using Models.API.DTO;
using System.Collections.Generic;

namespace Models.API.Queries
{
    public class GetModelsAggregateQueryHandler : QueryHandler<GetModelsAggregateQuery, List<ModelsAggregateResponseDTO>>
    {

        private readonly ILogger<GetModelsAggregateQueryHandler> _logger;
        private readonly IModelsEntityRepository _models;

        public GetModelsAggregateQueryHandler(ILogger<GetModelsAggregateQueryHandler> logger, IModelsEntityRepository models)
        {
            _models = models;
            _logger = logger;
        }

        public override async Task<List<ModelsAggregateResponseDTO>> Handle(GetModelsAggregateQuery query, CancellationToken token)
        {
            var modelsDTO = new List<ModelsAggregateResponseDTO>();
            
            foreach (ModelsEntity model in _models.GetAll())
                modelsDTO.Add(new ModelsAggregateResponseDTO(){
                    name = model.Name,
                    status = model.Status.ToString(),
                    visibility = model.Visibility.ToString(),
                    dateCreated = model.DateCreated.ToString(),
                    classification = model.Classification.ToString()
                });
        
            _logger.LogInformation("Getting models from database");

            await Task.CompletedTask;

            return modelsDTO;
        }
    }
}