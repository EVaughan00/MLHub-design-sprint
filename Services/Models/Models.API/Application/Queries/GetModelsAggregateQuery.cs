using BuildingBlocks.Common;
using Models.Domain;
using Models.API.DTO;
using System.Collections.Generic;

namespace Models.API.Queries
{
    public class GetModelsAggregateQuery : Query<List<ModelsAggregateResponseDTO>>
    {
        public string modelsID { get; set; }
    }
}